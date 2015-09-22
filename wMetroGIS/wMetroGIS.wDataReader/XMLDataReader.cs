using System;
using System.Xml;

namespace wMetroGIS.wDataReader
{
	public class XMLDataReader
	{
		public XmlDocument m_XmlDoc = new XmlDocument();

		private XmlElement root = null;

		public bool LoadXMLDoc(string filePath)
		{
			bool result;
			try
			{
				this.m_XmlDoc = new XmlDocument();
				this.m_XmlDoc.Load(filePath);
			}
			catch
			{
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		public bool SaveXMLDoc(string filePath)
		{
			bool result;
			try
			{
				this.m_XmlDoc.Save(filePath);
			}
			catch
			{
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		public XmlElement InitXMLDoc(string title)
		{
			this.m_XmlDoc = new XmlDocument();
			this.m_XmlDoc.LoadXml(string.Format("<{0}></{0}>", title));
			this.root = this.m_XmlDoc.DocumentElement;
			this.m_XmlDoc.InsertBefore(this.m_XmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes"), this.root);
			this.m_XmlDoc.InsertBefore(this.m_XmlDoc.CreateComment("参数配置文件，请不要修改任何地方，否则程序可能无法启动！"), this.root);
			return this.root;
		}

		public XmlNode AddXMLNode(string nodeName, string nodeValue, XmlNode parentNode)
		{
			XmlNode result;
			if (nodeName == null || nodeName == "")
			{
				result = null;
			}
			else
			{
				XmlNode node = this.m_XmlDoc.CreateElement(nodeName);
				if (nodeValue != null && nodeValue != "")
				{
					XmlAttribute nodeAtt = this.m_XmlDoc.CreateAttribute("value");
					nodeAtt.Value = nodeValue;
					node.Attributes.Append(nodeAtt);
				}
				if (parentNode == null)
				{
					this.root.AppendChild(node);
				}
				else
				{
					parentNode.AppendChild(node);
				}
				result = node;
			}
			return result;
		}

		public XmlNode AddXMLNode(string nodeName, string[] nodeValueNames, string[] nodeValues, XmlNode parentNode)
		{
			XmlNode result;
			if (nodeName == null || nodeName == "")
			{
				result = null;
			}
			else
			{
				XmlNode node = this.m_XmlDoc.CreateElement(nodeName);
				if (nodeValueNames != null && nodeValues != null && nodeValueNames.Length == nodeValues.Length)
				{
					for (int i = 0; i < nodeValueNames.Length; i++)
					{
						if (nodeValueNames[i] != null && nodeValueNames[i] != "" && nodeValues[i] != null && nodeValues[i] != "")
						{
							XmlAttribute nodeAtt = this.m_XmlDoc.CreateAttribute(nodeValueNames[i]);
							nodeAtt.Value = nodeValues[i];
							node.Attributes.Append(nodeAtt);
						}
					}
				}
				if (parentNode == null)
				{
					this.root.AppendChild(node);
				}
				else
				{
					parentNode.AppendChild(node);
				}
				result = node;
			}
			return result;
		}

		public XmlNodeList GetXMLNodeList(string nodeName)
		{
			XmlNodeList result;
			if (nodeName == null || nodeName == "")
			{
				result = null;
			}
			else
			{
				XmlNodeList myParams = this.m_XmlDoc.GetElementsByTagName(nodeName);
				result = myParams;
			}
			return result;
		}

		public string GetXMLNodeValue(string nodeName)
		{
			XmlNodeList nodeList = this.GetXMLNodeList(nodeName);
			return this.GetXMLNodeValue(nodeList);
		}

		public string GetXMLNodeValue(XmlNodeList node)
		{
			string result;
			if (node == null || node.Count == 0 || node[0].Attributes.Count == 0)
			{
				result = "";
			}
			else
			{
				result = node[0].Attributes[0].Value;
			}
			return result;
		}

		public string GetXMLNodeValue(XmlNodeList node, string attributeName)
		{
			string result;
			if (node == null || node.Count == 0 || node[0].Attributes.Count == 0)
			{
				result = "";
			}
			else
			{
				try
				{
					result = node[0].Attributes[attributeName].Value;
				}
				catch
				{
					result = "";
				}
			}
			return result;
		}
	}
}
