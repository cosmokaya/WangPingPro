using System;
using System.Data;
using System.Drawing;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wLayers
{
	public class wStationItem
	{
		private const int testRadii = 15;

		private System.Drawing.Size sizeIconSmall = new System.Drawing.Size(24, 24);

		private System.Drawing.Size sizeIconLarge = new System.Drawing.Size(32, 32);

		private bool stationSelected = false;

		public System.Drawing.PointF stationPos;

		public string stationName;

		public ushort stationID;

		public ushort stationLevel;

		public DataRow stationData;

		public wStationItem()
		{
			this.stationID = 0;
			this.stationName = "";
			this.stationPos = System.Drawing.PointF.Empty;
			this.stationLevel = 0;
			this.stationData = null;
		}

		public wStationItem(System.Drawing.PointF Pos, ushort ID, string Name, ushort Level, DataRow Data)
		{
			this.stationPos = Pos;
			this.stationID = ID;
			this.stationName = Name;
			this.stationLevel = Level;
			this.stationData = Data;
		}

		public void DrawMe(System.Drawing.Graphics g, Projection p, System.Drawing.Bitmap myIcon)
		{
			System.Drawing.Point myPt = p.LonLat2XY(this.stationPos.X, this.stationPos.Y);
			if (myIcon != null)
			{
				if (this.stationSelected)
				{
					g.DrawImage(myIcon, new System.Drawing.Rectangle(myPt.X - this.sizeIconLarge.Width / 2, myPt.Y - this.sizeIconLarge.Height / 2, this.sizeIconLarge.Width, this.sizeIconLarge.Height), 0, 0, myIcon.Width, myIcon.Height, System.Drawing.GraphicsUnit.Pixel);
				}
				else
				{
					g.DrawImage(myIcon, new System.Drawing.Rectangle(myPt.X - this.sizeIconSmall.Width / 2, myPt.Y - this.sizeIconSmall.Height / 2, this.sizeIconSmall.Width, this.sizeIconSmall.Height), 0, 0, myIcon.Width, myIcon.Height, System.Drawing.GraphicsUnit.Pixel);
				}
			}
			else if (this.stationSelected)
			{
				g.FillEllipse(new System.Drawing.SolidBrush(System.Drawing.Color.Orange), myPt.X - this.sizeIconLarge.Width / 2, myPt.Y - this.sizeIconLarge.Height / 2, this.sizeIconLarge.Width, this.sizeIconLarge.Height);
				g.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Red, 2f), myPt.X - this.sizeIconLarge.Width / 2, myPt.Y - this.sizeIconLarge.Height / 2, this.sizeIconLarge.Width, this.sizeIconLarge.Height);
			}
			else
			{
				g.FillEllipse(new System.Drawing.SolidBrush(System.Drawing.Color.Orange), myPt.X - this.sizeIconSmall.Width / 2, myPt.Y - this.sizeIconSmall.Height / 2, this.sizeIconSmall.Width, this.sizeIconSmall.Height);
				g.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Red, 2f), myPt.X - this.sizeIconSmall.Width / 2, myPt.Y - this.sizeIconSmall.Height / 2, this.sizeIconSmall.Width, this.sizeIconSmall.Height);
			}
			System.Drawing.Font stationFont = new System.Drawing.Font("黑体", 11f, System.Drawing.FontStyle.Bold);
			g.DrawString(this.stationName, stationFont, new System.Drawing.SolidBrush(System.Drawing.Color.Black), (float)(myPt.X + 1), (float)(myPt.Y + 1));
			if (this.stationSelected)
			{
				g.DrawString(this.stationName, stationFont, new System.Drawing.SolidBrush(System.Drawing.Color.Red), (float)myPt.X, (float)myPt.Y);
			}
			else
			{
				g.DrawString(this.stationName, stationFont, new System.Drawing.SolidBrush(System.Drawing.Color.Yellow), (float)myPt.X, (float)myPt.Y);
			}
		}

		public bool SelectMe(System.Drawing.PointF testPos, Projection mapPrj)
		{
			System.Drawing.PointF p = mapPrj.XY2LonLat(0, 0);
			double tmpRadii = (double)System.Math.Abs(mapPrj.XY2LonLat(0, 15).Y - p.Y);
			double dis = System.Math.Sqrt((double)((testPos.X - this.stationPos.X) * (testPos.X - this.stationPos.X) + (testPos.Y - this.stationPos.Y) * (testPos.Y - this.stationPos.Y)));
			this.stationSelected = (dis <= tmpRadii);
			return this.stationSelected;
		}
	}
}
