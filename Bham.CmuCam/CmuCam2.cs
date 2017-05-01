using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Collections.ObjectModel;

using Bham.CmuCam.Packets;

using Cult = System.Globalization.CultureInfo;

namespace Bham.CmuCam {
	
	/// <summary>Represents a single CMUcam2 camera connected to a serial port on the local computer.</summary>
	public class CmuCam2 : IDisposable {
		
		/// <summary>Releases the unmanaged resources (the serial port connection) used by the CmuCam2 object.</summary>
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		/// <summary>Releases the unmanaged resources used by the CmuCam2 object, and optionally releases the managed resources.</summary>
		protected virtual void Dispose(Boolean disposing) {
			if(disposing) {
				_c.Dispose();
				_c = null;
			}
		}
		
		private CmuCam2Connection _c;
		
		private class RegisterState : Dictionary<CameraRegister,byte> {
			public new Byte this[CameraRegister register] {
				get {
					if( base.ContainsKey(register) ) return base[register];
					else throw new KeyNotFoundException("No cache for " + register);
				}
				set {
					if( base.ContainsKey(register) ) base[register] = value;
					else base.Add(register, value);
				}
			}
		}
		
		//////////////////////////////
		// State cache:
		
		// Configuration
		private Boolean         _stateFrameBuffer;
		private PowerMode       _statePowerMode;
		private CameraType      _stateSlaveCameraType;
		private Boolean         _stateHighResolution;
		private Channel         _stateFrameDifferencingChannel;
		private Boolean         _stateFrameDifferencingHighRes;
		private Byte            _stateNoiseFilter;
		private Boolean         _statePixelDifference;
		private Boolean         _stateTrackInverted;
		private LedMode         _stateLed1;
		private LedMode         _stateLed2;
		private Byte            _stateDownsampleX;
		private Byte            _stateDownsampleY;
		private RegisterState   _stateRegisters = new RegisterState();
		private VirtualWindow   _stateWindow;
		private Size            _stateFullFrameSize;
		
		private HistogramBinCount _stateHistogramBins;
		private Byte              _stateHistogramScale;
		private Boolean           _stateHistogramTracking;
		
		private Color           _stateTrackMin;
		private Color           _stateTrackMax;
		
		// Seros
		private Boolean[]       _stateServoHigh = new Boolean[] { false, false, false, false, false };
		
		private Byte            _stateServoPanFar;
		private Byte            _stateServoPanNear;
		private Byte            _stateServoPanStep;
		private Byte            _stateServoTiltFar;
		private Byte            _stateServoTiltNear;
		private Byte            _stateServoTiltStep;
		
		private Boolean         _stateServoPanControl;
		private Boolean         _stateServoTiltControl;
		private Boolean         _stateServoPanReport;
		private Boolean         _stateServoTiltReport;
		
		
		// Protocol and Serial
		private Boolean         _statePollMode;
		private Byte            _stateSerialDelay;
		private Boolean         _stateFrameStreaming;
		private Int32           _statePacketSkipRate;
		private Boolean         _statePacketFiltering;
		
		private Byte            _stateLineModeTrack;
		private Byte            _stateLineModeMean;
		private Byte            _stateLineModeDiff;
		
		private Dictionary<PacketType,Byte> _stateOutputMask = new Dictionary<PacketType,Byte>();
		
		public CmuCam2(String portName, CmuCam2Baud baudRate) {
			
			_c = new CmuCam2Connection(portName, (int)baudRate);
			// Reset the camera, restore to known default state
			
			_c.SendIdle();
			
			ResetState();
			
			CameraVersion = Reset();
			ComPortName   = portName;
		}
		
		private void ResetState() {
			
			// Protocol and Serial
			_statePollMode                 = false;
			_stateSerialDelay              = 0;
			_statePacketSkipRate           = 0;
			_statePacketFiltering          = false;
			_stateLineModeTrack            = 0;
			_stateLineModeMean             = 0;
			_stateLineModeDiff             = 0;
			_stateOutputMask.Clear();
			_stateFrameStreaming           = false;
			
			// Configuration
			_stateFrameBuffer              = false;
			_statePowerMode                = PowerMode.On;
			_stateSlaveCameraType          = CameraType.OV6620;
			_stateHighResolution           = false;
			_stateFrameDifferencingChannel = Channel.Green;
			_stateFrameDifferencingHighRes = false;
			_stateNoiseFilter              = 2;
			_statePixelDifference          = false;
			_stateTrackInverted            = false;
			_stateLed1                     = LedMode.Auto;
			_stateLed2                     = LedMode.Auto;
			_stateDownsampleX              = 1;
			_stateDownsampleY              = 1;
			
			_stateWindow                   = GetVirtualWindow();
			_stateFullFrameSize            = new Size( _stateWindow.Width, _stateWindow.Height );
			
			_stateHistogramBins            = HistogramBinCount.Bins28;
			_stateHistogramScale           = 0;
			_stateHistogramTracking        = false;
			
			// Servo
			_stateServoPanFar              = 16;
			_stateServoPanNear             =  8;
			_stateServoPanStep             =  5;
			_stateServoTiltFar             = 16;
			_stateServoTiltNear            =  8;
			_stateServoTiltStep            =  5;
			for(int i=0;i<_stateServoHigh.Length;i++) _stateServoHigh[i] = false;
			
			
			ResetRegistersState();
			
			ReloadState();
		}
		
