using System;
using System.Collections.Generic;
using System.Drawing;
using wMetroGIS.wContour;
using wMetroGIS.wCurve;
using wMetroGIS.wDataObject;
using wMetroGIS.wMapMask;
using wMetroGIS.wMapPictureBoxControl;
using wMetroGIS.wMapProjection;
using wMetroGIS.wParams;
using wMetroGIS.wTriangulation;

namespace wMetroGIS.wLayers
{
	public class wRegionLayer : wBaseLayer
	{
		public RegionParams m_RegionParams;

		public CurveManager m_CurveManager;

		private VertexManager m_VertexManager;

		private ContourManager m_ContourManager;

		private System.Collections.Generic.List<Triangle> m_TriangleList;

		private System.Drawing.RectangleF m_DataRange;

		public wRegionLayer()
		{
			this.layerName = "区域图层";
			this.layerVisable = true;
			this.layerColorBarName = "区域颜色图例";
		}

		public wRegionLayer(string layerName, bool isVisible)
		{
			this.layerName = layerName;
			this.layerVisable = isVisible;
			this.layerColorBarName = "区域颜色图例";
		}

		public override void Draw(System.Drawing.Graphics g, Projection p)
		{
			if (this.m_RegionParams.RegionWantFill)
			{
				this.m_CurveManager.FillRegion(g, p);
			}
			this.m_CurveManager.DrawRegionText(g, p);
			if (this.m_RegionParams.RegionWantVertex || this.m_RegionParams.RegionWantTriangle)
			{
				this.m_ContourManager.DrawVertexAndTriangle(g, p, this.m_RegionParams.RegionWantVertex, this.m_RegionParams.RegionWantTriangle);
			}
		}

		public bool LoadData(GridDataScalar gds, RegionParams regionParams)
		{
			System.Collections.Generic.List<System.Drawing.PointF> pts = new System.Collections.Generic.List<System.Drawing.PointF>();
			System.Collections.Generic.List<float> vals = new System.Collections.Generic.List<float>();
			int GridStep = 1;
			int RowNum = gds.m_GridSize.Height / GridStep;
			int ColNum = gds.m_GridSize.Width / GridStep;
			int VertexNum = 1500;
			System.Random rad = new System.Random(100);
			for (int i = 0; i < VertexNum; i++)
			{
				float thisLon = gds.m_DataRange.Left + System.Convert.ToSingle((double)(gds.m_DataRange.Right - gds.m_DataRange.Left) * rad.NextDouble());
				float thisLat = gds.m_DataRange.Top + System.Convert.ToSingle((double)(gds.m_DataRange.Bottom - gds.m_DataRange.Top) * rad.NextDouble());
				int thisJ = System.Convert.ToInt32(((double)thisLon - gds.m_MinLon) / gds.m_LonLatStep);
				int thisI = System.Convert.ToInt32(((double)thisLat - gds.m_MinLat) / gds.m_LonLatStep);
				System.Collections.Generic.List<float> thisV = new System.Collections.Generic.List<float>();
				System.Collections.Generic.List<float> thisD = new System.Collections.Generic.List<float>();
				for (int j = 0; j < 4; j++)
				{
					int nowI = thisI;
					int nowJ = thisJ;
					if (j == 1)
					{
						nowI++;
					}
					else if (j == 2)
					{
						nowJ++;
					}
					else if (j == 3)
					{
						nowI++;
						nowJ++;
					}
					float nowVal = (float)gds.GetData(nowI, nowJ);
					System.Drawing.PointF nowPos = gds.GetDataLonLat(nowI, nowJ);
					float nowDis = System.Convert.ToSingle((nowPos.X - thisLon) * (nowPos.X - thisLon) + (nowPos.Y - thisLat) * (nowPos.Y - thisLat));
					bool Found = false;
					for (int k = 0; k < thisV.Count; k++)
					{
						if (thisV[k] == nowVal)
						{
							System.Collections.Generic.List<float> list;
							int index;
							(list = thisD)[index = k] = list[index] + nowDis;
							Found = true;
							break;
						}
					}
					if (!Found)
					{
						thisV.Add(nowVal);
						thisD.Add(nowDis);
					}
				}
				float MinD = thisD[0];
				float MinV = thisV[0];
				for (int j = 0; j < thisV.Count; j++)
				{
					if (thisD[j] < MinD)
					{
						MinD = thisD[j];
						MinV = thisV[j];
					}
				}
				pts.Add(new System.Drawing.PointF(thisLon, thisLat));
				vals.Add(MinV);
			}
			return this.LoadData(pts, vals, regionParams, true);
		}

