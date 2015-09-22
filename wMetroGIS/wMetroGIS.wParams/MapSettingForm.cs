using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Ribbon;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using wMetroGIS.Properties;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wParams
{
	public class MapSettingForm : System.Windows.Forms.Form
	{
		public MapParams m_MapParams;

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.ColorDialog colorDialog;

		private System.Windows.Forms.ImageList imageList;

		private System.Windows.Forms.CheckBox checkBoxWantCity;

		private System.Windows.Forms.PictureBox pictureBoxCityTextColorFore;

		private System.Windows.Forms.NumericUpDown numericUpDownCityTextHeight;

		private System.Windows.Forms.Label label19;

		private System.Windows.Forms.Button buttonCityTextColorFore;

		private System.Windows.Forms.Label label20;

		private System.Windows.Forms.ComboBox comboBoxLonLatLineStyle;

		private System.Windows.Forms.CheckBox checkBoxWantLonLat;

		private System.Windows.Forms.NumericUpDown numericUpDownLonLatTextHeight;

		private System.Windows.Forms.NumericUpDown numericUpDownLonLatLineWidth;

		private System.Windows.Forms.PictureBox pictureBoxLonLatTextColor;

		private System.Windows.Forms.PictureBox pictureBoxLonLatLineColor;

		private System.Windows.Forms.Label label16;

		private System.Windows.Forms.Label label15;

		private System.Windows.Forms.Label label12;

		private System.Windows.Forms.Button buttonLonLatTextColor;

		private System.Windows.Forms.Button buttonLonLatLineColor;

		private System.Windows.Forms.Label label13;

		private System.Windows.Forms.Label label14;

		private System.Windows.Forms.CheckBox checkBoxFillBoundary;

		private System.Windows.Forms.CheckBox checkBoxWantBoundary;

		private System.Windows.Forms.ComboBox comboBoxBoundaryLineStyle;

		private System.Windows.Forms.NumericUpDown numericUpDownBoundaryLineWidth;

		private System.Windows.Forms.Button buttonAreaColor;

		private System.Windows.Forms.Label label9;

		private System.Windows.Forms.Label label8;

		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.Button buttonLineColor;

		private System.Windows.Forms.Label label6;

		private System.Windows.Forms.PictureBox pictureBoxBoundaryAreaColor;

		private System.Windows.Forms.Label label7;

		private System.Windows.Forms.PictureBox pictureBoxBoundaryLineColor;

		private System.Windows.Forms.Label labelAlpha;

		private System.Windows.Forms.CheckBox checkBoxWantBackgroundImage;

		private System.Windows.Forms.Button buttonBackgroundColor;

		private System.Windows.Forms.PictureBox pictureBoxBackgroundColor;

		private System.Windows.Forms.Label label11;

		private System.Windows.Forms.Label label21;

		private System.Windows.Forms.Label label10;

		private System.Windows.Forms.Label labelZoom;

		private RibbonClientPanel ribbonClientPanel1;

		private DevComponents.DotNetBar.TabControl tabControl1;

		private TabControlPanel tabControlPanel4;

		private TabItem tabItem4;

		private TabControlPanel tabControlPanel3;

		private TabItem tabItem3;

		private TabControlPanel tabControlPanel2;

		private TabItem tabItem2;

		private TabControlPanel tabControlPanel1;

		private TabItem tabItem1;

		private TextBoxX textBoxXFilePath;

		private ButtonX buttonXCancel;

		private ButtonX buttonXOK;

		private Slider trackBarZoom;

		private Slider trackBarBoundaryAreaAlpha;

		private System.Windows.Forms.Label label22;

		private TextBoxX textBoxXLineDataPath;

		private System.Windows.Forms.Button buttonLineDataPath;

		private System.Windows.Forms.NumericUpDown numericUpDownLonLatStep;

		private System.Windows.Forms.Label label25;

		private System.Windows.Forms.Label label24;

		private System.Windows.Forms.Label label23;

		private System.Windows.Forms.Label label26;

		private System.Windows.Forms.Label label31;

		private System.Windows.Forms.OpenFileDialog openFileDialog;

		private TextBoxX textBoxXBackgroundImagePath;

		private System.Windows.Forms.Button buttontextBoxXBackgroundImagePath;

		private System.Windows.Forms.OpenFileDialog openFileDialogaMap;

		private GroupPanel groupPanelPreview;

		private ButtonX buttonXShowPreview;

		private System.Windows.Forms.PictureBox pictureBoxPreview;

		private TabControlPanel tabControlPanel5;

		private System.Windows.Forms.CheckBox checkBoxWantRiver;

		private System.Windows.Forms.ComboBox comboBoxRiverStyle;

		private System.Windows.Forms.CheckBox checkBoxWantProvince;

		private System.Windows.Forms.PictureBox pictureBoxRiverColor;

		private System.Windows.Forms.ComboBox comboBoxProvinceLineStyle;

		private System.Windows.Forms.NumericUpDown numericUpDownRiverWidth;

		private System.Windows.Forms.PictureBox pictureBoxProvinceLineColor;

		private System.Windows.Forms.Label label39;

		private System.Windows.Forms.NumericUpDown numericUpDownProvinceLineWidth;

		private System.Windows.Forms.Button buttonRiverColor;

		private System.Windows.Forms.Label label34;

		private System.Windows.Forms.Label label38;

		private System.Windows.Forms.Button buttonProvinceLineColor;

		private System.Windows.Forms.Label label37;

		private System.Windows.Forms.Label label35;

		private System.Windows.Forms.Label label36;

		private TabItem tabItem5;

		private ButtonX buttonXSaveDefaultParams;

		private ButtonX buttonXLoadDefaultParams;

		private System.Windows.Forms.NumericUpDown numericUpDownWHScale;

		private System.Windows.Forms.Label label33;

		private TabControlPanel tabControlPanel6;

		private TabItem tabItem6;

		private TabControlPanel tabControlPanel7;

		private TabItem tabItem7;

		private TabControlPanel tabControlPanel8;

		private TabItem tabItem8;

		private TabControlPanel tabControlPanel9;

		private TabItem tabItem9;

		private System.Windows.Forms.Label label32;

		private System.Windows.Forms.CheckBox checkBoxWantStation;

		private System.Windows.Forms.Label label18;

		private System.Windows.Forms.NumericUpDown numericUpDownStationTextHeight;

		private System.Windows.Forms.Button buttonStationTextColorFore1;

		private System.Windows.Forms.PictureBox pictureBoxStationTextColorFore1;

		private System.Windows.Forms.Label label17;

		private System.Windows.Forms.Button buttonCityTextColorBack;

		private System.Windows.Forms.PictureBox pictureBoxCityTextColorBack;

		private System.Windows.Forms.Label label41;

		private System.Windows.Forms.Label label42;

		private System.Windows.Forms.Button buttonStationTextColorBack1;

		private System.Windows.Forms.PictureBox pictureBoxStationTextColorBack1;

		private System.Windows.Forms.Label label43;

		private TextBoxX textBoxStationDataPath1;

		private System.Windows.Forms.Label label44;

		private TextBoxX textBoxStationDataPath2;

		private System.Windows.Forms.Label label48;

		private System.Windows.Forms.Label label47;

		private System.Windows.Forms.Button buttonStationTextColorBack2;

		private System.Windows.Forms.Button buttonStationTextColorFore2;

		private System.Windows.Forms.PictureBox pictureBoxStationTextColorBack2;

		private System.Windows.Forms.PictureBox pictureBoxStationTextColorFore2;

		private System.Windows.Forms.Label label46;

		private System.Windows.Forms.Label label45;

		private System.Windows.Forms.ListView listViewKeyArea;

		private System.Windows.Forms.ColumnHeader columnHeader1;

		private ButtonX buttonDeleteKeyArea;

		private ButtonX buttonAddKeyArea;

		private ButtonX buttonModifyKeyArea;

		private TextBoxX textBoxKeyAreaDataPath;

		private System.Windows.Forms.Label label49;

		private System.Windows.Forms.Button buttonChoseKeyAreaColor;

		private System.Windows.Forms.PictureBox pictureBoxKeyAreaColor;

		private System.Windows.Forms.Label label50;

		private Slider sliderKeyAreaAlpha;

		private System.Windows.Forms.Label labelKeyAreaAlpha;

		private System.Windows.Forms.Label label52;

		private System.Windows.Forms.Label label59;

		private System.Windows.Forms.Label label57;

		private System.Windows.Forms.Label label51;

		private System.Windows.Forms.NumericUpDown numericUpDownColorBarHeight;

		private System.Windows.Forms.Label label58;

		private System.Windows.Forms.NumericUpDown numericUpDownColorBarWidth;

		private System.Windows.Forms.Label label56;

		private System.Windows.Forms.NumericUpDown numericUpDownColorBarPosY;

		private System.Windows.Forms.Label label54;

		private System.Windows.Forms.NumericUpDown numericUpDownColorBarPosX;

		private System.Windows.Forms.Label label53;

		private System.Windows.Forms.RadioButton radioButtonByTypeUserDefine;

		private System.Windows.Forms.RadioButton radioButtonByTypeLonLat;

		private TextBoxX textBoxCoorNameY;

		private System.Windows.Forms.Label label61;

		private TextBoxX textBoxCoorNameX;

		private System.Windows.Forms.Label label60;

		private System.Windows.Forms.Label label55;

		private TabItem tabItem10;

		private System.Windows.Forms.CheckBox checkBoxShowKeyArea;

		private ButtonItem buttonItem2;

		private ButtonItem buttonItem1;

		private ButtonItem buttonSystem7;

		private ButtonItem buttonSystem6;

		private ButtonItem buttonSystem5;

		private ButtonItem buttonSystem4;

		private ButtonItem buttonSystem3;

		private ButtonItem buttonSystem2;

		private ButtonItem buttonSystem1;

		private System.Windows.Forms.CheckBox checkBoxShowStationInThumb;

		private System.Windows.Forms.Label label62;

		private System.Windows.Forms.TextBox textBoxMapTitle;

		private System.Windows.Forms.NumericUpDown numericUpDownEdgeTop;

		private System.Windows.Forms.NumericUpDown numericUpDownEdgeBottom;

		private System.Windows.Forms.NumericUpDown numericUpDownEdgeRight;

		private System.Windows.Forms.NumericUpDown numericUpDownEdgeLeft;

		private System.Windows.Forms.Label label67;

		private System.Windows.Forms.Label label65;

		private System.Windows.Forms.Label label66;

		private System.Windows.Forms.Label label64;

		private System.Windows.Forms.Label label63;

		private System.Windows.Forms.CheckBox checkBoxLonLatTextBold;

		private System.Windows.Forms.CheckBox checkBoxCityTextBold;

		private System.Windows.Forms.CheckBox checkBoxStationTextBold;

		private TabControlPanel tabControlPanel10;

		private TabItem tabItem11;

		private System.Windows.Forms.NumericUpDown numericUpDownCenterLon;

		private System.Windows.Forms.Label label73;

		private System.Windows.Forms.ComboBox comboBoxProjectionType;

		private System.Windows.Forms.Label label68;

		private GroupPanel groupPanel2;

		private System.Windows.Forms.NumericUpDown numericUpDownStandardLat;

		private System.Windows.Forms.Label label71;

		private System.Windows.Forms.NumericUpDown numericUpDownCenterLat;

		private System.Windows.Forms.NumericUpDown numericUpDownStandardLon;

		private System.Windows.Forms.Label label69;

		private System.Windows.Forms.Label label70;

		private GroupPanel groupPanel1;

		private System.Windows.Forms.NumericUpDown numericUpDownPicHeight;

		private System.Windows.Forms.NumericUpDown numericUpDownPicWidth;

		private System.Windows.Forms.Label label75;

		private System.Windows.Forms.Label label74;

		private System.Windows.Forms.Label label72;

		public string BoundaryDataPath
		{
			get
			{
				string result;
				if (this.textBoxXLineDataPath.Text == "")
				{
					result = "";
				}
				else if (System.IO.Path.GetDirectoryName(this.textBoxXLineDataPath.Text).Length == 0)
				{
					result = System.IO.Path.GetDirectoryName(this.m_MapParams.ParamFilePath) + "\\" + this.textBoxXLineDataPath.Text;
				}
				else
				{
					result = this.textBoxXLineDataPath.Text;
				}
				return result;
			}
			set
			{
				if (value == "")
				{
					this.textBoxXLineDataPath.Text = "";
				}
				else if (System.IO.Path.GetDirectoryName(value) == System.IO.Path.GetDirectoryName(this.m_MapParams.ParamFilePath))
				{
					this.textBoxXLineDataPath.Text = System.IO.Path.GetFileName(value);
				}
				else
				{
					this.textBoxXLineDataPath.Text = value;
				}
			}
		}

		public string BackgroundImageDataPath
		{
			get
			{
				string result;
				if (System.IO.Path.GetDirectoryName(this.textBoxXBackgroundImagePath.Text).Length == 0)
				{
					result = System.IO.Path.GetDirectoryName(this.m_MapParams.BackgroundImagePath) + "\\" + this.textBoxXBackgroundImagePath.Text;
				}
				else
				{
					result = this.textBoxXBackgroundImagePath.Text;
				}
				return result;
			}
			set
			{
				if (System.IO.Path.GetDirectoryName(value) == System.IO.Path.GetDirectoryName(this.m_MapParams.BackgroundImagePath))
				{
					this.textBoxXBackgroundImagePath.Text = System.IO.Path.GetFileName(value);
				}
				else
				{
					this.textBoxXBackgroundImagePath.Text = value;
				}
			}
		}

		public MapSettingForm()
		{
			this.InitializeComponent();
			this.m_MapParams = new MapParams();
			this.m_MapParams.LoadParams();
		}

		public MapSettingForm(MapParams mapParams)
		{
			this.InitializeComponent();
			this.m_MapParams = mapParams;
			if (this.m_MapParams == null)
			{
				System.Windows.Forms.MessageBox.Show("传入地图参数为空！使用默认参数……", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_MapParams = new MapParams();
				this.m_MapParams.LoadParams();
			}
		}

		private void SettingForm_Load(object sender, System.EventArgs e)
		{
			this.Text = System.IO.Path.GetFileNameWithoutExtension(this.m_MapParams.ParamFilePath) + " 地图参数设置";
			this.LoadParams();
			this.ShowPreview();
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			if (this.ApplyParams())
			{
				this.m_MapParams.SaveParams();
				base.DialogResult = System.Windows.Forms.DialogResult.OK;
				base.Close();
			}
		}

		private void buttonXCancel_Click(object sender, System.EventArgs e)
		{
			base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			base.Close();
		}

		private void trackBarZoom_ValueChanged(object sender, System.EventArgs e)
		{
			this.labelZoom.Text = this.trackBarZoom.Value.ToString();
		}

		private void trackBarBoundaryAreaAlpha_ValueChanged(object sender, System.EventArgs e)
		{
			this.labelAlpha.Text = this.trackBarBoundaryAreaAlpha.Value.ToString();
		}

		private void buttonBackgroundColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxBackgroundColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxBackgroundColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonLineColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxBoundaryLineColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxBoundaryLineColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonAreaColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxBoundaryAreaColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxBoundaryAreaColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonLonLatLineColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxLonLatLineColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxLonLatLineColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonLonLatTextColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxLonLatTextColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxLonLatTextColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonCityTextColorFore_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxCityTextColorFore.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxCityTextColorFore.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonCityTextColorBack_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxCityTextColorBack.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxCityTextColorBack.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonStationTextColorFore1_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxStationTextColorFore1.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxStationTextColorFore1.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonStationTextColorBack1_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxStationTextColorBack1.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxStationTextColorBack1.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonStationTextColorFore2_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxStationTextColorFore2.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxStationTextColorFore2.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonStationTextColorBack2_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxStationTextColorBack2.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxStationTextColorBack2.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonLineDataPath_Click(object sender, System.EventArgs e)
		{
			this.openFileDialog.InitialDirectory = System.IO.Path.GetDirectoryName(this.m_MapParams.ParamFilePath);
			if (this.openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.BoundaryDataPath = this.openFileDialog.FileName;
			}
		}

		private void buttontextBoxXBackgroundImagePath_Click(object sender, System.EventArgs e)
		{
			this.openFileDialogaMap.InitialDirectory = System.IO.Path.GetDirectoryName(this.m_MapParams.ParamFilePath);
			if (this.openFileDialogaMap.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.BackgroundImageDataPath = this.openFileDialogaMap.FileName;
			}
		}

		private void buttonXShowPreview_Click(object sender, System.EventArgs e)
		{
			if (this.ApplyParams())
			{
				this.ShowPreview();
			}
		}

		private void buttonProvinceLineColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxProvinceLineColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxProvinceLineColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonRiverColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxRiverColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxRiverColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonXSaveDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.ApplyParams())
			{
				if (this.m_MapParams.SaveDefaultParams())
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
			}
		}

		private void buttonXLoadDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.m_MapParams.LoadDefaultParams())
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				this.LoadParams();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
		}

		private void sliderKeyAreaAlpha_ValueChanged(object sender, System.EventArgs e)
		{
			this.labelKeyAreaAlpha.Text = this.sliderKeyAreaAlpha.Value.ToString();
		}

		private void buttonChoseKeyAreaColor_Click(object sender, System.EventArgs e)
		{
			this.colorDialog.Color = this.pictureBoxKeyAreaColor.BackColor;
			if (this.colorDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				this.pictureBoxKeyAreaColor.BackColor = this.colorDialog.Color;
			}
		}

		private void buttonAddKeyArea_Click(object sender, System.EventArgs e)
		{
			if (this.textBoxKeyAreaDataPath.Text == "")
			{
				System.Windows.Forms.MessageBox.Show("数据路径不能为空！");
			}
			else
			{
				System.Windows.Forms.ListViewItem newItem = new System.Windows.Forms.ListViewItem(this.textBoxKeyAreaDataPath.Text);
				newItem.Tag = this.pictureBoxKeyAreaColor.BackColor;
				this.listViewKeyArea.Items.Add(newItem);
				newItem.Selected = true;
			}
		}

		private void buttonDeleteKeyArea_Click(object sender, System.EventArgs e)
		{
			if (this.listViewKeyArea.SelectedItems.Count == 0)
			{
				System.Windows.Forms.MessageBox.Show("请选择要删除的一条数据！");
			}
			else if (System.Windows.Forms.MessageBox.Show("确定要删除吗？", "询问", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.No)
			{
				this.listViewKeyArea.Items.Remove(this.listViewKeyArea.SelectedItems[0]);
			}
		}

		private void buttonModifyKeyArea_Click(object sender, System.EventArgs e)
		{
			if (this.listViewKeyArea.SelectedItems.Count == 0)
			{
				System.Windows.Forms.MessageBox.Show("请选择要修改的一条数据！");
			}
			else if (this.textBoxKeyAreaDataPath.Text == "")
			{
				System.Windows.Forms.MessageBox.Show("数据路径不能为空！");
			}
			else
			{
				this.listViewKeyArea.SelectedItems[0].Text = this.textBoxKeyAreaDataPath.Text;
				this.listViewKeyArea.SelectedItems[0].Tag = this.pictureBoxKeyAreaColor.BackColor;
			}
		}

		private void listViewKeyArea_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (this.listViewKeyArea.SelectedItems.Count != 0)
			{
				this.textBoxKeyAreaDataPath.Text = this.listViewKeyArea.SelectedItems[0].Text;
				this.pictureBoxKeyAreaColor.BackColor = (System.Drawing.Color)this.listViewKeyArea.SelectedItems[0].Tag;
			}
		}

		private void ShowPreview()
		{
			Projection projectionThumb = null;
			if (this.comboBoxProjectionType.SelectedIndex == 0)
			{
				ProjectionLinear p = new ProjectionLinear((double)((float)this.numericUpDownCenterLon.Value), (double)((float)this.numericUpDownCenterLat.Value), this.pictureBoxPreview.Width / 2, this.pictureBoxPreview.Height / 2, (double)((float)this.numericUpDownWHScale.Value), (double)this.trackBarZoom.Value * 0.5);
				projectionThumb = p;
			}
			else if (this.comboBoxProjectionType.SelectedIndex == 1)
			{
				ProjectionLambert p2 = new ProjectionLambert((double)((float)this.numericUpDownStandardLon.Value), (double)((float)this.numericUpDownStandardLat.Value), (double)((float)this.numericUpDownCenterLon.Value), (double)((float)this.numericUpDownCenterLat.Value), this.pictureBoxPreview.Width / 2, this.pictureBoxPreview.Height / 2, (double)this.trackBarZoom.Value * 0.05);
				projectionThumb = p2;
			}
			else if (this.comboBoxProjectionType.SelectedIndex == 2)
			{
				ProjectionMercator p3 = new ProjectionMercator((double)((float)this.numericUpDownCenterLon.Value), (double)((float)this.numericUpDownCenterLat.Value), this.pictureBoxPreview.Width / 2, this.pictureBoxPreview.Height / 2, (double)this.trackBarZoom.Value * 0.05);
				projectionThumb = p3;
			}
			else if (this.comboBoxProjectionType.SelectedIndex == 3)
			{
				ProjectionStereogram p4 = new ProjectionStereogram((double)((float)this.numericUpDownStandardLon.Value), 90.0, (double)((float)this.numericUpDownCenterLon.Value), (double)((float)this.numericUpDownCenterLat.Value), this.pictureBoxPreview.Width / 2, this.pictureBoxPreview.Height / 2, (double)this.trackBarZoom.Value * 0.05);
				projectionThumb = p4;
			}
			this.pictureBoxPreview.Image = this.m_MapParams.DrawMap(projectionThumb, new System.Drawing.Size(this.pictureBoxPreview.Width, this.pictureBoxPreview.Height), true);
		}

		private void LoadParams()
		{
			this.textBoxXFilePath.Text = this.m_MapParams.ParamFilePath;
			this.comboBoxProjectionType.SelectedIndex = this.m_MapParams.ProjectionType - 1;
			this.numericUpDownStandardLon.Value = (decimal)this.m_MapParams.StandardLon;
			this.numericUpDownStandardLat.Value = (decimal)this.m_MapParams.StandardLat;
			this.numericUpDownCenterLon.Value = (decimal)this.m_MapParams.CenterLon;
			this.numericUpDownCenterLat.Value = (decimal)this.m_MapParams.CenterLat;
			this.textBoxMapTitle.Text = this.m_MapParams.DefaultMapTitle;
			if (this.m_MapParams.Zoom > this.trackBarZoom.Maximum)
			{
				this.trackBarZoom.Maximum = this.m_MapParams.Zoom;
				this.trackBarZoom.Enabled = false;
			}
			this.trackBarZoom.Value = this.m_MapParams.Zoom;
			this.numericUpDownWHScale.Value = (decimal)this.m_MapParams.WHScale;
			this.labelZoom.Text = this.m_MapParams.Zoom.ToString();
			this.pictureBoxBackgroundColor.BackColor = this.m_MapParams.BackgroundColor;
			this.checkBoxWantBackgroundImage.Checked = this.m_MapParams.WantBackgroundImage;
			this.BackgroundImageDataPath = this.m_MapParams.BackgroundImagePath;
			this.numericUpDownPicWidth.Value = this.m_MapParams.PicWidth;
			this.numericUpDownPicHeight.Value = this.m_MapParams.PicHeight;
			this.numericUpDownEdgeLeft.Value = this.m_MapParams.m_EdgeLeft;
			this.numericUpDownEdgeRight.Value = this.m_MapParams.m_EdgeRight;
			this.numericUpDownEdgeBottom.Value = this.m_MapParams.m_EdgeBottom;
			this.numericUpDownEdgeTop.Value = this.m_MapParams.m_EdgeTop;
			this.pictureBoxBoundaryLineColor.BackColor = this.m_MapParams.BoundaryLineColor;
			this.numericUpDownBoundaryLineWidth.Value = this.m_MapParams.BoundaryLineWidth;
			this.comboBoxBoundaryLineStyle.SelectedIndex = this.m_MapParams.DashStyleToInt(this.m_MapParams.BoundaryLineStyle);
			this.pictureBoxBoundaryAreaColor.BackColor = this.m_MapParams.BoundaryAreaColor;
			this.trackBarBoundaryAreaAlpha.Value = this.m_MapParams.BoundaryAreaAlpha;
			this.checkBoxWantBoundary.Checked = this.m_MapParams.WantBoundary;
			this.checkBoxFillBoundary.Checked = this.m_MapParams.FillBoundary;
			this.BoundaryDataPath = this.m_MapParams.BoundaryDataPath;
			this.checkBoxWantLonLat.Checked = this.m_MapParams.WantLonLat;
			this.pictureBoxLonLatLineColor.BackColor = this.m_MapParams.LonLatLineColor;
			this.numericUpDownLonLatLineWidth.Value = this.m_MapParams.LonLatLineWidth;
			this.comboBoxLonLatLineStyle.SelectedIndex = this.m_MapParams.DashStyleToInt(this.m_MapParams.LonLatLineStyle);
			this.pictureBoxLonLatTextColor.BackColor = this.m_MapParams.LonLatTextColor;
			this.numericUpDownLonLatTextHeight.Value = this.m_MapParams.LonLatTextHeight;
			this.numericUpDownLonLatStep.Value = (decimal)this.m_MapParams.LonLatStep;
			this.checkBoxLonLatTextBold.Checked = this.m_MapParams.LonLatTextBold;
			this.checkBoxWantCity.Checked = this.m_MapParams.WantCity;
			this.pictureBoxCityTextColorFore.BackColor = this.m_MapParams.CityTextColorFore;
			this.pictureBoxCityTextColorBack.BackColor = this.m_MapParams.CityTextColorBack;
			this.numericUpDownCityTextHeight.Value = this.m_MapParams.CityTextHeight;
			this.checkBoxCityTextBold.Checked = this.m_MapParams.CityTextBold;
			this.checkBoxWantStation.Checked = this.m_MapParams.WantStation;
			this.checkBoxShowStationInThumb.Checked = this.m_MapParams.ShowStationInThumb;
			this.pictureBoxStationTextColorFore1.BackColor = this.m_MapParams.StationTextColorFore1;
			this.pictureBoxStationTextColorBack1.BackColor = this.m_MapParams.StationTextColorBack1;
			this.pictureBoxStationTextColorFore2.BackColor = this.m_MapParams.StationTextColorFore2;
			this.pictureBoxStationTextColorBack2.BackColor = this.m_MapParams.StationTextColorBack2;
			this.textBoxStationDataPath1.Text = this.m_MapParams.StationDataPath1;
			this.textBoxStationDataPath2.Text = this.m_MapParams.StationDataPath2;
			this.numericUpDownStationTextHeight.Value = this.m_MapParams.StationTextHeight;
			this.checkBoxStationTextBold.Checked = this.m_MapParams.StationTextBold;
			this.checkBoxWantProvince.Checked = this.m_MapParams.WantProvince;
			this.pictureBoxProvinceLineColor.BackColor = this.m_MapParams.ProvinceLineColor;
			this.numericUpDownProvinceLineWidth.Value = this.m_MapParams.ProvinceLineWidth;
			this.comboBoxProvinceLineStyle.SelectedIndex = this.m_MapParams.DashStyleToInt(this.m_MapParams.ProvinceLineStyle);
			this.checkBoxWantRiver.Checked = this.m_MapParams.WantRiver;
			this.pictureBoxRiverColor.BackColor = this.m_MapParams.RiverColor;
			this.numericUpDownRiverWidth.Value = this.m_MapParams.RiverWidth;
			this.comboBoxRiverStyle.SelectedIndex = this.m_MapParams.DashStyleToInt(this.m_MapParams.RiverStyle);
			this.checkBoxShowKeyArea.Checked = this.m_MapParams.KeyAreaShow;
			this.sliderKeyAreaAlpha.Value = this.m_MapParams.KeyAreaAlpha;
			this.listViewKeyArea.Items.Clear();
			for (int i = 0; i < this.m_MapParams.KeyAreaDataPath.Count; i++)
			{
				System.Windows.Forms.ListViewItem newItem = new System.Windows.Forms.ListViewItem(this.m_MapParams.KeyAreaDataPath[i]);
				newItem.Tag = this.m_MapParams.KeyAreaColor[i];
				this.listViewKeyArea.Items.Add(newItem);
			}
			if (this.listViewKeyArea.Items.Count > 0)
			{
				this.listViewKeyArea.Items[0].Selected = true;
			}
			this.numericUpDownColorBarPosX.Value = this.m_MapParams.ColorBarPos.X;
			this.numericUpDownColorBarPosY.Value = this.m_MapParams.ColorBarPos.Y;
			this.numericUpDownColorBarWidth.Value = this.m_MapParams.ColorBarWidth;
			this.numericUpDownColorBarHeight.Value = this.m_MapParams.ColorBarHeight;
			this.radioButtonByTypeLonLat.Checked = this.m_MapParams.CoorUseLonLatType;
			this.radioButtonByTypeUserDefine.Checked = !this.m_MapParams.CoorUseLonLatType;
			this.textBoxCoorNameX.Text = this.m_MapParams.CoorNameX;
			this.textBoxCoorNameY.Text = this.m_MapParams.CoorNameY;
		}

		private bool ApplyParams()
		{
			bool result;
			try
			{
				this.m_MapParams.DefaultMapTitle = this.textBoxMapTitle.Text;
				this.m_MapParams.Zoom = System.Convert.ToInt32(this.trackBarZoom.Value);
				this.m_MapParams.WHScale = System.Convert.ToSingle(this.numericUpDownWHScale.Value);
				this.m_MapParams.BackgroundColor = this.pictureBoxBackgroundColor.BackColor;
				this.m_MapParams.WantBackgroundImage = this.checkBoxWantBackgroundImage.Checked;
				this.m_MapParams.BackgroundImagePath = this.textBoxXBackgroundImagePath.Text;
				this.m_MapParams.PicWidth = (int)this.numericUpDownPicWidth.Value;
				this.m_MapParams.PicHeight = (int)this.numericUpDownPicHeight.Value;
				this.m_MapParams.m_EdgeLeft = (int)this.numericUpDownEdgeLeft.Value;
				this.m_MapParams.m_EdgeRight = (int)this.numericUpDownEdgeRight.Value;
				this.m_MapParams.m_EdgeBottom = (int)this.numericUpDownEdgeBottom.Value;
				this.m_MapParams.m_EdgeTop = (int)this.numericUpDownEdgeTop.Value;
				this.m_MapParams.ProjectionType = this.comboBoxProjectionType.SelectedIndex + 1;
				this.m_MapParams.StandardLon = (float)this.numericUpDownStandardLon.Value;
				this.m_MapParams.StandardLat = (float)this.numericUpDownStandardLat.Value;
				this.m_MapParams.CenterLon = (float)this.numericUpDownCenterLon.Value;
				this.m_MapParams.CenterLat = (float)this.numericUpDownCenterLat.Value;
				if (this.m_MapParams.PicWidth > 10000 || this.m_MapParams.PicHeight > 10000)
				{
					System.Windows.Forms.MessageBox.Show("地图的尺寸太大，宽或高不能超过10000像素，请重新设置！");
					result = false;
					return result;
				}
				if (this.m_MapParams.PicWidth < 400 || this.m_MapParams.PicHeight < 400)
				{
					System.Windows.Forms.MessageBox.Show("地图的尺寸太小，宽或高不能小于400像素，请重新设置！");
					result = false;
					return result;
				}
				this.m_MapParams.BoundaryLineColor = this.pictureBoxBoundaryLineColor.BackColor;
				this.m_MapParams.BoundaryLineWidth = System.Convert.ToInt32(this.numericUpDownBoundaryLineWidth.Value);
				this.m_MapParams.BoundaryLineStyle = this.m_MapParams.IntToDashStyle(this.comboBoxBoundaryLineStyle.SelectedIndex);
				this.m_MapParams.BoundaryAreaColor = this.pictureBoxBoundaryAreaColor.BackColor;
				this.m_MapParams.BoundaryAreaAlpha = this.trackBarBoundaryAreaAlpha.Value;
				this.m_MapParams.WantBoundary = this.checkBoxWantBoundary.Checked;
				this.m_MapParams.FillBoundary = this.checkBoxFillBoundary.Checked;
				this.m_MapParams.BoundaryDataPath = this.textBoxXLineDataPath.Text;
				this.m_MapParams.WantLonLat = this.checkBoxWantLonLat.Checked;
				this.m_MapParams.LonLatLineColor = this.pictureBoxLonLatLineColor.BackColor;
				this.m_MapParams.LonLatLineWidth = System.Convert.ToInt32(this.numericUpDownLonLatLineWidth.Value);
				this.m_MapParams.LonLatLineStyle = this.m_MapParams.IntToDashStyle(this.comboBoxLonLatLineStyle.SelectedIndex);
				this.m_MapParams.LonLatTextColor = this.pictureBoxLonLatTextColor.BackColor;
				this.m_MapParams.LonLatTextHeight = System.Convert.ToInt32(this.numericUpDownLonLatTextHeight.Value);
				this.m_MapParams.LonLatStep = System.Convert.ToSingle(this.numericUpDownLonLatStep.Value);
				this.m_MapParams.LonLatTextBold = this.checkBoxLonLatTextBold.Checked;
				this.m_MapParams.WantCity = this.checkBoxWantCity.Checked;
				this.m_MapParams.CityTextColorFore = this.pictureBoxCityTextColorFore.BackColor;
				this.m_MapParams.CityTextColorBack = this.pictureBoxCityTextColorBack.BackColor;
				this.m_MapParams.CityTextHeight = System.Convert.ToInt32(this.numericUpDownCityTextHeight.Value);
				this.m_MapParams.CityTextBold = this.checkBoxCityTextBold.Checked;
				this.m_MapParams.WantStation = this.checkBoxWantStation.Checked;
				this.m_MapParams.ShowStationInThumb = this.checkBoxShowStationInThumb.Checked;
				this.m_MapParams.StationTextColorFore1 = this.pictureBoxStationTextColorFore1.BackColor;
				this.m_MapParams.StationTextColorBack1 = this.pictureBoxStationTextColorBack1.BackColor;
				this.m_MapParams.StationTextColorFore2 = this.pictureBoxStationTextColorFore2.BackColor;
				this.m_MapParams.StationTextColorBack2 = this.pictureBoxStationTextColorBack2.BackColor;
				this.m_MapParams.StationDataPath1 = this.textBoxStationDataPath1.Text;
				this.m_MapParams.StationDataPath2 = this.textBoxStationDataPath2.Text;
				this.m_MapParams.StationTextHeight = System.Convert.ToInt32(this.numericUpDownStationTextHeight.Value);
				this.m_MapParams.StationTextBold = this.checkBoxStationTextBold.Checked;
				this.m_MapParams.WantProvince = this.checkBoxWantProvince.Checked;
				this.m_MapParams.ProvinceLineColor = this.pictureBoxProvinceLineColor.BackColor;
				this.m_MapParams.ProvinceLineWidth = System.Convert.ToInt32(this.numericUpDownProvinceLineWidth.Value);
				this.m_MapParams.ProvinceLineStyle = this.m_MapParams.IntToDashStyle(this.comboBoxProvinceLineStyle.SelectedIndex);
				this.m_MapParams.WantRiver = this.checkBoxWantRiver.Checked;
				this.m_MapParams.RiverColor = this.pictureBoxRiverColor.BackColor;
				this.m_MapParams.RiverWidth = System.Convert.ToInt32(this.numericUpDownRiverWidth.Value);
				this.m_MapParams.RiverStyle = this.m_MapParams.IntToDashStyle(this.comboBoxRiverStyle.SelectedIndex);
				this.m_MapParams.KeyAreaShow = this.checkBoxShowKeyArea.Checked;
				this.m_MapParams.KeyAreaAlpha = this.sliderKeyAreaAlpha.Value;
				this.m_MapParams.KeyAreaDataPath.Clear();
				this.m_MapParams.KeyAreaColor.Clear();
				for (int i = 0; i < this.listViewKeyArea.Items.Count; i++)
				{
					this.m_MapParams.KeyAreaDataPath.Add(this.listViewKeyArea.Items[i].Text);
					this.m_MapParams.KeyAreaColor.Add((System.Drawing.Color)this.listViewKeyArea.Items[i].Tag);
				}
				this.m_MapParams.ColorBarPos = new System.Drawing.Point((int)this.numericUpDownColorBarPosX.Value, (int)this.numericUpDownColorBarPosY.Value);
				this.m_MapParams.ColorBarWidth = (int)this.numericUpDownColorBarWidth.Value;
				this.m_MapParams.ColorBarHeight = (int)this.numericUpDownColorBarHeight.Value;
				this.m_MapParams.CoorUseLonLatType = this.radioButtonByTypeLonLat.Checked;
				this.m_MapParams.CoorNameX = this.textBoxCoorNameX.Text;
				this.m_MapParams.CoorNameY = this.textBoxCoorNameY.Text;
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("无法保存参数！\r\n请检查输入参数是否合法！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
				return result;
			}
			result = true;
			return result;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MapSettingForm));
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			this.checkBoxWantCity = new System.Windows.Forms.CheckBox();
			this.numericUpDownCityTextHeight = new System.Windows.Forms.NumericUpDown();
			this.label19 = new System.Windows.Forms.Label();
			this.buttonCityTextColorFore = new System.Windows.Forms.Button();
			this.label20 = new System.Windows.Forms.Label();
			this.comboBoxLonLatLineStyle = new System.Windows.Forms.ComboBox();
			this.checkBoxWantLonLat = new System.Windows.Forms.CheckBox();
			this.numericUpDownLonLatTextHeight = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownLonLatLineWidth = new System.Windows.Forms.NumericUpDown();
			this.label16 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.buttonLonLatTextColor = new System.Windows.Forms.Button();
			this.buttonLonLatLineColor = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.checkBoxFillBoundary = new System.Windows.Forms.CheckBox();
			this.checkBoxWantBoundary = new System.Windows.Forms.CheckBox();
			this.comboBoxBoundaryLineStyle = new System.Windows.Forms.ComboBox();
			this.numericUpDownBoundaryLineWidth = new System.Windows.Forms.NumericUpDown();
			this.buttonAreaColor = new System.Windows.Forms.Button();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.buttonLineColor = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.labelAlpha = new System.Windows.Forms.Label();
			this.checkBoxWantBackgroundImage = new System.Windows.Forms.CheckBox();
			this.buttonBackgroundColor = new System.Windows.Forms.Button();
			this.label11 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.labelZoom = new System.Windows.Forms.Label();
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.groupPanelPreview = new GroupPanel();
			this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
			this.textBoxXFilePath = new TextBoxX();
			this.buttonXSaveDefaultParams = new ButtonX();
			this.buttonXCancel = new ButtonX();
			this.buttonXShowPreview = new ButtonX();
			this.buttonXLoadDefaultParams = new ButtonX();
			this.buttonXOK = new ButtonX();
			this.tabControl1 = new DevComponents.DotNetBar.TabControl();
			this.tabControlPanel1 = new TabControlPanel();
			this.numericUpDownEdgeTop = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownEdgeBottom = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownPicHeight = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownPicWidth = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownEdgeRight = new System.Windows.Forms.NumericUpDown();
			this.numericUpDownEdgeLeft = new System.Windows.Forms.NumericUpDown();
			this.textBoxXBackgroundImagePath = new TextBoxX();
			this.buttontextBoxXBackgroundImagePath = new System.Windows.Forms.Button();
			this.label75 = new System.Windows.Forms.Label();
			this.label67 = new System.Windows.Forms.Label();
			this.label65 = new System.Windows.Forms.Label();
			this.label74 = new System.Windows.Forms.Label();
			this.label66 = new System.Windows.Forms.Label();
			this.label72 = new System.Windows.Forms.Label();
			this.label64 = new System.Windows.Forms.Label();
			this.label63 = new System.Windows.Forms.Label();
			this.label62 = new System.Windows.Forms.Label();
			this.textBoxMapTitle = new System.Windows.Forms.TextBox();
			this.pictureBoxBackgroundColor = new System.Windows.Forms.PictureBox();
			this.tabItem1 = new TabItem(this.components);
			this.tabControlPanel10 = new TabControlPanel();
			this.groupPanel2 = new GroupPanel();
			this.numericUpDownStandardLat = new System.Windows.Forms.NumericUpDown();
			this.label71 = new System.Windows.Forms.Label();
			this.numericUpDownStandardLon = new System.Windows.Forms.NumericUpDown();
			this.label70 = new System.Windows.Forms.Label();
			this.groupPanel1 = new GroupPanel();
			this.numericUpDownWHScale = new System.Windows.Forms.NumericUpDown();
			this.label33 = new System.Windows.Forms.Label();
			this.numericUpDownCenterLat = new System.Windows.Forms.NumericUpDown();
			this.comboBoxProjectionType = new System.Windows.Forms.ComboBox();
			this.label69 = new System.Windows.Forms.Label();
			this.label68 = new System.Windows.Forms.Label();
			this.trackBarZoom = new Slider();
			this.numericUpDownCenterLon = new System.Windows.Forms.NumericUpDown();
			this.label73 = new System.Windows.Forms.Label();
			this.tabItem11 = new TabItem(this.components);
			this.tabControlPanel9 = new TabControlPanel();
			this.radioButtonByTypeUserDefine = new System.Windows.Forms.RadioButton();
			this.radioButtonByTypeLonLat = new System.Windows.Forms.RadioButton();
			this.textBoxCoorNameY = new TextBoxX();
			this.label61 = new System.Windows.Forms.Label();
			this.textBoxCoorNameX = new TextBoxX();
			this.label60 = new System.Windows.Forms.Label();
			this.label55 = new System.Windows.Forms.Label();
			this.tabItem9 = new TabItem(this.components);
			this.tabControlPanel8 = new TabControlPanel();
			this.label59 = new System.Windows.Forms.Label();
			this.label57 = new System.Windows.Forms.Label();
			this.label51 = new System.Windows.Forms.Label();
			this.numericUpDownColorBarHeight = new System.Windows.Forms.NumericUpDown();
			this.label58 = new System.Windows.Forms.Label();
			this.numericUpDownColorBarWidth = new System.Windows.Forms.NumericUpDown();
			this.label56 = new System.Windows.Forms.Label();
			this.numericUpDownColorBarPosY = new System.Windows.Forms.NumericUpDown();
			this.label54 = new System.Windows.Forms.Label();
			this.numericUpDownColorBarPosX = new System.Windows.Forms.NumericUpDown();
			this.label53 = new System.Windows.Forms.Label();
			this.tabItem8 = new TabItem(this.components);
			this.tabControlPanel7 = new TabControlPanel();
			this.checkBoxShowKeyArea = new System.Windows.Forms.CheckBox();
			this.sliderKeyAreaAlpha = new Slider();
			this.labelKeyAreaAlpha = new System.Windows.Forms.Label();
			this.label52 = new System.Windows.Forms.Label();
			this.textBoxKeyAreaDataPath = new TextBoxX();
			this.label49 = new System.Windows.Forms.Label();
			this.buttonChoseKeyAreaColor = new System.Windows.Forms.Button();
			this.pictureBoxKeyAreaColor = new System.Windows.Forms.PictureBox();
			this.label50 = new System.Windows.Forms.Label();
			this.listViewKeyArea = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.buttonDeleteKeyArea = new ButtonX();
			this.buttonAddKeyArea = new ButtonX();
			this.buttonModifyKeyArea = new ButtonX();
			this.tabItem7 = new TabItem(this.components);
			this.tabControlPanel2 = new TabControlPanel();
			this.textBoxXLineDataPath = new TextBoxX();
			this.trackBarBoundaryAreaAlpha = new Slider();
			this.buttonLineDataPath = new System.Windows.Forms.Button();
			this.label22 = new System.Windows.Forms.Label();
			this.pictureBoxBoundaryLineColor = new System.Windows.Forms.PictureBox();
			this.pictureBoxBoundaryAreaColor = new System.Windows.Forms.PictureBox();
			this.tabItem2 = new TabItem(this.components);
			this.tabControlPanel4 = new TabControlPanel();
			this.checkBoxCityTextBold = new System.Windows.Forms.CheckBox();
			this.label31 = new System.Windows.Forms.Label();
			this.buttonCityTextColorBack = new System.Windows.Forms.Button();
			this.pictureBoxCityTextColorBack = new System.Windows.Forms.PictureBox();
			this.label41 = new System.Windows.Forms.Label();
			this.pictureBoxCityTextColorFore = new System.Windows.Forms.PictureBox();
			this.tabItem4 = new TabItem(this.components);
			this.tabControlPanel3 = new TabControlPanel();
			this.checkBoxLonLatTextBold = new System.Windows.Forms.CheckBox();
			this.numericUpDownLonLatStep = new System.Windows.Forms.NumericUpDown();
			this.pictureBoxLonLatTextColor = new System.Windows.Forms.PictureBox();
			this.pictureBoxLonLatLineColor = new System.Windows.Forms.PictureBox();
			this.label25 = new System.Windows.Forms.Label();
			this.label26 = new System.Windows.Forms.Label();
			this.label24 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.tabItem3 = new TabItem(this.components);
			this.tabControlPanel5 = new TabControlPanel();
			this.checkBoxWantRiver = new System.Windows.Forms.CheckBox();
			this.comboBoxRiverStyle = new System.Windows.Forms.ComboBox();
			this.checkBoxWantProvince = new System.Windows.Forms.CheckBox();
			this.pictureBoxRiverColor = new System.Windows.Forms.PictureBox();
			this.comboBoxProvinceLineStyle = new System.Windows.Forms.ComboBox();
			this.numericUpDownRiverWidth = new System.Windows.Forms.NumericUpDown();
			this.pictureBoxProvinceLineColor = new System.Windows.Forms.PictureBox();
			this.label39 = new System.Windows.Forms.Label();
			this.numericUpDownProvinceLineWidth = new System.Windows.Forms.NumericUpDown();
			this.buttonRiverColor = new System.Windows.Forms.Button();
			this.label34 = new System.Windows.Forms.Label();
			this.label38 = new System.Windows.Forms.Label();
			this.buttonProvinceLineColor = new System.Windows.Forms.Button();
			this.label37 = new System.Windows.Forms.Label();
			this.label35 = new System.Windows.Forms.Label();
			this.label36 = new System.Windows.Forms.Label();
			this.tabItem5 = new TabItem(this.components);
			this.tabControlPanel6 = new TabControlPanel();
			this.checkBoxStationTextBold = new System.Windows.Forms.CheckBox();
			this.textBoxStationDataPath2 = new TextBoxX();
			this.textBoxStationDataPath1 = new TextBoxX();
			this.label48 = new System.Windows.Forms.Label();
			this.label44 = new System.Windows.Forms.Label();
			this.label32 = new System.Windows.Forms.Label();
			this.label47 = new System.Windows.Forms.Label();
			this.checkBoxShowStationInThumb = new System.Windows.Forms.CheckBox();
			this.checkBoxWantStation = new System.Windows.Forms.CheckBox();
			this.label42 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.buttonStationTextColorBack2 = new System.Windows.Forms.Button();
			this.numericUpDownStationTextHeight = new System.Windows.Forms.NumericUpDown();
			this.buttonStationTextColorFore2 = new System.Windows.Forms.Button();
			this.buttonStationTextColorBack1 = new System.Windows.Forms.Button();
			this.pictureBoxStationTextColorBack2 = new System.Windows.Forms.PictureBox();
			this.buttonStationTextColorFore1 = new System.Windows.Forms.Button();
			this.pictureBoxStationTextColorFore2 = new System.Windows.Forms.PictureBox();
			this.pictureBoxStationTextColorBack1 = new System.Windows.Forms.PictureBox();
			this.label46 = new System.Windows.Forms.Label();
			this.pictureBoxStationTextColorFore1 = new System.Windows.Forms.PictureBox();
			this.label45 = new System.Windows.Forms.Label();
			this.label43 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.tabItem6 = new TabItem(this.components);
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.openFileDialogaMap = new System.Windows.Forms.OpenFileDialog();
			this.tabItem10 = new TabItem(this.components);
			this.buttonItem2 = new ButtonItem();
			this.buttonItem1 = new ButtonItem();
			this.buttonSystem7 = new ButtonItem();
			this.buttonSystem6 = new ButtonItem();
			this.buttonSystem5 = new ButtonItem();
			this.buttonSystem4 = new ButtonItem();
			this.buttonSystem3 = new ButtonItem();
			this.buttonSystem2 = new ButtonItem();
			this.buttonSystem1 = new ButtonItem();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCityTextHeight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLonLatTextHeight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLonLatLineWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownBoundaryLineWidth).BeginInit();
			this.ribbonClientPanel1.SuspendLayout();
			this.groupPanelPreview.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.tabControl1).BeginInit();
			this.tabControl1.SuspendLayout();
			this.tabControlPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEdgeTop).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEdgeBottom).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownPicHeight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownPicWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEdgeRight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEdgeLeft).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBackgroundColor).BeginInit();
			this.tabControlPanel10.SuspendLayout();
			this.groupPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStandardLat).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStandardLon).BeginInit();
			this.groupPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownWHScale).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCenterLat).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCenterLon).BeginInit();
			this.tabControlPanel9.SuspendLayout();
			this.tabControlPanel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorBarHeight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorBarWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorBarPosY).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorBarPosX).BeginInit();
			this.tabControlPanel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxKeyAreaColor).BeginInit();
			this.tabControlPanel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBoundaryLineColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBoundaryAreaColor).BeginInit();
			this.tabControlPanel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxCityTextColorBack).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxCityTextColorFore).BeginInit();
			this.tabControlPanel3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLonLatStep).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxLonLatTextColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxLonLatLineColor).BeginInit();
			this.tabControlPanel5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxRiverColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownRiverWidth).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxProvinceLineColor).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownProvinceLineWidth).BeginInit();
			this.tabControlPanel6.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStationTextHeight).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStationTextColorBack2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStationTextColorFore2).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStationTextColorBack1).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStationTextColorFore1).BeginInit();
			base.SuspendLayout();
			this.colorDialog.AnyColor = true;
			this.colorDialog.FullOpen = true;
			this.imageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList.ImageStream");
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "colorbar0.bmp");
			this.imageList.Images.SetKeyName(1, "colorbar1.bmp");
			this.imageList.Images.SetKeyName(2, "colorbar2.bmp");
			this.imageList.Images.SetKeyName(3, "colorbar3.bmp");
			this.checkBoxWantCity.AutoSize = true;
			this.checkBoxWantCity.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxWantCity.Location = new System.Drawing.Point(29, 16);
			this.checkBoxWantCity.Name = "checkBoxWantCity";
			this.checkBoxWantCity.Size = new System.Drawing.Size(112, 23);
			this.checkBoxWantCity.TabIndex = 12;
			this.checkBoxWantCity.Text = "显示主要城市";
			this.checkBoxWantCity.UseVisualStyleBackColor = false;
			this.numericUpDownCityTextHeight.Location = new System.Drawing.Point(133, 108);
			System.Windows.Forms.NumericUpDown arg_D0E_0 = this.numericUpDownCityTextHeight;
			int[] array = new int[4];
			array[0] = 1;
			arg_D0E_0.Minimum = new decimal(array);
			this.numericUpDownCityTextHeight.Name = "numericUpDownCityTextHeight";
			this.numericUpDownCityTextHeight.Size = new System.Drawing.Size(63, 26);
			this.numericUpDownCityTextHeight.TabIndex = 11;
			this.numericUpDownCityTextHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_D6C_0 = this.numericUpDownCityTextHeight;
			array = new int[4];
			array[0] = 1;
			arg_D6C_0.Value = new decimal(array);
			this.label19.AutoSize = true;
			this.label19.BackColor = System.Drawing.Color.Transparent;
			this.label19.Location = new System.Drawing.Point(48, 112);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(79, 19);
			this.label19.TabIndex = 0;
			this.label19.Text = "文字大小：";
			this.buttonCityTextColorFore.Location = new System.Drawing.Point(202, 44);
			this.buttonCityTextColorFore.Name = "buttonCityTextColorFore";
			this.buttonCityTextColorFore.Size = new System.Drawing.Size(68, 26);
			this.buttonCityTextColorFore.TabIndex = 0;
			this.buttonCityTextColorFore.Text = "选择";
			this.buttonCityTextColorFore.UseVisualStyleBackColor = true;
			this.buttonCityTextColorFore.Click += new System.EventHandler(this.buttonCityTextColorFore_Click);
			this.label20.AutoSize = true;
			this.label20.BackColor = System.Drawing.Color.Transparent;
			this.label20.Location = new System.Drawing.Point(23, 48);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(107, 19);
			this.label20.TabIndex = 0;
			this.label20.Text = "文字前景颜色：";
			this.comboBoxLonLatLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxLonLatLineStyle.FormattingEnabled = true;
			this.comboBoxLonLatLineStyle.Items.AddRange(new object[]
			{
				"— — — —",
				"—.—.—.—",
				"—. .—. .—",
				". . . . . . . . . ",
				"—————"
			});
			this.comboBoxLonLatLineStyle.Location = new System.Drawing.Point(124, 104);
			this.comboBoxLonLatLineStyle.Name = "comboBoxLonLatLineStyle";
			this.comboBoxLonLatLineStyle.Size = new System.Drawing.Size(144, 27);
			this.comboBoxLonLatLineStyle.TabIndex = 12;
			this.checkBoxWantLonLat.AutoSize = true;
			this.checkBoxWantLonLat.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxWantLonLat.Location = new System.Drawing.Point(29, 16);
			this.checkBoxWantLonLat.Name = "checkBoxWantLonLat";
			this.checkBoxWantLonLat.Size = new System.Drawing.Size(98, 23);
			this.checkBoxWantLonLat.TabIndex = 12;
			this.checkBoxWantLonLat.Text = "显示经纬线";
			this.checkBoxWantLonLat.UseVisualStyleBackColor = false;
			this.numericUpDownLonLatTextHeight.Location = new System.Drawing.Point(124, 201);
			System.Windows.Forms.NumericUpDown arg_103C_0 = this.numericUpDownLonLatTextHeight;
			array = new int[4];
			array[0] = 1;
			arg_103C_0.Minimum = new decimal(array);
			this.numericUpDownLonLatTextHeight.Name = "numericUpDownLonLatTextHeight";
			this.numericUpDownLonLatTextHeight.Size = new System.Drawing.Size(76, 26);
			this.numericUpDownLonLatTextHeight.TabIndex = 11;
			this.numericUpDownLonLatTextHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_109A_0 = this.numericUpDownLonLatTextHeight;
			array = new int[4];
			array[0] = 1;
			arg_109A_0.Value = new decimal(array);
			this.numericUpDownLonLatLineWidth.Location = new System.Drawing.Point(124, 72);
			System.Windows.Forms.NumericUpDown arg_10CD_0 = this.numericUpDownLonLatLineWidth;
			array = new int[4];
			array[0] = 10;
			arg_10CD_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_10EA_0 = this.numericUpDownLonLatLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_10EA_0.Minimum = new decimal(array);
			this.numericUpDownLonLatLineWidth.Name = "numericUpDownLonLatLineWidth";
			this.numericUpDownLonLatLineWidth.Size = new System.Drawing.Size(76, 26);
			this.numericUpDownLonLatLineWidth.TabIndex = 11;
			this.numericUpDownLonLatLineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_1148_0 = this.numericUpDownLonLatLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_1148_0.Value = new decimal(array);
			this.label16.AutoSize = true;
			this.label16.BackColor = System.Drawing.Color.Transparent;
			this.label16.Location = new System.Drawing.Point(39, 203);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(79, 19);
			this.label16.TabIndex = 0;
			this.label16.Text = "文字大小：";
			this.label15.AutoSize = true;
			this.label15.BackColor = System.Drawing.Color.Transparent;
			this.label15.Location = new System.Drawing.Point(39, 171);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(79, 19);
			this.label15.TabIndex = 0;
			this.label15.Text = "文字颜色：";
			this.label12.AutoSize = true;
			this.label12.BackColor = System.Drawing.Color.Transparent;
			this.label12.Location = new System.Drawing.Point(25, 42);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(93, 19);
			this.label12.TabIndex = 0;
			this.label12.Text = "经纬线颜色：";
			this.buttonLonLatTextColor.Location = new System.Drawing.Point(206, 169);
			this.buttonLonLatTextColor.Name = "buttonLonLatTextColor";
			this.buttonLonLatTextColor.Size = new System.Drawing.Size(68, 26);
			this.buttonLonLatTextColor.TabIndex = 0;
			this.buttonLonLatTextColor.Text = "选择";
			this.buttonLonLatTextColor.UseVisualStyleBackColor = true;
			this.buttonLonLatTextColor.Click += new System.EventHandler(this.buttonLonLatTextColor_Click);
			this.buttonLonLatLineColor.Location = new System.Drawing.Point(206, 40);
			this.buttonLonLatLineColor.Name = "buttonLonLatLineColor";
			this.buttonLonLatLineColor.Size = new System.Drawing.Size(68, 26);
			this.buttonLonLatLineColor.TabIndex = 0;
			this.buttonLonLatLineColor.Text = "选择";
			this.buttonLonLatLineColor.UseVisualStyleBackColor = true;
			this.buttonLonLatLineColor.Click += new System.EventHandler(this.buttonLonLatLineColor_Click);
			this.label13.AutoSize = true;
			this.label13.BackColor = System.Drawing.Color.Transparent;
			this.label13.Location = new System.Drawing.Point(25, 74);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(93, 19);
			this.label13.TabIndex = 0;
			this.label13.Text = "经纬线粗细：";
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.Location = new System.Drawing.Point(25, 106);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(93, 19);
			this.label14.TabIndex = 0;
			this.label14.Text = "经纬线类型：";
			this.checkBoxFillBoundary.AutoSize = true;
			this.checkBoxFillBoundary.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxFillBoundary.Location = new System.Drawing.Point(128, 15);
			this.checkBoxFillBoundary.Name = "checkBoxFillBoundary";
			this.checkBoxFillBoundary.Size = new System.Drawing.Size(84, 23);
			this.checkBoxFillBoundary.TabIndex = 13;
			this.checkBoxFillBoundary.Text = "填充区域";
			this.checkBoxFillBoundary.UseVisualStyleBackColor = false;
			this.checkBoxWantBoundary.AutoSize = true;
			this.checkBoxWantBoundary.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxWantBoundary.Location = new System.Drawing.Point(29, 16);
			this.checkBoxWantBoundary.Name = "checkBoxWantBoundary";
			this.checkBoxWantBoundary.Size = new System.Drawing.Size(84, 23);
			this.checkBoxWantBoundary.TabIndex = 13;
			this.checkBoxWantBoundary.Text = "显示边界";
			this.checkBoxWantBoundary.UseVisualStyleBackColor = false;
			this.comboBoxBoundaryLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxBoundaryLineStyle.FormattingEnabled = true;
			this.comboBoxBoundaryLineStyle.Items.AddRange(new object[]
			{
				"— — — —",
				"—.—.—.—",
				"—. .—. .—",
				". . . . . . . . . ",
				"—————"
			});
			this.comboBoxBoundaryLineStyle.Location = new System.Drawing.Point(234, 83);
			this.comboBoxBoundaryLineStyle.Name = "comboBoxBoundaryLineStyle";
			this.comboBoxBoundaryLineStyle.Size = new System.Drawing.Size(100, 27);
			this.comboBoxBoundaryLineStyle.TabIndex = 12;
			this.numericUpDownBoundaryLineWidth.Location = new System.Drawing.Point(102, 83);
			System.Windows.Forms.NumericUpDown arg_168D_0 = this.numericUpDownBoundaryLineWidth;
			array = new int[4];
			array[0] = 10;
			arg_168D_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_16AA_0 = this.numericUpDownBoundaryLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_16AA_0.Minimum = new decimal(array);
			this.numericUpDownBoundaryLineWidth.Name = "numericUpDownBoundaryLineWidth";
			this.numericUpDownBoundaryLineWidth.Size = new System.Drawing.Size(50, 26);
			this.numericUpDownBoundaryLineWidth.TabIndex = 11;
			this.numericUpDownBoundaryLineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_1708_0 = this.numericUpDownBoundaryLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_1708_0.Value = new decimal(array);
			this.buttonAreaColor.Location = new System.Drawing.Point(175, 152);
			this.buttonAreaColor.Name = "buttonAreaColor";
			this.buttonAreaColor.Size = new System.Drawing.Size(68, 26);
			this.buttonAreaColor.TabIndex = 1;
			this.buttonAreaColor.Text = "选择";
			this.buttonAreaColor.UseVisualStyleBackColor = true;
			this.buttonAreaColor.Click += new System.EventHandler(this.buttonAreaColor_Click);
			this.label9.AutoSize = true;
			this.label9.BackColor = System.Drawing.Color.Transparent;
			this.label9.Location = new System.Drawing.Point(158, 86);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(79, 19);
			this.label9.TabIndex = 0;
			this.label9.Text = "边界类型：";
			this.label8.AutoSize = true;
			this.label8.BackColor = System.Drawing.Color.Transparent;
			this.label8.Location = new System.Drawing.Point(26, 85);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(79, 19);
			this.label8.TabIndex = 0;
			this.label8.Text = "边界粗细：";
			this.label5.AutoSize = true;
			this.label5.BackColor = System.Drawing.Color.Transparent;
			this.label5.Location = new System.Drawing.Point(25, 48);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(79, 19);
			this.label5.TabIndex = 0;
			this.label5.Text = "边界颜色：";
			this.buttonLineColor.Location = new System.Drawing.Point(176, 47);
			this.buttonLineColor.Name = "buttonLineColor";
			this.buttonLineColor.Size = new System.Drawing.Size(68, 26);
			this.buttonLineColor.TabIndex = 0;
			this.buttonLineColor.Text = "选择";
			this.buttonLineColor.UseVisualStyleBackColor = true;
			this.buttonLineColor.Click += new System.EventHandler(this.buttonLineColor_Click);
			this.label6.AutoSize = true;
			this.label6.BackColor = System.Drawing.Color.Transparent;
			this.label6.Location = new System.Drawing.Point(25, 155);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(79, 19);
			this.label6.TabIndex = 0;
			this.label6.Text = "区域颜色：";
			this.label7.AutoSize = true;
			this.label7.BackColor = System.Drawing.Color.Transparent;
			this.label7.Location = new System.Drawing.Point(39, 192);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(65, 19);
			this.label7.TabIndex = 0;
			this.label7.Text = "透明度：";
			this.labelAlpha.AutoSize = true;
			this.labelAlpha.BackColor = System.Drawing.Color.Transparent;
			this.labelAlpha.Location = new System.Drawing.Point(307, 194);
			this.labelAlpha.Name = "labelAlpha";
			this.labelAlpha.Size = new System.Drawing.Size(36, 19);
			this.labelAlpha.TabIndex = 0;
			this.labelAlpha.Text = "255";
			this.checkBoxWantBackgroundImage.AutoSize = true;
			this.checkBoxWantBackgroundImage.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxWantBackgroundImage.Location = new System.Drawing.Point(11, 189);
			this.checkBoxWantBackgroundImage.Name = "checkBoxWantBackgroundImage";
			this.checkBoxWantBackgroundImage.Size = new System.Drawing.Size(84, 23);
			this.checkBoxWantBackgroundImage.TabIndex = 11;
			this.checkBoxWantBackgroundImage.Text = "图片底图";
			this.checkBoxWantBackgroundImage.UseVisualStyleBackColor = false;
			this.buttonBackgroundColor.Location = new System.Drawing.Point(260, 152);
			this.buttonBackgroundColor.Name = "buttonBackgroundColor";
			this.buttonBackgroundColor.Size = new System.Drawing.Size(68, 28);
			this.buttonBackgroundColor.TabIndex = 10;
			this.buttonBackgroundColor.Text = "选择";
			this.buttonBackgroundColor.UseVisualStyleBackColor = true;
			this.buttonBackgroundColor.Click += new System.EventHandler(this.buttonBackgroundColor_Click);
			this.label11.AutoSize = true;
			this.label11.BackColor = System.Drawing.Color.Transparent;
			this.label11.Location = new System.Drawing.Point(15, 156);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(79, 19);
			this.label11.TabIndex = 0;
			this.label11.Text = "背景颜色：";
			this.label21.AutoSize = true;
			this.label21.BackColor = System.Drawing.Color.Transparent;
			this.label21.Location = new System.Drawing.Point(6, 9);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(68, 17);
			this.label21.TabIndex = 0;
			this.label21.Text = "宽高比例：";
			this.label10.AutoSize = true;
			this.label10.BackColor = System.Drawing.Color.Transparent;
			this.label10.Location = new System.Drawing.Point(16, 93);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(79, 19);
			this.label10.TabIndex = 0;
			this.label10.Text = "放大倍数：";
			this.labelZoom.AutoSize = true;
			this.labelZoom.BackColor = System.Drawing.Color.Transparent;
			this.labelZoom.Location = new System.Drawing.Point(320, 93);
			this.labelZoom.Name = "labelZoom";
			this.labelZoom.Size = new System.Drawing.Size(27, 19);
			this.labelZoom.TabIndex = 0;
			this.labelZoom.Text = "10";
			this.ribbonClientPanel1.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.groupPanelPreview);
			this.ribbonClientPanel1.Controls.Add(this.textBoxXFilePath);
			this.ribbonClientPanel1.Controls.Add(this.buttonXSaveDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.buttonXCancel);
			this.ribbonClientPanel1.Controls.Add(this.buttonXShowPreview);
			this.ribbonClientPanel1.Controls.Add(this.buttonXLoadDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.buttonXOK);
			this.ribbonClientPanel1.Controls.Add(this.tabControl1);
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(896, 544);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.StyleMouseDown.Class = "";
			this.ribbonClientPanel1.StyleMouseOver.Class = "";
			this.ribbonClientPanel1.TabIndex = 15;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.groupPanelPreview.BackColor = System.Drawing.Color.Transparent;
			this.groupPanelPreview.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanelPreview.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanelPreview.Controls.Add(this.pictureBoxPreview);
			this.groupPanelPreview.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanelPreview.Location = new System.Drawing.Point(395, 3);
			this.groupPanelPreview.Name = "groupPanelPreview";
			this.groupPanelPreview.Size = new System.Drawing.Size(488, 416);
			this.groupPanelPreview.Style.BackColor2SchemePart = eColorSchemePart.PanelBackground2;
			this.groupPanelPreview.Style.BackColorGradientAngle = 90;
			this.groupPanelPreview.Style.BackColorSchemePart = eColorSchemePart.PanelBackground;
			this.groupPanelPreview.Style.BorderBottom = eStyleBorderType.Solid;
			this.groupPanelPreview.Style.BorderBottomWidth = 1;
			this.groupPanelPreview.Style.BorderColorSchemePart = eColorSchemePart.PanelBorder;
			this.groupPanelPreview.Style.BorderLeft = eStyleBorderType.Solid;
			this.groupPanelPreview.Style.BorderLeftWidth = 1;
			this.groupPanelPreview.Style.BorderRight = eStyleBorderType.Solid;
			this.groupPanelPreview.Style.BorderRightWidth = 1;
			this.groupPanelPreview.Style.BorderTop = eStyleBorderType.Solid;
			this.groupPanelPreview.Style.BorderTopWidth = 1;
			this.groupPanelPreview.Style.Class = "";
			this.groupPanelPreview.Style.CornerDiameter = 4;
			this.groupPanelPreview.Style.CornerType = eCornerType.Rounded;
			this.groupPanelPreview.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanelPreview.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanelPreview.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanelPreview.StyleMouseDown.Class = "";
			this.groupPanelPreview.StyleMouseOver.Class = "";
			this.groupPanelPreview.TabIndex = 36;
			this.groupPanelPreview.Text = "效果预览";
			this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
			this.pictureBoxPreview.Name = "pictureBoxPreview";
			this.pictureBoxPreview.Size = new System.Drawing.Size(482, 387);
			this.pictureBoxPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBoxPreview.TabIndex = 0;
			this.pictureBoxPreview.TabStop = false;
			this.textBoxXFilePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.textBoxXFilePath.Border.Class = "TextBoxBorder";
			this.textBoxXFilePath.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.textBoxXFilePath.Location = new System.Drawing.Point(15, 427);
			this.textBoxXFilePath.Multiline = true;
			this.textBoxXFilePath.Name = "textBoxXFilePath";
			this.textBoxXFilePath.Size = new System.Drawing.Size(868, 49);
			this.textBoxXFilePath.TabIndex = 34;
			this.textBoxXFilePath.Text = "数据路径：";
			this.buttonXSaveDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXSaveDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXSaveDefaultParams.Image = Resources.GroupMoveData;
			this.buttonXSaveDefaultParams.Location = new System.Drawing.Point(337, 484);
			this.buttonXSaveDefaultParams.Name = "buttonXSaveDefaultParams";
			this.buttonXSaveDefaultParams.Size = new System.Drawing.Size(162, 44);
			this.buttonXSaveDefaultParams.TabIndex = 33;
			this.buttonXSaveDefaultParams.Text = "保存为默认参数";
			this.buttonXSaveDefaultParams.Click += new System.EventHandler(this.buttonXSaveDefaultParams_Click);
			this.buttonXCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXCancel.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXCancel.Image = Resources.Cancel;
			this.buttonXCancel.Location = new System.Drawing.Point(693, 484);
			this.buttonXCancel.Name = "buttonXCancel";
			this.buttonXCancel.Size = new System.Drawing.Size(190, 44);
			this.buttonXCancel.TabIndex = 33;
			this.buttonXCancel.Text = "取\u3000消";
			this.buttonXCancel.Click += new System.EventHandler(this.buttonXCancel_Click);
			this.buttonXShowPreview.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXShowPreview.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXShowPreview.Image = Resources.未标题_1;
			this.buttonXShowPreview.Location = new System.Drawing.Point(15, 484);
			this.buttonXShowPreview.Name = "buttonXShowPreview";
			this.buttonXShowPreview.Size = new System.Drawing.Size(161, 44);
			this.buttonXShowPreview.TabIndex = 32;
			this.buttonXShowPreview.Text = "显示效果预览";
			this.buttonXShowPreview.Click += new System.EventHandler(this.buttonXShowPreview_Click);
			this.buttonXLoadDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXLoadDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXLoadDefaultParams.Image = Resources.GroupModify;
			this.buttonXLoadDefaultParams.Location = new System.Drawing.Point(184, 484);
			this.buttonXLoadDefaultParams.Name = "buttonXLoadDefaultParams";
			this.buttonXLoadDefaultParams.Size = new System.Drawing.Size(145, 44);
			this.buttonXLoadDefaultParams.TabIndex = 32;
			this.buttonXLoadDefaultParams.Text = "载入默认参数";
			this.buttonXLoadDefaultParams.Click += new System.EventHandler(this.buttonXLoadDefaultParams_Click);
			this.buttonXOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXOK.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXOK.Image = Resources.OK;
			this.buttonXOK.Location = new System.Drawing.Point(505, 484);
			this.buttonXOK.Name = "buttonXOK";
			this.buttonXOK.Size = new System.Drawing.Size(181, 44);
			this.buttonXOK.TabIndex = 32;
			this.buttonXOK.Text = "确\u3000定";
			this.buttonXOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.tabControl1.AntiAlias = true;
			this.tabControl1.CanReorderTabs = true;
			this.tabControl1.Controls.Add(this.tabControlPanel10);
			this.tabControl1.Controls.Add(this.tabControlPanel4);
			this.tabControl1.Controls.Add(this.tabControlPanel1);
			this.tabControl1.Controls.Add(this.tabControlPanel9);
			this.tabControl1.Controls.Add(this.tabControlPanel8);
			this.tabControl1.Controls.Add(this.tabControlPanel7);
			this.tabControl1.Controls.Add(this.tabControlPanel2);
			this.tabControl1.Controls.Add(this.tabControlPanel3);
			this.tabControl1.Controls.Add(this.tabControlPanel5);
			this.tabControl1.Controls.Add(this.tabControlPanel6);
			this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.tabControl1.Location = new System.Drawing.Point(15, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedTabFont = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.tabControl1.SelectedTabIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(374, 407);
			this.tabControl1.Style = eTabStripStyle.Office2007Dock;
			this.tabControl1.TabIndex = 0;
			this.tabControl1.TabLayoutType = eTabLayoutType.MultilineNoNavigationBox;
			this.tabControl1.Tabs.Add(this.tabItem1);
			this.tabControl1.Tabs.Add(this.tabItem2);
			this.tabControl1.Tabs.Add(this.tabItem3);
			this.tabControl1.Tabs.Add(this.tabItem4);
			this.tabControl1.Tabs.Add(this.tabItem5);
			this.tabControl1.Tabs.Add(this.tabItem6);
			this.tabControl1.Tabs.Add(this.tabItem7);
			this.tabControl1.Tabs.Add(this.tabItem8);
			this.tabControl1.Tabs.Add(this.tabItem9);
			this.tabControl1.Tabs.Add(this.tabItem11);
			this.tabControl1.Text = "tabControl1";
			this.tabControlPanel1.Controls.Add(this.numericUpDownEdgeTop);
			this.tabControlPanel1.Controls.Add(this.numericUpDownEdgeBottom);
			this.tabControlPanel1.Controls.Add(this.numericUpDownPicHeight);
			this.tabControlPanel1.Controls.Add(this.numericUpDownPicWidth);
			this.tabControlPanel1.Controls.Add(this.numericUpDownEdgeRight);
			this.tabControlPanel1.Controls.Add(this.numericUpDownEdgeLeft);
			this.tabControlPanel1.Controls.Add(this.textBoxXBackgroundImagePath);
			this.tabControlPanel1.Controls.Add(this.buttontextBoxXBackgroundImagePath);
			this.tabControlPanel1.Controls.Add(this.label75);
			this.tabControlPanel1.Controls.Add(this.label67);
			this.tabControlPanel1.Controls.Add(this.label65);
			this.tabControlPanel1.Controls.Add(this.label74);
			this.tabControlPanel1.Controls.Add(this.label66);
			this.tabControlPanel1.Controls.Add(this.label72);
			this.tabControlPanel1.Controls.Add(this.label64);
			this.tabControlPanel1.Controls.Add(this.label63);
			this.tabControlPanel1.Controls.Add(this.label62);
			this.tabControlPanel1.Controls.Add(this.checkBoxWantBackgroundImage);
			this.tabControlPanel1.Controls.Add(this.buttonBackgroundColor);
			this.tabControlPanel1.Controls.Add(this.label11);
			this.tabControlPanel1.Controls.Add(this.textBoxMapTitle);
			this.tabControlPanel1.Controls.Add(this.pictureBoxBackgroundColor);
			this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.tabControlPanel1.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel1.Name = "tabControlPanel1";
			this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel1.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel1.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel1.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel1.Style.GradientAngle = 90;
			this.tabControlPanel1.TabIndex = 1;
			this.tabControlPanel1.TabItem = this.tabItem1;
			this.numericUpDownEdgeTop.Location = new System.Drawing.Point(247, 120);
			System.Windows.Forms.NumericUpDown arg_2C88_0 = this.numericUpDownEdgeTop;
			array = new int[4];
			array[0] = 200;
			arg_2C88_0.Maximum = new decimal(array);
			this.numericUpDownEdgeTop.Name = "numericUpDownEdgeTop";
			this.numericUpDownEdgeTop.Size = new System.Drawing.Size(82, 26);
			this.numericUpDownEdgeTop.TabIndex = 39;
			this.numericUpDownEdgeTop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_2CE6_0 = this.numericUpDownEdgeTop;
			array = new int[4];
			array[0] = 1;
			arg_2CE6_0.Value = new decimal(array);
			this.numericUpDownEdgeBottom.Location = new System.Drawing.Point(128, 120);
			System.Windows.Forms.NumericUpDown arg_2D1F_0 = this.numericUpDownEdgeBottom;
			array = new int[4];
			array[0] = 200;
			arg_2D1F_0.Maximum = new decimal(array);
			this.numericUpDownEdgeBottom.Name = "numericUpDownEdgeBottom";
			this.numericUpDownEdgeBottom.Size = new System.Drawing.Size(82, 26);
			this.numericUpDownEdgeBottom.TabIndex = 39;
			this.numericUpDownEdgeBottom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_2D7D_0 = this.numericUpDownEdgeBottom;
			array = new int[4];
			array[0] = 1;
			arg_2D7D_0.Value = new decimal(array);
			this.numericUpDownPicHeight.Location = new System.Drawing.Point(247, 56);
			System.Windows.Forms.NumericUpDown arg_2DB6_0 = this.numericUpDownPicHeight;
			array = new int[4];
			array[0] = 10000;
			arg_2DB6_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_2DD3_0 = this.numericUpDownPicHeight;
			array = new int[4];
			array[0] = 1;
			arg_2DD3_0.Minimum = new decimal(array);
			this.numericUpDownPicHeight.Name = "numericUpDownPicHeight";
			this.numericUpDownPicHeight.Size = new System.Drawing.Size(82, 26);
			this.numericUpDownPicHeight.TabIndex = 39;
			this.numericUpDownPicHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_2E31_0 = this.numericUpDownPicHeight;
			array = new int[4];
			array[0] = 1;
			arg_2E31_0.Value = new decimal(array);
			this.numericUpDownPicWidth.Location = new System.Drawing.Point(128, 56);
			System.Windows.Forms.NumericUpDown arg_2E6A_0 = this.numericUpDownPicWidth;
			array = new int[4];
			array[0] = 10000;
			arg_2E6A_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_2E87_0 = this.numericUpDownPicWidth;
			array = new int[4];
			array[0] = 1;
			arg_2E87_0.Minimum = new decimal(array);
			this.numericUpDownPicWidth.Name = "numericUpDownPicWidth";
			this.numericUpDownPicWidth.Size = new System.Drawing.Size(82, 26);
			this.numericUpDownPicWidth.TabIndex = 39;
			this.numericUpDownPicWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_2EE5_0 = this.numericUpDownPicWidth;
			array = new int[4];
			array[0] = 1;
			arg_2EE5_0.Value = new decimal(array);
			this.numericUpDownEdgeRight.Location = new System.Drawing.Point(247, 88);
			System.Windows.Forms.NumericUpDown arg_2F1E_0 = this.numericUpDownEdgeRight;
			array = new int[4];
			array[0] = 200;
			arg_2F1E_0.Maximum = new decimal(array);
			this.numericUpDownEdgeRight.Name = "numericUpDownEdgeRight";
			this.numericUpDownEdgeRight.Size = new System.Drawing.Size(82, 26);
			this.numericUpDownEdgeRight.TabIndex = 39;
			this.numericUpDownEdgeRight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_2F7C_0 = this.numericUpDownEdgeRight;
			array = new int[4];
			array[0] = 1;
			arg_2F7C_0.Value = new decimal(array);
			this.numericUpDownEdgeLeft.Location = new System.Drawing.Point(128, 88);
			System.Windows.Forms.NumericUpDown arg_2FB5_0 = this.numericUpDownEdgeLeft;
			array = new int[4];
			array[0] = 200;
			arg_2FB5_0.Maximum = new decimal(array);
			this.numericUpDownEdgeLeft.Name = "numericUpDownEdgeLeft";
			this.numericUpDownEdgeLeft.Size = new System.Drawing.Size(82, 26);
			this.numericUpDownEdgeLeft.TabIndex = 39;
			this.numericUpDownEdgeLeft.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_3013_0 = this.numericUpDownEdgeLeft;
			array = new int[4];
			array[0] = 1;
			arg_3013_0.Value = new decimal(array);
			this.textBoxXBackgroundImagePath.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.textBoxXBackgroundImagePath.Border.Class = "TextBoxBorder";
			this.textBoxXBackgroundImagePath.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxXBackgroundImagePath.Location = new System.Drawing.Point(100, 186);
			this.textBoxXBackgroundImagePath.Name = "textBoxXBackgroundImagePath";
			this.textBoxXBackgroundImagePath.ReadOnly = true;
			this.textBoxXBackgroundImagePath.Size = new System.Drawing.Size(154, 23);
			this.textBoxXBackgroundImagePath.TabIndex = 37;
			this.textBoxXBackgroundImagePath.Text = "Default.map";
			this.buttontextBoxXBackgroundImagePath.Location = new System.Drawing.Point(260, 186);
			this.buttontextBoxXBackgroundImagePath.Name = "buttontextBoxXBackgroundImagePath";
			this.buttontextBoxXBackgroundImagePath.Size = new System.Drawing.Size(68, 28);
			this.buttontextBoxXBackgroundImagePath.TabIndex = 36;
			this.buttontextBoxXBackgroundImagePath.Text = "选择";
			this.buttontextBoxXBackgroundImagePath.UseVisualStyleBackColor = true;
			this.buttontextBoxXBackgroundImagePath.Click += new System.EventHandler(this.buttontextBoxXBackgroundImagePath_Click);
			this.label75.AutoSize = true;
			this.label75.BackColor = System.Drawing.Color.Transparent;
			this.label75.Location = new System.Drawing.Point(220, 60);
			this.label75.Name = "label75";
			this.label75.Size = new System.Drawing.Size(23, 19);
			this.label75.TabIndex = 0;
			this.label75.Text = "高";
			this.label67.AutoSize = true;
			this.label67.BackColor = System.Drawing.Color.Transparent;
			this.label67.Location = new System.Drawing.Point(220, 124);
			this.label67.Name = "label67";
			this.label67.Size = new System.Drawing.Size(23, 19);
			this.label67.TabIndex = 0;
			this.label67.Text = "上";
			this.label65.AutoSize = true;
			this.label65.BackColor = System.Drawing.Color.Transparent;
			this.label65.Location = new System.Drawing.Point(220, 92);
			this.label65.Name = "label65";
			this.label65.Size = new System.Drawing.Size(23, 19);
			this.label65.TabIndex = 0;
			this.label65.Text = "右";
			this.label74.AutoSize = true;
			this.label74.BackColor = System.Drawing.Color.Transparent;
			this.label74.Location = new System.Drawing.Point(101, 60);
			this.label74.Name = "label74";
			this.label74.Size = new System.Drawing.Size(23, 19);
			this.label74.TabIndex = 0;
			this.label74.Text = "宽";
			this.label66.AutoSize = true;
			this.label66.BackColor = System.Drawing.Color.Transparent;
			this.label66.Location = new System.Drawing.Point(101, 124);
			this.label66.Name = "label66";
			this.label66.Size = new System.Drawing.Size(23, 19);
			this.label66.TabIndex = 0;
			this.label66.Text = "下";
			this.label72.AutoSize = true;
			this.label72.BackColor = System.Drawing.Color.Transparent;
			this.label72.Location = new System.Drawing.Point(16, 60);
			this.label72.Name = "label72";
			this.label72.Size = new System.Drawing.Size(79, 19);
			this.label72.TabIndex = 0;
			this.label72.Text = "图片尺寸：";
			this.label64.AutoSize = true;
			this.label64.BackColor = System.Drawing.Color.Transparent;
			this.label64.Location = new System.Drawing.Point(101, 92);
			this.label64.Name = "label64";
			this.label64.Size = new System.Drawing.Size(23, 19);
			this.label64.TabIndex = 0;
			this.label64.Text = "左";
			this.label63.AutoSize = true;
			this.label63.BackColor = System.Drawing.Color.Transparent;
			this.label63.Location = new System.Drawing.Point(16, 92);
			this.label63.Name = "label63";
			this.label63.Size = new System.Drawing.Size(79, 19);
			this.label63.TabIndex = 0;
			this.label63.Text = "图边留白：";
			this.label62.AutoSize = true;
			this.label62.BackColor = System.Drawing.Color.Transparent;
			this.label62.Location = new System.Drawing.Point(16, 22);
			this.label62.Name = "label62";
			this.label62.Size = new System.Drawing.Size(79, 19);
			this.label62.TabIndex = 0;
			this.label62.Text = "默认标题：";
			this.textBoxMapTitle.Location = new System.Drawing.Point(100, 19);
			this.textBoxMapTitle.MaxLength = 20;
			this.textBoxMapTitle.Name = "textBoxMapTitle";
			this.textBoxMapTitle.Size = new System.Drawing.Size(228, 26);
			this.textBoxMapTitle.TabIndex = 5;
			this.textBoxMapTitle.Text = "中国区域地图";
			this.pictureBoxBackgroundColor.BackColor = System.Drawing.Color.Blue;
			this.pictureBoxBackgroundColor.Location = new System.Drawing.Point(100, 154);
			this.pictureBoxBackgroundColor.Name = "pictureBoxBackgroundColor";
			this.pictureBoxBackgroundColor.Size = new System.Drawing.Size(154, 26);
			this.pictureBoxBackgroundColor.TabIndex = 1;
			this.pictureBoxBackgroundColor.TabStop = false;
			this.tabItem1.AttachedControl = this.tabControlPanel1;
			this.tabItem1.Name = "tabItem1";
			this.tabItem1.Text = "基本";
			this.tabControlPanel10.Controls.Add(this.groupPanel2);
			this.tabControlPanel10.Controls.Add(this.groupPanel1);
			this.tabControlPanel10.Controls.Add(this.numericUpDownCenterLat);
			this.tabControlPanel10.Controls.Add(this.comboBoxProjectionType);
			this.tabControlPanel10.Controls.Add(this.label69);
			this.tabControlPanel10.Controls.Add(this.label68);
			this.tabControlPanel10.Controls.Add(this.trackBarZoom);
			this.tabControlPanel10.Controls.Add(this.numericUpDownCenterLon);
			this.tabControlPanel10.Controls.Add(this.labelZoom);
			this.tabControlPanel10.Controls.Add(this.label73);
			this.tabControlPanel10.Controls.Add(this.label10);
			this.tabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel10.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel10.Name = "tabControlPanel10";
			this.tabControlPanel10.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel10.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel10.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel10.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel10.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel10.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel10.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel10.Style.GradientAngle = 90;
			this.tabControlPanel10.TabIndex = 10;
			this.tabControlPanel10.TabItem = this.tabItem11;
			this.groupPanel2.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel2.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel2.Controls.Add(this.numericUpDownStandardLat);
			this.groupPanel2.Controls.Add(this.label71);
			this.groupPanel2.Controls.Add(this.numericUpDownStandardLon);
			this.groupPanel2.Controls.Add(this.label70);
			this.groupPanel2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel2.Location = new System.Drawing.Point(20, 197);
			this.groupPanel2.Name = "groupPanel2";
			this.groupPanel2.Size = new System.Drawing.Size(323, 60);
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
			this.groupPanel2.Style.Class = "";
			this.groupPanel2.Style.CornerDiameter = 4;
			this.groupPanel2.Style.CornerType = eCornerType.Rounded;
			this.groupPanel2.Style.TextAlignment = eStyleTextAlignment.Center;
			this.groupPanel2.Style.TextColorSchemePart = eColorSchemePart.PanelText;
			this.groupPanel2.Style.TextLineAlignment = eStyleTextAlignment.Near;
			this.groupPanel2.StyleMouseDown.Class = "";
			this.groupPanel2.StyleMouseOver.Class = "";
			this.groupPanel2.TabIndex = 39;
			this.groupPanel2.Text = "兰勃特正形投影参数";
			this.numericUpDownStandardLat.DecimalPlaces = 1;
			this.numericUpDownStandardLat.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDownStandardLat.Location = new System.Drawing.Point(229, 3);
			System.Windows.Forms.NumericUpDown arg_3BAF_0 = this.numericUpDownStandardLat;
			array = new int[4];
			array[0] = 90;
			arg_3BAF_0.Maximum = new decimal(array);
			this.numericUpDownStandardLat.Minimum = new decimal(new int[]
			{
				90,
				0,
				0,
				-2147483648
			});
			this.numericUpDownStandardLat.Name = "numericUpDownStandardLat";
			this.numericUpDownStandardLat.Size = new System.Drawing.Size(82, 23);
			this.numericUpDownStandardLat.TabIndex = 47;
			this.numericUpDownStandardLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_3C33_0 = this.numericUpDownStandardLat;
			array = new int[4];
			array[0] = 1;
			arg_3C33_0.Value = new decimal(array);
			this.label71.AutoSize = true;
			this.label71.BackColor = System.Drawing.Color.Transparent;
			this.label71.Location = new System.Drawing.Point(164, 6);
			this.label71.Name = "label71";
			this.label71.Size = new System.Drawing.Size(68, 17);
			this.label71.TabIndex = 41;
			this.label71.Text = "标准纬度：";
			this.numericUpDownStandardLon.DecimalPlaces = 1;
			this.numericUpDownStandardLon.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDownStandardLon.Location = new System.Drawing.Point(75, 3);
			System.Windows.Forms.NumericUpDown arg_3D14_0 = this.numericUpDownStandardLon;
			array = new int[4];
			array[0] = 360;
			arg_3D14_0.Maximum = new decimal(array);
			this.numericUpDownStandardLon.Name = "numericUpDownStandardLon";
			this.numericUpDownStandardLon.Size = new System.Drawing.Size(82, 23);
			this.numericUpDownStandardLon.TabIndex = 47;
			this.numericUpDownStandardLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_3D72_0 = this.numericUpDownStandardLon;
			array = new int[4];
			array[0] = 1;
			arg_3D72_0.Value = new decimal(array);
			this.label70.AutoSize = true;
			this.label70.BackColor = System.Drawing.Color.Transparent;
			this.label70.Location = new System.Drawing.Point(6, 6);
			this.label70.Name = "label70";
			this.label70.Size = new System.Drawing.Size(68, 17);
			this.label70.TabIndex = 41;
			this.label70.Text = "标准经度：";
			this.groupPanel1.BackColor = System.Drawing.Color.Transparent;
			this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.groupPanel1.ColorSchemeStyle = eDotNetBarStyle.Office2007;
			this.groupPanel1.Controls.Add(this.numericUpDownWHScale);
			this.groupPanel1.Controls.Add(this.label21);
			this.groupPanel1.Controls.Add(this.label33);
			this.groupPanel1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.groupPanel1.Location = new System.Drawing.Point(20, 129);
			this.groupPanel1.Name = "groupPanel1";
			this.groupPanel1.Size = new System.Drawing.Size(323, 62);
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
			this.groupPanel1.TabIndex = 39;
			this.groupPanel1.Text = "等经纬网格投影参数";
			this.numericUpDownWHScale.DecimalPlaces = 2;
			this.numericUpDownWHScale.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				131072
			});
			this.numericUpDownWHScale.Location = new System.Drawing.Point(75, 7);
			System.Windows.Forms.NumericUpDown arg_40BB_0 = this.numericUpDownWHScale;
			array = new int[4];
			array[0] = 10;
			arg_40BB_0.Maximum = new decimal(array);
			this.numericUpDownWHScale.Minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDownWHScale.Name = "numericUpDownWHScale";
			this.numericUpDownWHScale.Size = new System.Drawing.Size(82, 23);
			this.numericUpDownWHScale.TabIndex = 38;
			this.numericUpDownWHScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_413E_0 = this.numericUpDownWHScale;
			array = new int[4];
			array[0] = 1;
			arg_413E_0.Value = new decimal(array);
			this.label33.AutoSize = true;
			this.label33.BackColor = System.Drawing.Color.Transparent;
			this.label33.Location = new System.Drawing.Point(157, 9);
			this.label33.Name = "label33";
			this.label33.Size = new System.Drawing.Size(27, 17);
			this.label33.TabIndex = 0;
			this.label33.Text = "：1";
			this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.numericUpDownCenterLat.DecimalPlaces = 1;
			this.numericUpDownCenterLat.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDownCenterLat.Location = new System.Drawing.Point(265, 55);
			System.Windows.Forms.NumericUpDown arg_422E_0 = this.numericUpDownCenterLat;
			array = new int[4];
			array[0] = 90;
			arg_422E_0.Maximum = new decimal(array);
			this.numericUpDownCenterLat.Minimum = new decimal(new int[]
			{
				90,
				0,
				0,
				-2147483648
			});
			this.numericUpDownCenterLat.Name = "numericUpDownCenterLat";
			this.numericUpDownCenterLat.Size = new System.Drawing.Size(82, 26);
			this.numericUpDownCenterLat.TabIndex = 47;
			this.numericUpDownCenterLat.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_42B2_0 = this.numericUpDownCenterLat;
			array = new int[4];
			array[0] = 1;
			arg_42B2_0.Value = new decimal(array);
			this.comboBoxProjectionType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxProjectionType.FormattingEnabled = true;
			this.comboBoxProjectionType.Items.AddRange(new object[]
			{
				"等经纬网格投影",
				"兰勃特正形投影",
				"麦卡特正形投影",
				"极射赤面投影"
			});
			this.comboBoxProjectionType.Location = new System.Drawing.Point(95, 20);
			this.comboBoxProjectionType.Name = "comboBoxProjectionType";
			this.comboBoxProjectionType.Size = new System.Drawing.Size(144, 27);
			this.comboBoxProjectionType.TabIndex = 14;
			this.label69.AutoSize = true;
			this.label69.BackColor = System.Drawing.Color.Transparent;
			this.label69.Location = new System.Drawing.Point(183, 59);
			this.label69.Name = "label69";
			this.label69.Size = new System.Drawing.Size(79, 19);
			this.label69.TabIndex = 41;
			this.label69.Text = "中心纬度：";
			this.label68.AutoSize = true;
			this.label68.BackColor = System.Drawing.Color.Transparent;
			this.label68.Location = new System.Drawing.Point(16, 22);
			this.label68.Name = "label68";
			this.label68.Size = new System.Drawing.Size(79, 19);
			this.label68.TabIndex = 13;
			this.label68.Text = "投影方式：";
			this.trackBarZoom.BackColor = System.Drawing.Color.Transparent;
			this.trackBarZoom.BackgroundStyle.Class = "";
			this.trackBarZoom.LabelVisible = false;
			this.trackBarZoom.Location = new System.Drawing.Point(95, 86);
			this.trackBarZoom.Maximum = 1500;
			this.trackBarZoom.Minimum = 10;
			this.trackBarZoom.Name = "trackBarZoom";
			this.trackBarZoom.Size = new System.Drawing.Size(219, 32);
			this.trackBarZoom.TabIndex = 29;
			this.trackBarZoom.Text = "slider1";
			this.trackBarZoom.Value = 10;
			this.trackBarZoom.ValueChanged += new System.EventHandler(this.trackBarZoom_ValueChanged);
			this.numericUpDownCenterLon.DecimalPlaces = 1;
			this.numericUpDownCenterLon.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDownCenterLon.Location = new System.Drawing.Point(95, 55);
			System.Windows.Forms.NumericUpDown arg_4582_0 = this.numericUpDownCenterLon;
			array = new int[4];
			array[0] = 360;
			arg_4582_0.Maximum = new decimal(array);
			this.numericUpDownCenterLon.Name = "numericUpDownCenterLon";
			this.numericUpDownCenterLon.Size = new System.Drawing.Size(82, 26);
			this.numericUpDownCenterLon.TabIndex = 47;
			this.numericUpDownCenterLon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_45E0_0 = this.numericUpDownCenterLon;
			array = new int[4];
			array[0] = 1;
			arg_45E0_0.Value = new decimal(array);
			this.label73.AutoSize = true;
			this.label73.BackColor = System.Drawing.Color.Transparent;
			this.label73.Location = new System.Drawing.Point(16, 59);
			this.label73.Name = "label73";
			this.label73.Size = new System.Drawing.Size(79, 19);
			this.label73.TabIndex = 41;
			this.label73.Text = "中心经度：";
			this.tabItem11.AttachedControl = this.tabControlPanel10;
			this.tabItem11.Name = "tabItem11";
			this.tabItem11.Text = "地图投影";
			this.tabControlPanel9.Controls.Add(this.radioButtonByTypeUserDefine);
			this.tabControlPanel9.Controls.Add(this.radioButtonByTypeLonLat);
			this.tabControlPanel9.Controls.Add(this.textBoxCoorNameY);
			this.tabControlPanel9.Controls.Add(this.label61);
			this.tabControlPanel9.Controls.Add(this.textBoxCoorNameX);
			this.tabControlPanel9.Controls.Add(this.label60);
			this.tabControlPanel9.Controls.Add(this.label55);
			this.tabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel9.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel9.Name = "tabControlPanel9";
			this.tabControlPanel9.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel9.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel9.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel9.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel9.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel9.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel9.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel9.Style.GradientAngle = 90;
			this.tabControlPanel9.TabIndex = 9;
			this.tabControlPanel9.TabItem = this.tabItem9;
			this.radioButtonByTypeUserDefine.AutoSize = true;
			this.radioButtonByTypeUserDefine.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonByTypeUserDefine.Location = new System.Drawing.Point(31, 44);
			this.radioButtonByTypeUserDefine.Name = "radioButtonByTypeUserDefine";
			this.radioButtonByTypeUserDefine.Size = new System.Drawing.Size(167, 23);
			this.radioButtonByTypeUserDefine.TabIndex = 49;
			this.radioButtonByTypeUserDefine.Text = "按自定义坐标单位显示";
			this.radioButtonByTypeUserDefine.UseVisualStyleBackColor = false;
			this.radioButtonByTypeLonLat.AutoSize = true;
			this.radioButtonByTypeLonLat.BackColor = System.Drawing.Color.Transparent;
			this.radioButtonByTypeLonLat.Checked = true;
			this.radioButtonByTypeLonLat.Location = new System.Drawing.Point(31, 16);
			this.radioButtonByTypeLonLat.Name = "radioButtonByTypeLonLat";
			this.radioButtonByTypeLonLat.Size = new System.Drawing.Size(139, 23);
			this.radioButtonByTypeLonLat.TabIndex = 49;
			this.radioButtonByTypeLonLat.TabStop = true;
			this.radioButtonByTypeLonLat.Text = "按经纬度方式显示";
			this.radioButtonByTypeLonLat.UseVisualStyleBackColor = false;
			this.textBoxCoorNameY.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.textBoxCoorNameY.Border.Class = "TextBoxBorder";
			this.textBoxCoorNameY.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxCoorNameY.Location = new System.Drawing.Point(197, 108);
			this.textBoxCoorNameY.Name = "textBoxCoorNameY";
			this.textBoxCoorNameY.ReadOnly = true;
			this.textBoxCoorNameY.Size = new System.Drawing.Size(97, 23);
			this.textBoxCoorNameY.TabIndex = 48;
			this.textBoxCoorNameY.Text = "line.lin";
			this.label61.AutoSize = true;
			this.label61.BackColor = System.Drawing.Color.Transparent;
			this.label61.Location = new System.Drawing.Point(166, 110);
			this.label61.Name = "label61";
			this.label61.Size = new System.Drawing.Size(29, 19);
			this.label61.TabIndex = 47;
			this.label61.Text = "Y=";
			this.textBoxCoorNameX.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.textBoxCoorNameX.Border.Class = "TextBoxBorder";
			this.textBoxCoorNameX.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxCoorNameX.Location = new System.Drawing.Point(55, 108);
			this.textBoxCoorNameX.Name = "textBoxCoorNameX";
			this.textBoxCoorNameX.ReadOnly = true;
			this.textBoxCoorNameX.Size = new System.Drawing.Size(97, 23);
			this.textBoxCoorNameX.TabIndex = 48;
			this.textBoxCoorNameX.Text = "line.lin";
			this.label60.AutoSize = true;
			this.label60.BackColor = System.Drawing.Color.Transparent;
			this.label60.Location = new System.Drawing.Point(24, 110);
			this.label60.Name = "label60";
			this.label60.Size = new System.Drawing.Size(30, 19);
			this.label60.TabIndex = 47;
			this.label60.Text = "X=";
			this.label55.AutoSize = true;
			this.label55.BackColor = System.Drawing.Color.Transparent;
			this.label55.Location = new System.Drawing.Point(23, 81);
			this.label55.Name = "label55";
			this.label55.Size = new System.Drawing.Size(121, 19);
			this.label55.TabIndex = 47;
			this.label55.Text = "自定义坐标单位：";
			this.tabItem9.AttachedControl = this.tabControlPanel9;
			this.tabItem9.Name = "tabItem9";
			this.tabItem9.Text = "鼠标信息";
			this.tabControlPanel8.Controls.Add(this.label59);
			this.tabControlPanel8.Controls.Add(this.label57);
			this.tabControlPanel8.Controls.Add(this.label51);
			this.tabControlPanel8.Controls.Add(this.numericUpDownColorBarHeight);
			this.tabControlPanel8.Controls.Add(this.label58);
			this.tabControlPanel8.Controls.Add(this.numericUpDownColorBarWidth);
			this.tabControlPanel8.Controls.Add(this.label56);
			this.tabControlPanel8.Controls.Add(this.numericUpDownColorBarPosY);
			this.tabControlPanel8.Controls.Add(this.label54);
			this.tabControlPanel8.Controls.Add(this.numericUpDownColorBarPosX);
			this.tabControlPanel8.Controls.Add(this.label53);
			this.tabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel8.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel8.Name = "tabControlPanel8";
			this.tabControlPanel8.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel8.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel8.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel8.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel8.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel8.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel8.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel8.Style.GradientAngle = 90;
			this.tabControlPanel8.TabIndex = 8;
			this.tabControlPanel8.TabItem = this.tabItem8;
			this.label59.AutoSize = true;
			this.label59.BackColor = System.Drawing.Color.Transparent;
			this.label59.Location = new System.Drawing.Point(24, 115);
			this.label59.Name = "label59";
			this.label59.Size = new System.Drawing.Size(93, 19);
			this.label59.TabIndex = 13;
			this.label59.Text = "颜色条高度：";
			this.label57.AutoSize = true;
			this.label57.BackColor = System.Drawing.Color.Transparent;
			this.label57.Location = new System.Drawing.Point(24, 82);
			this.label57.Name = "label57";
			this.label57.Size = new System.Drawing.Size(93, 19);
			this.label57.TabIndex = 13;
			this.label57.Text = "颜色条宽度：";
			this.label51.AutoSize = true;
			this.label51.BackColor = System.Drawing.Color.Transparent;
			this.label51.Location = new System.Drawing.Point(25, 18);
			this.label51.Name = "label51";
			this.label51.Size = new System.Drawing.Size(93, 19);
			this.label51.TabIndex = 13;
			this.label51.Text = "颜色条位置：";
			this.numericUpDownColorBarHeight.Location = new System.Drawing.Point(123, 112);
			System.Windows.Forms.NumericUpDown arg_505D_0 = this.numericUpDownColorBarHeight;
			array = new int[4];
			array[0] = 1000;
			arg_505D_0.Maximum = new decimal(array);
			this.numericUpDownColorBarHeight.Name = "numericUpDownColorBarHeight";
			this.numericUpDownColorBarHeight.Size = new System.Drawing.Size(76, 26);
			this.numericUpDownColorBarHeight.TabIndex = 14;
			this.numericUpDownColorBarHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_50BB_0 = this.numericUpDownColorBarHeight;
			array = new int[4];
			array[0] = 1;
			arg_50BB_0.Value = new decimal(array);
			this.label58.AutoSize = true;
			this.label58.BackColor = System.Drawing.Color.Transparent;
			this.label58.Location = new System.Drawing.Point(205, 115);
			this.label58.Name = "label58";
			this.label58.Size = new System.Drawing.Size(37, 19);
			this.label58.TabIndex = 12;
			this.label58.Text = "像素";
			this.numericUpDownColorBarWidth.Location = new System.Drawing.Point(123, 80);
			System.Windows.Forms.NumericUpDown arg_516C_0 = this.numericUpDownColorBarWidth;
			array = new int[4];
			array[0] = 1000;
			arg_516C_0.Maximum = new decimal(array);
			this.numericUpDownColorBarWidth.Name = "numericUpDownColorBarWidth";
			this.numericUpDownColorBarWidth.Size = new System.Drawing.Size(76, 26);
			this.numericUpDownColorBarWidth.TabIndex = 14;
			this.numericUpDownColorBarWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_51CA_0 = this.numericUpDownColorBarWidth;
			array = new int[4];
			array[0] = 1;
			arg_51CA_0.Value = new decimal(array);
			this.label56.AutoSize = true;
			this.label56.BackColor = System.Drawing.Color.Transparent;
			this.label56.Location = new System.Drawing.Point(205, 82);
			this.label56.Name = "label56";
			this.label56.Size = new System.Drawing.Size(37, 19);
			this.label56.TabIndex = 12;
			this.label56.Text = "像素";
			this.numericUpDownColorBarPosY.Location = new System.Drawing.Point(156, 48);
			this.numericUpDownColorBarPosY.Name = "numericUpDownColorBarPosY";
			this.numericUpDownColorBarPosY.Size = new System.Drawing.Size(76, 26);
			this.numericUpDownColorBarPosY.TabIndex = 14;
			this.numericUpDownColorBarPosY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_52BB_0 = this.numericUpDownColorBarPosY;
			array = new int[4];
			array[0] = 1;
			arg_52BB_0.Value = new decimal(array);
			this.label54.AutoSize = true;
			this.label54.BackColor = System.Drawing.Color.Transparent;
			this.label54.Location = new System.Drawing.Point(124, 50);
			this.label54.Name = "label54";
			this.label54.Size = new System.Drawing.Size(29, 19);
			this.label54.TabIndex = 12;
			this.label54.Text = "Y=";
			this.numericUpDownColorBarPosX.Location = new System.Drawing.Point(156, 16);
			this.numericUpDownColorBarPosX.Name = "numericUpDownColorBarPosX";
			this.numericUpDownColorBarPosX.Size = new System.Drawing.Size(76, 26);
			this.numericUpDownColorBarPosX.TabIndex = 14;
			this.numericUpDownColorBarPosX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_53A9_0 = this.numericUpDownColorBarPosX;
			array = new int[4];
			array[0] = 1;
			arg_53A9_0.Value = new decimal(array);
			this.label53.AutoSize = true;
			this.label53.BackColor = System.Drawing.Color.Transparent;
			this.label53.Location = new System.Drawing.Point(124, 18);
			this.label53.Name = "label53";
			this.label53.Size = new System.Drawing.Size(30, 19);
			this.label53.TabIndex = 12;
			this.label53.Text = "X=";
			this.tabItem8.AttachedControl = this.tabControlPanel8;
			this.tabItem8.Name = "tabItem8";
			this.tabItem8.Text = "颜色条";
			this.tabControlPanel7.Controls.Add(this.checkBoxShowKeyArea);
			this.tabControlPanel7.Controls.Add(this.sliderKeyAreaAlpha);
			this.tabControlPanel7.Controls.Add(this.labelKeyAreaAlpha);
			this.tabControlPanel7.Controls.Add(this.label52);
			this.tabControlPanel7.Controls.Add(this.textBoxKeyAreaDataPath);
			this.tabControlPanel7.Controls.Add(this.label49);
			this.tabControlPanel7.Controls.Add(this.buttonChoseKeyAreaColor);
			this.tabControlPanel7.Controls.Add(this.pictureBoxKeyAreaColor);
			this.tabControlPanel7.Controls.Add(this.label50);
			this.tabControlPanel7.Controls.Add(this.listViewKeyArea);
			this.tabControlPanel7.Controls.Add(this.buttonDeleteKeyArea);
			this.tabControlPanel7.Controls.Add(this.buttonAddKeyArea);
			this.tabControlPanel7.Controls.Add(this.buttonModifyKeyArea);
			this.tabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel7.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel7.Name = "tabControlPanel7";
			this.tabControlPanel7.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel7.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel7.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel7.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel7.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel7.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel7.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel7.Style.GradientAngle = 90;
			this.tabControlPanel7.TabIndex = 7;
			this.tabControlPanel7.TabItem = this.tabItem7;
			this.checkBoxShowKeyArea.AutoSize = true;
			this.checkBoxShowKeyArea.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxShowKeyArea.Location = new System.Drawing.Point(29, 16);
			this.checkBoxShowKeyArea.Name = "checkBoxShowKeyArea";
			this.checkBoxShowKeyArea.Size = new System.Drawing.Size(112, 23);
			this.checkBoxShowKeyArea.TabIndex = 50;
			this.checkBoxShowKeyArea.Text = "显示关键区域";
			this.checkBoxShowKeyArea.UseVisualStyleBackColor = false;
			this.sliderKeyAreaAlpha.BackColor = System.Drawing.Color.Transparent;
			this.sliderKeyAreaAlpha.BackgroundStyle.Class = "";
			this.sliderKeyAreaAlpha.LabelVisible = false;
			this.sliderKeyAreaAlpha.Location = new System.Drawing.Point(213, 11);
			this.sliderKeyAreaAlpha.Maximum = 255;
			this.sliderKeyAreaAlpha.Minimum = 1;
			this.sliderKeyAreaAlpha.Name = "sliderKeyAreaAlpha";
			this.sliderKeyAreaAlpha.Size = new System.Drawing.Size(101, 32);
			this.sliderKeyAreaAlpha.TabIndex = 49;
			this.sliderKeyAreaAlpha.Text = "slider1";
			this.sliderKeyAreaAlpha.Value = 10;
			this.sliderKeyAreaAlpha.ValueChanged += new System.EventHandler(this.sliderKeyAreaAlpha_ValueChanged);
			this.labelKeyAreaAlpha.AutoSize = true;
			this.labelKeyAreaAlpha.BackColor = System.Drawing.Color.Transparent;
			this.labelKeyAreaAlpha.Location = new System.Drawing.Point(320, 17);
			this.labelKeyAreaAlpha.Name = "labelKeyAreaAlpha";
			this.labelKeyAreaAlpha.Size = new System.Drawing.Size(27, 19);
			this.labelKeyAreaAlpha.TabIndex = 48;
			this.labelKeyAreaAlpha.Text = "10";
			this.label52.AutoSize = true;
			this.label52.BackColor = System.Drawing.Color.Transparent;
			this.label52.Location = new System.Drawing.Point(147, 17);
			this.label52.Name = "label52";
			this.label52.Size = new System.Drawing.Size(65, 19);
			this.label52.TabIndex = 47;
			this.label52.Text = "透明度：";
			this.textBoxKeyAreaDataPath.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.textBoxKeyAreaDataPath.Border.Class = "TextBoxBorder";
			this.textBoxKeyAreaDataPath.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxKeyAreaDataPath.Location = new System.Drawing.Point(101, 215);
			this.textBoxKeyAreaDataPath.Name = "textBoxKeyAreaDataPath";
			this.textBoxKeyAreaDataPath.Size = new System.Drawing.Size(236, 23);
			this.textBoxKeyAreaDataPath.TabIndex = 46;
			this.textBoxKeyAreaDataPath.Text = "line.lin";
			this.label49.AutoSize = true;
			this.label49.BackColor = System.Drawing.Color.Transparent;
			this.label49.Location = new System.Drawing.Point(25, 217);
			this.label49.Name = "label49";
			this.label49.Size = new System.Drawing.Size(79, 19);
			this.label49.TabIndex = 45;
			this.label49.Text = "数据路径：";
			this.buttonChoseKeyAreaColor.Location = new System.Drawing.Point(238, 182);
			this.buttonChoseKeyAreaColor.Name = "buttonChoseKeyAreaColor";
			this.buttonChoseKeyAreaColor.Size = new System.Drawing.Size(68, 26);
			this.buttonChoseKeyAreaColor.TabIndex = 42;
			this.buttonChoseKeyAreaColor.Text = "选择";
			this.buttonChoseKeyAreaColor.UseVisualStyleBackColor = true;
			this.buttonChoseKeyAreaColor.Click += new System.EventHandler(this.buttonChoseKeyAreaColor_Click);
			this.pictureBoxKeyAreaColor.BackColor = System.Drawing.Color.Red;
			this.pictureBoxKeyAreaColor.Location = new System.Drawing.Point(101, 182);
			this.pictureBoxKeyAreaColor.Name = "pictureBoxKeyAreaColor";
			this.pictureBoxKeyAreaColor.Size = new System.Drawing.Size(131, 26);
			this.pictureBoxKeyAreaColor.TabIndex = 44;
			this.pictureBoxKeyAreaColor.TabStop = false;
			this.label50.AutoSize = true;
			this.label50.BackColor = System.Drawing.Color.Transparent;
			this.label50.Location = new System.Drawing.Point(25, 186);
			this.label50.Name = "label50";
			this.label50.Size = new System.Drawing.Size(79, 19);
			this.label50.TabIndex = 43;
			this.label50.Text = "区域颜色：";
			this.listViewKeyArea.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1
			});
			this.listViewKeyArea.FullRowSelect = true;
			this.listViewKeyArea.GridLines = true;
			this.listViewKeyArea.HideSelection = false;
			this.listViewKeyArea.Location = new System.Drawing.Point(23, 49);
			this.listViewKeyArea.MultiSelect = false;
			this.listViewKeyArea.Name = "listViewKeyArea";
			this.listViewKeyArea.Size = new System.Drawing.Size(329, 126);
			this.listViewKeyArea.TabIndex = 38;
			this.listViewKeyArea.UseCompatibleStateImageBehavior = false;
			this.listViewKeyArea.View = System.Windows.Forms.View.Details;
			this.listViewKeyArea.SelectedIndexChanged += new System.EventHandler(this.listViewKeyArea_SelectedIndexChanged);
			this.columnHeader1.Text = "数据路径";
			this.columnHeader1.Width = 234;
			this.buttonDeleteKeyArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonDeleteKeyArea.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonDeleteKeyArea.Image = Resources.Minus;
			this.buttonDeleteKeyArea.Location = new System.Drawing.Point(134, 247);
			this.buttonDeleteKeyArea.Name = "buttonDeleteKeyArea";
			this.buttonDeleteKeyArea.Size = new System.Drawing.Size(105, 44);
			this.buttonDeleteKeyArea.TabIndex = 39;
			this.buttonDeleteKeyArea.Text = "删\u3000除";
			this.buttonDeleteKeyArea.Click += new System.EventHandler(this.buttonDeleteKeyArea_Click);
			this.buttonAddKeyArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonAddKeyArea.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonAddKeyArea.Image = Resources.Plus;
			this.buttonAddKeyArea.Location = new System.Drawing.Point(23, 247);
			this.buttonAddKeyArea.Name = "buttonAddKeyArea";
			this.buttonAddKeyArea.Size = new System.Drawing.Size(105, 44);
			this.buttonAddKeyArea.TabIndex = 41;
			this.buttonAddKeyArea.Text = "添\u3000加";
			this.buttonAddKeyArea.Click += new System.EventHandler(this.buttonAddKeyArea_Click);
			this.buttonModifyKeyArea.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonModifyKeyArea.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonModifyKeyArea.Image = Resources.未标题_1;
			this.buttonModifyKeyArea.Location = new System.Drawing.Point(245, 247);
			this.buttonModifyKeyArea.Name = "buttonModifyKeyArea";
			this.buttonModifyKeyArea.Size = new System.Drawing.Size(105, 44);
			this.buttonModifyKeyArea.TabIndex = 40;
			this.buttonModifyKeyArea.Text = "修\u3000改";
			this.buttonModifyKeyArea.Click += new System.EventHandler(this.buttonModifyKeyArea_Click);
			this.tabItem7.AttachedControl = this.tabControlPanel7;
			this.tabItem7.Name = "tabItem7";
			this.tabItem7.Text = "关键区域";
			this.tabControlPanel2.Controls.Add(this.textBoxXLineDataPath);
			this.tabControlPanel2.Controls.Add(this.trackBarBoundaryAreaAlpha);
			this.tabControlPanel2.Controls.Add(this.buttonLineDataPath);
			this.tabControlPanel2.Controls.Add(this.checkBoxFillBoundary);
			this.tabControlPanel2.Controls.Add(this.label22);
			this.tabControlPanel2.Controls.Add(this.checkBoxWantBoundary);
			this.tabControlPanel2.Controls.Add(this.labelAlpha);
			this.tabControlPanel2.Controls.Add(this.comboBoxBoundaryLineStyle);
			this.tabControlPanel2.Controls.Add(this.pictureBoxBoundaryLineColor);
			this.tabControlPanel2.Controls.Add(this.numericUpDownBoundaryLineWidth);
			this.tabControlPanel2.Controls.Add(this.label7);
			this.tabControlPanel2.Controls.Add(this.pictureBoxBoundaryAreaColor);
			this.tabControlPanel2.Controls.Add(this.buttonAreaColor);
			this.tabControlPanel2.Controls.Add(this.label6);
			this.tabControlPanel2.Controls.Add(this.label9);
			this.tabControlPanel2.Controls.Add(this.buttonLineColor);
			this.tabControlPanel2.Controls.Add(this.label8);
			this.tabControlPanel2.Controls.Add(this.label5);
			this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel2.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel2.Name = "tabControlPanel2";
			this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel2.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel2.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel2.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel2.Style.GradientAngle = 90;
			this.tabControlPanel2.TabIndex = 2;
			this.tabControlPanel2.TabItem = this.tabItem2;
			this.textBoxXLineDataPath.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.textBoxXLineDataPath.Border.Class = "TextBoxBorder";
			this.textBoxXLineDataPath.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxXLineDataPath.Location = new System.Drawing.Point(102, 120);
			this.textBoxXLineDataPath.Name = "textBoxXLineDataPath";
			this.textBoxXLineDataPath.ReadOnly = true;
			this.textBoxXLineDataPath.Size = new System.Drawing.Size(158, 23);
			this.textBoxXLineDataPath.TabIndex = 34;
			this.textBoxXLineDataPath.Text = "Boundary.dat";
			this.trackBarBoundaryAreaAlpha.BackColor = System.Drawing.Color.Transparent;
			this.trackBarBoundaryAreaAlpha.BackgroundStyle.Class = "";
			this.trackBarBoundaryAreaAlpha.LabelVisible = false;
			this.trackBarBoundaryAreaAlpha.Location = new System.Drawing.Point(102, 187);
			this.trackBarBoundaryAreaAlpha.Maximum = 255;
			this.trackBarBoundaryAreaAlpha.Name = "trackBarBoundaryAreaAlpha";
			this.trackBarBoundaryAreaAlpha.Size = new System.Drawing.Size(199, 32);
			this.trackBarBoundaryAreaAlpha.TabIndex = 30;
			this.trackBarBoundaryAreaAlpha.Text = "slider1";
			this.trackBarBoundaryAreaAlpha.Value = 255;
			this.trackBarBoundaryAreaAlpha.ValueChanged += new System.EventHandler(this.trackBarBoundaryAreaAlpha_ValueChanged);
			this.buttonLineDataPath.Location = new System.Drawing.Point(266, 116);
			this.buttonLineDataPath.Name = "buttonLineDataPath";
			this.buttonLineDataPath.Size = new System.Drawing.Size(68, 31);
			this.buttonLineDataPath.TabIndex = 1;
			this.buttonLineDataPath.Text = "选择";
			this.buttonLineDataPath.UseVisualStyleBackColor = true;
			this.buttonLineDataPath.Click += new System.EventHandler(this.buttonLineDataPath_Click);
			this.label22.AutoSize = true;
			this.label22.BackColor = System.Drawing.Color.Transparent;
			this.label22.Location = new System.Drawing.Point(26, 121);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(79, 19);
			this.label22.TabIndex = 0;
			this.label22.Text = "边界数据：";
			this.pictureBoxBoundaryLineColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxBoundaryLineColor.Location = new System.Drawing.Point(102, 46);
			this.pictureBoxBoundaryLineColor.Name = "pictureBoxBoundaryLineColor";
			this.pictureBoxBoundaryLineColor.Size = new System.Drawing.Size(68, 26);
			this.pictureBoxBoundaryLineColor.TabIndex = 1;
			this.pictureBoxBoundaryLineColor.TabStop = false;
			this.pictureBoxBoundaryAreaColor.BackColor = System.Drawing.Color.White;
			this.pictureBoxBoundaryAreaColor.Location = new System.Drawing.Point(102, 152);
			this.pictureBoxBoundaryAreaColor.Name = "pictureBoxBoundaryAreaColor";
			this.pictureBoxBoundaryAreaColor.Size = new System.Drawing.Size(68, 26);
			this.pictureBoxBoundaryAreaColor.TabIndex = 1;
			this.pictureBoxBoundaryAreaColor.TabStop = false;
			this.tabItem2.AttachedControl = this.tabControlPanel2;
			this.tabItem2.Name = "tabItem2";
			this.tabItem2.Text = "边界";
			this.tabControlPanel4.Controls.Add(this.checkBoxCityTextBold);
			this.tabControlPanel4.Controls.Add(this.label31);
			this.tabControlPanel4.Controls.Add(this.buttonCityTextColorBack);
			this.tabControlPanel4.Controls.Add(this.buttonCityTextColorFore);
			this.tabControlPanel4.Controls.Add(this.pictureBoxCityTextColorBack);
			this.tabControlPanel4.Controls.Add(this.checkBoxWantCity);
			this.tabControlPanel4.Controls.Add(this.label41);
			this.tabControlPanel4.Controls.Add(this.pictureBoxCityTextColorFore);
			this.tabControlPanel4.Controls.Add(this.label20);
			this.tabControlPanel4.Controls.Add(this.numericUpDownCityTextHeight);
			this.tabControlPanel4.Controls.Add(this.label19);
			this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel4.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel4.Name = "tabControlPanel4";
			this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel4.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel4.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel4.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel4.Style.GradientAngle = 90;
			this.tabControlPanel4.TabIndex = 4;
			this.tabControlPanel4.TabItem = this.tabItem4;
			this.checkBoxCityTextBold.AutoSize = true;
			this.checkBoxCityTextBold.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxCityTextBold.Location = new System.Drawing.Point(245, 112);
			this.checkBoxCityTextBold.Name = "checkBoxCityTextBold";
			this.checkBoxCityTextBold.Size = new System.Drawing.Size(56, 23);
			this.checkBoxCityTextBold.TabIndex = 14;
			this.checkBoxCityTextBold.Text = "加粗";
			this.checkBoxCityTextBold.UseVisualStyleBackColor = false;
			this.label31.AutoSize = true;
			this.label31.BackColor = System.Drawing.Color.Transparent;
			this.label31.Location = new System.Drawing.Point(202, 112);
			this.label31.Name = "label31";
			this.label31.Size = new System.Drawing.Size(37, 19);
			this.label31.TabIndex = 13;
			this.label31.Text = "像素";
			this.buttonCityTextColorBack.Location = new System.Drawing.Point(202, 76);
			this.buttonCityTextColorBack.Name = "buttonCityTextColorBack";
			this.buttonCityTextColorBack.Size = new System.Drawing.Size(68, 26);
			this.buttonCityTextColorBack.TabIndex = 0;
			this.buttonCityTextColorBack.Text = "选择";
			this.buttonCityTextColorBack.UseVisualStyleBackColor = true;
			this.buttonCityTextColorBack.Click += new System.EventHandler(this.buttonCityTextColorBack_Click);
			this.pictureBoxCityTextColorBack.BackColor = System.Drawing.Color.Red;
			this.pictureBoxCityTextColorBack.Location = new System.Drawing.Point(133, 76);
			this.pictureBoxCityTextColorBack.Name = "pictureBoxCityTextColorBack";
			this.pictureBoxCityTextColorBack.Size = new System.Drawing.Size(63, 26);
			this.pictureBoxCityTextColorBack.TabIndex = 1;
			this.pictureBoxCityTextColorBack.TabStop = false;
			this.label41.AutoSize = true;
			this.label41.BackColor = System.Drawing.Color.Transparent;
			this.label41.Location = new System.Drawing.Point(23, 80);
			this.label41.Name = "label41";
			this.label41.Size = new System.Drawing.Size(107, 19);
			this.label41.TabIndex = 0;
			this.label41.Text = "文字背景颜色：";
			this.pictureBoxCityTextColorFore.BackColor = System.Drawing.Color.Red;
			this.pictureBoxCityTextColorFore.Location = new System.Drawing.Point(133, 44);
			this.pictureBoxCityTextColorFore.Name = "pictureBoxCityTextColorFore";
			this.pictureBoxCityTextColorFore.Size = new System.Drawing.Size(63, 26);
			this.pictureBoxCityTextColorFore.TabIndex = 1;
			this.pictureBoxCityTextColorFore.TabStop = false;
			this.tabItem4.AttachedControl = this.tabControlPanel4;
			this.tabItem4.Name = "tabItem4";
			this.tabItem4.Text = "主要城市";
			this.tabControlPanel3.Controls.Add(this.comboBoxLonLatLineStyle);
			this.tabControlPanel3.Controls.Add(this.buttonLonLatLineColor);
			this.tabControlPanel3.Controls.Add(this.checkBoxLonLatTextBold);
			this.tabControlPanel3.Controls.Add(this.checkBoxWantLonLat);
			this.tabControlPanel3.Controls.Add(this.label14);
			this.tabControlPanel3.Controls.Add(this.numericUpDownLonLatStep);
			this.tabControlPanel3.Controls.Add(this.numericUpDownLonLatTextHeight);
			this.tabControlPanel3.Controls.Add(this.label13);
			this.tabControlPanel3.Controls.Add(this.numericUpDownLonLatLineWidth);
			this.tabControlPanel3.Controls.Add(this.buttonLonLatTextColor);
			this.tabControlPanel3.Controls.Add(this.pictureBoxLonLatTextColor);
			this.tabControlPanel3.Controls.Add(this.label12);
			this.tabControlPanel3.Controls.Add(this.pictureBoxLonLatLineColor);
			this.tabControlPanel3.Controls.Add(this.label25);
			this.tabControlPanel3.Controls.Add(this.label26);
			this.tabControlPanel3.Controls.Add(this.label24);
			this.tabControlPanel3.Controls.Add(this.label23);
			this.tabControlPanel3.Controls.Add(this.label15);
			this.tabControlPanel3.Controls.Add(this.label16);
			this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel3.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel3.Name = "tabControlPanel3";
			this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel3.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel3.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel3.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel3.Style.GradientAngle = 90;
			this.tabControlPanel3.TabIndex = 3;
			this.tabControlPanel3.TabItem = this.tabItem3;
			this.checkBoxLonLatTextBold.AutoSize = true;
			this.checkBoxLonLatTextBold.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxLonLatTextBold.Location = new System.Drawing.Point(249, 203);
			this.checkBoxLonLatTextBold.Name = "checkBoxLonLatTextBold";
			this.checkBoxLonLatTextBold.Size = new System.Drawing.Size(56, 23);
			this.checkBoxLonLatTextBold.TabIndex = 12;
			this.checkBoxLonLatTextBold.Text = "加粗";
			this.checkBoxLonLatTextBold.UseVisualStyleBackColor = false;
			this.numericUpDownLonLatStep.DecimalPlaces = 1;
			this.numericUpDownLonLatStep.Increment = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDownLonLatStep.Location = new System.Drawing.Point(124, 137);
			this.numericUpDownLonLatStep.Maximum = new decimal(new int[]
			{
				200,
				0,
				0,
				65536
			});
			this.numericUpDownLonLatStep.Minimum = new decimal(new int[]
			{
				1,
				0,
				0,
				65536
			});
			this.numericUpDownLonLatStep.Name = "numericUpDownLonLatStep";
			this.numericUpDownLonLatStep.Size = new System.Drawing.Size(76, 26);
			this.numericUpDownLonLatStep.TabIndex = 11;
			this.numericUpDownLonLatStep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_6ED1_0 = this.numericUpDownLonLatStep;
			array = new int[4];
			array[0] = 1;
			arg_6ED1_0.Value = new decimal(array);
			this.pictureBoxLonLatTextColor.BackColor = System.Drawing.Color.Red;
			this.pictureBoxLonLatTextColor.Location = new System.Drawing.Point(124, 169);
			this.pictureBoxLonLatTextColor.Name = "pictureBoxLonLatTextColor";
			this.pictureBoxLonLatTextColor.Size = new System.Drawing.Size(76, 26);
			this.pictureBoxLonLatTextColor.TabIndex = 1;
			this.pictureBoxLonLatTextColor.TabStop = false;
			this.pictureBoxLonLatLineColor.BackColor = System.Drawing.Color.Black;
			this.pictureBoxLonLatLineColor.Location = new System.Drawing.Point(124, 40);
			this.pictureBoxLonLatLineColor.Name = "pictureBoxLonLatLineColor";
			this.pictureBoxLonLatLineColor.Size = new System.Drawing.Size(76, 26);
			this.pictureBoxLonLatLineColor.TabIndex = 1;
			this.pictureBoxLonLatLineColor.TabStop = false;
			this.label25.AutoSize = true;
			this.label25.BackColor = System.Drawing.Color.Transparent;
			this.label25.Location = new System.Drawing.Point(206, 139);
			this.label25.Name = "label25";
			this.label25.Size = new System.Drawing.Size(58, 19);
			this.label25.TabIndex = 0;
			this.label25.Text = "经/纬度";
			this.label26.AutoSize = true;
			this.label26.BackColor = System.Drawing.Color.Transparent;
			this.label26.Location = new System.Drawing.Point(206, 203);
			this.label26.Name = "label26";
			this.label26.Size = new System.Drawing.Size(37, 19);
			this.label26.TabIndex = 0;
			this.label26.Text = "像素";
			this.label24.AutoSize = true;
			this.label24.BackColor = System.Drawing.Color.Transparent;
			this.label24.Location = new System.Drawing.Point(206, 74);
			this.label24.Name = "label24";
			this.label24.Size = new System.Drawing.Size(37, 19);
			this.label24.TabIndex = 0;
			this.label24.Text = "像素";
			this.label23.AutoSize = true;
			this.label23.BackColor = System.Drawing.Color.Transparent;
			this.label23.Location = new System.Drawing.Point(25, 137);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(93, 19);
			this.label23.TabIndex = 0;
			this.label23.Text = "经纬线间隔：";
			this.tabItem3.AttachedControl = this.tabControlPanel3;
			this.tabItem3.Name = "tabItem3";
			this.tabItem3.Text = "经纬线";
			this.tabControlPanel5.Controls.Add(this.checkBoxWantRiver);
			this.tabControlPanel5.Controls.Add(this.comboBoxRiverStyle);
			this.tabControlPanel5.Controls.Add(this.checkBoxWantProvince);
			this.tabControlPanel5.Controls.Add(this.pictureBoxRiverColor);
			this.tabControlPanel5.Controls.Add(this.comboBoxProvinceLineStyle);
			this.tabControlPanel5.Controls.Add(this.numericUpDownRiverWidth);
			this.tabControlPanel5.Controls.Add(this.pictureBoxProvinceLineColor);
			this.tabControlPanel5.Controls.Add(this.label39);
			this.tabControlPanel5.Controls.Add(this.numericUpDownProvinceLineWidth);
			this.tabControlPanel5.Controls.Add(this.buttonRiverColor);
			this.tabControlPanel5.Controls.Add(this.label34);
			this.tabControlPanel5.Controls.Add(this.label38);
			this.tabControlPanel5.Controls.Add(this.buttonProvinceLineColor);
			this.tabControlPanel5.Controls.Add(this.label37);
			this.tabControlPanel5.Controls.Add(this.label35);
			this.tabControlPanel5.Controls.Add(this.label36);
			this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel5.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel5.Name = "tabControlPanel5";
			this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel5.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel5.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel5.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel5.Style.GradientAngle = 90;
			this.tabControlPanel5.TabIndex = 5;
			this.tabControlPanel5.TabItem = this.tabItem5;
			this.checkBoxWantRiver.AutoSize = true;
			this.checkBoxWantRiver.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxWantRiver.Location = new System.Drawing.Point(29, 124);
			this.checkBoxWantRiver.Name = "checkBoxWantRiver";
			this.checkBoxWantRiver.Size = new System.Drawing.Size(84, 23);
			this.checkBoxWantRiver.TabIndex = 21;
			this.checkBoxWantRiver.Text = "显示河流";
			this.checkBoxWantRiver.UseVisualStyleBackColor = false;
			this.comboBoxRiverStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxRiverStyle.FormattingEnabled = true;
			this.comboBoxRiverStyle.Items.AddRange(new object[]
			{
				"— — — —",
				"—.—.—.—",
				"—. .—. .—",
				". . . . . . . . . ",
				"—————"
			});
			this.comboBoxRiverStyle.Location = new System.Drawing.Point(234, 191);
			this.comboBoxRiverStyle.Name = "comboBoxRiverStyle";
			this.comboBoxRiverStyle.Size = new System.Drawing.Size(100, 27);
			this.comboBoxRiverStyle.TabIndex = 20;
			this.checkBoxWantProvince.AutoSize = true;
			this.checkBoxWantProvince.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxWantProvince.Location = new System.Drawing.Point(29, 16);
			this.checkBoxWantProvince.Name = "checkBoxWantProvince";
			this.checkBoxWantProvince.Size = new System.Drawing.Size(84, 23);
			this.checkBoxWantProvince.TabIndex = 21;
			this.checkBoxWantProvince.Text = "显示省界";
			this.checkBoxWantProvince.UseVisualStyleBackColor = false;
			this.pictureBoxRiverColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxRiverColor.Location = new System.Drawing.Point(102, 154);
			this.pictureBoxRiverColor.Name = "pictureBoxRiverColor";
			this.pictureBoxRiverColor.Size = new System.Drawing.Size(68, 26);
			this.pictureBoxRiverColor.TabIndex = 18;
			this.pictureBoxRiverColor.TabStop = false;
			this.comboBoxProvinceLineStyle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxProvinceLineStyle.FormattingEnabled = true;
			this.comboBoxProvinceLineStyle.Items.AddRange(new object[]
			{
				"— — — —",
				"—.—.—.—",
				"—. .—. .—",
				". . . . . . . . . ",
				"—————"
			});
			this.comboBoxProvinceLineStyle.Location = new System.Drawing.Point(234, 83);
			this.comboBoxProvinceLineStyle.Name = "comboBoxProvinceLineStyle";
			this.comboBoxProvinceLineStyle.Size = new System.Drawing.Size(100, 27);
			this.comboBoxProvinceLineStyle.TabIndex = 20;
			this.numericUpDownRiverWidth.Location = new System.Drawing.Point(102, 191);
			System.Windows.Forms.NumericUpDown arg_7761_0 = this.numericUpDownRiverWidth;
			array = new int[4];
			array[0] = 10;
			arg_7761_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_777E_0 = this.numericUpDownRiverWidth;
			array = new int[4];
			array[0] = 1;
			arg_777E_0.Minimum = new decimal(array);
			this.numericUpDownRiverWidth.Name = "numericUpDownRiverWidth";
			this.numericUpDownRiverWidth.Size = new System.Drawing.Size(50, 26);
			this.numericUpDownRiverWidth.TabIndex = 19;
			this.numericUpDownRiverWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_77DC_0 = this.numericUpDownRiverWidth;
			array = new int[4];
			array[0] = 1;
			arg_77DC_0.Value = new decimal(array);
			this.pictureBoxProvinceLineColor.BackColor = System.Drawing.Color.Yellow;
			this.pictureBoxProvinceLineColor.Location = new System.Drawing.Point(102, 46);
			this.pictureBoxProvinceLineColor.Name = "pictureBoxProvinceLineColor";
			this.pictureBoxProvinceLineColor.Size = new System.Drawing.Size(68, 26);
			this.pictureBoxProvinceLineColor.TabIndex = 18;
			this.pictureBoxProvinceLineColor.TabStop = false;
			this.label39.AutoSize = true;
			this.label39.BackColor = System.Drawing.Color.Transparent;
			this.label39.Location = new System.Drawing.Point(158, 194);
			this.label39.Name = "label39";
			this.label39.Size = new System.Drawing.Size(79, 19);
			this.label39.TabIndex = 15;
			this.label39.Text = "线条类型：";
			this.numericUpDownProvinceLineWidth.Location = new System.Drawing.Point(102, 83);
			System.Windows.Forms.NumericUpDown arg_78F4_0 = this.numericUpDownProvinceLineWidth;
			array = new int[4];
			array[0] = 10;
			arg_78F4_0.Maximum = new decimal(array);
			System.Windows.Forms.NumericUpDown arg_7911_0 = this.numericUpDownProvinceLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_7911_0.Minimum = new decimal(array);
			this.numericUpDownProvinceLineWidth.Name = "numericUpDownProvinceLineWidth";
			this.numericUpDownProvinceLineWidth.Size = new System.Drawing.Size(50, 26);
			this.numericUpDownProvinceLineWidth.TabIndex = 19;
			this.numericUpDownProvinceLineWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_796F_0 = this.numericUpDownProvinceLineWidth;
			array = new int[4];
			array[0] = 1;
			arg_796F_0.Value = new decimal(array);
			this.buttonRiverColor.Location = new System.Drawing.Point(176, 155);
			this.buttonRiverColor.Name = "buttonRiverColor";
			this.buttonRiverColor.Size = new System.Drawing.Size(68, 26);
			this.buttonRiverColor.TabIndex = 14;
			this.buttonRiverColor.Text = "选择";
			this.buttonRiverColor.UseVisualStyleBackColor = true;
			this.buttonRiverColor.Click += new System.EventHandler(this.buttonRiverColor_Click);
			this.label34.AutoSize = true;
			this.label34.BackColor = System.Drawing.Color.Transparent;
			this.label34.Location = new System.Drawing.Point(158, 86);
			this.label34.Name = "label34";
			this.label34.Size = new System.Drawing.Size(79, 19);
			this.label34.TabIndex = 15;
			this.label34.Text = "线条类型：";
			this.label38.AutoSize = true;
			this.label38.BackColor = System.Drawing.Color.Transparent;
			this.label38.Location = new System.Drawing.Point(26, 193);
			this.label38.Name = "label38";
			this.label38.Size = new System.Drawing.Size(79, 19);
			this.label38.TabIndex = 17;
			this.label38.Text = "河流粗细：";
			this.buttonProvinceLineColor.Location = new System.Drawing.Point(176, 47);
			this.buttonProvinceLineColor.Name = "buttonProvinceLineColor";
			this.buttonProvinceLineColor.Size = new System.Drawing.Size(68, 26);
			this.buttonProvinceLineColor.TabIndex = 14;
			this.buttonProvinceLineColor.Text = "选择";
			this.buttonProvinceLineColor.UseVisualStyleBackColor = true;
			this.buttonProvinceLineColor.Click += new System.EventHandler(this.buttonProvinceLineColor_Click);
			this.label37.AutoSize = true;
			this.label37.BackColor = System.Drawing.Color.Transparent;
			this.label37.Location = new System.Drawing.Point(25, 156);
			this.label37.Name = "label37";
			this.label37.Size = new System.Drawing.Size(79, 19);
			this.label37.TabIndex = 16;
			this.label37.Text = "河流颜色：";
			this.label35.AutoSize = true;
			this.label35.BackColor = System.Drawing.Color.Transparent;
			this.label35.Location = new System.Drawing.Point(26, 85);
			this.label35.Name = "label35";
			this.label35.Size = new System.Drawing.Size(79, 19);
			this.label35.TabIndex = 17;
			this.label35.Text = "省界粗细：";
			this.label36.AutoSize = true;
			this.label36.BackColor = System.Drawing.Color.Transparent;
			this.label36.Location = new System.Drawing.Point(25, 48);
			this.label36.Name = "label36";
			this.label36.Size = new System.Drawing.Size(79, 19);
			this.label36.TabIndex = 16;
			this.label36.Text = "省界颜色：";
			this.tabItem5.AttachedControl = this.tabControlPanel5;
			this.tabItem5.Name = "tabItem5";
			this.tabItem5.Text = "省界河流";
			this.tabControlPanel6.Controls.Add(this.checkBoxStationTextBold);
			this.tabControlPanel6.Controls.Add(this.textBoxStationDataPath2);
			this.tabControlPanel6.Controls.Add(this.textBoxStationDataPath1);
			this.tabControlPanel6.Controls.Add(this.label48);
			this.tabControlPanel6.Controls.Add(this.label44);
			this.tabControlPanel6.Controls.Add(this.label32);
			this.tabControlPanel6.Controls.Add(this.label47);
			this.tabControlPanel6.Controls.Add(this.checkBoxShowStationInThumb);
			this.tabControlPanel6.Controls.Add(this.checkBoxWantStation);
			this.tabControlPanel6.Controls.Add(this.label42);
			this.tabControlPanel6.Controls.Add(this.label18);
			this.tabControlPanel6.Controls.Add(this.buttonStationTextColorBack2);
			this.tabControlPanel6.Controls.Add(this.numericUpDownStationTextHeight);
			this.tabControlPanel6.Controls.Add(this.buttonStationTextColorFore2);
			this.tabControlPanel6.Controls.Add(this.buttonStationTextColorBack1);
			this.tabControlPanel6.Controls.Add(this.pictureBoxStationTextColorBack2);
			this.tabControlPanel6.Controls.Add(this.buttonStationTextColorFore1);
			this.tabControlPanel6.Controls.Add(this.pictureBoxStationTextColorFore2);
			this.tabControlPanel6.Controls.Add(this.pictureBoxStationTextColorBack1);
			this.tabControlPanel6.Controls.Add(this.label46);
			this.tabControlPanel6.Controls.Add(this.pictureBoxStationTextColorFore1);
			this.tabControlPanel6.Controls.Add(this.label45);
			this.tabControlPanel6.Controls.Add(this.label43);
			this.tabControlPanel6.Controls.Add(this.label17);
			this.tabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlPanel6.Location = new System.Drawing.Point(0, 59);
			this.tabControlPanel6.Name = "tabControlPanel6";
			this.tabControlPanel6.Padding = new System.Windows.Forms.Padding(1);
			this.tabControlPanel6.Size = new System.Drawing.Size(374, 348);
			this.tabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(253, 253, 254);
			this.tabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(157, 188, 227);
			this.tabControlPanel6.Style.Border = eBorderType.SingleLine;
			this.tabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(146, 165, 199);
			this.tabControlPanel6.Style.BorderSide = (eBorderSide.Left | eBorderSide.Right | eBorderSide.Bottom);
			this.tabControlPanel6.Style.GradientAngle = 90;
			this.tabControlPanel6.TabIndex = 6;
			this.tabControlPanel6.TabItem = this.tabItem6;
			this.checkBoxStationTextBold.AutoSize = true;
			this.checkBoxStationTextBold.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxStationTextBold.Location = new System.Drawing.Point(244, 46);
			this.checkBoxStationTextBold.Name = "checkBoxStationTextBold";
			this.checkBoxStationTextBold.Size = new System.Drawing.Size(56, 23);
			this.checkBoxStationTextBold.TabIndex = 38;
			this.checkBoxStationTextBold.Text = "加粗";
			this.checkBoxStationTextBold.UseVisualStyleBackColor = false;
			this.textBoxStationDataPath2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.textBoxStationDataPath2.Border.Class = "TextBoxBorder";
			this.textBoxStationDataPath2.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxStationDataPath2.Location = new System.Drawing.Point(100, 294);
			this.textBoxStationDataPath2.Name = "textBoxStationDataPath2";
			this.textBoxStationDataPath2.Size = new System.Drawing.Size(236, 23);
			this.textBoxStationDataPath2.TabIndex = 37;
			this.textBoxStationDataPath2.Text = "Station.sta";
			this.textBoxStationDataPath1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.textBoxStationDataPath1.Border.Class = "TextBoxBorder";
			this.textBoxStationDataPath1.Font = new System.Drawing.Font("微软雅黑", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBoxStationDataPath1.Location = new System.Drawing.Point(100, 167);
			this.textBoxStationDataPath1.Name = "textBoxStationDataPath1";
			this.textBoxStationDataPath1.Size = new System.Drawing.Size(236, 23);
			this.textBoxStationDataPath1.TabIndex = 37;
			this.textBoxStationDataPath1.Text = "Station.sta";
			this.label48.AutoSize = true;
			this.label48.BackColor = System.Drawing.Color.Transparent;
			this.label48.Location = new System.Drawing.Point(24, 296);
			this.label48.Name = "label48";
			this.label48.Size = new System.Drawing.Size(79, 19);
			this.label48.TabIndex = 35;
			this.label48.Text = "站点数据：";
			this.label44.AutoSize = true;
			this.label44.BackColor = System.Drawing.Color.Transparent;
			this.label44.Location = new System.Drawing.Point(24, 169);
			this.label44.Name = "label44";
			this.label44.Size = new System.Drawing.Size(79, 19);
			this.label44.TabIndex = 35;
			this.label44.Text = "站点数据：";
			this.label32.AutoSize = true;
			this.label32.BackColor = System.Drawing.Color.Transparent;
			this.label32.Location = new System.Drawing.Point(201, 47);
			this.label32.Name = "label32";
			this.label32.Size = new System.Drawing.Size(37, 19);
			this.label32.TabIndex = 20;
			this.label32.Text = "像素";
			this.label47.AutoSize = true;
			this.label47.BackColor = System.Drawing.Color.Transparent;
			this.label47.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label47.ForeColor = System.Drawing.Color.Maroon;
			this.label47.Location = new System.Drawing.Point(24, 202);
			this.label47.Name = "label47";
			this.label47.Size = new System.Drawing.Size(84, 22);
			this.label47.TabIndex = 14;
			this.label47.Text = "站点列表2";
			this.checkBoxShowStationInThumb.AutoSize = true;
			this.checkBoxShowStationInThumb.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxShowStationInThumb.Location = new System.Drawing.Point(172, 16);
			this.checkBoxShowStationInThumb.Name = "checkBoxShowStationInThumb";
			this.checkBoxShowStationInThumb.Size = new System.Drawing.Size(154, 23);
			this.checkBoxShowStationInThumb.TabIndex = 19;
			this.checkBoxShowStationInThumb.Text = "显示站点在缩略图上";
			this.checkBoxShowStationInThumb.UseVisualStyleBackColor = false;
			this.checkBoxWantStation.AutoSize = true;
			this.checkBoxWantStation.BackColor = System.Drawing.Color.Transparent;
			this.checkBoxWantStation.Location = new System.Drawing.Point(29, 16);
			this.checkBoxWantStation.Name = "checkBoxWantStation";
			this.checkBoxWantStation.Size = new System.Drawing.Size(140, 23);
			this.checkBoxWantStation.TabIndex = 19;
			this.checkBoxWantStation.Text = "显示站点在地图上";
			this.checkBoxWantStation.UseVisualStyleBackColor = false;
			this.label42.AutoSize = true;
			this.label42.BackColor = System.Drawing.Color.Transparent;
			this.label42.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label42.ForeColor = System.Drawing.Color.Maroon;
			this.label42.Location = new System.Drawing.Point(24, 75);
			this.label42.Name = "label42";
			this.label42.Size = new System.Drawing.Size(84, 22);
			this.label42.TabIndex = 14;
			this.label42.Text = "站点列表1";
			this.label18.AutoSize = true;
			this.label18.BackColor = System.Drawing.Color.Transparent;
			this.label18.Location = new System.Drawing.Point(25, 47);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(107, 19);
			this.label18.TabIndex = 14;
			this.label18.Text = "站点文字大小：";
			this.buttonStationTextColorBack2.Location = new System.Drawing.Point(268, 261);
			this.buttonStationTextColorBack2.Name = "buttonStationTextColorBack2";
			this.buttonStationTextColorBack2.Size = new System.Drawing.Size(68, 26);
			this.buttonStationTextColorBack2.TabIndex = 15;
			this.buttonStationTextColorBack2.Text = "选择";
			this.buttonStationTextColorBack2.UseVisualStyleBackColor = true;
			this.buttonStationTextColorBack2.Click += new System.EventHandler(this.buttonStationTextColorBack2_Click);
			this.numericUpDownStationTextHeight.Location = new System.Drawing.Point(132, 43);
			System.Windows.Forms.NumericUpDown arg_8750_0 = this.numericUpDownStationTextHeight;
			array = new int[4];
			array[0] = 1;
			arg_8750_0.Minimum = new decimal(array);
			this.numericUpDownStationTextHeight.Name = "numericUpDownStationTextHeight";
			this.numericUpDownStationTextHeight.Size = new System.Drawing.Size(63, 26);
			this.numericUpDownStationTextHeight.TabIndex = 18;
			this.numericUpDownStationTextHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			System.Windows.Forms.NumericUpDown arg_87AE_0 = this.numericUpDownStationTextHeight;
			array = new int[4];
			array[0] = 1;
			arg_87AE_0.Value = new decimal(array);
			this.buttonStationTextColorFore2.Location = new System.Drawing.Point(268, 229);
			this.buttonStationTextColorFore2.Name = "buttonStationTextColorFore2";
			this.buttonStationTextColorFore2.Size = new System.Drawing.Size(68, 26);
			this.buttonStationTextColorFore2.TabIndex = 15;
			this.buttonStationTextColorFore2.Text = "选择";
			this.buttonStationTextColorFore2.UseVisualStyleBackColor = true;
			this.buttonStationTextColorFore2.Click += new System.EventHandler(this.buttonStationTextColorFore2_Click);
			this.buttonStationTextColorBack1.Location = new System.Drawing.Point(268, 134);
			this.buttonStationTextColorBack1.Name = "buttonStationTextColorBack1";
			this.buttonStationTextColorBack1.Size = new System.Drawing.Size(68, 26);
			this.buttonStationTextColorBack1.TabIndex = 15;
			this.buttonStationTextColorBack1.Text = "选择";
			this.buttonStationTextColorBack1.UseVisualStyleBackColor = true;
			this.buttonStationTextColorBack1.Click += new System.EventHandler(this.buttonStationTextColorBack1_Click);
			this.pictureBoxStationTextColorBack2.BackColor = System.Drawing.Color.Red;
			this.pictureBoxStationTextColorBack2.Location = new System.Drawing.Point(131, 261);
			this.pictureBoxStationTextColorBack2.Name = "pictureBoxStationTextColorBack2";
			this.pictureBoxStationTextColorBack2.Size = new System.Drawing.Size(131, 26);
			this.pictureBoxStationTextColorBack2.TabIndex = 17;
			this.pictureBoxStationTextColorBack2.TabStop = false;
			this.buttonStationTextColorFore1.Location = new System.Drawing.Point(268, 102);
			this.buttonStationTextColorFore1.Name = "buttonStationTextColorFore1";
			this.buttonStationTextColorFore1.Size = new System.Drawing.Size(68, 26);
			this.buttonStationTextColorFore1.TabIndex = 15;
			this.buttonStationTextColorFore1.Text = "选择";
			this.buttonStationTextColorFore1.UseVisualStyleBackColor = true;
			this.buttonStationTextColorFore1.Click += new System.EventHandler(this.buttonStationTextColorFore1_Click);
			this.pictureBoxStationTextColorFore2.BackColor = System.Drawing.Color.Red;
			this.pictureBoxStationTextColorFore2.Location = new System.Drawing.Point(131, 229);
			this.pictureBoxStationTextColorFore2.Name = "pictureBoxStationTextColorFore2";
			this.pictureBoxStationTextColorFore2.Size = new System.Drawing.Size(131, 26);
			this.pictureBoxStationTextColorFore2.TabIndex = 17;
			this.pictureBoxStationTextColorFore2.TabStop = false;
			this.pictureBoxStationTextColorBack1.BackColor = System.Drawing.Color.Red;
			this.pictureBoxStationTextColorBack1.Location = new System.Drawing.Point(131, 134);
			this.pictureBoxStationTextColorBack1.Name = "pictureBoxStationTextColorBack1";
			this.pictureBoxStationTextColorBack1.Size = new System.Drawing.Size(131, 26);
			this.pictureBoxStationTextColorBack1.TabIndex = 17;
			this.pictureBoxStationTextColorBack1.TabStop = false;
			this.label46.AutoSize = true;
			this.label46.BackColor = System.Drawing.Color.Transparent;
			this.label46.Location = new System.Drawing.Point(24, 265);
			this.label46.Name = "label46";
			this.label46.Size = new System.Drawing.Size(107, 19);
			this.label46.TabIndex = 16;
			this.label46.Text = "文字背景颜色：";
			this.pictureBoxStationTextColorFore1.BackColor = System.Drawing.Color.Red;
			this.pictureBoxStationTextColorFore1.Location = new System.Drawing.Point(131, 102);
			this.pictureBoxStationTextColorFore1.Name = "pictureBoxStationTextColorFore1";
			this.pictureBoxStationTextColorFore1.Size = new System.Drawing.Size(131, 26);
			this.pictureBoxStationTextColorFore1.TabIndex = 17;
			this.pictureBoxStationTextColorFore1.TabStop = false;
			this.label45.AutoSize = true;
			this.label45.BackColor = System.Drawing.Color.Transparent;
			this.label45.Location = new System.Drawing.Point(24, 233);
			this.label45.Name = "label45";
			this.label45.Size = new System.Drawing.Size(107, 19);
			this.label45.TabIndex = 16;
			this.label45.Text = "文字前景颜色：";
			this.label43.AutoSize = true;
			this.label43.BackColor = System.Drawing.Color.Transparent;
			this.label43.Location = new System.Drawing.Point(24, 138);
			this.label43.Name = "label43";
			this.label43.Size = new System.Drawing.Size(107, 19);
			this.label43.TabIndex = 16;
			this.label43.Text = "文字背景颜色：";
			this.label17.AutoSize = true;
			this.label17.BackColor = System.Drawing.Color.Transparent;
			this.label17.Location = new System.Drawing.Point(24, 106);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(107, 19);
			this.label17.TabIndex = 16;
			this.label17.Text = "文字前景颜色：";
			this.tabItem6.AttachedControl = this.tabControlPanel6;
			this.tabItem6.Name = "tabItem6";
			this.tabItem6.Text = "站点参数";
			this.openFileDialog.Filter = "边界数据(*.lin)|*.lin|所有文件(*.*)|*.*";
			this.openFileDialogaMap.Filter = "底图文件(*.map)|*.map|所有文件(*.*)|*.*";
			this.tabItem10.AttachedControl = this.tabControlPanel7;
			this.tabItem10.Name = "tabItem10";
			this.tabItem10.Text = "关键区域";
			this.buttonItem2.Name = "buttonItem2";
			this.buttonItem2.Text = "鼠标信息";
			this.buttonItem1.Name = "buttonItem1";
			this.buttonItem1.Text = "颜色条";
			this.buttonSystem7.Name = "buttonSystem7";
			this.buttonSystem7.Text = "关键区域";
			this.buttonSystem6.Name = "buttonSystem6";
			this.buttonSystem6.Text = "站点";
			this.buttonSystem5.Name = "buttonSystem5";
			this.buttonSystem5.Text = "省界和河流";
			this.buttonSystem4.Name = "buttonSystem4";
			this.buttonSystem4.OptionGroup = "dotnetbar";
			this.buttonSystem4.Text = "城市";
			this.buttonSystem3.Name = "buttonSystem3";
			this.buttonSystem3.OptionGroup = "dotnetbar";
			this.buttonSystem3.Text = "经纬线参数";
			this.buttonSystem2.Name = "buttonSystem2";
			this.buttonSystem2.OptionGroup = "dotnetbar";
			this.buttonSystem2.Text = "边界参数";
			this.buttonSystem1.Name = "buttonSystem1";
			this.buttonSystem1.OptionGroup = "dotnetbar";
			this.buttonSystem1.Text = "地图参数";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(895, 543);
			base.ControlBox = false;
			base.Controls.Add(this.ribbonClientPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "MapSettingForm";
			base.ShowInTaskbar = false;
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "地图参数设置";
			base.Load += new System.EventHandler(this.SettingForm_Load);
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCityTextHeight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLonLatTextHeight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLonLatLineWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownBoundaryLineWidth).EndInit();
			this.ribbonClientPanel1.ResumeLayout(false);
			this.groupPanelPreview.ResumeLayout(false);
			this.groupPanelPreview.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxPreview).EndInit();
			((System.ComponentModel.ISupportInitialize)this.tabControl1).EndInit();
			this.tabControl1.ResumeLayout(false);
			this.tabControlPanel1.ResumeLayout(false);
			this.tabControlPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEdgeTop).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEdgeBottom).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownPicHeight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownPicWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEdgeRight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownEdgeLeft).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBackgroundColor).EndInit();
			this.tabControlPanel10.ResumeLayout(false);
			this.tabControlPanel10.PerformLayout();
			this.groupPanel2.ResumeLayout(false);
			this.groupPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStandardLat).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStandardLon).EndInit();
			this.groupPanel1.ResumeLayout(false);
			this.groupPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownWHScale).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCenterLat).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownCenterLon).EndInit();
			this.tabControlPanel9.ResumeLayout(false);
			this.tabControlPanel9.PerformLayout();
			this.tabControlPanel8.ResumeLayout(false);
			this.tabControlPanel8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorBarHeight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorBarWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorBarPosY).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownColorBarPosX).EndInit();
			this.tabControlPanel7.ResumeLayout(false);
			this.tabControlPanel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxKeyAreaColor).EndInit();
			this.tabControlPanel2.ResumeLayout(false);
			this.tabControlPanel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBoundaryLineColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxBoundaryAreaColor).EndInit();
			this.tabControlPanel4.ResumeLayout(false);
			this.tabControlPanel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxCityTextColorBack).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxCityTextColorFore).EndInit();
			this.tabControlPanel3.ResumeLayout(false);
			this.tabControlPanel3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLonLatStep).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxLonLatTextColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxLonLatLineColor).EndInit();
			this.tabControlPanel5.ResumeLayout(false);
			this.tabControlPanel5.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxRiverColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownRiverWidth).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxProvinceLineColor).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownProvinceLineWidth).EndInit();
			this.tabControlPanel6.ResumeLayout(false);
			this.tabControlPanel6.PerformLayout();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownStationTextHeight).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStationTextColorBack2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStationTextColorFore2).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStationTextColorBack1).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxStationTextColorFore1).EndInit();
			base.ResumeLayout(false);
		}
	}
}
