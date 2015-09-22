using System;
using System.Collections.Generic;
using System.Drawing;
using wMetroGIS.wDataObject;
using wMetroGIS.wMapMask;
using wMetroGIS.wMapPictureBoxControl;
using wMetroGIS.wMapProjection;
using wMetroGIS.wMathmatics;
using wMetroGIS.wParams;

namespace wMetroGIS.wLayers
{
	public class wVectorLayer : wBaseLayer
	{
		public VectorParams m_VectorParams;

		public GridDataVector m_GridDataVector;

		public System.Drawing.PointF[] m_DataVectorPos = null;

		public float[] m_DataVectorU = null;

		public float[] m_DataVectorV = null;

		private System.Drawing.RectangleF m_DataRange = System.Drawing.RectangleF.Empty;

		public wVectorLayer()
		{
			this.layerName = "矢量场图层";
			this.layerVisable = true;
			this.layerColorBarName = "流速等级颜色表";
		}

		public wVectorLayer(string layerName, bool isVisible)
		{
			this.layerName = layerName;
			this.layerVisable = isVisible;
			this.layerColorBarName = "流速等级颜色表";
		}

		public bool LoadData(GridDataVector gridDataVector, VectorParams vectorParams)
		{
			this.m_GridDataVector = gridDataVector;
			this.m_VectorParams = vectorParams;
			this.m_DataRange = this.m_GridDataVector.m_DataRange;
			return this.m_GridDataVector != null && this.m_VectorParams != null;
		}

		public bool LoadData(System.Collections.Generic.List<System.Drawing.PointF> DataVectorPos, System.Collections.Generic.List<float> DataVectorU, System.Collections.Generic.List<float> DataVectorV, VectorParams vectorParams)
		{
			return this.LoadData(DataVectorPos.ToArray(), DataVectorU.ToArray(), DataVectorV.ToArray(), vectorParams);
		}

		public bool LoadData(System.Drawing.PointF[] DataVectorPos, float[] DataVectorU, float[] DataVectorV, VectorParams vectorParams)
		{
			this.m_DataVectorPos = DataVectorPos;
			this.m_DataVectorU = DataVectorU;
			this.m_DataVectorV = DataVectorV;
			this.m_VectorParams = vectorParams;
			float MinX = this.m_DataVectorPos[0].X;
			float MaxX = this.m_DataVectorPos[0].X;
			float MinY = this.m_DataVectorPos[0].Y;
			float MaxY = this.m_DataVectorPos[0].Y;
			for (int i = 1; i < this.m_DataVectorPos.Length; i++)
			{
				if (this.m_DataVectorPos[i].X < MinX)
				{
					MinX = this.m_DataVectorPos[i].X;
				}
				else if (this.m_DataVectorPos[i].X > MaxX)
				{
					MaxX = this.m_DataVectorPos[i].X;
				}
				if (this.m_DataVectorPos[i].Y < MinY)
				{
					MinY = this.m_DataVectorPos[i].Y;
				}
				else if (this.m_DataVectorPos[i].Y > MaxY)
				{
					MaxY = this.m_DataVectorPos[i].Y;
				}
			}
			this.m_DataRange = new System.Drawing.RectangleF(MinX, MinY, MaxX - MinX, MaxY - MinY);
			return this.m_DataVectorPos != null && this.m_DataVectorU != null && this.m_DataVectorV != null && this.m_DataVectorPos.Length == this.m_DataVectorU.Length && this.m_DataVectorPos.Length == this.m_DataVectorV.Length && this.m_VectorParams != null;
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
			objRectangle = new System.Drawing.Rectangle(0, 0, p.centerXY.X * 2, p.centerXY.Y * 2);
			objBitmap = new System.Drawing.Bitmap(p.centerXY.X * 2, p.centerXY.Y * 2);
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
				this.DrawVector(g, p);
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
			return !this.m_VectorParams.VectorUseDefaultColor;
		}

		public override void DrawColorBar(wMapPictureBox mapPictureBox, System.Drawing.Graphics g, bool RedrawColorBar = true)
		{
			if (!this.layerShowColorBarTextOnCenter)
			{
				mapPictureBox.DrawColorBar(RedrawColorBar, this.layerColorBarName, this.m_VectorParams.m_VectorLevelColorManager1, this.m_VectorParams.m_VectorLevelColorManager2);
			}
			else
			{
				mapPictureBox.DrawVectorColor(RedrawColorBar, this.layerColorBarName, this.m_VectorParams.m_VectorLevelColorManager1, this.m_VectorParams.m_VectorLevelColorManager2);
			}
		}

