using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using DevComponents.DotNetBar;
using wMetroGIS.wDataObject;
using wMetroGIS.wDataReader;
using wMetroGIS.wMathmatics;
using wMetroGIS.wParams;
using wMetroGIS.wMapPictureBoxControl;
using wMetroGIS.wLayers;
using wMetroGIS.wMapMask;
using System.Configuration;

namespace SCWPredictSystem
{
    public partial class MainForm : Office2007Form
    {
        //第五代中尺度模式 MM5
        private const double DefaultValue = -9999;
        private const int RowNum = 272;
        private const int ColNum = 302;
        private long BlockSizeS = RowNum * ColNum * 4;
        private long BlockSizeB = RowNum * ColNum * 4 * 156;
        ////
        //private int[] mm5_factor_level = new int[] { 1, 1, 1, 1, 1, 21, 21, 21, 21, 21, 1, 21, 21, 1, 1, 1 };
        ////
        //private int[] mm5_factor_pos = new int[] { 0, 1, 2, 3, 4, 5, 26, 47, 68, 89, 110, 111, 132, 153, 154, 155 };
        //
        private int[] mm5_factor_level = new int[] { 21, 21, 1, 1, 1, 1, 1, 21, 21, 21, 21, 21, 1, 1, 1, 1 };
        //
        private int[] mm5_factor_pos = new int[] { 0, 21, 42, 43, 44, 45, 46, 67, 88, 109, 130, 151, 152, 153, 154, 155 };
        //
        private double[] mm5_level = new double[] { 1000, 975, 950, 925, 900, 850, 800, 750, 700, 650, 600, 550, 500, 450, 400, 350, 300, 250, 200, 150, 100 };

        //private enum MM5_FACTOR //16
        //{
        //    T2 = 0,    //   1      0  TEMP at 2 M (K)
        //    RAINC,     //   1      1  ACCUMULATED TOTAL CUMULUS PRECIPITATION (mm)
        //    RAINNC,    //   1      2  ACCUMULATED TOTAL GRID SCALE PRECIPITATION (mm)
        //    XLAT,      //   1      3  LATITUDE, SOUTH IS NEGATIVE (degree_north)
        //    XLONG,     //   1      4  LONGITUDE, WEST IS NEGATIVE (degree_east)
        //    geopt,     //  21      5  Geopotential (m2/s2)
        //    height,    //  21     26  Model height (km)
        //    tc,        //  21     47  Temperature (C)
        //    td,        //  21     68  Dewpoint Temperature (C)
        //    rh,        //  21     89  Relative Humidity (%)
        //    rh2,       //   1    110  Relative Humidity at 2m (%)
        //    umet,      //  21    111  Rotated wind component (m s-1)
        //    vmet,      //  21    132  Rotated wind component (m s-1)
        //    u10m,      //   1    153  Rotated wind component (m s-1)
        //    v10m,      //   1    154  Rotated wind component (m s-1) 
        //    slp        //   1    155  Sea Levelp Pressure (hPa)
        //}

        private enum MM5_FACTOR //16
        {
            U,
            V,
            T2,//   1      0  TEMP at 2 M (K)
            RAINC,     //   1      1  ACCUMULATED TOTAL CUMULUS PRECIPITATION (mm)
            RAINNC,    //   1      2  ACCUMULATED TOTAL GRID SCALE PRECIPITATION (mm)
            XLAT,      //   1      3  LATITUDE, SOUTH IS NEGATIVE (degree_north)
            XLONG,     //   1      4  LONGITUDE, WEST IS NEGATIVE (degree_east)
            pressure,    //  21     26  Model height (km)
            height,
            tc,        //  21     47  Temperature (C)
            td,        //  21     68  Dewpoint Temperature (C)
            rh,        //  21     89  Relative Humidity (%)
            rh2,       //   1    110  Relative Humidity at 2m (%)
            u10m,      //   1    153  Rotated wind component (m s-1)
            v10m,      //   1    154  Rotated wind component (m s-1) 
            slp        //   1    155  Sea Levelp Pressure (hPa)
        }

        private enum MM5_LEVEL //21
        {
            GK1000HPA,
            GK975HPA,
            GK950HPA,
            GK925HPA,
            GK900HPA,
            GK850HPA,
            GK800HPA,
            GK750HPA,
            GK700HPA,
            GK650HPA,
            GK600HPA,
            GK550HPA,
            GK500HPA,
            GK450HPA,
            GK400HPA,
            GK350HPA,
            GK300HPA,
            GK250HPA,
            GK200HPA,
            GK150HPA,
            GK100HPA
        }
        private enum MM5_HOUR
        {
            HR00 = 0,
            HR06,
            HR12,
            HR18,
            HR24,
            HR30,
            HR36,
            HR42,
            HR48,
            HR54,
            HR60,
            HR66,
            HR72
        }
        //保存每个点的经度纬度
        private double[] m_Longitude = new double[RowNum * ColNum];
        private double[] m_Latitude = new double[RowNum * ColNum];

        //潜势
        private enum POTENTIAL_FACTOR
        {
            LEIBAO_SINGLE_INDEX = 0,
            LEIBAO_MULTI_INDEX,
            LEIBAO_CONDITION_INDEX,
            DAFENG_SINGLE_INDEX,
            DAFENG_MULTI_INDEX,
            DAFENG_CONDITION_INDEX,
            BINBAO_SINGLE_INDEX,
            BINBAO_MULTI_INDEX,
            BINBAO_CONDITION_INDEX
        }
        private enum POTENTIAL_HOUR
        {
            HR06 = 0,
            HR12,
            HR18,
            HR24,
            HR30,
            HR36,
            HR42,
            HR48,
            HR54,
            HR60,
            HR66,
            HR72
        }
        private string[] potential_name = { "CAPE", "CIN", "LI", "SI", "SSI", "BRN", "BRNSHR", "AI", "KI", "SWEAT", "FF75", "FF52" };

