using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using wMetroGIS.wDataReader;
using wMetroGIS.wMathmatics;

namespace wMetroGIS.wDataObject
{
	public class GridDataScalar : GridDataObj
	{
		public double[] m_GridData;

		public double m_MaxVal;

		public double m_MinVal;

		public GridDataScalar()
		{
			this.m_DataType = GridDataObj.DATA_TYPE.TYPE_SCALAR;
		}

		public override void SetDataParams(double MinLon, double MaxLon, double MinLat, double MaxLat, double LonLatStep)
		{
			base.SetDataParams(MinLon, MaxLon, MinLat, MaxLat, LonLatStep);
			this.m_GridData = new double[this.m_RowNum * this.m_ColNum];
			for (int i = 0; i < this.m_GridData.Length; i++)
			{
				this.m_GridData[i] = this.m_DefaultValue;
			}
		}

		public bool LoadData(double MinLon, double MaxLon, double MinLat, double MaxLat, double LonLatStep, double[] DataVal)
		{
			this.SetDataParams(MinLon, MaxLon, MinLat, MaxLat, LonLatStep);
			return this.LoadData(DataVal);
		}

		public bool LoadData(double[] DataVal)
		{
			bool result;
			if (this.m_RowNum * this.m_ColNum != DataVal.Length)
			{
				System.Windows.Forms.MessageBox.Show("载入数据长度错误，数据载入失败！", "GridDataScalar错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			else
			{
				this.m_GridData = DataVal;
				this.m_MinVal = 1.7976931348623157E+308;
				this.m_MaxVal = -1.7976931348623157E+308;
				bool dataValid = false;
				for (int i = 0; i < this.m_GridData.Length; i++)
				{
					if (this.m_GridData[i] != this.m_DefaultValue)
					{
						dataValid = true;
						if (this.m_GridData[i] > this.m_MaxVal)
						{
							this.m_MaxVal = this.m_GridData[i];
						}
						else if (this.m_GridData[i] < this.m_MinVal)
						{
							this.m_MinVal = this.m_GridData[i];
						}
					}
				}
				result = dataValid;
			}
			return result;
		}

		public override bool LoadData(string DataPath)
		{
			bool result;
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(DataPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.IO.StreamReader sr = new System.IO.StreamReader(fs);
				int FormatFlag = System.Convert.ToInt32(sr.ReadLine());
				if (FormatFlag == 0)
				{
					double[] GridSize = DataReader.String2DoubleData(sr.ReadLine());
					if (GridSize[0] != (double)this.m_RowNum || GridSize[1] != (double)this.m_ColNum)
					{
						System.Windows.Forms.MessageBox.Show("行列数不符合,请检查数据!");
						sr.Close();
						fs.Close();
						result = false;
						return result;
					}
					int Pos = 0;
					int i = 0;
					while ((double)i < GridSize[0])
					{
						double[] TempData = DataReader.String2DoubleData(sr.ReadLine());
						if ((double)TempData.Length != GridSize[1])
						{
							sr.Close();
							fs.Close();
							result = false;
							return result;
						}
						int j = 0;
						while ((double)j < GridSize[1])
						{
							this.m_GridData[Pos++] = TempData[j];
							j++;
						}
						i++;
					}
				}
				else
				{
					if (FormatFlag != 1)
					{
						sr.Close();
						fs.Close();
						result = false;
						return result;
					}
					while (!sr.EndOfStream)
					{
						double[] TempData = DataReader.String2DoubleData(sr.ReadLine());
						if (TempData.Length != 3)
						{
							System.Windows.Forms.MessageBox.Show("数据格式错误!每行必须是三个数据,分别为经度 纬度 数值!", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
							sr.Close();
							fs.Close();
							result = false;
							return result;
						}
						double Lon = TempData[0];
						double Lat = TempData[1];
						double Value = TempData[2];
						if (Value != this.m_DefaultValue)
						{
							int ii = System.Convert.ToInt32((Lat - this.m_MinLat) / this.m_LonLatStep);
							if (ii >= 0 && ii < this.m_RowNum)
							{
								int jj = System.Convert.ToInt32((Lon - this.m_MinLon) / this.m_LonLatStep);
								if (jj >= 0 && jj < this.m_ColNum)
								{
									this.m_GridData[ii * this.m_ColNum + jj] = Value;
								}
							}
						}
					}
				}
				fs.Close();
				sr.Close();
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
				return result;
			}
			this.m_MinVal = 1.7976931348623157E+308;
			this.m_MaxVal = -1.7976931348623157E+308;
			bool dataValid = false;
			for (int i = 0; i < this.m_GridData.Length; i++)
			{
				if (this.m_GridData[i] != this.m_DefaultValue)
				{
					dataValid = true;
					if (this.m_GridData[i] > this.m_MaxVal)
					{
						this.m_MaxVal = this.m_GridData[i];
					}
					else if (this.m_GridData[i] < this.m_MinVal)
					{
						this.m_MinVal = this.m_GridData[i];
					}
				}
			}
			result = dataValid;
			return result;
		}

		public System.Drawing.PointF GetDataLonLat(int i, int j)
		{
			System.Drawing.PointF result;
			if (i < 0 || i >= this.m_RowNum || j < 0 || j >= this.m_ColNum)
			{
				result = new System.Drawing.PointF(-999f, -999f);
			}
			else
			{
				result = new System.Drawing.PointF((float)this.m_LonValue[j], (float)this.m_LatValue[i]);
			}
			return result;
		}

		public double GetData(int i, int j)
		{
			double result;
			if (i < 0 || i >= base.m_GridSize.Height || j < 0 || j >= base.m_GridSize.Width)
			{
				result = this.m_DefaultValue;
			}
			else
			{
				result = this.m_GridData[i * base.m_GridSize.Width + j];
			}
			return result;
		}

		public double GetData(double Lon, double Lat)
		{
			int i = System.Convert.ToInt32((Lon - this.m_MinLon) / this.m_LonLatStep);
			int j = System.Convert.ToInt32((Lat - this.m_MinLat) / this.m_LonLatStep);
			return this.GetData(j, i);
		}

		public double GetDataBySPL(double Lon, double Lat)
		{
			double result;
			if (Lon < this.m_MinLon || Lon > this.m_MaxLon || Lat < this.m_MinLat || Lat > this.m_MaxLat)
			{
				result = this.m_DefaultValue;
			}
			else
			{
				result = Mathmatics.SLGQ(this.m_LatValue, this.m_LonValue, this.m_GridData, Lon, Lat);
			}
			return result;
		}

		public GridDataScalar GetSubData(double MinLon, double MaxLon, double MinLat, double MaxLat)
		{
			if (MinLon < this.m_MinLon)
			{
				MinLon = this.m_MinLon;
			}
			if (MaxLon > this.m_MaxLon)
			{
				MaxLon = this.m_MaxLon;
			}
			if (MinLat < this.m_MinLat)
			{
				MinLat = this.m_MinLat;
			}
			if (MaxLat > this.m_MaxLat)
			{
				MaxLat = this.m_MaxLat;
			}
			MaxLon += this.m_LonLatStep / 2.0;
			MaxLat += this.m_LonLatStep / 2.0;
			GridDataScalar newDataObj = new GridDataScalar();
			newDataObj.SetDataParams(MinLon, MaxLon, MinLat, MaxLat, this.m_LonLatStep);
			double[] newData = new double[newDataObj.m_RowNum * newDataObj.m_ColNum];
			for (int i = 0; i < newDataObj.m_RowNum; i++)
			{
				for (int j = 0; j < newDataObj.m_ColNum; j++)
				{
					System.Drawing.PointF thisLonLat = newDataObj.GetDataLonLat(i, j);
					double thisLon = (double)thisLonLat.X;
					double thisLat = (double)thisLonLat.Y;
					newData[i * newDataObj.m_ColNum + j] = this.GetData(thisLon, thisLat);
				}
			}
			GridDataScalar result;
			if (newDataObj.LoadData(newData))
			{
				result = newDataObj;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public override GridDataObj CreateDataObj(int LonLatStepN)
		{
			System.Collections.Generic.List<double> tmpLon = new System.Collections.Generic.List<double>();
			System.Collections.Generic.List<double> tmpLat = new System.Collections.Generic.List<double>();
			for (int i = 0; i < this.m_RowNum; i += LonLatStepN)
			{
				tmpLat.Add(this.m_LatValue[i]);
			}
			for (int i = 0; i < this.m_ColNum; i += LonLatStepN)
			{
				tmpLon.Add(this.m_LonValue[i]);
			}
			GridDataScalar gds = new GridDataScalar();
			gds.m_MinLon = tmpLon[0];
			gds.m_MaxLon = tmpLon[tmpLon.Count - 1];
			gds.m_MinLat = tmpLat[0];
			gds.m_MaxLat = tmpLat[tmpLat.Count - 1];
			gds.m_LonLatStep = this.m_LonLatStep * (double)LonLatStepN;
			gds.m_RowNum = tmpLat.Count;
			gds.m_ColNum = tmpLon.Count;
			gds.m_LonValue = tmpLon.ToArray();
			gds.m_LatValue = tmpLat.ToArray();
			double[] newData = new double[gds.m_GridSize.Height * gds.m_GridSize.Width];
			double[] newDataV = new double[gds.m_GridSize.Height * gds.m_GridSize.Width];
			for (int i = 0; i < gds.m_GridSize.Height; i++)
			{
				for (int j = 0; j < gds.m_GridSize.Width; j++)
				{
					if (this.m_GridData[i * LonLatStepN * base.m_GridSize.Width + j * LonLatStepN] == this.m_DefaultValue)
					{
						newData[i * gds.m_GridSize.Width + j] = this.m_DefaultValue;
					}
					else
					{
						newData[i * gds.m_GridSize.Width + j] = this.m_GridData[i * LonLatStepN * base.m_GridSize.Width + j * LonLatStepN];
					}
				}
			}
			gds.m_DefaultValue = this.m_DefaultValue;
			gds.LoadData(newData);
			return gds;
		}
	}
}
