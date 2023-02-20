using AForge.Imaging.Filters;
using AForge.Imaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using AForge.Math.Geometry;
using AForge;
using System.Windows;
using ImageMagick;
using System.Drawing.Imaging;
using System.IO;
using MetadataExtractor.Formats.Exif.Makernotes;



namespace AutoFocuser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void goButton_Click(object sender, EventArgs e)
        {
            serialPort1.Write(stepsTextBox.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            trackBar1.Minimum = 1;
            trackBar1.Maximum = 4;
            trackBar1.SmallChange = 1;
            trackBar1.LargeChange = 1;
            trackBar1.UseWaitCursor = false;
            this.DoubleBuffered = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Load the BMP image from file
            Bitmap image = new Bitmap("C:\\Users\\mical\\Desktop\\test2.bmp");
            ProcessImage(image);
        }

        PictureBox org = new PictureBox();

        private void ProcessImage(Bitmap image)
        {
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = grayscaleFilter.Apply(image);
            AForge.Imaging.Filters.Threshold thresholdFilter = new AForge.Imaging.Filters.Threshold(100);
            Bitmap thresholdImage = thresholdFilter.Apply(grayImage);

            // Apply blob counter to detect objects in the image
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 10;
            blobCounter.MinWidth = 10;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            blobCounter.ProcessImage(thresholdImage);

            SimpleShapeChecker simpleShapeChecker = new SimpleShapeChecker();
            GrahamConvexHull grahamConvexHull = new GrahamConvexHull();
            float hfd=-1;
            // Get information about objects in the image
            Blob[] blobs = blobCounter.GetObjectsInformation();
            Bitmap starbg = null;
            foreach (Blob blob in blobs)
            {

                Graphics g = Graphics.FromImage(image);

                blobCounter.ExtractBlobsImage(thresholdImage, blob, true);
                Bitmap star = blob.Image.ToManagedImage();
                //AForge.Imaging.Filters.Invert invertFilter = new AForge.Imaging.Filters.Invert();
                //star = invertFilter.Apply(star);

                Rectangle expandedRectangle = new Rectangle(
                blob.Rectangle.X - 200,
                blob.Rectangle.Y - 200,
                blob.Rectangle.Width + 400,
                blob.Rectangle.Height + 400);

                // Ensure the expanded rectangle stays within the bounds of the original image
                expandedRectangle.Intersect(new Rectangle(0, 0, star.Width, star.Height));

                // Crop the image to just include the expanded bounding rectangle
                starbg = star.Clone(expandedRectangle, image.PixelFormat);


                Blob savedBlob = null;
                BlobCounter blobCounter2 = new BlobCounter();
                blobCounter2.FilterBlobs = true;
                blobCounter2.MinHeight = 10;
                blobCounter2.MinWidth = 10;
                blobCounter2.ObjectsOrder = ObjectsOrder.Size;
                blobCounter2.ProcessImage(starbg);
                Blob[] blobsInside = blobCounter2.GetObjectsInformation();
                foreach (Blob blobInside in blobsInside)
                {
                    savedBlob= blobInside;
                    List<IntPoint> edgePoints = blobCounter2.GetBlobsEdgePoints(savedBlob);
                    List<IntPoint> hull = grahamConvexHull.FindHull(edgePoints);
                    // Calculate desired circle diameter
                    int circleDiameter = 300;

                    // Calculate circle bounds
                    int circleRadius = circleDiameter / 2;
                    int circleX = (int)savedBlob.CenterOfGravity.X - circleRadius;
                    int circleY = (int)savedBlob.CenterOfGravity.Y - circleRadius;
                    hfd = CalcHfd(starbg, circleDiameter);
                    int circleXHFD = (int)(savedBlob.CenterOfGravity.X - hfd/2);
                    int circleYHFD = (int)(savedBlob.CenterOfGravity.Y - hfd/2);

                    using (Graphics gh = Graphics.FromImage(starbg))
                    {
                        gh.DrawEllipse(new Pen(Color.Red, 2), circleX, circleY, circleDiameter, circleDiameter);
                        gh.DrawEllipse(new Pen(Color.Green, 2), circleXHFD, circleYHFD, hfd, hfd);
                        gh.DrawPolygon(new Pen(Color.Blue, 3), hull.Select(p => new PointF(p.X, p.Y)).ToArray());
                    }
                }

                starbg.Save("C:\\Users\\mical\\Desktop\\testOutput15.bmp");

            }
            // Update picture box
            pictureBox1.Image = starbg;
            org.Image = starbg;
            image.Save("C:\\Users\\mical\\Desktop\\testOutput11.bmp");
            panel1.AutoScrollPosition = new System.Drawing.Point((int)blobs[0].CenterOfGravity.X - panel1.Width / 2, (int)blobs[0].CenterOfGravity.Y - panel1.Height / 2);
            hfdLabel.Text="HFD: "+hfd.ToString();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value != 0)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = ZoomPicture(org.Image, new System.Drawing.Size(trackBar1.Value, trackBar1.Value));
            }
        }

        System.Drawing.Image ZoomPicture(System.Drawing.Image img, System.Drawing.Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width),
                Convert.ToInt32(img.Height * size.Height));
            Graphics g = Graphics.FromImage(bm);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bm;
        }


        float CalcHfd(Bitmap inImage, int inOuterDiameter)
        {
            // Sum up all pixel values in whole circle
            float outerRadius = inOuterDiameter / 2f;
            float sum = 0, sumDist = 0;
            int centerX = (int)Math.Ceiling(inImage.Width / 2f);
            int centerY = (int)Math.Ceiling(inImage.Height / 2f);

            for (int x = 0; x < inImage.Width; x++)
            {
                for (int y = 0; y < inImage.Height; y++)
                {
                    if (InsideCircle(x, y, centerX, centerY, outerRadius))
                    {
                        sum += GetPixelValue(inImage, x, y);
                        sumDist += GetPixelValue(inImage, x, y) *
                                   (float)Math.Sqrt(Math.Pow(x - centerX, 2.0f) + Math.Pow(y - centerY, 2.0f));
                    }
                }
            }

            // NOTE: Multiplying with 2 is required since actually just the HFR is calculated above
            return (sum != 0 ? 2f * sumDist / sum : (float)Math.Sqrt(2) * outerRadius);
        }

        bool InsideCircle(float inX, float inY, float inCenterX, float inCenterY, float inRadius)
        {
            return Math.Pow(inX - inCenterX, 2.0) + Math.Pow(inY - inCenterY, 2.0) <= Math.Pow(inRadius, 2.0);
        }

        float GetPixelValue(Bitmap image, int x, int y)
        {
            Color pixel = image.GetPixel(x, y);
            return pixel.GetBrightness();
        }


        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
