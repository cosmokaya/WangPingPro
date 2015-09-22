using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Ribbon;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using wMetroGIS.Properties;
using wMetroGIS.wColorManager;
using wMetroGIS.wMathmatics;

namespace wMetroGIS.wParams
{
	public class VectorSettingForm : System.Windows.Forms.Form
	{
		public VectorParams m_VectorParams;

		private System.ComponentModel.IContainer components = null;

		private RibbonClientPanel ribbonClientPanel1;

		private TextBoxX textBoxXFilePath;

		private ButtonX buttonCancel;

		private ButtonX buttonOK;

		private GroupPanel groupPanel3;

		private Slider trackBarArrowAngle;

		private System.Windows.Forms.Label label7;

		private System.Windows.Forms.NumericUpDown numericUpDownArrowWidth;

		private System.Windows.Forms.Label label13;

		private ButtonX buttonXClearColor;

		private ButtonX buttonX3DeleteColor;

		private ButtonX buttonXModifyColor;

		private ButtonX buttonXAddColor;

		private System.Windows.Forms.TextBox textBoxColorText;

		private System.Windows.Forms.NumericUpDown numericUpDownColorValueMin;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.Button buttonChoseVectorColor;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.PictureBox pictureBoxVectorColor;

		private GroupPanel groupPanel5;

		private System.Windows.Forms.NumericUpDown numericUpDownColorValueMax;

		private System.Windows.Forms.Label label8;

		private System.Windows.Forms.ListView listViewColorItem;

		private System.Windows.Forms.ColumnHeader columnHeader1;

		private System.Windows.Forms.ColumnHeader columnHeader2;

		private System.Windows.Forms.ColumnHeader columnHeader3;

		private System.Windows.Forms.ColumnHeader columnHeader4;

		private System.Windows.Forms.ColorDialog colorDialog;

		private System.Windows.Forms.ImageList imageList;

		private System.Windows.Forms.RadioButton radioButtonUseLevelColor;

		private System.Windows.Forms.RadioButton radioButtonUseDefaultColor;

		private System.Windows.Forms.PictureBox pictureBoxDefaultColor;

		private System.Windows.Forms.Button buttonChoseDeaultColor;

		private System.Windows.Forms.Label label2;

		private ButtonX buttonXShowPreview;

		private GroupPanel groupPanel2;

		private System.Windows.Forms.PictureBox pictureBoxPreview;

		private ButtonX buttonXSaveDefaultParams;

		private ButtonX buttonXLoadDefaultParams;

		private GroupPanel groupPanel4;

		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.NumericUpDown numericUpDownArrowLength;

		private System.Windows.Forms.RadioButton radioButtonAutoLength;

		private System.Windows.Forms.RadioButton radioButtonDefaultLength;

		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.RadioButton radioButtonLevelLength;

		private System.Windows.Forms.Label label9;

		private System.Windows.Forms.Panel panel1;

		private System.Windows.Forms.RadioButton radioButtonTypeWind;

		private System.Windows.Forms.RadioButton radioButtonTypeArrow;

		private System.Windows.Forms.Label label10;

		public ColorManager VectorLevelColorManager1
		{
			get
			{
				return this.m_VectorParams.m_VectorLevelColorManager1;
			}
		}

		public ColorManager VectorLevelColorManager2
		{
			get
			{
				return this.m_VectorParams.m_VectorLevelColorManager2;
			}
		}

		public int VectorWidth
		{
			get
			{
				return (int)this.numericUpDownArrowWidth.Value;
			}
			set
			{
				this.numericUpDownArrowWidth.Value = value;
			}
		}

		public float VectorAngle
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

		public bool VectorUseDefaultColor
		{
			get
			{
				return this.radioButtonUseDefaultColor.Checked;
			}
			set
			{
				this.radioButtonUseDefaultColor.Checked = value;
				this.radioButtonUseLevelColor.Checked = !value;
			}
		}

		public System.Drawing.Color VectorDefaultColor
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

