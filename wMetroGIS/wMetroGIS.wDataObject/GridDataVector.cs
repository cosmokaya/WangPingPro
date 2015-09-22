using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using wMetroGIS.wDataReader;
using wMetroGIS.wMathmatics;

namespace wMetroGIS.wDataObject
{
	public class GridDataVector : GridDataObj
	{
		public double[] m_GridDataU;

		public double[] m_GridDataV;

		public double m_MaxU;

		public double m_MinU;

		public double m_MaxV;

		public double m_MinV;

		public GridDataVector()
		{
			this.m_DataType = GridDataObj.DATA_TYPE.TYPE_VECTOR;
		}

		public override void SetDataParams(double MinLon, double MaxLon, double MinLat, double MaxLat, double LonLatStep)
		{
			base.SetDataParams(MinLon, MaxLon, MinLat, MaxLat, LonLatStep);
			this.m_GridDataU = new double[this.m_RowNum * this.m_ColNum];
			this.m_GridDataV = new double[this.m_RowNum * this.m_ColNum];
			for (int i = 0; i < this.m_GridDataU.Length; i++)
			{
				this.m_GridDataU[i] = this.m_DefaultValue;
				this.m_GridDataV[i] = this.m_DefaultValue;
			}
		}

		public bool LoadData(double MinLon, double MaxLon, double MinLat, double MaxLat, double LonLatStep, double[] UDataVal, double[] VDataVal)
		{
			this.SetDataParams(MinLon, MaxLon, MinLat, MaxLat, LonLatStep);
			return this.LoadData(UDataVal, VDataVal);
		}

