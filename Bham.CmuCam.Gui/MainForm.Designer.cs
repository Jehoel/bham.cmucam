namespace Bham.CmuCam.Gui
{
	partial class MainForm
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
			System.Windows.Forms.Label @__windowLeftLbl;
			System.Windows.Forms.Label @__windowRightLbl;
			System.Windows.Forms.Label @__windowBottomLbl;
			System.Windows.Forms.Label @__windowTopLbl;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.@__status = new System.Windows.Forms.StatusStrip();
			this.@__frameProgress = new System.Windows.Forms.ToolStripProgressBar();
			this.@__statusLbl = new System.Windows.Forms.ToolStripStatusLabel();
			this.@__pickColorLbl = new System.Windows.Forms.Label();
			this.@__pickColor = new System.Windows.Forms.CheckBox();
			this.@__viewStretch = new System.Windows.Forms.CheckBox();
			this.@__histoLiveChannel = new System.Windows.Forms.ComboBox();
			this.@__histoLive = new System.Windows.Forms.CheckBox();
			this.@__histoRefresh = new System.Windows.Forms.Button();
			this.@__stillChannel = new System.Windows.Forms.ComboBox();
			this.@__stillGetFrame = new System.Windows.Forms.Button();
			this.@__trackMaxGrp = new System.Windows.Forms.GroupBox();
			this.@__trackMaxColor = new System.Windows.Forms.Button();
			this.@__trackMaxB = new System.Windows.Forms.TextBox();
			this.@__trackMaxR = new System.Windows.Forms.TextBox();
			this.@__trackMaxG = new System.Windows.Forms.TextBox();
			this.@__trackMinGrp = new System.Windows.Forms.GroupBox();
			this.@__trackMinColor = new System.Windows.Forms.Button();
			this.@__trackMinB = new System.Windows.Forms.TextBox();
			this.@__trackMinG = new System.Windows.Forms.TextBox();
			this.@__trackMinR = new System.Windows.Forms.TextBox();
			this.@__trackLiveColor = new System.Windows.Forms.CheckBox();
			this.@__windowLeft = new System.Windows.Forms.TextBox();
			this.@__windowRight = new System.Windows.Forms.TextBox();
			this.@__windowBottom = new System.Windows.Forms.TextBox();
			this.@__windowReset = new System.Windows.Forms.Button();
			this.@__winHighRes = new System.Windows.Forms.ComboBox();
			this.@__windowTop = new System.Windows.Forms.TextBox();
			this.@__tabs = new System.Windows.Forms.TabControl();
			this.@__tabStill = new System.Windows.Forms.TabPage();
			this.@__stillGetFrameStream = new System.Windows.Forms.CheckBox();
			this.@__configGrp = new System.Windows.Forms.GroupBox();
			this.@__configColorMode = new System.Windows.Forms.ComboBox();
			this.@__configReset = new System.Windows.Forms.Button();
			this.@__configPixelDifference = new System.Windows.Forms.CheckBox();
			this.@__configColorModeLbl = new System.Windows.Forms.Label();
			this.@__configAutoExposureGain = new System.Windows.Forms.CheckBox();
			this.@__configContrastLbl = new System.Windows.Forms.Label();
			this.@__configBrightnessLbl = new System.Windows.Forms.Label();
			this.@__configContrast = new Bham.CmuCam.Gui.TrackBar2();
			this.@__configBrightness = new Bham.CmuCam.Gui.TrackBar2();
			this.@__stillBufferLoad = new System.Windows.Forms.Button();
			this.@__stillBuffer = new System.Windows.Forms.CheckBox();
			this.@__stillChannelLbl = new System.Windows.Forms.Label();
			this.@__tabTrack = new System.Windows.Forms.TabPage();
			this.@__trackLiveWindowM2 = new System.Windows.Forms.CheckBox();
			this.@__trackLiveColorM2 = new System.Windows.Forms.CheckBox();
			this.@__trackLiveWindowM1 = new System.Windows.Forms.CheckBox();
			this.@__trackLiveColorM1 = new System.Windows.Forms.CheckBox();
			this.@__trackLiveWindow = new System.Windows.Forms.CheckBox();
			this.@__trackNoiseFilterLbl = new System.Windows.Forms.Label();
			this.@__trackNoiseFilter = new System.Windows.Forms.NumericUpDown();
			this.@__trackDefineLbl = new System.Windows.Forms.Label();
			this.@__trackDefine = new System.Windows.Forms.ComboBox();
			this.@__trackInverted = new System.Windows.Forms.CheckBox();
			this.@__tabDiff = new System.Windows.Forms.TabPage();
			this.@__diffLiveM3 = new System.Windows.Forms.CheckBox();
			this.@__diffLiveM2 = new System.Windows.Forms.CheckBox();
			this.@__diffLiveM1 = new System.Windows.Forms.CheckBox();
			this.@__diffLive = new System.Windows.Forms.CheckBox();
			this.@__diffThresholdLbl = new System.Windows.Forms.Label();
			this.@__diffThreshold = new System.Windows.Forms.NumericUpDown();
			this.@__diffLoad = new System.Windows.Forms.Button();
			this.@__diffChannelLbl = new System.Windows.Forms.Label();
			this.@__diffChannel = new System.Windows.Forms.ComboBox();
			this.@__diffHighRes = new System.Windows.Forms.CheckBox();
			this.@__tabMean = new System.Windows.Forms.TabPage();
			this.@__meanLiveM2 = new System.Windows.Forms.CheckBox();
			this.@__meanLiveM1 = new System.Windows.Forms.CheckBox();
			this.@__meanLive = new System.Windows.Forms.CheckBox();
			this.@__mean = new Bham.CmuCam.Gui.MeanDisplay();
			this.@__tabHisto = new System.Windows.Forms.TabPage();
			this.@__histoTrack = new System.Windows.Forms.CheckBox();
			this.@__histoScaleLbl = new System.Windows.Forms.Label();
			this.@__histoScale = new System.Windows.Forms.NumericUpDown();
			this.@__histoBins = new System.Windows.Forms.ComboBox();
			this.@__histoRed = new Bham.CmuCam.Gui.HistogramDisplay();
			this.@__histoGreen = new Bham.CmuCam.Gui.HistogramDisplay();
			this.@__histoBlue = new Bham.CmuCam.Gui.HistogramDisplay();
			this.@__tabAux = new System.Windows.Forms.TabPage();
			this.@__auxAuxMsgBinLbl = new System.Windows.Forms.Label();
			this.@__auxAuxMsgDecLbl = new System.Windows.Forms.Label();
			this.@__auxAuxMsgHexLbl = new System.Windows.Forms.Label();
			this.@__auxLed2 = new System.Windows.Forms.ComboBox();
			this.@__auxLed2Lbl = new System.Windows.Forms.Label();
			this.@__auxLed1 = new System.Windows.Forms.ComboBox();
			this.@__auxLed1Lbl = new System.Windows.Forms.Label();
			this.@__auxAuxMsgBin = new System.Windows.Forms.TextBox();
			this.@__auxAuxMsgDec = new System.Windows.Forms.TextBox();
			this.@__auxAuxMsgHex = new System.Windows.Forms.TextBox();
			this.@__auxAux = new System.Windows.Forms.Button();
			this.@__auxBtnMsg = new System.Windows.Forms.TextBox();
			this.@__auxBtn = new System.Windows.Forms.Button();
			this.@__tabServo = new System.Windows.Forms.TabPage();
			this.@__servoHome = new System.Windows.Forms.Button();
			this.@__servoTiltStepsLbl = new System.Windows.Forms.Label();
			this.@__servoTiltNearLbl = new System.Windows.Forms.Label();
			this.@__servoTiltFarLbl = new System.Windows.Forms.Label();
			this.@__servoTiltSteps = new System.Windows.Forms.NumericUpDown();
			this.@__servoTiltNear = new System.Windows.Forms.NumericUpDown();
			this.@__servoTiltFar = new System.Windows.Forms.NumericUpDown();
			this.@__servoPanStepsLbl = new System.Windows.Forms.Label();
			this.@__servoPanNearLbl = new System.Windows.Forms.Label();
			this.@__servoPanFarLbl = new System.Windows.Forms.Label();
			this.@__servoPanSteps = new System.Windows.Forms.NumericUpDown();
			this.@__servoPanNear = new System.Windows.Forms.NumericUpDown();
			this.@__servoPanFar = new System.Windows.Forms.NumericUpDown();
			this.@__servo5High = new System.Windows.Forms.CheckBox();
			this.@__servo4High = new System.Windows.Forms.CheckBox();
			this.@__servo3High = new System.Windows.Forms.CheckBox();
			this.@__servo2High = new System.Windows.Forms.CheckBox();
			this.@__servo1High = new System.Windows.Forms.CheckBox();
			this.@__servo5Lbl = new System.Windows.Forms.Label();
			this.@__servo4Lbl = new System.Windows.Forms.Label();
			this.@__servo3Lbl = new System.Windows.Forms.Label();
			this.@__servo2Lbl = new System.Windows.Forms.Label();
			this.@__servo1Lbl = new System.Windows.Forms.Label();
			this.@__servoTiltReporting = new System.Windows.Forms.CheckBox();
			this.@__servoPanReporting = new System.Windows.Forms.CheckBox();
			this.@__servoTiltControl = new System.Windows.Forms.CheckBox();
			this.@__servoPanControl = new System.Windows.Forms.CheckBox();
			this.@__servo5 = new Bham.CmuCam.Gui.TrackBar2();
			this.@__servo4 = new Bham.CmuCam.Gui.TrackBar2();
			this.@__servo3 = new Bham.CmuCam.Gui.TrackBar2();
			this.@__servo2 = new Bham.CmuCam.Gui.TrackBar2();
			this.@__servo1 = new Bham.CmuCam.Gui.TrackBar2();
			this.@__window = new System.Windows.Forms.GroupBox();
			this.@__winDownsampleYLbl = new System.Windows.Forms.Label();
			this.@__winDownsampleY = new System.Windows.Forms.NumericUpDown();
			this.@__winDownsampleXLbl = new System.Windows.Forms.Label();
			this.@__winDownsampleX = new System.Windows.Forms.NumericUpDown();
			this.@__colorDlg = new System.Windows.Forms.ColorDialog();
			this.@__tip = new System.Windows.Forms.ToolTip(this.components);
			this.@__viewStyle = new System.Windows.Forms.ComboBox();
			this.@__viewSave = new System.Windows.Forms.Button();
			this.@__sfd = new System.Windows.Forms.SaveFileDialog();
			this.@__frame = new Bham.CmuCam.Gui.CmuView();
			@__windowLeftLbl = new System.Windows.Forms.Label();
			@__windowRightLbl = new System.Windows.Forms.Label();
			@__windowBottomLbl = new System.Windows.Forms.Label();
			@__windowTopLbl = new System.Windows.Forms.Label();
			this.@__status.SuspendLayout();
			this.@__trackMaxGrp.SuspendLayout();
			this.@__trackMinGrp.SuspendLayout();
			this.@__tabs.SuspendLayout();
			this.@__tabStill.SuspendLayout();
			this.@__configGrp.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__configContrast)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__configBrightness)).BeginInit();
			this.@__tabTrack.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__trackNoiseFilter)).BeginInit();
			this.@__tabDiff.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__diffThreshold)).BeginInit();
			this.@__tabMean.SuspendLayout();
			this.@__tabHisto.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__histoScale)).BeginInit();
			this.@__tabAux.SuspendLayout();
			this.@__tabServo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__servoTiltSteps)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoTiltNear)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoTiltFar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoPanSteps)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoPanNear)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoPanFar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo1)).BeginInit();
			this.@__window.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__winDownsampleY)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.@__winDownsampleX)).BeginInit();
			this.SuspendLayout();
			// 
			// __windowLeftLbl
			// 
			@__windowLeftLbl.AutoSize = true;
			@__windowLeftLbl.Location = new System.Drawing.Point(183, 51);
			@__windowLeftLbl.Name = "__windowLeftLbl";
			@__windowLeftLbl.Size = new System.Drawing.Size(25, 13);
			@__windowLeftLbl.TabIndex = 6;
			@__windowLeftLbl.Text = "Left";
			// 
			// __windowRightLbl
			// 
			@__windowRightLbl.AutoSize = true;
			@__windowRightLbl.Location = new System.Drawing.Point(270, 51);
			@__windowRightLbl.Name = "__windowRightLbl";
			@__windowRightLbl.Size = new System.Drawing.Size(32, 13);
			@__windowRightLbl.TabIndex = 7;
			@__windowRightLbl.Text = "Right";
			// 
			// __windowBottomLbl
			// 
			@__windowBottomLbl.AutoSize = true;
			@__windowBottomLbl.Location = new System.Drawing.Point(216, 78);
			@__windowBottomLbl.Name = "__windowBottomLbl";
			@__windowBottomLbl.Size = new System.Drawing.Size(40, 13);
			@__windowBottomLbl.TabIndex = 9;
			@__windowBottomLbl.Text = "Bottom";
			// 
			// __windowTopLbl
			// 
			@__windowTopLbl.AutoSize = true;
			@__windowTopLbl.Location = new System.Drawing.Point(230, 26);
			@__windowTopLbl.Name = "__windowTopLbl";
			@__windowTopLbl.Size = new System.Drawing.Size(26, 13);
			@__windowTopLbl.TabIndex = 8;
			@__windowTopLbl.Text = "Top";
			// 
			// __status
			// 
			this.@__status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.@__frameProgress,
            this.@__statusLbl});
			this.@__status.Location = new System.Drawing.Point(0, 637);
			this.@__status.Name = "__status";
			this.@__status.Size = new System.Drawing.Size(860, 22);
			this.@__status.TabIndex = 10;
			// 
			// __frameProgress
			// 
			this.@__frameProgress.Name = "__frameProgress";
			this.@__frameProgress.Size = new System.Drawing.Size(150, 16);
			// 
			// __statusLbl
			// 
			this.@__statusLbl.Name = "__statusLbl";
			this.@__statusLbl.Size = new System.Drawing.Size(39, 17);
			this.@__statusLbl.Text = "Ready";
			// 
			// __pickColorLbl
			// 
			this.@__pickColorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.@__pickColorLbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.@__pickColorLbl.Location = new System.Drawing.Point(83, 608);
			this.@__pickColorLbl.Name = "__pickColorLbl";
			this.@__pickColorLbl.Size = new System.Drawing.Size(76, 22);
			this.@__pickColorLbl.TabIndex = 16;
			this.@__pickColorLbl.Text = "255,255,255";
			this.@__pickColorLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// __pickColor
			// 
			this.@__pickColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.@__pickColor.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__pickColor.AutoSize = true;
			this.@__pickColor.Location = new System.Drawing.Point(12, 607);
			this.@__pickColor.Name = "__pickColor";
			this.@__pickColor.Size = new System.Drawing.Size(65, 23);
			this.@__pickColor.TabIndex = 1;
			this.@__pickColor.Text = "Pick Color";
			this.@__pickColor.UseVisualStyleBackColor = true;
			// 
			// __viewStretch
			// 
			this.@__viewStretch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.@__viewStretch.AutoSize = true;
			this.@__viewStretch.Location = new System.Drawing.Point(173, 611);
			this.@__viewStretch.Name = "__viewStretch";
			this.@__viewStretch.Size = new System.Drawing.Size(60, 17);
			this.@__viewStretch.TabIndex = 2;
			this.@__viewStretch.Text = "Stretch";
			this.@__viewStretch.UseVisualStyleBackColor = true;
			// 
			// __histoLiveChannel
			// 
			this.@__histoLiveChannel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.@__histoLiveChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__histoLiveChannel.FormattingEnabled = true;
			this.@__histoLiveChannel.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
			this.@__histoLiveChannel.Location = new System.Drawing.Point(105, 15);
			this.@__histoLiveChannel.Name = "__histoLiveChannel";
			this.@__histoLiveChannel.Size = new System.Drawing.Size(83, 21);
			this.@__histoLiveChannel.TabIndex = 1;
			// 
			// __histoLive
			// 
			this.@__histoLive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.@__histoLive.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__histoLive.AutoSize = true;
			this.@__histoLive.Location = new System.Drawing.Point(12, 14);
			this.@__histoLive.Name = "__histoLive";
			this.@__histoLive.Size = new System.Drawing.Size(87, 23);
			this.@__histoLive.TabIndex = 0;
			this.@__histoLive.Text = "Live Histogram";
			this.@__histoLive.UseVisualStyleBackColor = true;
			// 
			// __histoRefresh
			// 
			this.@__histoRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.@__histoRefresh.Location = new System.Drawing.Point(9, 387);
			this.@__histoRefresh.Name = "__histoRefresh";
			this.@__histoRefresh.Size = new System.Drawing.Size(132, 23);
			this.@__histoRefresh.TabIndex = 5;
			this.@__histoRefresh.Text = "Reload All Histograms";
			this.@__histoRefresh.UseVisualStyleBackColor = true;
			// 
			// __stillChannel
			// 
			this.@__stillChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__stillChannel.FormattingEnabled = true;
			this.@__stillChannel.Items.AddRange(new object[] {
            "All",
            "Red",
            "Green",
            "Blue"});
			this.@__stillChannel.Location = new System.Drawing.Point(82, 160);
			this.@__stillChannel.Name = "__stillChannel";
			this.@__stillChannel.Size = new System.Drawing.Size(126, 21);
			this.@__stillChannel.TabIndex = 4;
			// 
			// __stillGetFrame
			// 
			this.@__stillGetFrame.Location = new System.Drawing.Point(17, 204);
			this.@__stillGetFrame.Name = "__stillGetFrame";
			this.@__stillGetFrame.Size = new System.Drawing.Size(97, 23);
			this.@__stillGetFrame.TabIndex = 5;
			this.@__stillGetFrame.Text = "Get Single Frame";
			this.@__tip.SetToolTip(this.@__stillGetFrame, "Downloads a single image frame from the camera. This takes about 3 seconds for a " +
					"low resolution frame and 12 seconds for a high-resolution frame.");
			this.@__stillGetFrame.UseVisualStyleBackColor = true;
			// 
			// __trackMaxGrp
			// 
			this.@__trackMaxGrp.Controls.Add(this.@__trackMaxColor);
			this.@__trackMaxGrp.Controls.Add(this.@__trackMaxB);
			this.@__trackMaxGrp.Controls.Add(this.@__trackMaxR);
			this.@__trackMaxGrp.Controls.Add(this.@__trackMaxG);
			this.@__trackMaxGrp.Location = new System.Drawing.Point(13, 145);
			this.@__trackMaxGrp.Name = "__trackMaxGrp";
			this.@__trackMaxGrp.Size = new System.Drawing.Size(203, 48);
			this.@__trackMaxGrp.TabIndex = 17;
			this.@__trackMaxGrp.TabStop = false;
			this.@__trackMaxGrp.Text = "Maximum";
			// 
			// __trackMaxColor
			// 
			this.@__trackMaxColor.Location = new System.Drawing.Point(150, 18);
			this.@__trackMaxColor.Name = "__trackMaxColor";
			this.@__trackMaxColor.Size = new System.Drawing.Size(42, 20);
			this.@__trackMaxColor.TabIndex = 3;
			this.@__tip.SetToolTip(this.@__trackMaxColor, "Pick a color from the System color picker.");
			this.@__trackMaxColor.UseVisualStyleBackColor = true;
			// 
			// __trackMaxB
			// 
			this.@__trackMaxB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.@__trackMaxB.Location = new System.Drawing.Point(102, 19);
			this.@__trackMaxB.Name = "__trackMaxB";
			this.@__trackMaxB.Size = new System.Drawing.Size(42, 20);
			this.@__trackMaxB.TabIndex = 2;
			this.@__trackMaxB.Text = "60";
			// 
			// __trackMaxR
			// 
			this.@__trackMaxR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.@__trackMaxR.Location = new System.Drawing.Point(6, 19);
			this.@__trackMaxR.Name = "__trackMaxR";
			this.@__trackMaxR.Size = new System.Drawing.Size(42, 20);
			this.@__trackMaxR.TabIndex = 0;
			this.@__trackMaxR.Text = "60";
			// 
			// __trackMaxG
			// 
			this.@__trackMaxG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
			this.@__trackMaxG.Location = new System.Drawing.Point(54, 19);
			this.@__trackMaxG.Name = "__trackMaxG";
			this.@__trackMaxG.Size = new System.Drawing.Size(42, 20);
			this.@__trackMaxG.TabIndex = 1;
			this.@__trackMaxG.Text = "255";
			// 
			// __trackMinGrp
			// 
			this.@__trackMinGrp.Controls.Add(this.@__trackMinColor);
			this.@__trackMinGrp.Controls.Add(this.@__trackMinB);
			this.@__trackMinGrp.Controls.Add(this.@__trackMinG);
			this.@__trackMinGrp.Controls.Add(this.@__trackMinR);
			this.@__trackMinGrp.Location = new System.Drawing.Point(12, 80);
			this.@__trackMinGrp.Name = "__trackMinGrp";
			this.@__trackMinGrp.Size = new System.Drawing.Size(204, 48);
			this.@__trackMinGrp.TabIndex = 16;
			this.@__trackMinGrp.TabStop = false;
			this.@__trackMinGrp.Text = "Minimum";
			// 
			// __trackMinColor
			// 
			this.@__trackMinColor.Location = new System.Drawing.Point(151, 19);
			this.@__trackMinColor.Name = "__trackMinColor";
			this.@__trackMinColor.Size = new System.Drawing.Size(42, 20);
			this.@__trackMinColor.TabIndex = 3;
			this.@__tip.SetToolTip(this.@__trackMinColor, "Pick a color from the System color picker.");
			this.@__trackMinColor.UseVisualStyleBackColor = true;
			// 
			// __trackMinB
			// 
			this.@__trackMinB.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.@__trackMinB.Location = new System.Drawing.Point(102, 19);
			this.@__trackMinB.Name = "__trackMinB";
			this.@__trackMinB.Size = new System.Drawing.Size(42, 20);
			this.@__trackMinB.TabIndex = 2;
			this.@__trackMinB.Text = "40";
			// 
			// __trackMinG
			// 
			this.@__trackMinG.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(255)))), ((int)(((byte)(200)))));
			this.@__trackMinG.Location = new System.Drawing.Point(54, 19);
			this.@__trackMinG.Name = "__trackMinG";
			this.@__trackMinG.Size = new System.Drawing.Size(42, 20);
			this.@__trackMinG.TabIndex = 1;
			this.@__trackMinG.Text = "60";
			// 
			// __trackMinR
			// 
			this.@__trackMinR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
			this.@__trackMinR.Location = new System.Drawing.Point(6, 19);
			this.@__trackMinR.Name = "__trackMinR";
			this.@__trackMinR.Size = new System.Drawing.Size(42, 20);
			this.@__trackMinR.TabIndex = 0;
			this.@__trackMinR.Text = "40";
			// 
			// __trackLiveColor
			// 
			this.@__trackLiveColor.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__trackLiveColor.Location = new System.Drawing.Point(13, 329);
			this.@__trackLiveColor.Name = "__trackLiveColor";
			this.@__trackLiveColor.Size = new System.Drawing.Size(181, 23);
			this.@__trackLiveColor.TabIndex = 6;
			this.@__trackLiveColor.Text = "Live Tracking on Color";
			this.@__trackLiveColor.UseVisualStyleBackColor = true;
			// 
			// __windowLeft
			// 
			this.@__windowLeft.Location = new System.Drawing.Point(214, 48);
			this.@__windowLeft.Name = "__windowLeft";
			this.@__windowLeft.Size = new System.Drawing.Size(45, 20);
			this.@__windowLeft.TabIndex = 5;
			// 
			// __windowRight
			// 
			this.@__windowRight.Location = new System.Drawing.Point(308, 48);
			this.@__windowRight.Name = "__windowRight";
			this.@__windowRight.Size = new System.Drawing.Size(45, 20);
			this.@__windowRight.TabIndex = 4;
			// 
			// __windowBottom
			// 
			this.@__windowBottom.Location = new System.Drawing.Point(262, 75);
			this.@__windowBottom.Name = "__windowBottom";
			this.@__windowBottom.Size = new System.Drawing.Size(45, 20);
			this.@__windowBottom.TabIndex = 6;
			// 
			// __windowReset
			// 
			this.@__windowReset.Location = new System.Drawing.Point(336, 75);
			this.@__windowReset.Name = "__windowReset";
			this.@__windowReset.Size = new System.Drawing.Size(75, 23);
			this.@__windowReset.TabIndex = 7;
			this.@__windowReset.Text = "Reset";
			this.@__windowReset.UseVisualStyleBackColor = true;
			// 
			// __winHighRes
			// 
			this.@__winHighRes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.@__winHighRes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__winHighRes.FormattingEnabled = true;
			this.@__winHighRes.Items.AddRange(new object[] {
            "Low Resolution",
            "High Resolution"});
			this.@__winHighRes.Location = new System.Drawing.Point(16, 22);
			this.@__winHighRes.Name = "__winHighRes";
			this.@__winHighRes.Size = new System.Drawing.Size(150, 21);
			this.@__winHighRes.TabIndex = 0;
			// 
			// __windowTop
			// 
			this.@__windowTop.Location = new System.Drawing.Point(262, 23);
			this.@__windowTop.Name = "__windowTop";
			this.@__windowTop.Size = new System.Drawing.Size(45, 20);
			this.@__windowTop.TabIndex = 3;
			// 
			// __tabs
			// 
			this.@__tabs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__tabs.Controls.Add(this.@__tabStill);
			this.@__tabs.Controls.Add(this.@__tabTrack);
			this.@__tabs.Controls.Add(this.@__tabDiff);
			this.@__tabs.Controls.Add(this.@__tabMean);
			this.@__tabs.Controls.Add(this.@__tabHisto);
			this.@__tabs.Controls.Add(this.@__tabAux);
			this.@__tabs.Controls.Add(this.@__tabServo);
			this.@__tabs.Location = new System.Drawing.Point(427, 136);
			this.@__tabs.Name = "__tabs";
			this.@__tabs.SelectedIndex = 0;
			this.@__tabs.Size = new System.Drawing.Size(421, 465);
			this.@__tabs.TabIndex = 0;
			// 
			// __tabStill
			// 
			this.@__tabStill.AutoScroll = true;
			this.@__tabStill.Controls.Add(this.@__stillGetFrameStream);
			this.@__tabStill.Controls.Add(this.@__configGrp);
			this.@__tabStill.Controls.Add(this.@__configContrastLbl);
			this.@__tabStill.Controls.Add(this.@__configBrightnessLbl);
			this.@__tabStill.Controls.Add(this.@__configContrast);
			this.@__tabStill.Controls.Add(this.@__configBrightness);
			this.@__tabStill.Controls.Add(this.@__stillBufferLoad);
			this.@__tabStill.Controls.Add(this.@__stillBuffer);
			this.@__tabStill.Controls.Add(this.@__stillChannelLbl);
			this.@__tabStill.Controls.Add(this.@__stillGetFrame);
			this.@__tabStill.Controls.Add(this.@__stillChannel);
			this.@__tabStill.Location = new System.Drawing.Point(4, 22);
			this.@__tabStill.Name = "__tabStill";
			this.@__tabStill.Padding = new System.Windows.Forms.Padding(3);
			this.@__tabStill.Size = new System.Drawing.Size(413, 439);
			this.@__tabStill.TabIndex = 1;
			this.@__tabStill.Text = "Images";
			this.@__tabStill.UseVisualStyleBackColor = true;
			// 
			// __stillGetFrameStream
			// 
			this.@__stillGetFrameStream.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__stillGetFrameStream.AutoSize = true;
			this.@__stillGetFrameStream.Location = new System.Drawing.Point(120, 204);
			this.@__stillGetFrameStream.Name = "__stillGetFrameStream";
			this.@__stillGetFrameStream.Size = new System.Drawing.Size(87, 23);
			this.@__stillGetFrameStream.TabIndex = 27;
			this.@__stillGetFrameStream.Text = "Stream Frames";
			this.@__stillGetFrameStream.UseVisualStyleBackColor = true;
			// 
			// __configGrp
			// 
			this.@__configGrp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__configGrp.Controls.Add(this.@__configColorMode);
			this.@__configGrp.Controls.Add(this.@__configReset);
			this.@__configGrp.Controls.Add(this.@__configPixelDifference);
			this.@__configGrp.Controls.Add(this.@__configColorModeLbl);
			this.@__configGrp.Controls.Add(this.@__configAutoExposureGain);
			this.@__configGrp.Location = new System.Drawing.Point(6, 263);
			this.@__configGrp.Name = "__configGrp";
			this.@__configGrp.Size = new System.Drawing.Size(401, 134);
			this.@__configGrp.TabIndex = 26;
			this.@__configGrp.TabStop = false;
			this.@__configGrp.Text = "Camera Configuration";
			// 
			// __configColorMode
			// 
			this.@__configColorMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__configColorMode.FormattingEnabled = true;
			this.@__configColorMode.Items.AddRange(new object[] {
            "RGB",
            "RGB with White Balance",
            "YCbCr",
            "YCbCr with White Balance"});
			this.@__configColorMode.Location = new System.Drawing.Point(106, 37);
			this.@__configColorMode.Name = "__configColorMode";
			this.@__configColorMode.Size = new System.Drawing.Size(188, 21);
			this.@__configColorMode.TabIndex = 0;
			// 
			// __configReset
			// 
			this.@__configReset.Location = new System.Drawing.Point(252, 97);
			this.@__configReset.Name = "__configReset";
			this.@__configReset.Size = new System.Drawing.Size(106, 23);
			this.@__configReset.TabIndex = 3;
			this.@__configReset.Text = "Reset Camera";
			this.@__configReset.UseVisualStyleBackColor = true;
			// 
			// __configPixelDifference
			// 
			this.@__configPixelDifference.AutoSize = true;
			this.@__configPixelDifference.Location = new System.Drawing.Point(22, 97);
			this.@__configPixelDifference.Name = "__configPixelDifference";
			this.@__configPixelDifference.Size = new System.Drawing.Size(130, 17);
			this.@__configPixelDifference.TabIndex = 2;
			this.@__configPixelDifference.Text = "Pixel Difference Mode";
			this.@__tip.SetToolTip(this.@__configPixelDifference, resources.GetString("__configPixelDifference.ToolTip"));
			this.@__configPixelDifference.UseVisualStyleBackColor = true;
			// 
			// __configColorModeLbl
			// 
			this.@__configColorModeLbl.AutoSize = true;
			this.@__configColorModeLbl.Location = new System.Drawing.Point(19, 40);
			this.@__configColorModeLbl.Name = "__configColorModeLbl";
			this.@__configColorModeLbl.Size = new System.Drawing.Size(61, 13);
			this.@__configColorModeLbl.TabIndex = 18;
			this.@__configColorModeLbl.Text = "Color Mode";
			// 
			// __configAutoExposureGain
			// 
			this.@__configAutoExposureGain.AutoSize = true;
			this.@__configAutoExposureGain.Location = new System.Drawing.Point(22, 74);
			this.@__configAutoExposureGain.Name = "__configAutoExposureGain";
			this.@__configAutoExposureGain.Size = new System.Drawing.Size(162, 17);
			this.@__configAutoExposureGain.TabIndex = 1;
			this.@__configAutoExposureGain.Text = "Auto-Exposure Gain Enabled";
			this.@__configAutoExposureGain.UseVisualStyleBackColor = true;
			// 
			// __configContrastLbl
			// 
			this.@__configContrastLbl.AutoSize = true;
			this.@__configContrastLbl.Location = new System.Drawing.Point(15, 109);
			this.@__configContrastLbl.Name = "__configContrastLbl";
			this.@__configContrastLbl.Size = new System.Drawing.Size(46, 13);
			this.@__configContrastLbl.TabIndex = 22;
			this.@__configContrastLbl.Text = "Contrast";
			// 
			// __configBrightnessLbl
			// 
			this.@__configBrightnessLbl.AutoSize = true;
			this.@__configBrightnessLbl.Location = new System.Drawing.Point(15, 52);
			this.@__configBrightnessLbl.Name = "__configBrightnessLbl";
			this.@__configBrightnessLbl.Size = new System.Drawing.Size(56, 13);
			this.@__configBrightnessLbl.TabIndex = 21;
			this.@__configBrightnessLbl.Text = "Brightness";
			// 
			// __configContrast
			// 
			this.@__configContrast.Location = new System.Drawing.Point(82, 109);
			this.@__configContrast.Maximum = 255;
			this.@__configContrast.Name = "__configContrast";
			this.@__configContrast.Size = new System.Drawing.Size(310, 45);
			this.@__configContrast.TabIndex = 3;
			this.@__configContrast.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// __configBrightness
			// 
			this.@__configBrightness.Location = new System.Drawing.Point(82, 52);
			this.@__configBrightness.Maximum = 255;
			this.@__configBrightness.Name = "__configBrightness";
			this.@__configBrightness.Size = new System.Drawing.Size(310, 45);
			this.@__configBrightness.TabIndex = 2;
			this.@__configBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// __stillBufferLoad
			// 
			this.@__stillBufferLoad.Location = new System.Drawing.Point(146, 11);
			this.@__stillBufferLoad.Name = "__stillBufferLoad";
			this.@__stillBufferLoad.Size = new System.Drawing.Size(138, 23);
			this.@__stillBufferLoad.TabIndex = 1;
			this.@__stillBufferLoad.Text = "Load Frame Into Buffer";
			this.@__tip.SetToolTip(this.@__stillBufferLoad, "Causes the camera to retake a new frame from the sensor and store is in the buffe" +
					"r cache for processing.");
			this.@__stillBufferLoad.UseVisualStyleBackColor = true;
			// 
			// __stillBuffer
			// 
			this.@__stillBuffer.AutoSize = true;
			this.@__stillBuffer.Location = new System.Drawing.Point(12, 15);
			this.@__stillBuffer.Name = "__stillBuffer";
			this.@__stillBuffer.Size = new System.Drawing.Size(128, 17);
			this.@__stillBuffer.TabIndex = 0;
			this.@__stillBuffer.Text = "Image Buffer Enabled";
			this.@__tip.SetToolTip(this.@__stillBuffer, "When checked, the current frame is cached in a buffer for processing and will rem" +
					"ain there until Load Frame is commanded. When unchecked a new frame will be retu" +
					"rned when clicking Get Frame.");
			this.@__stillBuffer.UseVisualStyleBackColor = true;
			// 
			// __stillChannelLbl
			// 
			this.@__stillChannelLbl.AutoSize = true;
			this.@__stillChannelLbl.Location = new System.Drawing.Point(14, 163);
			this.@__stillChannelLbl.Name = "__stillChannelLbl";
			this.@__stillChannelLbl.Size = new System.Drawing.Size(51, 13);
			this.@__stillChannelLbl.TabIndex = 15;
			this.@__stillChannelLbl.Text = "Channels";
			// 
			// __tabTrack
			// 
			this.@__tabTrack.AutoScroll = true;
			this.@__tabTrack.Controls.Add(this.@__trackLiveWindowM2);
			this.@__tabTrack.Controls.Add(this.@__trackLiveColorM2);
			this.@__tabTrack.Controls.Add(this.@__trackLiveWindowM1);
			this.@__tabTrack.Controls.Add(this.@__trackLiveColorM1);
			this.@__tabTrack.Controls.Add(this.@__trackLiveWindow);
			this.@__tabTrack.Controls.Add(this.@__trackNoiseFilterLbl);
			this.@__tabTrack.Controls.Add(this.@__trackNoiseFilter);
			this.@__tabTrack.Controls.Add(this.@__trackDefineLbl);
			this.@__tabTrack.Controls.Add(this.@__trackDefine);
			this.@__tabTrack.Controls.Add(this.@__trackInverted);
			this.@__tabTrack.Controls.Add(this.@__trackMaxGrp);
			this.@__tabTrack.Controls.Add(this.@__trackLiveColor);
			this.@__tabTrack.Controls.Add(this.@__trackMinGrp);
			this.@__tabTrack.Location = new System.Drawing.Point(4, 22);
			this.@__tabTrack.Name = "__tabTrack";
			this.@__tabTrack.Size = new System.Drawing.Size(413, 439);
			this.@__tabTrack.TabIndex = 2;
			this.@__tabTrack.Text = "Tracking";
			this.@__tabTrack.UseVisualStyleBackColor = true;
			// 
			// __trackLiveWindowM2
			// 
			this.@__trackLiveWindowM2.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__trackLiveWindowM2.Location = new System.Drawing.Point(200, 387);
			this.@__trackLiveWindowM2.Name = "__trackLiveWindowM2";
			this.@__trackLiveWindowM2.Size = new System.Drawing.Size(196, 23);
			this.@__trackLiveWindowM2.TabIndex = 24;
			this.@__trackLiveWindowM2.Text = "Live Tracking on Window with Stats";
			this.@__trackLiveWindowM2.UseVisualStyleBackColor = true;
			// 
			// __trackLiveColorM2
			// 
			this.@__trackLiveColorM2.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__trackLiveColorM2.Location = new System.Drawing.Point(13, 387);
			this.@__trackLiveColorM2.Name = "__trackLiveColorM2";
			this.@__trackLiveColorM2.Size = new System.Drawing.Size(181, 23);
			this.@__trackLiveColorM2.TabIndex = 23;
			this.@__trackLiveColorM2.Text = "Live Tracking on Color with Stats";
			this.@__trackLiveColorM2.UseVisualStyleBackColor = true;
			// 
			// __trackLiveWindowM1
			// 
			this.@__trackLiveWindowM1.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__trackLiveWindowM1.Location = new System.Drawing.Point(200, 358);
			this.@__trackLiveWindowM1.Name = "__trackLiveWindowM1";
			this.@__trackLiveWindowM1.Size = new System.Drawing.Size(196, 23);
			this.@__trackLiveWindowM1.TabIndex = 22;
			this.@__trackLiveWindowM1.Text = "Live Tracking on Window with Bitmap";
			this.@__trackLiveWindowM1.UseVisualStyleBackColor = true;
			// 
			// __trackLiveColorM1
			// 
			this.@__trackLiveColorM1.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__trackLiveColorM1.Location = new System.Drawing.Point(13, 358);
			this.@__trackLiveColorM1.Name = "__trackLiveColorM1";
			this.@__trackLiveColorM1.Size = new System.Drawing.Size(181, 23);
			this.@__trackLiveColorM1.TabIndex = 21;
			this.@__trackLiveColorM1.Text = "Live Tracking on Color with Bitmap";
			this.@__trackLiveColorM1.UseVisualStyleBackColor = true;
			// 
			// __trackLiveWindow
			// 
			this.@__trackLiveWindow.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__trackLiveWindow.Location = new System.Drawing.Point(200, 329);
			this.@__trackLiveWindow.Name = "__trackLiveWindow";
			this.@__trackLiveWindow.Size = new System.Drawing.Size(196, 23);
			this.@__trackLiveWindow.TabIndex = 7;
			this.@__trackLiveWindow.Text = "Live Tracking on Window";
			this.@__trackLiveWindow.UseVisualStyleBackColor = true;
			// 
			// __trackNoiseFilterLbl
			// 
			this.@__trackNoiseFilterLbl.AutoSize = true;
			this.@__trackNoiseFilterLbl.Location = new System.Drawing.Point(15, 240);
			this.@__trackNoiseFilterLbl.Name = "__trackNoiseFilterLbl";
			this.@__trackNoiseFilterLbl.Size = new System.Drawing.Size(59, 13);
			this.@__trackNoiseFilterLbl.TabIndex = 2;
			this.@__trackNoiseFilterLbl.Text = "Noise Filter";
			this.@__tip.SetToolTip(this.@__trackNoiseFilterLbl, "How many consecutive active pixels before the current pixel are required before t" +
					"he pixel should be detected (default 2). The range is between 0 and 255.");
			// 
			// __trackNoiseFilter
			// 
			this.@__trackNoiseFilter.Location = new System.Drawing.Point(93, 237);
			this.@__trackNoiseFilter.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.@__trackNoiseFilter.Name = "__trackNoiseFilter";
			this.@__trackNoiseFilter.Size = new System.Drawing.Size(63, 20);
			this.@__trackNoiseFilter.TabIndex = 3;
			this.@__tip.SetToolTip(this.@__trackNoiseFilter, "How many consecutive active pixels before the current pixel are required before t" +
					"he pixel should be detected (default 2). The range is between 0 and 255.");
			// 
			// __trackDefineLbl
			// 
			this.@__trackDefineLbl.AutoSize = true;
			this.@__trackDefineLbl.Location = new System.Drawing.Point(16, 26);
			this.@__trackDefineLbl.Name = "__trackDefineLbl";
			this.@__trackDefineLbl.Size = new System.Drawing.Size(125, 13);
			this.@__trackDefineLbl.TabIndex = 20;
			this.@__trackDefineLbl.Text = "Common Tracking Colors";
			// 
			// __trackDefine
			// 
			this.@__trackDefine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__trackDefine.FormattingEnabled = true;
			this.@__trackDefine.Items.AddRange(new object[] {
            "Custom",
            "Red",
            "Green",
            "Blue",
            "Yellow"});
			this.@__trackDefine.Location = new System.Drawing.Point(18, 42);
			this.@__trackDefine.Name = "__trackDefine";
			this.@__trackDefine.Size = new System.Drawing.Size(138, 21);
			this.@__trackDefine.TabIndex = 0;
			// 
			// __trackInverted
			// 
			this.@__trackInverted.AutoSize = true;
			this.@__trackInverted.Location = new System.Drawing.Point(19, 208);
			this.@__trackInverted.Name = "__trackInverted";
			this.@__trackInverted.Size = new System.Drawing.Size(140, 17);
			this.@__trackInverted.TabIndex = 1;
			this.@__trackInverted.Text = "Inverted Tracking Mode";
			this.@__tip.SetToolTip(this.@__trackInverted, "When checked, the camera will track objects outside of the min-max color range, a" +
					"s opposed to colors within the range.");
			this.@__trackInverted.UseVisualStyleBackColor = true;
			// 
			// __tabDiff
			// 
			this.@__tabDiff.AutoScroll = true;
			this.@__tabDiff.Controls.Add(this.@__diffLiveM3);
			this.@__tabDiff.Controls.Add(this.@__diffLiveM2);
			this.@__tabDiff.Controls.Add(this.@__diffLiveM1);
			this.@__tabDiff.Controls.Add(this.@__diffLive);
			this.@__tabDiff.Controls.Add(this.@__diffThresholdLbl);
			this.@__tabDiff.Controls.Add(this.@__diffThreshold);
			this.@__tabDiff.Controls.Add(this.@__diffLoad);
			this.@__tabDiff.Controls.Add(this.@__diffChannelLbl);
			this.@__tabDiff.Controls.Add(this.@__diffChannel);
			this.@__tabDiff.Controls.Add(this.@__diffHighRes);
			this.@__tabDiff.Location = new System.Drawing.Point(4, 22);
			this.@__tabDiff.Name = "__tabDiff";
			this.@__tabDiff.Size = new System.Drawing.Size(413, 439);
			this.@__tabDiff.TabIndex = 3;
			this.@__tabDiff.Text = "Difference";
			this.@__tabDiff.UseVisualStyleBackColor = true;
			// 
			// __diffLiveM3
			// 
			this.@__diffLiveM3.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__diffLiveM3.Enabled = false;
			this.@__diffLiveM3.Location = new System.Drawing.Point(17, 258);
			this.@__diffLiveM3.Name = "__diffLiveM3";
			this.@__diffLiveM3.Size = new System.Drawing.Size(281, 23);
			this.@__diffLiveM3.TabIndex = 27;
			this.@__diffLiveM3.Text = "Live Frame Difference with Original Frame Bitmap";
			this.@__diffLiveM3.UseVisualStyleBackColor = true;
			// 
			// __diffLiveM2
			// 
			this.@__diffLiveM2.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__diffLiveM2.Enabled = false;
			this.@__diffLiveM2.Location = new System.Drawing.Point(17, 229);
			this.@__diffLiveM2.Name = "__diffLiveM2";
			this.@__diffLiveM2.Size = new System.Drawing.Size(281, 23);
			this.@__diffLiveM2.TabIndex = 26;
			this.@__diffLiveM2.Text = "Live Frame Difference with Delta Bitmap";
			this.@__diffLiveM2.UseVisualStyleBackColor = true;
			// 
			// __diffLiveM1
			// 
			this.@__diffLiveM1.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__diffLiveM1.Enabled = false;
			this.@__diffLiveM1.Location = new System.Drawing.Point(17, 200);
			this.@__diffLiveM1.Name = "__diffLiveM1";
			this.@__diffLiveM1.Size = new System.Drawing.Size(281, 23);
			this.@__diffLiveM1.TabIndex = 25;
			this.@__diffLiveM1.Text = "Live Frame Difference with Bitmap";
			this.@__diffLiveM1.UseVisualStyleBackColor = true;
			// 
			// __diffLive
			// 
			this.@__diffLive.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__diffLive.Location = new System.Drawing.Point(17, 171);
			this.@__diffLive.Name = "__diffLive";
			this.@__diffLive.Size = new System.Drawing.Size(281, 23);
			this.@__diffLive.TabIndex = 24;
			this.@__diffLive.Text = "Live Frame Difference";
			this.@__diffLive.UseVisualStyleBackColor = true;
			// 
			// __diffThresholdLbl
			// 
			this.@__diffThresholdLbl.AutoSize = true;
			this.@__diffThresholdLbl.Location = new System.Drawing.Point(14, 88);
			this.@__diffThresholdLbl.Name = "__diffThresholdLbl";
			this.@__diffThresholdLbl.Size = new System.Drawing.Size(54, 13);
			this.@__diffThresholdLbl.TabIndex = 21;
			this.@__diffThresholdLbl.Text = "Threshold";
			// 
			// __diffThreshold
			// 
			this.@__diffThreshold.Location = new System.Drawing.Point(142, 86);
			this.@__diffThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
			this.@__diffThreshold.Name = "__diffThreshold";
			this.@__diffThreshold.Size = new System.Drawing.Size(77, 20);
			this.@__diffThreshold.TabIndex = 20;
			this.@__diffThreshold.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
			// 
			// __diffLoad
			// 
			this.@__diffLoad.Location = new System.Drawing.Point(17, 137);
			this.@__diffLoad.Name = "__diffLoad";
			this.@__diffLoad.Size = new System.Drawing.Size(281, 23);
			this.@__diffLoad.TabIndex = 18;
			this.@__diffLoad.Text = "Load Frame into Difference Buffer";
			this.@__diffLoad.UseVisualStyleBackColor = true;
			// 
			// __diffChannelLbl
			// 
			this.@__diffChannelLbl.AutoSize = true;
			this.@__diffChannelLbl.Location = new System.Drawing.Point(14, 52);
			this.@__diffChannelLbl.Name = "__diffChannelLbl";
			this.@__diffChannelLbl.Size = new System.Drawing.Size(46, 13);
			this.@__diffChannelLbl.TabIndex = 17;
			this.@__diffChannelLbl.Text = "Channel";
			// 
			// __diffChannel
			// 
			this.@__diffChannel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__diffChannel.FormattingEnabled = true;
			this.@__diffChannel.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
			this.@__diffChannel.Location = new System.Drawing.Point(93, 49);
			this.@__diffChannel.Name = "__diffChannel";
			this.@__diffChannel.Size = new System.Drawing.Size(126, 21);
			this.@__diffChannel.TabIndex = 1;
			// 
			// __diffHighRes
			// 
			this.@__diffHighRes.AutoSize = true;
			this.@__diffHighRes.Location = new System.Drawing.Point(17, 19);
			this.@__diffHighRes.Name = "__diffHighRes";
			this.@__diffHighRes.Size = new System.Drawing.Size(193, 17);
			this.@__diffHighRes.TabIndex = 0;
			this.@__diffHighRes.Text = "High-Resolution Frame Differencing";
			this.@__diffHighRes.UseVisualStyleBackColor = true;
			// 
			// __tabMean
			// 
			this.@__tabMean.AutoScroll = true;
			this.@__tabMean.Controls.Add(this.@__meanLiveM2);
			this.@__tabMean.Controls.Add(this.@__meanLiveM1);
			this.@__tabMean.Controls.Add(this.@__meanLive);
			this.@__tabMean.Controls.Add(this.@__mean);
			this.@__tabMean.Location = new System.Drawing.Point(4, 22);
			this.@__tabMean.Name = "__tabMean";
			this.@__tabMean.Padding = new System.Windows.Forms.Padding(3);
			this.@__tabMean.Size = new System.Drawing.Size(413, 439);
			this.@__tabMean.TabIndex = 8;
			this.@__tabMean.Text = "Mean";
			this.@__tabMean.UseVisualStyleBackColor = true;
			// 
			// __meanLiveM2
			// 
			this.@__meanLiveM2.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__meanLiveM2.Location = new System.Drawing.Point(12, 91);
			this.@__meanLiveM2.Name = "__meanLiveM2";
			this.@__meanLiveM2.Size = new System.Drawing.Size(161, 51);
			this.@__meanLiveM2.TabIndex = 3;
			this.@__meanLiveM2.Text = "Live Mean Display with Per-Line Mean and Deviation Values";
			this.@__meanLiveM2.UseVisualStyleBackColor = true;
			// 
			// __meanLiveM1
			// 
			this.@__meanLiveM1.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__meanLiveM1.Location = new System.Drawing.Point(12, 45);
			this.@__meanLiveM1.Name = "__meanLiveM1";
			this.@__meanLiveM1.Size = new System.Drawing.Size(161, 40);
			this.@__meanLiveM1.TabIndex = 2;
			this.@__meanLiveM1.Text = "Live Mean Display with Per-Line Mean Values";
			this.@__meanLiveM1.UseVisualStyleBackColor = true;
			// 
			// __meanLive
			// 
			this.@__meanLive.Appearance = System.Windows.Forms.Appearance.Button;
			this.@__meanLive.Location = new System.Drawing.Point(12, 15);
			this.@__meanLive.Name = "__meanLive";
			this.@__meanLive.Size = new System.Drawing.Size(161, 24);
			this.@__meanLive.TabIndex = 1;
			this.@__meanLive.Text = "Live Mean Display";
			this.@__meanLive.UseVisualStyleBackColor = true;
			// 
			// __mean
			// 
			this.@__mean.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__mean.FrameHeight = 140;
			this.@__mean.Location = new System.Drawing.Point(182, 6);
			this.@__mean.Name = "__mean";
			this.@__mean.Size = new System.Drawing.Size(225, 427);
			this.@__mean.SPacket = null;
			this.@__mean.TabIndex = 0;
			this.@__mean.Text = "meanDisplay1";
			// 
			// __tabHisto
			// 
			this.@__tabHisto.AutoScroll = true;
			this.@__tabHisto.Controls.Add(this.@__histoTrack);
			this.@__tabHisto.Controls.Add(this.@__histoScaleLbl);
			this.@__tabHisto.Controls.Add(this.@__histoScale);
			this.@__tabHisto.Controls.Add(this.@__histoBins);
			this.@__tabHisto.Controls.Add(this.@__histoLiveChannel);
			this.@__tabHisto.Controls.Add(this.@__histoLive);
			this.@__tabHisto.Controls.Add(this.@__histoRefresh);
			this.@__tabHisto.Controls.Add(this.@__histoRed);
			this.@__tabHisto.Controls.Add(this.@__histoGreen);
			this.@__tabHisto.Controls.Add(this.@__histoBlue);
			this.@__tabHisto.Location = new System.Drawing.Point(4, 22);
			this.@__tabHisto.Name = "__tabHisto";
			this.@__tabHisto.Size = new System.Drawing.Size(413, 439);
			this.@__tabHisto.TabIndex = 4;
			this.@__tabHisto.Text = "Histogram";
			this.@__tabHisto.UseVisualStyleBackColor = true;
			// 
			// __histoTrack
			// 
			this.@__histoTrack.AutoSize = true;
			this.@__histoTrack.Location = new System.Drawing.Point(14, 46);
			this.@__histoTrack.Name = "__histoTrack";
			this.@__histoTrack.Size = new System.Drawing.Size(285, 17);
			this.@__histoTrack.TabIndex = 4;
			this.@__histoTrack.Text = "Limit histogram to pixels within the Tracking color range";
			this.@__tip.SetToolTip(this.@__histoTrack, "Hint: Select a color range on the Tracking tab.");
			this.@__histoTrack.UseVisualStyleBackColor = true;
			// 
			// __histoScaleLbl
			// 
			this.@__histoScaleLbl.AutoSize = true;
			this.@__histoScaleLbl.Location = new System.Drawing.Point(283, 18);
			this.@__histoScaleLbl.Name = "__histoScaleLbl";
			this.@__histoScaleLbl.Size = new System.Drawing.Size(37, 13);
			this.@__histoScaleLbl.TabIndex = 24;
			this.@__histoScaleLbl.Text = "Scale:";
			// 
			// __histoScale
			// 
			this.@__histoScale.Location = new System.Drawing.Point(328, 15);
			this.@__histoScale.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.@__histoScale.Name = "__histoScale";
			this.@__histoScale.Size = new System.Drawing.Size(52, 20);
			this.@__histoScale.TabIndex = 3;
			// 
			// __histoBins
			// 
			this.@__histoBins.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.@__histoBins.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__histoBins.FormattingEnabled = true;
			this.@__histoBins.Items.AddRange(new object[] {
            "28 bins",
            "14 bins",
            "7 bins"});
			this.@__histoBins.Location = new System.Drawing.Point(194, 15);
			this.@__histoBins.Name = "__histoBins";
			this.@__histoBins.Size = new System.Drawing.Size(83, 21);
			this.@__histoBins.TabIndex = 2;
			// 
			// __histoRed
			// 
			this.@__histoRed.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__histoRed.HistogramColor = System.Drawing.Color.Red;
			this.@__histoRed.HistogramData = null;
			this.@__histoRed.Location = new System.Drawing.Point(9, 69);
			this.@__histoRed.Name = "__histoRed";
			this.@__histoRed.Size = new System.Drawing.Size(389, 100);
			this.@__histoRed.TabIndex = 16;
			this.@__histoRed.Text = "histogram1";
			// 
			// __histoGreen
			// 
			this.@__histoGreen.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__histoGreen.HistogramColor = System.Drawing.Color.Green;
			this.@__histoGreen.HistogramData = null;
			this.@__histoGreen.Location = new System.Drawing.Point(9, 175);
			this.@__histoGreen.Name = "__histoGreen";
			this.@__histoGreen.Size = new System.Drawing.Size(389, 100);
			this.@__histoGreen.TabIndex = 17;
			this.@__histoGreen.Text = "histogramDisplay1";
			// 
			// __histoBlue
			// 
			this.@__histoBlue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__histoBlue.HistogramColor = System.Drawing.Color.Blue;
			this.@__histoBlue.HistogramData = null;
			this.@__histoBlue.Location = new System.Drawing.Point(9, 281);
			this.@__histoBlue.Name = "__histoBlue";
			this.@__histoBlue.Size = new System.Drawing.Size(389, 100);
			this.@__histoBlue.TabIndex = 18;
			this.@__histoBlue.Text = "histogramDisplay2";
			// 
			// __tabAux
			// 
			this.@__tabAux.AutoScroll = true;
			this.@__tabAux.Controls.Add(this.@__auxAuxMsgBinLbl);
			this.@__tabAux.Controls.Add(this.@__auxAuxMsgDecLbl);
			this.@__tabAux.Controls.Add(this.@__auxAuxMsgHexLbl);
			this.@__tabAux.Controls.Add(this.@__auxLed2);
			this.@__tabAux.Controls.Add(this.@__auxLed2Lbl);
			this.@__tabAux.Controls.Add(this.@__auxLed1);
			this.@__tabAux.Controls.Add(this.@__auxLed1Lbl);
			this.@__tabAux.Controls.Add(this.@__auxAuxMsgBin);
			this.@__tabAux.Controls.Add(this.@__auxAuxMsgDec);
			this.@__tabAux.Controls.Add(this.@__auxAuxMsgHex);
			this.@__tabAux.Controls.Add(this.@__auxAux);
			this.@__tabAux.Controls.Add(this.@__auxBtnMsg);
			this.@__tabAux.Controls.Add(this.@__auxBtn);
			this.@__tabAux.Location = new System.Drawing.Point(4, 22);
			this.@__tabAux.Name = "__tabAux";
			this.@__tabAux.Size = new System.Drawing.Size(413, 439);
			this.@__tabAux.TabIndex = 7;
			this.@__tabAux.Text = "Aux IO";
			this.@__tabAux.UseVisualStyleBackColor = true;
			// 
			// __auxAuxMsgBinLbl
			// 
			this.@__auxAuxMsgBinLbl.AutoSize = true;
			this.@__auxAuxMsgBinLbl.Location = new System.Drawing.Point(273, 77);
			this.@__auxAuxMsgBinLbl.Name = "__auxAuxMsgBinLbl";
			this.@__auxAuxMsgBinLbl.Size = new System.Drawing.Size(40, 13);
			this.@__auxAuxMsgBinLbl.TabIndex = 14;
			this.@__auxAuxMsgBinLbl.Text = "Base 2";
			// 
			// __auxAuxMsgDecLbl
			// 
			this.@__auxAuxMsgDecLbl.AutoSize = true;
			this.@__auxAuxMsgDecLbl.Location = new System.Drawing.Point(204, 77);
			this.@__auxAuxMsgDecLbl.Name = "__auxAuxMsgDecLbl";
			this.@__auxAuxMsgDecLbl.Size = new System.Drawing.Size(46, 13);
			this.@__auxAuxMsgDecLbl.TabIndex = 13;
			this.@__auxAuxMsgDecLbl.Text = "Base 10";
			// 
			// __auxAuxMsgHexLbl
			// 
			this.@__auxAuxMsgHexLbl.AutoSize = true;
			this.@__auxAuxMsgHexLbl.Location = new System.Drawing.Point(146, 77);
			this.@__auxAuxMsgHexLbl.Name = "__auxAuxMsgHexLbl";
			this.@__auxAuxMsgHexLbl.Size = new System.Drawing.Size(46, 13);
			this.@__auxAuxMsgHexLbl.TabIndex = 12;
			this.@__auxAuxMsgHexLbl.Text = "Base 16";
			// 
			// __auxLed2
			// 
			this.@__auxLed2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__auxLed2.FormattingEnabled = true;
			this.@__auxLed2.Items.AddRange(new object[] {
            "Off",
            "On",
            "Automatic"});
			this.@__auxLed2.Location = new System.Drawing.Point(57, 140);
			this.@__auxLed2.Name = "__auxLed2";
			this.@__auxLed2.Size = new System.Drawing.Size(121, 21);
			this.@__auxLed2.TabIndex = 7;
			// 
			// __auxLed2Lbl
			// 
			this.@__auxLed2Lbl.AutoSize = true;
			this.@__auxLed2Lbl.Location = new System.Drawing.Point(14, 143);
			this.@__auxLed2Lbl.Name = "__auxLed2Lbl";
			this.@__auxLed2Lbl.Size = new System.Drawing.Size(37, 13);
			this.@__auxLed2Lbl.TabIndex = 10;
			this.@__auxLed2Lbl.Text = "LED 2";
			// 
			// __auxLed1
			// 
			this.@__auxLed1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__auxLed1.FormattingEnabled = true;
			this.@__auxLed1.Items.AddRange(new object[] {
            "Off",
            "On",
            "Automatic"});
			this.@__auxLed1.Location = new System.Drawing.Point(57, 113);
			this.@__auxLed1.Name = "__auxLed1";
			this.@__auxLed1.Size = new System.Drawing.Size(121, 21);
			this.@__auxLed1.TabIndex = 6;
			// 
			// __auxLed1Lbl
			// 
			this.@__auxLed1Lbl.AutoSize = true;
			this.@__auxLed1Lbl.Location = new System.Drawing.Point(14, 116);
			this.@__auxLed1Lbl.Name = "__auxLed1Lbl";
			this.@__auxLed1Lbl.Size = new System.Drawing.Size(37, 13);
			this.@__auxLed1Lbl.TabIndex = 8;
			this.@__auxLed1Lbl.Text = "LED 1";
			// 
			// __auxAuxMsgBin
			// 
			this.@__auxAuxMsgBin.Location = new System.Drawing.Point(258, 51);
			this.@__auxAuxMsgBin.Name = "__auxAuxMsgBin";
			this.@__auxAuxMsgBin.ReadOnly = true;
			this.@__auxAuxMsgBin.Size = new System.Drawing.Size(67, 20);
			this.@__auxAuxMsgBin.TabIndex = 5;
			this.@__tip.SetToolTip(this.@__auxAuxMsgBin, "Auxiliary IO status byte in base 2 (binary) with leading zeros.");
			// 
			// __auxAuxMsgDec
			// 
			this.@__auxAuxMsgDec.Location = new System.Drawing.Point(207, 51);
			this.@__auxAuxMsgDec.Name = "__auxAuxMsgDec";
			this.@__auxAuxMsgDec.ReadOnly = true;
			this.@__auxAuxMsgDec.Size = new System.Drawing.Size(45, 20);
			this.@__auxAuxMsgDec.TabIndex = 4;
			this.@__tip.SetToolTip(this.@__auxAuxMsgDec, "Auxiliary IO status byte in base 10 (decimal)");
			// 
			// __auxAuxMsgHex
			// 
			this.@__auxAuxMsgHex.Location = new System.Drawing.Point(140, 51);
			this.@__auxAuxMsgHex.Name = "__auxAuxMsgHex";
			this.@__auxAuxMsgHex.ReadOnly = true;
			this.@__auxAuxMsgHex.Size = new System.Drawing.Size(61, 20);
			this.@__auxAuxMsgHex.TabIndex = 3;
			this.@__tip.SetToolTip(this.@__auxAuxMsgHex, "Auxiliary IO status byte in base 16 (hexadecimal)");
			// 
			// __auxAux
			// 
			this.@__auxAux.Location = new System.Drawing.Point(12, 49);
			this.@__auxAux.Name = "__auxAux";
			this.@__auxAux.Size = new System.Drawing.Size(122, 23);
			this.@__auxAux.TabIndex = 2;
			this.@__auxAux.Text = "Get AUX Status";
			this.@__auxAux.UseVisualStyleBackColor = true;
			// 
			// __auxBtnMsg
			// 
			this.@__auxBtnMsg.Location = new System.Drawing.Point(140, 22);
			this.@__auxBtnMsg.Name = "__auxBtnMsg";
			this.@__auxBtnMsg.ReadOnly = true;
			this.@__auxBtnMsg.Size = new System.Drawing.Size(185, 20);
			this.@__auxBtnMsg.TabIndex = 1;
			// 
			// __auxBtn
			// 
			this.@__auxBtn.Location = new System.Drawing.Point(12, 20);
			this.@__auxBtn.Name = "__auxBtn";
			this.@__auxBtn.Size = new System.Drawing.Size(122, 23);
			this.@__auxBtn.TabIndex = 0;
			this.@__auxBtn.Text = "Get Button Status";
			this.@__auxBtn.UseVisualStyleBackColor = true;
			// 
			// __tabServo
			// 
			this.@__tabServo.AutoScroll = true;
			this.@__tabServo.Controls.Add(this.@__servoHome);
			this.@__tabServo.Controls.Add(this.@__servoTiltStepsLbl);
			this.@__tabServo.Controls.Add(this.@__servoTiltNearLbl);
			this.@__tabServo.Controls.Add(this.@__servoTiltFarLbl);
			this.@__tabServo.Controls.Add(this.@__servoTiltSteps);
			this.@__tabServo.Controls.Add(this.@__servoTiltNear);
			this.@__tabServo.Controls.Add(this.@__servoTiltFar);
			this.@__tabServo.Controls.Add(this.@__servoPanStepsLbl);
			this.@__tabServo.Controls.Add(this.@__servoPanNearLbl);
			this.@__tabServo.Controls.Add(this.@__servoPanFarLbl);
			this.@__tabServo.Controls.Add(this.@__servoPanSteps);
			this.@__tabServo.Controls.Add(this.@__servoPanNear);
			this.@__tabServo.Controls.Add(this.@__servoPanFar);
			this.@__tabServo.Controls.Add(this.@__servo5High);
			this.@__tabServo.Controls.Add(this.@__servo4High);
			this.@__tabServo.Controls.Add(this.@__servo3High);
			this.@__tabServo.Controls.Add(this.@__servo2High);
			this.@__tabServo.Controls.Add(this.@__servo1High);
			this.@__tabServo.Controls.Add(this.@__servo5Lbl);
			this.@__tabServo.Controls.Add(this.@__servo4Lbl);
			this.@__tabServo.Controls.Add(this.@__servo3Lbl);
			this.@__tabServo.Controls.Add(this.@__servo2Lbl);
			this.@__tabServo.Controls.Add(this.@__servo1Lbl);
			this.@__tabServo.Controls.Add(this.@__servoTiltReporting);
			this.@__tabServo.Controls.Add(this.@__servoPanReporting);
			this.@__tabServo.Controls.Add(this.@__servoTiltControl);
			this.@__tabServo.Controls.Add(this.@__servoPanControl);
			this.@__tabServo.Controls.Add(this.@__servo5);
			this.@__tabServo.Controls.Add(this.@__servo4);
			this.@__tabServo.Controls.Add(this.@__servo3);
			this.@__tabServo.Controls.Add(this.@__servo2);
			this.@__tabServo.Controls.Add(this.@__servo1);
			this.@__tabServo.Location = new System.Drawing.Point(4, 22);
			this.@__tabServo.Name = "__tabServo";
			this.@__tabServo.Size = new System.Drawing.Size(413, 439);
			this.@__tabServo.TabIndex = 6;
			this.@__tabServo.Text = "Servos";
			this.@__tabServo.UseVisualStyleBackColor = true;
			// 
			// __servoHome
			// 
			this.@__servoHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.@__servoHome.Location = new System.Drawing.Point(327, 38);
			this.@__servoHome.Name = "__servoHome";
			this.@__servoHome.Size = new System.Drawing.Size(75, 23);
			this.@__servoHome.TabIndex = 4;
			this.@__servoHome.Text = "Home";
			this.@__servoHome.UseVisualStyleBackColor = true;
			// 
			// __servoTiltStepsLbl
			// 
			this.@__servoTiltStepsLbl.AutoSize = true;
			this.@__servoTiltStepsLbl.Location = new System.Drawing.Point(219, 388);
			this.@__servoTiltStepsLbl.Name = "__servoTiltStepsLbl";
			this.@__servoTiltStepsLbl.Size = new System.Drawing.Size(51, 13);
			this.@__servoTiltStepsLbl.TabIndex = 33;
			this.@__servoTiltStepsLbl.Text = "Tilt Steps";
			// 
			// __servoTiltNearLbl
			// 
			this.@__servoTiltNearLbl.AutoSize = true;
			this.@__servoTiltNearLbl.Location = new System.Drawing.Point(219, 362);
			this.@__servoTiltNearLbl.Name = "__servoTiltNearLbl";
			this.@__servoTiltNearLbl.Size = new System.Drawing.Size(82, 13);
			this.@__servoTiltNearLbl.TabIndex = 32;
			this.@__servoTiltNearLbl.Text = "Tilt Range Near";
			// 
			// __servoTiltFarLbl
			// 
			this.@__servoTiltFarLbl.AutoSize = true;
			this.@__servoTiltFarLbl.Location = new System.Drawing.Point(219, 336);
			this.@__servoTiltFarLbl.Name = "__servoTiltFarLbl";
			this.@__servoTiltFarLbl.Size = new System.Drawing.Size(74, 13);
			this.@__servoTiltFarLbl.TabIndex = 31;
			this.@__servoTiltFarLbl.Text = "Tilt Range Far";
			// 
			// __servoTiltSteps
			// 
			this.@__servoTiltSteps.Location = new System.Drawing.Point(327, 386);
			this.@__servoTiltSteps.Name = "__servoTiltSteps";
			this.@__servoTiltSteps.Size = new System.Drawing.Size(68, 20);
			this.@__servoTiltSteps.TabIndex = 20;
			// 
			// __servoTiltNear
			// 
			this.@__servoTiltNear.Location = new System.Drawing.Point(327, 360);
			this.@__servoTiltNear.Name = "__servoTiltNear";
			this.@__servoTiltNear.Size = new System.Drawing.Size(68, 20);
			this.@__servoTiltNear.TabIndex = 19;
			// 
			// __servoTiltFar
			// 
			this.@__servoTiltFar.Location = new System.Drawing.Point(327, 334);
			this.@__servoTiltFar.Name = "__servoTiltFar";
			this.@__servoTiltFar.Size = new System.Drawing.Size(68, 20);
			this.@__servoTiltFar.TabIndex = 18;
			// 
			// __servoPanStepsLbl
			// 
			this.@__servoPanStepsLbl.AutoSize = true;
			this.@__servoPanStepsLbl.Location = new System.Drawing.Point(13, 388);
			this.@__servoPanStepsLbl.Name = "__servoPanStepsLbl";
			this.@__servoPanStepsLbl.Size = new System.Drawing.Size(56, 13);
			this.@__servoPanStepsLbl.TabIndex = 27;
			this.@__servoPanStepsLbl.Text = "Pan Steps";
			// 
			// __servoPanNearLbl
			// 
			this.@__servoPanNearLbl.AutoSize = true;
			this.@__servoPanNearLbl.Location = new System.Drawing.Point(13, 362);
			this.@__servoPanNearLbl.Name = "__servoPanNearLbl";
			this.@__servoPanNearLbl.Size = new System.Drawing.Size(87, 13);
			this.@__servoPanNearLbl.TabIndex = 26;
			this.@__servoPanNearLbl.Text = "Pan Range Near";
			// 
			// __servoPanFarLbl
			// 
			this.@__servoPanFarLbl.AutoSize = true;
			this.@__servoPanFarLbl.Location = new System.Drawing.Point(13, 336);
			this.@__servoPanFarLbl.Name = "__servoPanFarLbl";
			this.@__servoPanFarLbl.Size = new System.Drawing.Size(79, 13);
			this.@__servoPanFarLbl.TabIndex = 25;
			this.@__servoPanFarLbl.Text = "Pan Range Far";
			// 
			// __servoPanSteps
			// 
			this.@__servoPanSteps.Location = new System.Drawing.Point(121, 386);
			this.@__servoPanSteps.Name = "__servoPanSteps";
			this.@__servoPanSteps.Size = new System.Drawing.Size(68, 20);
			this.@__servoPanSteps.TabIndex = 17;
			// 
			// __servoPanNear
			// 
			this.@__servoPanNear.Location = new System.Drawing.Point(121, 360);
			this.@__servoPanNear.Name = "__servoPanNear";
			this.@__servoPanNear.Size = new System.Drawing.Size(68, 20);
			this.@__servoPanNear.TabIndex = 16;
			// 
			// __servoPanFar
			// 
			this.@__servoPanFar.Location = new System.Drawing.Point(121, 334);
			this.@__servoPanFar.Name = "__servoPanFar";
			this.@__servoPanFar.Size = new System.Drawing.Size(68, 20);
			this.@__servoPanFar.TabIndex = 15;
			// 
			// __servo5High
			// 
			this.@__servo5High.AutoSize = true;
			this.@__servo5High.Location = new System.Drawing.Point(12, 296);
			this.@__servo5High.Name = "__servo5High";
			this.@__servo5High.Size = new System.Drawing.Size(48, 17);
			this.@__servo5High.TabIndex = 9;
			this.@__servo5High.Text = "High";
			this.@__servo5High.UseVisualStyleBackColor = true;
			// 
			// __servo4High
			// 
			this.@__servo4High.AutoSize = true;
			this.@__servo4High.Location = new System.Drawing.Point(12, 245);
			this.@__servo4High.Name = "__servo4High";
			this.@__servo4High.Size = new System.Drawing.Size(48, 17);
			this.@__servo4High.TabIndex = 8;
			this.@__servo4High.Text = "High";
			this.@__servo4High.UseVisualStyleBackColor = true;
			// 
			// __servo3High
			// 
			this.@__servo3High.AutoSize = true;
			this.@__servo3High.Location = new System.Drawing.Point(12, 194);
			this.@__servo3High.Name = "__servo3High";
			this.@__servo3High.Size = new System.Drawing.Size(48, 17);
			this.@__servo3High.TabIndex = 7;
			this.@__servo3High.Text = "High";
			this.@__servo3High.UseVisualStyleBackColor = true;
			// 
			// __servo2High
			// 
			this.@__servo2High.AutoSize = true;
			this.@__servo2High.Location = new System.Drawing.Point(12, 143);
			this.@__servo2High.Name = "__servo2High";
			this.@__servo2High.Size = new System.Drawing.Size(48, 17);
			this.@__servo2High.TabIndex = 6;
			this.@__servo2High.Text = "High";
			this.@__servo2High.UseVisualStyleBackColor = true;
			// 
			// __servo1High
			// 
			this.@__servo1High.AutoSize = true;
			this.@__servo1High.Location = new System.Drawing.Point(12, 92);
			this.@__servo1High.Name = "__servo1High";
			this.@__servo1High.Size = new System.Drawing.Size(48, 17);
			this.@__servo1High.TabIndex = 5;
			this.@__servo1High.Text = "High";
			this.@__servo1High.UseVisualStyleBackColor = true;
			// 
			// __servo5Lbl
			// 
			this.@__servo5Lbl.AutoSize = true;
			this.@__servo5Lbl.Location = new System.Drawing.Point(9, 274);
			this.@__servo5Lbl.Name = "__servo5Lbl";
			this.@__servo5Lbl.Size = new System.Drawing.Size(44, 13);
			this.@__servo5Lbl.TabIndex = 13;
			this.@__servo5Lbl.Text = "Servo 5";
			// 
			// __servo4Lbl
			// 
			this.@__servo4Lbl.AutoSize = true;
			this.@__servo4Lbl.Location = new System.Drawing.Point(9, 223);
			this.@__servo4Lbl.Name = "__servo4Lbl";
			this.@__servo4Lbl.Size = new System.Drawing.Size(44, 13);
			this.@__servo4Lbl.TabIndex = 11;
			this.@__servo4Lbl.Text = "Servo 4";
			// 
			// __servo3Lbl
			// 
			this.@__servo3Lbl.AutoSize = true;
			this.@__servo3Lbl.Location = new System.Drawing.Point(9, 172);
			this.@__servo3Lbl.Name = "__servo3Lbl";
			this.@__servo3Lbl.Size = new System.Drawing.Size(44, 13);
			this.@__servo3Lbl.TabIndex = 9;
			this.@__servo3Lbl.Text = "Servo 3";
			// 
			// __servo2Lbl
			// 
			this.@__servo2Lbl.AutoSize = true;
			this.@__servo2Lbl.Location = new System.Drawing.Point(9, 121);
			this.@__servo2Lbl.Name = "__servo2Lbl";
			this.@__servo2Lbl.Size = new System.Drawing.Size(44, 13);
			this.@__servo2Lbl.TabIndex = 7;
			this.@__servo2Lbl.Text = "Servo 2";
			// 
			// __servo1Lbl
			// 
			this.@__servo1Lbl.AutoSize = true;
			this.@__servo1Lbl.Location = new System.Drawing.Point(9, 70);
			this.@__servo1Lbl.Name = "__servo1Lbl";
			this.@__servo1Lbl.Size = new System.Drawing.Size(44, 13);
			this.@__servo1Lbl.TabIndex = 5;
			this.@__servo1Lbl.Text = "Servo 1";
			// 
			// __servoTiltReporting
			// 
			this.@__servoTiltReporting.AutoSize = true;
			this.@__servoTiltReporting.Location = new System.Drawing.Point(182, 38);
			this.@__servoTiltReporting.Name = "__servoTiltReporting";
			this.@__servoTiltReporting.Size = new System.Drawing.Size(131, 17);
			this.@__servoTiltReporting.TabIndex = 3;
			this.@__servoTiltReporting.Text = "Tilt Reporting Enabled";
			this.@__servoTiltReporting.UseVisualStyleBackColor = true;
			// 
			// __servoPanReporting
			// 
			this.@__servoPanReporting.AutoSize = true;
			this.@__servoPanReporting.Location = new System.Drawing.Point(17, 38);
			this.@__servoPanReporting.Name = "__servoPanReporting";
			this.@__servoPanReporting.Size = new System.Drawing.Size(136, 17);
			this.@__servoPanReporting.TabIndex = 1;
			this.@__servoPanReporting.Text = "Pan Reporting Enabled";
			this.@__servoPanReporting.UseVisualStyleBackColor = true;
			// 
			// __servoTiltControl
			// 
			this.@__servoTiltControl.AutoSize = true;
			this.@__servoTiltControl.Location = new System.Drawing.Point(182, 15);
			this.@__servoTiltControl.Name = "__servoTiltControl";
			this.@__servoTiltControl.Size = new System.Drawing.Size(118, 17);
			this.@__servoTiltControl.TabIndex = 2;
			this.@__servoTiltControl.Text = "Tilt Control Enabled";
			this.@__servoTiltControl.UseVisualStyleBackColor = true;
			// 
			// __servoPanControl
			// 
			this.@__servoPanControl.AutoSize = true;
			this.@__servoPanControl.Location = new System.Drawing.Point(17, 15);
			this.@__servoPanControl.Name = "__servoPanControl";
			this.@__servoPanControl.Size = new System.Drawing.Size(123, 17);
			this.@__servoPanControl.TabIndex = 0;
			this.@__servoPanControl.Text = "Pan Control Enabled";
			this.@__servoPanControl.UseVisualStyleBackColor = true;
			// 
			// __servo5
			// 
			this.@__servo5.Location = new System.Drawing.Point(84, 274);
			this.@__servo5.Maximum = 255;
			this.@__servo5.Name = "__servo5";
			this.@__servo5.Size = new System.Drawing.Size(316, 45);
			this.@__servo5.TabIndex = 14;
			this.@__servo5.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// __servo4
			// 
			this.@__servo4.Location = new System.Drawing.Point(84, 223);
			this.@__servo4.Maximum = 255;
			this.@__servo4.Name = "__servo4";
			this.@__servo4.Size = new System.Drawing.Size(316, 45);
			this.@__servo4.TabIndex = 13;
			this.@__servo4.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// __servo3
			// 
			this.@__servo3.Location = new System.Drawing.Point(84, 172);
			this.@__servo3.Maximum = 255;
			this.@__servo3.Name = "__servo3";
			this.@__servo3.Size = new System.Drawing.Size(316, 45);
			this.@__servo3.TabIndex = 12;
			this.@__servo3.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// __servo2
			// 
			this.@__servo2.Location = new System.Drawing.Point(84, 121);
			this.@__servo2.Maximum = 255;
			this.@__servo2.Name = "__servo2";
			this.@__servo2.Size = new System.Drawing.Size(316, 45);
			this.@__servo2.TabIndex = 11;
			this.@__servo2.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// __servo1
			// 
			this.@__servo1.Location = new System.Drawing.Point(84, 70);
			this.@__servo1.Maximum = 255;
			this.@__servo1.Name = "__servo1";
			this.@__servo1.Size = new System.Drawing.Size(316, 45);
			this.@__servo1.TabIndex = 10;
			this.@__servo1.TickStyle = System.Windows.Forms.TickStyle.None;
			// 
			// __window
			// 
			this.@__window.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.@__window.Controls.Add(@__windowLeftLbl);
			this.@__window.Controls.Add(this.@__windowReset);
			this.@__window.Controls.Add(this.@__windowRight);
			this.@__window.Controls.Add(@__windowRightLbl);
			this.@__window.Controls.Add(@__windowBottomLbl);
			this.@__window.Controls.Add(this.@__winDownsampleYLbl);
			this.@__window.Controls.Add(this.@__winDownsampleY);
			this.@__window.Controls.Add(this.@__windowLeft);
			this.@__window.Controls.Add(this.@__windowBottom);
			this.@__window.Controls.Add(this.@__winDownsampleXLbl);
			this.@__window.Controls.Add(this.@__winHighRes);
			this.@__window.Controls.Add(this.@__windowTop);
			this.@__window.Controls.Add(@__windowTopLbl);
			this.@__window.Controls.Add(this.@__winDownsampleX);
			this.@__window.Location = new System.Drawing.Point(427, 12);
			this.@__window.Name = "__window";
			this.@__window.Size = new System.Drawing.Size(424, 110);
			this.@__window.TabIndex = 14;
			this.@__window.TabStop = false;
			this.@__window.Text = "Camera Window Configuration";
			// 
			// __winDownsampleYLbl
			// 
			this.@__winDownsampleYLbl.AutoSize = true;
			this.@__winDownsampleYLbl.Location = new System.Drawing.Point(18, 77);
			this.@__winDownsampleYLbl.Name = "__winDownsampleYLbl";
			this.@__winDownsampleYLbl.Size = new System.Drawing.Size(101, 13);
			this.@__winDownsampleYLbl.TabIndex = 16;
			this.@__winDownsampleYLbl.Text = "Vert. Downsampling";
			// 
			// __winDownsampleY
			// 
			this.@__winDownsampleY.Location = new System.Drawing.Point(125, 75);
			this.@__winDownsampleY.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.@__winDownsampleY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.@__winDownsampleY.Name = "__winDownsampleY";
			this.@__winDownsampleY.Size = new System.Drawing.Size(41, 20);
			this.@__winDownsampleY.TabIndex = 2;
			this.@__winDownsampleY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// __winDownsampleXLbl
			// 
			this.@__winDownsampleXLbl.AutoSize = true;
			this.@__winDownsampleXLbl.Location = new System.Drawing.Point(13, 51);
			this.@__winDownsampleXLbl.Name = "__winDownsampleXLbl";
			this.@__winDownsampleXLbl.Size = new System.Drawing.Size(106, 13);
			this.@__winDownsampleXLbl.TabIndex = 14;
			this.@__winDownsampleXLbl.Text = "Horiz. Downsampling";
			// 
			// __winDownsampleX
			// 
			this.@__winDownsampleX.Location = new System.Drawing.Point(125, 49);
			this.@__winDownsampleX.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
			this.@__winDownsampleX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.@__winDownsampleX.Name = "__winDownsampleX";
			this.@__winDownsampleX.Size = new System.Drawing.Size(41, 20);
			this.@__winDownsampleX.TabIndex = 1;
			this.@__winDownsampleX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
			// 
			// __colorDlg
			// 
			this.@__colorDlg.FullOpen = true;
			// 
			// __viewStyle
			// 
			this.@__viewStyle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.@__viewStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.@__viewStyle.FormattingEnabled = true;
			this.@__viewStyle.Items.AddRange(new object[] {
            "Show Image and Overlay",
            "Show Image",
            "Show Overlay"});
			this.@__viewStyle.Location = new System.Drawing.Point(239, 608);
			this.@__viewStyle.Name = "__viewStyle";
			this.@__viewStyle.Size = new System.Drawing.Size(165, 21);
			this.@__viewStyle.TabIndex = 3;
			// 
			// __viewSave
			// 
			this.@__viewSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.@__viewSave.Location = new System.Drawing.Point(410, 607);
			this.@__viewSave.Name = "__viewSave";
			this.@__viewSave.Size = new System.Drawing.Size(91, 23);
			this.@__viewSave.TabIndex = 4;
			this.@__viewSave.Text = "Save Image...";
			this.@__viewSave.UseVisualStyleBackColor = true;
			// 
			// __sfd
			// 
			this.@__sfd.Filter = "Bitmap Images (*.bmp)|*.bmp|All files (*.*)|*.*";
			// 
			// __frame
			// 
			this.@__frame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__frame.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.@__frame.DifferencePacket = null;
			this.@__frame.Frame = null;
			this.@__frame.FrameSizeFallback = new System.Drawing.Size(0, 0);
			this.@__frame.Location = new System.Drawing.Point(12, 12);
			this.@__frame.Name = "__frame";
			this.@__frame.ShowImage = true;
			this.@__frame.ShowOverlays = false;
			this.@__frame.Size = new System.Drawing.Size(409, 589);
			this.@__frame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Normal;
			this.@__frame.TabIndex = 17;
			this.@__frame.TrackColor = System.Drawing.Color.Empty;
			this.@__frame.TrackPacket = null;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(860, 659);
			this.Controls.Add(this.@__viewSave);
			this.Controls.Add(this.@__viewStyle);
			this.Controls.Add(this.@__pickColorLbl);
			this.Controls.Add(this.@__window);
			this.Controls.Add(this.@__tabs);
			this.Controls.Add(this.@__status);
			this.Controls.Add(this.@__pickColor);
			this.Controls.Add(this.@__viewStretch);
			this.Controls.Add(this.@__frame);
			this.Name = "MainForm";
			this.Text = "CMUcam2 Viewer";
			this.@__status.ResumeLayout(false);
			this.@__status.PerformLayout();
			this.@__trackMaxGrp.ResumeLayout(false);
			this.@__trackMaxGrp.PerformLayout();
			this.@__trackMinGrp.ResumeLayout(false);
			this.@__trackMinGrp.PerformLayout();
			this.@__tabs.ResumeLayout(false);
			this.@__tabStill.ResumeLayout(false);
			this.@__tabStill.PerformLayout();
			this.@__configGrp.ResumeLayout(false);
			this.@__configGrp.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__configContrast)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__configBrightness)).EndInit();
			this.@__tabTrack.ResumeLayout(false);
			this.@__tabTrack.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__trackNoiseFilter)).EndInit();
			this.@__tabDiff.ResumeLayout(false);
			this.@__tabDiff.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__diffThreshold)).EndInit();
			this.@__tabMean.ResumeLayout(false);
			this.@__tabHisto.ResumeLayout(false);
			this.@__tabHisto.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__histoScale)).EndInit();
			this.@__tabAux.ResumeLayout(false);
			this.@__tabAux.PerformLayout();
			this.@__tabServo.ResumeLayout(false);
			this.@__tabServo.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__servoTiltSteps)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoTiltNear)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoTiltFar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoPanSteps)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoPanNear)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servoPanFar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__servo1)).EndInit();
			this.@__window.ResumeLayout(false);
			this.@__window.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.@__winDownsampleY)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.@__winDownsampleX)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip __status;
		private System.Windows.Forms.ToolStripProgressBar __frameProgress;
		private System.Windows.Forms.ToolStripStatusLabel __statusLbl;
		private System.Windows.Forms.ComboBox __stillChannel;
		private System.Windows.Forms.CheckBox __viewStretch;
		private System.Windows.Forms.ComboBox __winHighRes;
		private System.Windows.Forms.Button __stillGetFrame;
		private System.Windows.Forms.CheckBox __trackLiveColor;
		private System.Windows.Forms.GroupBox __trackMinGrp;
		private System.Windows.Forms.GroupBox __trackMaxGrp;
		private System.Windows.Forms.TextBox __trackMaxB;
		private System.Windows.Forms.TextBox __trackMaxR;
		private System.Windows.Forms.TextBox __trackMaxG;
		private System.Windows.Forms.TextBox __trackMinB;
		private System.Windows.Forms.TextBox __trackMinG;
		private System.Windows.Forms.TextBox __trackMinR;
		private System.Windows.Forms.CheckBox __pickColor;
		private System.Windows.Forms.Label __pickColorLbl;
		private System.Windows.Forms.TextBox __windowBottom;
		private System.Windows.Forms.TextBox __windowRight;
		private System.Windows.Forms.TextBox __windowTop;
		private System.Windows.Forms.TextBox __windowLeft;
		private System.Windows.Forms.Button __windowReset;
		private System.Windows.Forms.TabControl __tabs;
		private System.Windows.Forms.TabPage __tabStill;
		private System.Windows.Forms.TabPage __tabTrack;
		private System.Windows.Forms.TabPage __tabDiff;
		private System.Windows.Forms.GroupBox __window;
		private System.Windows.Forms.Label __winDownsampleYLbl;
		private System.Windows.Forms.NumericUpDown __winDownsampleY;
		private System.Windows.Forms.Label __winDownsampleXLbl;
		private System.Windows.Forms.NumericUpDown __winDownsampleX;
		private System.Windows.Forms.Label __stillChannelLbl;
		private CmuView __frame;
		private System.Windows.Forms.ComboBox __histoLiveChannel;
		private System.Windows.Forms.CheckBox __histoLive;
		private System.Windows.Forms.Button __histoRefresh;
		private HistogramDisplay __histoBlue;
		private HistogramDisplay __histoGreen;
		private HistogramDisplay __histoRed;
		private System.Windows.Forms.TabPage __tabHisto;
		private System.Windows.Forms.TabPage __tabAux;
		private System.Windows.Forms.TabPage __tabServo;
		private System.Windows.Forms.CheckBox __stillBuffer;
		private System.Windows.Forms.Button __stillBufferLoad;
		private System.Windows.Forms.CheckBox __trackInverted;
		private System.Windows.Forms.Button __auxBtn;
		private System.Windows.Forms.TextBox __auxAuxMsgHex;
		private System.Windows.Forms.Button __auxAux;
		private System.Windows.Forms.TextBox __auxBtnMsg;
		private System.Windows.Forms.Label __trackDefineLbl;
		private System.Windows.Forms.ComboBox __trackDefine;
		private System.Windows.Forms.Button __trackMaxColor;
		private System.Windows.Forms.Button __trackMinColor;
		private System.Windows.Forms.ColorDialog __colorDlg;
		private System.Windows.Forms.ToolTip __tip;
		private System.Windows.Forms.TextBox __auxAuxMsgBin;
		private System.Windows.Forms.TextBox __auxAuxMsgDec;
		private System.Windows.Forms.ComboBox __auxLed2;
		private System.Windows.Forms.Label __auxLed2Lbl;
		private System.Windows.Forms.ComboBox __auxLed1;
		private System.Windows.Forms.Label __auxLed1Lbl;
		private System.Windows.Forms.Label __auxAuxMsgBinLbl;
		private System.Windows.Forms.Label __auxAuxMsgDecLbl;
		private System.Windows.Forms.Label __auxAuxMsgHexLbl;
		private Bham.CmuCam.Gui.TrackBar2 __servo1;
		private System.Windows.Forms.CheckBox __servoTiltReporting;
		private System.Windows.Forms.CheckBox __servoPanReporting;
		private System.Windows.Forms.CheckBox __servoTiltControl;
		private System.Windows.Forms.CheckBox __servoPanControl;
		private System.Windows.Forms.Label __servo1Lbl;
		private System.Windows.Forms.Label __servo5Lbl;
		private Bham.CmuCam.Gui.TrackBar2 __servo5;
		private System.Windows.Forms.Label __servo4Lbl;
		private Bham.CmuCam.Gui.TrackBar2 __servo4;
		private System.Windows.Forms.Label __servo3Lbl;
		private Bham.CmuCam.Gui.TrackBar2 __servo3;
		private System.Windows.Forms.Label __servo2Lbl;
		private Bham.CmuCam.Gui.TrackBar2 __servo2;
		private System.Windows.Forms.Label __histoScaleLbl;
		private System.Windows.Forms.NumericUpDown __histoScale;
		private System.Windows.Forms.ComboBox __histoBins;
		private System.Windows.Forms.CheckBox __histoTrack;
		private System.Windows.Forms.ComboBox __viewStyle;
		private System.Windows.Forms.CheckBox __servo5High;
		private System.Windows.Forms.CheckBox __servo4High;
		private System.Windows.Forms.CheckBox __servo3High;
		private System.Windows.Forms.CheckBox __servo2High;
		private System.Windows.Forms.CheckBox __servo1High;
		private System.Windows.Forms.Label __servoPanStepsLbl;
		private System.Windows.Forms.Label __servoPanNearLbl;
		private System.Windows.Forms.Label __servoPanFarLbl;
		private System.Windows.Forms.NumericUpDown __servoPanSteps;
		private System.Windows.Forms.NumericUpDown __servoPanNear;
		private System.Windows.Forms.NumericUpDown __servoPanFar;
		private System.Windows.Forms.Label __servoTiltStepsLbl;
		private System.Windows.Forms.Label __servoTiltNearLbl;
		private System.Windows.Forms.Label __servoTiltFarLbl;
		private System.Windows.Forms.NumericUpDown __servoTiltSteps;
		private System.Windows.Forms.NumericUpDown __servoTiltNear;
		private System.Windows.Forms.NumericUpDown __servoTiltFar;
		private System.Windows.Forms.Button __servoHome;
		private System.Windows.Forms.Button __viewSave;
		private System.Windows.Forms.SaveFileDialog __sfd;
		private System.Windows.Forms.Button __configReset;
		private System.Windows.Forms.Label __trackNoiseFilterLbl;
		private System.Windows.Forms.NumericUpDown __trackNoiseFilter;
		private System.Windows.Forms.Label __configContrastLbl;
		private System.Windows.Forms.Label __configBrightnessLbl;
		private TrackBar2 __configContrast;
		private TrackBar2 __configBrightness;
		private System.Windows.Forms.CheckBox __configAutoExposureGain;
		private System.Windows.Forms.ComboBox __configColorMode;
		private System.Windows.Forms.Label __configColorModeLbl;
		private System.Windows.Forms.CheckBox __configPixelDifference;
		private System.Windows.Forms.GroupBox __configGrp;
		private System.Windows.Forms.CheckBox __diffHighRes;
		private System.Windows.Forms.CheckBox __trackLiveWindow;
		private System.Windows.Forms.Label __diffChannelLbl;
		private System.Windows.Forms.ComboBox __diffChannel;
		private System.Windows.Forms.Button __diffLoad;
		private System.Windows.Forms.Label __diffThresholdLbl;
		private System.Windows.Forms.NumericUpDown __diffThreshold;
		private System.Windows.Forms.TabPage __tabMean;
		private MeanDisplay __mean;
		private System.Windows.Forms.CheckBox __meanLive;
		private System.Windows.Forms.CheckBox __meanLiveM2;
		private System.Windows.Forms.CheckBox __meanLiveM1;
		private System.Windows.Forms.CheckBox __stillGetFrameStream;
		private System.Windows.Forms.CheckBox __trackLiveWindowM2;
		private System.Windows.Forms.CheckBox __trackLiveColorM2;
		private System.Windows.Forms.CheckBox __trackLiveWindowM1;
		private System.Windows.Forms.CheckBox __trackLiveColorM1;
		private System.Windows.Forms.CheckBox __diffLive;
		private System.Windows.Forms.CheckBox __diffLiveM3;
		private System.Windows.Forms.CheckBox __diffLiveM2;
		private System.Windows.Forms.CheckBox __diffLiveM1;
	}
}

