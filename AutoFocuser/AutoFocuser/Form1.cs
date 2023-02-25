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
using EOSDigital.API;
using EOSDigital.SDK;
using System.Runtime.InteropServices;
using System.Windows.Media.Imaging;
using Emgu.CV.Reg;
using System.Runtime.CompilerServices;

namespace AutoFocuser
{
    public partial class Form1 : Form
    {

        CanonAPI APIHandler;
        Camera MainCamera;
        CameraValue[] AvList;
        CameraValue[] TvList;
        CameraValue[] ISOList;
        List<Camera> CamList;
        bool IsInit = false;
        Bitmap Evf_Bmp;
        int LVBw, LVBh, w, h;
        float LVBratio, LVration;

        int ErrCount;
        object ErrLock = new object();
        object LvLock = new object();



        public Form1()
        {
            try
            {
                InitializeComponent();
                APIHandler = new CanonAPI();
                APIHandler.CameraAdded += APIHandler_CameraAdded;
                ErrorHandler.SevereErrorHappened += ErrorHandler_SevereErrorHappened;
                ErrorHandler.NonSevereErrorHappened += ErrorHandler_NonSevereErrorHappened;
                SavePathTextBox.Text = "imgTemp";
                SaveFolderBrowser.Description = "Save Images To...";
                LiveViewPicBox.Paint += LiveViewPicBox_Paint;
                LVBw = LiveViewPicBox.Width;
                LVBh = LiveViewPicBox.Height;
                RefreshCamera();
                IsInit = true;
            }
            catch (DllNotFoundException) { ReportError("Canon DLLs not found!", true); }
            catch (Exception ex) { ReportError(ex.Message, true); }
        }

        PictureBox org = new PictureBox();

        #region Events

        private void goButton_Click(object sender, EventArgs e)
        {
            if (CounterclockwiseCheckBox.Checked == true)
                serialPort1.Write(stepsTextBox.Text + ",1");
            else if (ClockwiseCheckBox.Checked == true)
                serialPort1.Write(stepsTextBox.Text + ",0");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ZoomTrackBar.Minimum = 1;
            ZoomTrackBar.Maximum = 4;
            ZoomTrackBar.SmallChange = 1;
            ZoomTrackBar.LargeChange = 1;
            ZoomTrackBar.UseWaitCursor = false;
            this.DoubleBuffered = true;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            serialPort1.Close();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            serialPort1.Open();
            stepperMovementPanel.Enabled = true;
            ControllerConnectionLabel.Text = "Connected";
        }


        private void button1_Click(object sender, EventArgs e)
        {

            _imageConverted = false;
            System.IO.DirectoryInfo di = new DirectoryInfo("imgTemp");
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            TakeAndDownloadImage();
        }

        private static System.Timers.Timer _timer;
        private static bool _imageConverted = false;

        public void TakeAndDownloadImage()
        {
            MainCamera.TakePhotoShutterAsync();
            // start timer to wait for image to be taken and downloaded
            _timer = new System.Timers.Timer(1000); // set timer interval to 1 second
            _timer.Elapsed += OnTimedEvent; // assign event handler
            _timer.AutoReset = true; // set timer to repeat
            _timer.Enabled = true; // start timer
        }


        private void OnTimedEvent(Object source, System.Timers.ElapsedEventArgs e)
        {
            DirectoryInfo di = new DirectoryInfo("imgTemp");
            string filePath = di.GetFiles().Select(fi => fi.FullName).FirstOrDefault();

            if (File.Exists(filePath))
            {
                int maxWaitTime = 10000; // milliseconds
                int timeWaited = 0;
                while (IsFileLocked(filePath) && timeWaited < maxWaitTime)
                {
                    System.Threading.Thread.Sleep(100); // Wait for 100 milliseconds
                    timeWaited += 100;
                }
                if (IsFileLocked(filePath))
                {
                    // File is still locked after waiting, so display an error message
                    System.Windows.Forms.MessageBox.Show("The file is still in use and cannot be accessed.");
                }
                else
                {
                    if (_imageConverted == false)
                    {
                        using (Stream bmpStream = System.IO.File.Open(filePath, System.IO.FileMode.Open))
                        {
                            Bitmap bitmap;
                            System.Drawing.Image imagesssss = System.Drawing.Image.FromStream(bmpStream);
                            bitmap = new Bitmap(imagesssss);
                            ProcessImage(bitmap);
                            _imageConverted = true;
                            _timer.Enabled = false;
                            _timer.Dispose();
                            _timer = null;
                        }
                    }
                }
            }
        }

