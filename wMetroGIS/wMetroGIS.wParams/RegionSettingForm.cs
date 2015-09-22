using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Ribbon;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;
using wMetroGIS.Properties;
using wMetroGIS.wColorManager;

namespace wMetroGIS.wParams
{
	public class RegionSettingForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		private RibbonClientPanel ribbonClientPanel1;

		private TextBoxX textBoxXFilePath;

		private ButtonX buttonCancel;

		private ButtonX buttonOK;

		private GroupPanel groupPanel3;

		private Slider trackBarFillAlpha;

		private System.Windows.Forms.Label label7;

		private System.Windows.Forms.Label labelFillAlpha;

		private System.Windows.Forms.CheckBox checkBoxFillRegion;

		private GroupPanel groupPanel2;

		private System.Windows.Forms.CheckBox checkBoxWantSPL;

		private System.Windows.Forms.CheckBox checkBoxShowText;

		private System.Windows.Forms.ComboBox comboBoxLineStyle;

		private System.Windows.Forms.NumericUpDown numericUpDownLineWidth;

		private System.Windows.Forms.Label label14;

		private System.Windows.Forms.Label label13;

		private GroupPanel groupPanel4;

		private System.Windows.Forms.CheckBox checkBoxShowVertex;

		private System.Windows.Forms.CheckBox checkBoxShowTriangle;

		private ButtonX buttonXClearColor;

		private ButtonX buttonX3DeleteColor;

		private ButtonX buttonXModifyColor;

		private ButtonX buttonXAddColor;

		private GroupPanel groupPanel1;

		private System.Windows.Forms.TextBox textBoxColorText;

		private System.Windows.Forms.NumericUpDown numericUpDownColorValueMin;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.Button buttonChoseCurveColor;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.PictureBox pictureBoxCurveColor;

		private GroupPanel groupPanel5;

		private System.Windows.Forms.NumericUpDown numericUpDownColorValueMax;

		private System.Windows.Forms.Label label8;

		private System.Windows.Forms.Button buttonChoseFillColor;

		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.PictureBox pictureBoxFillColor;

		private System.Windows.Forms.ListView listViewColorItem;

		private System.Windows.Forms.ColumnHeader columnHeader1;

		private System.Windows.Forms.ColumnHeader columnHeader2;

		private System.Windows.Forms.ColumnHeader columnHeader3;

		private System.Windows.Forms.ColumnHeader columnHeader4;

		private System.Windows.Forms.ColorDialog colorDialog;

		private System.Windows.Forms.ImageList imageList;

		private ButtonX buttonXSaveDefaultParams;

		private ButtonX buttonXLoadDefaultParams;

		public RegionParams m_RegionParams;

		public ColorManager RegionLineColorManager
		{
			get
			{
				return this.m_RegionParams.m_RegionLineColorManager;
			}
		}

		public ColorManager RegionFillColorManager
		{
			get
			{
				return this.m_RegionParams.m_RegionFillColorManager;
			}
		}

		public int RegionLineWidth
		{
			get
			{
				return (int)this.numericUpDownLineWidth.Value;
			}
			set
			{
				this.numericUpDownLineWidth.Value = value;
			}
		}

		public System.Drawing.Drawing2D.DashStyle RegionLineStyle
		{
			get
			{
				return this.m_RegionParams.IntToDashStyle(this.comboBoxLineStyle.SelectedIndex);
			}
			set
			{
				this.comboBoxLineStyle.SelectedIndex = this.m_RegionParams.DashStyleToInt(value);
			}
		}

		public bool RegionWantFill
		{
			get
			{
				return this.checkBoxFillRegion.Checked;
			}
			set
			{
				this.checkBoxFillRegion.Checked = value;
			}
		}

		public int RegionFillAlpha
		{
			get
			{
				return this.trackBarFillAlpha.Value;
			}
			set
			{
				this.trackBarFillAlpha.Value = value;
			}
		}

		public bool RegionWantVertex
		{
			get
			{
				return this.checkBoxShowVertex.Checked;
			}
			set
			{
				this.checkBoxShowVertex.Checked = value;
			}
		}

		public bool RegionWantTriangle
		{
			get
			{
				return this.checkBoxShowTriangle.Checked;
			}
			set
			{
				this.checkBoxShowTriangle.Checked = value;
			}
		}

		public bool RegionShowRegionText
		{
			get
			{
				return this.checkBoxShowText.Checked;
			}
			set
			{
				this.checkBoxShowText.Checked = value;
			}
		}

