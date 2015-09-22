using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using wMetroGIS.wTriangulation;

namespace wMetroGIS.wContour
{
	public class Edge
	{
		public bool m_Used = false;

		public VertexManager m_VertexManager = null;

		public int m_Vertex1 = -1;

		public int m_Vertex2 = -1;

		private int m_Triangle1 = -1;

		private int m_Triangle2 = -1;

		public VertexWithValue Vertex1
		{
			get
			{
				VertexWithValue result;
				if (this.m_VertexManager == null || this.m_VertexManager.PointNum <= 0)
				{
					result = null;
				}
				else
				{
					result = this.m_VertexManager.GetVertex(this.m_Vertex1);
				}
				return result;
			}
		}

		public VertexWithValue Vertex2
		{
			get
			{
				VertexWithValue result;
				if (this.m_VertexManager == null || this.m_VertexManager.PointNum <= 0)
				{
					result = null;
				}
				else
				{
					result = this.m_VertexManager.GetVertex(this.m_Vertex2);
				}
				return result;
			}
		}

		public int Triangle1
		{
			get
			{
				return this.m_Triangle1;
			}
		}

		public int Triangle2
		{
			get
			{
				return this.m_Triangle2;
			}
		}

		public bool IsInnerEdge
		{
			get
			{
				return this.m_Triangle1 != -1 && this.m_Triangle2 != -1;
			}
		}

		public int HashID
		{
			get
			{
				int result;
				if (this.m_VertexManager == null)
				{
					result = 0;
				}
				else
				{
					result = this.m_Vertex1 * this.m_VertexManager.Points.Count + this.m_Vertex2;
				}
				return result;
			}
		}

		public Edge()
		{
		}

		public Edge(VertexManager vertexManager, int Vertex1, int Vertex2)
		{
			this.m_VertexManager = vertexManager;
			this.m_Triangle1 = -1;
			this.m_Triangle2 = -1;
			this.m_Used = false;
			if (Vertex1 < Vertex2)
			{
				this.m_Vertex1 = Vertex1;
				this.m_Vertex2 = Vertex2;
			}
			else
			{
				this.m_Vertex2 = Vertex1;
				this.m_Vertex1 = Vertex2;
			}
		}

		public override bool Equals(object obj)
		{
			Edge e = (Edge)obj;
			return this.m_Vertex1 == e.m_Vertex1 && this.m_Vertex2 == e.m_Vertex2;
		}

		public override int GetHashCode()
		{
			return this.m_Vertex1 * 100000 + this.m_Vertex2;
		}

		public bool ValueOnEdge(float Value)
		{
			this.m_Used = true;
			return (this.Vertex1.m_VertexValue >= Value && this.Vertex2.m_VertexValue <= Value) || (this.Vertex2.m_VertexValue >= Value && this.Vertex1.m_VertexValue <= Value);
		}

		public void SetTriangle(int TriangleIndex)
		{
			if (TriangleIndex < 0)
			{
				System.Windows.Forms.MessageBox.Show("TriangleIndex<0 Error In SetTriangle!");
			}
			else if (this.m_Triangle1 == -1)
			{
				this.m_Triangle1 = TriangleIndex;
			}
			else if (this.m_Triangle2 == -1)
			{
				this.m_Triangle2 = TriangleIndex;
				if (this.m_Triangle2 < this.m_Triangle1)
				{
					int temp = this.m_Triangle1;
					this.m_Triangle1 = this.m_Triangle2;
					this.m_Triangle2 = temp;
				}
			}
		}

		public System.Drawing.PointF PointOnEdge(float Value)
		{
			System.Drawing.PointF result;
			if (!this.ValueOnEdge(Value))
			{
				result = System.Drawing.PointF.Empty;
			}
			else
			{
				float V = this.Vertex1.m_VertexValue;
				float V2 = this.Vertex2.m_VertexValue;
				float X = this.Vertex1.X;
				float X2 = this.Vertex2.X;
				float Y = this.Vertex1.Y;
				float Y2 = this.Vertex2.Y;
				result = new System.Drawing.PointF
				{
					X = X + (Value - V) / (V2 - V) * (X2 - X),
					Y = Y + (Value - V) / (V2 - V) * (Y2 - Y)
				};
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
				sw.WriteLine(string.Format("{0},{1},{2},{3}", new object[]
				{
					this.m_Vertex1,
					this.m_Vertex2,
					this.m_Triangle1,
					this.m_Triangle2
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
				bw.Write(this.m_Vertex1);
				bw.Write(this.m_Vertex2);
				bw.Write(this.m_Triangle1);
				bw.Write(this.m_Triangle2);
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
				this.m_Vertex1 = System.Convert.ToInt32(cell[0]);
				this.m_Vertex2 = System.Convert.ToInt32(cell[1]);
				this.m_Triangle1 = System.Convert.ToInt32(cell[2]);
				this.m_Triangle2 = System.Convert.ToInt32(cell[3]);
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
				this.m_Vertex1 = br.ReadInt32();
				this.m_Vertex2 = br.ReadInt32();
				this.m_Triangle1 = br.ReadInt32();
				this.m_Triangle2 = br.ReadInt32();
				result = true;
			}
			return result;
		}
	}
}
