using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;
using wMetroGIS.wColorManager;

namespace wMetroGIS.wParams
{
	public class ContourParams : BaseParams
	{
		public ColorManager m_ContourLineColorManager = new ColorManager();

		public ColorManager m_ContourFillColorManager = new ColorManager();

		private int m_ContourSearchType;

		private int m_ContourSearchCount;

		private float m_ContourBaseValue;

		private float m_ContourStepValue;

		private float m_ContourMinValue;

		private float m_ContourMaxValue;

		private bool m_ContourUseSpecifiedMinValue;

		private bool m_ContourUseSpecifiedMaxValue;

		private int m_ContourLineWidth;

		private int m_ContourLineStyle;

		private int m_ContourwColorManager;

		private System.Drawing.Color m_ContourDefaultColor;

		private bool m_ContourShowContour;

		private bool m_ContourShowContourText;

		private int m_ContourTextStep;

		private int m_ContourTextHeight;

		private bool m_ContourTextBold;

		private bool m_ContourTextRotate;

		private bool m_ContourTextColor;

		private bool m_ContourWantSPL;

		private int m_ContourMinColorID;

		private int m_ContourMaxColorID;

		private int m_ContourFillType;

		private bool m_ContourWantFill;

		private int m_ContourFillwColorManager;

		private int m_ContourFillAlpha;

		private bool m_ContourWantVertex;

		private bool m_ContourWantTriangle;

		private bool m_ContourShowArrow;

		private string m_ContourValueFormat;

		private string m_ContourValueUnit;

		private bool m_ContourShowUnitInCurve;

		private bool m_ContourShowUnitInColorBar;

		public int ContourSearchType
		{
			get
			{
				return this.m_ContourSearchType;
			}
			set
			{
				if (value == 1 || value == 2 || value == 3)
				{
					this.m_ContourSearchType = value;
				}
				else
				{
					this.m_ContourSearchType = 2;
				}
			}
		}

		public int ContourSearchCount
		{
			get
			{
				return this.m_ContourSearchCount;
			}
			set
			{
				this.m_ContourSearchCount = value;
			}
		}

		public float ContourBaseValue
		{
			get
			{
				return this.m_ContourBaseValue;
			}
			set
			{
				this.m_ContourBaseValue = value;
			}
		}

		public float ContourStepValue
		{
			get
			{
				return this.m_ContourStepValue;
			}
			set
			{
				this.m_ContourStepValue = value;
			}
		}

		public float ContourMinValue
		{
			get
			{
				return this.m_ContourMinValue;
			}
			set
			{
				this.m_ContourMinValue = value;
			}
		}

		public float ContourMaxValue
		{
			get
			{
				return this.m_ContourMaxValue;
			}
			set
			{
				this.m_ContourMaxValue = value;
			}
		}

		public bool ContourUseSpcifiedMinValue
		{
			get
			{
				return this.m_ContourUseSpecifiedMinValue;
			}
			set
			{
				this.m_ContourUseSpecifiedMinValue = value;
			}
		}

		public bool ContourUseSpcifiedMaxValue
		{
			get
			{
				return this.m_ContourUseSpecifiedMaxValue;
			}
			set
			{
				this.m_ContourUseSpecifiedMaxValue = value;
			}
		}

		public int ContourLineWidth
		{
			get
			{
				return this.m_ContourLineWidth;
			}
			set
			{
				this.m_ContourLineWidth = value;
			}
		}

		public System.Drawing.Drawing2D.DashStyle ContourLineStyle
		{
			get
			{
				return base.IntToDashStyle(this.m_ContourLineStyle);
			}
			set
			{
				this.m_ContourLineStyle = base.DashStyleToInt(value);
			}
		}

		public int ContourwColorManager
		{
			get
			{
				return this.m_ContourwColorManager;
			}
			set
			{
				this.m_ContourwColorManager = value;
			}
		}

		public System.Drawing.Color ContourDefaultColor
		{
			get
			{
				return this.m_ContourDefaultColor;
			}
			set
			{
				this.m_ContourDefaultColor = value;
			}
		}

		public bool ContourShowContour
		{
			get
			{
				return this.m_ContourShowContour;
			}
			set
			{
				this.m_ContourShowContour = value;
			}
		}