		public bool LoadData(double[] UDataVal, double[] VDataVal)
		{
			bool result;
			if (this.m_RowNum * this.m_ColNum != UDataVal.Length || this.m_RowNum * this.m_ColNum != VDataVal.Length)
			{
				System.Windows.Forms.MessageBox.Show("载入数据长度错误，数据载入失败！", "GridDataScalar错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			else
			{
				this.m_GridDataU = UDataVal;
				this.m_GridDataV = VDataVal;
				this.m_MinU = (this.m_MinV = 1.7976931348623157E+308);
				this.m_MaxU = (this.m_MaxV = -1.7976931348623157E+308);
				for (int i = 0; i < this.m_GridDataU.Length; i++)
				{
					if (this.m_GridDataU[i] != this.m_DefaultValue)
					{
						if (this.m_GridDataU[i] > this.m_MaxU)
						{
							this.m_MaxU = this.m_GridDataU[i];
						}
						else if (this.m_GridDataU[i] < this.m_MinU)
						{
							this.m_MinU = this.m_GridDataU[i];
						}
					}
					if (this.m_GridDataV[i] != this.m_DefaultValue)
					{
						if (this.m_GridDataV[i] > this.m_MaxV)
						{
							this.m_MaxV = this.m_GridDataV[i];
						}
						else if (this.m_GridDataV[i] < this.m_MinV)
						{
							this.m_MinV = this.m_GridDataV[i];
						}
					}
				}
				result = true;
			}
			return result;
		}

		public override bool LoadData(string DataPathU, string DataPathV)
		{
			bool result;
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(DataPathU, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.IO.StreamReader sr = new System.IO.StreamReader(fs);
				int FormatFlag = System.Convert.ToInt32(sr.ReadLine());
				if (FormatFlag != 0)
				{
					sr.Close();
					fs.Close();
					result = false;
					return result;
				}
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
						this.m_GridDataU[Pos++] = TempData[j];
						j++;
					}
					i++;
				}
				fs.Close();
				sr.Close();
				fs = new System.IO.FileStream(DataPathV, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				sr = new System.IO.StreamReader(fs);
				FormatFlag = System.Convert.ToInt32(sr.ReadLine());
				if (FormatFlag != 0)
				{
					sr.Close();
					fs.Close();
					result = false;
					return result;
				}
				GridSize = DataReader.String2DoubleData(sr.ReadLine());
				if (GridSize[0] != (double)this.m_RowNum || GridSize[1] != (double)this.m_ColNum)
				{
					System.Windows.Forms.MessageBox.Show("行列数不符合,请检查数据!");
					sr.Close();
					fs.Close();
					result = false;
					return result;
				}
				Pos = 0;
				i = 0;
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
						this.m_GridDataV[Pos++] = TempData[j];
						j++;
					}
					i++;
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
			this.m_MinU = (this.m_MinV = 1.7976931348623157E+308);
			this.m_MaxU = (this.m_MaxV = -1.7976931348623157E+308);
			for (int i = 0; i < this.m_GridDataU.Length; i++)
			{
				if (this.m_GridDataU[i] != this.m_DefaultValue)
				{
					if (this.m_GridDataU[i] > this.m_MaxU)
					{
						this.m_MaxU = this.m_GridDataU[i];
					}
					else if (this.m_GridDataU[i] < this.m_MinU)
					{
						this.m_MinU = this.m_GridDataU[i];
					}
				}
				if (this.m_GridDataV[i] != this.m_DefaultValue)
				{
					if (this.m_GridDataV[i] > this.m_MaxV)
					{
						this.m_MaxV = this.m_GridDataV[i];
					}
					else if (this.m_GridDataV[i] < this.m_MinV)
					{
						this.m_MinV = this.m_GridDataV[i];
					}
				}
			}
			result = base.LoadData(DataPathU, DataPathV);
			return result;
		}

		public override bool LoadData(string DataPath)
		{
			double Left = (double)base.m_DataRange.Left;
			double Right = (double)base.m_DataRange.Right;
			double Top = (double)base.m_DataRange.Bottom;
			double Bottom = (double)base.m_DataRange.Top;
			this.m_MaxU = (this.m_MinV = -1.7976931348623157E+308);
			this.m_MinU = (this.m_MinV = 1.7976931348623157E+308);
			bool result;
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(DataPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.IO.StreamReader sr = new System.IO.StreamReader(fs);
				int FormatFlag = System.Convert.ToInt32(sr.ReadLine());
				if (FormatFlag == 0)
				{
					sr.Close();
					fs.Close();
					result = false;
					return result;
				}
				if (FormatFlag == 1)
				{
					while (!sr.EndOfStream)
					{
						double[] TempData = DataReader.String2DoubleData(sr.ReadLine());
						if (TempData.Length != 4)
						{
							System.Windows.Forms.MessageBox.Show("数据格式错误!每行必须是四个数据,分别为经度 纬度 U数值 V数值!", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
							sr.Close();
							fs.Close();
							result = false;
							return result;
						}
						double Lon = TempData[0];
						double Lat = TempData[1];
						double ValueU = TempData[2];
						double ValueV = TempData[3];
						if (ValueU != this.m_DefaultValue && ValueV != this.m_DefaultValue)
						{
							int ii = System.Convert.ToInt32((Lat - this.m_MinLat) / this.m_LonLatStep);
							if (ii >= 0 && ii < this.m_RowNum)
							{
								int jj = System.Convert.ToInt32((Lon - this.m_MinLon) / this.m_LonLatStep);
								if (jj >= 0 && jj < this.m_ColNum)
								{
									this.m_GridDataU[ii * this.m_ColNum + jj] = ValueU;
									this.m_GridDataV[ii * this.m_ColNum + jj] = ValueV;
									if (ValueU > this.m_MaxU)
									{
										this.m_MaxU = ValueU;
									}
									else if (ValueU < this.m_MinU)
									{
										this.m_MinU = ValueU;
									}
									if (ValueV > this.m_MaxV)
									{
										this.m_MaxV = ValueV;
									}
									else if (ValueV < this.m_MinV)
									{
										this.m_MinV = ValueV;
									}
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
			result = base.LoadData(DataPath);
			return result;
		}

		public GridDataScalar GetModelData()
		{
			GridDataScalar result;
			if (this.m_GridDataU == null || this.m_GridDataV == null)
			{
				result = null;
			}
			else
			{
				double[] modelData = new double[this.m_GridDataU.Length];
				for (int i = 0; i < modelData.Length; i++)
				{
					if (this.m_GridDataU[i] == this.m_DefaultValue || this.m_GridDataV[i] == this.m_DefaultValue)
					{
						modelData[i] = this.m_DefaultValue;
					}
					else
					{
						modelData[i] = System.Convert.ToDouble(System.Math.Sqrt(this.m_GridDataU[i] * this.m_GridDataU[i] + this.m_GridDataV[i] * this.m_GridDataV[i]));
					}
				}
				GridDataScalar gds = new GridDataScalar();
				gds.SetDataParams(this.m_MinLon, this.m_MaxLon, this.m_MinLat, this.m_MaxLat, this.m_LonLatStep);
				gds.m_DefaultValue = this.m_DefaultValue;
				gds.LoadData(modelData);
				result = gds;
			}
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

		public System.Drawing.PointF GetData(int i, int j)
		{
			System.Drawing.PointF result;
			if (i < 0 || i >= base.m_GridSize.Height || j < 0 || j >= base.m_GridSize.Width)
			{
				result = System.Drawing.PointF.Empty;
			}
			else
			{
				result = new System.Drawing.PointF(System.Convert.ToSingle(this.m_GridDataU[i * base.m_GridSize.Width + j]), System.Convert.ToSingle(this.m_GridDataV[i * base.m_GridSize.Width + j]));
			}
			return result;
		}

		public System.Drawing.PointF GetData(double Lon, double Lat)
		{
			System.Drawing.PointF result;
			if (Lon < this.m_MinLon || Lon > this.m_MaxLon || Lat < this.m_MinLat || Lat > this.m_MaxLat)
			{
				result = System.Drawing.PointF.Empty;
			}
			else
			{
				int i = System.Convert.ToInt32((Lon - this.m_MinLon) / this.m_LonLatStep);
				int j = System.Convert.ToInt32((Lat - this.m_MinLat) / this.m_LonLatStep);
				result = this.GetData(j, i);
			}
			return result;
		}

		public System.Drawing.PointF GetDataBySPL(double Lon, double Lat)
		{
			System.Drawing.PointF result;
			if (Lon < this.m_MinLon || Lon > this.m_MaxLon || Lat < this.m_MinLat || Lat > this.m_MaxLat)
			{
				result = System.Drawing.PointF.Empty;
			}
			else
			{
				double U = Mathmatics.SLGQ(this.m_LatValue, this.m_LonValue, this.m_GridDataU, Lon, Lat);
				double V = Mathmatics.SLGQ(this.m_LatValue, this.m_LonValue, this.m_GridDataV, Lon, Lat);
				result = new System.Drawing.PointF((float)U, (float)V);
			}
			return result;
		}

		public GridDataVector GetSubData(double MinLon, double MaxLon, double MinLat, double MaxLat)
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
			GridDataVector newDataObj = new GridDataVector();
			newDataObj.SetDataParams(MinLon, MaxLon, MinLat, MaxLat, this.m_LonLatStep);
			double[] newDataU = new double[newDataObj.m_RowNum * newDataObj.m_ColNum];
			double[] newDataV = new double[newDataObj.m_RowNum * newDataObj.m_ColNum];
			for (int i = 0; i < newDataObj.m_RowNum; i++)
			{
				for (int j = 0; j < newDataObj.m_ColNum; j++)
				{
					System.Drawing.PointF thisLonLat = newDataObj.GetDataLonLat(i, j);
					double thisLon = (double)thisLonLat.X;
					double thisLat = (double)thisLonLat.Y;
					System.Drawing.PointF pt = this.GetData(thisLon, thisLat);
					newDataU[i * newDataObj.m_ColNum + j] = (double)pt.X;
					newDataV[i * newDataObj.m_ColNum + j] = (double)pt.Y;
				}
			}
			GridDataVector result;
			if (newDataObj.LoadData(newDataU, newDataV))
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
			GridDataVector gdv = new GridDataVector();
			gdv.m_MinLon = tmpLon[0];
			gdv.m_MaxLon = tmpLon[tmpLon.Count - 1];
			gdv.m_MinLat = tmpLat[0];
			gdv.m_MaxLat = tmpLat[tmpLat.Count - 1];
			gdv.m_LonLatStep = this.m_LonLatStep * (double)LonLatStepN;
			gdv.m_RowNum = tmpLat.Count;
			gdv.m_ColNum = tmpLon.Count;
			gdv.m_LonValue = tmpLon.ToArray();
			gdv.m_LatValue = tmpLat.ToArray();
			double[] newDataU = new double[gdv.m_GridSize.Height * gdv.m_GridSize.Width];
			double[] newDataV = new double[gdv.m_GridSize.Height * gdv.m_GridSize.Width];
			for (int i = 0; i < gdv.m_GridSize.Height; i++)
			{
				for (int j = 0; j < gdv.m_GridSize.Width; j++)
				{
					if (this.m_GridDataU[i * LonLatStepN * base.m_GridSize.Width + j * LonLatStepN] == this.m_DefaultValue || this.m_GridDataV[i * LonLatStepN * base.m_GridSize.Width + j * LonLatStepN] == this.m_DefaultValue)
					{
						newDataU[i * gdv.m_GridSize.Width + j] = this.m_DefaultValue;
						newDataV[i * gdv.m_GridSize.Width + j] = this.m_DefaultValue;
					}
					else
					{
						newDataU[i * gdv.m_GridSize.Width + j] = this.m_GridDataU[i * LonLatStepN * base.m_GridSize.Width + j * LonLatStepN];
						newDataV[i * gdv.m_GridSize.Width + j] = this.m_GridDataV[i * LonLatStepN * base.m_GridSize.Width + j * LonLatStepN];
					}
				}
			}
			gdv.m_DefaultValue = this.m_DefaultValue;
			gdv.LoadData(newDataU, newDataV);
			return gdv;
		}
	}
}
