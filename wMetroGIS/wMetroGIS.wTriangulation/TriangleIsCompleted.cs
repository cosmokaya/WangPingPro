using System;
using System.Collections.Generic;

namespace wMetroGIS.wTriangulation
{
	internal class TriangleIsCompleted
	{
		private int m_itVertex;

		private System.Collections.Generic.List<Triangle> m_Output;

		private int[] m_pSuperTriangle;

		private VertexManager parent;

		public TriangleIsCompleted(int itVertex, System.Collections.Generic.List<Triangle> output, int[] SuperTriangle, VertexManager p)
		{
			this.m_itVertex = itVertex;
			this.m_Output = output;
			this.m_pSuperTriangle = SuperTriangle;
			this.parent = p;
		}

		public bool IsCompleted(Triangle tri)
		{
			bool b = tri.IsLeftOf(this.parent.GetVertex(this.m_itVertex));
			if (b)
			{
				TriangleHasVertex thv = new TriangleHasVertex(this.m_pSuperTriangle, this.parent);
				if (!thv.HasVertex(tri))
				{
					this.m_Output.Add(tri);
				}
			}
			return b;
		}
	}
}