		public int VectorLengthType
		{
			get
			{
				int result;
				if (this.radioButtonAutoLength.Checked)
				{
					result = 1;
				}
				else if (this.radioButtonLevelLength.Checked)
				{
					result = 2;
				}
				else if (this.radioButtonDefaultLength.Checked)
				{
					result = 3;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			set
			{
				this.radioButtonAutoLength.Checked = (value == 1);
				this.radioButtonLevelLength.Checked = (value == 2);
				this.radioButtonDefaultLength.Checked = (value == 3);
			}
		}

		public float VectorDefaultLength
		{
			get
			{
				return System.Convert.ToSingle(this.numericUpDownArrowLength.Value);
			}
			set
			{
				this.numericUpDownArrowLength.Value = (decimal)value;
			}
		}

		public int VectorArrowType
		{
			get
			{
				int result;
				if (this.radioButtonTypeArrow.Checked)
				{
					result = 1;
				}
				else if (this.radioButtonTypeWind.Checked)
				{
					result = 2;
				}
				else
				{
					result = 0;
				}
				return result;
			}
			set
			{
				this.radioButtonTypeArrow.Checked = (value == 1);
				this.radioButtonTypeWind.Checked = (value == 2);
			}
		}

		public VectorSettingForm()
		{
			this.InitializeComponent();
			this.m_VectorParams = new VectorParams();
			this.m_VectorParams.LoadParams();
			this.LoadVectorParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_VectorParams.ParamFilePath;
		}

		public VectorSettingForm(VectorParams vectorParams)
		{
			this.InitializeComponent();
			this.m_VectorParams = vectorParams;
			if (this.m_VectorParams == null)
			{
				System.Windows.Forms.MessageBox.Show("传入矢量场参数为空！使用默认参数……", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_VectorParams = new VectorParams();
				this.m_VectorParams.LoadParams();
			}
			this.LoadVectorParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_VectorParams.ParamFilePath;
		}

		private void LoadVectorParams()
		{
			this.VectorWidth = this.m_VectorParams.VectorWidth;
			this.VectorAngle = this.m_VectorParams.VectorAngle;
			this.VectorUseDefaultColor = this.m_VectorParams.VectorUseDefaultColor;
			this.VectorDefaultColor = this.m_VectorParams.VectorDefaultColor;
			this.VectorLengthType = this.m_VectorParams.VectorLengthType;
			this.VectorDefaultLength = this.m_VectorParams.VectorDefaultLength;
			this.VectorArrowType = this.m_VectorParams.VectorArrowType;
			this.ShowColorItems();
			this.ShowPreview();
		}

		private bool ApplyVectorParams()
		{
			this.m_VectorParams.VectorWidth = this.VectorWidth;
			this.m_VectorParams.VectorAngle = this.VectorAngle;
			this.m_VectorParams.VectorUseDefaultColor = this.VectorUseDefaultColor;
			this.m_VectorParams.VectorDefaultColor = this.VectorDefaultColor;
			this.m_VectorParams.VectorLengthType = this.VectorLengthType;
			this.m_VectorParams.VectorDefaultLength = this.VectorDefaultLength;
			this.m_VectorParams.VectorArrowType = this.VectorArrowType;
			this.ApplyColorItems();
			return true;
		}

		private void ShowColorItems()
		{
			this.listViewColorItem.Items.Clear();
			for (int i = 0; i < this.VectorLevelColorManager1.m_ColorItems.Count; i++)
			{
				System.Windows.Forms.ListViewItem newItem = this.listViewColorItem.Items.Add(System.Convert.ToString(i + 1));
				newItem.SubItems.Add(this.VectorLevelColorManager1.m_ColorItems[i].myValueText);
				System.Windows.Forms.ListViewItem.ListViewSubItem lineSubItem = newItem.SubItems.Add(this.VectorLevelColorManager1.m_ColorItems[i].myValue.ToString("F2"));
				lineSubItem.Tag = this.VectorLevelColorManager1.m_ColorItems[i].myColor;
				System.Windows.Forms.ListViewItem.ListViewSubItem fillSubItem = newItem.SubItems.Add(this.VectorLevelColorManager2.m_ColorItems[i].myValue.ToString("F2"));
				fillSubItem.Tag = this.VectorLevelColorManager2.m_ColorItems[i].myColor;
			}
			if (this.listViewColorItem.Items.Count != 0)
			{
				this.listViewColorItem.Items[0].Selected = true;
			}
		}

		private void ApplyColorItems()
		{
			this.VectorLevelColorManager1.m_ColorItems.Clear();
			this.VectorLevelColorManager2.m_ColorItems.Clear();
			for (int i = 0; i < this.listViewColorItem.Items.Count; i++)
			{
				string Name = this.listViewColorItem.Items[i].SubItems[1].Text;
				float MinValue = System.Convert.ToSingle(this.listViewColorItem.Items[i].SubItems[2].Text);
				float MaxValue = System.Convert.ToSingle(this.listViewColorItem.Items[i].SubItems[3].Text);
				System.Drawing.Color curveColor = (System.Drawing.Color)this.listViewColorItem.Items[i].SubItems[2].Tag;
				System.Drawing.Color fillColor = (System.Drawing.Color)this.listViewColorItem.Items[i].SubItems[3].Tag;
				wMetroGIS.wColorManager.ColorItem curveItem = new wMetroGIS.wColorManager.ColorItem(curveColor, MinValue, Name);
				wMetroGIS.wColorManager.ColorItem fillItem = new wMetroGIS.wColorManager.ColorItem(fillColor, MaxValue, Name);
				this.VectorLevelColorManager1.m_ColorItems.Add(curveItem);
				this.VectorLevelColorManager2.m_ColorItems.Add(fillItem);
			}
		}

		private void ShowPreview()
		{
			System.Drawing.Bitmap previewBitmap = new System.Drawing.Bitmap(this.pictureBoxPreview.Size.Width, this.pictureBoxPreview.Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(previewBitmap);
			g.FillRectangle(new System.Drawing.SolidBrush(System.Drawing.Color.White), new System.Drawing.Rectangle(0, 0, previewBitmap.Width, previewBitmap.Height));
			int BlockWidth = (previewBitmap.Width - 10) / this.listViewColorItem.Items.Count;
			float a150 = (float)((double)this.trackBarArrowAngle.Value * 3.1416 / 180.0);
			for (int i = 0; i < this.listViewColorItem.Items.Count; i++)
			{
				System.Drawing.Pen ArrowPen;
				if (this.radioButtonUseDefaultColor.Checked)
				{
					ArrowPen = new System.Drawing.Pen(this.pictureBoxDefaultColor.BackColor, (float)((int)this.numericUpDownArrowWidth.Value));
				}
				else
				{
					ArrowPen = new System.Drawing.Pen((System.Drawing.Color)this.listViewColorItem.Items[i].SubItems[2].Tag, (float)((int)this.numericUpDownArrowWidth.Value));
				}
				int ArrowLen = 10 * (i + 1);
				int X = i * BlockWidth + BlockWidth / 2;
				int Y = previewBitmap.Height - 5;
				int X2 = i * BlockWidth + BlockWidth / 2;
				int Y2 = previewBitmap.Height - 5 - ArrowLen;
				if (this.VectorArrowType == 1)
				{
					VectorParams.DrawArrow(g, ArrowPen, ArrowLen, a150, X, Y, X2, Y2);
				}
				else if (this.VectorArrowType == 2)
				{
					double j;
					double a151;
					Mathmatics.UVToMA(0.0, (double)(i * 4 + 4), out j, out a151);
					int fs = System.Convert.ToInt32(j);
					int fx = System.Convert.ToInt32(a151);
					VectorParams.DrawWind(g, ArrowPen, ArrowLen, fs, (float)fx, X, Y);
				}
			}
			g.Dispose();
			this.pictureBoxPreview.Image = previewBitmap;
		}

		private void buttonChoseVectorColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxVectorColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxVectorColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonChoseDefaultColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxDefaultColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxDefaultColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.ApplyVectorParams();
			if (this.m_VectorParams.SaveParams())
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
				this.pictureBoxVectorColor.BackColor = (System.Drawing.Color)selectedItem.SubItems[2].Tag;
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
				lineSubItem.Tag = this.pictureBoxVectorColor.BackColor;
				System.Windows.Forms.ListViewItem.ListViewSubItem fillSubItem = newItem.SubItems.Add(this.numericUpDownColorValueMax.Value.ToString("F2"));
				fillSubItem.Tag = this.pictureBoxVectorColor.BackColor;
				this.listViewColorItem.Items[this.listViewColorItem.Items.Count - 1].Selected = true;
			}
			this.buttonXModifyColor.Enabled = this.listViewColorItem.Enabled;
			this.buttonX3DeleteColor.Enabled = this.listViewColorItem.Enabled;
			this.buttonXClearColor.Enabled = this.listViewColorItem.Enabled;
			this.buttonOK.Enabled = this.listViewColorItem.Enabled;
			this.buttonCancel.Enabled = this.listViewColorItem.Enabled;
			this.buttonChoseVectorColor.Enabled = !this.listViewColorItem.Enabled;
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
					selectedItem.SubItems[2].Tag = this.pictureBoxVectorColor.BackColor;
				}
				this.buttonXAddColor.Enabled = this.listViewColorItem.Enabled;
				this.buttonX3DeleteColor.Enabled = this.listViewColorItem.Enabled;
				this.buttonXClearColor.Enabled = this.listViewColorItem.Enabled;
				this.buttonOK.Enabled = this.listViewColorItem.Enabled;
				this.buttonCancel.Enabled = this.listViewColorItem.Enabled;
				this.buttonChoseVectorColor.Enabled = !this.listViewColorItem.Enabled;
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

		private void buttonXShowPreview_Click(object sender, System.EventArgs e)
		{
			this.ShowPreview();
		}

		private void buttonXLoadDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.m_VectorParams.LoadDefaultParams())
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				this.LoadVectorParams();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
		}

