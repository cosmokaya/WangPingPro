using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Ribbon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wMetroGIS.Properties;

namespace wMetroGIS.wFunctionFormLib
{
	public class AnimateShowForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		private RibbonClientPanel ribbonClientPanel1;

		private System.Windows.Forms.Panel panel1;

		private GroupPanel groupPanel1;

		private System.Windows.Forms.ListView listViewImage;

		private System.Windows.Forms.ColumnHeader columnHeader1;

		private System.Windows.Forms.ColumnHeader columnHeader2;

		private System.Windows.Forms.PictureBox pictureBoxImage;

		private System.Windows.Forms.Timer timerAnimate;

		private System.Windows.Forms.Label labelAnimateRate;

		private Slider sliderAnimateRate;

		private System.Windows.Forms.Label label1;

		private LabelX labelMemo;

		private ButtonX buttonStop;

		private ButtonX buttonStart;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.RadioButton radioButtonVisualType2;

		private System.Windows.Forms.RadioButton radioButtonVisualType1;

		private ButtonX buttonClose;

		public System.Collections.Generic.List<string> m_AnimatePathList = new System.Collections.Generic.List<string>();

		public System.Collections.Generic.List<string> m_AnimateMemoList = new System.Collections.Generic.List<string>();

		private int m_AnimateFrameID = 0;

