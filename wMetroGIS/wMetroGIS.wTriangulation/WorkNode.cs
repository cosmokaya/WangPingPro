using System;

namespace wMetroGIS.wTriangulation
{
	internal class WorkNode : System.IComparable
	{
		public VertexManager parent;

		private int index;

		public int Index
		{
			get
			{
				return this.index;
			}
		}

		public WorkNode(int i, VertexManager p)
		{
			this.index = i;
			this.parent = p;
		}

		public Vertex GetVertex()
		{
			return this.parent.Points[this.index];
		}

		public virtual int CompareTo(object obj)
		{
			int result;
			if (this.parent.Points[this.index].LessThan(this.parent.Points[((WorkNode)obj).Index]))
			{
				result = -1;
			}
			else
			{
				result = 1;
			}
			return result;
		}
	}
}
