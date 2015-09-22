using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using wMetroGIS.wColorManager;
using wMetroGIS.wCurve;
using wMetroGIS.wDataObject;

namespace wMetroGIS.wStreamline
{
	public class Streamline
	{
		private double[] u;

		private double[] v;

		private double long_start;

		private double lati_start;

		private double dx;

		private double dy;

		private int Is;

		private int Js;

		private double uund;

		private double vund;

		private double[] shdlvs;

		private int[] shdcls;

		private int shdcnt;

		private int den;

		public Streamline()
		{
			this.u = null;
			this.v = null;
			this.long_start = 0.0;
			this.lati_start = 0.0;
			this.dx = (this.dy = 0.0);
			this.Is = (this.Js = 0);
			this.uund = (this.vund = 0.0);
			this.shdlvs = null;
			this.shdcls = null;
			this.shdcnt = (this.den = 0);
		}

		public CurveManager CreateStreamlines(GridDataVector streamLineData, int streamLineDensity)
		{
			this.shdcls = new int[120];
			this.shdlvs = new double[120];
			this.shdcnt = 50;
			for (int index = 0; index < this.shdcnt; index++)
			{
				this.shdcls[index] = index;
				this.shdlvs[index] = (double)(index * 2);
			}
			this.den = streamLineDensity;
			this.u = streamLineData.m_GridDataU;
			this.v = streamLineData.m_GridDataV;
			this.Is = streamLineData.m_ColNum;
			this.Js = streamLineData.m_RowNum;
			this.uund = streamLineData.m_DefaultValue;
			this.vund = streamLineData.m_DefaultValue;
			this.long_start = streamLineData.m_MinLon;
			this.lati_start = streamLineData.m_MinLat;
			this.dx = streamLineData.m_LonLatStep;
			this.dy = streamLineData.m_LonLatStep;
			int icol = 1;
			int i = this.Is;
			if (this.Js > i)
			{
				i = this.Js;
			}
			int iscl = 200 / i;
			iscl = iscl + this.den - 5;
			if (iscl < 1)
			{
				iscl = 1;
			}
			if (iscl > 10)
			{
				iscl = 10;
			}
			double fact = 0.5 / (double)iscl;
			double rscl = (double)iscl;
			int iss = this.Is * iscl;
			int jss = this.Js * iscl;
			int siz = iss * jss;
			int[] it = new int[siz];
			CurveManager result;
			if (it == null)
			{
				System.Windows.Forms.MessageBox.Show("Cannot allocate memory for streamline function\n");
				result = null;
			}
			else
			{
				for (i = 0; i < siz; i++)
				{
					it[i] = 0;
				}
				CurveManager curveManager = new CurveManager();
				curveManager.m_ColorManagerCurve = new ColorManager();
				curveManager.m_ColorManagerFill = new ColorManager();
				curveManager.m_ColorManagerCurve.m_ColorItems.Add(new ColorItem(System.Drawing.Color.Red, 0f));
				curveManager.m_ColorManagerFill.m_ColorItems.Add(new ColorItem(System.Drawing.Color.Red, 0f));
				int i2 = 0;
				int j2 = 0;
				for (i = 0; i < siz; i++)
				{
					System.Collections.Generic.List<System.Drawing.PointF> StreamLinePoints = new System.Collections.Generic.List<System.Drawing.PointF>(512);
					int dis = 2;
					if (this.den < 5)
					{
						dis = 3;
					}
					if (this.den > 5)
					{
						dis = 1;
					}
					int imn = i2 - dis;
					int imx = i2 + dis + 1;
					int jmn = j2 - dis;
					int jmx = j2 + dis + 1;
					if (imn < 0)
					{
						imn = 0;
					}
					if (imx > iss)
					{
						imx = iss;
					}
					if (jmn < 0)
					{
						jmn = 0;
					}
					if (jmx > jss)
					{
						jmx = jss;
					}
					int iacc = 0;
					for (int jz = jmn; jz < jmx; jz++)
					{
						int ipt = jz * iss + imn;
						for (int iz = imn; iz < imx; iz++)
						{
							iacc += it[ipt];
							ipt++;
						}
					}
					if (iacc == 0)
					{
						double x = (double)i2 / rscl;
						double y = (double)j2 / rscl;
						double xsav = x;
						double ysav = y;
						StreamLinePoints.Add(new System.Drawing.PointF(System.Convert.ToSingle(this.long_start + x * this.dx), System.Convert.ToSingle(this.lati_start + y * this.dy)));
						int iisav = -999;
						iacc = 0;
						int bflg = 0;
						while (x >= 0.0 && x < (double)(this.Is - 1) && y >= 0.0 && y < (double)(this.Js - 1))
						{
							int ii = (int)x;
							int jj = (int)y;
							double xx = x - (double)ii;
							double yy = y - (double)jj;
							int tmp_int = jj * this.Is + ii;
							if (this.u[tmp_int] == this.uund || this.u[tmp_int + 1] == this.uund || this.u[tmp_int + this.Is] == this.uund || this.u[tmp_int + this.Is + 1] == this.uund)
							{
								break;
							}
							if (this.v[tmp_int] == this.vund || this.v[tmp_int + 1] == this.vund || this.v[tmp_int + this.Is] == this.vund || this.v[tmp_int + this.Is + 1] == this.vund)
							{
								break;
							}
							double uv = this.u[tmp_int] + (this.u[tmp_int + 1] - this.u[tmp_int]) * xx;
							double uv2 = this.u[tmp_int + this.Is] + (this.u[tmp_int + this.Is + 1] - this.u[tmp_int + this.Is]) * xx;
							double uv3 = uv + (uv2 - uv) * yy;
							double vv = this.v[tmp_int] + (this.v[tmp_int + 1] - this.v[tmp_int]) * xx;
							double vv2 = this.v[tmp_int + this.Is] + (this.v[tmp_int + this.Is + 1] - this.v[tmp_int + this.Is]) * xx;
							double vv3 = vv + (vv2 - vv) * yy;
							double auv = System.Math.Abs(uv3);
							double avv = System.Math.Abs(vv3);
							if (auv < 0.1 && avv < 0.1)
							{
								break;
							}
							if (auv > avv)
							{
								vv3 = vv3 * fact / auv;
								uv3 = uv3 * fact / auv;
							}
							else
							{
								uv3 = uv3 * fact / avv;
								vv3 = vv3 * fact / avv;
							}
							x += uv3;
							y += vv3;
							int ii2 = (int)(x * rscl);
							int ij = (int)(y * rscl);
							ii2 = ij * iss + ii2;
							if (ii2 < 0 || ii2 >= siz)
							{
								break;
							}
							if (it[ii2] == 1)
							{
								break;
							}
							if (ii2 != iisav && iisav > -1)
							{
								it[iisav] = 1;
							}
							if (ii2 == iisav)
							{
								iacc++;
							}
							else
							{
								iacc = 0;
							}
							if (iacc > 10)
							{
								break;
							}
							iisav = ii2;
							StreamLinePoints.Add(new System.Drawing.PointF(System.Convert.ToSingle(this.long_start + x * this.dx), System.Convert.ToSingle(this.lati_start + y * this.dy)));
							if (icol > -1)
							{
								if (bflg != 0)
								{
									bflg = 0;
								}
							}
							else
							{
								bflg = 1;
							}
						}
						bflg = 0;
						x = xsav;
						y = ysav;
						StreamLinePoints.Insert(0, new System.Drawing.PointF(System.Convert.ToSingle(this.long_start + x * this.dx), System.Convert.ToSingle(this.lati_start + y * this.dy)));
						iisav = -999;
						iacc = 0;
						while (x >= 0.0 && x < (double)(this.Is - 1) && y >= 0.0 && y < (double)(this.Js - 1))
						{
							int ii = (int)x;
							int jj = (int)y;
							double xx = x - (double)ii;
							double yy = y - (double)jj;
							int tmp_int = jj * this.Is + ii;
							if (this.u[tmp_int] == this.uund || this.u[tmp_int + 1] == this.uund || this.u[tmp_int + this.Is] == this.uund || this.u[tmp_int + this.Is + 1] == this.uund)
							{
								break;
							}
							if (this.v[tmp_int] == this.vund || this.v[tmp_int + 1] == this.vund || this.v[tmp_int + this.Is] == this.vund || this.v[tmp_int + this.Is + 1] == this.vund)
							{
								break;
							}
							double uv = this.u[tmp_int] + (this.u[tmp_int + 1] - this.u[tmp_int]) * xx;
							double uv2 = this.u[tmp_int + this.Is] + (this.u[tmp_int + this.Is + 1] - this.u[tmp_int + this.Is]) * xx;
							double uv3 = uv + (uv2 - uv) * yy;
							double vv = this.v[tmp_int] + (this.v[tmp_int + 1] - this.v[tmp_int]) * xx;
							double vv2 = this.v[tmp_int + this.Is] + (this.v[tmp_int + this.Is + 1] - this.v[tmp_int + this.Is]) * xx;
							double vv3 = vv + (vv2 - vv) * yy;
							double auv = System.Math.Abs(uv3);
							double avv = System.Math.Abs(vv3);
							if (auv < 0.1 && avv < 0.1)
							{
								break;
							}
							if (auv > avv)
							{
								vv3 = vv3 * fact / auv;
								uv3 = uv3 * fact / auv;
							}
							else
							{
								uv3 = uv3 * fact / avv;
								vv3 = vv3 * fact / avv;
							}
							x -= uv3;
							y -= vv3;
							int ii2 = (int)(x * rscl);
							int ij = (int)(y * rscl);
							ii2 = ij * iss + ii2;
							if (ii2 < 0 || ii2 >= siz)
							{
								break;
							}
							if (it[ii2] == 1)
							{
								break;
							}
							if (ii2 != iisav && iisav > -1)
							{
								it[iisav] = 1;
							}
							if (ii2 == iisav)
							{
								iacc++;
							}
							else
							{
								iacc = 0;
							}
							if (iacc > 10)
							{
								break;
							}
							iisav = ii2;
							StreamLinePoints.Insert(0, new System.Drawing.PointF(System.Convert.ToSingle(this.long_start + x * this.dx), System.Convert.ToSingle(this.lati_start + y * this.dy)));
							if (icol > -1)
							{
								if (bflg != 0)
								{
									bflg = 0;
								}
							}
							else
							{
								bflg = 1;
							}
						}
					}
					i2++;
					if (i2 == iss)
					{
						i2 = 0;
						j2++;
					}
					if (StreamLinePoints.Count > 3)
					{
						curveManager.AddCurve(StreamLinePoints.ToArray(), 0, 0, false, false);
					}
				}
				result = curveManager;
			}
			return result;
		}
	}
}
