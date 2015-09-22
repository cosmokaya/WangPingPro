using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using wMetroGIS.Properties;
using wMetroGIS.wMathmatics;
using wMetroGIS.wParams;

namespace wMetroGIS.wTlnP
{
	public class wTlnPControl : System.Windows.Forms.UserControl
	{
		private const double minT1 = -85.0;

		private const double maxT1 = 40.0;

		private const double minT2 = 188.0;

		private const double maxT2 = 313.0;

		private const double minP1 = 200.0;

		private const double maxP1 = 1050.0;

		private const double minP2 = 50.0;

		private const double maxP2 = 262.5;

		private System.Drawing.Rectangle m_Rect = System.Drawing.Rectangle.Empty;

		private System.Drawing.Color m_PicBackColor = System.Drawing.Color.LightYellow;

		private string m_PicTitle = "温度压力对数图";

		private int m_BlankLeft = 50;

		private int m_BlankRight = 50;

		private int m_BlankTop = 50;

		private int m_BlankBottom = 30;

		private double minLnP1 = System.Math.Log(200.0);

		private double maxLnP1 = System.Math.Log(1050.0);

		private double minLnP2 = System.Math.Log(50.0);

		private double maxLnP2 = System.Math.Log(262.5);

		private System.Collections.Generic.List<double> m_DataP = new System.Collections.Generic.List<double>();

		private System.Collections.Generic.List<double> m_DataH = new System.Collections.Generic.List<double>();

		private System.Collections.Generic.List<double> m_DataT = new System.Collections.Generic.List<double>();

		private System.Collections.Generic.List<double> m_DataTd = new System.Collections.Generic.List<double>();

		private System.Collections.Generic.List<int> m_DataFs = new System.Collections.Generic.List<int>();

		private System.Collections.Generic.List<int> m_DataFx = new System.Collections.Generic.List<int>();

		private System.Collections.Generic.List<System.Drawing.PointF> m_DataZT = new System.Collections.Generic.List<System.Drawing.PointF>();

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.PictureBox pictureBox;

		private System.Windows.Forms.SaveFileDialog saveFileDialog;

		private System.Windows.Forms.ToolStrip toolStrip1;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		private System.Windows.Forms.ToolStripButton toolStripButton保存图片;

		private System.Windows.Forms.ToolStripButton toolStripButton重绘图片;

		private System.Windows.Forms.ToolStripButton toolStripButton查看数据;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		private System.Windows.Forms.ToolStripLabel toolStripLabelMousePos;

		private System.Windows.Forms.ToolStripButton toolStripButton显示层结曲线;

		private System.Windows.Forms.ToolStripButton toolStripButton显示正负能量区;

		private System.Windows.Forms.ToolStripButton toolStripButton显示状态曲线;

		private System.Windows.Forms.ToolStripButton toolStripButton显示等干绝热线;

		private System.Windows.Forms.ToolStripButton toolStripButton显示等湿绝热线;

		private System.Windows.Forms.ToolStripButton toolStripButton显示等饱和比湿热线;

		public System.Drawing.Color PicBackColor
		{
			get
			{
				return this.m_PicBackColor;
			}
			set
			{
				this.m_PicBackColor = value;
			}
		}

		public string PicTitle
		{
			get
			{
				return this.m_PicTitle;
			}
			set
			{
				this.m_PicTitle = value;
			}
		}

		public int BlankLeft
		{
			get
			{
				return this.m_BlankLeft;
			}
			set
			{
				this.m_BlankLeft = value;
			}
		}

		public int BlankRight
		{
			get
			{
				return this.m_BlankRight;
			}
			set
			{
				this.m_BlankRight = value;
			}
		}

		public int BlankTop
		{
			get
			{
				return this.m_BlankTop;
			}
			set
			{
				this.m_BlankTop = value;
			}
		}

		public int BlankBottom
		{
			get
			{
				return this.m_BlankBottom;
			}
			set
			{
				this.m_BlankBottom = value;
			}
		}

		public bool ShowSitaIsoLine
		{
			get
			{
				return this.toolStripButton显示等干绝热线.Checked;
			}
			set
			{
				this.toolStripButton显示等干绝热线.Checked = value;
			}
		}

		public bool ShowSitaSeIsoLine
		{
			get
			{
				return this.toolStripButton显示等湿绝热线.Checked;
			}
			set
			{
				this.toolStripButton显示等湿绝热线.Checked = value;
			}
		}

		public bool ShowQsIsoLine
		{
			get
			{
				return this.toolStripButton显示等饱和比湿热线.Checked;
			}
			set
			{
				this.toolStripButton显示等饱和比湿热线.Checked = value;
			}
		}

		public bool ShowEnageArea
		{
			get
			{
				return this.toolStripButton显示正负能量区.Checked;
			}
			set
			{
				this.toolStripButton显示正负能量区.Checked = value;
			}
		}

		public bool ShowCJLine
		{
			get
			{
				return this.toolStripButton显示层结曲线.Checked;
			}
			set
			{
				this.toolStripButton显示层结曲线.Checked = value;
			}
		}

		public bool ShowStatusLine
		{
			get
			{
				return this.toolStripButton显示状态曲线.Checked;
			}
			set
			{
				this.toolStripButton显示状态曲线.Checked = value;
			}
		}

		public wTlnPControl()
		{
			this.InitializeComponent();
		}

