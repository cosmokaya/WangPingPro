namespace SCWPredictSystem
{
    partial class controlDateTimePicker
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.radioButton08H = new System.Windows.Forms.RadioButton();
            this.radioButton20H = new System.Windows.Forms.RadioButton();
            this.buttonNow = new DevComponents.DotNetBar.ButtonX();
            this.buttonPrevious = new DevComponents.DotNetBar.ButtonX();
            this.buttonNext = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.labelX1.Location = new System.Drawing.Point(10, 7);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(79, 26);
            this.labelX1.TabIndex = 0;
            this.labelX1.Text = "起报时间：";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "yyyy年MM月dd日";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(87, 7);
            this.dateTimePicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(159, 26);
            this.dateTimePicker1.TabIndex = 1;
            // 
            // radioButton08H
            // 
            this.radioButton08H.AutoSize = true;
            this.radioButton08H.Checked = true;
            this.radioButton08H.Location = new System.Drawing.Point(87, 41);
            this.radioButton08H.Name = "radioButton08H";
            this.radioButton08H.Size = new System.Drawing.Size(59, 23);
            this.radioButton08H.TabIndex = 2;
            this.radioButton08H.TabStop = true;
            this.radioButton08H.Text = "08时";
            this.radioButton08H.UseVisualStyleBackColor = true;
            // 
            // radioButton20H
            // 
            this.radioButton20H.AutoSize = true;
            this.radioButton20H.Location = new System.Drawing.Point(152, 41);
            this.radioButton20H.Name = "radioButton20H";
            this.radioButton20H.Size = new System.Drawing.Size(59, 23);
            this.radioButton20H.TabIndex = 2;
            this.radioButton20H.Text = "20时";
            this.radioButton20H.UseVisualStyleBackColor = true;
            // 
            // buttonNow
            // 
            this.buttonNow.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonNow.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonNow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.buttonNow.Image = global::SCWPredictSystem.Properties.Resources.Calendar;
            this.buttonNow.Location = new System.Drawing.Point(90, 71);
            this.buttonNow.Name = "buttonNow";
            this.buttonNow.Size = new System.Drawing.Size(75, 30);
            this.buttonNow.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonNow.TabIndex = 3;
            this.buttonNow.Text = "最  新";
            this.buttonNow.Click += new System.EventHandler(this.buttonNow_Click);
            // 
            // buttonPrevious
            // 
            this.buttonPrevious.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonPrevious.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonPrevious.Image = global::SCWPredictSystem.Properties.Resources.MailMergeGoToPreviousRecord;
            this.buttonPrevious.Location = new System.Drawing.Point(10, 71);
            this.buttonPrevious.Name = "buttonPrevious";
            this.buttonPrevious.Size = new System.Drawing.Size(75, 30);
            this.buttonPrevious.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonPrevious.TabIndex = 3;
            this.buttonPrevious.Text = "上一个";
            this.buttonPrevious.Click += new System.EventHandler(this.buttonPrevious_Click);
            // 
            // buttonNext
            // 
            this.buttonNext.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonNext.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonNext.Image = global::SCWPredictSystem.Properties.Resources.MailMergeGoToNextRecord;
            this.buttonNext.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.buttonNext.Location = new System.Drawing.Point(169, 71);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 30);
            this.buttonNext.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonNext.TabIndex = 3;
            this.buttonNext.Text = "下一个";
            this.buttonNext.Click += new System.EventHandler(this.buttonNext_Click);
            // 
            // controlDateTimePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonPrevious);
            this.Controls.Add(this.buttonNow);
            this.Controls.Add(this.radioButton20H);
            this.Controls.Add(this.radioButton08H);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.labelX1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "controlDateTimePicker";
            this.Size = new System.Drawing.Size(250, 108);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.RadioButton radioButton08H;
        private System.Windows.Forms.RadioButton radioButton20H;
        private DevComponents.DotNetBar.ButtonX buttonNow;
        private DevComponents.DotNetBar.ButtonX buttonPrevious;
        private DevComponents.DotNetBar.ButtonX buttonNext;
    }
}
