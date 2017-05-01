namespace Bham.CmuCam.Gui {
	partial class PortSelectForm {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.@__comList = new System.Windows.Forms.ListBox();
			this.@__comLbl = new System.Windows.Forms.Label();
			this.@__baudList = new System.Windows.Forms.ListBox();
			this.@__baudLbl = new System.Windows.Forms.Label();
			this.@__ok = new System.Windows.Forms.Button();
			this.@__cancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// __comList
			// 
			this.@__comList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
						| System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__comList.FormattingEnabled = true;
			this.@__comList.IntegralHeight = false;
			this.@__comList.Location = new System.Drawing.Point(12, 25);
			this.@__comList.Name = "__comList";
			this.@__comList.Size = new System.Drawing.Size(176, 96);
			this.@__comList.TabIndex = 0;
			// 
			// __comLbl
			// 
			this.@__comLbl.AutoSize = true;
			this.@__comLbl.Location = new System.Drawing.Point(12, 9);
			this.@__comLbl.Name = "__comLbl";
			this.@__comLbl.Size = new System.Drawing.Size(53, 13);
			this.@__comLbl.TabIndex = 1;
			this.@__comLbl.Text = "COM Port";
			// 
			// __baudList
			// 
			this.@__baudList.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
						| System.Windows.Forms.AnchorStyles.Right)));
			this.@__baudList.FormattingEnabled = true;
			this.@__baudList.IntegralHeight = false;
			this.@__baudList.Location = new System.Drawing.Point(12, 142);
			this.@__baudList.Name = "__baudList";
			this.@__baudList.Size = new System.Drawing.Size(176, 131);
			this.@__baudList.TabIndex = 2;
			// 
			// __baudLbl
			// 
			this.@__baudLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.@__baudLbl.AutoSize = true;
			this.@__baudLbl.Location = new System.Drawing.Point(12, 126);
			this.@__baudLbl.Name = "__baudLbl";
			this.@__baudLbl.Size = new System.Drawing.Size(58, 13);
			this.@__baudLbl.TabIndex = 3;
			this.@__baudLbl.Text = "Baud Rate";
			// 
			// __ok
			// 
			this.@__ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.@__ok.Location = new System.Drawing.Point(32, 279);
			this.@__ok.Name = "__ok";
			this.@__ok.Size = new System.Drawing.Size(75, 23);
			this.@__ok.TabIndex = 4;
			this.@__ok.Text = "OK";
			this.@__ok.UseVisualStyleBackColor = true;
			// 
			// __cancel
			// 
			this.@__cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.@__cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.@__cancel.Location = new System.Drawing.Point(113, 279);
			this.@__cancel.Name = "__cancel";
			this.@__cancel.Size = new System.Drawing.Size(75, 23);
			this.@__cancel.TabIndex = 5;
			this.@__cancel.Text = "Cancel";
			this.@__cancel.UseVisualStyleBackColor = true;
			// 
			// PortSelectForm
			// 
			this.AcceptButton = this.@__ok;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.@__cancel;
			this.ClientSize = new System.Drawing.Size(200, 311);
			this.Controls.Add(this.@__cancel);
			this.Controls.Add(this.@__ok);
			this.Controls.Add(this.@__baudLbl);
			this.Controls.Add(this.@__baudList);
			this.Controls.Add(this.@__comLbl);
			this.Controls.Add(this.@__comList);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "PortSelectForm";
			this.Text = "Select COM Port";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListBox __comList;
		private System.Windows.Forms.Label __comLbl;
		private System.Windows.Forms.ListBox __baudList;
		private System.Windows.Forms.Label __baudLbl;
		private System.Windows.Forms.Button __ok;
		private System.Windows.Forms.Button __cancel;
	}
}