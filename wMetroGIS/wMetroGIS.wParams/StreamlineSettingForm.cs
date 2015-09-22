using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Ribbon;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wMetroGIS.Properties;

namespace wMetroGIS.wParams
{
	public class StreamlineSettingForm : System.Windows.Forms.Form
	{
		public StreamlineParams m_StreamlineParams;

		private System.ComponentModel.IContainer components = null;

		private RibbonClientPanel ribbonClientPanel1;

		private TextBoxX textBoxXFilePath;

		private ButtonX buttonCancel;

		private ButtonX buttonXShowPreview;

		private ButtonX buttonOK;

		private GroupPanel groupPanel2;

		private System.Windows.Forms.PictureBox pictureBoxPreview;

		private GroupPanel groupPanel3;

		private System.Windows.Forms.PictureBox pictureBoxStreamlineColor;

		private System.Windows.Forms.NumericUpDown numericUpDownStreamlineWidth;

		private System.Windows.Forms.Label label13;

		private Slider trackBarArrowAngle;

		private System.Windows.Forms.Label label7;

		private System.Windows.Forms.Button buttonChoseStreamlineColor;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.NumericUpDown numericUpDownStreamlineDensity;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.ColorDialog colorDialog;

		public int StreamlineWidth
		{
			get
			{
				return System.Convert.ToInt32(this.numericUpDownStreamlineWidth.Value);
			}
			set
			{
				this.numericUpDownStreamlineWidth.Value = value;
			}
		}

		public System.Drawing.Color StreamlineColor
		{
			get
			{
				return this.pictureBoxStreamlineColor.BackColor;
			}
			set
			{
				this.pictureBoxStreamlineColor.BackColor = value;
			}
		}

		public float ArrowAngle
		{
			get
			{
				return System.Convert.ToSingle(this.trackBarArrowAngle.Value);
			}
			set
			{
				this.trackBarArrowAngle.Value = System.Convert.ToInt32(value);
			}
		}

		public int StreamlineDensity
		{
			get
			{
				return System.Convert.ToInt32(this.numericUpDownStreamlineDensity.Value);
			}
			set
			{
				this.numericUpDownStreamlineDensity.Value = value;
			}
		}

		public StreamlineSettingForm()
		{
			this.InitializeComponent();
			this.m_StreamlineParams = new StreamlineParams();
			this.m_StreamlineParams.LoadParams();
			this.LoadStreamlineParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_StreamlineParams.ParamFilePath;
		}

