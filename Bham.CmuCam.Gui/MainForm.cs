using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using Bham.CmuCam.Packets;

using Cult = System.Globalization.CultureInfo;

namespace Bham.CmuCam.Gui {
	
	public partial class MainForm : Form {
		
		private CmuCam2 _cam;
		private Boolean _restoringValues = false; // if true, then event handlers must not set anything on the device
		
		public MainForm() {
			InitializeComponent();
			
			_cam = Program.Camera;
			_cam.SingleFrameProgress += new EventHandler<FrameProgressEventArgs>(_cam_SingleFrameProgress);
			
			this.__stillChannel    .SelectedIndex = 0;
			this.__winHighRes      .SelectedIndex = 0;
			this.__histoLiveChannel.SelectedIndex = 0;
			
			this.Load += new EventHandler(MainForm_Load);
			this.FormClosing += new FormClosingEventHandler(MainForm_FormClosing);
			
			//////////////////////////////////////
			// View
			this.__viewStretch.CheckedChanged       += new EventHandler(__viewStretch_CheckedChanged);
			this.__frame      .MouseMove            += new MouseEventHandler(__frame_MouseMove);
			this.__viewStyle  .SelectedIndexChanged += new EventHandler(__viewStyle_SelectedIndexChanged);
			this.__viewStyle  .SelectedIndex        = 0;
			this.__viewSave.Click += new EventHandler(__viewSave_Click);
			
			//////////////////////////////////////
			// Window Configuration
			this.__windowTop   .LostFocus += new EventHandler(__window_LostFocus);
			this.__windowLeft  .LostFocus += new EventHandler(__window_LostFocus);
			this.__windowRight .LostFocus += new EventHandler(__window_LostFocus);
			this.__windowBottom.LostFocus += new EventHandler(__window_LostFocus);
			this.__winHighRes    .SelectedIndexChanged += new EventHandler(__winHighRes_SelectedIndexChanged);
			this.__winDownsampleX.ValueChanged += new EventHandler(__winDownsample_ValueChanged);
			this.__winDownsampleY.ValueChanged += new EventHandler(__winDownsample_ValueChanged);
			this.__windowReset.Click += new EventHandler(__windowReset_Click);
			
			//////////////////////////////////////
			// Still Images
			this.__stillGetFrame  .Click          += new EventHandler(__getFrame_Click);
			this.__stillGetFrameStream.CheckedChanged += new EventHandler(__stillGetFrameStream_CheckedChanged);
			this.__stillBuffer    .CheckedChanged += new EventHandler(__stillBuffer_CheckedChanged);
			this.__stillBufferLoad.Click          += new EventHandler(__stillBufferLoad_Click);
			
			//////////////////////////////////////
			// Tracking
			this.__trackLiveColor   .CheckedChanged += new EventHandler(__trackLive_CheckedChanged);
			this.__trackLiveWindow  .CheckedChanged += new EventHandler(__trackLiveWindow_CheckedChanged);
			this.__trackLiveColorM1 .CheckedChanged += new EventHandler(__trackLiveM1_CheckedChanged);
			this.__trackLiveWindowM1.CheckedChanged += new EventHandler(__trackLiveWindowM1_CheckedChanged);
			this.__trackLiveColorM2 .CheckedChanged += new EventHandler(__trackLiveM2_CheckedChanged);
			this.__trackLiveWindowM2.CheckedChanged += new EventHandler(__trackLiveWindowM2_CheckedChanged);
			
			this.__trackMinR.TextChanged    += new EventHandler(__trackText_TextChanged);
			this.__trackMinG.TextChanged    += new EventHandler(__trackText_TextChanged);
			this.__trackMinB.TextChanged    += new EventHandler(__trackText_TextChanged);
			this.__trackMaxR.TextChanged    += new EventHandler(__trackText_TextChanged);
			this.__trackMaxG.TextChanged    += new EventHandler(__trackText_TextChanged);
			this.__trackMaxB.TextChanged    += new EventHandler(__trackText_TextChanged);
			
			this.__trackInverted.CheckedChanged       += new EventHandler(__trackInverted_CheckedChanged);
			this.__trackDefine  .SelectedIndexChanged += new EventHandler(__trackDefine_SelectedIndexChanged);
			
			this.__trackMinColor.Click += new EventHandler(__trackMinColor_Click);
			this.__trackMaxColor.Click += new EventHandler(__trackMaxColor_Click);

			this.__trackNoiseFilter.ValueChanged += new EventHandler(__trackNoiseFilter_ValueChanged);
			
			//////////////////////////////////////
			// Difference
			this.__diffChannel.SelectedIndexChanged += new EventHandler(__diffChannel_SelectedIndexChanged);
			this.__diffHighRes.CheckedChanged += new EventHandler(__diffHighRes_CheckedChanged);
			
			this.__diffLoad  .Click          += new EventHandler(__diffLoad_Click);
			this.__diffLive  .CheckedChanged += new EventHandler(__diffLive_CheckedChanged);
			this.__diffLiveM1.CheckedChanged += new EventHandler(__diffLiveM1_CheckedChanged);
			this.__diffLiveM2.CheckedChanged += new EventHandler(__diffLiveM2_CheckedChanged);
			this.__diffLiveM3.CheckedChanged += new EventHandler(__diffLiveM3_CheckedChanged);
			
			//////////////////////////////////////
			// Mean
			this.__meanLive  .CheckedChanged += new EventHandler(__meanLive_CheckedChanged);
			this.__meanLiveM1.CheckedChanged += new EventHandler(__meanLiveM1_CheckedChanged);
			this.__meanLiveM2.CheckedChanged += new EventHandler(__meanLiveM2_CheckedChanged);
			
			//////////////////////////////////////
			// Histogram
			this.__histoLive   .CheckedChanged       += new EventHandler(__histoLive_CheckedChanged);
			this.__histoBins   .SelectedIndexChanged += new EventHandler(__histoConfig_Changed);
			this.__histoScale  .ValueChanged         += new EventHandler(__histoConfig_Changed);
			this.__histoTrack  .CheckedChanged       += new EventHandler(__histoTrack_CheckedChanged);
			this.__histoRefresh.Click                += new EventHandler(__histoRefresh_Click);
			
			//////////////////////////////////////
			// Servos
			__servo1.Tag = Servo.Servo1;
			__servo2.Tag = Servo.Servo2;
			__servo3.Tag = Servo.Servo3;
			__servo4.Tag = Servo.Servo4;
			__servo5.Tag = Servo.Servo5;
			
			this.__servoHome.Click += new EventHandler(__servoHome_Click);
			
			this.__servo1.ValueChanged += new EventHandler(__servo_ValueChanged);
			this.__servo2.ValueChanged += new EventHandler(__servo_ValueChanged);
			this.__servo3.ValueChanged += new EventHandler(__servo_ValueChanged);
			this.__servo4.ValueChanged += new EventHandler(__servo_ValueChanged);
			this.__servo5.ValueChanged += new EventHandler(__servo_ValueChanged);
			
			this.__servo1.ScrollStopped += new EventHandler(__servo_ScrollStopped);
			this.__servo2.ScrollStopped += new EventHandler(__servo_ScrollStopped);
			this.__servo3.ScrollStopped += new EventHandler(__servo_ScrollStopped);
			this.__servo4.ScrollStopped += new EventHandler(__servo_ScrollStopped);
			this.__servo5.ScrollStopped += new EventHandler(__servo_ScrollStopped);
			
			this.__servoPanControl   .CheckedChanged += new EventHandler(__servoParameter_CheckedChanged);
			this.__servoPanReporting .CheckedChanged += new EventHandler(__servoParameter_CheckedChanged);
			this.__servoTiltControl  .CheckedChanged += new EventHandler(__servoParameter_CheckedChanged);
			this.__servoTiltReporting.CheckedChanged += new EventHandler(__servoParameter_CheckedChanged);
			
			this.__servo1High.CheckedChanged += new EventHandler(__servoHigh_CheckedChanged); this.__servo1High.Tag = Servo.Servo1;
			this.__servo2High.CheckedChanged += new EventHandler(__servoHigh_CheckedChanged); this.__servo2High.Tag = Servo.Servo2;
			this.__servo3High.CheckedChanged += new EventHandler(__servoHigh_CheckedChanged); this.__servo3High.Tag = Servo.Servo3;
			this.__servo4High.CheckedChanged += new EventHandler(__servoHigh_CheckedChanged); this.__servo4High.Tag = Servo.Servo4;
			this.__servo5High.CheckedChanged += new EventHandler(__servoHigh_CheckedChanged); this.__servo5High.Tag = Servo.Servo5;
			
			this.__servoPanFar   .ValueChanged += new EventHandler(__servoParam_ValueChanged);
			this.__servoPanNear  .ValueChanged += new EventHandler(__servoParam_ValueChanged);
			this.__servoPanSteps .ValueChanged += new EventHandler(__servoParam_ValueChanged);
			this.__servoTiltFar  .ValueChanged += new EventHandler(__servoParam_ValueChanged);
			this.__servoTiltNear .ValueChanged += new EventHandler(__servoParam_ValueChanged);
			this.__servoTiltSteps.ValueChanged += new EventHandler(__servoParam_ValueChanged);
			
			//////////////////////////////////////
			// Aux IO
			this.__auxAux.Click += new EventHandler(__auxAux_Click);
			this.__auxBtn.Click += new EventHandler(__auxBtn_Click);
			this.__auxLed1.SelectedIndexChanged += new EventHandler(__auxLed1_SelectedIndexChanged);
			this.__auxLed2.SelectedIndexChanged += new EventHandler(__auxLed2_SelectedIndexChanged);
			
			//////////////////////////////////////
			// Configuration
			this.__configColorMode       .SelectedIndexChanged += new EventHandler(__configColorMode_SelectedIndexChanged);
			this.__configAutoExposureGain.CheckedChanged       += new EventHandler(__configAutoExposureGain_CheckedChanged);
			this.__configPixelDifference.CheckedChanged += new EventHandler(__configPixelDifference_CheckedChanged);
			
			this.__configBrightness.ValueChanged += new EventHandler(__configBrightness_ValueChanged);
			this.__configContrast  .ValueChanged += new EventHandler(__configContrast_ValueChanged);
			
			this.__configBrightness.ScrollStopped += new EventHandler(__configBrightness_ScrollStopped);
			this.__configContrast  .ScrollStopped += new EventHandler(__configContrast_ScrollStopped);
			
			this.__configReset.Click += new EventHandler(__configReset_Click);
		}
		
