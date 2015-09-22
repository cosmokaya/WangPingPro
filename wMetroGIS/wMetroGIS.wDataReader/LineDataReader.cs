using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace wMetroGIS.wDataReader
{
	public class LineDataReader : DataReader
	{
		public static System.Collections.Generic.List<System.Drawing.PointF[]> ReadData(string filePath, bool isBinary = true)
		{
			System.Collections.Generic.List<System.Drawing.PointF[]> result;
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				if (isBinary)
				{
					System.IO.BinaryReader br = new System.IO.BinaryReader(fs, System.Text.Encoding.Default);
					System.Collections.Generic.List<System.Drawing.PointF[]> res = LineDataReader.ReadData(br);
					br.Close();
					fs.Close();
					result = res;
				}
				else
				{
					System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
					System.Collections.Generic.List<System.Drawing.PointF[]> res = LineDataReader.ReadData(sr);
					sr.Close();
					fs.Close();
					result = res;
				}
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "读取曲线数据错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = null;
			}
			return result;
		}

		public static System.Collections.Generic.List<System.Drawing.PointF[]> ReadData(System.IO.BinaryReader br)
		{
			System.Collections.Generic.List<System.Drawing.PointF[]> m_Lines = new System.Collections.Generic.List<System.Drawing.PointF[]>();
			while (br.PeekChar() != -1)
			{
				int PointNum = br.ReadInt32();
				System.Drawing.PointF[] pts = new System.Drawing.PointF[PointNum];
				for (int i = 0; i < PointNum; i++)
				{
					float X = br.ReadSingle();
					float Y = br.ReadSingle();
					pts[i] = new System.Drawing.PointF(X, Y);
				}
				m_Lines.Add(pts);
			}
			return m_Lines;
		}

		public static System.Collections.Generic.List<System.Drawing.PointF[]> ReadData(System.IO.StreamReader sr)
		{
			System.Collections.Generic.List<System.Drawing.PointF[]> m_Lines = new System.Collections.Generic.List<System.Drawing.PointF[]>();
			while (!sr.EndOfStream)
			{
				int PointNum = System.Convert.ToInt32(sr.ReadLine());
				System.Drawing.PointF[] pts = new System.Drawing.PointF[PointNum];
				for (int i = 0; i < PointNum; i++)
				{
					float[] tmpXY = DataReader.String2FloatData(sr.ReadLine());
					float X = tmpXY[0];
					float Y = tmpXY[1];
					pts[i] = new System.Drawing.PointF(X, Y);
				}
				m_Lines.Add(pts);
			}
			return m_Lines;
		}

		public static bool SaveData(string filePath, System.Collections.Generic.List<System.Drawing.PointF[]> lines, bool isBinary = true)
		{
			bool result;
			try
			{
				System.IO.FileStream fs = new System.IO.FileStream(filePath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
				if (isBinary)
				{
					System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs, System.Text.Encoding.Default);
					LineDataReader.WriteData(bw, lines);
					bw.Close();
					fs.Close();
					result = true;
				}
				else
				{
					System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);
					LineDataReader.WriteData(sw, lines);
					sw.Close();
					fs.Close();
					result = true;
				}
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "保存曲线数据错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		public static bool WriteData(System.IO.BinaryWriter bw, System.Collections.Generic.List<System.Drawing.PointF[]> lines)
		{
			for (int i = 0; i < lines.Count; i++)
			{
				System.Drawing.PointF[] line = lines[i];
				if (line != null && line.Length != 0)
				{
					bw.Write(line.Length);
					for (int j = 0; j < line.Length; j++)
					{
						bw.Write(line[j].X);
						bw.Write(line[j].Y);
					}
				}
			}
			return true;
		}

		public static bool WriteData(System.IO.StreamWriter sw, System.Collections.Generic.List<System.Drawing.PointF[]> lines)
		{
			for (int i = 0; i < lines.Count; i++)
			{
				System.Drawing.PointF[] line = lines[i];
				if (line != null && line.Length != 0)
				{
					sw.WriteLine(line.Length);
					for (int j = 0; j < line.Length; j++)
					{
						sw.WriteLine(string.Format("{0:000.0000},{1:000.0000}", line[j].X, line[j].Y));
					}
				}
			}
			return true;
		}
	}
}
