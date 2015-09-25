using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using wMetroGIS.wDataReader;
using wMetroGIS.wMathmatics;

namespace SCWPredictSystem
{
    public partial class MainForm
    {
        //
        private int[] mm5_factor_level = new int[] { 21, 21, 1, 1, 1, 1, 1, 21, 21, 21, 21, 21, 1, 1, 1, 1 };
        //
        private int[] mm5_factor_pos = new int[] { 0, 21, 42, 43, 44, 45, 46, 47, 68, 89, 110, 131, 152, 153, 154, 155 };
        //
        private double[] mm5_level = new double[] { 1000, 975, 950, 925, 900, 850, 800, 750, 700, 650, 600, 550, 500, 450, 400, 350, 300, 250, 200, 150, 100 };

        private enum MM5_FACTOR //16
        {
            U,           //21  0  x-wind component (m s-1)
            V,           //21  0  y-wind component (m s-1)
            T2,          //   1  0  TEMP at 2 M (K)
            RAINC,       //   1  0  ACCUMULATED TOTAL CUMULUS PRECIPITATION (mm)
            RAINNC,      //   1  0  ACCUMULATED TOTAL GRID SCALE PRECIPITATION (mm)
            XLAT,        //  1  0  LATITUDE, SOUTH IS NEGATIVE (degree_north)
            XLONG,       //   1      0  LONGITUDE, WEST IS NEGATIVE (degree_east)
            pressure,    //  21  0  Model pressure (hPa)
            height,      //  21  0  Model height (km)
            tc,          //  21  0  Temperature (C)
            td,          //  21  0  Dewpoint Temperature (C)
            rh,          //  21  0  Relative Humidity (%)
            rh2,         //   1  0  Relative Humidity at 2m (%)
            u10m,        //   1    153  Rotated wind component (m s-1)
            v10m,        //   1    154  Rotated wind component (m s-1) 
            slp          //   1    155  Sea Levelp Pressure (hPa)
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


        /// <summary>
        /// 读取某一层的全部数据
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
                //for (int i = 0; i < 156; i++)
                //{
                //    double[] test = DataReader.ReadBigEndianFloatBlockToDouble(br, RowNum, ColNum);
                //}
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

        /// <summary>
        /// 规范化数据
        /// </summary>
        /// <param name="data"></param>
        /// <param name="factor"></param>
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
    }
}