		private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
			
			if( _cam != null ) _cam.StopStream();
			Thread.Sleep( 150 ); // just to make sure
		}
		
		private	void MainForm_Load(object sender, EventArgs e) {
			
			ReloadConfiguration();
		}
		
		/// <summary>Disables all UI that alters the camera.</summary>
		private void SetActionUI(Boolean enabled, Control exceptFor) {
			
			__window.Enabled = enabled;
			
			// Need to disable other controls manually because you can't override a parent tab-page being disabled
			
			__viewSave.Enabled = enabled; // because the image might be disposed while the save UI is shown
			
			// labels have different rendering too....
			
			//////////////////////////////////////////////
			// Images
			
			__stillBuffer        .Enabled = enabled;
			__stillBufferLoad    .Enabled = enabled;
			__stillChannelLbl    .Enabled = enabled;
			__stillChannel       .Enabled = enabled;
			__stillGetFrame      .Enabled = enabled;
			__stillGetFrameStream.Enabled = enabled;
			
			__configBrightness.Enabled = enabled;
			__configContrast  .Enabled = enabled;
			__configGrp       .Enabled = enabled; // shortcut, as no controls within it would be 'exceptFor'
			
			__configBrightnessLbl.Enabled = enabled;
			__configContrastLbl  .Enabled = enabled;
			
			//////////////////////////////////////////////
			// Tracking
			
			__trackDefine   .Enabled = enabled;
			__trackDefineLbl.Enabled = enabled;
			__trackMinGrp   .Enabled = enabled;
			__trackMaxGrp   .Enabled = enabled;
			
			__trackInverted      .Enabled = enabled;
			__trackNoiseFilter   .Enabled = enabled;
			__trackNoiseFilterLbl.Enabled = enabled;
			
			__trackLiveColor   .Enabled = enabled;
			__trackLiveWindow  .Enabled = enabled;
			__trackLiveColorM1 .Enabled = enabled;
			__trackLiveWindowM1.Enabled = enabled;
			__trackLiveColorM2 .Enabled = enabled;
			__trackLiveWindowM2.Enabled = enabled;
			
			//////////////////////////////////////////////
			// Difference
			
			__diffHighRes   .Enabled = enabled;
			__diffChannel   .Enabled = enabled;
			__diffChannelLbl.Enabled = enabled;
			
			__diffThreshold   .Enabled = enabled;
			__diffThresholdLbl.Enabled = enabled;
			
			__diffLoad  .Enabled = enabled;
			__diffLive  .Enabled = enabled;
			__diffLiveM1.Enabled = enabled;
			__diffLiveM2.Enabled = enabled;
			__diffLiveM3.Enabled = enabled;
			
			//////////////////////////////////////////////
			// Mean
			
			__meanLive  .Enabled = enabled;
			__meanLiveM1.Enabled = enabled;
			__meanLiveM2.Enabled = enabled;
			
			//////////////////////////////////////////////
			// Histogram
			
			__histoLive       .Enabled = enabled;
			__histoLiveChannel.Enabled = enabled;
			__histoRefresh    .Enabled = enabled;
			
			__histoBins    .Enabled = enabled;
			__histoScale   .Enabled = enabled;
			__histoScaleLbl.Enabled = enabled;
			__histoTrack   .Enabled = enabled;
			
			//////////////////////////////////////////////
			// Aux IO and Servos
			
			foreach(Control c in __tabAux.Controls) {
				c.Enabled = enabled;
			}
			foreach(Control c in __tabServo.Controls) {
				c.Enabled = enabled;
			}
			
			//////////////////////////////////////////////
			// Except-For
			
			if( exceptFor != null ) exceptFor.Enabled = true;
			
		}
		
