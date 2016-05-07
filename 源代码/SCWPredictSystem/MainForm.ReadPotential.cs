using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using wMetroGIS.wDataReader;

namespace SCWPredictSystem
{
    public partial class MainForm
    {

        //潜势
        private enum POTENTIAL_FACTOR
        {
            //LEIBAO_SINGLE_INDEX = 0,
            LEIBAO_MULTI_INDEX,
            LEIBAO_CONDITION_INDEX,
            //DAFENG_SINGLE_INDEX,
            DAFENG_MULTI_INDEX,
            DAFENG_CONDITION_INDEX,
            //BINBAO_SINGLE_INDEX,
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

        private enum Surf_Factor
        {
            CAPE,
            CIN,
            LI,
            SI,
            SSI,
            BRN,
            BRNSHR,
            AI,
            KI,
            SWEAT,
            FF75,
            FF52
        }
        ///// <summary>
        ///// 获取12个指数的DataTable
        ///// </summary>
        ///// <param name="datetime"></param>
        ///// <param name="factor"></param>
        ///// <param name="hour"></param>
        ///// <returns></returns>
        //private DataTable ReadPotentialData(DateTime datetime, POTENTIAL_FACTOR factor, POTENTIAL_HOUR hour)
        //{
        //    string dataPathName = GetPotentialFilePath(datetime, factor); //@"D:\S各种项目\W王平项目\系统\数据\强对流数据\wrf-17zhan-2015072100-lbdf-danzhishu-gailv.DAT";
        //    int stationNum = 17;
        //    FileStream fs = null;
        //    StreamReader br = null;

        //    DataTable dtResult = new DataTable("POTENTIAL");
        //    dtResult.Columns.Add("StationID", typeof(int));
        //    for (int i = 0; i < potential_name.Length; i++)
        //        dtResult.Columns.Add(potential_name[i], typeof(double));
        //    //打开文件
        //    fs = new FileStream(dataPathName, FileMode.Open, FileAccess.Read);
        //    br = new StreamReader(fs, Encoding.Default);
        //    int n = stationNum * (int)hour;
        //    for (int i = 1; i <= n; i++)
        //        br.ReadLine();
        //    for (int i = 1; i <= stationNum; i++)
        //    {
        //        string[] lineData = DataReader.String2StringData(br.ReadLine());
        //        //if (lineData.Length != 23)
        //        //    continue;
        //        dtResult.Rows.Add(Convert.ToInt32(lineData[2]),
        //                          Convert.ToDouble(lineData[15]),
        //                          Convert.ToDouble(lineData[16]),
        //                          Convert.ToDouble(lineData[17]),
        //                          Convert.ToDouble(lineData[18]),
        //                          Convert.ToDouble(lineData[19]),
        //                          Convert.ToDouble(lineData[20]),
        //                          Convert.ToDouble(lineData[21]),
        //                          Convert.ToDouble(lineData[22]),
        //                          Convert.ToDouble(lineData[23]),
        //                          Convert.ToDouble(lineData[24]));
        //    }
        //    br.Close();
        //    fs.Close();
        //    return dtResult;
        //}

        /// <summary>
        /// 获取指定指数的DataTable
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

            DataTable dtResult = new DataTable("POTENTIAL");
            dtResult.Columns.Add("StationID", typeof(int));
            dtResult.Columns.Add("Index", typeof(double));
            //打开文件
            fs = new FileStream(dataPathName, FileMode.Open, FileAccess.Read);
            br = new StreamReader(fs, Encoding.Default);
            int n = stationNum * (int)hour;
            for (int i = 1; i <= n; i++)
                br.ReadLine();
            for (int i = 1; i <= stationNum; i++)
            {
                string[] lineData = DataReader.String2StringData(br.ReadLine());
                dtResult.Rows.Add(Convert.ToInt32(lineData[2]),
                                  Convert.ToDouble(lineData[lineData.Length - 1]));
            }
            br.Close();
            fs.Close();
            return dtResult;
        }

        private double[] ReadSurfData(DateTime datetime, Surf_Factor factor, POTENTIAL_HOUR hour)
        {
            try
            {
                double[] result = new double[187];
                string dataPathName = Get12IndexSurfPath(datetime); //@"D:\S各种项目\W王平项目\系统\数据\强对流数据\wrf-17zhan-2015072100-lbdf-danzhishu-gailv.DAT";
                FileStream fs = null;
                StreamReader br = null;

                //DataTable dtResult = new DataTable("POTENTIAL");
                //dtResult.Columns.Add("StationID", typeof(int));
                //dtResult.Columns.Add("Index", typeof(double));
                //打开文件
                fs = new FileStream(dataPathName, FileMode.Open, FileAccess.Read);
                br = new StreamReader(fs, Encoding.Default);
                int n = 187 * (int)hour;
                for (int i = 1; i <= n; i++)
                    br.ReadLine();
                for (int i = 0; i < 187; i++)
                {
                    string[] lineData = DataReader.String2StringData(br.ReadLine());
                    //dtResult.Rows.Add(Convert.ToInt32(lineData[2]),Convert.ToDouble(lineData[(int)factor + 3]));
                    result[i] = Convert.ToDouble(lineData[(int)factor + 3]);
                }
                br.Close();
                fs.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

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
    }
}
