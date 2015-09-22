using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Xml;
using wMetroGIS.wColorManager;

namespace wMetroGIS.wParams
{
	public class RegionParams : BaseParams
	{
		public ColorManager m_RegionLineColorManager;

		public ColorManager m_RegionFillColorManager;

		private int m_RegionLineWidth;

		private int m_RegionLineStyle;

		private bool m_RegionWantFill;

		private int m_RegionFillAlpha;

		private bool m_RegionWantVertex;

		private bool m_RegionWantTriangle;

		private bool m_RegionShowRegionText;

		private bool m_RegionWantSPL;

		public int RegionLineWidth
		{
			get
			{
				return this.m_RegionLineWidth;
			}
			set
			{
				this.m_RegionLineWidth = value;
			}
		}

		public System.Drawing.Drawing2D.DashStyle RegionLineStyle
		{
			get
			{
				return base.IntToDashStyle(this.m_RegionLineStyle);
			}
			set
			{
				this.m_RegionLineStyle = base.DashStyleToInt(value);
			}
		}

		public bool RegionWantFill
		{
			get
			{
				return this.m_RegionWantFill;
			}
			set
			{
				this.m_RegionWantFill = value;
			}
		}

		public int RegionFillAlpha
		{
			get
			{
				return this.m_RegionFillAlpha;
			}
			set
			{
				this.m_RegionFillAlpha = value;
			}
		}

		public bool RegionWantVertex
		{
			get
			{
				return this.m_RegionWantVertex;
			}
			set
			{
				this.m_RegionWantVertex = value;
			}
		}

		public bool RegionWantTriangle
		{
			get
			{
				return this.m_RegionWantTriangle;
			}
			set
			{
				this.m_RegionWantTriangle = value;
			}
		}

		public bool RegionShowRegionText
		{
			get
			{
				return this.m_RegionShowRegionText;
			}
			set
			{
				this.m_RegionShowRegionText = value;
			}
		}

		public bool RegionWantSPL
		{
			get
			{
				return this.m_RegionWantSPL;
			}
			set
			{
				this.m_RegionWantSPL = value;
			}
		}

		public RegionParams()
		{
			base.ParamFilePath = System.Windows.Forms.Application.StartupPath + "\\AppData\\Default.rst";
			this.LoadParams();
		}

		public RegionParams(string paramFilePath)
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
				XmlNodeList myParams = myXmlDoc.GetElementsByTagName("边线粗细");
				this.m_RegionLineWidth = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("边线类型");
				this.m_RegionLineStyle = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("填充区域");
				this.m_RegionWantFill = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("区域透明度");
				this.m_RegionFillAlpha = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示节点");
				this.m_RegionWantVertex = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示三角形");
				this.m_RegionWantTriangle = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示文字");
				this.m_RegionShowRegionText = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("样条插值");
				this.m_RegionWantSPL = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				this.m_RegionFillColorManager = new ColorManager();
				this.m_RegionLineColorManager = new ColorManager();
				myParams = myXmlDoc.GetElementsByTagName("区划个数");
				int N = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				for (int i = 1; i <= N; i++)
				{
					string Name = "区域" + System.Convert.ToString(i);
					myParams = myXmlDoc.GetElementsByTagName(Name);
					string RegionName = System.Convert.ToString(myParams[0].Attributes["名称"].Value);
					float MinValue = System.Convert.ToSingle(myParams[0].Attributes["最小值"].Value);
					float MaxValue = System.Convert.ToSingle(myParams[0].Attributes["最大值"].Value);
					System.Drawing.Color LineColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["边界颜色"].Value));
					System.Drawing.Color FillColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["填充颜色"].Value));
					ColorItem lineItem = new ColorItem(LineColor, MinValue, RegionName);
					ColorItem fillItem = new ColorItem(FillColor, MaxValue, RegionName);
					this.m_RegionLineColorManager.m_ColorItems.Add(lineItem);
					this.m_RegionFillColorManager.m_ColorItems.Add(fillItem);
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
			bool result;
			try
			{
				XmlDocument myXmlDoc = new XmlDocument();
				myXmlDoc.LoadXml("<参数></参数>");
				XmlElement root = myXmlDoc.DocumentElement;
				myXmlDoc.InsertBefore(myXmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes"), root);
				myXmlDoc.InsertBefore(myXmlDoc.CreateComment("参数配置文件，请不要修改任何地方，否则程序可能无法启动！"), root);
				XmlNode node = myXmlDoc.CreateElement("边界线参数");
				XmlNode subnode = myXmlDoc.CreateElement("边线粗细");
				XmlAttribute subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_RegionLineWidth.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("边线类型");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_RegionLineStyle.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("区域填充参数");
				subnode = myXmlDoc.CreateElement("填充区域");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_RegionWantFill.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("区域透明度");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_RegionFillAlpha.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("其它参数");
				subnode = myXmlDoc.CreateElement("显示节点");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_RegionWantVertex.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("显示三角形");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_RegionWantTriangle.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("显示文字");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_RegionShowRegionText.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("样条插值");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_RegionWantSPL.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("区划参数");
				subnode = myXmlDoc.CreateElement("区划个数");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_RegionLineColorManager.m_ColorItems.Count.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				for (int i = 0; i < this.m_RegionLineColorManager.m_ColorItems.Count; i++)
				{
					subnode = myXmlDoc.CreateElement("区域" + System.Convert.ToString(i + 1));
					subnodeAtt = myXmlDoc.CreateAttribute("名称");
					subnodeAtt.Value = this.m_RegionLineColorManager.m_ColorItems[i].myValueText;
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("最小值");
					subnodeAtt.Value = this.m_RegionLineColorManager.m_ColorItems[i].myValue.ToString("F2");
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("最大值");
					subnodeAtt.Value = this.m_RegionFillColorManager.m_ColorItems[i].myValue.ToString("F2");
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("边界颜色");
					subnodeAtt.Value = this.m_RegionLineColorManager.m_ColorItems[i].myColor.ToArgb().ToString();
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("填充颜色");
					subnodeAtt.Value = this.m_RegionFillColorManager.m_ColorItems[i].myColor.ToArgb().ToString();
					subnode.Attributes.Append(subnodeAtt);
					node.AppendChild(subnode);
				}
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
			return result;
		}
	}
}