		public bool LoadData(System.Collections.Generic.List<System.Drawing.PointF> LonLatArray, System.Collections.Generic.List<float> ValueArray, RegionParams regionParams, bool UseBoundBox)
		{
			return this.LoadData(LonLatArray.ToArray(), ValueArray.ToArray(), regionParams, UseBoundBox);
		}

		public bool LoadData(System.Drawing.PointF[] LonLatArray, float[] ValueArray, RegionParams regionParams, bool UseBoundBox)
		{
			bool result;
			if (LonLatArray.Length != ValueArray.Length || LonLatArray.Length <= 3)
			{
				result = false;
			}
			else
			{
				this.m_RegionParams = regionParams;
				if (this.m_RegionParams == null)
				{
					this.m_RegionParams = new RegionParams();
					if (!this.m_RegionParams.LoadParams())
					{
						result = false;
						return result;
					}
				}
				System.Collections.Generic.List<VertexWithValue> vertexList = new System.Collections.Generic.List<VertexWithValue>(LonLatArray.Length);
				float MinValue = 999f;
				float MaxValue = -999f;
				for (int i = 0; i < LonLatArray.Length; i++)
				{
					System.Drawing.PointF LonLat = LonLatArray[i];
					VertexWithValue newVertex = new VertexWithValue(LonLat.X, LonLat.Y);
					float Val = ValueArray[i];
					newVertex.m_VertexValue = Val;
					if (Val != -999f)
					{
						newVertex.m_VertexValue = Val;
						if (newVertex.m_VertexValue > MaxValue)
						{
							MaxValue = newVertex.m_VertexValue;
						}
						if (newVertex.m_VertexValue < MinValue)
						{
							MinValue = newVertex.m_VertexValue;
						}
					}
					vertexList.Add(newVertex);
				}
				float MinX = vertexList[0].X;
				float MaxX = vertexList[0].X;
				float MinY = vertexList[0].Y;
				float MaxY = vertexList[0].Y;
				for (int i = 1; i < LonLatArray.Length; i++)
				{
					if (vertexList[i].X < MinX)
					{
						MinX = vertexList[i].X;
					}
					else if (vertexList[i].X > MaxX)
					{
						MaxX = vertexList[i].X;
					}
					if (vertexList[i].Y < MinY)
					{
						MinY = vertexList[i].Y;
					}
					else if (vertexList[i].Y > MaxY)
					{
						MaxY = vertexList[i].Y;
					}
				}
				this.m_DataRange = new System.Drawing.RectangleF(MinX, MinY, MaxX - MinX, MaxY - MinY);
				if (UseBoundBox)
				{
					int block = 5;
					float range = MaxX - MinX;
					for (int i = 0; i <= block; i++)
					{
						vertexList.Add(new VertexWithValue(MinX - range + (float)i * (MaxX - MinX + 2f * range) / (float)block, MinY - range)
						{
							m_VertexValue = MinValue - MinValue / 10f
						});
					}
					for (int i = 0; i <= block; i++)
					{
						vertexList.Add(new VertexWithValue(MinX - range + (float)i * (MaxX - MinX + 2f * range) / (float)block, MaxY + range)
						{
							m_VertexValue = MinValue - MinValue / 10f
						});
					}
					for (int i = 1; i < block; i++)
					{
						vertexList.Add(new VertexWithValue(MinX - range, MinY - range + (float)i * (MaxY - MinY + 2f * range) / (float)block)
						{
							m_VertexValue = MinValue - MinValue / 10f
						});
					}
					for (int i = 1; i < block; i++)
					{
						vertexList.Add(new VertexWithValue(MaxX + range, MinY - range + (float)i * (MaxY - MinY + 2f * range) / (float)block)
						{
							m_VertexValue = MinValue - MinValue / 10f
						});
					}
				}
				this.m_TriangleList = new System.Collections.Generic.List<Triangle>(vertexList.Count / 2);
				Triangulation tri = new Triangulation();
				tri.TriangulateOld(vertexList, this.m_TriangleList);
				this.m_VertexManager = tri.GetVertexManager();
				this.m_ContourManager = new ContourManager();
				this.m_ContourManager.SetParams(this.m_VertexManager, this.m_TriangleList);
				result = this.CreateCurveManager();
			}
			return result;
		}

