using System;
using System.Drawing;

namespace wMetroGIS.wMapPictureBoxControl
{
	public class StationSelectEventArgs : System.EventArgs
	{
		public int StationID = -1;

		public string StationName = "";

		public System.Drawing.PointF StationPoint = System.Drawing.PointF.Empty;

		public int StationType = 1;

		public StationSelectEventArgs()
		{
		}

		public StationSelectEventArgs(int stationID, string stationName, System.Drawing.PointF stationPoint)
		{
			this.StationID = stationID;
			this.StationName = stationName;
			this.StationPoint = stationPoint;
			this.StationType = 1;
		}
	}
}
