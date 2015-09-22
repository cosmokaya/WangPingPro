using System;
using System.Drawing;
using wMetroGIS.wMapMask;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wLayers
{
	public class wImageLayer : wBaseLayer
	{
		private System.Drawing.Bitmap m_Image = null;

		private System.Drawing.RectangleF m_ImageRange = System.Drawing.RectangleF.Empty;

		public wImageLayer()
		{
			this.layerName = "图像图层";
			this.layerVisable = true;
			this.layerColorBarName = "";
		}

		public wImageLayer(string layerName, bool isVisible)
		{
			this.layerName = layerName;
			this.layerVisable = isVisible;
			this.layerColorBarName = "";
		}

		public bool LoadData(string imagePath, System.Drawing.RectangleF imageRange)
		{
			System.Drawing.Bitmap image = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(imagePath);
			return this.LoadData(image, imageRange);
		}

		public bool LoadData(System.Drawing.Bitmap image, System.Drawing.RectangleF imageRange)
		{
			this.m_ImageRange = imageRange;
			this.m_Image = image;
			return true;
		}

		public override bool DrawToBitmap(Projection p, ref System.Drawing.Bitmap objBitmap, ref System.Drawing.Bitmap objBitmapFill, ref System.Drawing.Rectangle objRectangle, ref float objBitmapFillAlpha, wBaseMasker objMasker, int edgeLeft = 0, int edgeRight = 0, int edgeBottom = 0, int edgeTop = 0)
		{
			if (objBitmap != null)
			{
				objBitmap.Dispose();
				objBitmap = null;
			}
			if (objBitmapFill != null)
			{
				objBitmapFill.Dispose();
				objBitmapFill = null;
			}
			System.Drawing.Color transparentColor = System.Drawing.Color.White;
			System.Drawing.Bitmap objBitmapMask = null;
			if (objMasker != null)
			{
				objBitmapMask = objMasker.CreateMasker(objBitmapFill.Size, p, transparentColor);
			}
			if (objBitmapFill != null)
			{
				System.Drawing.Point pt = p.LonLat2XY(this.m_ImageRange.Left, this.m_ImageRange.Bottom);
				System.Drawing.Point pt2 = p.LonLat2XY(this.m_ImageRange.Right, this.m_ImageRange.Top);
				System.Drawing.Rectangle desRect = new System.Drawing.Rectangle(pt.X, pt.Y, pt2.X - pt.X, pt2.Y - pt.Y);
				System.Drawing.Rectangle srcRect = new System.Drawing.Rectangle(0, 0, this.m_Image.Width, this.m_Image.Height);
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(objBitmapFill);
				g.Clear(transparentColor);
				g.DrawImage(this.m_Image, desRect, srcRect, System.Drawing.GraphicsUnit.Pixel);
				if (objBitmapMask != null)
				{
					g.DrawImage(objBitmapMask, 0, 0);
				}
				g.Dispose();
				objBitmapFill.MakeTransparent(transparentColor);
				objBitmapFillAlpha = 200f;
			}
			return true;
		}
	}
}
