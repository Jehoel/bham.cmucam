using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.Collections.ObjectModel;

namespace Bham.CmuCam {
	
	public class FrameProgressEventArgs : EventArgs {
		
		internal FrameProgressEventArgs(float percentage) {
		
			Percentage = percentage;
		}
		
		public float Percentage { get; private  set; }
	}
	
	internal enum PacketType {
		TrackColor                   = 0,
		GetMean                      = 1,
		FrameDifference              = 2,
		NonTrackedPackets            = 3,
		AdditionalCountInformation   = 4,
		TrackColorMode2              = 5,
		GetMeanMode1And2             = 6
	}
	
	/// <summary>Specifies the COM port baud rate for the CMUcam2 camera. Only supported baud rates are listed.</summary>
	public enum CmuCam2Baud {
		B115200 = 115200,
		B57600  = 57600,
		B38400  = 38400,
		B19200  = 19200,
		B9600   = 9600,
		B4800   = 4800,
		B2400   = 2400,
		B1200   = 1200
	}
	
	/// <summary>Specifies the image channels to return when querying for image frames from the camera.</summary>
	public enum Channels {
		All   = Byte.MaxValue,
		Red   =  0,
		Green =  1,
		Blue  =  2
	}
	
	/// <summary>Specifies the image channel to return when querying for histogram streams.</summary>
	public enum Channel {
		Red   = 0,
		Green = 1,
		Blue  = 2
	}
	
	/// <summary>Specifies the camera's power mode.</summary>
	public enum PowerMode {
		On,
		/// <summary>The camera is put into power-down mode. This preserves register state. Images in the frame buffer may become corrupted.</summary>
		PoweredDown,
		/// <summary>Puts the processor to sleep. Any command causes the camera to restore after a delay of 10ms. Sleeping disables the servo output.</summary>
		Sleep,
		/// <summary>Puts the processor to sleep as 'Sleep' does, but also uses one of the Aux IO pins to sleep the oscillator. See the manual for further instructions.</summary>
		DeepSleep
	}
	
	/// <summary>Specifies a known CmuCam2 camera processor register.</summary>
	public enum CameraRegister {
		Contrast = 5,
		Brightness = 6,
		ColorMode = 18,
		ClockSpeed = 17,
		AutoExposure = 19
	}
	
	public static class CameraRegisterValues {
		public const byte ColorYCbCrWB = 36;
		public const byte ColorYCbCr   = 32;
		public const byte ColorRgbWB   = 44;
		public const byte ColorRgb     = 40;
		
		public const byte Clock50Fps =  0;
		public const byte Clock26Fps =  1;
		public const byte Clock17Fps =  2;
		public const byte Clock13Fps =  3;
		public const byte Clock11Fps =  4;
		public const byte Clock09Fps =  5;
		public const byte Clock08Fps =  6;
		public const byte Clock07Fps =  7;
		public const byte Clock06Fps =  8;
		public const byte Clock05Fps = 10;
		
		public const byte AutoExposureGainOn  = 32;
		public const byte AutoExposureGainOff = 33;
	}
	
	/// <summary>Specifies the type of camera daughter-board connected to the CmuCam2 main board. Used when in slave mode.</summary>
	public enum CameraType {
		OV6620 = 0,
		OV7620 = 1
	}
	
	public enum LineMode {
		TrackColor   = 0,
		Mean         = 1,
		Differencing = 2
	}
	
	/// <summary>Specifies the status of the selected LED on the CmuCam2 mainboard.</summary>
	public enum LedMode {
		Off = 0,
		On  = 1,
		Auto = 2
	}
	
	/// <summary>Specifies the number of bins in returned histograms.</summary>
	public enum HistogramBinCount {
		Bins28 = 0,
		Bins14 = 1,
		Bins7  = 2
	}
	
	public enum Servo {
		Servo1 = 0,
		Servo2 = 1,
		Servo3 = 2,
		Servo4 = 3,
		Servo5 = 4
	}
	
}