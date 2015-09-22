using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using wMetroGIS.wColorManager;
using wMetroGIS.wCurve;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wLayers
{
	public class wAreaLayer : wBaseLayer
	{
		private CurveManager m_CurveManager;

		private System.Collections.Generic.List<string> m_CurveName;

		private System.Collections.Generic.List<System.Drawing.PointF> m_CurveNamePoint;

		public wAreaLayer()
		{
			this.layerName = "等值线图层";
			this.layerVisable = true;
		}

		public wAreaLayer(string layerName, bool isVisible)
		{
			this.layerName = layerName;
			this.layerVisable = isVisible;
		}

		public string[] String2Data(string Line)
		{
			System.Collections.Generic.List<string> Data = new System.Collections.Generic.List<string>();
			string[] TempCells = Line.Split(new char[]
			{
				',',
				' ',
				'\t'
			});
			for (int i = 0; i < TempCells.Length; i++)
			{
				if (TempCells[i] != "")
				{
					Data.Add(TempCells[i]);
				}
			}
			return Data.ToArray();
		}

		public bool LoadData(string DataPath)
		{
			bool result;
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(DataPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
				this.m_CurveName = new System.Collections.Generic.List<string>();
				this.m_CurveNamePoint = new System.Collections.Generic.List<System.Drawing.PointF>();
				this.m_CurveManager = new CurveManager();
				this.m_CurveManager.m_ColorManagerCurve.m_ColorItems.Add(new ColorItem(System.Drawing.Color.Red, 0f));
				this.m_CurveManager.m_ColorManagerFill.m_ColorItems.Add(new ColorItem(System.Drawing.Color.Red, 0f));
				while (!sr.EndOfStream)
				{
					string[] cells = this.String2Data(sr.ReadLine());
					int PointNum = System.Convert.ToInt32(cells[1]);
					this.m_CurveName.Add(cells[2]);
					System.Drawing.PointF[] CurvePoints = new System.Drawing.PointF[PointNum];
					float MinLon = 999f;
					float MinLat = 999f;
					float MaxLon = -999f;
					float MaxLat = -999f;
					for (int i = 0; i < PointNum; i++)
					{
						cells = this.String2Data(sr.ReadLine());
						CurvePoints[i] = new System.Drawing.PointF(System.Convert.ToSingle(cells[0]), System.Convert.ToSingle(cells[1]));
						if (CurvePoints[i].X < MinLon)
						{
							MinLon = CurvePoints[i].X;
						}
						else if (CurvePoints[i].X > MaxLon)
						{
							MaxLon = CurvePoints[i].X;
						}
						if (CurvePoints[i].Y < MinLat)
						{
							MinLat = CurvePoints[i].Y;
						}
						else if (CurvePoints[i].Y > MaxLat)
						{
							MaxLat = CurvePoints[i].Y;
						}
					}
					this.m_CurveManager.AddCurve(CurvePoints, 0, 0, true, true);
					this.m_CurveNamePoint.Add(new System.Drawing.PointF(MinLon + (MaxLon - MinLon) / 2f, MinLat + (MaxLat - MinLat) / 2f));
				}
				sr.Close();
				fs.Close();
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message);
				result = false;
				return result;
			}
			this.m_CurveManager.WantFill = true;
			this.m_CurveManager.ShowText = false;
			this.m_CurveManager.SetDefaultCurveStyle(2, System.Drawing.Drawing2D.DashStyle.Solid);
			for (int i = 0; i < this.m_CurveManager.CurveNum; i++)
			{
			}
			result = true;
			return result;
		}

		public override void Draw(System.Drawing.Graphics g, Projection p)
		{
			if (this.m_CurveManager != null && this.m_CurveManager.CurveNum != 0)
			{
				this.m_CurveManager.FillClosedArea(g, p);
				this.m_CurveManager.DrawCurves(g, p);
				System.Drawing.Font myFont = new System.Drawing.Font("黑体", 15f, System.Drawing.FontStyle.Bold);
				System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				for (int i = 0; i < this.m_CurveManager.CurveNum; i++)
				{
					System.Drawing.Point myPoint = p.LonLat2XY(this.m_CurveNamePoint[i].X, this.m_CurveNamePoint[i].Y);
					g.DrawString(this.m_CurveName[i], myFont, myBrush, myPoint);
				}
			}
		}
	}
}
