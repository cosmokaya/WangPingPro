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
	public class ContourSettingForm : System.Windows.Forms.Form
	{
		public ContourParams m_ContourParams;

		private bool m_IsModify;

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.ComboBox comboBoxwColorManager;

		private System.Windows.Forms.Label label22;

		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.Button buttonDefaultColor;

		private System.Windows.Forms.PictureBox pictureBoxDefaultColor;

		private System.Windows.Forms.ColorDialog colorDialog;

		private System.Windows.Forms.ImageList imageList;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.NumericUpDown numericUpDownBaseValue;

		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.NumericUpDown numericUpDownStepValue;

		private System.Windows.Forms.CheckBox checkBoxShowVertex;

		private System.Windows.Forms.CheckBox checkBoxShowTriangle;

		private System.Windows.Forms.ComboBox comboBoxLineStyle;

		private System.Windows.Forms.NumericUpDown numericUpDownLineWidth;

		private System.Windows.Forms.Label label13;

		private System.Windows.Forms.Label label14;

		private System.Windows.Forms.CheckBox checkBoxFillRegion;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.ComboBox comboBoxFillwColorManager;

		private System.Windows.Forms.Label label7;

		private System.Windows.Forms.Label labelFillAlpha;

		private RibbonClientPanel ribbonClientPanel1;

		private GroupPanel groupPanelSearchType2;

		private GroupPanel groupPanelContourStyle;

		private GroupPanel groupPanelContourFill;

		private Slider trackBarFillAlpha;

		private GroupPanel groupPanelValue;

		private ButtonX buttonCancel;

		private ButtonX buttonOK;

		private TextBoxX textBoxXFilePath;

		private System.Windows.Forms.CheckBox checkBoxShowContour;

		private System.Windows.Forms.CheckBox checkBoxWantSPL;

		private System.Windows.Forms.CheckBox checkBoxShowText;

		private GroupPanel groupPanelColorRange;

		private System.Windows.Forms.PictureBox pictureBoxColorBarLine;

		private Slider sliderMaxColorID;

		private Slider sliderMinColorID;

		private System.Windows.Forms.NumericUpDown numericUpDownMinValue;

		private System.Windows.Forms.NumericUpDown numericUpDownMaxValue;

		private System.Windows.Forms.NumericUpDown numericUpDownTextStep;

		private System.Windows.Forms.Label label9;

		private System.Windows.Forms.CheckBox checkBoxShowArrow;

		private System.Windows.Forms.PictureBox pictureBoxColorBarFill;

		private System.Windows.Forms.Label label11;

		private System.Windows.Forms.CheckBox checkBoxUseSpecifiedMinValue;

		private System.Windows.Forms.NumericUpDown numericUpDownFontHeight;

		private System.Windows.Forms.Label label15;

		private System.Windows.Forms.TextBox textBoxValueUnit;

		private System.Windows.Forms.TextBox textBoxValueFormat;

		private System.Windows.Forms.Label label17;

		private System.Windows.Forms.Label labelTextFormatPreview;

		private System.Windows.Forms.Label label16;

		private ButtonX buttonXSaveDefaultParams;

		private ButtonX buttonXLoadDefaultParams;

		private GroupPanel groupPanelSearchType1;

		private ButtonX buttonXClearValue;

		private System.Windows.Forms.ListView listViewColorItem;

		private System.Windows.Forms.ColumnHeader columnHeader1;

		private System.Windows.Forms.ColumnHeader columnHeader2;

		private ButtonX buttonX3DeleteValue;

		private ButtonX buttonXAddValue;

		private ButtonX buttonXModifyValue;

		private System.Windows.Forms.NumericUpDown numericUpDownContourValue;

		private System.Windows.Forms.Label label19;

		private System.Windows.Forms.Button buttonChoseContourCurveColor;

		private System.Windows.Forms.Label label20;

		private System.Windows.Forms.PictureBox pictureBoxContourCurveColor;

		private System.Windows.Forms.RadioButton radioButtonSearchType2;

		private System.Windows.Forms.RadioButton radioButtonSearchType1;

		private System.Windows.Forms.Button buttonChoseContourFillColor;

		private System.Windows.Forms.Label label21;

		private System.Windows.Forms.PictureBox pictureBoxContourFillColor;

		private System.Windows.Forms.Label label23;

		private System.Windows.Forms.TextBox textBoxContourValueText;

		private System.Windows.Forms.RadioButton radioButtonSearchType3;

		private System.Windows.Forms.NumericUpDown numericUpDownSearchCount;

		private System.Windows.Forms.ColumnHeader columnHeader3;

		private System.Windows.Forms.Label label24;

		private System.Windows.Forms.CheckBox checkBoxShowUnitInColorBar;

		private System.Windows.Forms.CheckBox checkBoxShowUnitInCurve;

		private System.Windows.Forms.Label label26;

		private System.Windows.Forms.CheckBox checkBoxUseSpecifiedMaxValue;

		private System.Windows.Forms.CheckBox checkBoxTextRotate;

		private System.Windows.Forms.CheckBox checkBoxTextBold;

		private System.Windows.Forms.CheckBox checkBoxTextColor;

		private System.Windows.Forms.ComboBox comboBoxCoutourLineStyle;

		private System.Windows.Forms.NumericUpDown numericUpDownCounterLineWidth;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.ColumnHeader columnHeader4;

		private System.Windows.Forms.ColumnHeader columnHeader5;

		public bool IsModify
		{
			get
			{
				return this.m_IsModify;
			}
			set
			{
				this.m_IsModify = value;
				this.numericUpDownBaseValue.Enabled = !this.m_IsModify;
				this.numericUpDownStepValue.Enabled = !this.m_IsModify;
				this.buttonCancel.Enabled = this.m_IsModify;
			}
		}

		public ColorManager ContourLineColorManager
		{
			get
			{
				return this.m_ContourParams.m_ContourLineColorManager;
			}
		}

		public ColorManager ContourFillColorManager
		{
			get
			{
				return this.m_ContourParams.m_ContourFillColorManager;
			}
		}

		public int SearchType
		{
			get
			{
				int result;
				if (this.radioButtonSearchType1.Checked)
				{
					result = 1;
				}
				else if (this.radioButtonSearchType2.Checked)
				{
					result = 2;
				}
				else
				{
					result = 3;
				}
				return result;
			}
			set
			{
				this.radioButtonSearchType1.Checked = (value == 1);
				this.radioButtonSearchType2.Checked = (value == 2);
				this.radioButtonSearchType3.Checked = (value == 3);
			}
		}

		public int SearchCount
		{
			get
			{
				return (int)this.numericUpDownSearchCount.Value;
			}
			set
			{
				this.numericUpDownSearchCount.Value = value;
			}
		}

		public bool UseSpecifiedMinValue
		{
			get
			{
				return this.checkBoxUseSpecifiedMinValue.Checked;
			}
			set
			{
				this.checkBoxUseSpecifiedMinValue.Checked = value;
			}
		}

		public bool UseSpecifiedMaxValue
		{
			get
			{
				return this.checkBoxUseSpecifiedMaxValue.Checked;
			}
			set
			{
				this.checkBoxUseSpecifiedMaxValue.Checked = value;
			}
		}

		public float MinValue
		{
			get
			{
				return (float)this.numericUpDownMinValue.Value;
			}
			set
			{
				this.numericUpDownMinValue.Value = (decimal)value;
			}
		}

		public float MaxValue
		{
			get
			{
				return (float)this.numericUpDownMaxValue.Value;
			}
			set
			{
				this.numericUpDownMaxValue.Value = (decimal)value;
			}
		}

		public float BaseValue
		{
			get
			{
				return System.Convert.ToSingle(this.numericUpDownBaseValue.Value);
			}
			set
			{
				this.numericUpDownBaseValue.Value = (decimal)value;
			}
		}

		public float StepValue
		{
			get
			{
				return System.Convert.ToSingle(this.numericUpDownStepValue.Value);
			}
			set
			{
				this.numericUpDownStepValue.Value = (decimal)value;
			}
		}

		public int LineWidth
		{
			get
			{
				return System.Convert.ToInt32(this.numericUpDownLineWidth.Value);
			}
			set
			{
				this.numericUpDownLineWidth.Value = value;
			}
		}

		public System.Drawing.Drawing2D.DashStyle LineStyle
		{
			get
			{
				return this.IntToDashStyle(this.comboBoxLineStyle.SelectedIndex);
			}
			set
			{
				this.comboBoxLineStyle.SelectedIndex = this.DashStyleToInt(value);
			}
		}

		public int LinewColorManagerID
		{
			get
			{
				return this.comboBoxwColorManager.SelectedIndex;
			}
			set
			{
				this.comboBoxwColorManager.SelectedIndex = value;
			}
		}

		public System.Drawing.Color DefaultColor
		{
			get
			{
				return this.pictureBoxDefaultColor.BackColor;
			}
			set
			{
				this.pictureBoxDefaultColor.BackColor = value;
			}
		}

		public bool ShowContour
		{
			get
			{
				return this.checkBoxShowContour.Checked;
			}
			set
			{
				this.checkBoxShowContour.Checked = value;
			}
		}

		public bool ShowContourText
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

		public bool ShowUnitInCurve
		{
			get
			{
				return this.checkBoxShowUnitInCurve.Checked;
			}
			set
			{
				this.checkBoxShowUnitInCurve.Checked = value;
			}
		}

		public bool ShowUnitInColorBar
		{
			get
			{
				return this.checkBoxShowUnitInColorBar.Checked;
			}
			set
			{
				this.checkBoxShowUnitInColorBar.Checked = value;
			}
		}

		public int TextStep
		{
			get
			{
				return (int)this.numericUpDownTextStep.Value;
			}
			set
			{
				this.numericUpDownTextStep.Value = value;
			}
		}

		public int TextHeight
		{
			get
			{
				return (int)this.numericUpDownFontHeight.Value;
			}
			set
			{
				this.numericUpDownFontHeight.Value = value;
			}
		}

		public bool TextBold
		{
			get
			{
				return this.checkBoxTextBold.Checked;
			}
			set
			{
				this.checkBoxTextBold.Checked = value;
			}
		}

		public bool TextRotate
		{
			get
			{
				return this.checkBoxTextRotate.Checked;
			}
			set
			{
				this.checkBoxTextRotate.Checked = value;
			}
		}

		public bool TextColor
		{
			get
			{
				return this.checkBoxTextColor.Checked;
			}
			set
			{
				this.checkBoxTextColor.Checked = value;
			}
		}

		public bool WantSPL
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

		public bool FillRegion
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

		public int FillwColorManagerID
		{
			get
			{
				return this.comboBoxFillwColorManager.SelectedIndex + 1;
			}
			set
			{
				this.comboBoxFillwColorManager.SelectedIndex = value - 1;
			}
		}

		public int FillAlpha
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

		public bool ShowVertex
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

		public bool ShowTriangle
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

		public bool ShowArrow
		{
			get
			{
				return this.checkBoxShowArrow.Checked;
			}
			set
			{
				this.checkBoxShowArrow.Checked = value;
			}
		}

		public int MinColorID
		{
			get
			{
				return this.sliderMinColorID.Value;
			}
			set
			{
				this.sliderMinColorID.Value = value;
			}
		}

		public int MaxColorID
		{
			get
			{
				return this.sliderMaxColorID.Value;
			}
			set
			{
				this.sliderMaxColorID.Value = value;
			}
		}

		public string ValueFormat
		{
			get
			{
				return this.textBoxValueFormat.Text;
			}
			set
			{
				this.textBoxValueFormat.Text = value;
			}
		}

		public string ValueUnit
		{
			get
			{
				return this.textBoxValueUnit.Text;
			}
			set
			{
				this.textBoxValueUnit.Text = value;
			}
		}

		public ContourSettingForm()
		{
			this.InitializeComponent();
			this.m_ContourParams = new ContourParams();
			this.m_ContourParams.LoadParams();
			this.LoadContourParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_ContourParams.ParamFilePath;
		}

		public ContourSettingForm(ContourParams contourParams)
		{
			this.InitializeComponent();
			this.m_ContourParams = contourParams;
			if (this.m_ContourParams == null)
			{
				System.Windows.Forms.MessageBox.Show("传入等值线参数为空！使用默认参数……", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_ContourParams = new ContourParams();
				this.m_ContourParams.LoadParams();
			}
			this.LoadContourParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_ContourParams.ParamFilePath;
		}

		private void ContourSettingForm_Load(object sender, System.EventArgs e)
		{
			this.Text = System.IO.Path.GetFileNameWithoutExtension(this.m_ContourParams.ParamFilePath) + " 等值线参数设置";
		}

		private void buttonDefaultColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxDefaultColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxDefaultColor.BackColor = this.colorDialog.Color;
				this.ShowColorBar();
			}
		}

		private void comboBoxwColorManager_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.comboBoxwColorManager.SelectedIndex != 0)
			{
				this.comboBoxFillwColorManager.SelectedIndex = this.comboBoxwColorManager.SelectedIndex - 1;
			}
			this.ShowColorBar();
		}

		private void comboBoxFillwColorManager_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.comboBoxwColorManager.SelectedIndex != 0)
			{
				this.comboBoxwColorManager.SelectedIndex = this.comboBoxFillwColorManager.SelectedIndex + 1;
			}
			this.ShowColorBar();
		}

		private void trackBarFillAlpha_ValueChanged(object sender, System.EventArgs e)
		{
			this.labelFillAlpha.Text = this.trackBarFillAlpha.Value.ToString();
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.ApplyContourParams();
			if (this.m_ContourParams.SaveParams())
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

		private void buttonXLoadDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.m_ContourParams.LoadDefaultParams())
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				this.LoadContourParams();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
		}

		private void buttonXSaveDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.ApplyContourParams())
			{
				if (this.m_ContourParams.SaveDefaultParams())
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
			}
		}

		private void checkBoxUseSpecifiedMinMaxValue_CheckedChanged(object sender, System.EventArgs e)
		{
			this.numericUpDownMinValue.Enabled = this.checkBoxUseSpecifiedMinValue.Checked;
			this.numericUpDownMaxValue.Enabled = this.checkBoxUseSpecifiedMaxValue.Checked;
		}

		private void radioButtonSearchType1_CheckedChanged(object sender, System.EventArgs e)
		{
			this.groupPanelSearchType1.Enabled = this.radioButtonSearchType1.Checked;
			this.groupPanelSearchType2.Enabled = this.radioButtonSearchType2.Checked;
			this.numericUpDownBaseValue.Enabled = this.radioButtonSearchType2.Checked;
			this.numericUpDownStepValue.Enabled = this.radioButtonSearchType2.Checked;
			this.numericUpDownSearchCount.Enabled = this.radioButtonSearchType3.Checked;
		}

		private void listViewColorItem_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.listViewColorItem.SelectedItems != null && this.listViewColorItem.SelectedItems.Count != 0)
			{
				System.Windows.Forms.ListViewItem selectedItem = this.listViewColorItem.SelectedItems[0];
				this.numericUpDownContourValue.Value = (decimal)System.Convert.ToSingle(selectedItem.SubItems[1].Text);
				this.textBoxContourValueText.Text = selectedItem.SubItems[2].Text;
				this.pictureBoxContourCurveColor.BackColor = (System.Drawing.Color)selectedItem.SubItems[0].Tag;
				this.pictureBoxContourFillColor.BackColor = (System.Drawing.Color)selectedItem.SubItems[1].Tag;
				this.numericUpDownCounterLineWidth.Value = System.Convert.ToInt32(selectedItem.SubItems[3].Text);
				this.comboBoxCoutourLineStyle.SelectedIndex = System.Convert.ToInt32(selectedItem.SubItems[4].Text);
			}
		}

		private void buttonXAddColor_Click(object sender, System.EventArgs e)
		{
			if (this.listViewColorItem.Enabled)
			{
				this.listViewColorItem.Enabled = false;
				this.buttonXAddValue.Text = "完\u3000成";
				this.numericUpDownContourValue.Value = 0m;
				this.textBoxContourValueText.Text = "0";
				this.numericUpDownCounterLineWidth.Value = 1m;
				this.comboBoxCoutourLineStyle.SelectedIndex = 4;
			}
			else
			{
				this.listViewColorItem.Enabled = true;
				this.buttonXAddValue.Text = "添\u3000加";
				System.Windows.Forms.ListViewItem newItem = this.listViewColorItem.Items.Add(System.Convert.ToString(this.listViewColorItem.Items.Count + 1));
				newItem.SubItems.Add(this.numericUpDownContourValue.Value.ToString("F2"));
				newItem.SubItems.Add(this.textBoxContourValueText.Text);
				newItem.SubItems.Add(this.numericUpDownCounterLineWidth.Value.ToString());
				newItem.SubItems.Add(this.comboBoxCoutourLineStyle.SelectedIndex.ToString());
				newItem.SubItems[0].Tag = this.pictureBoxContourCurveColor.BackColor;
				newItem.SubItems[1].Tag = this.pictureBoxContourFillColor.BackColor;
			}
			this.buttonXModifyValue.Enabled = this.listViewColorItem.Enabled;
			this.buttonX3DeleteValue.Enabled = this.listViewColorItem.Enabled;
			this.buttonXClearValue.Enabled = this.listViewColorItem.Enabled;
			this.buttonOK.Enabled = this.listViewColorItem.Enabled;
			this.buttonCancel.Enabled = this.listViewColorItem.Enabled;
			this.buttonXLoadDefaultParams.Enabled = this.listViewColorItem.Enabled;
			this.buttonXSaveDefaultParams.Enabled = this.listViewColorItem.Enabled;
			this.buttonChoseContourCurveColor.Enabled = !this.listViewColorItem.Enabled;
			this.buttonChoseContourFillColor.Enabled = !this.listViewColorItem.Enabled;
			this.numericUpDownContourValue.Enabled = !this.listViewColorItem.Enabled;
			this.numericUpDownCounterLineWidth.Enabled = !this.listViewColorItem.Enabled;
			this.textBoxContourValueText.Enabled = !this.listViewColorItem.Enabled;
			this.comboBoxCoutourLineStyle.Enabled = !this.listViewColorItem.Enabled;
			this.groupPanelContourStyle.Enabled = this.listViewColorItem.Enabled;
			this.groupPanelContourFill.Enabled = this.listViewColorItem.Enabled;
			this.groupPanelColorRange.Enabled = this.listViewColorItem.Enabled;
			this.groupPanelValue.Enabled = this.listViewColorItem.Enabled;
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
					this.buttonXModifyValue.Text = "完\u3000成";
				}
				else
				{
					this.listViewColorItem.Enabled = true;
					this.buttonXModifyValue.Text = "修\u3000改";
					System.Windows.Forms.ListViewItem selectedItem = this.listViewColorItem.SelectedItems[0];
					selectedItem.SubItems[1].Text = this.numericUpDownContourValue.Value.ToString();
					selectedItem.SubItems[2].Text = this.textBoxContourValueText.Text;
					selectedItem.SubItems[3].Text = this.numericUpDownCounterLineWidth.Value.ToString();
					selectedItem.SubItems[4].Text = this.comboBoxCoutourLineStyle.SelectedIndex.ToString();
					selectedItem.SubItems[0].Tag = this.pictureBoxContourCurveColor.BackColor;
					selectedItem.SubItems[1].Tag = this.pictureBoxContourFillColor.BackColor;
				}
				this.buttonXAddValue.Enabled = this.listViewColorItem.Enabled;
				this.buttonX3DeleteValue.Enabled = this.listViewColorItem.Enabled;
				this.buttonXClearValue.Enabled = this.listViewColorItem.Enabled;
				this.buttonOK.Enabled = this.listViewColorItem.Enabled;
				this.buttonCancel.Enabled = this.listViewColorItem.Enabled;
				this.buttonXLoadDefaultParams.Enabled = this.listViewColorItem.Enabled;
				this.buttonXSaveDefaultParams.Enabled = this.listViewColorItem.Enabled;
				this.buttonChoseContourCurveColor.Enabled = !this.listViewColorItem.Enabled;
				this.buttonChoseContourFillColor.Enabled = !this.listViewColorItem.Enabled;
				this.numericUpDownContourValue.Enabled = !this.listViewColorItem.Enabled;
				this.numericUpDownCounterLineWidth.Enabled = !this.listViewColorItem.Enabled;
				this.textBoxContourValueText.Enabled = !this.listViewColorItem.Enabled;
				this.comboBoxCoutourLineStyle.Enabled = !this.listViewColorItem.Enabled;
				this.groupPanelContourStyle.Enabled = this.listViewColorItem.Enabled;
				this.groupPanelContourFill.Enabled = this.listViewColorItem.Enabled;
				this.groupPanelColorRange.Enabled = this.listViewColorItem.Enabled;
				this.groupPanelValue.Enabled = this.listViewColorItem.Enabled;
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

		private void buttonChoseContourCurveColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxContourCurveColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxContourCurveColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonChoseContourFillColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxContourFillColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxContourFillColor.BackColor = this.colorDialog.Color;
			}
		}

		private int DashStyleToInt(System.Drawing.Drawing2D.DashStyle thisDashStyle)
		{
			int result;
			if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.Dash)
			{
				result = 0;
			}
			else if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.DashDot)
			{
				result = 1;
			}
			else if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.DashDotDot)
			{
				result = 2;
			}
			else if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.Dot)
			{
				result = 3;
			}
			else if (thisDashStyle == System.Drawing.Drawing2D.DashStyle.Solid)
			{
				result = 4;
			}
			else
			{
				result = -1;
			}
			return result;
		}

		private System.Drawing.Drawing2D.DashStyle IntToDashStyle(int thisDashStyle)
		{
			System.Drawing.Drawing2D.DashStyle result;
			if (thisDashStyle == 0)
			{
				result = System.Drawing.Drawing2D.DashStyle.Dash;
			}
			else if (thisDashStyle == 1)
			{
				result = System.Drawing.Drawing2D.DashStyle.DashDot;
			}
			else if (thisDashStyle == 2)
			{
				result = System.Drawing.Drawing2D.DashStyle.DashDotDot;
			}
			else if (thisDashStyle == 3)
			{
				result = System.Drawing.Drawing2D.DashStyle.Dot;
			}
			else if (thisDashStyle == 4)
			{
				result = System.Drawing.Drawing2D.DashStyle.Solid;
			}
			else
			{
				result = System.Drawing.Drawing2D.DashStyle.Custom;
			}
			return result;
		}

		private void ShowColorBar()
		{
			System.Drawing.Bitmap barBitmap = new System.Drawing.Bitmap(this.pictureBoxColorBarLine.Width, this.pictureBoxColorBarLine.Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(barBitmap);
			ColorTable ct = new ColorTable(this.LinewColorManagerID, this.DefaultColor);
			for (int i = 0; i < barBitmap.Width; i++)
			{
				int j = System.Convert.ToInt32(255.0 * (double)i / (double)barBitmap.Width);
				System.Drawing.Pen thisPen = new System.Drawing.Pen(ct.GetColor(j), 1f);
				g.DrawLine(thisPen, new System.Drawing.Point(i, 0), new System.Drawing.Point(i, barBitmap.Height));
			}
			this.pictureBoxColorBarLine.Image = barBitmap;
			barBitmap = new System.Drawing.Bitmap(this.pictureBoxColorBarFill.Width, this.pictureBoxColorBarFill.Height);
			g = System.Drawing.Graphics.FromImage(barBitmap);
			ct = new ColorTable(this.FillwColorManagerID, this.DefaultColor);
			for (int i = 0; i < barBitmap.Width; i++)
			{
				int j = System.Convert.ToInt32(255.0 * (double)i / (double)barBitmap.Width);
				System.Drawing.Pen thisPen = new System.Drawing.Pen(ct.GetColor(j), 1f);
				g.DrawLine(thisPen, new System.Drawing.Point(i, 0), new System.Drawing.Point(i, barBitmap.Height));
			}
			this.pictureBoxColorBarFill.Image = barBitmap;
		}

		private void LoadContourParams()
		{
			this.SearchType = this.m_ContourParams.ContourSearchType;
			this.SearchCount = this.m_ContourParams.ContourSearchCount;
			this.BaseValue = this.m_ContourParams.ContourBaseValue;
			this.StepValue = this.m_ContourParams.ContourStepValue;
			this.MinValue = this.m_ContourParams.ContourMinValue;
			this.MaxValue = this.m_ContourParams.ContourMaxValue;
			this.UseSpecifiedMinValue = this.m_ContourParams.ContourUseSpcifiedMinValue;
			this.UseSpecifiedMaxValue = this.m_ContourParams.ContourUseSpcifiedMaxValue;
			this.LineWidth = this.m_ContourParams.ContourLineWidth;
			this.LineStyle = this.m_ContourParams.ContourLineStyle;
			this.DefaultColor = this.m_ContourParams.ContourDefaultColor;
			this.ShowContour = this.m_ContourParams.ContourShowContour;
			this.ShowContourText = this.m_ContourParams.ContourShowContourText;
			this.ShowUnitInCurve = this.m_ContourParams.ContourShowUnitInCurve;
			this.ShowUnitInColorBar = this.m_ContourParams.ContourShowUnitInColorBar;
			this.TextStep = this.m_ContourParams.ContourTextStep;
			this.TextHeight = this.m_ContourParams.ContourTextHeight;
			this.TextBold = this.m_ContourParams.ContourTextBold;
			this.TextRotate = this.m_ContourParams.ContourTextRotate;
			this.TextColor = this.m_ContourParams.ContourTextColor;
			this.WantSPL = this.m_ContourParams.ContourWantSPL;
			this.MinColorID = this.m_ContourParams.ContourMinColorID;
			this.MaxColorID = this.m_ContourParams.ContourMaxColorID;
			this.FillRegion = this.m_ContourParams.ContourWantFill;
			this.FillAlpha = this.m_ContourParams.ContourFillAlpha;
			this.ShowTriangle = this.m_ContourParams.ContourWantTriangle;
			this.ShowVertex = this.m_ContourParams.ContourWantVertex;
			this.ShowArrow = this.m_ContourParams.ContourShowArrow;
			this.LinewColorManagerID = this.m_ContourParams.ContourwColorManager;
			this.FillwColorManagerID = this.m_ContourParams.ContourFillwColorManager;
			this.ValueFormat = this.m_ContourParams.ContourValueFormat;
			this.ValueUnit = this.m_ContourParams.ContourValueUnit;
			this.ShowColorItems();
		}

		private bool ApplyContourParams()
		{
			this.m_ContourParams.ContourSearchType = this.SearchType;
			this.m_ContourParams.ContourSearchCount = this.SearchCount;
			this.m_ContourParams.ContourBaseValue = this.BaseValue;
			this.m_ContourParams.ContourStepValue = this.StepValue;
			this.m_ContourParams.ContourMinValue = this.MinValue;
			this.m_ContourParams.ContourMaxValue = this.MaxValue;
			this.m_ContourParams.ContourUseSpcifiedMinValue = this.UseSpecifiedMinValue;
			this.m_ContourParams.ContourUseSpcifiedMaxValue = this.UseSpecifiedMaxValue;
			this.m_ContourParams.ContourLineWidth = this.LineWidth;
			this.m_ContourParams.ContourLineStyle = this.LineStyle;
			this.m_ContourParams.ContourwColorManager = this.LinewColorManagerID;
			this.m_ContourParams.ContourDefaultColor = this.DefaultColor;
			this.m_ContourParams.ContourShowContour = this.ShowContour;
			this.m_ContourParams.ContourShowContourText = this.ShowContourText;
			this.m_ContourParams.ContourShowUnitInCurve = this.ShowUnitInCurve;
			this.m_ContourParams.ContourShowUnitInColorBar = this.ShowUnitInColorBar;
			this.m_ContourParams.ContourTextStep = this.TextStep;
			this.m_ContourParams.ContourTextBold = this.TextBold;
			this.m_ContourParams.ContourTextRotate = this.TextRotate;
			this.m_ContourParams.ContourTextHeight = this.TextHeight;
			this.m_ContourParams.ContourTextColor = this.TextColor;
			this.m_ContourParams.ContourWantSPL = this.WantSPL;
			this.m_ContourParams.ContourMinColorID = this.MinColorID;
			this.m_ContourParams.ContourMaxColorID = this.MaxColorID;
			this.m_ContourParams.ContourWantFill = this.FillRegion;
			this.m_ContourParams.ContourFillwColorManager = this.FillwColorManagerID;
			this.m_ContourParams.ContourFillAlpha = this.FillAlpha;
			this.m_ContourParams.ContourWantTriangle = this.ShowTriangle;
			this.m_ContourParams.ContourWantVertex = this.ShowVertex;
			this.m_ContourParams.ContourShowArrow = this.ShowArrow;
			this.m_ContourParams.ContourValueFormat = this.ValueFormat;
			this.m_ContourParams.ContourValueUnit = this.ValueUnit;
			this.ApplyColorItems();
			return true;
		}

		private void ShowColorItems()
		{
			this.listViewColorItem.Items.Clear();
			for (int i = 0; i < this.ContourLineColorManager.m_ColorItems.Count; i++)
			{
				System.Windows.Forms.ListViewItem newItem = this.listViewColorItem.Items.Add(System.Convert.ToString(i + 1));
				newItem.SubItems.Add(this.ContourLineColorManager.m_ColorItems[i].myValue.ToString());
				newItem.SubItems.Add(this.ContourLineColorManager.m_ColorItems[i].myValueText);
				newItem.SubItems.Add(this.ContourLineColorManager.m_ColorItems[i].myLineWidth.ToString());
				newItem.SubItems.Add(this.DashStyleToInt(this.ContourLineColorManager.m_ColorItems[i].myDashStyle).ToString());
				newItem.SubItems[0].Tag = this.ContourLineColorManager.m_ColorItems[i].myColor;
				newItem.SubItems[1].Tag = this.ContourFillColorManager.m_ColorItems[i].myColor;
			}
			if (this.listViewColorItem.Items.Count != 0)
			{
				this.listViewColorItem.Items[0].Selected = true;
			}
		}

		private void ApplyColorItems()
		{
			this.ContourLineColorManager.m_ColorItems.Clear();
			this.ContourFillColorManager.m_ColorItems.Clear();
			for (int i = 0; i < this.listViewColorItem.Items.Count; i++)
			{
				float Value = System.Convert.ToSingle(this.listViewColorItem.Items[i].SubItems[1].Text);
				string RegionName = this.listViewColorItem.Items[i].SubItems[2].Text;
				System.Drawing.Color curveColor = (System.Drawing.Color)this.listViewColorItem.Items[i].SubItems[0].Tag;
				System.Drawing.Color fillColor = (System.Drawing.Color)this.listViewColorItem.Items[i].SubItems[1].Tag;
				int curveWidth = System.Convert.ToInt32(this.listViewColorItem.Items[i].SubItems[3].Text);
				System.Drawing.Drawing2D.DashStyle curveStyle = this.IntToDashStyle(System.Convert.ToInt32(this.listViewColorItem.Items[i].SubItems[4].Text));
				wMetroGIS.wColorManager.ColorItem curveItem = new wMetroGIS.wColorManager.ColorItem(curveColor, Value, RegionName);
				wMetroGIS.wColorManager.ColorItem fillItem = new wMetroGIS.wColorManager.ColorItem(fillColor, Value, RegionName);
				curveItem.myLineWidth = curveWidth;
				curveItem.myDashStyle = curveStyle;
				fillItem.myLineWidth = curveWidth;
				fillItem.myDashStyle = curveStyle;
				this.ContourLineColorManager.m_ColorItems.Add(curveItem);
				this.ContourFillColorManager.m_ColorItems.Add(fillItem);
			}
		}

		private void checkBoxShowText_CheckedChanged(object sender, System.EventArgs e)
		{
			if (!this.checkBoxShowText.Checked)
			{
				this.checkBoxShowUnitInCurve.Checked = false;
			}
		}

		private void textBoxValueFormat_TextChanged(object sender, System.EventArgs e)
		{
			if (this.textBoxValueFormat.Text == "")
			{
				this.textBoxValueFormat.Text = "0";
			}
			try
			{
				string format = "{0:" + this.textBoxValueFormat.Text + "}" + this.textBoxValueUnit.Text;
				this.labelTextFormatPreview.Text = string.Format("123.45显示为" + format, 123.45);
			}
			catch
			{
				this.labelTextFormatPreview.Text = "格式设置错误！";
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContourSettingForm));
			this.comboBoxwColorManager = new System.Windows.Forms.ComboBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonDefaultColor = new System.Windows.Forms.Button();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.label3 = new System.Windows.Forms.Label();
			this.numericUpDownBaseValue = new System.Windows.Forms.NumericUpDown();
			this.label4 = new System.Windows.Forms.Label();
			this.numericUpDownStepValue = new System.Windows.Forms.NumericUpDown();
			this.checkBoxShowVertex = new System.Windows.Forms.CheckBox();
			this.checkBoxShowTriangle = new System.Windows.Forms.CheckBox();
			this.comboBoxLineStyle = new System.Windows.Forms.ComboBox();
			this.numericUpDownLineWidth = new System.Windows.Forms.NumericUpDown();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.checkBoxFillRegion = new System.Windows.Forms.CheckBox();
			this.label7 = new System.Windows.Forms.Label();
			this.labelFillAlpha = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBoxFillwColorManager = new System.Windows.Forms.ComboBox();
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.groupPanelSearchType1 = new GroupPanel();
			this.textBoxContourValueText = new System.Windows.Forms.TextBox();
			this.numericUpDownContourValue = new System.Windows.Forms.NumericUpDown();
			this.label23 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.buttonChoseContourFillColor = new System.Windows.Forms.Button();
			this.buttonChoseContourCurveColor = new System.Windows.Forms.Button();
			this.label21 = new System.Windows.Forms.Label();
			this.pictureBoxContourFillColor = new System.Windows.Forms.PictureBox();
			this.label20 = new System.Windows.Forms.Label();
			this.pictureBoxContourCurveColor = new System.Windows.Forms.PictureBox();
			this.buttonXClearValue = new ButtonX();
			this.listViewColorItem = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.buttonX3DeleteValue = new ButtonX();
			this.buttonXAddValue = new ButtonX();
			this.buttonXModifyValue = new ButtonX();
			this.buttonXSaveDefaultParams = new ButtonX();
			this.buttonXLoadDefaultParams = new ButtonX();
			this.textBoxXFilePath = new TextBoxX();
			this.buttonCancel = new ButtonX();
			this.buttonOK = new ButtonX();
			this.groupPanelContourFill = new GroupPanel();
			this.trackBarFillAlpha = new Slider();
			this.groupPanelContourStyle = new GroupPanel();
			this.checkBoxShowArrow = new System.Windows.Forms.CheckBox();
			this.checkBoxShowContour = new System.Windows.Forms.CheckBox();
			this.checkBoxWantSPL = new System.Windows.Forms.CheckBox();
			this.pictureBoxDefaultColor = new System.Windows.Forms.PictureBox();
			this.groupPanelColorRange = new GroupPanel();
			this.sliderMaxColorID = new Slider();
			this.sliderMinColorID = new Slider();
			this.pictureBoxColorBarFill = new System.Windows.Forms.PictureBox();
			this.pictureBoxColorBarLine = new System.Windows.Forms.PictureBox();
			this.label11 = new System.Windows.Forms.Label();
			this.groupPanelValue = new GroupPanel();
			this.radioButtonSearchType3 = new System.Windows.Forms.RadioButton();
			this.checkBoxUseSpecifiedMaxValue = new System.Windows.Forms.CheckBox();
			this.checkBoxUseSpecifiedMinValue = new System.Windows.Forms.CheckBox();
			this.numericUpDownSearchCount = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownMaxValue = new System.Windows.Forms.NumericUpDown();
			this.radioButtonSearchType2 = new System.Windows.Forms.RadioButton();
			this.numericUpDownMinValue = new System.Windows.Forms.NumericUpDown();
			this.radioButtonSearchType1 = new System.Windows.Forms.RadioButton();
			this.label24 = new System.Windows.Forms.Label();
			this.groupPanelSearchType2 = new GroupPanel();
			this.numericUpDownFontHeight = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownTextStep = new System.Windows.Forms.NumericUpDown();
			this.label15 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.textBoxValueUnit = new System.Windows.Forms.TextBox();
			this.checkBoxShowText = new System.Windows.Forms.CheckBox();
			this.textBoxValueFormat = new System.Windows.Forms.TextBox();
			this.checkBoxShowUnitInColorBar = new System.Windows.Forms.CheckBox();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.labelTextFormatPreview = new System.Windows.Forms.Label();
			this.checkBoxTextRotate = new System.Windows.Forms.CheckBox();
			this.checkBoxTextColor = new System.Windows.Forms.CheckBox();
			this.checkBoxTextBold = new System.Windows.Forms.CheckBox();
			this.checkBoxShowUnitInCurve = new System.Windows.Forms.CheckBox();
			this.label26 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownCounterLineWidth = new System.Windows.Forms.NumericUpDown();
			this.label6 = new System.Windows.Forms.Label();
			this.comboBoxCoutourLineStyle = new System.Windows.Forms.ComboBox();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownBaseValue).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStepValue).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLineWidth).BeginInit();
			this.ribbonClientPanel1.SuspendLayout();
			this.groupPanelSearchType1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownContourValue).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxContourFillColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxContourCurveColor).BeginInit();
			this.groupPanelContourFill.SuspendLayout();
			this.groupPanelContourStyle.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxDefaultColor).BeginInit();
			this.groupPanelColorRange.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxColorBarFill).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxColorBarLine).BeginInit();
			this.groupPanelValue.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownSearchCount).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownMaxValue).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownMinValue).BeginInit();
			this.groupPanelSearchType2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownFontHeight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownTextStep).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCounterLineWidth).BeginInit();
			base.SuspendLayout();
			this.comboBoxwColorManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxwColorManager.FormattingEnabled = true;
			this.comboBoxwColorManager.Items.AddRange(new object[]
			{
				"默认颜色",
				"彩虹编码1",
				"彩虹编码2",
				"金属编码1",
				"金属编码2",
				"绿色渐变",
				"红黄渐变"
			});
			this.comboBoxwColorManager.Location = new System.Drawing.Point(85, 95);
			this.comboBoxwColorManager.Name = "comboBoxwColorManager";
			this.comboBoxwColorManager.Size = new System.Drawing.Size(102, 25);
			this.comboBoxwColorManager.TabIndex = 2;
			this.comboBoxwColorManager.SelectedIndexChanged += new System.EventHandler(this.comboBoxwColorManager_SelectedIndexChanged);
			this.label22.AutoSize = true;
			this.label22.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label22.Location = new System.Drawing.Point(18, 99);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(68, 17);
			this.label22.TabIndex = 18;
			this.label22.Text = "曲线颜色：";
			this.label5.AutoSize = true;
			this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label5.Location = new System.Drawing.Point(18, 130);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(68, 17);
			this.label5.TabIndex = 22;
			this.label5.Text = "默认颜色：";
			this.buttonDefaultColor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.buttonDefaultColor.Location = new System.Drawing.Point(194, 126);
			this.buttonDefaultColor.Name = "buttonDefaultColor";
			this.buttonDefaultColor.Size = new System.Drawing.Size(76, 27);
			this.buttonDefaultColor.TabIndex = 3;
			this.buttonDefaultColor.Text = "选\u3000择";
			this.buttonDefaultColor.UseVisualStyleBackColor = true;
			this.buttonDefaultColor.Click += new System.EventHandler(this.buttonDefaultColor_Click);
			this.colorDialog.AnyColor = true;
			this.colorDialog.FullOpen = true;
			this.imageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList.ImageStream");
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "colorbar0.bmp");
			this.imageList.Images.SetKeyName(1, "colorbar1.bmp");
			this.imageList.Images.SetKeyName(2, "colorbar2.bmp");
			this.imageList.Images.SetKeyName(3, "colorbar3.bmp");
			this.label3.AutoSize = true;
			this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label3.Location = new System.Drawing.Point(29, 54);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 17);
			this.label3.TabIndex = 22;
			this.label3.Text = "基准线：";
			this.numericUpDownBaseValue.DecimalPlaces = 2;
			this.numericUpDownBaseValue.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDownBaseValue.Location = new System.Drawing.Point(81, 52);
			System.Windows.Forms.NumericUpDown arg_8F2_0 = this.numericUpDownBaseValue;
			int[] array = new int[4];
			array[0] = 9999;
			arg_8F2_0.Maximum = new decimal(array);
			this.numericUpDownBaseValue.Minimum = new decimal(new int[]
			{
				9999,
				0,
				0,
				-2147483648
			});
			this.numericUpDownBaseValue.Name = "numericUpDownBaseValue";
			this.numericUpDownBaseValue.Size = new System.Drawing.Size(79, 23);
			this.numericUpDownBaseValue.TabIndex = 15;
			this.numericUpDownBaseValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label4.AutoSize = true;
			this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label4.Location = new System.Drawing.Point(172, 54);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(44, 17);
			this.label4.TabIndex = 22;
			this.label4.Text = "步长：";
			this.numericUpDownStepValue.DecimalPlaces = 2;
			this.numericUpDownStepValue.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDownStepValue.Location = new System.Drawing.Point(210, 52);
			System.Windows.Forms.NumericUpDown arg_A42_0 = this.numericUpDownStepValue;
			array = new int[4];
			array[0] = 9999;
			arg_A42_0.Maximum = new decimal(array);
			this.numericUpDownStepValue.Name = "numericUpDownStepValue";
			this.numericUpDownStepValue.Size = new System.Drawing.Size(79, 23);
			this.numericUpDownStepValue.TabIndex = 16;
			this.numericUpDownStepValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_AA1_0 = this.numericUpDownStepValue;
			array = new int[4];
			array[0] = 50;
			arg_AA1_0.Value = new decimal(array);
			this.checkBoxShowVertex.AutoSize = true;
			this.checkBoxShowVertex.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowVertex.Location = new System.Drawing.Point(144, 161);
			this.checkBoxShowVertex.Name = "checkBoxShowVertex";
			this.checkBoxShowVertex.Size = new System.Drawing.Size(99, 21);
			this.checkBoxShowVertex.TabIndex = 17;
			this.checkBoxShowVertex.Text = "显示节点数值";
			this.checkBoxShowVertex.UseVisualStyleBackColor = true;
			this.checkBoxShowTriangle.AutoSize = true;
			this.checkBoxShowTriangle.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowTriangle.Location = new System.Drawing.Point(26, 189);
			this.checkBoxShowTriangle.Name = "checkBoxShowTriangle";
			this.checkBoxShowTriangle.Size = new System.Drawing.Size(99, 21);
			this.checkBoxShowTriangle.TabIndex = 18;
			this.checkBoxShowTriangle.Text = "显示三角剖分";
			this.checkBoxShowTriangle.UseVisualStyleBackColor = true;
			this.comboBoxLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLineStyle.FormattingEnabled = true;
			this.comboBoxLineStyle.Items.AddRange(new object[]
			{
				"— — — —",
				"—.—.—.—",
				"—. .—. .—",
				". . . . . . . . . ",
				"—————"
			});
			this.comboBoxLineStyle.Location = new System.Drawing.Point(85, 64);
			this.comboBoxLineStyle.Name = "comboBoxLineStyle";
			this.comboBoxLineStyle.Size = new System.Drawing.Size(102, 25);
			this.comboBoxLineStyle.TabIndex = 1;
			this.numericUpDownLineWidth.Location = new System.Drawing.Point(85, 34);
			System.Windows.Forms.NumericUpDown arg_C8A_0 = this.numericUpDownLineWidth;
			array = new int[4];
			array[0] = 10;
			arg_C8A_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_CA7_0 = this.numericUpDownLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_CA7_0.Minimum = new decimal(array);
			this.numericUpDownLineWidth.Name = "numericUpDownLineWidth";
			this.numericUpDownLineWidth.Size = new System.Drawing.Size(102, 23);
			this.numericUpDownLineWidth.TabIndex = 0;
			this.numericUpDownLineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_D04_0 = this.numericUpDownLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_D04_0.Value = new decimal(array);
			this.label13.AutoSize = true;
			this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label13.Location = new System.Drawing.Point(18, 36);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(68, 17);
			this.label13.TabIndex = 28;
			this.label13.Text = "曲线粗细：";
			this.label14.AutoSize = true;
			this.label14.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label14.Location = new System.Drawing.Point(18, 68);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(68, 17);
			this.label14.TabIndex = 29;
			this.label14.Text = "曲线类型：";
			this.checkBoxFillRegion.AutoSize = true;
			this.checkBoxFillRegion.Checked = true;
			this.checkBoxFillRegion.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxFillRegion.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxFillRegion.Location = new System.Drawing.Point(19, 9);
			this.checkBoxFillRegion.Name = "checkBoxFillRegion";
			this.checkBoxFillRegion.Size = new System.Drawing.Size(87, 21);
			this.checkBoxFillRegion.TabIndex = 10;
			this.checkBoxFillRegion.Text = "填充等值线";
			this.checkBoxFillRegion.UseVisualStyleBackColor = true;
			this.label7.AutoSize = true;
			this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label7.Location = new System.Drawing.Point(12, 45);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(80, 17);
			this.label7.TabIndex = 26;
			this.label7.Text = "填充透明度：";
			this.labelFillAlpha.AutoSize = true;
			this.labelFillAlpha.ForeColor = System.Drawing.SystemColors.WindowText;
			this.labelFillAlpha.Location = new System.Drawing.Point(238, 45);
			this.labelFillAlpha.Name = "labelFillAlpha";
			this.labelFillAlpha.Size = new System.Drawing.Size(29, 17);
			this.labelFillAlpha.TabIndex = 25;
			this.labelFillAlpha.Text = "150";
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label2.Location = new System.Drawing.Point(12, 34);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 19);
			this.label2.TabIndex = 18;
			this.label2.Text = "曲线：";
			this.comboBoxFillwColorManager.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFillwColorManager.FormattingEnabled = true;
			this.comboBoxFillwColorManager.Items.AddRange(new object[]
			{
				"彩虹编码1",
				"彩虹编码2",
				"金属编码1",
				"金属编码2",
				"绿色编码",
				"红黄渐变"
			});
			this.comboBoxFillwColorManager.Location = new System.Drawing.Point(112, 7);
			this.comboBoxFillwColorManager.Name = "comboBoxFillwColorManager";
			this.comboBoxFillwColorManager.Size = new System.Drawing.Size(155, 25);
			this.comboBoxFillwColorManager.TabIndex = 11;
			this.comboBoxFillwColorManager.SelectedIndexChanged += new System.EventHandler(this.comboBoxFillwColorManager_SelectedIndexChanged);
			this.ribbonClientPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.groupPanelSearchType1);
			this.ribbonClientPanel1.Controls.Add(this.buttonXSaveDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.buttonXLoadDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.textBoxXFilePath);
			this.ribbonClientPanel1.Controls.Add(this.buttonCancel);
			this.ribbonClientPanel1.Controls.Add(this.buttonOK);
			this.ribbonClientPanel1.Controls.Add(this.groupPanelContourFill);
			this.ribbonClientPanel1.Controls.Add(this.groupPanelContourStyle);
			this.ribbonClientPanel1.Controls.Add(this.groupPanelColorRange);
			this.ribbonClientPanel1.Controls.Add(this.groupPanelValue);
			this.ribbonClientPanel1.Controls.Add(this.groupPanelSearchType2);
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(996, 738);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.StyleMouseDown.Class = "";
			this.ribbonClientPanel1.StyleMouseOver.Class = "";
			this.ribbonClientPanel1.TabIndex = 37;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.groupPanelSearchType1.BackColor = System.Drawing.Color.Transparent;
			this.groupPanelSearchType1.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanelSearchType1.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanelSearchType1.Controls.Add(this.textBoxContourValueText);
			this.groupPanelSearchType1.Controls.Add(this.numericUpDownContourValue);
			this.groupPanelSearchType1.Controls.Add(this.label23);
			this.groupPanelSearchType1.Controls.Add(this.label19);
			this.groupPanelSearchType1.Controls.Add(this.buttonChoseContourFillColor);
			this.groupPanelSearchType1.Controls.Add(this.buttonChoseContourCurveColor);
			this.groupPanelSearchType1.Controls.Add(this.comboBoxCoutourLineStyle);
			this.groupPanelSearchType1.Controls.Add(this.label21);
			this.groupPanelSearchType1.Controls.Add(this.pictureBoxContourFillColor);
			this.groupPanelSearchType1.Controls.Add(this.label20);
			this.groupPanelSearchType1.Controls.Add(this.pictureBoxContourCurveColor);
			this.groupPanelSearchType1.Controls.Add(this.numericUpDownCounterLineWidth);
			this.groupPanelSearchType1.Controls.Add(this.label6);
			this.groupPanelSearchType1.Controls.Add(this.buttonXClearValue);
			this.groupPanelSearchType1.Controls.Add(this.listViewColorItem);
			this.groupPanelSearchType1.Controls.Add(this.label1);
			this.groupPanelSearchType1.Controls.Add(this.buttonX3DeleteValue);
			this.groupPanelSearchType1.Controls.Add(this.buttonXAddValue);
			this.groupPanelSearchType1.Controls.Add(this.buttonXModifyValue);
			this.groupPanelSearchType1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanelSearchType1.Location = new System.Drawing.Point(640, 12);
			this.groupPanelSearchType1.Name = "groupPanelSearchType1";
			this.groupPanelSearchType1.Size = new System.Drawing.Size(342, 431);
			this.groupPanelSearchType1.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanelSearchType1.Style.BackColorGradientAngle = 90;
			this.groupPanelSearchType1.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanelSearchType1.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanelSearchType1.Style.BorderBottomWidth = 1;
			this.groupPanelSearchType1.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanelSearchType1.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanelSearchType1.Style.BorderLeftWidth = 1;
			this.groupPanelSearchType1.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanelSearchType1.Style.BorderRightWidth = 1;
			this.groupPanelSearchType1.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanelSearchType1.Style.BorderTopWidth = 1;
			this.groupPanelSearchType1.Style.Class = "";
			this.groupPanelSearchType1.Style.CornerDiameter = 4;
			this.groupPanelSearchType1.Style.CornerType = eCornerType.Rounded;
			this.groupPanelSearchType1.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanelSearchType1.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanelSearchType1.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanelSearchType1.StyleMouseDown.Class = "";
			this.groupPanelSearchType1.StyleMouseOver.Class = "";
			this.groupPanelSearchType1.TabIndex = 36;
			this.groupPanelSearchType1.Text = "按指定的数值搜索";
			this.textBoxContourValueText.Enabled = false;
			this.textBoxContourValueText.Location = new System.Drawing.Point(229, 286);
			this.textBoxContourValueText.Name = "textBoxContourValueText";
			this.textBoxContourValueText.Size = new System.Drawing.Size(94, 23);
			this.textBoxContourValueText.TabIndex = 23;
			this.textBoxContourValueText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownContourValue.DecimalPlaces = 5;
			this.numericUpDownContourValue.Enabled = false;
			this.numericUpDownContourValue.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.numericUpDownContourValue.Location = new System.Drawing.Point(72, 286);
			System.Windows.Forms.NumericUpDown arg_1765_0 = this.numericUpDownContourValue;
			array = new int[4];
			array[0] = 9999;
			arg_1765_0.Maximum = new decimal(array);
			this.numericUpDownContourValue.Minimum = new decimal(new int[]
			{
				9999,
				0,
				0,
				-2147483648
			});
			this.numericUpDownContourValue.Name = "numericUpDownContourValue";
			this.numericUpDownContourValue.Size = new System.Drawing.Size(94, 23);
			this.numericUpDownContourValue.TabIndex = 42;
			this.numericUpDownContourValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label23.AutoSize = true;
			this.label23.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label23.Location = new System.Drawing.Point(165, 289);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(68, 17);
			this.label23.TabIndex = 40;
			this.label23.Text = "指定文字：";
			this.label19.AutoSize = true;
			this.label19.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label19.Location = new System.Drawing.Point(8, 288);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(68, 17);
			this.label19.TabIndex = 40;
			this.label19.Text = "指定数值：";
			this.buttonChoseContourFillColor.Enabled = false;
			this.buttonChoseContourFillColor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.buttonChoseContourFillColor.Location = new System.Drawing.Point(272, 369);
			this.buttonChoseContourFillColor.Name = "buttonChoseContourFillColor";
			this.buttonChoseContourFillColor.Size = new System.Drawing.Size(49, 27);
			this.buttonChoseContourFillColor.TabIndex = 38;
			this.buttonChoseContourFillColor.Text = "选择";
			this.buttonChoseContourFillColor.UseVisualStyleBackColor = true;
			this.buttonChoseContourFillColor.Click += new System.EventHandler(this.buttonChoseContourFillColor_Click);
			this.buttonChoseContourCurveColor.Enabled = false;
			this.buttonChoseContourCurveColor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.buttonChoseContourCurveColor.Location = new System.Drawing.Point(116, 368);
			this.buttonChoseContourCurveColor.Name = "buttonChoseContourCurveColor";
			this.buttonChoseContourCurveColor.Size = new System.Drawing.Size(49, 27);
			this.buttonChoseContourCurveColor.TabIndex = 38;
			this.buttonChoseContourCurveColor.Text = "选择";
			this.buttonChoseContourCurveColor.UseVisualStyleBackColor = true;
			this.buttonChoseContourCurveColor.Click += new System.EventHandler(this.buttonChoseContourCurveColor_Click);
			this.label21.AutoSize = true;
			this.label21.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label21.Location = new System.Drawing.Point(165, 348);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(68, 17);
			this.label21.TabIndex = 39;
			this.label21.Text = "填充颜色：";
			this.pictureBoxContourFillColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxContourFillColor.Location = new System.Drawing.Point(170, 369);
			this.pictureBoxContourFillColor.Name = "pictureBoxContourFillColor";
			this.pictureBoxContourFillColor.Size = new System.Drawing.Size(95, 26);
			this.pictureBoxContourFillColor.TabIndex = 41;
			this.pictureBoxContourFillColor.TabStop = false;
			this.label20.AutoSize = true;
			this.label20.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label20.Location = new System.Drawing.Point(8, 348);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(68, 17);
			this.label20.TabIndex = 39;
			this.label20.Text = "线条颜色：";
			this.pictureBoxContourCurveColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxContourCurveColor.Location = new System.Drawing.Point(13, 370);
			this.pictureBoxContourCurveColor.Name = "pictureBoxContourCurveColor";
			this.pictureBoxContourCurveColor.Size = new System.Drawing.Size(95, 26);
			this.pictureBoxContourCurveColor.TabIndex = 41;
			this.pictureBoxContourCurveColor.TabStop = false;
			this.buttonXClearValue.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXClearValue.Image = Resources.ClearValue;
			this.buttonXClearValue.Location = new System.Drawing.Point(249, 245);
			this.buttonXClearValue.Name = "buttonXClearValue";
			this.buttonXClearValue.Size = new System.Drawing.Size(75, 35);
			this.buttonXClearValue.TabIndex = 35;
			this.buttonXClearValue.Text = "清\u3000空";
			this.buttonXClearValue.Click += new System.EventHandler(this.buttonXClearColor_Click);
			this.listViewColorItem.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1,
				this.columnHeader2,
				this.columnHeader3,
				this.columnHeader4,
				this.columnHeader5
			});
			this.listViewColorItem.FullRowSelect = true;
			this.listViewColorItem.GridLines = true;
			this.listViewColorItem.HideSelection = false;
			this.listViewColorItem.Location = new System.Drawing.Point(9, 5);
			this.listViewColorItem.MultiSelect = false;
			this.listViewColorItem.Name = "listViewColorItem";
			this.listViewColorItem.Size = new System.Drawing.Size(314, 234);
			this.listViewColorItem.TabIndex = 0;
			this.listViewColorItem.UseCompatibleStateImageBehavior = false;
			this.listViewColorItem.View = System.Windows.Forms.View.Details;
			this.listViewColorItem.SelectedIndexChanged += new System.EventHandler(this.listViewColorItem_SelectedIndexChanged);
			this.columnHeader1.Text = "序号";
			this.columnHeader1.Width = 49;
			this.columnHeader2.Text = "数值";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 130;
			this.columnHeader3.Text = "文字";
			this.columnHeader3.Width = 109;
			this.buttonX3DeleteValue.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX3DeleteValue.Image = Resources.DeleteValue;
			this.buttonX3DeleteValue.Location = new System.Drawing.Point(169, 245);
			this.buttonX3DeleteValue.Name = "buttonX3DeleteValue";
			this.buttonX3DeleteValue.Size = new System.Drawing.Size(75, 35);
			this.buttonX3DeleteValue.TabIndex = 34;
			this.buttonX3DeleteValue.Text = "删\u3000除";
			this.buttonX3DeleteValue.Click += new System.EventHandler(this.buttonX3DeleteColor_Click);
			this.buttonXAddValue.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXAddValue.Image = Resources.AddValue;
			this.buttonXAddValue.Location = new System.Drawing.Point(9, 245);
			this.buttonXAddValue.Name = "buttonXAddValue";
			this.buttonXAddValue.Size = new System.Drawing.Size(75, 35);
			this.buttonXAddValue.TabIndex = 37;
			this.buttonXAddValue.Text = "添\u3000加";
			this.buttonXAddValue.Click += new System.EventHandler(this.buttonXAddColor_Click);
			this.buttonXModifyValue.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXModifyValue.Image = Resources.ModifyValue;
			this.buttonXModifyValue.Location = new System.Drawing.Point(89, 245);
			this.buttonXModifyValue.Name = "buttonXModifyValue";
			this.buttonXModifyValue.Size = new System.Drawing.Size(75, 35);
			this.buttonXModifyValue.TabIndex = 36;
			this.buttonXModifyValue.Text = "修\u3000改";
			this.buttonXModifyValue.Click += new System.EventHandler(this.buttonXModifyColor_Click);
			this.buttonXSaveDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXSaveDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXSaveDefaultParams.Image = (System.Drawing.Image)resources.GetObject("buttonXSaveDefaultParams.Image");
			this.buttonXSaveDefaultParams.Location = new System.Drawing.Point(739, 507);
			this.buttonXSaveDefaultParams.Name = "buttonXSaveDefaultParams";
			this.buttonXSaveDefaultParams.Size = new System.Drawing.Size(243, 53);
			this.buttonXSaveDefaultParams.TabIndex = 35;
			this.buttonXSaveDefaultParams.Text = "保存为默认参数";
			this.buttonXSaveDefaultParams.Click += new System.EventHandler(this.buttonXSaveDefaultParams_Click);
			this.buttonXLoadDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXLoadDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXLoadDefaultParams.Image = (System.Drawing.Image)resources.GetObject("buttonXLoadDefaultParams.Image");
			this.buttonXLoadDefaultParams.Location = new System.Drawing.Point(739, 457);
			this.buttonXLoadDefaultParams.Name = "buttonXLoadDefaultParams";
			this.buttonXLoadDefaultParams.Size = new System.Drawing.Size(243, 44);
			this.buttonXLoadDefaultParams.TabIndex = 34;
			this.buttonXLoadDefaultParams.Text = "载入默认参数";
			this.buttonXLoadDefaultParams.Click += new System.EventHandler(this.buttonXLoadDefaultParams_Click);
			this.textBoxXFilePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.textBoxXFilePath.Border.Class = "TextBoxBorder";
			this.textBoxXFilePath.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxXFilePath.Location = new System.Drawing.Point(16, 615);
			this.textBoxXFilePath.Multiline = true;
			this.textBoxXFilePath.Name = "textBoxXFilePath";
			this.textBoxXFilePath.Size = new System.Drawing.Size(717, 49);
			this.textBoxXFilePath.TabIndex = 31;
			this.textBoxXFilePath.TabStop = false;
			this.textBoxXFilePath.Text = "数据路径：";
			this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonCancel.Image = (System.Drawing.Image)resources.GetObject("buttonCancel.Image");
			this.buttonCancel.Location = new System.Drawing.Point(739, 620);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(243, 43);
			this.buttonCancel.TabIndex = 25;
			this.buttonCancel.Text = "取\u3000消";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonOK.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonOK.Image = (System.Drawing.Image)resources.GetObject("buttonOK.Image");
			this.buttonOK.Location = new System.Drawing.Point(739, 566);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(243, 48);
			this.buttonOK.TabIndex = 24;
			this.buttonOK.Text = "确\u3000定";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.groupPanelContourFill.BackColor = System.Drawing.Color.Transparent;
			this.groupPanelContourFill.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanelContourFill.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanelContourFill.Controls.Add(this.trackBarFillAlpha);
			this.groupPanelContourFill.Controls.Add(this.label7);
			this.groupPanelContourFill.Controls.Add(this.comboBoxFillwColorManager);
			this.groupPanelContourFill.Controls.Add(this.labelFillAlpha);
			this.groupPanelContourFill.Controls.Add(this.checkBoxFillRegion);
			this.groupPanelContourFill.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanelContourFill.Location = new System.Drawing.Point(15, 337);
			this.groupPanelContourFill.Name = "groupPanelContourFill";
			this.groupPanelContourFill.Size = new System.Drawing.Size(295, 106);
			this.groupPanelContourFill.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanelContourFill.Style.BackColorGradientAngle = 90;
			this.groupPanelContourFill.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanelContourFill.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanelContourFill.Style.BorderBottomWidth = 1;
			this.groupPanelContourFill.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanelContourFill.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanelContourFill.Style.BorderLeftWidth = 1;
			this.groupPanelContourFill.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanelContourFill.Style.BorderRightWidth = 1;
			this.groupPanelContourFill.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanelContourFill.Style.BorderTopWidth = 1;
			this.groupPanelContourFill.Style.Class = "";
			this.groupPanelContourFill.Style.CornerDiameter = 4;
			this.groupPanelContourFill.Style.CornerType = eCornerType.Rounded;
			this.groupPanelContourFill.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanelContourFill.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanelContourFill.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanelContourFill.StyleMouseDown.Class = "";
			this.groupPanelContourFill.StyleMouseOver.Class = "";
			this.groupPanelContourFill.TabIndex = 0;
			this.groupPanelContourFill.Text = "伪彩色填充选项";
			this.trackBarFillAlpha.BackgroundStyle.Class = "";
			this.trackBarFillAlpha.LabelVisible = false;
			this.trackBarFillAlpha.Location = new System.Drawing.Point(91, 38);
			this.trackBarFillAlpha.Maximum = 255;
			this.trackBarFillAlpha.Name = "trackBarFillAlpha";
			this.trackBarFillAlpha.Size = new System.Drawing.Size(144, 32);
			this.trackBarFillAlpha.TabIndex = 20;
			this.trackBarFillAlpha.Text = "slider1";
			this.trackBarFillAlpha.Value = 150;
			this.trackBarFillAlpha.ValueChanged += new System.EventHandler(this.trackBarFillAlpha_ValueChanged);
			this.groupPanelContourStyle.BackColor = System.Drawing.Color.Transparent;
			this.groupPanelContourStyle.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanelContourStyle.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanelContourStyle.Controls.Add(this.comboBoxwColorManager);
			this.groupPanelContourStyle.Controls.Add(this.checkBoxShowVertex);
			this.groupPanelContourStyle.Controls.Add(this.checkBoxShowArrow);
			this.groupPanelContourStyle.Controls.Add(this.checkBoxShowTriangle);
			this.groupPanelContourStyle.Controls.Add(this.checkBoxShowContour);
			this.groupPanelContourStyle.Controls.Add(this.checkBoxWantSPL);
			this.groupPanelContourStyle.Controls.Add(this.comboBoxLineStyle);
			this.groupPanelContourStyle.Controls.Add(this.buttonDefaultColor);
			this.groupPanelContourStyle.Controls.Add(this.label22);
			this.groupPanelContourStyle.Controls.Add(this.label5);
			this.groupPanelContourStyle.Controls.Add(this.numericUpDownLineWidth);
			this.groupPanelContourStyle.Controls.Add(this.pictureBoxDefaultColor);
			this.groupPanelContourStyle.Controls.Add(this.label14);
			this.groupPanelContourStyle.Controls.Add(this.label13);
			this.groupPanelContourStyle.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanelContourStyle.Location = new System.Drawing.Point(15, 12);
			this.groupPanelContourStyle.Name = "groupPanelContourStyle";
			this.groupPanelContourStyle.Size = new System.Drawing.Size(295, 319);
			this.groupPanelContourStyle.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanelContourStyle.Style.BackColorGradientAngle = 90;
			this.groupPanelContourStyle.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanelContourStyle.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanelContourStyle.Style.BorderBottomWidth = 1;
			this.groupPanelContourStyle.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanelContourStyle.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanelContourStyle.Style.BorderLeftWidth = 1;
			this.groupPanelContourStyle.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanelContourStyle.Style.BorderRightWidth = 1;
			this.groupPanelContourStyle.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanelContourStyle.Style.BorderTopWidth = 1;
			this.groupPanelContourStyle.Style.Class = "";
			this.groupPanelContourStyle.Style.CornerDiameter = 4;
			this.groupPanelContourStyle.Style.CornerType = eCornerType.Rounded;
			this.groupPanelContourStyle.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanelContourStyle.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanelContourStyle.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanelContourStyle.StyleMouseDown.Class = "";
			this.groupPanelContourStyle.StyleMouseOver.Class = "";
			this.groupPanelContourStyle.TabIndex = 0;
			this.groupPanelContourStyle.Text = "等值线样式选项";
			this.checkBoxShowArrow.AutoSize = true;
			this.checkBoxShowArrow.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowArrow.Location = new System.Drawing.Point(144, 190);
			this.checkBoxShowArrow.Name = "checkBoxShowArrow";
			this.checkBoxShowArrow.Size = new System.Drawing.Size(99, 21);
			this.checkBoxShowArrow.TabIndex = 19;
			this.checkBoxShowArrow.Text = "显示曲线方向";
			this.checkBoxShowArrow.UseVisualStyleBackColor = true;
			this.checkBoxShowContour.AutoSize = true;
			this.checkBoxShowContour.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowContour.Location = new System.Drawing.Point(26, 8);
			this.checkBoxShowContour.Name = "checkBoxShowContour";
			this.checkBoxShowContour.Size = new System.Drawing.Size(87, 21);
			this.checkBoxShowContour.TabIndex = 4;
			this.checkBoxShowContour.Text = "显示等值线";
			this.checkBoxShowContour.UseVisualStyleBackColor = true;
			this.checkBoxWantSPL.AutoSize = true;
			this.checkBoxWantSPL.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxWantSPL.Location = new System.Drawing.Point(26, 160);
			this.checkBoxWantSPL.Name = "checkBoxWantSPL";
			this.checkBoxWantSPL.Size = new System.Drawing.Size(99, 21);
			this.checkBoxWantSPL.TabIndex = 5;
			this.checkBoxWantSPL.Text = "使用样条插值";
			this.checkBoxWantSPL.UseVisualStyleBackColor = true;
			this.pictureBoxDefaultColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxDefaultColor.Location = new System.Drawing.Point(86, 126);
			this.pictureBoxDefaultColor.Name = "pictureBoxDefaultColor";
			this.pictureBoxDefaultColor.Size = new System.Drawing.Size(102, 26);
			this.pictureBoxDefaultColor.TabIndex = 23;
			this.pictureBoxDefaultColor.TabStop = false;
			this.groupPanelColorRange.BackColor = System.Drawing.Color.Transparent;
			this.groupPanelColorRange.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanelColorRange.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanelColorRange.Controls.Add(this.sliderMaxColorID);
			this.groupPanelColorRange.Controls.Add(this.sliderMinColorID);
			this.groupPanelColorRange.Controls.Add(this.pictureBoxColorBarFill);
			this.groupPanelColorRange.Controls.Add(this.pictureBoxColorBarLine);
			this.groupPanelColorRange.Controls.Add(this.label11);
			this.groupPanelColorRange.Controls.Add(this.label2);
			this.groupPanelColorRange.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanelColorRange.Location = new System.Drawing.Point(16, 449);
			this.groupPanelColorRange.Name = "groupPanelColorRange";
			this.groupPanelColorRange.Size = new System.Drawing.Size(717, 160);
			this.groupPanelColorRange.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanelColorRange.Style.BackColorGradientAngle = 90;
			this.groupPanelColorRange.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanelColorRange.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanelColorRange.Style.BorderBottomWidth = 1;
			this.groupPanelColorRange.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanelColorRange.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanelColorRange.Style.BorderLeftWidth = 1;
			this.groupPanelColorRange.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanelColorRange.Style.BorderRightWidth = 1;
			this.groupPanelColorRange.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanelColorRange.Style.BorderTopWidth = 1;
			this.groupPanelColorRange.Style.Class = "";
			this.groupPanelColorRange.Style.CornerDiameter = 4;
			this.groupPanelColorRange.Style.CornerType = eCornerType.Rounded;
			this.groupPanelColorRange.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanelColorRange.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanelColorRange.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanelColorRange.StyleMouseDown.Class = "";
			this.groupPanelColorRange.StyleMouseOver.Class = "";
			this.groupPanelColorRange.TabIndex = 0;
			this.groupPanelColorRange.Text = "曲线和填充颜色范围选项";
			this.sliderMaxColorID.BackgroundStyle.Class = "";
			this.sliderMaxColorID.Location = new System.Drawing.Point(12, 94);
			this.sliderMaxColorID.Maximum = 255;
			this.sliderMaxColorID.Name = "sliderMaxColorID";
			this.sliderMaxColorID.Size = new System.Drawing.Size(685, 26);
			this.sliderMaxColorID.TabIndex = 22;
			this.sliderMaxColorID.Text = "最大";
			this.sliderMaxColorID.Value = 128;
			this.sliderMinColorID.BackgroundStyle.Class = "";
			this.sliderMinColorID.Location = new System.Drawing.Point(12, 3);
			this.sliderMinColorID.Maximum = 255;
			this.sliderMinColorID.Name = "sliderMinColorID";
			this.sliderMinColorID.Size = new System.Drawing.Size(685, 26);
			this.sliderMinColorID.TabIndex = 21;
			this.sliderMinColorID.Text = "最小";
			this.sliderMinColorID.Value = 128;
			this.pictureBoxColorBarFill.BackColor = System.Drawing.Color.White;
			this.pictureBoxColorBarFill.Location = new System.Drawing.Point(64, 62);
			this.pictureBoxColorBarFill.Name = "pictureBoxColorBarFill";
			this.pictureBoxColorBarFill.Size = new System.Drawing.Size(618, 26);
			this.pictureBoxColorBarFill.TabIndex = 0;
			this.pictureBoxColorBarFill.TabStop = false;
			this.pictureBoxColorBarLine.BackColor = System.Drawing.Color.White;
			this.pictureBoxColorBarLine.Location = new System.Drawing.Point(64, 30);
			this.pictureBoxColorBarLine.Name = "pictureBoxColorBarLine";
			this.pictureBoxColorBarLine.Size = new System.Drawing.Size(618, 26);
			this.pictureBoxColorBarLine.TabIndex = 0;
			this.pictureBoxColorBarLine.TabStop = false;
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label11.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label11.Location = new System.Drawing.Point(12, 66);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(51, 19);
			this.label11.TabIndex = 18;
			this.label11.Text = "填充：";
			this.groupPanelValue.BackColor = System.Drawing.Color.Transparent;
			this.groupPanelValue.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanelValue.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanelValue.Controls.Add(this.numericUpDownBaseValue);
			this.groupPanelValue.Controls.Add(this.numericUpDownStepValue);
			this.groupPanelValue.Controls.Add(this.radioButtonSearchType3);
			this.groupPanelValue.Controls.Add(this.checkBoxUseSpecifiedMaxValue);
			this.groupPanelValue.Controls.Add(this.checkBoxUseSpecifiedMinValue);
			this.groupPanelValue.Controls.Add(this.label4);
			this.groupPanelValue.Controls.Add(this.numericUpDownSearchCount);
			this.groupPanelValue.Controls.Add(this.numericUpDownMaxValue);
			this.groupPanelValue.Controls.Add(this.radioButtonSearchType2);
			this.groupPanelValue.Controls.Add(this.numericUpDownMinValue);
			this.groupPanelValue.Controls.Add(this.radioButtonSearchType1);
			this.groupPanelValue.Controls.Add(this.label24);
			this.groupPanelValue.Controls.Add(this.label3);
			this.groupPanelValue.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanelValue.Location = new System.Drawing.Point(321, 12);
			this.groupPanelValue.Name = "groupPanelValue";
			this.groupPanelValue.Size = new System.Drawing.Size(309, 206);
			this.groupPanelValue.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanelValue.Style.BackColorGradientAngle = 90;
			this.groupPanelValue.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanelValue.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanelValue.Style.BorderBottomWidth = 1;
			this.groupPanelValue.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanelValue.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanelValue.Style.BorderLeftWidth = 1;
			this.groupPanelValue.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanelValue.Style.BorderRightWidth = 1;
			this.groupPanelValue.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanelValue.Style.BorderTopWidth = 1;
			this.groupPanelValue.Style.Class = "";
			this.groupPanelValue.Style.CornerDiameter = 4;
			this.groupPanelValue.Style.CornerType = eCornerType.Rounded;
			this.groupPanelValue.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanelValue.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanelValue.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanelValue.StyleMouseDown.Class = "";
			this.groupPanelValue.StyleMouseOver.Class = "";
			this.groupPanelValue.TabIndex = 0;
			this.groupPanelValue.Text = "等值线搜索选项";
			this.radioButtonSearchType3.AutoSize = true;
			this.radioButtonSearchType3.Location = new System.Drawing.Point(14, 84);
			this.radioButtonSearchType3.Name = "radioButtonSearchType3";
			this.radioButtonSearchType3.Size = new System.Drawing.Size(122, 21);
			this.radioButtonSearchType3.TabIndex = 24;
			this.radioButtonSearchType3.Text = "在数值范围内搜索";
			this.radioButtonSearchType3.UseVisualStyleBackColor = true;
			this.radioButtonSearchType3.CheckedChanged += new System.EventHandler(this.radioButtonSearchType1_CheckedChanged);
			this.checkBoxUseSpecifiedMaxValue.AutoSize = true;
			this.checkBoxUseSpecifiedMaxValue.Checked = true;
			this.checkBoxUseSpecifiedMaxValue.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxUseSpecifiedMaxValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxUseSpecifiedMaxValue.Location = new System.Drawing.Point(15, 140);
			this.checkBoxUseSpecifiedMaxValue.Name = "checkBoxUseSpecifiedMaxValue";
			this.checkBoxUseSpecifiedMaxValue.Size = new System.Drawing.Size(123, 21);
			this.checkBoxUseSpecifiedMaxValue.TabIndex = 12;
			this.checkBoxUseSpecifiedMaxValue.Text = "限定搜索最大值：";
			this.checkBoxUseSpecifiedMaxValue.UseVisualStyleBackColor = true;
			this.checkBoxUseSpecifiedMaxValue.CheckedChanged += new System.EventHandler(this.checkBoxUseSpecifiedMinMaxValue_CheckedChanged);
			this.checkBoxUseSpecifiedMinValue.AutoSize = true;
			this.checkBoxUseSpecifiedMinValue.Checked = true;
			this.checkBoxUseSpecifiedMinValue.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkBoxUseSpecifiedMinValue.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxUseSpecifiedMinValue.Location = new System.Drawing.Point(15, 112);
			this.checkBoxUseSpecifiedMinValue.Name = "checkBoxUseSpecifiedMinValue";
			this.checkBoxUseSpecifiedMinValue.Size = new System.Drawing.Size(123, 21);
			this.checkBoxUseSpecifiedMinValue.TabIndex = 12;
			this.checkBoxUseSpecifiedMinValue.Text = "限定搜索最小值：";
			this.checkBoxUseSpecifiedMinValue.UseVisualStyleBackColor = true;
			this.checkBoxUseSpecifiedMinValue.CheckedChanged += new System.EventHandler(this.checkBoxUseSpecifiedMinMaxValue_CheckedChanged);
			this.numericUpDownSearchCount.Location = new System.Drawing.Point(140, 82);
			System.Windows.Forms.NumericUpDown arg_3709_0 = this.numericUpDownSearchCount;
			array = new int[4];
			array[0] = 500;
			arg_3709_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_3726_0 = this.numericUpDownSearchCount;
			array = new int[4];
			array[0] = 2;
			arg_3726_0.Minimum = new decimal(array);
			this.numericUpDownSearchCount.Name = "numericUpDownSearchCount";
			this.numericUpDownSearchCount.Size = new System.Drawing.Size(115, 23);
			this.numericUpDownSearchCount.TabIndex = 42;
			this.numericUpDownSearchCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_3785_0 = this.numericUpDownSearchCount;
			array = new int[4];
			array[0] = 20;
			arg_3785_0.Value = new decimal(array);
			this.numericUpDownMaxValue.DecimalPlaces = 2;
			this.numericUpDownMaxValue.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDownMaxValue.Location = new System.Drawing.Point(140, 140);
			System.Windows.Forms.NumericUpDown arg_37F3_0 = this.numericUpDownMaxValue;
			array = new int[4];
			array[0] = 9999;
			arg_37F3_0.Maximum = new decimal(array);
			this.numericUpDownMaxValue.Minimum = new decimal(new int[]
			{
				9999,
				0,
				0,
				-2147483648
			});
			this.numericUpDownMaxValue.Name = "numericUpDownMaxValue";
			this.numericUpDownMaxValue.Size = new System.Drawing.Size(115, 23);
			this.numericUpDownMaxValue.TabIndex = 14;
			this.numericUpDownMaxValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.radioButtonSearchType2.AutoSize = true;
			this.radioButtonSearchType2.Location = new System.Drawing.Point(13, 27);
			this.radioButtonSearchType2.Name = "radioButtonSearchType2";
			this.radioButtonSearchType2.Size = new System.Drawing.Size(158, 21);
			this.radioButtonSearchType2.TabIndex = 24;
			this.radioButtonSearchType2.Text = "按指定基准线和步长搜索";
			this.radioButtonSearchType2.UseVisualStyleBackColor = true;
			this.radioButtonSearchType2.CheckedChanged += new System.EventHandler(this.radioButtonSearchType1_CheckedChanged);
			this.numericUpDownMinValue.DecimalPlaces = 2;
			this.numericUpDownMinValue.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDownMinValue.Location = new System.Drawing.Point(140, 111);
			System.Windows.Forms.NumericUpDown arg_3957_0 = this.numericUpDownMinValue;
			array = new int[4];
			array[0] = 9999;
			arg_3957_0.Maximum = new decimal(array);
			this.numericUpDownMinValue.Minimum = new decimal(new int[]
			{
				9999,
				0,
				0,
				-2147483648
			});
			this.numericUpDownMinValue.Name = "numericUpDownMinValue";
			this.numericUpDownMinValue.Size = new System.Drawing.Size(115, 23);
			this.numericUpDownMinValue.TabIndex = 13;
			this.numericUpDownMinValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.radioButtonSearchType1.AutoSize = true;
			this.radioButtonSearchType1.Checked = true;
			this.radioButtonSearchType1.Location = new System.Drawing.Point(13, 1);
			this.radioButtonSearchType1.Name = "radioButtonSearchType1";
			this.radioButtonSearchType1.Size = new System.Drawing.Size(122, 21);
			this.radioButtonSearchType1.TabIndex = 24;
			this.radioButtonSearchType1.TabStop = true;
			this.radioButtonSearchType1.Text = "按指定的数值搜索";
			this.radioButtonSearchType1.UseVisualStyleBackColor = true;
			this.radioButtonSearchType1.CheckedChanged += new System.EventHandler(this.radioButtonSearchType1_CheckedChanged);
			this.label24.AutoSize = true;
			this.label24.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label24.Location = new System.Drawing.Point(255, 86);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(20, 17);
			this.label24.TabIndex = 22;
			this.label24.Text = "根";
			this.groupPanelSearchType2.BackColor = System.Drawing.Color.Transparent;
			this.groupPanelSearchType2.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanelSearchType2.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanelSearchType2.Controls.Add(this.numericUpDownFontHeight);
			this.groupPanelSearchType2.Controls.Add(this.numericUpDownTextStep);
			this.groupPanelSearchType2.Controls.Add(this.label15);
			this.groupPanelSearchType2.Controls.Add(this.label9);
			this.groupPanelSearchType2.Controls.Add(this.textBoxValueUnit);
			this.groupPanelSearchType2.Controls.Add(this.checkBoxShowText);
			this.groupPanelSearchType2.Controls.Add(this.textBoxValueFormat);
			this.groupPanelSearchType2.Controls.Add(this.checkBoxShowUnitInColorBar);
			this.groupPanelSearchType2.Controls.Add(this.label16);
			this.groupPanelSearchType2.Controls.Add(this.label17);
			this.groupPanelSearchType2.Controls.Add(this.labelTextFormatPreview);
			this.groupPanelSearchType2.Controls.Add(this.checkBoxTextRotate);
			this.groupPanelSearchType2.Controls.Add(this.checkBoxTextColor);
			this.groupPanelSearchType2.Controls.Add(this.checkBoxTextBold);
			this.groupPanelSearchType2.Controls.Add(this.checkBoxShowUnitInCurve);
			this.groupPanelSearchType2.Controls.Add(this.label26);
			this.groupPanelSearchType2.Enabled = false;
			this.groupPanelSearchType2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanelSearchType2.Location = new System.Drawing.Point(321, 224);
			this.groupPanelSearchType2.Name = "groupPanelSearchType2";
			this.groupPanelSearchType2.Size = new System.Drawing.Size(309, 217);
			this.groupPanelSearchType2.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanelSearchType2.Style.BackColorGradientAngle = 90;
			this.groupPanelSearchType2.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanelSearchType2.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanelSearchType2.Style.BorderBottomWidth = 1;
			this.groupPanelSearchType2.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanelSearchType2.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanelSearchType2.Style.BorderLeftWidth = 1;
			this.groupPanelSearchType2.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanelSearchType2.Style.BorderRightWidth = 1;
			this.groupPanelSearchType2.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanelSearchType2.Style.BorderTopWidth = 1;
			this.groupPanelSearchType2.Style.Class = "";
			this.groupPanelSearchType2.Style.CornerDiameter = 4;
			this.groupPanelSearchType2.Style.CornerType = eCornerType.Rounded;
			this.groupPanelSearchType2.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanelSearchType2.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanelSearchType2.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanelSearchType2.StyleMouseDown.Class = "";
			this.groupPanelSearchType2.StyleMouseOver.Class = "";
			this.groupPanelSearchType2.TabIndex = 0;
			this.groupPanelSearchType2.Text = "等值线数值选项";
			this.numericUpDownFontHeight.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.numericUpDownFontHeight.Location = new System.Drawing.Point(82, 124);
			System.Windows.Forms.NumericUpDown arg_3EE2_0 = this.numericUpDownFontHeight;
			array = new int[4];
			array[0] = 99;
			arg_3EE2_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_3EFF_0 = this.numericUpDownFontHeight;
			array = new int[4];
			array[0] = 5;
			arg_3EFF_0.Minimum = new decimal(array);
			this.numericUpDownFontHeight.Name = "numericUpDownFontHeight";
			this.numericUpDownFontHeight.Size = new System.Drawing.Size(56, 23);
			this.numericUpDownFontHeight.TabIndex = 7;
			this.numericUpDownFontHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_3F5C_0 = this.numericUpDownFontHeight;
			array = new int[4];
			array[0] = 5;
			arg_3F5C_0.Value = new decimal(array);
			this.numericUpDownTextStep.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.numericUpDownTextStep.Location = new System.Drawing.Point(82, 153);
			System.Windows.Forms.NumericUpDown arg_3FB4_0 = this.numericUpDownTextStep;
			array = new int[4];
			array[0] = 20;
			arg_3FB4_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_3FD1_0 = this.numericUpDownTextStep;
			array = new int[4];
			array[0] = 1;
			arg_3FD1_0.Minimum = new decimal(array);
			this.numericUpDownTextStep.Name = "numericUpDownTextStep";
			this.numericUpDownTextStep.Size = new System.Drawing.Size(56, 23);
			this.numericUpDownTextStep.TabIndex = 8;
			this.numericUpDownTextStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_402E_0 = this.numericUpDownTextStep;
			array = new int[4];
			array[0] = 1;
			arg_402E_0.Value = new decimal(array);
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label15.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label15.Location = new System.Drawing.Point(12, 128);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(68, 17);
			this.label15.TabIndex = 18;
			this.label15.Text = "文字大小：";
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label9.Location = new System.Drawing.Point(11, 155);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(68, 17);
			this.label9.TabIndex = 18;
			this.label9.Text = "文字间隔：";
			this.textBoxValueUnit.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxValueUnit.Location = new System.Drawing.Point(82, 94);
			this.textBoxValueUnit.Name = "textBoxValueUnit";
			this.textBoxValueUnit.Size = new System.Drawing.Size(204, 23);
			this.textBoxValueUnit.TabIndex = 23;
			this.textBoxValueUnit.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBoxValueUnit.TextChanged += new System.EventHandler(this.textBoxValueFormat_TextChanged);
			this.checkBoxShowText.AutoSize = true;
			this.checkBoxShowText.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxShowText.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowText.Location = new System.Drawing.Point(16, 7);
			this.checkBoxShowText.Name = "checkBoxShowText";
			this.checkBoxShowText.Size = new System.Drawing.Size(135, 21);
			this.checkBoxShowText.TabIndex = 6;
			this.checkBoxShowText.Text = "在等值线上显示数值";
			this.checkBoxShowText.UseVisualStyleBackColor = true;
			this.checkBoxShowText.CheckedChanged += new System.EventHandler(this.checkBoxShowText_CheckedChanged);
			this.textBoxValueFormat.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxValueFormat.Location = new System.Drawing.Point(82, 36);
			this.textBoxValueFormat.Name = "textBoxValueFormat";
			this.textBoxValueFormat.Size = new System.Drawing.Size(62, 23);
			this.textBoxValueFormat.TabIndex = 23;
			this.textBoxValueFormat.Text = "0.0";
			this.textBoxValueFormat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBoxValueFormat.TextChanged += new System.EventHandler(this.textBoxValueFormat_TextChanged);
			this.checkBoxShowUnitInColorBar.AutoSize = true;
			this.checkBoxShowUnitInColorBar.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxShowUnitInColorBar.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowUnitInColorBar.Location = new System.Drawing.Point(175, 67);
			this.checkBoxShowUnitInColorBar.Name = "checkBoxShowUnitInColorBar";
			this.checkBoxShowUnitInColorBar.Size = new System.Drawing.Size(75, 21);
			this.checkBoxShowUnitInColorBar.TabIndex = 6;
			this.checkBoxShowUnitInColorBar.Text = "在色标上";
			this.checkBoxShowUnitInColorBar.UseVisualStyleBackColor = true;
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label16.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label16.Location = new System.Drawing.Point(12, 39);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(68, 17);
			this.label16.TabIndex = 22;
			this.label16.Text = "数值格式：";
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label17.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label17.Location = new System.Drawing.Point(12, 97);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(68, 17);
			this.label17.TabIndex = 22;
			this.label17.Text = "数值单位：";
			this.labelTextFormatPreview.AutoSize = true;
			this.labelTextFormatPreview.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.labelTextFormatPreview.ForeColor = System.Drawing.Color.Maroon;
			this.labelTextFormatPreview.Location = new System.Drawing.Point(150, 40);
			this.labelTextFormatPreview.Name = "labelTextFormatPreview";
			this.labelTextFormatPreview.Size = new System.Drawing.Size(113, 17);
			this.labelTextFormatPreview.TabIndex = 22;
			this.labelTextFormatPreview.Text = "123.45显示为123.5";
			this.checkBoxTextRotate.AutoSize = true;
			this.checkBoxTextRotate.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxTextRotate.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxTextRotate.Location = new System.Drawing.Point(147, 155);
			this.checkBoxTextRotate.Name = "checkBoxTextRotate";
			this.checkBoxTextRotate.Size = new System.Drawing.Size(111, 21);
			this.checkBoxTextRotate.TabIndex = 6;
			this.checkBoxTextRotate.Text = "文字随曲线旋转";
			this.checkBoxTextRotate.UseVisualStyleBackColor = true;
			this.checkBoxTextColor.AutoSize = true;
			this.checkBoxTextColor.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxTextColor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxTextColor.Location = new System.Drawing.Point(196, 125);
			this.checkBoxTextColor.Name = "checkBoxTextColor";
			this.checkBoxTextColor.Size = new System.Drawing.Size(99, 21);
			this.checkBoxTextColor.TabIndex = 6;
			this.checkBoxTextColor.Text = "文字曲线同色";
			this.checkBoxTextColor.UseVisualStyleBackColor = true;
			this.checkBoxTextBold.AutoSize = true;
			this.checkBoxTextBold.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxTextBold.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxTextBold.Location = new System.Drawing.Point(147, 125);
			this.checkBoxTextBold.Name = "checkBoxTextBold";
			this.checkBoxTextBold.Size = new System.Drawing.Size(51, 21);
			this.checkBoxTextBold.TabIndex = 6;
			this.checkBoxTextBold.Text = "加粗";
			this.checkBoxTextBold.UseVisualStyleBackColor = true;
			this.checkBoxShowUnitInCurve.AutoSize = true;
			this.checkBoxShowUnitInCurve.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.checkBoxShowUnitInCurve.ForeColor = System.Drawing.SystemColors.WindowText;
			this.checkBoxShowUnitInCurve.Location = new System.Drawing.Point(82, 67);
			this.checkBoxShowUnitInCurve.Name = "checkBoxShowUnitInCurve";
			this.checkBoxShowUnitInCurve.Size = new System.Drawing.Size(87, 21);
			this.checkBoxShowUnitInCurve.TabIndex = 6;
			this.checkBoxShowUnitInCurve.Text = "在等值线上";
			this.checkBoxShowUnitInCurve.UseVisualStyleBackColor = true;
			this.label26.AutoSize = true;
			this.label26.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label26.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label26.Location = new System.Drawing.Point(12, 68);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(68, 17);
			this.label26.TabIndex = 22;
			this.label26.Text = "显示单位：";
			this.label1.AutoSize = true;
			this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label1.Location = new System.Drawing.Point(8, 318);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(68, 17);
			this.label1.TabIndex = 28;
			this.label1.Text = "曲线粗细：";
			this.numericUpDownCounterLineWidth.Enabled = false;
			this.numericUpDownCounterLineWidth.Location = new System.Drawing.Point(72, 316);
			System.Windows.Forms.NumericUpDown arg_49D1_0 = this.numericUpDownCounterLineWidth;
			array = new int[4];
			array[0] = 10;
			arg_49D1_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_49EE_0 = this.numericUpDownCounterLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_49EE_0.Minimum = new decimal(array);
			this.numericUpDownCounterLineWidth.Name = "numericUpDownCounterLineWidth";
			this.numericUpDownCounterLineWidth.Size = new System.Drawing.Size(94, 23);
			this.numericUpDownCounterLineWidth.TabIndex = 0;
			this.numericUpDownCounterLineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_4A4B_0 = this.numericUpDownCounterLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_4A4B_0.Value = new decimal(array);
			this.label6.AutoSize = true;
			this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label6.Location = new System.Drawing.Point(165, 319);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(68, 17);
			this.label6.TabIndex = 29;
			this.label6.Text = "曲线类型：";
			this.comboBoxCoutourLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxCoutourLineStyle.Enabled = false;
			this.comboBoxCoutourLineStyle.FormattingEnabled = true;
			this.comboBoxCoutourLineStyle.Items.AddRange(new object[]
			{
				"— — — —",
				"—.—.—.—",
				"—. .—. .—",
				". . . . . . . . . ",
				"—————"
			});
			this.comboBoxCoutourLineStyle.Location = new System.Drawing.Point(229, 314);
			this.comboBoxCoutourLineStyle.Name = "comboBoxCoutourLineStyle";
			this.comboBoxCoutourLineStyle.Size = new System.Drawing.Size(95, 25);
			this.comboBoxCoutourLineStyle.TabIndex = 1;
			this.columnHeader4.Text = "线粗";
			this.columnHeader5.Text = "线型";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(994, 678);
			base.ControlBox = false;
			base.Controls.Add(this.ribbonClientPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "ContourSettingForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "等值线参数";
			base.Load += new System.EventHandler(this.ContourSettingForm_Load);
			((System.ComponentModel.ISupportInitialize)this.numericUpDownBaseValue).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStepValue).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLineWidth).EndInit();
			this.ribbonClientPanel1.ResumeLayout(false);
			this.groupPanelSearchType1.ResumeLayout(false);
			this.groupPanelSearchType1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownContourValue).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxContourFillColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxContourCurveColor).EndInit();
			this.groupPanelContourFill.ResumeLayout(false);
			this.groupPanelContourFill.PerformLayout();
			this.groupPanelContourStyle.ResumeLayout(false);
			this.groupPanelContourStyle.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxDefaultColor).EndInit();
			this.groupPanelColorRange.ResumeLayout(false);
			this.groupPanelColorRange.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxColorBarFill).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxColorBarLine).EndInit();
			this.groupPanelValue.ResumeLayout(false);
			this.groupPanelValue.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownSearchCount).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownMaxValue).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownMinValue).EndInit();
			this.groupPanelSearchType2.ResumeLayout(false);
			this.groupPanelSearchType2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownFontHeight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownTextStep).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCounterLineWidth).EndInit();
			base.ResumeLayout(false);
		}
	}
}
