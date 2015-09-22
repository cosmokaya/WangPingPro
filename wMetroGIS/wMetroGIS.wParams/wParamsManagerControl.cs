using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace wMetroGIS.wParams
{
	public class wParamsManagerControl : System.Windows.Forms.UserControl
	{
		private string m_RootText = "";

		private string m_SearchingPath = "C:\\";

		private int m_ExpandLevel = 0;

		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.TreeView treeViewParams;

		private System.Windows.Forms.ImageList imageList;

		public string RootText
		{
			get
			{
				return this.m_RootText;
			}
			set
			{
				this.m_RootText = value;
			}
		}

		public string SearchingPath
		{
			get
			{
				return this.m_SearchingPath;
			}
			set
			{
				this.m_SearchingPath = value;
			}
		}

		public int ExpandLevel
		{
			get
			{
				return this.m_ExpandLevel;
			}
			set
			{
				this.m_ExpandLevel = value;
			}
		}

		public wParamsManagerControl()
		{
			this.InitializeComponent();
		}

		private void wParamsManagerControl_Load(object sender, System.EventArgs e)
		{
		}

		private void SearchFile(string fileDirectory, System.Windows.Forms.TreeNode parentNode, int Level)
		{
			System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(fileDirectory);
			System.IO.FileSystemInfo[] f = dir.GetFileSystemInfos();
			System.IO.FileSystemInfo[] array = f;
			for (int j = 0; j < array.Length; j++)
			{
				System.IO.FileSystemInfo i = array[j];
				if (i is System.IO.DirectoryInfo)
				{
					System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(i.Name);
					newNode.ImageIndex = 0;
					newNode.SelectedImageIndex = 0;
					this.SearchFile(i.FullName, newNode, Level + 1);
				}
				else
				{
					string extName = System.IO.Path.GetExtension(i.Name);
					string titleName = System.IO.Path.GetFileNameWithoutExtension(i.Name);
					if (extName == ".mst")
					{
						System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(i.Name) + " 地图参数");
						newNode.ImageIndex = 1;
						newNode.SelectedImageIndex = 1;
						newNode.Tag = i.FullName;
					}
					else if (extName == ".bst")
					{
						System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(i.Name) + " 图表参数");
						newNode.ImageIndex = 2;
						newNode.SelectedImageIndex = 2;
						newNode.Tag = i.FullName;
					}
					else if (extName == ".cst")
					{
						System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(i.Name) + " 等值线参数");
						newNode.ImageIndex = 3;
						newNode.SelectedImageIndex = 3;
						newNode.Tag = i.FullName;
					}
					else if (extName == ".rst")
					{
						System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(i.Name) + " 区域参数");
						newNode.ImageIndex = 4;
						newNode.SelectedImageIndex = 4;
						newNode.Tag = i.FullName;
					}
					else if (extName == ".vst")
					{
						System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(i.Name) + " 矢量场参数");
						newNode.ImageIndex = 5;
						newNode.SelectedImageIndex = 5;
						newNode.Tag = i.FullName;
					}
					else if (extName == ".3st")
					{
						System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(i.Name) + " 三维可视参数");
						newNode.ImageIndex = 6;
						newNode.SelectedImageIndex = 6;
						newNode.Tag = i.FullName;
					}
					else if (extName == ".ost")
					{
						System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(i.Name) + " 玫瑰图参数");
						newNode.ImageIndex = 7;
						newNode.SelectedImageIndex = 7;
						newNode.Tag = i.FullName;
					}
					else if (extName == ".lst")
					{
						System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(i.Name) + " 流线参数");
						newNode.ImageIndex = 8;
						newNode.SelectedImageIndex = 8;
						newNode.Tag = i.FullName;
					}
					else if (extName == ".dst")
					{
						System.Windows.Forms.TreeNode newNode = parentNode.Nodes.Add(System.IO.Path.GetFileNameWithoutExtension(i.Name) + " 数据库连接参数");
						newNode.ImageIndex = 9;
						newNode.SelectedImageIndex = 9;
						newNode.Tag = i.FullName;
					}
				}
			}
			if (this.m_ExpandLevel == 0)
			{
				parentNode.Expand();
			}
			else if (Level <= this.m_ExpandLevel)
			{
				parentNode.Expand();
			}
		}

		public void SearchParams()
		{
			this.treeViewParams.Nodes.Clear();
			System.Windows.Forms.TreeNode rootNode = this.treeViewParams.Nodes.Add(this.m_RootText);
			rootNode.ImageIndex = 0;
			rootNode.SelectedImageIndex = 0;
			this.SearchFile(this.m_SearchingPath, rootNode, 0);
		}

		private void treeViewParams_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.TreeNode selectedNode = this.treeViewParams.GetNodeAt(e.Location);
			if (selectedNode != null && selectedNode.Tag != null)
			{
				string extName = System.IO.Path.GetExtension(selectedNode.Tag.ToString());
				string fullName = selectedNode.Tag.ToString();
				if (extName == ".mst")
				{
					MapParams mapParams = new MapParams(fullName);
					if (!mapParams.LoadSccessed)
					{
						System.Windows.Forms.MessageBox.Show("载入参数错误！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					}
					else
					{
						MapSettingForm form = new MapSettingForm(mapParams);
						form.ShowDialog();
					}
				}
				else if (extName == ".bst")
				{
					BarChartParams barParams = new BarChartParams(fullName);
					if (!barParams.LoadSccessed)
					{
						System.Windows.Forms.MessageBox.Show("载入参数错误！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					}
					else
					{
						BarChartSettingForm form2 = new BarChartSettingForm(barParams);
						form2.ShowDialog();
					}
				}
				else if (extName == ".cst")
				{
					ContourParams contourParams = new ContourParams(fullName);
					if (!contourParams.LoadSccessed)
					{
						System.Windows.Forms.MessageBox.Show("载入参数错误！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					}
					else
					{
						ContourSettingForm form3 = new ContourSettingForm(contourParams);
						form3.ShowDialog();
					}
				}
				else if (extName == ".rst")
				{
					RegionParams regionParams = new RegionParams(fullName);
					if (!regionParams.LoadSccessed)
					{
						System.Windows.Forms.MessageBox.Show("载入参数错误！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					}
					else
					{
						RegionSettingForm form4 = new RegionSettingForm(regionParams);
						form4.ShowDialog();
					}
				}
				else if (extName == ".vst")
				{
					VectorParams vectorParams = new VectorParams(fullName);
					if (!vectorParams.LoadSccessed)
					{
						System.Windows.Forms.MessageBox.Show("载入参数错误！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					}
					else
					{
						VectorSettingForm form5 = new VectorSettingForm(vectorParams);
						form5.ShowDialog();
					}
				}
				else if (extName == ".3st")
				{
					System.Windows.Forms.MessageBox.Show("未做！");
				}
				else if (!(extName == ".ost"))
				{
					if (extName == ".lst")
					{
						StreamlineParams streamlineParams = new StreamlineParams(fullName);
						if (!streamlineParams.LoadSccessed)
						{
							System.Windows.Forms.MessageBox.Show("载入参数错误！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
						}
						else
						{
							StreamlineSettingForm form6 = new StreamlineSettingForm(streamlineParams);
							form6.ShowDialog();
						}
					}
					else if (extName == ".dst")
					{
						DatabaseParams databaseParams = new DatabaseParams(fullName);
						if (!databaseParams.LoadSccessed)
						{
							System.Windows.Forms.MessageBox.Show("载入参数错误！", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
						}
						else
						{
							DatabaseSettingForm form7 = new DatabaseSettingForm(databaseParams);
							form7.ShowDialog();
						}
					}
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(wParamsManagerControl));
			this.treeViewParams = new System.Windows.Forms.TreeView();
			this.imageList = new System.Windows.Forms.ImageList(this.components);
			base.SuspendLayout();
			this.treeViewParams.BackColor = System.Drawing.Color.Azure;
			this.treeViewParams.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewParams.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.treeViewParams.HideSelection = false;
			this.treeViewParams.ImageIndex = 0;
			this.treeViewParams.ImageList = this.imageList;
			this.treeViewParams.Location = new System.Drawing.Point(0, 0);
			this.treeViewParams.Name = "treeViewParams";
			this.treeViewParams.SelectedImageIndex = 0;
			this.treeViewParams.Size = new System.Drawing.Size(400, 400);
			this.treeViewParams.TabIndex = 0;
			this.treeViewParams.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeViewParams_MouseDoubleClick);
			this.imageList.ImageStream = (System.Windows.Forms.ImageListStreamer)resources.GetObject("imageList.ImageStream");
			this.imageList.TransparentColor = System.Drawing.Color.Transparent;
			this.imageList.Images.SetKeyName(0, "ICON_FOLDER.png");
			this.imageList.Images.SetKeyName(1, "ICON_MAP.png");
			this.imageList.Images.SetKeyName(2, "ICON_CHART.png");
			this.imageList.Images.SetKeyName(3, "ICON_CONTOUR.png");
			this.imageList.Images.SetKeyName(4, "ICON_REGION.png");
			this.imageList.Images.SetKeyName(5, "ICON_VECTOR.png");
			this.imageList.Images.SetKeyName(6, "ICON_3D.png");
			this.imageList.Images.SetKeyName(7, "ICON_ROSE.png");
			this.imageList.Images.SetKeyName(8, "ICON_STREAML.png");
			this.imageList.Images.SetKeyName(9, "ICON_DATABASE");
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.treeViewParams);
			base.Name = "wParamsManagerControl";
			base.Size = new System.Drawing.Size(400, 400);
			base.Load += new System.EventHandler(this.wParamsManagerControl_Load);
			base.ResumeLayout(false);
		}
	}
}