		public bool RegionWantSPL
		{
			get
			{
				return this.checkBoxWantSPL.Checked;
			}
			set
			{
				this.checkBoxWantSPL.Checked = value;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegionSettingForm));
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.buttonXSaveDefaultParams = new ButtonX();
			this.buttonXLoadDefaultParams = new ButtonX();
			this.groupPanel1 = new GroupPanel();
			this.textBoxColorText = new System.Windows.Forms.TextBox();
			this.numericUpDownColorValueMax = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownColorValueMin = new System.Windows.Forms.NumericUpDown();
			this.label1 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonChoseFillColor = new System.Windows.Forms.Button();
			this.buttonChoseCurveColor = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.pictureBoxFillColor = new System.Windows.Forms.PictureBox();
			this.pictureBoxCurveColor = new System.Windows.Forms.PictureBox();
			this.groupPanel5 = new GroupPanel();
			this.buttonXClearColor = new ButtonX();
			this.listViewColorItem = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.buttonX3DeleteColor = new ButtonX();
			this.buttonXAddColor = new ButtonX();
			this.buttonXModifyColor = new ButtonX();
			this.textBoxXFilePath = new TextBoxX();
			this.buttonCancel = new ButtonX();
			this.buttonOK = new ButtonX();
			this.groupPanel3 = new GroupPanel();
			this.trackBarFillAlpha = new Slider();
			this.label7 = new System.Windows.Forms.Label();
			this.labelFillAlpha = new System.Windows.Forms.Label();
			this.checkBoxFillRegion = new System.Windows.Forms.CheckBox();
			this.groupPanel2 = new GroupPanel();
			this.comboBoxLineStyle = new System.Windows.Forms.ComboBox();
			this.numericUpDownLineWidth = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.groupPanel4 = new GroupPanel();
			this.checkBoxWantSPL = new System.Windows.Forms.CheckBox();
			this.checkBoxShowVertex = new System.Windows.Forms.CheckBox();
			this.checkBoxShowText = new System.Windows.Forms.CheckBox();
			this.checkBoxShowTriangle = new System.Windows.Forms.CheckBox();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.ribbonClientPanel1.SuspendLayout();
			this.groupPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorValueMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorValueMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxFillColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxCurveColor).BeginInit();
			this.groupPanel5.SuspendLayout();
			this.groupPanel3.SuspendLayout();
			this.groupPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLineWidth).BeginInit();
			this.groupPanel4.SuspendLayout();
			base.SuspendLayout();
			this.ribbonClientPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.buttonXSaveDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.buttonXLoadDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel1);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel5);
			this.ribbonClientPanel1.Controls.Add(this.textBoxXFilePath);
			this.ribbonClientPanel1.Controls.Add(this.buttonCancel);
			this.ribbonClientPanel1.Controls.Add(this.buttonOK);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel3);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel2);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel4);
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(827, 361);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.TabIndex = 38;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.buttonXSaveDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXSaveDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXSaveDefaultParams.Image = (System.Drawing.Image)resources.GetObject("buttonXSaveDefaultParams.Image");
			this.buttonXSaveDefaultParams.Location = new System.Drawing.Point(408, 304);
			this.buttonXSaveDefaultParams.Name = "buttonXSaveDefaultParams";
			this.buttonXSaveDefaultParams.Size = new System.Drawing.Size(166, 44);
			this.buttonXSaveDefaultParams.TabIndex = 37;
			this.buttonXSaveDefaultParams.Text = "保存为默认参数";
			this.buttonXSaveDefaultParams.Click += new System.EventHandler(this.buttonXSaveDefaultParams_Click);
			this.buttonXLoadDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXLoadDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXLoadDefaultParams.Image = (System.Drawing.Image)resources.GetObject("buttonXLoadDefaultParams.Image");
			this.buttonXLoadDefaultParams.Location = new System.Drawing.Point(245, 304);
			this.buttonXLoadDefaultParams.Name = "buttonXLoadDefaultParams";
			this.buttonXLoadDefaultParams.Size = new System.Drawing.Size(157, 44);
			this.buttonXLoadDefaultParams.TabIndex = 36;
			this.buttonXLoadDefaultParams.Text = "载入默认参数";
			this.buttonXLoadDefaultParams.Click += new System.EventHandler(this.buttonXLoadDefaultParams_Click);
			this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel1.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel1.Controls.Add(this.textBoxColorText);
			this.groupPanel1.Controls.Add(this.numericUpDownColorValueMax);
			this.groupPanel1.Controls.Add(this.numericUpDownColorValueMin);
			this.groupPanel1.Controls.Add(this.label1);
			this.groupPanel1.Controls.Add(this.label8);
			this.groupPanel1.Controls.Add(this.label3);
			this.groupPanel1.Controls.Add(this.buttonChoseFillColor);
			this.groupPanel1.Controls.Add(this.buttonChoseCurveColor);
			this.groupPanel1.Controls.Add(this.label5);
			this.groupPanel1.Controls.Add(this.label6);
			this.groupPanel1.Controls.Add(this.pictureBoxFillColor);
			this.groupPanel1.Controls.Add(this.pictureBoxCurveColor);
			this.groupPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel1.Location = new System.Drawing.Point(245, 12);
			this.groupPanel1.Name = "groupPanel1";
			this.groupPanel1.Size = new System.Drawing.Size(159, 286);
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
			this.groupPanel1.Style.CornerDiameter = 4;
			this.groupPanel1.Style.CornerType = eCornerType.Rounded;
			this.groupPanel1.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel1.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel1.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel1.TabIndex = 32;
			this.groupPanel1.Text = "区域参数";
			this.textBoxColorText.Location = new System.Drawing.Point(7, 216);
			this.textBoxColorText.Name = "textBoxColorText";
			this.textBoxColorText.ReadOnly = true;
			this.textBoxColorText.Size = new System.Drawing.Size(142, 26);
			this.textBoxColorText.TabIndex = 26;
			this.textBoxColorText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownColorValueMax.DecimalPlaces = 2;
			this.numericUpDownColorValueMax.Enabled = false;
			this.numericUpDownColorValueMax.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDownColorValueMax.Location = new System.Drawing.Point(42, 162);
			System.Windows.Forms.NumericUpDown arg_987_0 = this.numericUpDownColorValueMax;
			int[] array = new int[4];
			array[0] = 9999;
			arg_987_0.Maximum = new decimal(array);
			this.numericUpDownColorValueMax.Minimum = new decimal(new int[]
			{
				9999,
				0,
				0,
				-2147483648
			});
			this.numericUpDownColorValueMax.Name = "numericUpDownColorValueMax";
			this.numericUpDownColorValueMax.Size = new System.Drawing.Size(108, 26);
			this.numericUpDownColorValueMax.TabIndex = 25;
			this.numericUpDownColorValueMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownColorValueMin.DecimalPlaces = 2;
			this.numericUpDownColorValueMin.Enabled = false;
			this.numericUpDownColorValueMin.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDownColorValueMin.Location = new System.Drawing.Point(6, 130);
			System.Windows.Forms.NumericUpDown arg_A68_0 = this.numericUpDownColorValueMin;
			array = new int[4];
			array[0] = 9999;
			arg_A68_0.Maximum = new decimal(array);
			this.numericUpDownColorValueMin.Minimum = new decimal(new int[]
			{
				9999,
				0,
				0,
				-2147483648
			});
			this.numericUpDownColorValueMin.Name = "numericUpDownColorValueMin";
			this.numericUpDownColorValueMin.Size = new System.Drawing.Size(108, 26);
			this.numericUpDownColorValueMin.TabIndex = 25;
			this.numericUpDownColorValueMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label1.Location = new System.Drawing.Point(3, 194);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(79, 19);
			this.label1.TabIndex = 22;
			this.label1.Text = "区域名称：";
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label8.Location = new System.Drawing.Point(120, 132);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(23, 19);
			this.label8.TabIndex = 22;
			this.label8.Text = "至";
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label3.Location = new System.Drawing.Point(2, 105);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 19);
			this.label3.TabIndex = 22;
			this.label3.Text = "数值范围：";
			this.buttonChoseFillColor.Enabled = false;
			this.buttonChoseFillColor.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonChoseFillColor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.buttonChoseFillColor.Location = new System.Drawing.Point(86, 24);
			this.buttonChoseFillColor.Name = "buttonChoseFillColor";
			this.buttonChoseFillColor.Size = new System.Drawing.Size(62, 27);
			this.buttonChoseFillColor.TabIndex = 21;
			this.buttonChoseFillColor.Text = "选\u3000择";
			this.buttonChoseFillColor.UseVisualStyleBackColor = true;
			this.buttonChoseFillColor.Click += new System.EventHandler(this.buttonChoseFillColor_Click);
			this.buttonChoseCurveColor.Enabled = false;
			this.buttonChoseCurveColor.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonChoseCurveColor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.buttonChoseCurveColor.Location = new System.Drawing.Point(86, 76);
			this.buttonChoseCurveColor.Name = "buttonChoseCurveColor";
			this.buttonChoseCurveColor.Size = new System.Drawing.Size(62, 27);
			this.buttonChoseCurveColor.TabIndex = 21;
			this.buttonChoseCurveColor.Text = "选\u3000择";
			this.buttonChoseCurveColor.UseVisualStyleBackColor = true;
			this.buttonChoseCurveColor.Click += new System.EventHandler(this.buttonChoseCurveColor_Click);
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label5.Location = new System.Drawing.Point(2, 2);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 19);
			this.label5.TabIndex = 22;
			this.label5.Text = "填充颜色：";
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label6.Location = new System.Drawing.Point(2, 54);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 19);
			this.label6.TabIndex = 22;
			this.label6.Text = "边界颜色：";
			this.pictureBoxFillColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxFillColor.Location = new System.Drawing.Point(6, 24);
			this.pictureBoxFillColor.Name = "pictureBoxFillColor";
			this.pictureBoxFillColor.Size = new System.Drawing.Size(71, 26);
			this.pictureBoxFillColor.TabIndex = 23;
			this.pictureBoxFillColor.TabStop = false;
			this.pictureBoxCurveColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxCurveColor.Location = new System.Drawing.Point(6, 76);
			this.pictureBoxCurveColor.Name = "pictureBoxCurveColor";
			this.pictureBoxCurveColor.Size = new System.Drawing.Size(71, 26);
			this.pictureBoxCurveColor.TabIndex = 23;
			this.pictureBoxCurveColor.TabStop = false;
			this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel5.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel5.Controls.Add(this.buttonXClearColor);
			this.groupPanel5.Controls.Add(this.listViewColorItem);
			this.groupPanel5.Controls.Add(this.buttonX3DeleteColor);
			this.groupPanel5.Controls.Add(this.buttonXAddColor);
			this.groupPanel5.Controls.Add(this.buttonXModifyColor);
			this.groupPanel5.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel5.Location = new System.Drawing.Point(12, 12);
			this.groupPanel5.Name = "groupPanel5";
			this.groupPanel5.Size = new System.Drawing.Size(227, 336);
			this.groupPanel5.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanel5.Style.BackColorGradientAngle = 90;
			this.groupPanel5.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanel5.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanel5.Style.BorderBottomWidth = 1;
			this.groupPanel5.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanel5.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanel5.Style.BorderLeftWidth = 1;
			this.groupPanel5.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanel5.Style.BorderRightWidth = 1;
			this.groupPanel5.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanel5.Style.BorderTopWidth = 1;
			this.groupPanel5.Style.CornerDiameter = 4;
			this.groupPanel5.Style.CornerType = eCornerType.Rounded;
			this.groupPanel5.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel5.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel5.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel5.TabIndex = 33;
			this.groupPanel5.Text = "区划列表";
			this.buttonXClearColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXClearColor.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXClearColor.Image = Resources.a008;
			this.buttonXClearColor.Location = new System.Drawing.Point(111, 254);
			this.buttonXClearColor.Name = "buttonXClearColor";
			this.buttonXClearColor.Size = new System.Drawing.Size(105, 44);
			this.buttonXClearColor.TabIndex = 35;
			this.buttonXClearColor.Text = "清\u3000空";
			this.buttonXClearColor.Click += new System.EventHandler(this.buttonXClearColor_Click);
			this.listViewColorItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1,
				this.columnHeader2,
				this.columnHeader3,
				this.columnHeader4
			});
			this.listViewColorItem.FullRowSelect = true;
			this.listViewColorItem.GridLines = true;
			this.listViewColorItem.HideSelection = false;
			this.listViewColorItem.Location = new System.Drawing.Point(3, 3);
			this.listViewColorItem.MultiSelect = false;
			this.listViewColorItem.Name = "listViewColorItem";
			this.listViewColorItem.Size = new System.Drawing.Size(213, 195);
			this.listViewColorItem.TabIndex = 0;
			this.listViewColorItem.UseCompatibleStateImageBehavior = false;
			this.listViewColorItem.View = System.Windows.Forms.View.Details;
			this.listViewColorItem.SelectedIndexChanged += new System.EventHandler(this.listViewColorItem_SelectedIndexChanged);
			this.columnHeader1.Text = "序号";
			this.columnHeader1.Width = 40;
			this.columnHeader2.Text = "文字";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 61;
			this.columnHeader3.Text = "最小值";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 55;
			this.columnHeader4.Text = "最大值";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 55;
			this.buttonX3DeleteColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX3DeleteColor.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonX3DeleteColor.Image = Resources.Minus;
			this.buttonX3DeleteColor.Location = new System.Drawing.Point(4, 254);
			this.buttonX3DeleteColor.Name = "buttonX3DeleteColor";
			this.buttonX3DeleteColor.Size = new System.Drawing.Size(105, 44);
			this.buttonX3DeleteColor.TabIndex = 34;
			this.buttonX3DeleteColor.Text = "删\u3000除";
			this.buttonX3DeleteColor.Click += new System.EventHandler(this.buttonX3DeleteColor_Click);
			this.buttonXAddColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXAddColor.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXAddColor.Image = Resources.Plus;
			this.buttonXAddColor.Location = new System.Drawing.Point(4, 204);
			this.buttonXAddColor.Name = "buttonXAddColor";
			this.buttonXAddColor.Size = new System.Drawing.Size(105, 44);
			this.buttonXAddColor.TabIndex = 37;
			this.buttonXAddColor.Text = "添\u3000加";
			this.buttonXAddColor.Click += new System.EventHandler(this.buttonXAddColor_Click);
			this.buttonXModifyColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXModifyColor.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXModifyColor.Image = Resources.未标题_1;
			this.buttonXModifyColor.Location = new System.Drawing.Point(111, 204);
			this.buttonXModifyColor.Name = "buttonXModifyColor";
			this.buttonXModifyColor.Size = new System.Drawing.Size(105, 44);
			this.buttonXModifyColor.TabIndex = 36;
			this.buttonXModifyColor.Text = "修\u3000改";
			this.buttonXModifyColor.Click += new System.EventHandler(this.buttonXModifyColor_Click);
			this.textBoxXFilePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.textBoxXFilePath.Border.Class = "TextBoxBorder";
			this.textBoxXFilePath.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.textBoxXFilePath.Location = new System.Drawing.Point(414, 241);
			this.textBoxXFilePath.Multiline = true;
			this.textBoxXFilePath.Name = "textBoxXFilePath";
			this.textBoxXFilePath.Size = new System.Drawing.Size(396, 57);
			this.textBoxXFilePath.TabIndex = 31;
			this.textBoxXFilePath.Text = "数据路径：";
			this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonCancel.Image = Resources.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(698, 304);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(112, 44);
			this.buttonCancel.TabIndex = 28;
			this.buttonCancel.Text = "取\u3000消";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonOK.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonOK.Image = Resources.OK;
			this.buttonOK.Location = new System.Drawing.Point(580, 303);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(112, 44);
			this.buttonOK.TabIndex = 28;
			this.buttonOK.Text = "确\u3000定";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel3.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel3.Controls.Add(this.trackBarFillAlpha);
			this.groupPanel3.Controls.Add(this.label7);
			this.groupPanel3.Controls.Add(this.labelFillAlpha);
			this.groupPanel3.Controls.Add(this.checkBoxFillRegion);
			this.groupPanel3.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel3.Location = new System.Drawing.Point(414, 132);
			this.groupPanel3.Name = "groupPanel3";
			this.groupPanel3.Size = new System.Drawing.Size(396, 103);
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
			this.groupPanel3.Text = "区域填充样式选项";
			this.trackBarFillAlpha.LabelVisible = false;
			this.trackBarFillAlpha.Location = new System.Drawing.Point(93, 29);
			this.trackBarFillAlpha.Maximum = 255;
			this.trackBarFillAlpha.Name = "trackBarFillAlpha";
			this.trackBarFillAlpha.Size = new System.Drawing.Size(238, 32);
			this.trackBarFillAlpha.TabIndex = 28;
			this.trackBarFillAlpha.Text = "slider1";
			this.trackBarFillAlpha.Value = 150;
			this.trackBarFillAlpha.ValueChanged += new System.EventHandler(this.trackBarFillAlpha_ValueChanged);
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label7.Location = new System.Drawing.Point(22, 36);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 19);
			this.label7.TabIndex = 26;
			this.label7.Text = "透明度：";
			this.labelFillAlpha.AutoSize = true;
			this.labelFillAlpha.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.labelFillAlpha.ForeColor = System.Drawing.SystemColors.WindowText;
			this.labelFillAlpha.Location = new System.Drawing.Point(337, 36);
			this.labelFillAlpha.Name = "labelFillAlpha";
			this.labelFillAlpha.Size = new System.Drawing.Size(36, 19);
			this.labelFillAlpha.TabIndex = 25;
			this.labelFillAlpha.Text = "150";
			this.checkBoxFillRegion.AutoSize = true;
			this.checkBoxFillRegion.Checked = true;
			this.checkBoxFillRegion.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxFillRegion.Enabled = false;
			this.checkBoxFillRegion.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxFillRegion.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxFillRegion.Location = new System.Drawing.Point(26, 10);
			this.checkBoxFillRegion.Name = "checkBoxFillRegion";
			this.checkBoxFillRegion.Size = new System.Drawing.Size(84, 23);
			this.checkBoxFillRegion.TabIndex = 24;
			this.checkBoxFillRegion.Text = "使用填充";
			this.checkBoxFillRegion.UseVisualStyleBackColor = true;
			this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel2.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel2.Controls.Add(this.comboBoxLineStyle);
			this.groupPanel2.Controls.Add(this.numericUpDownLineWidth);
			this.groupPanel2.Controls.Add(this.label14);
			this.groupPanel2.Controls.Add(this.label13);
			this.groupPanel2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel2.Location = new System.Drawing.Point(414, 12);
			this.groupPanel2.Name = "groupPanel2";
			this.groupPanel2.Size = new System.Drawing.Size(186, 114);
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
			this.groupPanel2.Text = "区域边界线样式选项";
			this.comboBoxLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLineStyle.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.comboBoxLineStyle.FormattingEnabled = true;
			this.comboBoxLineStyle.Items.AddRange(new object[]
			{
				"— — — —",
				"—.—.—.—",
				"—. .—. .—",
				". . . . . . . . . ",
				"—————"
			});
			this.comboBoxLineStyle.Location = new System.Drawing.Point(80, 42);
			this.comboBoxLineStyle.Name = "comboBoxLineStyle";
			this.comboBoxLineStyle.Size = new System.Drawing.Size(86, 25);
			this.comboBoxLineStyle.TabIndex = 31;
			this.numericUpDownLineWidth.Location = new System.Drawing.Point(80, 10);
			System.Windows.Forms.NumericUpDown arg_2132_0 = this.numericUpDownLineWidth;
			array = new int[4];
			array[0] = 10;
			arg_2132_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_214F_0 = this.numericUpDownLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_214F_0.Minimum = new decimal(array);
			this.numericUpDownLineWidth.Name = "numericUpDownLineWidth";
			this.numericUpDownLineWidth.Size = new System.Drawing.Size(86, 26);
			this.numericUpDownLineWidth.TabIndex = 30;
			this.numericUpDownLineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_21AD_0 = this.numericUpDownLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_21AD_0.Value = new decimal(array);
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label14.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label14.Location = new System.Drawing.Point(9, 43);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(65, 19);
			this.label14.TabIndex = 29;
			this.label14.Text = "线\u3000型：";
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label13.Location = new System.Drawing.Point(9, 14);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(65, 19);
			this.label13.TabIndex = 28;
			this.label13.Text = "线\u3000粗：";
			this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel4.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel4.Controls.Add(this.checkBoxWantSPL);
			this.groupPanel4.Controls.Add(this.checkBoxShowVertex);
			this.groupPanel4.Controls.Add(this.checkBoxShowText);
			this.groupPanel4.Controls.Add(this.checkBoxShowTriangle);
			this.groupPanel4.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel4.Location = new System.Drawing.Point(606, 11);
			this.groupPanel4.Name = "groupPanel4";
			this.groupPanel4.Size = new System.Drawing.Size(204, 115);
			this.groupPanel4.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanel4.Style.BackColorGradientAngle = 90;
			this.groupPanel4.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanel4.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanel4.Style.BorderBottomWidth = 1;
			this.groupPanel4.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanel4.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanel4.Style.BorderLeftWidth = 1;
			this.groupPanel4.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanel4.Style.BorderRightWidth = 1;
			this.groupPanel4.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanel4.Style.BorderTopWidth = 1;
			this.groupPanel4.Style.CornerDiameter = 4;
			this.groupPanel4.Style.CornerType = eCornerType.Rounded;
			this.groupPanel4.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel4.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel4.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel4.TabIndex = 0;
			this.groupPanel4.Text = "其它选项";
			this.checkBoxWantSPL.AutoSize = true;
			this.checkBoxWantSPL.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxWantSPL.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxWantSPL.Location = new System.Drawing.Point(95, 40);
			this.checkBoxWantSPL.Name = "checkBoxWantSPL";
			this.checkBoxWantSPL.Size = new System.Drawing.Size(84, 23);
			this.checkBoxWantSPL.TabIndex = 24;
			this.checkBoxWantSPL.Text = "样条插值";
			this.checkBoxWantSPL.UseVisualStyleBackColor = true;
			this.checkBoxShowVertex.AutoSize = true;
			this.checkBoxShowVertex.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxShowVertex.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowVertex.Location = new System.Drawing.Point(8, 11);
			this.checkBoxShowVertex.Name = "checkBoxShowVertex";
			this.checkBoxShowVertex.Size = new System.Drawing.Size(84, 23);
			this.checkBoxShowVertex.TabIndex = 24;
			this.checkBoxShowVertex.Text = "显示站点";
			this.checkBoxShowVertex.UseVisualStyleBackColor = true;
			this.checkBoxShowText.AutoSize = true;
			this.checkBoxShowText.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxShowText.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowText.Location = new System.Drawing.Point(8, 40);
			this.checkBoxShowText.Name = "checkBoxShowText";
			this.checkBoxShowText.Size = new System.Drawing.Size(84, 23);
			this.checkBoxShowText.TabIndex = 24;
			this.checkBoxShowText.Text = "显示文字";
			this.checkBoxShowText.UseVisualStyleBackColor = true;
			this.checkBoxShowTriangle.AutoSize = true;
			this.checkBoxShowTriangle.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxShowTriangle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowTriangle.Location = new System.Drawing.Point(95, 11);
			this.checkBoxShowTriangle.Name = "checkBoxShowTriangle";
			this.checkBoxShowTriangle.Size = new System.Drawing.Size(98, 23);
			this.checkBoxShowTriangle.TabIndex = 24;
			this.checkBoxShowTriangle.Text = "显示三角形";
			this.checkBoxShowTriangle.UseVisualStyleBackColor = true;
			this.colorDialog.AnyColor = true;
			this.colorDialog.FullOpen = true;
			this.imageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList.ImageStream");
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "colorbar0.bmp");
			this.imageList.Images.SetKeyName(1, "colorbar1.bmp");
			this.imageList.Images.SetKeyName(2, "colorbar2.bmp");
			this.imageList.Images.SetKeyName(3, "colorbar3.bmp");
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(824, 361);
			base.ControlBox = false;
			base.Controls.Add(this.ribbonClientPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "RegionSettingForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "区划参数设置";
			base.Load += new System.EventHandler(this.RegionSettingForm_Load);
			this.ribbonClientPanel1.ResumeLayout(false);
			this.groupPanel1.ResumeLayout(false);
			this.groupPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorValueMax).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorValueMin).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxFillColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxCurveColor).EndInit();
			this.groupPanel5.ResumeLayout(false);
			this.groupPanel3.ResumeLayout(false);
			this.groupPanel3.PerformLayout();
			this.groupPanel2.ResumeLayout(false);
			this.groupPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLineWidth).EndInit();
			this.groupPanel4.ResumeLayout(false);
			this.groupPanel4.PerformLayout();
			base.ResumeLayout(false);
		}

		public RegionSettingForm()
		{
			this.InitializeComponent();
			this.m_RegionParams = new RegionParams();
			this.m_RegionParams.LoadParams();
			this.LoadRegionParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_RegionParams.ParamFilePath;
		}

		public RegionSettingForm(RegionParams regionParams)
		{
			this.InitializeComponent();
			this.m_RegionParams = regionParams;
			if (this.m_RegionParams == null)
			{
				System.Windows.Forms.MessageBox.Show("传入区划参数为空！使用默认参数……", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_RegionParams = new RegionParams();
				this.m_RegionParams.LoadParams();
			}
			this.LoadRegionParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_RegionParams.ParamFilePath;
		}

		private void LoadRegionParams()
		{
			this.RegionLineWidth = this.m_RegionParams.RegionLineWidth;
			this.RegionLineStyle = this.m_RegionParams.RegionLineStyle;
			this.RegionWantFill = this.m_RegionParams.RegionWantFill;
			this.RegionFillAlpha = this.m_RegionParams.RegionFillAlpha;
			this.RegionWantVertex = this.m_RegionParams.RegionWantVertex;
			this.RegionWantTriangle = this.m_RegionParams.RegionWantTriangle;
			this.RegionShowRegionText = this.m_RegionParams.RegionShowRegionText;
			this.RegionWantSPL = this.m_RegionParams.RegionWantSPL;
			this.ShowColorItems();
		}

		private bool ApplyRegionParams()
		{
			this.m_RegionParams.RegionLineWidth = this.RegionLineWidth;
			this.m_RegionParams.RegionLineStyle = this.RegionLineStyle;
			this.m_RegionParams.RegionWantFill = this.RegionWantFill;
			this.m_RegionParams.RegionFillAlpha = this.RegionFillAlpha;
			this.m_RegionParams.RegionWantVertex = this.RegionWantVertex;
			this.m_RegionParams.RegionWantTriangle = this.RegionWantTriangle;
			this.m_RegionParams.RegionShowRegionText = this.RegionShowRegionText;
			this.m_RegionParams.RegionWantSPL = this.RegionWantSPL;
			this.ApplyColorItems();
			return true;
		}

		private void ShowColorItems()
		{
			this.listViewColorItem.Items.Clear();
			for (int i = 0; i < this.RegionLineColorManager.m_ColorItems.Count; i++)
			{
				System.Windows.Forms.ListViewItem newItem = this.listViewColorItem.Items.Add(System.Convert.ToString(i + 1));
				newItem.SubItems.Add(this.RegionLineColorManager.m_ColorItems[i].myValueText);
				System.Windows.Forms.ListViewItem.ListViewSubItem lineSubItem = newItem.SubItems.Add(this.RegionLineColorManager.m_ColorItems[i].myValue.ToString("F2"));
				lineSubItem.Tag = this.RegionLineColorManager.m_ColorItems[i].myColor;
				System.Windows.Forms.ListViewItem.ListViewSubItem fillSubItem = newItem.SubItems.Add(this.RegionFillColorManager.m_ColorItems[i].myValue.ToString("F2"));
				fillSubItem.Tag = this.RegionFillColorManager.m_ColorItems[i].myColor;
			}
			if (this.listViewColorItem.Items.Count != 0)
			{
				this.listViewColorItem.Items[0].Selected = true;
			}
		}

		private void ApplyColorItems()
		{
			this.RegionLineColorManager.m_ColorItems.Clear();
			this.RegionFillColorManager.m_ColorItems.Clear();
			for (int i = 0; i < this.listViewColorItem.Items.Count; i++)
			{
				string Name = this.listViewColorItem.Items[i].SubItems[1].Text;
				float MinValue = System.Convert.ToSingle(this.listViewColorItem.Items[i].SubItems[2].Text);
				float MaxValue = System.Convert.ToSingle(this.listViewColorItem.Items[i].SubItems[3].Text);
				System.Drawing.Color curveColor = (System.Drawing.Color)this.listViewColorItem.Items[i].SubItems[2].Tag;
				System.Drawing.Color fillColor = (System.Drawing.Color)this.listViewColorItem.Items[i].SubItems[3].Tag;
				wMetroGIS.wColorManager.ColorItem curveItem = new wMetroGIS.wColorManager.ColorItem(curveColor, MinValue, Name);
				wMetroGIS.wColorManager.ColorItem fillItem = new wMetroGIS.wColorManager.ColorItem(fillColor, MaxValue, Name);
				this.RegionLineColorManager.m_ColorItems.Add(curveItem);
				this.RegionFillColorManager.m_ColorItems.Add(fillItem);
			}
		}

		private void trackBarFillAlpha_ValueChanged(object sender, System.EventArgs e)
		{
			this.labelFillAlpha.Text = this.trackBarFillAlpha.Value.ToString();
		}

		private void buttonChoseFillColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxFillColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxFillColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonChoseCurveColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxCurveColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxCurveColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.ApplyRegionParams();
			if (this.m_RegionParams.SaveParams())
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

		private void listViewColorItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.listViewColorItem.SelectedItems != null && this.listViewColorItem.SelectedItems.Count != 0)
			{
				System.Windows.Forms.ListViewItem selectedItem = this.listViewColorItem.SelectedItems[0];
				this.textBoxColorText.Text = selectedItem.SubItems[1].Text;
				this.numericUpDownColorValueMin.Value = (decimal)System.Convert.ToSingle(selectedItem.SubItems[2].Text);
				this.numericUpDownColorValueMax.Value = (decimal)System.Convert.ToSingle(selectedItem.SubItems[3].Text);
				this.pictureBoxCurveColor.BackColor = (System.Drawing.Color)selectedItem.SubItems[2].Tag;
				this.pictureBoxFillColor.BackColor = (System.Drawing.Color)selectedItem.SubItems[3].Tag;
			}
		}

		private void buttonXAddColor_Click(object sender, System.EventArgs e)
		{
			if (this.listViewColorItem.Enabled)
			{
				this.listViewColorItem.Enabled = false;
				this.buttonXAddColor.Text = "完\u3000成";
				this.textBoxColorText.Text = "";
				this.numericUpDownColorValueMin.Value = 0m;
				this.numericUpDownColorValueMax.Value = 0m;
			}
			else
			{
				if (this.textBoxColorText.Text == "")
				{
					System.Windows.Forms.MessageBox.Show("请填写区划文字！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					return;
				}
				this.listViewColorItem.Enabled = true;
				this.buttonXAddColor.Text = "添\u3000加";
				System.Windows.Forms.ListViewItem newItem = this.listViewColorItem.Items.Add(System.Convert.ToString(this.listViewColorItem.Items.Count + 1));
				newItem.SubItems.Add(this.textBoxColorText.Text);
				System.Windows.Forms.ListViewItem.ListViewSubItem lineSubItem = newItem.SubItems.Add(this.numericUpDownColorValueMin.Value.ToString("F2"));
				lineSubItem.Tag = this.pictureBoxCurveColor.BackColor;
				System.Windows.Forms.ListViewItem.ListViewSubItem fillSubItem = newItem.SubItems.Add(this.numericUpDownColorValueMax.Value.ToString("F2"));
				fillSubItem.Tag = this.pictureBoxFillColor.BackColor;
				this.listViewColorItem.Items[this.listViewColorItem.Items.Count - 1].Selected = true;
			}
			this.buttonXModifyColor.Enabled = this.listViewColorItem.Enabled;
			this.buttonX3DeleteColor.Enabled = this.listViewColorItem.Enabled;
			this.buttonXClearColor.Enabled = this.listViewColorItem.Enabled;
			this.buttonOK.Enabled = this.listViewColorItem.Enabled;
			this.buttonCancel.Enabled = this.listViewColorItem.Enabled;
			this.buttonChoseFillColor.Enabled = !this.listViewColorItem.Enabled;
			this.buttonChoseCurveColor.Enabled = !this.listViewColorItem.Enabled;
			this.numericUpDownColorValueMin.Enabled = !this.listViewColorItem.Enabled;
			this.numericUpDownColorValueMax.Enabled = !this.listViewColorItem.Enabled;
			this.textBoxColorText.ReadOnly = this.listViewColorItem.Enabled;
		}

		private void buttonXModifyColor_Click(object sender, System.EventArgs e)
		{
			if (this.listViewColorItem.SelectedItems == null || this.listViewColorItem.SelectedItems.Count == 0)
			{
				System.Windows.Forms.MessageBox.Show("请先选择一项！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
			else
			{
				if (this.listViewColorItem.Enabled)
				{
					this.listViewColorItem.Enabled = false;
					this.buttonXModifyColor.Text = "完\u3000成";
				}
				else
				{
					if (this.textBoxColorText.Text == "")
					{
						System.Windows.Forms.MessageBox.Show("请填写区划文字！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
						return;
					}
					this.listViewColorItem.Enabled = true;
					this.buttonXModifyColor.Text = "修\u3000改";
					System.Windows.Forms.ListViewItem selectedItem = this.listViewColorItem.SelectedItems[0];
					selectedItem.SubItems[1].Text = this.textBoxColorText.Text;
					selectedItem.SubItems[2].Text = this.numericUpDownColorValueMin.Value.ToString("F2");
					selectedItem.SubItems[3].Text = this.numericUpDownColorValueMax.Value.ToString("F2");
					selectedItem.SubItems[2].Tag = this.pictureBoxCurveColor.BackColor;
					selectedItem.SubItems[3].Tag = this.pictureBoxFillColor.BackColor;
				}
				this.buttonXAddColor.Enabled = this.listViewColorItem.Enabled;
				this.buttonX3DeleteColor.Enabled = this.listViewColorItem.Enabled;
				this.buttonXClearColor.Enabled = this.listViewColorItem.Enabled;
				this.buttonOK.Enabled = this.listViewColorItem.Enabled;
				this.buttonCancel.Enabled = this.listViewColorItem.Enabled;
				this.buttonChoseFillColor.Enabled = !this.listViewColorItem.Enabled;
				this.buttonChoseCurveColor.Enabled = !this.listViewColorItem.Enabled;
				this.numericUpDownColorValueMin.Enabled = !this.listViewColorItem.Enabled;
				this.numericUpDownColorValueMax.Enabled = !this.listViewColorItem.Enabled;
				this.textBoxColorText.ReadOnly = this.listViewColorItem.Enabled;
			}
		}

		private void buttonX3DeleteColor_Click(object sender, System.EventArgs e)
		{
			if (this.listViewColorItem.SelectedItems == null || this.listViewColorItem.SelectedItems.Count == 0)
			{
				System.Windows.Forms.MessageBox.Show("请先选择一项！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
			else if (System.Windows.Forms.MessageBox.Show("确定要删除此项吗？", "警告", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				this.listViewColorItem.Items.Remove(this.listViewColorItem.SelectedItems[0]);
				for (int i = 0; i < this.listViewColorItem.Items.Count; i++)
				{
					this.listViewColorItem.Items[i].Text = System.Convert.ToString(i + 1);
				}
				if (this.listViewColorItem.Items.Count != 0)
				{
					this.listViewColorItem.Items[0].Selected = true;
				}
			}
		}

		private void buttonXClearColor_Click(object sender, System.EventArgs e)
		{
			if (System.Windows.Forms.MessageBox.Show("清空区划列表无法恢复，确认吗？", "警告", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
			{
				this.listViewColorItem.Items.Clear();
			}
		}

		private void buttonXLoadDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.m_RegionParams.LoadDefaultParams())
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				this.LoadRegionParams();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
		}

		private void buttonXSaveDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.ApplyRegionParams())
			{
				if (this.m_RegionParams.SaveDefaultParams())
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
			}
		}

		private void RegionSettingForm_Load(object sender, System.EventArgs e)
		{
			this.Text = System.IO.Path.GetFileNameWithoutExtension(this.m_RegionParams.ParamFilePath) + " 区域绘制参数设置";
		}
	}
}
