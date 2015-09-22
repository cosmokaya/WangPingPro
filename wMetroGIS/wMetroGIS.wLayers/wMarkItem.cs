using System;
using System.Drawing;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wLayers
{
	public class wMarkItem
	{
		public string m_myText;

		public System.Drawing.PointF m_myPosition;

		public int m_myTextHeight;

		public bool m_Visible;

		public bool m_ShowPoint;

		public System.Drawing.Color m_myTextColor;

		public System.Drawing.Image m_Image;

		public System.Drawing.Size m_ImageSize;

		public wMarkItem()
		{
			this.m_myText = "";
			this.m_myPosition = System.Drawing.PointF.Empty;
			this.m_myTextHeight = 10;
			this.m_Visible = true;
			this.m_ShowPoint = true;
			this.m_myTextColor = System.Drawing.Color.Red;
			this.m_Image = null;
			this.m_ImageSize = new System.Drawing.Size(32, 32);
		}

		public wMarkItem(System.Drawing.PointF myPosition, string myText, int myTextHeight, System.Drawing.Color myTextColor, System.Drawing.Image myImage, bool ShowPoint, bool Visible)
		{
			this.m_myPosition = myPosition;
			this.m_myText = myText;
			this.m_myTextHeight = myTextHeight;
			this.m_myTextColor = myTextColor;
			this.m_Image = myImage;
			this.m_ShowPoint = ShowPoint;
			this.m_Visible = Visible;
			this.m_ImageSize = new System.Drawing.Size(32, 32);
		}

		public void DrawMe(System.Drawing.Graphics g, Projection p)
		{
			System.Drawing.Point StationPos = p.LonLat2XY(this.m_myPosition.X, this.m_myPosition.Y);
			System.Drawing.Font myFont = new System.Drawing.Font("黑体", (float)this.m_myTextHeight, System.Drawing.FontStyle.Regular);
			if (this.m_ShowPoint)
			{
				if (this.m_Image == null)
				{
					g.FillEllipse(new System.Drawing.SolidBrush(System.Drawing.Color.Orange), StationPos.X - 5, StationPos.Y - 5, 10, 10);
					g.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Red), StationPos.X - 3, StationPos.Y - 3, 6, 6);
					g.DrawString(this.m_myText, myFont, new System.Drawing.SolidBrush(this.m_myTextColor), StationPos);
				}
				else
				{
					System.Drawing.Point imagePoint = new System.Drawing.Point(StationPos.X - this.m_Image.Width / 2, StationPos.Y - this.m_Image.Height / 2);
					System.Drawing.Rectangle imageRectangle = new System.Drawing.Rectangle(StationPos.X - this.m_ImageSize.Width / 2, StationPos.Y - this.m_ImageSize.Height / 2, this.m_ImageSize.Width, this.m_ImageSize.Height);
					g.DrawImage(this.m_Image, imageRectangle, new System.Drawing.Rectangle(0, 0, this.m_Image.Width, this.m_Image.Height), System.Drawing.GraphicsUnit.Pixel);
					g.DrawString(this.m_myText, myFont, new System.Drawing.SolidBrush(this.m_myTextColor), new System.Drawing.Point(StationPos.X - this.m_ImageSize.Width / 4, StationPos.Y - this.m_ImageSize.Height / 4));
				}
			}
			else
			{
				g.DrawString(this.m_myText, myFont, new System.Drawing.SolidBrush(this.m_myTextColor), StationPos);
			}
		}
	}
}
