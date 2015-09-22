using System;
using System.Collections.Generic;
using System.Drawing;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wMapMask
{
	public class wBaseMasker
	{
		private Projection m_MapProjection;

		private System.Drawing.Color m_TransparentColor;

		private System.Drawing.Size m_MaskerSize;

		public Projection MapProjection
		{
			get
			{
				return this.m_MapProjection;
			}
			set
			{
				this.m_MapProjection = value;
			}
		}

		public System.Drawing.Color TransparentColor
		{
			get
			{
				return this.m_TransparentColor;
			}
			set
			{
				this.m_TransparentColor = value;
			}
		}

		public System.Drawing.Size MaskerSize
		{
			get
			{
				return this.m_MaskerSize;
			}
			set
			{
				this.m_MaskerSize = value;
			}
		}

		public wBaseMasker()
		{
			this.m_MaskerSize = System.Drawing.Size.Empty;
			this.m_MapProjection = new Projection();
			this.m_TransparentColor = System.Drawing.Color.White;
		}

		public wBaseMasker(System.Drawing.Size maskerSize, Projection mapPrj, System.Drawing.Color transparentColor)
		{
			this.m_MaskerSize = maskerSize;
			this.m_MapProjection = mapPrj;
			this.m_TransparentColor = transparentColor;
		}

		public float[] String2Data(string Line)
		{
			System.Collections.Generic.List<float> Data = new System.Collections.Generic.List<float>();
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
					Data.Add(System.Convert.ToSingle(TempCells[i]));
				}
			}
			return Data.ToArray();
		}

		public virtual System.Drawing.Bitmap CreateMasker()
		{
			return null;
		}

		public virtual System.Drawing.Region CreateRegion()
		{
			return null;
		}

		public virtual System.Drawing.Bitmap CreateMasker(System.Drawing.Size maskerSize, Projection mapPrj, System.Drawing.Color transparentColor)
		{
			this.m_MaskerSize = maskerSize;
			this.m_MapProjection = mapPrj;
			this.m_TransparentColor = transparentColor;
			return this.CreateMasker();
		}

		public virtual System.Drawing.Region CreateRegion(Projection mapPrj)
		{
			this.m_MaskerSize = System.Drawing.Size.Empty;
			this.m_MapProjection = mapPrj;
			this.m_TransparentColor = System.Drawing.Color.White;
			return this.CreateRegion();
		}
	}
}