        public static bool IsFileLocked(string filePath)
        {
            try
            {
                using (FileStream stream = File.Open(filePath, FileMode.Open, System.IO.FileAccess.ReadWrite, FileShare.None))
                {
                    stream.Close();
                }
            }
            catch (IOException)
            {
                // The file is locked by another process
                return true;
            }

            // The file is not locked
            return false;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (ZoomTrackBar.Value != 0)
            {
                pictureBox1.Image = null;
                pictureBox1.Image = ZoomPicture(org.Image, new System.Drawing.Size(ZoomTrackBar.Value, ZoomTrackBar.Value));
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                IsInit = false;
                MainCamera?.Dispose();
                APIHandler?.Dispose();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void SessionButton_Click(object sender, EventArgs e)
        {
            if (MainCamera?.SessionOpen == true) CloseSession();
            else OpenSession();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
        {
            try { RefreshCamera(); }
            catch (Exception ex) { ReportError(ex.Message, false); }

        }

        private void TakePhotoButton_Click(object sender, EventArgs e)
        {
            try
            {
                if ((string)TvCoBox.SelectedItem == "Bulb") MainCamera.TakePhotoBulbAsync((int)BulbUpDo.Value);
                else MainCamera.TakePhotoShutterAsync();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }

        }

        private void BrowseButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (Directory.Exists(SavePathTextBox.Text)) SaveFolderBrowser.SelectedPath = SavePathTextBox.Text;
                if (SaveFolderBrowser.ShowDialog() == DialogResult.OK)
                {
                    SavePathTextBox.Text = SaveFolderBrowser.SelectedPath;
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }

        }

        private void SaveToRdButton_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (IsInit)
                {
                    if (STCameraRdButton.Checked)
                    {
                        MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Camera);
                        BrowseButton.Enabled = false;
                        SavePathTextBox.Enabled = false;
                    }
                    else
                    {
                        if (STComputerRdButton.Checked) MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);
                        else if (STBothRdButton.Checked) MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Both);

                        MainCamera.SetCapacity(4096, int.MaxValue);
                        BrowseButton.Enabled = true;
                        SavePathTextBox.Enabled = true;
                    }
                }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void AvCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (AvCoBox.SelectedIndex < 0) return;
                MainCamera.SetSetting(PropertyID.Av, AvValues.GetValue((string)AvCoBox.SelectedItem).IntValue);
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void TvCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TvCoBox.SelectedIndex < 0) return;

                MainCamera.SetSetting(PropertyID.Tv, TvValues.GetValue((string)TvCoBox.SelectedItem).IntValue);
                BulbUpDo.Enabled = (string)TvCoBox.SelectedItem == "Bulb";
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void ISOCoBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ISOCoBox.SelectedIndex < 0) return;
                MainCamera.SetSetting(PropertyID.ISO, ISOValues.GetValue((string)ISOCoBox.SelectedItem).IntValue);
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        #endregion

        #region Methods
        private void ProcessImage(Bitmap image)
        {
            image.Save("C:\\Users\\mical\\Desktop\\imageStart.bmp");
            Grayscale grayscaleFilter = new Grayscale(0.2125, 0.7154, 0.0721);
            Bitmap grayImage = grayscaleFilter.Apply(image);
            AForge.Imaging.Filters.Threshold thresholdFilter = new AForge.Imaging.Filters.Threshold(int.Parse(ThresholdTextBox.Text));
            Bitmap thresholdImage = thresholdFilter.Apply(grayImage);
            thresholdImage.Save("C:\\Users\\mical\\Desktop\\thresholdImage.bmp");
            // Apply blob counter to detect objects in the image
            BlobCounter blobCounter = new BlobCounter();
            blobCounter.FilterBlobs = true;
            blobCounter.MinHeight = 10;
            blobCounter.MinWidth = 10;
            blobCounter.ObjectsOrder = ObjectsOrder.Size;
            blobCounter.ProcessImage(thresholdImage);

            SimpleShapeChecker simpleShapeChecker = new SimpleShapeChecker();
            GrahamConvexHull grahamConvexHull = new GrahamConvexHull();
            float hfd = -1;
            // Get information about objects in the image
            Blob[] blobs = blobCounter.GetObjectsInformation();
            Bitmap starbg = null;
            int biggestBlobIndex = -1;
            int biggestBlobArea = -1;
            for (int i = 0; i < blobs.Length; i++)
            {
                if (blobs[i].Area > biggestBlobArea)
                {
                    biggestBlobIndex = i;
                    biggestBlobArea = blobs[i].Area;
                }
            }
            if (blobs.Length == 0)
                return;

            Blob blob = blobs[biggestBlobIndex];

            Graphics g = Graphics.FromImage(image);

            blobCounter.ExtractBlobsImage(thresholdImage, blob, true);
            Bitmap star = blob.Image.ToManagedImage();
            star.Save("C:\\Users\\mical\\Desktop\\blob.bmp");
            //AForge.Imaging.Filters.Invert invertFilter = new AForge.Imaging.Filters.Invert();
            //star = invertFilter.Apply(star);

            System.Drawing.Rectangle expandedRectangle = new System.Drawing.Rectangle(
            blob.Rectangle.X - 200,
            blob.Rectangle.Y - 200,
            blob.Rectangle.Width + 400,
            blob.Rectangle.Height + 400);

            // Ensure the expanded rectangle stays within the bounds of the original image
            expandedRectangle.Intersect(new System.Drawing.Rectangle(0, 0, star.Width, star.Height));

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

            int biggestBlobInsideIndex = -1;
            int biggestBlobInsideArea = -1;

            for (int i = 0; i < blobsInside.Length; i++)
            {
                if (blobsInside[i].Area > biggestBlobInsideArea)
                {
                    biggestBlobInsideIndex = i;
                    biggestBlobInsideArea = blobsInside[i].Area;
                }
            }
            if (blobsInside.Length == 0)
                return;
            Blob blobInside = blobsInside[biggestBlobInsideIndex];

            savedBlob = blobInside;
            List<IntPoint> edgePoints = blobCounter2.GetBlobsEdgePoints(savedBlob);
            List<IntPoint> hull = grahamConvexHull.FindHull(edgePoints);
            // Calculate desired circle diameter
            int circleDiameter = int.Parse(outerDiameterTextBox.Text);

            // Calculate circle bounds
            int circleRadius = circleDiameter / 2;
            int circleX = (int)savedBlob.CenterOfGravity.X - circleRadius;
            int circleY = (int)savedBlob.CenterOfGravity.Y - circleRadius;
            hfd = CalcHfd(starbg, circleDiameter);
            int circleXHFD = (int)(savedBlob.CenterOfGravity.X - hfd / 2);
            int circleYHFD = (int)(savedBlob.CenterOfGravity.Y - hfd / 2);

            using (Graphics gh = Graphics.FromImage(starbg))
            {
                gh.DrawEllipse(new Pen(Color.Red, 2), circleX, circleY, circleDiameter, circleDiameter);
                gh.DrawEllipse(new Pen(Color.Green, 2), circleXHFD, circleYHFD, hfd, hfd);
                gh.DrawPolygon(new Pen(Color.Blue, 3), hull.Select(p => new PointF(p.X, p.Y)).ToArray());
            }


            // Update picture box
            pictureBox1.Invoke(new Action(() => { pictureBox1.Image = starbg; }));
            org.Image = starbg;
            panel1.Invoke(new Action(() =>
            {
                panel1.AutoScrollPosition = new System.Drawing.Point((int)blobs[0].CenterOfGravity.X - panel1.Width / 2, (int)blobs[0].CenterOfGravity.Y - panel1.Height / 2);
            }));
            hfdLabel.Invoke(new Action(() => { hfdLabel.Text = "HFD: " + hfd.ToString(); }));
            ZoomTrackBar.Invoke(new Action(() => { ZoomTrackBar.Enabled = true; }));
        }

        System.Drawing.Image ZoomPicture(System.Drawing.Image img, System.Drawing.Size size)
        {
            Bitmap bm = new Bitmap(img, Convert.ToInt32(img.Width * size.Width),
                Convert.ToInt32(img.Height * size.Height));
            Graphics g = Graphics.FromImage(bm);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            return bm;
        }

        #endregion

        #region HalfFluxDiameter

        public static byte[] BitmapToByteArray(Bitmap bitmap)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Bmp);
                return ms.ToArray();
            }
        }

        float GetPixelValue(Bitmap image, int x, int y)
        {
            Color pixel = image.GetPixel(x, y);
            return pixel.GetBrightness();
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


        #endregion

        #region Subroutines

        private void CloseSession()
        {
            MainCamera.CloseSession();
            AvCoBox.Items.Clear();
            TvCoBox.Items.Clear();
            ISOCoBox.Items.Clear();
            SettingsGroupBox.Enabled = false;
            LiveViewGroupBox.Enabled = false;

            SessionButton.Text = "Open Session";
            SessionLabel.Text = "No open session";
            LiveViewButton.Text = "Start LV";
        }

        private void LiveViewGroupBox_Enter(object sender, EventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void LiveViewButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (!MainCamera.IsLiveViewOn) { MainCamera.StartLiveView(); LiveViewButton.Text = "Stop LV"; }
                else { MainCamera.StopLiveView(); LiveViewButton.Text = "Start LV"; }
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void LiveViewPicBox_Paint(object sender, PaintEventArgs e)
        {
            if (MainCamera == null || !MainCamera.SessionOpen) return;

            if (!MainCamera.IsLiveViewOn) e.Graphics.Clear(BackColor);
            else
            {
                lock (LvLock)
                {
                    if (Evf_Bmp != null)
                    {
                        LVBratio = LVBw / (float)LVBh;
                        LVration = Evf_Bmp.Width / (float)Evf_Bmp.Height;
                        if (LVBratio < LVration)
                        {
                            w = LVBw;
                            h = (int)(LVBw / LVration);
                        }
                        else
                        {
                            w = (int)(LVBh * LVration);
                            h = LVBh;
                        }
                        e.Graphics.DrawImage(Evf_Bmp, 0, 0, w, h);
                    }
                }
            }
        }

        private void RefreshCamera()
        {
            CameraListBox.Items.Clear();
            CamList = APIHandler.GetCameraList();
            foreach (Camera cam in CamList) CameraListBox.Items.Add(cam.DeviceName);
            if (MainCamera?.SessionOpen == true) CameraListBox.SelectedIndex = CamList.FindIndex(t => t.ID == MainCamera.ID);
            else if (CamList.Count > 0) CameraListBox.SelectedIndex = 0;
        }



        private void OpenSession()
        {
            if (CameraListBox.SelectedIndex >= 0)
            {
                MainCamera = CamList[CameraListBox.SelectedIndex];
                MainCamera.OpenSession();
                MainCamera.LiveViewUpdated += MainCamera_LiveViewUpdated;
                MainCamera.ProgressChanged += MainCamera_ProgressChanged;
                MainCamera.StateChanged += MainCamera_StateChanged;
                MainCamera.DownloadReady += MainCamera_DownloadReady;
                MainCamera.SetSetting(PropertyID.SaveTo, (int)SaveTo.Host);

                SessionButton.Text = "Close Session";
                SessionLabel.Text = MainCamera.DeviceName;
                AvList = MainCamera.GetSettingsList(PropertyID.Av);
                TvList = MainCamera.GetSettingsList(PropertyID.Tv);
                ISOList = MainCamera.GetSettingsList(PropertyID.ISO);
                foreach (var Av in AvList) AvCoBox.Items.Add(Av.StringValue);
                foreach (var Tv in TvList) TvCoBox.Items.Add(Tv.StringValue);
                foreach (var ISO in ISOList) ISOCoBox.Items.Add(ISO.StringValue);
                AvCoBox.SelectedIndex = AvCoBox.Items.IndexOf(AvValues.GetValue(MainCamera.GetInt32Setting(PropertyID.Av)).StringValue);
                TvCoBox.SelectedIndex = TvCoBox.Items.IndexOf(TvValues.GetValue(MainCamera.GetInt32Setting(PropertyID.Tv)).StringValue);
                ISOCoBox.SelectedIndex = ISOCoBox.Items.IndexOf(ISOValues.GetValue(MainCamera.GetInt32Setting(PropertyID.ISO)).StringValue);
                SettingsGroupBox.Enabled = true;
                LiveViewGroupBox.Enabled = true;
                ManualCalculationButton.Enabled = true;
            }
        }

        private void ReportError(string message, bool lockdown)
        {
            int errc;
            lock (ErrLock) { errc = ++ErrCount; }

            if (lockdown) EnableUI(false);

            if (errc < 4) System.Windows.Forms.MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else if (errc == 4) System.Windows.Forms.MessageBox.Show("Many errors happened!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            lock (ErrLock) { ErrCount--; }
        }

        private void EnableUI(bool enable)
        {
            if (InvokeRequired) Invoke((Action)delegate { EnableUI(enable); });
            else
            {
                SettingsGroupBox.Enabled = enable;
                InitGroupBox.Enabled = enable;
                LiveViewGroupBox.Enabled = enable;
            }
        }

        #endregion

        #region API Events
        private void APIHandler_CameraAdded(CanonAPI sender)
        {
            try { Invoke((Action)delegate { RefreshCamera(); }); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_StateChanged(Camera sender, StateEventID eventID, int parameter)
        {
            try { if (eventID == StateEventID.Shutdown && IsInit) { Invoke((Action)delegate { CloseSession(); }); } }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_ProgressChanged(object sender, int progress)
        {
            try { Invoke((Action)delegate { MainProgressBar.Value = progress; }); }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void CounterclockwiseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (CounterclockwiseCheckBox.Checked == true)
                ClockwiseCheckBox.Checked = false;
        }

        private void ClockwiseCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (ClockwiseCheckBox.Checked == true)
                CounterclockwiseCheckBox.Checked = false;
        }

        private void HomingButton_Click(object sender, EventArgs e)
        {
            serialPort1.Write("CallHoming");
        }

        private void MainCamera_LiveViewUpdated(Camera sender, Stream img)
        {
            try
            {
                lock (LvLock)
                {
                    Evf_Bmp?.Dispose();
                    Evf_Bmp = new Bitmap(img);
                }
                LiveViewPicBox.Invalidate();
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void MainCamera_DownloadReady(Camera sender, DownloadInfo Info)
        {
            try
            {
                string dir = null;
                Invoke((Action)delegate { dir = SavePathTextBox.Text; });
                sender.DownloadFile(Info, dir);
                Invoke((Action)delegate { MainProgressBar.Value = 0; });
            }
            catch (Exception ex) { ReportError(ex.Message, false); }
        }

        private void ErrorHandler_NonSevereErrorHappened(object sender, ErrorCode ex)
        {
            ReportError($"SDK Error code: {ex} ({((int)ex).ToString("X")})", false);
        }

        private void ErrorHandler_SevereErrorHappened(object sender, Exception ex)
        {
            ReportError(ex.Message, true);
        }


        #endregion
    }
}