		private void ResetRegistersState() {
			_stateRegisters.Clear();
			_stateRegisters[CameraRegister.Brightness]   = 127; // The default is not defined in the manual, but my research shows 127 is the default for both brightness and contrast
			_stateRegisters[CameraRegister.Contrast]     = 127;
			_stateRegisters[CameraRegister.ColorMode]    = CameraRegisterValues.ColorRgb;
			_stateRegisters[CameraRegister.ClockSpeed]   = CameraRegisterValues.Clock50Fps;
			_stateRegisters[CameraRegister.AutoExposure] = CameraRegisterValues.AutoExposureGainOn;
		}
		
		/// <summary>Queries the camera for various state values that don't have reliable defaults.</summary>
		private void ReloadState() {
			
			SetHighResolution( _stateHighResolution );
		}
		
		/// <summary>Gets the camera version string reported by the camera.</summary>
		public String CameraVersion { get; private set; }
		/// <summary>Gets the name of the COM port the camera is currently connected to</summary>
		public String ComPortName   { get; private set; }
		
		/// <summary>Returns true if the camera is currently streaming data in one of the streaming methods.</summary>
		public bool IsStreaming { get; private set; }
		
		/// <summary>Causes the camera to abort sending streaming data. This method causes an Idle command to be sent to the camera.</summary>
		public void StopStream() {
			_c.StopStream();
			IsStreaming = false;
		}
		
#region Configuration
		
		public Boolean       FrameBufferEnabled     { get { return _stateFrameBuffer; } }
		/// <summary>Gets the user-specified slave camera type.</summary>
		public CameraType    SlaveCameraType        { get { return _stateSlaveCameraType; } }
		/// <summary>Gets wheather or not the camera is in high-resolution mode or not. High resolution mode affects almost every coordinate system in the camera (such as tracking).</summary>
		public Boolean       HighResolutionEnabled  { get { return _stateHighResolution; } }
		public PowerMode     PowerMode              { get { return _statePowerMode; } }
		public Size          DownSampling           { get { return new Size( _stateDownsampleX, _stateDownsampleY ); } }
		public VirtualWindow ViewWindow             { get { return _stateWindow; } }
		public Boolean       PixelDifferenceEnabled { get { return _statePixelDifference; } }
		
		/// <summary>Sets the mode of the CMUcam's frame buffer. When disabled (the default) new frames are constantly being pushed into the frame buffer. When enabled a single frame remains in the frame buffer until ReadFrame is called. This allows multiple processing calls to be applied to the same frame. Calling ReadFrame will then read a new frame into the buffer from the camera. When disabled ReadFrame is not required to get new frames.</summary>
		public void SetFrameBuffer(bool enabled) {
			
			_c.SendCommand("BM", enabled ? 1 : 0 );
			_stateFrameBuffer = enabled;
		}
		
		public Byte GetCameraRegisterValue(CameraRegister register) {
			return _stateRegisters[register];
		}
		
		/// <summary>Sets the camera's internal register values directly. The register locations and settings can be found in the Omnivision CMOS camera documentation.</summary>
		public void SetCameraRegisterValue(CameraRegister register, byte value) {
			
			_c.SendCommand("CR", (byte)register, value);
			_stateRegisters[register] = value;
		}
		
		/// <summary>Resets the camera and restores the camera's register values to their defaults.</summary>
		public void SetCameraRegistersToDefaults() {
			
			_c.SendCommand("CR");
			ResetRegistersState();
		}
		
		/// <summary>Sets the camera type while the camera is in slave mode. Since the CMUcam2 can not determine the type of the camera without communicating with the module it is not possible for it to auto-detect the camera type in slave mode. The default slave mode startup value assumes the OV6620.</summary>
		public void SetSlaveCameraType(CameraType type) {
			
			_c.SendCommand("CT", (byte)type );
			_stateSlaveCameraType = type;
		}
		
