﻿namespace SCWPredictSystem
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "对流有效能量",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "对流抑制能量",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "抬升指数",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "沙氏指数",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "风暴强度指数",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "粗理查森数",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "粗理查森数切变",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "A指数",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "K指数",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "位势不稳定指数",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "700-500hPa间平均相对湿度",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "500-200间平均相对湿度",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "0℃所在高度层",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "20℃所在高度层",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem15 = new System.Windows.Forms.ListViewItem(new string[] {
            "雷暴",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem16 = new System.Windows.Forms.ListViewItem(new string[] {
            "雷暴大风",
            "",
            ""}, -1);
            System.Windows.Forms.ListViewItem listViewItem17 = new System.Windows.Forms.ListViewItem(new string[] {
            "冰雹",
            "",
            ""}, -1);
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("南京", 1, 1);
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("福州", 1, 1);
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("厦门", 1, 1);
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("漳州", 1, 1);
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("合肥", 1, 1);
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("南昌", 1, 1);
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("杭州", 1, 1);
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("徐州", 1, 1);
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("射阳", 1, 1);
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("战区重要站点列表", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6,
            treeNode7,
            treeNode8,
            treeNode9});
            this.tabControl1 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel13 = new DevComponents.DotNetBar.TabControlPanel();
            this.wMapPictureBox3 = new wMetroGIS.wMapPictureBoxControl.wMapPictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX7 = new DevComponents.DotNetBar.LabelX();
            this.listBoxFactorSurf = new System.Windows.Forms.ListBox();
            this.labelX9 = new DevComponents.DotNetBar.LabelX();
            this.listBoxHourSurf = new System.Windows.Forms.ListBox();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel3 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.wLayerManagerControl3 = new wMetroGIS.wLayers.wLayerManagerControl();
            this.controlDateTimePickerSurf = new SCWPredictSystem.controlDateTimePicker();
            this.tabItem13 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel2 = new DevComponents.DotNetBar.TabControlPanel();
            this.wMapPictureBox1 = new wMetroGIS.wMapPictureBoxControl.wMapPictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.listBoxFactorMM5 = new System.Windows.Forms.ListBox();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.listBoxLevelMM5 = new System.Windows.Forms.ListBox();
            this.listBoxHourMM5 = new System.Windows.Forms.ListBox();
            this.buttonLevelMM5Up = new DevComponents.DotNetBar.ButtonX();
            this.buttonLevelMM5Down = new DevComponents.DotNetBar.ButtonX();
            this.buttonHourMM5Up = new DevComponents.DotNetBar.ButtonX();
            this.buttonHourMM5Down = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.wLayerManagerControl1 = new wMetroGIS.wLayers.wLayerManagerControl();
            this.controlDateTimePickerMM5 = new SCWPredictSystem.controlDateTimePicker();
            this.tabItem2 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel7 = new DevComponents.DotNetBar.TabControlPanel();
            this.wMapPictureBox2 = new wMetroGIS.wMapPictureBoxControl.wMapPictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.listBoxFactorArea = new System.Windows.Forms.ListBox();
            this.labelX8 = new DevComponents.DotNetBar.LabelX();
            this.listBoxHourArea = new System.Windows.Forms.ListBox();
            this.buttonHourAreaUp = new DevComponents.DotNetBar.ButtonX();
            this.buttonHourAreaDown = new DevComponents.DotNetBar.ButtonX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.wLayerManagerControl2 = new wMetroGIS.wLayers.wLayerManagerControl();
            this.controlDateTimePickerArea = new SCWPredictSystem.controlDateTimePicker();
            this.tabItem7 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel1 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabItem1 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel4 = new DevComponents.DotNetBar.TabControlPanel();
            this.wParamsManagerControl1 = new wMetroGIS.wParams.wParamsManagerControl();
            this.tabItem4 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel3 = new DevComponents.DotNetBar.TabControlPanel();
            this.tabControl2 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel5 = new DevComponents.DotNetBar.TabControlPanel();
            this.expandablePanel1 = new DevComponents.DotNetBar.ExpandablePanel();
            this.tabControl3 = new DevComponents.DotNetBar.TabControl();
            this.tabControlPanel8 = new DevComponents.DotNetBar.TabControlPanel();
            this.listViewPotentialLeiBao = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabItem8 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel11 = new DevComponents.DotNetBar.TabControlPanel();
            this.m_listViewIndex = new System.Windows.Forms.ListView();
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabItem11 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel12 = new DevComponents.DotNetBar.TabControlPanel();
            this.m_listViewParas = new System.Windows.Forms.ListView();
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabItem12 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel10 = new DevComponents.DotNetBar.TabControlPanel();
            this.listViewPotentialBinBao = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabItem10 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel9 = new DevComponents.DotNetBar.TabControlPanel();
            this.listViewPotentialDaFeng = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabItem9 = new DevComponents.DotNetBar.TabItem(this.components);
            this.wTlnPControl1 = new wMetroGIS.wTlnP.wTlnPControl();
            this.tabItem5 = new DevComponents.DotNetBar.TabItem(this.components);
            this.tabControlPanel6 = new DevComponents.DotNetBar.TabControlPanel();
            this.wWindRoseControl1 = new wMetroGIS.wTlnP.wWindRoseControl();
            this.tabItem6 = new DevComponents.DotNetBar.TabItem(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.treeViewStation = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.listBoxHourStation = new System.Windows.Forms.ListBox();
            this.buttonHourStationUp = new DevComponents.DotNetBar.ButtonX();
            this.buttonHourStationDown = new DevComponents.DotNetBar.ButtonX();
            this.controlDateTimePickerStation = new SCWPredictSystem.controlDateTimePicker();
            this.tabItem3 = new DevComponents.DotNetBar.TabItem(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabControlPanel13.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupPanel3.SuspendLayout();
            this.tabControlPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupPanel1.SuspendLayout();
            this.tabControlPanel7.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupPanel2.SuspendLayout();
            this.tabControlPanel4.SuspendLayout();
            this.tabControlPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).BeginInit();
            this.tabControl2.SuspendLayout();
            this.tabControlPanel5.SuspendLayout();
            this.expandablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabControl3)).BeginInit();
            this.tabControl3.SuspendLayout();
            this.tabControlPanel8.SuspendLayout();
            this.tabControlPanel11.SuspendLayout();
            this.tabControlPanel12.SuspendLayout();
            this.tabControlPanel10.SuspendLayout();
            this.tabControlPanel9.SuspendLayout();
            this.tabControlPanel6.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(194)))), ((int)(((byte)(217)))), ((int)(((byte)(247)))));
            this.tabControl1.CanReorderTabs = true;
            this.tabControl1.Controls.Add(this.tabControlPanel13);
            this.tabControl1.Controls.Add(this.tabControlPanel2);
            this.tabControl1.Controls.Add(this.tabControlPanel1);
            this.tabControl1.Controls.Add(this.tabControlPanel7);
            this.tabControl1.Controls.Add(this.tabControlPanel4);
            this.tabControl1.Controls.Add(this.tabControlPanel3);
            this.tabControl1.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedTabFont = new System.Drawing.Font("微软雅黑", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.SelectedTabIndex = 1;
            this.tabControl1.Size = new System.Drawing.Size(968, 718);
            this.tabControl1.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Dock;
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl1.Tabs.Add(this.tabItem1);
            this.tabControl1.Tabs.Add(this.tabItem2);
            this.tabControl1.Tabs.Add(this.tabItem13);
            this.tabControl1.Tabs.Add(this.tabItem7);
            this.tabControl1.Tabs.Add(this.tabItem3);
            this.tabControl1.Tabs.Add(this.tabItem4);
            this.tabControl1.Text = "tabControl1";
            // 
            // tabControlPanel13
            // 
            this.tabControlPanel13.Controls.Add(this.wMapPictureBox3);
            this.tabControlPanel13.Controls.Add(this.panel4);
            this.tabControlPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel13.Location = new System.Drawing.Point(0, 41);
            this.tabControlPanel13.Name = "tabControlPanel13";
            this.tabControlPanel13.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel13.Size = new System.Drawing.Size(968, 677);
            this.tabControlPanel13.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel13.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel13.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel13.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel13.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel13.Style.GradientAngle = 90;
            this.tabControlPanel13.TabIndex = 6;
            this.tabControlPanel13.TabItem = this.tabItem13;
            // 
            // wMapPictureBox3
            // 
            this.wMapPictureBox3.AutoZoomMode = wMetroGIS.wMapPictureBoxControl.wMapPictureBox.AUTOZOOM_MODE.FIT_AUTO;
            this.wMapPictureBox3.BackColor = System.Drawing.Color.White;
            this.wMapPictureBox3.ColorBarBitmap = null;
            this.wMapPictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wMapPictureBox3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wMapPictureBox3.LabelInfo = "";
            this.wMapPictureBox3.Location = new System.Drawing.Point(268, 1);
            this.wMapPictureBox3.MapTitle = "";
            this.wMapPictureBox3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wMapPictureBox3.MouseStatus = wMetroGIS.wMapPictureBoxControl.wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_NORMAL;
            this.wMapPictureBox3.Name = "wMapPictureBox3";
            this.wMapPictureBox3.ShowColorBar = false;
            this.wMapPictureBox3.ShowMapTitle = false;
            this.wMapPictureBox3.ShowMousePosition = false;
            this.wMapPictureBox3.ShowStation = false;
            this.wMapPictureBox3.ShowToolStripButtonAutoZoom = false;
            this.wMapPictureBox3.ShowToolStripButtonMouseNormal = false;
            this.wMapPictureBox3.ShowToolStripButtonMouseScrach = false;
            this.wMapPictureBox3.ShowToolStripButtonMouseSelectArea = false;
            this.wMapPictureBox3.ShowToolStripButtonMouseSelectPoint = false;
            this.wMapPictureBox3.ShowToolStripButtonRefresh = false;
            this.wMapPictureBox3.ShowToolStripButtonSavePicture = false;
            this.wMapPictureBox3.ShowToolStripButtonSetParams = false;
            this.wMapPictureBox3.ShowToolStripButtonShowColorBar = false;
            this.wMapPictureBox3.ShowToolStripButtonShowStation = false;
            this.wMapPictureBox3.ShowToolStripButtonShowTitle = false;
            this.wMapPictureBox3.ShowToolStripButtonZoom = false;
            this.wMapPictureBox3.Size = new System.Drawing.Size(699, 675);
            this.wMapPictureBox3.StationDataPath1 = "";
            this.wMapPictureBox3.StationDataPath2 = "";
            this.wMapPictureBox3.TabIndex = 8;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Transparent;
            this.panel4.Controls.Add(this.tableLayoutPanel4);
            this.panel4.Controls.Add(this.controlDateTimePickerSurf);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(1, 1);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(267, 675);
            this.panel4.TabIndex = 7;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Controls.Add(this.labelX7, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.listBoxFactorSurf, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.labelX9, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.listBoxHourSurf, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.buttonX1, 0, 4);
            this.tableLayoutPanel4.Controls.Add(this.buttonX2, 1, 4);
            this.tableLayoutPanel4.Controls.Add(this.groupPanel3, 0, 5);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(14, 113);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 6;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(240, 559);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // labelX7
            // 
            // 
            // 
            // 
            this.labelX7.BackgroundStyle.Class = "";
            this.tableLayoutPanel4.SetColumnSpan(this.labelX7, 2);
            this.labelX7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX7.Location = new System.Drawing.Point(4, 5);
            this.labelX7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX7.Name = "labelX7";
            this.labelX7.Size = new System.Drawing.Size(232, 16);
            this.labelX7.TabIndex = 2;
            this.labelX7.Text = "潜势预报产品：";
            // 
            // listBoxFactorSurf
            // 
            this.listBoxFactorSurf.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel4.SetColumnSpan(this.listBoxFactorSurf, 2);
            this.listBoxFactorSurf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFactorSurf.FormattingEnabled = true;
            this.listBoxFactorSurf.ItemHeight = 22;
            this.listBoxFactorSurf.Items.AddRange(new object[] {
            "对流有效位能CAPE",
            "抑制有效位能CIN",
            "抬升指数LI",
            "沙氏指数SI",
            "风暴强度指数SSI",
            "粗理查逊数BRN",
            "理查逊数切变BRNSHR",
            "A指数AI",
            "K指数KI",
            "强天气威胁指数SWEAT",
            "雷暴大风附加指数1   F75F",
            "雷暴大风附加指数2   F52F"});
            this.listBoxFactorSurf.Location = new System.Drawing.Point(3, 29);
            this.listBoxFactorSurf.Name = "listBoxFactorSurf";
            this.listBoxFactorSurf.Size = new System.Drawing.Size(234, 156);
            this.listBoxFactorSurf.TabIndex = 1;
            // 
            // labelX9
            // 
            // 
            // 
            // 
            this.labelX9.BackgroundStyle.Class = "";
            this.tableLayoutPanel4.SetColumnSpan(this.labelX9, 2);
            this.labelX9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX9.Location = new System.Drawing.Point(4, 193);
            this.labelX9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX9.Name = "labelX9";
            this.labelX9.Size = new System.Drawing.Size(232, 16);
            this.labelX9.TabIndex = 2;
            this.labelX9.Text = "预报时间：";
            // 
            // listBoxHourSurf
            // 
            this.listBoxHourSurf.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel4.SetColumnSpan(this.listBoxHourSurf, 2);
            this.listBoxHourSurf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHourSurf.FormattingEnabled = true;
            this.listBoxHourSurf.ItemHeight = 22;
            this.listBoxHourSurf.Items.AddRange(new object[] {
            "06小时",
            "12小时",
            "18小时",
            "24小时",
            "30小时",
            "36小时",
            "42小时",
            "48小时",
            "54小时",
            "60小时",
            "66小时",
            "72小时"});
            this.listBoxHourSurf.Location = new System.Drawing.Point(3, 217);
            this.listBoxHourSurf.Name = "listBoxHourSurf";
            this.listBoxHourSurf.Size = new System.Drawing.Size(234, 156);
            this.listBoxHourSurf.TabIndex = 1;
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonX1.Image = ((System.Drawing.Image)(resources.GetObject("buttonX1.Image")));
            this.buttonX1.Location = new System.Drawing.Point(3, 379);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(114, 27);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 0;
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonX2.Image = ((System.Drawing.Image)(resources.GetObject("buttonX2.Image")));
            this.buttonX2.Location = new System.Drawing.Point(123, 379);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(114, 27);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 0;
            // 
            // groupPanel3
            // 
            this.groupPanel3.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel3.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.tableLayoutPanel4.SetColumnSpan(this.groupPanel3, 2);
            this.groupPanel3.Controls.Add(this.wLayerManagerControl3);
            this.groupPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel3.Location = new System.Drawing.Point(3, 412);
            this.groupPanel3.Name = "groupPanel3";
            this.groupPanel3.Size = new System.Drawing.Size(234, 144);
            // 
            // 
            // 
            this.groupPanel3.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel3.Style.BackColorGradientAngle = 90;
            this.groupPanel3.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel3.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderBottomWidth = 1;
            this.groupPanel3.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel3.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderLeftWidth = 1;
            this.groupPanel3.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderRightWidth = 1;
            this.groupPanel3.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel3.Style.BorderTopWidth = 1;
            this.groupPanel3.Style.Class = "";
            this.groupPanel3.Style.CornerDiameter = 4;
            this.groupPanel3.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel3.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel3.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel3.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel3.StyleMouseDown.Class = "";
            // 
            // 
            // 
            this.groupPanel3.StyleMouseOver.Class = "";
            this.groupPanel3.TabIndex = 3;
            this.groupPanel3.Text = "图层管理";
            // 
            // wLayerManagerControl3
            // 
            this.wLayerManagerControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wLayerManagerControl3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wLayerManagerControl3.Location = new System.Drawing.Point(0, 0);
            this.wLayerManagerControl3.MapPictureBox = null;
            this.wLayerManagerControl3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wLayerManagerControl3.Name = "wLayerManagerControl3";
            this.wLayerManagerControl3.SelectedLayerID = -1;
            this.wLayerManagerControl3.Size = new System.Drawing.Size(228, 112);
            this.wLayerManagerControl3.TabIndex = 0;
            // 
            // controlDateTimePickerSurf
            // 
            this.controlDateTimePickerSurf.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlDateTimePickerSurf.Location = new System.Drawing.Point(4, 5);
            this.controlDateTimePickerSurf.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controlDateTimePickerSurf.Name = "controlDateTimePickerSurf";
            this.controlDateTimePickerSurf.selectedDateTime = new System.DateTime(2015, 7, 21, 8, 0, 0, 0);
            this.controlDateTimePickerSurf.Size = new System.Drawing.Size(250, 108);
            this.controlDateTimePickerSurf.TabIndex = 0;
            // 
            // tabItem13
            // 
            this.tabItem13.AttachedControl = this.tabControlPanel13;
            this.tabItem13.Icon = ((System.Drawing.Icon)(resources.GetObject("tabItem13.Icon")));
            this.tabItem13.Image = global::SCWPredictSystem.Properties.Resources.SmartArtChangeColorsGallery;
            this.tabItem13.Name = "tabItem13";
            this.tabItem13.Text = "强对流天气指数预报";
            // 
            // tabControlPanel2
            // 
            this.tabControlPanel2.Controls.Add(this.wMapPictureBox1);
            this.tabControlPanel2.Controls.Add(this.panel1);
            this.tabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel2.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlPanel2.Location = new System.Drawing.Point(0, 41);
            this.tabControlPanel2.Name = "tabControlPanel2";
            this.tabControlPanel2.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel2.Size = new System.Drawing.Size(968, 677);
            this.tabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel2.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel2.Style.GradientAngle = 90;
            this.tabControlPanel2.TabIndex = 2;
            this.tabControlPanel2.TabItem = this.tabItem2;
            // 
            // wMapPictureBox1
            // 
            this.wMapPictureBox1.AutoZoomMode = wMetroGIS.wMapPictureBoxControl.wMapPictureBox.AUTOZOOM_MODE.FIT_AUTO;
            this.wMapPictureBox1.BackColor = System.Drawing.Color.White;
            this.wMapPictureBox1.ColorBarBitmap = null;
            this.wMapPictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wMapPictureBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wMapPictureBox1.LabelInfo = "";
            this.wMapPictureBox1.Location = new System.Drawing.Point(268, 1);
            this.wMapPictureBox1.MapTitle = "";
            this.wMapPictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wMapPictureBox1.MouseStatus = wMetroGIS.wMapPictureBoxControl.wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_NORMAL;
            this.wMapPictureBox1.Name = "wMapPictureBox1";
            this.wMapPictureBox1.ShowColorBar = false;
            this.wMapPictureBox1.ShowMapTitle = false;
            this.wMapPictureBox1.ShowMousePosition = false;
            this.wMapPictureBox1.ShowStation = false;
            this.wMapPictureBox1.ShowToolStripButtonAutoZoom = false;
            this.wMapPictureBox1.ShowToolStripButtonMouseNormal = false;
            this.wMapPictureBox1.ShowToolStripButtonMouseScrach = false;
            this.wMapPictureBox1.ShowToolStripButtonMouseSelectArea = false;
            this.wMapPictureBox1.ShowToolStripButtonMouseSelectPoint = false;
            this.wMapPictureBox1.ShowToolStripButtonRefresh = false;
            this.wMapPictureBox1.ShowToolStripButtonSavePicture = false;
            this.wMapPictureBox1.ShowToolStripButtonSetParams = false;
            this.wMapPictureBox1.ShowToolStripButtonShowColorBar = false;
            this.wMapPictureBox1.ShowToolStripButtonShowStation = false;
            this.wMapPictureBox1.ShowToolStripButtonShowTitle = false;
            this.wMapPictureBox1.ShowToolStripButtonZoom = false;
            this.wMapPictureBox1.Size = new System.Drawing.Size(699, 675);
            this.wMapPictureBox1.StationDataPath1 = "";
            this.wMapPictureBox1.StationDataPath2 = "";
            this.wMapPictureBox1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Controls.Add(this.controlDateTimePickerMM5);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 675);
            this.panel1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.labelX1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.listBoxFactorMM5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.labelX2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelX3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.listBoxLevelMM5, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.listBoxHourMM5, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.buttonLevelMM5Up, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonLevelMM5Down, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonHourMM5Up, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.buttonHourMM5Down, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.groupPanel1, 0, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(14, 113);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(240, 559);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.Class = "";
            this.tableLayoutPanel1.SetColumnSpan(this.labelX1, 2);
            this.labelX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX1.Location = new System.Drawing.Point(4, 5);
            this.labelX1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(112, 16);
            this.labelX1.TabIndex = 2;
            this.labelX1.Text = "要素产品：";
            // 
            // listBoxFactorMM5
            // 
            this.listBoxFactorMM5.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxFactorMM5, 4);
            this.listBoxFactorMM5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFactorMM5.FormattingEnabled = true;
            this.listBoxFactorMM5.ItemHeight = 19;
            this.listBoxFactorMM5.Items.AddRange(new object[] {
            "地面风场+累计降水量",
            "500百帕风场+相对湿度",
            "700百帕风场+相对湿度",
            "850百帕风场+相对湿度",
            "500百帕高度+500百帕风场",
            "500百帕高度+700百帕风场",
            "500百帕高度+850百帕风场",
            "地面气压",
            "地面10米风场",
            "地面2米温度",
            "地面2米相对湿度",
            "地面累积降水量",
            "等压面高度",
            "等压面温度",
            "等压面露点温度",
            "等压面相对湿度",
            "等压面风场"});
            this.listBoxFactorMM5.Location = new System.Drawing.Point(3, 29);
            this.listBoxFactorMM5.Name = "listBoxFactorMM5";
            this.listBoxFactorMM5.Size = new System.Drawing.Size(234, 156);
            this.listBoxFactorMM5.TabIndex = 1;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.Class = "";
            this.tableLayoutPanel1.SetColumnSpan(this.labelX2, 2);
            this.labelX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX2.Location = new System.Drawing.Point(4, 193);
            this.labelX2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(112, 16);
            this.labelX2.TabIndex = 2;
            this.labelX2.Text = "要素层次：";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.Class = "";
            this.tableLayoutPanel1.SetColumnSpan(this.labelX3, 2);
            this.labelX3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX3.Location = new System.Drawing.Point(124, 193);
            this.labelX3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(112, 16);
            this.labelX3.TabIndex = 2;
            this.labelX3.Text = "预报时间：";
            // 
            // listBoxLevelMM5
            // 
            this.listBoxLevelMM5.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxLevelMM5, 2);
            this.listBoxLevelMM5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLevelMM5.Enabled = false;
            this.listBoxLevelMM5.FormattingEnabled = true;
            this.listBoxLevelMM5.ItemHeight = 19;
            this.listBoxLevelMM5.Items.AddRange(new object[] {
            "925百帕",
            "850百帕",
            "700百帕",
            "500百帕",
            "400百帕",
            "300百帕",
            "200百帕",
            "100百帕"});
            this.listBoxLevelMM5.Location = new System.Drawing.Point(3, 217);
            this.listBoxLevelMM5.Name = "listBoxLevelMM5";
            this.listBoxLevelMM5.Size = new System.Drawing.Size(114, 156);
            this.listBoxLevelMM5.TabIndex = 1;
            // 
            // listBoxHourMM5
            // 
            this.listBoxHourMM5.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel1.SetColumnSpan(this.listBoxHourMM5, 2);
            this.listBoxHourMM5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHourMM5.FormattingEnabled = true;
            this.listBoxHourMM5.ItemHeight = 19;
            this.listBoxHourMM5.Items.AddRange(new object[] {
            "00小时",
            "06小时",
            "12小时",
            "18小时",
            "24小时",
            "30小时",
            "36小时",
            "42小时",
            "48小时",
            "54小时",
            "60小时",
            "66小时",
            "72小时"});
            this.listBoxHourMM5.Location = new System.Drawing.Point(123, 217);
            this.listBoxHourMM5.Name = "listBoxHourMM5";
            this.listBoxHourMM5.Size = new System.Drawing.Size(114, 156);
            this.listBoxHourMM5.TabIndex = 1;
            // 
            // buttonLevelMM5Up
            // 
            this.buttonLevelMM5Up.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLevelMM5Up.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLevelMM5Up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLevelMM5Up.Image = ((System.Drawing.Image)(resources.GetObject("buttonLevelMM5Up.Image")));
            this.buttonLevelMM5Up.Location = new System.Drawing.Point(3, 379);
            this.buttonLevelMM5Up.Name = "buttonLevelMM5Up";
            this.buttonLevelMM5Up.Size = new System.Drawing.Size(54, 27);
            this.buttonLevelMM5Up.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonLevelMM5Up.TabIndex = 0;
            this.buttonLevelMM5Up.Click += new System.EventHandler(this.buttonLevelMM5Up_Click);
            // 
            // buttonLevelMM5Down
            // 
            this.buttonLevelMM5Down.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonLevelMM5Down.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonLevelMM5Down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonLevelMM5Down.Image = ((System.Drawing.Image)(resources.GetObject("buttonLevelMM5Down.Image")));
            this.buttonLevelMM5Down.Location = new System.Drawing.Point(63, 379);
            this.buttonLevelMM5Down.Name = "buttonLevelMM5Down";
            this.buttonLevelMM5Down.Size = new System.Drawing.Size(54, 27);
            this.buttonLevelMM5Down.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonLevelMM5Down.TabIndex = 0;
            this.buttonLevelMM5Down.Click += new System.EventHandler(this.buttonLevelMM5Down_Click);
            // 
            // buttonHourMM5Up
            // 
            this.buttonHourMM5Up.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHourMM5Up.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonHourMM5Up.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHourMM5Up.Image = ((System.Drawing.Image)(resources.GetObject("buttonHourMM5Up.Image")));
            this.buttonHourMM5Up.Location = new System.Drawing.Point(123, 379);
            this.buttonHourMM5Up.Name = "buttonHourMM5Up";
            this.buttonHourMM5Up.Size = new System.Drawing.Size(54, 27);
            this.buttonHourMM5Up.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonHourMM5Up.TabIndex = 0;
            this.buttonHourMM5Up.Click += new System.EventHandler(this.buttonHourMM5Up_Click);
            // 
            // buttonHourMM5Down
            // 
            this.buttonHourMM5Down.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHourMM5Down.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonHourMM5Down.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHourMM5Down.Image = ((System.Drawing.Image)(resources.GetObject("buttonHourMM5Down.Image")));
            this.buttonHourMM5Down.Location = new System.Drawing.Point(183, 379);
            this.buttonHourMM5Down.Name = "buttonHourMM5Down";
            this.buttonHourMM5Down.Size = new System.Drawing.Size(54, 27);
            this.buttonHourMM5Down.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonHourMM5Down.TabIndex = 0;
            this.buttonHourMM5Down.Click += new System.EventHandler(this.buttonHourMM5Down_Click);
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.tableLayoutPanel1.SetColumnSpan(this.groupPanel1, 4);
            this.groupPanel1.Controls.Add(this.wLayerManagerControl1);
            this.groupPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel1.Location = new System.Drawing.Point(3, 412);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(234, 144);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.Class = "";
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.Class = "";
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.Class = "";
            this.groupPanel1.TabIndex = 3;
            this.groupPanel1.Text = "图层管理";
            // 
            // wLayerManagerControl1
            // 
            this.wLayerManagerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wLayerManagerControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wLayerManagerControl1.Location = new System.Drawing.Point(0, 0);
            this.wLayerManagerControl1.MapPictureBox = null;
            this.wLayerManagerControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wLayerManagerControl1.Name = "wLayerManagerControl1";
            this.wLayerManagerControl1.SelectedLayerID = -1;
            this.wLayerManagerControl1.Size = new System.Drawing.Size(228, 115);
            this.wLayerManagerControl1.TabIndex = 0;
            // 
            // controlDateTimePickerMM5
            // 
            this.controlDateTimePickerMM5.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlDateTimePickerMM5.Location = new System.Drawing.Point(4, 5);
            this.controlDateTimePickerMM5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controlDateTimePickerMM5.Name = "controlDateTimePickerMM5";
            this.controlDateTimePickerMM5.selectedDateTime = new System.DateTime(2015, 7, 21, 8, 0, 0, 0);
            this.controlDateTimePickerMM5.Size = new System.Drawing.Size(250, 108);
            this.controlDateTimePickerMM5.TabIndex = 0;
            // 
            // tabItem2
            // 
            this.tabItem2.AttachedControl = this.tabControlPanel2;
            this.tabItem2.Image = global::SCWPredictSystem.Properties.Resources.SmartArtChangeColorsGallery;
            this.tabItem2.Name = "tabItem2";
            this.tabItem2.Text = "强对流形式预报";
            // 
            // tabControlPanel7
            // 
            this.tabControlPanel7.Controls.Add(this.wMapPictureBox2);
            this.tabControlPanel7.Controls.Add(this.panel3);
            this.tabControlPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel7.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControlPanel7.Location = new System.Drawing.Point(0, 41);
            this.tabControlPanel7.Name = "tabControlPanel7";
            this.tabControlPanel7.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel7.Size = new System.Drawing.Size(968, 677);
            this.tabControlPanel7.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel7.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel7.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel7.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel7.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel7.Style.GradientAngle = 90;
            this.tabControlPanel7.TabIndex = 5;
            this.tabControlPanel7.TabItem = this.tabItem7;
            // 
            // wMapPictureBox2
            // 
            this.wMapPictureBox2.AutoZoomMode = wMetroGIS.wMapPictureBoxControl.wMapPictureBox.AUTOZOOM_MODE.FIT_AUTO;
            this.wMapPictureBox2.BackColor = System.Drawing.Color.White;
            this.wMapPictureBox2.ColorBarBitmap = null;
            this.wMapPictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wMapPictureBox2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wMapPictureBox2.LabelInfo = "";
            this.wMapPictureBox2.Location = new System.Drawing.Point(268, 1);
            this.wMapPictureBox2.MapTitle = "";
            this.wMapPictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wMapPictureBox2.MouseStatus = wMetroGIS.wMapPictureBoxControl.wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_NORMAL;
            this.wMapPictureBox2.Name = "wMapPictureBox2";
            this.wMapPictureBox2.ShowColorBar = false;
            this.wMapPictureBox2.ShowMapTitle = false;
            this.wMapPictureBox2.ShowMousePosition = false;
            this.wMapPictureBox2.ShowStation = false;
            this.wMapPictureBox2.ShowToolStripButtonAutoZoom = false;
            this.wMapPictureBox2.ShowToolStripButtonMouseNormal = false;
            this.wMapPictureBox2.ShowToolStripButtonMouseScrach = false;
            this.wMapPictureBox2.ShowToolStripButtonMouseSelectArea = false;
            this.wMapPictureBox2.ShowToolStripButtonMouseSelectPoint = false;
            this.wMapPictureBox2.ShowToolStripButtonRefresh = false;
            this.wMapPictureBox2.ShowToolStripButtonSavePicture = false;
            this.wMapPictureBox2.ShowToolStripButtonSetParams = false;
            this.wMapPictureBox2.ShowToolStripButtonShowColorBar = false;
            this.wMapPictureBox2.ShowToolStripButtonShowStation = false;
            this.wMapPictureBox2.ShowToolStripButtonShowTitle = false;
            this.wMapPictureBox2.ShowToolStripButtonZoom = false;
            this.wMapPictureBox2.Size = new System.Drawing.Size(699, 675);
            this.wMapPictureBox2.StationDataPath1 = "";
            this.wMapPictureBox2.StationDataPath2 = "";
            this.wMapPictureBox2.TabIndex = 6;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Transparent;
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Controls.Add(this.controlDateTimePickerArea);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(1, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(267, 675);
            this.panel3.TabIndex = 5;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Controls.Add(this.labelX5, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.listBoxFactorArea, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.labelX8, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.listBoxHourArea, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.buttonHourAreaUp, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.buttonHourAreaDown, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.groupPanel2, 0, 5);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(14, 113);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 6;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 149F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(240, 559);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.Class = "";
            this.tableLayoutPanel3.SetColumnSpan(this.labelX5, 2);
            this.labelX5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX5.Location = new System.Drawing.Point(4, 5);
            this.labelX5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(232, 16);
            this.labelX5.TabIndex = 2;
            this.labelX5.Text = "潜势预报产品：";
            // 
            // listBoxFactorArea
            // 
            this.listBoxFactorArea.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel3.SetColumnSpan(this.listBoxFactorArea, 2);
            this.listBoxFactorArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxFactorArea.FormattingEnabled = true;
            this.listBoxFactorArea.ItemHeight = 19;
            this.listBoxFactorArea.Items.AddRange(new object[] {
            "雷暴发生潜势（多指数）",
            "雷暴发生潜势（条件指数）",
            "雷暴大风发生潜势（多指数）",
            "雷暴大风发生潜势（条件指数）",
            "冰雹大风发生潜势（多指数）",
            "冰雹大风发生潜势（条件指数）"});
            this.listBoxFactorArea.Location = new System.Drawing.Point(3, 29);
            this.listBoxFactorArea.Name = "listBoxFactorArea";
            this.listBoxFactorArea.Size = new System.Drawing.Size(234, 156);
            this.listBoxFactorArea.TabIndex = 1;
            // 
            // labelX8
            // 
            // 
            // 
            // 
            this.labelX8.BackgroundStyle.Class = "";
            this.tableLayoutPanel3.SetColumnSpan(this.labelX8, 2);
            this.labelX8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX8.Location = new System.Drawing.Point(4, 193);
            this.labelX8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX8.Name = "labelX8";
            this.labelX8.Size = new System.Drawing.Size(232, 16);
            this.labelX8.TabIndex = 2;
            this.labelX8.Text = "预报时间：";
            // 
            // listBoxHourArea
            // 
            this.listBoxHourArea.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel3.SetColumnSpan(this.listBoxHourArea, 2);
            this.listBoxHourArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHourArea.FormattingEnabled = true;
            this.listBoxHourArea.ItemHeight = 19;
            this.listBoxHourArea.Items.AddRange(new object[] {
            "06小时",
            "12小时",
            "18小时",
            "24小时",
            "30小时",
            "36小时",
            "42小时",
            "48小时",
            "54小时",
            "60小时",
            "66小时",
            "72小时"});
            this.listBoxHourArea.Location = new System.Drawing.Point(3, 217);
            this.listBoxHourArea.Name = "listBoxHourArea";
            this.listBoxHourArea.Size = new System.Drawing.Size(234, 156);
            this.listBoxHourArea.TabIndex = 1;
            // 
            // buttonHourAreaUp
            // 
            this.buttonHourAreaUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHourAreaUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonHourAreaUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHourAreaUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonHourAreaUp.Image")));
            this.buttonHourAreaUp.Location = new System.Drawing.Point(3, 379);
            this.buttonHourAreaUp.Name = "buttonHourAreaUp";
            this.buttonHourAreaUp.Size = new System.Drawing.Size(114, 27);
            this.buttonHourAreaUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonHourAreaUp.TabIndex = 0;
            // 
            // buttonHourAreaDown
            // 
            this.buttonHourAreaDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHourAreaDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonHourAreaDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHourAreaDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonHourAreaDown.Image")));
            this.buttonHourAreaDown.Location = new System.Drawing.Point(123, 379);
            this.buttonHourAreaDown.Name = "buttonHourAreaDown";
            this.buttonHourAreaDown.Size = new System.Drawing.Size(114, 27);
            this.buttonHourAreaDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonHourAreaDown.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.tableLayoutPanel3.SetColumnSpan(this.groupPanel2, 2);
            this.groupPanel2.Controls.Add(this.wLayerManagerControl2);
            this.groupPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupPanel2.Location = new System.Drawing.Point(3, 412);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(234, 144);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.Class = "";
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.Class = "";
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.Class = "";
            this.groupPanel2.TabIndex = 3;
            this.groupPanel2.Text = "图层管理";
            // 
            // wLayerManagerControl2
            // 
            this.wLayerManagerControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wLayerManagerControl2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wLayerManagerControl2.Location = new System.Drawing.Point(0, 0);
            this.wLayerManagerControl2.MapPictureBox = null;
            this.wLayerManagerControl2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wLayerManagerControl2.Name = "wLayerManagerControl2";
            this.wLayerManagerControl2.SelectedLayerID = -1;
            this.wLayerManagerControl2.Size = new System.Drawing.Size(228, 115);
            this.wLayerManagerControl2.TabIndex = 0;
            // 
            // controlDateTimePickerArea
            // 
            this.controlDateTimePickerArea.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlDateTimePickerArea.Location = new System.Drawing.Point(4, 5);
            this.controlDateTimePickerArea.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controlDateTimePickerArea.Name = "controlDateTimePickerArea";
            this.controlDateTimePickerArea.selectedDateTime = new System.DateTime(2015, 7, 21, 8, 0, 0, 0);
            this.controlDateTimePickerArea.Size = new System.Drawing.Size(250, 108);
            this.controlDateTimePickerArea.TabIndex = 0;
            // 
            // tabItem7
            // 
            this.tabItem7.AttachedControl = this.tabControlPanel7;
            this.tabItem7.Image = global::SCWPredictSystem.Properties.Resources.BlogCategoryInsert;
            this.tabItem7.Name = "tabItem7";
            this.tabItem7.Text = "区域分类潜势预报";
            // 
            // tabControlPanel1
            // 
            this.tabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlPanel1.Location = new System.Drawing.Point(0, 41);
            this.tabControlPanel1.Name = "tabControlPanel1";
            this.tabControlPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel1.Size = new System.Drawing.Size(968, 677);
            this.tabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel1.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel1.Style.GradientAngle = 90;
            this.tabControlPanel1.TabIndex = 1;
            this.tabControlPanel1.TabItem = this.tabItem1;
            // 
            // tabItem1
            // 
            this.tabItem1.AttachedControl = this.tabControlPanel1;
            this.tabItem1.Image = global::SCWPredictSystem.Properties.Resources.LookUp;
            this.tabItem1.Name = "tabItem1";
            this.tabItem1.Text = "历史资料查询";
            this.tabItem1.Visible = false;
            // 
            // tabControlPanel4
            // 
            this.tabControlPanel4.Controls.Add(this.wParamsManagerControl1);
            this.tabControlPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel4.Location = new System.Drawing.Point(0, 41);
            this.tabControlPanel4.Name = "tabControlPanel4";
            this.tabControlPanel4.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel4.Size = new System.Drawing.Size(968, 677);
            this.tabControlPanel4.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel4.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel4.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel4.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel4.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel4.Style.GradientAngle = 90;
            this.tabControlPanel4.TabIndex = 4;
            this.tabControlPanel4.TabItem = this.tabItem4;
            // 
            // wParamsManagerControl1
            // 
            this.wParamsManagerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wParamsManagerControl1.ExpandLevel = 0;
            this.wParamsManagerControl1.Location = new System.Drawing.Point(1, 1);
            this.wParamsManagerControl1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.wParamsManagerControl1.Name = "wParamsManagerControl1";
            this.wParamsManagerControl1.RootText = "";
            this.wParamsManagerControl1.SearchingPath = "C:\\";
            this.wParamsManagerControl1.Size = new System.Drawing.Size(966, 675);
            this.wParamsManagerControl1.TabIndex = 0;
            // 
            // tabItem4
            // 
            this.tabItem4.AttachedControl = this.tabControlPanel4;
            this.tabItem4.Image = global::SCWPredictSystem.Properties.Resources.GroupDesign;
            this.tabItem4.Name = "tabItem4";
            this.tabItem4.Text = "系统参数设置";
            // 
            // tabControlPanel3
            // 
            this.tabControlPanel3.Controls.Add(this.tabControl2);
            this.tabControlPanel3.Controls.Add(this.panel2);
            this.tabControlPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel3.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControlPanel3.Location = new System.Drawing.Point(0, 41);
            this.tabControlPanel3.Name = "tabControlPanel3";
            this.tabControlPanel3.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel3.Size = new System.Drawing.Size(968, 677);
            this.tabControlPanel3.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel3.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel3.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel3.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel3.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel3.Style.GradientAngle = 90;
            this.tabControlPanel3.TabIndex = 3;
            this.tabControlPanel3.TabItem = this.tabItem3;
            // 
            // tabControl2
            // 
            this.tabControl2.CanReorderTabs = true;
            this.tabControl2.Controls.Add(this.tabControlPanel5);
            this.tabControl2.Controls.Add(this.tabControlPanel6);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(268, 1);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedTabFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControl2.SelectedTabIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(699, 675);
            this.tabControl2.Style = DevComponents.DotNetBar.eTabStripStyle.Office2007Document;
            this.tabControl2.TabIndex = 6;
            this.tabControl2.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl2.Tabs.Add(this.tabItem5);
            this.tabControl2.Tabs.Add(this.tabItem6);
            this.tabControl2.Text = "tabControl2";
            // 
            // tabControlPanel5
            // 
            this.tabControlPanel5.Controls.Add(this.expandablePanel1);
            this.tabControlPanel5.Controls.Add(this.wTlnPControl1);
            this.tabControlPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel5.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel5.Name = "tabControlPanel5";
            this.tabControlPanel5.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel5.Size = new System.Drawing.Size(699, 650);
            this.tabControlPanel5.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel5.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel5.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel5.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel5.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel5.Style.GradientAngle = 90;
            this.tabControlPanel5.TabIndex = 1;
            this.tabControlPanel5.TabItem = this.tabItem5;
            // 
            // expandablePanel1
            // 
            this.expandablePanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.expandablePanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.expandablePanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.expandablePanel1.Controls.Add(this.tabControl3);
            this.expandablePanel1.Location = new System.Drawing.Point(349, 3);
            this.expandablePanel1.Name = "expandablePanel1";
            this.expandablePanel1.Size = new System.Drawing.Size(348, 424);
            this.expandablePanel1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.Style.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.expandablePanel1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.expandablePanel1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.ItemText;
            this.expandablePanel1.Style.GradientAngle = 90;
            this.expandablePanel1.TabIndex = 1;
            this.expandablePanel1.TitleHeight = 20;
            this.expandablePanel1.TitleStyle.Alignment = System.Drawing.StringAlignment.Center;
            this.expandablePanel1.TitleStyle.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.expandablePanel1.TitleStyle.BackColor2.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.expandablePanel1.TitleStyle.Border = DevComponents.DotNetBar.eBorderType.RaisedInner;
            this.expandablePanel1.TitleStyle.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.expandablePanel1.TitleStyle.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.expandablePanel1.TitleStyle.GradientAngle = 90;
            this.expandablePanel1.TitleText = "信息";
            // 
            // tabControl3
            // 
            this.tabControl3.BackColor = System.Drawing.Color.LightYellow;
            this.tabControl3.CanReorderTabs = true;
            this.tabControl3.Controls.Add(this.tabControlPanel8);
            this.tabControl3.Controls.Add(this.tabControlPanel11);
            this.tabControl3.Controls.Add(this.tabControlPanel12);
            this.tabControl3.Controls.Add(this.tabControlPanel10);
            this.tabControl3.Controls.Add(this.tabControlPanel9);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 20);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedTabFont = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold);
            this.tabControl3.SelectedTabIndex = 3;
            this.tabControl3.Size = new System.Drawing.Size(348, 404);
            this.tabControl3.Style = DevComponents.DotNetBar.eTabStripStyle.RoundHeader;
            this.tabControl3.TabIndex = 0;
            this.tabControl3.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox;
            this.tabControl3.Tabs.Add(this.tabItem8);
            this.tabControl3.Tabs.Add(this.tabItem9);
            this.tabControl3.Tabs.Add(this.tabItem10);
            this.tabControl3.Tabs.Add(this.tabItem11);
            this.tabControl3.Tabs.Add(this.tabItem12);
            this.tabControl3.Text = "tabControl3";
            // 
            // tabControlPanel8
            // 
            this.tabControlPanel8.Controls.Add(this.listViewPotentialLeiBao);
            this.tabControlPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel8.Location = new System.Drawing.Point(0, 30);
            this.tabControlPanel8.Name = "tabControlPanel8";
            this.tabControlPanel8.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel8.Size = new System.Drawing.Size(348, 374);
            this.tabControlPanel8.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel8.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(215)))));
            this.tabControlPanel8.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel8.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControlPanel8.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel8.Style.GradientAngle = 90;
            this.tabControlPanel8.TabIndex = 1;
            this.tabControlPanel8.TabItem = this.tabItem8;
            // 
            // listViewPotentialLeiBao
            // 
            this.listViewPotentialLeiBao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader10});
            this.listViewPotentialLeiBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPotentialLeiBao.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewPotentialLeiBao.GridLines = true;
            this.listViewPotentialLeiBao.Location = new System.Drawing.Point(1, 1);
            this.listViewPotentialLeiBao.MultiSelect = false;
            this.listViewPotentialLeiBao.Name = "listViewPotentialLeiBao";
            this.listViewPotentialLeiBao.Size = new System.Drawing.Size(346, 372);
            this.listViewPotentialLeiBao.TabIndex = 0;
            this.listViewPotentialLeiBao.UseCompatibleStateImageBehavior = false;
            this.listViewPotentialLeiBao.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "单指数";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "多指数";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "条件指数";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabItem8
            // 
            this.tabItem8.AttachedControl = this.tabControlPanel8;
            this.tabItem8.Name = "tabItem8";
            this.tabItem8.Text = "雷暴";
            this.tabItem8.Visible = false;
            // 
            // tabControlPanel11
            // 
            this.tabControlPanel11.Controls.Add(this.m_listViewIndex);
            this.tabControlPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel11.Location = new System.Drawing.Point(0, 30);
            this.tabControlPanel11.Name = "tabControlPanel11";
            this.tabControlPanel11.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel11.Size = new System.Drawing.Size(348, 374);
            this.tabControlPanel11.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel11.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(215)))));
            this.tabControlPanel11.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel11.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControlPanel11.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel11.Style.GradientAngle = 90;
            this.tabControlPanel11.TabIndex = 4;
            this.tabControlPanel11.TabItem = this.tabItem11;
            // 
            // m_listViewIndex
            // 
            this.m_listViewIndex.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader13,
            this.columnHeader14});
            this.m_listViewIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listViewIndex.GridLines = true;
            this.m_listViewIndex.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14});
            this.m_listViewIndex.Location = new System.Drawing.Point(1, 1);
            this.m_listViewIndex.Name = "m_listViewIndex";
            this.m_listViewIndex.Size = new System.Drawing.Size(346, 372);
            this.m_listViewIndex.TabIndex = 0;
            this.m_listViewIndex.UseCompatibleStateImageBehavior = false;
            this.m_listViewIndex.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "指数";
            this.columnHeader13.Width = 208;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "值";
            this.columnHeader14.Width = 133;
            // 
            // tabItem11
            // 
            this.tabItem11.AttachedControl = this.tabControlPanel11;
            this.tabItem11.Name = "tabItem11";
            this.tabItem11.Text = "14Index";
            // 
            // tabControlPanel12
            // 
            this.tabControlPanel12.Controls.Add(this.m_listViewParas);
            this.tabControlPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel12.Location = new System.Drawing.Point(0, 30);
            this.tabControlPanel12.Name = "tabControlPanel12";
            this.tabControlPanel12.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel12.Size = new System.Drawing.Size(348, 374);
            this.tabControlPanel12.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel12.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(215)))));
            this.tabControlPanel12.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel12.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControlPanel12.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel12.Style.GradientAngle = 90;
            this.tabControlPanel12.TabIndex = 5;
            this.tabControlPanel12.TabItem = this.tabItem12;
            // 
            // m_listViewParas
            // 
            this.m_listViewParas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17});
            this.m_listViewParas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.m_listViewParas.GridLines = true;
            this.m_listViewParas.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem15,
            listViewItem16,
            listViewItem17});
            this.m_listViewParas.Location = new System.Drawing.Point(1, 1);
            this.m_listViewParas.Name = "m_listViewParas";
            this.m_listViewParas.Size = new System.Drawing.Size(346, 372);
            this.m_listViewParas.TabIndex = 1;
            this.m_listViewParas.UseCompatibleStateImageBehavior = false;
            this.m_listViewParas.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "分类";
            this.columnHeader15.Width = 98;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "多指数";
            this.columnHeader16.Width = 113;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "条件指数";
            this.columnHeader17.Width = 116;
            // 
            // tabItem12
            // 
            this.tabItem12.AttachedControl = this.tabControlPanel12;
            this.tabItem12.Name = "tabItem12";
            this.tabItem12.Text = "2Params";
            // 
            // tabControlPanel10
            // 
            this.tabControlPanel10.Controls.Add(this.listViewPotentialBinBao);
            this.tabControlPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel10.Location = new System.Drawing.Point(0, 30);
            this.tabControlPanel10.Name = "tabControlPanel10";
            this.tabControlPanel10.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel10.Size = new System.Drawing.Size(348, 374);
            this.tabControlPanel10.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel10.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(215)))));
            this.tabControlPanel10.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel10.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControlPanel10.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel10.Style.GradientAngle = 90;
            this.tabControlPanel10.TabIndex = 3;
            this.tabControlPanel10.TabItem = this.tabItem10;
            // 
            // listViewPotentialBinBao
            // 
            this.listViewPotentialBinBao.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader12});
            this.listViewPotentialBinBao.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPotentialBinBao.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewPotentialBinBao.GridLines = true;
            this.listViewPotentialBinBao.Location = new System.Drawing.Point(1, 1);
            this.listViewPotentialBinBao.MultiSelect = false;
            this.listViewPotentialBinBao.Name = "listViewPotentialBinBao";
            this.listViewPotentialBinBao.Size = new System.Drawing.Size(346, 372);
            this.listViewPotentialBinBao.TabIndex = 1;
            this.listViewPotentialBinBao.UseCompatibleStateImageBehavior = false;
            this.listViewPotentialBinBao.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "单指数";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "多指数";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "条件指数";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabItem10
            // 
            this.tabItem10.AttachedControl = this.tabControlPanel10;
            this.tabItem10.Name = "tabItem10";
            this.tabItem10.Text = "冰雹";
            this.tabItem10.Visible = false;
            // 
            // tabControlPanel9
            // 
            this.tabControlPanel9.Controls.Add(this.listViewPotentialDaFeng);
            this.tabControlPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel9.Location = new System.Drawing.Point(0, 30);
            this.tabControlPanel9.Name = "tabControlPanel9";
            this.tabControlPanel9.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel9.Size = new System.Drawing.Size(348, 374);
            this.tabControlPanel9.Style.BackColor1.Color = System.Drawing.Color.White;
            this.tabControlPanel9.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(233)))), ((int)(((byte)(215)))));
            this.tabControlPanel9.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel9.Style.BorderColor.Color = System.Drawing.SystemColors.ControlDarkDark;
            this.tabControlPanel9.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel9.Style.GradientAngle = 90;
            this.tabControlPanel9.TabIndex = 2;
            this.tabControlPanel9.TabItem = this.tabItem9;
            // 
            // listViewPotentialDaFeng
            // 
            this.listViewPotentialDaFeng.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader11});
            this.listViewPotentialDaFeng.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPotentialDaFeng.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listViewPotentialDaFeng.GridLines = true;
            this.listViewPotentialDaFeng.Location = new System.Drawing.Point(1, 1);
            this.listViewPotentialDaFeng.MultiSelect = false;
            this.listViewPotentialDaFeng.Name = "listViewPotentialDaFeng";
            this.listViewPotentialDaFeng.Size = new System.Drawing.Size(346, 372);
            this.listViewPotentialDaFeng.TabIndex = 1;
            this.listViewPotentialDaFeng.UseCompatibleStateImageBehavior = false;
            this.listViewPotentialDaFeng.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "单指数";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 62;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "多指数";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "条件指数";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabItem9
            // 
            this.tabItem9.AttachedControl = this.tabControlPanel9;
            this.tabItem9.Name = "tabItem9";
            this.tabItem9.Text = "雷暴大风";
            this.tabItem9.Visible = false;
            // 
            // wTlnPControl1
            // 
            this.wTlnPControl1.BlankBottom = 30;
            this.wTlnPControl1.BlankLeft = 50;
            this.wTlnPControl1.BlankRight = 50;
            this.wTlnPControl1.BlankTop = 50;
            this.wTlnPControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wTlnPControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wTlnPControl1.Location = new System.Drawing.Point(1, 1);
            this.wTlnPControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wTlnPControl1.Name = "wTlnPControl1";
            this.wTlnPControl1.PicBackColor = System.Drawing.Color.LightYellow;
            this.wTlnPControl1.PicTitle = "温度压力对数图";
            this.wTlnPControl1.ShowCJLine = true;
            this.wTlnPControl1.ShowEnageArea = true;
            this.wTlnPControl1.ShowQsIsoLine = true;
            this.wTlnPControl1.ShowSitaIsoLine = true;
            this.wTlnPControl1.ShowSitaSeIsoLine = true;
            this.wTlnPControl1.ShowStatusLine = true;
            this.wTlnPControl1.Size = new System.Drawing.Size(697, 648);
            this.wTlnPControl1.TabIndex = 0;
            // 
            // tabItem5
            // 
            this.tabItem5.AttachedControl = this.tabControlPanel5;
            this.tabItem5.Image = global::SCWPredictSystem.Properties.Resources.TlnP;
            this.tabItem5.Name = "tabItem5";
            this.tabItem5.Text = "T-lnP图";
            // 
            // tabControlPanel6
            // 
            this.tabControlPanel6.Controls.Add(this.wWindRoseControl1);
            this.tabControlPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlPanel6.Location = new System.Drawing.Point(0, 25);
            this.tabControlPanel6.Name = "tabControlPanel6";
            this.tabControlPanel6.Padding = new System.Windows.Forms.Padding(1);
            this.tabControlPanel6.Size = new System.Drawing.Size(699, 650);
            this.tabControlPanel6.Style.BackColor1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(253)))), ((int)(((byte)(254)))));
            this.tabControlPanel6.Style.BackColor2.Color = System.Drawing.Color.FromArgb(((int)(((byte)(157)))), ((int)(((byte)(188)))), ((int)(((byte)(227)))));
            this.tabControlPanel6.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.tabControlPanel6.Style.BorderColor.Color = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(165)))), ((int)(((byte)(199)))));
            this.tabControlPanel6.Style.BorderSide = ((DevComponents.DotNetBar.eBorderSide)(((DevComponents.DotNetBar.eBorderSide.Left | DevComponents.DotNetBar.eBorderSide.Right) 
            | DevComponents.DotNetBar.eBorderSide.Bottom)));
            this.tabControlPanel6.Style.GradientAngle = 90;
            this.tabControlPanel6.TabIndex = 2;
            this.tabControlPanel6.TabItem = this.tabItem6;
            // 
            // wWindRoseControl1
            // 
            this.wWindRoseControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wWindRoseControl1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.wWindRoseControl1.Location = new System.Drawing.Point(1, 1);
            this.wWindRoseControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.wWindRoseControl1.Name = "wWindRoseControl1";
            this.wWindRoseControl1.PicBackColor = System.Drawing.Color.LightYellow;
            this.wWindRoseControl1.PicTitle = "风向风速玫瑰图";
            this.wWindRoseControl1.Size = new System.Drawing.Size(697, 648);
            this.wWindRoseControl1.TabIndex = 5;
            // 
            // tabItem6
            // 
            this.tabItem6.AttachedControl = this.tabControlPanel6;
            this.tabItem6.Image = global::SCWPredictSystem.Properties.Resources.WindRose;
            this.tabItem6.Name = "tabItem6";
            this.tabItem6.Text = "风玫瑰图";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.controlDateTimePickerStation);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(1, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(267, 675);
            this.panel2.TabIndex = 4;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.labelX4, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.treeViewStation, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelX6, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.listBoxHourStation, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.buttonHourStationUp, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.buttonHourStationDown, 1, 4);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(14, 113);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 5;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(240, 548);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.Class = "";
            this.tableLayoutPanel2.SetColumnSpan(this.labelX4, 2);
            this.labelX4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX4.Location = new System.Drawing.Point(4, 5);
            this.labelX4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(232, 16);
            this.labelX4.TabIndex = 2;
            this.labelX4.Text = "重要站点：";
            // 
            // treeViewStation
            // 
            this.treeViewStation.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel2.SetColumnSpan(this.treeViewStation, 2);
            this.treeViewStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewStation.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.treeViewStation.HideSelection = false;
            this.treeViewStation.HotTracking = true;
            this.treeViewStation.ImageIndex = 0;
            this.treeViewStation.ImageList = this.imageList1;
            this.treeViewStation.Location = new System.Drawing.Point(3, 29);
            this.treeViewStation.Name = "treeViewStation";
            treeNode1.ImageIndex = 1;
            treeNode1.Name = "STATION";
            treeNode1.SelectedImageIndex = 1;
            treeNode1.Tag = "32.0,118.48";
            treeNode1.Text = "南京";
            treeNode2.ImageIndex = 1;
            treeNode2.Name = "STATION";
            treeNode2.SelectedImageIndex = 1;
            treeNode2.Tag = "26.05,119.17";
            treeNode2.Text = "福州";
            treeNode3.ImageIndex = 1;
            treeNode3.Name = "STATION";
            treeNode3.SelectedImageIndex = 1;
            treeNode3.Tag = "24.29,118.04";
            treeNode3.Text = "厦门";
            treeNode4.ImageIndex = 1;
            treeNode4.Name = "STATION";
            treeNode4.SelectedImageIndex = 1;
            treeNode4.Tag = "24.3,117.39";
            treeNode4.Text = "漳州";
            treeNode5.ImageIndex = 1;
            treeNode5.Name = "STATION";
            treeNode5.SelectedImageIndex = 1;
            treeNode5.Tag = "31.52,117.14";
            treeNode5.Text = "合肥";
            treeNode6.ImageIndex = 1;
            treeNode6.Name = "STATION";
            treeNode6.SelectedImageIndex = 1;
            treeNode6.Tag = "28.36,115.55";
            treeNode6.Text = "南昌";
            treeNode7.ImageIndex = 1;
            treeNode7.Name = "STATION";
            treeNode7.SelectedImageIndex = 1;
            treeNode7.Tag = "30.14,120.10";
            treeNode7.Text = "杭州";
            treeNode8.ImageIndex = 1;
            treeNode8.Name = "STATION";
            treeNode8.SelectedImageIndex = 1;
            treeNode8.Tag = "34.17,117.09";
            treeNode8.Text = "徐州";
            treeNode9.ImageIndex = 1;
            treeNode9.Name = "STATION";
            treeNode9.SelectedImageIndex = 1;
            treeNode9.Tag = "33.46,120.15";
            treeNode9.Text = "射阳";
            treeNode10.Name = "ROOT";
            treeNode10.Text = "战区重要站点列表";
            this.treeViewStation.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode10});
            this.treeViewStation.SelectedImageIndex = 0;
            this.treeViewStation.Size = new System.Drawing.Size(234, 268);
            this.treeViewStation.TabIndex = 2;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "BlogOpenExisting.png");
            this.imageList1.Images.SetKeyName(1, "FileAddDigitalSignature.png");
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.Class = "";
            this.tableLayoutPanel2.SetColumnSpan(this.labelX6, 2);
            this.labelX6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelX6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelX6.Location = new System.Drawing.Point(4, 305);
            this.labelX6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(232, 16);
            this.labelX6.TabIndex = 2;
            this.labelX6.Text = "预报时间：";
            // 
            // listBoxHourStation
            // 
            this.listBoxHourStation.BackColor = System.Drawing.Color.LemonChiffon;
            this.tableLayoutPanel2.SetColumnSpan(this.listBoxHourStation, 2);
            this.listBoxHourStation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxHourStation.FormattingEnabled = true;
            this.listBoxHourStation.ItemHeight = 19;
            this.listBoxHourStation.Items.AddRange(new object[] {
            "06小时",
            "12小时",
            "18小时",
            "24小时",
            "30小时",
            "36小时",
            "42小时",
            "48小时",
            "54小时",
            "60小时",
            "66小时",
            "72小时"});
            this.listBoxHourStation.Location = new System.Drawing.Point(3, 329);
            this.listBoxHourStation.Name = "listBoxHourStation";
            this.listBoxHourStation.Size = new System.Drawing.Size(234, 177);
            this.listBoxHourStation.TabIndex = 1;
            // 
            // buttonHourStationUp
            // 
            this.buttonHourStationUp.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHourStationUp.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonHourStationUp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHourStationUp.Image = global::SCWPredictSystem.Properties.Resources.MoveUp;
            this.buttonHourStationUp.Location = new System.Drawing.Point(3, 512);
            this.buttonHourStationUp.Name = "buttonHourStationUp";
            this.buttonHourStationUp.Size = new System.Drawing.Size(114, 33);
            this.buttonHourStationUp.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonHourStationUp.TabIndex = 0;
            this.buttonHourStationUp.Click += new System.EventHandler(this.buttonHourStationUp_Click);
            // 
            // buttonHourStationDown
            // 
            this.buttonHourStationDown.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonHourStationDown.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonHourStationDown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonHourStationDown.Image = global::SCWPredictSystem.Properties.Resources.MoveDown;
            this.buttonHourStationDown.Location = new System.Drawing.Point(123, 512);
            this.buttonHourStationDown.Name = "buttonHourStationDown";
            this.buttonHourStationDown.Size = new System.Drawing.Size(114, 33);
            this.buttonHourStationDown.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonHourStationDown.TabIndex = 0;
            this.buttonHourStationDown.Click += new System.EventHandler(this.buttonHourStationDown_Click);
            // 
            // controlDateTimePickerStation
            // 
            this.controlDateTimePickerStation.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.controlDateTimePickerStation.Location = new System.Drawing.Point(4, 5);
            this.controlDateTimePickerStation.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controlDateTimePickerStation.Name = "controlDateTimePickerStation";
            this.controlDateTimePickerStation.selectedDateTime = new System.DateTime(2015, 7, 21, 8, 0, 0, 0);
            this.controlDateTimePickerStation.Size = new System.Drawing.Size(250, 108);
            this.controlDateTimePickerStation.TabIndex = 1;
            // 
            // tabItem3
            // 
            this.tabItem3.AttachedControl = this.tabControlPanel3;
            this.tabItem3.Image = global::SCWPredictSystem.Properties.Resources.ChartDepthGridlines;
            this.tabItem3.Name = "tabItem3";
            this.tabItem3.Text = "重要站点分类潜势预报";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(992, 742);
            this.Controls.Add(this.tabControl1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "东南沿海地区强对流天气分类潜势预报系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl1)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabControlPanel13.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.groupPanel3.ResumeLayout(false);
            this.tabControlPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupPanel1.ResumeLayout(false);
            this.tabControlPanel7.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.groupPanel2.ResumeLayout(false);
            this.tabControlPanel4.ResumeLayout(false);
            this.tabControlPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl2)).EndInit();
            this.tabControl2.ResumeLayout(false);
            this.tabControlPanel5.ResumeLayout(false);
            this.expandablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tabControl3)).EndInit();
            this.tabControl3.ResumeLayout(false);
            this.tabControlPanel8.ResumeLayout(false);
            this.tabControlPanel11.ResumeLayout(false);
            this.tabControlPanel12.ResumeLayout(false);
            this.tabControlPanel10.ResumeLayout(false);
            this.tabControlPanel9.ResumeLayout(false);
            this.tabControlPanel6.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.TabControl tabControl1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel1;
        private DevComponents.DotNetBar.TabItem tabItem1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel3;
        private DevComponents.DotNetBar.TabItem tabItem3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel2;
        private DevComponents.DotNetBar.TabItem tabItem2;
        private wMetroGIS.wTlnP.wTlnPControl wTlnPControl1;
        private wMetroGIS.wMapPictureBoxControl.wMapPictureBox wMapPictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private controlDateTimePicker controlDateTimePickerMM5;
        private System.Windows.Forms.ListBox listBoxLevelMM5;
        private System.Windows.Forms.ListBox listBoxHourMM5;
        private System.Windows.Forms.ListBox listBoxFactorMM5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX buttonLevelMM5Down;
        private DevComponents.DotNetBar.ButtonX buttonLevelMM5Up;
        private DevComponents.DotNetBar.ButtonX buttonHourMM5Up;
        private DevComponents.DotNetBar.ButtonX buttonHourMM5Down;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel4;
        private DevComponents.DotNetBar.TabItem tabItem4;
        private wMetroGIS.wParams.wParamsManagerControl wParamsManagerControl1;
        private wMetroGIS.wLayers.wLayerManagerControl wLayerManagerControl1;
        private controlDateTimePicker controlDateTimePickerStation;
        private System.Windows.Forms.TreeView treeViewStation;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private wMetroGIS.wTlnP.wWindRoseControl wWindRoseControl1;
        private DevComponents.DotNetBar.TabControl tabControl2;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel6;
        private DevComponents.DotNetBar.TabItem tabItem6;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel5;
        private DevComponents.DotNetBar.TabItem tabItem5;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.LabelX labelX6;
        private System.Windows.Forms.ListBox listBoxHourStation;
        private DevComponents.DotNetBar.ButtonX buttonHourStationUp;
        private DevComponents.DotNetBar.ButtonX buttonHourStationDown;
        private System.Windows.Forms.ImageList imageList1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private DevComponents.DotNetBar.LabelX labelX5;
        private System.Windows.Forms.ListBox listBoxFactorArea;
        private DevComponents.DotNetBar.LabelX labelX8;
        private System.Windows.Forms.ListBox listBoxHourArea;
        private DevComponents.DotNetBar.ButtonX buttonHourAreaUp;
        private DevComponents.DotNetBar.ButtonX buttonHourAreaDown;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private wMetroGIS.wLayers.wLayerManagerControl wLayerManagerControl2;
        private controlDateTimePicker controlDateTimePickerArea;
        private DevComponents.DotNetBar.TabItem tabItem7;
        private wMetroGIS.wMapPictureBoxControl.wMapPictureBox wMapPictureBox2;
        private DevComponents.DotNetBar.TabControl tabControl3;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel8;
        private System.Windows.Forms.ListView listViewPotentialLeiBao;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private DevComponents.DotNetBar.TabItem tabItem8;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel9;
        private DevComponents.DotNetBar.TabItem tabItem9;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel10;
        private DevComponents.DotNetBar.TabItem tabItem10;
        private System.Windows.Forms.ListView listViewPotentialBinBao;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.ListView listViewPotentialDaFeng;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private DevComponents.DotNetBar.ExpandablePanel expandablePanel1;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel12;
        private System.Windows.Forms.ListView m_listViewParas;
        private DevComponents.DotNetBar.TabItem tabItem12;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel11;
        private System.Windows.Forms.ListView m_listViewIndex;
        private DevComponents.DotNetBar.TabItem tabItem11;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader17;
        private DevComponents.DotNetBar.TabControlPanel tabControlPanel13;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private DevComponents.DotNetBar.LabelX labelX7;
        private System.Windows.Forms.ListBox listBoxFactorSurf;
        private DevComponents.DotNetBar.LabelX labelX9;
        private System.Windows.Forms.ListBox listBoxHourSurf;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel3;
        private wMetroGIS.wLayers.wLayerManagerControl wLayerManagerControl3;
        private controlDateTimePicker controlDateTimePickerSurf;
        private DevComponents.DotNetBar.TabItem tabItem13;
        private wMetroGIS.wMapPictureBoxControl.wMapPictureBox wMapPictureBox3;



    }
}

