namespace AutoFocuser
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.MoveStepperButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.stepsTextBox = new System.Windows.Forms.TextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.ManualCalculationButton = new System.Windows.Forms.Button();
            this.connectButton = new System.Windows.Forms.Button();
            this.hfdLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ZoomTrackBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CameraListBox = new System.Windows.Forms.ListBox();
            this.MainProgressBar = new System.Windows.Forms.ProgressBar();
            this.LiveViewPicBox = new System.Windows.Forms.PictureBox();
            this.SessionLabel = new System.Windows.Forms.Label();
            this.SessionButton = new System.Windows.Forms.Button();
            this.AvCoBox = new System.Windows.Forms.ComboBox();
            this.TvCoBox = new System.Windows.Forms.ComboBox();
            this.ISOCoBox = new System.Windows.Forms.ComboBox();
            this.SettingsGroupBox = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TakePhotoButton = new System.Windows.Forms.Button();
            this.SavePathTextBox = new System.Windows.Forms.TextBox();
            this.BrowseButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.STBothRdButton = new System.Windows.Forms.RadioButton();
            this.STComputerRdButton = new System.Windows.Forms.RadioButton();
            this.STCameraRdButton = new System.Windows.Forms.RadioButton();
            this.BulbUpDo = new System.Windows.Forms.NumericUpDown();
            this.LiveViewGroupBox = new System.Windows.Forms.GroupBox();
            this.LiveViewButton = new System.Windows.Forms.Button();
            this.InitGroupBox = new System.Windows.Forms.GroupBox();
            this.RefreshButton = new System.Windows.Forms.Button();
            this.SaveFolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.stepperMovementPanel = new System.Windows.Forms.Panel();
            this.HomingButton = new System.Windows.Forms.Button();
            this.CounterclockwiseCheckBox = new System.Windows.Forms.CheckBox();
            this.ClockwiseCheckBox = new System.Windows.Forms.CheckBox();
            this.ThresholdLabel = new System.Windows.Forms.Label();
            this.ThresholdTextBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.outerDiameterTextBox = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.AutomaticFocusButton = new System.Windows.Forms.Button();
            this.HFDChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.ControllerConnectionLabel = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.AutomaticResultHFDLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LiveViewPicBox)).BeginInit();
            this.SettingsGroupBox.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BulbUpDo)).BeginInit();
            this.LiveViewGroupBox.SuspendLayout();
            this.InitGroupBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.stepperMovementPanel.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HFDChart)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // MoveStepperButton
            // 
            this.MoveStepperButton.Location = new System.Drawing.Point(189, 59);
            this.MoveStepperButton.Name = "MoveStepperButton";
            this.MoveStepperButton.Size = new System.Drawing.Size(86, 55);
            this.MoveStepperButton.TabIndex = 0;
            this.MoveStepperButton.Text = "Move Stepper";
            this.MoveStepperButton.UseVisualStyleBackColor = true;
            this.MoveStepperButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Number of steps";
            // 
            // stepsTextBox
            // 
            this.stepsTextBox.Location = new System.Drawing.Point(189, 20);
            this.stepsTextBox.Name = "stepsTextBox";
            this.stepsTextBox.Size = new System.Drawing.Size(211, 22);
            this.stepsTextBox.TabIndex = 2;
            // 
            // serialPort1
            // 
            this.serialPort1.PortName = "COM6";
            // 
            // ManualCalculationButton
            // 
            this.ManualCalculationButton.Enabled = false;
            this.ManualCalculationButton.Location = new System.Drawing.Point(504, 105);
            this.ManualCalculationButton.Name = "ManualCalculationButton";
            this.ManualCalculationButton.Size = new System.Drawing.Size(125, 43);
            this.ManualCalculationButton.TabIndex = 3;
            this.ManualCalculationButton.Text = "Manual Calculation";
            this.ManualCalculationButton.UseVisualStyleBackColor = true;
            this.ManualCalculationButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(76, 34);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(152, 55);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect to SerialPort";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // hfdLabel
            // 
            this.hfdLabel.AutoSize = true;
            this.hfdLabel.Location = new System.Drawing.Point(549, 199);
            this.hfdLabel.Name = "hfdLabel";
            this.hfdLabel.Size = new System.Drawing.Size(28, 16);
            this.hfdLabel.TabIndex = 5;
            this.hfdLabel.Text = "Hfd";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(156, 156);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // ZoomTrackBar
            // 
            this.ZoomTrackBar.Enabled = false;
            this.ZoomTrackBar.Location = new System.Drawing.Point(71, 156);
            this.ZoomTrackBar.Name = "ZoomTrackBar";
            this.ZoomTrackBar.Size = new System.Drawing.Size(206, 56);
            this.ZoomTrackBar.TabIndex = 7;
            this.ZoomTrackBar.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(71, 218);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(663, 510);
            this.panel1.TabIndex = 8;
            // 
            // CameraListBox
            // 
            this.CameraListBox.FormattingEnabled = true;
            this.CameraListBox.ItemHeight = 16;
            this.CameraListBox.Location = new System.Drawing.Point(18, 68);
            this.CameraListBox.Name = "CameraListBox";
            this.CameraListBox.Size = new System.Drawing.Size(141, 148);
            this.CameraListBox.TabIndex = 10;
            // 
            // MainProgressBar
            // 
            this.MainProgressBar.Location = new System.Drawing.Point(17, 180);
            this.MainProgressBar.Name = "MainProgressBar";
            this.MainProgressBar.Size = new System.Drawing.Size(328, 23);
            this.MainProgressBar.TabIndex = 11;
            // 
            // LiveViewPicBox
            // 
            this.LiveViewPicBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LiveViewPicBox.Location = new System.Drawing.Point(29, 21);
            this.LiveViewPicBox.Name = "LiveViewPicBox";
            this.LiveViewPicBox.Size = new System.Drawing.Size(807, 413);
            this.LiveViewPicBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.LiveViewPicBox.TabIndex = 12;
            this.LiveViewPicBox.TabStop = false;
            this.LiveViewPicBox.Paint += new System.Windows.Forms.PaintEventHandler(this.LiveViewPicBox_Paint);
            // 
            // SessionLabel
            // 
            this.SessionLabel.AutoSize = true;
            this.SessionLabel.Location = new System.Drawing.Point(15, 26);
            this.SessionLabel.Name = "SessionLabel";
            this.SessionLabel.Size = new System.Drawing.Size(109, 16);
            this.SessionLabel.TabIndex = 13;
            this.SessionLabel.Text = "No open session";
            // 
            // SessionButton
            // 
            this.SessionButton.Location = new System.Drawing.Point(183, 157);
            this.SessionButton.Name = "SessionButton";
            this.SessionButton.Size = new System.Drawing.Size(116, 58);
            this.SessionButton.TabIndex = 14;
            this.SessionButton.Text = "Open Session";
            this.SessionButton.UseVisualStyleBackColor = true;
            this.SessionButton.Click += new System.EventHandler(this.SessionButton_Click);
            // 
            // AvCoBox
            // 
            this.AvCoBox.FormattingEnabled = true;
            this.AvCoBox.Location = new System.Drawing.Point(17, 37);
            this.AvCoBox.Name = "AvCoBox";
            this.AvCoBox.Size = new System.Drawing.Size(121, 24);
            this.AvCoBox.TabIndex = 15;
            this.AvCoBox.SelectedIndexChanged += new System.EventHandler(this.AvCoBox_SelectedIndexChanged);
            // 
            // TvCoBox
            // 
            this.TvCoBox.FormattingEnabled = true;
            this.TvCoBox.Location = new System.Drawing.Point(17, 76);
            this.TvCoBox.Name = "TvCoBox";
            this.TvCoBox.Size = new System.Drawing.Size(121, 24);
            this.TvCoBox.TabIndex = 16;
            this.TvCoBox.SelectedIndexChanged += new System.EventHandler(this.TvCoBox_SelectedIndexChanged);
            // 
            // ISOCoBox
            // 
            this.ISOCoBox.FormattingEnabled = true;
            this.ISOCoBox.Location = new System.Drawing.Point(17, 116);
            this.ISOCoBox.Name = "ISOCoBox";
            this.ISOCoBox.Size = new System.Drawing.Size(121, 24);
            this.ISOCoBox.TabIndex = 17;
            this.ISOCoBox.SelectedIndexChanged += new System.EventHandler(this.ISOCoBox_SelectedIndexChanged);
            // 
            // SettingsGroupBox
            // 
            this.SettingsGroupBox.Controls.Add(this.label7);
            this.SettingsGroupBox.Controls.Add(this.label6);
            this.SettingsGroupBox.Controls.Add(this.label5);
            this.SettingsGroupBox.Controls.Add(this.label4);
            this.SettingsGroupBox.Controls.Add(this.label3);
            this.SettingsGroupBox.Controls.Add(this.label2);
            this.SettingsGroupBox.Controls.Add(this.TakePhotoButton);
            this.SettingsGroupBox.Controls.Add(this.SavePathTextBox);
            this.SettingsGroupBox.Controls.Add(this.BrowseButton);
            this.SettingsGroupBox.Controls.Add(this.groupBox1);
            this.SettingsGroupBox.Controls.Add(this.AvCoBox);
            this.SettingsGroupBox.Controls.Add(this.BulbUpDo);
            this.SettingsGroupBox.Controls.Add(this.TvCoBox);
            this.SettingsGroupBox.Controls.Add(this.ISOCoBox);
            this.SettingsGroupBox.Controls.Add(this.MainProgressBar);
            this.SettingsGroupBox.Enabled = false;
            this.SettingsGroupBox.Location = new System.Drawing.Point(521, 14);
            this.SettingsGroupBox.Name = "SettingsGroupBox";
            this.SettingsGroupBox.Size = new System.Drawing.Size(582, 263);
            this.SettingsGroupBox.TabIndex = 18;
            this.SettingsGroupBox.TabStop = false;
            this.SettingsGroupBox.Text = "Settings";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 206);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 32;
            this.label7.Text = "Destination";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 16);
            this.label6.TabIndex = 31;
            this.label6.Text = "Progress";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(321, 40);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "Bulb (s)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(144, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 16);
            this.label4.TabIndex = 29;
            this.label4.Text = "ISO";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(144, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(23, 16);
            this.label3.TabIndex = 28;
            this.label3.Text = "Tv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 16);
            this.label2.TabIndex = 27;
            this.label2.Text = "Av";
            // 
            // TakePhotoButton
            // 
            this.TakePhotoButton.Location = new System.Drawing.Point(401, 176);
            this.TakePhotoButton.Name = "TakePhotoButton";
            this.TakePhotoButton.Size = new System.Drawing.Size(146, 23);
            this.TakePhotoButton.TabIndex = 26;
            this.TakePhotoButton.Text = "Take Photo";
            this.TakePhotoButton.UseVisualStyleBackColor = true;
            this.TakePhotoButton.Click += new System.EventHandler(this.TakePhotoButton_Click);
            // 
            // SavePathTextBox
            // 
            this.SavePathTextBox.Location = new System.Drawing.Point(17, 225);
            this.SavePathTextBox.Name = "SavePathTextBox";
            this.SavePathTextBox.Size = new System.Drawing.Size(328, 22);
            this.SavePathTextBox.TabIndex = 25;
            // 
            // BrowseButton
            // 
            this.BrowseButton.Location = new System.Drawing.Point(401, 224);
            this.BrowseButton.Name = "BrowseButton";
            this.BrowseButton.Size = new System.Drawing.Size(146, 23);
            this.BrowseButton.TabIndex = 24;
            this.BrowseButton.Text = "Browse";
            this.BrowseButton.UseVisualStyleBackColor = true;
            this.BrowseButton.Click += new System.EventHandler(this.BrowseButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.STBothRdButton);
            this.groupBox1.Controls.Add(this.STComputerRdButton);
            this.groupBox1.Controls.Add(this.STCameraRdButton);
            this.groupBox1.Location = new System.Drawing.Point(401, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 134);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Save To";
            // 
            // STBothRdButton
            // 
            this.STBothRdButton.AutoSize = true;
            this.STBothRdButton.Location = new System.Drawing.Point(26, 93);
            this.STBothRdButton.Name = "STBothRdButton";
            this.STBothRdButton.Size = new System.Drawing.Size(55, 20);
            this.STBothRdButton.TabIndex = 2;
            this.STBothRdButton.Text = "Both";
            this.STBothRdButton.UseVisualStyleBackColor = true;
            this.STBothRdButton.CheckedChanged += new System.EventHandler(this.SaveToRdButton_CheckedChanged);
            // 
            // STComputerRdButton
            // 
            this.STComputerRdButton.AutoSize = true;
            this.STComputerRdButton.Checked = true;
            this.STComputerRdButton.Location = new System.Drawing.Point(26, 60);
            this.STComputerRdButton.Name = "STComputerRdButton";
            this.STComputerRdButton.Size = new System.Drawing.Size(86, 20);
            this.STComputerRdButton.TabIndex = 1;
            this.STComputerRdButton.TabStop = true;
            this.STComputerRdButton.Text = "Computer";
            this.STComputerRdButton.UseVisualStyleBackColor = true;
            this.STComputerRdButton.CheckedChanged += new System.EventHandler(this.SaveToRdButton_CheckedChanged);
            // 
            // STCameraRdButton
            // 
            this.STCameraRdButton.AutoSize = true;
            this.STCameraRdButton.Location = new System.Drawing.Point(26, 24);
            this.STCameraRdButton.Name = "STCameraRdButton";
            this.STCameraRdButton.Size = new System.Drawing.Size(76, 20);
            this.STCameraRdButton.TabIndex = 0;
            this.STCameraRdButton.Text = "Camera";
            this.STCameraRdButton.UseVisualStyleBackColor = true;
            this.STCameraRdButton.CheckedChanged += new System.EventHandler(this.SaveToRdButton_CheckedChanged);
            // 
            // BulbUpDo
            // 
            this.BulbUpDo.Location = new System.Drawing.Point(195, 38);
            this.BulbUpDo.Name = "BulbUpDo";
            this.BulbUpDo.Size = new System.Drawing.Size(120, 22);
            this.BulbUpDo.TabIndex = 22;
            // 
            // LiveViewGroupBox
            // 
            this.LiveViewGroupBox.Controls.Add(this.LiveViewButton);
            this.LiveViewGroupBox.Controls.Add(this.LiveViewPicBox);
            this.LiveViewGroupBox.Enabled = false;
            this.LiveViewGroupBox.Location = new System.Drawing.Point(15, 292);
            this.LiveViewGroupBox.Name = "LiveViewGroupBox";
            this.LiveViewGroupBox.Size = new System.Drawing.Size(1088, 454);
            this.LiveViewGroupBox.TabIndex = 19;
            this.LiveViewGroupBox.TabStop = false;
            this.LiveViewGroupBox.Text = "Live View";
            // 
            // LiveViewButton
            // 
            this.LiveViewButton.Location = new System.Drawing.Point(879, 21);
            this.LiveViewButton.Name = "LiveViewButton";
            this.LiveViewButton.Size = new System.Drawing.Size(163, 51);
            this.LiveViewButton.TabIndex = 21;
            this.LiveViewButton.Text = "Start Live View";
            this.LiveViewButton.UseVisualStyleBackColor = true;
            this.LiveViewButton.Click += new System.EventHandler(this.LiveViewButton_Click);
            // 
            // InitGroupBox
            // 
            this.InitGroupBox.Controls.Add(this.RefreshButton);
            this.InitGroupBox.Controls.Add(this.SessionLabel);
            this.InitGroupBox.Controls.Add(this.SessionButton);
            this.InitGroupBox.Controls.Add(this.CameraListBox);
            this.InitGroupBox.Location = new System.Drawing.Point(15, 14);
            this.InitGroupBox.Name = "InitGroupBox";
            this.InitGroupBox.Size = new System.Drawing.Size(314, 263);
            this.InitGroupBox.TabIndex = 20;
            this.InitGroupBox.TabStop = false;
            this.InitGroupBox.Text = "Session";
            // 
            // RefreshButton
            // 
            this.RefreshButton.Location = new System.Drawing.Point(183, 76);
            this.RefreshButton.Name = "RefreshButton";
            this.RefreshButton.Size = new System.Drawing.Size(116, 57);
            this.RefreshButton.TabIndex = 27;
            this.RefreshButton.Text = "Refresh";
            this.RefreshButton.UseVisualStyleBackColor = true;
            this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Location = new System.Drawing.Point(5, 1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1133, 784);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.stepperMovementPanel);
            this.tabPage1.Controls.Add(this.ThresholdLabel);
            this.tabPage1.Controls.Add(this.ThresholdTextBox);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.outerDiameterTextBox);
            this.tabPage1.Controls.Add(this.ZoomTrackBar);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.hfdLabel);
            this.tabPage1.Controls.Add(this.ManualCalculationButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1125, 755);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Manual";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // stepperMovementPanel
            // 
            this.stepperMovementPanel.Controls.Add(this.HomingButton);
            this.stepperMovementPanel.Controls.Add(this.label1);
            this.stepperMovementPanel.Controls.Add(this.CounterclockwiseCheckBox);
            this.stepperMovementPanel.Controls.Add(this.MoveStepperButton);
            this.stepperMovementPanel.Controls.Add(this.ClockwiseCheckBox);
            this.stepperMovementPanel.Controls.Add(this.stepsTextBox);
            this.stepperMovementPanel.Enabled = false;
            this.stepperMovementPanel.Location = new System.Drawing.Point(29, 6);
            this.stepperMovementPanel.Name = "stepperMovementPanel";
            this.stepperMovementPanel.Size = new System.Drawing.Size(419, 144);
            this.stepperMovementPanel.TabIndex = 15;
            // 
            // HomingButton
            // 
            this.HomingButton.Location = new System.Drawing.Point(314, 59);
            this.HomingButton.Name = "HomingButton";
            this.HomingButton.Size = new System.Drawing.Size(86, 55);
            this.HomingButton.TabIndex = 15;
            this.HomingButton.Text = "Homing";
            this.HomingButton.UseVisualStyleBackColor = true;
            this.HomingButton.Click += new System.EventHandler(this.HomingButton_Click);
            // 
            // CounterclockwiseCheckBox
            // 
            this.CounterclockwiseCheckBox.AutoSize = true;
            this.CounterclockwiseCheckBox.Location = new System.Drawing.Point(21, 94);
            this.CounterclockwiseCheckBox.Name = "CounterclockwiseCheckBox";
            this.CounterclockwiseCheckBox.Size = new System.Drawing.Size(134, 20);
            this.CounterclockwiseCheckBox.TabIndex = 14;
            this.CounterclockwiseCheckBox.Text = "Counterclockwise";
            this.CounterclockwiseCheckBox.UseVisualStyleBackColor = true;
            this.CounterclockwiseCheckBox.CheckedChanged += new System.EventHandler(this.CounterclockwiseCheckBox_CheckedChanged);
            // 
            // ClockwiseCheckBox
            // 
            this.ClockwiseCheckBox.AutoSize = true;
            this.ClockwiseCheckBox.Location = new System.Drawing.Point(21, 59);
            this.ClockwiseCheckBox.Name = "ClockwiseCheckBox";
            this.ClockwiseCheckBox.Size = new System.Drawing.Size(90, 20);
            this.ClockwiseCheckBox.TabIndex = 13;
            this.ClockwiseCheckBox.Text = "Clockwise";
            this.ClockwiseCheckBox.UseVisualStyleBackColor = true;
            this.ClockwiseCheckBox.CheckedChanged += new System.EventHandler(this.ClockwiseCheckBox_CheckedChanged);
            // 
            // ThresholdLabel
            // 
            this.ThresholdLabel.AutoSize = true;
            this.ThresholdLabel.Location = new System.Drawing.Point(655, 65);
            this.ThresholdLabel.Name = "ThresholdLabel";
            this.ThresholdLabel.Size = new System.Drawing.Size(131, 16);
            this.ThresholdLabel.TabIndex = 12;
            this.ThresholdLabel.Text = "Threshold filter value";
            // 
            // ThresholdTextBox
            // 
            this.ThresholdTextBox.Location = new System.Drawing.Point(504, 59);
            this.ThresholdTextBox.Name = "ThresholdTextBox";
            this.ThresholdTextBox.Size = new System.Drawing.Size(125, 22);
            this.ThresholdTextBox.TabIndex = 11;
            this.ThresholdTextBox.Text = "6";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(655, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(155, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Outer circle diameter (px)";
            // 
            // outerDiameterTextBox
            // 
            this.outerDiameterTextBox.Location = new System.Drawing.Point(504, 31);
            this.outerDiameterTextBox.Name = "outerDiameterTextBox";
            this.outerDiameterTextBox.Size = new System.Drawing.Size(125, 22);
            this.outerDiameterTextBox.TabIndex = 9;
            this.outerDiameterTextBox.Text = "300";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.AutomaticResultHFDLabel);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.AutomaticFocusButton);
            this.tabPage2.Controls.Add(this.HFDChart);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1125, 755);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Automatic";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // AutomaticFocusButton
            // 
            this.AutomaticFocusButton.Location = new System.Drawing.Point(640, 416);
            this.AutomaticFocusButton.Name = "AutomaticFocusButton";
            this.AutomaticFocusButton.Size = new System.Drawing.Size(297, 62);
            this.AutomaticFocusButton.TabIndex = 1;
            this.AutomaticFocusButton.Text = "Automatic Focus";
            this.AutomaticFocusButton.UseVisualStyleBackColor = true;
            this.AutomaticFocusButton.Click += new System.EventHandler(this.AutomaticFocusButton_Click);
            // 
            // HFDChart
            // 
            chartArea1.Name = "ChartArea1";
            this.HFDChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.HFDChart.Legends.Add(legend1);
            this.HFDChart.Location = new System.Drawing.Point(30, 54);
            this.HFDChart.Name = "HFDChart";
            this.HFDChart.Size = new System.Drawing.Size(989, 300);
            this.HFDChart.TabIndex = 0;
            this.HFDChart.Text = "chart1";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.ControllerConnectionLabel);
            this.tabPage3.Controls.Add(this.connectButton);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1125, 755);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Microcontroller";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // ControllerConnectionLabel
            // 
            this.ControllerConnectionLabel.AutoSize = true;
            this.ControllerConnectionLabel.Location = new System.Drawing.Point(426, 44);
            this.ControllerConnectionLabel.Name = "ControllerConnectionLabel";
            this.ControllerConnectionLabel.Size = new System.Drawing.Size(0, 16);
            this.ControllerConnectionLabel.TabIndex = 5;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.InitGroupBox);
            this.tabPage4.Controls.Add(this.LiveViewGroupBox);
            this.tabPage4.Controls.Add(this.SettingsGroupBox);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1125, 755);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Camera";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(638, 496);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(381, 16);
            this.label9.TabIndex = 2;
            this.label9.Text = "*Make sure to home the position before starting automatic focus";
            // 
            // AutomaticResultHFDLabel
            // 
            this.AutomaticResultHFDLabel.AutoSize = true;
            this.AutomaticResultHFDLabel.Location = new System.Drawing.Point(58, 416);
            this.AutomaticResultHFDLabel.Name = "AutomaticResultHFDLabel";
            this.AutomaticResultHFDLabel.Size = new System.Drawing.Size(0, 16);
            this.AutomaticResultHFDLabel.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1150, 784);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Auto Focuser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ZoomTrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LiveViewPicBox)).EndInit();
            this.SettingsGroupBox.ResumeLayout(false);
            this.SettingsGroupBox.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BulbUpDo)).EndInit();
            this.LiveViewGroupBox.ResumeLayout(false);
            this.InitGroupBox.ResumeLayout(false);
            this.InitGroupBox.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.stepperMovementPanel.ResumeLayout(false);
            this.stepperMovementPanel.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HFDChart)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MoveStepperButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox stepsTextBox;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button ManualCalculationButton;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Label hfdLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TrackBar ZoomTrackBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListBox CameraListBox;
        private System.Windows.Forms.ProgressBar MainProgressBar;
        private System.Windows.Forms.PictureBox LiveViewPicBox;
        private System.Windows.Forms.Label SessionLabel;
        private System.Windows.Forms.Button SessionButton;
        private System.Windows.Forms.ComboBox AvCoBox;
        private System.Windows.Forms.ComboBox TvCoBox;
        private System.Windows.Forms.ComboBox ISOCoBox;
        private System.Windows.Forms.GroupBox SettingsGroupBox;
        private System.Windows.Forms.GroupBox LiveViewGroupBox;
        private System.Windows.Forms.GroupBox InitGroupBox;
        private System.Windows.Forms.Button LiveViewButton;
        private System.Windows.Forms.NumericUpDown BulbUpDo;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton STBothRdButton;
        private System.Windows.Forms.RadioButton STComputerRdButton;
        private System.Windows.Forms.RadioButton STCameraRdButton;
        private System.Windows.Forms.Button BrowseButton;
        private System.Windows.Forms.TextBox SavePathTextBox;
        private System.Windows.Forms.FolderBrowserDialog SaveFolderBrowser;
        private System.Windows.Forms.Button TakePhotoButton;
        private System.Windows.Forms.Button RefreshButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox outerDiameterTextBox;
        private System.Windows.Forms.Label ControllerConnectionLabel;
        private System.Windows.Forms.Label ThresholdLabel;
        private System.Windows.Forms.TextBox ThresholdTextBox;
        private System.Windows.Forms.Panel stepperMovementPanel;
        private System.Windows.Forms.CheckBox CounterclockwiseCheckBox;
        private System.Windows.Forms.CheckBox ClockwiseCheckBox;
        private System.Windows.Forms.Button HomingButton;
        private System.Windows.Forms.Button AutomaticFocusButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart HFDChart;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label AutomaticResultHFDLabel;
    }
}

