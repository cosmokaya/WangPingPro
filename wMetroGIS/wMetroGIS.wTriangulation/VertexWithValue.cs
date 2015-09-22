using System;

namespace wMetroGIS.wTriangulation
{
	public class VertexWithValue : Vertex
	{
		public float m_VertexValue;

		public bool m_IsOuterVertex;

		public VertexWithValue()
		{
			this.m_VertexValue = 0f;
			this.m_IsOuterVertex = false;
		}

		public VertexWithValue(float X, float Y)
		{
			base.X = X;
			base.Y = Y;
		}
	}
}