		/// <summary>Sets the values of every configuration control in the GUI.</summary>
		private void ReloadConfiguration() {
			
			_restoringValues = true;
			
			this.Text = _cam.CameraVersion + " on " + _cam.ComPortName + " - CMUcam2 Viewer " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			
			//////////////////////////////////////////////
			// Window Configuration
			
			ReloadWindowConfig();
			
			//////////////////////////////////////////////
			// Still Image
			
			this.__stillBuffer    .Checked = this._cam.FrameBufferEnabled;
			this.__stillBufferLoad.Enabled = this.__stillBuffer.Checked;
			
			//////////////////////////////////////////////
			// Tracking
			
			this.__trackInverted.Checked = _cam.TrackInverted;
			
			Color min, max;
			_cam.GetTrackingColors(out min, out max);
			
			SetTrackColors(min, max);
			
			this.__trackNoiseFilter.Value = _cam.NoiseFilter;
			
			//////////////////////////////////////////////
			// Difference
			
			this.__diffChannel.SelectedIndex = (int)_cam.DifferencingChannel;
			this.__diffHighRes.Checked       = _cam.DifferenceHighResolutionEnabled;
			
			//////////////////////////////////////////////
			// Histogram
			
			this.__histoRed  .HistogramData = null;
			this.__histoGreen.HistogramData = null;
			this.__histoBlue .HistogramData = null;
			
			this.__histoTrack.Checked = _cam.HistogramTracking;
			
			this.__histoScale.Value = _cam.HistogramScale;
			this.__histoBins.SelectedIndex = (int)_cam.HistogramBins;
			
			//////////////////////////////////////////////
			// Aux IO
			
			this.__auxLed1.SelectedIndex = (int)_cam.Led1;
			this.__auxLed2.SelectedIndex = (int)_cam.Led2;
			
			//////////////////////////////////////////////
			// Servos
			
			this.__servo1.Value = _cam.GetServoPosition(Servo.Servo1);
			this.__servo2.Value = _cam.GetServoPosition(Servo.Servo2);
			this.__servo3.Value = _cam.GetServoPosition(Servo.Servo3);
			this.__servo4.Value = _cam.GetServoPosition(Servo.Servo4);
			this.__servo5.Value = _cam.GetServoPosition(Servo.Servo5);
			
			this.__servoPanControl   .Checked = _cam.ServoPanControlEnabled;
			this.__servoPanReporting .Checked = _cam.ServoPanReportEnabled;
			this.__servoTiltControl  .Checked = _cam.ServoTiltControlEnabled;
			this.__servoTiltReporting.Checked = _cam.ServoTiltReportEnabled;
			
			System.Collections.ObjectModel.ReadOnlyCollection<Boolean> servoLevels = _cam.GetServoLevels();
			this.__servo1High.Checked = servoLevels[0];
			this.__servo2High.Checked = servoLevels[1];
			this.__servo3High.Checked = servoLevels[2];
			this.__servo4High.Checked = servoLevels[3];
			this.__servo5High.Checked = servoLevels[4];
			
			this.__servoPanFar   .Value = _cam.ServoPanRangeFar;
			this.__servoPanNear  .Value = _cam.ServoPanRangeNear;
			this.__servoPanSteps .Value = _cam.ServoPanSteps;
			this.__servoTiltFar  .Value = _cam.ServoTiltRangeFar;
			this.__servoTiltNear .Value = _cam.ServoTiltRangeNear;
			this.__servoTiltSteps.Value = _cam.ServoTiltSteps;
			
			//////////////////////////////////////////////
			// Configuration
			switch( _cam.GetCameraRegisterValue(CameraRegister.ColorMode) ) {
				case CameraRegisterValues.ColorRgb:
					__configColorMode.SelectedIndex = 0;
					break;
				case CameraRegisterValues.ColorRgbWB:
					__configColorMode.SelectedIndex = 1;
					break;
				case CameraRegisterValues.ColorYCbCr:
					__configColorMode.SelectedIndex = 2;
					break;
				case CameraRegisterValues.ColorYCbCrWB:
					__configColorMode.SelectedIndex = 3;
					break;
			}
			
			switch( _cam.GetCameraRegisterValue(CameraRegister.AutoExposure) ) {
				case CameraRegisterValues.AutoExposureGainOn:
					__configAutoExposureGain.CheckState = CheckState.Checked;
					break;
				case CameraRegisterValues.AutoExposureGainOff:
					__configAutoExposureGain.CheckState = CheckState.Unchecked;
					break;
				default:
					__configAutoExposureGain.CheckState = CheckState.Indeterminate;
					break;
			}
			
			this.__configPixelDifference.Checked = _cam.PixelDifferenceEnabled;
			
			__configBrightness.Value = _cam.GetCameraRegisterValue(CameraRegister.Brightness);
			__configContrast  .Value = _cam.GetCameraRegisterValue(CameraRegister.Contrast);
			
			_restoringValues = false;
		}
		
