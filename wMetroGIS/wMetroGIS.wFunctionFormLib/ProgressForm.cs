using DevComponents.DotNetBar.Controls;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wMetroGIS.wFunctionFormLib
{
	public class ProgressForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		private ProgressBarX progressBarX1;

		private string ProgressInfoText = "";

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
			this.progressBarX1 = new ProgressBarX();
			base.SuspendLayout();
			this.progressBarX1.BackgroundStyle.Class = "";
			this.progressBarX1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.progressBarX1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.progressBarX1.Location = new System.Drawing.Point(0, 0);
			this.progressBarX1.Name = "progressBarX1";
			this.progressBarX1.Size = new System.Drawing.Size(700, 35);
			this.progressBarX1.TabIndex = 0;
			this.progressBarX1.TextVisible = true;
			this.progressBarX1.Value = 50;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(700, 35);
			base.ControlBox = false;
			base.Controls.Add(this.progressBarX1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "ProgressForm";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ProgressForm";
			base.TopMost = true;
			base.ResumeLayout(false);
		}

		public ProgressForm()
		{
			this.InitializeComponent();
		}

		public void SetProgressRange(int Min, int Max)
		{
			this.progressBarX1.Minimum = Min;
			this.progressBarX1.Maximum = Max;
			this.progressBarX1.Value = 0;
		}

		public void SetProgressPos(int Pos, bool ShowPercent)
		{
			if (Pos < this.progressBarX1.Minimum)
			{
				Pos = this.progressBarX1.Minimum;
			}
			else if (Pos > this.progressBarX1.Maximum)
			{
				Pos = this.progressBarX1.Maximum;
			}
			this.progressBarX1.Value = Pos;
			if (ShowPercent)
			{
				this.progressBarX1.Text = string.Format("{0} 完成{1:00}%", this.ProgressInfoText, 100.0 * (double)(Pos - this.progressBarX1.Minimum) / (double)(this.progressBarX1.Maximum - this.progressBarX1.Minimum));
			}
		}

		public void SetProgressInfoText(string Info)
		{
			this.ProgressInfoText = Info;
		}
	}
}
