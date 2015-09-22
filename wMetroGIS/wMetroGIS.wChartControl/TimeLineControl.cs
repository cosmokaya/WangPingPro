using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace wMetroGIS.wChartControl
{
	public class TimeLineControl : BaseChartControl
	{
		private float[] m_ChartData;

		private bool m_ShowBar;

		private bool m_ShowLine;

		private LineItem m_LineItem = null;

		private BarItem m_BarItem = null;

		private bool m_MouseIsDown = false;

		private double m_OldValue = 0.0;

		private int m_FindPointIndex = -1;

		private CurveItem m_FindCurveItem = null;

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.ColorDialog colorDialog;

		private ZedGraphControl ChartGraph;

		public event System.EventHandler eventCurveValueChanged;

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
			}
		}

		public TimeLineControl()
		{
			this.InitializeComponent();
			this.m_ShowBar = true;
			this.m_ShowLine = true;
			this.m_ChartData = null;
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
					double ymax = -99999.0;
					for (int i = 0; i < this.m_ChartData.Length; i++)
					{
						x[i] = (double)(i + 1) * 1.0;
						y[i] = (double)this.m_ChartData[i] * 1.0;
						if (y[i] > ymax)
						{
							ymax = y[i];
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
							this.m_LineItem = myPane.AddCurve("", x, y, this.CurveColor, SymbolType.HDash);
							this.m_LineItem.Line.Width = (float)this.CurveWidth;
							this.m_LineItem.Line.IsSmooth = base.LineSmooth;
							this.m_LineItem.Line.SmoothTension = 0.6f;
							this.m_LineItem.Symbol.Fill = new Fill(System.Drawing.Color.White);
							this.m_LineItem.Symbol.Size = 10f;
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
						myPane.XAxis.Scale.Max = (double)(this.m_ChartData.Length + 1);
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

		private bool ChartGraph_MouseDownEvent(ZedGraphControl sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				if (sender.GraphPane.FindNearestPoint(e.Location, out this.m_FindCurveItem, out this.m_FindPointIndex))
				{
					double x;
					double y;
					sender.GraphPane.ReverseTransform(e.Location, out x, out y);
					this.m_OldValue = y;
				}
				else
				{
					this.m_FindCurveItem = null;
					this.m_FindPointIndex = -1;
				}
				this.m_MouseIsDown = true;
			}
			return false;
		}

		private bool ChartGraph_MouseMoveEvent(ZedGraphControl sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.m_MouseIsDown)
			{
				if (this.m_FindCurveItem != null && this.m_FindPointIndex != -1)
				{
					double x;
					double y;
					sender.GraphPane.ReverseTransform(e.Location, out x, out y);
					double offSet = y - this.m_OldValue;
					if (this.m_BarItem != null)
					{
						this.m_BarItem.Points[this.m_FindPointIndex].Y += offSet;
					}
					if (this.m_LineItem != null)
					{
						this.m_LineItem.Points[this.m_FindPointIndex].Y += offSet;
					}
					this.m_ChartData[this.m_FindPointIndex] += System.Convert.ToSingle(offSet);
					this.m_OldValue = y;
					sender.AxisChange();
					sender.Refresh();
				}
			}
			return false;
		}

		private bool ChartGraph_MouseUpEvent(ZedGraphControl sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.m_FindPointIndex != -1)
			{
				this.ShowChartData();
				if (this.eventCurveValueChanged != null)
				{
					this.eventCurveValueChanged(this, new System.EventArgs());
				}
			}
			this.m_MouseIsDown = false;
			this.m_OldValue = 0.0;
			this.m_FindCurveItem = null;
			this.m_FindPointIndex = -1;
			return false;
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
			this.ChartGraph.Size = new System.Drawing.Size(566, 286);
			this.ChartGraph.TabIndex = 3;
			this.ChartGraph.MouseDownEvent += new ZedGraphControl.ZedMouseEventHandler(this.ChartGraph_MouseDownEvent);
			this.ChartGraph.MouseUpEvent += new ZedGraphControl.ZedMouseEventHandler(this.ChartGraph_MouseUpEvent);
			this.ChartGraph.MouseMoveEvent += new ZedGraphControl.ZedMouseEventHandler(this.ChartGraph_MouseMoveEvent);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.ChartGraph);
			base.Name = "CurveControlBarControl";
			base.Size = new System.Drawing.Size(569, 289);
			base.ResumeLayout(false);
		}
	}
}