		/// <summary>Sets the high-resolution mode of the camera. High resolution mode affects almost every coordinate system in the camera (such as tracking).</summary>
		public void SetHighResolution(bool enabled) {
			
			_c.SendCommand("HR", enabled ? 1 : 0 );
			_stateHighResolution = enabled;
			
			ResetViewWindow();
			
			VirtualWindow frame = GetVirtualWindow();
			_stateFullFrameSize = new Size( frame.Width, frame.Height );
		}
		
		public void SetPowerMode(PowerMode mode) {
			
			switch(mode) {
				case PowerMode.On:
					
					if( _statePowerMode == PowerMode.PoweredDown ) {
						
						_c.SendCommand("CP", 1);
						
					} else {
						
						_c.SendIdle();
						Thread.Sleep( 15 );
					}
					
					break;
				case PowerMode.PoweredDown:
					_c.SendCommand("CP", 0);
					break;
				case PowerMode.Sleep:
					_c.SendCommand("SL");
					break;
				case PowerMode.DeepSleep:
					_c.SendCommand("DS");
					break;
			}
			
			_statePowerMode = mode;
			
		}
		
		/// <summary>Sets the downsampling of the image beng processed. A factor of 1 means there is no change in the resolution. A factor of 2 halves the resolution of the axis. This gives you a speed increase and reduces the amount of data sent. Commands like SendFrame and TrackColor will operate at this lower downsampled resolution.</summary>
		public void SetDownSampling(byte xFactor, byte yFactor) {
			
			_c.SendCommand("DS", xFactor, yFactor);
			_stateDownsampleX = xFactor;
			_stateDownsampleY = yFactor;
			
			VirtualWindow frame = GetVirtualWindow();
			_stateFullFrameSize = new Size( frame.Width, frame.Height );
		}
		
		public void SetVirtualWindow(byte x, byte y, byte bx, byte by) {
			
			_c.SendCommand("VW", x, y, bx, by);
			_stateWindow = new VirtualWindow(x, y, bx, by );
		}
		
		public VirtualWindow GetVirtualWindow() {
			
			String resp = _c.SendCommandGetResponse("GW");
			String[] components = resp.Split(' ');
			if( components.Length != 4 ) throw new CmuCamException("Expected 4-tuple response");
			
			Byte x  = Byte.Parse( components[0], Cult.InvariantCulture );
			Byte y  = Byte.Parse( components[1], Cult.InvariantCulture );
			Byte bx = Byte.Parse( components[2], Cult.InvariantCulture );
			Byte by = Byte.Parse( components[3], Cult.InvariantCulture );
			
			return _stateWindow = new VirtualWindow(x, y, bx, by);
		}
		
		/// <summary>Resets the Virtual Window size to that of the full-frame at the current resolution setting.</summary>
		public void ResetViewWindow() {
			
			_c.SendCommand("VW");
			_stateWindow = GetVirtualWindow();
		}
		
		public String Reset() {
			
			String response = _c.SendCommandGetResponse("RS");
			// response is the version string
			ResetState();
			
			return response;
		}
		
		public void SetPixelDifferenceEnabled(bool enabled) {
			
			_c.SendCommand("PD", enabled ? 1 : 0 );
			
			_statePixelDifference = enabled;
		}
		
#endregion
		
#region Serial Port and Protocol Control
		
		// Commands that change the protocol are private functions because the consuming program should never touch them, the CmuCam2 is a task-based library, not a simple wrapper.
		
		/// <summary>Sets the Frame Streaming mode of the camera. When enabled the camera will continuously send frames down the serial connection in response to a SendFrame command.</summary>
		private void SetFrameStreaming(bool enabled) {
			
			_c.SendCommand("FS", enabled ? 1 : 0 );
			_stateFrameStreaming = enabled;
		}
		
		private void SetSerialMode(bool rawOutput, bool suppressAckNck, bool rawInput) {
			
			byte v = 0;
			if( rawOutput      ) v |= 0x1; // 001
			if( suppressAckNck ) v |= 0x2; // 010
			if( rawInput       ) v |= 0x4; // 100
			
			_c.SendCommand("RM", v);
		}
		
		/// <summary>Sets the Delay Mode which controls the delay between characters that are transmitted over the serial port. This can give slower processors the time they need to handle serial data. A value fof 0 has no delay and 255 sets the maximum delay. Each delay unit is equal to the tranfer time of one bit at the current baud rate.</summary>
		private void SetSerialDelay(byte delay) {
			
			_c.SendCommand("DM", delay);
			_stateSerialDelay = delay;
		}
		
