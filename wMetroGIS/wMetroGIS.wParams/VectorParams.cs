using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;
using wMetroGIS.wColorManager;

namespace wMetroGIS.wParams
{
	public class VectorParams : BaseParams
	{
		public ColorManager m_VectorLevelColorManager1;

		public ColorManager m_VectorLevelColorManager2;

		private int m_VectorWidth;

		private float m_VectorAngle;

		private bool m_VectorUseDefaultColor;

		private System.Drawing.Color m_VectorDeaultColor;

		private int m_VectorLengthType;

		private float m_VectorDefaultLength;

		private int m_VectorArrowType;

		public int VectorWidth
		{
			get
			{
				return this.m_VectorWidth;
			}
			set
			{
				this.m_VectorWidth = value;
			}
		}

		public float VectorAngle
		{
			get
			{
				return this.m_VectorAngle;
			}
			set
			{
				this.m_VectorAngle = value;
			}
		}

		public bool VectorUseDefaultColor
		{
			get
			{
				return this.m_VectorUseDefaultColor;
			}
			set
			{
				this.m_VectorUseDefaultColor = value;
			}
		}

		public System.Drawing.Color VectorDefaultColor
		{
			get
			{
				return this.m_VectorDeaultColor;
			}
			set
			{
				this.m_VectorDeaultColor = value;
			}
		}

		public int VectorLengthType
		{
			get
			{
				return this.m_VectorLengthType;
			}
			set
			{
				this.m_VectorLengthType = value;
			}
		}

		public float VectorDefaultLength
		{
			get
			{
				return this.m_VectorDefaultLength;
			}
			set
			{
				this.m_VectorDefaultLength = value;
			}
		}

		public int VectorArrowType
		{
			get
			{
				return this.m_VectorArrowType;
			}
			set
			{
				this.m_VectorArrowType = value;
			}
		}

		public VectorParams()
		{
			base.ParamFilePath = System.Windows.Forms.Application.StartupPath + "\\AppData\\Default.vst";
			this.LoadParams();
		}

