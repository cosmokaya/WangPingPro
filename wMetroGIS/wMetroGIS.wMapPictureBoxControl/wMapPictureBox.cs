using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Text;
using System.Windows.Forms;
using wMetroGIS.Properties;
using wMetroGIS.wColorManager;
using wMetroGIS.wMapProjection;
using wMetroGIS.wParams;

namespace wMetroGIS.wMapPictureBoxControl
{
	public class wMapPictureBox : System.Windows.Forms.UserControl
	{
		public enum MOUSE_STATUS
		{
			MOUSE_STATUS_NORMAL,
			MOUSE_STATUS_SCRACH,
			MOUSE_STATUS_SELECTPOINT,
			MOUSE_STATUS_SELECTAREA
		}

		public enum AUTOZOOM_MODE
		{
			FIT_AUTO,
			FIT_WIDTH,
			FIT_HEIGHT
		}

		private const int m_MaxColorBarNum = 5;

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Panel panel;

		private System.Windows.Forms.SaveFileDialog saveFileDialog;

		private System.Windows.Forms.ToolStrip toolStripControl;

		private System.Windows.Forms.ToolStripButton toolStripButtonMouseNormal;

		private System.Windows.Forms.ToolStripButton toolStripButtonMouseScrach;

		private System.Windows.Forms.ToolStripButton toolStripButtonMouseSelectStation;

		private System.Windows.Forms.ToolStripButton toolStripButtonMouseSelectArea;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;

		private System.Windows.Forms.ToolStripButton toolStripButtonZoomIn;

		private System.Windows.Forms.ToolStripButton toolStripButtonZoomOut;

		private System.Windows.Forms.ToolStripButton toolStripButtonSavePicture;

		private System.Windows.Forms.ToolStripButton toolStripButtonSetParams;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

		private System.Windows.Forms.ToolStripLabel toolStripLabelLonLat;

		private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;

		private System.Windows.Forms.ToolStripButton toolStripButtonShowColorBar;

		private System.Windows.Forms.ToolStripButton toolStripButtonShowTitle;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

		private System.Windows.Forms.ToolStripLabel toolStripLabelInfo;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;

		private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;

		private System.Windows.Forms.PictureBox mapPictureBox;

		private System.Windows.Forms.ContextMenuStrip contextMenuStripMap;

		private System.Windows.Forms.ToolStripMenuItem 鼠标正常状态ToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem 拖动地图ToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem 选择站点ToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem 选择区域ToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem 放大地图ToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem 缩小地图ToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem 重绘地图ToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem 保存当前地图ToolStripMenuItem;

		private System.Windows.Forms.ToolStripMenuItem 设置地图参数ToolStripMenuItem;

		private System.Windows.Forms.ToolStripButton toolStripButtonZoomToBest;

		private System.Windows.Forms.Label labelTitle;

		private System.Windows.Forms.ToolStripButton toolStripButtonZoomToWidth;

		private System.Windows.Forms.ToolStripButton toolStripButtonZoomToHeight;

		private System.Windows.Forms.ToolStripButton toolStripButtonShowStation;

		private wMapPictureBox.MOUSE_STATUS m_MouseStatus = wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_NORMAL;

		private wMapPictureBox.AUTOZOOM_MODE m_AutoZoomMode = wMapPictureBox.AUTOZOOM_MODE.FIT_AUTO;

		private Projection m_Projection = null;

		private MapParams m_MapParams = null;

		private wMapThumbPictureBox m_ThumbPictureBox;

		private string m_MapTitle = "";

		private bool m_MouseIsDown = false;

		private System.Drawing.PointF m_SelectedRectStartPos = System.Drawing.Point.Empty;

		private System.Drawing.PointF m_SelectedRectEndPos = System.Drawing.Point.Empty;

		private System.Drawing.PointF m_LastPoint = System.Drawing.Point.Empty;

		private System.Windows.Forms.Cursor m_CursorHandOff;

		private System.Windows.Forms.Cursor m_CursorHandOn;

		private System.Drawing.Point m_ColorBarPos = new System.Drawing.Point(50, 30);

		private int m_ColorBarWidth = 400;

		private int m_ColorBarHeight = 60;

		private int m_ColorBarNum = 0;

		private System.Drawing.Bitmap m_ColorBarBitmap = null;

		private string m_StationDataPath1 = "";

		private string m_StationDataPath2 = "";

		public int m_SelectedStationIndex1 = -1;

		public System.Collections.Generic.List<int> m_StationIDList1 = new System.Collections.Generic.List<int>();

		public System.Collections.Generic.List<string> m_StationNameList1 = new System.Collections.Generic.List<string>();

		public System.Collections.Generic.List<System.Drawing.PointF> m_StationPositionList1 = new System.Collections.Generic.List<System.Drawing.PointF>();

		public System.Collections.Generic.List<string> m_StationInfo1 = new System.Collections.Generic.List<string>();

		public int m_SelectedStationIndex2 = -1;

		public System.Collections.Generic.List<int> m_StationIDList2 = new System.Collections.Generic.List<int>();

		public System.Collections.Generic.List<string> m_StationNameList2 = new System.Collections.Generic.List<string>();

		public System.Collections.Generic.List<System.Drawing.PointF> m_StationPositionList2 = new System.Collections.Generic.List<System.Drawing.PointF>();

		public System.Collections.Generic.List<string> m_StationInfo2 = new System.Collections.Generic.List<string>();

		private System.Drawing.Point pt = System.Drawing.Point.Empty;

		private System.Drawing.Point def = System.Drawing.Point.Empty;

		public event System.EventHandler MapRefreshed;

		public event System.EventHandler MapZoomed;

		public event System.EventHandler StationSelected;

		public event System.EventHandler StationUnselected;

		public event System.EventHandler StationClicked;

		public event System.EventHandler StationDoubleClicked;

		public event System.EventHandler AreaSelected;

		public wMapPictureBox.MOUSE_STATUS MouseStatus
		{
			get
			{
				return this.m_MouseStatus;
			}
			set
			{
				this.m_MouseStatus = value;
				this.toolStripButtonMouseNormal.Checked = (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_NORMAL);
				this.toolStripButtonMouseScrach.Checked = (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SCRACH);
				this.toolStripButtonMouseSelectStation.Checked = (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTPOINT);
				this.toolStripButtonMouseSelectArea.Checked = (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTAREA);
				this.鼠标正常状态ToolStripMenuItem.Checked = this.toolStripButtonMouseNormal.Checked;
				this.拖动地图ToolStripMenuItem.Checked = this.toolStripButtonMouseScrach.Checked;
				this.选择站点ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectStation.Checked;
				this.选择区域ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectArea.Checked;
				if (this.toolStripButtonMouseSelectStation.Checked)
				{
					this.toolStripButtonShowStation.Checked = true;
				}
			}
		}

		public wMapPictureBox.AUTOZOOM_MODE AutoZoomMode
		{
			get
			{
				return this.m_AutoZoomMode;
			}
			set
			{
				this.m_AutoZoomMode = value;
			}
		}

		public Projection Projection
		{
			get
			{
				return this.m_Projection;
			}
		}

		public MapParams MapParams
		{
			get
			{
				return this.m_MapParams;
			}
		}

		public wMapThumbPictureBox ThumbPictureBox
		{
			get
			{
				return this.m_ThumbPictureBox;
			}
		}

		public string MapTitle
		{
			get
			{
				return this.m_MapTitle;
			}
			set
			{
				this.m_MapTitle = value;
				if (this.m_MapTitle == null || this.m_MapTitle == "")
				{
					this.labelTitle.Text = "";
					this.labelTitle.Height = 0;
					this.ShowMapTitle = false;
				}
				else
				{
					this.labelTitle.Text = this.m_MapTitle;
					this.labelTitle.Height = 40;
					this.ShowMapTitle = true;
				}
			}
		}

		public string LabelInfo
		{
			get
			{
				return this.toolStripLabelInfo.Text;
			}
			set
			{
				this.toolStripLabelInfo.Text = value;
			}
		}

		public System.Windows.Forms.PictureBox MapPictureBox
		{
			get
			{
				return this.mapPictureBox;
			}
		}

		public System.Drawing.Bitmap ColorBarBitmap
		{
			get
			{
				return this.m_ColorBarBitmap;
			}
			set
			{
				if (value == null)
				{
					this.toolStripButtonShowColorBar.Enabled = false;
				}
				else
				{
					this.toolStripButtonShowColorBar.Enabled = true;
				}
				this.m_ColorBarBitmap = value;
			}
		}

		public string StationDataPath1
		{
			get
			{
				return this.m_StationDataPath1;
			}
			set
			{
				this.m_StationDataPath1 = value;
			}
		}

		public string StationDataPath2
		{
			get
			{
				return this.m_StationDataPath2;
			}
			set
			{
				this.m_StationDataPath2 = value;
			}
		}

		public bool ShowToolStripButtonMouseNormal
		{
			get
			{
				return this.toolStripButtonMouseNormal.Visible;
			}
			set
			{
				this.toolStripButtonMouseNormal.Visible = value;
			}
		}

		public bool ShowToolStripButtonMouseScrach
		{
			get
			{
				return this.toolStripButtonMouseScrach.Visible;
			}
			set
			{
				this.toolStripButtonMouseScrach.Visible = value;
			}
		}

		public bool ShowToolStripButtonMouseSelectPoint
		{
			get
			{
				return this.toolStripButtonMouseSelectStation.Visible;
			}
			set
			{
				this.toolStripButtonMouseSelectStation.Visible = value;
			}
		}

		public bool ShowToolStripButtonMouseSelectArea
		{
			get
			{
				return this.toolStripButtonMouseSelectArea.Visible;
			}
			set
			{
				this.toolStripButtonMouseSelectArea.Visible = value;
			}
		}

		public bool ShowToolStripButtonZoom
		{
			get
			{
				return this.toolStripButtonZoomIn.Visible;
			}
			set
			{
				this.toolStripButtonZoomIn.Visible = value;
				this.toolStripButtonZoomOut.Visible = value;
			}
		}

		public bool ShowToolStripButtonAutoZoom
		{
			get
			{
				return this.toolStripButtonZoomToBest.Visible;
			}
			set
			{
				this.toolStripButtonZoomToBest.Visible = value;
				this.toolStripButtonZoomToWidth.Visible = value;
				this.toolStripButtonZoomToHeight.Visible = value;
			}
		}

		public bool ShowToolStripButtonRefresh
		{
			get
			{
				return this.toolStripButtonRefresh.Visible;
			}
			set
			{
				this.toolStripButtonRefresh.Visible = value;
			}
		}

		public bool ShowToolStripButtonSavePicture
		{
			get
			{
				return this.toolStripButtonSavePicture.Visible;
			}
			set
			{
				this.toolStripButtonSavePicture.Visible = value;
			}
		}

		public bool ShowToolStripButtonSetParams
		{
			get
			{
				return this.toolStripButtonSetParams.Visible;
			}
			set
			{
				this.toolStripButtonSetParams.Visible = value;
			}
		}

		public bool ShowToolStripButtonShowColorBar
		{
			get
			{
				return this.toolStripButtonShowColorBar.Visible;
			}
			set
			{
				this.toolStripButtonShowColorBar.Visible = value;
			}
		}

		public bool ShowToolStripButtonShowTitle
		{
			get
			{
				return this.toolStripButtonShowTitle.Visible;
			}
			set
			{
				this.toolStripButtonShowTitle.Visible = value;
			}
		}

		public bool ShowToolStripButtonShowStation
		{
			get
			{
				return this.toolStripButtonShowStation.Visible;
			}
			set
			{
				this.toolStripButtonShowStation.Visible = value;
			}
		}

		public bool ShowMousePosition
		{
			get
			{
				return this.toolStripLabelLonLat.Visible;
			}
			set
			{
				this.toolStripLabelLonLat.Visible = value;
			}
		}

		public bool ShowColorBar
		{
			get
			{
				return this.toolStripButtonShowColorBar.Checked;
			}
			set
			{
				if (this.m_ColorBarNum == 0)
				{
					this.toolStripButtonShowColorBar.Checked = false;
					this.toolStripButtonShowColorBar.Enabled = false;
				}
				else
				{
					this.toolStripButtonShowColorBar.Checked = value;
					this.toolStripButtonShowColorBar.Enabled = true;
				}
			}
		}

