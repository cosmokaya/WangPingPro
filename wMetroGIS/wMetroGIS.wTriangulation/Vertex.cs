using System;
using System.Drawing;

namespace wMetroGIS.wTriangulation
{
	public class Vertex : System.IComparable
	{
		private System.Drawing.PointF m_Pnt;

		public float X
		{
			get
			{
				return this.m_Pnt.X;
			}
			set
			{
				this.m_Pnt.X = value;
			}
		}

		public float Y
		{
			get
			{
				return this.m_Pnt.Y;
			}
			set
			{
				this.m_Pnt.Y = value;
			}
		}

		public Vertex()
		{
			this.m_Pnt = System.Drawing.PointF.Empty;
		}

		public Vertex(System.Drawing.PointF point)
		{
			this.m_Pnt = point;
		}

		public Vertex(Vertex vertex)
		{
			this.m_Pnt = vertex.m_Pnt;
		}

		public Vertex(float X, float Y)
		{
			this.m_Pnt = new System.Drawing.PointF(X, Y);
		}

		public Vertex(int X, int Y)
		{
			this.m_Pnt = new System.Drawing.PointF((float)X, (float)Y);
		}

		public bool LessThan(Vertex v)
		{
			bool result;
			if (this.m_Pnt.X == v.m_Pnt.X)
			{
				result = (this.m_Pnt.Y < v.m_Pnt.Y);
			}
			else
			{
				result = (this.m_Pnt.X < v.m_Pnt.X);
			}
			return result;
		}

		public override bool Equals(object obj)
		{
			Vertex v = (Vertex)obj;
			return (double)System.Math.Abs(this.m_Pnt.X - v.m_Pnt.X) < 0.001 && (double)System.Math.Abs(this.m_Pnt.Y - v.m_Pnt.Y) < 0.001;
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public virtual int CompareTo(object obj)
		{
			int result;
			if (this.LessThan((Vertex)obj))
			{
				result = -1;
			}
			else if (this.Equals(obj))
			{
				result = 0;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		public System.Drawing.PointF GetPoint()
		{
			return this.m_Pnt;
		}
	}
}