		public VectorParams(string paramFilePath)
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
				XmlNodeList myParams = myXmlDoc.GetElementsByTagName("箭头类型");
				this.m_VectorArrowType = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("箭头粗细");
				this.m_VectorWidth = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("箭头张角");
				this.m_VectorAngle = System.Convert.ToSingle(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("使用默认颜色");
				this.m_VectorUseDefaultColor = System.Convert.ToBoolean(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("默认颜色");
				this.m_VectorDeaultColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["R"].Value), System.Convert.ToInt32(myParams[0].Attributes["G"].Value), System.Convert.ToInt32(myParams[0].Attributes["B"].Value));
				myParams = myXmlDoc.GetElementsByTagName("长度类型");
				this.m_VectorLengthType = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				myParams = myXmlDoc.GetElementsByTagName("默认长度");
				this.m_VectorDefaultLength = System.Convert.ToSingle(myParams[0].Attributes["value"].Value);
				this.m_VectorLevelColorManager2 = new ColorManager();
				this.m_VectorLevelColorManager1 = new ColorManager();
				myParams = myXmlDoc.GetElementsByTagName("等级个数");
				int N = System.Convert.ToInt32(myParams[0].Attributes["value"].Value);
				for (int i = 1; i <= N; i++)
				{
					string Name = "等级" + System.Convert.ToString(i);
					myParams = myXmlDoc.GetElementsByTagName(Name);
					string RegionName = System.Convert.ToString(myParams[0].Attributes["名称"].Value);
					float MinValue = System.Convert.ToSingle(myParams[0].Attributes["最小值"].Value);
					float MaxValue = System.Convert.ToSingle(myParams[0].Attributes["最大值"].Value);
					System.Drawing.Color LineColor = System.Drawing.Color.FromArgb(System.Convert.ToInt32(myParams[0].Attributes["颜色"].Value));
					ColorItem lineItem = new ColorItem(LineColor, MinValue, RegionName);
					ColorItem fillItem = new ColorItem(LineColor, MaxValue, RegionName);
					this.m_VectorLevelColorManager1.m_ColorItems.Add(lineItem);
					this.m_VectorLevelColorManager2.m_ColorItems.Add(fillItem);
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
				XmlNode node = myXmlDoc.CreateElement("矢量箭头参数");
				XmlNode subnode = myXmlDoc.CreateElement("箭头类型");
				XmlAttribute subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_VectorArrowType.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("箭头粗细");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_VectorWidth.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("箭头张角");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_VectorAngle.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("使用默认颜色");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_VectorUseDefaultColor.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("默认颜色");
				subnodeAtt = myXmlDoc.CreateAttribute("R");
				subnodeAtt.Value = this.m_VectorDeaultColor.R.ToString();
				subnode.Attributes.Append(subnodeAtt);
				subnodeAtt = myXmlDoc.CreateAttribute("G");
				subnodeAtt.Value = this.m_VectorDeaultColor.G.ToString();
				subnode.Attributes.Append(subnodeAtt);
				subnodeAtt = myXmlDoc.CreateAttribute("B");
				subnodeAtt.Value = this.m_VectorDeaultColor.B.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("长度类型");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_VectorLengthType.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				subnode = myXmlDoc.CreateElement("默认长度");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_VectorDefaultLength.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				root.AppendChild(node);
				node = myXmlDoc.CreateElement("等级划分参数");
				subnode = myXmlDoc.CreateElement("等级个数");
				subnodeAtt = myXmlDoc.CreateAttribute("value");
				subnodeAtt.Value = this.m_VectorLevelColorManager1.m_ColorItems.Count.ToString();
				subnode.Attributes.Append(subnodeAtt);
				node.AppendChild(subnode);
				for (int i = 0; i < this.m_VectorLevelColorManager1.m_ColorItems.Count; i++)
				{
					subnode = myXmlDoc.CreateElement("等级" + System.Convert.ToString(i + 1));
					subnodeAtt = myXmlDoc.CreateAttribute("名称");
					subnodeAtt.Value = this.m_VectorLevelColorManager1.m_ColorItems[i].myValueText;
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("最小值");
					subnodeAtt.Value = this.m_VectorLevelColorManager1.m_ColorItems[i].myValue.ToString("F2");
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("最大值");
					subnodeAtt.Value = this.m_VectorLevelColorManager2.m_ColorItems[i].myValue.ToString("F2");
					subnode.Attributes.Append(subnodeAtt);
					subnodeAtt = myXmlDoc.CreateAttribute("颜色");
					subnodeAtt.Value = this.m_VectorLevelColorManager1.m_ColorItems[i].myColor.ToArgb().ToString();
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

		public static void DrawArrow(System.Drawing.Graphics g, System.Drawing.Pen ArrowPen, int ArrowLen, float ArrowAng, int X1, int Y1, int X2, int Y2)
		{
			g.DrawLine(ArrowPen, X1, Y1, X2, Y2);
			double dir = System.Math.Atan2((double)(Y2 - Y1), (double)(X2 - X1));
			g.DrawLine(ArrowPen, (float)X2, (float)Y2, (float)((double)X2 + (double)(ArrowLen / 2) * System.Math.Cos(dir + (double)ArrowAng)), (float)((double)Y2 + (double)(ArrowLen / 2) * System.Math.Sin(dir + (double)ArrowAng)));
			g.DrawLine(ArrowPen, (float)X2, (float)Y2, (float)((double)X2 + (double)(ArrowLen / 2) * System.Math.Cos(dir - (double)ArrowAng)), (float)((double)Y2 + (double)(ArrowLen / 2) * System.Math.Sin(dir - (double)ArrowAng)));
		}

		public static void DrawWind(System.Drawing.Graphics g, System.Drawing.Pen ArrowPen, int ArrowLen, int fs, float fx, int X0, int Y0)
		{
			try
			{
				g.DrawEllipse(ArrowPen, X0 - 1, Y0 - 1, 2, 2);
				fx = (float)((double)fx * 3.1415926535897931 / 180.0);
				System.Drawing.Point yd = new System.Drawing.Point(X0, Y0);
				float xdis = (float)((double)(1f * (float)ArrowLen) * System.Math.Sin((double)fx));
				float ydis = -(float)((double)(1f * (float)ArrowLen) * System.Math.Cos((double)fx));
				System.Drawing.Point fxd = new System.Drawing.Point(yd.X + (int)xdis, yd.Y + (int)ydis);
				g.DrawLine(ArrowPen, yd, fxd);
				System.Drawing.Point[] pointz = new System.Drawing.Point[8];
				for (int i = 0; i < 8; i++)
				{
					pointz[i] = new System.Drawing.Point(fxd.X - (int)(xdis * (float)i / 8f), fxd.Y - (int)(ydis * (float)i / 8f));
				}
				int xdis2 = (int)((double)(0.4f * (float)ArrowLen) * System.Math.Sin(1.5707963267948966 + (double)fx));
				int ydis2 = -(int)((double)(0.4f * (float)ArrowLen) * System.Math.Cos(1.5707963267948966 + (double)fx));
				int num40 = 0;
				int num41 = 0;
				int num42 = 0;
				int num43 = 0;
				while (fs > 0)
				{
					if (fs % 2 != 0)
					{
						fs++;
					}
					if (fs >= 40)
					{
						num40++;
						fs -= 40;
					}
					else if (fs >= 20)
					{
						num41++;
						fs -= 20;
					}
					else if (fs >= 4)
					{
						num42++;
						fs -= 4;
					}
					else if (fs >= 2)
					{
						num43++;
						fs -= 2;
					}
				}
				int lastnum = 0;
				System.Drawing.Point[] tem = new System.Drawing.Point[3];
				for (int i = 1; i <= num40; i++)
				{
					tem[0] = pointz[lastnum];
					tem[1] = new System.Drawing.Point(pointz[lastnum + 1].X + xdis2, pointz[lastnum + 1].Y + ydis2);
					tem[2] = pointz[lastnum + 2];
					g.DrawPolygon(ArrowPen, tem);
					lastnum += 2;
				}
				for (int i = 1; i <= num41; i++)
				{
					tem[0] = pointz[lastnum];
					tem[1] = new System.Drawing.Point(pointz[lastnum + 1].X + xdis2, pointz[lastnum + 1].Y + ydis2);
					tem[2] = pointz[lastnum + 2];
					g.DrawLine(ArrowPen, tem[0], tem[1]);
					g.DrawLine(ArrowPen, tem[1], tem[2]);
					lastnum += 2;
				}
				for (int i = 1; i <= num42; i++)
				{
					tem[0] = pointz[lastnum];
					tem[1] = new System.Drawing.Point(pointz[lastnum].X + xdis2, pointz[lastnum].Y + ydis2);
					g.DrawLine(ArrowPen, tem[0], tem[1]);
					lastnum++;
				}
				for (int i = 1; i <= num43; i++)
				{
					tem[0] = pointz[lastnum];
					tem[1] = new System.Drawing.Point(pointz[lastnum].X + xdis2 / 2, pointz[lastnum].Y + ydis2 / 2);
					g.DrawLine(ArrowPen, tem[0], tem[1]);
					lastnum++;
				}
			}
			catch
			{
			}
		}
	}
}