		private void ReloadWindowConfig() {
			
			__winHighRes.SelectedIndex = _cam.HighResolutionEnabled ? 1 : 0;
			__winDownsampleX.Value     = _cam.DownSampling.Width;
			__winDownsampleY.Value     = _cam.DownSampling.Height;
			
			VirtualWindow vw = _cam.GetVirtualWindow();
			__windowTop   .Text = vw.Top.ToString();
			__windowRight .Text = vw.Right.ToString();
			__windowBottom.Text = vw.Bottom.ToString();
			__windowLeft  .Text = vw.Left.ToString();
			
			__frame.FrameSizeFallback = new Size( vw.Width, vw.Height );
		}
		
		private delegate void VoidSub();
		
#region Camera View
		
		private void __viewStretch_CheckedChanged(object sender, EventArgs e) {
			
			__frame.SizeMode = __viewStretch.Checked ? PictureBoxSizeMode.Zoom : PictureBoxSizeMode.Normal;
		}
		
		private void __viewStyle_SelectedIndexChanged(object sender, EventArgs e) {
			
			switch(__viewStyle.SelectedIndex) {
				case 0: // Show both
					__frame.ShowImage    = true;
					__frame.ShowOverlays = true;
					break;
				case 1: // Show image
					__frame.ShowImage    = true;
					__frame.ShowOverlays = false;
					break;
				case 2: // Show overlays
					__frame.ShowImage    = false;
					__frame.ShowOverlays = true;
					break;
			}
			
		}
		
		private void __frame_MouseMove(object sender, MouseEventArgs e) {
			
			if( __pickColor.Checked ) {
				
				Color c = Program.GetPixelUnderCursor();
				__pickColorLbl.BackColor = c;
				__pickColorLbl.Text = String.Format("{0},{1},{2}", c.R, c.G, c.B);
				__pickColorLbl.ForeColor = c.R < 100 || c.G < 100 ? Color.White : Color.Black;
			}
			
		}
		
		private void __viewSave_Click(object sender, EventArgs e) {
			
			Bitmap bmp = __frame.FrameImage;
			if( bmp == null ) {
				MessageBox.Show(this, "There is no image to save.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				return;
			}
			
			if( String.IsNullOrEmpty( __sfd.InitialDirectory ) ) __sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
			if( __sfd.ShowDialog(this) == DialogResult.OK ) {
				
				String filename = __sfd.FileName;
				
				bmp.Save( filename, System.Drawing.Imaging.ImageFormat.Bmp );
			}
			
		}
		
#endregion
		
#region Camera Window Configuration
		
		private void __winHighRes_SelectedIndexChanged(object sender, EventArgs e) {
			
			_cam.SetHighResolution( __winHighRes.SelectedIndex == 1 );
			
			ReloadWindowConfig();
		}
		
		private void __window_LostFocus(object sender, EventArgs e) {
			
			Byte left   = B( __windowLeft.Text );
			Byte top    = B( __windowTop.Text );
			Byte right  = B( __windowRight.Text );
			Byte bottom = B( __windowBottom.Text );
			
			if( right  <= left ) right  = (byte)(left + 1);
			if( bottom <= top  ) bottom = (byte)(top + 1);
			
			_cam.SetVirtualWindow( left, top, right, bottom );
		}
		
		private static Byte B(String text) {
			Byte b;
			if( Byte.TryParse(text, out b) ) return b;
			return 1;
		}
		
		private void __windowReset_Click(object sender, EventArgs e) {
			
			_cam.ResetViewWindow();
			
			ReloadWindowConfig();
		}
		
		private void __winDownsample_ValueChanged(object sender, EventArgs e) {
			
			Byte x = Convert.ToByte( __winDownsampleX.Value );
			Byte y = Convert.ToByte( __winDownsampleY.Value );
			
			_cam.SetDownSampling( x, y );
			
			ReloadWindowConfig();
		}
		
#endregion
		
#region Still Images
		
		private	void __stillBuffer_CheckedChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			_cam.SetFrameBuffer( __stillBuffer.Checked );
			__stillBufferLoad.Enabled = __stillBuffer.Checked;
		}
		
		private void __stillBufferLoad_Click(object sender, EventArgs e) {
			
			_cam.ReadFrame();
		}
		
