using System;
using System.Drawing;
using System.Drawing.Imaging;
using wMetroGIS.wMapMask;
using wMetroGIS.wMapPictureBoxControl;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wLayers
{
	public class wBaseLayer
	{
		public string layerName;

		public bool layerVisable;

		public bool layerIsDrawed = false;

		public string layerColorBarName = "";

		public bool layerShowColorBarTextOnCenter = false;

		public bool layerShowProgress = false;

		protected System.Drawing.Bitmap layerBitmap = null;

		protected System.Drawing.Bitmap layerBitmapMask = null;

		protected System.Drawing.Bitmap layerBitmapFill = null;

		protected System.Drawing.Rectangle layerRectangle = System.Drawing.Rectangle.Empty;

		protected float layerBitmapFillAlpha = 0f;

		public wBaseLayer()
		{
			this.layerName = "";
			this.layerVisable = true;
		}

		public wBaseLayer(string Name, bool Visable, System.Drawing.Region Masker)
		{
			this.layerName = Name;
			this.layerVisable = Visable;
		}

		public virtual void Draw(System.Drawing.Graphics g, Projection p)
		{
			if (!this.layerVisable)
			{
			}
		}

		public virtual bool SetupLayer()
		{
			return true;
		}

		public virtual bool DrawToBitmap(Projection p, ref System.Drawing.Bitmap objBitmap, ref System.Drawing.Bitmap objBitmapFill, ref System.Drawing.Rectangle objRectangle, ref float objBitmapFillAlpha, wBaseMasker objMasker, int edgeLeft = 0, int edgeRight = 0, int edgeBottom = 0, int edgeTop = 0)
		{
			return true;
		}

		public virtual bool DrawToMapPictureBox(wMapPictureBox mapPictureBox, wBaseMasker mapMasker, bool WantRedrawMap = true, bool WantRedrawColorBar = true)
		{
			bool result;
			if (!this.layerIsDrawed)
			{
				if (!this.DrawToBitmap(mapPictureBox.GetMapProjection(), ref this.layerBitmap, ref this.layerBitmapFill, ref this.layerRectangle, ref this.layerBitmapFillAlpha, mapMasker, mapPictureBox.GetMapParams().m_EdgeLeft, mapPictureBox.GetMapParams().m_EdgeRight, mapPictureBox.GetMapParams().m_EdgeBottom, mapPictureBox.GetMapParams().m_EdgeTop))
				{
					result = false;
					return result;
				}
				this.layerIsDrawed = true;
			}
			if (WantRedrawMap)
			{
				mapPictureBox.DrawMap();
			}
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(mapPictureBox.GetPictureBox().Image);
			if (this.layerBitmapFill != null)
			{
				System.Drawing.Imaging.ImageAttributes im = new System.Drawing.Imaging.ImageAttributes();
				im.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix
				{
					Matrix00 = 1f,
					Matrix11 = 1f,
					Matrix22 = 1f,
					Matrix33 = System.Convert.ToSingle(this.layerBitmapFillAlpha / 255f),
					Matrix44 = 1f
				});
				g.DrawImage(this.layerBitmapFill, this.layerRectangle, 0, 0, this.layerBitmapFill.Width, this.layerBitmapFill.Height, System.Drawing.GraphicsUnit.Pixel, im);
			}
			if (this.layerBitmap != null)
			{
				g.DrawImage(this.layerBitmap, this.layerRectangle.Location);
			}
			mapPictureBox.DrawEdgeRect(g);
			mapPictureBox.DrawLonLatText(g);
			if (this.NeedDrawColorBar())
			{
				this.DrawColorBar(mapPictureBox, g, WantRedrawColorBar);
			}
			g.Dispose();
			result = true;
			return result;
		}

		public virtual bool NeedDrawColorBar()
		{
			return false;
		}

		public virtual void DrawColorBar(wMapPictureBox mapPictureBox, System.Drawing.Graphics g, bool RedrawColorBar = true)
		{
		}
	}
}
