using System;
using System.Data;
using System.Data.OracleClient;
using System.Windows.Forms;
using wMetroGIS.wParams;

namespace wMetroGIS.wDBConnecter
{
	public class OracleConnect
	{
		private OracleConnection m_DataConn;

		private string m_UserID;

		private string m_Password;

		private string m_Database;

		private string m_Server;

		public OracleConnect()
		{
			this.m_Server = "(local)";
			this.m_UserID = "sa";
			this.m_Password = "sa";
			this.m_Database = "master";
		}

		public OracleConnect(DatabaseParams databaseParams)
		{
			this.SetConnectParams(databaseParams);
		}

		public OracleConnect(string Server, string UserID, string Password, string Database)
		{
			this.SetConnectParams(Server, UserID, Password, Database);
		}

		public void SetConnectParams(DatabaseParams databaseParams)
		{
			this.SetConnectParams(databaseParams.m_DatabaseServer, databaseParams.m_DatabaseUserName, databaseParams.m_DatabasePassword, databaseParams.m_DatabaseName);
		}

		public void SetConnectParams(string Server, string UserID, string Password, string Database)
		{
			this.m_Server = Server;
			this.m_UserID = UserID;
			this.m_Password = Password;
			this.m_Database = Database;
		}

		public bool InitConn()
		{
			bool result;
			try
			{
				this.m_DataConn = new OracleConnection(string.Concat(new string[]
				{
					"Data Source=",
					this.m_Server,
					";User ID=",
					this.m_UserID,
					";Password=",
					this.m_Password,
					";Integrated Security=no"
				}));
				this.m_DataConn.Open();
			}
			catch (System.Exception ex)
			{
				System.Windows.Forms.MessageBox.Show("数据库连接失败！\r\n" + ex.Message);
				result = false;
				return result;
			}
			result = true;
			return result;
		}

		public bool ExitConn()
		{
			bool result;
			if (this.m_DataConn.State != ConnectionState.Closed)
			{
				try
				{
					this.m_DataConn.Close();
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("断开数据库连接失败！\r\n" + ex.Message);
					result = false;
					return result;
				}
			}
			result = true;
			return result;
		}

		public DataTable GetDataSet(string commandSQL)
		{
			DataTable result;
			if (this.m_DataConn.State != ConnectionState.Open)
			{
				result = null;
			}
			else
			{
				try
				{
					OracleDataAdapter DataAdapter = new OracleDataAdapter(commandSQL, this.m_DataConn);
					DataTable tempDataTable = new DataTable();
					DataAdapter.Fill(tempDataTable);
					result = tempDataTable;
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("执行SQL语句时出错！\r\n" + ex.Message);
					result = null;
				}
			}
			return result;
		}

		public int ExcuteSQL(string commandSQL)
		{
			int result;
			if (this.m_DataConn.State != ConnectionState.Open)
			{
				result = -1;
			}
			else
			{
				try
				{
					OracleCommand DataConnCommand = new OracleCommand(commandSQL, this.m_DataConn);
					int i = DataConnCommand.ExecuteNonQuery();
					result = i;
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("执行SQL语句时出错！\r\n" + ex.Message);
					result = -1;
				}
			}
			return result;
		}

		public int ExcuteSQL(string commandSQL, OracleParameter[] Parameters)
		{
			int result;
			if (this.m_DataConn.State != ConnectionState.Open)
			{
				result = -1;
			}
			else
			{
				try
				{
					OracleCommand DataConnCommand = new OracleCommand(commandSQL, this.m_DataConn);
					for (int i = 0; i < Parameters.Length; i++)
					{
						DataConnCommand.Parameters.Add(Parameters[i]);
					}
					int j = DataConnCommand.ExecuteNonQuery();
					result = j;
				}
				catch (System.Exception ex)
				{
					System.Windows.Forms.MessageBox.Show("执行SQL语句时出错！\r\n" + ex.Message);
					result = -1;
				}
			}
			return result;
		}
	}
}
