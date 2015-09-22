using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using wMetroGIS.wCurve;
using wMetroGIS.wDataObject;
using wMetroGIS.wMapMask;
using wMetroGIS.wMapProjection;
using wMetroGIS.wParams;
using wMetroGIS.wStreamline;

namespace wMetroGIS.wLayers
{
	public class wStreamlineLayer : wBaseLayer
	{
		public StreamlineParams m_StreamlineParams = null;

		public CurveManager m_CurveManager = null;

		private GridDataVector m_GridDataVector = null;

		private System.Drawing.RectangleF m_DataRange = System.Drawing.RectangleF.Empty;

		public wStreamlineLayer()
		{
			this.layerName = "流线图层";
			this.layerVisable = true;
		}

		public wStreamlineLayer(string layerName, bool isVisible)
		{
			this.layerName = layerName;
			this.layerVisable = isVisible;
		}

		public bool LoadData(GridDataVector gridDataVector, StreamlineParams streamlineParams)
		{
			Streamline streamline = new Streamline();
			CurveManager curveManager = streamline.CreateStreamlines(gridDataVector, streamlineParams.StreamlineDensity);
			bool result;
			if (curveManager == null)
			{
				result = false;
			}
			else
			{
				this.m_GridDataVector = gridDataVector;
				this.m_DataRange = this.m_GridDataVector.m_DataRange;
				this.m_StreamlineParams = streamlineParams;
				result = true;
			}
			return result;
		}

		public override bool DrawToBitmap(Projection p, ref System.Drawing.Bitmap objBitmap, ref System.Drawing.Bitmap objBitmapFill, ref System.Drawing.Rectangle objRectangle, ref float objBitmapFillAlpha, wBaseMasker objMasker, int edgeLeft = 0, int edgeRight = 0, int edgeBottom = 0, int edgeTop = 0)
		{
			if (objBitmap != null)
			{
				objBitmap.Dispose();
			}
			if (objBitmapFill != null)
			{
				objBitmapFill.Dispose();
			}
			int bitmapWidth = p.centerXY.X * 2;
			int bitmapHeight = p.centerXY.Y * 2;
			objRectangle = new System.Drawing.Rectangle(0, 0, bitmapWidth, bitmapHeight);
			objBitmap = new System.Drawing.Bitmap(bitmapWidth, bitmapHeight);
			System.Drawing.Color transparentColor = System.Drawing.Color.White;
			System.Drawing.Bitmap objBitmapMask = null;
			if (objMasker != null)
			{
				objBitmapMask = objMasker.CreateMasker(objBitmap.Size, p, transparentColor);
			}
			if (objBitmap != null)
			{
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(objBitmap);
				g.Clear(transparentColor);
				this.DrawStreamline(g, p);
				if (objBitmapMask != null)
				{
					g.DrawImage(objBitmapMask, 0, 0);
				}
				g.Dispose();
				objBitmap.MakeTransparent(transparentColor);
			}
			return true;
		}

		private void DrawStreamline(System.Drawing.Graphics g, Projection p)
		{
			if (this.m_CurveManager != null && this.m_StreamlineParams != null)
			{
				int LineWidth = this.m_StreamlineParams.StreamlineWidth;
				System.Drawing.Drawing2D.DashStyle LineStyle = System.Drawing.Drawing2D.DashStyle.Solid;
				this.m_CurveManager.SetDefaultCurveStyle(LineWidth, LineStyle);
				this.m_CurveManager.WantArrow = true;
				this.m_CurveManager.ArrowSplit = 10;
				this.m_CurveManager.ArrowPositiveDir = true;
				this.m_CurveManager.ShowText = false;
				this.m_CurveManager.DrawCurves(g, p);
			}
		}
	}
}
