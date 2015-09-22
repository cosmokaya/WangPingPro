using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using wMetroGIS.Properties;
using wMetroGIS.wMapProjection;

namespace wMetroGIS.wParams
{
	public class MapParams : BaseParams
	{
		public MapLine m_MapLineBoundary = new MapLine();

		public int m_EdgeLeft = 50;

		public int m_EdgeRight = 50;

		public int m_EdgeTop = 30;

		public int m_EdgeBottom = 30;

		private System.Drawing.Color m_BackgroundColor;

		private bool m_WantBackgroundImage;

		private string m_BackgroundImagePath;

		private string m_DefaultMapTitle;

		private float m_WHScale;

		private int m_Zoom;

		private System.Drawing.Color m_BoundaryLineColor;

		private int m_BoundaryLineWidth;

		private System.Drawing.Drawing2D.DashStyle m_BoundaryLineStyle;

		private System.Drawing.Color m_BoundaryAreaColor;

		private int m_BoundaryAreaAlpha;

		private bool m_WantBoundary;

		private bool m_FillBoundary;

		private string m_BoundaryDataPath;

		private bool m_WantLonLat;

		private System.Drawing.Color m_LonLatLineColor;

		private int m_LonLatLineWidth;

		private System.Drawing.Drawing2D.DashStyle m_LonLatLineStyle;

		private System.Drawing.Color m_LonLatTextColor;

		private int m_LonLatTextHeight;

		private bool m_LonLatTextBold;

		private float m_LonLatStep;

		private bool m_WantCity;

		private System.Drawing.Color m_CityTextColorFore;

		private System.Drawing.Color m_CityTextColorBack;

		private int m_CityTextHeight;

		private bool m_CityTextBold;

		private bool m_WantStation;

		private bool m_ShowStationInThumb = false;

		private System.Drawing.Color m_StationTextColorFore1;

		private System.Drawing.Color m_StationTextColorFore2;

		private System.Drawing.Color m_StationTextColorBack1;

		private System.Drawing.Color m_StationTextColorBack2;

		private string m_StationDataPath1;

		private string m_StationDataPath2;

		private int m_StationTextHeight;

		private bool m_StationTextBold;

		private bool m_WantProvince;

		private System.Drawing.Color m_ProvinceLineColor;

		private int m_ProvinceLineWidth;

		private System.Drawing.Drawing2D.DashStyle m_ProvinceLineStyle;

		private bool m_WantRiver;

		private System.Drawing.Color m_RiverColor;

		private int m_RiverWidth;

		private System.Drawing.Drawing2D.DashStyle m_RiverStyle;

		public bool KeyAreaShow = false;

		public System.Collections.Generic.List<string> KeyAreaDataPath = new System.Collections.Generic.List<string>();

		public System.Collections.Generic.List<System.Drawing.Color> KeyAreaColor = new System.Collections.Generic.List<System.Drawing.Color>();

		public int KeyAreaAlpha = 128;

		public System.Drawing.Point ColorBarPos = new System.Drawing.Point(40, 30);

		public int ColorBarWidth = 400;

		public int ColorBarHeight = 60;

		public bool CoorUseLonLatType = true;

		public string CoorNameX = "M";

		public string CoorNameY = "M";

		public System.Drawing.Color BackgroundColor
		{
			get
			{
				return this.m_BackgroundColor;
			}
			set
			{
				if (this.m_BackgroundColor != value)
				{
					this.m_BackgroundColor = value;
				}
			}
		}

		public bool WantBackgroundImage
		{
			get
			{
				return this.m_WantBackgroundImage;
			}
			set
			{
				if (this.m_WantBackgroundImage != value)
				{
					this.m_WantBackgroundImage = value;
				}
			}
		}

		public string BackgroundImagePath
		{
			get
			{
				string result;
				if (System.IO.Path.GetDirectoryName(this.m_BackgroundImagePath).Length == 0)
				{
					result = System.IO.Path.GetDirectoryName(base.ParamFilePath) + "\\" + this.m_BackgroundImagePath;
				}
				else
				{
					result = this.m_BackgroundImagePath;
				}
				return result;
			}
			set
			{
				if (System.IO.Path.GetDirectoryName(value) == System.IO.Path.GetDirectoryName(base.ParamFilePath))
				{
					this.m_BackgroundImagePath = System.IO.Path.GetFileName(value);
				}
				else
				{
					this.m_BackgroundImagePath = value;
				}
			}
		}

		public string DefaultMapTitle
		{
			get
			{
				return this.m_DefaultMapTitle;
			}
			set
			{
				this.m_DefaultMapTitle = value;
			}
		}

		public int ProjectionType
		{
			get;
			set;
		}

		public int PicWidth
		{
			get;
			set;
		}

		public int PicHeight
		{
			get;
			set;
		}

		public int Zoom
		{
			get
			{
				return this.m_Zoom;
			}
			set
			{
				if (this.m_Zoom != value)
				{
					this.m_Zoom = value;
				}
			}
		}

		public float WHScale
		{
			get
			{
				return this.m_WHScale;
			}
			set
			{
				if (this.m_WHScale != value)
				{
					this.m_WHScale = value;
				}
			}
		}

		public float StandardLon
		{
			get;
			set;
		}

		public float StandardLat
		{
			get;
			set;
		}

		public float CenterLon
		{
			get;
			set;
		}

		public float CenterLat
		{
			get;
			set;
		}

		public System.Drawing.Color BoundaryLineColor
		{
			get
			{
				return this.m_BoundaryLineColor;
			}
			set
			{
				if (this.m_BoundaryLineColor != value)
				{
					this.m_BoundaryLineColor = value;
				}
			}
		}

		public int BoundaryLineWidth
		{
			get
			{
				return this.m_BoundaryLineWidth;
			}
			set
			{
				this.m_BoundaryLineWidth = value;
			}
		}

		public System.Drawing.Drawing2D.DashStyle BoundaryLineStyle
		{
			get
			{
				return this.m_BoundaryLineStyle;
			}
			set
			{
				this.m_BoundaryLineStyle = value;
			}
		}

