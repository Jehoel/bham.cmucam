using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using System.IO;

namespace Bham.CmuCam.Gui {
	
	public partial class PortSelectForm : Form {
		
		public PortSelectForm() {
			
			InitializeComponent();

			this.__ok.Click += new EventHandler(__ok_Click);
		}
		
		protected override void OnLoad(EventArgs e) {
			base.OnLoad(e);
			
			String[] ports = SerialPort.GetPortNames();
			__comList.Items.AddRange( ports );
			
			if( ports.Length == 0 ) {
				
				__comList.Items.Add("No COM Ports Detected");
				__ok.Enabled = false;
			} else {
				
				__comList.SelectedIndex = 0;
			}
			
			////////////////////////////
			
			Array values = Enum.GetValues(typeof(CmuCam2Baud)); // values is CmuCam2Baud[]
			foreach(CmuCam2Baud value in values) __baudList.Items.Add( (int)value );
			
			__baudList.SelectedIndex = __baudList.Items.Count - 1; // the lowest item is 115200
			
		}
		
		private void __ok_Click(object sender, EventArgs e) {
			
			Program.ComPort =       __comList .Items[ __comList.SelectedIndex  ].ToString();
			Program.BaudRate = (int)__baudList.Items[ __baudList.SelectedIndex ];
			
			try {
				
				Program.Camera = new CmuCam2( Program.ComPort, (CmuCam2Baud)Program.BaudRate );
				DialogResult = DialogResult.OK; // setting this causes the form to return from ShowDialog()
				
			} catch(CmuCamException cex) {
				
				MessageBox.Show(this, cex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				
				if( Program.Camera != null ) Program.Camera.Dispose();
				Program.Camera = null;
				
				return;
				
			} catch(TimeoutException) {
				
				MessageBox.Show(this, "Could not detect a CMUcam2 camera. The operation timed out.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
				
				if( Program.Camera != null ) Program.Camera.Dispose();
				Program.Camera = null;
				
				return;
			}
			
		}
		
	}
}
