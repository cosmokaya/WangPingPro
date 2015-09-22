using System;
using System.Drawing;

namespace wMetroGIS.wMapProjection
{
	public class ProjectionStereogram : Projection
	{
		private static double RADIUS = 6371.004;

		private static double RADIUS_POLAR = 6356.755;

		private static double RADIUS_EQUATOR = 6373.14;

		private System.Drawing.PointF standardLonLat;

		private System.Drawing.Point offset;

		public ProjectionStereogram(double standardLon, double standardLat, double centerLon, double centerLat, int centerX, int centerY, double zoomIndex)
		{
			double lon = System.Math.IEEERemainder(System.Math.Abs(standardLon), 360.0);
			this.standardLonLat = new System.Drawing.PointF((float)lon, (float)standardLat);
			lon = System.Math.IEEERemainder(System.Math.Abs(centerLon), 360.0);
			double lat;
			if (standardLat == 90.0)
			{
				lat = ((centerLat < -85.0) ? -85.0 : ((centerLat > 90.0) ? 90.0 : centerLat));
			}
			else
			{
				lat = ((centerLat < 85.0) ? 85.0 : ((centerLat > -90.0) ? -90.0 : centerLat));
			}
			this.centerLonLat = new System.Drawing.PointF((float)lon, (float)lat);
			this.centerXY = new System.Drawing.Point(centerX, centerY);
			this.scale = ((zoomIndex <= 0.0) ? 1.0 : zoomIndex);
			this.scaleOriginal = this.scale;
			double _lon0 = standardLon * 3.1415926535897931 / 180.0;
			double _lat0 = standardLat * 3.1415926535897931 / 180.0;
			double _lon = centerLon * 3.1415926535897931 / 180.0;
			double _lat = centerLat * 3.1415926535897931 / 180.0;
			double i = this.scale * 0.04149 * 2.0 * ProjectionStereogram.RADIUS / (1.0 + System.Math.Sin(_lat0) * System.Math.Sin(_lat) + System.Math.Cos(_lat0) * System.Math.Cos(_lat) * System.Math.Cos(_lon - _lon0));
			double x0 = i * System.Math.Cos(_lat) * System.Math.Sin(_lon - _lon0);
			double y0 = i * (System.Math.Cos(_lat0) * System.Math.Sin(_lat) - System.Math.Sin(_lat0) * System.Math.Cos(_lat) * System.Math.Cos(_lon - _lon0));
			this.offset = new System.Drawing.Point((int)(0.5 + (double)centerX + x0), (int)(0.5 + (double)centerY + y0));
		}

		public override System.Drawing.Point LonLat2XY(System.Drawing.PointF LonLat)
		{
			return this.LonLat2XY(LonLat.X, LonLat.Y);
		}

		public override System.Drawing.Point LonLat2XY(float Lon, float Lat)
		{
			double deltaLon = (double)(Lon - this.standardLonLat.X) * 3.1415926535897931 / 180.0;
			double radianLat = (double)Lat * 3.1415926535897931 / 180.0;
			double sgn = ((double)this.standardLonLat.Y == 90.0) ? 1.0 : -1.0;
			double i = this.scale * 0.04149 * 2.0 * ProjectionStereogram.RADIUS / (1.0 + sgn * System.Math.Sin(radianLat));
			double x = i * System.Math.Cos(radianLat) * System.Math.Sin(deltaLon);
			double y = i * (-sgn * System.Math.Cos(radianLat) * System.Math.Cos(deltaLon));
			return new System.Drawing.Point((int)(0.5 + (double)this.offset.X + x), (int)(0.5 + (double)this.offset.Y - y));
		}

		public override System.Drawing.PointF XY2LonLat(System.Drawing.Point XY)
		{
			return this.XY2LonLat(XY.X, XY.Y);
		}

		public override System.Drawing.PointF XY2LonLat(int X, int Y)
		{
			System.Drawing.Point p0 = this.LonLat2XY(0f, this.standardLonLat.Y);
			System.Drawing.PointF result;
			if (p0.X == X && p0.Y == Y)
			{
				result = new System.Drawing.PointF(0f, this.standardLonLat.Y);
			}
			else
			{
				System.Drawing.Point p = this.LonLat2XY(0f, 0f);
				if (p.X == X && p.Y == Y)
				{
					result = new System.Drawing.PointF(0f, 0f);
				}
				else
				{
					double x = (double)p0.X;
					double y = (double)p0.Y;
					double x2 = (double)p.X;
					double y2 = (double)p.Y;
					double x3 = (double)X;
					double y3 = (double)Y;
					double x3_x2 = x3 - x2;
					double y3_y2 = y3 - y2;
					double aa = x3_x2 * x3_x2 + y3_y2 * y3_y2;
					double x3_x3 = x3 - x;
					double y3_y3 = y3 - y;
					double bb = x3_x3 * x3_x3 + y3_y3 * y3_y3;
					double b = System.Math.Sqrt(bb);
					double x1_x2 = x - x2;
					double y1_y2 = y - y2;
					double cc = x1_x2 * x1_x2 + y1_y2 * y1_y2;
					double c = System.Math.Sqrt(cc);
					double angle = System.Math.Acos((bb + cc - aa) / (2.0 * b * c));
					double lon = angle * 180.0 / 3.1415926535897931;
					double deltaLon = (lon - (double)this.standardLonLat.X) * 3.1415926535897931 / 180.0;
					double sgn = ((double)this.standardLonLat.Y == 90.0) ? 1.0 : -1.0;
					double i = (double)(this.offset.Y - Y) / (-sgn * this.scale * 0.04149 * 2.0 * ProjectionStereogram.RADIUS * System.Math.Cos(deltaLon));
					double lat = System.Math.Asin((1.0 - sgn * i * i) / (1.0 + i * i)) * 180.0 / 3.1415926535897931;
					result = new System.Drawing.PointF((float)lon, (float)lat);
				}
			}
			return result;
		}

		public override double GetAngle(System.Drawing.PointF LonLat)
		{
			return this.GetAngle(LonLat.X, LonLat.Y);
		}

		public override double GetAngle(float Lon, float Lat)
		{
			double agl;
			for (agl = 360.0 + (double)this.standardLonLat.X - (double)Lon; agl >= 360.0; agl -= 360.0)
			{
			}
			while (agl <= -360.0)
			{
				agl += 360.0;
			}
			return agl;
		}
	}
}