		public System.Drawing.Color BoundaryAreaColor
		{
			get
			{
				return this.m_BoundaryAreaColor;
			}
			set
			{
				if (this.m_BoundaryAreaColor != value)
				{
					this.m_BoundaryAreaColor = value;
				}
			}
		}

		public int BoundaryAreaAlpha
		{
			get
			{
				return this.m_BoundaryAreaAlpha;
			}
			set
			{
				if (this.m_BoundaryAreaAlpha != value)
				{
					this.m_BoundaryAreaAlpha = value;
				}
			}
		}

		public bool WantBoundary
		{
			get
			{
				return this.m_WantBoundary;
			}
			set
			{
				if (this.m_WantBoundary != value)
				{
					this.m_WantBoundary = value;
				}
			}
		}

		public bool FillBoundary
		{
			get
			{
				return this.m_FillBoundary;
			}
			set
			{
				if (this.m_FillBoundary != value)
				{
					this.m_FillBoundary = value;
				}
			}
		}

		public string BoundaryDataPath
		{
			get
			{
				string result;
				if (this.m_BoundaryDataPath == "")
				{
					result = "";
				}
				else if (System.IO.Path.GetDirectoryName(this.m_BoundaryDataPath).Length == 0)
				{
					result = System.IO.Path.GetDirectoryName(base.ParamFilePath) + "\\" + this.m_BoundaryDataPath;
				}
				else
				{
					result = this.m_BoundaryDataPath;
				}
				return result;
			}
			set
			{
				if (System.IO.Path.GetDirectoryName(value) == System.IO.Path.GetDirectoryName(base.ParamFilePath))
				{
					this.m_BoundaryDataPath = System.IO.Path.GetFileName(value);
				}
				else
				{
					this.m_BoundaryDataPath = value;
				}
			}
		}

		public bool WantLonLat
		{
			get
			{
				return this.m_WantLonLat;
			}
			set
			{
				this.m_WantLonLat = value;
			}
		}

		public System.Drawing.Color LonLatLineColor
		{
			get
			{
				return this.m_LonLatLineColor;
			}
			set
			{
				this.m_LonLatLineColor = value;
			}
		}

		public int LonLatLineWidth
		{
			get
			{
				return this.m_LonLatLineWidth;
			}
			set
			{
				this.m_LonLatLineWidth = value;
			}
		}

		public System.Drawing.Drawing2D.DashStyle LonLatLineStyle
		{
			get
			{
				return this.m_LonLatLineStyle;
			}
			set
			{
				this.m_LonLatLineStyle = value;
			}
		}

		public System.Drawing.Color LonLatTextColor
		{
			get
			{
				return this.m_LonLatTextColor;
			}
			set
			{
				this.m_LonLatTextColor = value;
			}
		}

		public int LonLatTextHeight
		{
			get
			{
				return this.m_LonLatTextHeight;
			}
			set
			{
				this.m_LonLatTextHeight = value;
			}
		}

		public bool LonLatTextBold
		{
			get
			{
				return this.m_LonLatTextBold;
			}
			set
			{
				this.m_LonLatTextBold = value;
			}
		}

		public float LonLatStep
		{
			get
			{
				return this.m_LonLatStep;
			}
			set
			{
				this.m_LonLatStep = value;
			}
		}

		public bool WantCity
		{
			get
			{
				return this.m_WantCity;
			}
			set
			{
				if (this.m_WantCity != value)
				{
					this.m_WantCity = value;
				}
			}
		}

		public System.Drawing.Color CityTextColorFore
		{
			get
			{
				return this.m_CityTextColorFore;
			}
			set
			{
				this.m_CityTextColorFore = value;
			}
		}

		public System.Drawing.Color CityTextColorBack
		{
			get
			{
				return this.m_CityTextColorBack;
			}
			set
			{
				this.m_CityTextColorBack = value;
			}
		}

		public int CityTextHeight
		{
			get
			{
				return this.m_CityTextHeight;
			}
			set
			{
				this.m_CityTextHeight = value;
			}
		}

		public bool CityTextBold
		{
			get
			{
				return this.m_CityTextBold;
			}
			set
			{
				this.m_CityTextBold = value;
			}
		}

		public bool WantStation
		{
			get
			{
				return this.m_WantStation;
			}
			set
			{
				if (this.m_WantStation != value)
				{
					this.m_WantStation = value;
				}
			}
		}

		public bool ShowStationInThumb
		{
			get
			{
				return this.m_ShowStationInThumb;
			}
			set
			{
				this.m_ShowStationInThumb = value;
			}
		}

		public System.Drawing.Color StationTextColorFore1
		{
			get
			{
				return this.m_StationTextColorFore1;
			}
			set
			{
				this.m_StationTextColorFore1 = value;
			}
		}

		public System.Drawing.Color StationTextColorFore2
		{
			get
			{
				return this.m_StationTextColorFore2;
			}
			set
			{
				this.m_StationTextColorFore2 = value;
			}
		}

		public System.Drawing.Color StationTextColorBack1
		{
			get
			{
				return this.m_StationTextColorBack1;
			}
			set
			{
				this.m_StationTextColorBack1 = value;
			}
		}

		public System.Drawing.Color StationTextColorBack2
		{
			get
			{
				return this.m_StationTextColorBack2;
			}
			set
			{
				this.m_StationTextColorBack2 = value;
			}
		}

		public string StationDataPath1
		{
			get
			{
				return this.m_StationDataPath1;
			}
			set
			{
				this.m_StationDataPath1 = value;
			}
		}

		public string StationDataPath2
		{
			get
			{
				return this.m_StationDataPath2;
			}
			set
			{
				this.m_StationDataPath2 = value;
			}
		}

		public int StationTextHeight
		{
			get
			{
				return this.m_StationTextHeight;
			}
			set
			{
				this.m_StationTextHeight = value;
			}
		}

		public bool StationTextBold
		{
			get
			{
				return this.m_StationTextBold;
			}
			set
			{
				this.m_StationTextBold = value;
			}
		}

