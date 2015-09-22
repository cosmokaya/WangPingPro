using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;
using wMetroGIS.wColorManager;
using wMetroGIS.wCurve;
using wMetroGIS.wFunctionFormLib;
using wMetroGIS.wMapProjection;
using wMetroGIS.wTriangulation;

namespace wMetroGIS.wContour
{
	public class ContourManager
	{
		public System.Collections.Generic.List<Edge> m_EdgeList;

		public System.Collections.Generic.List<TriangleWithEdge> m_TriangleList;

		public VertexManager m_VertexManager;

		public bool m_ShowProgress = true;

		private Edge currentEdge;

		public float m_MinVal;

		public float m_MaxVal;

		public float m_MinLon;

		public float m_MaxLon;

		public float m_MinLat;

		public float m_MaxLat;

		public ContourManager()
		{
			this.m_TriangleList = null;
			this.m_VertexManager = null;
			this.m_EdgeList = null;
			this.currentEdge = null;
		}

		public void SetParams(VertexManager vertexManager, System.Collections.Generic.List<Triangle> triangleList)
		{
			if (vertexManager != null && vertexManager.Points.Count != 0)
			{
				this.m_TriangleList = new System.Collections.Generic.List<TriangleWithEdge>(triangleList.Count);
				for (int i = 0; i < triangleList.Count; i++)
				{
					this.m_TriangleList.Add(new TriangleWithEdge(triangleList[i]));
				}
				if (triangleList != null && triangleList.Count != 0)
				{
					this.m_VertexManager = vertexManager;
					this.CreateEdges();
					this.CalculateRange();
				}
			}
		}

		public bool ReplaceVertexValue(System.Collections.Generic.List<float> newVal)
		{
			return this.ReplaceVertexValue(newVal.ToArray());
		}