		public void CalculateData()
		{
			System.IO.FileStream fs = new System.IO.FileStream(System.Windows.Forms.Application.StartupPath + "\\Line_Sita.dat", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			System.IO.StreamWriter sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);
			for (int sita = -80; sita <= 130; sita += 5)
			{
				double T;
				double P2;
				double T2;
				if (sita < 30)
				{
					T = -85.0;
					double P = Mathmatics.get_P_from_SitaAndT((double)sita, T);
					P2 = 1050.0;
					T2 = Mathmatics.get_T_from_SitaAndP((double)sita, P2);
				}
				else if (sita >= 30 && sita < 40)
				{
					double P = 200.0;
					T = Mathmatics.get_T_from_SitaAndP((double)sita, P);
					P2 = 1050.0;
					T2 = Mathmatics.get_T_from_SitaAndP((double)sita, P2);
				}
				else
				{
					double P = 200.0;
					T = Mathmatics.get_T_from_SitaAndP((double)sita, P);
					T2 = 40.0;
					P2 = Mathmatics.get_P_from_SitaAndT((double)sita, T2);
				}
				System.Collections.Generic.List<double> T3 = new System.Collections.Generic.List<double>();
				System.Collections.Generic.List<double> P3 = new System.Collections.Generic.List<double>();
				double splitT = (T2 - T) / 50.0;
				for (double tt = T; tt < T2; tt += splitT)
				{
					double pp = Mathmatics.get_P_from_SitaAndT((double)sita, tt);
					T3.Add(tt);
					P3.Add(pp);
				}
				T3.Add(T2);
				P3.Add(P2);
				sw.WriteLine(sita.ToString());
				sw.WriteLine(P3.Count.ToString());
				for (int i = 0; i < P3.Count; i++)
				{
					sw.WriteLine(string.Format("{0:000.00},{1:0000.0000000}", T3[i], P3[i]));
				}
			}
			sw.Close();
			fs.Close();
			fs = new System.IO.FileStream(System.Windows.Forms.Application.StartupPath + "\\Line_Qs.dat", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);
			double[] qs = new double[]
			{
				0.01,
				0.05,
				0.1,
				0.2,
				0.3,
				0.4,
				0.5,
				0.8,
				1.3,
				1.5,
				2.0,
				2.5,
				3.0,
				4.0,
				5.0,
				6.0,
				8.0,
				10.0,
				12.0,
				14.0,
				16.0,
				18.0,
				20.0,
				25.0,
				30.0,
				35.0,
				40.0
			};
			for (int i = 0; i < qs.Length; i++)
			{
				double P = 200.0;
				double E = Mathmatics.get_e_from_qAndP(qs[i], P);
				double T = Mathmatics.get_T_from_es(E) - 273.15;
				double P2 = 1050.0;
				double E2 = Mathmatics.get_e_from_qAndP(qs[i], P2);
				double T2 = Mathmatics.get_T_from_es(E2) - 273.15;
				System.Collections.Generic.List<double> T3 = new System.Collections.Generic.List<double>();
				System.Collections.Generic.List<double> P3 = new System.Collections.Generic.List<double>();
				double splitP = (P2 - P) / 50.0;
				for (double p = P; p < P2; p += splitP)
				{
					double e = Mathmatics.get_e_from_qAndP(qs[i], p);
					double t = Mathmatics.get_T_from_es(e) - 273.15;
					T3.Add(t);
					P3.Add(p);
				}
				T3.Add(T2);
				P3.Add(P2);
				sw.WriteLine(qs[i].ToString());
				sw.WriteLine(P3.Count.ToString());
				for (int j = 0; j < P3.Count; j++)
				{
					sw.WriteLine(string.Format("{0:000.000000},{1:0000.0}", T3[j], P3[j]));
				}
			}
			sw.Close();
			fs.Close();
			fs = new System.IO.FileStream(System.Windows.Forms.Application.StartupPath + "\\Line_SitaSe.dat", System.IO.FileMode.Create, System.IO.FileAccess.Write);
			sw = new System.IO.StreamWriter(fs, System.Text.Encoding.Default);
			int SitaSe;
			for (SitaSe = -45; SitaSe <= 50; SitaSe += 5)
			{
				double T4 = Mathmatics.joint_Sita_qs((double)SitaSe, qs[0]);
				double es = Mathmatics.get_es_from_T(T4 + 273.15);
				double P4 = Mathmatics.get_P_from_qAnde(qs[0], es);
				System.Collections.Generic.List<double> TT = new System.Collections.Generic.List<double>();
				System.Collections.Generic.List<double> PP = new System.Collections.Generic.List<double>();
				double splitP = (1050.0 - P4) / 50.0;
				double t;
				for (double p = P4; p < 1050.0; p += splitP)
				{
					t = Mathmatics.iterative_T(p, (double)SitaSe);
					TT.Add(t);
					PP.Add(p);
				}
				t = Mathmatics.iterative_T(1050.0, (double)SitaSe);
				TT.Add(t);
				PP.Add(1050.0);
				sw.WriteLine(SitaSe.ToString());
				sw.WriteLine(PP.Count.ToString());
				for (int i = 0; i < PP.Count; i++)
				{
					sw.WriteLine(string.Format("{0:000.000},{1:0000.000000}", TT[i], PP[i]));
				}
			}
			SitaSe = 55;
			while (SitaSe <= 180)
			{
				System.Collections.Generic.List<System.Drawing.Point> ptLine = new System.Collections.Generic.List<System.Drawing.Point>();
				System.Collections.Generic.List<double> TT = new System.Collections.Generic.List<double>();
				System.Collections.Generic.List<double> PP = new System.Collections.Generic.List<double>();
				double splitP = 17.0;
				double t;
				for (double p = 200.0; p < 1050.0; p += splitP)
				{
					t = Mathmatics.iterative_T(p, (double)SitaSe);
					TT.Add(t);
					PP.Add(p);
				}
				t = Mathmatics.iterative_T(1050.0, (double)SitaSe);
				TT.Add(t);
				PP.Add(1050.0);
				sw.WriteLine(SitaSe.ToString());
				sw.WriteLine(PP.Count.ToString());
				for (int i = 0; i < PP.Count; i++)
				{
					sw.WriteLine(string.Format("{0:000.000},{1:0000.000000}", TT[i], PP[i]));
				}
				if (SitaSe < 70)
				{
					SitaSe += 5;
				}
				else
				{
					SitaSe += 10;
				}
			}
			sw.Close();
			fs.Close();
		}