		public bool WantProvince
		{
			get
			{
				return this.m_WantProvince;
			}
			set
			{
				this.m_WantProvince = value;
			}
		}

		public System.Drawing.Color ProvinceLineColor
		{
			get
			{
				return this.m_ProvinceLineColor;
			}
			set
			{
				this.m_ProvinceLineColor = value;
			}
		}

		public int ProvinceLineWidth
		{
			get
			{
				return this.m_ProvinceLineWidth;
			}
			set
			{
				this.m_ProvinceLineWidth = value;
			}
		}

		public System.Drawing.Drawing2D.DashStyle ProvinceLineStyle
		{
			get
			{
				return this.m_ProvinceLineStyle;
			}
			set
			{
				this.m_ProvinceLineStyle = value;
			}
		}

		public bool WantRiver
		{
			get
			{
				return this.m_WantRiver;
			}
			set
			{
				this.m_WantRiver = value;
			}
		}

		public System.Drawing.Color RiverColor
		{
			get
			{
				return this.m_RiverColor;
			}
			set
			{
				this.m_RiverColor = value;
			}
		}

		public int RiverWidth
		{
			get
			{
				return this.m_RiverWidth;
			}
			set
			{
				this.m_RiverWidth = value;
			}
		}

		public System.Drawing.Drawing2D.DashStyle RiverStyle
		{
			get
			{
				return this.m_RiverStyle;
			}
			set
			{
				this.m_RiverStyle = value;
			}
		}

		public System.Drawing.Rectangle PicRect
		{
			get
			{
				return new System.Drawing.Rectangle(this.m_EdgeLeft, this.m_EdgeTop, this.PicWidth - this.m_EdgeLeft - this.m_EdgeRight + 1, this.PicHeight - this.m_EdgeTop - this.m_EdgeBottom + 1);
			}
		}

		public System.Drawing.Rectangle CoorRect
		{
			get
			{
				return new System.Drawing.Rectangle(this.m_EdgeLeft / 2, this.m_EdgeTop / 2, this.PicWidth - this.m_EdgeLeft / 2 - this.m_EdgeRight / 2, this.PicHeight - this.m_EdgeTop / 2 - this.m_EdgeBottom / 2);
			}
		}

		public MapParams()
		{
			base.ParamFilePath = System.Windows.Forms.Application.StartupPath + "\\AppData\\Default.mst";
			this.LoadParams();
		}

		public MapParams(string paramFilePath)
		{
			base.ParamFilePath = paramFilePath;
			this.LoadParams();
		}

