using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace wMetroGIS.wCurve
{
	public class CurveRelationForm : System.Windows.Forms.Form
	{
		private System.ComponentModel.IContainer components = null;

		private System.Windows.Forms.TreeView treeViewCurveRelation;

		public CurveRelation m_CurveRelation = null;

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
			this.treeViewCurveRelation = new System.Windows.Forms.TreeView();
			base.SuspendLayout();
			this.treeViewCurveRelation.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right);
			this.treeViewCurveRelation.FullRowSelect = true;
			this.treeViewCurveRelation.Location = new System.Drawing.Point(12, 12);
			this.treeViewCurveRelation.Name = "treeViewCurveRelation";
			this.treeViewCurveRelation.Size = new System.Drawing.Size(442, 397);
			this.treeViewCurveRelation.TabIndex = 0;
			base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(466, 421);
			base.Controls.Add(this.treeViewCurveRelation);
			base.Name = "CurveRelationForm";
			this.Text = "CurveRelationForm";
			base.Load += new System.EventHandler(this.CurveRelationForm_Load);
			base.ResumeLayout(false);
		}

		public CurveRelationForm()
		{
			this.InitializeComponent();
		}

		private void CurveRelationForm_Load(object sender, System.EventArgs e)
		{
			if (this.m_CurveRelation != null)
			{
				this.treeViewCurveRelation.Nodes.Add(this.m_CurveRelation.m_RootNode);
				this.treeViewCurveRelation.ExpandAll();
			}
		}
	}
}