		public void LoadData(System.Collections.Generic.List<double> dataP, System.Collections.Generic.List<double> dataH, System.Collections.Generic.List<double> dataT, System.Collections.Generic.List<double> dataTd, System.Collections.Generic.List<int> dataFs, System.Collections.Generic.List<int> dataFx)
		{
			this.m_DataP = dataP;
			this.m_DataH = dataH;
			this.m_DataT = dataT;
			this.m_DataTd = dataTd;
			this.m_DataFs = dataFs;
			this.m_DataFx = dataFx;
			this.m_DataZT.Clear();
			if (this.m_DataP.Count != 0)
			{
				double p0 = this.m_DataP[0];
				double t0 = this.m_DataT[0];
				double td0 = this.m_DataTd[0];
				double sita = Mathmatics.get_Sita_from_TAndP(t0, p0);
				double pc = Mathmatics.solve_Lcl(p0, t0, td0);
				double tc = Mathmatics.get_T_from_SitaAndP(sita, pc);
				double sita_se = Mathmatics.get_ISOP_sita_se(p0, t0, td0);
				this.m_DataZT.Add(new System.Drawing.PointF((float)t0, (float)p0));
				this.m_DataZT.Add(new System.Drawing.PointF((float)tc, (float)pc));
				if (sita_se >= 55.0)
				{
					double maxP = pc;
					double minP = 200.0;
					double splitP = (maxP - minP) / 10.0;
					for (double p = maxP; p >= minP; p -= splitP)
					{
						double t = Mathmatics.iterative_T(p, sita_se);
						this.m_DataZT.Add(new System.Drawing.PointF((float)t, (float)p));
					}
				}
				else
				{
					double T = Mathmatics.joint_Sita_qs(sita_se, 0.01);
					double es = Mathmatics.get_es_from_T(T + 273.15);
					double P = Mathmatics.get_P_from_qAnde(0.01, es);
					double splitP = (pc - P) / 10.0;
					for (double p = pc; p >= P; p -= splitP)
					{
						double t = Mathmatics.iterative_T(p, sita_se);
						this.m_DataZT.Add(new System.Drawing.PointF((float)t, (float)p));
					}
				}
			}
		}

