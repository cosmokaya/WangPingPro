using System;
using System.Collections.Generic;
using System.Drawing;

namespace wMetroGIS.wDataObject
{
	public class GridDataObj
	{
		public enum DATA_TYPE
		{
			TYPE_SCALAR,
			TYPE_VECTOR
		}

		public GridDataObj.DATA_TYPE m_DataType;

		public double m_MinLon;

		public double m_MaxLon;

		public double m_MinLat;

		public double m_MaxLat;

		public double m_LonLatStep;

		public int m_RowNum;

		public int m_ColNum;

		public double m_DefaultValue = -999.0;

		public double[] m_LonValue;

		public double[] m_LatValue;

		public System.Drawing.RectangleF m_DataRange
		{
			get
			{
				return new System.Drawing.RectangleF((float)this.m_MinLon, (float)this.m_MinLat, (float)(this.m_MaxLon - this.m_MinLon), (float)(this.m_MaxLat - this.m_MinLat));
			}
		}

		public System.Drawing.Size m_GridSize
		{
			get
			{
				return new System.Drawing.Size(this.m_ColNum, this.m_RowNum);
			}
		}

		public virtual void SetDataParams(double MinLon, double MaxLon, double MinLat, double MaxLat, double LonLatStep)
		{
			this.m_MinLon = MinLon;
			this.m_MaxLon = MaxLon;
			this.m_MinLat = MinLat;
			this.m_MaxLat = MaxLat;
			this.m_LonLatStep = LonLatStep;
			this.m_RowNum = System.Convert.ToInt32((MaxLat - MinLat) / LonLatStep) + 1;
			this.m_ColNum = System.Convert.ToInt32((MaxLon - MinLon) / LonLatStep) + 1;
			System.Collections.Generic.List<double> LatList = new System.Collections.Generic.List<double>();
			for (int i = 0; i < this.m_RowNum; i++)
			{
				LatList.Add(MinLat + (double)i * LonLatStep);
			}
			this.m_LatValue = LatList.ToArray();
			System.Collections.Generic.List<double> LonList = new System.Collections.Generic.List<double>();
			for (int i = 0; i < this.m_ColNum; i++)
			{
				LonList.Add(MinLon + (double)i * LonLatStep);
			}
			this.m_LonValue = LonList.ToArray();
		}

		public virtual bool LoadData(string DataPath)
		{
			return true;
		}

		public virtual bool LoadData(string DataPathU, string DataPathV)
		{
			return true;
		}

		public virtual GridDataObj CreateDataObj(int LonLatStepN)
		{
			return null;
		}
	}
}
