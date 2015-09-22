using System;
using System.Drawing;

namespace wMetroGIS.wMapProjection
{
	public class ProjectionLambert : Projection
	{
		private System.Drawing.PointF standardLonLat;

		private System.Drawing.Point offset;

		private double F;

		private double n;

		private double p0;

		public ProjectionLambert(double standardLon, double standardLat, double centerLon, double centerLat, int centerX, int centerY, double zoomIndex)
		{
			double lon = System.Math.IEEERemainder(System.Math.Abs(standardLon), 360.0);
			double lat = 0.0;
			this.standardLonLat = new System.Drawing.PointF((float)lon, (float)lat);
			lon = System.Math.IEEERemainder(System.Math.Abs(centerLon), 360.0);
			lat = ((centerLat < -85.0) ? -85.0 : ((centerLat > 85.0) ? 85.0 : centerLat));
			this.centerLonLat = new System.Drawing.PointF((float)lon, (float)lat);
			this.centerXY = new System.Drawing.Point(centerX, centerY);
			this.scale = ((zoomIndex <= 0.0) ? 1.0 : zoomIndex);
			this.scaleOriginal = this.scale;
			double lat2 = 0.52359877559829882;
			double lat3 = 1.0471975511965976;
			double lat4 = 1.0471975511965976;
			double lat5 = 1.3089969389957472;
			double lat6 = (45.0 + (double)this.centerLonLat.Y / 2.0) * 3.1415926535897931 / 180.0;
			double lat7 = (45.0 + (double)this.standardLonLat.Y / 2.0) * 3.1415926535897931 / 180.0;
			this.n = System.Math.Log(System.Math.Cos(lat2) / System.Math.Cos(lat3)) / System.Math.Log(System.Math.Tan(lat5) / System.Math.Tan(lat4));
			this.F = this.scale * 484.96 * System.Math.Cos(lat2) * System.Math.Pow(System.Math.Tan(lat4), this.n) / this.n;
			this.p0 = this.F * System.Math.Pow(1.0 / System.Math.Tan(lat7), this.n);
			double r = this.n * (double)(this.centerLonLat.X - this.standardLonLat.X) * 3.1415926535897931 / 180.0;
			double p = this.F * System.Math.Pow(1.0 / System.Math.Tan(lat6), this.n);
			double x = p * System.Math.Sin(r);
			double y = p * System.Math.Cos(r) - this.p0;
			this.offset = new System.Drawing.Point((int)(0.5 + (double)this.centerXY.X - x), (int)(0.5 + (double)this.centerXY.Y - y));
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
			double lat5 = (45.0 + (double)Lat / 2.0) * 3.1415926535897931 / 180.0;
			double r = this.n * (double)(Lon - this.standardLonLat.X) * 3.1415926535897931 / 180.0;
			double p = this.F * System.Math.Pow(1.0 / System.Math.Tan(lat5), this.n);
			double x = p * System.Math.Sin(r);
			double y = p * System.Math.Cos(r) - this.p0;
			System.Drawing.Point XY = new System.Drawing.Point((int)(0.5 + (double)this.offset.X + x), (int)(0.5 + (double)this.offset.Y + y));
			return XY;
		}

		public override System.Drawing.PointF XY2LonLat(System.Drawing.Point XY)
		{
			return this.XY2LonLat(XY.X, XY.Y);
		}

		public override System.Drawing.PointF XY2LonLat(int X, int Y)
		{
			double lon;
			double lat;
			if ((double)(Y - this.offset.Y) + this.p0 == 0.0)
			{
				lon = (double)this.standardLonLat.X + 45.0 / this.n;
				lat = 2.0 * (System.Math.Atan(1.0 / System.Math.Pow((double)(X - this.offset.X) / this.F, 1.0 / this.n)) * 180.0 / 3.1415926535897931 - 45.0);
			}
			else
			{
				lon = (double)this.standardLonLat.X + System.Math.Atan((double)(X - this.offset.X) / ((double)(Y - this.offset.Y) + this.p0)) * 180.0 / 3.1415926535897931 / this.n;
				double r = this.n * (lon - (double)this.standardLonLat.X) * 3.1415926535897931 / 180.0;
				lat = 2.0 * (System.Math.Atan(1.0 / System.Math.Pow(((double)(Y - this.offset.Y) + this.p0) / System.Math.Cos(r) / this.F, 1.0 / this.n)) * 180.0 / 3.1415926535897931 - 45.0);
			}
			System.Drawing.PointF LonLat = new System.Drawing.PointF((float)lon, (float)lat);
			return LonLat;
		}

		public override double GetAngle(System.Drawing.PointF LonLat)
		{
			return this.GetAngle(LonLat.X, LonLat.Y);
		}

		public override double GetAngle(float Lon, float Lat)
		{
			double result;
			if (9999.0 <= (double)Lat || -9999.0 >= (double)Lat || 90.0 == (double)Lat || -90.0 == (double)Lat)
			{
				result = 0.0;
			}
			else
			{
				System.Drawing.Point xy = this.LonLat2XY(this.standardLonLat.X, 90f);
				System.Drawing.Point xy2 = this.LonLat2XY(Lon, Lat);
				double x = (double)xy.X;
				double y = (double)xy.Y;
				double x2 = (double)xy2.X;
				double y2 = (double)xy2.Y;
				double rotateAngle;
				if (x2 == x)
				{
					rotateAngle = ((y2 >= y) ? 0.0 : 180.0);
				}
				else if (y == y2)
				{
					rotateAngle = ((x2 >= x) ? 270.0 : 90.0);
				}
				else
				{
					double deltaY = System.Math.Abs(y2 - y);
					double r = System.Math.Sqrt((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y));
					double angelDegree = System.Math.Asin(deltaY / r) * 180.0 / 3.1415926535897931;
					if (x2 > x && y2 > y)
					{
						rotateAngle = -90.0 + angelDegree;
					}
					else if (x2 > x && y2 < y)
					{
						rotateAngle = -90.0 - angelDegree;
					}
					else if (x2 < x && y2 < y)
					{
						rotateAngle = 90.0 + angelDegree;
					}
					else
					{
						if (x2 >= x || y2 <= y)
						{
							result = 0.0;
							return result;
						}
						rotateAngle = 90.0 - angelDegree;
					}
				}
				result = rotateAngle;
			}
			return result;
		}
	}
}