        public MainForm()
        {
            InitializeComponent();

            //从文件读取经纬度
            FileStream fs = new FileStream(Application.StartupPath + "\\AppData\\GridPosition.dat", FileMode.Open, FileAccess.Read);
            BinaryReader br = new BinaryReader(fs);
            for (int i = 0; i < m_Longitude.Length; i++)
            {
                m_Longitude[i] = br.ReadDouble();
                m_Latitude[i] = br.ReadDouble();
            }
            br.Close();
            fs.Close();

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //激活地图控件并开始绘图（这几句的顺序不能打乱）
            MapParams mapParams1 = new MapParams(Application.StartupPath + "\\ParamsData\\东南沿海地图.mst");
            MapParams mapParams2 = new MapParams(Application.StartupPath + "\\ParamsData\\南京战区地图.mst");
            //wMapPictureBox1.SetThumbPictureBoxControl(wMapThumbPictureBox1);
            wMapPictureBox1.InitializeMapControl(mapParams1);
            wMapPictureBox1.DrawMap();
            wMapPictureBox1.ThumbPictureBox.InitializeThumbMapControl();
            wMapPictureBox2.InitializeMapControl(mapParams2);
            wMapPictureBox2.DrawMap();
            wMapPictureBox2.ThumbPictureBox.InitializeThumbMapControl();
            //设置地图控制
            wMapPictureBox1.MouseStatus = wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SCRACH;
            wMapPictureBox1.ShowColorBar = false;
            wMapPictureBox1.ShowMapTitle = false;
            wMapPictureBox1.ShowMousePosition = true;
            wMapPictureBox1.ShowToolStripButtonMouseNormal = false;
            wMapPictureBox1.ShowToolStripButtonMouseScrach = true;
            wMapPictureBox1.ShowToolStripButtonMouseSelectArea = false;
            wMapPictureBox1.ShowToolStripButtonMouseSelectPoint = true;
            wMapPictureBox1.ShowToolStripButtonZoom = true;
            wMapPictureBox1.ShowToolStripButtonAutoZoom = true;
            wMapPictureBox1.ShowToolStripButtonRefresh = true;
            wMapPictureBox1.ShowToolStripButtonSavePicture = true;
            wMapPictureBox1.ShowToolStripButtonSetParams = true;
            wMapPictureBox1.ShowToolStripButtonShowStation = true;
            wMapPictureBox1.ShowToolStripButtonShowColorBar = true;
            wMapPictureBox1.ShowToolStripButtonShowTitle = true;
            wMapPictureBox2.MouseStatus = wMapPictureBox.MOUSE_STATUS.MOUSE_STATUS_SCRACH;
            wMapPictureBox2.ShowColorBar = false;
            wMapPictureBox2.ShowMapTitle = false;
            wMapPictureBox2.ShowMousePosition = true;
            wMapPictureBox2.ShowToolStripButtonMouseNormal = false;
            wMapPictureBox2.ShowToolStripButtonMouseScrach = true;
            wMapPictureBox2.ShowToolStripButtonMouseSelectArea = false;
            wMapPictureBox2.ShowToolStripButtonMouseSelectPoint = true;
            wMapPictureBox2.ShowToolStripButtonZoom = true;
            wMapPictureBox2.ShowToolStripButtonAutoZoom = true;
            wMapPictureBox2.ShowToolStripButtonRefresh = true;
            wMapPictureBox2.ShowToolStripButtonSavePicture = true;
            wMapPictureBox2.ShowToolStripButtonSetParams = true;
            wMapPictureBox2.ShowToolStripButtonShowStation = true;
            wMapPictureBox2.ShowToolStripButtonShowColorBar = true;
            wMapPictureBox2.ShowToolStripButtonShowTitle = true;
            //设置图层管理器
            wLayerManagerControl1.SetDrawingMapControl(wMapPictureBox1);
            wLayerManagerControl2.SetDrawingMapControl(wMapPictureBox2);
            //设置站点
            treeViewStation.Nodes[0].Nodes.Clear();
            for (int i = 0; i < wMapPictureBox2.m_StationIDList1.Count; i++)
            {
                TreeNode newNode = new TreeNode(string.Format("{0} {1}", wMapPictureBox2.m_StationIDList1[i], wMapPictureBox2.m_StationNameList1[i]), 1, 1);
                newNode.Name = "STATION";
                PointF pt = wMapPictureBox2.m_StationPositionList1[i];
                double minDis = double.MaxValue;
                int index = -1;
                for (int j = 0; j < m_Longitude.Length; j++)
                {
                    double dis = (pt.X - m_Longitude[j]) * (pt.X - m_Longitude[j]) + (pt.Y - m_Latitude[j]) * (pt.Y - m_Latitude[j]);
                    if (dis < minDis)
                    {
                        minDis = dis;
                        index = j;
                    }
                }
                newNode.Tag = index;
                treeViewStation.Nodes[0].Nodes.Add(newNode);
            }
            treeViewStation.ExpandAll();
            //设置站点潜势列表
            listViewPotentialLeiBao.Items.Clear();
            for (int i = 0; i < potential_name.Length; i++)
            {
                ListViewItem newItem = new ListViewItem(potential_name[i]);
                newItem.SubItems.Add("-");
                newItem.SubItems.Add("-");
                newItem.SubItems.Add("-");
                listViewPotentialLeiBao.Items.Add(newItem);
            }
            listViewPotentialDaFeng.Items.Clear();
            for (int i = 0; i < potential_name.Length; i++)
            {
                ListViewItem newItem = new ListViewItem(potential_name[i]);
                newItem.SubItems.Add("-");
                newItem.SubItems.Add("-");
                newItem.SubItems.Add("-");
                listViewPotentialDaFeng.Items.Add(newItem);
            }
            listViewPotentialBinBao.Items.Clear();
            for (int i = 0; i < potential_name.Length; i++)
            {
                ListViewItem newItem = new ListViewItem(potential_name[i]);
                newItem.SubItems.Add("-");
                newItem.SubItems.Add("-");
                newItem.SubItems.Add("-");
                listViewPotentialBinBao.Items.Add(newItem);
            }
            //其它控件
            wParamsManagerControl1.SearchingPath = Application.StartupPath + "\\ParamsData";
            wParamsManagerControl1.SearchParams();

            //时间绑定
            listBoxFactorMM5.SelectedIndex = 0;
            listBoxLevelMM5.SelectedIndex = 0;
            listBoxHourMM5.SelectedIndex = 0;
            listBoxFactorMM5.SelectedValueChanged += new EventHandler(MM5TimeFactorLevelHour_SelectedIndexChanged);
            listBoxLevelMM5.SelectedValueChanged += new EventHandler(MM5TimeFactorLevelHour_SelectedIndexChanged);
            listBoxHourMM5.SelectedValueChanged += new EventHandler(MM5TimeFactorLevelHour_SelectedIndexChanged);
            //todo:要修改回来
            //controlDateTimePickerMM5.selectedDateTime = DateTime.Now;
            controlDateTimePickerMM5.DateTimeChanged += new EventHandler(MM5TimeFactorLevelHour_SelectedIndexChanged);

            listBoxFactorArea.SelectedIndex = 0;
            listBoxHourArea.SelectedIndex = 0;
            listBoxFactorArea.SelectedIndexChanged += new EventHandler(AreaTimeFactorhOUR_SelectedIndexChanged);
            listBoxHourArea.SelectedIndexChanged += new EventHandler(AreaTimeFactorhOUR_SelectedIndexChanged);
            //todo:要修改回来
            //controlDateTimePickerArea.selectedDateTime = DateTime.Now;
            controlDateTimePickerArea.DateTimeChanged += new EventHandler(AreaTimeFactorhOUR_SelectedIndexChanged);

            listBoxHourStation.SelectedIndex = 0;
            listBoxHourStation.SelectedValueChanged += new EventHandler(StationTimeStationHour_SelectedValueChanged);
            //todo:要修改回来
            //controlDateTimePickerStation.selectedDateTime = DateTime.Now;
            controlDateTimePickerStation.DateTimeChanged += new EventHandler(StationTimeStationHour_SelectedValueChanged);
            treeViewStation.AfterSelect += new TreeViewEventHandler(treeViewStation_AfterSelect);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            //DataTable dt = ReadPotentialData(DateTime.Now, POTENTIAL_FACTOR.BENBAO_CONDITION_INDEX, POTENTIAL_HOUR.HR72);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataPathName"></param>
        /// <param name="factor"></param>
        /// <param name="level"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        private double[] ReadMM5Data(string dataPathName, MM5_FACTOR factor, MM5_LEVEL level = MM5_LEVEL.GK1000HPA, MM5_HOUR time = MM5_HOUR.HR00)
        {
            FileStream fs = null;
            BinaryReader br = null;
            try
            {
                //打开文件
                fs = new FileStream(dataPathName, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs, Encoding.BigEndianUnicode);
                //计算数据存放位置
                long posD = BlockSizeB * (int)time + BlockSizeS * mm5_factor_pos[(int)factor];
                if (mm5_factor_level[(int)factor] != 1)
                    posD += BlockSizeS * (int)level;
                //读取数据
                fs.Seek(posD, SeekOrigin.Begin);
                double[] dataD = DataReader.ReadBigEndianFloatBlockToDouble(br, RowNum, ColNum);
                br.Close();
                fs.Close();
                //整理数据
                RegularMM5Data(dataD, factor);
                return dataD;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (br != null)
                br.Close();
            if (fs != null)
                fs.Close();
            return null;
        }

        private void RegularMM5Data(double[] data, MM5_FACTOR factor)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] > 99999)
                    data[i] = DefaultValue;
            }
            if (factor == MM5_FACTOR.T2)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != DefaultValue)
                        data[i] -= Mathmatics.AbsoluteZero;
                }
            }
            else if (factor == MM5_FACTOR.height)
            {
                for (int i = 0; i < data.Length; i++)
                {
                    if (data[i] != DefaultValue)
                        data[i] = data[i] * 100;
                }
            }
        }


        /// <summary>
        /// 获取12个指数的DataTable
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="factor"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        private DataTable ReadPotentialData(DateTime datetime, POTENTIAL_FACTOR factor, POTENTIAL_HOUR hour)
        {
            string dataPathName = GetPotentialFilePath(datetime, factor); //@"D:\S各种项目\W王平项目\系统\数据\强对流数据\wrf-17zhan-2015072100-lbdf-danzhishu-gailv.DAT";
            int stationNum = 17;
            FileStream fs = null;
            StreamReader br = null;
            try
            {
                DataTable dtResult = new DataTable("POTENTIAL");

                dtResult.Columns.Add("StationID", typeof(int));
                for (int i = 0; i < potential_name.Length; i++)
                    dtResult.Columns.Add(potential_name[i], typeof(double));
                //打开文件
                fs = new FileStream(dataPathName, FileMode.Open, FileAccess.Read);
                br = new StreamReader(fs, Encoding.Default);
                int n = stationNum * (int)hour;
                for (int i = 1; i <= n; i++)
                    br.ReadLine();
                for (int i = 1; i <= stationNum; i++)
                {
                    string[] lineData = DataReader.String2StringData(br.ReadLine());
                    //if (lineData.Length != 23)
                    //    continue;
                    dtResult.Rows.Add(Convert.ToInt32(lineData[2]),

                                      Convert.ToDouble(lineData[15]),
                                      Convert.ToDouble(lineData[16]),
                                      Convert.ToDouble(lineData[17]),
                                      Convert.ToDouble(lineData[18]),
                                      Convert.ToDouble(lineData[19]),
                                      Convert.ToDouble(lineData[20]),
                                      Convert.ToDouble(lineData[21]),
                                      Convert.ToDouble(lineData[22]),
                                      Convert.ToDouble(lineData[23]),
                                      Convert.ToDouble(lineData[24]));
                }
                br.Close();
                fs.Close();
                return dtResult;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (br != null)
                br.Close();
            if (fs != null)
                fs.Close();
            return null;
        }

        private double[] ReadPotentialData(DateTime datetime, POTENTIAL_FACTOR factor, POTENTIAL_HOUR hour, int stationID)
        {
            DataTable dtResult = ReadPotentialData(datetime, factor, hour);
            if (dtResult == null || dtResult.Rows.Count == 0)
                return null;
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                if (stationID == (int)dtResult.Rows[i]["StationID"])
                {
                    double[] result = new double[10];
                    for (int j = 0; j < 10; j++)
                        result[j] = (double)dtResult.Rows[i][j + 1];
                    return result;
                }
            }
            return null;
        }


        /// <summary>
        /// 显示MM5数据
        /// </summary>
        private void ShowMM5Data()
        {
            wLayerManagerControl1.ClearLayers();
            string dataPathName = GetMM5FilePath(controlDateTimePickerMM5.selectedDateTime);
            MM5_LEVEL level = MM5_LEVEL.GK925HPA;
            switch (listBoxLevelMM5.SelectedIndex)
            {
                case 0:
                    level = MM5_LEVEL.GK925HPA;
                    break;
                case 1:
                    level = MM5_LEVEL.GK850HPA;
                    break;
                case 2:
                    level = MM5_LEVEL.GK700HPA;
                    break;
                case 3:
                    level = MM5_LEVEL.GK500HPA;
                    break;
                case 4:
                    level = MM5_LEVEL.GK400HPA;
                    break;
                case 5:
                    level = MM5_LEVEL.GK300HPA;
                    break;
                case 6:
                    level = MM5_LEVEL.GK200HPA;
                    break;
                case 7:
                    level = MM5_LEVEL.GK100HPA;
                    break;
                default:
                    return;
            }
            string levelName = listBoxLevelMM5.Enabled ? listBoxLevelMM5.SelectedItem.ToString() : "";
            MM5_HOUR time = (MM5_HOUR)listBoxHourMM5.SelectedIndex;
            string hourName = listBoxHourMM5.SelectedItem.ToString();
            string factorName = listBoxFactorMM5.SelectedItem.ToString();
            DateTime startDateTime = controlDateTimePickerMM5.selectedDateTime;
            DateTime endDateTime = startDateTime + new TimeSpan(listBoxHourMM5.SelectedIndex * 6, 0, 0);
            string mapTitle = string.Format("{0}{1}({2} {3:00}H {4})",
                                            levelName,
                                            factorName,
                                            startDateTime.ToString("yyyyMMddHH"),
                                            listBoxHourMM5.SelectedIndex * 6,
                                            endDateTime.ToString("yyyyMMddHH"));
            string layerTitleD = string.Format("{0}{1}", levelName, factorName);
            string layerTitleUV = string.Format("{0}{1}", levelName, factorName);
            //准备数据
            ContourParams contourParams = null;
            VectorParams vectorParams = null;
            string contourColorBarName = "";
            string vectorColorBarName = "";
            double[] factorDataD = null;
            double[] factorDataU = null;
            double[] factorDataV = null;
            if (listBoxFactorMM5.SelectedIndex == 0)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.RAINC, level, time);
                double[] tempDataD = ReadMM5Data(dataPathName, MM5_FACTOR.RAINNC, level, time);
                for (int i = 0; i < factorDataD.Length; i++)
                {
                    if (factorDataD[i] != DefaultValue && tempDataD[i] != DefaultValue)
                        factorDataD[i] += tempDataD[i];
                    else
                        factorDataD[i] = DefaultValue;
                }
                factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.u10m, level, time);
                factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.v10m, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\地面降水量.cst");
                vectorParams = new VectorParams(Application.StartupPath + "\\ParamsData\\地面风向.vst");
                layerTitleD = "地面降水量";
                layerTitleUV = "地面风向";
                contourColorBarName = "降水量等值线颜色表";
                vectorColorBarName = "风速等级颜色表";
            }
            else if (listBoxFactorMM5.SelectedIndex == 1)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.rh, MM5_LEVEL.GK500HPA, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面相对湿度.cst");
                //factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.umet, MM5_LEVEL.GK500HPA, time);
                //factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.vmet, MM5_LEVEL.GK500HPA, time);
                factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.U, MM5_LEVEL.GK500HPA, time);
                factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.V, MM5_LEVEL.GK500HPA, time);
                vectorParams = new VectorParams(Application.StartupPath + "\\ParamsData\\等压面风向.vst");
                layerTitleD = "500百帕相对湿度";
                layerTitleUV = "500百帕风向";
                contourColorBarName = "相对湿度等值线颜色表";
                vectorColorBarName = "风速等级颜色表";
            }
            else if (listBoxFactorMM5.SelectedIndex == 2)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.rh, MM5_LEVEL.GK700HPA, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面相对湿度.cst");
                //factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.umet, MM5_LEVEL.GK700HPA, time);
                //factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.vmet, MM5_LEVEL.GK700HPA, time);
                factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.U, MM5_LEVEL.GK500HPA, time);
                factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.V, MM5_LEVEL.GK500HPA, time);
                vectorParams = new VectorParams(Application.StartupPath + "\\ParamsData\\等压面风向.vst");
                layerTitleD = "700百帕相对湿度";
                layerTitleUV = "700百帕风向";
                contourColorBarName = "相对湿度等值线颜色表";
                vectorColorBarName = "风速等级颜色表";
            }
            else if (listBoxFactorMM5.SelectedIndex == 3)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.rh, MM5_LEVEL.GK850HPA, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面相对湿度.cst");
                //factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.umet, MM5_LEVEL.GK850HPA, time);
                //factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.vmet, MM5_LEVEL.GK850HPA, time);
                factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.U, MM5_LEVEL.GK500HPA, time);
                factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.V, MM5_LEVEL.GK500HPA, time);
                vectorParams = new VectorParams(Application.StartupPath + "\\ParamsData\\等压面风向.vst");
                layerTitleD = "850百帕相对湿度";
                layerTitleUV = "850百帕风向";
                contourColorBarName = "相对湿度等值线颜色表";
                vectorColorBarName = "风速等级颜色表";
            }
            else if (listBoxFactorMM5.SelectedIndex == 4)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.height, MM5_LEVEL.GK500HPA, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面位势高度.cst");
                //factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.umet, MM5_LEVEL.GK500HPA, time);
                //factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.vmet, MM5_LEVEL.GK500HPA, time);
                factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.U, MM5_LEVEL.GK500HPA, time);
                factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.V, MM5_LEVEL.GK500HPA, time);
                vectorParams = new VectorParams(Application.StartupPath + "\\ParamsData\\等压面风向.vst");
                layerTitleD = "500百帕位势高度";
                layerTitleUV = "500百帕风向";
                contourColorBarName = "位势高度等值线颜色表";
                vectorColorBarName = "风速等级颜色表";
            }
            else if (listBoxFactorMM5.SelectedIndex == 5)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.height, MM5_LEVEL.GK500HPA, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面位势高度.cst");
                //factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.umet, MM5_LEVEL.GK700HPA, time);
                //factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.vmet, MM5_LEVEL.GK700HPA, time);
                factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.U, MM5_LEVEL.GK500HPA, time);
                factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.V, MM5_LEVEL.GK500HPA, time);
                vectorParams = new VectorParams(Application.StartupPath + "\\ParamsData\\等压面风向.vst");
                layerTitleD = "500百帕位势高度";
                layerTitleUV = "700百帕风向";
                contourColorBarName = "位势高度等值线颜色表";
                vectorColorBarName = "风速等级颜色表";
            }
            else if (listBoxFactorMM5.SelectedIndex == 6)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.height, MM5_LEVEL.GK500HPA, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面位势高度.cst");
                //factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.umet, MM5_LEVEL.GK850HPA, time);
                //factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.vmet, MM5_LEVEL.GK850HPA, time);
                factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.U, MM5_LEVEL.GK500HPA, time);
                factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.V, MM5_LEVEL.GK500HPA, time);
                vectorParams = new VectorParams(Application.StartupPath + "\\ParamsData\\等压面风向.vst");
                layerTitleD = "500百帕位势高度";
                layerTitleUV = "850百帕风向";
                contourColorBarName = "位势高度等值线颜色表";
                vectorColorBarName = "风速等级颜色表";
            }
            else if (listBoxFactorMM5.SelectedIndex == 7)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.slp, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\地面气压.cst");
                contourColorBarName = "气压等值线颜色表";
                vectorColorBarName = "";
            }
            else if (listBoxFactorMM5.SelectedIndex == 8)
            {
                factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.u10m, level, time);
                factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.v10m, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\地面风速.cst");
                vectorParams = new VectorParams(Application.StartupPath + "\\ParamsData\\地面风向.vst");
                layerTitleD += "-风速";
                layerTitleUV += "-风向";
                contourColorBarName = "风速等值线颜色表";
                vectorColorBarName = "风速等级颜色表";
            }
            else if (listBoxFactorMM5.SelectedIndex == 9)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.T2, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\地面温度.cst");
                contourColorBarName = "温度等值线颜色表";
                vectorColorBarName = "";
            }
            else if (listBoxFactorMM5.SelectedIndex == 10)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.rh2, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\地面相对湿度.cst");
                contourColorBarName = "相对湿度等值线颜色表";
                vectorColorBarName = "";
            }
            else if (listBoxFactorMM5.SelectedIndex == 11)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.RAINC, level, time);
                double[] tempDataD = ReadMM5Data(dataPathName, MM5_FACTOR.RAINNC, level, time);
                for (int i = 0; i < factorDataD.Length; i++)
                {
                    if (factorDataD[i] != DefaultValue && tempDataD[i] != DefaultValue)
                        factorDataD[i] += tempDataD[i];
                    else
                        factorDataD[i] = DefaultValue;
                }
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\地面降水量.cst");
                contourColorBarName = "降水量等值线颜色表";
                vectorColorBarName = "";
            }
            else if (listBoxFactorMM5.SelectedIndex == 12)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.height, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面位势高度.cst");
                contourColorBarName = "位势高度等值线颜色表";
                vectorColorBarName = "";
            }
            else if (listBoxFactorMM5.SelectedIndex == 13)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.tc, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面温度.cst");
                contourColorBarName = "温度等值线颜色表";
                vectorColorBarName = "";
            }
            else if (listBoxFactorMM5.SelectedIndex == 14)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.td, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面露点温度.cst");
                contourColorBarName = "露点温度等值线颜色表";
                vectorColorBarName = "";
            }
            else if (listBoxFactorMM5.SelectedIndex == 15)
            {
                factorDataD = ReadMM5Data(dataPathName, MM5_FACTOR.rh, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面相对湿度.cst");
                contourColorBarName = "相对湿度等值线颜色表";
                vectorColorBarName = "";
            }
            else if (listBoxFactorMM5.SelectedIndex == 16)
            {
                //factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.umet, level, time);
                //factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.vmet, level, time);
                factorDataU = ReadMM5Data(dataPathName, MM5_FACTOR.U, level, time);
                factorDataV = ReadMM5Data(dataPathName, MM5_FACTOR.V, level, time);
                contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\等压面风速.cst");
                vectorParams = new VectorParams(Application.StartupPath + "\\ParamsData\\等压面风向.vst");
                layerTitleD += "-风速";
                layerTitleUV += "-风向";
                contourColorBarName = "风速等值线颜色表";
                vectorColorBarName = "风速等级颜色表";
            }
            else
            {
                return;
            }
            int jump = 10;
            List<PointF> listPosD = null;
            List<float> listValD = null;
            List<PointF> listPosUV = null;
            List<float> listValU = null;
            List<float> listValV = null;
            if (factorDataU != null && factorDataV != null)
            {
                listPosUV = new List<PointF>(RowNum * ColNum / (jump * jump));
                listValU = new List<float>(RowNum * ColNum / (jump * jump));
                listValV = new List<float>(RowNum * ColNum / (jump * jump));
                for (int i = 0; i < RowNum; i += jump)
                {
                    for (int j = 0, pos = i * ColNum; j < ColNum; j += jump, pos += jump)
                    {
                        double valU = factorDataU[pos];
                        double valV = factorDataV[pos];
                        if (valU == DefaultValue || valV == DefaultValue)
                            continue;
                        listPosUV.Add(new PointF((float)m_Longitude[pos], (float)m_Latitude[pos]));
                        listValU.Add((float)valU);
                        listValV.Add((float)valV);
                    }
                }
                if (factorDataD == null)
                {
                    listPosD = listPosUV;
                    listValD = new List<float>(RowNum * ColNum / (jump * jump));
                    for (int i = 0; i < listValU.Count; i++)
                    {
                        float valU = listValU[i];
                        float valV = listValV[i];
                        listValD.Add((float)Math.Sqrt(valU * valU + valV * valV));
                    }
                }
            }
            if (factorDataD != null)
            {
                listPosD = new List<PointF>(RowNum * ColNum / (jump * jump));
                listValD = new List<float>(RowNum * ColNum / (jump * jump));
                for (int i = 0; i < RowNum; i += jump)
                {
                    for (int j = 0, pos = i * ColNum; j < ColNum; j += jump, pos += jump)
                    {
                        double valD = factorDataD[pos];
                        if (valD == DefaultValue)
                            continue;
                        listPosD.Add(new PointF((float)m_Longitude[pos], (float)m_Latitude[pos]));
                        listValD.Add((float)valD);
                    }
                }
            }
            //显示数据
            if (listPosD != null)
            {
                wChinaMasker masker = new wChinaMasker();
                wContourLayer contourLayer = new wContourLayer(layerTitleD, true);
                if (contourLayer.LoadData(listPosD, listValD, contourParams, true) == true)
                {
                    contourLayer.layerColorBarName = contourColorBarName;
                    wLayerManagerControl1.AddLayer(contourLayer, null, 0);
                }
            }
            if (listPosUV != null)
            {
                wVectorLayer vectorLayer = new wVectorLayer(layerTitleUV, true);
                if (vectorLayer.LoadData(listPosUV, listValU, listValV, vectorParams) == true)
                {
                    vectorLayer.layerColorBarName = vectorColorBarName;
                    wLayerManagerControl1.AddLayer(vectorLayer, null, 0);
                }
            }
            wMapPictureBox1.MapTitle = mapTitle;
        }

        /// <summary>
        /// 显示Area数据到右侧
        /// </summary>
        private void ShowAreaData()
        {
            string factorName = listBoxFactorArea.SelectedItem.ToString();
            POTENTIAL_HOUR hour = (POTENTIAL_HOUR)listBoxHourArea.SelectedIndex;
            string hourName = listBoxHourArea.SelectedItem.ToString();
            DateTime startDateTime = controlDateTimePickerArea.selectedDateTime;
            DateTime endDateTime = startDateTime + new TimeSpan(listBoxHourArea.SelectedIndex * 6 + 6, 0, 0);
            string mapTitle = string.Format("{0}({1} {2:00}H {3})",
                                            factorName,
                                            startDateTime.ToString("yyyyMMddHH"),
                                            listBoxHourArea.SelectedIndex * 6 + 6,
                                            endDateTime.ToString("yyyyMMddHH"));
            string layerName = factorName;

            ContourParams contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\强对流天气发生潜势.cst");
            POTENTIAL_FACTOR factor = POTENTIAL_FACTOR.LEIBAO_SINGLE_INDEX;
            if (listBoxFactorArea.SelectedIndex == 0)
            {
                factor = POTENTIAL_FACTOR.LEIBAO_SINGLE_INDEX;
                //contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\强对流天气发生潜势.cst");
            }
            else if (listBoxFactorArea.SelectedIndex == 1)
            {
                factor = POTENTIAL_FACTOR.LEIBAO_MULTI_INDEX;
                //contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\雷暴发生潜势.cst");
            }
            else if (listBoxFactorArea.SelectedIndex == 2)
            {
                factor = POTENTIAL_FACTOR.LEIBAO_CONDITION_INDEX;
                //contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\雷暴发生潜势.cst");
            }
            else if (listBoxFactorArea.SelectedIndex == 3)
            {
                factor = POTENTIAL_FACTOR.DAFENG_SINGLE_INDEX;
                //contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\雷暴大风发生潜势.cst");
            }
            else if (listBoxFactorArea.SelectedIndex == 4)
            {
                factor = POTENTIAL_FACTOR.DAFENG_MULTI_INDEX;
                //contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\雷暴大风发生潜势.cst");
            }
            else if (listBoxFactorArea.SelectedIndex == 5)
            {
                factor = POTENTIAL_FACTOR.DAFENG_CONDITION_INDEX;
                //contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\雷暴大风发生潜势.cst");
            }
            else if (listBoxFactorArea.SelectedIndex == 6)
            {
                factor = POTENTIAL_FACTOR.BINBAO_SINGLE_INDEX;
                //contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\冰雹发生潜势.cst");
            }
            else if (listBoxFactorArea.SelectedIndex == 7)
            {
                factor = POTENTIAL_FACTOR.BINBAO_MULTI_INDEX;
                //contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\冰雹发生潜势.cst");
            }
            else if (listBoxFactorArea.SelectedIndex == 8)
            {
                factor = POTENTIAL_FACTOR.BINBAO_CONDITION_INDEX;
                //contourParams = new ContourParams(Application.StartupPath + "\\ParamsData\\冰雹发生潜势.cst");
            }

            DataTable dtResult = ReadPotentialData(startDateTime, factor, hour);
            if (dtResult == null || dtResult.Rows.Count == 0)
            {
                MessageBox.Show("数据不存在");
                return;
            }

            List<PointF> listPosD = new List<PointF>();
            List<float> listValD = new List<float>();
            for (int i = 0; i < dtResult.Rows.Count; i++)
            {
                int stationID = (int)dtResult.Rows[i]["StationID"];
                for (int j = 0; j < wMapPictureBox2.m_StationIDList1.Count; j++)
                {
                    if (stationID == wMapPictureBox2.m_StationIDList1[j])
                    {
                        listPosD.Add(wMapPictureBox2.m_StationPositionList1[j]);
                        listValD.Add(Convert.ToSingle(dtResult.Rows[i]["SWEAT"]));
                    }
                }
            }

            wLayerManagerControl2.ClearLayers();
            wUserDefineMasker masker = new wUserDefineMasker(Application.StartupPath + "\\ParamsData\\南京军区.lin", true);
            wContourLayer contourLayer = new wContourLayer(layerName, true);
            if (contourLayer.LoadData(listPosD, listValD, contourParams, true) == true)
            {
                contourLayer.layerColorBarName = layerName;
                wLayerManagerControl2.AddLayer(contourLayer, masker, 0);
            }
            wMapPictureBox2.MapTitle = mapTitle;
        }

        /// <summary>
        /// 显示Tlnp数据到右侧
        /// </summary>
        private void ShowTlnPData()
        {
            if (treeViewStation.SelectedNode == null || treeViewStation.SelectedNode.Name != "STATION")
            {
                return;
            }
            if (listBoxHourStation.SelectedIndex < 0)
                return;
            int stationID = wMapPictureBox2.m_StationIDList1[(int)treeViewStation.SelectedNode.Index];
            string dataPathName = GetMM5FilePath(controlDateTimePickerStation.selectedDateTime);
            string stationName = treeViewStation.SelectedNode.Text;
            int dataIndex = (int)treeViewStation.SelectedNode.Tag;
            if (dataIndex < 0)
                return;
            MM5_HOUR time = (MM5_HOUR)(listBoxHourStation.SelectedIndex + 1);
            List<double> P = new List<double>();
            List<double> T = new List<double>();
            List<double> Td = new List<double>();
            List<double> H = new List<double>();
            List<int> Fs = new List<int>();
            List<int> Fx = new List<int>();
            for (int i = 0; i < mm5_level.Length; i++)
            {
                double[] tempData = ReadMM5Data(dataPathName, MM5_FACTOR.tc, (MM5_LEVEL)i, time);
                double t = tempData[dataIndex];
                tempData = ReadMM5Data(dataPathName, MM5_FACTOR.td, (MM5_LEVEL)i, time);
                double td = tempData[dataIndex];
                tempData = ReadMM5Data(dataPathName, MM5_FACTOR.height, (MM5_LEVEL)i, time);
                double h = tempData[dataIndex];
                //tempData = ReadMM5Data(dataPathName, MM5_FACTOR.umet, (MM5_LEVEL)i, time);
                tempData = ReadMM5Data(dataPathName, MM5_FACTOR.U, (MM5_LEVEL)i, time);
                double u = tempData[dataIndex];
                //tempData = ReadMM5Data(dataPathName, MM5_FACTOR.vmet, (MM5_LEVEL)i, time);
                tempData = ReadMM5Data(dataPathName, MM5_FACTOR.V, (MM5_LEVEL)i, time);
                double v = tempData[dataIndex];
                if (t != DefaultValue && td != DefaultValue && h != DefaultValue && u != DefaultValue && v != DefaultValue)
                {
                    h *= 10;
                    double fs = 0, fx = 0;
                    Mathmatics.UVToFxFs(u, v, out fs, out fx);
                    P.Add(mm5_level[i]);
                    T.Add(t);
                    Td.Add(td);
                    H.Add(h);
                    Fs.Add((int)fs);
                    Fx.Add((int)fx);
                }
            }
            DateTime startDateTime = controlDateTimePickerStation.selectedDateTime;
            DateTime endDateTime = startDateTime + new TimeSpan(listBoxHourStation.SelectedIndex * 6, 0, 0);
            string tlnpTitle = string.Format("{0} 温度压力对数图({1} {2:00}H {3})",
                                            stationName,
                                            startDateTime.ToString("yyyyMMddHH"),
                                            listBoxHourStation.SelectedIndex * 6,
                                            endDateTime.ToString("yyyyMMddHH"));
            string roseTitle = string.Format("{0} 风玫瑰图({1} {2:00}H {3})",
                                            stationName,
                                            startDateTime.ToString("yyyyMMddHH"),
                                            listBoxHourStation.SelectedIndex * 6,
                                            endDateTime.ToString("yyyyMMddHH"));
            wTlnPControl1.LoadData(P, H, T, Td, Fs, Fx);
            wTlnPControl1.PicTitle = tlnpTitle;
            wTlnPControl1.DrawData();

            //todo:风玫瑰图，还是应该添加上去,有bug
            //wWindRoseControl1.LoadData(P, Fs, Fx);
            //wWindRoseControl1.PicTitle = roseTitle;
            //wWindRoseControl1.DrawData();

            //12个指数
            POTENTIAL_HOUR hour = (POTENTIAL_HOUR)listBoxHourStation.SelectedIndex;
            double[] dt12Index = Read12IndexData(controlDateTimePickerStation.selectedDateTime, stationID, hour);
            for (int i = 0; i < m_listViewIndex.Items.Count; i++)
            {
                m_listViewIndex.Items[i].SubItems[1].Text = string.Format("{0:0.000}", dt12Index[i]);
            }
            //3个分类的2个参数
            m_listViewParas.Items[0].SubItems[1].Text = string.Format("{0:0.000}", ReadPotentialParas(controlDateTimePickerStation.selectedDateTime, stationID, hour, POTENTIAL_FACTOR.BINBAO_MULTI_INDEX));
            m_listViewParas.Items[0].SubItems[2].Text = string.Format("{0:0.000}", ReadPotentialParas(controlDateTimePickerStation.selectedDateTime, stationID, hour, POTENTIAL_FACTOR.BINBAO_CONDITION_INDEX));
            m_listViewParas.Items[1].SubItems[1].Text = string.Format("{0:0.000}", ReadPotentialParas(controlDateTimePickerStation.selectedDateTime, stationID, hour, POTENTIAL_FACTOR.DAFENG_MULTI_INDEX));
            m_listViewParas.Items[1].SubItems[2].Text = string.Format("{0:0.000}", ReadPotentialParas(controlDateTimePickerStation.selectedDateTime, stationID, hour, POTENTIAL_FACTOR.DAFENG_CONDITION_INDEX));
            m_listViewParas.Items[2].SubItems[1].Text = string.Format("{0:0.000}", ReadPotentialParas(controlDateTimePickerStation.selectedDateTime, stationID, hour, POTENTIAL_FACTOR.LEIBAO_MULTI_INDEX));
            m_listViewParas.Items[2].SubItems[2].Text = string.Format("{0:0.000}", ReadPotentialParas(controlDateTimePickerStation.selectedDateTime, stationID, hour, POTENTIAL_FACTOR.LEIBAO_CONDITION_INDEX));


            //POTENTIAL_HOUR hour = (POTENTIAL_HOUR)listBoxHourStation.SelectedIndex;
            //double[] potentialSingle = ReadPotentialData(controlDateTimePickerStation.selectedDateTime,
            //                                             POTENTIAL_FACTOR.LEIBAO_SINGLE_INDEX,
            //                                             hour,
            //                                             stationID);
            //double[] potentialMulti = ReadPotentialData(controlDateTimePickerStation.selectedDateTime,
            //                                            POTENTIAL_FACTOR.LEIBAO_MULTI_INDEX,
            //                                            hour,
            //                                            stationID);
            //double[] potentialCondition = ReadPotentialData(controlDateTimePickerStation.selectedDateTime,
            //                                                POTENTIAL_FACTOR.LEIBAO_CONDITION_INDEX,
            //                                                hour,
            //                                                stationID);
            //for (int i = 0; i < listViewPotentialLeiBao.Items.Count; i++)
            //{
            //    if (potentialSingle != null)
            //        listViewPotentialLeiBao.Items[i].SubItems[1].Text = string.Format("{0:0.000}", potentialSingle[i]);
            //    else
            //        listViewPotentialLeiBao.Items[i].SubItems[1].Text = "-";
            //    if (potentialMulti != null)
            //        listViewPotentialLeiBao.Items[i].SubItems[2].Text = string.Format("{0:0.000}", potentialMulti[i]);
            //    else
            //        listViewPotentialLeiBao.Items[i].SubItems[2].Text = "-";
            //    if (potentialCondition != null)
            //        listViewPotentialLeiBao.Items[i].SubItems[3].Text = string.Format("{0:0.000}", potentialCondition[i]);
            //    else
            //        listViewPotentialLeiBao.Items[i].SubItems[3].Text = "-";
            //}
            ////雷暴大风
            //potentialSingle = ReadPotentialData(controlDateTimePickerStation.selectedDateTime,
            //                                    POTENTIAL_FACTOR.DAFENG_SINGLE_INDEX,
            //                                    hour,
            //                                    stationID);
            //potentialMulti = ReadPotentialData(controlDateTimePickerStation.selectedDateTime,
            //                                   POTENTIAL_FACTOR.DAFENG_MULTI_INDEX,
            //                                   hour,
            //                                   stationID);
            //potentialCondition = ReadPotentialData(controlDateTimePickerStation.selectedDateTime,
            //                                       POTENTIAL_FACTOR.DAFENG_CONDITION_INDEX,
            //                                       hour,
            //                                       stationID);
            //for (int i = 0; i < listViewPotentialDaFeng.Items.Count; i++)
            //{
            //    if (potentialSingle != null)
            //        listViewPotentialDaFeng.Items[i].SubItems[1].Text = string.Format("{0:0.000}", potentialSingle[i]);
            //    else
            //        listViewPotentialDaFeng.Items[i].SubItems[1].Text = "-";
            //    if (potentialMulti != null)
            //        listViewPotentialDaFeng.Items[i].SubItems[2].Text = string.Format("{0:0.000}", potentialMulti[i]);
            //    else
            //        listViewPotentialDaFeng.Items[i].SubItems[2].Text = "-";
            //    if (potentialCondition != null)
            //        listViewPotentialDaFeng.Items[i].SubItems[3].Text = string.Format("{0:0.000}", potentialCondition[i]);
            //    else
            //        listViewPotentialDaFeng.Items[i].SubItems[3].Text = "-";
            //}
            ////冰雹
            ////雷暴大风
            //potentialSingle = ReadPotentialData(controlDateTimePickerStation.selectedDateTime,
            //                                    POTENTIAL_FACTOR.BINBAO_SINGLE_INDEX,
            //                                    hour,
            //                                    stationID);
            //potentialMulti = ReadPotentialData(controlDateTimePickerStation.selectedDateTime,
            //                                   POTENTIAL_FACTOR.BINBAO_MULTI_INDEX,
            //                                   hour,
            //                                   stationID);
            //potentialCondition = ReadPotentialData(controlDateTimePickerStation.selectedDateTime,
            //                                       POTENTIAL_FACTOR.BINBAO_CONDITION_INDEX,
            //                                       hour,
            //                                       stationID);
            //for (int i = 0; i < listViewPotentialBinBao.Items.Count; i++)
            //{
            //    if (potentialSingle != null)
            //        listViewPotentialBinBao.Items[i].SubItems[1].Text = string.Format("{0:0.000}", potentialSingle[i]);
            //    else
            //        listViewPotentialBinBao.Items[i].SubItems[1].Text = "-";
            //    if (potentialMulti != null)
            //        listViewPotentialBinBao.Items[i].SubItems[2].Text = string.Format("{0:0.000}", potentialMulti[i]);
            //    else
            //        listViewPotentialBinBao.Items[i].SubItems[2].Text = "-";
            //    if (potentialCondition != null)
            //        listViewPotentialBinBao.Items[i].SubItems[3].Text = string.Format("{0:0.000}", potentialCondition[i]);
            //    else
            //        listViewPotentialBinBao.Items[i].SubItems[3].Text = "-";
            //}
        }

        /// <summary>
        /// 站点选中后，显示ShowTlnPData
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void treeViewStation_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ShowTlnPData();
        }

        void StationTimeStationHour_SelectedValueChanged(object sender, EventArgs e)
        {
            ShowTlnPData(); ;
        }

        private void MM5TimeFactorLevelHour_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFactorMM5.SelectedIndex >= 12 && listBoxFactorMM5.SelectedIndex <= 16)
            {
                listBoxLevelMM5.Enabled = true;
                buttonLevelMM5Up.Enabled = true;
                buttonLevelMM5Down.Enabled = true;
            }
            else
            {
                listBoxLevelMM5.Enabled = false;
                buttonLevelMM5Up.Enabled = false;
                buttonLevelMM5Down.Enabled = false;
            }
            ShowMM5Data();
        }

        void AreaTimeFactorhOUR_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowAreaData();
        }

        private void buttonLevelMM5Up_Click(object sender, EventArgs e)
        {
            if (listBoxLevelMM5.SelectedIndex > 0)
                listBoxLevelMM5.SelectedIndex--;
        }

        private void buttonLevelMM5Down_Click(object sender, EventArgs e)
        {
            if (listBoxLevelMM5.SelectedIndex < listBoxLevelMM5.Items.Count - 1)
                listBoxLevelMM5.SelectedIndex++;
        }

        private void buttonHourMM5Up_Click(object sender, EventArgs e)
        {
            if (listBoxHourMM5.SelectedIndex > 0)
                listBoxHourMM5.SelectedIndex--;
        }

        private void buttonHourMM5Down_Click(object sender, EventArgs e)
        {
            if (listBoxHourMM5.SelectedIndex < listBoxHourMM5.Items.Count - 1)
                listBoxHourMM5.SelectedIndex++;
        }

        private void buttonHourStationUp_Click(object sender, EventArgs e)
        {
            if (listBoxHourStation.SelectedIndex > 0)
                listBoxHourStation.SelectedIndex--;
        }

        private void buttonHourStationDown_Click(object sender, EventArgs e)
        {
            if (listBoxHourStation.SelectedIndex < listBoxHourMM5.Items.Count - 1)
                listBoxHourStation.SelectedIndex++;
        }


    }
}
