using System;

namespace wMetroGIS.wTriangulation
{
	internal class Edge : System.IComparable
	{
		public int m_pV0;

		public int m_pV1;

		private VertexManager parent;

		public Edge(Edge e, VertexManager p)
		{
			this.m_pV0 = e.m_pV0;
			this.m_pV1 = e.m_pV1;
			this.parent = p;
		}

		public Edge(int pV0, int pV1, VertexManager p)
		{
			this.m_pV0 = pV0;
			this.m_pV1 = pV1;
			this.parent = p;
		}

		public bool LessThan(Edge e)
		{
			bool result;
			if (this.parent.GetVertex(this.m_pV0) == this.parent.GetVertex(e.m_pV0))
			{
				result = this.parent.GetVertex(this.m_pV1).LessThan(this.parent.GetVertex(e.m_pV1));
			}
			else
			{
				result = this.parent.GetVertex(this.m_pV0).LessThan(this.parent.GetVertex(e.m_pV0));
			}
			return result;
		}

		public virtual int CompareTo(object obj)
		{
			int result;
			if (this.LessThan((Edge)obj))
			{
				result = -1;
			}
			else if ((this.m_pV0 == ((Edge)obj).m_pV0 && this.m_pV1 == ((Edge)obj).m_pV1) || (this.m_pV0 == ((Edge)obj).m_pV1 && this.m_pV1 == ((Edge)obj).m_pV0))
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}
	}
}