		private void buttonXSaveDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.ApplyVectorParams())
			{
				if (this.m_VectorParams.SaveDefaultParams())
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
			}
		}

		private void VectorSettingForm_Load(object sender, System.EventArgs e)
		{
			this.Text = System.IO.Path.GetFileNameWithoutExtension(this.m_VectorParams.ParamFilePath) + " 矢量场参数设置";
		}

		private void radioButtonTypeWind_CheckedChanged(object sender, System.EventArgs e)
		{
			if (this.radioButtonTypeWind.Checked)
			{
				this.radioButtonAutoLength.Enabled = false;
				this.radioButtonLevelLength.Enabled = false;
				this.radioButtonDefaultLength.Checked = true;
			}
			else
			{
				this.radioButtonAutoLength.Enabled = true;
				this.radioButtonLevelLength.Enabled = true;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VectorSettingForm));
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.buttonXSaveDefaultParams = new ButtonX();
			this.buttonXLoadDefaultParams = new ButtonX();
			this.groupPanel5 = new GroupPanel();
			this.numericUpDownColorValueMax = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownColorValueMin = new System.Windows.Forms.NumericUpDown();
			this.textBoxColorText = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.buttonXClearColor = new ButtonX();
			this.listViewColorItem = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonX3DeleteColor = new ButtonX();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonXAddColor = new ButtonX();
			this.buttonXModifyColor = new ButtonX();
			this.label6 = new System.Windows.Forms.Label();
			this.buttonChoseVectorColor = new System.Windows.Forms.Button();
			this.pictureBoxVectorColor = new System.Windows.Forms.PictureBox();
			this.textBoxXFilePath = new TextBoxX();
			this.buttonCancel = new ButtonX();
			this.buttonXShowPreview = new ButtonX();
			this.buttonOK = new ButtonX();
			this.groupPanel2 = new GroupPanel();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.groupPanel4 = new GroupPanel();
			this.pictureBoxDefaultColor = new System.Windows.Forms.PictureBox();
			this.radioButtonUseDefaultColor = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonChoseDeaultColor = new System.Windows.Forms.Button();
			this.radioButtonUseLevelColor = new System.Windows.Forms.RadioButton();
			this.groupPanel3 = new GroupPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.radioButtonLevelLength = new System.Windows.Forms.RadioButton();
			this.radioButtonAutoLength = new System.Windows.Forms.RadioButton();
			this.numericUpDownArrowLength = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownArrowWidth = new System.Windows.Forms.NumericUpDown();
			this.radioButtonDefaultLength = new System.Windows.Forms.RadioButton();
			this.label13 = new System.Windows.Forms.Label();
			this.trackBarArrowAngle = new Slider();
			this.label9 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.label10 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.radioButtonTypeArrow = new System.Windows.Forms.RadioButton();
			this.radioButtonTypeWind = new System.Windows.Forms.RadioButton();
			this.ribbonClientPanel1.SuspendLayout();
			this.groupPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorValueMax).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorValueMin).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxVectorColor).BeginInit();
			this.groupPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).BeginInit();
			this.groupPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxDefaultColor).BeginInit();
			this.groupPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownArrowLength).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownArrowWidth).BeginInit();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.ribbonClientPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.buttonXSaveDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.buttonXLoadDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel5);
			this.ribbonClientPanel1.Controls.Add(this.textBoxXFilePath);
			this.ribbonClientPanel1.Controls.Add(this.buttonCancel);
			this.ribbonClientPanel1.Controls.Add(this.buttonXShowPreview);
			this.ribbonClientPanel1.Controls.Add(this.buttonOK);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel2);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel4);
			this.ribbonClientPanel1.Controls.Add(this.groupPanel3);
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(875, 529);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.TabIndex = 38;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.buttonXSaveDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXSaveDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXSaveDefaultParams.Image = (System.Drawing.Image)resources.GetObject("buttonXSaveDefaultParams.Image");
			this.buttonXSaveDefaultParams.Location = new System.Drawing.Point(682, 144);
			this.buttonXSaveDefaultParams.Name = "buttonXSaveDefaultParams";
			this.buttonXSaveDefaultParams.Size = new System.Drawing.Size(176, 50);
			this.buttonXSaveDefaultParams.TabIndex = 39;
			this.buttonXSaveDefaultParams.Text = "保存为默认参数";
			this.buttonXSaveDefaultParams.Click += new System.EventHandler(this.buttonXSaveDefaultParams_Click);
			this.buttonXLoadDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXLoadDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXLoadDefaultParams.Image = (System.Drawing.Image)resources.GetObject("buttonXLoadDefaultParams.Image");
			this.buttonXLoadDefaultParams.Location = new System.Drawing.Point(682, 85);
			this.buttonXLoadDefaultParams.Name = "buttonXLoadDefaultParams";
			this.buttonXLoadDefaultParams.Size = new System.Drawing.Size(176, 50);
			this.buttonXLoadDefaultParams.TabIndex = 38;
			this.buttonXLoadDefaultParams.Text = "载入默认参数";
			this.buttonXLoadDefaultParams.Click += new System.EventHandler(this.buttonXLoadDefaultParams_Click);
			this.groupPanel5.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel5.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel5.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel5.Controls.Add(this.numericUpDownColorValueMax);
			this.groupPanel5.Controls.Add(this.numericUpDownColorValueMin);
			this.groupPanel5.Controls.Add(this.textBoxColorText);
			this.groupPanel5.Controls.Add(this.label8);
			this.groupPanel5.Controls.Add(this.buttonXClearColor);
			this.groupPanel5.Controls.Add(this.listViewColorItem);
			this.groupPanel5.Controls.Add(this.label3);
			this.groupPanel5.Controls.Add(this.buttonX3DeleteColor);
			this.groupPanel5.Controls.Add(this.label1);
			this.groupPanel5.Controls.Add(this.buttonXAddColor);
			this.groupPanel5.Controls.Add(this.buttonXModifyColor);
			this.groupPanel5.Controls.Add(this.label6);
			this.groupPanel5.Controls.Add(this.buttonChoseVectorColor);
			this.groupPanel5.Controls.Add(this.pictureBoxVectorColor);
			this.groupPanel5.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel5.Location = new System.Drawing.Point(12, 12);
			this.groupPanel5.Name = "groupPanel5";
			this.groupPanel5.Size = new System.Drawing.Size(392, 395);
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
			this.groupPanel5.Text = "矢量场等级列表";
			this.numericUpDownColorValueMax.DecimalPlaces = 2;
			this.numericUpDownColorValueMax.Enabled = false;
			this.numericUpDownColorValueMax.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDownColorValueMax.Location = new System.Drawing.Point(215, 275);
			System.Windows.Forms.NumericUpDown arg_9A4_0 = this.numericUpDownColorValueMax;
			int[] array = new int[4];
			array[0] = 999;
			arg_9A4_0.Maximum = new decimal(array);
			this.numericUpDownColorValueMax.Minimum = new decimal(new int[]
			{
				999,
				0,
				0,
				-2147483648
			});
			this.numericUpDownColorValueMax.Name = "numericUpDownColorValueMax";
			this.numericUpDownColorValueMax.Size = new System.Drawing.Size(94, 26);
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
			this.numericUpDownColorValueMin.Location = new System.Drawing.Point(93, 275);
			System.Windows.Forms.NumericUpDown arg_A86_0 = this.numericUpDownColorValueMin;
			array = new int[4];
			array[0] = 999;
			arg_A86_0.Maximum = new decimal(array);
			this.numericUpDownColorValueMin.Minimum = new decimal(new int[]
			{
				999,
				0,
				0,
				-2147483648
			});
			this.numericUpDownColorValueMin.Name = "numericUpDownColorValueMin";
			this.numericUpDownColorValueMin.Size = new System.Drawing.Size(94, 26);
			this.numericUpDownColorValueMin.TabIndex = 25;
			this.numericUpDownColorValueMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBoxColorText.Location = new System.Drawing.Point(67, 242);
			this.textBoxColorText.Name = "textBoxColorText";
			this.textBoxColorText.ReadOnly = true;
			this.textBoxColorText.Size = new System.Drawing.Size(107, 26);
			this.textBoxColorText.TabIndex = 26;
			this.textBoxColorText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label8.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label8.Location = new System.Drawing.Point(186, 280);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(23, 19);
			this.label8.TabIndex = 22;
			this.label8.Text = "～";
			this.buttonXClearColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXClearColor.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXClearColor.Image = Resources.a008;
			this.buttonXClearColor.Location = new System.Drawing.Point(289, 313);
			this.buttonXClearColor.Name = "buttonXClearColor";
			this.buttonXClearColor.Size = new System.Drawing.Size(85, 44);
			this.buttonXClearColor.TabIndex = 35;
			this.buttonXClearColor.Text = "清空";
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
			this.listViewColorItem.Location = new System.Drawing.Point(14, 11);
			this.listViewColorItem.MultiSelect = false;
			this.listViewColorItem.Name = "listViewColorItem";
			this.listViewColorItem.Size = new System.Drawing.Size(359, 225);
			this.listViewColorItem.TabIndex = 0;
			this.listViewColorItem.UseCompatibleStateImageBehavior = false;
			this.listViewColorItem.View = System.Windows.Forms.View.Details;
			this.listViewColorItem.SelectedIndexChanged += new System.EventHandler(this.listViewColorItem_SelectedIndexChanged);
			this.columnHeader1.Text = "序号";
			this.columnHeader1.Width = 40;
			this.columnHeader2.Text = "文字";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 122;
			this.columnHeader3.Text = "最小值";
			this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader3.Width = 86;
			this.columnHeader4.Text = "最大值";
			this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader4.Width = 98;
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label3.Location = new System.Drawing.Point(18, 277);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(79, 19);
			this.label3.TabIndex = 22;
			this.label3.Text = "数值范围：";
			this.buttonX3DeleteColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonX3DeleteColor.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonX3DeleteColor.Image = Resources.Minus;
			this.buttonX3DeleteColor.Location = new System.Drawing.Point(198, 313);
			this.buttonX3DeleteColor.Name = "buttonX3DeleteColor";
			this.buttonX3DeleteColor.Size = new System.Drawing.Size(85, 44);
			this.buttonX3DeleteColor.TabIndex = 34;
			this.buttonX3DeleteColor.Text = "删除";
			this.buttonX3DeleteColor.Click += new System.EventHandler(this.buttonX3DeleteColor_Click);
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label1.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label1.Location = new System.Drawing.Point(18, 245);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 19);
			this.label1.TabIndex = 22;
			this.label1.Text = "名称：";
			this.buttonXAddColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXAddColor.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXAddColor.Image = Resources.Plus;
			this.buttonXAddColor.Location = new System.Drawing.Point(16, 313);
			this.buttonXAddColor.Name = "buttonXAddColor";
			this.buttonXAddColor.Size = new System.Drawing.Size(85, 44);
			this.buttonXAddColor.TabIndex = 37;
			this.buttonXAddColor.Text = "添加";
			this.buttonXAddColor.Click += new System.EventHandler(this.buttonXAddColor_Click);
			this.buttonXModifyColor.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXModifyColor.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXModifyColor.Image = Resources.未标题_1;
			this.buttonXModifyColor.Location = new System.Drawing.Point(107, 313);
			this.buttonXModifyColor.Name = "buttonXModifyColor";
			this.buttonXModifyColor.Size = new System.Drawing.Size(85, 44);
			this.buttonXModifyColor.TabIndex = 36;
			this.buttonXModifyColor.Text = "修改";
			this.buttonXModifyColor.Click += new System.EventHandler(this.buttonXModifyColor_Click);
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label6.Location = new System.Drawing.Point(186, 246);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(51, 19);
			this.label6.TabIndex = 22;
			this.label6.Text = "颜色：";
			this.buttonChoseVectorColor.Enabled = false;
			this.buttonChoseVectorColor.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonChoseVectorColor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.buttonChoseVectorColor.Location = new System.Drawing.Point(312, 242);
			this.buttonChoseVectorColor.Name = "buttonChoseVectorColor";
			this.buttonChoseVectorColor.Size = new System.Drawing.Size(62, 27);
			this.buttonChoseVectorColor.TabIndex = 21;
			this.buttonChoseVectorColor.Text = "选择";
			this.buttonChoseVectorColor.UseVisualStyleBackColor = true;
			this.buttonChoseVectorColor.Click += new System.EventHandler(this.buttonChoseVectorColor_Click);
			this.pictureBoxVectorColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxVectorColor.Location = new System.Drawing.Point(237, 242);
			this.pictureBoxVectorColor.Name = "pictureBoxVectorColor";
			this.pictureBoxVectorColor.Size = new System.Drawing.Size(71, 26);
			this.pictureBoxVectorColor.TabIndex = 23;
			this.pictureBoxVectorColor.TabStop = false;
			this.textBoxXFilePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.textBoxXFilePath.Border.Class = "TextBoxBorder";
			this.textBoxXFilePath.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.textBoxXFilePath.Location = new System.Drawing.Point(12, 413);
			this.textBoxXFilePath.Multiline = true;
			this.textBoxXFilePath.Name = "textBoxXFilePath";
			this.textBoxXFilePath.Size = new System.Drawing.Size(392, 101);
			this.textBoxXFilePath.TabIndex = 31;
			this.textBoxXFilePath.Text = "数据路径：";
			this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonCancel.Image = Resources.Cancel;
			this.buttonCancel.Location = new System.Drawing.Point(682, 262);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(176, 50);
			this.buttonCancel.TabIndex = 28;
			this.buttonCancel.Text = "取\u3000消";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.buttonXShowPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXShowPreview.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXShowPreview.Image = Resources.未标题_1;
			this.buttonXShowPreview.Location = new System.Drawing.Point(682, 26);
			this.buttonXShowPreview.Name = "buttonXShowPreview";
			this.buttonXShowPreview.Size = new System.Drawing.Size(176, 50);
			this.buttonXShowPreview.TabIndex = 28;
			this.buttonXShowPreview.Text = "显示预览";
			this.buttonXShowPreview.Click += new System.EventHandler(this.buttonXShowPreview_Click);
			this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonOK.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonOK.Image = Resources.OK;
			this.buttonOK.Location = new System.Drawing.Point(682, 203);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(176, 50);
			this.buttonOK.TabIndex = 28;
			this.buttonOK.Text = "确\u3000定";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel2.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel2.Controls.Add(this.pictureBoxPreview);
			this.groupPanel2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel2.Location = new System.Drawing.Point(410, 380);
			this.groupPanel2.Name = "groupPanel2";
			this.groupPanel2.Size = new System.Drawing.Size(448, 134);
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
			this.pictureBoxPreview.Size = new System.Drawing.Size(436, 99);
			this.pictureBoxPreview.TabIndex = 0;
			this.pictureBoxPreview.TabStop = false;
			this.groupPanel4.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel4.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel4.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel4.Controls.Add(this.pictureBoxDefaultColor);
			this.groupPanel4.Controls.Add(this.radioButtonUseDefaultColor);
			this.groupPanel4.Controls.Add(this.label2);
			this.groupPanel4.Controls.Add(this.buttonChoseDeaultColor);
			this.groupPanel4.Controls.Add(this.radioButtonUseLevelColor);
			this.groupPanel4.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel4.Location = new System.Drawing.Point(410, 9);
			this.groupPanel4.Name = "groupPanel4";
			this.groupPanel4.Size = new System.Drawing.Size(266, 109);
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
			this.groupPanel4.Text = "矢量箭头颜色";
			this.pictureBoxDefaultColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxDefaultColor.Location = new System.Drawing.Point(93, 39);
			this.pictureBoxDefaultColor.Name = "pictureBoxDefaultColor";
			this.pictureBoxDefaultColor.Size = new System.Drawing.Size(78, 26);
			this.pictureBoxDefaultColor.TabIndex = 23;
			this.pictureBoxDefaultColor.TabStop = false;
			this.radioButtonUseDefaultColor.AutoSize = true;
			this.radioButtonUseDefaultColor.Checked = true;
			this.radioButtonUseDefaultColor.Location = new System.Drawing.Point(22, 10);
			this.radioButtonUseDefaultColor.Name = "radioButtonUseDefaultColor";
			this.radioButtonUseDefaultColor.Size = new System.Drawing.Size(111, 23);
			this.radioButtonUseDefaultColor.TabIndex = 29;
			this.radioButtonUseDefaultColor.TabStop = true;
			this.radioButtonUseDefaultColor.Text = "使用默认颜色";
			this.radioButtonUseDefaultColor.UseVisualStyleBackColor = true;
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label2.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label2.Location = new System.Drawing.Point(18, 43);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(79, 19);
			this.label2.TabIndex = 22;
			this.label2.Text = "默认颜色：";
			this.buttonChoseDeaultColor.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonChoseDeaultColor.ForeColor = System.Drawing.SystemColors.WindowText;
			this.buttonChoseDeaultColor.Location = new System.Drawing.Point(177, 39);
			this.buttonChoseDeaultColor.Name = "buttonChoseDeaultColor";
			this.buttonChoseDeaultColor.Size = new System.Drawing.Size(62, 27);
			this.buttonChoseDeaultColor.TabIndex = 21;
			this.buttonChoseDeaultColor.Text = "选\u3000择";
			this.buttonChoseDeaultColor.UseVisualStyleBackColor = true;
			this.buttonChoseDeaultColor.Click += new System.EventHandler(this.buttonChoseDefaultColor_Click);
			this.radioButtonUseLevelColor.AutoSize = true;
			this.radioButtonUseLevelColor.Location = new System.Drawing.Point(139, 10);
			this.radioButtonUseLevelColor.Name = "radioButtonUseLevelColor";
			this.radioButtonUseLevelColor.Size = new System.Drawing.Size(111, 23);
			this.radioButtonUseLevelColor.TabIndex = 29;
			this.radioButtonUseLevelColor.Text = "使用分级颜色";
			this.radioButtonUseLevelColor.UseVisualStyleBackColor = true;
			this.groupPanel3.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel3.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel3.Controls.Add(this.panel1);
			this.groupPanel3.Controls.Add(this.label4);
			this.groupPanel3.Controls.Add(this.radioButtonLevelLength);
			this.groupPanel3.Controls.Add(this.radioButtonAutoLength);
			this.groupPanel3.Controls.Add(this.numericUpDownArrowLength);
			this.groupPanel3.Controls.Add(this.numericUpDownArrowWidth);
			this.groupPanel3.Controls.Add(this.radioButtonDefaultLength);
			this.groupPanel3.Controls.Add(this.label13);
			this.groupPanel3.Controls.Add(this.trackBarArrowAngle);
			this.groupPanel3.Controls.Add(this.label10);
			this.groupPanel3.Controls.Add(this.label9);
			this.groupPanel3.Controls.Add(this.label7);
			this.groupPanel3.Controls.Add(this.label5);
			this.groupPanel3.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel3.Location = new System.Drawing.Point(410, 124);
			this.groupPanel3.Name = "groupPanel3";
			this.groupPanel3.Size = new System.Drawing.Size(266, 250);
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
			this.groupPanel3.Text = "矢量箭头形状";
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label4.Location = new System.Drawing.Point(185, 101);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(37, 19);
			this.label4.TabIndex = 28;
			this.label4.Text = "经距";
			this.radioButtonLevelLength.AutoSize = true;
			this.radioButtonLevelLength.Location = new System.Drawing.Point(93, 155);
			this.radioButtonLevelLength.Name = "radioButtonLevelLength";
			this.radioButtonLevelLength.Size = new System.Drawing.Size(111, 23);
			this.radioButtonLevelLength.TabIndex = 29;
			this.radioButtonLevelLength.Text = "使用分级长度";
			this.radioButtonLevelLength.UseVisualStyleBackColor = true;
			this.radioButtonAutoLength.AutoSize = true;
			this.radioButtonAutoLength.Checked = true;
			this.radioButtonAutoLength.Location = new System.Drawing.Point(93, 131);
			this.radioButtonAutoLength.Name = "radioButtonAutoLength";
			this.radioButtonAutoLength.Size = new System.Drawing.Size(111, 23);
			this.radioButtonAutoLength.TabIndex = 29;
			this.radioButtonAutoLength.TabStop = true;
			this.radioButtonAutoLength.Text = "使用自动长度";
			this.radioButtonAutoLength.UseVisualStyleBackColor = true;
			this.numericUpDownArrowLength.DecimalPlaces = 3;
			this.numericUpDownArrowLength.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.numericUpDownArrowLength.Location = new System.Drawing.Point(93, 99);
			System.Windows.Forms.NumericUpDown arg_22F4_0 = this.numericUpDownArrowLength;
			array = new int[4];
			array[0] = 10;
			arg_22F4_0.Maximum = new decimal(array);
			this.numericUpDownArrowLength.Minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				196608
			});
			this.numericUpDownArrowLength.Name = "numericUpDownArrowLength";
			this.numericUpDownArrowLength.Size = new System.Drawing.Size(91, 26);
			this.numericUpDownArrowLength.TabIndex = 30;
			this.numericUpDownArrowLength.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numericUpDownArrowLength.Value = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDownArrowWidth.Location = new System.Drawing.Point(93, 37);
			System.Windows.Forms.NumericUpDown arg_23B2_0 = this.numericUpDownArrowWidth;
			array = new int[4];
			array[0] = 10;
			arg_23B2_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_23CF_0 = this.numericUpDownArrowWidth;
			array = new int[4];
			array[0] = 1;
			arg_23CF_0.Minimum = new decimal(array);
			this.numericUpDownArrowWidth.Name = "numericUpDownArrowWidth";
			this.numericUpDownArrowWidth.ReadOnly = true;
			this.numericUpDownArrowWidth.Size = new System.Drawing.Size(86, 26);
			this.numericUpDownArrowWidth.TabIndex = 30;
			this.numericUpDownArrowWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_243A_0 = this.numericUpDownArrowWidth;
			array = new int[4];
			array[0] = 1;
			arg_243A_0.Value = new decimal(array);
			this.radioButtonDefaultLength.AutoSize = true;
			this.radioButtonDefaultLength.Location = new System.Drawing.Point(93, 180);
			this.radioButtonDefaultLength.Name = "radioButtonDefaultLength";
			this.radioButtonDefaultLength.Size = new System.Drawing.Size(111, 23);
			this.radioButtonDefaultLength.TabIndex = 29;
			this.radioButtonDefaultLength.Text = "使用同一长度";
			this.radioButtonDefaultLength.UseVisualStyleBackColor = true;
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label13.Location = new System.Drawing.Point(18, 39);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(79, 19);
			this.label13.TabIndex = 28;
			this.label13.Text = "箭头粗细：";
			this.trackBarArrowAngle.LabelVisible = false;
			this.trackBarArrowAngle.Location = new System.Drawing.Point(93, 63);
			this.trackBarArrowAngle.Maximum = 180;
			this.trackBarArrowAngle.Minimum = 100;
			this.trackBarArrowAngle.Name = "trackBarArrowAngle";
			this.trackBarArrowAngle.Size = new System.Drawing.Size(146, 32);
			this.trackBarArrowAngle.TabIndex = 28;
			this.trackBarArrowAngle.Text = "slider1";
			this.trackBarArrowAngle.Value = 150;
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label9.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label9.Location = new System.Drawing.Point(18, 133);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(79, 19);
			this.label9.TabIndex = 26;
			this.label9.Text = "长度类型：";
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label7.Location = new System.Drawing.Point(18, 70);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(79, 19);
			this.label7.TabIndex = 26;
			this.label7.Text = "箭头张角：";
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label5.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label5.Location = new System.Drawing.Point(18, 101);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 19);
			this.label5.TabIndex = 26;
			this.label5.Text = "箭头长度：";
			this.colorDialog.AnyColor = true;
			this.colorDialog.FullOpen = true;
			this.imageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList.ImageStream");
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "colorbar0.bmp");
			this.imageList.Images.SetKeyName(1, "colorbar1.bmp");
			this.imageList.Images.SetKeyName(2, "colorbar2.bmp");
			this.imageList.Images.SetKeyName(3, "colorbar3.bmp");
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label10.ForeColor = System.Drawing.SystemColors.WindowText;
			this.label10.Location = new System.Drawing.Point(18, 9);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(79, 19);
			this.label10.TabIndex = 26;
			this.label10.Text = "显示样式：";
			this.panel1.Controls.Add(this.radioButtonTypeWind);
			this.panel1.Controls.Add(this.radioButtonTypeArrow);
			this.panel1.Location = new System.Drawing.Point(93, 5);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(156, 26);
			this.panel1.TabIndex = 31;
			this.radioButtonTypeArrow.AutoSize = true;
			this.radioButtonTypeArrow.Checked = true;
			this.radioButtonTypeArrow.Location = new System.Drawing.Point(3, 2);
			this.radioButtonTypeArrow.Name = "radioButtonTypeArrow";
			this.radioButtonTypeArrow.Size = new System.Drawing.Size(69, 23);
			this.radioButtonTypeArrow.TabIndex = 29;
			this.radioButtonTypeArrow.TabStop = true;
			this.radioButtonTypeArrow.Text = "流箭头";
			this.radioButtonTypeArrow.UseVisualStyleBackColor = true;
			this.radioButtonTypeWind.AutoSize = true;
			this.radioButtonTypeWind.Checked = true;
			this.radioButtonTypeWind.Location = new System.Drawing.Point(77, 2);
			this.radioButtonTypeWind.Name = "radioButtonTypeWind";
			this.radioButtonTypeWind.Size = new System.Drawing.Size(69, 23);
			this.radioButtonTypeWind.TabIndex = 29;
			this.radioButtonTypeWind.TabStop = true;
			this.radioButtonTypeWind.Text = "风向杆";
			this.radioButtonTypeWind.UseVisualStyleBackColor = true;
			this.radioButtonTypeWind.CheckedChanged += new System.EventHandler(this.radioButtonTypeWind_CheckedChanged);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(872, 529);
			base.ControlBox = false;
			base.Controls.Add(this.ribbonClientPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "VectorSettingForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "矢量场参数设置";
			base.Load += new System.EventHandler(this.VectorSettingForm_Load);
			this.ribbonClientPanel1.ResumeLayout(false);
			this.groupPanel5.ResumeLayout(false);
			this.groupPanel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorValueMax).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorValueMin).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxVectorColor).EndInit();
			this.groupPanel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).EndInit();
			this.groupPanel4.ResumeLayout(false);
			this.groupPanel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxDefaultColor).EndInit();
			this.groupPanel3.ResumeLayout(false);
			this.groupPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownArrowLength).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownArrowWidth).EndInit();
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
