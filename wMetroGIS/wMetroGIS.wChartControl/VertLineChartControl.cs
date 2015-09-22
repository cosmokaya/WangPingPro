using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace wMetroGIS.wChartControl
{
	public class VertLineChartControl : BaseChartControl
	{
		private float[] m_ChartDataX = null;

		private float[] m_ChartDataY = null;

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.ColorDialog colorDialog;

		private ZedGraphControl ChartGraph;

		public float[] ChartDataX
		{
			get
			{
				return this.m_ChartDataX;
			}
			set
			{
				this.m_ChartDataX = value;
			}
		}

		public float[] ChartDataY
		{
			get
			{
				return this.m_ChartDataY;
			}
			set
			{
				this.m_ChartDataY = value;
			}
		}

		public bool ShowContextMenu
		{
			get
			{
				return this.ChartGraph.IsShowContextMenu;
			}
			set
			{
				this.ChartGraph.IsShowContextMenu = value;
				this.ChartGraph.IsEnableHPan = value;
				this.ChartGraph.IsEnableHZoom = value;
				this.ChartGraph.IsEnableVPan = value;
				this.ChartGraph.IsEnableVZoom = value;
			}
		}

		public VertLineChartControl()
		{
			this.InitializeComponent();
			this.m_ChartDataX = null;
			this.m_ChartDataY = null;
			this.ChartGraph.IsShowPointValues = true;
		}

		public void ShowChartData(float[] ChartDataX, float[] ChartDataY, string Title, string XAxisName, string YAxisName, string[] xPointName)
		{
			this.m_ChartDataX = ChartDataX;
			this.m_ChartDataY = ChartDataY;
			base.Title = Title;
			base.XAxisName = XAxisName;
			base.YAxisName = YAxisName;
			base.XPointName = xPointName;
			this.ShowChartData();
		}

		public override void ShowChartData()
		{
			if (this.m_ChartDataX != null && this.m_ChartDataX.Length != 0 && this.m_ChartDataY != null && this.m_ChartDataY.Length != 0 && this.m_ChartDataX.Length == this.m_ChartDataY.Length)
			{
				this.LoadParams();
				double[] x = new double[this.m_ChartDataX.Length];
				double[] y = new double[this.m_ChartDataY.Length];
				double ymax = -99999.0;
				for (int i = 0; i < this.m_ChartDataX.Length; i++)
				{
					x[i] = (double)this.m_ChartDataX[i] * 1.0;
					y[i] = (double)this.m_ChartDataY[i] * 1.0;
					if (y[i] > ymax)
					{
						ymax = y[i];
					}
				}
				this.ChartGraph.GraphPane = new GraphPane(this.ChartGraph.ClientRectangle, "", "", "");
				GraphPane myPane = this.ChartGraph.GraphPane;
				myPane.Title.Text = base.Title;
				myPane.Title.FontSpec.Family = this.TitleFontFamily;
				myPane.Title.FontSpec.Size = (float)this.TitleFontSize;
				myPane.Title.FontSpec.FontColor = this.TitleFontColor;
				myPane.XAxis.Title.Text = base.XAxisName;
				myPane.XAxis.Title.FontSpec.Family = this.AxisFontFamily;
				myPane.XAxis.Title.FontSpec.Size = (float)this.AxisFontSize;
				myPane.XAxis.Title.FontSpec.FontColor = this.AxisFontColor;
				myPane.YAxis.Title.Text = base.YAxisName;
				myPane.YAxis.Title.FontSpec.Family = this.AxisFontFamily;
				myPane.YAxis.Title.FontSpec.Size = (float)this.AxisFontSize;
				myPane.YAxis.Title.FontSpec.FontColor = this.AxisFontColor;
				myPane.Fill = new Fill(this.PaneColor1, this.PaneColor2, this.PaneColorAngle);
				myPane.Chart.Fill = new Fill(this.ChartColor1, this.ChartColor2, this.ChartColor1, this.ChartColorAngle);
				LineItem curve = myPane.AddCurve("数据曲线", x, y, this.CurveColor, SymbolType.HDash);
				curve.Line.Width = (float)this.CurveWidth;
				curve.Line.IsSmooth = base.LineSmooth;
				curve.Line.SmoothTension = 0.6f;
				curve.Symbol.Fill = new Fill(System.Drawing.Color.White);
				curve.Symbol.Size = 10f;
				myPane.XAxis.MajorGrid.IsVisible = this.ShowMajorGridX;
				myPane.XAxis.MajorGrid.DashOn = 2f;
				myPane.XAxis.MajorGrid.DashOff = 1f;
				myPane.XAxis.MajorGrid.Color = this.GridColor;
				myPane.XAxis.MinorGrid.IsVisible = this.ShowMinorGridX;
				myPane.XAxis.MinorGrid.DashOn = 1f;
				myPane.XAxis.MinorGrid.DashOff = 2f;
				myPane.XAxis.MinorGrid.Color = this.GridColor;
				myPane.YAxis.MajorGrid.IsVisible = this.ShowMajorGridY;
				myPane.YAxis.MajorGrid.DashOn = 2f;
				myPane.YAxis.MajorGrid.DashOff = 1f;
				myPane.YAxis.MajorGrid.Color = this.GridColor;
				myPane.YAxis.MinorGrid.IsVisible = this.ShowMinorGridY;
				myPane.YAxis.MinorGrid.DashOn = 1f;
				myPane.YAxis.MinorGrid.DashOff = 2f;
				myPane.YAxis.MinorGrid.Color = this.GridColor;
				if (this.ShowBarValue)
				{
					BarItem.CreateBarLabels(myPane, this.BarValueIsCenter, "f2");
				}
				if (base.XPointName != null && base.XPointName.Length == x.Length)
				{
					myPane.XAxis.Scale.TextLabels = base.XPointName;
					myPane.XAxis.Type = AxisType.Text;
				}
				if (base.RangeBoxMin != base.RangeBoxMax)
				{
					BoxObj box = new BoxObj(1.0, base.RangeBoxMax, System.Convert.ToDouble(x.Length - 1), base.RangeBoxMax - base.RangeBoxMin, System.Drawing.Color.Empty, System.Drawing.Color.FromArgb(128, 225, 0, 0));
					box.Location.CoordinateFrame = CoordType.AxisXYScale;
					box.Location.AlignH = AlignH.Left;
					box.Location.AlignV = AlignV.Top;
					box.ZOrder = ZOrder.F_BehindGrid;
					myPane.GraphObjList.Add(box);
				}
				this.ChartGraph.AxisChange();
				this.ChartGraph.Refresh();
			}
		}

		public override ZedGraphControl GetGraphControl()
		{
			return this.ChartGraph;
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
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.ChartGraph = new ZedGraphControl();
			base.SuspendLayout();
			this.ChartGraph.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ChartGraph.IsEnableHPan = false;
			this.ChartGraph.IsEnableHZoom = false;
			this.ChartGraph.IsEnableVPan = false;
			this.ChartGraph.IsEnableVZoom = false;
			this.ChartGraph.IsShowContextMenu = false;
			this.ChartGraph.Location = new System.Drawing.Point(0, 0);
			this.ChartGraph.Name = "ChartGraph";
			this.ChartGraph.ScrollGrace = 0.0;
			this.ChartGraph.ScrollMaxX = 0.0;
			this.ChartGraph.ScrollMaxY = 0.0;
			this.ChartGraph.ScrollMaxY2 = 0.0;
			this.ChartGraph.ScrollMinX = 0.0;
			this.ChartGraph.ScrollMinY = 0.0;
			this.ChartGraph.ScrollMinY2 = 0.0;
			this.ChartGraph.Size = new System.Drawing.Size(297, 297);
			this.ChartGraph.TabIndex = 3;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.ChartGraph);
			base.Name = "VertLineChartControl";
			base.Size = new System.Drawing.Size(300, 300);
			base.ResumeLayout(false);
		}
	}
}
