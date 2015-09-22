using System;
using System.Drawing;
using wMetroGIS.Properties;

namespace wMetroGIS.wColorManager
{
	public class ColorTable
	{
		private System.Drawing.Color[] m_ColorData;

		private int m_ColorID;

		public int ColorID
		{
			get
			{
				return this.m_ColorID;
			}
			set
			{
				this.m_ColorID = value;
			}
		}

		public ColorTable(int ColorID, System.Drawing.Color DefaultColor)
		{
			this.m_ColorData = new System.Drawing.Color[256];
			if (ColorID <= 0 || ColorID > 6)
			{
				for (int i = 0; i < 256; i++)
				{
					this.m_ColorData[i] = DefaultColor;
				}
				this.m_ColorID = 0;
			}
			else
			{
				byte[] colorData = null;
				if (ColorID == 1)
				{
					colorData = Resources.ColorTable1;
				}
				else if (ColorID == 2)
				{
					colorData = Resources.ColorTable2;
				}
				else if (ColorID == 3)
				{
					colorData = Resources.ColorTable3;
				}
				else if (ColorID == 4)
				{
					colorData = Resources.ColorTable4;
				}
				else if (ColorID == 5)
				{
					colorData = Resources.ColorTable5;
				}
				else if (ColorID == 6)
				{
					colorData = Resources.ColorTable6;
				}
				for (int i = 0; i < 256; i++)
				{
					int r = System.Convert.ToInt32(colorData[i * 4 + 2]);
					int g = System.Convert.ToInt32(colorData[i * 4 + 1]);
					int b = System.Convert.ToInt32(colorData[i * 4]);
					this.m_ColorData[i] = System.Drawing.Color.FromArgb(255, r, g, b);
				}
				this.m_ColorID = ColorID;
			}
		}

		public System.Drawing.Color GetColor(int N)
		{
			System.Drawing.Color result;
			if (N < 0)
			{
				result = this.m_ColorData[0];
			}
			else if (N >= this.m_ColorData.Length)
			{
				result = this.m_ColorData[this.m_ColorData.Length - 1];
			}
			else
			{
				result = this.m_ColorData[N];
			}
			return result;
		}
	}
}
