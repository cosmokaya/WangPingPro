using System;
using System.Collections.Generic;
using System.IO;
using wMetroGIS.wTriangulation;

namespace wMetroGIS.wContour
{
	public class TriangleWithEdge
	{
		public VertexManager m_VertexManager;

		public int[] m_VertexIndces = new int[3];

		public System.Collections.Generic.List<Edge> m_EdgeList;

		public int[] m_EdgeIndces = new int[3];

		public TriangleWithEdge()
		{
		}

		public TriangleWithEdge(Triangle tri)
		{
			this.m_VertexManager = tri.parent;
			this.m_VertexIndces = new int[]
			{
				tri.GetVertexIndex(0),
				tri.GetVertexIndex(1),
				tri.GetVertexIndex(2)
			};
		}

		public void SetEdge(System.Collections.Generic.List<Edge> EdgeList, int E1, int E2, int E3)
		{
			this.m_EdgeList = EdgeList;
			this.m_EdgeIndces = new int[]
			{
				E1,
				E2,
				E3
			};
		}

		public Vertex GetVertex(int Index)
		{
			Vertex result;
			if (Index >= 0 && Index <= 2)
			{
				result = this.m_VertexManager.Points[this.m_VertexIndces[Index]];
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int GetVertexIndex(int Index)
		{
			int result;
			if (Index >= 0 && Index <= 2)
			{
				result = this.m_VertexIndces[Index];
			}
			else
			{
				result = -1;
			}
			return result;
		}

		public Edge GetEdge(int Index)
		{
			Edge result;
			if (Index >= 0 && Index <= 2)
			{
				result = this.m_EdgeList[this.m_EdgeIndces[Index]];
			}
			else
			{
				result = null;
			}
			return result;
		}

		public int GetEdgeIndex(int Index)
		{
			int result;
			if (Index >= 0 && Index <= 2)
			{
				result = this.m_EdgeIndces[Index];
			}
			else
			{
				result = -1;
			}
			return result;
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
				sw.WriteLine(string.Format("{0},{1},{2},{3},{4},{5}", new object[]
				{
					this.m_VertexIndces[0],
					this.m_VertexIndces[1],
					this.m_VertexIndces[2],
					this.m_EdgeIndces[0],
					this.m_EdgeIndces[1],
					this.m_EdgeIndces[2]
				}));
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
				bw.Write(this.m_VertexIndces[0]);
				bw.Write(this.m_VertexIndces[1]);
				bw.Write(this.m_VertexIndces[2]);
				bw.Write(this.m_EdgeIndces[0]);
				bw.Write(this.m_EdgeIndces[1]);
				bw.Write(this.m_EdgeIndces[2]);
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
				string[] cell = sr.ReadLine().Split(new char[]
				{
					' ',
					',',
					'\t'
				});
				this.m_VertexIndces[0] = System.Convert.ToInt32(cell[0]);
				this.m_VertexIndces[1] = System.Convert.ToInt32(cell[1]);
				this.m_VertexIndces[2] = System.Convert.ToInt32(cell[2]);
				this.m_EdgeIndces[0] = System.Convert.ToInt32(cell[3]);
				this.m_EdgeIndces[1] = System.Convert.ToInt32(cell[4]);
				this.m_EdgeIndces[2] = System.Convert.ToInt32(cell[5]);
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
				this.m_VertexIndces[0] = br.ReadInt32();
				this.m_VertexIndces[1] = br.ReadInt32();
				this.m_VertexIndces[2] = br.ReadInt32();
				this.m_EdgeIndces[0] = br.ReadInt32();
				this.m_EdgeIndces[1] = br.ReadInt32();
				this.m_EdgeIndces[2] = br.ReadInt32();
				result = true;
			}
			return result;
		}
	}
}