		public override bool LoadParams()
		{
			this.m_LoadSccessed = false;
			bool result;
			try
			{
				XmlDocument myXmlDoc = new XmlDocument();
				myXmlDoc.Load(base.ParamFilePath);
				XmlNodeList myParams = myXmlDoc.GetElementsByTagName("背景颜色");
				this.m_BackgroundColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("显示地图");
				this.m_WantBackgroundImage = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("地图文件");
				this.m_BackgroundImagePath = System.Convert.ToString(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("默认标题");
				this.m_DefaultMapTitle = System.Convert.ToString(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("图片尺寸");
				this.PicWidth = System.Convert.ToInt32(myParams[0].Attributes["宽"].Value);
				this.PicHeight = System.Convert.ToInt32(myParams[0].Attributes["高"].Value);
				myParams = myXmlDoc.GetElementsByTagName("图边留白");
				this.m_EdgeLeft = System.Convert.ToInt32(myParams[0].Attributes["左"].Value);
				this.m_EdgeRight = System.Convert.ToInt32(myParams[0].Attributes["右"].Value);
				this.m_EdgeBottom = System.Convert.ToInt32(myParams[0].Attributes["下"].Value);
				this.m_EdgeTop = System.Convert.ToInt32(myParams[0].Attributes["上"].Value);
				myParams = myXmlDoc.GetElementsByTagName("投影类型");
				this.ProjectionType = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("中心经度");
				this.CenterLon = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("中心纬度");
				this.CenterLat = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("放大倍数");
				this.m_Zoom = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("宽高比例");
				this.m_WHScale = System.Convert.ToSingle(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("标准经度");
				this.StandardLon = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("标准纬度");
				this.StandardLat = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("边线颜色");
				this.m_BoundaryLineColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("边线粗细");
				this.m_BoundaryLineWidth = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("边线类型");
				this.m_BoundaryLineStyle = base.IntToDashStyle(System.Convert.ToInt32(myParams[0].Attributes["value"].Value));
				myParams = myXmlDoc.GetElementsByTagName("区域颜色");
				this.m_BoundaryAreaColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("区域透明度");
				this.m_BoundaryAreaAlpha = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示边线");
				this.m_WantBoundary = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("填充区域");
				this.m_FillBoundary = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("边线数据");
				this.m_BoundaryDataPath = System.Convert.ToString(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示经纬线");
				this.m_WantLonLat = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("经纬线颜色");
				this.m_LonLatLineColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("经纬线粗细");
				this.m_LonLatLineWidth = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("经纬线类型");
				this.m_LonLatLineStyle = base.IntToDashStyle(System.Convert.ToInt32(myParams[0].Attributes["value"].Value));
				myParams = myXmlDoc.GetElementsByTagName("经纬文字颜色");
				this.m_LonLatTextColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("经纬文字大小");
				this.m_LonLatTextHeight = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("经纬文字加粗");
				this.m_LonLatTextBold = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("经纬线间隔");
				this.m_LonLatStep = System.Convert.ToSingle(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示城市");
				this.m_WantCity = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("城市文字前景颜色");
				this.m_CityTextColorFore = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("城市文字背景颜色");
				this.m_CityTextColorBack = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("城市文字大小");
				this.m_CityTextHeight = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("城市文字加粗");
				this.m_CityTextBold = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示站点");
				this.m_WantStation = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示站点在缩略图");
				this.m_ShowStationInThumb = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("站点文字前景颜色1");
				this.m_StationTextColorFore1 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("站点文字背景颜色1");
				this.m_StationTextColorBack1 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("站点文字前景颜色2");
				this.m_StationTextColorFore2 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("站点文字背景颜色2");
				this.m_StationTextColorBack2 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("站点数据1");
				this.m_StationDataPath1 = System.Convert.ToString(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("站点数据2");
				this.m_StationDataPath2 = System.Convert.ToString(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("站点文字大小");
				this.m_StationTextHeight = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("站点文字加粗");
				this.m_StationTextBold = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示省界");
				this.m_WantProvince = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("省界颜色");
				this.m_ProvinceLineColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("省界粗细");
				this.m_ProvinceLineWidth = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("省界类型");
				this.m_ProvinceLineStyle = base.IntToDashStyle(System.Convert.ToInt32(myParams[0].Attributes["value"].Value));
				myParams = myXmlDoc.GetElementsByTagName("显示河流");
				this.m_WantRiver = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("河流颜色");
				this.m_RiverColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("河流粗细");
				this.m_RiverWidth = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("河流类型");
				this.m_RiverStyle = base.IntToDashStyle(System.Convert.ToInt32(myParams[0].Attributes["value"].Value));
				this.KeyAreaDataPath = new System.Collections.Generic.List<string>();
				this.KeyAreaColor = new System.Collections.Generic.List<System.Drawing.Color>();
				myParams = myXmlDoc.GetElementsByTagName("显示关键区域");
				this.KeyAreaShow = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("关键区域透明度");
				this.KeyAreaAlpha = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("关键区域个数");
				int N = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				for (int i = 1; i <= N; i++)
				{
					string Name = "关键区域" + System.Convert.ToString(i);
					myParams = myXmlDoc.GetElementsByTagName(Name);
					string dataPath = System.Convert.ToString(myParams[0].Attributes["路径"].Value);
					int R = System.Convert.ToInt32(myParams[0].Attributes["R"].Value);
					int G = System.Convert.ToInt32(myParams[0].Attributes["G"].Value);
					int B = System.Convert.ToInt32(myParams[0].Attributes["B"].Value);
					this.KeyAreaDataPath.Add(dataPath);
					this.KeyAreaColor.Add(System.Drawing.Color.FromArgb(R, G, B));
				}
				myParams = myXmlDoc.GetElementsByTagName("颜色条位置");
				this.ColorBarPos = new System.Drawing.Point(System.Convert.ToInt32(myParams[0].Attributes["X"].Value), System.Convert.ToInt32(myParams[0].Attributes["Y"].Value));
				myParams = myXmlDoc.GetElementsByTagName("颜色条宽度");
				this.ColorBarWidth = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("颜色条高度");
				this.ColorBarHeight = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示为经纬信息");
				this.CoorUseLonLatType = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("鼠标X坐标名称");
				this.CoorNameX = System.Convert.ToString(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("鼠标Y坐标名称");
				this.CoorNameY = System.Convert.ToString(myParams[0].Attributes["value"].Value);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("载入参数出错!\r\n" + ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_LoadSccessed = false;
				result = false;
				return result;
			}
			this.m_LoadSccessed = true;
			result = base.LoadParams();
			return result;
		}

		public override bool SaveParams()
		{
			bool result;
			if (this.PicWidth > 4000 || this.PicHeight > 4000)
			{
				System.Windows.Forms.MessageBox.Show("地图的尺寸太大，宽或高不能超过4000像素，请重新设置！");
				result = false;
			}
			else
			{
				try
				{
					XmlDocument myXmlDoc = new XmlDocument();
					myXmlDoc.LoadXml("<参数></参数>");
					XmlElement root = myXmlDoc.DocumentElement;
					myXmlDoc.InsertBefore(myXmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes"), root);
					myXmlDoc.InsertBefore(myXmlDoc.CreateComment("参数配置文件，请不要修改任何地方，否则程序可能无法启动！"), root);
					XmlNode node = myXmlDoc.CreateElement("地图参数");
					XmlNode subnode = myXmlDoc.CreateElement("背景颜色");
					XmlAttribute subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_BackgroundColor.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_BackgroundColor.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_BackgroundColor.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("显示地图");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_WantBackgroundImage.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("地图文件");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_BackgroundImagePath;
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("默认标题");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_DefaultMapTitle;
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("图片尺寸");
					subnodeAtt = myXmlDoc.CreateAttribute("宽");
					subnodeAtt.Value = this.PicWidth.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("高");
					subnodeAtt.Value = this.PicHeight.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("图边留白");
					subnodeAtt = myXmlDoc.CreateAttribute("左");
					subnodeAtt.Value = this.m_EdgeLeft.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("右");
					subnodeAtt.Value = this.m_EdgeRight.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("下");
					subnodeAtt.Value = this.m_EdgeBottom.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("上");
					subnodeAtt.Value = this.m_EdgeTop.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("投影参数");
					subnode = myXmlDoc.CreateElement("投影类型");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.ProjectionType.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("中心经度");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.CenterLon.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("中心纬度");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.CenterLat.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("放大倍数");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_Zoom.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("宽高比例");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_WHScale.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("标准经度");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.StandardLon.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("标准纬度");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.StandardLat.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("边界参数");
					subnode = myXmlDoc.CreateElement("边线颜色");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_BoundaryLineColor.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_BoundaryLineColor.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_BoundaryLineColor.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("边线粗细");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_BoundaryLineWidth.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("边线类型");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = base.DashStyleToInt(this.m_BoundaryLineStyle).ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("边线数据");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_BoundaryDataPath;
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("区域颜色");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_BoundaryAreaColor.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_BoundaryAreaColor.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_BoundaryAreaColor.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("区域透明度");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_BoundaryAreaAlpha.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("显示边线");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_WantBoundary.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("填充区域");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_FillBoundary.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("经纬线");
					subnode = myXmlDoc.CreateElement("显示经纬线");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_WantLonLat.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("经纬线颜色");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_LonLatLineColor.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_LonLatLineColor.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_LonLatLineColor.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("经纬线粗细");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_LonLatLineWidth.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("经纬线类型");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = base.DashStyleToInt(this.m_LonLatLineStyle).ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("经纬文字颜色");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_LonLatTextColor.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_LonLatTextColor.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_LonLatTextColor.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("经纬文字大小");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_LonLatTextHeight.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("经纬文字加粗");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_LonLatTextBold.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("经纬线间隔");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_LonLatStep.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("城市");
					subnode = myXmlDoc.CreateElement("显示城市");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_WantCity.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("城市文字前景颜色");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_CityTextColorFore.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_CityTextColorFore.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_CityTextColorFore.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("城市文字背景颜色");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_CityTextColorBack.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_CityTextColorBack.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_CityTextColorBack.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("城市文字大小");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_CityTextHeight.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("城市文字加粗");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_CityTextBold.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("站点");
					subnode = myXmlDoc.CreateElement("显示站点");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_WantStation.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("显示站点在缩略图");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.ShowStationInThumb.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("站点文字前景颜色1");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_StationTextColorFore1.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_StationTextColorFore1.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_StationTextColorFore1.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("站点文字前景颜色2");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_StationTextColorFore2.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_StationTextColorFore2.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_StationTextColorFore2.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("站点文字背景颜色1");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_StationTextColorBack1.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_StationTextColorBack1.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_StationTextColorBack1.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("站点文字背景颜色2");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_StationTextColorBack2.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_StationTextColorBack2.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_StationTextColorBack2.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("站点文字大小");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_StationTextHeight.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("站点文字加粗");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_StationTextBold.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("站点数据1");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_StationDataPath1.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("站点数据2");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_StationDataPath2.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("省界");
					subnode = myXmlDoc.CreateElement("显示省界");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_WantProvince.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("省界颜色");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_ProvinceLineColor.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_ProvinceLineColor.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_ProvinceLineColor.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("省界粗细");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_ProvinceLineWidth.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("省界类型");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = base.DashStyleToInt(this.m_ProvinceLineStyle).ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("河流");
					subnode = myXmlDoc.CreateElement("显示河流");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_WantRiver.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("河流颜色");
					subnodeAtt = myXmlDoc.CreateAttribute("R");
					subnodeAtt.Value = this.m_RiverColor.R.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("G");
					subnodeAtt.Value = this.m_RiverColor.G.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("B");
					subnodeAtt.Value = this.m_RiverColor.B.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("河流粗细");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.m_RiverWidth.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("河流类型");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = base.DashStyleToInt(this.m_RiverStyle).ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("关键区域");
					subnode = myXmlDoc.CreateElement("显示关键区域");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.KeyAreaShow.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("关键区域个数");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.KeyAreaDataPath.Count.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("关键区域透明度");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.KeyAreaAlpha.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					for (int i = 0; i < this.KeyAreaDataPath.Count; i++)
					{
						subnode = myXmlDoc.CreateElement("关键区域" + System.Convert.ToString(i + 1));
						subnodeAtt = myXmlDoc.CreateAttribute("路径");
						subnodeAtt.Value = this.KeyAreaDataPath[i];
						subnode.Attributes.Append(subnodeAtt);
						subnodeAtt = myXmlDoc.CreateAttribute("R");
						subnodeAtt.Value = this.KeyAreaColor[i].R.ToString();
						subnode.Attributes.Append(subnodeAtt);
						subnodeAtt = myXmlDoc.CreateAttribute("G");
						subnodeAtt.Value = this.KeyAreaColor[i].G.ToString();
						subnode.Attributes.Append(subnodeAtt);
						subnodeAtt = myXmlDoc.CreateAttribute("B");
						subnodeAtt.Value = this.KeyAreaColor[i].B.ToString();
						subnode.Attributes.Append(subnodeAtt);
						node.AppendChild(subnode);
					}
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("颜色条");
					subnode = myXmlDoc.CreateElement("颜色条位置");
					subnodeAtt = myXmlDoc.CreateAttribute("X");
					subnodeAtt.Value = this.ColorBarPos.X.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("Y");
					subnodeAtt.Value = this.ColorBarPos.Y.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("颜色条宽度");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.ColorBarWidth.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("颜色条高度");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.ColorBarHeight.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					node = myXmlDoc.CreateElement("鼠标信息");
					subnode = myXmlDoc.CreateElement("显示为经纬信息");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.CoorUseLonLatType.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("鼠标X坐标名称");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.CoorNameX.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					subnode = myXmlDoc.CreateElement("鼠标Y坐标名称");
					subnodeAtt = myXmlDoc.CreateAttribute("value");
					subnodeAtt.Value = this.CoorNameY.ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
					root.AppendChild(node);
					myXmlDoc.Save(base.ParamFilePath);
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("保存参数出错!\r\n" + ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					result = false;
					return result;
				}
				result = base.SaveParams();
			}
			return result;
		}

		public System.Drawing.Bitmap DrawMap(Projection Projection)
		{
			return this.DrawMap(Projection, new System.Drawing.Size(this.PicWidth, this.PicHeight), false);
		}

		public System.Drawing.Bitmap DrawMap(Projection Projection, System.Drawing.Size MapPicSize, bool IsThumb)
		{
			bool getBkGroundSccessed = false;
			System.Drawing.Bitmap loadBitmap = null;
			if (this.WantBackgroundImage)
			{
				try
				{
					loadBitmap = (System.Drawing.Bitmap)System.Drawing.Image.FromFile(this.BackgroundImagePath);
					if (loadBitmap != null)
					{
						getBkGroundSccessed = true;
					}
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show(ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
			}
			System.Drawing.Bitmap MapPic = new System.Drawing.Bitmap(MapPicSize.Width, MapPicSize.Height);
			System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(MapPic);
			if (getBkGroundSccessed)
			{
				System.Drawing.PointF ptLeftTop = new System.Drawing.PointF(70f, 90f);
				float pixPerLonLat = 20f;
				if (System.IO.File.Exists(this.BackgroundImagePath + ".pz"))
				{
					try
					{
						System.IO.FileStream fs = new System.IO.FileStream(this.BackgroundImagePath + ".pz", System.IO.FileMode.Open, System.IO.FileAccess.Read);
						System.IO.StreamReader sr = new System.IO.StreamReader(fs, System.Text.Encoding.Default);
						float n = System.Convert.ToSingle(sr.ReadLine());
						float n2 = System.Convert.ToSingle(sr.ReadLine());
						float n3 = System.Convert.ToSingle(sr.ReadLine());
						float n4 = System.Convert.ToSingle(sr.ReadLine());
						sr.Close();
						fs.Close();
						ptLeftTop = new System.Drawing.PointF(n, n4);
						pixPerLonLat = System.Convert.ToSingle((float)loadBitmap.Width / (n2 - n));
					}
					catch (System.Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "读取底图配准信息错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					}
				}
				System.Drawing.PointF pt = Projection.XY2LonLat(0, 0);
				System.Drawing.PointF pt2 = Projection.XY2LonLat(this.PicWidth, this.PicHeight);
				float Left = pt.X;
				float Right = pt2.X;
				float Top = pt.Y;
				float Bottom = pt2.Y;
				int StartX = (int)(pixPerLonLat * (Left - ptLeftTop.X));
				int StartY = (int)(pixPerLonLat * (ptLeftTop.Y - Top));
				int OrgWidth = (int)(pixPerLonLat * (Right - Left));
				int OrgHeight = (int)(pixPerLonLat * (Top - Bottom));
				g.DrawImage(loadBitmap, new System.Drawing.Rectangle(0, 0, MapPic.Width, MapPic.Height), new System.Drawing.Rectangle(StartX, StartY, OrgWidth, OrgHeight), System.Drawing.GraphicsUnit.Pixel);
				loadBitmap.Dispose();
			}
			else
			{
				g.FillRectangle(new System.Drawing.SolidBrush(this.BackgroundColor), new System.Drawing.Rectangle(0, 0, MapPic.Width, MapPic.Height));
			}
			if (this.WantBoundary || this.FillBoundary)
			{
				if (this.BoundaryDataPath != "")
				{
					this.m_MapLineBoundary.LoadData(this.BoundaryDataPath);
				}
				if (!this.m_MapLineBoundary.isValable)
				{
					this.m_MapLineBoundary.LoadDefaultData();
				}
				if (this.m_MapLineBoundary.isValable)
				{
					System.Drawing.Pen LinePen = new System.Drawing.Pen(this.BoundaryLineColor, (float)this.BoundaryLineWidth);
					LinePen.DashStyle = this.BoundaryLineStyle;
					foreach (System.Drawing.PointF[] LineDataF in this.m_MapLineBoundary.m_Lines)
					{
						int PointNum = LineDataF.Length;
						System.Drawing.Point[] LineData = new System.Drawing.Point[PointNum];
						System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
						for (int i = 0; i < PointNum; i++)
						{
							LineData[i] = Projection.LonLat2XY(LineDataF[i]);
						}
						if (this.FillBoundary)
						{
							path.AddLines(LineData);
							g.FillPath(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(this.BoundaryAreaAlpha, this.BoundaryAreaColor)), path);
						}
						if (this.WantBoundary)
						{
							g.DrawLines(LinePen, LineData);
						}
					}
				}
			}
			if (this.WantProvince)
			{
				System.Drawing.Pen LinePen = new System.Drawing.Pen(this.ProvinceLineColor, (float)this.ProvinceLineWidth);
				LinePen.DashStyle = this.ProvinceLineStyle;
				System.IO.MemoryStream ms = new System.IO.MemoryStream(Resources.China_Province);
				System.IO.BinaryReader br = new System.IO.BinaryReader(ms, System.Text.Encoding.Default);
				while (br.PeekChar() != -1)
				{
					int PointNum = br.ReadInt32();
					System.Drawing.Point[] LineData = new System.Drawing.Point[PointNum];
					for (int i = 0; i < PointNum; i++)
					{
						float Lon = br.ReadSingle();
						float Lat = br.ReadSingle();
						LineData[i] = Projection.LonLat2XY(Lon, Lat);
					}
					g.DrawLines(LinePen, LineData);
				}
				br.Close();
				ms.Close();
			}
			if (this.WantRiver)
			{
				System.Drawing.Pen LinePen = new System.Drawing.Pen(this.RiverColor, (float)this.RiverWidth);
				LinePen.DashStyle = this.RiverStyle;
				System.IO.MemoryStream ms = new System.IO.MemoryStream(Resources.China_River);
				System.IO.BinaryReader br = new System.IO.BinaryReader(ms, System.Text.Encoding.Default);
				int j = 0;
				while (br.PeekChar() != -1)
				{
					int PointNum = br.ReadInt32();
					System.Collections.Generic.List<System.Drawing.Point> LineData2 = new System.Collections.Generic.List<System.Drawing.Point>(PointNum);
					for (int i = 0; i < PointNum; i++)
					{
						float Lon = br.ReadSingle();
						float Lat = br.ReadSingle();
						if (j != 1 || i >= 4)
						{
							LineData2.Add(Projection.LonLat2XY(Lon, Lat));
						}
					}
					g.DrawLines(LinePen, LineData2.ToArray());
					j++;
				}
				br.Close();
				ms.Close();
			}
			if (this.KeyAreaShow)
			{
				if (this.KeyAreaDataPath != null && this.KeyAreaDataPath.Count != 0 && this.KeyAreaColor != null && this.KeyAreaColor.Count == this.KeyAreaDataPath.Count)
				{
					try
					{
						for (int i = 0; i < this.KeyAreaDataPath.Count; i++)
						{
							string thisDataPath = this.KeyAreaDataPath[i];
							if (!System.IO.File.Exists(thisDataPath))
							{
								thisDataPath = System.Windows.Forms.Application.StartupPath + "\\" + thisDataPath;
								if (!System.IO.File.Exists(thisDataPath))
								{
									throw new System.Exception(string.Format("关键区域{0}数据文件不存在！\n{1}", i + 1, thisDataPath));
								}
							}
							System.Drawing.Color thisColor = this.KeyAreaColor[i];
							MapLine thisLine = new MapLine();
							if (thisLine.LoadData(thisDataPath))
							{
								System.Drawing.Pen LinePen = new System.Drawing.Pen(thisColor, 1f);
								LinePen.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
								foreach (System.Drawing.PointF[] LineDataF in thisLine.m_Lines)
								{
									int PointNum = LineDataF.Length;
									System.Drawing.Point[] LineData = new System.Drawing.Point[PointNum];
									System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath(System.Drawing.Drawing2D.FillMode.Winding);
									for (int k = 0; k < PointNum; k++)
									{
										LineData[k] = Projection.LonLat2XY(LineDataF[k]);
									}
									path.AddLines(LineData);
									g.FillPath(new System.Drawing.SolidBrush(System.Drawing.Color.FromArgb(this.KeyAreaAlpha, thisColor)), path);
								}
							}
						}
					}
					catch (System.Exception ex)
					{
						System.Windows.Forms.MessageBox.Show(ex.Message, "绘制重点区域错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
					}
				}
			}
			if (this.WantLonLat)
			{
				System.Drawing.Pen pen = new System.Drawing.Pen(this.LonLatLineColor, (float)this.LonLatLineWidth);
				pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Custom;
				if (this.LonLatLineStyle == System.Drawing.Drawing2D.DashStyle.Dash)
				{
					pen.DashPattern = new float[]
					{
						8f,
						3f
					};
				}
				else if (this.LonLatLineStyle == System.Drawing.Drawing2D.DashStyle.DashDot)
				{
					pen.DashPattern = new float[]
					{
						8f,
						3f,
						2f,
						3f
					};
				}
				else if (this.LonLatLineStyle == System.Drawing.Drawing2D.DashStyle.DashDotDot)
				{
					pen.DashPattern = new float[]
					{
						8f,
						3f,
						2f,
						3f,
						2f,
						3f
					};
				}
				else if (this.LonLatLineStyle == System.Drawing.Drawing2D.DashStyle.Dot)
				{
					pen.DashPattern = new float[]
					{
						2f,
						2f
					};
				}
				else
				{
					pen.DashStyle = this.LonLatLineStyle;
				}
				int myFontHeight = this.LonLatTextHeight;
				System.Drawing.Font myFont = new System.Drawing.Font("黑体", (float)myFontHeight, this.LonLatTextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
				System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(this.LonLatTextColor);
				for (float CurLon = 0f; CurLon <= 360f; CurLon += this.LonLatStep)
				{
					System.Drawing.Point StartPoint = Projection.LonLat2XY(CurLon, 0f);
					System.Drawing.Point EndPoint = Projection.LonLat2XY(CurLon, 90f);
					g.DrawLine(pen, StartPoint, EndPoint);
				}
				for (float CurLat = 0f; CurLat <= 90f; CurLat += this.LonLatStep)
				{
					System.Collections.Generic.List<System.Drawing.Point> pts = new System.Collections.Generic.List<System.Drawing.Point>();
					for (float CurLon = 0f; CurLon <= 360f; CurLon += 1f)
					{
						System.Drawing.Point pt3 = Projection.LonLat2XY(CurLon, CurLat);
						pts.Add(pt3);
					}
					g.DrawLines(pen, pts.ToArray());
				}
			}
			if (this.WantCity)
			{
				int cityFontHeight = this.CityTextHeight;
				System.Drawing.Font cityFont = new System.Drawing.Font("黑体", (float)cityFontHeight, this.CityTextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular);
				System.Drawing.SolidBrush cityBrushFore = new System.Drawing.SolidBrush(this.CityTextColorFore);
				System.Drawing.SolidBrush cityBrushBack = new System.Drawing.SolidBrush(this.CityTextColorBack);
				System.Drawing.StringFormat format = new System.Drawing.StringFormat(System.Drawing.StringFormatFlags.NoClip);
				format.LineAlignment = System.Drawing.StringAlignment.Near;
				format.Alignment = System.Drawing.StringAlignment.Near;
				System.IO.MemoryStream ms = new System.IO.MemoryStream(Resources.China_City);
				System.IO.StreamReader sr = new System.IO.StreamReader(ms, System.Text.Encoding.Default);
				while (!sr.EndOfStream)
				{
					string[] tmp = base.String2StrData(sr.ReadLine());
					System.Drawing.Point CityPos = Projection.LonLat2XY(System.Convert.ToSingle(tmp[1]), System.Convert.ToSingle(tmp[0]));
					if (tmp[2] == "北京")
					{
						g.DrawImage(Resources.STAR_01, new System.Drawing.Rectangle(CityPos.X - cityFontHeight, CityPos.Y - cityFontHeight, cityFontHeight * 2, cityFontHeight * 2), new System.Drawing.Rectangle(0, 0, Resources.STAR_01.Size.Width, Resources.STAR_01.Size.Height), System.Drawing.GraphicsUnit.Pixel);
					}
					else
					{
						g.FillEllipse(cityBrushFore, new System.Drawing.Rectangle(CityPos.X - cityFontHeight / 2, CityPos.Y - cityFontHeight / 2, cityFontHeight, cityFontHeight));
						g.DrawEllipse(new System.Drawing.Pen(cityBrushBack, 2f), new System.Drawing.Rectangle(CityPos.X - cityFontHeight / 2, CityPos.Y - cityFontHeight / 2, cityFontHeight, cityFontHeight));
					}
					g.DrawString(" " + tmp[2], cityFont, cityBrushBack, CityPos, format);
					CityPos.Offset(-1, -1);
					g.DrawString(" " + tmp[2], cityFont, cityBrushFore, CityPos, format);
				}
				sr.Close();
				ms.Close();
			}
			g.Dispose();
			return MapPic;
		}

		public void DrawLonLatText(System.Drawing.Graphics g, Projection Projection)
		{
			this.DrawLonLatText(g, Projection, 0, 0);
		}

		public void DrawLonLatText(System.Drawing.Graphics g, Projection Projection, int offX, int offY)
		{
			g.TranslateTransform((float)offX, (float)offY);
			if (this.WantLonLat)
			{
				int myFontHeight = this.LonLatTextHeight;
				System.Drawing.Font myFont = new System.Drawing.Font("黑体", (float)myFontHeight, this.LonLatTextBold ? System.Drawing.FontStyle.Bold : System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
				System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(this.LonLatTextColor);
				System.Drawing.StringFormat sfLeft = new System.Drawing.StringFormat();
				sfLeft.Alignment = System.Drawing.StringAlignment.Far;
				sfLeft.LineAlignment = System.Drawing.StringAlignment.Center;
				System.Drawing.StringFormat sfRight = new System.Drawing.StringFormat();
				sfRight.Alignment = System.Drawing.StringAlignment.Near;
				sfRight.LineAlignment = System.Drawing.StringAlignment.Center;
				System.Drawing.StringFormat sfTop = new System.Drawing.StringFormat();
				sfTop.Alignment = System.Drawing.StringAlignment.Center;
				sfTop.LineAlignment = System.Drawing.StringAlignment.Far;
				System.Drawing.StringFormat sfBottom = new System.Drawing.StringFormat();
				sfBottom.Alignment = System.Drawing.StringAlignment.Center;
				sfBottom.LineAlignment = System.Drawing.StringAlignment.Near;
				System.Drawing.Rectangle showRect = this.PicRect;
				for (float CurLon = 0f; CurLon <= 360f; CurLon += this.LonLatStep)
				{
					string str = string.Format("{0:0.0}{1}", (CurLon <= 180f) ? CurLon : (360f - CurLon), (CurLon <= 180f) ? 'E' : 'W');
					System.Drawing.Point pt = Projection.LonLat2XY(CurLon, 0f);
					System.Drawing.Point pt2 = System.Drawing.Point.Empty;
					for (float CurLat = 1f; CurLat <= 90f; CurLat += 1f)
					{
						pt2 = Projection.LonLat2XY(CurLon, CurLat);
						if (pt.Y >= showRect.Bottom && pt2.Y <= showRect.Bottom)
						{
							System.Drawing.Point ptText = new System.Drawing.Point(pt.X, showRect.Bottom + 2);
							if (ptText.X >= showRect.Left && ptText.X <= showRect.Right)
							{
								g.DrawString(str, myFont, myBrush, ptText, sfBottom);
							}
							break;
						}
						pt = pt2;
					}
					pt = Projection.LonLat2XY(CurLon, 90f);
					pt2 = System.Drawing.Point.Empty;
					for (float CurLat = 89f; CurLat >= 0f; CurLat -= 1f)
					{
						pt2 = Projection.LonLat2XY(CurLon, CurLat);
						if (pt.Y <= showRect.Top && pt2.Y >= showRect.Top)
						{
							System.Drawing.Point ptText = new System.Drawing.Point(pt.X, showRect.Top - 2);
							if (ptText.X >= showRect.Left && ptText.X <= showRect.Right)
							{
								g.DrawString(str, myFont, myBrush, ptText, sfTop);
							}
							break;
						}
						pt = pt2;
					}
				}
				for (float CurLat = 0f; CurLat <= 90f; CurLat += this.LonLatStep)
				{
					string str = string.Format("{0:0.0}{1}", CurLat, (CurLat <= 0f) ? 'S' : 'N');
					System.Drawing.Point pt = Projection.LonLat2XY(0f, CurLat);
					System.Drawing.Point pt2 = System.Drawing.Point.Empty;
					for (float CurLon = 1f; CurLon <= 360f; CurLon += 1f)
					{
						pt2 = Projection.LonLat2XY(CurLon, CurLat);
						if (pt.X <= showRect.Left && pt2.X >= showRect.Left)
						{
							System.Drawing.Point ptText = new System.Drawing.Point(showRect.Left - 2, pt.Y);
							if (ptText.Y >= showRect.Top && ptText.Y <= showRect.Bottom)
							{
								g.DrawString(str, myFont, myBrush, ptText, sfLeft);
							}
							break;
						}
						pt = pt2;
					}
					pt = Projection.LonLat2XY(360f, CurLat);
					pt2 = System.Drawing.Point.Empty;
					for (float CurLon = 359f; CurLon >= 0f; CurLon -= 1f)
					{
						pt2 = Projection.LonLat2XY(CurLon, CurLat);
						if (pt.X >= showRect.Right && pt2.X <= showRect.Right)
						{
							System.Drawing.Point ptText = new System.Drawing.Point(showRect.Right + 2, pt.Y);
							if (ptText.Y >= showRect.Top && ptText.Y <= showRect.Bottom)
							{
								g.DrawString(str, myFont, myBrush, ptText, sfRight);
							}
							break;
						}
						pt = pt2;
					}
				}
			}
			g.ResetTransform();
		}

		public Projection GetProjection()
		{
			return this.GetProjection(this.PicWidth, this.PicHeight, (double)this.Zoom);
		}

		public Projection GetProjection(int picWidth, int picHeight, double zoom)
		{
			Projection result;
			if (this.ProjectionType == 1)
			{
				ProjectionLinear p = new ProjectionLinear((double)this.CenterLon, (double)this.CenterLat, picWidth / 2, picHeight / 2, (double)this.WHScale, zoom);
				result = p;
			}
			else if (this.ProjectionType == 2)
			{
				ProjectionLambert p2 = new ProjectionLambert((double)this.StandardLon, (double)this.StandardLat, (double)this.CenterLon, (double)this.CenterLat, picWidth / 2, picHeight / 2, 0.1 * zoom);
				result = p2;
			}
			else if (this.ProjectionType == 3)
			{
				ProjectionMercator p3 = new ProjectionMercator((double)this.CenterLon, (double)this.CenterLat, picWidth / 2, picHeight / 2, 0.1 * zoom);
				result = p3;
			}
			else if (this.ProjectionType == 4)
			{
				ProjectionStereogram p4 = new ProjectionStereogram((double)this.StandardLon, 90.0, (double)this.CenterLon, (double)this.CenterLat, picWidth / 2, picHeight / 2, 0.1 * zoom);
				result = p4;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