		private void _cam_SingleFrameProgress(Object sender, FrameProgressEventArgs e) {
			
			float percentage = e.Percentage;
			
			if( this.InvokeRequired ) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					if( percentage == -1 ) {
						__frameProgress.Visible = false;
						return;
					}
					
					__frameProgress.Visible = true;
					__frameProgress.Value = (int)percentage;
					__statusLbl.Text      = (int)percentage + "%";
					
				}));
				
			} else {
				
				if( percentage == -1 ) {
					__frameProgress.Visible = false;
					return;
				}
				
				__frameProgress.Visible = true;
				__frameProgress.Value = (int)percentage;
				__statusLbl.Text      = (int)percentage + "%";
				
			}
			
		}
		
		private void __getFrame_Click(object sender, EventArgs e) {
			
			SetActionUI(false, null);
			
			Channels channel = Channels.All;
			switch(__stillChannel.SelectedIndex) {
				case 1: channel = Channels.Red; break;
				case 2: channel = Channels.Green; break;
				case 3: channel = Channels.Blue; break;
			}
			
			Thread t = new Thread( GetFrameThreadStart );
			t.Name = "GetFrame Thread";
			t.Start( channel );
			
		}
		
		private void GetFrameThreadStart(Object channelsObj) {
			
			Stopwatch sw = new Stopwatch();
			sw.Start();
			
			FPacket frame = _cam.GetFrame( (Channels)channelsObj );
			
			sw.Stop();
			
			BeginInvoke( new VoidSub( delegate() {
				
				__frame.Frame = frame;
				__statusLbl.Text = "Time taken: " + sw.ElapsedMilliseconds.ToString(Cult.CurrentCulture) + "ms";
				
				//////////////////////////
				// Get histograms
				__histoRefresh_Click(null, EventArgs.Empty);
				
				SetActionUI(true, null);
			}));
			
		}
		
		private void __stillGetFrameStream_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __stillGetFrameStream);
			
			if( __stillGetFrameStream.Checked ) {
				
				Channels channel = Channels.All;
				switch(__stillChannel.SelectedIndex) {
					case 1: channel = Channels.Red; break;
					case 2: channel = Channels.Green; break;
					case 3: channel = Channels.Blue; break;
				}
				
				Thread t = new Thread( GetFrameStreamThreadStart );
				t.Name = "GetFrameStream Thread";
				t.Start( channel );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __stillGetFrameStream);
				
			}
			
		}
		
		private void GetFrameStreamThreadStart(Object channelsObj) {
			
			IEnumerable<FPacket> stream = _cam.GetFrameStream( (Channels)channelsObj );
			foreach(FPacket pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.Frame = pack;
					__statusLbl.Text = "Streaming";
					
				}));
				
			}
			
		}
		
#endregion
		