		/// <summary>Sets the Poll Mode to be enabled or not. When enabled a single packet is returned from the image processing functions. Otherwise a continuous stream of packets is returned.</summary>
		private void SetPollMode(bool pollModeEnabled) {
			
			_c.SendCommand("PM", pollModeEnabled ? 1 : 0 );
			_statePollMode = pollModeEnabled;
		}
		
		/// <summary>Sets the Packet Sskip rate. A value of 0 means all packets are transmitted for all streaming operations. A value of 1 skips every other packet, a value of 2 means only every second packet is transmitted, and so on.</summary>
		private void SetPacketSkipRate(int packetsToSkip) {
			
			_c.SendCommand("PS", packetsToSkip);
			_statePacketSkipRate = packetsToSkip;
		}
		
		/// <summary>Sets the Packet Filtering mode (default is disabled). When enabled (and tracking an object) only the first empty packet will be sent when the object disappears from view. Thus no packets will be transmitted until the object returns into view.</summary>
		private void SetPacketFiltering(bool enabled) {
			
			_c.SendCommand("PF", enabled ? 1 : 0);
			_statePacketFiltering = enabled;
		}
		
		private void SetOutputMask(PacketType packetType, bool showParam0, bool showParam1, bool showParam2, bool showParam3, bool showParam4, bool showParam5, bool showParam6, bool showParam7) {
			
			Byte mask = 0x00;
			if( showParam0 ) mask |= 0x01;
			if( showParam1 ) mask |= 0x02;
			if( showParam2 ) mask |= 0x04;
			if( showParam3 ) mask |= 0x08;
			if( showParam4 ) mask |= 0x10;
			if( showParam5 ) mask |= 0x20;
			if( showParam6 ) mask |= 0x40;
			if( showParam7 ) mask |= 0x80;
			
			SetOutputMask(packetType, mask);
		}
		
		private void SetOutputMask(PacketType packetType, Byte mask) {
			
			_c.SendCommand("OM", mask);
			
			if( _stateOutputMask.ContainsKey(packetType) ) _stateOutputMask[packetType] = mask;
			else                                           _stateOutputMask.Add(packetType, mask);
		}
		
		private void SetLineMode(LineMode line, byte mode) {
			
			_c.SendCommand("LM", (int)line, mode);
			
			switch(line) {
				case LineMode.TrackColor:
					_stateLineModeTrack = mode;
					break;
				case LineMode.Mean:
					_stateLineModeMean = mode;
					break;
				case LineMode.Differencing:
					_stateLineModeDiff = mode;
					break;
			}
			
		}
		
#endregion

#region Histogram and Statistics
		
		public HistogramBinCount HistogramBins     { get { return _stateHistogramBins; } }
		public Byte              HistogramScale    { get { return _stateHistogramScale; } }
		public Boolean           HistogramTracking { get { return _stateHistogramTracking; } }
		
		/// <summary>Gets the Mean color value in the current image. If, optionally, a subimage is selected via virtual windowing then this function only operates on that window.</summary>
		public SPacket GetMeanColor() {
			
			SetLineMode(LineMode.Mean, 0);
			
			SPacketReader rdr = new SPacketReader();
			
			SPacket spak = _c.SendCommandGetPacket(rdr, "GM");
			return spak;
		}
		
		public IEnumerable<SPacket> GetMeanColorStream() {
			
			SetLineMode(LineMode.Mean, 0);
			
			SPacketReader rdr = new SPacketReader();
			
			IEnumerable<SPacket> stream = _c.SendCommandGetPacketStream(rdr, "GM");
			IsStreaming = true;
			return stream;
		}
		
		public SPacketM1 GetMeanColorMode1() {
			
			SetLineMode(LineMode.Mean, 1);
			
			SPacketM1Reader rdr = new SPacketM1Reader();
			
			SPacketM1 spak = _c.SendCommandGetPacket(rdr, "GM");
			return spak;
		}
		
		public IEnumerable<SPacketM1> GetMeanColorMode1Stream() {
			
			SetLineMode(LineMode.Mean, 1);
			
			SPacketM1Reader rdr = new SPacketM1Reader();
			
			IEnumerable<SPacketM1> stream = _c.SendCommandGetPacketStream(rdr, "GM");
			IsStreaming = true;
			return stream;
		}
		
