using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wMetroGIS.wMapProjection;
using wMetroGIS.wParams;

namespace wMetroGIS.wMapPictureBoxControl
{
	public class wMapThumbPictureBox : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.PictureBox pictureBoxThumb;

		private System.Windows.Forms.Timer timer;

		private System.Drawing.PointF m_SelectedPos = System.Drawing.PointF.Empty;

		private bool m_IsValid = false;

		private wMapPictureBox m_wMapPictureBox = null;

		private MapParams m_MapParams = null;

		private Projection m_Projection = new Projection();

		private bool m_TickShow = false;

		public System.Drawing.PointF SelectedPos
		{
			get
			{
				return this.m_SelectedPos;
			}
			set
			{
				this.m_SelectedPos = value;
				if (this.m_wMapPictureBox != null)
				{
					this.m_wMapPictureBox.ShowMapPoint(this.m_SelectedPos);
				}
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
			this.pictureBoxThumb = new System.Windows.Forms.PictureBox();
			this.timer = new System.Windows.Forms.Timer(this.components);
			((System.ComponentModel.ISupportInitialize)this.pictureBoxThumb).BeginInit();
			base.SuspendLayout();
			this.pictureBoxThumb.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.pictureBoxThumb.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.pictureBoxThumb.Location = new System.Drawing.Point(3, 3);
			this.pictureBoxThumb.Name = "pictureBoxThumb";
			this.pictureBoxThumb.Size = new System.Drawing.Size(250, 250);
			this.pictureBoxThumb.TabIndex = 0;
			this.pictureBoxThumb.TabStop = false;
			this.pictureBoxThumb.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxThumb_Paint);
			this.pictureBoxThumb.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxThumb_MouseClick);
			this.pictureBoxThumb.MouseEnter += new System.EventHandler(this.pictureBoxThumb_MouseEnter);
			this.timer.Tick += new System.EventHandler(this.timer_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.pictureBoxThumb);
			base.Name = "wMapThumbPictureBox";
			base.Size = new System.Drawing.Size(256, 256);
			((System.ComponentModel.ISupportInitialize)this.pictureBoxThumb).EndInit();
			base.ResumeLayout(false);
		}

		public wMapThumbPictureBox()
		{
			this.InitializeComponent();
		}

		public bool InitializeThumbMapControl()
		{
			bool result;
			if (this.m_wMapPictureBox == null)
			{
				result = false;
			}
			else
			{
				this.timer.Interval = 150;
				this.timer.Start();
				this.DrawThumbImage();
				this.m_wMapPictureBox.ShowMapPoint(this.m_SelectedPos);
				result = true;
			}
			return result;
		}

		public void AttachMapPictureBox(wMapPictureBox mapPic)
		{
			this.m_wMapPictureBox = mapPic;
			this.m_MapParams = mapPic.GetMapParams();
		}

		public void DrawThumbImage()
		{
			if (this.pictureBoxThumb.Width != 0 && this.pictureBoxThumb.Height != 0)
			{
				if (this.m_MapParams != null)
				{
					this.m_Projection = this.m_MapParams.GetProjection(this.pictureBoxThumb.Width, this.pictureBoxThumb.Height, (double)this.m_MapParams.Zoom * 0.2);
					this.pictureBoxThumb.Image = this.m_MapParams.DrawMap(this.m_Projection, new System.Drawing.Size(this.pictureBoxThumb.Width, this.pictureBoxThumb.Height), true);
					if (this.m_MapParams.ShowStationInThumb)
					{
						System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(this.pictureBoxThumb.Image);
						if (this.m_wMapPictureBox.m_StationPositionList1 != null)
						{
							for (int i = 0; i < this.m_wMapPictureBox.m_StationPositionList1.Count; i++)
							{
								System.Drawing.PointF StationPosF = this.m_wMapPictureBox.m_StationPositionList1[i];
								System.Drawing.Point StationPos = this.m_Projection.LonLat2XY(StationPosF);
								g.FillEllipse(new System.Drawing.SolidBrush(System.Drawing.Color.Orange), StationPos.X - 3, StationPos.Y - 3, 6, 6);
								g.DrawEllipse(new System.Drawing.Pen(System.Drawing.Color.Red), StationPos.X - 3, StationPos.Y - 3, 6, 6);
							}
						}
						if (this.m_wMapPictureBox.m_StationPositionList2 != null)
						{
							for (int i = 0; i < this.m_wMapPictureBox.m_StationPositionList2.Count; i++)
							{
								System.Drawing.PointF StationPosF = this.m_wMapPictureBox.m_StationPositionList2[i];
								System.Drawing.Point StationPos = this.m_Projection.LonLat2XY(StationPosF);
								g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.Yellow), StationPos.X - 3, StationPos.Y - 3, 6, 6);
								g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black), StationPos.X - 3, StationPos.Y - 3, 6, 6);
							}
						}
					}
					this.m_SelectedPos = this.m_Projection.centerLonLat;
					this.m_IsValid = true;
				}
			}
		}

		private void pictureBoxThumb_MouseEnter(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.Cross;
		}

		private void pictureBoxThumb_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Drawing.PointF LonLat = this.m_Projection.XY2LonLat(e.X, e.Y);
			System.Drawing.PointF[] points = this.m_wMapPictureBox.GetVisableArea();
			System.Drawing.PointF lonlatStart = points[0];
			System.Drawing.PointF lonlatEnd = points[1];
			System.Drawing.PointF lonlatCenter = this.m_wMapPictureBox.GetMapProjection().centerLonLat;
			this.m_SelectedPos = lonlatCenter;
			if (this.m_wMapPictureBox != null)
			{
				this.m_wMapPictureBox.ShowMapPoint(this.m_SelectedPos);
			}
		}

		private void timer_Tick(object sender, System.EventArgs e)
		{
			this.m_TickShow = !this.m_TickShow;
			this.pictureBoxThumb.Refresh();
		}

		private void pictureBoxThumb_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (this.m_IsValid)
			{
				System.Drawing.Graphics g = e.Graphics;
				if (this.m_wMapPictureBox != null)
				{
					System.Drawing.PointF[] points = this.m_wMapPictureBox.GetVisableArea();
					System.Drawing.PointF lonlatStart = points[0];
					System.Drawing.PointF lonlatEnd = points[1];
					System.Drawing.PointF lonlatCenter = this.m_wMapPictureBox.GetMapProjection().centerLonLat;
					this.m_SelectedPos = lonlatCenter;
					System.Drawing.Point P = this.m_Projection.LonLat2XY(lonlatStart);
					System.Drawing.Point P2 = this.m_Projection.LonLat2XY(lonlatEnd);
					g.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black, 1f), P.X, P.Y, P2.X - P.X, P2.Y - P.Y);
					g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(100, 128, 128, 128)), P.X, P.Y, P2.X - P.X, P2.Y - P.Y);
				}
				if (!this.m_SelectedPos.IsEmpty)
				{
					System.Drawing.Point XY = this.m_Projection.LonLat2XY(this.m_SelectedPos.X, this.m_SelectedPos.Y);
					System.Drawing.Pen pen;
					if (this.m_TickShow)
					{
						pen = new System.Drawing.Pen(System.Drawing.Color.Red, 1f);
					}
					else
					{
						pen = new System.Drawing.Pen(System.Drawing.Color.White, 1f);
					}
					g.DrawLine(pen, XY.X - 10, XY.Y, XY.X + 10, XY.Y);
					g.DrawLine(pen, XY.X, XY.Y - 10, XY.X, XY.Y + 10);
					g.DrawEllipse(pen, new System.Drawing.Rectangle(XY.X - 1, XY.Y - 1, 2, 2));
					System.Drawing.Font myFont = new System.Drawing.Font("黑体", 8f, System.Drawing.FontStyle.Bold);
					g.DrawString(this.m_SelectedPos.X.ToString("F1") + "," + this.m_SelectedPos.Y.ToString("F1"), myFont, new System.Drawing.SolidBrush(System.Drawing.Color.Blue), XY);
				}
			}
		}
	}
}
