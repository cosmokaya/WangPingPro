using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using wMetroGIS.Properties;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wLayers
{
	public class wStationLayer : wBaseLayer
	{
		private System.Windows.Forms.ImageList m_stationIconList = new System.Windows.Forms.ImageList();

		private int m_stationIconID = 0;

		private System.Collections.Generic.List<wStationItem> m_layerStationItems = new System.Collections.Generic.List<wStationItem>();

		private DataTable m_stationDatas = null;

		private int m_selectedStationID = -1;

		private ushort m_showStationLevel = 10;

		private System.Drawing.Bitmap stationIcon
		{
			get
			{
				return (System.Drawing.Bitmap)this.m_stationIconList.Images[this.m_stationIconID];
			}
		}

		public System.Windows.Forms.ImageList stationIconList
		{
			get
			{
				return this.m_stationIconList;
			}
		}

		public int stationIconID
		{
			get
			{
				return this.m_stationIconID;
			}
			set
			{
				if (value >= 0 && value <= this.m_stationIconList.Images.Count)
				{
					this.m_stationIconID = value;
				}
			}
		}

		public System.Collections.Generic.List<wStationItem> layerStationItems
		{
			get
			{
				return this.m_layerStationItems;
			}
		}

		public DataTable stationData
		{
			get
			{
				return this.m_stationDatas;
			}
		}

		public int selectedStationID
		{
			get
			{
				return this.m_selectedStationID;
			}
		}

		public ushort showStationLevel
		{
			get
			{
				return this.m_showStationLevel;
			}
			set
			{
				if (value >= 0 && value <= 10)
				{
					this.m_showStationLevel = value;
				}
			}
		}

		public wStationItem selectedStationItem
		{
			get
			{
				wStationItem result;
				if (this.m_selectedStationID == -1 || this.m_selectedStationID >= this.m_layerStationItems.Count)
				{
					result = null;
				}
				else
				{
					result = this.m_layerStationItems[this.m_selectedStationID];
				}
				return result;
			}
		}

		public wStationLayer()
		{
			this.layerName = "";
			this.layerVisable = true;
			this.LoadImageList();
		}

		public wStationLayer(string Name, bool Visable, System.Drawing.Region Masker)
		{
			this.layerName = Name;
			this.layerVisable = Visable;
			this.LoadImageList();
		}

		private void LoadImageList()
		{
			this.m_stationIconList = new System.Windows.Forms.ImageList();
			this.m_stationIconList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.m_stationIconList.ImageSize = new System.Drawing.Size(Resources.STAR_01.Width, Resources.STAR_01.Height);
			this.m_stationIconList.Images.Add(Resources.STAR_01);
			this.m_stationIconList.Images.Add(Resources.STAR_02);
			this.m_stationIconList.Images.Add(Resources.STAR_03);
			this.m_stationIconList.Images.Add(Resources.STAR_04);
			this.m_stationIconList.Images.Add(Resources.STAR_05);
			this.m_stationIconList.Images.Add(Resources.STAR_06);
			this.m_stationIconID = 0;
		}

		public override void Draw(System.Drawing.Graphics g, Projection p)
		{
			foreach (wStationItem thisItem in this.m_layerStationItems)
			{
				if (thisItem.stationLevel <= this.m_showStationLevel)
				{
					thisItem.DrawMe(g, p, this.stationIcon);
				}
			}
		}

		public override bool SetupLayer()
		{
			return new wStationLayerSetupForm
			{
				m_StationLayer = this
			}.ShowDialog() == System.Windows.Forms.DialogResult.OK;
		}

		public bool LoadStationData(System.Collections.Generic.List<System.Drawing.PointF> stationPoses, System.Collections.Generic.List<ushort> stationIDs, System.Collections.Generic.List<string> stationNames, System.Collections.Generic.List<ushort> stationLevels, DataTable stationDatas)
		{
			bool result;
			if (stationPoses == null || stationNames == null || stationLevels == null || stationDatas == null || stationIDs == null)
			{
				result = false;
			}
			else if (stationPoses.Count != stationNames.Count || stationPoses.Count != stationLevels.Count || stationPoses.Count != stationIDs.Count || stationPoses.Count != stationDatas.Rows.Count)
			{
				result = false;
			}
			else
			{
				this.m_stationDatas = stationDatas;
				this.m_layerStationItems.Clear();
				for (int i = 0; i < stationPoses.Count; i++)
				{
					wStationItem newItem = new wStationItem(stationPoses[i], stationIDs[i], stationNames[i], stationLevels[i], stationDatas.Rows[i]);
					this.m_layerStationItems.Add(newItem);
				}
				this.m_selectedStationID = -1;
				result = true;
			}
			return result;
		}

		public bool TestSelectStation(System.Drawing.PointF testLonLat, Projection mapPrj)
		{
			bool result;
			if (this.m_selectedStationID != -1)
			{
				if (this.selectedStationItem.SelectMe(testLonLat, mapPrj))
				{
					result = true;
					return result;
				}
			}
			this.m_selectedStationID = -1;
			for (int i = 0; i < this.m_layerStationItems.Count; i++)
			{
				if (this.m_layerStationItems[i].stationLevel <= this.m_showStationLevel)
				{
					if (this.m_layerStationItems[i].SelectMe(testLonLat, mapPrj))
					{
						this.m_selectedStationID = i;
						result = true;
						return result;
					}
				}
			}
			result = false;
			return result;
		}
	}
}