		public SPacketM2 GetMeanColorMode2() {
			
			SetLineMode(LineMode.Mean, 2);
			
			SPacketM2Reader rdr = new SPacketM2Reader();
			
			SPacketM2 spak = _c.SendCommandGetPacket(rdr, "GM");
			return spak;
		}
		
		public IEnumerable<SPacketM2> GetMeanColorMode2Stream() {
			
			SetLineMode(LineMode.Mean, 2);
			
			SPacketM2Reader rdr = new SPacketM2Reader();
			
			IEnumerable<SPacketM2> stream = _c.SendCommandGetPacketStream(rdr, "GM");
			IsStreaming = true;
			return stream;
		}
		
		/// <summary>Gets a histogram of the specified channel. The histogram contains 28 bins each holding the number of pixels that occurred within that bin's range of color values. So bin 0 contains the number of red pixels that were between 16 and 23 in value. The value returned in each bin is the number of pixels in that bin divided by the total number of pixels multiplied 256 and capped at 255.</summary>
		public HPacket GetHistogram(Channel channel) {
			
			HPacketReader rdr = new HPacketReader();
			
			HPacket hpak = _c.SendCommandGetPacket(rdr, "GH", (byte)channel );
			return hpak;
		}
		
		public IEnumerable<HPacket> GetHistogramStream(Channel channel) {
			
			HPacketReader rdr = new HPacketReader();
			
			IEnumerable<HPacket> stream = _c.SendCommandGetPacketStream(rdr, "GH", (byte)channel);
			IsStreaming = true;
			return stream;
		}
		
		public void SetHistogramConfiguration(HistogramBinCount nofBins, Byte scale) {
			
			_c.SendCommand("HC", (int)nofBins, scale);
			
			_stateHistogramBins  = nofBins;
			_stateHistogramScale = scale;
		}
		
		public void SetHistogramTracking(Boolean enabled) {
			
			_c.SendCommand("HT", enabled ? 1 : 0 );
			
			_stateHistogramTracking = enabled;
		}
		
#endregion
		
#region Tracking
		
		/// <summary>How many consecutive active pixels before the current pixel are required before the pixel should be detected (default 2). The range is between 0 and 255.</summary>
		public Byte    NoiseFilter   { get { return _stateNoiseFilter; } }
		public Boolean TrackInverted { get { return _stateTrackInverted; } }
		
	#region Mode 0
		
		public IEnumerable<TPacket> GetTrackingStream(Color min, Color max) {
			
			_stateTrackMin = min;
			_stateTrackMax = max;
			
			SetLineMode(LineMode.TrackColor, 0);
			
			TPacketReader rdr = new TPacketReader();
			
			IEnumerable<TPacket> stream = _c.SendCommandGetPacketStream(rdr, "TC", min.R, max.R, min.G, max.G, min.B, max.B);
			IsStreaming = true;
			return stream;
		}
		
		public IEnumerable<TPacket> GetTrackingStreamFromVWCenter() {
			
			SetLineMode(LineMode.TrackColor, 0);
			
			TPacketReader rdr = new TPacketReader(true);
			
			IEnumerable<TPacket> stream = _c.SendCommandGetPacketStream(rdr, "TW");
			IsStreaming = true;
			return stream;
		}
		
	#endregion
	#region Mode 1
		
		public IEnumerable<TPacketM1> GetTrackingMode1Stream(Color min, Color max) {
			
			_stateTrackMin = min;
			_stateTrackMax = max;
			
			SetLineMode(LineMode.TrackColor, 1);
			
			TPacketM1Reader rdr = new TPacketM1Reader();
			
			IEnumerable<TPacketM1> stream = _c.SendCommandGetPacketStream(rdr, "TC", min.R, max.R, min.G, max.G, min.B, max.B);
			IsStreaming = true;
			return stream;
		}
		
		public IEnumerable<TPacketM1> GetTrackingMode1StreamFromVWCenter() {
			
			SetLineMode(LineMode.TrackColor, 1);
			
			TPacketM1Reader rdr = new TPacketM1Reader();
			
			IEnumerable<TPacketM1> stream = _c.SendCommandGetPacketStream(rdr, "TW");
			IsStreaming = true;
			return stream;
		}
		
	#endregion
	#region Mode 2
		
		public IEnumerable<TPacketM2> GetTrackingMode2Stream(Color min, Color max) {
			
			_stateTrackMin = min;
			_stateTrackMax = max;
			
			SetLineMode(LineMode.TrackColor, 2);
			
			TPacketM2Reader rdr = new TPacketM2Reader();
			
			IEnumerable<TPacketM2> stream = _c.SendCommandGetPacketStream(rdr, "TC", min.R, max.R, min.G, max.G, min.B, max.B);
			IsStreaming = true;
			return stream;
		}
		