		public bool ShowMapTitle
		{
			get
			{
				return this.toolStripButtonShowTitle.Checked;
			}
			set
			{
				if (this.m_MapTitle == null || this.m_MapTitle == "")
				{
					this.toolStripButtonShowTitle.Checked = false;
					this.toolStripButtonShowTitle.Enabled = false;
				}
				else
				{
					this.toolStripButtonShowTitle.Checked = value;
					this.toolStripButtonShowTitle.Enabled = true;
				}
				this.labelTitle.Height = (this.toolStripButtonShowTitle.Checked ? 40 : 0);
			}
		}

		public bool ShowStation
		{
			get
			{
				return this.toolStripButtonShowStation.Checked;
			}
			set
			{
				if (this.m_StationNameList1.Count == 0 && this.m_StationNameList2.Count == 0)
				{
					this.toolStripButtonShowStation.Checked = false;
					this.toolStripButtonShowStation.Enabled = false;
				}
				else
				{
					this.toolStripButtonShowStation.Checked = value;
					this.toolStripButtonShowStation.Enabled = true;
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
			this.panel = new System.Windows.Forms.Panel();
			this.mapPictureBox = new System.Windows.Forms.PictureBox();
			this.contextMenuStripMap = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.鼠标正常状态ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.拖动地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.选择站点ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.选择区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.放大地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.缩小地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.重绘地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.保存当前地图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.设置地图参数ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.toolStripControl = new System.Windows.Forms.ToolStrip();
			this.toolStripButtonMouseNormal = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonMouseScrach = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonMouseSelectStation = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonMouseSelectArea = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonZoomIn = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonZoomOut = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonZoomToBest = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonZoomToWidth = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonZoomToHeight = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonSavePicture = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonSetParams = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripButtonShowStation = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonShowColorBar = new System.Windows.Forms.ToolStripButton();
			this.toolStripButtonShowTitle = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelLonLat = new System.Windows.Forms.ToolStripLabel();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripLabelInfo = new System.Windows.Forms.ToolStripLabel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.mapPictureBox).BeginInit();
			this.contextMenuStripMap.SuspendLayout();
			this.toolStripControl.SuspendLayout();
			base.SuspendLayout();
			this.panel.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.panel.AutoScroll = true;
			this.panel.BackColor = System.Drawing.Color.White;
			this.panel.Controls.Add(this.mapPictureBox);
			this.panel.Location = new System.Drawing.Point(0, 58);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(613, 498);
			this.panel.TabIndex = 2;
			this.panel.Scroll += new System.Windows.Forms.ScrollEventHandler(this.panel_Scroll);
			this.panel.SizeChanged += new System.EventHandler(this.panel_SizeChanged);
			this.mapPictureBox.BackColor = System.Drawing.Color.Black;
			this.mapPictureBox.ContextMenuStrip = this.contextMenuStripMap;
			this.mapPictureBox.Location = new System.Drawing.Point(0, 0);
			this.mapPictureBox.Name = "mapPictureBox";
			this.mapPictureBox.Size = new System.Drawing.Size(324, 337);
			this.mapPictureBox.TabIndex = 1;
			this.mapPictureBox.TabStop = false;
			this.mapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.mapPictureBox_Paint);
			this.mapPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseClick);
			this.mapPictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseDoubleClick);
			this.mapPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseDown);
			this.mapPictureBox.MouseEnter += new System.EventHandler(this.mapPictureBox_MouseEnter);
			this.mapPictureBox.MouseLeave += new System.EventHandler(this.mapPictureBox_MouseLeave);
			this.mapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseMove);
			this.mapPictureBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.mapPictureBox_MouseUp);
			this.contextMenuStripMap.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.鼠标正常状态ToolStripMenuItem,
				this.拖动地图ToolStripMenuItem,
				this.选择站点ToolStripMenuItem,
				this.选择区域ToolStripMenuItem,
				this.放大地图ToolStripMenuItem,
				this.缩小地图ToolStripMenuItem,
				this.重绘地图ToolStripMenuItem,
				this.保存当前地图ToolStripMenuItem,
				this.设置地图参数ToolStripMenuItem
			});
			this.contextMenuStripMap.Name = "contextMenuStripMap";
			this.contextMenuStripMap.Size = new System.Drawing.Size(153, 224);
			this.contextMenuStripMap.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripMap_Opening);
			this.鼠标正常状态ToolStripMenuItem.Checked = true;
			this.鼠标正常状态ToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.鼠标正常状态ToolStripMenuItem.Image = Resources._49_25_;
			this.鼠标正常状态ToolStripMenuItem.Name = "鼠标正常状态ToolStripMenuItem";
			this.鼠标正常状态ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.鼠标正常状态ToolStripMenuItem.Text = "鼠标指针";
			this.鼠标正常状态ToolStripMenuItem.Click += new System.EventHandler(this.鼠标正常状态ToolStripMenuItem_Click);
			this.拖动地图ToolStripMenuItem.Image = Resources.acdsee9;
			this.拖动地图ToolStripMenuItem.Name = "拖动地图ToolStripMenuItem";
			this.拖动地图ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.拖动地图ToolStripMenuItem.Text = "拖动地图";
			this.拖动地图ToolStripMenuItem.Click += new System.EventHandler(this.拖动地图ToolStripMenuItem_Click);
			this.选择站点ToolStripMenuItem.Image = Resources.SelectPoint;
			this.选择站点ToolStripMenuItem.Name = "选择站点ToolStripMenuItem";
			this.选择站点ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.选择站点ToolStripMenuItem.Text = "选择站点";
			this.选择站点ToolStripMenuItem.Click += new System.EventHandler(this.选择站点ToolStripMenuItem_Click);
			this.选择区域ToolStripMenuItem.Image = Resources.ContentControlsUngroup;
			this.选择区域ToolStripMenuItem.Name = "选择区域ToolStripMenuItem";
			this.选择区域ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.选择区域ToolStripMenuItem.Text = "选择区域";
			this.选择区域ToolStripMenuItem.Click += new System.EventHandler(this.选择区域ToolStripMenuItem_Click);
			this.放大地图ToolStripMenuItem.Image = Resources._40_04_;
			this.放大地图ToolStripMenuItem.Name = "放大地图ToolStripMenuItem";
			this.放大地图ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.放大地图ToolStripMenuItem.Text = "放大地图";
			this.放大地图ToolStripMenuItem.Click += new System.EventHandler(this.放大地图ToolStripMenuItem_Click);
			this.缩小地图ToolStripMenuItem.Image = Resources._41_04_;
			this.缩小地图ToolStripMenuItem.Name = "缩小地图ToolStripMenuItem";
			this.缩小地图ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.缩小地图ToolStripMenuItem.Text = "缩小地图";
			this.缩小地图ToolStripMenuItem.Click += new System.EventHandler(this.缩小地图ToolStripMenuItem_Click);
			this.重绘地图ToolStripMenuItem.Image = Resources.Refresh;
			this.重绘地图ToolStripMenuItem.Name = "重绘地图ToolStripMenuItem";
			this.重绘地图ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.重绘地图ToolStripMenuItem.Text = "重绘地图";
			this.重绘地图ToolStripMenuItem.Click += new System.EventHandler(this.重绘地图ToolStripMenuItem_Click);
			this.保存当前地图ToolStripMenuItem.Image = Resources.SaveMap;
			this.保存当前地图ToolStripMenuItem.Name = "保存当前地图ToolStripMenuItem";
			this.保存当前地图ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.保存当前地图ToolStripMenuItem.Text = "保存当前地图";
			this.保存当前地图ToolStripMenuItem.Click += new System.EventHandler(this.保存当前地图ToolStripMenuItem_Click);
			this.设置地图参数ToolStripMenuItem.Image = Resources.ControlsGallery;
			this.设置地图参数ToolStripMenuItem.Name = "设置地图参数ToolStripMenuItem";
			this.设置地图参数ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.设置地图参数ToolStripMenuItem.Text = "设置地图参数";
			this.设置地图参数ToolStripMenuItem.Click += new System.EventHandler(this.设置地图参数ToolStripMenuItem_Click);
			this.saveFileDialog.Filter = "BMP图片|*.bmp|JPG图片|*.jpg";
			this.saveFileDialog.Title = "保存绘图结果";
			this.toolStripControl.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.toolStripButtonMouseNormal,
				this.toolStripButtonMouseScrach,
				this.toolStripButtonMouseSelectStation,
				this.toolStripButtonMouseSelectArea,
				this.toolStripSeparator1,
				this.toolStripButtonZoomIn,
				this.toolStripButtonZoomOut,
				this.toolStripButtonZoomToBest,
				this.toolStripButtonZoomToWidth,
				this.toolStripButtonZoomToHeight,
				this.toolStripButtonRefresh,
				this.toolStripSeparator5,
				this.toolStripButtonSavePicture,
				this.toolStripButtonSetParams,
				this.toolStripSeparator4,
				this.toolStripButtonShowStation,
				this.toolStripButtonShowColorBar,
				this.toolStripButtonShowTitle,
				this.toolStripSeparator2,
				this.toolStripLabelLonLat,
				this.toolStripSeparator3,
				this.toolStripLabelInfo
			});
			this.toolStripControl.Location = new System.Drawing.Point(0, 0);
			this.toolStripControl.Name = "toolStripControl";
			this.toolStripControl.Size = new System.Drawing.Size(613, 25);
			this.toolStripControl.TabIndex = 3;
			this.toolStripControl.Text = "toolStrip1";
			this.toolStripButtonMouseNormal.Checked = true;
			this.toolStripButtonMouseNormal.CheckState = System.Windows.Forms.CheckState.Checked;
			this.toolStripButtonMouseNormal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonMouseNormal.Image = Resources._49_25_;
			this.toolStripButtonMouseNormal.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMouseNormal.Name = "toolStripButtonMouseNormal";
			this.toolStripButtonMouseNormal.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMouseNormal.Text = "正常状态";
			this.toolStripButtonMouseNormal.Click += new System.EventHandler(this.toolStripButtonMouseNormal_Click);
			this.toolStripButtonMouseScrach.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonMouseScrach.Image = Resources.acdsee9;
			this.toolStripButtonMouseScrach.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMouseScrach.Name = "toolStripButtonMouseScrach";
			this.toolStripButtonMouseScrach.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMouseScrach.Text = "拖动";
			this.toolStripButtonMouseScrach.Click += new System.EventHandler(this.toolStripButtonMouseScrach_Click);
			this.toolStripButtonMouseSelectStation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonMouseSelectStation.Image = Resources.SelectPoint;
			this.toolStripButtonMouseSelectStation.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMouseSelectStation.Name = "toolStripButtonMouseSelectStation";
			this.toolStripButtonMouseSelectStation.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMouseSelectStation.Text = "选择单点";
			this.toolStripButtonMouseSelectStation.Click += new System.EventHandler(this.toolStripButtonMouseSelectStation_Click);
			this.toolStripButtonMouseSelectArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonMouseSelectArea.Image = Resources.ContentControlsUngroup;
			this.toolStripButtonMouseSelectArea.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonMouseSelectArea.Name = "toolStripButtonMouseSelectArea";
			this.toolStripButtonMouseSelectArea.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonMouseSelectArea.Text = "选择区域";
			this.toolStripButtonMouseSelectArea.Click += new System.EventHandler(this.toolStripButtonMouseSelectArea_Click);
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			this.toolStripButtonZoomIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonZoomIn.Image = Resources._40_04_;
			this.toolStripButtonZoomIn.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonZoomIn.Name = "toolStripButtonZoomIn";
			this.toolStripButtonZoomIn.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonZoomIn.Text = "放大";
			this.toolStripButtonZoomIn.Click += new System.EventHandler(this.toolStripButtonZoomIn_Click);
			this.toolStripButtonZoomOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonZoomOut.Image = Resources._41_04_;
			this.toolStripButtonZoomOut.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonZoomOut.Name = "toolStripButtonZoomOut";
			this.toolStripButtonZoomOut.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonZoomOut.Text = "缩小";
			this.toolStripButtonZoomOut.Click += new System.EventHandler(this.toolStripButtonZoomOut_Click);
			this.toolStripButtonZoomToBest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonZoomToBest.Image = Resources.SizeToControlHeightAndWidth;
			this.toolStripButtonZoomToBest.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonZoomToBest.Name = "toolStripButtonZoomToBest";
			this.toolStripButtonZoomToBest.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonZoomToBest.Text = "自动缩放";
			this.toolStripButtonZoomToBest.ToolTipText = "将视图调整为最佳比例";
			this.toolStripButtonZoomToBest.Click += new System.EventHandler(this.toolStripButtonZoomToBest_Click);
			this.toolStripButtonZoomToWidth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonZoomToWidth.Image = Resources.SizeToControlWidth;
			this.toolStripButtonZoomToWidth.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonZoomToWidth.Name = "toolStripButtonZoomToWidth";
			this.toolStripButtonZoomToWidth.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonZoomToWidth.Text = "自动缩放";
			this.toolStripButtonZoomToWidth.ToolTipText = "将视图调整为最佳宽度";
			this.toolStripButtonZoomToWidth.Click += new System.EventHandler(this.toolStripButtonZoomToWidth_Click);
			this.toolStripButtonZoomToHeight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonZoomToHeight.Image = Resources.SizeToControlHeight;
			this.toolStripButtonZoomToHeight.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonZoomToHeight.Name = "toolStripButtonZoomToHeight";
			this.toolStripButtonZoomToHeight.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonZoomToHeight.Text = "自动缩放";
			this.toolStripButtonZoomToHeight.ToolTipText = "将视图调整为最佳高度";
			this.toolStripButtonZoomToHeight.Click += new System.EventHandler(this.toolStripButtonZoomToHeight_Click);
			this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonRefresh.Image = Resources.Refresh;
			this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
			this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonRefresh.Text = "重绘地图";
			this.toolStripButtonRefresh.Click += new System.EventHandler(this.toolStripButtonRefresh_Click);
			this.toolStripSeparator5.Name = "toolStripSeparator5";
			this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
			this.toolStripButtonSavePicture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSavePicture.Image = Resources.SaveMap;
			this.toolStripButtonSavePicture.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSavePicture.Name = "toolStripButtonSavePicture";
			this.toolStripButtonSavePicture.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonSavePicture.Text = "保存为图片";
			this.toolStripButtonSavePicture.Click += new System.EventHandler(this.toolStripButtonSavePicture_Click);
			this.toolStripButtonSetParams.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.toolStripButtonSetParams.Image = Resources.ControlsGallery;
			this.toolStripButtonSetParams.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonSetParams.Name = "toolStripButtonSetParams";
			this.toolStripButtonSetParams.Size = new System.Drawing.Size(23, 22);
			this.toolStripButtonSetParams.Text = "设置地图参数";
			this.toolStripButtonSetParams.Click += new System.EventHandler(this.toolStripButtonSetParams_Click);
			this.toolStripSeparator4.Name = "toolStripSeparator4";
			this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
			this.toolStripButtonShowStation.Image = Resources._17_46_;
			this.toolStripButtonShowStation.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonShowStation.Name = "toolStripButtonShowStation";
			this.toolStripButtonShowStation.Size = new System.Drawing.Size(52, 22);
			this.toolStripButtonShowStation.Text = "站点";
			this.toolStripButtonShowStation.Click += new System.EventHandler(this.toolStripButtonShowStation_Click);
			this.toolStripButtonShowColorBar.Image = Resources.ColorBar;
			this.toolStripButtonShowColorBar.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonShowColorBar.Name = "toolStripButtonShowColorBar";
			this.toolStripButtonShowColorBar.Size = new System.Drawing.Size(52, 22);
			this.toolStripButtonShowColorBar.Text = "色标";
			this.toolStripButtonShowColorBar.Click += new System.EventHandler(this.toolStripButtonShowColorBar_Click);
			this.toolStripButtonShowTitle.Image = Resources.GroupInsertText;
			this.toolStripButtonShowTitle.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolStripButtonShowTitle.Name = "toolStripButtonShowTitle";
			this.toolStripButtonShowTitle.Size = new System.Drawing.Size(52, 22);
			this.toolStripButtonShowTitle.Text = "标题";
			this.toolStripButtonShowTitle.Click += new System.EventHandler(this.toolStripButtonShowTitle_Click);
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			this.toolStripLabelLonLat.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.toolStripLabelLonLat.Name = "toolStripLabelLonLat";
			this.toolStripLabelLonLat.Size = new System.Drawing.Size(130, 22);
			this.toolStripLabelLonLat.Text = "经度=未知,纬度=未知";
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
			this.toolStripLabelInfo.Font = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.toolStripLabelInfo.Name = "toolStripLabelInfo";
			this.toolStripLabelInfo.Size = new System.Drawing.Size(0, 22);
			this.labelTitle.Font = new System.Drawing.Font("微软雅黑", 14.25f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.labelTitle.Location = new System.Drawing.Point(0, 25);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(613, 30);
			this.labelTitle.TabIndex = 2;
			this.labelTitle.Text = "地图";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			base.Controls.Add(this.panel);
			base.Controls.Add(this.labelTitle);
			base.Controls.Add(this.toolStripControl);
			base.Name = "wMapPictureBox";
			base.Size = new System.Drawing.Size(613, 556);
			this.panel.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.mapPictureBox).EndInit();
			this.contextMenuStripMap.ResumeLayout(false);
			this.toolStripControl.ResumeLayout(false);
			this.toolStripControl.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		public bool LoadStationList(string stationDataPath, bool isLoadToList1)
		{
			bool result;
			try
			{
				if (!System.IO.File.Exists(stationDataPath))
				{
					stationDataPath = System.Windows.Forms.Application.StartupPath + "\\" + stationDataPath;
					if (!System.IO.File.Exists(stationDataPath))
					{
						throw new System.Exception(string.Format("站点数据文件不存在！\n{0}", stationDataPath));
					}
				}
				System.IO.FileStream fs = new System.IO.FileStream(stationDataPath, System.IO.FileMode.Open, System.IO.FileAccess.Read);
				System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
				bool res = false;
				if (isLoadToList1)
				{
					this.LoadStationList1(sr);
				}
				else
				{
					this.LoadStationList2(sr);
				}
				sr.Close();
				fs.Close();
				result = res;
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "读取站点信息错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
			}
			return result;
		}

		public bool LoadStationList1(System.IO.StreamReader sr)
		{
			int ID = 0;
			bool result;
			try
			{
				this.m_StationIDList1.Clear();
				this.m_StationNameList1.Clear();
				this.m_StationPositionList1.Clear();
				this.m_StationInfo1.Clear();
				this.m_SelectedStationIndex1 = -1;
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					string[] Cells = line.Split(new char[]
					{
						',',
						' '
					});
					if (Cells.Length == 3)
					{
						this.m_StationIDList1.Add(ID);
						this.m_StationNameList1.Add(Cells[0]);
						this.m_StationPositionList1.Add(new System.Drawing.PointF(System.Convert.ToSingle(Cells[1]), System.Convert.ToSingle(Cells[2])));
						this.m_StationInfo1.Add("");
					}
					else if (Cells.Length == 4)
					{
						this.m_StationIDList1.Add(System.Convert.ToInt32(Cells[0]));
						this.m_StationNameList1.Add(Cells[1]);
						this.m_StationPositionList1.Add(new System.Drawing.PointF(System.Convert.ToSingle(Cells[2]), System.Convert.ToSingle(Cells[3])));
						this.m_StationInfo1.Add("");
					}
					else if (Cells.Length == 5)
					{
						this.m_StationIDList1.Add(System.Convert.ToInt32(Cells[0]));
						this.m_StationNameList1.Add(Cells[1]);
						this.m_StationPositionList1.Add(new System.Drawing.PointF(System.Convert.ToSingle(Cells[2]), System.Convert.ToSingle(Cells[3])));
						this.m_StationInfo1.Add(Cells[4]);
					}
					ID++;
				}
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message + "\n出错行数：" + (ID + 1).ToString(), "读取站点信息错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_StationIDList1.Clear();
				this.m_StationNameList1.Clear();
				this.m_StationPositionList1.Clear();
				this.m_SelectedStationIndex1 = -1;
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		public bool LoadStationList2(System.IO.StreamReader sr)
		{
			bool result;
			try
			{
				this.m_StationIDList2.Clear();
				this.m_StationNameList2.Clear();
				this.m_StationPositionList2.Clear();
				this.m_StationInfo2.Clear();
				this.m_SelectedStationIndex1 = -1;
				int ID = 0;
				while (!sr.EndOfStream)
				{
					string line = sr.ReadLine();
					string[] Cells = line.Split(new char[]
					{
						',',
						' '
					});
					if (Cells.Length == 3)
					{
						this.m_StationIDList2.Add(ID);
						this.m_StationNameList2.Add(Cells[0]);
						this.m_StationPositionList2.Add(new System.Drawing.PointF(System.Convert.ToSingle(Cells[1]), System.Convert.ToSingle(Cells[2])));
						this.m_StationInfo2.Add("");
					}
					else if (Cells.Length == 4)
					{
						this.m_StationIDList2.Add(System.Convert.ToInt32(Cells[0]));
						this.m_StationNameList2.Add(Cells[1]);
						this.m_StationPositionList2.Add(new System.Drawing.PointF(System.Convert.ToSingle(Cells[2]), System.Convert.ToSingle(Cells[3])));
						this.m_StationInfo2.Add("");
					}
					else if (Cells.Length >= 5)
					{
						this.m_StationIDList2.Add(System.Convert.ToInt32(Cells[0]));
						this.m_StationNameList2.Add(Cells[1]);
						this.m_StationPositionList2.Add(new System.Drawing.PointF(System.Convert.ToSingle(Cells[2]), System.Convert.ToSingle(Cells[3])));
						this.m_StationInfo2.Add(Cells[4]);
					}
					ID++;
				}
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.Message, "读取站点信息错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_StationIDList2.Clear();
				this.m_StationNameList2.Clear();
				this.m_StationPositionList2.Clear();
				this.m_SelectedStationIndex2 = -1;
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		private void toolStripButtonMouseNormal_Click(object sender, System.EventArgs e)
		{
			this.MouseStatus = wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_NORMAL;
		}

		private void toolStripButtonMouseScrach_Click(object sender, System.EventArgs e)
		{
			this.MouseStatus = wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SCRACH;
		}

		private void toolStripButtonMouseSelectStation_Click(object sender, System.EventArgs e)
		{
			this.MouseStatus = wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTPOINT;
		}

		private void toolStripButtonMouseSelectArea_Click(object sender, System.EventArgs e)
		{
			this.MouseStatus = wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTAREA;
		}

		private void toolStripButtonZoomIn_Click(object sender, System.EventArgs e)
		{
			this.toolStripControl.Enabled = false;
			if (this.m_MapParams.PicWidth >= 3000 || this.m_MapParams.PicHeight >= 3000)
			{
				System.Windows.Forms.MessageBox.Show("当前不能放大！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.toolStripControl.Enabled = true;
			}
			else
			{
				int oldPicWidth = this.m_MapParams.PicWidth;
				int oldPicHeight = this.m_MapParams.PicHeight;
				int newPicWidth = this.m_MapParams.PicWidth;
				int newPicHeight = this.m_MapParams.PicHeight;
				int oldZoom = this.m_MapParams.Zoom;
				int newZoom = this.m_MapParams.Zoom;
				double picScale = (double)this.m_MapParams.PicWidth * 1.0 / (double)this.m_MapParams.PicHeight;
				newPicWidth = oldPicWidth + 200;
				newPicHeight = System.Convert.ToInt32((double)newPicWidth / picScale);
				newZoom = System.Convert.ToInt32((double)oldZoom * ((double)newPicWidth * 1.0 / (double)oldPicWidth));
				this.m_MapParams.PicWidth = newPicWidth;
				this.m_MapParams.PicHeight = newPicHeight;
				this.m_MapParams.Zoom = newZoom;
				this.DrawMap();
				if (this.MapZoomed != null)
				{
					this.MapZoomed(this, new System.EventArgs());
				}
				this.toolStripControl.Enabled = true;
			}
		}

		private void toolStripButtonZoomOut_Click(object sender, System.EventArgs e)
		{
			this.toolStripControl.Enabled = false;
			if (this.m_MapParams.PicWidth <= 400 || this.m_MapParams.PicHeight <= 400 || this.m_MapParams.Zoom <= 10)
			{
				System.Windows.Forms.MessageBox.Show("当前不能缩小！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.toolStripControl.Enabled = true;
			}
			else
			{
				int oldPicWidth = this.m_MapParams.PicWidth;
				int oldPicHeight = this.m_MapParams.PicHeight;
				int newPicWidth = this.m_MapParams.PicWidth;
				int newPicHeight = this.m_MapParams.PicHeight;
				int oldZoom = this.m_MapParams.Zoom;
				int newZoom = this.m_MapParams.Zoom;
				double picScale = (double)this.m_MapParams.PicWidth * 1.0 / (double)this.m_MapParams.PicHeight;
				newPicWidth = oldPicWidth - 200;
				newPicHeight = System.Convert.ToInt32((double)newPicWidth / picScale);
				newZoom = System.Convert.ToInt32((double)oldZoom * ((double)newPicWidth * 1.0 / (double)oldPicWidth));
				this.m_MapParams.PicWidth = newPicWidth;
				this.m_MapParams.PicHeight = newPicHeight;
				this.m_MapParams.Zoom = newZoom;
				this.DrawMap();
				if (this.MapZoomed != null)
				{
					this.MapZoomed(this, new System.EventArgs());
				}
				this.toolStripControl.Enabled = true;
			}
		}

		private void toolStripButtonSavePicture_Click(object sender, System.EventArgs e)
		{
			this.saveFileDialog.FileName = this.MapTitle;
			if (this.saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.SavePicture(this.saveFileDialog.FileName);
			}
		}

		private void toolStripButtonSetParams_Click(object sender, System.EventArgs e)
		{
			MapSettingForm msf = new MapSettingForm(this.m_MapParams);
			if (msf.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.InitializeMapControl(this.m_MapParams);
				this.DrawMap();
				this.m_ThumbPictureBox.InitializeThumbMapControl();
				if (this.MapZoomed != null)
				{
					this.MapZoomed(this, new System.EventArgs());
				}
				else if (this.MapRefreshed != null)
				{
					this.MapRefreshed(this, new System.EventArgs());
				}
			}
		}

		private void toolStripButtonRefresh_Click(object sender, System.EventArgs e)
		{
			if (System.Windows.Forms.MessageBox.Show("重绘时会清除当前绘制的结果，确定吗？", "提示", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				this.toolStripControl.Enabled = false;
				this.InitializeMapControl(this.m_MapParams);
				this.DrawMap();
				if (this.MapRefreshed != null)
				{
					this.MapRefreshed(this, new System.EventArgs());
				}
				this.toolStripControl.Enabled = true;
			}
		}

		private void toolStripButtonShowColorBar_Click(object sender, System.EventArgs e)
		{
			this.ShowColorBar = !this.ShowColorBar;
			this.toolStripButtonShowColorBar.Checked = this.ShowColorBar;
			this.mapPictureBox.Refresh();
		}

		private void toolStripButtonShowTitle_Click(object sender, System.EventArgs e)
		{
			this.ShowMapTitle = !this.ShowMapTitle;
			this.toolStripButtonShowTitle.Checked = this.ShowMapTitle;
			this.labelTitle.Height = (this.ShowMapTitle ? 40 : 0);
		}

		private void toolStripButtonShowStation_Click(object sender, System.EventArgs e)
		{
			this.ShowStation = !this.ShowStation;
			this.toolStripButtonShowStation.Checked = this.ShowStation;
			if (!this.toolStripButtonShowStation.Checked)
			{
				if (this.toolStripButtonMouseNormal.Visible)
				{
					this.toolStripButtonMouseNormal_Click(this.toolStripButtonMouseNormal, null);
				}
				else if (this.toolStripButtonMouseScrach.Visible)
				{
					this.toolStripButtonMouseScrach_Click(this.toolStripButtonMouseScrach, null);
				}
			}
			else
			{
				this.toolStripButtonMouseSelectStation_Click(this.toolStripButtonMouseSelectStation, null);
			}
			this.mapPictureBox.Refresh();
		}

		private void toolStripButtonZoomToBest_Click(object sender, System.EventArgs e)
		{
			this.m_AutoZoomMode = wMapPictureBox.AUTOZOOM_MODE.FIT_AUTO;
			this.AutoZoom();
		}

		private void toolStripButtonZoomToWidth_Click(object sender, System.EventArgs e)
		{
			this.m_AutoZoomMode = wMapPictureBox.AUTOZOOM_MODE.FIT_WIDTH;
			this.AutoZoom();
		}

		private void toolStripButtonZoomToHeight_Click(object sender, System.EventArgs e)
		{
			this.m_AutoZoomMode = wMapPictureBox.AUTOZOOM_MODE.FIT_HEIGHT;
			this.AutoZoom();
		}

		private void mapPictureBox_MouseEnter(object sender, System.EventArgs e)
		{
			if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_NORMAL)
			{
				this.Cursor = System.Windows.Forms.Cursors.Default;
			}
			else if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SCRACH)
			{
				this.Cursor = this.m_CursorHandOff;
			}
			else if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTPOINT)
			{
				this.Cursor = System.Windows.Forms.Cursors.Cross;
			}
			else if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTAREA)
			{
				this.Cursor = System.Windows.Forms.Cursors.Cross;
			}
		}

		private void mapPictureBox_MouseLeave(object sender, System.EventArgs e)
		{
			this.Cursor = System.Windows.Forms.Cursors.Default;
		}

		private void mapPictureBox_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.m_Projection != null && this.m_MapParams != null)
			{
				if (this.m_MapParams.PicRect.Contains(e.Location))
				{
					System.Drawing.PointF LonLat = this.m_Projection.XY2LonLat(e.X, e.Y);
					if (this.m_MapParams.CoorUseLonLatType)
					{
						this.toolStripLabelLonLat.Text = string.Format("鼠标位置：经度{0:0.000}{1},纬度{2:0.000}{3}", new object[]
						{
							LonLat.X,
							(LonLat.X < 0f) ? "W" : "E",
							LonLat.Y,
							(LonLat.Y < 0f) ? "S" : "N"
						});
					}
					else
					{
						this.toolStripLabelLonLat.Text = string.Format("鼠标位置：X={0:0.000}{1},Y={2:0.000}{3}", new object[]
						{
							LonLat.X,
							this.m_MapParams.CoorNameX,
							LonLat.Y,
							this.m_MapParams.CoorNameY
						});
					}
					if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SCRACH && this.m_MouseIsDown)
					{
						if (e.Button == System.Windows.Forms.MouseButtons.Left)
						{
							System.Drawing.Point cur = this.panel.PointToClient(this.mapPictureBox.PointToScreen(e.Location));
							cur = new System.Drawing.Point(this.pt.X - cur.X, this.pt.Y - cur.Y);
							cur.X = this.def.X + cur.X;
							cur.Y = this.def.Y + cur.Y;
							if (0 > cur.X)
							{
								cur.X = 0;
							}
							if (0 > cur.Y)
							{
								cur.Y = 0;
							}
							if (this.panel.HorizontalScroll.Visible)
							{
								this.panel.HorizontalScroll.Value = cur.X;
							}
							if (this.panel.VerticalScroll.Visible)
							{
								this.panel.VerticalScroll.Value = cur.Y;
							}
							this.mapPictureBox.Refresh();
						}
					}
					else if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTAREA)
					{
						if (e.Button == System.Windows.Forms.MouseButtons.Left)
						{
							this.m_SelectedRectEndPos = this.m_Projection.XY2LonLat(e.Location);
							float startLon = this.m_SelectedRectStartPos.X;
							float endLon = this.m_SelectedRectEndPos.X;
							float startLat = this.m_SelectedRectEndPos.Y;
							float endLat = this.m_SelectedRectStartPos.Y;
							if (startLon > endLon)
							{
							}
							if (startLat < endLat)
							{
							}
							this.mapPictureBox.Refresh();
						}
					}
					else if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTPOINT)
					{
						bool isSelected = this.m_SelectedStationIndex1 != -1 || this.m_SelectedStationIndex2 != -1;
						if (this.m_StationIDList1 != null && this.m_StationIDList1.Count != 0)
						{
							bool Found = false;
							for (int i = 0; i < this.m_StationIDList1.Count; i++)
							{
								System.Drawing.Point pos = this.m_Projection.LonLat2XY(this.m_StationPositionList1[i].X, this.m_StationPositionList1[i].Y);
								double dis = System.Math.Sqrt((double)((e.X - pos.X) * (e.X - pos.X) + (e.Y - pos.Y) * (e.Y - pos.Y)));
								if (dis <= 4.0)
								{
									Found = true;
									this.m_SelectedStationIndex1 = i;
									break;
								}
							}
							if (!Found)
							{
								if (this.m_SelectedStationIndex1 != -1)
								{
									this.m_SelectedStationIndex1 = -1;
								}
							}
							else if (this.StationSelected != null)
							{
								StationSelectEventArgs arg = new StationSelectEventArgs();
								arg.StationID = this.m_StationIDList1[this.m_SelectedStationIndex1];
								arg.StationName = this.m_StationNameList1[this.m_SelectedStationIndex1];
								arg.StationPoint = this.m_StationPositionList1[this.m_SelectedStationIndex1];
								arg.StationType = 1;
								this.StationSelected(this, arg);
							}
							this.mapPictureBox.Refresh();
						}
						if (this.m_StationIDList2 != null && this.m_StationIDList2.Count != 0)
						{
							bool Found = false;
							for (int i = 0; i < this.m_StationIDList2.Count; i++)
							{
								System.Drawing.Point pos = this.m_Projection.LonLat2XY(this.m_StationPositionList2[i].X, this.m_StationPositionList2[i].Y);
								double dis = System.Math.Sqrt((double)((e.X - pos.X) * (e.X - pos.X) + (e.Y - pos.Y) * (e.Y - pos.Y)));
								if (dis <= 4.0)
								{
									Found = true;
									this.m_SelectedStationIndex2 = i;
									break;
								}
							}
							if (!Found)
							{
								if (this.m_SelectedStationIndex2 != -1)
								{
									this.m_SelectedStationIndex2 = -1;
								}
							}
							else if (this.StationSelected != null)
							{
								StationSelectEventArgs arg = new StationSelectEventArgs();
								arg.StationID = this.m_StationIDList2[this.m_SelectedStationIndex2];
								arg.StationName = this.m_StationNameList2[this.m_SelectedStationIndex2];
								arg.StationPoint = this.m_StationPositionList2[this.m_SelectedStationIndex2];
								arg.StationType = 2;
								this.StationSelected(this, arg);
							}
							this.mapPictureBox.Refresh();
						}
						if (isSelected && this.m_SelectedStationIndex1 == -1 && this.m_SelectedStationIndex2 == -1)
						{
							if (this.StationUnselected != null)
							{
								this.StationUnselected(this, new System.EventArgs());
							}
						}
					}
				}
			}
		}

		private void mapPictureBox_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.m_Projection != null && this.m_MapParams != null)
			{
				if (this.m_MapParams.PicRect.Contains(e.Location))
				{
					this.m_MouseIsDown = true;
					if (e.Button == System.Windows.Forms.MouseButtons.Left)
					{
						if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SCRACH)
						{
							this.m_LastPoint = e.Location;
							this.Cursor = this.m_CursorHandOn;
							this.pt = this.panel.PointToClient(this.mapPictureBox.PointToScreen(e.Location));
							this.def.X = this.panel.HorizontalScroll.Value;
							this.def.Y = this.panel.VerticalScroll.Value;
						}
						else if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTAREA)
						{
							this.m_SelectedRectStartPos = this.m_Projection.XY2LonLat(e.Location);
							this.m_SelectedRectEndPos = System.Drawing.Point.Empty;
							this.mapPictureBox.Refresh();
						}
					}
				}
			}
		}

		private void mapPictureBox_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.m_Projection != null && this.m_MapParams != null)
			{
				this.m_MouseIsDown = false;
				if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SCRACH)
					{
						this.Cursor = this.m_CursorHandOff;
					}
					else if (this.m_MouseStatus == wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SELECTAREA)
					{
						if (!this.m_SelectedRectStartPos.IsEmpty && !this.m_SelectedRectEndPos.IsEmpty)
						{
							this.m_SelectedRectStartPos.X = (float)System.Math.Floor((double)this.m_SelectedRectStartPos.X);
							this.m_SelectedRectStartPos.Y = (float)System.Math.Floor((double)this.m_SelectedRectStartPos.Y);
							this.m_SelectedRectEndPos.X = (float)System.Math.Ceiling((double)this.m_SelectedRectEndPos.X);
							this.m_SelectedRectEndPos.Y = (float)System.Math.Ceiling((double)this.m_SelectedRectEndPos.Y);
							this.mapPictureBox.Refresh();
							if (this.AreaSelected != null)
							{
								System.Drawing.RectangleF selectedRectMap = new System.Drawing.RectangleF(this.m_SelectedRectStartPos.X, this.m_SelectedRectStartPos.Y, this.m_SelectedRectEndPos.X - this.m_SelectedRectStartPos.X, this.m_SelectedRectStartPos.Y - this.m_SelectedRectEndPos.Y);
								this.AreaSelected(this.mapPictureBox, new AreaSelectEventArgs(selectedRectMap));
							}
						}
					}
				}
			}
		}

		private void mapPictureBox_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.m_Projection != null && this.m_MapParams != null)
			{
				if (this.m_MapParams.PicRect.Contains(e.Location))
				{
					System.Drawing.PointF LonLat = this.m_Projection.XY2LonLat(e.X, e.Y);
					if (e.Button == System.Windows.Forms.MouseButtons.Left)
					{
						if (this.m_SelectedStationIndex1 != -1)
						{
							if (this.StationClicked != null)
							{
								StationSelectEventArgs arg = new StationSelectEventArgs();
								arg.StationID = this.m_StationIDList1[this.m_SelectedStationIndex1];
								arg.StationName = this.m_StationNameList1[this.m_SelectedStationIndex1];
								arg.StationPoint = this.m_StationPositionList1[this.m_SelectedStationIndex1];
								arg.StationType = 1;
								this.StationClicked(this, arg);
							}
						}
						if (this.m_SelectedStationIndex2 != -1)
						{
							if (this.StationClicked != null)
							{
								StationSelectEventArgs arg = new StationSelectEventArgs();
								arg.StationID = this.m_StationIDList2[this.m_SelectedStationIndex2];
								arg.StationName = this.m_StationNameList2[this.m_SelectedStationIndex2];
								arg.StationPoint = this.m_StationPositionList2[this.m_SelectedStationIndex2];
								arg.StationType = 2;
								this.StationClicked(this, arg);
							}
						}
					}
				}
			}
		}

		private void mapPictureBox_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (this.m_Projection != null && this.m_MapParams != null)
			{
				if (this.m_MapParams.PicRect.Contains(e.Location))
				{
					System.Drawing.PointF LonLat = this.m_Projection.XY2LonLat(e.X, e.Y);
					if (e.Button == System.Windows.Forms.MouseButtons.Left)
					{
						if (this.m_SelectedStationIndex1 != -1)
						{
							if (this.StationDoubleClicked != null)
							{
								StationSelectEventArgs arg = new StationSelectEventArgs();
								arg.StationID = this.m_StationIDList1[this.m_SelectedStationIndex1];
								arg.StationName = this.m_StationNameList1[this.m_SelectedStationIndex1];
								arg.StationPoint = this.m_StationPositionList1[this.m_SelectedStationIndex1];
								arg.StationType = 1;
								this.StationDoubleClicked(this, arg);
							}
						}
						if (this.m_SelectedStationIndex2 != -1)
						{
							if (this.StationDoubleClicked != null)
							{
								StationSelectEventArgs arg = new StationSelectEventArgs();
								arg.StationID = this.m_StationIDList2[this.m_SelectedStationIndex2];
								arg.StationName = this.m_StationNameList2[this.m_SelectedStationIndex2];
								arg.StationPoint = this.m_StationPositionList2[this.m_SelectedStationIndex2];
								arg.StationType = 2;
								this.StationClicked(this, arg);
							}
						}
					}
				}
			}
		}

		private void mapPictureBox_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (this.m_Projection != null && this.m_MapParams != null)
			{
				System.Drawing.Graphics g = e.Graphics;
				if (this.ShowStation)
				{
					if (this.m_StationIDList1 != null && this.m_StationIDList1.Count != 0)
					{
						int stationFontHeight = this.m_MapParams.StationTextHeight;
						System.Drawing.Font stationFontNormal = new System.Drawing.Font("微软雅黑", (float)stationFontHeight, this.m_MapParams.StationTextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
						System.Drawing.Font stationFontSelect = new System.Drawing.Font("微软雅黑", (float)(stationFontHeight + 2), System.Drawing.FontStyle.Bold);
						System.Drawing.SolidBrush stationBrushStationFore = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorFore1);
						System.Drawing.SolidBrush stationBrushStationBack = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorBack1);
						for (int i = 0; i < this.m_StationIDList1.Count; i++)
						{
							if (i != this.m_SelectedStationIndex1)
							{
								System.Drawing.Point StationPos = this.m_Projection.LonLat2XY(this.m_StationPositionList1[i]);
								if (this.m_MapParams.PicRect.Contains(StationPos))
								{
									double angle = this.m_Projection.GetAngle(this.m_StationPositionList1[i]);
									g.TranslateTransform((float)StationPos.X, (float)StationPos.Y);
									g.RotateTransform((float)angle);
									g.FillEllipse(stationBrushStationFore, -3, -3, 6, 6);
									g.DrawEllipse(new System.Drawing.Pen(stationBrushStationBack), -3, -3, 6, 6);
									g.DrawString(this.m_StationNameList1[i], stationFontNormal, stationBrushStationBack, 0f, 0f);
									g.DrawString(this.m_StationNameList1[i], stationFontNormal, stationBrushStationFore, -1f, -1f);
									g.ResetTransform();
								}
							}
						}
					}
					if (this.m_StationIDList2 != null && this.m_StationIDList2.Count != 0)
					{
						int stationFontHeight = this.m_MapParams.StationTextHeight;
						System.Drawing.Font stationFontNormal = new System.Drawing.Font("微软雅黑", (float)stationFontHeight, this.m_MapParams.StationTextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
						System.Drawing.Font stationFontSelect = new System.Drawing.Font("微软雅黑", (float)(stationFontHeight + 2), System.Drawing.FontStyle.Bold);
						System.Drawing.SolidBrush stationBrushStationFore = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorFore2);
						System.Drawing.SolidBrush stationBrushStationBack = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorBack2);
						for (int i = 0; i < this.m_StationIDList2.Count; i++)
						{
							if (i != this.m_SelectedStationIndex2)
							{
								System.Drawing.Point StationPos = this.m_Projection.LonLat2XY(this.m_StationPositionList2[i]);
								if (this.m_MapParams.PicRect.Contains(StationPos))
								{
									double angle = this.m_Projection.GetAngle(this.m_StationPositionList1[i]);
									g.TranslateTransform((float)StationPos.X, (float)StationPos.Y);
									g.RotateTransform((float)angle);
									g.FillRectangle(stationBrushStationFore, -3, -3, 6, 6);
									g.DrawRectangle(new System.Drawing.Pen(stationBrushStationBack), -3, -3, 6, 6);
									g.DrawString(this.m_StationNameList2[i], stationFontNormal, stationBrushStationBack, 0f, 0f);
									g.DrawString(this.m_StationNameList2[i], stationFontNormal, stationBrushStationFore, -1f, -1f);
									g.ResetTransform();
								}
							}
						}
					}
					if (this.m_StationIDList1 != null && this.m_StationIDList1.Count != 0)
					{
						if (this.m_SelectedStationIndex1 != -1)
						{
							int stationFontHeight = this.m_MapParams.StationTextHeight;
							System.Drawing.Font stationFontNormal = new System.Drawing.Font("微软雅黑", (float)stationFontHeight, this.m_MapParams.StationTextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
							System.Drawing.Font stationFontSelect = new System.Drawing.Font("微软雅黑", (float)(stationFontHeight + 2), System.Drawing.FontStyle.Bold);
							System.Drawing.SolidBrush stationBrushStationFore = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorFore1);
							System.Drawing.SolidBrush stationBrushStationBack = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorBack1);
							System.Drawing.Point StationPos = this.m_Projection.LonLat2XY(this.m_StationPositionList1[this.m_SelectedStationIndex1]);
							double angle = this.m_Projection.GetAngle(this.m_StationPositionList1[this.m_SelectedStationIndex1]);
							g.TranslateTransform((float)StationPos.X, (float)StationPos.Y);
							g.RotateTransform((float)angle);
							g.FillEllipse(stationBrushStationFore, -5, -5, 10, 10);
							g.DrawEllipse(new System.Drawing.Pen(stationBrushStationBack, 2f), -5, -5, 10, 10);
							g.DrawString(this.m_StationNameList1[this.m_SelectedStationIndex1], stationFontSelect, stationBrushStationBack, 0f, 0f);
							g.DrawString(this.m_StationNameList1[this.m_SelectedStationIndex1], stationFontSelect, stationBrushStationFore, -1f, -1f);
							g.ResetTransform();
						}
					}
					if (this.m_StationIDList2 != null && this.m_StationIDList2.Count != 0)
					{
						if (this.m_SelectedStationIndex2 != -1)
						{
							int stationFontHeight = this.m_MapParams.StationTextHeight;
							System.Drawing.Font stationFontNormal = new System.Drawing.Font("微软雅黑", (float)stationFontHeight, this.m_MapParams.StationTextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
							System.Drawing.Font stationFontSelect = new System.Drawing.Font("微软雅黑", (float)(stationFontHeight + 2), System.Drawing.FontStyle.Bold);
							System.Drawing.SolidBrush stationBrushStationFore = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorFore2);
							System.Drawing.SolidBrush stationBrushStationBack = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorBack2);
							System.Drawing.Point StationPos = this.m_Projection.LonLat2XY(this.m_StationPositionList2[this.m_SelectedStationIndex2]);
							double angle = this.m_Projection.GetAngle(this.m_StationPositionList1[this.m_SelectedStationIndex2]);
							g.TranslateTransform((float)StationPos.X, (float)StationPos.Y);
							g.RotateTransform((float)angle);
							g.FillRectangle(stationBrushStationFore, -5, -5, 10, 10);
							g.DrawRectangle(new System.Drawing.Pen(stationBrushStationBack, 2f), -5, -5, 10, 10);
							g.DrawString(this.m_StationNameList2[this.m_SelectedStationIndex2], stationFontSelect, stationBrushStationBack, 0f, 0f);
							g.DrawString(this.m_StationNameList2[this.m_SelectedStationIndex2], stationFontSelect, stationBrushStationFore, 0f, 0f);
						}
					}
				}
				if (!this.m_SelectedRectStartPos.IsEmpty && !this.m_SelectedRectEndPos.IsEmpty)
				{
					float startLon = this.m_SelectedRectStartPos.X;
					float startLat = this.m_SelectedRectStartPos.Y;
					float endLon = this.m_SelectedRectEndPos.X;
					float endLat = this.m_SelectedRectEndPos.Y;
					System.Drawing.Drawing2D.GraphicsPath selectedRectPath = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
					System.Collections.Generic.List<System.Drawing.Point> pathLine = new System.Collections.Generic.List<System.Drawing.Point>();
					pathLine.Add(this.m_Projection.LonLat2XY(startLon, startLat));
					pathLine.Add(this.m_Projection.LonLat2XY(startLon, endLat));
					for (float curLon = startLon; curLon <= endLon; curLon += 1f)
					{
						pathLine.Add(this.m_Projection.LonLat2XY(curLon, endLat));
					}
					pathLine.Add(this.m_Projection.LonLat2XY(endLon, endLat));
					pathLine.Add(this.m_Projection.LonLat2XY(endLon, startLat));
					for (float curLon = endLon; curLon >= startLon; curLon -= 1f)
					{
						pathLine.Add(this.m_Projection.LonLat2XY(curLon, startLat));
					}
					selectedRectPath.AddLines(pathLine.ToArray());
					g.FillPath(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(100, System.Drawing.Color.Yellow)), selectedRectPath);
					g.DrawPath(new System.Drawing.Pen(System.Drawing.Color.Yellow, 2f), selectedRectPath);
					System.Drawing.Point startPoint = this.m_Projection.LonLat2XY(this.m_SelectedRectStartPos);
					System.Drawing.Point endPoint = this.m_Projection.LonLat2XY(this.m_SelectedRectEndPos);
					System.Drawing.Font myFont = new System.Drawing.Font("微软雅黑", 9f);
					string myString = string.Format("({0:0.00},{1:0.00})", startLon, startLat);
					g.DrawString(myString, myFont, new System.Drawing.SolidBrush(System.Drawing.Color.Red), new System.Drawing.PointF((float)(startPoint.X - myString.Length * 4), (float)(startPoint.Y - 13)));
					myString = string.Format("({0:0.00},{1:0.00})", endLon, endLat);
					g.DrawString(myString, myFont, new System.Drawing.SolidBrush(System.Drawing.Color.Red), new System.Drawing.PointF((float)(endPoint.X - myString.Length * 4), (float)endPoint.Y));
				}
				if (this.ShowColorBar && this.ColorBarBitmap != null)
				{
					int MinX = -this.mapPictureBox.Location.X;
					int MinY = -this.mapPictureBox.Location.Y;
					if (MinX < 0)
					{
						MinX = 0;
					}
					if (MinY < 0)
					{
						MinY = 0;
					}
					g.DrawImage(this.ColorBarBitmap, new System.Drawing.Rectangle(MinX + this.m_ColorBarPos.X, MinY + this.m_ColorBarPos.Y, this.m_ColorBarWidth, this.m_ColorBarHeight * this.m_ColorBarNum), new System.Drawing.Rectangle(0, 0, this.m_ColorBarWidth, this.m_ColorBarHeight * this.m_ColorBarNum), System.Drawing.GraphicsUnit.Pixel);
				}
			}
		}

		private void 鼠标正常状态ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.toolStripButtonMouseNormal_Click(this.toolStripButtonMouseNormal, new System.EventArgs());
			this.鼠标正常状态ToolStripMenuItem.Checked = this.toolStripButtonMouseNormal.Checked;
			this.拖动地图ToolStripMenuItem.Checked = this.toolStripButtonMouseScrach.Checked;
			this.选择站点ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectStation.Checked;
			this.选择区域ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectArea.Checked;
		}

		private void 拖动地图ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.toolStripButtonMouseScrach_Click(this.toolStripButtonMouseScrach, new System.EventArgs());
			this.鼠标正常状态ToolStripMenuItem.Checked = this.toolStripButtonMouseNormal.Checked;
			this.拖动地图ToolStripMenuItem.Checked = this.toolStripButtonMouseScrach.Checked;
			this.选择站点ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectStation.Checked;
			this.选择区域ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectArea.Checked;
		}

		private void 选择站点ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.toolStripButtonMouseSelectStation_Click(this.toolStripButtonMouseSelectStation, new System.EventArgs());
			this.鼠标正常状态ToolStripMenuItem.Checked = this.toolStripButtonMouseNormal.Checked;
			this.拖动地图ToolStripMenuItem.Checked = this.toolStripButtonMouseScrach.Checked;
			this.选择站点ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectStation.Checked;
			this.选择区域ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectArea.Checked;
		}

		private void 选择区域ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.toolStripButtonMouseSelectArea_Click(this.toolStripButtonMouseSelectArea, new System.EventArgs());
			this.鼠标正常状态ToolStripMenuItem.Checked = this.toolStripButtonMouseNormal.Checked;
			this.拖动地图ToolStripMenuItem.Checked = this.toolStripButtonMouseScrach.Checked;
			this.选择站点ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectStation.Checked;
			this.选择区域ToolStripMenuItem.Checked = this.toolStripButtonMouseSelectArea.Checked;
		}

		private void 放大地图ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.toolStripButtonZoomIn_Click(this.toolStripButtonZoomIn, new System.EventArgs());
		}

		private void 缩小地图ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.toolStripButtonZoomOut_Click(this.toolStripButtonZoomOut, new System.EventArgs());
		}

		private void 重绘地图ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.toolStripButtonRefresh_Click(this.toolStripButtonRefresh, new System.EventArgs());
		}

		private void 保存当前地图ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.toolStripButtonSavePicture_Click(this.toolStripButtonSavePicture, new System.EventArgs());
		}

		private void 设置地图参数ToolStripMenuItem_Click(object sender, System.EventArgs e)
		{
			this.toolStripButtonSetParams_Click(this.toolStripButtonSetParams, new System.EventArgs());
		}

		private void contextMenuStripMap_Opening(object sender, System.ComponentModel.CancelEventArgs e)
		{
			this.鼠标正常状态ToolStripMenuItem.Visible = this.toolStripButtonMouseNormal.Visible;
			this.拖动地图ToolStripMenuItem.Visible = this.toolStripButtonMouseScrach.Visible;
			this.选择站点ToolStripMenuItem.Visible = this.toolStripButtonMouseSelectStation.Visible;
			this.选择区域ToolStripMenuItem.Visible = this.toolStripButtonMouseSelectArea.Visible;
			this.放大地图ToolStripMenuItem.Visible = this.toolStripButtonZoomIn.Visible;
			this.缩小地图ToolStripMenuItem.Visible = this.toolStripButtonZoomOut.Visible;
			this.重绘地图ToolStripMenuItem.Visible = this.toolStripButtonRefresh.Visible;
			this.保存当前地图ToolStripMenuItem.Visible = this.toolStripButtonSavePicture.Visible;
			this.设置地图参数ToolStripMenuItem.Visible = this.toolStripButtonSetParams.Visible;
		}

		public wMapPictureBox()
		{
			this.InitializeComponent();
		}

		public void InitializeMapControl()
		{
			MapParams mapParams = new MapParams();
			mapParams.LoadParams();
			this.InitializeMapControl(mapParams);
		}

		public void InitializeMapControl(MapParams mapParams)
		{
			this.m_MapParams = mapParams;
			if (this.m_ThumbPictureBox == null)
			{
				this.m_ThumbPictureBox = new wMapThumbPictureBox();
			}
			this.m_ThumbPictureBox.AttachMapPictureBox(this);
			System.IO.MemoryStream msHandOn = new System.IO.MemoryStream(Resources.HandOn);
			System.IO.MemoryStream msHandOff = new System.IO.MemoryStream(Resources.HandOff);
			this.m_CursorHandOn = new System.Windows.Forms.Cursor(msHandOn);
			this.m_CursorHandOff = new System.Windows.Forms.Cursor(msHandOff);
			msHandOn.Close();
			msHandOff.Close();
			if (this.m_MapParams.StationDataPath1 != "")
			{
				this.LoadStationList(this.m_MapParams.StationDataPath1, true);
			}
			if (this.m_MapParams.StationDataPath2 != "")
			{
				this.LoadStationList(this.m_MapParams.StationDataPath2, false);
			}
			this.m_ColorBarPos = this.m_MapParams.ColorBarPos;
			this.m_ColorBarWidth = this.m_MapParams.ColorBarWidth;
			this.m_ColorBarHeight = this.m_MapParams.ColorBarHeight;
			this.ColorBarBitmap = null;
			this.MapTitle = this.m_MapParams.DefaultMapTitle;
			this.ShowColorBar = false;
			this.ShowMapTitle = (this.MapTitle != "");
			this.ShowStation = mapParams.WantStation;
		}

		public void SetThumbPictureBoxControl(wMapThumbPictureBox thumbPictureBoxControl)
		{
			this.m_ThumbPictureBox = thumbPictureBoxControl;
		}

		public System.Windows.Forms.PictureBox GetPictureBox()
		{
			return this.mapPictureBox;
		}

		public Projection GetMapProjection()
		{
			return this.m_Projection;
		}

		public MapParams GetMapParams()
		{
			return this.m_MapParams;
		}

		public void DrawMap()
		{
			if (this.m_MapParams != null)
			{
				this.m_Projection = this.m_MapParams.GetProjection();
				System.Drawing.Bitmap m_MapPic = this.m_MapParams.DrawMap(this.m_Projection);
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(m_MapPic);
				this.DrawEdgeRect(g);
				this.DrawLonLatText(g);
				g.Dispose();
				this.mapPictureBox.Width = m_MapPic.Width;
				this.mapPictureBox.Height = m_MapPic.Height;
				this.mapPictureBox.Image = m_MapPic;
				System.Drawing.PointF centerPoint = new System.Drawing.PointF(this.m_MapParams.CenterLon, this.m_MapParams.CenterLat);
				if (this.m_ThumbPictureBox != null && !this.m_ThumbPictureBox.SelectedPos.IsEmpty)
				{
					this.ShowMapPoint(this.m_ThumbPictureBox.SelectedPos);
				}
				else
				{
					this.ShowMapPoint(centerPoint);
				}
				this.ColorBarBitmap = null;
				this.labelTitle.Size = new System.Drawing.Size(m_MapPic.Width, this.labelTitle.Size.Height);
			}
		}

		public void ShowMapPoint(System.Drawing.PointF showPoint)
		{
			bool flag = 0 == 0;
			System.Drawing.Point XY = this.m_Projection.LonLat2XY(showPoint.X, showPoint.Y);
			int posX = XY.X - this.panel.Width / 2;
			if (posX > this.panel.HorizontalScroll.Maximum)
			{
				posX = this.panel.HorizontalScroll.Maximum;
			}
			if (posX < 0)
			{
				posX = 0;
			}
			int posY = XY.Y - this.panel.Height / 2;
			if (posY > this.panel.Width)
			{
				posY = this.panel.Width;
			}
			if (posY < 0)
			{
				posY = 0;
			}
			if (this.panel.HorizontalScroll.Visible && posX < this.panel.HorizontalScroll.Maximum)
			{
				this.panel.HorizontalScroll.Value = posX;
			}
			if (this.panel.VerticalScroll.Visible && posY < this.panel.VerticalScroll.Maximum)
			{
				this.panel.VerticalScroll.Value = posY;
			}
			this.mapPictureBox.Refresh();
		}

		public System.Drawing.PointF[] GetVisableArea()
		{
			int MinX = -this.mapPictureBox.Location.X;
			int MinY = -this.mapPictureBox.Location.Y;
			int MaxX = MinX;
			int MaxY = MinY;
			if (this.mapPictureBox.Width <= this.panel.Width)
			{
				MaxX += this.mapPictureBox.Width;
			}
			else
			{
				MaxX += this.panel.Width;
			}
			if (this.mapPictureBox.Height <= this.panel.Height)
			{
				MaxY += this.mapPictureBox.Height;
			}
			else
			{
				MaxY += this.panel.Height;
			}
			if (this.panel.HorizontalScroll.Visible)
			{
				MaxX -= 25;
			}
			if (this.panel.VerticalScroll.Visible)
			{
				MaxY -= 25;
			}
			MinX += this.m_MapParams.m_EdgeLeft;
			MaxX -= this.m_MapParams.m_EdgeRight;
			MinY += this.m_MapParams.m_EdgeTop;
			MaxY -= this.m_MapParams.m_EdgeBottom;
			return new System.Drawing.PointF[]
			{
				this.m_Projection.XY2LonLat(MinX, MinY),
				this.m_Projection.XY2LonLat(MaxX, MaxY)
			};
		}

		public void DrawColorBar(bool WantReset, string ColorBarName, ColorManager curveColorManager, ColorManager fillColorManager)
		{
			if (this.ColorBarBitmap == null)
			{
				this.ColorBarBitmap = new System.Drawing.Bitmap(this.m_ColorBarWidth, this.m_ColorBarHeight * 5);
			}
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(this.ColorBarBitmap);
			if (WantReset || this.m_ColorBarNum == 5)
			{
				this.m_ColorBarNum = 0;
				g.Clear(System.Drawing.Color.FromArgb(200, 255, 255, 254));
			}
			this.m_ColorBarNum++;
			g.TranslateTransform(10f, (float)(this.m_ColorBarHeight * this.m_ColorBarNum - this.m_ColorBarHeight));
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
			if (curveColorManager.m_ColorItems.Count != fillColorManager.m_ColorItems.Count)
			{
				g.Dispose();
			}
			else
			{
				int Block = 20;
				int Step;
				if (curveColorManager.m_ColorItems.Count < Block)
				{
					Step = 1;
					Block = curveColorManager.m_ColorItems.Count;
				}
				else
				{
					Step = System.Convert.ToInt32((double)curveColorManager.m_ColorItems.Count / ((double)Block * 1.0) + 0.5);
					Block = System.Convert.ToInt32((double)curveColorManager.m_ColorItems.Count / ((double)Step * 1.0) + 0.5);
				}
				System.Drawing.Rectangle ColorBarRectangle = new System.Drawing.Rectangle(10, 0, this.m_ColorBarWidth - 10, this.m_ColorBarHeight);
				int BlockWidth = ColorBarRectangle.Width / (Block + 1);
				int BlockHeight = ColorBarRectangle.Height / 4;
				System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular);
				System.Drawing.SolidBrush myFontBrushFore = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				System.Drawing.StringFormat myFormat = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				myFormat.LineAlignment = System.Drawing.StringAlignment.Far;
				myFormat.Alignment = System.Drawing.StringAlignment.Center;
				System.Drawing.Point myFontPos = new System.Drawing.Point(ColorBarRectangle.X + ColorBarRectangle.Width / 2, ColorBarRectangle.Y + ColorBarRectangle.Height / 2 - 7);
				g.DrawString(ColorBarName, myFont, myFontBrushFore, myFontPos, myFormat);
				int i = 0;
				while (i < fillColorManager.m_ColorItems.Count && i < Block * Step)
				{
					System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(fillColorManager.m_ColorItems[i].myColor);
					System.Drawing.Rectangle myRect = new System.Drawing.Rectangle(ColorBarRectangle.X + i * BlockWidth / Step, ColorBarRectangle.Y + 2 * BlockHeight, BlockWidth, BlockHeight);
					g.FillRectangle(myBrush, myRect);
					i += Step;
				}
				i = 0;
				while (i < fillColorManager.m_ColorItems.Count && i < Block * Step)
				{
					System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black, 1f);
					System.Drawing.Rectangle myRect = new System.Drawing.Rectangle(ColorBarRectangle.X + i * BlockWidth / Step, ColorBarRectangle.Y + 2 * BlockHeight, BlockWidth, BlockHeight);
					g.DrawRectangle(myPen, myRect);
					i += Step;
				}
				myFont = new System.Drawing.Font("宋体", 7f, System.Drawing.FontStyle.Regular);
				i = 0;
				while (i < curveColorManager.m_ColorItems.Count && i < Block * Step)
				{
					if (i / Step % 2 == 0)
					{
						myFontPos = new System.Drawing.Point(ColorBarRectangle.X + i * BlockWidth / Step, ColorBarRectangle.Y + 2 * BlockHeight);
						myFormat.LineAlignment = System.Drawing.StringAlignment.Far;
					}
					else
					{
						myFontPos = new System.Drawing.Point(ColorBarRectangle.X + i * BlockWidth / Step, ColorBarRectangle.Y + 3 * BlockHeight);
						myFormat.LineAlignment = System.Drawing.StringAlignment.Near;
					}
					g.DrawString(fillColorManager.m_ColorItems[i].myValueText, myFont, myFontBrushFore, myFontPos, myFormat);
					i += Step;
				}
				g.Dispose();
				this.ColorBarBitmap.MakeTransparent(System.Drawing.Color.White);
			}
		}

		public void DrawVectorColor(bool WantReset, string ColorBarName, ColorManager curveColorManager, ColorManager fillColorManager)
		{
			if (this.ColorBarBitmap == null)
			{
				this.ColorBarBitmap = new System.Drawing.Bitmap(this.m_ColorBarWidth, this.m_ColorBarHeight);
			}
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(this.ColorBarBitmap);
			if (WantReset || this.m_ColorBarNum == 5)
			{
				this.m_ColorBarNum = 0;
				g.Clear(System.Drawing.Color.FromArgb(200, 255, 255, 254));
			}
			this.m_ColorBarNum++;
			g.TranslateTransform(10f, (float)(this.m_ColorBarHeight * this.m_ColorBarNum - this.m_ColorBarHeight));
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
			if (curveColorManager.m_ColorItems.Count != fillColorManager.m_ColorItems.Count)
			{
				g.Dispose();
			}
			else
			{
				int Block = 30;
				int Step;
				if (curveColorManager.m_ColorItems.Count < Block)
				{
					Step = 1;
					Block = curveColorManager.m_ColorItems.Count;
				}
				else
				{
					Step = System.Convert.ToInt32((double)curveColorManager.m_ColorItems.Count / ((double)Block * 1.0) + 0.5);
					Block = System.Convert.ToInt32((double)curveColorManager.m_ColorItems.Count / ((double)Step * 1.0) + 0.5);
				}
				System.Drawing.Rectangle ColorBarRectangle = new System.Drawing.Rectangle(0, 0, this.m_ColorBarWidth - 10, this.m_ColorBarHeight);
				int BlockWidth = ColorBarRectangle.Width / (Block + 1);
				int BlockHeight = ColorBarRectangle.Height / 4;
				System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular);
				System.Drawing.SolidBrush myFontBrushFore = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				System.Drawing.StringFormat myFormat = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				myFormat.LineAlignment = System.Drawing.StringAlignment.Far;
				myFormat.Alignment = System.Drawing.StringAlignment.Center;
				System.Drawing.Point myFontPos = new System.Drawing.Point(ColorBarRectangle.X + ColorBarRectangle.Width / 2, ColorBarRectangle.Y + ColorBarRectangle.Height / 2 - 7);
				g.DrawString(ColorBarName, myFont, myFontBrushFore, myFontPos, myFormat);
				int i = 0;
				while (i < fillColorManager.m_ColorItems.Count && i < Block * Step)
				{
					System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(fillColorManager.m_ColorItems[i].myColor);
					System.Drawing.Rectangle myRect = new System.Drawing.Rectangle(ColorBarRectangle.X + i * BlockWidth / Step, ColorBarRectangle.Y + 2 * BlockHeight, BlockWidth, BlockHeight);
					g.FillRectangle(myBrush, myRect);
					i += Step;
				}
				i = 0;
				while (i < fillColorManager.m_ColorItems.Count && i < Block * Step)
				{
					System.Drawing.Pen myPen = new System.Drawing.Pen(System.Drawing.Color.Black, 1f);
					System.Drawing.Rectangle myRect = new System.Drawing.Rectangle(ColorBarRectangle.X + i * BlockWidth / Step, ColorBarRectangle.Y + 2 * BlockHeight, BlockWidth, BlockHeight);
					g.DrawRectangle(myPen, myRect);
					i += Step;
				}
				myFont = new System.Drawing.Font("宋体", 7f, System.Drawing.FontStyle.Regular);
				i = 0;
				while (i < curveColorManager.m_ColorItems.Count && i < Block * Step)
				{
					if (i / Step % 2 == 0)
					{
						myFontPos = new System.Drawing.Point(ColorBarRectangle.X + i * BlockWidth / Step + BlockWidth / 2, ColorBarRectangle.Y + 2 * BlockHeight);
						myFormat.LineAlignment = System.Drawing.StringAlignment.Far;
					}
					else
					{
						myFontPos = new System.Drawing.Point(ColorBarRectangle.X + i * BlockWidth / Step + BlockWidth / 2, ColorBarRectangle.Y + 3 * BlockHeight);
						myFormat.LineAlignment = System.Drawing.StringAlignment.Near;
					}
					g.DrawString(fillColorManager.m_ColorItems[i].myValueText, myFont, myFontBrushFore, myFontPos, myFormat);
					i += Step;
				}
				g.Dispose();
				this.ColorBarBitmap.MakeTransparent(System.Drawing.Color.White);
			}
		}

		public void DrawVectorColor(bool WantReset, string ColorBarName, VectorParams vectorParams)
		{
			if (this.ColorBarBitmap == null)
			{
				this.ColorBarBitmap = new System.Drawing.Bitmap(this.m_ColorBarWidth, this.m_ColorBarHeight);
			}
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(this.ColorBarBitmap);
			if (WantReset || this.m_ColorBarNum == 5)
			{
				this.m_ColorBarNum = 0;
				g.Clear(System.Drawing.Color.FromArgb(200, 255, 255, 254));
			}
			this.m_ColorBarNum++;
			g.TranslateTransform(10f, (float)(this.m_ColorBarHeight * this.m_ColorBarNum - this.m_ColorBarHeight));
			g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixelGridFit;
			ColorManager curveColorManager = vectorParams.m_VectorLevelColorManager1;
			ColorManager fillColorManager = vectorParams.m_VectorLevelColorManager2;
			if (curveColorManager.m_ColorItems.Count != fillColorManager.m_ColorItems.Count)
			{
				g.Dispose();
			}
			else
			{
				int Block = 20;
				int Step;
				if (curveColorManager.m_ColorItems.Count < Block)
				{
					Step = 1;
					Block = curveColorManager.m_ColorItems.Count;
				}
				else
				{
					Step = System.Convert.ToInt32((double)curveColorManager.m_ColorItems.Count / ((double)Block * 1.0) + 0.5);
					Block = System.Convert.ToInt32((double)curveColorManager.m_ColorItems.Count / ((double)Step * 1.0) + 0.5);
				}
				System.Drawing.Rectangle ColorBarRectangle = new System.Drawing.Rectangle(0, 0, this.m_ColorBarWidth - 10, this.m_ColorBarHeight);
				int BlockWidth = ColorBarRectangle.Width / (Block + 1);
				int BlockHeight = ColorBarRectangle.Height / 4;
				System.Drawing.Font myFont = new System.Drawing.Font("宋体", 9f, System.Drawing.FontStyle.Regular);
				System.Drawing.SolidBrush myFontBrushFore = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
				System.Drawing.StringFormat myFormat = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				myFormat.LineAlignment = System.Drawing.StringAlignment.Far;
				myFormat.Alignment = System.Drawing.StringAlignment.Center;
				System.Drawing.Point myFontPos = new System.Drawing.Point(ColorBarRectangle.X + ColorBarRectangle.Width / 2, ColorBarRectangle.Y + ColorBarRectangle.Height / 2 - 7);
				g.DrawString(ColorBarName, myFont, myFontBrushFore, myFontPos, myFormat);
				double a150 = 2.9670666666666667;
				int i = 0;
				while (i < curveColorManager.m_ColorItems.Count && i < Block * Step)
				{
					System.Drawing.Rectangle myRect = new System.Drawing.Rectangle(ColorBarRectangle.X + i * BlockWidth / Step, ColorBarRectangle.Y + 2 * BlockHeight, BlockWidth, BlockHeight);
					System.Drawing.Pen thisArrowPen = new System.Drawing.Pen(fillColorManager.m_ColorItems[i].myColor, 1f);
					int X = myRect.Left;
					int X2 = myRect.Right - 5;
					int Y = myRect.Y + myRect.Height / 2;
					int Y2 = Y;
					double thisArrowLen = System.Convert.ToDouble(myRect.Width);
					if (vectorParams.VectorArrowType == 1)
					{
						VectorParams.DrawArrow(g, thisArrowPen, (int)thisArrowLen, (float)a150, X, Y, X2, Y2);
					}
					else if (vectorParams.VectorArrowType == 2)
					{
						VectorParams.DrawWind(g, thisArrowPen, (int)thisArrowLen, (int)fillColorManager.m_ColorItems[i].myValue, 80f, X, Y);
					}
					i += Step;
				}
				myFont = new System.Drawing.Font("宋体", 7f, System.Drawing.FontStyle.Regular);
				i = 0;
				while (i < curveColorManager.m_ColorItems.Count && i < Block * Step)
				{
					if (i / Step % 2 == 0)
					{
						myFontPos = new System.Drawing.Point(ColorBarRectangle.X + i * BlockWidth / Step + BlockWidth / 2, ColorBarRectangle.Y + 2 * BlockHeight + 5);
						myFormat.LineAlignment = System.Drawing.StringAlignment.Far;
					}
					else
					{
						myFontPos = new System.Drawing.Point(ColorBarRectangle.X + i * BlockWidth / Step + BlockWidth / 2, ColorBarRectangle.Y + 3 * BlockHeight - 5);
						myFormat.LineAlignment = System.Drawing.StringAlignment.Near;
					}
					g.DrawString(curveColorManager.m_ColorItems[i].myValueText, myFont, myFontBrushFore, myFontPos, myFormat);
					i += Step;
				}
				g.Dispose();
				this.ColorBarBitmap.MakeTransparent(System.Drawing.Color.White);
			}
		}

		public void DrawTitle(System.Drawing.Graphics g, System.Drawing.Point ptTitle)
		{
			int FontSize = 14;
			System.Drawing.Color FontForeColor = System.Drawing.Color.Black;
			System.Drawing.Color FontBackColor = System.Drawing.Color.White;
			System.Drawing.Font myFont = new System.Drawing.Font("微软雅黑", (float)FontSize, System.Drawing.FontStyle.Bold);
			System.Drawing.SolidBrush myFontBrushFore = new System.Drawing.SolidBrush(FontForeColor);
			System.Drawing.SolidBrush myFontBrushBack = new System.Drawing.SolidBrush(FontBackColor);
			System.Drawing.StringFormat myFormat = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
			myFormat.LineAlignment = System.Drawing.StringAlignment.Center;
			myFormat.Alignment = System.Drawing.StringAlignment.Center;
			g.TranslateTransform((float)ptTitle.X, (float)ptTitle.Y);
			g.DrawString(this.m_MapTitle, myFont, myFontBrushBack, new System.Drawing.PointF(1f, 1f), myFormat);
			g.DrawString(this.m_MapTitle, myFont, myFontBrushFore, new System.Drawing.PointF(0f, 0f), myFormat);
			g.ResetTransform();
		}

		public void DrawEdgeRect(System.Drawing.Graphics g)
		{
			int PicWidth = this.m_MapParams.PicWidth;
			int PicHeight = this.m_MapParams.PicHeight;
			System.Drawing.SolidBrush brushEdge = new System.Drawing.SolidBrush(System.Drawing.Color.White);
			System.Drawing.Rectangle rect = new System.Drawing.Rectangle(0, 0, PicWidth, this.m_MapParams.m_EdgeTop);
			System.Drawing.Rectangle rect2 = new System.Drawing.Rectangle(0, PicHeight - this.m_MapParams.m_EdgeBottom, PicWidth, this.m_MapParams.m_EdgeBottom);
			System.Drawing.Rectangle rect3 = new System.Drawing.Rectangle(0, 0, this.m_MapParams.m_EdgeLeft, PicHeight);
			System.Drawing.Rectangle rect4 = new System.Drawing.Rectangle(PicWidth - this.m_MapParams.m_EdgeRight, 0, this.m_MapParams.m_EdgeRight, PicHeight);
			g.FillRectangle(brushEdge, rect);
			g.FillRectangle(brushEdge, rect2);
			g.FillRectangle(brushEdge, rect3);
			g.FillRectangle(brushEdge, rect4);
			System.Drawing.Rectangle rectEdge = new System.Drawing.Rectangle(this.m_MapParams.m_EdgeLeft, this.m_MapParams.m_EdgeTop, PicWidth - this.m_MapParams.m_EdgeLeft - this.m_MapParams.m_EdgeRight, PicHeight - this.m_MapParams.m_EdgeTop - this.m_MapParams.m_EdgeBottom);
			System.Drawing.Pen penEdge = new System.Drawing.Pen(System.Drawing.Color.Black, 2f);
			g.DrawRectangle(penEdge, rectEdge);
		}

		public void DrawLonLatText(System.Drawing.Graphics g)
		{
			this.m_MapParams.DrawLonLatText(g, this.m_Projection);
		}

		public bool SavePicture(string picPath)
		{
			return this.SavePicture(picPath, null, false);
		}

		public bool SavePicture(string picPath, System.Drawing.Imaging.ImageFormat imageFormat, bool showMessage)
		{
			bool result;
			try
			{
				System.Drawing.Bitmap newBitmap = (System.Drawing.Bitmap)this.mapPictureBox.Image.Clone();
				System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(newBitmap);
				if (this.m_Projection != null)
				{
					this.m_MapParams.DrawLonLatText(g, this.m_Projection);
				}
				if (this.ShowStation)
				{
					if (this.m_StationIDList1 != null && this.m_StationIDList1.Count != 0)
					{
						int stationFontHeight = this.m_MapParams.StationTextHeight;
						System.Drawing.Font stationFontNormal = new System.Drawing.Font("微软雅黑", (float)stationFontHeight, this.m_MapParams.StationTextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
						System.Drawing.SolidBrush stationBrushStationFore = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorFore1);
						System.Drawing.SolidBrush stationBrushStationBack = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorBack1);
						for (int i = 0; i < this.m_StationIDList1.Count; i++)
						{
							if (i != this.m_SelectedStationIndex1)
							{
								System.Drawing.Point StationPos = this.m_Projection.LonLat2XY(this.m_StationPositionList1[i].X, this.m_StationPositionList1[i].Y);
								if (this.m_MapParams.PicRect.Contains(StationPos))
								{
									g.FillEllipse(stationBrushStationFore, StationPos.X - 3, StationPos.Y - 3, 6, 6);
									g.DrawEllipse(new System.Drawing.Pen(stationBrushStationBack), StationPos.X - 3, StationPos.Y - 3, 6, 6);
									g.DrawString(this.m_StationNameList1[i], stationFontNormal, stationBrushStationBack, StationPos);
									StationPos.Offset(-1, -1);
									g.DrawString(this.m_StationNameList1[i], stationFontNormal, stationBrushStationFore, StationPos);
								}
							}
						}
					}
					if (this.m_StationIDList2 != null && this.m_StationIDList2.Count != 0)
					{
						int stationFontHeight = this.m_MapParams.StationTextHeight;
						System.Drawing.Font stationFontNormal = new System.Drawing.Font("微软雅黑", (float)stationFontHeight, this.m_MapParams.StationTextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
						System.Drawing.SolidBrush stationBrushStationFore = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorFore2);
						System.Drawing.SolidBrush stationBrushStationBack = new System.Drawing.SolidBrush(this.m_MapParams.StationTextColorBack2);
						for (int i = 0; i < this.m_StationIDList2.Count; i++)
						{
							if (i != this.m_SelectedStationIndex2)
							{
								System.Drawing.Point StationPos = this.m_Projection.LonLat2XY(this.m_StationPositionList2[i].X, this.m_StationPositionList2[i].Y);
								if (this.m_MapParams.PicRect.Contains(StationPos))
								{
									g.FillRectangle(stationBrushStationFore, StationPos.X - 3, StationPos.Y - 3, 6, 6);
									g.DrawRectangle(new System.Drawing.Pen(stationBrushStationBack), StationPos.X - 3, StationPos.Y - 3, 6, 6);
									g.DrawString(this.m_StationNameList2[i], stationFontNormal, stationBrushStationBack, StationPos);
									StationPos.Offset(-1, -1);
									g.DrawString(this.m_StationNameList2[i], stationFontNormal, stationBrushStationFore, StationPos);
								}
							}
						}
					}
				}
				if (this.ShowColorBar && this.ColorBarBitmap != null)
				{
					g.DrawImage(this.ColorBarBitmap, new System.Drawing.Rectangle(this.m_ColorBarPos.X, this.m_ColorBarPos.Y, this.m_ColorBarWidth, this.m_ColorBarHeight * this.m_ColorBarNum), new System.Drawing.Rectangle(0, 0, this.m_ColorBarWidth, this.m_ColorBarHeight * this.m_ColorBarNum), System.Drawing.GraphicsUnit.Pixel);
				}
				g.Dispose();
				if (this.m_MapTitle != "" && this.ShowMapTitle)
				{
					System.Drawing.Bitmap tmpBitmap = new System.Drawing.Bitmap(newBitmap.Width, newBitmap.Height + 50);
					g = System.Drawing.Graphics.FromImage(tmpBitmap);
					g.Clear(System.Drawing.Color.White);
					g.DrawImage(newBitmap, new System.Drawing.Point(0, 50));
					this.DrawTitle(g, new System.Drawing.Point(newBitmap.Width / 2, 25));
					g.Dispose();
					newBitmap.Dispose();
					newBitmap = tmpBitmap;
				}
				if (imageFormat == null)
				{
					imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
					string exe = System.IO.Path.GetExtension(picPath).ToUpper();
					if (exe == ".BMP")
					{
						imageFormat = System.Drawing.Imaging.ImageFormat.Bmp;
					}
					else if (exe == ".JPG")
					{
						imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
					}
				}
				newBitmap.Save(picPath, imageFormat);
				newBitmap.Dispose();
			}
			catch (System.Exception ex)
			{
				if (showMessage)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
				result = false;
				return result;
			}
			if (showMessage)
			{
				System.Windows.Forms.MessageBox.Show("图片保存成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
			}
			result = true;
			return result;
		}

		public void AutoZoom()
		{
			if (this.m_MapParams != null)
			{
				int panelWidth = this.panel.Width - 30;
				int panelHeight = this.panel.Height - 30;
				double panelScale = (double)panelWidth * 1.0 / (double)panelHeight;
				double picScale = (double)this.m_MapParams.PicWidth * 1.0 / (double)this.m_MapParams.PicHeight;
				int oldPicWidth = this.m_MapParams.PicWidth;
				int oldPicHeight = this.m_MapParams.PicHeight;
				int newPicWidth = this.m_MapParams.PicWidth;
				int newPicHeight = this.m_MapParams.PicHeight;
				int oldZoom = this.m_MapParams.Zoom;
				int newZoom = this.m_MapParams.Zoom;
				if (this.m_AutoZoomMode == wMapPictureBox.AUTOZOOM_MODE.FIT_AUTO)
				{
					if (panelScale <= picScale)
					{
						newPicWidth = panelWidth;
						newPicHeight = System.Convert.ToInt32((double)newPicWidth / picScale);
						newZoom = System.Convert.ToInt32((double)oldZoom * ((double)newPicWidth * 1.0 / (double)oldPicWidth));
					}
					else
					{
						newPicHeight = panelHeight;
						newPicWidth = System.Convert.ToInt32(picScale * (double)newPicHeight);
						newZoom = System.Convert.ToInt32((double)oldZoom * ((double)newPicWidth * 1.0 / (double)oldPicWidth));
					}
				}
				else if (this.m_AutoZoomMode == wMapPictureBox.AUTOZOOM_MODE.FIT_WIDTH)
				{
					newPicWidth = panelWidth;
					newPicHeight = System.Convert.ToInt32((double)newPicWidth / picScale);
					newZoom = System.Convert.ToInt32((double)oldZoom * ((double)newPicWidth * 1.0 / (double)oldPicWidth));
				}
				else if (this.m_AutoZoomMode == wMapPictureBox.AUTOZOOM_MODE.FIT_HEIGHT)
				{
					newPicHeight = panelHeight;
					newPicWidth = System.Convert.ToInt32(picScale * (double)newPicHeight);
					newZoom = System.Convert.ToInt32((double)oldZoom * ((double)newPicWidth * 1.0 / (double)oldPicWidth));
				}
				this.m_MapParams.PicWidth = newPicWidth;
				this.m_MapParams.PicHeight = newPicHeight;
				this.m_MapParams.Zoom = newZoom;
				if (this.m_ThumbPictureBox != null)
				{
					this.m_ThumbPictureBox.SelectedPos = new System.Drawing.PointF(0f, 0f);
				}
				this.DrawMap();
				if (this.MapZoomed != null)
				{
					this.MapZoomed(this, new System.EventArgs());
				}
			}
		}

		private void panel_Scroll(object sender, System.Windows.Forms.ScrollEventArgs e)
		{
			this.mapPictureBox.Refresh();
		}

		private void panel_SizeChanged(object sender, System.EventArgs e)
		{
		}
	}
}