		public bool LoadData(ContourManager contourManager, RegionParams regionParams)
		{
			bool result;
			if (contourManager == null || regionParams == null)
			{
				result = false;
			}
			else
			{
				this.m_ContourManager = contourManager;
				this.m_RegionParams = regionParams;
				this.m_DataRange = new System.Drawing.RectangleF(contourManager.m_MinLon, contourManager.m_MinLat, contourManager.m_MaxLon - contourManager.m_MinLon, contourManager.m_MaxLat - contourManager.m_MinLat);
				result = this.CreateCurveManager();
			}
			return result;
		}

		private bool CreateCurveManager()
		{
			this.m_CurveManager = this.m_ContourManager.CreateRegions(this.m_RegionParams.m_RegionLineColorManager, this.m_RegionParams.m_RegionFillColorManager, this.m_RegionParams.RegionWantSPL);
			bool result;
			if (this.m_CurveManager == null)
			{
				this.m_TriangleList = null;
				this.m_VertexManager = null;
				result = false;
			}
			else
			{
				this.m_CurveManager.WantFill = this.m_RegionParams.RegionWantFill;
				this.m_CurveManager.FillAlpha = this.m_RegionParams.RegionFillAlpha;
				this.m_CurveManager.ShowText = this.m_RegionParams.RegionShowRegionText;
				this.m_CurveManager.SetDefaultCurveStyle(this.m_RegionParams.RegionLineWidth, this.m_RegionParams.RegionLineStyle);
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
			float thisLeft = (p.Left > this.m_DataRange.Left) ? p.Left : this.m_DataRange.Left;
			float thisRight = (p.Right < this.m_DataRange.Right) ? p.Right : this.m_DataRange.Right;
			float thisBottom = (p.Bottom > this.m_DataRange.Top) ? p.Bottom : this.m_DataRange.Top;
			float thisTop = (p.Top < this.m_DataRange.Bottom) ? p.Top : this.m_DataRange.Bottom;
			System.Drawing.Point LeftTop = p.LonLat2XY(thisLeft, thisTop);
			System.Drawing.Point RightBottom = p.LonLat2XY(thisRight, thisBottom);
			objRectangle = new System.Drawing.Rectangle(LeftTop, new System.Drawing.Size(RightBottom.X - LeftTop.X, RightBottom.Y - LeftTop.Y));
			objBitmap = new System.Drawing.Bitmap(RightBottom.X - LeftTop.X, RightBottom.Y - LeftTop.Y);
			objBitmapFill = new System.Drawing.Bitmap(RightBottom.X - LeftTop.X, RightBottom.Y - LeftTop.Y);
			objBitmapFillAlpha = (float)this.m_RegionParams.RegionFillAlpha;
			System.Drawing.Color transparentColor = System.Drawing.Color.White;
			System.Drawing.Bitmap objBitmapMask = null;
			if (objMasker != null)
			{
				objBitmapMask = objMasker.CreateMasker(objBitmap.Size, p, transparentColor);
			}
			if (objBitmapFill != null)
			{
				this.m_RegionParams.RegionWantFill = true;
				this.m_CurveManager.FillAlpha = 255;
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(objBitmapFill);
				g.Clear(transparentColor);
				this.Draw(g, p);
				if (objBitmapMask != null)
				{
					g.DrawImage(objBitmapMask, 0, 0);
				}
				g.Dispose();
				this.m_CurveManager.FillAlpha = (int)objBitmapFillAlpha;
				objBitmapFill.MakeTransparent(transparentColor);
			}
			if (objBitmap != null)
			{
				this.m_RegionParams.RegionWantFill = false;
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(objBitmap);
				g.Clear(transparentColor);
				this.Draw(g, p);
				if (objBitmapMask != null)
				{
					g.DrawImage(objBitmapMask, 0, 0);
				}
				g.Dispose();
				objBitmap.MakeTransparent(transparentColor);
			}
			return true;
		}

		public override bool NeedDrawColorBar()
		{
			return true;
		}

		public override void DrawColorBar(wMapPictureBox mapPictureBox, System.Drawing.Graphics g, bool RedrawColorBar = true)
		{
			if (!this.layerShowColorBarTextOnCenter)
			{
				mapPictureBox.DrawColorBar(RedrawColorBar, this.layerColorBarName, this.m_CurveManager.m_ColorManagerCurve, this.m_CurveManager.m_ColorManagerFill);
			}
			else
			{
				mapPictureBox.DrawVectorColor(RedrawColorBar, this.layerColorBarName, this.m_CurveManager.m_ColorManagerCurve, this.m_CurveManager.m_ColorManagerFill);
			}
		}
	}
}
