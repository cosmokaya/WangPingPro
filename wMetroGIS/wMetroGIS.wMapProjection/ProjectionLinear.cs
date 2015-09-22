using System;
using System.Drawing;

namespace wMetroGIS.wMapProjection
{
	public class ProjectionLinear : Projection
	{
		private double WHScale;

		public ProjectionLinear(double centerLon, double centerLat, int centerX, int centerY, double whScale, double zoomIndex)
		{
			this.centerLonLat = new System.Drawing.PointF((float)centerLon, (float)centerLat);
			this.centerXY = new System.Drawing.Point(centerX, centerY);
			this.scale = ((zoomIndex <= 0.0) ? 1.0 : zoomIndex);
			this.scaleOriginal = this.scale;
			this.WHScale = whScale;
		}

		public override System.Drawing.Point LonLat2XY(System.Drawing.PointF LonLat)
		{
			return this.LonLat2XY(LonLat.X, LonLat.Y);
		}

		public override System.Drawing.Point LonLat2XY(float Lon, float Lat)
		{
			int X = System.Convert.ToInt32((double)this.centerXY.X - (double)(this.centerLonLat.X - Lon) * this.scale * this.WHScale);
			int Y = System.Convert.ToInt32((double)this.centerXY.Y - (double)(Lat - this.centerLonLat.Y) * this.scale);
			return new System.Drawing.Point(X, Y);
		}

		public override System.Drawing.PointF XY2LonLat(System.Drawing.Point XY)
		{
			return this.XY2LonLat(XY.X, XY.Y);
		}

		public override System.Drawing.PointF XY2LonLat(int X, int Y)
		{
			float Lon = System.Convert.ToSingle((double)this.centerLonLat.X - (double)(this.centerXY.X - X) / (this.scale * this.WHScale));
			float Lat = System.Convert.ToSingle((double)this.centerLonLat.Y + (double)(this.centerXY.Y - Y) / this.scale);
			return new System.Drawing.PointF(Lon, Lat);
		}
	}
}