		public bool ReplaceVertexValue(float[] newVal)
		{
			bool result;
			if (newVal.Length > this.m_VertexManager.Points.Count)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < newVal.Length; i++)
				{
					this.m_VertexManager.Points[i].m_VertexValue = newVal[i];
				}
				this.CalculateRange(newVal.Length);
				result = true;
			}
			return result;
		}

		public bool ReplaceVertexValue(System.Collections.Generic.List<double> newVal)
		{
			return this.ReplaceVertexValue(newVal.ToArray());
		}

		public bool ReplaceVertexValue(double[] newVal)
		{
			float[] newValF = new float[newVal.Length];
			for (int i = 0; i < newVal.Length; i++)
			{
				newValF[i] = (float)newVal[i];
			}
			this.ReplaceVertexValue(newValF);
			return true;
		}

		public bool Save(string saveFilePath, bool IsBinary)
		{
			bool result;
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(saveFilePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
				if (IsBinary)
				{
					System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
					this.Save(bw);
					bw.Close();
				}
				else
				{
					System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);
					this.Save(sw);
					sw.Close();
				}
				fs.Close();
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "保存等值线管理器错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		public bool Save(System.IO.StreamWriter sw)
		{
			bool result;
			if (sw == null)
			{
				result = false;
			}
			else if (!this.m_VertexManager.Save(sw))
			{
				result = false;
			}
			else
			{
				sw.WriteLine(this.m_EdgeList.Count.ToString());
				for (int i = 0; i < this.m_EdgeList.Count; i++)
				{
					if (!this.m_EdgeList[i].Save(sw))
					{
						result = false;
						return result;
					}
				}
				sw.WriteLine(this.m_TriangleList.Count.ToString());
				for (int i = 0; i < this.m_TriangleList.Count; i++)
				{
					if (!this.m_TriangleList[i].Save(sw))
					{
						result = false;
						return result;
					}
				}
				result = true;
			}
			return result;
		}

		public bool Save(System.IO.BinaryWriter bw)
		{
			bool result;
			if (bw == null)
			{
				result = false;
			}
			else if (!this.m_VertexManager.Save(bw))
			{
				result = false;
			}
			else
			{
				bw.Write(this.m_EdgeList.Count);
				for (int i = 0; i < this.m_EdgeList.Count; i++)
				{
					if (!this.m_EdgeList[i].Save(bw))
					{
						result = false;
						return result;
					}
				}
				bw.Write(this.m_TriangleList.Count);
				for (int i = 0; i < this.m_TriangleList.Count; i++)
				{
					if (!this.m_TriangleList[i].Save(bw))
					{
						result = false;
						return result;
					}
				}
				result = true;
			}
			return result;
		}

		public bool Load(string loadFilePath, bool IsBinary)
		{
			bool result;
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(loadFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				if (IsBinary)
				{
					System.IO.BinaryReader br = new System.IO.BinaryReader(fs);
					this.Load(br);
					br.Close();
				}
				else
				{
					System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
					this.Load(sr);
					sr.Close();
				}
				fs.Close();
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "读取等值线管理器错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		public bool Load(System.IO.StreamReader sr)
		{
			bool result;
			if (sr == null)
			{
				result = false;
			}
			else
			{
				this.m_VertexManager = new VertexManager();
				this.m_EdgeList = new System.Collections.Generic.List<Edge>();
				this.m_TriangleList = new System.Collections.Generic.List<TriangleWithEdge>();
				if (!this.m_VertexManager.Load(sr))
				{
					result = false;
				}
				else
				{
					int EdgeCount = System.Convert.ToInt32(sr.ReadLine());
					for (int i = 0; i < EdgeCount; i++)
					{
						Edge newEdge = new Edge();
						if (!newEdge.Load(sr))
						{
							result = false;
							return result;
						}
						newEdge.m_VertexManager = this.m_VertexManager;
						this.m_EdgeList.Add(newEdge);
					}
					int TriangleCount = System.Convert.ToInt32(sr.ReadLine());
					for (int i = 0; i < TriangleCount; i++)
					{
						TriangleWithEdge newTriangle = new TriangleWithEdge();
						if (!newTriangle.Load(sr))
						{
							result = false;
							return result;
						}
						newTriangle.m_VertexManager = this.m_VertexManager;
						newTriangle.m_EdgeList = this.m_EdgeList;
						this.m_TriangleList.Add(newTriangle);
					}
					this.CalculateRange();
					result = true;
				}
			}
			return result;
		}

		public bool Load(System.IO.BinaryReader br)
		{
			bool result;
			if (br == null)
			{
				result = false;
			}
			else
			{
				this.m_VertexManager = new VertexManager();
				this.m_EdgeList = new System.Collections.Generic.List<Edge>();
				this.m_TriangleList = new System.Collections.Generic.List<TriangleWithEdge>();
				if (!this.m_VertexManager.Load(br))
				{
					result = false;
				}
				else
				{
					int EdgeCount = br.ReadInt32();
					for (int i = 0; i < EdgeCount; i++)
					{
						Edge newEdge = new Edge();
						if (!newEdge.Load(br))
						{
							result = false;
							return result;
						}
						newEdge.m_VertexManager = this.m_VertexManager;
						this.m_EdgeList.Add(newEdge);
					}
					int TriangleCount = br.ReadInt32();
					for (int i = 0; i < TriangleCount; i++)
					{
						TriangleWithEdge newTriangle = new TriangleWithEdge();
						if (!newTriangle.Load(br))
						{
							result = false;
							return result;
						}
						newTriangle.m_VertexManager = this.m_VertexManager;
						newTriangle.m_EdgeList = this.m_EdgeList;
						this.m_TriangleList.Add(newTriangle);
					}
					this.CalculateRange();
					result = true;
				}
			}
			return result;
		}

		public CurveManager CreateContours(float BaseValue, float StepValue, bool WantSPL, int CurvewColorManager, System.Drawing.Color DefaultCurveColor, int FillwColorManager, System.Drawing.Color DefaultFillColor)
		{
			return this.CreateContours(BaseValue, StepValue, -999f, -999f, WantSPL, CurvewColorManager, DefaultCurveColor, FillwColorManager, DefaultFillColor);
		}

		public CurveManager CreateContours(float BaseValue, float StepValue, float MinValue, float MaxValue, bool WantSPL, int CurvewColorManager, System.Drawing.Color DefaultCurveColor, int FillwColorManager, System.Drawing.Color DefaultFillColor)
		{
			ColorManager colorManagerCurve = new ColorManager();
			ColorManager colorManagerFill = new ColorManager();
			if (MinValue == -999f || MaxValue == -999f)
			{
				float CurrentVal = BaseValue;
				if (CurrentVal > this.m_MinVal)
				{
					while (CurrentVal > this.m_MinVal)
					{
						CurrentVal -= StepValue;
					}
				}
				else
				{
					while (CurrentVal < this.m_MinVal)
					{
						CurrentVal += StepValue;
					}
				}
				CurrentVal += StepValue;
				colorManagerCurve.CreateColorItems(CurrentVal, this.m_MaxVal, StepValue, BaseValue, CurvewColorManager, DefaultCurveColor, 0, 255, 1);
				colorManagerFill.CreateColorItems(CurrentVal, this.m_MaxVal, StepValue, BaseValue, FillwColorManager, DefaultFillColor, 0, 255, 1);
			}
			else
			{
				float CurrentVal = BaseValue;
				if (CurrentVal > MinValue)
				{
					while (CurrentVal > MinValue)
					{
						CurrentVal -= StepValue;
					}
				}
				else
				{
					while (CurrentVal < MinValue)
					{
						CurrentVal += StepValue;
					}
				}
				CurrentVal += StepValue;
				colorManagerCurve.CreateColorItems(CurrentVal, this.m_MaxVal, StepValue, BaseValue, CurvewColorManager, DefaultCurveColor, 0, 255, 1);
				colorManagerFill.CreateColorItems(CurrentVal, this.m_MaxVal, StepValue, BaseValue, FillwColorManager, DefaultFillColor, 0, 255, 1);
			}
			return this.CreateContours(colorManagerCurve, colorManagerFill, WantSPL);
		}

		public CurveManager CreateContours(ColorManager colorManagerCurve, ColorManager colorManagerFill, bool WantSPL)
		{
			return this.SearchContours(colorManagerCurve, colorManagerFill, WantSPL);
		}

		public CurveManager CreateGridContours(float BaseValue, float StepValue, int RowNum, int ColNum, bool WantSPL, int CurvewColorManager, System.Drawing.Color DefaultCurveColor, int FillwColorManager, System.Drawing.Color DefaultFillColor)
		{
			return this.CreateGridContours(BaseValue, StepValue, -999f, -999f, RowNum, ColNum, WantSPL, CurvewColorManager, DefaultCurveColor, FillwColorManager, DefaultFillColor);
		}

		public CurveManager CreateGridContours(float BaseValue, float StepValue, float MinValue, float MaxValue, int RowNum, int ColNum, bool WantSPL, int CurvewColorManager, System.Drawing.Color DefaultCurveColor, int FillwColorManager, System.Drawing.Color DefaultFillColor)
		{
			ColorManager colorManagerCurve = new ColorManager();
			ColorManager colorManagerFill = new ColorManager();
			if (MinValue == -999f || MaxValue == -999f)
			{
				float CurrentVal = BaseValue;
				if (CurrentVal > this.m_MinVal)
				{
					while (CurrentVal > this.m_MinVal)
					{
						CurrentVal -= StepValue;
					}
				}
				else
				{
					while (CurrentVal < this.m_MinVal)
					{
						CurrentVal += StepValue;
					}
				}
				CurrentVal += StepValue;
				colorManagerCurve.CreateColorItems(CurrentVal, this.m_MaxVal, StepValue, BaseValue, CurvewColorManager, DefaultCurveColor, 0, 255, 1);
				colorManagerFill.CreateColorItems(CurrentVal, this.m_MaxVal, StepValue, BaseValue, FillwColorManager, DefaultFillColor, 0, 255, 1);
			}
			else
			{
				float CurrentVal = BaseValue;
				if (CurrentVal > MinValue)
				{
					while (CurrentVal > MinValue)
					{
						CurrentVal -= StepValue;
					}
				}
				else
				{
					while (CurrentVal < MinValue)
					{
						CurrentVal += StepValue;
					}
				}
				CurrentVal += StepValue;
				colorManagerCurve.CreateColorItems(CurrentVal, this.m_MaxVal, StepValue, BaseValue, CurvewColorManager, DefaultCurveColor, 0, 255, 1);
				colorManagerFill.CreateColorItems(CurrentVal, this.m_MaxVal, StepValue, BaseValue, FillwColorManager, DefaultFillColor, 0, 255, 1);
			}
			return this.CreateGridContours(RowNum, ColNum, colorManagerCurve, colorManagerFill, WantSPL);
		}

		public CurveManager CreateGridContours(int RowNum, int ColNum, ColorManager colorManagerCurve, ColorManager colorManagerFill, bool WantSPL)
		{
			CurveManager result;
			if (!this.CreateGridEdges(RowNum, ColNum))
			{
				result = null;
			}
			else
			{
				CurveManager curveManager = this.SearchContours(colorManagerCurve, colorManagerFill, WantSPL);
				curveManager.IsGridData = true;
				curveManager.GridDataSize = new System.Drawing.Size(ColNum, RowNum);
				double[] GridData = new double[this.m_VertexManager.Points.Count];
				for (int i = 0; i < GridData.Length; i++)
				{
					GridData[i] = (double)this.m_VertexManager.Points[i].m_VertexValue;
				}
				curveManager.GridData = GridData;
				result = curveManager;
			}
			return result;
		}

		public CurveManager CreateRegions(ColorManager colorManagerCurve, ColorManager colorManagerFill, bool WantSPL)
		{
			return this.SearchRegions(colorManagerCurve, colorManagerFill, WantSPL);
		}

		public void DrawEdge(System.Drawing.Graphics g, Projection p)
		{
			System.Drawing.Font font = new System.Drawing.Font("宋体", 10f);
			for (int i = 0; i < this.m_EdgeList.Count; i++)
			{
				Vertex V = this.m_EdgeList[i].Vertex1;
				Vertex V2 = this.m_EdgeList[i].Vertex2;
				System.Drawing.Point P = p.LonLat2XY(V.X, V.Y);
				System.Drawing.Point P2 = p.LonLat2XY(V2.X, V2.Y);
				g.DrawLine(new System.Drawing.Pen(System.Drawing.Color.Red), P, P2);
			}
		}

		public void DrawVertexAndTriangle(System.Drawing.Graphics g, Projection p, bool ShowVertex, bool ShowTriangle)
		{
			System.Drawing.Font myFont = new System.Drawing.Font("宋体", 10f);
			if (ShowTriangle)
			{
				System.Drawing.Pen trianglePen = new System.Drawing.Pen(System.Drawing.Color.Black, 1f);
				for (int i = 0; i < this.m_TriangleList.Count; i++)
				{
					Vertex V = this.m_TriangleList[i].GetVertex(0);
					Vertex V2 = this.m_TriangleList[i].GetVertex(1);
					Vertex V3 = this.m_TriangleList[i].GetVertex(2);
					System.Drawing.Point P = p.LonLat2XY(V.X, V.Y);
					System.Drawing.Point P2 = p.LonLat2XY(V2.X, V2.Y);
					System.Drawing.Point P3 = p.LonLat2XY(V3.X, V3.Y);
					g.DrawLine(trianglePen, P, P2);
					g.DrawLine(trianglePen, P, P3);
					g.DrawLine(trianglePen, P2, P3);
				}
			}
			if (ShowVertex)
			{
				System.Collections.Generic.List<VertexWithValue> m_VertexList = this.m_VertexManager.Points;
				g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
				System.Drawing.Pen vertexPen = new System.Drawing.Pen(System.Drawing.Color.Black, 2f);
				System.Drawing.SolidBrush vertexBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				System.Drawing.SolidBrush vertexTextBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
				System.Drawing.Font vertexTextFont = new System.Drawing.Font("宋体", 10f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
				System.Drawing.StringFormat vertexTextFormat = new System.Drawing.StringFormat();
				vertexTextFormat.LineAlignment = System.Drawing.StringAlignment.Center;
				vertexTextFormat.Alignment = System.Drawing.StringAlignment.Center;
				for (int i = 0; i < m_VertexList.Count; i++)
				{
					System.Drawing.Point XY = p.LonLat2XY(m_VertexList[i].X, m_VertexList[i].Y);
					g.FillEllipse(vertexBrush, new System.Drawing.RectangleF((float)(XY.X - 1), (float)(XY.Y - 1), 2f, 2f));
					g.DrawString(string.Format("{0:0.0}", m_VertexList[i].m_VertexValue), vertexTextFont, vertexBrush, (float)(XY.X + 1), (float)(XY.Y + 1), vertexTextFormat);
					g.DrawString(string.Format("{0:0.0}", m_VertexList[i].m_VertexValue), vertexTextFont, vertexTextBrush, XY, vertexTextFormat);
				}
			}
		}

		private CurveManager SearchContours(ColorManager colorManagerCurve, ColorManager colorManagerFill, bool WantSPL)
		{
			for (int i = 0; i < this.m_VertexManager.Points.Count; i++)
			{
				VertexWithValue thisVertex = this.m_VertexManager.Points[i];
				for (int j = 0; j < colorManagerCurve.m_ColorItems.Count; j++)
				{
					if ((double)System.Math.Abs(thisVertex.m_VertexValue - colorManagerCurve.m_ColorItems[j].myValue) <= 0.0001)
					{
						if (thisVertex.m_VertexValue == 0f)
						{
							thisVertex.m_VertexValue = 0.01f;
						}
						else
						{
							thisVertex.m_VertexValue += (float)System.Math.Abs((double)thisVertex.m_VertexValue * 0.001);
						}
					}
				}
			}
			CurveManager curveManager = new CurveManager();
			curveManager.m_ColorManagerCurve = colorManagerCurve;
			curveManager.m_ColorManagerFill = colorManagerFill;
			System.Collections.Generic.List<int> InnerEdgeIndeces = new System.Collections.Generic.List<int>(this.m_EdgeList.Count);
			System.Collections.Generic.List<int> OutterEdgeIndeces = new System.Collections.Generic.List<int>(this.m_EdgeList.Count / 10);
			for (int i = 0; i < this.m_EdgeList.Count; i++)
			{
				if (this.m_EdgeList[i].IsInnerEdge)
				{
					InnerEdgeIndeces.Add(i);
				}
				else
				{
					OutterEdgeIndeces.Add(i);
				}
			}
			InnerEdgeIndeces.TrimExcess();
			OutterEdgeIndeces.TrimExcess();
			ProgressForm pf = new ProgressForm();
			if (this.m_ShowProgress)
			{
				pf.Show();
				pf.SetProgressInfoText("正在进行数据处理，");
				pf.SetProgressRange(0, colorManagerCurve.m_ColorItems.Count * (OutterEdgeIndeces.Count + InnerEdgeIndeces.Count));
				pf.SetProgressPos(0, true);
				System.Windows.Forms.Application.DoEvents();
			}
			for (int i = 0; i < colorManagerCurve.m_ColorItems.Count; i++)
			{
				float thisContourValue = colorManagerCurve.m_ColorItems[i].myValue;
				for (int j = 0; j < this.m_EdgeList.Count; j++)
				{
					this.m_EdgeList[j].m_Used = false;
				}
				for (int j = 0; j < OutterEdgeIndeces.Count; j++)
				{
					if (this.m_ShowProgress)
					{
						if (j % 50 == 0)
						{
							pf.SetProgressPos(i * (OutterEdgeIndeces.Count + InnerEdgeIndeces.Count) + j, true);
							System.Windows.Forms.Application.DoEvents();
						}
					}
					this.currentEdge = this.m_EdgeList[OutterEdgeIndeces[j]];
					if (!this.currentEdge.m_Used)
					{
						if (this.currentEdge.ValueOnEdge(thisContourValue))
						{
							System.Collections.Generic.List<System.Drawing.PointF> VertexList = new System.Collections.Generic.List<System.Drawing.PointF>(128);
							while (true)
							{
								VertexList.Add(this.currentEdge.PointOnEdge(thisContourValue));
								bool Found = false;
								System.Collections.Generic.List<Edge> findEdge = this.FindOtherEdge(this.currentEdge);
								for (int k = 0; k < findEdge.Count; k++)
								{
									if (!findEdge[k].m_Used)
									{
										if (findEdge[k].ValueOnEdge(thisContourValue))
										{
											Found = true;
											this.currentEdge = findEdge[k];
											break;
										}
									}
								}
								if (!Found)
								{
									goto Block_15;
								}
								if (!this.currentEdge.IsInnerEdge)
								{
									goto Block_16;
								}
							}
							IL_39F:
							if (VertexList.Count > 3)
							{
								VertexList = this.CorrectVertexList(VertexList);
								curveManager.AddCurve(VertexList.ToArray(), i, i, false, WantSPL);
							}
							goto IL_3D1;
							Block_16:
							VertexList.Add(this.currentEdge.PointOnEdge(thisContourValue));
							goto IL_39F;
							Block_15:
							VertexList.Clear();
							goto IL_39F;
						}
					}
					IL_3D1:;
				}
				for (int j = 0; j < InnerEdgeIndeces.Count; j++)
				{
					if (this.m_ShowProgress)
					{
						if (j % 50 == 0)
						{
							pf.SetProgressPos(i * (OutterEdgeIndeces.Count + InnerEdgeIndeces.Count) + OutterEdgeIndeces.Count + j, true);
							System.Windows.Forms.Application.DoEvents();
						}
					}
					this.currentEdge = this.m_EdgeList[InnerEdgeIndeces[j]];
					if (!this.currentEdge.m_Used)
					{
						if (this.currentEdge.ValueOnEdge(thisContourValue))
						{
							System.Collections.Generic.List<System.Drawing.PointF> VertexList = new System.Collections.Generic.List<System.Drawing.PointF>(128);
							Edge startEdge = this.currentEdge;
							while (true)
							{
								VertexList.Add(this.currentEdge.PointOnEdge(thisContourValue));
								if (VertexList.Count == 3)
								{
									startEdge.m_Used = false;
								}
								bool Found = false;
								System.Collections.Generic.List<Edge> findEdge = this.FindOtherEdge(this.currentEdge);
								for (int k = 0; k < findEdge.Count; k++)
								{
									if (!findEdge[k].m_Used)
									{
										if (findEdge[k].ValueOnEdge(thisContourValue))
										{
											Found = true;
											this.currentEdge = findEdge[k];
											break;
										}
									}
								}
								if (!Found)
								{
									goto Block_26;
								}
								if (this.currentEdge.Equals(startEdge))
								{
									goto Block_27;
								}
							}
							IL_596:
							if (VertexList.Count > 3)
							{
								VertexList = this.CorrectVertexList(VertexList);
								curveManager.AddCurve(VertexList.ToArray(), i, i, true, WantSPL);
							}
							goto IL_5C8;
							Block_27:
							VertexList.Add(this.currentEdge.PointOnEdge(thisContourValue));
							goto IL_596;
							Block_26:
							VertexList.Clear();
							goto IL_596;
						}
					}
					IL_5C8:;
				}
			}
			if (this.m_ShowProgress)
			{
				pf.Close();
			}
			if (colorManagerCurve.m_ColorItems.Count > 1)
			{
				curveManager.CreateRelationship();
			}
			curveManager.CurveArea = new System.Drawing.RectangleF(this.m_MinLon, this.m_MinLat, this.m_MaxLon - this.m_MinLon, this.m_MaxLat - this.m_MinLat);
			return curveManager;
		}

		private CurveManager SearchRegions(ColorManager colorManagerCurve, ColorManager colorManagerFill, bool WantSPL)
		{
			CurveManager curveManager = new CurveManager();
			curveManager.m_ColorManagerCurve = colorManagerCurve;
			curveManager.m_ColorManagerFill = colorManagerFill;
			System.Collections.Generic.List<int> InnerEdgeIndeces = new System.Collections.Generic.List<int>(this.m_EdgeList.Count);
			for (int i = 0; i < this.m_EdgeList.Count; i++)
			{
				if (this.m_EdgeList[i].IsInnerEdge)
				{
					InnerEdgeIndeces.Add(i);
				}
			}
			InnerEdgeIndeces.TrimExcess();
			float[] VertexValOrg = new float[this.m_VertexManager.Points.Count];
			for (int i = 0; i < VertexValOrg.Length; i++)
			{
				VertexValOrg[i] = this.m_VertexManager.Points[i].m_VertexValue;
			}
			ProgressForm pf = new ProgressForm();
			pf.Show();
			pf.SetProgressInfoText("正在进行数据处理，");
			pf.SetProgressRange(0, colorManagerCurve.m_ColorItems.Count * InnerEdgeIndeces.Count);
			pf.SetProgressPos(0, true);
			System.Windows.Forms.Application.DoEvents();
			for (int i = 0; i < colorManagerCurve.m_ColorItems.Count; i++)
			{
				float thisRegionValueMin = colorManagerCurve.m_ColorItems[i].myValue;
				float thisRegionValueMax = colorManagerFill.m_ColorItems[i].myValue;
				for (int j = 0; j < VertexValOrg.Length; j++)
				{
					VertexWithValue thisVertex = this.m_VertexManager.Points[j];
					if (VertexValOrg[j] >= thisRegionValueMin && VertexValOrg[j] <= thisRegionValueMax)
					{
						thisVertex.m_VertexValue = 2f;
					}
					else
					{
						thisVertex.m_VertexValue = 0f;
					}
				}
				float thisContourValue = 1f;
				for (int j = 0; j < this.m_EdgeList.Count; j++)
				{
					this.m_EdgeList[j].m_Used = false;
				}
				for (int j = 0; j < InnerEdgeIndeces.Count; j++)
				{
					if (j % 50 == 0)
					{
						pf.SetProgressPos(i * InnerEdgeIndeces.Count + j, true);
						System.Windows.Forms.Application.DoEvents();
					}
					this.currentEdge = this.m_EdgeList[InnerEdgeIndeces[j]];
					if (!this.currentEdge.m_Used)
					{
						if (this.currentEdge.ValueOnEdge(thisContourValue))
						{
							System.Collections.Generic.List<System.Drawing.PointF> VertexList = new System.Collections.Generic.List<System.Drawing.PointF>(128);
							Edge startEdge = this.currentEdge;
							while (true)
							{
								VertexList.Add(this.currentEdge.PointOnEdge(thisContourValue));
								if (VertexList.Count == 3)
								{
									startEdge.m_Used = false;
								}
								bool Found = false;
								System.Collections.Generic.List<Edge> findEdge = this.FindOtherEdge(this.currentEdge);
								for (int k = 0; k < findEdge.Count; k++)
								{
									if (!findEdge[k].m_Used)
									{
										if (findEdge[k].ValueOnEdge(thisContourValue))
										{
											Found = true;
											this.currentEdge = findEdge[k];
											break;
										}
									}
								}
								if (!Found)
								{
									break;
								}
								if (this.currentEdge.Equals(startEdge))
								{
									goto Block_15;
								}
							}
							IL_351:
							if (VertexList.Count > 2)
							{
								curveManager.AddCurve(VertexList.ToArray(), i, i, true, WantSPL);
							}
							goto IL_379;
							Block_15:
							VertexList.Add(this.currentEdge.PointOnEdge(thisContourValue));
							goto IL_351;
						}
					}
					IL_379:;
				}
			}
			for (int j = 0; j < VertexValOrg.Length; j++)
			{
				VertexWithValue thisVertex = this.m_VertexManager.Points[j];
				thisVertex.m_VertexValue = VertexValOrg[j];
			}
			pf.SetProgressRange(0, curveManager.CurveNum);
			pf.SetProgressInfoText("正在绘图");
			pf.SetProgressPos(0, true);
			int l = 0;
			int pos = 0;
			while (pos < curveManager.CurveNum)
			{
				Curve curve = curveManager.Curves[pos];
				int count = 0;
				foreach (Vertex vertex in this.m_VertexManager.Points)
				{
					if (curve.PointInMe(new System.Drawing.PointF(vertex.X, vertex.Y)) != 0)
					{
						count++;
					}
				}
				if (count < 5)
				{
					curveManager.Curves.Remove(curve);
				}
				else
				{
					pos++;
				}
				pf.SetProgressPos(++l, true);
			}
			pf.Close();
			if (colorManagerCurve.m_ColorItems.Count > 1)
			{
				curveManager.CreateRelationship();
			}
			curveManager.CurveArea = new System.Drawing.RectangleF(this.m_MinLon, this.m_MinLat, this.m_MaxLon - this.m_MinLon, this.m_MaxLat - this.m_MinLat);
			return curveManager;
		}

		private bool CreateEdges()
		{
			bool result;
			if (this.m_TriangleList == null || this.m_TriangleList.Count == 0)
			{
				System.Windows.Forms.MessageBox.Show("三角形列表未设置或为空！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			else if (this.m_VertexManager == null || this.m_VertexManager.Points.Count == 0)
			{
				System.Windows.Forms.MessageBox.Show("节点管理器未设置或为空！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			else
			{
				System.Collections.Generic.Dictionary<int, int> seachEdgeList = new System.Collections.Generic.Dictionary<int, int>(this.m_TriangleList.Count * 3);
				this.m_EdgeList = new System.Collections.Generic.List<Edge>(this.m_TriangleList.Count * 3);
				for (int i = 0; i < this.m_TriangleList.Count; i++)
				{
					Edge newEdge = new Edge(this.m_VertexManager, this.m_TriangleList[i].GetVertexIndex(0), this.m_TriangleList[i].GetVertexIndex(1));
					int index = -1;
					if (seachEdgeList.TryGetValue(newEdge.HashID, out index))
					{
						this.m_EdgeList[index].SetTriangle(i);
					}
					else
					{
						newEdge.SetTriangle(i);
						this.m_EdgeList.Add(newEdge);
						index = this.m_EdgeList.Count - 1;
						seachEdgeList.Add(newEdge.HashID, index);
					}
					Edge newEdge2 = new Edge(this.m_VertexManager, this.m_TriangleList[i].GetVertexIndex(0), this.m_TriangleList[i].GetVertexIndex(2));
					int index2 = -1;
					if (seachEdgeList.TryGetValue(newEdge2.HashID, out index2))
					{
						this.m_EdgeList[index2].SetTriangle(i);
					}
					else
					{
						newEdge2.SetTriangle(i);
						this.m_EdgeList.Add(newEdge2);
						index2 = this.m_EdgeList.Count - 1;
						seachEdgeList.Add(newEdge2.HashID, index2);
					}
					Edge newEdge3 = new Edge(this.m_VertexManager, this.m_TriangleList[i].GetVertexIndex(1), this.m_TriangleList[i].GetVertexIndex(2));
					int index3 = -1;
					if (seachEdgeList.TryGetValue(newEdge3.HashID, out index3))
					{
						this.m_EdgeList[index3].SetTriangle(i);
					}
					else
					{
						newEdge3.SetTriangle(i);
						this.m_EdgeList.Add(newEdge3);
						index3 = this.m_EdgeList.Count - 1;
						seachEdgeList.Add(newEdge3.HashID, index3);
					}
					this.m_TriangleList[i].SetEdge(this.m_EdgeList, index, index2, index3);
				}
				for (int i = 0; i < this.m_EdgeList.Count; i++)
				{
					if (!this.m_EdgeList[i].IsInnerEdge)
					{
						this.m_EdgeList[i].Vertex1.m_IsOuterVertex = true;
						this.m_EdgeList[i].Vertex2.m_IsOuterVertex = true;
					}
				}
				result = true;
			}
			return result;
		}

		private bool CreateGridEdges(int RowNum, int ColNum)
		{
			bool result;
			if (this.m_TriangleList == null || this.m_TriangleList.Count == 0)
			{
				System.Windows.Forms.MessageBox.Show("三角形列表未设置或为空！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			else if (this.m_VertexManager == null || this.m_VertexManager.Points.Count == 0)
			{
				System.Windows.Forms.MessageBox.Show("节点管理器未设置或为空！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			else
			{
				this.m_EdgeList = new System.Collections.Generic.List<Edge>(this.m_TriangleList.Count * 3);
				for (int i = 0; i < RowNum; i++)
				{
					for (int j = 0; j < ColNum - 1; j++)
					{
						Edge newEdge = new Edge(this.m_VertexManager, i * ColNum + j, i * ColNum + j + 1);
						if (i == 0)
						{
							newEdge.SetTriangle(i * 2 * (ColNum - 1) + 2 * j);
						}
						else if (i == RowNum - 1)
						{
							newEdge.SetTriangle((i - 1) * 2 * (ColNum - 1) + 2 * j + 1);
						}
						else
						{
							newEdge.SetTriangle((i - 1) * 2 * (ColNum - 1) + 2 * j + 1);
							newEdge.SetTriangle(i * 2 * (ColNum - 1) + 2 * j);
						}
						this.m_EdgeList.Add(newEdge);
					}
				}
				for (int i = 0; i < RowNum - 1; i++)
				{
					for (int j = 0; j < ColNum; j++)
					{
						Edge newEdge = new Edge(this.m_VertexManager, i * ColNum + j, (i + 1) * ColNum + j);
						if (j == 0)
						{
							newEdge.SetTriangle(i * 2 * (ColNum - 1) + 2 * j);
						}
						else if (j == ColNum - 1)
						{
							newEdge.SetTriangle(i * 2 * (ColNum - 1) + 2 * j - 1);
						}
						else
						{
							newEdge.SetTriangle(i * 2 * (ColNum - 1) + 2 * j - 1);
							newEdge.SetTriangle(i * 2 * (ColNum - 1) + 2 * j);
						}
						this.m_EdgeList.Add(newEdge);
					}
				}
				for (int i = 0; i < RowNum - 1; i++)
				{
					for (int j = 0; j < ColNum - 1; j++)
					{
						Edge newEdge = new Edge(this.m_VertexManager, (i + 1) * ColNum + j, i * ColNum + j + 1);
						newEdge.SetTriangle(i * 2 * (ColNum - 1) + 2 * j);
						newEdge.SetTriangle(i * 2 * (ColNum - 1) + 2 * j + 1);
						this.m_EdgeList.Add(newEdge);
					}
				}
				int ID = 0;
				int H_EdgeNum = RowNum * (ColNum - 1);
				int S_EdgeNum = (RowNum - 1) * ColNum;
				for (int i = 0; i < RowNum - 1; i++)
				{
					for (int j = 0; j < ColNum - 1; j++)
					{
						this.m_TriangleList[ID].SetEdge(this.m_EdgeList, i * (ColNum - 1) + j, i * ColNum + j + H_EdgeNum, i * (ColNum - 1) + j + H_EdgeNum + S_EdgeNum);
						this.m_TriangleList[ID + 1].SetEdge(this.m_EdgeList, (i + 1) * (ColNum - 1) + j, i * ColNum + j + 1 + H_EdgeNum, i * (ColNum - 1) + j + H_EdgeNum + S_EdgeNum);
						ID += 2;
					}
				}
				result = true;
			}
			return result;
		}

		private bool BeloneToTheSameTriangle(Edge testEdge)
		{
			bool result;
			if (testEdge.Equals(this.currentEdge))
			{
				result = false;
			}
			else
			{
				if (testEdge.Triangle1 != -1)
				{
					if (testEdge.Triangle1 == this.currentEdge.Triangle1 || testEdge.Triangle1 == this.currentEdge.Triangle2)
					{
						result = true;
						return result;
					}
				}
				if (testEdge.Triangle2 != -1)
				{
					if (testEdge.Triangle2 == this.currentEdge.Triangle1 || testEdge.Triangle2 == this.currentEdge.Triangle2)
					{
						result = true;
						return result;
					}
				}
				result = false;
			}
			return result;
		}

		private System.Collections.Generic.List<Edge> FindOtherEdge(Edge testEdge)
		{
			System.Collections.Generic.List<Edge> EdgeList = new System.Collections.Generic.List<Edge>(4);
			if (testEdge.Triangle1 != -1)
			{
				TriangleWithEdge Triangle = this.m_TriangleList[testEdge.Triangle1];
				for (int i = 0; i < 3; i++)
				{
					Edge thisEdge = Triangle.GetEdge(i);
					if (thisEdge != testEdge)
					{
						EdgeList.Add(thisEdge);
					}
				}
			}
			if (testEdge.Triangle2 != -1)
			{
				TriangleWithEdge Triangle2 = this.m_TriangleList[testEdge.Triangle2];
				for (int i = 0; i < 3; i++)
				{
					Edge thisEdge = Triangle2.GetEdge(i);
					if (thisEdge != testEdge)
					{
						EdgeList.Add(thisEdge);
					}
				}
			}
			return EdgeList;
		}

		private System.Collections.Generic.List<System.Drawing.PointF> CorrectVertexList(System.Collections.Generic.List<System.Drawing.PointF> vertexList)
		{
			foreach (System.Drawing.PointF thisPoint in vertexList)
			{
				bool flag = 0 == 0;
				if (float.IsNaN(thisPoint.X) || float.IsNaN(thisPoint.Y))
				{
					vertexList.Remove(thisPoint);
				}
			}
			for (int i = 0; i < vertexList.Count - 2; i++)
			{
				float x = vertexList[i].X;
				float y = vertexList[i].Y;
				float x2 = vertexList[i + 1].X;
				float y2 = vertexList[i + 1].Y;
				float x3 = vertexList[i + 2].X;
				float y3 = vertexList[i + 2].Y;
				double dis = (double)((x2 - x) * (x2 - x) + (y2 - y) * (y2 - y));
				if (dis < 0.1)
				{
					vertexList.RemoveAt(i);
					i--;
				}
				else
				{
					double dis2 = (double)((x3 - x) * (x3 - x) + (y3 - y) * (y3 - y));
					if (dis2 < 0.1)
					{
						vertexList.RemoveAt(i + 1);
						i--;
					}
				}
			}
			return vertexList;
		}

		public void CalculateRange()
		{
			this.CalculateRange(this.m_VertexManager.Points.Count);
		}

		public void CalculateRange(int calLen)
		{
			if (calLen > this.m_VertexManager.Points.Count)
			{
				calLen = this.m_VertexManager.Points.Count;
			}
			this.m_MinVal = 3.40282347E+38f;
			this.m_MaxVal = -3.40282347E+38f;
			this.m_MinLon = 3.40282347E+38f;
			this.m_MaxLon = -3.40282347E+38f;
			this.m_MinLat = 3.40282347E+38f;
			this.m_MaxLat = -3.40282347E+38f;
			for (int i = 0; i < calLen; i++)
			{
				VertexWithValue thisVertex = this.m_VertexManager.Points[i];
				if (thisVertex.X < this.m_MinLon)
				{
					this.m_MinLon = thisVertex.X;
				}
				if (thisVertex.X > this.m_MaxLon)
				{
					this.m_MaxLon = thisVertex.X;
				}
				if (thisVertex.Y < this.m_MinLat)
				{
					this.m_MinLat = thisVertex.Y;
				}
				if (thisVertex.Y > this.m_MaxLat)
				{
					this.m_MaxLat = thisVertex.Y;
				}
				if (!thisVertex.m_IsOuterVertex)
				{
					if (this.m_MaxVal < thisVertex.m_VertexValue)
					{
						this.m_MaxVal = thisVertex.m_VertexValue;
					}
					if (this.m_MinVal > thisVertex.m_VertexValue)
					{
						this.m_MinVal = thisVertex.m_VertexValue;
					}
				}
			}
		}
	}
}
