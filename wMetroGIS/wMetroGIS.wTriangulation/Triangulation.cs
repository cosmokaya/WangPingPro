using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
using wMetroGIS.Properties;
using wMetroGIS.wDataReader;

namespace wMetroGIS.wTriangulation
{
	public class Triangulation
	{
		private const float sqrt3 = 1.73205078f;

		public VertexManager vManager;

		private System.Collections.Generic.List<WorkNode> PointWorkSet;

		public VertexManager GetVertexManager()
		{
			return this.vManager;
		}

		public void TriangulateOld(System.Collections.Generic.List<VertexWithValue> vertices, System.Collections.Generic.List<Triangle> TriOutput)
		{
			if (vertices.Count >= 3)
			{
				if (TriOutput == null)
				{
					TriOutput = new System.Collections.Generic.List<Triangle>();
				}
				this.vManager = new VertexManager(vertices);
				this.PointWorkSet = new System.Collections.Generic.List<WorkNode>();
				for (int i = 0; i < this.vManager.PointNum; i++)
				{
					WorkNode wn = new WorkNode(i, this.vManager);
					this.PointWorkSet.Add(wn);
				}
				this.PointWorkSet.Sort();
				System.Collections.Generic.IEnumerator<WorkNode> itVertex = this.PointWorkSet.GetEnumerator();
				itVertex.MoveNext();
				float xMin = this.vManager.GetVertex(itVertex.Current.Index).X;
				float yMin = this.vManager.GetVertex(itVertex.Current.Index).Y;
				float xMax = xMin;
				float yMax = yMin;
				while (itVertex.MoveNext())
				{
					xMax = this.vManager.GetVertex(itVertex.Current.Index).X;
					float y = this.vManager.GetVertex(itVertex.Current.Index).Y;
					if (y < yMin)
					{
						yMin = y;
					}
					if (y > yMax)
					{
						yMax = y;
					}
				}
				float dx = xMax - xMin;
				float dy = yMax - yMin;
				float ddx = dx * 0.01f;
				float ddy = dy * 0.01f;
				xMin -= ddx;
				xMax += ddx;
				dx += 2f * ddx;
				yMin -= ddy;
				yMax += ddy;
				dy += 2f * ddy;
				VertexWithValue[] vSuper = new VertexWithValue[3];
				int[] iSuper = new int[3];
				vSuper[0] = new VertexWithValue(xMin - dy * 1.73205078f / 3f, yMin);
				this.vManager.AddVertex(vSuper[0]);
				iSuper[0] = this.vManager.Points.Count - 1;
				vSuper[1] = new VertexWithValue(xMax + dy * 1.73205078f / 3f, yMin);
				this.vManager.AddVertex(vSuper[1]);
				iSuper[1] = this.vManager.Points.Count - 1;
				vSuper[2] = new VertexWithValue((xMin + xMax) * 0.5f, yMax + dx * 1.73205078f * 0.5f);
				this.vManager.AddVertex(vSuper[2]);
				iSuper[2] = this.vManager.Points.Count - 1;
				System.Collections.Generic.SortedList<Triangle, string> workset = new System.Collections.Generic.SortedList<Triangle, string>();
				workset.Add(new Triangle(iSuper[0], iSuper[1], iSuper[2], this.vManager), null);
				itVertex = this.PointWorkSet.GetEnumerator();
				int pos = 0;
				while (itVertex.MoveNext())
				{
					TriangleIsCompleted TestCompleted = new TriangleIsCompleted(itVertex.Current.Index, TriOutput, iSuper, this.vManager);
					for (int i = 0; i < workset.Count; i++)
					{
						if (TestCompleted.IsCompleted(workset.Keys[i]))
						{
							workset.RemoveAt(i);
							i--;
						}
					}
					System.Collections.Generic.SortedList<Edge, string> edges = new System.Collections.Generic.SortedList<Edge, string>();
					edges.Clear();
					VertexIsInCircumCircle IsInCircum = new VertexIsInCircumCircle(itVertex.Current.Index, edges, this.vManager);
					for (int j = 0; j < workset.Count; j++)
					{
						if (IsInCircum.IsInCircumCircle(workset.Keys[j]))
						{
							workset.RemoveAt(j);
							j--;
						}
					}
					for (int j = 0; j < edges.Count; j++)
					{
						workset.Add(new Triangle(edges.Keys[j].m_pV0, edges.Keys[j].m_pV1, itVertex.Current.Index, this.vManager), null);
					}
					pos++;
				}
				TriangleHasVertex TestTriangle = new TriangleHasVertex(iSuper, this.vManager);
				int LastVertexIndex = this.PointWorkSet[this.PointWorkSet.Count - 1].Index;
				System.Collections.Generic.List<Triangle> listTriContainLast = new System.Collections.Generic.List<Triangle>();
				for (int i = 0; i < workset.Count; i++)
				{
					Triangle t = workset.Keys[i];
					if (!TestTriangle.HasVertex(t))
					{
						TriOutput.Insert(0, workset.Keys[i]);
						workset.RemoveAt(i);
						i--;
					}
					else if (t.Contains(LastVertexIndex) != -1)
					{
						listTriContainLast.Add(t);
						workset.RemoveAt(i);
						i--;
					}
					else if ((t.Contains(iSuper[0]) != -1 && t.Contains(iSuper[1]) != -1) || (t.Contains(iSuper[0]) != -1 && t.Contains(iSuper[2]) != -1) || (t.Contains(iSuper[1]) != -1 && t.Contains(iSuper[2]) != -1))
					{
						workset.RemoveAt(i);
						i--;
					}
				}
				for (int i = 0; i < listTriContainLast.Count; i++)
				{
					int v;
					int v2;
					if (listTriContainLast[i].GetVertexIndex(0) == LastVertexIndex)
					{
						v = listTriContainLast[i].GetVertexIndex(1);
						v2 = listTriContainLast[i].GetVertexIndex(2);
					}
					else if (listTriContainLast[i].GetVertexIndex(1) == LastVertexIndex)
					{
						v = listTriContainLast[i].GetVertexIndex(0);
						v2 = listTriContainLast[i].GetVertexIndex(2);
					}
					else
					{
						v = listTriContainLast[i].GetVertexIndex(0);
						v2 = listTriContainLast[i].GetVertexIndex(1);
					}
					if ((v != iSuper[0] && v != iSuper[1] && v != iSuper[2]) || (v2 != iSuper[0] && v2 != iSuper[1] && v2 != iSuper[2]))
					{
						for (int j = 0; j < workset.Count; j++)
						{
							Triangle t = workset.Keys[j];
							int IndexV = t.Contains(v);
							int IndexV2 = t.Contains(v2);
							if (IndexV != -1 && IndexV2 != -1)
							{
								int index = (v == iSuper[0] || v == iSuper[1] || v == iSuper[2]) ? v2 : v;
								int index2 = t.GetVertexIndex(3 - (IndexV + IndexV2));
								for (int u = 0; u < TriOutput.Count; u++)
								{
									if (TriOutput[u].Contains(index) != -1 && TriOutput[u].Contains(index2) != -1)
									{
										int d = 3 - (TriOutput[u].Contains(index) + TriOutput[u].Contains(index2));
										if (!this.SameSide(this.vManager.GetVertex(index), this.vManager.GetVertex(index2), this.vManager.GetVertex(LastVertexIndex), TriOutput[u].GetVertex(d)))
										{
											TriOutput.Insert(0, new Triangle(index, index2, LastVertexIndex, this.vManager));
											break;
										}
									}
								}
							}
						}
					}
				}
				this.vManager.Points.RemoveAt(iSuper[0]);
				this.vManager.Points.RemoveAt(iSuper[0]);
				this.vManager.Points.RemoveAt(iSuper[0]);
			}
		}