		public bool ContourShowContourText
		{
			get
			{
				return this.m_ContourShowContourText;
			}
			set
			{
				this.m_ContourShowContourText = value;
			}
		}

		public int ContourTextStep
		{
			get
			{
				return this.m_ContourTextStep;
			}
			set
			{
				this.m_ContourTextStep = value;
			}
		}

		public int ContourTextHeight
		{
			get
			{
				return this.m_ContourTextHeight;
			}
			set
			{
				this.m_ContourTextHeight = value;
			}
		}

		public bool ContourTextBold
		{
			get
			{
				return this.m_ContourTextBold;
			}
			set
			{
				this.m_ContourTextBold = value;
			}
		}

		public bool ContourTextRotate
		{
			get
			{
				return this.m_ContourTextRotate;
			}
			set
			{
				this.m_ContourTextRotate = value;
			}
		}

		public bool ContourTextColor
		{
			get
			{
				return this.m_ContourTextColor;
			}
			set
			{
				this.m_ContourTextColor = value;
			}
		}

		public bool ContourWantSPL
		{
			get
			{
				return this.m_ContourWantSPL;
			}
			set
			{
				this.m_ContourWantSPL = value;
			}
		}

		public int ContourMinColorID
		{
			get
			{
				return this.m_ContourMinColorID;
			}
			set
			{
				this.m_ContourMinColorID = value;
			}
		}

		public int ContourMaxColorID
		{
			get
			{
				return this.m_ContourMaxColorID;
			}
			set
			{
				this.m_ContourMaxColorID = value;
			}
		}

		public int ContourFillType
		{
			get
			{
				return this.m_ContourFillType;
			}
			set
			{
				this.m_ContourFillType = value;
			}
		}

		public bool ContourWantFill
		{
			get
			{
				return this.m_ContourWantFill;
			}
			set
			{
				this.m_ContourWantFill = value;
			}
		}

		public int ContourFillwColorManager
		{
			get
			{
				return this.m_ContourFillwColorManager;
			}
			set
			{
				this.m_ContourFillwColorManager = value;
			}
		}

		public int ContourFillAlpha
		{
			get
			{
				return this.m_ContourFillAlpha;
			}
			set
			{
				this.m_ContourFillAlpha = value;
			}
		}

		public bool ContourWantVertex
		{
			get
			{
				return this.m_ContourWantVertex;
			}
			set
			{
				this.m_ContourWantVertex = value;
			}
		}

		public bool ContourWantTriangle
		{
			get
			{
				return this.m_ContourWantTriangle;
			}
			set
			{
				this.m_ContourWantTriangle = value;
			}
		}

		public bool ContourShowArrow
		{
			get
			{
				return this.m_ContourShowArrow;
			}
			set
			{
				this.m_ContourShowArrow = value;
			}
		}

		public string ContourValueFormat
		{
			get
			{
				return this.m_ContourValueFormat;
			}
			set
			{
				this.m_ContourValueFormat = value;
			}
		}

		public string ContourValueUnit
		{
			get
			{
				return this.m_ContourValueUnit;
			}
			set
			{
				this.m_ContourValueUnit = value;
			}
		}

		public bool ContourShowUnitInCurve
		{
			get
			{
				return this.m_ContourShowUnitInCurve;
			}
			set
			{
				this.m_ContourShowUnitInCurve = value;
			}
		}

		public bool ContourShowUnitInColorBar
		{
			get
			{
				return this.m_ContourShowUnitInColorBar;
			}
			set
			{
				this.m_ContourShowUnitInColorBar = value;
			}
		}

		public ContourParams()
		{
			base.ParamFilePath = System.Windows.Forms.Application.StartupPath + "\\AppData\\Default.cst";
			this.LoadParams();
		}

