using System;

namespace wMetroGIS.wTriangulation
{
	internal class TriangleHasVertex
	{
		private int[] m_pSuperTriangle;

		private VertexManager parent;

		public TriangleHasVertex(int[] SuperTriangle, VertexManager p)
		{
			this.m_pSuperTriangle = SuperTriangle;
			this.parent = p;
		}

		public bool HasVertex(Triangle tri)
		{
			bool result;
			for (int i = 0; i < 3; i++)
			{
				Vertex v = tri.GetVertex(i);
				for (int j = 0; j < 3; j++)
				{
					if (v == this.parent.GetVertex(this.m_pSuperTriangle[j]))
					{
						result = true;
						return result;
					}
				}
			}
			result = false;
			return result;
		}
	}
}
