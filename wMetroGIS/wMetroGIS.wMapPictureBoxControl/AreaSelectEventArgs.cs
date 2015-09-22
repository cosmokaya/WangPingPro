using System;
using System.Drawing;

namespace wMetroGIS.wMapPictureBoxControl
{
	public class AreaSelectEventArgs : System.EventArgs
	{
		public System.Drawing.RectangleF SelectRectMap = System.Drawing.RectangleF.Empty;

		public AreaSelectEventArgs()
		{
		}

		public AreaSelectEventArgs(System.Drawing.RectangleF selectRectMap)
		{
			this.SelectRectMap = selectRectMap;
		}
	}
}
