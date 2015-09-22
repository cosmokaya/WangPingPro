using System;
using System.Drawing;
using System.Windows.Forms;
using wMetroGIS.wParams;
using ZedGraph;

namespace wMetroGIS.wChartControl
{
	public class BaseChartControl : System.Windows.Forms.UserControl
	{
		private BarChartParams m_BarChartParams;

		private string m_Title = "未设置标题";

		private string m_XAxisName = "X坐标";

		private string m_YAxisName = "Y坐标";

		private double m_RangeBoxMin = 0.0;

		private double m_RangeBoxMax = 1.0;

		private string[] m_XPointName = null;

		private bool m_SetXYRange = false;

		private bool m_LineSmooth = false;

		private string m_BarTextFormat = "F2";

		public string TitleFontFamily;

		public System.Drawing.Color TitleFontColor;

		public int TitleFontSize;

		public string AxisFontFamily;

		public System.Drawing.Color AxisFontColor;

		public int AxisFontSize;

		public System.Drawing.Color PaneColor1;

		public System.Drawing.Color PaneColor2;

		public float PaneColorAngle;

		public System.Drawing.Color ChartColor1;

		public System.Drawing.Color ChartColor2;

		public float ChartColorAngle;

		public System.Drawing.Color BarColor1;

		public System.Drawing.Color BarColor2;

		public float BarColorAngle;

		public bool ShowBarValue;

		public bool BarValueIsCenter;

		public System.Drawing.Color CurveColor;

		public int CurveWidth;

		public System.Drawing.Color GridColor;

		public bool ShowMajorGridX;

		public bool ShowMajorGridY;

		public bool ShowMinorGridX;

		public bool ShowMinorGridY;

		public BarChartParams BarChartParams
		{
			get
			{
				return this.m_BarChartParams;
			}
			set
			{
				this.m_BarChartParams = value;
			}
		}

		public string Title
		{
			get
			{
				return this.m_Title;
			}
			set
			{
				this.m_Title = value;
			}
		}

		public string XAxisName
		{
			get
			{
				return this.m_XAxisName;
			}
			set
			{
				this.m_XAxisName = value;
			}
		}

		public string YAxisName
		{
			get
			{
				return this.m_YAxisName;
			}
			set
			{
				this.m_YAxisName = value;
			}
		}

		public double RangeBoxMin
		{
			get
			{
				return this.m_RangeBoxMin;
			}
			set
			{
				this.m_RangeBoxMin = value;
			}
		}

		public double RangeBoxMax
		{
			get
			{
				return this.m_RangeBoxMax;
			}
			set
			{
				this.m_RangeBoxMax = value;
			}
		}

		public string[] XPointName
		{
			get
			{
				return this.m_XPointName;
			}
			set
			{
				this.m_XPointName = value;
			}
		}

		public bool SetXYRange
		{
			get
			{
				return this.m_SetXYRange;
			}
			set
			{
				this.m_SetXYRange = value;
			}
		}

		public bool LineSmooth
		{
			get
			{
				return this.m_LineSmooth;
			}
			set
			{
				this.m_LineSmooth = value;
			}
		}

		public string BarTextFormat
		{
			get
			{
				return this.m_BarTextFormat;
			}
			set
			{
				this.m_BarTextFormat = value;
			}
		}

		public virtual void LoadParams()
		{
			this.TitleFontFamily = this.m_BarChartParams.TitleFontFamily;
			this.TitleFontColor = this.m_BarChartParams.TitleFontColor;
			this.TitleFontSize = this.m_BarChartParams.TitleFontSize;
			this.AxisFontFamily = this.m_BarChartParams.AxisFontFamily;
			this.AxisFontColor = this.m_BarChartParams.AxisFontColor;
			this.AxisFontSize = this.m_BarChartParams.AxisFontSize;
			this.PaneColor1 = this.m_BarChartParams.PaneColor1;
			this.PaneColor2 = this.m_BarChartParams.PaneColor2;
			this.PaneColorAngle = this.m_BarChartParams.PaneColorAngle;
			this.ChartColor1 = this.m_BarChartParams.ChartColor1;
			this.ChartColor2 = this.m_BarChartParams.ChartColor2;
			this.ChartColorAngle = this.m_BarChartParams.ChartColorAngle;
			this.BarColor1 = this.m_BarChartParams.BarColor1;
			this.BarColor2 = this.m_BarChartParams.BarColor2;
			this.BarColorAngle = this.m_BarChartParams.BarColorAngle;
			this.ShowBarValue = this.m_BarChartParams.ShowBarValue;
			this.BarValueIsCenter = this.m_BarChartParams.BarValueIsCenter;
			this.CurveColor = this.m_BarChartParams.CurveColor;
			this.CurveWidth = this.m_BarChartParams.CurveWidth;
			this.GridColor = this.m_BarChartParams.GridColor;
			this.ShowMajorGridX = this.m_BarChartParams.ShowMajorGridX;
			this.ShowMajorGridY = this.m_BarChartParams.ShowMajorGridY;
			this.ShowMinorGridX = this.m_BarChartParams.ShowMinorGridX;
			this.ShowMinorGridY = this.m_BarChartParams.ShowMinorGridY;
		}

		public virtual void ShowChartData()
		{
		}

		public virtual ZedGraphControl GetGraphControl()
		{
			return null;
		}
	}
}
