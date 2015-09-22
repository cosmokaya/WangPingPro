using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace wMetroGIS.wMapMask
{
	public class wUserDefineMasker : wBaseMasker
	{
		public bool m_useTransparentColor = false;

		public System.Collections.Generic.List<System.Drawing.PointF[]> m_areaLines = new System.Collections.Generic.List<System.Drawing.PointF[]>();

		public wUserDefineMasker()
		{
			base.MaskerSize = System.Drawing.Size.Empty;
			base.MapProjection = null;
			base.TransparentColor = System.Drawing.Color.White;
		}

		public wUserDefineMasker(string dataPath, bool IsBinaryData)
		{
			base.MaskerSize = System.Drawing.Size.Empty;
			base.MapProjection = null;
			base.TransparentColor = System.Drawing.Color.White;
			if (IsBinaryData)
			{
				try
				{
					System.IO.FileStream fileStream = new System.IO.FileStream(dataPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
					System.IO.BinaryReader binReader = new System.IO.BinaryReader(fileStream, System.Text.Encoding.Default);
					while (binReader.PeekChar() != -1)
					{
						int PointNum = binReader.ReadInt32();
						System.Drawing.PointF[] LineData = new System.Drawing.PointF[PointNum];
						System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
						for (int i = 0; i < PointNum; i++)
						{
							float Lon = binReader.ReadSingle();
							float Lat = binReader.ReadSingle();
							LineData[i] = new System.Drawing.PointF(Lon, Lat);
						}
						this.m_areaLines.Add(LineData);
					}
					binReader.Close();
					fileStream.Close();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
			}
			else
			{
				try
				{
					System.IO.FileStream ms = new System.IO.FileStream(dataPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
					System.IO.StreamReader sr = new System.IO.StreamReader(ms, System.Text.Encoding.Default);
					while (!sr.EndOfStream)
					{
						int PointNum = System.Convert.ToInt32(sr.ReadLine());
						System.Drawing.PointF[] LineData = new System.Drawing.PointF[PointNum];
						for (int i = 0; i < PointNum; i++)
						{
							string[] lineData = sr.ReadLine().Split(new char[]
							{
								',',
								' ',
								'\t'
							});
							float Lon = System.Convert.ToSingle(lineData[0]);
							float Lat = System.Convert.ToSingle(lineData[1]);
							LineData[i] = new System.Drawing.PointF(Lon, Lat);
						}
						this.m_areaLines.Add(LineData);
					}
					sr.Close();
					ms.Close();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
			}
		}

		public wUserDefineMasker(System.Collections.Generic.List<System.Drawing.PointF[]> areaLines)
		{
			base.MaskerSize = System.Drawing.Size.Empty;
			base.MapProjection = null;
			base.TransparentColor = System.Drawing.Color.White;
			this.m_areaLines = areaLines;
		}

		public override System.Drawing.Region CreateRegion()
		{
			System.Drawing.Region result;
			if (this.m_areaLines == null || this.m_areaLines.Count == 0)
			{
				result = null;
			}
			else
			{
				System.Drawing.Region myRegion = new System.Drawing.Region();
				myRegion.MakeEmpty();
				for (int i = 0; i < this.m_areaLines.Count; i++)
				{
					System.Drawing.PointF[] thisLinePoint = this.m_areaLines[i];
					System.Drawing.Point[] LineData = new System.Drawing.Point[thisLinePoint.Length];
					for (int j = 0; j < thisLinePoint.Length; j++)
					{
						LineData[j] = base.MapProjection.LonLat2XY(thisLinePoint[j].X, thisLinePoint[j].Y);
					}
					System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
					path.AddLines(LineData);
					myRegion.Union(path);
				}
				result = myRegion;
			}
			return result;
		}

		public override System.Drawing.Bitmap CreateMasker()
		{
			System.Drawing.Color untransColor = System.Drawing.Color.Black;
			if (untransColor == base.TransparentColor)
			{
				untransColor = System.Drawing.Color.White;
			}
			System.Drawing.Bitmap bitmapMask = new System.Drawing.Bitmap(base.MaskerSize.Width, base.MaskerSize.Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bitmapMask);
			if (this.m_useTransparentColor)
			{
				g.FillRectangle(new System.Drawing.SolidBrush(untransColor), new System.Drawing.Rectangle(0, 0, bitmapMask.Width, bitmapMask.Height));
			}
			else
			{
				g.FillRectangle(new System.Drawing.SolidBrush(base.TransparentColor), new System.Drawing.Rectangle(0, 0, bitmapMask.Width, bitmapMask.Height));
			}
			for (int i = 0; i < this.m_areaLines.Count; i++)
			{
				int PointNum = this.m_areaLines[i].Length;
				System.Drawing.Point[] LineData = new System.Drawing.Point[PointNum];
				System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
				for (int j = 0; j < this.m_areaLines[i].Length; j++)
				{
					float Lon = this.m_areaLines[i][j].X;
					float Lat = this.m_areaLines[i][j].Y;
					LineData[j] = base.MapProjection.LonLat2XY(Lon, Lat);
				}
				path.AddLines(LineData);
				if (this.m_useTransparentColor)
				{
					g.FillPath(new System.Drawing.SolidBrush(base.TransparentColor), path);
				}
				else
				{
					g.FillPath(new System.Drawing.SolidBrush(untransColor), path);
				}
			}
			g.Dispose();
			bitmapMask.MakeTransparent(untransColor);
			return bitmapMask;
		}
	}
}
