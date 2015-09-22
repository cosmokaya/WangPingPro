using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using wMetroGIS.Properties;

namespace wMetroGIS.wParams
{
	public class MapLine
	{
		public System.Collections.Generic.List<System.Drawing.PointF[]> m_Lines = new System.Collections.Generic.List<System.Drawing.PointF[]>();

		public bool isValable
		{
			get
			{
				return this.m_Lines != null && this.m_Lines.Count != 0;
			}
		}

		public bool LoadDefaultData()
		{
			bool result;
			try
			{
				System.IO.MemoryStream ms = new System.IO.MemoryStream(Resources.World_Boundary);
				System.IO.BinaryReader br = new System.IO.BinaryReader(ms, System.Text.Encoding.Default);
				bool res = this.LoadData(br);
				br.Close();
				ms.Close();
				result = res;
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "读取默认边界数据错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		public bool LoadData(string dataPath)
		{
			bool result;
			try
			{
				System.IO.FileStream ms = new System.IO.FileStream(dataPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.IO.BinaryReader br = new System.IO.BinaryReader(ms, System.Text.Encoding.Default);
				bool res = this.LoadData(br);
				br.Close();
				ms.Close();
				result = res;
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "读取指定边界数据错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		public bool LoadData(System.IO.BinaryReader br)
		{
			this.m_Lines.Clear();
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
				this.m_Lines.Add(pts);
			}
			return true;
		}
	}
}