		public IEnumerable<TPacketM2> GetTrackingMode2StreamFromVWCenter() {
			
			SetLineMode(LineMode.TrackColor, 2);
			
			TPacketM2Reader rdr = new TPacketM2Reader();
			
			IEnumerable<TPacketM2> stream = _c.SendCommandGetPacketStream(rdr, "TW");
			IsStreaming = true;
			return stream;
		}
		
	#endregion
		
		/// <summary>Sets the colors used for tracking (as well as 'tracked histograms') but does not initiate a track.</summary>
		public void SetTrackingColors(Color min, Color max) {
			
			_stateTrackMin = min;
			_stateTrackMax = max;
			
			_c.SendCommand("ST", min.R, max.R, min.G, max.G, min.B, max.B);
			
		}
		
		public void GetTrackingColors(out Color min, out Color max) {
			
			String response = _c.SendCommandGetResponse("GT");
			
			String[] components = response.Split(' ');
			if( components.Length != 6 ) throw new CmuCamException("Unexpected response format");
			
			Byte rMin = Byte.Parse( components[0], Cult.InvariantCulture );
			Byte rMax = Byte.Parse( components[1], Cult.InvariantCulture );
			Byte gMin = Byte.Parse( components[2], Cult.InvariantCulture );
			Byte gMax = Byte.Parse( components[3], Cult.InvariantCulture );
			Byte bMin = Byte.Parse( components[4], Cult.InvariantCulture );
			Byte bMax = Byte.Parse( components[5], Cult.InvariantCulture );
			
			min = Color.FromArgb( rMin, gMin, bMin );
			max = Color.FromArgb( rMax, gMax, bMax );
			
			_stateTrackMin = min;
			_stateTrackMax = max;
		}
		
		/// <summary>This command controls the Noise Filter setting. It accepts a value that determines how many consecutive active pixels before the current pixel are required before the pixel should be detected (default 2). The range is between 0 and 255.</summary>
		public void SetNoiseFilter(Byte threshold) {
			
			_c.SendCommand("NF", threshold);
			
			_stateNoiseFilter = threshold;
		}
		
		public void SetTrackInverted(Boolean enabled) {
			
			_c.SendCommand("TI", enabled ? 1 : 0 );
			_stateTrackInverted = enabled;
		}
		
#endregion
		
#region Difference
		
		public Channel DifferencingChannel             { get { return _stateFrameDifferencingChannel; } }
		public Boolean DifferenceHighResolutionEnabled { get { return _stateFrameDifferencingHighRes; } }
		
		/// <summary>Sets the channel that is used for the frame differencing commands.</summary>
		public void SetDifferencingChannel(Channel channel) {
			
			_c.SendCommand("DC", (byte)channel );
			_stateFrameDifferencingChannel = channel;
		}
		
	#region Mode 0
		
		/// <summary><para>Calls Frame Differencing against the last loaded frame (using the LoadFrame command). It returns data containing the middle mass, bounding box, pixel count, and confidence of any change since the previously loaded frame. It does this by calculating the average color intensity of an 8x8 grid of 64 regions ont he image and comparing those (plus or minus the threshhold value). The larger the threshold the less sensitive the camera will be towards differences in the image. Usually values between 5 and 20 yield good results.</para><para>In High-resolution mode a 16x16 grid is used with 256 regions.</para></summary>
		public DPacket GetDifference(Byte threshold) {
			
			SetLineMode(LineMode.Differencing, 0);
			
			DPacketReader rdr = new DPacketReader() { Resolution = _stateFrameDifferencingHighRes ? 16 : 8 };
			
			DPacket dpak = _c.SendCommandGetPacket(rdr, "FD", threshold);
			return dpak;
		}
		
		public IEnumerable<DPacket> GetDifferenceStream(Byte threshold) {
			
			SetLineMode(LineMode.Differencing, 0);
			
			DPacketReader rdr = new DPacketReader() { Resolution = _stateFrameDifferencingHighRes ? 16 : 8 };
			
			IEnumerable<DPacket> stream = _c.SendCommandGetPacketStream(rdr, "FD", threshold);
			return stream;
		}
		
	#endregion
	#region Modes 1, 2, and 3
		
		public IEnumerable<DPacketM1> GetDifferenceMode1Stream(Byte threshold) {
			
			SetLineMode(LineMode.Differencing, 1);
			
			DPacketM1Reader rdr = new DPacketM1Reader();
			
			IEnumerable<DPacketM1> stream = _c.SendCommandGetPacketStream(rdr, "FD", threshold);
			return stream;
		}
		