		private void DrawVector(System.Drawing.Graphics g, Projection p)
		{
			if (this.m_VectorParams != null)
			{
				float a150 = (float)((double)this.m_VectorParams.VectorAngle * 3.1416 / 180.0);
				System.Drawing.Pen ArrowPenDefault = new System.Drawing.Pen(this.m_VectorParams.VectorDefaultColor, (float)this.m_VectorParams.VectorWidth);
				System.Drawing.Point P = p.LonLat2XY(p.centerLonLat);
				float DefaultArrowLen = (float)(p.LonLat2XY(p.centerLonLat.X + this.m_VectorParams.VectorDefaultLength, p.centerLonLat.Y).X - P.X);
				if (this.m_GridDataVector != null)
				{
					if (this.m_VectorParams.VectorLengthType == 1 || this.m_VectorParams.VectorLengthType == 2)
					{
						P = p.LonLat2XY(0f, 0f);
						DefaultArrowLen = (float)(p.LonLat2XY((float)this.m_GridDataVector.m_LonLatStep, 0f).X - P.X);
					}
					float MaxUV = (float)System.Math.Abs(this.m_GridDataVector.m_MaxU);
					if (System.Math.Abs(this.m_GridDataVector.m_MinV) > (double)MaxUV)
					{
						MaxUV = (float)System.Math.Abs(this.m_GridDataVector.m_MinV);
					}
					for (int i = 0; i < this.m_GridDataVector.m_GridSize.Height; i++)
					{
						for (int j = 0; j < this.m_GridDataVector.m_GridSize.Width; j++)
						{
							System.Drawing.PointF UV = this.m_GridDataVector.GetData(i, j);
							float U = UV.X;
							float V = UV.Y;
							if ((double)U != this.m_GridDataVector.m_DefaultValue && (double)V != this.m_GridDataVector.m_DefaultValue)
							{
								System.Drawing.Pen thisArrowPen = ArrowPenDefault;
								float LevelMax = -999f;
								if (!this.m_VectorParams.VectorUseDefaultColor)
								{
									double M = System.Math.Sqrt((double)(U * U + V * V));
									for (int k = 0; k < this.m_VectorParams.m_VectorLevelColorManager1.m_ColorItems.Count; k++)
									{
										float Value = this.m_VectorParams.m_VectorLevelColorManager1.m_ColorItems[k].myValue;
										float Value2 = this.m_VectorParams.m_VectorLevelColorManager2.m_ColorItems[k].myValue;
										if (M >= (double)Value && M <= (double)Value2)
										{
											thisArrowPen = new System.Drawing.Pen(this.m_VectorParams.m_VectorLevelColorManager1.m_ColorItems[k].myColor, (float)this.m_VectorParams.VectorWidth);
											LevelMax = Value2;
											break;
										}
									}
								}
								System.Drawing.PointF LonLat = this.m_GridDataVector.GetDataLonLat(i, j);
								System.Drawing.Point pos = p.LonLat2XY(LonLat.X, LonLat.Y);
								double angle = p.GetAngle(LonLat);
								int X = pos.X;
								int Y = pos.Y;
								int X2;
								int Y2;
								if (this.m_VectorParams.VectorLengthType == 1)
								{
									X2 = pos.X + System.Convert.ToInt32(U / MaxUV * DefaultArrowLen);
									Y2 = pos.Y - System.Convert.ToInt32(V / MaxUV * DefaultArrowLen);
								}
								else if (this.m_VectorParams.VectorLengthType == 2)
								{
									X2 = pos.X + System.Convert.ToInt32(U / LevelMax * DefaultArrowLen);
									Y2 = pos.Y - System.Convert.ToInt32(V / LevelMax * DefaultArrowLen);
								}
								else
								{
									double R = System.Math.Sqrt((double)(U * U + V * V));
									if (R == 0.0)
									{
										X2 = X + 1;
										Y2 = Y + 1;
									}
									else
									{
										X2 = pos.X + System.Convert.ToInt32((double)U / R * (double)DefaultArrowLen);
										Y2 = pos.Y - System.Convert.ToInt32((double)V / R * (double)DefaultArrowLen);
									}
								}
								int thisArrowLen = System.Convert.ToInt32(System.Math.Sqrt((double)((X2 - X) * (X2 - X) + (Y2 - Y) * (Y2 - Y))));
								if (X == X2 && Y == Y2)
								{
									X2 = X + 1;
									Y2 = Y + 1;
								}
								g.TranslateTransform((float)X, (float)Y);
								g.RotateTransform((float)angle);
								if (this.m_VectorParams.VectorArrowType == 1)
								{
									VectorParams.DrawArrow(g, thisArrowPen, thisArrowLen, a150, 0, 0, X2 - X, Y2 - Y);
								}
								else if (this.m_VectorParams.VectorArrowType == 2)
								{
									double fs;
									double fx;
									Mathmatics.UVToFxFs((double)U, (double)V, out fs, out fx);
									int Fs = System.Convert.ToInt32(fs);
									float Fx = System.Convert.ToSingle(fx);
									VectorParams.DrawWind(g, thisArrowPen, thisArrowLen, Fs, Fx, 0, 0);
								}
								g.ResetTransform();
							}
						}
					}
				}
				else if (this.m_DataVectorPos != null && this.m_DataVectorU != null && this.m_DataVectorV != null && this.m_DataVectorPos.Length == this.m_DataVectorU.Length && this.m_DataVectorPos.Length == this.m_DataVectorV.Length)
				{
					float MaxUV = -9999f;
					for (int i = 0; i < this.m_DataVectorV.Length; i++)
					{
						float UV2 = System.Convert.ToSingle(System.Math.Sqrt((double)(this.m_DataVectorU[i] * this.m_DataVectorU[i] + this.m_DataVectorV[i] * this.m_DataVectorV[i])));
						if (UV2 >= MaxUV)
						{
							MaxUV = UV2;
						}
					}
					for (int i = 0; i < this.m_DataVectorV.Length; i++)
					{
						float U = this.m_DataVectorU[i];
						float V = this.m_DataVectorV[i];
						System.Drawing.Pen thisArrowPen = ArrowPenDefault;
						float LevelMax = -999f;
						if (!this.m_VectorParams.VectorUseDefaultColor)
						{
							double M = System.Math.Sqrt((double)(U * U + V * V));
							for (int k = 0; k < this.m_VectorParams.m_VectorLevelColorManager1.m_ColorItems.Count; k++)
							{
								float Value = this.m_VectorParams.m_VectorLevelColorManager1.m_ColorItems[k].myValue;
								float Value2 = this.m_VectorParams.m_VectorLevelColorManager2.m_ColorItems[k].myValue;
								if (M >= (double)Value && M <= (double)Value2)
								{
									thisArrowPen = new System.Drawing.Pen(this.m_VectorParams.m_VectorLevelColorManager1.m_ColorItems[k].myColor, (float)this.m_VectorParams.VectorWidth);
									LevelMax = Value2;
									break;
								}
							}
						}
						System.Drawing.PointF LonLat = this.m_DataVectorPos[i];
						System.Drawing.Point pos = p.LonLat2XY(LonLat.X, LonLat.Y);
						double angle = p.GetAngle(LonLat);
						int X = pos.X;
						int Y = pos.Y;
						int X2;
						int Y2;
						if (this.m_VectorParams.VectorLengthType == 1)
						{
							X2 = pos.X + System.Convert.ToInt32(U / MaxUV * DefaultArrowLen);
							Y2 = pos.Y - System.Convert.ToInt32(V / MaxUV * DefaultArrowLen);
						}
						else if (this.m_VectorParams.VectorLengthType == 2)
						{
							X2 = pos.X + System.Convert.ToInt32(U / LevelMax * DefaultArrowLen);
							Y2 = pos.Y - System.Convert.ToInt32(V / LevelMax * DefaultArrowLen);
						}
						else
						{
							double R = System.Math.Sqrt((double)(U * U + V * V));
							if (R == 0.0)
							{
								X2 = X + 1;
								Y2 = Y + 1;
							}
							else
							{
								X2 = pos.X + System.Convert.ToInt32((double)U / R * (double)DefaultArrowLen);
								Y2 = pos.Y - System.Convert.ToInt32((double)V / R * (double)DefaultArrowLen);
							}
						}
						int thisArrowLen = System.Convert.ToInt32(System.Math.Sqrt((double)((X2 - X) * (X2 - X) + (Y2 - Y) * (Y2 - Y))));
						if (X == X2 && Y == Y2)
						{
							X2 = X + 1;
							Y2 = Y + 1;
						}
						g.TranslateTransform((float)X, (float)Y);
						g.RotateTransform((float)angle);
						if (this.m_VectorParams.VectorArrowType == 1)
						{
							VectorParams.DrawArrow(g, thisArrowPen, thisArrowLen, a150, 0, 0, X2 - X, Y2 - X);
						}
						else if (this.m_VectorParams.VectorArrowType == 2)
						{
							double fs;
							double fx;
							Mathmatics.UVToFxFs((double)U, (double)V, out fs, out fx);
							int Fs = System.Convert.ToInt32(fs);
							float Fx = System.Convert.ToSingle(fx);
							VectorParams.DrawWind(g, thisArrowPen, thisArrowLen, Fs, Fx, 0, 0);
						}
						g.ResetTransform();
					}
				}
			}
		}
	}
}