#region Tracking
		
	#region Tracking Colors
		
		private void SetTrackColors(Color min, Color max) {
			
			__trackMinR.Text = min.R.ToString();
			__trackMinG.Text = min.G.ToString();
			__trackMinB.Text = min.B.ToString();
			
			__trackMaxR.Text = max.R.ToString();
			__trackMaxG.Text = max.G.ToString();
			__trackMaxB.Text = max.B.ToString();
			
			__trackMinColor.BackColor = min;
			__trackMaxColor.BackColor = max;
			
			_cam.SetTrackingColors( min, max );
		}
		
		private void GetTrackColors(out Color min, out Color max) {
			
			min = Color.FromArgb( B( __trackMinR.Text ), B( __trackMinG.Text ), B( __trackMinB.Text ) );
			max = Color.FromArgb( B( __trackMaxR.Text ), B( __trackMaxG.Text ), B( __trackMaxB.Text ) );
		}
		
		private Boolean _ignoreColor = false;
		
		private void __trackDefine_SelectedIndexChanged(object sender, EventArgs e) {
			
			if( _ignoreColor ) return;
			_ignoreColor = true;
			
			Color min, max;
			
			if( __trackDefine.SelectedIndex == 0 ) {
				// set to custom
				// so load the last custom colors
				
				SetTrackColors( TrackingColors.CustomMin, TrackingColors.CustomMax );
				
			} else {
				// set to predefined
				// so save the current custom colors
				
				GetTrackColors(out min, out max);
				TrackingColors.CustomMin = min;
				TrackingColors.CustomMax = max;
				
				switch(__trackDefine.SelectedIndex) {
					case 1:
						SetTrackColors( TrackingColors.RedMin, TrackingColors.RedMax );
						break;
					case 2:
						SetTrackColors( TrackingColors.GreenMin, TrackingColors.GreenMax );
						break;
					case 3:
						SetTrackColors( TrackingColors.BlueMin, TrackingColors.BlueMax );
						break;
					case 4:
						SetTrackColors( TrackingColors.YellowMin, TrackingColors.YellowMax );
						break;
				}
				
			}
			
			_ignoreColor = false;
		}
		
		private void __trackText_TextChanged(object sender, EventArgs e) {
			if( _ignoreColor ) return;
			_ignoreColor = true;
			__trackDefine.SelectedIndex = 0;
			
			Color min, max;
			GetTrackColors(out min, out max);
			__trackMinColor.BackColor = min;
			__trackMaxColor.BackColor = max;
			
			_ignoreColor = false;
		}
		
		private void __trackMinColor_Click(object sender, EventArgs e) {
			
			Color min, max;
			GetTrackColors(out min, out max);
			__colorDlg.Color = min;
			
			if( __colorDlg.ShowDialog(this) == DialogResult.OK ) {
				
				min = __colorDlg.Color;
				SetTrackColors(min, max);
			}
			
		}
		
		private void __trackMaxColor_Click(object sender, EventArgs e) {
			
			Color min, max;
			GetTrackColors(out min, out max);
			__colorDlg.Color = max;
			
			if( __colorDlg.ShowDialog(this) == DialogResult.OK ) {
				
				max = __colorDlg.Color;
				SetTrackColors(min, max);
			}
		}
		
	#endregion
		
		private void __trackInverted_CheckedChanged(object sender, EventArgs e) {
			
			if( _cam.IsStreaming ) {
				__trackInverted.Checked = !__trackInverted.Checked;
				return;
			}
			
			_cam.SetTrackInverted( __trackInverted.Checked );
			
		}
		
		private void __trackNoiseFilter_ValueChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			Byte v = Convert.ToByte( __trackNoiseFilter.Value );
			_cam.SetNoiseFilter( v );
		}
		
		private void __trackSetColor_Click(object sender, EventArgs e) {
			
			Color min, max;
			GetTrackColors(out min, out max);
			
			_cam.SetTrackingColors( min, max );
		}
		
	#region Mode 0
		
		private void __trackLive_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __trackLiveColor);
			
			if( __trackLiveColor.Checked ) {
				
				Color min, max;
				GetTrackColors(out min, out max);
				
				__frame.TrackColor = TrackingColors.GetMidColor( min, max );
				__frame.DifferencePacket = null;
				
				Thread t = new Thread( LiveTrackingColorThreadStart );
				t.Name = "Live Tracking Thread";
				t.Start( new Color[] { min, max }  );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __trackLiveColor);
			}
			
		}
		
		private void LiveTrackingColorThreadStart(Object obj) {
			Color[] colors = (Color[])obj;
			Color min = colors[0];
			Color max = colors[1];
			
			IEnumerable<TPacket> stream = _cam.GetTrackingStream(min, max);
			foreach(TPacket pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.TrackPacket = pack;
				}));
				
			}
		}
		
		private void __trackLiveWindow_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __trackLiveWindow);
			
			if( __trackLiveWindow.Checked ) {
				
				__frame.TrackColor = Color.White;
				__frame.DifferencePacket = null;
				
				Thread t = new Thread( LiveTrackingWindowThreadStart );
				t.Name = "Live Tracking Thread";
				t.Start( null );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __trackLiveColor);
			}
			
		}
		
		private void LiveTrackingWindowThreadStart(Object obj) {
			
			IEnumerable<TPacket> stream = _cam.GetTrackingStreamFromVWCenter();
			foreach(TPacket pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.TrackPacket = pack;
				}));
				
			}
			
			BeginInvoke( new VoidSub( delegate() {
				
				// the window is reset after calling TW
				ReloadWindowConfig();
			}));
			
		}
		
	#endregion
	#region Mode 1
		
		private void __trackLiveM1_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __trackLiveColorM1);
			
			if( __trackLiveColorM1.Checked ) {
				
				Color min, max;
				GetTrackColors(out min, out max);
				
				__frame.TrackColor = TrackingColors.GetMidColor( min, max );
				__frame.DifferencePacket = null;
				
				Thread t = new Thread( LiveTrackingColorM1ThreadStart );
				t.Name = "Live Tracking M1 Thread";
				t.Start( new Color[] { min, max }  );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __trackLiveColorM1);
			}
			
		}
		
		private void LiveTrackingColorM1ThreadStart(Object obj) {
			Color[] colors = (Color[])obj;
			Color min = colors[0];
			Color max = colors[1];
			
			IEnumerable<TPacketM1> stream = _cam.GetTrackingMode1Stream(min, max);
			foreach(TPacketM1 pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.TrackPacket = pack;
				}));
				
			}
		}
		
		private void __trackLiveWindowM1_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __trackLiveWindowM1);
			
			if( __trackLiveWindowM1.Checked ) {
				
				__frame.TrackColor = Color.White;
				__frame.DifferencePacket = null;
				
				Thread t = new Thread( LiveTrackingWindowM1ThreadStart );
				t.Name = "Live Tracking M1 Thread";
				t.Start( null );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __trackLiveWindowM1);
			}
			
		}
		
		private void LiveTrackingWindowM1ThreadStart(Object obj) {
			
			IEnumerable<TPacketM1> stream = _cam.GetTrackingMode1StreamFromVWCenter();
			foreach(TPacketM1 pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.TrackPacket = pack;
				}));
				
			}
			
			BeginInvoke( new VoidSub( delegate() {
				
				// the window is reset after calling TW
				ReloadWindowConfig();
			}));
			
		}
		
	#endregion
	#region Mode 2
		
		private void __trackLiveM2_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __trackLiveColorM2);
			
			if( __trackLiveColorM2.Checked ) {
				
				Color min, max;
				GetTrackColors(out min, out max);
				
				__frame.TrackColor = TrackingColors.GetMidColor( min, max );
				__frame.DifferencePacket = null;
				
				Thread t = new Thread( LiveTrackingColorM2ThreadStart );
				t.Name = "Live Tracking M2 Thread";
				t.Start( new Color[] { min, max }  );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __trackLiveColorM2);
			}
			
		}
		
		private void LiveTrackingColorM2ThreadStart(Object obj) {
			Color[] colors = (Color[])obj;
			Color min = colors[0];
			Color max = colors[1];
			
			IEnumerable<TPacketM2> stream = _cam.GetTrackingMode2Stream(min, max);
			foreach(TPacketM2 pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.TrackPacket = pack;
				}));
				
			}
		}
		
		private void __trackLiveWindowM2_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __trackLiveWindowM2);
			
			if( __trackLiveWindowM2.Checked ) {
				
				__frame.TrackColor = Color.White;
				__frame.DifferencePacket = null;
				
				Thread t = new Thread( LiveTrackingWindowM2ThreadStart );
				t.Name = "Live Tracking M2 Thread";
				t.Start( null );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __trackLiveWindowM2);
			}
			
		}
		
		private void LiveTrackingWindowM2ThreadStart(Object obj) {
			
			IEnumerable<TPacketM2> stream = _cam.GetTrackingMode2StreamFromVWCenter();
			foreach(TPacketM2 pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.TrackPacket = pack;
				}));
				
			}
			
			BeginInvoke( new VoidSub( delegate() {
				
				// the window is reset after calling TW
				ReloadWindowConfig();
			}));
			
		}
		
	#endregion
		
#endregion
		
#region Mean
		
		private void __meanLive_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __meanLive);
			
			if( __meanLive.Checked ) {
				
				__mean.FrameHeight = _cam.GetVirtualWindow().Height;
				
				Thread t = new Thread( LiveMeanThreadStart );
				t.Name = "Live Histogram Thread";
				t.Start();
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __meanLive);
			}
			
		}
		
		private void LiveMeanThreadStart() {
			
			IEnumerable<SPacket> stream = _cam.GetMeanColorStream();
			foreach(SPacket pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__mean.SPacket = pack;
				} ) );
			}
			
		}
		
		private void __meanLiveM1_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __meanLiveM1);
			
			if( __meanLiveM1.Checked ) {
				
				__mean.FrameHeight = _cam.GetVirtualWindow().Height;
				
				Thread t = new Thread( LiveMeanM1ThreadStart );
				t.Name = "Live Histogram M1 Thread";
				t.Start();
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __meanLiveM1);
			}
			
		}
		
		private void LiveMeanM1ThreadStart() {
			
			IEnumerable<SPacketM1> stream = _cam.GetMeanColorMode1Stream();
			foreach(SPacketM1 pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__mean.SPacket = pack;
				} ) );
			}
			
		}
		
		private void __meanLiveM2_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __meanLiveM2);
			
			if( __meanLiveM2.Checked ) {
				
				__mean.FrameHeight = _cam.GetVirtualWindow().Height;
				
				Thread t = new Thread( LiveMeanM2ThreadStart );
				t.Name = "Live Histogram M2 Thread";
				t.Start();
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __meanLiveM2);
			}
			
		}
		
		private void LiveMeanM2ThreadStart() {
			
			IEnumerable<SPacketM2> stream = _cam.GetMeanColorMode2Stream();
			foreach(SPacketM2 pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__mean.SPacket = pack;
				} ) );
			}
			
		}
		
		
