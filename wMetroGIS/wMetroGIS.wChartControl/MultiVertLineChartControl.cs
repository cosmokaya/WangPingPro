using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ZedGraph;

namespace wMetroGIS.wChartControl
{
	public class MultiVertLineChartControl : BaseChartControl
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.ColorDialog colorDialog;

		private ZedGraphControl ChartGraph;

		private System.Collections.Generic.List<float[]> m_ChartDatasX = new System.Collections.Generic.List<float[]>();

		private System.Collections.Generic.List<float[]> m_ChartDatasY = new System.Collections.Generic.List<float[]>();

		private System.Collections.Generic.List<string> m_ChartDataNames = new System.Collections.Generic.List<string>();

		private System.Collections.Generic.List<System.Drawing.Color> m_ChartDataColors = new System.Collections.Generic.List<System.Drawing.Color>();

		public System.Collections.Generic.List<float[]> ChartDatasX
		{
			get
			{
				return this.m_ChartDatasX;
			}
			set
			{
				this.m_ChartDatasX = value;
			}
		}

		public System.Collections.Generic.List<float[]> ChartDatasY
		{
			get
			{
				return this.m_ChartDatasY;
			}
			set
			{
				this.m_ChartDatasY = value;
			}
		}

		public System.Collections.Generic.List<string> ChartDataNames
		{
			get
			{
				return this.m_ChartDataNames;
			}
			set
			{
				this.m_ChartDataNames = value;
			}
		}

		public System.Collections.Generic.List<System.Drawing.Color> ChartDataColors
		{
			get
			{
				return this.m_ChartDataColors;
			}
			set
			{
				this.m_ChartDataColors = value;
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

		public MultiVertLineChartControl()
		{
			this.InitializeComponent();
			this.m_ChartDatasX = null;
			this.m_ChartDatasY = null;
			this.ChartGraph.IsShowPointValues = true;
		}

		public void ShowChartData(System.Collections.Generic.List<float[]> ChartDatasX, System.Collections.Generic.List<float[]> ChartDatasY, System.Collections.Generic.List<string> ChartDataNames, System.Collections.Generic.List<System.Drawing.Color> ChartDataColors, string Title, string XAxisName, string YAxisName, string[] xPointName)
		{
			this.m_ChartDatasX = ChartDatasX;
			this.m_ChartDatasY = ChartDatasY;
			this.m_ChartDataNames = ChartDataNames;
			this.m_ChartDataColors = ChartDataColors;
			base.Title = Title;
			base.XAxisName = XAxisName;
			base.YAxisName = YAxisName;
			base.XPointName = xPointName;
			this.ShowChartData();
		}

		public override void ShowChartData()
		{
			if (this.m_ChartDatasX != null && this.m_ChartDatasX.Count != 0 && this.m_ChartDatasY != null && this.m_ChartDatasY.Count != 0)
			{
				if (this.m_ChartDataColors.Count == this.m_ChartDatasX.Count && this.m_ChartDataNames.Count == this.m_ChartDatasX.Count)
				{
					this.LoadParams();
					System.Collections.Generic.List<double[]> x = new System.Collections.Generic.List<double[]>();
					System.Collections.Generic.List<double[]> y = new System.Collections.Generic.List<double[]>();
					double ymax = -99999.0;
					for (int i = 0; i < this.m_ChartDatasX.Count; i++)
					{
						double[] tempx = new double[this.m_ChartDatasX[i].Length];
						double[] tempy = new double[this.m_ChartDatasY[i].Length];
						for (int j = 0; j < tempx.Length; j++)
						{
							tempx[j] = (double)this.m_ChartDatasX[i][j];
							tempy[j] = (double)this.m_ChartDatasY[i][j];
							if (tempy[j] > ymax)
							{
								ymax = tempy[j];
							}
						}
						x.Add(tempx);
						y.Add(tempy);
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
					for (int i = 0; i < x.Count; i++)
					{
						LineItem curve = myPane.AddCurve(this.m_ChartDataNames[i], x[i], y[i], this.m_ChartDataColors[i], SymbolType.HDash);
						curve.Line.Width = (float)this.CurveWidth;
						curve.Line.IsSmooth = base.LineSmooth;
						curve.Line.SmoothTension = 0.6f;
						curve.Symbol.Fill = new Fill(System.Drawing.Color.White);
						curve.Symbol.Size = 10f;
					}
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
					if (base.XPointName != null && base.XPointName.Length == x[0].Length)
					{
						myPane.XAxis.Scale.TextLabels = base.XPointName;
						myPane.XAxis.Type = AxisType.Text;
					}
					if (base.RangeBoxMin != base.RangeBoxMax)
					{
						BoxObj box = new BoxObj(1.0, base.RangeBoxMax, System.Convert.ToDouble(x[0].Length - 1), base.RangeBoxMax - base.RangeBoxMin, System.Drawing.Color.Empty, System.Drawing.Color.FromArgb(128, 225, 0, 0));
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

		public override ZedGraphControl GetGraphControl()
		{
			return this.ChartGraph;
		}
	}
}