		public void DrawData()
		{
			int width = this.pictureBox.Width;
			int height = this.pictureBox.Height;
			if (width != 0 && height != 0)
			{
				if (this.pictureBox.Image != null)
				{
					this.pictureBox.Image.Dispose();
				}
				this.pictureBox.Image = new System.Drawing.Bitmap(width, height);
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(this.pictureBox.Image);
				g.Clear(this.m_PicBackColor);
				this.m_Rect = new System.Drawing.Rectangle(this.m_BlankLeft, this.m_BlankTop, width - this.m_BlankLeft - this.m_BlankRight, height - this.m_BlankTop - this.m_BlankBottom);
				g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.DarkOrange, 2f), this.m_Rect);
				System.Drawing.StringFormat formatTitle = new System.Drawing.StringFormat();
				formatTitle.Alignment = System.Drawing.StringAlignment.Center;
				formatTitle.LineAlignment = System.Drawing.StringAlignment.Near;
				System.Drawing.Font fontTitle = new System.Drawing.Font("微软雅黑", 17f, System.Drawing.FontStyle.Bold);
				System.Drawing.SolidBrush brushTitle = new System.Drawing.SolidBrush(System.Drawing.Color.DarkOrange);
				g.DrawString(this.m_PicTitle, fontTitle, brushTitle, new System.Drawing.PointF((float)(width / 2), 5f), formatTitle);
				System.Drawing.Pen penGrid = new System.Drawing.Pen(System.Drawing.Color.DarkOrange, 1f);
				System.Drawing.Pen penGrid2 = new System.Drawing.Pen(System.Drawing.Color.DarkOrange, 2f);
				System.Drawing.Font font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Bold);
				System.Drawing.Font font2 = new System.Drawing.Font("宋体", 7f, System.Drawing.FontStyle.Bold);
				System.Drawing.SolidBrush fontBrush = new System.Drawing.SolidBrush(System.Drawing.Color.DarkOrange);
				System.Drawing.SolidBrush backBrush = new System.Drawing.SolidBrush(this.m_PicBackColor);
				System.Drawing.StringFormat formatLeft = new System.Drawing.StringFormat();
				formatLeft.Alignment = System.Drawing.StringAlignment.Far;
				formatLeft.LineAlignment = System.Drawing.StringAlignment.Center;
				System.Drawing.StringFormat formatRight = new System.Drawing.StringFormat();
				formatRight.Alignment = System.Drawing.StringAlignment.Near;
				formatRight.LineAlignment = System.Drawing.StringAlignment.Center;
				System.Drawing.StringFormat formatTop = new System.Drawing.StringFormat();
				formatTop.Alignment = System.Drawing.StringAlignment.Center;
				formatTop.LineAlignment = System.Drawing.StringAlignment.Far;
				System.Drawing.StringFormat formatBottom = new System.Drawing.StringFormat();
				formatBottom.Alignment = System.Drawing.StringAlignment.Center;
				formatBottom.LineAlignment = System.Drawing.StringAlignment.Near;
				System.Drawing.StringFormat formatCenter = new System.Drawing.StringFormat();
				formatCenter.Alignment = System.Drawing.StringAlignment.Center;
				formatCenter.LineAlignment = System.Drawing.StringAlignment.Center;
				int T = -85;
				while ((double)T <= 40.0)
				{
					System.Drawing.Point pt = this.TPtoXY((double)T, 200.0, this.m_Rect, 1, 1);
					System.Drawing.Point pt2 = this.TPtoXY((double)T, 1050.0, this.m_Rect, 1, 1);
					if (T % 10 == 0)
					{
						g.DrawLine(penGrid2, pt, pt2);
						g.DrawString(string.Format("{0}°", T), font, fontBrush, pt, formatTop);
						g.DrawString(string.Format("{0}°", T), font, fontBrush, pt2, formatBottom);
					}
					else
					{
						g.DrawLine(penGrid, pt, pt2);
					}
					T++;
				}
				int P = 200;
				while ((double)P <= 1050.0)
				{
					System.Drawing.Point pt = this.TPtoXY(-85.0, (double)P, this.m_Rect, 1, 1);
					System.Drawing.Point pt2 = this.TPtoXY(40.0, (double)P, this.m_Rect, 1, 1);
					if (P % 100 == 0)
					{
						g.DrawLine(penGrid2, pt, pt2);
						g.DrawString(string.Format("{0}", P), font, fontBrush, pt, formatLeft);
						g.DrawString(string.Format("{0}", P), font, fontBrush, pt2, formatRight);
					}
					else
					{
						g.DrawLine(penGrid, pt, pt2);
					}
					P += 10;
				}
				P = 50;
				while ((double)P <= 262.5)
				{
					System.Drawing.Point pt = this.TPtoXY(-85.0, (double)P, this.m_Rect, 1, 2);
					string text = string.Format("({0})", P);
					System.Drawing.SizeF sizeText = g.MeasureString(text, font2);
					System.Drawing.RectangleF rectText = new System.Drawing.RectangleF((float)(pt.X + 2), (float)pt.Y - sizeText.Height / 2f, sizeText.Width, sizeText.Height);
					g.FillRectangle(backBrush, rectText);
					g.DrawString(text, font2, fontBrush, pt, formatRight);
					P += 25;
				}
				char[] splitChar = new char[]
				{
					',',
					' '
				};
				if (this.ShowSitaIsoLine)
				{
					System.Drawing.Pen penSita = new System.Drawing.Pen(System.Drawing.Color.OrangeRed, 1f);
					System.Drawing.Font fontSita = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Bold);
					System.Drawing.SolidBrush brushSita = new System.Drawing.SolidBrush(System.Drawing.Color.OrangeRed);
					System.IO.MemoryStream fs = new System.IO.MemoryStream(Resources.Line_Sita);
					System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
					while (!sr.EndOfStream)
					{
						int sita = System.Convert.ToInt32(sr.ReadLine());
						int pointNum = System.Convert.ToInt32(sr.ReadLine());
						System.Drawing.Point[] ptLine = new System.Drawing.Point[pointNum];
						for (int i = 0; i < pointNum; i++)
						{
							string[] data = sr.ReadLine().Split(splitChar);
							double t = System.Convert.ToDouble(data[0]);
							double p = System.Convert.ToDouble(data[1]);
							ptLine[i] = this.TPtoXY(t, p, this.m_Rect, 1, 1);
						}
						g.DrawLines(penSita, ptLine.ToArray<System.Drawing.Point>());
						if (sita % 10 == 0)
						{
							System.Drawing.Point ptMid = ptLine[ptLine.Length / 2];
							g.TranslateTransform((float)ptMid.X, (float)ptMid.Y);
							string textSita = string.Format("{0}°", sita);
							System.Drawing.SizeF sizeSita = g.MeasureString(textSita, font);
							System.Drawing.RectangleF rectSitaText = new System.Drawing.RectangleF(-sizeSita.Width / 2f, -sizeSita.Height / 2f, sizeSita.Width, sizeSita.Height - 5f);
							g.FillRectangle(backBrush, rectSitaText);
							g.DrawString(textSita, fontSita, brushSita, 0f, 0f, formatCenter);
							g.ResetTransform();
						}
					}
					sr.Close();
					fs.Close();
				}
				if (this.ShowQsIsoLine)
				{
					System.Drawing.Pen penQs = new System.Drawing.Pen(System.Drawing.Color.DarkGreen, 1f);
					System.Drawing.SolidBrush brushQs = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGreen);
					System.Drawing.Font fontQs = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Bold);
					System.IO.MemoryStream fs = new System.IO.MemoryStream(Resources.Line_Qs);
					System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
					while (!sr.EndOfStream)
					{
						double qs = System.Convert.ToDouble(sr.ReadLine());
						int pointNum = System.Convert.ToInt32(sr.ReadLine());
						System.Drawing.Point[] ptLine = new System.Drawing.Point[pointNum];
						for (int i = 0; i < pointNum; i++)
						{
							string[] data = sr.ReadLine().Split(splitChar);
							double t = System.Convert.ToDouble(data[0]);
							double p = System.Convert.ToDouble(data[1]);
							ptLine[i] = this.TPtoXY(t, p, this.m_Rect, 1, 1);
						}
						g.DrawLines(penQs, ptLine);
						double textE = Mathmatics.get_e_from_qAndP(qs, 700.0);
						double textT = Mathmatics.get_T_from_es(textE) - 273.15;
						System.Drawing.Point ptText = this.TPtoXY(textT, 700.0, this.m_Rect, 1, 1);
						string textQs = string.Format("{0}", qs);
						System.Drawing.SizeF sizeQs = g.MeasureString(textQs, font);
						System.Drawing.RectangleF rectQsText = new System.Drawing.RectangleF(-sizeQs.Width / 2f, -sizeQs.Height / 2f, sizeQs.Width, sizeQs.Height - 5f);
						g.TranslateTransform((float)ptText.X, (float)ptText.Y);
						g.FillRectangle(backBrush, rectQsText);
						g.DrawString(textQs, fontQs, brushQs, 0f, 0f, formatCenter);
						g.ResetTransform();
					}
					sr.Close();
					fs.Close();
				}
				if (this.ShowSitaSeIsoLine)
				{
					System.Drawing.Pen penSitaSe = new System.Drawing.Pen(System.Drawing.Color.DarkGreen, 1f);
					penSitaSe.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					penSitaSe.DashPattern = new float[]
					{
						15f,
						3f
					};
					System.Drawing.SolidBrush brushSitaSe = new System.Drawing.SolidBrush(System.Drawing.Color.DarkGreen);
					System.Drawing.Font fontSitaSe = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Bold);
					System.IO.MemoryStream fs = new System.IO.MemoryStream(Resources.Line_SitaSe);
					System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
					while (!sr.EndOfStream)
					{
						int sitase = System.Convert.ToInt32(sr.ReadLine());
						int pointNum = System.Convert.ToInt32(sr.ReadLine());
						System.Drawing.Point[] ptLine = new System.Drawing.Point[pointNum];
						for (int i = 0; i < pointNum; i++)
						{
							string[] data = sr.ReadLine().Split(splitChar);
							double t = System.Convert.ToDouble(data[0]);
							double p = System.Convert.ToDouble(data[1]);
							ptLine[i] = this.TPtoXY(t, p, this.m_Rect, 1, 1);
						}
						g.DrawLines(penSitaSe, ptLine);
						if (sitase % 10 == 0)
						{
							System.Drawing.Point ptMid = ptLine[3];
							g.TranslateTransform((float)ptMid.X, (float)ptMid.Y);
							string textSita = string.Format("{0}°", sitase);
							System.Drawing.SizeF sizeSita = g.MeasureString(textSita, font);
							System.Drawing.RectangleF rectSitaText = new System.Drawing.RectangleF(-sizeSita.Width / 2f, -sizeSita.Height / 2f, sizeSita.Width, sizeSita.Height - 5f);
							g.FillRectangle(backBrush, rectSitaText);
							g.DrawString(textSita, fontSitaSe, brushSitaSe, 0f, 0f, formatCenter);
							g.ResetTransform();
						}
					}
					sr.Close();
					fs.Close();
				}
				if (this.ShowEnageArea && this.m_DataP.Count != 0 && this.m_DataZT.Count != 0)
				{
					System.Drawing.Drawing2D.GraphicsPath pathCJ_Right = new System.Drawing.Drawing2D.GraphicsPath();
					System.Drawing.Drawing2D.GraphicsPath pathCJ_Left = new System.Drawing.Drawing2D.GraphicsPath();
					System.Collections.Generic.List<System.Drawing.Point> ptPathRight = new System.Collections.Generic.List<System.Drawing.Point>();
					System.Collections.Generic.List<System.Drawing.Point> ptPathLeft = new System.Collections.Generic.List<System.Drawing.Point>();
					for (int i = 0; i < this.m_DataP.Count; i++)
					{
						System.Drawing.Point ptTemp = this.TPtoXY(this.m_DataT[i], this.m_DataP[i], this.m_Rect, 1, 1);
						ptPathLeft.Add(ptTemp);
						ptPathRight.Add(ptTemp);
					}
					ptPathRight.Add(this.TPtoXY(40.0, this.m_DataP[this.m_DataP.Count - 1], this.m_Rect, 1, 1));
					ptPathRight.Add(this.TPtoXY(40.0, this.m_DataP[0], this.m_Rect, 1, 1));
					pathCJ_Right.AddLines(ptPathRight.ToArray());
					ptPathLeft.Add(this.TPtoXY(-85.0, this.m_DataP[this.m_DataP.Count - 1], this.m_Rect, 1, 1));
					ptPathLeft.Add(this.TPtoXY(-85.0, this.m_DataP[0], this.m_Rect, 1, 1));
					pathCJ_Left.AddLines(ptPathLeft.ToArray());
					System.Drawing.Drawing2D.GraphicsPath pathZT_Right = new System.Drawing.Drawing2D.GraphicsPath();
					System.Drawing.Drawing2D.GraphicsPath pathZT_Left = new System.Drawing.Drawing2D.GraphicsPath();
					ptPathRight.Clear();
					ptPathLeft.Clear();
					for (int i = 0; i < this.m_DataZT.Count; i++)
					{
						double t = (double)this.m_DataZT[i].X;
						double p = (double)this.m_DataZT[i].Y;
						System.Drawing.Point ptTemp = this.TPtoXY(t, p, this.m_Rect, 1, 1);
						ptPathLeft.Add(ptTemp);
						ptPathRight.Add(ptTemp);
					}
					ptPathRight.Add(this.TPtoXY(40.0, (double)this.m_DataZT[this.m_DataZT.Count - 1].Y, this.m_Rect, 1, 1));
					ptPathRight.Add(this.TPtoXY(40.0, (double)this.m_DataZT[0].Y, this.m_Rect, 1, 1));
					pathZT_Right.AddLines(ptPathRight.ToArray());
					ptPathLeft.Add(this.TPtoXY(-85.0, (double)this.m_DataZT[this.m_DataZT.Count - 1].Y, this.m_Rect, 1, 1));
					ptPathLeft.Add(this.TPtoXY(-85.0, (double)this.m_DataZT[0].Y, this.m_Rect, 1, 1));
					pathZT_Left.AddLines(ptPathLeft.ToArray());
					System.Drawing.Drawing2D.HatchBrush brushPositive = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal, System.Drawing.Color.Red, System.Drawing.Color.FromArgb(120, System.Drawing.Color.Red));
					System.Drawing.Region regionZT_CJ = new System.Drawing.Region(pathCJ_Right);
					regionZT_CJ.Intersect(pathZT_Left);
					g.FillRegion(brushPositive, regionZT_CJ);
					System.Drawing.Drawing2D.HatchBrush brushNagative = new System.Drawing.Drawing2D.HatchBrush(System.Drawing.Drawing2D.HatchStyle.BackwardDiagonal, System.Drawing.Color.Blue, System.Drawing.Color.FromArgb(120, System.Drawing.Color.Blue));
					System.Drawing.Region regionCJ_ZT = new System.Drawing.Region(pathZT_Right);
					regionCJ_ZT.Intersect(pathCJ_Left);
					g.FillRegion(brushNagative, regionCJ_ZT);
					pathCJ_Left.Dispose();
					pathCJ_Right.Dispose();
					pathZT_Left.Dispose();
					pathZT_Right.Dispose();
					regionZT_CJ.Dispose();
					regionCJ_ZT.Dispose();
				}
				if (this.ShowCJLine && this.m_DataP.Count != 0)
				{
					System.Drawing.Pen penT = new System.Drawing.Pen(System.Drawing.Color.Black, 2f);
					System.Drawing.Pen penTd = new System.Drawing.Pen(System.Drawing.Color.Black, 2f);
					System.Drawing.Pen penWind = new System.Drawing.Pen(System.Drawing.Color.Black, 2f);
					penTd.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
					penTd.DashPattern = new float[]
					{
						15f,
						3f
					};
					System.Drawing.SolidBrush brushT = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
					System.Collections.Generic.List<System.Drawing.Point> ptLineT = new System.Collections.Generic.List<System.Drawing.Point>();
					System.Collections.Generic.List<System.Drawing.Point> ptLineTd = new System.Collections.Generic.List<System.Drawing.Point>();
					System.Collections.Generic.List<System.Drawing.Point> ptLineT2 = new System.Collections.Generic.List<System.Drawing.Point>();
					System.Collections.Generic.List<System.Drawing.Point> ptLineTd2 = new System.Collections.Generic.List<System.Drawing.Point>();
					for (int i = 0; i < this.m_DataP.Count; i++)
					{
						System.Drawing.Point ptT = System.Drawing.Point.Empty;
						System.Drawing.Point ptTd = System.Drawing.Point.Empty;
						if (this.m_DataP[i] >= 250.0)
						{
							ptT = this.TPtoXY(this.m_DataT[i], this.m_DataP[i], this.m_Rect, 1, 1);
							ptTd = this.TPtoXY(this.m_DataTd[i], this.m_DataP[i], this.m_Rect, 1, 1);
							ptLineT.Add(ptT);
							ptLineTd.Add(ptTd);
						}
						else
						{
							ptT = this.TPtoXY(this.m_DataT[i], this.m_DataP[i], this.m_Rect, 1, 2);
							ptTd = this.TPtoXY(this.m_DataTd[i], this.m_DataP[i], this.m_Rect, 1, 2);
							ptLineT2.Add(ptT);
							ptLineTd2.Add(ptTd);
						}
						g.FillEllipse(brushT, new System.Drawing.Rectangle(ptT.X - 3, ptT.Y - 3, 6, 6));
						g.FillEllipse(brushT, new System.Drawing.Rectangle(ptTd.X - 3, ptTd.Y - 3, 6, 6));
						if (this.m_DataFs.Count > i && this.m_DataFx.Count > i)
						{
							int fs2 = this.m_DataFs[i];
							int fx = this.m_DataFx[i];
							VectorParams.DrawWind(g, penWind, 40, fs2, (float)fx, ptT.X, ptT.Y);
						}
					}
					g.DrawLines(penT, ptLineT.ToArray());
					g.DrawLines(penTd, ptLineTd.ToArray());
					g.DrawLines(penT, ptLineT2.ToArray());
					g.DrawLines(penTd, ptLineTd2.ToArray());
				}
				if (this.ShowStatusLine && this.m_DataZT.Count != 0)
				{
					System.Drawing.Pen penZT = new System.Drawing.Pen(System.Drawing.Color.Red, 2f);
					System.Drawing.SolidBrush brushZT = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
					System.Collections.Generic.List<System.Drawing.Point> ptLine2 = new System.Collections.Generic.List<System.Drawing.Point>();
					for (int i = 0; i < this.m_DataZT.Count; i++)
					{
						double t = (double)this.m_DataZT[i].X;
						double p = (double)this.m_DataZT[i].Y;
						System.Drawing.Point ptTemp = this.TPtoXY(t, p, this.m_Rect, 1, 1);
						ptLine2.Add(ptTemp);
					}
					g.DrawLines(penZT, ptLine2.ToArray());
				}
				g.Dispose();
			}
		}

		public System.Drawing.Point TPtoXY(double T, double P, System.Drawing.Rectangle rect, int typeT = 1, int typeP = 1)
		{
			int X = 0;
			int Y = 0;
			if (typeT == 1)
			{
				X = System.Convert.ToInt32((double)rect.Left + (double)rect.Width * ((T - -85.0) / 125.0));
			}
			else if (typeT == 2)
			{
				X = System.Convert.ToInt32((double)rect.Left + (double)rect.Width * ((T - 188.0) / 125.0));
			}
			if (typeP == 1)
			{
				Y = System.Convert.ToInt32((double)rect.Top + (double)rect.Height * ((System.Math.Log(P) - this.minLnP1) / (this.maxLnP1 - this.minLnP1)));
			}
			else if (typeP == 2)
			{
				Y = System.Convert.ToInt32((double)rect.Top + (double)rect.Height * ((System.Math.Log(P) - this.minLnP2) / (this.maxLnP2 - this.minLnP2)));
			}
			System.Drawing.Point pt = new System.Drawing.Point(X, Y);
			return pt;
		}

		public System.Drawing.PointF XYtoTP(int X, int Y, System.Drawing.Rectangle rect, int typeT = 1, int typeP = 1)
		{
			double T = 0.0;
			double P = 0.0;
			if (typeT == 1)
			{
				T = -85.0 + (double)(X - rect.Left) * 125.0 / (double)rect.Width;
			}
			else if (typeT == 2)
			{
				T = 188.0 + (double)(X - rect.Left) * 125.0 / (double)rect.Width;
			}
			if (typeP == 1)
			{
				P = System.Math.Exp(this.minLnP1 + (double)(Y - rect.Top) * (this.maxLnP1 - this.minLnP1) / (double)rect.Height);
			}
			else if (typeP == 2)
			{
				P = System.Math.Exp(this.minLnP2 + (double)(Y - rect.Top) * (this.maxLnP2 - this.minLnP2) / (double)rect.Height);
			}
			System.Drawing.PointF pt = new System.Drawing.PointF((float)T, (float)P);
			return pt;
		}

		private void TlnPControl_SizeChanged(object sender, System.EventArgs e)
		{
			if (base.Width != 0 && base.Height != 0)
			{
				this.DrawData();
			}
		}

		private void toolStripButton保存图片_Click(object sender, System.EventArgs e)
		{
			this.saveFileDialog.FileName = this.m_PicTitle + ".bmp";
			if (this.saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBox.Image.Save(this.saveFileDialog.FileName);
			}
		}

		private void toolStripButton重绘图片_Click(object sender, System.EventArgs e)
		{
			this.DrawData();
		}

		private void toolStripButton查看数据_Click(object sender, System.EventArgs e)
		{
		}

		private void pictureBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.m_Rect.IsEmpty || !this.m_Rect.Contains(e.Location))
			{
				this.toolStripLabelMousePos.Text = "T=N/A, P=N/A";
			}
			else
			{
				System.Drawing.PointF ptTP = this.XYtoTP(e.X, e.Y, this.m_Rect, 1, 1);
				this.toolStripLabelMousePos.Text = string.Format("T={0:0.00}℃, P={1:0.00}hPa", ptTP.X, ptTP.Y);
			}
		}

		private void toolStripButton显示层结曲线_Click(object sender, System.EventArgs e)
		{
			this.ShowCJLine = !this.ShowCJLine;
			this.DrawData();
		}

		private void toolStripButton显示状态曲线_Click(object sender, System.EventArgs e)
		{
			this.ShowStatusLine = !this.ShowStatusLine;
			this.DrawData();
		}

		private void toolStripButton显示等干绝热线_Click(object sender, System.EventArgs e)
		{
			this.ShowSitaIsoLine = !this.ShowSitaIsoLine;
			this.DrawData();
		}

		private void toolStripButton显示等湿绝热线_Click(object sender, System.EventArgs e)
		{
			this.ShowSitaSeIsoLine = !this.ShowSitaSeIsoLine;
			this.DrawData();
		}

		private void toolStripButton显示等饱和比湿热线_Click(object sender, System.EventArgs e)
		{
			this.ShowQsIsoLine = !this.ShowQsIsoLine;
			this.DrawData();
		}

		private void toolStripButton显示正负能量区_Click(object sender, System.EventArgs e)
		{
			this.ShowEnageArea = !this.ShowEnageArea;
			this.DrawData();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wTlnPControl));
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolStripButton保存图片 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton查看数据 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton重绘图片 = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelMousePos = new System.Windows.Forms.ToolStripLabel();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.toolStripButton显示层结曲线 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton显示正负能量区 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton显示状态曲线 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton显示等干绝热线 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton显示等湿绝热线 = new System.Windows.Forms.ToolStripButton();
			this.toolStripButton显示等饱和比湿热线 = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox).BeginInit();
			base.SuspendLayout();
			this.saveFileDialog.Filter = "BMP文件|*.bmp|JPG文件|*.jpg";
			this.saveFileDialog.Title = "保存T-lnP图";
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripButton保存图片,
				this.toolStripButton查看数据,
				this.toolStripButton重绘图片,
				this.toolStripSeparator2,
				this.toolStripButton显示层结曲线,
				this.toolStripButton显示状态曲线,
				this.toolStripButton显示等干绝热线,
				this.toolStripButton显示等湿绝热线,
				this.toolStripButton显示等饱和比湿热线,
				this.toolStripButton显示正负能量区,
				this.toolStripSeparator1,
				this.toolStripLabelMousePos
			});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(694, 25);
			this.toolStrip1.TabIndex = 1;
			this.toolStrip1.Text = "toolStrip1";
			this.toolStripButton保存图片.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton保存图片.Image = Resources.SaveMap;
			this.toolStripButton保存图片.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton保存图片.Name = "toolStripButton保存图片";
			this.toolStripButton保存图片.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton保存图片.Text = "保存图片";
			this.toolStripButton保存图片.Click += new System.EventHandler(this.toolStripButton保存图片_Click);
			this.toolStripButton查看数据.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton查看数据.Image = Resources._00_09_;
			this.toolStripButton查看数据.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton查看数据.Name = "toolStripButton查看数据";
			this.toolStripButton查看数据.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton查看数据.Text = "查看数据";
			this.toolStripButton查看数据.Visible = false;
			this.toolStripButton查看数据.Click += new System.EventHandler(this.toolStripButton查看数据_Click);
			this.toolStripButton重绘图片.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButton重绘图片.Image = Resources.Refresh;
			this.toolStripButton重绘图片.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton重绘图片.Name = "toolStripButton重绘图片";
			this.toolStripButton重绘图片.Size = new System.Drawing.Size(23, 22);
			this.toolStripButton重绘图片.Text = "重绘图片";
			this.toolStripButton重绘图片.Click += new System.EventHandler(this.toolStripButton重绘图片_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			this.toolStripLabelMousePos.Name = "toolStripLabelMousePos";
			this.toolStripLabelMousePos.Size = new System.Drawing.Size(61, 22);
			this.toolStripLabelMousePos.Text = "T=0, P=0";
			this.pictureBox.BackColor = System.Drawing.Color.White;
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Location = new System.Drawing.Point(0, 25);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(694, 449);
			this.pictureBox.TabIndex = 0;
			this.pictureBox.TabStop = false;
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			this.toolStripButton显示层结曲线.Checked = true;
			this.toolStripButton显示层结曲线.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButton显示层结曲线.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton显示层结曲线.Image = (System.Drawing.Image)resources.GetObject("toolStripButton显示层结曲线.Image");
			this.toolStripButton显示层结曲线.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton显示层结曲线.Name = "toolStripButton显示层结曲线";
			this.toolStripButton显示层结曲线.Size = new System.Drawing.Size(36, 22);
			this.toolStripButton显示层结曲线.Text = "层结";
			this.toolStripButton显示层结曲线.ToolTipText = "显示层结曲线";
			this.toolStripButton显示层结曲线.Click += new System.EventHandler(this.toolStripButton显示层结曲线_Click);
			this.toolStripButton显示正负能量区.Checked = true;
			this.toolStripButton显示正负能量区.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButton显示正负能量区.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton显示正负能量区.Image = (System.Drawing.Image)resources.GetObject("toolStripButton显示正负能量区.Image");
			this.toolStripButton显示正负能量区.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton显示正负能量区.Name = "toolStripButton显示正负能量区";
			this.toolStripButton显示正负能量区.Size = new System.Drawing.Size(36, 22);
			this.toolStripButton显示正负能量区.Text = "能量";
			this.toolStripButton显示正负能量区.ToolTipText = "显示正负能量区";
			this.toolStripButton显示正负能量区.Click += new System.EventHandler(this.toolStripButton显示正负能量区_Click);
			this.toolStripButton显示状态曲线.Checked = true;
			this.toolStripButton显示状态曲线.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButton显示状态曲线.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton显示状态曲线.Image = (System.Drawing.Image)resources.GetObject("toolStripButton显示状态曲线.Image");
			this.toolStripButton显示状态曲线.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton显示状态曲线.Name = "toolStripButton显示状态曲线";
			this.toolStripButton显示状态曲线.Size = new System.Drawing.Size(36, 22);
			this.toolStripButton显示状态曲线.Text = "状态";
			this.toolStripButton显示状态曲线.ToolTipText = "显示状态曲线";
			this.toolStripButton显示状态曲线.Click += new System.EventHandler(this.toolStripButton显示状态曲线_Click);
			this.toolStripButton显示等干绝热线.Checked = true;
			this.toolStripButton显示等干绝热线.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButton显示等干绝热线.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton显示等干绝热线.Image = (System.Drawing.Image)resources.GetObject("toolStripButton显示等干绝热线.Image");
			this.toolStripButton显示等干绝热线.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton显示等干绝热线.Name = "toolStripButton显示等干绝热线";
			this.toolStripButton显示等干绝热线.Size = new System.Drawing.Size(48, 22);
			this.toolStripButton显示等干绝热线.Text = "干绝热";
			this.toolStripButton显示等干绝热线.ToolTipText = "显示等干绝热线";
			this.toolStripButton显示等干绝热线.Click += new System.EventHandler(this.toolStripButton显示等干绝热线_Click);
			this.toolStripButton显示等湿绝热线.Checked = true;
			this.toolStripButton显示等湿绝热线.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButton显示等湿绝热线.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton显示等湿绝热线.Image = (System.Drawing.Image)resources.GetObject("toolStripButton显示等湿绝热线.Image");
			this.toolStripButton显示等湿绝热线.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton显示等湿绝热线.Name = "toolStripButton显示等湿绝热线";
			this.toolStripButton显示等湿绝热线.Size = new System.Drawing.Size(48, 22);
			this.toolStripButton显示等湿绝热线.Text = "湿绝热";
			this.toolStripButton显示等湿绝热线.ToolTipText = "显示等湿绝热线";
			this.toolStripButton显示等湿绝热线.Click += new System.EventHandler(this.toolStripButton显示等湿绝热线_Click);
			this.toolStripButton显示等饱和比湿热线.Checked = true;
			this.toolStripButton显示等饱和比湿热线.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButton显示等饱和比湿热线.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.toolStripButton显示等饱和比湿热线.Image = (System.Drawing.Image)resources.GetObject("toolStripButton显示等饱和比湿热线.Image");
			this.toolStripButton显示等饱和比湿热线.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButton显示等饱和比湿热线.Name = "toolStripButton显示等饱和比湿热线";
			this.toolStripButton显示等饱和比湿热线.Size = new System.Drawing.Size(36, 22);
			this.toolStripButton显示等饱和比湿热线.Text = "比湿";
			this.toolStripButton显示等饱和比湿热线.ToolTipText = "显示等饱和比湿热线";
			this.toolStripButton显示等饱和比湿热线.Click += new System.EventHandler(this.toolStripButton显示等饱和比湿热线_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.pictureBox);
			base.Controls.Add(this.toolStrip1);
			base.Name = "wTlnPControl";
			base.Size = new System.Drawing.Size(694, 474);
			base.SizeChanged += new System.EventHandler(this.TlnPControl_SizeChanged);
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
