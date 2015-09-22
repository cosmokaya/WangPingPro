using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace wMetroGIS.wColorManager
{
	public class ColorItem
	{
		private System.Drawing.Color m_Color = System.Drawing.Color.Black;

		private float m_Value = 0f;

		private string m_ValueText = "0";

		private string m_ValueTextFormat = "0";

		private string m_ValueUnit = "";

		private System.Drawing.Drawing2D.DashStyle m_DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;

		private int m_LineWidth = 1;

		public System.Drawing.Color myColor
		{
			get
			{
				return this.m_Color;
			}
			set
			{
				this.m_Color = value;
			}
		}

		public float myValue
		{
			get
			{
				return this.m_Value;
			}
			set
			{
				this.m_Value = value;
			}
		}

		public string myValueText
		{
			get
			{
				return this.m_ValueText;
			}
			set
			{
				this.m_ValueText = value;
			}
		}

		public string myValueTextFormat
		{
			get
			{
				return this.m_ValueTextFormat;
			}
			set
			{
				this.m_ValueTextFormat = value;
			}
		}

		public string myValueUnit
		{
			get
			{
				return this.m_ValueUnit;
			}
			set
			{
				this.m_ValueUnit = value;
			}
		}

		public System.Drawing.Drawing2D.DashStyle myDashStyle
		{
			get
			{
				return this.m_DashStyle;
			}
			set
			{
				this.m_DashStyle = value;
			}
		}

		public int myLineWidth
		{
			get
			{
				return this.m_LineWidth;
			}
			set
			{
				this.m_LineWidth = value;
			}
		}

		public ColorItem()
		{
			this.m_Color = System.Drawing.Color.White;
			this.m_Value = 0f;
			this.m_ValueText = "";
		}

		public ColorItem(System.Drawing.Color c, float v)
		{
			this.m_Color = c;
			this.m_Value = v;
			this.m_ValueText = v.ToString("F2");
		}

		public ColorItem(System.Drawing.Color c, float v, string t)
		{
			this.m_Color = c;
			this.m_Value = v;
			this.m_ValueText = t;
		}

		public ColorItem(System.Drawing.Color c, float v, string t, string f)
		{
			this.m_Color = c;
			this.m_Value = v;
			this.m_ValueText = t;
			this.m_ValueTextFormat = f;
		}

		public ColorItem(System.Drawing.Color c, float v, string t, string f, string u)
		{
			this.m_Color = c;
			this.m_Value = v;
			this.m_ValueText = t;
			this.m_ValueTextFormat = f;
			this.m_ValueUnit = u;
		}

		public ColorItem(System.Drawing.Color c, float v, string t, string f, string u, System.Drawing.Drawing2D.DashStyle s, int w)
		{
			this.m_Color = c;
			this.m_Value = v;
			this.m_ValueText = t;
			this.m_ValueTextFormat = f;
			this.m_ValueUnit = u;
			this.m_DashStyle = s;
			this.m_LineWidth = w;
		}
	}
}
