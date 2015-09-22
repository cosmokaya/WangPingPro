using System;
using System.Collections.Generic;
using System.IO;

namespace wMetroGIS.wTriangulation
{
	public class VertexManager
	{
		public System.Collections.Generic.List<VertexWithValue> Points = null;

		public int PointNum = 0;

		public VertexManager()
		{
		}

		public VertexManager(System.Collections.Generic.List<VertexWithValue> ps)
		{
			this.Points = ps;
			this.PointNum = ps.Count;
		}

		public VertexWithValue GetVertex(int index)
		{
			return this.Points[index];
		}

		public void AddVertex(VertexWithValue v)
		{
			this.Points.Add(v);
		}

		public bool Save(System.IO.StreamWriter sw)
		{
			bool result;
			if (sw == null)
			{
				result = false;
			}
			else
			{
				sw.WriteLine(this.Points.Count.ToString());
				for (int i = 0; i < this.Points.Count; i++)
				{
					sw.WriteLine(string.Format("{0},{1},{2},{3}", new object[]
					{
						this.Points[i].X,
						this.Points[i].Y,
						this.Points[i].m_IsOuterVertex,
						this.Points[i].m_VertexValue
					}));
				}
				result = true;
			}
			return result;
		}

		public bool Save(System.IO.BinaryWriter bw)
		{
			bool result;
			if (bw == null)
			{
				result = false;
			}
			else
			{
				bw.Write(this.Points.Count);
				for (int i = 0; i < this.Points.Count; i++)
				{
					bw.Write(this.Points[i].X);
					bw.Write(this.Points[i].Y);
					bw.Write(this.Points[i].m_IsOuterVertex);
					bw.Write(this.Points[i].m_VertexValue);
				}
				result = true;
			}
			return result;
		}

		public bool Load(System.IO.StreamReader sr)
		{
			bool result;
			if (sr == null)
			{
				result = false;
			}
			else
			{
				this.PointNum = System.Convert.ToInt32(sr.ReadLine());
				this.Points = new System.Collections.Generic.List<VertexWithValue>(this.PointNum);
				for (int i = 0; i < this.PointNum; i++)
				{
					string[] cell = sr.ReadLine().Split(new char[]
					{
						' ',
						',',
						'\t'
					});
					float X = System.Convert.ToSingle(cell[0]);
					float Y = System.Convert.ToSingle(cell[1]);
					bool isOuterVertex = System.Convert.ToBoolean(cell[2]);
					float vertexValue = System.Convert.ToSingle(cell[3]);
					VertexWithValue newVertex = new VertexWithValue(X, Y);
					newVertex.m_IsOuterVertex = isOuterVertex;
					newVertex.m_VertexValue = vertexValue;
					this.Points.Add(newVertex);
				}
				result = true;
			}
			return result;
		}

		public bool Load(System.IO.BinaryReader br)
		{
			bool result;
			if (br == null)
			{
				result = false;
			}
			else
			{
				this.PointNum = br.ReadInt32();
				this.Points = new System.Collections.Generic.List<VertexWithValue>(this.PointNum);
				for (int i = 0; i < this.PointNum; i++)
				{
					float X = br.ReadSingle();
					float Y = br.ReadSingle();
					bool isOuterVertex = br.ReadBoolean();
					float vertexValue = br.ReadSingle();
					VertexWithValue newVertex = new VertexWithValue(X, Y);
					newVertex.m_IsOuterVertex = isOuterVertex;
					newVertex.m_VertexValue = vertexValue;
					this.Points.Add(newVertex);
				}
				result = true;
			}
			return result;
		}
	}
}
