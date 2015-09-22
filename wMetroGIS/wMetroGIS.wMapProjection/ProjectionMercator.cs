using System;
using System.Drawing;

namespace wMetroGIS.wMapProjection
{
	public class ProjectionMercator : Projection
	{
		private System.Drawing.PointF scaleXY;

		public ProjectionMercator(double centerLon, double centerLat, int centerX, int centerY, double zoomIndex)
		{
			this.centerLonLat = new System.Drawing.PointF((float)centerLon, (float)centerLat);
			this.centerXY = new System.Drawing.Point(centerX, centerY);
			this.scale = ((zoomIndex <= 0.0) ? 1.0 : zoomIndex);
			this.scaleOriginal = this.scale;
			this.scaleXY = new System.Drawing.PointF(7.25f, 433f);
		}

		public override System.Drawing.Point LonLat2XY(System.Drawing.PointF LonLat)
		{
			return this.LonLat2XY(LonLat.X, LonLat.Y);
		}

		public override System.Drawing.Point LonLat2XY(float Lon, float Lat)
		{
			if (Lat > 90f)
			{
				Lat = 90f;
			}
			else if (Lat < -90f)
			{
				Lat = -90f;
			}
			double x = this.scale * (double)this.scaleXY.X * (double)(Lon - this.centerLonLat.X) + (double)this.centerXY.X;
			double centerLat = (double)this.centerLonLat.Y * 3.1415926535897931 / 180.0;
			double thisLat = (double)Lat * 3.1415926535897931 / 180.0;
			double y = System.Math.Log(System.Math.Tan(centerLat) + 1.0 / System.Math.Cos(centerLat));
			double y2 = System.Math.Log(System.Math.Tan(thisLat) + 1.0 / System.Math.Cos(thisLat));
			double y3 = this.scale * (double)this.scaleXY.Y * (y - y2) + (double)this.centerXY.Y;
			System.Drawing.Point XY = new System.Drawing.Point((int)(x + 0.5), (int)(y3 + 0.5));
			return XY;
		}

		public override System.Drawing.PointF XY2LonLat(System.Drawing.Point XY)
		{
			return this.XY2LonLat(XY.X, XY.Y);
		}

		public override System.Drawing.PointF XY2LonLat(int X, int Y)
		{
			double centerLat = (double)this.centerLonLat.Y * 3.1415926535897931 / 180.0;
			double y = System.Math.Log(System.Math.Tan(centerLat) + 1.0 / System.Math.Cos(centerLat));
			double y2 = y - (double)(Y - this.centerXY.Y) / this.scale / (double)this.scaleXY.Y;
			double lon = (double)(X - this.centerXY.X) / this.scale / (double)this.scaleXY.X + (double)this.centerXY.X;
			double lat = System.Math.Asin((System.Math.Exp(y2) * System.Math.Exp(y2) - 1.0) / (System.Math.Exp(y2) * System.Math.Exp(y2) + 1.0)) * 180.0 / 3.1415926535897931;
			System.Drawing.PointF LonLat = new System.Drawing.PointF((float)lon, (float)lat);
			return LonLat;
		}
	}
}