		public string m_FormTitle
		{
			set
			{
				this.Text = value;
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
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.labelMemo = new LabelX();
			this.panel1 = new System.Windows.Forms.Panel();
			this.pictureBoxImage = new System.Windows.Forms.PictureBox();
			this.groupPanel1 = new GroupPanel();
			this.radioButtonVisualType2 = new System.Windows.Forms.RadioButton();
			this.radioButtonVisualType1 = new System.Windows.Forms.RadioButton();
			this.buttonClose = new ButtonX();
			this.buttonStop = new ButtonX();
			this.buttonStart = new ButtonX();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.labelAnimateRate = new System.Windows.Forms.Label();
			this.sliderAnimateRate = new Slider();
			this.listViewImage = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.timerAnimate = new System.Windows.Forms.Timer(this.components);
			this.ribbonClientPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxImage).BeginInit();
			this.groupPanel1.SuspendLayout();
			base.SuspendLayout();
			this.ribbonClientPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.labelMemo);
			this.ribbonClientPanel1.Controls.Add(this.panel1);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel1);
			this.ribbonClientPanel1.Controls.Add(this.listViewImage);
			this.ribbonClientPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(891, 593);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.StyleMouseDown.Class = "";
			this.ribbonClientPanel1.StyleMouseOver.Class = "";
			this.ribbonClientPanel1.TabIndex = 0;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.labelMemo.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.labelMemo.BackColor = System.Drawing.Color.Transparent;
			this.labelMemo.BackgroundStyle.Class = "";
			this.labelMemo.Font = new System.Drawing.Font("微软雅黑", 21.75f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.labelMemo.Location = new System.Drawing.Point(12, 7);
			this.labelMemo.Name = "labelMemo";
			this.labelMemo.Size = new System.Drawing.Size(590, 36);
			this.labelMemo.TabIndex = 60;
			this.labelMemo.Text = "未选择有效帧";
			this.labelMemo.TextAlignment = System.Drawing.StringAlignment.Center;
			this.panel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.panel1.AutoScroll = true;
			this.panel1.BackColor = System.Drawing.Color.Black;
			this.panel1.Controls.Add(this.pictureBoxImage);
			this.panel1.Location = new System.Drawing.Point(12, 45);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(590, 535);
			this.panel1.TabIndex = 59;
			this.panel1.SizeChanged += new System.EventHandler(this.panel1_SizeChanged);
			this.pictureBoxImage.BackColor = System.Drawing.Color.Black;
			this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxImage.Name = "pictureBoxImage";
			this.pictureBoxImage.Size = new System.Drawing.Size(420, 414);
			this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxImage.TabIndex = 0;
			this.pictureBoxImage.TabStop = false;
			this.groupPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel1.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel1.Controls.Add(this.radioButtonVisualType2);
			this.groupPanel1.Controls.Add(this.radioButtonVisualType1);
			this.groupPanel1.Controls.Add(this.buttonClose);
			this.groupPanel1.Controls.Add(this.buttonStop);
			this.groupPanel1.Controls.Add(this.buttonStart);
			this.groupPanel1.Controls.Add(this.label2);
			this.groupPanel1.Controls.Add(this.label1);
			this.groupPanel1.Controls.Add(this.labelAnimateRate);
			this.groupPanel1.Controls.Add(this.sliderAnimateRate);
			this.groupPanel1.Location = new System.Drawing.Point(608, 288);
			this.groupPanel1.Name = "groupPanel1";
			this.groupPanel1.Size = new System.Drawing.Size(271, 291);
			this.groupPanel1.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanel1.Style.BackColorGradientAngle = 90;
			this.groupPanel1.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanel1.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanel1.Style.BorderBottomWidth = 1;
			this.groupPanel1.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanel1.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanel1.Style.BorderLeftWidth = 1;
			this.groupPanel1.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanel1.Style.BorderRightWidth = 1;
			this.groupPanel1.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanel1.Style.BorderTopWidth = 1;
			this.groupPanel1.Style.Class = "";
			this.groupPanel1.Style.CornerDiameter = 4;
			this.groupPanel1.Style.CornerType = eCornerType.Rounded;
			this.groupPanel1.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel1.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel1.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel1.StyleMouseDown.Class = "";
			this.groupPanel1.StyleMouseOver.Class = "";
			this.groupPanel1.TabIndex = 58;
			this.groupPanel1.Text = "动画显控";
			this.radioButtonVisualType2.AutoSize = true;
			this.radioButtonVisualType2.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonVisualType2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.radioButtonVisualType2.Location = new System.Drawing.Point(179, 64);
			this.radioButtonVisualType2.Name = "radioButtonVisualType2";
			this.radioButtonVisualType2.Size = new System.Drawing.Size(83, 23);
			this.radioButtonVisualType2.TabIndex = 65;
			this.radioButtonVisualType2.Text = "缩放显示";
			this.radioButtonVisualType2.UseVisualStyleBackColor = false;
			this.radioButtonVisualType1.AutoSize = true;
			this.radioButtonVisualType1.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonVisualType1.Checked = true;
			this.radioButtonVisualType1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.radioButtonVisualType1.Location = new System.Drawing.Point(92, 64);
			this.radioButtonVisualType1.Name = "radioButtonVisualType1";
			this.radioButtonVisualType1.Size = new System.Drawing.Size(83, 23);
			this.radioButtonVisualType1.TabIndex = 64;
			this.radioButtonVisualType1.TabStop = true;
			this.radioButtonVisualType1.Text = "原始大小";
			this.radioButtonVisualType1.UseVisualStyleBackColor = false;
			this.radioButtonVisualType1.CheckedChanged += new System.EventHandler(this.radioButtonVisualType1_CheckedChanged);
			this.buttonClose.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonClose.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonClose.Image = Resources.DeclineTask;
			this.buttonClose.Location = new System.Drawing.Point(11, 201);
			this.buttonClose.Name = "buttonClose";
			this.buttonClose.Size = new System.Drawing.Size(251, 48);
			this.buttonClose.TabIndex = 15;
			this.buttonClose.Text = "关闭窗口";
			this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
			this.buttonStop.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonStop.Enabled = false;
			this.buttonStop.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonStop.Image = Resources.PauseTimer;
			this.buttonStop.Location = new System.Drawing.Point(11, 147);
			this.buttonStop.Name = "buttonStop";
			this.buttonStop.Size = new System.Drawing.Size(251, 48);
			this.buttonStop.TabIndex = 15;
			this.buttonStop.Text = "停止动画";
			this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
			this.buttonStart.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonStart.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonStart.Image = Resources.StartTimer;
			this.buttonStart.Location = new System.Drawing.Point(11, 93);
			this.buttonStart.Name = "buttonStart";
			this.buttonStart.Size = new System.Drawing.Size(251, 48);
			this.buttonStart.TabIndex = 15;
			this.buttonStart.Text = "开始动画";
			this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Location = new System.Drawing.Point(7, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 19);
			this.label2.TabIndex = 14;
			this.label2.Text = "显示模式：";
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Location = new System.Drawing.Point(7, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 19);
			this.label1.TabIndex = 14;
			this.label1.Text = "动画速度：";
			this.labelAnimateRate.AutoSize = true;
			this.labelAnimateRate.BackColor = System.Drawing.Color.Transparent;
			this.labelAnimateRate.Location = new System.Drawing.Point(92, 11);
			this.labelAnimateRate.Name = "labelAnimateRate";
			this.labelAnimateRate.Size = new System.Drawing.Size(66, 19);
			this.labelAnimateRate.TabIndex = 14;
			this.labelAnimateRate.Text = "1.0秒/张";
			this.sliderAnimateRate.BackgroundStyle.Class = "";
			this.sliderAnimateRate.LabelVisible = false;
			this.sliderAnimateRate.Location = new System.Drawing.Point(11, 33);
			this.sliderAnimateRate.Maximum = 5000;
			this.sliderAnimateRate.Minimum = 500;
			this.sliderAnimateRate.Name = "sliderAnimateRate";
			this.sliderAnimateRate.Size = new System.Drawing.Size(251, 23);
			this.sliderAnimateRate.Step = 500;
			this.sliderAnimateRate.TabIndex = 13;
			this.sliderAnimateRate.Text = "速度";
			this.sliderAnimateRate.Value = 1000;
			this.sliderAnimateRate.ValueChanged += new System.EventHandler(this.sliderAnimateRate_ValueChanged);
			this.listViewImage.Activation = System.Windows.Forms.ItemActivation.OneClick;
			this.listViewImage.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.listViewImage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1,
				this.columnHeader2
			});
			this.listViewImage.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.listViewImage.ForeColor = System.Drawing.SystemColors.MenuHighlight;
			this.listViewImage.FullRowSelect = true;
			this.listViewImage.GridLines = true;
			this.listViewImage.HideSelection = false;
			this.listViewImage.Location = new System.Drawing.Point(608, 12);
			this.listViewImage.MultiSelect = false;
			this.listViewImage.Name = "listViewImage";
			this.listViewImage.Size = new System.Drawing.Size(271, 270);
			this.listViewImage.TabIndex = 57;
			this.listViewImage.UseCompatibleStateImageBehavior = false;
			this.listViewImage.View = System.Windows.Forms.View.Details;
			this.listViewImage.SelectedIndexChanged += new System.EventHandler(this.listViewImage_SelectedIndexChanged);
			this.columnHeader1.Text = "帧";
			this.columnHeader1.Width = 46;
			this.columnHeader2.Text = "说明";
			this.columnHeader2.Width = 400;
			this.timerAnimate.Interval = 500;
			this.timerAnimate.Tick += new System.EventHandler(this.timerAnimate_Tick);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(891, 592);
			base.Controls.Add(this.ribbonClientPanel1);
			base.Name = "AnimateShowForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "动画显示";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AnimateShowForm_FormClosed);
			base.Load += new System.EventHandler(this.AnimateShowForm_Load);
			this.ribbonClientPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxImage).EndInit();
			this.groupPanel1.ResumeLayout(false);
			this.groupPanel1.PerformLayout();
			base.ResumeLayout(false);
		}

		public AnimateShowForm()
		{
			this.InitializeComponent();
		}

		private void AnimateShowForm_Load(object sender, System.EventArgs e)
		{
			this.LoadImageList();
		}

		private void LoadImageList()
		{
			this.listViewImage.Items.Clear();
			this.m_AnimateFrameID = 0;
			ProgressFormEx apf = new ProgressFormEx();
			apf.Show();
			apf.SetProgressRange(0, this.m_AnimatePathList.Count);
			apf.SetProgressText("正在载入图片列表，请稍候");
			System.Windows.Forms.Application.DoEvents();
			for (int i = 0; i < this.m_AnimatePathList.Count; i++)
			{
				System.Windows.Forms.ListViewItem newItem = new System.Windows.Forms.ListViewItem(System.Convert.ToString(i + 1));
				newItem.SubItems.Add(this.m_AnimateMemoList[i]);
				this.listViewImage.Items.Add(newItem);
				apf.SetProgressPos(i + 1);
				System.Windows.Forms.Application.DoEvents();
			}
			apf.Close();
			if (this.listViewImage.Items.Count > 0)
			{
				this.listViewImage.Focus();
				this.listViewImage.Items[0].Selected = true;
			}
		}

		private void sliderAnimateRate_ValueChanged(object sender, System.EventArgs e)
		{
			int value = this.sliderAnimateRate.Value;
			this.timerAnimate.Interval = value;
			this.labelAnimateRate.Text = string.Format("{0:0.0}秒/张", (double)value / 1000.0);
		}

		private void listViewImage_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.listViewImage.SelectedIndices.Count == 0)
			{
				this.m_AnimateFrameID = -1;
				this.labelMemo.Text = "未选择效帧";
			}
			else
			{
				this.m_AnimateFrameID = this.listViewImage.SelectedIndices[0];
				this.labelMemo.Text = this.m_AnimateMemoList[this.m_AnimateFrameID];
				if (this.m_AnimateFrameID < this.m_AnimatePathList.Count)
				{
					this.pictureBoxImage.Image = System.Drawing.Image.FromFile(this.m_AnimatePathList[this.m_AnimateFrameID]);
				}
				System.GC.Collect();
			}
		}

		private void buttonStart_Click(object sender, System.EventArgs e)
		{
			this.listViewImage.Enabled = false;
			this.buttonStart.Enabled = false;
			this.buttonStop.Enabled = true;
			this.timerAnimate.Start();
		}

		private void buttonStop_Click(object sender, System.EventArgs e)
		{
			this.listViewImage.Enabled = true;
			this.buttonStart.Enabled = true;
			this.buttonStop.Enabled = false;
			this.timerAnimate.Stop();
		}

		private void radioButtonVisualType1_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.radioButtonVisualType1.Checked)
			{
				this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			}
			else
			{
				this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
				this.pictureBoxImage.Size = this.panel1.Size;
			}
			this.pictureBoxImage.Location = new System.Drawing.Point(0, 0);
		}

		private void panel1_SizeChanged(object sender, System.EventArgs e)
		{
			if (this.pictureBoxImage.SizeMode == System.Windows.Forms.PictureBoxSizeMode.Zoom)
			{
				this.pictureBoxImage.Size = this.panel1.Size;
			}
		}

		private void timerAnimate_Tick(object sender, System.EventArgs e)
		{
			if (this.m_AnimateFrameID < this.listViewImage.Items.Count - 1)
			{
				this.m_AnimateFrameID++;
			}
			else
			{
				this.m_AnimateFrameID = 0;
			}
			this.listViewImage.Focus();
			this.listViewImage.Items[this.m_AnimateFrameID].Selected = true;
			this.listViewImage.EnsureVisible(this.m_AnimateFrameID);
		}

		private void buttonClose_Click(object sender, System.EventArgs e)
		{
			base.Close();
		}

		private void AnimateShowForm_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
		{
			this.pictureBoxImage.Image.Dispose();
			this.pictureBoxImage.Image = null;
		}
	}
}
