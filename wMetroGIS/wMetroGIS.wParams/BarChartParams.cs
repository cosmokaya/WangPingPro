using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace wMetroGIS.wParams
{
	public class BarChartParams : BaseParams
	{
		public string TitleFontFamily;

		public System.Drawing.Color TitleFontColor;

		public int TitleFontSize;

		public string AxisFontFamily;

		public System.Drawing.Color AxisFontColor;

		public int AxisFontSize;

		public System.Drawing.Color PaneColor1;

		public System.Drawing.Color PaneColor2;

		public float PaneColorAngle;

		public System.Drawing.Color ChartColor1;

		public System.Drawing.Color ChartColor2;

		public float ChartColorAngle;

		public System.Drawing.Color BarColor1;

		public System.Drawing.Color BarColor2;

		public float BarColorAngle;

		public bool ShowBarValue;

		public bool BarValueIsCenter;

		public System.Drawing.Color CurveColor;

		public int CurveWidth;

		public System.Drawing.Color GridColor;

		public bool ShowMajorGridX;

		public bool ShowMajorGridY;

		public bool ShowMinorGridX;

		public bool ShowMinorGridY;

		public BarChartParams()
		{
			base.ParamFilePath = System.Windows.Forms.Application.StartupPath + "\\AppData\\Default.bst";
			this.LoadParams();
		}

		public BarChartParams(string paramFilePath)
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
				XmlNodeList myParams = myXmlDoc.GetElementsByTagName("标题字体");
				this.TitleFontFamily = System.Convert.ToString(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("标题字体颜色");
				this.TitleFontColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("标题字号");
				this.TitleFontSize = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("坐标轴字体");
				this.AxisFontFamily = System.Convert.ToString(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("坐标轴字体颜色");
				this.AxisFontColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("坐标轴字号");
				this.AxisFontSize = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("背景颜色1");
				this.PaneColor1 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("背景颜色2");
				this.PaneColor2 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("背景颜色变化角度");
				this.PaneColorAngle = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("图表区域颜色1");
				this.ChartColor1 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("图表区域颜色2");
				this.ChartColor2 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("图表区域颜色变化角度");
				this.ChartColorAngle = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("柱状图颜色1");
				this.BarColor1 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("柱状图颜色2");
				this.BarColor2 = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("柱状图颜色变化角度");
				this.BarColorAngle = System.Convert.ToSingle(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示数值");
				this.ShowBarValue = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("数值位置");
				this.BarValueIsCenter = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("曲线颜色");
				this.CurveColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("曲线粗细");
				this.CurveWidth = System.Convert.ToInt32(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("网络线颜色");
				this.GridColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("显示X轴主网格线");
				this.ShowMajorGridX = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示X轴辅网格线");
				this.ShowMinorGridX = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示Y轴主网格线");
				this.ShowMajorGridY = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
				myParams = myXmlDoc.GetElementsByTagName("显示Y轴辅网格线");
				this.ShowMinorGridY = System.Convert.ToBoolean(myParams[0].Attributes[0].Value);
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("载入参数出错!\r\n" + ex.Message, "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_LoadSccessed = false;
				result = false;
				return result;
			}
			this.m_LoadSccessed = true;
			result = true;
			return result;
		}

		public override bool SaveParams()
		{
			bool result;
			try
			{
				XmlDocument myXmlDoc = new XmlDocument();
				myXmlDoc.LoadXml("<柱状图显示参数></柱状图显示参数>");
				XmlElement root = myXmlDoc.DocumentElement;
				myXmlDoc.InsertBefore(myXmlDoc.CreateXmlDeclaration("1.0", "UTF-8", "yes"), root);
				myXmlDoc.InsertBefore(myXmlDoc.CreateComment("参数配置文件，请不要修改任何地方，否则程序可能无法启动！"), root);
				XmlNode node = myXmlDoc.CreateElement("标题字体");
				XmlAttribute nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.TitleFontFamily.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("标题字体颜色");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.TitleFontColor.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.TitleFontColor.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.TitleFontColor.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("标题字号");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.TitleFontSize.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("坐标轴字体");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.AxisFontFamily.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("坐标轴字体颜色");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.AxisFontColor.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.AxisFontColor.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.AxisFontColor.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("坐标轴字号");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.AxisFontSize.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("背景颜色1");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.PaneColor1.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.PaneColor1.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.PaneColor1.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("背景颜色2");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.PaneColor2.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.PaneColor2.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.PaneColor2.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("背景颜色变化角度");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.PaneColorAngle.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("图表区域颜色1");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.ChartColor1.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.ChartColor1.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.ChartColor1.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("图表区域颜色2");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.ChartColor2.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.ChartColor2.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.ChartColor2.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("图表区域颜色变化角度");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.ChartColorAngle.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("柱状图颜色1");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.BarColor1.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.BarColor1.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.BarColor1.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("柱状图颜色2");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.BarColor2.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.BarColor2.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.BarColor2.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("柱状图颜色变化角度");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.BarColorAngle.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示数值");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.ShowBarValue.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("数值位置");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.BarValueIsCenter.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("曲线颜色");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.CurveColor.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.CurveColor.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.CurveColor.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("曲线粗细");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.CurveWidth.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("网络线颜色");
				nodeAtt = myXmlDoc.CreateAttribute("R");
				nodeAtt.Value = this.GridColor.R.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("G");
				nodeAtt.Value = this.GridColor.G.ToString();
				node.Attributes.Append(nodeAtt);
				nodeAtt = myXmlDoc.CreateAttribute("B");
				nodeAtt.Value = this.GridColor.B.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示X轴主网格线");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.ShowMajorGridX.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示X轴辅网格线");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.ShowMinorGridX.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示Y轴主网格线");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.ShowMajorGridY.ToString();
				node.Attributes.Append(nodeAtt);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("显示Y轴辅网格线");
				nodeAtt = myXmlDoc.CreateAttribute("value");
				nodeAtt.Value = this.ShowMinorGridY.ToString();
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
			result = base.SaveParams();
			return result;
		}
	}
}