#endregion
		
#region Histograms
		
		private void __histoRefresh_Click(object sender, EventArgs e) {
			
			HPacket hRed = _cam.GetHistogram(Channel.Red);
			HPacket hGrn = _cam.GetHistogram(Channel.Green);
			HPacket hBlu = _cam.GetHistogram(Channel.Blue);
			
			__histoRed  .HistogramData = hRed.Histogram;
			__histoGreen.HistogramData = hGrn.Histogram;
			__histoBlue .HistogramData = hBlu.Histogram;
			
		}
		
		private void __histoLive_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __histoLive);
			
			if( __histoLive.Checked ) {
				
				Channel channel = (Channel)__histoLiveChannel.SelectedIndex;
				
				Thread t = new Thread( LiveHistogramThreadStart );
				t.Name = "Live Histogram Thread";
				t.Start( channel );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __histoLive);
			}
			
		}
		
		private void LiveHistogramThreadStart(Object channelObj) {
			Channel channel = (Channel)channelObj;
			IEnumerable<HPacket> stream = _cam.GetHistogramStream(channel);
			foreach(HPacket pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					switch(channel) {
						case Channel.Red:
							__histoRed.HistogramData = pack.Histogram;
							break;
						case Channel.Green:
							__histoGreen.HistogramData = pack.Histogram;
							break;
						case Channel.Blue:
							__histoBlue.HistogramData = pack.Histogram;
							break;
					}
					
				} ) );
			}
			
		}
		
		private void __histoConfig_Changed(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			HistogramBinCount bins  = (HistogramBinCount)__histoBins.SelectedIndex;
			Byte          scale = Convert.ToByte( __histoScale.Value );
			
			_cam.SetHistogramConfiguration( bins, scale );
		}
		
		private void __histoTrack_CheckedChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			_cam.SetHistogramTracking( __histoTrack.Checked );
		}
		
#endregion
		
#region Difference
		
		private void __diffLoad_Click(object sender, EventArgs e) {
			
			_cam.LoadDifferenceFrame();
		}
		
		private void __diffHighRes_CheckedChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			_cam.SetDifferenceResolution( __diffHighRes.Checked );
		}
		
		private void __diffChannel_SelectedIndexChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			Channel ch = (Channel)__diffChannel.SelectedIndex;
			
			_cam.SetDifferencingChannel( ch );
		}
		
	#region Mode 0
		
		private void __diffLive_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __diffLive);
			
			if( __diffLive.Checked ) {
				
				__frame.TrackPacket = null; // so it doesn't show the tracking overlay, only the diff overlay
				
				Byte threshold = Convert.ToByte( __diffThreshold.Value );
				
				Thread t = new Thread( LiveDifferenceThreadStart );
				t.Name = "Live Difference Thread";
				t.Start( threshold );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __diffLive);
			}
			
		}
		
		private void LiveDifferenceThreadStart(Object obj) {
			Byte threshold = (Byte)obj;
			
			IEnumerable<DPacket> stream = _cam.GetDifferenceStream( threshold );
			foreach(DPacket pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.DifferencePacket = pack;
				}));
				
			}
		}
		
	#endregion
	#region Mode 1
		
		private void __diffLiveM1_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __diffLiveM1);
			
			if( __diffLiveM1.Checked ) {
				
				__frame.TrackPacket = null; // so it doesn't show the tracking overlay, only the diff overlay
				
				Byte threshold = Convert.ToByte( __diffThreshold.Value );
				
				Thread t = new Thread( LiveDifferenceM1ThreadStart );
				t.Name = "Live Difference M1 Thread";
				t.Start( threshold );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __diffLiveM1);
			}
			
		}
		
		private void LiveDifferenceM1ThreadStart(Object obj) {
			Byte threshold = (Byte)obj;
			
			IEnumerable<DPacketM1> stream = _cam.GetDifferenceMode1Stream( threshold );
			foreach(DPacketM1 pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.DifferencePacket = pack;
				}));
				
			}
		}
		
	#endregion
	#region Mode 2
		
		private void __diffLiveM2_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __diffLiveM2);
			
			if( __diffLiveM2.Checked ) {
				
				__frame.TrackPacket = null; // so it doesn't show the tracking overlay, only the diff overlay
				
				Byte threshold = Convert.ToByte( __diffThreshold.Value );
				
				Thread t = new Thread( LiveDifferenceM2ThreadStart );
				t.Name = "Live Difference M2 Thread";
				t.Start( threshold );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __diffLiveM2);
			}
			
		}
		
		private void LiveDifferenceM2ThreadStart(Object obj) {
			Byte threshold = (Byte)obj;
			
			IEnumerable<DPacketM2> stream = _cam.GetDifferenceMode2Stream( threshold );
			foreach(DPacketM2 pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.DifferencePacket = pack;
				}));
				
			}
		}
		
	#endregion
	#region Mode 3
		
		private void __diffLiveM3_CheckedChanged(object sender, EventArgs e) {
			
			SetActionUI(false, __diffLiveM3);
			
			if( __diffLiveM3.Checked ) {
				
				__frame.TrackPacket = null; // so it doesn't show the tracking overlay, only the diff overlay
				
				Byte threshold = Convert.ToByte( __diffThreshold.Value );
				
				Thread t = new Thread( LiveDifferenceM3ThreadStart );
				t.Name = "Live Difference M3 Thread";
				t.Start( threshold );
				
			} else {
				
				_cam.StopStream();
				
				SetActionUI(true, __diffLiveM3);
			}
			
		}
		
		private void LiveDifferenceM3ThreadStart(Object obj) {
			Byte threshold = (Byte)obj;
			
			IEnumerable<DPacketM3> stream = _cam.GetDifferenceMode3Stream( threshold );
			foreach(DPacketM3 pack in stream) {
				
				BeginInvoke( new VoidSub( delegate() {
					
					__frame.DifferencePacket = pack;
				}));
				
			}
		}
		
	#endregion
		
		
		