		public void Triangulate(System.Collections.Generic.List<VertexWithValue> vertices, System.Collections.Generic.List<Triangle> TriOutput)
		{
			if (vertices.Count >= 3)
			{
				if (TriOutput == null)
				{
					TriOutput = new System.Collections.Generic.List<Triangle>();
				}
				this.vManager = new VertexManager(vertices);
				string QHullPath = System.Windows.Forms.Application.StartupPath + "\\QHull\\qdelaunay.exe";
				string CommandPath = System.Windows.Forms.Application.StartupPath + "\\QHull\\command.bat";
				if (!System.IO.File.Exists(QHullPath))
				{
					try
					{
						if (!System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(QHullPath)))
						{
							System.IO.Directory.CreateDirectory(System.IO.Path.GetDirectoryName(QHullPath));
						}
						System.IO.FileStream fs = new System.IO.FileStream(QHullPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
						System.IO.BinaryWriter bw = new System.IO.BinaryWriter(fs);
						bw.Write(Resources.qdelaunay);
						bw.Close();
						fs.Close();
					}
					catch (System.Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "生成QHull引擎错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
						return;
					}
				}
				try
				{
					System.IO.FileStream fs = new System.IO.FileStream(System.Windows.Forms.Application.StartupPath + "\\QHull\\input.dat", System.IO.FileMode.Create, System.IO.FileAccess.Write);
					System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);
					sw.WriteLine(string.Format("2 RBOX {0}", vertices.Count));
					sw.WriteLine(string.Format("{0}", vertices.Count));
					for (int i = 0; i < vertices.Count; i++)
					{
						sw.WriteLine(string.Format("{0} {1}", vertices[i].X, vertices[i].Y));
					}
					sw.Close();
					fs.Close();
					fs = new System.IO.FileStream(CommandPath, System.IO.FileMode.Create, System.IO.FileAccess.Write);
					sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);
					sw.WriteLine("qdelaunay <input.dat Qt i TO output.dat");
					sw.Close();
					fs.Close();
					System.Diagnostics.Process processQHull = new System.Diagnostics.Process();
					processQHull.StartInfo = new System.Diagnostics.ProcessStartInfo();
					processQHull.StartInfo.FileName = CommandPath;
					processQHull.StartInfo.CreateNoWindow = true;
					processQHull.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
					processQHull.StartInfo.WorkingDirectory = System.IO.Path.GetDirectoryName(QHullPath);
					processQHull.StartInfo.UseShellExecute = false;
					if (!processQHull.Start())
					{
						throw new System.Exception("无法启动QHull引擎！");
					}
					processQHull.WaitForExit();
					fs = new System.IO.FileStream(System.Windows.Forms.Application.StartupPath + "\\QHull\\output.dat", System.IO.FileMode.Open, System.IO.FileAccess.Read);
					System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
					int N = System.Convert.ToInt32(sr.ReadLine());
					for (int i = 0; i < N; i++)
					{
						int[] index = DataReader.String2Int32Data(sr.ReadLine());
						Triangle newTriangle = new Triangle(index, this.vManager);
						TriOutput.Add(newTriangle);
					}
					sr.Close();
					fs.Close();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message, "调用QHull引擎错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
			}
		}

