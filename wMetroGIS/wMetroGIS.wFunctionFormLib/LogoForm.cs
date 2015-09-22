using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace wMetroGIS.wFunctionFormLib
{
	public class LogoForm : System.Windows.Forms.Form
	{
		public string m_LogoPicturePath = "";

		private int time_tick;

		private bool isStart;

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.PictureBox pictureBox;

		private System.Windows.Forms.Timer timer;

		public LogoForm()
		{
			this.InitializeComponent();
		}

		private void LogoForm_Load(object sender, System.EventArgs e)
		{
			try
			{
				if (this.m_LogoPicturePath == "")
				{
					this.m_LogoPicturePath = System.Windows.Forms.Application.StartupPath + "\\AppData\\LOGO.JPG";
				}
				if (!System.IO.File.Exists(this.m_LogoPicturePath))
				{
					base.Close();
				}
				System.Drawing.Bitmap logoImage = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(this.m_LogoPicturePath);
				base.Width = logoImage.Width;
				base.Height = logoImage.Height;
				this.pictureBox.Image = logoImage;
				base.Location = new System.Drawing.Point((System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width - logoImage.Width) / 2, (System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height - logoImage.Height) / 2);
				this.isStart = true;
			}
			catch
			{
				base.Close();
			}
			this.time_tick = 0;
			this.timer.Start();
		}

		private void timer_Tick(object sender, System.EventArgs e)
		{
			this.time_tick++;
			if (this.isStart)
			{
				base.Opacity = (double)this.time_tick / 10.0;
				if (this.time_tick > 30)
				{
					this.timer.Stop();
					this.isStart = false;
					this.time_tick = 0;
					this.timer.Start();
				}
			}
			else
			{
				base.Opacity = (double)(10 - this.time_tick) / 10.0;
				if (this.time_tick > 10)
				{
					this.timer.Stop();
					base.Close();
				}
			}
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.timer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)this.pictureBox).BeginInit();
			base.SuspendLayout();
			this.pictureBox.BackColor = System.Drawing.Color.Black;
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Location = new System.Drawing.Point(0, 0);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(640, 480);
			this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(640, 480);
			base.ControlBox = false;
			base.Controls.Add(this.pictureBox);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "LogoForm";
			base.Opacity = 0.0;
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "LogoForm";
			base.TopMost = true;
			base.Load += new System.EventHandler(this.LogoForm_Load);
			((System.ComponentModel.ISupportInitialize)this.pictureBox).EndInit();
			base.ResumeLayout(false);
		}
	}
}
