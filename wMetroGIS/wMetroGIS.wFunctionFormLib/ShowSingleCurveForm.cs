using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Ribbon;
using DevComponents.DotNetBar.Validator;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wMetroGIS.wChartControl;
using wMetroGIS.wParams;

namespace wMetroGIS.wFunctionFormLib
{
	public class ShowSingleCurveForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		private RibbonClientPanel ribbonClientPanel1;

		private Highlighter highlighter1;

		private BarChartControl chartControl;

		private ButtonX buttonClose;

		public string m_FormTitle = "";

		public BarChartParams m_ChartParams = null;

		public string m_ChartTitle = "";

		public string m_ChartXAsixName = "";

		public string m_ChartYAxisName = "";

		public float[] m_ChartData = null;

		public string[] m_ChartXAxisPointStrings = null;

		public BarChartControl _ChartControl
		{
			get
			{
				return this.chartControl;
			}
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
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.buttonClose = new ButtonX();
			this.chartControl = new BarChartControl();
			this.highlighter1 = new Highlighter();
			this.ribbonClientPanel1.SuspendLayout();
			base.SuspendLayout();
			this.ribbonClientPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.buttonClose);
			this.ribbonClientPanel1.Controls.Add(this.chartControl);
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, -1);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(643, 543);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.StyleMouseDown.Class = "";
			this.ribbonClientPanel1.StyleMouseOver.Class = "";
			this.ribbonClientPanel1.TabIndex = 0;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonClose.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.buttonClose.ColorTable = eButtonColor.OrangeWithBackground;
			this.buttonClose.Font = new System.Drawing.Font("微软雅黑", 18f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonClose.Location = new System.Drawing.Point(12, 479);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(618, 51);
			this.buttonClose.Style = eDotNetBarStyle.StyleManagerControlled;
			this.buttonClose.TabIndex = 1;
			this.buttonClose.Text = "关\u3000闭";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			this.chartControl.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.chartControl.BarChartParams = null;
			this.chartControl.ChartData = null;
			this.chartControl.LineSmooth = false;
			this.chartControl.Location = new System.Drawing.Point(12, 13);
			this.chartControl.Name = "chartControl";
			this.chartControl.RangeBoxMax = 0.0;
			this.chartControl.RangeBoxMin = 0.0;
			this.chartControl.SetXYRange = false;
			this.chartControl.ShowBar = true;
			this.chartControl.ShowContextMenu = false;
			this.chartControl.ShowLine = true;
			this.chartControl.Size = new System.Drawing.Size(618, 460);
			this.chartControl.TabIndex = 0;
			this.chartControl.Title = null;
			this.chartControl.XAxisName = null;
			this.chartControl.XPointName = null;
			this.chartControl.YAxisName = null;
			this.highlighter1.ContainerControl = this;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(642, 541);
			base.ControlBox = false;
			base.Controls.Add(this.ribbonClientPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "ShowSingleCurveForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "标题";
			base.Load += new System.EventHandler(this.ShowSingleCurveForm_Load);
			this.ribbonClientPanel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public ShowSingleCurveForm()
		{
			this.InitializeComponent();
		}

		private void ShowSingleCurveForm_Load(object sender, System.EventArgs e)
		{
			this.Text = this.m_FormTitle;
			this.chartControl.BarChartParams = this.m_ChartParams;
			this.chartControl.ShowChartData(this.m_ChartData, this.m_ChartTitle, this.m_ChartXAsixName, this.m_ChartYAxisName, this.m_ChartXAxisPointStrings);
		}

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}
	}
}
