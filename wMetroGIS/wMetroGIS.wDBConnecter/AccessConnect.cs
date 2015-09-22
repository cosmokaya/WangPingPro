using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace wMetroGIS.wDBConnecter
{
	public class AccessConnect
	{
		private OleDbConnection m_DataConn;

		private string m_DataSourcePath;

		public AccessConnect(string DataSourcePath)
		{
			this.m_DataSourcePath = DataSourcePath;
		}

		public bool InitConn()
		{
			bool result;
			try
			{
				this.m_DataConn = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;data source=" + this.m_DataSourcePath);
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
					OleDbCommand DataConnCommand = new OleDbCommand(commandSQL, this.m_DataConn);
					OleDbDataAdapter DataAdapter = new OleDbDataAdapter(DataConnCommand);
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
					OleDbCommand DataConnCommand = new OleDbCommand(commandSQL, this.m_DataConn);
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

		public int ExcuteSQL(string commandSQL, OleDbParameter[] Parameters)
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
					OleDbCommand DataConnCommand = new OleDbCommand(commandSQL, this.m_DataConn);
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
