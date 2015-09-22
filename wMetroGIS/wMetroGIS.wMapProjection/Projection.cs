using System;
using System.Drawing;

namespace wMetroGIS.wMapProjection
{
	public class Projection
	{
		protected int m_PicWidth;

		protected int m_PicHeight;

		protected float m_Left;

		protected float m_Right;

		protected float m_Bottom;

		protected float m_Top;

		public System.Drawing.PointF centerLonLat;

		public System.Drawing.Point centerXY;

		public double scale;

		public double scaleOriginal;

		public float Left
		{
			get
			{
				return this.m_Left;
			}
		}

		public float Right
		{
			get
			{
				return this.m_Right;
			}
		}

		public float Bottom
		{
			get
			{
				return this.m_Bottom;
			}
		}

		public float Top
		{
			get
			{
				return this.m_Top;
			}
		}

		public virtual System.Drawing.Point LonLat2XY(System.Drawing.PointF LonLat)
		{
			return this.LonLat2XY(LonLat.X, LonLat.Y);
		}

		public virtual System.Drawing.Point LonLat2XY(float Lon, float Lat)
		{
			return System.Drawing.Point.Empty;
		}

		public virtual System.Drawing.PointF XY2LonLat(System.Drawing.Point XY)
		{
			return this.XY2LonLat(XY.X, XY.Y);
		}

		public virtual System.Drawing.PointF XY2LonLat(int X, int Y)
		{
			return System.Drawing.PointF.Empty;
		}

		public virtual double GetAngle(System.Drawing.PointF LonLat)
		{
			return this.GetAngle(LonLat.X, LonLat.Y);
		}

		public virtual double GetAngle(float Lon, float Lat)
		{
			return 0.0;
		}
	}
}
