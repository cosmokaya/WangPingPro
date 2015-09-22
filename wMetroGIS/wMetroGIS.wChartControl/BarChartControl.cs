using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace wMetroGIS.wChartControl
{
	public class BarChartControl : BaseChartControl
	{
		private float[] m_ChartData = null;

		private bool m_ShowBar = true;

		private bool m_ShowLine = true;

		private string m_BarName = "柱状图";

		private string m_LineName = "折线图";

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.ColorDialog colorDialog;

		private ZedGraphControl ChartGraph;

		public bool ShowBar
		{
			get
			{
				return this.m_ShowBar;
			}
			set
			{
				this.m_ShowBar = value;
			}
		}

		public bool ShowLine
		{
			get
			{
				return this.m_ShowLine;
			}
			set
			{
				this.m_ShowLine = value;
			}
		}

		public float[] ChartData
		{
			get
			{
				return this.m_ChartData;
			}
			set
			{
				this.m_ChartData = value;
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

		public string BarName
		{
			get
			{
				return this.m_BarName;
			}
			set
			{
				this.m_BarName = value;
			}
		}

		public string LineName
		{
			get
			{
				return this.m_LineName;
			}
			set
			{
				this.m_LineName = value;
			}
		}

		public BarChartControl()
		{
			this.InitializeComponent();
			this.m_ShowBar = true;
			this.m_ShowLine = true;
			this.m_ChartData = null;
			this.ChartGraph.IsShowPointValues = true;
		}

		public void ShowChartData(float[] ChartData, string Title, string XAxisName, string YAxisName, string[] xPointName)
		{
			this.m_ChartData = ChartData;
			base.Title = Title;
			base.XAxisName = XAxisName;
			base.YAxisName = YAxisName;
			base.XPointName = xPointName;
			this.ShowChartData();
		}

		public override void ShowChartData()
		{
			if (this.m_ShowBar || this.m_ShowLine)
			{
				if (this.m_ChartData != null && this.m_ChartData.Length != 0)
				{
					this.LoadParams();
					double[] x = new double[this.m_ChartData.Length];
					double[] y = new double[this.m_ChartData.Length];
					double ymin = 1.7976931348623157E+308;
					double ymax = -1.7976931348623157E+308;
					for (int i = 0; i < this.m_ChartData.Length; i++)
					{
						x[i] = (double)(i + 1) * 1.0;
						y[i] = (double)this.m_ChartData[i] * 1.0;
						if (y[i] > ymax)
						{
							ymax = y[i];
						}
						if (y[i] < ymin)
						{
							ymin = y[i];
						}
					}
					if (this.ChartGraph.ClientRectangle.Width != 0 && this.ChartGraph.ClientRectangle.Height != 0)
					{
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
						if (this.m_ShowLine)
						{
							LineItem curve = myPane.AddCurve(this.m_LineName, x, y, this.CurveColor, SymbolType.HDash);
							curve.Line.Width = (float)this.CurveWidth;
							curve.Line.IsSmooth = base.LineSmooth;
							curve.Line.SmoothTension = 0.6f;
							curve.Symbol.Fill = new Fill(System.Drawing.Color.White);
							curve.Symbol.Size = 10f;
						}
						if (this.m_ShowBar)
						{
							BarItem bar = myPane.AddBar(this.m_BarName, x, y, System.Drawing.Color.SteelBlue);
							bar.Bar.Fill = new Fill(this.BarColor1, this.BarColor2, this.BarColor1, this.BarColorAngle);
						}
						myPane.XAxis.MajorGrid.IsVisible = this.ShowMajorGridX;
						myPane.XAxis.MajorGrid.DashOn = 2f;
						myPane.XAxis.MajorGrid.DashOff = 1f;
						myPane.XAxis.MajorGrid.Color = this.GridColor;
						myPane.XAxis.Scale.MajorStep = 1.0;
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
						myPane.XAxis.Scale.Min = 0.0;
						myPane.XAxis.Scale.Max = (double)(this.m_ChartData.Length + 1);
						if (ymax > ymin)
						{
							myPane.YAxis.Scale.Min = ymin - 0.2 * (ymax - ymin);
							myPane.YAxis.Scale.Max = ymax + 0.2 * (ymax - ymin);
						}
						if (this.ShowBarValue)
						{
							BarItem.CreateBarLabels(myPane, this.BarValueIsCenter, base.BarTextFormat);
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
			this.ChartGraph.IsEnableHEdit = true;
			this.ChartGraph.IsEnableHPan = false;
			this.ChartGraph.IsEnableHZoom = false;
			this.ChartGraph.IsEnableVEdit = true;
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
			this.ChartGraph.Size = new System.Drawing.Size(566, 286);
			this.ChartGraph.TabIndex = 3;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.ChartGraph);
			base.Name = "BarChartControl";
			base.Size = new System.Drawing.Size(569, 289);
			base.ResumeLayout(false);
		}
	}
}
