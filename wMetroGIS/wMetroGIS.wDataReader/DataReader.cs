using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace wMetroGIS.wDataReader
{
	public class DataReader
	{
		protected static char[] splitChars = new char[]
		{
			',',
			' ',
			'\t',
			';'
		};

		public static float[] String2FloatData(string Line)
		{
			System.Collections.Generic.List<float> Data = new System.Collections.Generic.List<float>();
			string[] TempCells = Line.Split(DataReader.splitChars, System.StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < TempCells.Length; i++)
			{
				if (TempCells[i] != "")
				{
					Data.Add(System.Convert.ToSingle(TempCells[i]));
				}
			}
			return Data.ToArray();
		}

		public static float[] String2FloatData(string Line, int SplitLen)
		{
			System.Collections.Generic.List<float> Data = new System.Collections.Generic.List<float>();
			for (int i = 0; i < Line.Length; i += SplitLen)
			{
				Data.Add(System.Convert.ToSingle(Line.Substring(i, SplitLen)));
			}
			return Data.ToArray();
		}

		public static double[] String2DoubleData(string Line)
		{
			System.Collections.Generic.List<double> Data = new System.Collections.Generic.List<double>();
			string[] TempCells = Line.Split(DataReader.splitChars, System.StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < TempCells.Length; i++)
			{
				if (TempCells[i] != "")
				{
					Data.Add(System.Convert.ToDouble(TempCells[i]));
				}
			}
			return Data.ToArray();
		}

		public static double[] String2DoubleData(string Line, int SplitLen)
		{
			System.Collections.Generic.List<double> Data = new System.Collections.Generic.List<double>();
			for (int i = 0; i < Line.Length; i += SplitLen)
			{
				Data.Add(System.Convert.ToDouble(Line.Substring(i, SplitLen)));
			}
			return Data.ToArray();
		}

		public static int[] String2Int32Data(string Line)
		{
			System.Collections.Generic.List<int> Data = new System.Collections.Generic.List<int>();
			string[] TempCells = Line.Split(DataReader.splitChars, System.StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < TempCells.Length; i++)
			{
				if (TempCells[i] != "")
				{
					Data.Add(System.Convert.ToInt32(TempCells[i]));
				}
			}
			return Data.ToArray();
		}

		public static int[] String2Int32Data(string Line, int SplitLen)
		{
			System.Collections.Generic.List<int> Data = new System.Collections.Generic.List<int>();
			for (int i = 0; i < Line.Length; i += SplitLen)
			{
				Data.Add(System.Convert.ToInt32(Line.Substring(i, SplitLen)));
			}
			return Data.ToArray();
		}

		public static string[] String2StringData(string Line)
		{
			System.Collections.Generic.List<string> Data = new System.Collections.Generic.List<string>();
			string[] TempCells = Line.Split(DataReader.splitChars, System.StringSplitOptions.RemoveEmptyEntries);
			for (int i = 0; i < TempCells.Length; i++)
			{
				if (TempCells[i] != "")
				{
					Data.Add(TempCells[i]);
				}
			}
			return Data.ToArray();
		}

		public static float[] ReadFloatBlockToFloat(System.IO.BinaryReader br, int RowNum, int ColNum)
		{
			float[] tempData = new float[RowNum * ColNum];
			byte[] tempBytes = new byte[4];
			for (int i = 0; i < tempData.Length; i++)
			{
				tempData[i] = br.ReadSingle();
			}
			return tempData;
		}

		public static float[] ReadFloatBlockToFloat(System.IO.StreamReader sr, int RowNum, int ColNum)
		{
			System.Collections.Generic.List<float> tempData = new System.Collections.Generic.List<float>(RowNum * ColNum);
			for (int i = 0; i < RowNum; i++)
			{
				float[] lineData = DataReader.String2FloatData(sr.ReadLine());
				if (lineData.Length != ColNum)
				{
					System.Windows.Forms.MessageBox.Show(string.Format("第{0}行数据的个数为{1}与列数{2}不符！", i, lineData.Length, ColNum));
				}
				for (int j = 0; j < ColNum; j++)
				{
					tempData.Add(lineData[j]);
				}
			}
			return tempData.ToArray();
		}

		public static double[] ReadFloatBlockToDouble(System.IO.BinaryReader br, int RowNum, int ColNum)
		{
			float[] floatData = DataReader.ReadFloatBlockToFloat(br, RowNum, ColNum);
			double[] result;
			if (floatData == null)
			{
				result = null;
			}
			else
			{
				double[] doubleData = new double[floatData.Length];
				for (int i = 0; i < doubleData.Length; i++)
				{
					doubleData[i] = (double)floatData[i];
				}
				result = doubleData;
			}
			return result;
		}

		public static double[] ReadFloatBlockToDouble(System.IO.StreamReader sr, int RowNum, int ColNum)
		{
			float[] floatData = DataReader.ReadFloatBlockToFloat(sr, RowNum, ColNum);
			double[] result;
			if (floatData == null)
			{
				result = null;
			}
			else
			{
				double[] doubleData = new double[floatData.Length];
				for (int i = 0; i < doubleData.Length; i++)
				{
					doubleData[i] = (double)floatData[i];
				}
				result = doubleData;
			}
			return result;
		}

		public static float[] ReadIntBlockToFloat(System.IO.BinaryReader br, int RowNum, int ColNum)
		{
			float[] tempData = new float[RowNum * ColNum];
			byte[] tempBytes = new byte[4];
			for (int i = 0; i < tempData.Length; i++)
			{
				tempData[i] = (float)br.ReadInt32();
			}
			return tempData;
		}

		public static double[] ReadIntBlockToDouble(System.IO.BinaryReader br, int RowNum, int ColNum)
		{
			double[] tempData = new double[RowNum * ColNum];
			for (int i = 0; i < tempData.Length; i++)
			{
				tempData[i] = (double)br.ReadInt32();
			}
			return tempData;
		}

		public static float[] ReadBigEndianFloatBlockToFloat(System.IO.BinaryReader br, int RowNum, int ColNum)
		{
			float[] tempData = new float[RowNum * ColNum];
			byte[] tempBytes = new byte[4];
			for (int i = 0; i < tempData.Length; i++)
			{
				tempData[i] = br.ReadSingle();
				byte[] bytes = System.BitConverter.GetBytes(tempData[i]);
				tempBytes[0] = bytes[3];
				tempBytes[1] = bytes[2];
				tempBytes[2] = bytes[1];
				tempBytes[3] = bytes[0];
				tempData[i] = System.BitConverter.ToSingle(tempBytes, 0);
			}
			return tempData;
		}

		public static float[] ReadBigEndianIntBlockToFloat(System.IO.BinaryReader br, int RowNum, int ColNum)
		{
			float[] tempData = new float[RowNum * ColNum];
			byte[] tempBytes = new byte[4];
			for (int i = 0; i < tempData.Length; i++)
			{
				int temp = br.ReadInt32();
				byte[] bytes = System.BitConverter.GetBytes(tempData[i]);
				tempBytes[0] = bytes[3];
				tempBytes[1] = bytes[2];
				tempBytes[2] = bytes[1];
				tempBytes[3] = bytes[0];
				tempData[i] = System.Convert.ToSingle(System.BitConverter.ToInt32(tempBytes, 0));
			}
			return tempData;
		}

		public static double[] ReadBigEndianFloatBlockToDouble(System.IO.BinaryReader br, int RowNum, int ColNum)
		{
			float[] floatData = DataReader.ReadBigEndianFloatBlockToFloat(br, RowNum, ColNum);
			double[] result;
			if (floatData == null)
			{
				result = null;
			}
			else
			{
				double[] doubleData = new double[floatData.Length];
				for (int i = 0; i < doubleData.Length; i++)
				{
					doubleData[i] = (double)floatData[i];
				}
				result = doubleData;
			}
			return result;
		}

		public static double[] ReadBigEndianIntBlockToDouble(System.IO.BinaryReader br, int RowNum, int ColNum)
		{
			float[] intData = DataReader.ReadBigEndianIntBlockToFloat(br, RowNum, ColNum);
			double[] result;
			if (intData == null)
			{
				result = null;
			}
			else
			{
				double[] doubleData = new double[intData.Length];
				for (int i = 0; i < doubleData.Length; i++)
				{
					doubleData[i] = (double)intData[i];
				}
				result = doubleData;
			}
			return result;
		}
	}
}
