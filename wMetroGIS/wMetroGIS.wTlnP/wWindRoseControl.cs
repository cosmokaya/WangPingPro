using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wMetroGIS.Properties;
using wMetroGIS.wParams;

namespace wMetroGIS.wTlnP
{
	public class wWindRoseControl : System.Windows.Forms.UserControl
	{
		private System.Drawing.Rectangle m_Rect = System.Drawing.Rectangle.Empty;

		private int m_R = 0;

		private int m_MaxFs = 0;

		private System.Drawing.Point m_Center = System.Drawing.Point.Empty;

		private System.Drawing.Color m_PicBackColor = System.Drawing.Color.LightYellow;

		private string m_PicTitle = "风向风速玫瑰图";

		private System.Collections.Generic.List<double> m_DataP = new System.Collections.Generic.List<double>();

		private System.Collections.Generic.List<int> m_DataFs = new System.Collections.Generic.List<int>();

		private System.Collections.Generic.List<int> m_DataFx = new System.Collections.Generic.List<int>();

		private System.Collections.Generic.List<System.Drawing.Point> m_DataFxFsPos = new System.Collections.Generic.List<System.Drawing.Point>();

		private int m_SelectedID = -1;

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		private System.Windows.Forms.ListView listView;

		private System.Windows.Forms.ColumnHeader columnHeader1;

		private System.Windows.Forms.ColumnHeader columnHeader2;

		private System.Windows.Forms.ColumnHeader columnHeader3;

		private System.Windows.Forms.PictureBox pictureBox;

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip;

		private System.Windows.Forms.ToolStripMenuItem 保存图片ToolStripMenuItem;

		private System.Windows.Forms.SaveFileDialog saveFileDialog;

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

		public wWindRoseControl()
		{
			this.InitializeComponent();
		}

