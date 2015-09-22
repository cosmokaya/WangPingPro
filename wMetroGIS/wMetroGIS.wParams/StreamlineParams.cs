using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace wMetroGIS.wParams
{
	public class StreamlineParams : BaseParams
	{
		private System.Drawing.Color m_StreamlineColor;

		private int m_StreamlineWidth;

		private float m_StreamlineArrowAngle;

		private int m_StreamlineDensity;

		public System.Drawing.Color StreamlineColor
		{
			get
			{
				return this.m_StreamlineColor;
			}
			set
			{
				this.m_StreamlineColor = value;
			}
		}

		public int StreamlineWidth
		{
			get
			{
				return this.m_StreamlineWidth;
			}
			set
			{
				this.m_StreamlineWidth = value;
			}
		}

		public float StreamlineArrowAngle
		{
			get
			{
				return this.m_StreamlineArrowAngle;
			}
			set
			{
				this.m_StreamlineArrowAngle = value;
			}
		}

		public int StreamlineDensity
		{
			get
			{
				return this.m_StreamlineDensity;
			}
			set
			{
				this.m_StreamlineDensity = value;
			}
		}

		public StreamlineParams()
		{
			base.ParamFilePath = System.Windows.Forms.Application.StartupPath + "\\AppData\\Default.lst";
			this.LoadParams();
		}

		public StreamlineParams(string paramFilePath)
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
				XmlNodeList myParams = myXmlDoc.GetElementsByTagName("流线粗细");
				this.m_StreamlineWidth = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("箭头张角");
				this.m_StreamlineArrowAngle = System.Convert.ToSingle(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("流线颜色");
				this.m_StreamlineColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("流线密度");
				this.m_StreamlineDensity = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
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
				XmlNode node = myXmlDoc.CreateElement("流线参数");
				XmlNode subnode = myXmlDoc.CreateElement("流线粗细");
				XmlAttribute subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_StreamlineWidth.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("箭头张角");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_StreamlineArrowAngle.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("流线颜色");
				subnodeAtt = myXmlDoc.CreateAttribute("R");
				subnodeAtt.Value = this.m_StreamlineColor.R.ToString();
				subnode.Attributes.Append(subnodeAtt);
				subnodeAtt = myXmlDoc.CreateAttribute("G");
				subnodeAtt.Value = this.m_StreamlineColor.G.ToString();
				subnode.Attributes.Append(subnodeAtt);
				subnodeAtt = myXmlDoc.CreateAttribute("B");
				subnodeAtt.Value = this.m_StreamlineColor.B.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("流线密度");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_StreamlineDensity.ToString();
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
			return result;
		}
	}
}