		public ContourParams(string paramFilePath)
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
				XmlNodeList myParams = myXmlDoc.GetElementsByTagName("搜索类型");
				this.m_ContourSearchType = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("搜索条数");
				this.m_ContourSearchCount = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("基准线");
				this.m_ContourBaseValue = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("搜索步长");
				this.m_ContourStepValue = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("最小值");
				this.m_ContourMinValue = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("最大值");
				this.m_ContourMaxValue = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("使用指定最小值");
				this.m_ContourUseSpecifiedMinValue = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("使用指定最大值");
				this.m_ContourUseSpecifiedMaxValue = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("线粗");
				this.m_ContourLineWidth = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("线型");
				this.m_ContourLineStyle = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("等值线颜色表");
				this.m_ContourwColorManager = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("等值线默认颜色");
				this.m_ContourDefaultColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("显示等值线");
				this.m_ContourShowContour = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示数值在等值线上");
				this.m_ContourShowContourText = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示单位在等值线上");
				this.m_ContourShowUnitInCurve = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示单位在色标上");
				this.m_ContourShowUnitInColorBar = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("文字间隔");
				this.m_ContourTextStep = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("文字大小");
				this.m_ContourTextHeight = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("文字加粗");
				this.m_ContourTextBold = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("文字旋转");
				this.m_ContourTextRotate = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("文字与曲线同色");
				this.m_ContourTextColor = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("样条插值");
				this.m_ContourWantSPL = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("伪彩色填充");
				this.m_ContourWantFill = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("伪彩色填充类型");
				this.m_ContourFillType = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("伪彩色填充颜色表");
				this.m_ContourFillwColorManager = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("伪彩色填充透明度");
				this.m_ContourFillAlpha = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示节点");
				this.m_ContourWantVertex = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示三角形");
				this.m_ContourWantTriangle = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示箭头");
				this.m_ContourShowArrow = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("最小颜色号");
				this.m_ContourMinColorID = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("最大颜色号");
				this.m_ContourMaxColorID = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("数值格式");
				this.m_ContourValueFormat = System.Convert.ToString(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("数值单位");
				this.m_ContourValueUnit = System.Convert.ToString(myParams[0].Attributes[0].Value);
				this.m_ContourLineColorManager = new ColorManager();
				this.m_ContourFillColorManager = new ColorManager();
				myParams = myXmlDoc.GetElementsByTagName("数值个数");
				int N = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				int fromBase = 10;
				for (int i = 1; i <= N; i++)
				{
					string Name = "数值" + System.Convert.ToString(i);
					myParams = myXmlDoc.GetElementsByTagName(Name);
					if (myParams != null)
					{
						if (i == 1 && myParams[0].Attributes["边界颜色"].Value.Substring(0, 2).ToUpper() == "FF")
						{
							fromBase = 16;
						}
						float ContourValue = System.Convert.ToSingle(myParams[0].Attributes["数值"].Value);
						string ContourText = System.Convert.ToString(myParams[0].Attributes["文字"].Value);
						System.Drawing.Color LineColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["边界颜色"].Value, fromBase));
						System.Drawing.Color FillColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["填充颜色"].Value, fromBase));
						int LineWidth = System.Convert.ToInt32(myParams[0].Attributes["线粗"].Value);
						System.Drawing.Drawing2D.DashStyle LineStyle = base.IntToDashStyle(System.Convert.ToInt32(myParams[0].Attributes["线型"].Value));
						ColorItem lineItem = new ColorItem(LineColor, ContourValue, ContourText);
						ColorItem fillItem = new ColorItem(FillColor, ContourValue, ContourText);
						lineItem.myLineWidth = LineWidth;
						lineItem.myDashStyle = LineStyle;
						fillItem.myLineWidth = LineWidth;
						fillItem.myDashStyle = LineStyle;
						this.m_ContourLineColorManager.m_ColorItems.Add(lineItem);
						this.m_ContourFillColorManager.m_ColorItems.Add(fillItem);
					}
				}
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
			this.m_LoadSccessed = false;
			bool result;
			try
			{
				XmlDocument myXmlDoc = new XmlDocument();
				myXmlDoc.LoadXml("<等值线参数></等值线参数>");
				XmlElement root = myXmlDoc.DocumentElement;
				myXmlDoc.InsertBefore(myXmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes"), root);
				myXmlDoc.InsertBefore(myXmlDoc.CreateComment("参数配置文件，请不要修改任何地方，否则程序可能无法启动！"), root);
				XmlNode node = myXmlDoc.CreateElement("搜索类型");
				XmlAttribute nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourSearchType.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("指定搜索数值");
				XmlNode subnode = myXmlDoc.CreateElement("数值个数");
				XmlAttribute subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_ContourLineColorManager.m_ColorItems.Count.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				for (int i = 0; i < this.m_ContourLineColorManager.m_ColorItems.Count; i++)
				{
					subnode = myXmlDoc.CreateElement("数值" + System.Convert.ToString(i + 1));
					subnodeAtt = myXmlDoc.CreateAttribute("数值");
					subnodeAtt.Value = this.m_ContourLineColorManager.m_ColorItems[i].myValue.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("文字");
					subnodeAtt.Value = this.m_ContourLineColorManager.m_ColorItems[i].myValueText;
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("边界颜色");
					subnodeAtt.Value = this.m_ContourLineColorManager.m_ColorItems[i].myColor.ToArgb().ToString("X8");
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("填充颜色");
					subnodeAtt.Value = this.m_ContourFillColorManager.m_ColorItems[i].myColor.ToArgb().ToString("X8");
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("线粗");
					subnodeAtt.Value = this.m_ContourLineColorManager.m_ColorItems[i].myLineWidth.ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("线型");
					subnodeAtt.Value = base.DashStyleToInt(this.m_ContourLineColorManager.m_ColorItems[i].myDashStyle).ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
				}
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("搜索条数");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourSearchCount.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("基准线");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourBaseValue.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("搜索步长");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourStepValue.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("最大值");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourMaxValue.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("最小值");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourMinValue.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("使用指定最小值");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourUseSpecifiedMinValue.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("使用指定最大值");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourUseSpecifiedMaxValue.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("线粗");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourLineWidth.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("线型");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourLineStyle.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("等值线颜色表");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourwColorManager.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("等值线默认颜色");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.ContourDefaultColor.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.ContourDefaultColor.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.ContourDefaultColor.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示等值线");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourShowContour.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示数值在等值线上");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourShowContourText.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示单位在等值线上");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourShowUnitInCurve.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示单位在色标上");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourShowUnitInColorBar.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("文字间隔");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourTextStep.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("文字大小");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourTextHeight.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("文字加粗");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourTextBold.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("文字旋转");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourTextRotate.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("文字与曲线同色");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourTextColor.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("样条插值");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourWantSPL.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("伪彩色填充");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourWantFill.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("伪彩色填充类型");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourFillType.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("伪彩色填充颜色表");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourFillwColorManager.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("伪彩色填充透明度");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourFillAlpha.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示节点");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourWantVertex.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示三角形");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourWantTriangle.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示箭头");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourShowArrow.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("最小颜色号");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourMinColorID.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("最大颜色号");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourMaxColorID.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("数值格式");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourValueFormat;
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("数值单位");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.m_ContourValueUnit;
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				myXmlDoc.Save(base.ParamFilePath);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("保存参数出错!\r\n" + ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				result = false;
				return result;
			}
			this.m_LoadSccessed = true;
			result = base.SaveParams();
			return result;
		}

		public ColorManager GetCurveColorManager(float MinValue, float MaxValue)
		{
			ColorManager result;
			if (this.m_ContourSearchType == 1)
			{
				for (int i = 0; i < this.m_ContourLineColorManager.m_ColorItems.Count; i++)
				{
					if (this.m_ContourLineColorManager.m_ColorItems[i].myValueText == "")
					{
						float thisVal = this.m_ContourLineColorManager.m_ColorItems[i].myValue;
						string ValueUnit = this.ContourShowUnitInCurve ? this.ContourValueUnit : "";
						this.m_ContourLineColorManager.m_ColorItems[i].myValueText = string.Format("{0:" + this.ContourValueFormat + "}{1}", thisVal, ValueUnit);
						this.m_ContourLineColorManager.m_ColorItems[i].myValueTextFormat = this.ContourValueFormat;
						this.m_ContourLineColorManager.m_ColorItems[i].myValueUnit = ValueUnit;
					}
				}
				result = this.m_ContourLineColorManager;
			}
			else if (this.m_ContourSearchType == 2)
			{
				ColorManager cm = new ColorManager();
				cm.CreateColorItems(this.ContourUseSpcifiedMinValue ? this.ContourMinValue : MinValue, this.ContourUseSpcifiedMaxValue ? this.ContourMaxValue : MaxValue, this.ContourStepValue, this.ContourBaseValue, this.ContourwColorManager, this.ContourDefaultColor, this.ContourMinColorID, this.ContourMaxColorID, this.ContourTextStep, this.ContourValueFormat, this.ContourShowUnitInCurve ? this.ContourValueUnit : "");
				for (int i = 0; i < cm.m_ColorItems.Count; i++)
				{
					cm.m_ColorItems[i].myDashStyle = this.ContourLineStyle;
					cm.m_ColorItems[i].myLineWidth = this.ContourLineWidth;
				}
				result = cm;
			}
			else if (this.m_ContourSearchType == 3)
			{
				ColorManager cm = new ColorManager();
				cm.CreateColorItems(MinValue, MaxValue, (MaxValue - MinValue) / (float)(this.m_ContourSearchCount - 1), MinValue, this.ContourwColorManager, this.ContourDefaultColor, this.ContourMinColorID, this.ContourMaxColorID, this.ContourTextStep, this.ContourValueFormat, this.ContourShowUnitInCurve ? this.ContourValueUnit : "");
				for (int i = 0; i < cm.m_ColorItems.Count; i++)
				{
					cm.m_ColorItems[i].myDashStyle = this.ContourLineStyle;
					cm.m_ColorItems[i].myLineWidth = this.ContourLineWidth;
				}
				result = cm;
			}
			else
			{
				result = null;
			}
			return result;
		}

		public ColorManager GetFillColorManager(float MinValue, float MaxValue)
		{
			ColorManager result;
			if (this.m_ContourSearchType == 1)
			{
				for (int i = 0; i < this.m_ContourFillColorManager.m_ColorItems.Count; i++)
				{
					if (this.m_ContourFillColorManager.m_ColorItems[i].myValueText == "")
					{
						float thisVal = this.m_ContourFillColorManager.m_ColorItems[i].myValue;
						string ValueUnit = this.ContourShowUnitInColorBar ? this.ContourValueUnit : "";
						this.m_ContourFillColorManager.m_ColorItems[i].myValueText = string.Format("{0:" + this.ContourValueFormat + "}{1}", thisVal, ValueUnit);
						this.m_ContourFillColorManager.m_ColorItems[i].myValueTextFormat = this.ContourValueFormat;
						this.m_ContourFillColorManager.m_ColorItems[i].myValueUnit = ValueUnit;
					}
				}
				result = this.m_ContourFillColorManager;
			}
			else if (this.m_ContourSearchType == 2)
			{
				ColorManager cm = new ColorManager();
				cm.CreateColorItems(this.ContourUseSpcifiedMinValue ? this.ContourMinValue : MinValue, this.ContourUseSpcifiedMaxValue ? this.ContourMaxValue : MaxValue, this.ContourStepValue, this.ContourBaseValue, this.ContourFillwColorManager, this.ContourDefaultColor, this.ContourMinColorID, this.ContourMaxColorID, this.ContourTextStep, this.ContourValueFormat, this.ContourShowUnitInColorBar ? this.ContourValueUnit : "");
				for (int i = 0; i < cm.m_ColorItems.Count; i++)
				{
					cm.m_ColorItems[i].myDashStyle = this.ContourLineStyle;
					cm.m_ColorItems[i].myLineWidth = this.ContourLineWidth;
				}
				result = cm;
			}
			else if (this.m_ContourSearchType == 3)
			{
				ColorManager cm = new ColorManager();
				cm.CreateColorItems(MinValue, MaxValue, (MaxValue - MinValue) / (float)(this.m_ContourSearchCount - 1), MinValue, this.ContourFillwColorManager, this.ContourDefaultColor, this.ContourMinColorID, this.ContourMaxColorID, this.ContourTextStep, this.ContourValueFormat, this.ContourShowUnitInColorBar ? this.ContourValueUnit : "");
				for (int i = 0; i < cm.m_ColorItems.Count; i++)
				{
					cm.m_ColorItems[i].myDashStyle = this.ContourLineStyle;
					cm.m_ColorItems[i].myLineWidth = this.ContourLineWidth;
				}
				result = cm;
			}
			else
			{
				result = null;
			}
			return result;
		}
	}
}