		public void LoadData(System.Collections.Generic.List<double> dataP, System.Collections.Generic.List<int> dataFs, System.Collections.Generic.List<int> dataFx)
		{
			this.m_DataP = dataP;
			this.m_DataFs = dataFs;
			this.m_DataFx = dataFx;
			this.listView.Items.Clear();
			this.m_MaxFs = 0;
			for (int i = this.m_DataP.Count - 1; i >= 0; i--)
			{
				System.Windows.Forms.ListViewItem newItem = new System.Windows.Forms.ListViewItem(string.Format("{0}hPa", this.m_DataP[i]));
				newItem.SubItems.Add(string.Format("{0}°", this.m_DataFx[i]));
				newItem.SubItems.Add(string.Format("{0}m/s", this.m_DataFs[i]));
				this.listView.Items.Add(newItem);
				if (dataFs[i] > this.m_MaxFs)
				{
					this.m_MaxFs = dataFs[i];
				}
			}
			if (this.m_MaxFs % 5 != 0)
			{
				this.m_MaxFs = 5 * (this.m_MaxFs / 5 + 1);
			}
			this.pictureBox.SizeChanged += new System.EventHandler(this.pictureBox_SizeChanged);
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
				System.Drawing.StringFormat formatTitle = new System.Drawing.StringFormat();
				formatTitle.Alignment = System.Drawing.StringAlignment.Center;
				formatTitle.LineAlignment = System.Drawing.StringAlignment.Near;
				System.Drawing.Font fontTitle = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold);
				System.Drawing.SolidBrush brushTitle = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				g.DrawString(this.m_PicTitle, fontTitle, brushTitle, new System.Drawing.PointF((float)(width / 2), 5f), formatTitle);
				this.m_R = ((width < height) ? width : height);
				this.m_R = (this.m_R - 40) / 2 - 30;
				int centerX = 70 + this.m_R;
				int centerY = 70 + this.m_R;
				this.m_Center = new System.Drawing.Point(centerX, centerY);
				this.m_Rect = new System.Drawing.Rectangle(centerX - this.m_R, centerY - this.m_R, 2 * this.m_R, 2 * this.m_R);
				System.Drawing.Font fontFx = new System.Drawing.Font("宋体", 10f, System.Drawing.FontStyle.Bold);
				System.Drawing.SolidBrush brushFx = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				System.Drawing.StringFormat formatFx = new System.Drawing.StringFormat();
				System.Drawing.Pen penFx = new System.Drawing.Pen(System.Drawing.Color.DarkOrange, 1f);
				formatFx.Alignment = System.Drawing.StringAlignment.Center;
				formatFx.LineAlignment = System.Drawing.StringAlignment.Center;
				string[] fxName = new string[]
				{
					"N",
					"NNE",
					"NE",
					"ENE",
					"E",
					"ESE",
					"SE",
					"SSE",
					"S",
					"SSW",
					"SW",
					"WSW",
					"W",
					"WNW",
					"NW",
					"NNW"
				};
				int fxNameIndex = 0;
				for (double fx = 0.0; fx < 360.0; fx += 22.5)
				{
					System.Drawing.Point ptFx = this.FxFxtoXY(fx, (double)this.m_MaxFs);
					g.DrawLine(penFx, this.m_Center, ptFx);
					ptFx = this.FxFxtoXY(fx, (double)this.m_MaxFs * 1.05);
					g.DrawString(fxName[fxNameIndex++], fontFx, brushFx, ptFx, formatFx);
				}
				System.Drawing.Font fontCoor = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Bold);
				System.Drawing.SolidBrush brushCoor = new System.Drawing.SolidBrush(System.Drawing.Color.DarkOrange);
				System.Drawing.Pen penCoor = new System.Drawing.Pen(System.Drawing.Color.DarkOrange, 1f);
				for (int i = 5; i <= this.m_MaxFs; i += 5)
				{
					int thisR = this.m_R * i / this.m_MaxFs;
					System.Drawing.Rectangle rect = new System.Drawing.Rectangle(this.m_Center.X - thisR, this.m_Center.Y - thisR, 2 * thisR, 2 * thisR);
					g.DrawEllipse(penCoor, rect);
					System.Drawing.Point ptCoor = new System.Drawing.Point(this.m_Center.X + thisR, this.m_Center.Y);
					g.DrawString(i.ToString(), fontCoor, brushCoor, ptCoor, formatTitle);
				}
				System.Drawing.Pen penData = new System.Drawing.Pen(System.Drawing.Color.Red, 2f);
				System.Drawing.Pen penDot = new System.Drawing.Pen(System.Drawing.Color.Black, 1f);
				System.Drawing.SolidBrush brushData = new System.Drawing.SolidBrush(System.Drawing.Color.Red);
				this.m_DataFxFsPos = new System.Collections.Generic.List<System.Drawing.Point>();
				for (int i = 0; i < this.m_DataP.Count; i++)
				{
					System.Drawing.Point pt = this.FxFxtoXY((double)this.m_DataFx[i], (double)this.m_DataFs[i]);
					this.m_DataFxFsPos.Add(pt);
				}
				g.DrawLines(penData, this.m_DataFxFsPos.ToArray());
				for (int i = 0; i < this.m_DataFxFsPos.Count; i++)
				{
					System.Drawing.Point pt = this.m_DataFxFsPos[i];
					System.Drawing.Rectangle rcData = new System.Drawing.Rectangle(pt.X - 3, pt.Y - 3, 6, 6);
					g.FillEllipse(brushData, rcData);
					g.DrawEllipse(penDot, rcData);
				}
				System.Drawing.Pen penWind = new System.Drawing.Pen(System.Drawing.Color.Blue, 4f);
				g.DrawLine(penWind, new System.Drawing.Point(this.m_Rect.Right + 70, this.m_Rect.Bottom), new System.Drawing.Point(this.m_Rect.Right + 70, this.m_Rect.Top));
				System.Drawing.Font fontWind = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Bold);
				penWind = new System.Drawing.Pen(System.Drawing.Color.Black, 1f);
				System.Drawing.Pen penSplit = new System.Drawing.Pen(System.Drawing.Color.Blue, 2f);
				System.Drawing.SolidBrush brushWind = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				System.Drawing.StringFormat formatWind = new System.Drawing.StringFormat();
				formatWind.Alignment = System.Drawing.StringAlignment.Near;
				formatWind.LineAlignment = System.Drawing.StringAlignment.Center;
				double minP = this.m_DataP[0];
				double maxP = this.m_DataP[this.m_DataP.Count - 1];
				int splitP = this.m_Rect.Height / (this.m_DataP.Count - 1);
				for (int i = 0; i < this.m_DataP.Count; i++)
				{
					double P = this.m_DataP[i];
					System.Drawing.Point ptWind = new System.Drawing.Point(this.m_Rect.Right + 70, System.Convert.ToInt32((double)this.m_Rect.Bottom - (double)this.m_Rect.Height * (P - minP) / (maxP - minP)));
					System.Drawing.Point pt2 = new System.Drawing.Point(ptWind.X - 5, ptWind.Y);
					System.Drawing.Point pt3 = new System.Drawing.Point(ptWind.X + 5, ptWind.Y);
					g.DrawLine(penSplit, pt2, pt3);
					g.DrawString(string.Format("{0}", P), fontWind, brushWind, pt3, formatWind);
					int fs = this.m_DataFs[i];
					int fx2 = this.m_DataFx[i];
					VectorParams.DrawWind(g, penWind, 30, fs, (float)fx2, ptWind.X, ptWind.Y);
				}
				g.Dispose();
			}
		}

		private System.Drawing.Point FxFxtoXY(double Fx, double Fs)
		{
			double rFx = (90.0 - Fx) * 3.1415926535897931 / 180.0;
			double R = Fs * 1.0 / (double)this.m_MaxFs * (double)this.m_R;
			int X = this.m_Center.X + System.Convert.ToInt32(R * System.Math.Cos(rFx));
			int Y = this.m_Center.Y - System.Convert.ToInt32(R * System.Math.Sin(rFx));
			System.Drawing.Point pt = new System.Drawing.Point(X, Y);
			return pt;
		}

		private void pictureBox_SizeChanged(object sender, System.EventArgs e)
		{
			if (this.pictureBox.Width != 0 && this.pictureBox.Height != 0)
			{
				this.DrawData();
			}
		}

		private void pictureBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (!this.m_Rect.Contains(e.Location))
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			else
			{
				this.Cursor = System.Windows.Forms.Cursors.Cross;
				if (this.m_SelectedID == -1)
				{
					for (int i = 0; i < this.m_DataFxFsPos.Count; i++)
					{
						System.Drawing.Point pt = this.m_DataFxFsPos[i];
						double dis = (double)((e.X - pt.X) * (e.X - pt.X) + (e.Y - pt.Y) * (e.Y - pt.Y));
						if (dis <= 25.0)
						{
							this.m_SelectedID = i;
							this.pictureBox.Refresh();
							break;
						}
					}
				}
				else
				{
					System.Drawing.Point pt = this.m_DataFxFsPos[this.m_SelectedID];
					double dis = (double)((e.X - pt.X) * (e.X - pt.X) + (e.Y - pt.Y) * (e.Y - pt.Y));
					if (dis > 25.0)
					{
						this.m_SelectedID = -1;
						this.pictureBox.Refresh();
					}
				}
			}
		}

		private void pictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (this.m_SelectedID != -1)
			{
				System.Drawing.Graphics g = e.Graphics;
				System.Drawing.Pen penDot = new System.Drawing.Pen(System.Drawing.Color.Black, 1f);
				System.Drawing.SolidBrush brushData = new System.Drawing.SolidBrush(System.Drawing.Color.Yellow);
				System.Drawing.Point pt = this.m_DataFxFsPos[this.m_SelectedID];
				System.Drawing.Rectangle rcData = new System.Drawing.Rectangle(pt.X - 4, pt.Y - 4, 8, 8);
				g.FillEllipse(brushData, rcData);
				g.DrawEllipse(penDot, rcData);
				System.Drawing.Rectangle rcInfo = new System.Drawing.Rectangle(pt.X + 5, pt.Y + 5, 120, 55);
				System.Drawing.Pen penInfo = new System.Drawing.Pen(System.Drawing.Color.DarkSlateBlue, 2f);
				System.Drawing.SolidBrush brushInfo = new System.Drawing.SolidBrush(System.Drawing.Color.LightCyan);
				g.FillRectangle(brushInfo, rcInfo);
				g.DrawRectangle(penInfo, rcInfo);
				System.Drawing.Font fontInfo = new System.Drawing.Font("宋体", 10f, System.Drawing.FontStyle.Bold);
				string info = string.Format("气压：{0} hPa\n风向：{1}°\n风速：{2} m/s", this.m_DataP[this.m_SelectedID], this.m_DataFx[this.m_SelectedID], this.m_DataFs[this.m_SelectedID]);
				g.DrawString(info, fontInfo, new System.Drawing.SolidBrush(System.Drawing.Color.Black), new System.Drawing.Point(pt.X + 10, pt.Y + 10));
				System.Drawing.Pen penWind = new System.Drawing.Pen(System.Drawing.Color.Black, 1f);
				VectorParams.DrawWind(g, penWind, 40, this.m_DataFs[this.m_SelectedID], (float)this.m_DataFx[this.m_SelectedID], pt.X, pt.Y);
			}
		}

		private void 保存图片ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.saveFileDialog.FileName = this.m_PicTitle + ".bmp";
			if (this.saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBox.Image.Save(this.saveFileDialog.FileName);
			}
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
			this.components = new System.ComponentModel.Container();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.listView = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.pictureBox = new System.Windows.Forms.PictureBox();
			this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.保存图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBox).BeginInit();
			this.contextMenuStrip.SuspendLayout();
			base.SuspendLayout();
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200f));
			this.tableLayoutPanel1.Controls.Add(this.listView, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.pictureBox, 0, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 1;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(750, 440);
			this.tableLayoutPanel1.TabIndex = 0;
			this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1,
				this.columnHeader2,
				this.columnHeader3
			});
			this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.listView.FullRowSelect = true;
			this.listView.GridLines = true;
			this.listView.Location = new System.Drawing.Point(553, 3);
			this.listView.MultiSelect = false;
			this.listView.Name = "listView";
			this.listView.Size = new System.Drawing.Size(194, 434);
			this.listView.TabIndex = 1;
			this.listView.UseCompatibleStateImageBehavior = false;
			this.listView.View = System.Windows.Forms.View.Details;
			this.columnHeader1.Text = "气压";
			this.columnHeader2.Text = "风向";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Text = "风速";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.pictureBox.BackColor = System.Drawing.Color.White;
			this.pictureBox.ContextMenuStrip = this.contextMenuStrip;
			this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox.Location = new System.Drawing.Point(3, 3);
			this.pictureBox.Name = "pictureBox";
			this.pictureBox.Size = new System.Drawing.Size(544, 434);
			this.pictureBox.TabIndex = 2;
			this.pictureBox.TabStop = false;
			this.pictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Paint);
			this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
			this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.保存图片ToolStripMenuItem
			});
			this.contextMenuStrip.Name = "contextMenuStrip";
			this.contextMenuStrip.Size = new System.Drawing.Size(153, 48);
			this.保存图片ToolStripMenuItem.Image = Resources.SaveMap;
			this.保存图片ToolStripMenuItem.Name = "保存图片ToolStripMenuItem";
			this.保存图片ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.保存图片ToolStripMenuItem.Text = "保存图片";
			this.保存图片ToolStripMenuItem.Click += new System.EventHandler(this.保存图片ToolStripMenuItem_Click);
			this.saveFileDialog.Filter = "BMP文件|*.bmp|JPG文件|*.jpg";
			this.saveFileDialog.Title = "保存玫瑰图";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.tableLayoutPanel1);
			base.Name = "wWindRoseControl";
			base.Size = new System.Drawing.Size(750, 440);
			this.tableLayoutPanel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.pictureBox).EndInit();
			this.contextMenuStrip.ResumeLayout(false);
			base.ResumeLayout(false);
		}
	}
}