		public IEnumerable<DPacketM2> GetDifferenceMode2Stream(Byte threshold) {
			
			SetLineMode(LineMode.Differencing, 1);
			
			DPacketM2Reader rdr = new DPacketM2Reader();
			
			IEnumerable<DPacketM2> stream = _c.SendCommandGetPacketStream(rdr, "FD", threshold);
			return stream;
		}
		
		public IEnumerable<DPacketM3> GetDifferenceMode3Stream(Byte threshold) {
			
			SetLineMode(LineMode.Differencing, 1);
			
			DPacketM3Reader rdr = new DPacketM3Reader();
			
			IEnumerable<DPacketM3> stream = _c.SendCommandGetPacketStream(rdr, "FD", threshold);
			return stream;
		}
		
	#endregion
		
		/// <summary>Loads a new Frame into the processor’s memory to be differenced from. This does not have anything to do with the camera’s frame buffer. It simply loads a baseline image for motion differencing and motion tracking.</summary>
		public void LoadDifferenceFrame() {
			
			_c.SendCommand("LF");
		}
		
		public DPacket GetDifferenceMask(Byte threshold) {
			
			DPacketReader rdr = new DPacketReader() { Resolution = _stateFrameDifferencingHighRes ? 16 : 8 };
			
			DPacket packet = _c.SendCommandGetPacket(rdr, "MD", threshold);
			
			return packet;
		}
		
		public IEnumerable<DPacket> GetDifferenceMaskStream(Byte threshold) {
			
			DPacketReader rdr = new DPacketReader() { Resolution = _stateFrameDifferencingHighRes ? 16 : 8 };
			
			IEnumerable<DPacket> stream = _c.SendCommandGetPacketStream(rdr, "MD", threshold );
			return stream;
		}
		
		public void SetDifferenceResolution(bool highResolution) {
			
			_c.SendCommand("HD", highResolution ? 1 : 0 );
			
			_stateFrameDifferencingHighRes = highResolution;
		}
		
		public void UploadDifferenceFrame(byte[] bitmap) {
			
			if( bitmap.Length != 64 ) throw new ArgumentException("Bitmap must consist of 64 byte elements");
			
			_c.SendCommandRawArg("UD", bitmap );
		}
		
#endregion
		
#region Non-Image Data Gathering
		
		/// <summary>Returns true if the camera's button was pressed anytime since the last call to GetButtonPress. Returns false otherwise.</summary>
		public Boolean GetButtonPress() {
			
			String response = _c.SendCommandGetResponse("GB");
			return response == "1";
		}
		
		public String GetVersion() {
			
			String response = _c.SendCommandGetResponse("GV");
			return response;
		}
		
		/// <summary>Get the auxiliary IO input values. A byte is returned containing the values of the auxiliary IO pins.</summary>
		public Byte GetAuxIO() {
			
			String response = _c.SendCommandGetResponse("GI");
			return Byte.Parse( response, Cult.InvariantCulture );
		}
		
		public LedMode Led1 {
			get { return _stateLed1; }
		}
		
		/// <summary></summary>
		public void SetLed1(LedMode mode) {
			_c.SendCommand("L0", (int)mode );
			_stateLed1 = mode;
		}
		
		public LedMode Led2 {
			get { return _stateLed2; }
		}
		
		public void SetLed2(LedMode mode) {
			_c.SendCommand("L1", (int)mode );
			_stateLed2 = mode;
		}
		
#endregion
		
#region Image Capture
		
		/// <summary>Reads a new frame into the buffer. This should only be used to get new data when using buffer mode. Under normal non-buffer mode operation a new frame is loaded right before a processing function is called.</summary>
		public void ReadFrame() {
			
			if( !_stateFrameBuffer ) throw new InvalidOperationException("Cannot read frame whilst in frame buffer is disabled.");
			
			_c.SendCommand("RF");
		}
		
		public FPacket GetFrame(Channels channel) {
			
			if( _stateFrameStreaming ) this.SetFrameStreaming( false );
			
			FPacketReader rdr = new FPacketReader() { 
				Channels      = channel,
				FullFrameSize = _stateFullFrameSize,
				VirtualWindow = _stateWindow,
				Streaming     = false
			};
			rdr.FrameProgress += new EventHandler<FrameProgressEventArgs>(OnGetSingleFrameProgress);
			
			FPacket frame;
			
			if( channel == Channels.All ) {
				
				frame = _c.SendCommandGetPacket(rdr, "SF");
				
			} else {
				
				frame = _c.SendCommandGetPacket(rdr, "SF", (byte)channel );
			}
			
			return frame;
		}
		