		public void Triangulate(System.Collections.Generic.List<VertexWithValue> vertexList, int RowNum, int ColNum, System.Collections.Generic.List<Triangle> triangleListOut)
		{
			if (RowNum * ColNum != vertexList.Count)
			{
				System.Windows.Forms.MessageBox.Show("输入节点列表的个数与指定的行列数不符合!无法进行三角剖分!", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
			else
			{
				if (triangleListOut == null)
				{
					triangleListOut = new System.Collections.Generic.List<Triangle>(2 * (RowNum - 1) * ColNum);
				}
				this.vManager = new VertexManager(vertexList);
				for (int i = 0; i < RowNum - 1; i++)
				{
					for (int j = 0; j < ColNum - 1; j++)
					{
						int V = i * ColNum + j;
						int V2 = i * ColNum + j + 1;
						int V3 = (i + 1) * ColNum + j;
						int V4 = (i + 1) * ColNum + j + 1;
						Triangle newTriangle = new Triangle(V, V2, V3, this.vManager);
						Triangle newTriangle2 = new Triangle(V2, V3, V4, this.vManager);
						triangleListOut.Add(newTriangle);
						triangleListOut.Add(newTriangle2);
					}
				}
			}
		}

		private void HandleEdge(int p0, int p1, System.Collections.Generic.SortedList<Edge, string> edges)
		{
			int pV0;
			int pV;
			if (this.vManager.GetVertex(p0).LessThan(this.vManager.GetVertex(p1)))
			{
				pV0 = p0;
				pV = p1;
			}
			else
			{
				pV0 = p1;
				pV = p0;
			}
			edges.Add(new Edge(pV0, pV, this.vManager), null);
		}

		private bool SameSide(Vertex LineStartVertex, Vertex LineEndVertex, Vertex p1, Vertex p2)
		{
			float dx = LineEndVertex.X - LineStartVertex.X;
			float dy = LineEndVertex.Y - LineStartVertex.Y;
			float dx2 = p1.X - LineStartVertex.X;
			float dy2 = p1.Y - LineStartVertex.Y;
			float dx3 = p2.X - LineEndVertex.X;
			float dy3 = p2.Y - LineEndVertex.Y;
			return (dx * dy2 - dy * dx2) * (dx * dy3 - dy * dx3) > 0f;
		}

		private void TrianglesToEdges(System.Collections.Generic.SortedList<Triangle, string> triangles, System.Collections.Generic.SortedList<Edge, string> edges)
		{
			for (int i = 0; i < triangles.Count; i++)
			{
				Triangle it = triangles.Keys[i];
				this.HandleEdge(it.GetVertexIndex(0), it.GetVertexIndex(1), edges);
				this.HandleEdge(it.GetVertexIndex(1), it.GetVertexIndex(2), edges);
				this.HandleEdge(it.GetVertexIndex(2), it.GetVertexIndex(0), edges);
			}
		}

		private System.Collections.Generic.List<Triangle> Zanshi(System.Collections.Generic.List<Triangle> OldTriangles, System.Collections.Generic.List<int> InvalidIndexs)
		{
			System.Collections.Generic.List<Triangle> result;
			if (InvalidIndexs == null || InvalidIndexs.Count == 0 || OldTriangles.Count == 0)
			{
				result = OldTriangles;
			}
			else
			{
				System.Collections.Generic.List<Triangle> NewTriangles = new System.Collections.Generic.List<Triangle>();
				for (int i = 0; i < OldTriangles.Count; i++)
				{
					NewTriangles.Add((Triangle)OldTriangles[i].Clone());
				}
				System.Collections.Generic.List<int> TriIndex = new System.Collections.Generic.List<int>();
				for (int i = 0; i < InvalidIndexs.Count; i++)
				{
					TriIndex.Clear();
					for (int j = 0; j < NewTriangles.Count; j++)
					{
						int Index = NewTriangles[j].Contains(InvalidIndexs[i]);
						if (Index != -1)
						{
							for (int k = 0; k < 3; k++)
							{
								if (Index != k && !TriIndex.Contains(NewTriangles[j].GetVertexIndex(k)))
								{
									int IndexInManager = NewTriangles[j].GetVertexIndex(k);
									TriIndex.Add(IndexInManager);
								}
							}
							NewTriangles.RemoveAt(j);
							j--;
						}
					}
					if (TriIndex.Count > 2)
					{
						if (TriIndex.Count == 3)
						{
							NewTriangles.Add(new Triangle(TriIndex[0], TriIndex[1], TriIndex[2], NewTriangles[0].parent));
						}
						else
						{
							Triangulation temp = new Triangulation();
							System.Collections.Generic.List<VertexWithValue> vList = new System.Collections.Generic.List<VertexWithValue>();
							System.Collections.Generic.List<int> listIndex = new System.Collections.Generic.List<int>();
							listIndex.Clear();
							for (i = 0; i < TriIndex.Count; i++)
							{
								vList.Add(OldTriangles[0].parent.GetVertex(TriIndex[i]));
								listIndex.Add(TriIndex[i]);
							}
							System.Collections.Generic.List<Triangle> u = new System.Collections.Generic.List<Triangle>();
							temp.Triangulate(vList, u);
							for (i = 0; i < u.Count; i++)
							{
								NewTriangles.Add(new Triangle(listIndex[u[i].GetVertexIndex(0)], listIndex[u[i].GetVertexIndex(1)], listIndex[u[i].GetVertexIndex(2)], NewTriangles[0].parent));
							}
						}
					}
				}
				result = NewTriangles;
			}
			return result;
		}
	}
}