#endregion
		
#region Servos
		
		private void __servoHome_Click(object sender, EventArgs e) {
			
			__servo1.Value = 127;
			__servo2.Value = 127;
			__servo3.Value = 127;
			__servo4.Value = 127;
			__servo5.Value = 127;
		}
		
		private void __servo_ValueChanged(object sender, EventArgs e) {
			
			TrackBar t = sender as TrackBar;
			
			Servo servo = (Servo)t.Tag;
			
			int servoNum = ((int)servo + 1);
			
			Control lbl = Program.FindControl(this, "__servo" + servoNum + "Lbl");
			if( lbl != null ) lbl.Text = "Servo " + servoNum + " : " + t.Value;
		}
		
		private	void __servo_ScrollStopped(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			TrackBar t = sender as TrackBar;
			
			Servo servo = (Servo)t.Tag;
			
			_cam.SetServoPosition( servo, (byte)t.Value );
		}
		
		private void __servoParameter_CheckedChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			_cam.SetServoMask( __servoPanControl.Checked, __servoTiltControl.Checked, __servoPanReporting.Checked, __servoTiltReporting.Checked );
		}
		
		private void __servoHigh_CheckedChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			CheckBox box = sender as CheckBox;
			Servo servo = (Servo)box.Tag;
			
			_cam.SetServoLevel(servo, box.Checked);
		}
		
		private void __servoParam_ValueChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			Byte panFar    = Convert.ToByte( __servoPanFar   .Value );
			Byte panNear   = Convert.ToByte( __servoPanNear  .Value );
			Byte panSteps  = Convert.ToByte( __servoPanSteps .Value );
			Byte tiltFar   = Convert.ToByte( __servoTiltFar  .Value );
			Byte tiltNear  = Convert.ToByte( __servoTiltNear .Value );
			Byte tiltSteps = Convert.ToByte( __servoTiltSteps.Value );
			
			_cam.SetServoParameters( panFar, panNear, panSteps, tiltFar, tiltNear, tiltSteps );
		}
		
#endregion
		
#region Aux
		
		private void __auxBtn_Click(object sender, EventArgs e) {
			
			bool pressed = _cam.GetButtonPress();
			
			__auxBtnMsg.Text = pressed ? "The button was pressed." : "The button was not pressed.";
		}
		
		private void __auxAux_Click(object sender, EventArgs e) {
			
			Byte b = _cam.GetAuxIO();
			
			__auxAuxMsgHex.Text = b.ToString("X", Cult.InvariantCulture);
			__auxAuxMsgDec.Text = b.ToString(Cult.InvariantCulture);
			
			String bin = String.Empty;
			for(int i=0;i<8;i++) {
				
				if( (( b >> i ) & 1 ) == 1 ) bin = "1" + bin;
				else                         bin = "0" + bin;
			}
			
			__auxAuxMsgBin.Text = bin;
		}
		
		private void __auxLed1_SelectedIndexChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			_cam.SetLed1( (LedMode)__auxLed1.SelectedIndex );
		}
		
		private void __auxLed2_SelectedIndexChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			_cam.SetLed2( (LedMode)__auxLed2.SelectedIndex );
		}
		
		
		
#endregion
		
#region Configuration
		
		private void __configColorMode_SelectedIndexChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			Byte regValue = 0;
			
			// 0 = Rgb, 1 = RgbWB, 2 = YCrCb, 3 = YCrCbWB
			switch(__configColorMode.SelectedIndex) {
				case 0:
					regValue = CameraRegisterValues.ColorRgb;
					break;
				case 1:
					regValue = CameraRegisterValues.ColorRgbWB;
					break;
				case 2:
					regValue = CameraRegisterValues.ColorYCbCr;
					break;
				case 3:
					regValue = CameraRegisterValues.ColorYCbCrWB;
					break;
				default:
					return;
			}
			
			_cam.SetCameraRegisterValue(CameraRegister.ColorMode, regValue);
		}
		
		private void __configAutoExposureGain_CheckedChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			Byte regValue = CameraRegisterValues.AutoExposureGainOff;
			if( __configAutoExposureGain.Checked ) regValue = CameraRegisterValues.AutoExposureGainOn;
			
			_cam.SetCameraRegisterValue(CameraRegister.AutoExposure, regValue);
		}
		
		private void __configPixelDifference_CheckedChanged(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			_cam.SetPixelDifferenceEnabled( __configPixelDifference.Checked );
		}
		
		private void __configBrightness_ValueChanged(object sender, EventArgs e) {
			
			__configBrightnessLbl.Text = "Brightness\n" + __configBrightness.Value;
		}
		
		private void __configBrightness_ScrollStopped(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			Byte regValue = Convert.ToByte( __configBrightness.Value );
			_cam.SetCameraRegisterValue(CameraRegister.Brightness, regValue );
		}
		
		private void  __configContrast_ValueChanged(object sender, EventArgs e) {
			
			__configContrastLbl.Text = "Contrast\n" + __configBrightness.Value;
		}
		
		private void __configContrast_ScrollStopped(object sender, EventArgs e) {
			if( _restoringValues ) return;
			
			Byte regValue = Convert.ToByte( __configContrast.Value );
			_cam.SetCameraRegisterValue(CameraRegister.Contrast, regValue );
		}
		
		private void __configReset_Click(object sender, EventArgs e) {
			
			_cam.Reset();
			
			ReloadConfiguration();
		}
		
#endregion
		
	}
}