		public StreamlineSettingForm(StreamlineParams streamlineParams)
		{
			this.InitializeComponent();
			this.m_StreamlineParams = streamlineParams;
			if (this.m_StreamlineParams == null)
			{
				System.Windows.Forms.MessageBox.Show("传入流线参数为空！使用默认参数……", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_StreamlineParams = new StreamlineParams();
				this.m_StreamlineParams.LoadParams();
			}
			this.LoadStreamlineParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_StreamlineParams.ParamFilePath;
		}

		private void LoadStreamlineParams()
		{
			this.StreamlineWidth = this.m_StreamlineParams.StreamlineWidth;
			this.StreamlineColor = this.m_StreamlineParams.StreamlineColor;
			this.ArrowAngle = this.m_StreamlineParams.StreamlineArrowAngle;
			this.StreamlineDensity = this.m_StreamlineParams.StreamlineDensity;
			this.ShowPreview();
		}

		private void ApplyStreamlineParams()
		{
			this.m_StreamlineParams.StreamlineWidth = this.StreamlineWidth;
			this.m_StreamlineParams.StreamlineColor = this.StreamlineColor;
			this.m_StreamlineParams.StreamlineArrowAngle = this.ArrowAngle;
			this.m_StreamlineParams.StreamlineDensity = this.StreamlineDensity;
		}

		private void ShowPreview()
		{
			System.Drawing.Bitmap previewBitmap = new System.Drawing.Bitmap(this.pictureBoxPreview.Size.Width, this.pictureBoxPreview.Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(previewBitmap);
			g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), new System.Drawing.Rectangle(0, 0, previewBitmap.Width, previewBitmap.Height));
			System.Drawing.Pen pen = new System.Drawing.Pen(this.StreamlineColor, (float)this.StreamlineWidth);
			int[] arrayX = new int[40];
			int[] arrayY = new int[40];
			System.Drawing.Point[] arrayPt = new System.Drawing.Point[40];
			for (int i = 0; i < arrayX.Length; i++)
			{
				arrayX[i] = System.Convert.ToInt32(i * this.pictureBoxPreview.Width / arrayX.Length);
				arrayY[i] = System.Convert.ToInt32(30.0 * System.Math.Sin((double)arrayX[i] * 3.1415926535897931 * 4.0 / (double)this.pictureBoxPreview.Width));
				arrayPt[i] = new System.Drawing.Point(arrayX[i], arrayY[i]);
			}
			for (int curPos = 0; curPos <= this.pictureBoxPreview.Height; curPos += 80 / (int)this.numericUpDownStreamlineDensity.Value)
			{
				g.ResetTransform();
				g.TranslateTransform(0f, (float)curPos);
				g.DrawLines(pen, arrayPt);
				int ArrowLen = 20;
				float a150 = (float)((double)this.trackBarArrowAngle.Value * 3.1416 / 180.0);
				for (int i = 0; i < arrayX.Length - 1; i++)
				{
					if (i % 5 == 0)
					{
						int X = arrayX[i];
						int Y = arrayY[i];
						int X2 = arrayX[i + 1];
						int Y2 = arrayY[i + 1];
						double dir = System.Math.Atan2((double)(Y2 - Y), (double)(X2 - X));
						g.DrawLine(pen, (float)X2, (float)Y2, (float)((double)X2 + (double)(ArrowLen / 2) * System.Math.Cos(dir + (double)a150)), (float)((double)Y2 + (double)(ArrowLen / 2) * System.Math.Sin(dir + (double)a150)));
						g.DrawLine(pen, (float)X2, (float)Y2, (float)((double)X2 + (double)(ArrowLen / 2) * System.Math.Cos(dir - (double)a150)), (float)((double)Y2 + (double)(ArrowLen / 2) * System.Math.Sin(dir - (double)a150)));
					}
				}
			}
			g.Dispose();
			this.pictureBoxPreview.Image = previewBitmap;
		}

		private void buttonXShowPreview_Click(object sender, System.EventArgs e)
		{
			this.ShowPreview();
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.ApplyStreamlineParams();
			if (this.m_StreamlineParams.SaveParams())
			{
				base.DialogResult = System.Windows.Forms.DialogResult.OK;
				base.Close();
			}
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			base.Close();
		}

