using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using wMetroGIS.wColorManager;
using wMetroGIS.wFunctionFormLib;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wCurve
{
	public class CurveManager
	{
		public ColorManager m_ColorManagerCurve;

		public ColorManager m_ColorManagerFill;

		private bool m_IsGridData;

		private System.Drawing.Size m_GridDataSize;

		private double[] m_GridData;

		private bool m_WantArrow;

		private int m_ArrowSplit;

		private bool m_ArrowPositiveDir;

		private bool m_ShowText;

		private int m_TextHeight;

		private bool m_TextBold;

		private bool m_TextRotate;

		private bool m_TextColor;

		private bool m_IsCombined;

		private bool m_WantFill;

		private int m_FillAlpha;

		private System.Drawing.RectangleF m_CurveArea;

		private System.Collections.Generic.List<Curve> m_Curves;

		private Curve m_SelectedCurve;

		public CurveRelation m_CurveRelation = new CurveRelation();

		public bool IsGridData
		{
			get
			{
				return this.m_IsGridData;
			}
			set
			{
				this.m_IsGridData = value;
			}
		}

		public System.Drawing.Size GridDataSize
		{
			get
			{
				return this.m_GridDataSize;
			}
			set
			{
				this.m_GridDataSize = value;
			}
		}

		public double[] GridData
		{
			get
			{
				return this.m_GridData;
			}
			set
			{
				this.m_GridData = value;
			}
		}

		public bool WantArrow
		{
			get
			{
				return this.m_WantArrow;
			}
			set
			{
				this.m_WantArrow = value;
			}
		}

		public int ArrowSplit
		{
			get
			{
				return this.m_ArrowSplit;
			}
			set
			{
				this.m_ArrowSplit = value;
			}
		}

		public bool ArrowPositiveDir
		{
			get
			{
				return this.m_ArrowPositiveDir;
			}
			set
			{
				this.m_ArrowPositiveDir = value;
			}
		}

		public bool ShowText
		{
			get
			{
				return this.m_ShowText;
			}
			set
			{
				this.m_ShowText = value;
			}
		}

		public int TextHeight
		{
			get
			{
				return this.m_TextHeight;
			}
			set
			{
				this.m_TextHeight = value;
			}
		}

		public bool TextBold
		{
			get
			{
				return this.m_TextBold;
			}
			set
			{
				this.m_TextBold = value;
			}
		}

		public bool TextRotate
		{
			get
			{
				return this.m_TextRotate;
			}
			set
			{
				this.m_TextRotate = value;
			}
		}

		public bool TextColor
		{
			get
			{
				return this.m_TextColor;
			}
			set
			{
				this.m_TextColor = value;
			}
		}

		public bool IsCombined
		{
			get
			{
				return this.m_IsCombined;
			}
		}

		public bool WantFill
		{
			get
			{
				return this.m_WantFill;
			}
			set
			{
				this.m_WantFill = value;
			}
		}

		public int FillAlpha
		{
			get
			{
				return this.m_FillAlpha;
			}
			set
			{
				if (value < 0)
				{
					this.m_FillAlpha = 0;
				}
				else if (value > 255)
				{
					this.m_FillAlpha = 255;
				}
				else
				{
					this.m_FillAlpha = value;
				}
			}
		}

		public System.Drawing.RectangleF CurveArea
		{
			get
			{
				return this.m_CurveArea;
			}
			set
			{
				this.m_CurveArea = value;
			}
		}

		public System.Collections.Generic.List<Curve> Curves
		{
			get
			{
				return this.m_Curves;
			}
		}

		public int CurveNum
		{
			get
			{
				return this.m_Curves.Count;
			}
		}

		public Curve SelectedCurve
		{
			get
			{
				return this.m_SelectedCurve;
			}
		}

		public CurveManager()
		{
			this.m_Curves = new System.Collections.Generic.List<Curve>();
			this.m_WantFill = false;
			this.m_FillAlpha = 100;
			this.m_SelectedCurve = null;
			this.m_CurveArea = System.Drawing.RectangleF.Empty;
			this.m_IsCombined = false;
			this.m_ShowText = true;
			this.m_TextHeight = 10;
			this.m_IsGridData = false;
			this.m_GridDataSize = System.Drawing.Size.Empty;
			this.m_GridData = null;
			this.m_WantArrow = false;
			this.m_ArrowSplit = 20;
			this.m_ArrowPositiveDir = true;
		}

		public void ClearCurves()
		{
			this.m_Curves.Clear();
			this.m_SelectedCurve = null;
		}

		public void AddCurve(System.Drawing.PointF[] CurvePoints, int curveColorIndex, int fillColorIndex, bool IsClosed, bool WantSPL)
		{
			Curve newCurve = new Curve();
			if (CurvePoints != null && CurvePoints.Length >= 3)
			{
				newCurve.SetPointArray(CurvePoints, IsClosed, WantSPL);
				newCurve.ColorManagerCurve = this.m_ColorManagerCurve;
				newCurve.ColorManagerFill = this.m_ColorManagerFill;
				newCurve.CurveColorIndex = curveColorIndex;
				newCurve.FillColorIndex = fillColorIndex;
				newCurve.LineWidth = this.m_ColorManagerCurve.m_ColorItems[curveColorIndex].myLineWidth;
				newCurve.LineStyle = this.m_ColorManagerCurve.m_ColorItems[curveColorIndex].myDashStyle;
				this.m_Curves.Add(newCurve);
			}
		}

		public Curve GetCurve(int Index)
		{
			Curve result;
			if (Index > this.m_Curves.Count - 1)
			{
				result = null;
			}
			else
			{
				result = this.m_Curves[Index];
			}
			return result;
		}

		public Curve SelectCurve(System.Drawing.PointF testPoint)
		{
			Curve result;
			if (this.m_Curves == null)
			{
				result = null;
			}
			else
			{
				this.m_SelectedCurve = null;
				for (int i = 0; i < this.m_Curves.Count; i++)
				{
					if (this.m_Curves[i].SelectCurve(testPoint))
					{
						this.m_SelectedCurve = this.m_Curves[i];
						result = this.m_SelectedCurve;
						return result;
					}
				}
				result = null;
			}
			return result;
		}

		public void DrawCurves(System.Drawing.Graphics g, Projection p)
		{
			this.DrawCurves(g, p, null);
		}

		public void DrawCurves(System.Drawing.Graphics g, Projection p, System.Drawing.Bitmap maskBitmap)
		{
			if (this.m_Curves != null)
			{
				foreach (Curve c in this.m_Curves)
				{
					c.DrawCurve(g, p, maskBitmap);
					if (this.m_WantArrow)
					{
						c.DrawArrow(g, p, this.ArrowSplit, this.ArrowPositiveDir);
					}
				}
			}
		}

		public void DrawCurveText(System.Drawing.Graphics g, Projection p, System.Drawing.Bitmap maskBitmap, int edgeLeft = 0, int edgeRight = 0, int edgeBottom = 0, int edgeTop = 0)
		{
			if (this.m_Curves != null)
			{
				System.Drawing.Font font = new System.Drawing.Font("times new romen", (float)this.TextHeight, this.m_TextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
				System.Drawing.StringFormat formatC = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				formatC.Alignment = System.Drawing.StringAlignment.Center;
				formatC.LineAlignment = System.Drawing.StringAlignment.Center;
				System.Drawing.StringFormat formatL = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				formatL.Alignment = System.Drawing.StringAlignment.Near;
				formatL.LineAlignment = System.Drawing.StringAlignment.Center;
				System.Drawing.StringFormat formatR = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				formatR.Alignment = System.Drawing.StringAlignment.Far;
				formatR.LineAlignment = System.Drawing.StringAlignment.Center;
				System.Drawing.StringFormat formatB = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				formatB.Alignment = System.Drawing.StringAlignment.Center;
				formatB.LineAlignment = System.Drawing.StringAlignment.Far;
				System.Drawing.StringFormat formatT = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				formatT.Alignment = System.Drawing.StringAlignment.Center;
				formatT.LineAlignment = System.Drawing.StringAlignment.Near;
				System.Drawing.Point ptLB = p.LonLat2XY(p.Left, p.Bottom);
				System.Drawing.Point ptRT = p.LonLat2XY(p.Right, p.Top);
				int validLeftXY = ptLB.X + edgeLeft;
				int validRightXY = ptRT.X - edgeRight;
				int validBottomXY = ptLB.Y - edgeBottom;
				int validTopXY = ptRT.Y + edgeTop;
				System.Drawing.PointF ptLB2 = p.XY2LonLat(validLeftXY, validBottomXY);
				System.Drawing.PointF ptRT2 = p.XY2LonLat(validRightXY, validTopXY);
				float validLeftLL = ptLB2.X;
				float validRightLL = ptRT2.X;
				float validBottomLL = ptLB2.Y;
				float validTopLL = ptRT2.Y;
				System.Drawing.SolidBrush brushTextBack = new System.Drawing.SolidBrush(System.Drawing.Color.White);
				g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
				foreach (Curve c in this.m_Curves)
				{
					System.Drawing.SolidBrush brushFront = new System.Drawing.SolidBrush(this.m_TextColor ? c.CurveColor : System.Drawing.Color.Black);
					System.Drawing.SolidBrush brushBack = new System.Drawing.SolidBrush(this.m_TextColor ? System.Drawing.Color.Black : System.Drawing.Color.FromArgb(254, 254, 254));
					System.Drawing.PointF[] m_PathPointArray = c.PathPointArray;
					if (m_PathPointArray.Length <= 1)
					{
						break;
					}
					string str = c.CurveValueText;
					if (maskBitmap == null)
					{
						bool found = false;
						for (int i = 0; i < m_PathPointArray.Length - 1; i++)
						{
							if (m_PathPointArray[i].X < validLeftLL && m_PathPointArray[i + 1].X >= validLeftLL)
							{
								System.Drawing.Point pt = p.LonLat2XY(m_PathPointArray[i + 1]);
								System.Drawing.SizeF size = g.MeasureString(str, font);
								System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0f, -size.Height / 2f, size.Width, size.Height);
								g.TranslateTransform((float)validLeftXY, (float)pt.Y);
								g.FillRectangle(brushTextBack, rect);
								g.DrawString(str, font, brushFront, 0f, 0f, formatL);
								g.ResetTransform();
								found = true;
							}
							if (m_PathPointArray[i].X >= validLeftLL && m_PathPointArray[i + 1].X < validLeftLL)
							{
								System.Drawing.Point pt = p.LonLat2XY(m_PathPointArray[i]);
								System.Drawing.SizeF size = g.MeasureString(str, font);
								System.Drawing.RectangleF rect = new System.Drawing.RectangleF(0f, -size.Height / 2f, size.Width, size.Height);
								g.TranslateTransform((float)validLeftXY, (float)pt.Y);
								g.FillRectangle(brushTextBack, rect);
								g.DrawString(str, font, brushFront, 0f, 0f, formatL);
								g.ResetTransform();
								found = true;
							}
							if (m_PathPointArray[i].X < validRightLL && m_PathPointArray[i + 1].X >= validRightLL)
							{
								System.Drawing.Point pt = p.LonLat2XY(m_PathPointArray[i]);
								System.Drawing.SizeF size = g.MeasureString(str, font);
								System.Drawing.RectangleF rect = new System.Drawing.RectangleF(-size.Width, -size.Height / 2f, size.Width, size.Height);
								g.TranslateTransform((float)validRightXY, (float)pt.Y);
								g.FillRectangle(brushTextBack, rect);
								g.DrawString(str, font, brushFront, 0f, 0f, formatR);
								g.ResetTransform();
								found = true;
							}
							if (m_PathPointArray[i].X >= validRightLL && m_PathPointArray[i + 1].X < validRightLL)
							{
								System.Drawing.Point pt = p.LonLat2XY(m_PathPointArray[i + 1]);
								System.Drawing.SizeF size = g.MeasureString(str, font);
								System.Drawing.RectangleF rect = new System.Drawing.RectangleF(-size.Width, -size.Height / 2f, size.Width, size.Height);
								g.TranslateTransform((float)validRightXY, (float)pt.Y);
								g.FillRectangle(brushTextBack, rect);
								g.DrawString(str, font, brushFront, 0f, 0f, formatR);
								g.ResetTransform();
								found = true;
							}
							if (m_PathPointArray[i].Y < validBottomLL && m_PathPointArray[i + 1].Y >= validBottomLL)
							{
								System.Drawing.Point pt = p.LonLat2XY(m_PathPointArray[i + 1]);
								System.Drawing.SizeF size = g.MeasureString(str, font);
								System.Drawing.RectangleF rect = new System.Drawing.RectangleF(-size.Width / 2f, -size.Height, size.Width, size.Height);
								g.TranslateTransform((float)pt.X, (float)validBottomXY);
								g.FillRectangle(brushTextBack, rect);
								g.DrawString(str, font, brushFront, 0f, 0f, formatB);
								g.ResetTransform();
								found = true;
							}
							if (m_PathPointArray[i].Y >= validBottomLL && m_PathPointArray[i + 1].Y < validBottomLL)
							{
								System.Drawing.Point pt = p.LonLat2XY(m_PathPointArray[i]);
								System.Drawing.SizeF size = g.MeasureString(str, font);
								System.Drawing.RectangleF rect = new System.Drawing.RectangleF(-size.Width / 2f, -size.Height, size.Width, size.Height);
								g.TranslateTransform((float)pt.X, (float)validBottomXY);
								g.FillRectangle(brushTextBack, rect);
								g.DrawString(str, font, brushFront, 0f, 0f, formatB);
								g.ResetTransform();
								found = true;
							}
							if (m_PathPointArray[i].Y < validTopLL && m_PathPointArray[i + 1].Y >= validTopLL)
							{
								System.Drawing.Point pt = p.LonLat2XY(m_PathPointArray[i]);
								System.Drawing.SizeF size = g.MeasureString(str, font);
								System.Drawing.RectangleF rect = new System.Drawing.RectangleF(-size.Width / 2f, 0f, size.Width, size.Height);
								g.TranslateTransform((float)pt.X, (float)validTopXY);
								g.FillRectangle(brushTextBack, rect);
								g.DrawString(str, font, brushFront, 0f, 0f, formatT);
								g.ResetTransform();
								found = true;
							}
							if (m_PathPointArray[i].Y >= validTopLL && m_PathPointArray[i + 1].Y < validTopLL)
							{
								System.Drawing.Point pt = p.LonLat2XY(m_PathPointArray[i + 1]);
								System.Drawing.SizeF size = g.MeasureString(str, font);
								System.Drawing.RectangleF rect = new System.Drawing.RectangleF(-size.Width / 2f, 0f, size.Width, size.Height);
								g.TranslateTransform((float)pt.X, (float)validTopXY);
								g.FillRectangle(brushTextBack, rect);
								g.DrawString(str, font, brushFront, 0f, 0f, formatT);
								g.ResetTransform();
								found = true;
							}
						}
						if (!found)
						{
							System.Drawing.PointF maxPt = m_PathPointArray[0];
							for (int i = 1; i < m_PathPointArray.Length - 1; i++)
							{
								if (m_PathPointArray[i].Y > maxPt.Y)
								{
									maxPt = m_PathPointArray[i];
								}
							}
							System.Drawing.Point pt2 = p.LonLat2XY(maxPt);
							System.Drawing.SizeF size = g.MeasureString(str, font);
							System.Drawing.RectangleF rect = new System.Drawing.RectangleF(-size.Width / 2f, -size.Height / 2f, size.Width, size.Height);
							g.TranslateTransform((float)pt2.X, (float)pt2.Y);
							g.FillRectangle(brushTextBack, rect);
							g.DrawString(str, font, brushFront, 0f, 0f, formatC);
							g.ResetTransform();
						}
					}
					else
					{
						int Interv = 300;
						double TotalLon = (double)(Interv + 1);
						for (int i = 2; i < m_PathPointArray.Length - 2; i++)
						{
							System.Drawing.Point lastPoint = p.LonLat2XY(m_PathPointArray[i - 1].X, m_PathPointArray[i - 1].Y);
							System.Drawing.Point thisPoint = p.LonLat2XY(m_PathPointArray[i].X, m_PathPointArray[i].Y);
							if (TotalLon < (double)Interv)
							{
								TotalLon += System.Math.Sqrt((double)((thisPoint.X - lastPoint.X) * (thisPoint.X - lastPoint.X) + (thisPoint.Y - lastPoint.Y) * (thisPoint.Y - lastPoint.Y)));
							}
							else
							{
								TotalLon = 0.0;
								g.TranslateTransform((float)thisPoint.X, (float)thisPoint.Y);
								if (this.m_TextRotate)
								{
									double angle;
									if (thisPoint.X == lastPoint.X)
									{
										if (thisPoint.Y <= lastPoint.Y)
										{
											angle = 90.0;
										}
										else
										{
											angle = -90.0;
										}
									}
									else
									{
										angle = System.Math.Atan((double)((thisPoint.Y - lastPoint.Y) / (thisPoint.X - lastPoint.X))) * 180.0 / 3.1415926535897931;
									}
									if (double.IsNaN(angle))
									{
										angle = 0.0;
									}
									if (angle > 180.0)
									{
										angle -= 180.0;
									}
									g.RotateTransform((float)angle);
								}
								bool canShow = true;
								if (thisPoint.X < 0 || thisPoint.X > maskBitmap.Width || thisPoint.Y < 0 || thisPoint.Y > maskBitmap.Height)
								{
									canShow = false;
								}
								else
								{
									try
									{
										if (maskBitmap.GetPixel(thisPoint.X - this.TextHeight * str.Length / 2, thisPoint.Y - this.TextHeight / 2).Name == "ffffffff")
										{
											canShow = false;
										}
										else if (maskBitmap.GetPixel(thisPoint.X - this.TextHeight * str.Length / 2, thisPoint.Y + this.TextHeight / 2).Name == "ffffffff")
										{
											canShow = false;
										}
										else if (maskBitmap.GetPixel(thisPoint.X + this.TextHeight * str.Length / 2, thisPoint.Y - this.TextHeight / 2).Name == "ffffffff")
										{
											canShow = false;
										}
										else if (maskBitmap.GetPixel(thisPoint.X + this.TextHeight * str.Length / 2, thisPoint.Y + this.TextHeight / 2).Name == "ffffffff")
										{
											canShow = false;
										}
									}
									catch
									{
										canShow = false;
									}
								}
								if (canShow)
								{
									System.Drawing.SizeF size = g.MeasureString(str, font);
									System.Drawing.RectangleF rect = new System.Drawing.RectangleF(-size.Width / 2f, -size.Height / 2f, size.Width, size.Height);
									g.FillRectangle(brushTextBack, rect);
									g.DrawString(str, font, brushFront, 0f, 0f, formatC);
								}
								g.ResetTransform();
							}
						}
					}
				}
			}
		}

		public void FillClosedArea(System.Drawing.Graphics g, Projection p)
		{
			if (this.m_Curves != null)
			{
				foreach (Curve c in this.m_Curves)
				{
					if (c.IsClosed)
					{
						c.FillCurve(g, p, this.m_FillAlpha, this.m_ColorManagerFill);
					}
				}
			}
		}

		public void FillRegion(System.Drawing.Graphics g, Projection p)
		{
			if (this.m_Curves != null)
			{
				System.Collections.Generic.List<Curve> curveList = new System.Collections.Generic.List<Curve>();
				foreach (Curve c in this.m_Curves)
				{
					if (c.IsClosed)
					{
						c.FillCurve(g, p, this.m_FillAlpha, this.m_ColorManagerFill);
						if (c.FillRegion != null)
						{
							curveList.Add(c);
						}
					}
				}
				System.Drawing.Point LT = p.LonLat2XY(this.m_CurveArea.Left, this.m_CurveArea.Bottom);
				System.Drawing.Point RT = p.LonLat2XY(this.m_CurveArea.Right, this.m_CurveArea.Bottom);
				System.Drawing.Point LB = p.LonLat2XY(this.m_CurveArea.Left, this.m_CurveArea.Top);
				System.Drawing.Point RB = p.LonLat2XY(this.m_CurveArea.Right, this.m_CurveArea.Top);
				System.Drawing.Rectangle myRect = new System.Drawing.Rectangle(LT, new System.Drawing.Size(RT.X - LT.X, LB.Y - LT.Y));
				System.Drawing.Region myRegion = new System.Drawing.Region(myRect);
				foreach (Curve c in curveList)
				{
					myRegion.Exclude(c.FillRegion);
				}
				System.Drawing.Drawing2D.Matrix matrix = g.Transform;
				System.Drawing.RectangleF[] myRects = myRegion.GetRegionScans(matrix);
				System.Collections.Generic.List<System.Drawing.RectangleF> rectList = new System.Collections.Generic.List<System.Drawing.RectangleF>(myRects.Length);
				for (int i = 0; i < myRects.Length; i++)
				{
					myRects[i].Inflate(1f, 1f);
					rectList.Add(myRects[i]);
				}
				ProgressForm pf = new ProgressForm();
				pf.Show();
				pf.SetProgressInfoText("正在对区域进行再合并计算");
				pf.SetProgressRange(0, rectList.Count);
				pf.SetProgressPos(0, true);
				int rectNum = rectList.Count;
				System.Collections.Generic.List<System.Drawing.Region> regionListTemp = new System.Collections.Generic.List<System.Drawing.Region>();
				while (rectList.Count != 0)
				{
					System.Drawing.RectangleF thisRect = rectList[0];
					rectList.RemoveAt(0);
					System.Drawing.Region thisRegion = new System.Drawing.Region(thisRect);
					System.Drawing.Region newRegion = new System.Drawing.Region(thisRect);
					if (rectList.Count != 0)
					{
						int pos = 0;
						do
						{
							if (thisRegion.IsVisible(rectList[pos]))
							{
								newRegion.Union(thisRegion);
								thisRegion = new System.Drawing.Region(rectList[pos]);
								rectList.RemoveAt(pos);
							}
							else
							{
								pos++;
							}
							int j = rectNum - rectList.Count;
							if (j % 10 == 0)
							{
								pf.SetProgressPos(j, true);
							}
						}
						while (pos < rectList.Count - 1 && rectList.Count != 0);
					}
					regionListTemp.Add(newRegion);
				}
				pf.Close();
				System.Collections.Generic.List<System.Drawing.Region> regionList = regionListTemp;
				foreach (System.Drawing.Region region in regionList)
				{
					foreach (Curve c in curveList)
					{
						System.Drawing.Region tempRegion = region.Clone();
						tempRegion.Intersect(c.FillRegion);
						if (!tempRegion.IsEmpty(g))
						{
							g.FillRegion(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(this.m_FillAlpha, c.FillColor)), region);
							break;
						}
					}
				}
			}
		}

		public void DrawRegionText(System.Drawing.Graphics g, Projection p)
		{
			if (this.m_ShowText)
			{
				System.Drawing.Font font = new System.Drawing.Font("黑体", (float)this.TextHeight, System.Drawing.FontStyle.Bold);
				System.Drawing.SolidBrush brush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				System.Drawing.StringFormat format = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				format.Alignment = System.Drawing.StringAlignment.Center;
				format.LineAlignment = System.Drawing.StringAlignment.Center;
				foreach (Curve c in this.m_Curves)
				{
					if (c.FillRegion != null)
					{
						string str = c.CurveValueText;
						System.Drawing.RectangleF myRect = c.FillRegion.GetBounds(g);
						g.DrawString(str, font, brush, myRect.Location.X + myRect.Width / 2f, myRect.Location.Y + myRect.Height / 2f, format);
					}
				}
			}
		}

		public void ApplyCurveModify()
		{
			if (this.m_Curves != null)
			{
				for (int i = 0; i < this.m_Curves.Count; i++)
				{
					if (this.m_Curves[i].IsSelected)
					{
						this.m_Curves.RemoveAt(i);
						this.m_Curves.Add(this.m_SelectedCurve.Clone());
						break;
					}
				}
			}
		}

		public void RefuseCurveModify()
		{
			if (this.m_Curves != null)
			{
				for (int i = 0; i < this.m_Curves.Count; i++)
				{
					if (this.m_Curves[i].IsSelected)
					{
						this.m_SelectedCurve = this.m_Curves[i].Clone();
						break;
					}
				}
			}
		}

		public void CancelSelectedCurve()
		{
			if (this.m_Curves != null)
			{
				for (int i = 0; i < this.m_Curves.Count; i++)
				{
					if (this.m_Curves[i].IsSelected)
					{
						this.m_Curves[i].IsSelected = false;
						this.m_SelectedCurve = null;
						break;
					}
				}
			}
		}

		public void DeleteSelectedCurve()
		{
			if (this.m_SelectedCurve != null && this.m_Curves != null)
			{
				int SelectedIndex = -1;
				for (int i = 0; i < this.m_Curves.Count; i++)
				{
					if (this.m_Curves[i].IsSelected)
					{
						SelectedIndex = i;
						break;
					}
				}
				if (SelectedIndex != -1)
				{
					this.m_Curves.RemoveAt(SelectedIndex);
					this.m_SelectedCurve = null;
				}
			}
		}

		public void CreateRelationship()
		{
			if (!this.m_IsCombined)
			{
				this.m_CurveRelation = new CurveRelation();
				if (this.m_CurveRelation.CreateRelationship(this.m_Curves))
				{
				}
			}
		}

		public void SetDefaultCurveStyle(int LineWidth, System.Drawing.Drawing2D.DashStyle LineStyle)
		{
			if (!this.m_IsCombined && this.m_Curves != null)
			{
				for (int i = 0; i < this.m_Curves.Count; i++)
				{
					this.m_Curves[i].LineWidth = LineWidth;
					this.m_Curves[i].LineStyle = LineStyle;
				}
			}
		}

		public void Combin(CurveManager sourceCurveManager)
		{
			for (int i = 0; i < sourceCurveManager.m_Curves.Count; i++)
			{
				this.m_Curves.Add(sourceCurveManager.m_Curves[i]);
			}
			float Left;
			if (sourceCurveManager.m_CurveArea.Left < this.m_CurveArea.Left)
			{
				Left = sourceCurveManager.m_CurveArea.Left;
			}
			else
			{
				Left = this.m_CurveArea.Left;
			}
			float Right;
			if (sourceCurveManager.m_CurveArea.Right < this.m_CurveArea.Right)
			{
				Right = sourceCurveManager.m_CurveArea.Right;
			}
			else
			{
				Right = this.m_CurveArea.Right;
			}
			float Bottom;
			if (sourceCurveManager.m_CurveArea.Bottom < this.m_CurveArea.Bottom)
			{
				Bottom = sourceCurveManager.m_CurveArea.Bottom;
			}
			else
			{
				Bottom = this.m_CurveArea.Bottom;
			}
			float Top;
			if (sourceCurveManager.m_CurveArea.Top < this.m_CurveArea.Top)
			{
				Top = sourceCurveManager.m_CurveArea.Top;
			}
			else
			{
				Top = this.m_CurveArea.Top;
			}
			this.m_CurveArea = new System.Drawing.RectangleF(Left, Top, Right - Left, Top - Bottom);
			this.m_IsCombined = true;
		}
	}
}
