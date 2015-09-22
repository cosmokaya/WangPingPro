using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using wMetroGIS.Properties;
using wMetroGIS.wMapMask;
using wMetroGIS.wMapPictureBoxControl;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wLayers
{
	public class wLayerManagerControl : System.Windows.Forms.UserControl
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.ListView listViewLayer;

		private System.Windows.Forms.ColumnHeader columnHeader1;

		private System.Windows.Forms.ColumnHeader columnHeader2;

		private System.Windows.Forms.ColumnHeader columnHeader4;

		internal System.Windows.Forms.ContextMenuStrip LayerPopup;

		internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem1;

		internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem2;

		internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem3;

		internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem4;

		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator1;

		internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem5;

		internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem6;

		internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem7;

		internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem8;

		internal System.Windows.Forms.ToolStripSeparator ToolStripSeparator2;

		internal System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem9;

		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem12;

		private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem13;

		internal System.Windows.Forms.ToolStripSeparator toolStripSeparator3;

		private wMapPictureBox m_MapPictureBox = null;

		private System.Collections.Generic.List<wBaseLayer> m_LayerList = new System.Collections.Generic.List<wBaseLayer>();

		private System.Collections.Generic.List<wBaseMasker> m_LayerMaskList = new System.Collections.Generic.List<wBaseMasker>();

		private int m_SelectedLayerID = -1;

		public wMapPictureBox MapPictureBox
		{
			get
			{
				return this.m_MapPictureBox;
			}
			set
			{
				this.SetDrawingMapControl(value);
			}
		}

		public int SelectedLayerID
		{
			get
			{
				return this.m_SelectedLayerID;
			}
			set
			{
				if (this.m_LayerList.Count == 0)
				{
					this.m_SelectedLayerID = -1;
				}
				else if (value < 0 || value >= this.m_LayerList.Count)
				{
					this.m_SelectedLayerID = 0;
				}
				else
				{
					this.m_SelectedLayerID = value;
				}
			}
		}

		public wBaseLayer SelectedLayer
		{
			get
			{
				wBaseLayer result;
				if (this.m_SelectedLayerID == -1 || this.m_LayerList.Count == 0)
				{
					result = null;
				}
				else
				{
					result = this.m_LayerList[this.m_SelectedLayerID];
				}
				return result;
			}
		}

		public System.Collections.Generic.List<wBaseLayer> LayerList
		{
			get
			{
				return this.m_LayerList;
			}
		}

		public System.Collections.Generic.List<wBaseMasker> LayerMaskList
		{
			get
			{
				return this.m_LayerMaskList;
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
			this.listViewLayer = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.LayerPopup = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.ToolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
			this.ToolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
			this.LayerPopup.SuspendLayout();
			base.SuspendLayout();
			this.listViewLayer.AllowDrop = true;
			this.listViewLayer.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.listViewLayer.BackColor = System.Drawing.Color.LemonChiffon;
			this.listViewLayer.Columns.AddRange(new System.Windows.Forms.ColumnHeader[]
			{
				this.columnHeader1,
				this.columnHeader2,
				this.columnHeader4
			});
			this.listViewLayer.ContextMenuStrip = this.LayerPopup;
			this.listViewLayer.FullRowSelect = true;
			this.listViewLayer.GridLines = true;
			this.listViewLayer.HideSelection = false;
			this.listViewLayer.Location = new System.Drawing.Point(2, 1);
			this.listViewLayer.MultiSelect = false;
			this.listViewLayer.Name = "listViewLayer";
			this.listViewLayer.Size = new System.Drawing.Size(216, 201);
			this.listViewLayer.TabIndex = 1;
			this.listViewLayer.UseCompatibleStateImageBehavior = false;
			this.listViewLayer.View = System.Windows.Forms.View.Details;
			this.listViewLayer.DragDrop += new System.Windows.Forms.DragEventHandler(this.listViewLayer_DragDrop);
			this.listViewLayer.DragEnter += new System.Windows.Forms.DragEventHandler(this.listViewLayer_DragEnter);
			this.listViewLayer.DragOver += new System.Windows.Forms.DragEventHandler(this.listViewLayer_DragOver);
			this.listViewLayer.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listViewLayer_MouseClick);
			this.listViewLayer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listViewLayer_MouseDown);
			this.columnHeader1.Text = "序号";
			this.columnHeader1.Width = 36;
			this.columnHeader2.Text = "显示";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.columnHeader2.Width = 37;
			this.columnHeader4.Text = "图层名称";
			this.columnHeader4.Width = 300;
			this.LayerPopup.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
			{
				this.ToolStripMenuItem1,
				this.ToolStripMenuItem2,
				this.ToolStripMenuItem3,
				this.ToolStripMenuItem4,
				this.ToolStripSeparator1,
				this.ToolStripMenuItem5,
				this.ToolStripMenuItem6,
				this.ToolStripMenuItem7,
				this.ToolStripMenuItem8,
				this.ToolStripSeparator2,
				this.ToolStripMenuItem9,
				this.ToolStripMenuItem12,
				this.ToolStripMenuItem13,
				this.toolStripSeparator3
			});
			this.LayerPopup.Name = "LayerPopup";
			this.LayerPopup.Size = new System.Drawing.Size(149, 264);
			this.ToolStripSeparator1.Name = "ToolStripSeparator1";
			this.ToolStripSeparator1.Size = new System.Drawing.Size(145, 6);
			this.ToolStripSeparator2.Name = "ToolStripSeparator2";
			this.ToolStripSeparator2.Size = new System.Drawing.Size(145, 6);
			this.toolStripSeparator3.Name = "toolStripSeparator3";
			this.toolStripSeparator3.Size = new System.Drawing.Size(145, 6);
			this.ToolStripMenuItem1.Image = Resources.ObjectEffectShadowGallery;
			this.ToolStripMenuItem1.Name = "ToolStripMenuItem1";
			this.ToolStripMenuItem1.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem1.Text = "显示图层";
			this.ToolStripMenuItem1.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
			this.ToolStripMenuItem2.Image = Resources.ObjectEffectSoftEdgesGallery;
			this.ToolStripMenuItem2.Name = "ToolStripMenuItem2";
			this.ToolStripMenuItem2.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem2.Text = "隐藏图层";
			this.ToolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2_Click);
			this.ToolStripMenuItem3.Image = Resources.ObjectSendBackwardOutlook;
			this.ToolStripMenuItem3.Name = "ToolStripMenuItem3";
			this.ToolStripMenuItem3.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem3.Text = "全部显示";
			this.ToolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3_Click);
			this.ToolStripMenuItem4.Image = Resources.DiagramStylesClassic;
			this.ToolStripMenuItem4.Name = "ToolStripMenuItem4";
			this.ToolStripMenuItem4.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem4.Text = "隐藏其它";
			this.ToolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4_Click);
			this.ToolStripMenuItem5.Image = Resources.FillUp;
			this.ToolStripMenuItem5.Name = "ToolStripMenuItem5";
			this.ToolStripMenuItem5.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem5.Text = "置于顶层";
			this.ToolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenuItem5_Click);
			this.ToolStripMenuItem6.Image = Resources.ObjectNudgeUp;
			this.ToolStripMenuItem6.Name = "ToolStripMenuItem6";
			this.ToolStripMenuItem6.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem6.Text = "上移一层";
			this.ToolStripMenuItem6.Click += new System.EventHandler(this.ToolStripMenuItem6_Click);
			this.ToolStripMenuItem7.Image = Resources.ObjectNudgeDown;
			this.ToolStripMenuItem7.Name = "ToolStripMenuItem7";
			this.ToolStripMenuItem7.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem7.Text = "下移一层";
			this.ToolStripMenuItem7.Click += new System.EventHandler(this.ToolStripMenuItem7_Click);
			this.ToolStripMenuItem8.Image = Resources.FillDown;
			this.ToolStripMenuItem8.Name = "ToolStripMenuItem8";
			this.ToolStripMenuItem8.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem8.Text = "置于底层";
			this.ToolStripMenuItem8.Click += new System.EventHandler(this.ToolStripMenuItem8_Click);
			this.ToolStripMenuItem9.Image = Resources.SharingRequestDeny;
			this.ToolStripMenuItem9.Name = "ToolStripMenuItem9";
			this.ToolStripMenuItem9.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem9.Text = "删除图层";
			this.ToolStripMenuItem9.Click += new System.EventHandler(this.ToolStripMenuItem9_Click);
			this.ToolStripMenuItem12.Image = Resources.Refresh;
			this.ToolStripMenuItem12.Name = "ToolStripMenuItem12";
			this.ToolStripMenuItem12.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem12.Text = "刷新所有图层";
			this.ToolStripMenuItem12.Click += new System.EventHandler(this.ToolStripMenuItem12_Click);
			this.ToolStripMenuItem13.Image = Resources.PageMenu;
			this.ToolStripMenuItem13.Name = "ToolStripMenuItem13";
			this.ToolStripMenuItem13.Size = new System.Drawing.Size(148, 22);
			this.ToolStripMenuItem13.Text = "图层属性";
			this.ToolStripMenuItem13.Click += new System.EventHandler(this.ToolStripMenuItem13_Click);
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.Controls.Add(this.listViewLayer);
			base.Name = "wLayerManagerControl";
			base.Size = new System.Drawing.Size(220, 203);
			this.LayerPopup.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		public wLayerManagerControl()
		{
			this.InitializeComponent();
		}

		public void SetDrawingMapControl(wMapPictureBox drawingMapControl)
		{
			if (drawingMapControl != null)
			{
				this.m_MapPictureBox = drawingMapControl;
				this.m_MapPictureBox.MapPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingControl_Paint);
				this.m_MapPictureBox.MapPictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.DrawingControl_MouseMove);
				this.m_MapPictureBox.MapPictureBox.MouseEnter += new System.EventHandler(this.DrawingControl_MouseEnter);
				this.m_MapPictureBox.MapPictureBox.MouseLeave += new System.EventHandler(this.DrawingControl_MouseLeave);
				this.m_MapPictureBox.MapPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DrawingControl_MouseClick);
				this.m_MapPictureBox.MapZoomed += new System.EventHandler(this.MapPictureBox_MapZoomed);
				this.m_MapPictureBox.MapRefreshed += new System.EventHandler(this.MapPictureBox_MapRefreshed);
			}
		}

		public void AddLayer(wBaseLayer newLayer, wBaseMasker newLayerMasker = null, int Index = 0)
		{
			if (Index < 0 || Index >= this.m_LayerList.Count)
			{
				this.m_LayerList.Insert(0, newLayer);
				this.m_LayerMaskList.Insert(0, newLayerMasker);
			}
			else
			{
				this.m_LayerList.Insert(Index, newLayer);
				this.m_LayerMaskList.Insert(Index, newLayerMasker);
			}
			this.DrawLayers(true);
			this.LoadLayers();
		}

		public bool DeleteLayer(int Index)
		{
			bool result;
			if (Index >= 0 && Index < this.m_LayerList.Count)
			{
				this.m_LayerList.RemoveAt(Index);
				this.m_LayerMaskList.RemoveAt(Index);
				this.DrawLayers(true);
				this.LoadLayers();
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void ClearLayers()
		{
			this.m_LayerList.Clear();
			this.m_LayerMaskList.Clear();
			this.DrawLayers(true);
			this.LoadLayers();
		}

		public bool MoveLayer(int OldIndex, int NewIndex)
		{
			bool result;
			if (OldIndex >= 0 && OldIndex < this.m_LayerList.Count && NewIndex >= 0 && NewIndex < this.m_LayerList.Count && OldIndex != NewIndex)
			{
				wBaseLayer selectedLayer = this.m_LayerList[OldIndex];
				wBaseMasker selectedLayerMasker = this.m_LayerMaskList[OldIndex];
				this.m_LayerList.RemoveAt(OldIndex);
				this.m_LayerMaskList.RemoveAt(OldIndex);
				this.m_LayerList.Insert(NewIndex, selectedLayer);
				this.m_LayerMaskList.Insert(NewIndex, selectedLayerMasker);
				this.LoadLayers();
				if (selectedLayer.layerVisable)
				{
					this.DrawLayers(true);
				}
				result = true;
			}
			else
			{
				result = false;
			}
			return result;
		}

		public void DrawLayers(bool wantRefreshMap = true)
		{
			if (this.m_MapPictureBox != null)
			{
				if (wantRefreshMap)
				{
					this.m_MapPictureBox.DrawMap();
				}
				int colorBarCount = 0;
				for (int i = this.m_LayerList.Count - 1; i >= 0; i--)
				{
					if (this.m_LayerList[i].layerVisable)
					{
						if (this.m_LayerList[i].NeedDrawColorBar())
						{
							colorBarCount++;
						}
						this.m_LayerList[i].DrawToMapPictureBox(this.m_MapPictureBox, this.m_LayerMaskList[i], false, colorBarCount == 1);
					}
				}
				this.m_MapPictureBox.ShowColorBar = (colorBarCount != 0);
				this.m_MapPictureBox.MapPictureBox.Refresh();
			}
		}

		public void DrawLayers(System.Drawing.Graphics g, Projection p)
		{
			for (int i = this.m_LayerList.Count - 1; i >= 0; i--)
			{
				if (this.m_LayerList[i].layerVisable)
				{
					this.m_LayerList[i].Draw(g, p);
				}
			}
		}

		private void LoadLayers()
		{
			this.listViewLayer.Items.Clear();
			for (int i = 0; i < this.m_LayerList.Count; i++)
			{
				System.Windows.Forms.ListViewItem newItem = new System.Windows.Forms.ListViewItem(System.Convert.ToString(i + 1));
				System.Windows.Forms.ListViewItem.ListViewSubItem newSubItem;
				if (this.m_LayerList[i].layerVisable)
				{
					newSubItem = newItem.SubItems.Add("√");
				}
				else
				{
					newSubItem = newItem.SubItems.Add("");
				}
				newSubItem.Name = "SHOW";
				newSubItem.Tag = this.m_LayerList[i].layerVisable;
				newSubItem = newItem.SubItems.Add(this.m_LayerList[i].layerName);
				newSubItem.Name = "LAYER_NAME";
				this.listViewLayer.Items.Add(newItem);
			}
			if (this.listViewLayer.Items.Count != 0)
			{
				this.listViewLayer.Items[0].Selected = true;
				this.m_SelectedLayerID = 0;
			}
		}

		private void listViewLayer_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.ListView lv = (System.Windows.Forms.ListView)sender;
			System.Windows.Forms.ListViewItem clickItem = lv.GetItemAt(e.X, e.Y);
			if (clickItem != null)
			{
				if (e.Button == System.Windows.Forms.MouseButtons.Left)
				{
					System.Windows.Forms.ListViewItem.ListViewSubItem clickSubItem = clickItem.GetSubItemAt(e.X, e.Y);
					if (clickSubItem.Name == "SHOW")
					{
						bool value = System.Convert.ToBoolean(clickSubItem.Tag);
						value = !value;
						if (value)
						{
							clickSubItem.Text = "√";
						}
						else
						{
							clickSubItem.Text = "";
						}
						clickSubItem.Tag = value;
						this.m_LayerList[clickItem.Index].layerVisable = value;
						this.DrawLayers(true);
					}
				}
			}
		}

		private void listViewLayer_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			System.Windows.Forms.ListView lv = (System.Windows.Forms.ListView)sender;
			System.Windows.Forms.ListViewItem clickItem = lv.GetItemAt(e.X, e.Y);
			if (clickItem != null)
			{
				this.m_SelectedLayerID = clickItem.Index;
				if (e.Button == System.Windows.Forms.MouseButtons.Right)
				{
					if (lv.Name == this.listViewLayer.Name)
					{
						if (clickItem == null)
						{
							this.ToolStripMenuItem1.Enabled = false;
							this.ToolStripMenuItem2.Enabled = false;
							this.ToolStripMenuItem3.Enabled = false;
							this.ToolStripMenuItem4.Enabled = false;
							this.ToolStripMenuItem5.Enabled = false;
							this.ToolStripMenuItem6.Enabled = false;
							this.ToolStripMenuItem7.Enabled = false;
							this.ToolStripMenuItem8.Enabled = false;
							this.ToolStripMenuItem9.Enabled = false;
							this.ToolStripMenuItem12.Enabled = false;
							this.ToolStripMenuItem13.Enabled = false;
						}
						else
						{
							this.ToolStripMenuItem1.Enabled = !System.Convert.ToBoolean(clickItem.SubItems["SHOW"].Tag);
							this.ToolStripMenuItem2.Enabled = System.Convert.ToBoolean(clickItem.SubItems["SHOW"].Tag);
							this.ToolStripMenuItem3.Enabled = true;
							this.ToolStripMenuItem4.Enabled = true;
							this.ToolStripMenuItem5.Enabled = (this.m_SelectedLayerID != 0);
							this.ToolStripMenuItem6.Enabled = (this.m_SelectedLayerID != 0);
							this.ToolStripMenuItem7.Enabled = (this.m_SelectedLayerID != this.m_LayerList.Count - 1);
							this.ToolStripMenuItem8.Enabled = (this.m_SelectedLayerID != this.m_LayerList.Count - 1);
							this.ToolStripMenuItem9.Enabled = true;
							this.ToolStripMenuItem12.Enabled = true;
							this.ToolStripMenuItem13.Enabled = true;
							this.m_SelectedLayerID = clickItem.Index;
						}
					}
				}
			}
		}

		private void listViewLayer_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			System.Windows.Forms.ListView lv = (System.Windows.Forms.ListView)sender;
			System.Windows.Forms.ListViewItem DraggedItem = (System.Windows.Forms.ListViewItem)e.Data.GetData(typeof(System.Windows.Forms.ListViewItem));
			System.Drawing.Point TargetPoint = lv.PointToClient(new System.Drawing.Point(e.X, e.Y));
			System.Windows.Forms.ListViewItem TargetItem = lv.GetItemAt(TargetPoint.X, TargetPoint.Y);
			if (TargetItem != null && !DraggedItem.Equals(TargetItem))
			{
				lv.BeginUpdate();
				if (e.Effect == System.Windows.Forms.DragDropEffects.Move)
				{
					DraggedItem.Remove();
					lv.Items.Insert(TargetItem.Index, DraggedItem);
				}
				lv.EndUpdate();
			}
		}

		private void listViewLayer_ItemDrag(object sender, System.Windows.Forms.ItemDragEventArgs e)
		{
			if (e.Button == System.Windows.Forms.MouseButtons.Left)
			{
				base.DoDragDrop(e.Item, System.Windows.Forms.DragDropEffects.Move);
			}
		}

		private void listViewLayer_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			System.Windows.Forms.ListView lv = (System.Windows.Forms.ListView)sender;
			System.Drawing.Point TargetPoint = lv.PointToClient(new System.Drawing.Point(e.X, e.Y));
			System.Windows.Forms.ListViewItem TargetItem = lv.GetItemAt(TargetPoint.X, TargetPoint.Y);
			lv.Focus();
			if (TargetItem != null)
			{
				TargetItem.Selected = true;
				TargetItem.Focused = true;
			}
		}

		private void listViewLayer_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			e.Effect = e.AllowedEffect;
		}

		private void ToolStripMenuItem1_Click(object sender, System.EventArgs e)
		{
			if (this.listViewLayer.SelectedIndices.Count != 0)
			{
				System.Windows.Forms.ListViewItem item = this.listViewLayer.SelectedItems[0];
				bool value = System.Convert.ToBoolean(item.SubItems["SHOW"].Tag);
				if (!value)
				{
					item.SubItems["SHOW"].Tag = true;
					item.SubItems["SHOW"].Text = "√";
					this.m_LayerList[item.Index].layerVisable = true;
					this.DrawLayers(true);
				}
			}
		}

		private void ToolStripMenuItem2_Click(object sender, System.EventArgs e)
		{
			if (this.listViewLayer.SelectedIndices.Count != 0)
			{
				System.Windows.Forms.ListViewItem item = this.listViewLayer.SelectedItems[0];
				if (System.Convert.ToBoolean(item.SubItems["SHOW"].Tag))
				{
					item.SubItems["SHOW"].Tag = false;
					item.SubItems["SHOW"].Text = "";
					this.m_LayerList[item.Index].layerVisable = false;
					this.DrawLayers(true);
				}
			}
		}

		private void ToolStripMenuItem3_Click(object sender, System.EventArgs e)
		{
			for (int i = 0; i < this.listViewLayer.Items.Count; i++)
			{
				this.listViewLayer.Items[i].SubItems["SHOW"].Tag = true;
				this.listViewLayer.Items[i].SubItems["SHOW"].Text = "√";
				this.m_LayerList[i].layerVisable = true;
			}
			this.DrawLayers(true);
		}

		private void ToolStripMenuItem4_Click(object sender, System.EventArgs e)
		{
			if (this.listViewLayer.SelectedIndices.Count != 0)
			{
				System.Windows.Forms.ListViewItem item = this.listViewLayer.SelectedItems[0];
				for (int i = 0; i < this.listViewLayer.Items.Count; i++)
				{
					if (i != item.Index)
					{
						this.listViewLayer.Items[i].SubItems["SHOW"].Tag = false;
						this.listViewLayer.Items[i].SubItems["SHOW"].Text = "";
						this.m_LayerList[i].layerVisable = false;
					}
				}
				this.DrawLayers(true);
			}
		}

		private void ToolStripMenuItem5_Click(object sender, System.EventArgs e)
		{
			if (this.listViewLayer.SelectedIndices.Count != 0)
			{
				int index = this.listViewLayer.SelectedIndices[0];
				if (index != 0)
				{
					this.MoveLayer(index, 0);
				}
			}
		}

		private void ToolStripMenuItem6_Click(object sender, System.EventArgs e)
		{
			if (this.listViewLayer.SelectedIndices.Count != 0)
			{
				int index = this.listViewLayer.SelectedIndices[0];
				if (index != 0)
				{
					this.MoveLayer(index, index - 1);
				}
			}
		}

		private void ToolStripMenuItem7_Click(object sender, System.EventArgs e)
		{
			if (this.listViewLayer.SelectedIndices.Count != 0)
			{
				int index = this.listViewLayer.SelectedIndices[0];
				if (index != this.listViewLayer.Items.Count - 1)
				{
					this.MoveLayer(index, index + 1);
				}
			}
		}

		private void ToolStripMenuItem8_Click(object sender, System.EventArgs e)
		{
			if (this.listViewLayer.SelectedIndices.Count != 0)
			{
				int index = this.listViewLayer.SelectedIndices[0];
				if (index != this.listViewLayer.Items.Count - 1)
				{
					this.MoveLayer(index, this.listViewLayer.Items.Count - 1);
				}
			}
		}

		private void ToolStripMenuItem9_Click(object sender, System.EventArgs e)
		{
			if (this.listViewLayer.SelectedIndices.Count != 0)
			{
				if (System.Windows.Forms.MessageBox.Show("确定删除图层吗？", "询问", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) != System.Windows.Forms.DialogResult.No)
				{
					if (this.DeleteLayer(this.listViewLayer.SelectedIndices[0]))
					{
					}
				}
			}
		}

		private void ToolStripMenuItem12_Click(object sender, System.EventArgs e)
		{
			foreach (wBaseLayer layer in this.m_LayerList)
			{
				layer.layerIsDrawed = false;
			}
			this.DrawLayers(true);
		}

		private void ToolStripMenuItem13_Click(object sender, System.EventArgs e)
		{
			if (this.listViewLayer.SelectedIndices.Count != 0)
			{
				if (this.m_LayerList[this.listViewLayer.SelectedIndices[0]].SetupLayer())
				{
					this.LoadLayers();
				}
			}
		}

		private void DrawingControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			if (this.m_MapPictureBox != null)
			{
				this.DrawLayers(e.Graphics, this.m_MapPictureBox.GetMapProjection());
			}
		}

		private void DrawingControl_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		}

		private void DrawingControl_MouseLeave(object sender, System.EventArgs e)
		{
		}

		private void DrawingControl_MouseEnter(object sender, System.EventArgs e)
		{
		}

		private void DrawingControl_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		}

		private void MapPictureBox_MapZoomed(object sender, System.EventArgs e)
		{
			this.m_MapPictureBox = (wMapPictureBox)sender;
			for (int i = 0; i < this.m_LayerList.Count; i++)
			{
				this.m_LayerList[i].layerIsDrawed = false;
			}
			this.DrawLayers(false);
		}

		private void MapPictureBox_MapRefreshed(object sender, System.EventArgs e)
		{
			this.m_MapPictureBox = (wMapPictureBox)sender;
			this.ClearLayers();
		}
	}
}
