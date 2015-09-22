using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wMetroGIS.wLayers
{
	public class wStationLayerSetupForm : System.Windows.Forms.Form
	{
		public wStationLayer m_StationLayer;

		private bool m_isLoading = true;

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.Button buttonOK;

		private System.Windows.Forms.Button buttonCancel;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.TextBox textBoxLayerName;

		private System.Windows.Forms.CheckBox checkBoxLayerVisable;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.DataGridView dataGridViewStationData;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.Label label4;

		private System.Windows.Forms.PictureBox pictureBoxIcon;

		private System.Windows.Forms.ComboBox comboBoxIcon;

		private System.Windows.Forms.NumericUpDown numericUpDownLevel;

		private System.Windows.Forms.Label label5;

		public wStationLayerSetupForm()
		{
			this.InitializeComponent();
		}

		private void wStationLayerSetupForm_Load(object sender, System.EventArgs e)
		{
			if (this.m_StationLayer == null)
			{
				System.Windows.Forms.MessageBox.Show("未设置要编辑的站点图层!");
				base.Close();
			}
			else
			{
				this.m_isLoading = true;
				this.comboBoxIcon.Items.Clear();
				for (int i = 0; i < this.m_StationLayer.stationIconList.Images.Count; i++)
				{
					this.comboBoxIcon.Items.Add(string.Format("图标{0}", i + 1));
				}
				this.comboBoxIcon.SelectedIndex = this.m_StationLayer.stationIconID;
				this.textBoxLayerName.Text = this.m_StationLayer.layerName;
				this.checkBoxLayerVisable.Checked = this.m_StationLayer.layerVisable;
				this.numericUpDownLevel.Value = this.m_StationLayer.showStationLevel;
				this.dataGridViewStationData.Columns.Add("STATION_ID", "站号");
				this.dataGridViewStationData.Columns.Add("STATION_NAME", "站名");
				this.dataGridViewStationData.Columns.Add("STATION_LON", "经度");
				this.dataGridViewStationData.Columns.Add("STATION_LAT", "纬度");
				this.dataGridViewStationData.Columns.Add("STATION_LEVEL", "级别");
				for (int i = 0; i < this.m_StationLayer.stationData.Columns.Count; i++)
				{
					this.dataGridViewStationData.Columns.Add("STATION_DATA", this.m_StationLayer.stationData.Columns[i].ColumnName);
				}
				this.dataGridViewStationData.Rows.Add(this.m_StationLayer.layerStationItems.Count);
				for (int i = 0; i < this.m_StationLayer.layerStationItems.Count; i++)
				{
					this.dataGridViewStationData.Rows[i].Cells[0].Value = this.m_StationLayer.layerStationItems[i].stationID;
					this.dataGridViewStationData.Rows[i].Cells[0].ReadOnly = true;
					this.dataGridViewStationData.Rows[i].Cells[1].Value = this.m_StationLayer.layerStationItems[i].stationName;
					this.dataGridViewStationData.Rows[i].Cells[2].Value = string.Format("{0:0.0}", this.m_StationLayer.layerStationItems[i].stationPos.X);
					this.dataGridViewStationData.Rows[i].Cells[3].Value = string.Format("{0:0.0}", this.m_StationLayer.layerStationItems[i].stationPos.Y);
					this.dataGridViewStationData.Rows[i].Cells[4].Value = this.m_StationLayer.layerStationItems[i].stationLevel;
					for (int j = 0; j < this.m_StationLayer.layerStationItems[i].stationData.ItemArray.Length; j++)
					{
						this.dataGridViewStationData.Rows[i].Cells[5 + j].Value = string.Format("{0:0.00}", this.m_StationLayer.layerStationItems[i].stationData.ItemArray[j]);
					}
				}
				this.m_isLoading = false;
			}
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			if (this.textBoxLayerName.Text == "")
			{
				System.Windows.Forms.MessageBox.Show("请填写图层名称！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
			else
			{
				this.m_StationLayer.layerName = this.textBoxLayerName.Text;
				this.m_StationLayer.layerVisable = this.checkBoxLayerVisable.Checked;
				this.m_StationLayer.showStationLevel = (ushort)this.numericUpDownLevel.Value;
				this.m_StationLayer.stationIconID = this.comboBoxIcon.SelectedIndex;
				base.DialogResult = System.Windows.Forms.DialogResult.OK;
				base.Close();
			}
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			base.Close();
		}

		private void dataGridViewStationData_CellValueChanged(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
		{
			if (!this.m_isLoading)
			{
				string colName = this.dataGridViewStationData.Columns[e.ColumnIndex].Name;
				object cellData = this.dataGridViewStationData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
				if (colName == "STATION_NAME")
				{
					this.m_StationLayer.layerStationItems[e.RowIndex].stationName = System.Convert.ToString(cellData);
				}
				else if (colName == "STATION_LON" || colName == "STATION_LAT")
				{
					try
					{
						float Lon = System.Convert.ToSingle(this.dataGridViewStationData.Rows[e.RowIndex].Cells[2].Value);
						float Lat = System.Convert.ToSingle(this.dataGridViewStationData.Rows[e.RowIndex].Cells[3].Value);
						this.m_StationLayer.layerStationItems[e.RowIndex].stationPos = new System.Drawing.PointF(Lon, Lat);
					}
					catch
					{
					}
					this.dataGridViewStationData.Rows[e.RowIndex].Cells[2].Value = string.Format("{0:0.0}", this.m_StationLayer.layerStationItems[e.RowIndex].stationPos.X);
					this.dataGridViewStationData.Rows[e.RowIndex].Cells[3].Value = string.Format("{0:0.0}", this.m_StationLayer.layerStationItems[e.RowIndex].stationPos.Y);
				}
				else if (colName == "STATION_LEVEL")
				{
					try
					{
						ushort Level = System.Convert.ToUInt16(cellData);
						if (Level <= 10)
						{
							this.m_StationLayer.layerStationItems[e.RowIndex].stationLevel = Level;
						}
					}
					catch
					{
					}
					this.dataGridViewStationData.Rows[e.RowIndex].Cells[4].Value = this.m_StationLayer.layerStationItems[e.RowIndex].stationLevel;
				}
				else if (colName == "STATION_DATA")
				{
					try
					{
						float data = System.Convert.ToSingle(cellData);
						this.m_StationLayer.stationData.Rows[e.RowIndex][e.ColumnIndex] = data;
					}
					catch
					{
					}
					this.dataGridViewStationData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = string.Format("{0:0.00}", this.m_StationLayer.stationData.Rows[e.RowIndex][e.ColumnIndex]);
				}
			}
		}

		private void comboBoxIcon_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			this.pictureBoxIcon.Image = this.m_StationLayer.stationIconList.Images[this.comboBoxIcon.SelectedIndex];
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.buttonOK = new System.Windows.Forms.Button();
			this.buttonCancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.textBoxLayerName = new System.Windows.Forms.TextBox();
			this.checkBoxLayerVisable = new System.Windows.Forms.CheckBox();
			this.label2 = new System.Windows.Forms.Label();
			this.dataGridViewStationData = new System.Windows.Forms.DataGridView();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.pictureBoxIcon = new System.Windows.Forms.PictureBox();
			this.comboBoxIcon = new System.Windows.Forms.ComboBox();
			this.numericUpDownLevel = new System.Windows.Forms.NumericUpDown();
			this.label5 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)this.dataGridViewStationData).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxIcon).BeginInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLevel).BeginInit();
			base.SuspendLayout();
			this.buttonOK.Location = new System.Drawing.Point(325, 309);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(75, 42);
			this.buttonOK.TabIndex = 0;
			this.buttonOK.Text = "确\u3000定";
			this.buttonOK.UseVisualStyleBackColor = true;
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.buttonCancel.Location = new System.Drawing.Point(412, 310);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(75, 41);
			this.buttonCancel.TabIndex = 0;
			this.buttonCancel.Text = "取\u3000消";
			this.buttonCancel.UseVisualStyleBackColor = true;
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(65, 12);
			this.label1.TabIndex = 1;
			this.label1.Text = "图层名称：";
			this.textBoxLayerName.Location = new System.Drawing.Point(83, 15);
			this.textBoxLayerName.Name = "textBoxLayerName";
			this.textBoxLayerName.Size = new System.Drawing.Size(280, 21);
			this.textBoxLayerName.TabIndex = 2;
			this.textBoxLayerName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.checkBoxLayerVisable.AutoSize = true;
			this.checkBoxLayerVisable.Location = new System.Drawing.Point(369, 19);
			this.checkBoxLayerVisable.Name = "checkBoxLayerVisable";
			this.checkBoxLayerVisable.Size = new System.Drawing.Size(48, 16);
			this.checkBoxLayerVisable.TabIndex = 3;
			this.checkBoxLayerVisable.Text = "显示";
			this.checkBoxLayerVisable.UseVisualStyleBackColor = true;
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 84);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(65, 12);
			this.label2.TabIndex = 1;
			this.label2.Text = "站点数据：";
			this.dataGridViewStationData.AllowUserToAddRows = false;
			this.dataGridViewStationData.AllowUserToDeleteRows = false;
			dataGridViewCellStyle2.BackColor = System.Drawing.Color.Silver;
			this.dataGridViewStationData.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
			this.dataGridViewStationData.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
			this.dataGridViewStationData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewStationData.Location = new System.Drawing.Point(14, 99);
			this.dataGridViewStationData.Name = "dataGridViewStationData";
			this.dataGridViewStationData.RowTemplate.Height = 23;
			this.dataGridViewStationData.Size = new System.Drawing.Size(473, 204);
			this.dataGridViewStationData.TabIndex = 4;
			this.dataGridViewStationData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewStationData_CellValueChanged);
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(208, 50);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(65, 12);
			this.label3.TabIndex = 1;
			this.label3.Text = "图层图标：";
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 50);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(89, 12);
			this.label4.TabIndex = 1;
			this.label4.Text = "显示站点级别：";
			this.pictureBoxIcon.BackColor = System.Drawing.SystemColors.ControlText;
			this.pictureBoxIcon.Location = new System.Drawing.Point(433, 15);
			this.pictureBoxIcon.Name = "pictureBoxIcon";
			this.pictureBoxIcon.Size = new System.Drawing.Size(54, 50);
			this.pictureBoxIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.pictureBoxIcon.TabIndex = 5;
			this.pictureBoxIcon.TabStop = false;
			this.comboBoxIcon.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxIcon.FormattingEnabled = true;
			this.comboBoxIcon.Location = new System.Drawing.Point(279, 46);
			this.comboBoxIcon.Name = "comboBoxIcon";
			this.comboBoxIcon.Size = new System.Drawing.Size(138, 20);
			this.comboBoxIcon.TabIndex = 6;
			this.comboBoxIcon.SelectedIndexChanged += new System.EventHandler(this.comboBoxIcon_SelectedIndexChanged);
			this.numericUpDownLevel.Location = new System.Drawing.Point(107, 46);
			System.Windows.Forms.NumericUpDown arg_61B_0 = this.numericUpDownLevel;
			int[] array = new int[4];
			array[0] = 10;
			arg_61B_0.Maximum = new decimal(array);
			this.numericUpDownLevel.Name = "numericUpDownLevel";
			this.numericUpDownLevel.ReadOnly = true;
			this.numericUpDownLevel.Size = new System.Drawing.Size(95, 21);
			this.numericUpDownLevel.TabIndex = 7;
			this.numericUpDownLevel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(14, 318);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(305, 24);
			this.label5.TabIndex = 1;
			this.label5.Text = "说明：显示站点级别表示显示所有级小于设置值的站点。\r\n\u3000\u3000\u3000修改站点数据将即时生效，请谨慎！";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(502, 363);
			base.ControlBox = false;
			base.Controls.Add(this.numericUpDownLevel);
			base.Controls.Add(this.comboBoxIcon);
			base.Controls.Add(this.pictureBoxIcon);
			base.Controls.Add(this.dataGridViewStationData);
			base.Controls.Add(this.checkBoxLayerVisable);
			base.Controls.Add(this.textBoxLayerName);
			base.Controls.Add(this.label5);
			base.Controls.Add(this.label2);
			base.Controls.Add(this.label4);
			base.Controls.Add(this.label3);
			base.Controls.Add(this.label1);
			base.Controls.Add(this.buttonCancel);
			base.Controls.Add(this.buttonOK);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "wStationLayerSetupForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "站点图层参数设置";
			base.Load += new System.EventHandler(this.wStationLayerSetupForm_Load);
			((System.ComponentModel.ISupportInitialize)this.dataGridViewStationData).EndInit();
			((System.ComponentModel.ISupportInitialize)this.pictureBoxIcon).EndInit();
			((System.ComponentModel.ISupportInitialize)this.numericUpDownLevel).EndInit();
			base.ResumeLayout(false);
			base.PerformLayout();
		}
	}
}
