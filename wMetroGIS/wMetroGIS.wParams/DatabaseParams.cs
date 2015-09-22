using System;
using System.Windows.Forms;
using wMetroGIS.wDataReader;

namespace wMetroGIS.wParams
{
	public class DatabaseParams : BaseParams
	{
		public string m_DatabaseServer = "";

		public string m_DatabaseUserName = "";

		public string m_DatabasePassword = "";

		public string m_DatabaseName = "";

		public DatabaseParams()
		{
			base.ParamFilePath = System.Windows.Forms.Application.StartupPath + "\\AppData\\Default.dst";
			this.LoadParams();
		}

		public DatabaseParams(string paramFilePath)
		{
			base.ParamFilePath = paramFilePath;
			this.LoadParams();
		}

		public override bool LoadParams()
		{
			XMLDataReader dataReader = new XMLDataReader();
			bool result;
			if (!dataReader.LoadXMLDoc(this.m_ParamFilePath))
			{
				result = false;
			}
			else
			{
				this.m_DatabaseServer = dataReader.GetXMLNodeValue("服务器");
				this.m_DatabaseUserName = dataReader.GetXMLNodeValue("用户名");
				this.m_DatabasePassword = EncryptDataReader.Decrypt(dataReader.GetXMLNodeValue("密码"));
				this.m_DatabaseName = dataReader.GetXMLNodeValue("数据库名");
				this.m_LoadSccessed = true;
				result = true;
			}
			return result;
		}

		public override bool SaveParams()
		{
			XMLDataReader dataReader = new XMLDataReader();
			dataReader.InitXMLDoc("数据库连接参数配置");
			dataReader.AddXMLNode("服务器", this.m_DatabaseServer, null);
			dataReader.AddXMLNode("用户名", this.m_DatabaseUserName, null);
			dataReader.AddXMLNode("密码", EncryptDataReader.Encrypt(this.m_DatabasePassword), null);
			dataReader.AddXMLNode("数据库名", this.m_DatabaseName, null);
			return dataReader.SaveXMLDoc(this.m_ParamFilePath);
		}
	}
}
