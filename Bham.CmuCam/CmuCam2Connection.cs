using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;
using System.Diagnostics;
using System.Drawing;
using System.Threading;

using Bham.CmuCam.Packets;

using Cult = System.Globalization.CultureInfo;

namespace Bham.CmuCam {
	
	internal class CmuCam2Connection : IDisposable {
		
		private Object     _lock = new Object();
		private SerialPort _port;
		private Boolean    _stopStream;
		
		public void Dispose() {
			Dispose(true);
			GC.SuppressFinalize(this);
		}
		protected virtual void Dispose(Boolean disposing) {
			if(disposing) {
				_port.Dispose();
				_port = null;
			}
		}
		
		public CmuCam2Connection(String portName, int baudRate) {
			
			_port = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
			_port.ReadBufferSize = 65536;
			_port.NewLine        = "\r";
			_port.ReadTimeout    = 1000;
			// SerialPort uses ASCIIEncoding by default
			
			try {
				
				_port.Open();
				
			} catch(SystemException ex) {
				
				throw new CmuCamException("Unable to open COM port: " + portName + ", " + ex.Message);
			}
		}
		
		private String SendCommandInternal(String command, params Int32[] args) {
			
			String cmd = command;
			foreach(Int32 i in args) {
				cmd += " " + i.ToString(Cult.InvariantCulture);
			}
			
			Debug.WriteLine(">>>" + cmd.Replace("\r", "\\r") );
			_port.WriteLine( cmd );
			
			return cmd;
		}
		
		/// <summary>Exchanges a single command (which may be parameterised). The CMUcam2 will return either an ACK response or an NCK, in which case an exception is thrown.</summary>
		public void SendCommand(String command, params Int32[] args) {
			
			lock( _lock ) {
				
				SendCommandInternal( command, args );
				
				// Response will be: "ACK\r:"
				String respCode  = _port.ReadLine(); // skips the \r
				if( respCode != "ACK" ) throw new CmuCamException("Non-ACK Response: " + respCode);
				
				Char respColon = (Char)_port.ReadChar();
				if( respColon != ':' ) throw new CmuCamException("Unexpected Response");
				
			}
		}
		
		/// <summary>Exchanges a single command (which may be parameterised). The CMUcam2 will return an ACK response followed by a single result line. If an NCK is returned then an exception is thrown.</summary>
		public String SendCommandGetResponse(String command, params Int32[] args) {
			
			lock( _lock ) {
				
				SendCommandInternal( command, args );
				
				// Response will be: "ACK\r%VALUE%\r:"
				String respCode  = _port.ReadLine(); // skips the \r
				if( respCode != "ACK" ) throw new CmuCamException("Non-ACK Response: " + respCode);
				
				String resp      = _port.ReadLine();
				
				Char respColon = (Char)_port.ReadChar();
				if( respColon != ':' ) throw new CmuCamException("Unexpected Response");
				
				return resp;
			}
		}
		
		/// <summary>Issues the Idle command multiple times and discards any returned data.</summary>
		public void SendIdle() {
			
			lock( _lock ) {
				
				_port.DiscardInBuffer();
				
				_port.Write("\r");
				_port.BaseStream.Flush();
				
				_port.DiscardInBuffer();
				
				_port.Write("\r");
				_port.BaseStream.Flush();
				
				Thread.Sleep(100);
				
				_port.DiscardInBuffer();
			}
		}
		
		/// <summary>Exchanges a single command (which may be parameterised). The CMUcam2 will return an ACK response followed by a stream of packets. This method will extract the first packet (which must end with the sentinel) and then issue an Idle command. It will then clear the input buffer.</summary>
		public T SendCommandGetPacket<T>(PacketReader<T> reader, String command, params Int32[] args) where T : Packet {
			
			lock( _lock ) {
				
				SendCommandInternal( command, args );
				
				// Response will be: "ACK\r(PACKET\r):"
				String respCode  = _port.ReadLine(); // skips the \r
				if( respCode != "ACK" ) throw new CmuCamException("Non-ACK Response: " + respCode);
				
				T packet0 = reader.ReadPacket( _port );
				
				SendIdle(); // this will handle the trailing colon
				
				return packet0;
			}
		}
		
		/// <summary>Exchanges a single command (which may be parameterised). The CMUcam2 will return an ACK response followed by a stream of packets. This method will yield return each packet as it's received. To stop the stream call StopStream() on another thread and the method will return.</summary>
		public IEnumerable<T> SendCommandGetPacketStream<T>(PacketReader<T> reader, String command, params Int32[] args) where T : Packet {
			
			_stopStream = false;
			
			lock( _lock ) {
				
				SendCommandInternal( command, args );
				
				// Response will be: "ACK\r(PACKET\r):"
				String respCode  = _port.ReadLine(); // skips the \r
				if( respCode != "ACK" ) throw new CmuCamException("Non-ACK Response: " + respCode);
				
				while( !_stopStream ) {
					
					T packetN = reader.ReadPacket( _port );
					
					yield return packetN;
				}
				
				SendIdle();
			}
			
		}
		
		public void StopStream() {
			
			_stopStream = true;
		}
		
		/// <summary>Sends an array of raw bytes to the camera followed by \r, it then reads back an ACK/NCK response and colon.</summary>
		public void SendCommandRawArg(String command, Byte[] bytes) {
			
			lock( _lock ) {
				
				_port.Write(command);
				
				_port.Write(bytes, 0, bytes.Length);
				
				_port.WriteLine("");
				
				String respCode  = _port.ReadLine(); // skips the \r
				if( respCode != "ACK" ) throw new CmuCamException("Non-ACK Response: " + respCode);
				
				Char respColon = (Char)_port.ReadChar();
				if( respColon != ':' ) throw new CmuCamException("Unexpected Response");
			}
		}
		
	}
	
}
