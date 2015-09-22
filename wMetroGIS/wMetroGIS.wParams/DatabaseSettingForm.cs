using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using DevComponents.DotNetBar.Ribbon;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wMetroGIS.wParams
{
	public class DatabaseSettingForm : System.Windows.Forms.Form
	{
		public DatabaseParams m_DatabaseParams;

		private bool m_IsModify;

		private System.ComponentModel.IContainer components = null;

		private RibbonClientPanel ribbonClientPanel1;

		private System.Windows.Forms.TextBox textBox数据库名;

		private System.Windows.Forms.TextBox textBox密码;

		private System.Windows.Forms.TextBox textBox用户;

		private System.Windows.Forms.Label label3;

		private System.Windows.Forms.TextBox textBox服务器;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.Label label14;

		private ButtonX buttonXSaveDefaultParams;

		private ButtonX buttonXLoadDefaultParams;

		private ButtonX buttonCancel;

		private ButtonX buttonOK;

		private TextBoxX textBoxXFilePath;

		public bool IsModify
		{
			get
			{
				return this.m_IsModify;
			}
			set
			{
				this.m_IsModify = value;
				this.buttonCancel.Enabled = this.m_IsModify;
			}
		}

		public DatabaseSettingForm()
		{
			this.InitializeComponent();
			this.m_DatabaseParams = new DatabaseParams();
			this.m_DatabaseParams.LoadParams();
			this.LoadDatabaseParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_DatabaseParams.ParamFilePath;
		}

		public DatabaseSettingForm(DatabaseParams databaseParams)
		{
			this.InitializeComponent();
			this.m_DatabaseParams = databaseParams;
			if (databaseParams == null)
			{
				System.Windows.Forms.MessageBox.Show("传入数据库连接参数为空！使用默认参数……", "错误", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				this.m_DatabaseParams = new DatabaseParams();
				this.m_DatabaseParams.LoadParams();
			}
			this.LoadDatabaseParams();
			this.textBoxXFilePath.Text = "数据路径：" + this.m_DatabaseParams.ParamFilePath;
		}

		private bool LoadDatabaseParams()
		{
			this.textBox服务器.Text = this.m_DatabaseParams.m_DatabaseServer;
			this.textBox用户.Text = this.m_DatabaseParams.m_DatabaseUserName;
			this.textBox密码.Text = this.m_DatabaseParams.m_DatabasePassword;
			this.textBox数据库名.Text = this.m_DatabaseParams.m_DatabaseName;
			return true;
		}

		private bool ApplyDatabaseParams()
		{
			this.m_DatabaseParams.m_DatabaseServer = this.textBox服务器.Text;
			this.m_DatabaseParams.m_DatabaseUserName = this.textBox用户.Text;
			this.m_DatabaseParams.m_DatabasePassword = this.textBox密码.Text;
			this.m_DatabaseParams.m_DatabaseName = this.textBox数据库名.Text;
			return true;
		}

		private void buttonXLoadDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.m_DatabaseParams.LoadDefaultParams())
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				this.LoadDatabaseParams();
			}
			else
			{
				System.Windows.Forms.MessageBox.Show("载入默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
			}
		}

		private void buttonXSaveDefaultParams_Click(object sender, System.EventArgs e)
		{
			if (this.ApplyDatabaseParams())
			{
				if (this.m_DatabaseParams.SaveDefaultParams())
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数成功！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Asterisk);
				}
				else
				{
					System.Windows.Forms.MessageBox.Show("保存默认参数失败！", "提示", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Hand);
				}
			}
		}

		private void buttonOK_Click(object sender, System.EventArgs e)
		{
			this.ApplyDatabaseParams();
			if (this.m_DatabaseParams.SaveParams())
			{
				base.DialogResult = System.Windows.Forms.DialogResult.OK;
				base.Close();
			}
		}

		private void buttonCancel_Click(object sender, System.EventArgs e)
		{
			base.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			base.Close();
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing && this.components != null)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DatabaseSettingForm));
			this.ribbonClientPanel1 = new RibbonClientPanel();
			this.textBox密码 = new System.Windows.Forms.TextBox();
			this.textBox用户 = new System.Windows.Forms.TextBox();
			this.textBox服务器 = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.textBox数据库名 = new System.Windows.Forms.TextBox();
			this.buttonXSaveDefaultParams = new ButtonX();
			this.buttonXLoadDefaultParams = new ButtonX();
			this.buttonCancel = new ButtonX();
			this.buttonOK = new ButtonX();
			this.textBoxXFilePath = new TextBoxX();
			this.ribbonClientPanel1.SuspendLayout();
			base.SuspendLayout();
			this.ribbonClientPanel1.CanvasColor = System.Drawing.SystemColors.Control;
			this.ribbonClientPanel1.Controls.Add(this.textBoxXFilePath);
			this.ribbonClientPanel1.Controls.Add(this.buttonXSaveDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.buttonXLoadDefaultParams);
			this.ribbonClientPanel1.Controls.Add(this.buttonCancel);
			this.ribbonClientPanel1.Controls.Add(this.buttonOK);
			this.ribbonClientPanel1.Controls.Add(this.textBox数据库名);
			this.ribbonClientPanel1.Controls.Add(this.textBox密码);
			this.ribbonClientPanel1.Controls.Add(this.textBox用户);
			this.ribbonClientPanel1.Controls.Add(this.label3);
			this.ribbonClientPanel1.Controls.Add(this.textBox服务器);
			this.ribbonClientPanel1.Controls.Add(this.label2);
			this.ribbonClientPanel1.Controls.Add(this.label1);
			this.ribbonClientPanel1.Controls.Add(this.label14);
			this.ribbonClientPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.ribbonClientPanel1.Location = new System.Drawing.Point(0, 0);
			this.ribbonClientPanel1.Name = "ribbonClientPanel1";
			this.ribbonClientPanel1.Size = new System.Drawing.Size(401, 364);
			this.ribbonClientPanel1.Style.Class = "RibbonClientPanel";
			this.ribbonClientPanel1.StyleMouseDown.Class = "";
			this.ribbonClientPanel1.StyleMouseOver.Class = "";
			this.ribbonClientPanel1.TabIndex = 0;
			this.ribbonClientPanel1.Text = "ribbonClientPanel1";
			this.textBox密码.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBox密码.Location = new System.Drawing.Point(127, 93);
			this.textBox密码.Name = "textBox密码";
			this.textBox密码.PasswordChar = '*';
			this.textBox密码.Size = new System.Drawing.Size(256, 29);
			this.textBox密码.TabIndex = 90;
			this.textBox密码.Text = "123456";
			this.textBox用户.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBox用户.Location = new System.Drawing.Point(127, 58);
			this.textBox用户.Name = "textBox用户";
			this.textBox用户.Size = new System.Drawing.Size(256, 29);
			this.textBox用户.TabIndex = 91;
			this.textBox用户.Text = "UserName";
			this.textBox服务器.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBox服务器.Location = new System.Drawing.Point(127, 23);
			this.textBox服务器.Name = "textBox服务器";
			this.textBox服务器.Size = new System.Drawing.Size(256, 29);
			this.textBox服务器.TabIndex = 92;
			this.textBox服务器.Text = "Server";
			this.label2.AutoSize = true;
			this.label2.BackColor = System.Drawing.Color.Transparent;
			this.label2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label2.ForeColor = System.Drawing.Color.Maroon;
			this.label2.Location = new System.Drawing.Point(31, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(90, 22);
			this.label2.TabIndex = 88;
			this.label2.Text = "登录密码：";
			this.label1.AutoSize = true;
			this.label1.BackColor = System.Drawing.Color.Transparent;
			this.label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label1.ForeColor = System.Drawing.Color.Maroon;
			this.label1.Location = new System.Drawing.Point(15, 61);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(106, 22);
			this.label1.TabIndex = 87;
			this.label1.Text = "登录用户名：";
			this.label14.AutoSize = true;
			this.label14.BackColor = System.Drawing.Color.Transparent;
			this.label14.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label14.ForeColor = System.Drawing.Color.Maroon;
			this.label14.Location = new System.Drawing.Point(15, 26);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(106, 22);
			this.label14.TabIndex = 89;
			this.label14.Text = "服务器地址：";
			this.label3.AutoSize = true;
			this.label3.BackColor = System.Drawing.Color.Transparent;
			this.label3.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.label3.ForeColor = System.Drawing.Color.Maroon;
			this.label3.Location = new System.Drawing.Point(31, 131);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 22);
			this.label3.TabIndex = 88;
			this.label3.Text = "数据库名：";
			this.textBox数据库名.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.textBox数据库名.Location = new System.Drawing.Point(127, 128);
			this.textBox数据库名.Name = "textBox数据库名";
			this.textBox数据库名.Size = new System.Drawing.Size(256, 29);
			this.textBox数据库名.TabIndex = 90;
			this.textBox数据库名.Text = "Database";
			this.buttonXSaveDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXSaveDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXSaveDefaultParams.Image = (System.Drawing.Image)resources.GetObject("buttonXSaveDefaultParams.Image");
			this.buttonXSaveDefaultParams.Location = new System.Drawing.Point(204, 243);
			this.buttonXSaveDefaultParams.Name = "buttonXSaveDefaultParams";
			this.buttonXSaveDefaultParams.Size = new System.Drawing.Size(179, 51);
			this.buttonXSaveDefaultParams.TabIndex = 96;
			this.buttonXSaveDefaultParams.Text = "保存为默认参数";
			this.buttonXSaveDefaultParams.Click += new System.EventHandler(this.buttonXSaveDefaultParams_Click);
			this.buttonXLoadDefaultParams.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonXLoadDefaultParams.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonXLoadDefaultParams.Image = (System.Drawing.Image)resources.GetObject("buttonXLoadDefaultParams.Image");
			this.buttonXLoadDefaultParams.Location = new System.Drawing.Point(19, 243);
			this.buttonXLoadDefaultParams.Name = "buttonXLoadDefaultParams";
			this.buttonXLoadDefaultParams.Size = new System.Drawing.Size(179, 51);
			this.buttonXLoadDefaultParams.TabIndex = 95;
			this.buttonXLoadDefaultParams.Text = "载入默认参数";
			this.buttonXLoadDefaultParams.Click += new System.EventHandler(this.buttonXLoadDefaultParams_Click);
			this.buttonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonCancel.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonCancel.Image = (System.Drawing.Image)resources.GetObject("buttonCancel.Image");
			this.buttonCancel.Location = new System.Drawing.Point(204, 300);
			this.buttonCancel.Name = "buttonCancel";
			this.buttonCancel.Size = new System.Drawing.Size(179, 48);
			this.buttonCancel.TabIndex = 94;
			this.buttonCancel.Text = "取\u3000消";
			this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
			this.buttonOK.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
			this.buttonOK.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
			this.buttonOK.Image = (System.Drawing.Image)resources.GetObject("buttonOK.Image");
			this.buttonOK.Location = new System.Drawing.Point(19, 300);
			this.buttonOK.Name = "buttonOK";
			this.buttonOK.Size = new System.Drawing.Size(179, 48);
			this.buttonOK.TabIndex = 93;
			this.buttonOK.Text = "确\u3000定";
			this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
			this.textBoxXFilePath.BackColor = System.Drawing.SystemColors.ActiveCaption;
			this.textBoxXFilePath.Border.Class = "TextBoxBorder";
			this.textBoxXFilePath.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold);
			this.textBoxXFilePath.Location = new System.Drawing.Point(19, 163);
			this.textBoxXFilePath.Multiline = true;
			this.textBoxXFilePath.Name = "textBoxXFilePath";
			this.textBoxXFilePath.Size = new System.Drawing.Size(364, 74);
			this.textBoxXFilePath.TabIndex = 97;
			this.textBoxXFilePath.TabStop = false;
			this.textBoxXFilePath.Text = "数据路径：";
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(401, 364);
			base.ControlBox = false;
			base.Controls.Add(this.ribbonClientPanel1);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			base.Name = "DatabaseSettingForm";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "数据库连接参数";
			this.ribbonClientPanel1.ResumeLayout(false);
			this.ribbonClientPanel1.PerformLayout();
			base.ResumeLayout(false);
		}
	}
}
