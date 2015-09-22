using System;
using System.Collections.Generic;
using System.Drawing;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wLayers
{
	public class wMarkLayer : wBaseLayer
	{
		public System.Collections.Generic.List<wMarkItem> m_MarkItemList = new System.Collections.Generic.List<wMarkItem>();

		public System.Collections.Generic.List<System.Drawing.Image> m_MarkImageList = new System.Collections.Generic.List<System.Drawing.Image>();

		public void AddMark(System.Drawing.PointF Position, string Text, int ImageIndex)
		{
			wMarkItem newItem = new wMarkItem(Position, Text, 10, System.Drawing.Color.White, this.m_MarkImageList[ImageIndex], true, true);
			this.m_MarkItemList.Add(newItem);
		}

		public override void Draw(System.Drawing.Graphics g, Projection p)
		{
			foreach (wMarkItem thisItem in this.m_MarkItemList)
			{
				thisItem.DrawMe(g, p);
			}
		}
	}
}
