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
	public class BarChartSettingForm : System.Windows.Forms.Form
	{
		public BarChartParams m_BarChartParams;

		private System.ComponentModel.IContainer components = null;

		private RibbonClientPanel ribbonClientPanel1;

		private GroupPanel groupPanel3;

		private System.Windows.Forms.PictureBox pictureBoxAxisFontColor;

		private System.Windows.Forms.NumericUpDown numericUpDownAxisFontSize;

		private System.Windows.Forms.Button buttonAxisFontFamily;

		private System.Windows.Forms.TextBox textBoxAxisFontFamily;

		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.Button buttonAxisFontColor;

		private GroupPanel groupPanel4;

		private System.Windows.Forms.PictureBox pictureBoxPaneColor1;

		private System.Windows.Forms.NumericUpDown numericUpDownPaneColorAngle;

		private System.Windows.Forms.Button buttonPaneColor1;

		private System.Windows.Forms.PictureBox pictureBoxPaneColor2;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.Label label8;

		private System.Windows.Forms.Button buttonPaneColor2;

		private System.Windows.Forms.Label label7;

		private GroupPanel groupPanel5;

		private System.Windows.Forms.NumericUpDown numericUpDownChartColorAngle;

		private System.Windows.Forms.PictureBox pictureBoxChartColor2;

		private System.Windows.Forms.Label label12;

		private System.Windows.Forms.PictureBox pictureBoxChartColor1;

		private System.Windows.Forms.Label label10;

		private System.Windows.Forms.Button buttonChartColor2;

		private System.Windows.Forms.Button buttonChartColor1;

		private System.Windows.Forms.Label label9;

		private GroupPanel groupPanel1;

		private System.Windows.Forms.PictureBox pictureBoxTitleFontColor;

		private System.Windows.Forms.NumericUpDown numericUpDownTitleFontSize;

		private System.Windows.Forms.Button buttonTitleFontFamily;

		private System.Windows.Forms.TextBox textBoxTitleFontFamily;

		private System.Windows.Forms.Label label11;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.Button buttonTitleFontColor;

		private System.Windows.Forms.CheckBox checkBoxMinorGridY;

		private System.Windows.Forms.CheckBox checkBoxMajorGridY;

		private System.Windows.Forms.CheckBox checkBoxMinorGridX;

		private System.Windows.Forms.CheckBox checkBoxMajorGridX;

		private System.Windows.Forms.Button buttonGridColor;

		private System.Windows.Forms.PictureBox pictureBoxGridColor;

		private System.Windows.Forms.Label label16;

		private System.Windows.Forms.NumericUpDown numericUpDownCurveWidth;

		private System.Windows.Forms.PictureBox pictureBoxCurveColor;

		private System.Windows.Forms.Button buttonCurveColor;

		private System.Windows.Forms.Label label19;

		private System.Windows.Forms.Label label20;

		private System.Windows.Forms.RadioButton radioButtonBarValurPosCenter;

		private System.Windows.Forms.RadioButton radioButtonBarValurPosTop;

		private System.Windows.Forms.NumericUpDown numericUpDownBarColorAngle;

		private System.Windows.Forms.PictureBox pictureBoxBarColor2;

		private System.Windows.Forms.PictureBox pictureBoxBarColor1;

		private System.Windows.Forms.CheckBox checkBoxShowBarValue;

		private System.Windows.Forms.Button buttonBarColor2;

		private System.Windows.Forms.Label label17;

		private System.Windows.Forms.Label label13;

		private System.Windows.Forms.Button buttonBarColor1;

		private System.Windows.Forms.Label label14;

		private System.Windows.Forms.Label label15;

		private GroupPanel groupPanel6;

		private GroupPanel groupPanel7;

		private GroupPanel groupPanel8;

		private ButtonX buttonXShowPreview;

		private ButtonX buttonCancel;

		private ButtonX buttonOK;

		private System.Windows.Forms.ColorDialog colorDialog;

		private System.Windows.Forms.FontDialog fontDialog;

		private TextBoxX textBoxXFilePath;

		private ButtonX buttonXSaveDefaultParams;

		private ButtonX buttonXLoadDefaultParams;

		public string TitleFontFamily
		{
			get
			{
				return this.textBoxTitleFontFamily.Text;
			}
			set
			{
				this.textBoxTitleFontFamily.Text = value;
			}
		}

		public System.Drawing.Color TitleFontColor
		{
			get
			{
				return this.pictureBoxTitleFontColor.BackColor;
			}
			set
			{
				this.pictureBoxTitleFontColor.BackColor = value;
			}
		}

		public int TitleFontSize
		{
			get
			{
				return System.Convert.ToInt32(this.numericUpDownTitleFontSize.Value);
			}
			set
			{
				this.numericUpDownTitleFontSize.Value = value;
			}
		}

		public string AxisFontFamily
		{
			get
			{
				return this.textBoxAxisFontFamily.Text;
			}
			set
			{
				this.textBoxAxisFontFamily.Text = value;
			}
		}

		public System.Drawing.Color AxisFontColor
		{
			get
			{
				return this.pictureBoxAxisFontColor.BackColor;
			}
			set
			{
				this.pictureBoxAxisFontColor.BackColor = value;
			}
		}

		public int AxisFontSize
		{
			get
			{
				return System.Convert.ToInt32(this.numericUpDownAxisFontSize.Value);
			}
			set
			{
				this.numericUpDownAxisFontSize.Value = value;
			}
		}

		public System.Drawing.Color PaneColor1
		{
			get
			{
				return this.pictureBoxPaneColor1.BackColor;
			}
			set
			{
				this.pictureBoxPaneColor1.BackColor = value;
			}
		}

		public System.Drawing.Color PaneColor2
		{
			get
			{
				return this.pictureBoxPaneColor2.BackColor;
			}
			set
			{
				this.pictureBoxPaneColor2.BackColor = value;
			}
		}

		public float PaneColorAngle
		{
			get
			{
				return System.Convert.ToSingle(this.numericUpDownPaneColorAngle.Value);
			}
			set
			{
				this.numericUpDownPaneColorAngle.Value = (int)value;
			}
		}

		public System.Drawing.Color ChartColor1
		{
			get
			{
				return this.pictureBoxChartColor1.BackColor;
			}
			set
			{
				this.pictureBoxChartColor1.BackColor = value;
			}
		}

		public System.Drawing.Color ChartColor2
		{
			get
			{
				return this.pictureBoxChartColor2.BackColor;
			}
			set
			{
				this.pictureBoxChartColor2.BackColor = value;
			}
		}

		public float ChartColorAngle
		{
			get
			{
				return System.Convert.ToSingle(this.numericUpDownChartColorAngle.Value);
			}
			set
			{
				this.numericUpDownChartColorAngle.Value = (int)value;
			}
		}

		public System.Drawing.Color BarColor1
		{
			get
			{
				return this.pictureBoxBarColor1.BackColor;
			}
			set
			{
				this.pictureBoxBarColor1.BackColor = value;
			}
		}

		public System.Drawing.Color BarColor2
		{
			get
			{
				return this.pictureBoxBarColor2.BackColor;
			}
			set
			{
				this.pictureBoxBarColor2.BackColor = value;
			}
		}

		public float BarColorAngle
		{
			get
			{
				return System.Convert.ToSingle(this.numericUpDownBarColorAngle.Value);
			}
			set
			{
				this.numericUpDownBarColorAngle.Value = (int)value;
			}
		}

		public bool ShowBarValue
		{
			get
			{
				return this.checkBoxShowBarValue.Checked;
			}
			set
			{
				this.checkBoxShowBarValue.Checked = value;
			}
		}

		public bool BarValueIsCenter
		{
			get
			{
				return this.radioButtonBarValurPosCenter.Checked;
			}
			set
			{
				this.radioButtonBarValurPosCenter.Checked = value;
			}
		}

		public System.Drawing.Color CurveColor
		{
			get
			{
				return this.pictureBoxCurveColor.BackColor;
			}
			set
			{
				this.pictureBoxCurveColor.BackColor = value;
			}
		}

		public int CurveWidth
		{
			get
			{
				return System.Convert.ToInt32(this.numericUpDownCurveWidth.Value);
			}
			set
			{
				this.numericUpDownCurveWidth.Value = value;
			}
		}

		public System.Drawing.Color GridColor
		{
			get
			{
				return this.pictureBoxGridColor.BackColor;
			}
			set
			{
				this.pictureBoxGridColor.BackColor = value;
			}
		}

		public bool ShowMajorGridX
		{
			get
			{
				return this.checkBoxMajorGridX.Checked;
			}
			set
			{
				this.checkBoxMajorGridX.Checked = value;
			}
		}

		public bool ShowMajorGridY
		{
			get
			{
				return this.checkBoxMajorGridY.Checked;
			}
			set
			{
				this.checkBoxMajorGridY.Checked = value;
			}
		}

		public bool ShowMinorGridX
		{
			get
			{
				return this.checkBoxMinorGridX.Checked;
			}
			set
			{
				this.checkBoxMinorGridX.Checked = value;
			}
		}

		public bool ShowMinorGridY
		{
			get
			{
				return this.checkBoxMinorGridY.Checked;
			}
			set
			{
				this.checkBoxMinorGridY.Checked = value;
			}
		}

		public BarChartSettingForm()
		{
			this.InitializeComponent();
			this.m_BarChartParams = new BarChartParams();
			this.m_BarChartParams.LoadParams();
			this.LoadBarChartParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_BarChartParams.ParamFilePath;
		}

		public BarChartSettingForm(BarChartParams barChartParams)
		{
			this.InitializeComponent();
			this.m_BarChartParams = barChartParams;
			if (this.m_BarChartParams == null)
			{
				System.Windows.Forms.MessageBox.Show("传入图表参数为空！使用默认参数……", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_BarChartParams = new BarChartParams();
				this.m_BarChartParams.LoadParams();
			}
			this.LoadBarChartParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_BarChartParams.ParamFilePath;
		}

		private void buttonTitleFontColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxTitleFontColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxTitleFontColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonTitleFontFamily_Click(object sender, System.EventArgs e)
		{
			if (this.fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.textBoxTitleFontFamily.Text = this.fontDialog.Font.FontFamily.Name;
			}
		}

		private void buttonAxisFontColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxAxisFontColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxAxisFontColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonAxisFontFamily_Click(object sender, System.EventArgs e)
		{
			if (this.fontDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.textBoxAxisFontFamily.Text = this.fontDialog.Font.FontFamily.Name;
			}
		}

		private void buttonPaneColor1_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxPaneColor1.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxPaneColor1.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonPaneColor2_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxPaneColor2.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxPaneColor2.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonChartColor1_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxChartColor1.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxChartColor1.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonChartColor2_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxChartColor2.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxChartColor2.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonBarColor1_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxBarColor1.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxBarColor1.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonBarColor2_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxBarColor2.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxBarColor2.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonGridColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxGridColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxGridColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonCurveColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxCurveColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxCurveColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.ApplyBarChartParams();
			if (this.m_BarChartParams.SaveParams())
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

		private void buttonXShowPreview_Click(object sender, System.EventArgs e)
		{
			this.ShowPreview();
		}

		private void LoadBarChartParams()
		{
			this.TitleFontFamily = this.m_BarChartParams.TitleFontFamily;
			this.TitleFontColor = this.m_BarChartParams.TitleFontColor;
			this.TitleFontSize = this.m_BarChartParams.TitleFontSize;
			this.AxisFontFamily = this.m_BarChartParams.AxisFontFamily;
			this.AxisFontColor = this.m_BarChartParams.AxisFontColor;
			this.AxisFontSize = this.m_BarChartParams.AxisFontSize;
			this.PaneColor1 = this.m_BarChartParams.PaneColor1;
			this.PaneColor2 = this.m_BarChartParams.PaneColor2;
			this.PaneColorAngle = this.m_BarChartParams.PaneColorAngle;
			this.ChartColor1 = this.m_BarChartParams.ChartColor1;
			this.ChartColor2 = this.m_BarChartParams.ChartColor2;
			this.ChartColorAngle = this.m_BarChartParams.ChartColorAngle;
			this.BarColor1 = this.m_BarChartParams.BarColor1;
			this.BarColor2 = this.m_BarChartParams.BarColor2;
			this.BarColorAngle = this.m_BarChartParams.BarColorAngle;
			this.ShowBarValue = this.m_BarChartParams.ShowBarValue;
			this.BarValueIsCenter = this.m_BarChartParams.BarValueIsCenter;
			this.CurveColor = this.m_BarChartParams.CurveColor;
			this.CurveWidth = this.m_BarChartParams.CurveWidth;
			this.GridColor = this.m_BarChartParams.GridColor;
			this.ShowMajorGridX = this.m_BarChartParams.ShowMajorGridX;
			this.ShowMajorGridY = this.m_BarChartParams.ShowMajorGridY;
			this.ShowMinorGridX = this.m_BarChartParams.ShowMinorGridX;
			this.ShowMinorGridY = this.m_BarChartParams.ShowMinorGridY;
			this.ShowPreview();
		}

		private bool ApplyBarChartParams()
		{
			this.m_BarChartParams.TitleFontFamily = this.TitleFontFamily;
			this.m_BarChartParams.TitleFontColor = this.TitleFontColor;
			this.m_BarChartParams.TitleFontSize = this.TitleFontSize;
			this.m_BarChartParams.AxisFontFamily = this.AxisFontFamily;
			this.m_BarChartParams.AxisFontColor = this.AxisFontColor;
			this.m_BarChartParams.AxisFontSize = this.AxisFontSize;
			this.m_BarChartParams.PaneColor1 = this.PaneColor1;
			this.m_BarChartParams.PaneColor2 = this.PaneColor2;
			this.m_BarChartParams.PaneColorAngle = this.PaneColorAngle;
			this.m_BarChartParams.ChartColor1 = this.ChartColor1;
			this.m_BarChartParams.ChartColor2 = this.ChartColor2;
			this.m_BarChartParams.ChartColorAngle = this.ChartColorAngle;
			this.m_BarChartParams.BarColor1 = this.BarColor1;
			this.m_BarChartParams.BarColor2 = this.BarColor2;
			this.m_BarChartParams.BarColorAngle = this.BarColorAngle;
			this.m_BarChartParams.ShowBarValue = this.ShowBarValue;
			this.m_BarChartParams.BarValueIsCenter = this.BarValueIsCenter;
			this.m_BarChartParams.CurveColor = this.CurveColor;
			this.m_BarChartParams.CurveWidth = this.CurveWidth;
			this.m_BarChartParams.GridColor = this.GridColor;
			this.m_BarChartParams.ShowMajorGridX = this.ShowMajorGridX;
			this.m_BarChartParams.ShowMajorGridY = this.ShowMajorGridY;
			this.m_BarChartParams.ShowMinorGridX = this.ShowMinorGridX;
			this.m_BarChartParams.ShowMinorGridY = this.ShowMinorGridY;
			return true;
		}

		private void ShowPreview()
		{
			this.ApplyBarChartParams();
		}

		private void buttonXLoadDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.m_BarChartParams.LoadDefaultParams())
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				this.LoadBarChartParams();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
		}

		private void buttonXSaveDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.ApplyBarChartParams())
			{
				if (this.m_BarChartParams.SaveDefaultParams())
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
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
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.textBoxXFilePath = new TextBoxX();
			this.groupPanel3 = new GroupPanel();
			this.numericUpDownAxisFontSize = new System.Windows.Forms.NumericUpDown();
			this.buttonAxisFontFamily = new System.Windows.Forms.Button();
			this.textBoxAxisFontFamily = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonAxisFontColor = new System.Windows.Forms.Button();
			this.groupPanel4 = new GroupPanel();
			this.numericUpDownPaneColorAngle = new System.Windows.Forms.NumericUpDown();
			this.buttonPaneColor1 = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.buttonPaneColor2 = new System.Windows.Forms.Button();
			this.label7 = new System.Windows.Forms.Label();
			this.groupPanel5 = new GroupPanel();
			this.numericUpDownChartColorAngle = new System.Windows.Forms.NumericUpDown();
			this.label12 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.buttonChartColor2 = new System.Windows.Forms.Button();
			this.buttonChartColor1 = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.groupPanel6 = new GroupPanel();
			this.radioButtonBarValurPosCenter = new System.Windows.Forms.RadioButton();
			this.radioButtonBarValurPosTop = new System.Windows.Forms.RadioButton();
			this.label15 = new System.Windows.Forms.Label();
			this.numericUpDownBarColorAngle = new System.Windows.Forms.NumericUpDown();
			this.label14 = new System.Windows.Forms.Label();
			this.buttonBarColor1 = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.checkBoxShowBarValue = new System.Windows.Forms.CheckBox();
			this.label17 = new System.Windows.Forms.Label();
			this.buttonBarColor2 = new System.Windows.Forms.Button();
			this.groupPanel7 = new GroupPanel();
			this.numericUpDownCurveWidth = new System.Windows.Forms.NumericUpDown();
			this.label20 = new System.Windows.Forms.Label();
			this.buttonCurveColor = new System.Windows.Forms.Button();
			this.label19 = new System.Windows.Forms.Label();
			this.groupPanel8 = new GroupPanel();
			this.checkBoxMinorGridY = new System.Windows.Forms.CheckBox();
			this.buttonGridColor = new System.Windows.Forms.Button();
			this.checkBoxMajorGridY = new System.Windows.Forms.CheckBox();
			this.label16 = new System.Windows.Forms.Label();
			this.checkBoxMinorGridX = new System.Windows.Forms.CheckBox();
			this.checkBoxMajorGridX = new System.Windows.Forms.CheckBox();
			this.groupPanel1 = new GroupPanel();
			this.numericUpDownTitleFontSize = new System.Windows.Forms.NumericUpDown();
			this.buttonTitleFontFamily = new System.Windows.Forms.Button();
			this.textBoxTitleFontFamily = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonTitleFontColor = new System.Windows.Forms.Button();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.buttonXSaveDefaultParams = new ButtonX();
			this.buttonXLoadDefaultParams = new ButtonX();
			this.buttonXShowPreview = new ButtonX();
			this.buttonCancel = new ButtonX();
			this.pictureBoxAxisFontColor = new System.Windows.Forms.PictureBox();
			this.buttonOK = new ButtonX();
			this.pictureBoxPaneColor1 = new System.Windows.Forms.PictureBox();
			this.pictureBoxPaneColor2 = new System.Windows.Forms.PictureBox();
			this.pictureBoxChartColor1 = new System.Windows.Forms.PictureBox();
			this.pictureBoxChartColor2 = new System.Windows.Forms.PictureBox();
			this.pictureBoxBarColor1 = new System.Windows.Forms.PictureBox();
			this.pictureBoxBarColor2 = new System.Windows.Forms.PictureBox();
			this.pictureBoxCurveColor = new System.Windows.Forms.PictureBox();
			this.pictureBoxGridColor = new System.Windows.Forms.PictureBox();
			this.pictureBoxTitleFontColor = new System.Windows.Forms.PictureBox();
			this.ribbonClientPanel1.SuspendLayout();
			this.groupPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownAxisFontSize).BeginInit();
			this.groupPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownPaneColorAngle).BeginInit();
			this.groupPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownChartColorAngle).BeginInit();
			this.groupPanel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownBarColorAngle).BeginInit();
			this.groupPanel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCurveWidth).BeginInit();
			this.groupPanel8.SuspendLayout();
			this.groupPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownTitleFontSize).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxAxisFontColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPaneColor1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPaneColor2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxChartColor1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxChartColor2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBarColor1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBarColor2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxCurveColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxGridColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxTitleFontColor).BeginInit();
			base.SuspendLayout();
			this.ribbonClientPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.buttonXSaveDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.buttonXLoadDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.textBoxXFilePath);
			this.ribbonClientPanel1.Controls.Add(this.buttonXShowPreview);
			this.ribbonClientPanel1.Controls.Add(this.buttonCancel);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel3);
			this.ribbonClientPanel1.Controls.Add(this.buttonOK);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel4);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel5);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel6);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel7);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel8);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel1);
			this.ribbonClientPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(698, 516);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.TabIndex = 0;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.textBoxXFilePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.textBoxXFilePath.Border.Class = "TextBoxBorder";
			this.textBoxXFilePath.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.textBoxXFilePath.Location = new System.Drawing.Point(12, 451);
			this.textBoxXFilePath.Multiline = true;
			this.textBoxXFilePath.Name = "textBoxXFilePath";
			this.textBoxXFilePath.Size = new System.Drawing.Size(430, 49);
			this.textBoxXFilePath.TabIndex = 32;
			this.textBoxXFilePath.TabStop = false;
			this.textBoxXFilePath.Text = "数据路径：";
			this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel3.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel3.Controls.Add(this.pictureBoxAxisFontColor);
			this.groupPanel3.Controls.Add(this.numericUpDownAxisFontSize);
			this.groupPanel3.Controls.Add(this.buttonAxisFontFamily);
			this.groupPanel3.Controls.Add(this.textBoxAxisFontFamily);
			this.groupPanel3.Controls.Add(this.label5);
			this.groupPanel3.Controls.Add(this.label4);
			this.groupPanel3.Controls.Add(this.label3);
			this.groupPanel3.Controls.Add(this.buttonAxisFontColor);
			this.groupPanel3.Location = new System.Drawing.Point(12, 158);
			this.groupPanel3.Name = "groupPanel3";
			this.groupPanel3.Size = new System.Drawing.Size(209, 139);
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
			this.groupPanel3.TabIndex = 27;
			this.groupPanel3.Text = "坐标轴文字";
			this.numericUpDownAxisFontSize.BackColor = System.Drawing.SystemColors.Window;
			this.numericUpDownAxisFontSize.Location = new System.Drawing.Point(52, 70);
			System.Windows.Forms.NumericUpDown arg_99B_0 = this.numericUpDownAxisFontSize;
			int[] array = new int[4];
			array[0] = 10;
			arg_99B_0.Minimum = new decimal(array);
			this.numericUpDownAxisFontSize.Name = "numericUpDownAxisFontSize";
			this.numericUpDownAxisFontSize.ReadOnly = true;
			this.numericUpDownAxisFontSize.Size = new System.Drawing.Size(67, 26);
			this.numericUpDownAxisFontSize.TabIndex = 15;
			this.numericUpDownAxisFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_A07_0 = this.numericUpDownAxisFontSize;
			array = new int[4];
			array[0] = 10;
			arg_A07_0.Value = new decimal(array);
			this.buttonAxisFontFamily.Location = new System.Drawing.Point(125, 8);
			this.buttonAxisFontFamily.Name = "buttonAxisFontFamily";
			this.buttonAxisFontFamily.Size = new System.Drawing.Size(68, 26);
			this.buttonAxisFontFamily.TabIndex = 13;
			this.buttonAxisFontFamily.Text = "选择";
			this.buttonAxisFontFamily.UseVisualStyleBackColor = true;
			this.buttonAxisFontFamily.Click += new System.EventHandler(this.buttonAxisFontFamily_Click);
			this.textBoxAxisFontFamily.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxAxisFontFamily.Location = new System.Drawing.Point(52, 8);
			this.textBoxAxisFontFamily.Name = "textBoxAxisFontFamily";
			this.textBoxAxisFontFamily.ReadOnly = true;
			this.textBoxAxisFontFamily.Size = new System.Drawing.Size(67, 26);
			this.textBoxAxisFontFamily.TabIndex = 14;
			this.textBoxAxisFontFamily.Text = "黑体";
			this.textBoxAxisFontFamily.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(4, 43);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(51, 19);
			this.label5.TabIndex = 11;
			this.label5.Text = "颜色：";
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(4, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(51, 19);
			this.label4.TabIndex = 11;
			this.label4.Text = "大小：";
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(4, 11);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 19);
			this.label3.TabIndex = 11;
			this.label3.Text = "字体：";
			this.buttonAxisFontColor.Location = new System.Drawing.Point(125, 40);
			this.buttonAxisFontColor.Name = "buttonAxisFontColor";
			this.buttonAxisFontColor.Size = new System.Drawing.Size(68, 26);
			this.buttonAxisFontColor.TabIndex = 13;
			this.buttonAxisFontColor.Text = "选择";
			this.buttonAxisFontColor.UseVisualStyleBackColor = true;
			this.buttonAxisFontColor.Click += new System.EventHandler(this.buttonAxisFontColor_Click);
			this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel4.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel4.Controls.Add(this.pictureBoxPaneColor1);
			this.groupPanel4.Controls.Add(this.numericUpDownPaneColorAngle);
			this.groupPanel4.Controls.Add(this.buttonPaneColor1);
			this.groupPanel4.Controls.Add(this.pictureBoxPaneColor2);
			this.groupPanel4.Controls.Add(this.label6);
			this.groupPanel4.Controls.Add(this.label8);
			this.groupPanel4.Controls.Add(this.buttonPaneColor2);
			this.groupPanel4.Controls.Add(this.label7);
			this.groupPanel4.Location = new System.Drawing.Point(12, 303);
			this.groupPanel4.Name = "groupPanel4";
			this.groupPanel4.Size = new System.Drawing.Size(209, 142);
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
			this.groupPanel4.TabIndex = 27;
			this.groupPanel4.Text = "背景颜色";
			this.numericUpDownPaneColorAngle.BackColor = System.Drawing.SystemColors.Window;
			this.numericUpDownPaneColorAngle.Location = new System.Drawing.Point(89, 72);
			System.Windows.Forms.NumericUpDown arg_F82_0 = this.numericUpDownPaneColorAngle;
			array = new int[4];
			array[0] = 360;
			arg_F82_0.Maximum = new decimal(array);
			this.numericUpDownPaneColorAngle.Name = "numericUpDownPaneColorAngle";
			this.numericUpDownPaneColorAngle.ReadOnly = true;
			this.numericUpDownPaneColorAngle.Size = new System.Drawing.Size(67, 26);
			this.numericUpDownPaneColorAngle.TabIndex = 15;
			this.numericUpDownPaneColorAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_FEE_0 = this.numericUpDownPaneColorAngle;
			array = new int[4];
			array[0] = 10;
			arg_FEE_0.Value = new decimal(array);
			this.buttonPaneColor1.Location = new System.Drawing.Point(125, 9);
			this.buttonPaneColor1.Name = "buttonPaneColor1";
			this.buttonPaneColor1.Size = new System.Drawing.Size(68, 26);
			this.buttonPaneColor1.TabIndex = 13;
			this.buttonPaneColor1.Text = "选择";
			this.buttonPaneColor1.UseVisualStyleBackColor = true;
			this.buttonPaneColor1.Click += new System.EventHandler(this.buttonPaneColor1_Click);
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(4, 13);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(60, 19);
			this.label6.TabIndex = 11;
			this.label6.Text = "颜色1：";
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(4, 74);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(79, 19);
			this.label8.TabIndex = 11;
			this.label8.Text = "变化角度：";
			this.buttonPaneColor2.Location = new System.Drawing.Point(125, 41);
			this.buttonPaneColor2.Name = "buttonPaneColor2";
			this.buttonPaneColor2.Size = new System.Drawing.Size(68, 26);
			this.buttonPaneColor2.TabIndex = 13;
			this.buttonPaneColor2.Text = "选择";
			this.buttonPaneColor2.UseVisualStyleBackColor = true;
			this.buttonPaneColor2.Click += new System.EventHandler(this.buttonPaneColor2_Click);
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(4, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(60, 19);
			this.label7.TabIndex = 11;
			this.label7.Text = "颜色2：";
			this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel5.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel5.Controls.Add(this.pictureBoxChartColor1);
			this.groupPanel5.Controls.Add(this.numericUpDownChartColorAngle);
			this.groupPanel5.Controls.Add(this.pictureBoxChartColor2);
			this.groupPanel5.Controls.Add(this.label12);
			this.groupPanel5.Controls.Add(this.label10);
			this.groupPanel5.Controls.Add(this.buttonChartColor2);
			this.groupPanel5.Controls.Add(this.buttonChartColor1);
			this.groupPanel5.Controls.Add(this.label9);
			this.groupPanel5.Location = new System.Drawing.Point(227, 12);
			this.groupPanel5.Name = "groupPanel5";
			this.groupPanel5.Size = new System.Drawing.Size(215, 140);
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
			this.groupPanel5.TabIndex = 27;
			this.groupPanel5.Text = "图表区域颜色";
			this.numericUpDownChartColorAngle.BackColor = System.Drawing.SystemColors.Window;
			this.numericUpDownChartColorAngle.Location = new System.Drawing.Point(88, 71);
			System.Windows.Forms.NumericUpDown arg_14E6_0 = this.numericUpDownChartColorAngle;
			array = new int[4];
			array[0] = 360;
			arg_14E6_0.Maximum = new decimal(array);
			this.numericUpDownChartColorAngle.Name = "numericUpDownChartColorAngle";
			this.numericUpDownChartColorAngle.ReadOnly = true;
			this.numericUpDownChartColorAngle.Size = new System.Drawing.Size(67, 26);
			this.numericUpDownChartColorAngle.TabIndex = 15;
			this.numericUpDownChartColorAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_1552_0 = this.numericUpDownChartColorAngle;
			array = new int[4];
			array[0] = 10;
			arg_1552_0.Value = new decimal(array);
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(10, 9);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(60, 19);
			this.label12.TabIndex = 11;
			this.label12.Text = "颜色1：";
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(10, 73);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(79, 19);
			this.label10.TabIndex = 11;
			this.label10.Text = "变化角度：";
			this.buttonChartColor2.Location = new System.Drawing.Point(133, 39);
			this.buttonChartColor2.Name = "buttonChartColor2";
			this.buttonChartColor2.Size = new System.Drawing.Size(68, 26);
			this.buttonChartColor2.TabIndex = 13;
			this.buttonChartColor2.Text = "选择";
			this.buttonChartColor2.UseVisualStyleBackColor = true;
			this.buttonChartColor2.Click += new System.EventHandler(this.buttonChartColor2_Click);
			this.buttonChartColor1.Location = new System.Drawing.Point(133, 7);
			this.buttonChartColor1.Name = "buttonChartColor1";
			this.buttonChartColor1.Size = new System.Drawing.Size(68, 26);
			this.buttonChartColor1.TabIndex = 13;
			this.buttonChartColor1.Text = "选择";
			this.buttonChartColor1.UseVisualStyleBackColor = true;
			this.buttonChartColor1.Click += new System.EventHandler(this.buttonChartColor1_Click);
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(10, 41);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(60, 19);
			this.label9.TabIndex = 11;
			this.label9.Text = "颜色2：";
			this.groupPanel6.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel6.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel6.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel6.Controls.Add(this.pictureBoxBarColor1);
			this.groupPanel6.Controls.Add(this.radioButtonBarValurPosCenter);
			this.groupPanel6.Controls.Add(this.radioButtonBarValurPosTop);
			this.groupPanel6.Controls.Add(this.label15);
			this.groupPanel6.Controls.Add(this.numericUpDownBarColorAngle);
			this.groupPanel6.Controls.Add(this.label14);
			this.groupPanel6.Controls.Add(this.pictureBoxBarColor2);
			this.groupPanel6.Controls.Add(this.buttonBarColor1);
			this.groupPanel6.Controls.Add(this.label13);
			this.groupPanel6.Controls.Add(this.checkBoxShowBarValue);
			this.groupPanel6.Controls.Add(this.label17);
			this.groupPanel6.Controls.Add(this.buttonBarColor2);
			this.groupPanel6.Location = new System.Drawing.Point(227, 158);
			this.groupPanel6.Name = "groupPanel6";
			this.groupPanel6.Size = new System.Drawing.Size(215, 186);
			this.groupPanel6.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanel6.Style.BackColorGradientAngle = 90;
			this.groupPanel6.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanel6.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanel6.Style.BorderBottomWidth = 1;
			this.groupPanel6.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanel6.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanel6.Style.BorderLeftWidth = 1;
			this.groupPanel6.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanel6.Style.BorderRightWidth = 1;
			this.groupPanel6.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanel6.Style.BorderTopWidth = 1;
			this.groupPanel6.Style.CornerDiameter = 4;
			this.groupPanel6.Style.CornerType = eCornerType.Rounded;
			this.groupPanel6.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel6.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel6.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel6.TabIndex = 27;
			this.groupPanel6.Text = "柱状图样式";
			this.radioButtonBarValurPosCenter.AutoSize = true;
			this.radioButtonBarValurPosCenter.Location = new System.Drawing.Point(133, 127);
			this.radioButtonBarValurPosCenter.Name = "radioButtonBarValurPosCenter";
			this.radioButtonBarValurPosCenter.Size = new System.Drawing.Size(55, 23);
			this.radioButtonBarValurPosCenter.TabIndex = 16;
			this.radioButtonBarValurPosCenter.TabStop = true;
			this.radioButtonBarValurPosCenter.Text = "中部";
			this.radioButtonBarValurPosCenter.UseVisualStyleBackColor = true;
			this.radioButtonBarValurPosTop.AutoSize = true;
			this.radioButtonBarValurPosTop.Checked = true;
			this.radioButtonBarValurPosTop.Location = new System.Drawing.Point(80, 127);
			this.radioButtonBarValurPosTop.Name = "radioButtonBarValurPosTop";
			this.radioButtonBarValurPosTop.Size = new System.Drawing.Size(55, 23);
			this.radioButtonBarValurPosTop.TabIndex = 16;
			this.radioButtonBarValurPosTop.TabStop = true;
			this.radioButtonBarValurPosTop.Text = "顶端";
			this.radioButtonBarValurPosTop.UseVisualStyleBackColor = true;
			this.label15.AutoSize = true;
			this.label15.Location = new System.Drawing.Point(10, 11);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(60, 19);
			this.label15.TabIndex = 11;
			this.label15.Text = "颜色1：";
			this.numericUpDownBarColorAngle.BackColor = System.Drawing.SystemColors.Window;
			this.numericUpDownBarColorAngle.Location = new System.Drawing.Point(88, 72);
			System.Windows.Forms.NumericUpDown arg_1C2A_0 = this.numericUpDownBarColorAngle;
			array = new int[4];
			array[0] = 360;
			arg_1C2A_0.Maximum = new decimal(array);
			this.numericUpDownBarColorAngle.Name = "numericUpDownBarColorAngle";
			this.numericUpDownBarColorAngle.ReadOnly = true;
			this.numericUpDownBarColorAngle.Size = new System.Drawing.Size(67, 26);
			this.numericUpDownBarColorAngle.TabIndex = 15;
			this.numericUpDownBarColorAngle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_1C96_0 = this.numericUpDownBarColorAngle;
			array = new int[4];
			array[0] = 10;
			arg_1C96_0.Value = new decimal(array);
			this.label14.AutoSize = true;
			this.label14.Location = new System.Drawing.Point(10, 74);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(79, 19);
			this.label14.TabIndex = 11;
			this.label14.Text = "变化角度：";
			this.buttonBarColor1.Location = new System.Drawing.Point(133, 8);
			this.buttonBarColor1.Name = "buttonBarColor1";
			this.buttonBarColor1.Size = new System.Drawing.Size(68, 26);
			this.buttonBarColor1.TabIndex = 13;
			this.buttonBarColor1.Text = "选择";
			this.buttonBarColor1.UseVisualStyleBackColor = true;
			this.buttonBarColor1.Click += new System.EventHandler(this.buttonBarColor1_Click);
			this.label13.AutoSize = true;
			this.label13.Location = new System.Drawing.Point(10, 43);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(60, 19);
			this.label13.TabIndex = 11;
			this.label13.Text = "颜色2：";
			this.checkBoxShowBarValue.AutoSize = true;
			this.checkBoxShowBarValue.Location = new System.Drawing.Point(14, 104);
			this.checkBoxShowBarValue.Name = "checkBoxShowBarValue";
			this.checkBoxShowBarValue.Size = new System.Drawing.Size(154, 23);
			this.checkBoxShowBarValue.TabIndex = 14;
			this.checkBoxShowBarValue.Text = "在柱状图上显示数值";
			this.checkBoxShowBarValue.UseVisualStyleBackColor = true;
			this.label17.AutoSize = true;
			this.label17.Location = new System.Drawing.Point(11, 129);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(79, 19);
			this.label17.TabIndex = 11;
			this.label17.Text = "数值位置：";
			this.buttonBarColor2.Location = new System.Drawing.Point(133, 40);
			this.buttonBarColor2.Name = "buttonBarColor2";
			this.buttonBarColor2.Size = new System.Drawing.Size(68, 26);
			this.buttonBarColor2.TabIndex = 13;
			this.buttonBarColor2.Text = "选择";
			this.buttonBarColor2.UseVisualStyleBackColor = true;
			this.buttonBarColor2.Click += new System.EventHandler(this.buttonBarColor2_Click);
			this.groupPanel7.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel7.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel7.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel7.Controls.Add(this.numericUpDownCurveWidth);
			this.groupPanel7.Controls.Add(this.pictureBoxCurveColor);
			this.groupPanel7.Controls.Add(this.label20);
			this.groupPanel7.Controls.Add(this.buttonCurveColor);
			this.groupPanel7.Controls.Add(this.label19);
			this.groupPanel7.Location = new System.Drawing.Point(227, 350);
			this.groupPanel7.Name = "groupPanel7";
			this.groupPanel7.Size = new System.Drawing.Size(215, 95);
			this.groupPanel7.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanel7.Style.BackColorGradientAngle = 90;
			this.groupPanel7.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanel7.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanel7.Style.BorderBottomWidth = 1;
			this.groupPanel7.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanel7.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanel7.Style.BorderLeftWidth = 1;
			this.groupPanel7.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanel7.Style.BorderRightWidth = 1;
			this.groupPanel7.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanel7.Style.BorderTopWidth = 1;
			this.groupPanel7.Style.CornerDiameter = 4;
			this.groupPanel7.Style.CornerType = eCornerType.Rounded;
			this.groupPanel7.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel7.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel7.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel7.TabIndex = 27;
			this.groupPanel7.Text = "数据曲线样式";
			this.numericUpDownCurveWidth.BackColor = System.Drawing.SystemColors.Window;
			this.numericUpDownCurveWidth.Location = new System.Drawing.Point(60, 32);
			System.Windows.Forms.NumericUpDown arg_21C8_0 = this.numericUpDownCurveWidth;
			array = new int[4];
			array[0] = 15;
			arg_21C8_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_21E5_0 = this.numericUpDownCurveWidth;
			array = new int[4];
			array[0] = 1;
			arg_21E5_0.Minimum = new decimal(array);
			this.numericUpDownCurveWidth.Name = "numericUpDownCurveWidth";
			this.numericUpDownCurveWidth.ReadOnly = true;
			this.numericUpDownCurveWidth.Size = new System.Drawing.Size(67, 26);
			this.numericUpDownCurveWidth.TabIndex = 15;
			this.numericUpDownCurveWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_2251_0 = this.numericUpDownCurveWidth;
			array = new int[4];
			array[0] = 10;
			arg_2251_0.Value = new decimal(array);
			this.label20.AutoSize = true;
			this.label20.Location = new System.Drawing.Point(11, 7);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(51, 19);
			this.label20.TabIndex = 11;
			this.label20.Text = "颜色：";
			this.buttonCurveColor.Location = new System.Drawing.Point(133, 3);
			this.buttonCurveColor.Name = "buttonCurveColor";
			this.buttonCurveColor.Size = new System.Drawing.Size(68, 26);
			this.buttonCurveColor.TabIndex = 13;
			this.buttonCurveColor.Text = "选择";
			this.buttonCurveColor.UseVisualStyleBackColor = true;
			this.buttonCurveColor.Click += new System.EventHandler(this.buttonCurveColor_Click);
			this.label19.AutoSize = true;
			this.label19.Location = new System.Drawing.Point(11, 33);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(51, 19);
			this.label19.TabIndex = 11;
			this.label19.Text = "粗细：";
			this.groupPanel8.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel8.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel8.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel8.Controls.Add(this.checkBoxMinorGridY);
			this.groupPanel8.Controls.Add(this.buttonGridColor);
			this.groupPanel8.Controls.Add(this.checkBoxMajorGridY);
			this.groupPanel8.Controls.Add(this.label16);
			this.groupPanel8.Controls.Add(this.checkBoxMinorGridX);
			this.groupPanel8.Controls.Add(this.pictureBoxGridColor);
			this.groupPanel8.Controls.Add(this.checkBoxMajorGridX);
			this.groupPanel8.Location = new System.Drawing.Point(448, 12);
			this.groupPanel8.Name = "groupPanel8";
			this.groupPanel8.Size = new System.Drawing.Size(234, 140);
			this.groupPanel8.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanel8.Style.BackColorGradientAngle = 90;
			this.groupPanel8.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanel8.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanel8.Style.BorderBottomWidth = 1;
			this.groupPanel8.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanel8.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanel8.Style.BorderLeftWidth = 1;
			this.groupPanel8.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanel8.Style.BorderRightWidth = 1;
			this.groupPanel8.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanel8.Style.BorderTopWidth = 1;
			this.groupPanel8.Style.CornerDiameter = 4;
			this.groupPanel8.Style.CornerType = eCornerType.Rounded;
			this.groupPanel8.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel8.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel8.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel8.TabIndex = 27;
			this.groupPanel8.Text = "标题文字";
			this.checkBoxMinorGridY.AutoSize = true;
			this.checkBoxMinorGridY.Location = new System.Drawing.Point(118, 71);
			this.checkBoxMinorGridY.Name = "checkBoxMinorGridY";
			this.checkBoxMinorGridY.Size = new System.Drawing.Size(107, 23);
			this.checkBoxMinorGridY.TabIndex = 14;
			this.checkBoxMinorGridY.Text = "Y轴辅网格线";
			this.checkBoxMinorGridY.UseVisualStyleBackColor = true;
			this.buttonGridColor.Location = new System.Drawing.Point(141, 8);
			this.buttonGridColor.Name = "buttonGridColor";
			this.buttonGridColor.Size = new System.Drawing.Size(68, 26);
			this.buttonGridColor.TabIndex = 13;
			this.buttonGridColor.Text = "选择";
			this.buttonGridColor.UseVisualStyleBackColor = true;
			this.buttonGridColor.Click += new System.EventHandler(this.buttonGridColor_Click);
			this.checkBoxMajorGridY.AutoSize = true;
			this.checkBoxMajorGridY.Location = new System.Drawing.Point(9, 72);
			this.checkBoxMajorGridY.Name = "checkBoxMajorGridY";
			this.checkBoxMajorGridY.Size = new System.Drawing.Size(107, 23);
			this.checkBoxMajorGridY.TabIndex = 14;
			this.checkBoxMajorGridY.Text = "Y轴主网格线";
			this.checkBoxMajorGridY.UseVisualStyleBackColor = true;
			this.label16.AutoSize = true;
			this.label16.Location = new System.Drawing.Point(14, 10);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(51, 19);
			this.label16.TabIndex = 11;
			this.label16.Text = "颜色：";
			this.checkBoxMinorGridX.AutoSize = true;
			this.checkBoxMinorGridX.Location = new System.Drawing.Point(118, 44);
			this.checkBoxMinorGridX.Name = "checkBoxMinorGridX";
			this.checkBoxMinorGridX.Size = new System.Drawing.Size(108, 23);
			this.checkBoxMinorGridX.TabIndex = 14;
			this.checkBoxMinorGridX.Text = "X轴辅网格线";
			this.checkBoxMinorGridX.UseVisualStyleBackColor = true;
			this.checkBoxMajorGridX.AutoSize = true;
			this.checkBoxMajorGridX.Location = new System.Drawing.Point(9, 44);
			this.checkBoxMajorGridX.Name = "checkBoxMajorGridX";
			this.checkBoxMajorGridX.Size = new System.Drawing.Size(108, 23);
			this.checkBoxMajorGridX.TabIndex = 14;
			this.checkBoxMajorGridX.Text = "X轴主网格线";
			this.checkBoxMajorGridX.UseVisualStyleBackColor = true;
			this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel1.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel1.Controls.Add(this.pictureBoxTitleFontColor);
			this.groupPanel1.Controls.Add(this.numericUpDownTitleFontSize);
			this.groupPanel1.Controls.Add(this.buttonTitleFontFamily);
			this.groupPanel1.Controls.Add(this.textBoxTitleFontFamily);
			this.groupPanel1.Controls.Add(this.label11);
			this.groupPanel1.Controls.Add(this.label2);
			this.groupPanel1.Controls.Add(this.label1);
			this.groupPanel1.Controls.Add(this.buttonTitleFontColor);
			this.groupPanel1.Location = new System.Drawing.Point(12, 12);
			this.groupPanel1.Name = "groupPanel1";
			this.groupPanel1.Size = new System.Drawing.Size(209, 140);
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
			this.groupPanel1.TabIndex = 27;
			this.groupPanel1.Text = "标题文字";
			this.numericUpDownTitleFontSize.BackColor = System.Drawing.SystemColors.Window;
			this.numericUpDownTitleFontSize.Location = new System.Drawing.Point(52, 70);
			System.Windows.Forms.NumericUpDown arg_2B83_0 = this.numericUpDownTitleFontSize;
			array = new int[4];
			array[0] = 10;
			arg_2B83_0.Minimum = new decimal(array);
			this.numericUpDownTitleFontSize.Name = "numericUpDownTitleFontSize";
			this.numericUpDownTitleFontSize.ReadOnly = true;
			this.numericUpDownTitleFontSize.Size = new System.Drawing.Size(67, 26);
			this.numericUpDownTitleFontSize.TabIndex = 15;
			this.numericUpDownTitleFontSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_2BEF_0 = this.numericUpDownTitleFontSize;
			array = new int[4];
			array[0] = 10;
			arg_2BEF_0.Value = new decimal(array);
			this.buttonTitleFontFamily.Location = new System.Drawing.Point(125, 8);
			this.buttonTitleFontFamily.Name = "buttonTitleFontFamily";
			this.buttonTitleFontFamily.Size = new System.Drawing.Size(68, 26);
			this.buttonTitleFontFamily.TabIndex = 13;
			this.buttonTitleFontFamily.Text = "选择";
			this.buttonTitleFontFamily.UseVisualStyleBackColor = true;
			this.buttonTitleFontFamily.Click += new System.EventHandler(this.buttonTitleFontFamily_Click);
			this.textBoxTitleFontFamily.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxTitleFontFamily.Location = new System.Drawing.Point(52, 8);
			this.textBoxTitleFontFamily.Name = "textBoxTitleFontFamily";
			this.textBoxTitleFontFamily.ReadOnly = true;
			this.textBoxTitleFontFamily.Size = new System.Drawing.Size(67, 26);
			this.textBoxTitleFontFamily.TabIndex = 14;
			this.textBoxTitleFontFamily.Text = "黑体";
			this.textBoxTitleFontFamily.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(4, 42);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(51, 19);
			this.label11.TabIndex = 11;
			this.label11.Text = "颜色：";
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(4, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 19);
			this.label2.TabIndex = 11;
			this.label2.Text = "大小：";
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(4, 10);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 19);
			this.label1.TabIndex = 11;
			this.label1.Text = "字体：";
			this.buttonTitleFontColor.Location = new System.Drawing.Point(125, 38);
			this.buttonTitleFontColor.Name = "buttonTitleFontColor";
			this.buttonTitleFontColor.Size = new System.Drawing.Size(68, 26);
			this.buttonTitleFontColor.TabIndex = 13;
			this.buttonTitleFontColor.Text = "选择";
			this.buttonTitleFontColor.UseVisualStyleBackColor = true;
			this.buttonTitleFontColor.Click += new System.EventHandler(this.buttonTitleFontColor_Click);
			this.buttonXSaveDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXSaveDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXSaveDefaultParams.Image = Resources.GroupMoveData;
			this.buttonXSaveDefaultParams.Location = new System.Drawing.Point(448, 321);
			this.buttonXSaveDefaultParams.Name = "buttonXSaveDefaultParams";
			this.buttonXSaveDefaultParams.Size = new System.Drawing.Size(233, 43);
			this.buttonXSaveDefaultParams.TabIndex = 37;
			this.buttonXSaveDefaultParams.Text = "保存为默认参数";
			this.buttonXSaveDefaultParams.Click += new System.EventHandler(this.buttonXSaveDefaultParams_Click);
			this.buttonXLoadDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXLoadDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXLoadDefaultParams.Image = Resources.GroupModify;
			this.buttonXLoadDefaultParams.Location = new System.Drawing.Point(448, 271);
			this.buttonXLoadDefaultParams.Name = "buttonXLoadDefaultParams";
			this.buttonXLoadDefaultParams.Size = new System.Drawing.Size(233, 43);
			this.buttonXLoadDefaultParams.TabIndex = 36;
			this.buttonXLoadDefaultParams.Text = "载入默认参数";
			this.buttonXLoadDefaultParams.Click += new System.EventHandler(this.buttonXLoadDefaultParams_Click);
			this.buttonXShowPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXShowPreview.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXShowPreview.Image = Resources.未标题_1;
			this.buttonXShowPreview.Location = new System.Drawing.Point(449, 457);
			this.buttonXShowPreview.Name = "buttonXShowPreview";
			this.buttonXShowPreview.Size = new System.Drawing.Size(233, 43);
			this.buttonXShowPreview.TabIndex = 27;
			this.buttonXShowPreview.Text = "显示效果";
			this.buttonXShowPreview.Visible = false;
			this.buttonXShowPreview.Click += new System.EventHandler(this.buttonXShowPreview_Click);
			this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonCancel.Image = Resources.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(449, 222);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(233, 43);
			this.buttonCancel.TabIndex = 27;
			this.buttonCancel.Text = "取\u3000消";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.pictureBoxAxisFontColor.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxAxisFontColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxAxisFontColor.Location = new System.Drawing.Point(52, 38);
			this.pictureBoxAxisFontColor.Name = "pictureBoxAxisFontColor";
			this.pictureBoxAxisFontColor.Size = new System.Drawing.Size(67, 26);
			this.pictureBoxAxisFontColor.TabIndex = 12;
			this.pictureBoxAxisFontColor.TabStop = false;
			this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonOK.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonOK.Image = Resources.OK;
			this.buttonOK.Location = new System.Drawing.Point(449, 170);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(233, 44);
			this.buttonOK.TabIndex = 26;
			this.buttonOK.Text = "确\u3000定";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.pictureBoxPaneColor1.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxPaneColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPaneColor1.Location = new System.Drawing.Point(55, 9);
			this.pictureBoxPaneColor1.Name = "pictureBoxPaneColor1";
			this.pictureBoxPaneColor1.Size = new System.Drawing.Size(64, 26);
			this.pictureBoxPaneColor1.TabIndex = 12;
			this.pictureBoxPaneColor1.TabStop = false;
			this.pictureBoxPaneColor2.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxPaneColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxPaneColor2.Location = new System.Drawing.Point(55, 41);
			this.pictureBoxPaneColor2.Name = "pictureBoxPaneColor2";
			this.pictureBoxPaneColor2.Size = new System.Drawing.Size(64, 26);
			this.pictureBoxPaneColor2.TabIndex = 12;
			this.pictureBoxPaneColor2.TabStop = false;
			this.pictureBoxChartColor1.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxChartColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxChartColor1.Location = new System.Drawing.Point(63, 7);
			this.pictureBoxChartColor1.Name = "pictureBoxChartColor1";
			this.pictureBoxChartColor1.Size = new System.Drawing.Size(64, 26);
			this.pictureBoxChartColor1.TabIndex = 12;
			this.pictureBoxChartColor1.TabStop = false;
			this.pictureBoxChartColor2.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxChartColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxChartColor2.Location = new System.Drawing.Point(63, 39);
			this.pictureBoxChartColor2.Name = "pictureBoxChartColor2";
			this.pictureBoxChartColor2.Size = new System.Drawing.Size(64, 26);
			this.pictureBoxChartColor2.TabIndex = 12;
			this.pictureBoxChartColor2.TabStop = false;
			this.pictureBoxBarColor1.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxBarColor1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxBarColor1.Location = new System.Drawing.Point(63, 8);
			this.pictureBoxBarColor1.Name = "pictureBoxBarColor1";
			this.pictureBoxBarColor1.Size = new System.Drawing.Size(64, 26);
			this.pictureBoxBarColor1.TabIndex = 12;
			this.pictureBoxBarColor1.TabStop = false;
			this.pictureBoxBarColor2.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxBarColor2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxBarColor2.Location = new System.Drawing.Point(63, 40);
			this.pictureBoxBarColor2.Name = "pictureBoxBarColor2";
			this.pictureBoxBarColor2.Size = new System.Drawing.Size(64, 26);
			this.pictureBoxBarColor2.TabIndex = 12;
			this.pictureBoxBarColor2.TabStop = false;
			this.pictureBoxCurveColor.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxCurveColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxCurveColor.Location = new System.Drawing.Point(60, 3);
			this.pictureBoxCurveColor.Name = "pictureBoxCurveColor";
			this.pictureBoxCurveColor.Size = new System.Drawing.Size(67, 26);
			this.pictureBoxCurveColor.TabIndex = 12;
			this.pictureBoxCurveColor.TabStop = false;
			this.pictureBoxGridColor.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxGridColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxGridColor.Location = new System.Drawing.Point(71, 8);
			this.pictureBoxGridColor.Name = "pictureBoxGridColor";
			this.pictureBoxGridColor.Size = new System.Drawing.Size(64, 26);
			this.pictureBoxGridColor.TabIndex = 12;
			this.pictureBoxGridColor.TabStop = false;
			this.pictureBoxTitleFontColor.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxTitleFontColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBoxTitleFontColor.Location = new System.Drawing.Point(52, 38);
			this.pictureBoxTitleFontColor.Name = "pictureBoxTitleFontColor";
			this.pictureBoxTitleFontColor.Size = new System.Drawing.Size(67, 26);
			this.pictureBoxTitleFontColor.TabIndex = 12;
			this.pictureBoxTitleFontColor.TabStop = false;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(697, 516);
			base.ControlBox = false;
			base.Controls.Add(this.ribbonClientPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "BarChartSettingForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "图表参数设置";
			this.ribbonClientPanel1.ResumeLayout(false);
			this.groupPanel3.ResumeLayout(false);
			this.groupPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownAxisFontSize).EndInit();
			this.groupPanel4.ResumeLayout(false);
			this.groupPanel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownPaneColorAngle).EndInit();
			this.groupPanel5.ResumeLayout(false);
			this.groupPanel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownChartColorAngle).EndInit();
			this.groupPanel6.ResumeLayout(false);
			this.groupPanel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownBarColorAngle).EndInit();
			this.groupPanel7.ResumeLayout(false);
			this.groupPanel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCurveWidth).EndInit();
			this.groupPanel8.ResumeLayout(false);
			this.groupPanel8.PerformLayout();
			this.groupPanel1.ResumeLayout(false);
			this.groupPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownTitleFontSize).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxAxisFontColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPaneColor1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPaneColor2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxChartColor1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxChartColor2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBarColor1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBarColor2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxCurveColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxGridColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxTitleFontColor).EndInit();
			base.ResumeLayout(false);
		}
	}
}
