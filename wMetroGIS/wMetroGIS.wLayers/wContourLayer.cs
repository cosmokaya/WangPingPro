using System;
using System.Collections.Generic;
using System.Drawing;
using wMetroGIS.wColorManager;
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
	public class wContourLayer : wBaseLayer
	{
		public ContourParams m_ContourParams;

		public CurveManager m_CurveManager;

		public VertexManager m_VertexManager;

		public ContourManager m_ContourManager;

		private System.Collections.Generic.List<Triangle> m_TriangleList;

		private System.Drawing.RectangleF m_DataRange;

		private float m_MinValue = 3.40282347E+38f;

		private float m_MaxValue = -3.40282347E+38f;

		public wContourLayer()
		{
			this.layerName = "等值线图层";
			this.layerVisable = true;
			this.layerColorBarName = "等值线颜色表";
		}

		public wContourLayer(string layerName, bool isVisible)
		{
			this.layerName = layerName;
			this.layerVisable = isVisible;
			this.layerColorBarName = "等值线颜色表";
		}

		public bool LoadData(GridDataScalar gds)
		{
			return this.LoadData(gds, null);
		}

		public bool LoadData(GridDataScalar gds, ContourParams contourParams)
		{
			System.Collections.Generic.List<System.Drawing.PointF> pts = new System.Collections.Generic.List<System.Drawing.PointF>();
			System.Collections.Generic.List<float> vals = new System.Collections.Generic.List<float>();
			int GridStep = 1;
			int RowNum = gds.m_GridSize.Height / GridStep;
			int ColNum = gds.m_GridSize.Width / GridStep;
			for (int i = 0; i < RowNum; i++)
			{
				for (int j = 0; j < ColNum; j++)
				{
					System.Drawing.PointF LonLat = gds.GetDataLonLat(i * GridStep, j * GridStep);
					float Val = (float)gds.GetData(i * GridStep, j * GridStep);
					if ((double)Val != gds.m_DefaultValue)
					{
						pts.Add(LonLat);
						vals.Add(Val);
					}
				}
			}
			return this.LoadData(pts.ToArray(), vals.ToArray(), contourParams, true);
		}

		public bool LoadData(System.Collections.Generic.List<System.Drawing.PointF> LonLatArray, System.Collections.Generic.List<float> ValueArray, ContourParams contourParams, bool UseBoundBox)
		{
			return this.LoadData(LonLatArray.ToArray(), ValueArray.ToArray(), contourParams, UseBoundBox);
		}

		public bool LoadData(System.Drawing.PointF[] LonLatArray, float[] ValueArray, ContourParams contourParams, bool UseBoundBox)
		{
			bool result;
			if (LonLatArray.Length != ValueArray.Length || LonLatArray.Length <= 3)
			{
				result = false;
			}
			else
			{
				this.m_ContourParams = contourParams;
				if (this.m_ContourParams == null)
				{
					this.m_ContourParams = new ContourParams();
					if (!this.m_ContourParams.LoadParams())
					{
						result = false;
						return result;
					}
				}
				System.Collections.Generic.List<VertexWithValue> vertexList = new System.Collections.Generic.List<VertexWithValue>(LonLatArray.Length);
				this.m_MinValue = 3.40282347E+38f;
				this.m_MaxValue = -3.40282347E+38f;
				for (int i = 0; i < LonLatArray.Length; i++)
				{
					System.Drawing.PointF LonLat = LonLatArray[i];
					VertexWithValue newVertex = new VertexWithValue(LonLat.X, LonLat.Y);
					float Val = ValueArray[i];
					newVertex.m_VertexValue = Val;
					newVertex.m_IsOuterVertex = false;
					if (Val != -999f)
					{
						newVertex.m_VertexValue = Val;
						if (newVertex.m_VertexValue > this.m_MaxValue)
						{
							this.m_MaxValue = newVertex.m_VertexValue;
						}
						if (newVertex.m_VertexValue < this.m_MinValue)
						{
							this.m_MinValue = newVertex.m_VertexValue;
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
					float rangeX = MaxX - MinX;
					float rangeY = MaxY - MinY;
					float rangeVal = this.m_MaxValue - this.m_MinValue;
					float val = this.m_MinValue - rangeVal / 10f;
					if (contourParams.ContourSearchType == 1)
					{
						float minVal = contourParams.m_ContourLineColorManager.m_ColorItems[0].myValue;
						float maxVal = contourParams.m_ContourLineColorManager.m_ColorItems[0].myValue;
						for (int i = 0; i < contourParams.m_ContourLineColorManager.m_ColorItems.Count; i++)
						{
							if (contourParams.m_ContourLineColorManager.m_ColorItems[i].myValue < minVal)
							{
								minVal = contourParams.m_ContourLineColorManager.m_ColorItems[i].myValue;
							}
							if (contourParams.m_ContourLineColorManager.m_ColorItems[i].myValue > maxVal)
							{
								maxVal = contourParams.m_ContourLineColorManager.m_ColorItems[i].myValue;
							}
						}
						if (minVal == 0f)
						{
							val = -5f;
						}
						else
						{
							val = System.Convert.ToSingle(minVal - System.Math.Abs(minVal / 10f));
						}
					}
					float val2 = val - rangeVal / 10f;
					for (int i = 0; i <= block; i++)
					{
						vertexList.Add(new VertexWithValue(MinX - rangeX + (float)i * (MaxX - MinX + 2f * rangeX) / (float)block, MinY - rangeY / 2f)
						{
							m_VertexValue = val,
							m_IsOuterVertex = false
						});
						vertexList.Add(new VertexWithValue(MinX - rangeX + (float)i * (MaxX - MinX + 2f * rangeX) / (float)block, MinY - rangeY)
						{
							m_VertexValue = val2,
							m_IsOuterVertex = true
						});
					}
					for (int i = 0; i <= block; i++)
					{
						vertexList.Add(new VertexWithValue(MinX - rangeX + (float)i * (MaxX - MinX + 2f * rangeX) / (float)block, MaxY + rangeY / 2f)
						{
							m_VertexValue = val,
							m_IsOuterVertex = false
						});
						vertexList.Add(new VertexWithValue(MinX - rangeX + (float)i * (MaxX - MinX + 2f * rangeX) / (float)block, MaxY + rangeY)
						{
							m_VertexValue = val2,
							m_IsOuterVertex = true
						});
					}
					for (int i = 1; i < block; i++)
					{
						vertexList.Add(new VertexWithValue(MinX - rangeX / 2f, MinY - rangeY + (float)i * (MaxY - MinY + 2f * rangeY) / (float)block)
						{
							m_VertexValue = val,
							m_IsOuterVertex = false
						});
						vertexList.Add(new VertexWithValue(MinX - rangeX, MinY - rangeY + (float)i * (MaxY - MinY + 2f * rangeY) / (float)block)
						{
							m_VertexValue = val2,
							m_IsOuterVertex = true
						});
					}
					for (int i = 1; i < block; i++)
					{
						vertexList.Add(new VertexWithValue(MaxX + rangeX / 2f, MinY - rangeY + (float)i * (MaxY - MinY + 2f * rangeY) / (float)block)
						{
							m_VertexValue = val,
							m_IsOuterVertex = false
						});
						vertexList.Add(new VertexWithValue(MaxX + rangeX, MinY - rangeY + (float)i * (MaxY - MinY + 2f * rangeY) / (float)block)
						{
							m_VertexValue = val2,
							m_IsOuterVertex = true
						});
					}
				}
				this.m_TriangleList = new System.Collections.Generic.List<Triangle>(vertexList.Count / 2);
				Triangulation tri = new Triangulation();
				tri.Triangulate(vertexList, this.m_TriangleList);
				this.m_VertexManager = tri.GetVertexManager();
				this.m_ContourManager = new ContourManager();
				this.m_ContourManager.SetParams(this.m_VertexManager, this.m_TriangleList);
				result = this.CreateCurveManager();
			}
			return result;
		}

		public bool LoadData(ContourManager contourManager, ContourParams contourParams)
		{
			bool result;
			if (contourManager == null || contourParams == null)
			{
				result = false;
			}
			else
			{
				this.m_ContourManager = contourManager;
				this.m_ContourParams = contourParams;
				this.m_DataRange = new System.Drawing.RectangleF(contourManager.m_MinLon, contourManager.m_MinLat, contourManager.m_MaxLon - contourManager.m_MinLon, contourManager.m_MaxLat - contourManager.m_MinLat);
				result = this.CreateCurveManager();
			}
			return result;
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
			int bitmapWidth = p.centerXY.X * 2;
			int bitmapHeight = p.centerXY.Y * 2;
			objRectangle = new System.Drawing.Rectangle(0, 0, bitmapWidth, bitmapHeight);
			System.Drawing.Color transparentColor = System.Drawing.Color.White;
			System.Drawing.Bitmap objBitmapMask = null;
			if (objMasker != null)
			{
				objBitmapMask = objMasker.CreateMasker(new System.Drawing.Size(bitmapWidth, bitmapHeight), p, transparentColor);
				this.layerBitmapMask = objBitmapMask;
			}
			if (this.m_ContourParams.ContourShowContour)
			{
				objBitmap = new System.Drawing.Bitmap(bitmapWidth, bitmapHeight);
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(objBitmap);
				g.Clear(transparentColor);
				this.m_CurveManager.DrawCurves(g, p, this.layerBitmapMask);
				if (this.m_ContourParams.ContourShowContourText)
				{
					this.m_CurveManager.DrawCurveText(g, p, this.layerBitmapMask, edgeLeft, edgeRight, edgeBottom, edgeTop);
				}
				if (this.m_ContourParams.ContourWantVertex || this.m_ContourParams.ContourWantTriangle)
				{
					this.m_ContourManager.DrawVertexAndTriangle(g, p, this.m_ContourParams.ContourWantVertex, this.m_ContourParams.ContourWantTriangle);
				}
				if (objBitmapMask != null)
				{
					g.DrawImage(objBitmapMask, 0, 0);
				}
				g.Dispose();
				objBitmap.MakeTransparent(transparentColor);
			}
			if (this.m_ContourParams.ContourWantFill)
			{
				objBitmapFill = new System.Drawing.Bitmap(bitmapWidth, bitmapHeight);
				objBitmapFillAlpha = (float)this.m_ContourParams.ContourFillAlpha;
				this.m_CurveManager.FillAlpha = 255;
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(objBitmapFill);
				g.Clear(transparentColor);
				this.m_CurveManager.FillClosedArea(g, p);
				if (objBitmapMask != null)
				{
					g.DrawImage(objBitmapMask, 0, 0);
				}
				g.Dispose();
				this.m_CurveManager.FillAlpha = (int)objBitmapFillAlpha;
				objBitmapFill.MakeTransparent(transparentColor);
			}
			else
			{
				objBitmapFill = null;
				objBitmapFillAlpha = 0f;
			}
			return true;
		}

		public override bool NeedDrawColorBar()
		{
			return this.m_ContourParams.ContourWantFill || this.m_ContourParams.ContourwColorManager != 0;
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

		private bool CreateCurveManager()
		{
			bool result;
			if (this.m_ContourManager.m_MinVal == this.m_ContourManager.m_MaxVal)
			{
				result = false;
			}
			else
			{
				ColorManager cmCurve = this.m_ContourParams.GetCurveColorManager(this.m_ContourManager.m_MinVal, this.m_ContourManager.m_MaxVal);
				ColorManager cmFill = this.m_ContourParams.GetFillColorManager(this.m_ContourManager.m_MinVal, this.m_ContourManager.m_MaxVal);
				this.m_ContourManager.m_ShowProgress = this.layerShowProgress;
				this.m_CurveManager = this.m_ContourManager.CreateContours(cmCurve, cmFill, this.m_ContourParams.ContourWantSPL);
				if (this.m_CurveManager == null)
				{
					this.m_TriangleList = null;
					this.m_VertexManager = null;
					result = false;
				}
				else
				{
					this.m_CurveManager.WantFill = (this.m_ContourParams.ContourFillType == 1 && this.m_ContourParams.ContourWantFill);
					this.m_CurveManager.FillAlpha = this.m_ContourParams.ContourFillAlpha;
					this.m_CurveManager.ShowText = this.m_ContourParams.ContourShowContourText;
					this.m_CurveManager.TextHeight = this.m_ContourParams.ContourTextHeight;
					this.m_CurveManager.TextBold = this.m_ContourParams.ContourTextBold;
					this.m_CurveManager.TextRotate = this.m_ContourParams.ContourTextRotate;
					this.m_CurveManager.TextColor = this.m_ContourParams.ContourTextColor;
					result = true;
				}
			}
			return result;
		}

		private void DrawContour(System.Drawing.Graphics g, Projection p)
		{
			if (this.m_CurveManager != null && this.m_CurveManager.CurveNum != 0)
			{
				if (!this.m_ContourParams.ContourWantFill || this.m_ContourParams.ContourFillType != 0)
				{
					if (this.m_ContourParams.ContourWantFill && this.m_ContourParams.ContourFillType == 1)
					{
						this.m_CurveManager.FillClosedArea(g, p);
					}
				}
				if (this.m_ContourParams.ContourShowContour)
				{
					this.m_CurveManager.DrawCurves(g, p, this.layerBitmapMask);
				}
				if (this.m_ContourParams.ContourWantVertex || this.m_ContourParams.ContourWantTriangle)
				{
					this.m_ContourManager.DrawVertexAndTriangle(g, p, this.m_ContourParams.ContourWantVertex, this.m_ContourParams.ContourWantTriangle);
				}
			}
		}
	}
}
