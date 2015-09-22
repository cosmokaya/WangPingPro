using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Ribbon;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wMetroGIS.wFunctionFormLib
{
	public class ProgressFormEx : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		private RibbonClientPanel ribbonClientPanel1;

		private ProgressBarX progressBar;

		private LabelX labelInfo;

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
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.progressBar = new ProgressBarX();
			this.labelInfo = new LabelX();
			this.ribbonClientPanel1.SuspendLayout();
			base.SuspendLayout();
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.progressBar);
			this.ribbonClientPanel1.Controls.Add(this.labelInfo);
			this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ribbonClientPanel1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(735, 114);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.StyleMouseDown.Class = "";
			this.ribbonClientPanel1.StyleMouseOver.Class = "";
			this.ribbonClientPanel1.TabIndex = 0;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.progressBar.BackgroundStyle.Class = "";
			this.progressBar.Location = new System.Drawing.Point(17, 58);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(700, 35);
			this.progressBar.TabIndex = 1;
			this.progressBar.TextVisible = true;
			this.labelInfo.BackColor = System.Drawing.Color.Transparent;
			this.labelInfo.BackgroundStyle.Class = "";
			this.labelInfo.Font = new System.Drawing.Font("微软雅黑", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.labelInfo.Location = new System.Drawing.Point(17, 16);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(700, 36);
			this.labelInfo.TabIndex = 0;
			this.labelInfo.Text = "正在生成动画序列，请稍等......";
			this.labelInfo.TextAlignment = System.Drawing.StringAlignment.Center;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(735, 114);
			base.Controls.Add(this.ribbonClientPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Name = "AnimateProgressForm";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "TidalCurrentProgressForm";
			base.TopMost = true;
			base.Load += new System.EventHandler(this.AnimateProgressForm_Load);
			this.ribbonClientPanel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public ProgressFormEx()
		{
			this.InitializeComponent();
		}

		private void AnimateProgressForm_Load(object sender, System.EventArgs e)
		{
			this.progressBar.Minimum = 0;
			this.progressBar.Maximum = 145;
			this.progressBar.Value = 0;
		}

		public void SetProgressPos(int pos)
		{
			if (pos >= this.progressBar.Minimum && pos <= this.progressBar.Maximum)
			{
				this.progressBar.Value = pos;
				this.progressBar.Text = string.Format("己完成{0:0.00}%", (double)pos * 100.0 / (double)this.progressBar.Maximum);
			}
		}

		public void SetProgressText(string Text)
		{
			this.labelInfo.Text = Text;
		}

		public void SetProgressRange(int min, int max)
		{
			this.progressBar.Minimum = min;
			this.progressBar.Maximum = max;
			this.progressBar.Value = min;
		}
	}
}
