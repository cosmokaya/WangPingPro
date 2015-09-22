using System;
using System.Drawing;
using System.Windows.Forms;

namespace wMetroGIS.wTriangulation
{
	public class Triangle : System.IComparable, System.ICloneable
	{
		private const float REAL_EPSILON = 1.1920929E-07f;

		private const float sqrt3 = 1.73205078f;

		public VertexManager parent;

		private int[] m_Vertices;

		private System.Drawing.PointF m_Center;

		private float m_R;

		private float m_R2;

		public Triangle(Triangle tri, VertexManager p)
		{
			this.parent = p;
			this.m_Center = tri.m_Center;
			this.m_R = tri.m_R;
			this.m_R2 = tri.m_R2;
			this.m_Vertices = new int[]
			{
				tri.m_Vertices[0],
				tri.m_Vertices[1],
				tri.m_Vertices[2]
			};
		}

		public Triangle(int p0, int p1, int p2, VertexManager p)
		{
			this.parent = p;
			this.m_Vertices = new int[3];
			this.m_Vertices[0] = p0;
			this.m_Vertices[1] = p1;
			this.m_Vertices[2] = p2;
			this.SetCircumCircle();
		}

		public Triangle(int[] pV, VertexManager p)
		{
			this.parent = p;
			this.m_Vertices = new int[3];
			for (int i = 0; i < 3; i++)
			{
				this.m_Vertices[i] = pV[i];
			}
			this.SetCircumCircle();
		}

		public virtual int CompareTo(object obj)
		{
			int result;
			if (this < (Triangle)obj)
			{
				result = -1;
			}
			else
			{
				result = 1;
			}
			return result;
		}

		public virtual object Clone()
		{
			return new Triangle(this, this.parent);
		}

		public Vertex GetVertex(int Index)
		{
			Vertex result;
			if (Index >= 0 && Index < 3)
			{
				result = this.parent.GetVertex(this.m_Vertices[Index]);
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("三角形序数不对");
				result = null;
			}
			return result;
		}

		public int GetVertexIndex(int Index)
		{
			int result;
			if (Index >= 0 && Index < 3)
			{
				result = this.m_Vertices[Index];
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("三角形序数不对");
				result = -1;
			}
			return result;
		}

		private void SetCircumCircle()
		{
			float x0 = this.parent.Points[this.m_Vertices[0]].X;
			float y0 = this.parent.Points[this.m_Vertices[0]].Y;
			float x = this.parent.Points[this.m_Vertices[1]].X;
			float y = this.parent.Points[this.m_Vertices[1]].Y;
			float x2 = this.parent.Points[this.m_Vertices[2]].X;
			float y2 = this.parent.Points[this.m_Vertices[2]].Y;
			float y3 = y - y0;
			float y4 = y2 - y;
			bool b21zero = y4 > -1.1920929E-07f && y4 < 1.1920929E-07f;
			if (y3 > -1.1920929E-07f && y3 < 1.1920929E-07f)
			{
				if (b21zero)
				{
					if (x > x0)
					{
						if (x2 > x)
						{
							x = x2;
						}
					}
					else if (x2 < x0)
					{
						x0 = x2;
					}
					this.m_Center.X = (x0 + x) * 0.5f;
					this.m_Center.Y = y0;
				}
				else
				{
					float m = -(x2 - x) / y4;
					float mx = (x + x2) * 0.5f;
					float my = (y + y2) * 0.5f;
					this.m_Center.X = (x0 + x) * 0.5f;
					this.m_Center.Y = m * (this.m_Center.X - mx) + my;
				}
			}
			else if (b21zero)
			{
				float m2 = -(x - x0) / y3;
				float mx2 = (x0 + x) * 0.5f;
				float my2 = (y0 + y) * 0.5f;
				this.m_Center.X = (x + x2) * 0.5f;
				this.m_Center.Y = m2 * (this.m_Center.X - mx2) + my2;
			}
			else
			{
				float m2 = -(x - x0) / y3;
				float m = -(x2 - x) / y4;
				float mx2 = (x0 + x) * 0.5f;
				float my2 = (y0 + y) * 0.5f;
				float mx = (x + x2) * 0.5f;
				float my = (y + y2) * 0.5f;
				this.m_Center.X = (m2 * mx2 - m * mx + my - my2) / (m2 - m);
				this.m_Center.Y = m2 * (this.m_Center.X - mx2) + my2;
			}
			float dx = x0 - this.m_Center.X;
			float dy = y0 - this.m_Center.Y;
			this.m_R2 = dx * dx + dy * dy;
			this.m_R = (float)System.Math.Sqrt((double)this.m_R2);
			this.m_R2 *= 1.000001f;
		}

		public bool CCEncompasses(Vertex itVertex)
		{
			System.Drawing.PointF dist = new System.Drawing.PointF(itVertex.GetPoint().X - this.m_Center.X, itVertex.GetPoint().Y - this.m_Center.Y);
			float dist2 = dist.X * dist.X + dist.Y * dist.Y;
			return dist2 <= this.m_R2;
		}

		public bool IsLeftOf(Vertex itVertex)
		{
			return itVertex.GetPoint().X > this.m_Center.X + this.m_R;
		}

		public static bool operator <(Triangle tri1, Triangle tri2)
		{
			bool result;
			if (tri1.m_Center.X == tri2.m_Center.X)
			{
				result = (tri1.m_Center.Y < tri2.m_Center.Y);
			}
			else
			{
				result = (tri1.m_Center.X < tri2.m_Center.X);
			}
			return result;
		}

		public static bool operator >(Triangle tri1, Triangle tri2)
		{
			return !(tri1 < tri2);
		}

		public int Contains(int PointIndex)
		{
			int result;
			if (PointIndex == this.m_Vertices[0])
			{
				result = 0;
			}
			else if (PointIndex == this.m_Vertices[1])
			{
				result = 1;
			}
			else if (PointIndex == this.m_Vertices[2])
			{
				result = 2;
			}
			else
			{
				result = -1;
			}
			return result;
		}
	}
}
