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
using OpenCvSharp;
using System.Security.Cryptography;
using AForge.Math.Geometry;
using AForge;
using System.Windows;

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
            this.DoubleBuffered= true;
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
            Threshold thresholdFilter = new Threshold(100);
            Bitmap grayImage = grayscaleFilter.Apply(image);
            Bitmap thresholdImage = thresholdFilter.Apply(grayImage);

            // Apply blob counter to detect objects in the image
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 10;
            blobCounter.MinWidth = 10;
            blobCounter.ObjectsOrder = ObjectsOrder.Size; 
            blobCounter.ProcessImage(thresholdImage);

            SimpleShapeChecker simpleShapeChecker = new SimpleShapeChecker();
            GrahamConvexHull grahamConvexHull= new GrahamConvexHull();

            // Get information about objects in the image
            Blob[] blobs = blobCounter.GetObjectsInformation();
            for (int i = 0, n = blobs.Length; i < n; i++)
            {
                List<IntPoint> edgePoints = blobCounter.GetBlobsEdgePoints(blobs[i]);
                List<IntPoint> hull = grahamConvexHull.FindHull(edgePoints);
                Graphics g = Graphics.FromImage(image);
                g.DrawPolygon(new Pen(Color.Red, 2), hull.Select(p => new PointF(p.X, p.Y)).ToArray());
            }
            // Update picture box
            pictureBox1.Image = image;
            org.Image = image;
            image.Save("C:\\Users\\mical\\Desktop\\testOutput1.bmp");
            panel1.AutoScrollPosition = new System.Drawing.Point((int)blobs[0].CenterOfGravity.X-panel1.Width/2, (int)blobs[0].CenterOfGravity.Y-panel1.Height/2);
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

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
