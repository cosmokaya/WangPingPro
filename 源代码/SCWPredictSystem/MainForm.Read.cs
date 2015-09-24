﻿using System;
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
        /// <summary>
        /// 获取12个指数的DataTable
        /// </summary>
        /// <param name="datetime"></param>
        /// <param name="factor"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        private double[] Read12IndexData(DateTime datetime, int stationID, POTENTIAL_HOUR hour)
        {
            string dataPathName = Get12IndexPath(datetime); //@"D:\S各种项目\W王平项目\系统\数据\强对流数据\wrf-17zhan-2015072100-lbdf-danzhishu-gailv.DAT";
            int stationNum = 17;
            FileStream fs = null;
            StreamReader br = null;
            double[] result = new double[12];
            try
            {
                //打开文件
                fs = new FileStream(dataPathName, FileMode.Open, FileAccess.Read);
                br = new StreamReader(fs, Encoding.Default);
                int n = stationNum * (int)hour;
                for (int i = 1; i <= n; i++)
                    br.ReadLine();
                for (int i = 1; i <= stationNum; i++)
                {
                    string[] lineData = DataReader.String2StringData(br.ReadLine());
                    if (stationID == Convert.ToInt32(lineData[2]))
                    {
                        for (int j = 0; j < 12; j++)
                        {
                            if (lineData.Length > 3 + j)//防止边界溢出
                            {
                                result[j] = Convert.ToDouble(lineData[3 + j]);
                            }
                        }
                    }
                }
                br.Close();
                fs.Close();
                return result;
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


        private double ReadPotentialParas(DateTime datetime, int stationID, POTENTIAL_HOUR hour, POTENTIAL_FACTOR factor)
        {
            double result = 0;
            string dataPathName = GetPotentialFilePath(datetime, factor);
            int stationNum = 17;
            FileStream fs = null;
            StreamReader br = null;
            try
            {
                //打开文件
                fs = new FileStream(dataPathName, FileMode.Open, FileAccess.Read);
                br = new StreamReader(fs, Encoding.Default);
                int n = stationNum * (int)hour;
                for (int i = 1; i <= n; i++)
                    br.ReadLine();
                for (int i = 1; i <= stationNum; i++)
                {
                    string[] lineData = DataReader.String2StringData(br.ReadLine());
                    if (stationID == Convert.ToInt32(lineData[2]))
                    {
                        result = Convert.ToDouble(lineData[lineData.Length - 1]);
                    }
                }
                br.Close();
                fs.Close();
                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (br != null)
                br.Close();
            if (fs != null)
                fs.Close();
            return 0;
        }
    }
}
