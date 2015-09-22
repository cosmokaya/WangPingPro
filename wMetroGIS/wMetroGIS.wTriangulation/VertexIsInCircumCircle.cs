using System;
using System.Collections.Generic;

namespace wMetroGIS.wTriangulation
{
	internal class VertexIsInCircumCircle
	{
		private int m_itVertex;

		private System.Collections.Generic.SortedList<Edge, string> m_Edges;

		private VertexManager parent;

		public VertexIsInCircumCircle(int itVertex, System.Collections.Generic.SortedList<Edge, string> edges, VertexManager p)
		{
			this.m_itVertex = itVertex;
			this.m_Edges = edges;
			this.parent = p;
		}

		public bool IsInCircumCircle(Triangle tri)
		{
			bool b = tri.CCEncompasses(this.parent.GetVertex(this.m_itVertex));
			if (b)
			{
				this.HandleEdge(tri.GetVertexIndex(0), tri.GetVertexIndex(1));
				this.HandleEdge(tri.GetVertexIndex(1), tri.GetVertexIndex(2));
				this.HandleEdge(tri.GetVertexIndex(2), tri.GetVertexIndex(0));
			}
			return b;
		}

		private void HandleEdge(int p0, int p1)
		{
			int pVertex0;
			int pVertex;
			if (this.parent.GetVertex(p0).LessThan(this.parent.GetVertex(p1)))
			{
				pVertex0 = p0;
				pVertex = p1;
			}
			else
			{
				pVertex0 = p1;
				pVertex = p0;
			}
			Edge e = new Edge(pVertex0, pVertex, this.parent);
			int found = this.m_Edges.IndexOfKey(e);
			if (found == -1)
			{
				this.m_Edges.Add(e, null);
			}
			else
			{
				this.m_Edges.RemoveAt(found);
			}
		}
	}
}
