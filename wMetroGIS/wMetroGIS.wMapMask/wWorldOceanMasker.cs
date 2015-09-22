using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using wMetroGIS.Properties;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wMapMask
{
	public class wWorldOceanMasker : wBaseMasker
	{
		public wWorldOceanMasker()
		{
			base.MaskerSize = System.Drawing.Size.Empty;
			base.MapProjection = null;
			base.TransparentColor = System.Drawing.Color.White;
		}

		public wWorldOceanMasker(System.Drawing.Size maskerSize, Projection mapPrj, System.Drawing.Color transparentColor)
		{
			base.MaskerSize = maskerSize;
			base.MapProjection = mapPrj;
			base.TransparentColor = transparentColor;
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
			g.FillRectangle(new System.Drawing.SolidBrush(untransColor), new System.Drawing.Rectangle(0, 0, bitmapMask.Width, bitmapMask.Height));
			System.IO.MemoryStream ms = new System.IO.MemoryStream(Resources.World_Boundary);
			System.IO.BinaryReader br = new System.IO.BinaryReader(ms, System.Text.Encoding.Default);
			while (br.PeekChar() != -1)
			{
				int PointNum = br.ReadInt32();
				System.Drawing.Point[] LineData = new System.Drawing.Point[PointNum];
				System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
				for (int i = 0; i < PointNum; i++)
				{
					float Lon = br.ReadSingle();
					float Lat = br.ReadSingle();
					LineData[i] = base.MapProjection.LonLat2XY(Lon, Lat);
				}
				path.AddLines(LineData);
				g.FillPath(new System.Drawing.SolidBrush(base.TransparentColor), path);
			}
			br.Close();
			ms.Close();
			g.Dispose();
			bitmapMask.MakeTransparent(untransColor);
			return bitmapMask;
		}

		public override System.Drawing.Bitmap CreateMasker(System.Drawing.Size maskerSize, Projection mapPrj, System.Drawing.Color transparentColor)
		{
			base.MaskerSize = maskerSize;
			base.MapProjection = mapPrj;
			base.TransparentColor = transparentColor;
			return this.CreateMasker();
		}

		public override System.Drawing.Region CreateRegion()
		{
			System.Drawing.Region myRegion = new System.Drawing.Region();
			myRegion.MakeEmpty();
			System.IO.MemoryStream ms = new System.IO.MemoryStream(Resources.World_Boundary);
			System.IO.BinaryReader br = new System.IO.BinaryReader(ms, System.Text.Encoding.Default);
			while (br.PeekChar() != -1)
			{
				int PointNum = br.ReadInt32();
				System.Drawing.Point[] LineData = new System.Drawing.Point[PointNum];
				System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
				for (int i = 0; i < PointNum; i++)
				{
					float Lon = br.ReadSingle();
					float Lat = br.ReadSingle();
					LineData[i] = base.MapProjection.LonLat2XY(Lon, Lat);
				}
				path.AddLines(LineData);
				myRegion.Union(path);
			}
			br.Close();
			ms.Close();
			myRegion.Xor(new System.Drawing.Region());
			return myRegion;
		}
	}
}