		public IEnumerable<FPacket> GetFrameStream(Channels channel) {
			
			if( !_stateFrameStreaming ) this.SetFrameStreaming( true );
			
			FPacketReader rdr = new FPacketReader() { 
				Channels      = channel,
				FullFrameSize = _stateFullFrameSize,
				VirtualWindow = _stateWindow,
				Streaming     = true
			};
			rdr.FrameProgress += new EventHandler<FrameProgressEventArgs>(OnGetSingleFrameProgress);
			
			IEnumerable<FPacket> frame;
			
			if( channel == Channels.All ) {
				
				frame = _c.SendCommandGetPacketStream(rdr, "SF");
				
			} else {
				
				frame = _c.SendCommandGetPacketStream(rdr, "SF", (byte)channel );
			}
			
			return frame;
		}
		
		private void OnGetSingleFrameProgress(Object sender, FrameProgressEventArgs e) {
			if( SingleFrameProgress != null ) SingleFrameProgress(this, e );
		}
		
		public event EventHandler<FrameProgressEventArgs> SingleFrameProgress;
		
#endregion
		
#region Servos
		
		public ReadOnlyCollection<Boolean> GetServoLevels() {
			
			return new ReadOnlyCollection<bool>( _stateServoHigh );
		}
		
		public void SetServoLevel(Servo servo, bool isHigh) {
			
			_c.SendCommand("SO", (int)servo, isHigh ? 1 : 0 );
			
			_stateServoHigh[ (int)servo ] = isHigh;
		}
		
		/// <summary>Sets the Servo Parameters that are used by the automatic tracking control law. Changing these values can help you tune your tracking for a particular servo setup. The automatic servoing uses a two stage “bang-bang” control law. When the pixel value is greater than the “far” range, the related servo will move by the step amount. When the pixel value is between the near and far range, the servo will move by half of the step amount. Any value smaller than the near value is part of the dead zone and will not trigger any servo motion.</summary>
		public void SetServoParameters(Byte panFar, Byte panNear, Byte panStep, Byte tiltFar, Byte tiltNear, Byte tiltStep) {
			
			_c.SendCommand("SP", panFar, panNear, panStep, tiltFar, tiltNear, tiltStep);
			
			_stateServoPanFar   = panFar;
			_stateServoPanNear  = panNear;
			_stateServoPanStep  = panStep;
			
			_stateServoTiltFar  = tiltFar;
			_stateServoTiltNear = tiltNear;
			_stateServoTiltStep = tiltStep;
		}
		
		public Byte GetServoPosition(Servo servo) {
			
			String resp = _c.SendCommandGetResponse("GS", (int)servo );
			return Byte.Parse( resp, Cult.InvariantCulture );
		}
		
		public void SetServoPosition(Servo servo, Byte position) {
			
			// effective range is 46 to 210
			
			_c.SendCommand("SV", (int)servo, position );
		}
		
		public void SetServoMask(bool panControlEnabled, bool tiltControlEnabled, bool panReportEnabled, bool tiltReportEnabled) {
			
			Byte v = 0;
			if( _stateServoPanControl  = panControlEnabled  ) v |= 0x1;
			if( _stateServoTiltControl = tiltControlEnabled ) v |= 0x2;
			if( _stateServoPanReport   = panReportEnabled   ) v |= 0x4;
			if( _stateServoTiltReport  = tiltReportEnabled  ) v |= 0x8;
			
			_c.SendCommand("SM", v);
		}
		
		public Boolean ServoPanControlEnabled  { get { return _stateServoPanControl;  } }
		public Boolean ServoTiltControlEnabled { get { return _stateServoTiltControl; } }
		public Boolean ServoPanReportEnabled   { get { return _stateServoPanReport;   } }
		public Boolean ServoTiltReportEnabled  { get { return _stateServoTiltReport;  } }
		
		public Byte ServoPanRangeFar  { get { return _stateServoPanFar;  } }
		public Byte ServoPanRangeNear { get { return _stateServoPanNear; } }
		public Byte ServoPanSteps     { get { return _stateServoPanStep; } }
		
		public Byte ServoTiltRangeFar  { get { return _stateServoTiltFar;  } }
		public Byte ServoTiltRangeNear { get { return _stateServoTiltNear; } }
		public Byte ServoTiltSteps     { get { return _stateServoTiltStep; } }
		
#endregion
		
	}
	
}