		private void buttonChoseStreamlineColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxStreamlineColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxStreamlineColor.BackColor = this.colorDialog.Color;
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
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.textBoxXFilePath = new TextBoxX();
			this.buttonCancel = new ButtonX();
			this.buttonXShowPreview = new ButtonX();
			this.buttonOK = new ButtonX();
			this.groupPanel2 = new GroupPanel();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.groupPanel3 = new GroupPanel();
			this.pictureBoxStreamlineColor = new System.Windows.Forms.PictureBox();
			this.numericUpDownStreamlineDensity = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownStreamlineWidth = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.trackBarArrowAngle = new Slider();
			this.label7 = new System.Windows.Forms.Label();
			this.buttonChoseStreamlineColor = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.ribbonClientPanel1.SuspendLayout();
			this.groupPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).BeginInit();
			this.groupPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStreamlineColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStreamlineDensity).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStreamlineWidth).BeginInit();
			base.SuspendLayout();
			this.ribbonClientPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.textBoxXFilePath);
			this.ribbonClientPanel1.Controls.Add(this.buttonCancel);
			this.ribbonClientPanel1.Controls.Add(this.buttonXShowPreview);
			this.ribbonClientPanel1.Controls.Add(this.buttonOK);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel2);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel3);
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(691, 378);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.TabIndex = 39;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.textBoxXFilePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.textBoxXFilePath.Border.Class = "TextBoxBorder";
			this.textBoxXFilePath.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.textBoxXFilePath.Location = new System.Drawing.Point(12, 306);
			this.textBoxXFilePath.Multiline = true;
			this.textBoxXFilePath.Name = "textBoxXFilePath";
			this.textBoxXFilePath.Size = new System.Drawing.Size(664, 57);
			this.textBoxXFilePath.TabIndex = 31;
			this.textBoxXFilePath.Text = "数据路径：";
			this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonCancel.Image = Resources.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(546, 256);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(130, 44);
			this.buttonCancel.TabIndex = 28;
			this.buttonCancel.Text = "取\u3000消";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.buttonXShowPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXShowPreview.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXShowPreview.Image = Resources.未标题_1;
			this.buttonXShowPreview.Location = new System.Drawing.Point(410, 206);
			this.buttonXShowPreview.Name = "buttonXShowPreview";
			this.buttonXShowPreview.Size = new System.Drawing.Size(266, 44);
			this.buttonXShowPreview.TabIndex = 28;
			this.buttonXShowPreview.Text = "显示预览";
			this.buttonXShowPreview.Click += new System.EventHandler(this.buttonXShowPreview_Click);
			this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonOK.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonOK.Image = Resources.OK;
			this.buttonOK.Location = new System.Drawing.Point(410, 256);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(130, 44);
			this.buttonOK.TabIndex = 28;
			this.buttonOK.Text = "确\u3000定";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel2.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel2.Controls.Add(this.pictureBoxPreview);
			this.groupPanel2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel2.Location = new System.Drawing.Point(12, 15);
			this.groupPanel2.Name = "groupPanel2";
			this.groupPanel2.Size = new System.Drawing.Size(392, 285);
			this.groupPanel2.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanel2.Style.BackColorGradientAngle = 90;
			this.groupPanel2.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanel2.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanel2.Style.BorderBottomWidth = 1;
			this.groupPanel2.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanel2.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanel2.Style.BorderLeftWidth = 1;
			this.groupPanel2.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanel2.Style.BorderRightWidth = 1;
			this.groupPanel2.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanel2.Style.BorderTopWidth = 1;
			this.groupPanel2.Style.CornerDiameter = 4;
			this.groupPanel2.Style.CornerType = eCornerType.Rounded;
			this.groupPanel2.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel2.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel2.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel2.TabIndex = 0;
			this.groupPanel2.Text = "预览效果";
			this.pictureBoxPreview.BackColor = System.Drawing.Color.Black;
			this.pictureBoxPreview.Location = new System.Drawing.Point(3, 3);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new System.Drawing.Size(380, 250);
			this.pictureBoxPreview.TabIndex = 0;
			this.pictureBoxPreview.TabStop = false;
			this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel3.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel3.Controls.Add(this.pictureBoxStreamlineColor);
			this.groupPanel3.Controls.Add(this.numericUpDownStreamlineDensity);
			this.groupPanel3.Controls.Add(this.label1);
			this.groupPanel3.Controls.Add(this.numericUpDownStreamlineWidth);
			this.groupPanel3.Controls.Add(this.label13);
			this.groupPanel3.Controls.Add(this.trackBarArrowAngle);
			this.groupPanel3.Controls.Add(this.label7);
			this.groupPanel3.Controls.Add(this.buttonChoseStreamlineColor);
			this.groupPanel3.Controls.Add(this.label2);
			this.groupPanel3.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel3.Location = new System.Drawing.Point(410, 15);
			this.groupPanel3.Name = "groupPanel3";
			this.groupPanel3.Size = new System.Drawing.Size(266, 185);
			this.groupPanel3.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanel3.Style.BackColorGradientAngle = 90;
			this.groupPanel3.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanel3.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanel3.Style.BorderBottomWidth = 1;
			this.groupPanel3.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanel3.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanel3.Style.BorderLeftWidth = 1;
			this.groupPanel3.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanel3.Style.BorderRightWidth = 1;
			this.groupPanel3.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanel3.Style.BorderTopWidth = 1;
			this.groupPanel3.Style.CornerDiameter = 4;
			this.groupPanel3.Style.CornerType = eCornerType.Rounded;
			this.groupPanel3.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel3.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel3.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel3.TabIndex = 0;
			this.groupPanel3.Text = "矢量箭头样式";
			this.pictureBoxStreamlineColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxStreamlineColor.Location = new System.Drawing.Point(95, 76);
			this.pictureBoxStreamlineColor.Name = "pictureBoxStreamlineColor";
			this.pictureBoxStreamlineColor.Size = new System.Drawing.Size(78, 26);
			this.pictureBoxStreamlineColor.TabIndex = 23;
			this.pictureBoxStreamlineColor.TabStop = false;
			this.numericUpDownStreamlineDensity.Location = new System.Drawing.Point(95, 114);
			System.Windows.Forms.NumericUpDown arg_AD8_0 = this.numericUpDownStreamlineDensity;
			int[] array = new int[4];
			array[0] = 10;
			arg_AD8_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_AF5_0 = this.numericUpDownStreamlineDensity;
			array = new int[4];
			array[0] = 3;
			arg_AF5_0.Minimum = new decimal(array);
			this.numericUpDownStreamlineDensity.Name = "numericUpDownStreamlineDensity";
			this.numericUpDownStreamlineDensity.Size = new System.Drawing.Size(86, 26);
			this.numericUpDownStreamlineDensity.TabIndex = 30;
			this.numericUpDownStreamlineDensity.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_B53_0 = this.numericUpDownStreamlineDensity;
			array = new int[4];
			array[0] = 3;
			arg_B53_0.Value = new decimal(array);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label1.Location = new System.Drawing.Point(20, 116);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 19);
			this.label1.TabIndex = 28;
			this.label1.Text = "线条密度：";
			this.numericUpDownStreamlineWidth.Location = new System.Drawing.Point(95, 7);
			System.Windows.Forms.NumericUpDown arg_C1F_0 = this.numericUpDownStreamlineWidth;
			array = new int[4];
			array[0] = 10;
			arg_C1F_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_C3C_0 = this.numericUpDownStreamlineWidth;
			array = new int[4];
			array[0] = 1;
			arg_C3C_0.Minimum = new decimal(array);
			this.numericUpDownStreamlineWidth.Name = "numericUpDownStreamlineWidth";
			this.numericUpDownStreamlineWidth.Size = new System.Drawing.Size(86, 26);
			this.numericUpDownStreamlineWidth.TabIndex = 30;
			this.numericUpDownStreamlineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_C9A_0 = this.numericUpDownStreamlineWidth;
			array = new int[4];
			array[0] = 1;
			arg_C9A_0.Value = new decimal(array);
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label13.Location = new System.Drawing.Point(20, 9);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(79, 19);
			this.label13.TabIndex = 28;
			this.label13.Text = "线条粗细：";
			this.trackBarArrowAngle.LabelVisible = false;
			this.trackBarArrowAngle.Location = new System.Drawing.Point(95, 38);
			this.trackBarArrowAngle.Maximum = 180;
			this.trackBarArrowAngle.Minimum = 100;
			this.trackBarArrowAngle.Name = "trackBarArrowAngle";
			this.trackBarArrowAngle.Size = new System.Drawing.Size(146, 32);
			this.trackBarArrowAngle.TabIndex = 28;
			this.trackBarArrowAngle.Text = "slider1";
			this.trackBarArrowAngle.Value = 150;
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label7.Location = new System.Drawing.Point(20, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(79, 19);
			this.label7.TabIndex = 26;
			this.label7.Text = "箭头张角：";
			this.buttonChoseStreamlineColor.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonChoseStreamlineColor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.buttonChoseStreamlineColor.Location = new System.Drawing.Point(179, 76);
			this.buttonChoseStreamlineColor.Name = "buttonChoseStreamlineColor";
			this.buttonChoseStreamlineColor.Size = new System.Drawing.Size(62, 27);
			this.buttonChoseStreamlineColor.TabIndex = 21;
			this.buttonChoseStreamlineColor.Text = "选\u3000择";
			this.buttonChoseStreamlineColor.UseVisualStyleBackColor = true;
			this.buttonChoseStreamlineColor.Click += new System.EventHandler(this.buttonChoseStreamlineColor_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label2.Location = new System.Drawing.Point(20, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 19);
			this.label2.TabIndex = 22;
			this.label2.Text = "线条颜色：";
			this.colorDialog.AnyColor = true;
			this.colorDialog.FullOpen = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(690, 378);
			base.ControlBox = false;
			base.Controls.Add(this.ribbonClientPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "StreamlineSettingForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "流线参数设置";
			this.ribbonClientPanel1.ResumeLayout(false);
			this.groupPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).EndInit();
			this.groupPanel3.ResumeLayout(false);
			this.groupPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStreamlineColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStreamlineDensity).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStreamlineWidth).EndInit();
			base.ResumeLayout(false);
		}
	}
}
