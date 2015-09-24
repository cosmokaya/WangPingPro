using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace SCWPredictSystem
{
    public partial class MainForm
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        private string GetMM5FilePath(DateTime datetime)
        {
            string str = datetime.ToString("yyyyMMdd");
            string path = ConfigurationManager.AppSettings["data"];
            //wrfbgm20150525
            str = path + str + "//" + "wrfbgm" + str + ".dat";
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        private string Get12IndexPath(DateTime datetime, string hour = "00")
        {
            string str = datetime.ToString("yyyyMMdd");
            string path = ConfigurationManager.AppSettings["data"];
            //wrf-17zhan-2015072100-12INDEX
            str = path + str + "//" + "wrf-17zhan-" + str + hour + "-12INDEX.dat";
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <param name="factor"></param>
        /// <param name="hour"></param>
        /// <returns></returns>
        private string GetPotentialFilePath(DateTime dateTime, POTENTIAL_FACTOR factor, string hour = "00")
        {
            string str = dateTime.ToString("yyyyMMdd");
            string path = ConfigurationManager.AppSettings["data"];
            switch (factor)
            {
                case POTENTIAL_FACTOR.BINBAO_CONDITION_INDEX:
                    //wrf-17zhan-2015072100-lbdf-danzhishu-gailv
                    str = path + str + "//" + "wrf-17zhan-" + str + hour + "-bb-tiaojianzhishu-gailv.dat";
                    break;
                case POTENTIAL_FACTOR.BINBAO_MULTI_INDEX:
                    //wrf-17zhan-2015072100-lbdf-danzhishu-gailv
                    str = path + str + "//" + "wrf-17zhan-" + str + hour + "-bb-duozhishu-gailv.dat";
                    break;
                case POTENTIAL_FACTOR.BINBAO_SINGLE_INDEX:
                    //wrf-17zhan-2015072100-lbdf-danzhishu-gailv
                    str = path + str + "//" + "wrf-17zhan-" + str + hour + "-bb-danzhishu-gailv.dat";
                    break;
                case POTENTIAL_FACTOR.DAFENG_CONDITION_INDEX:
                    //wrf-17zhan-2015072100-lbdf-duozhishu-gailv
                    str = path + str + "//" + "wrf-17zhan-" + str + hour + "-lbdf-tiaojianzhishu-gailv.dat";
                    break;
                case POTENTIAL_FACTOR.DAFENG_MULTI_INDEX:
                    //wrf-17zhan-2015072100-lbdf-duozhishu-gailv
                    str = path + str + "//" + "wrf-17zhan-" + str + hour + "-lbdf-duozhishu-gailv.dat";
                    break;
                case POTENTIAL_FACTOR.DAFENG_SINGLE_INDEX:
                    //wrf-17zhan-2015072100-lbdf-duozhishu-gailv
                    str = path + str + "//" + "wrf-17zhan-" + str + hour + "-lbdf-danzhishu-gailv.dat";
                    break;
                case POTENTIAL_FACTOR.LEIBAO_CONDITION_INDEX:
                    //wrf-17zhan-2015072100-lbdf-tiaojianzhishu-gailv
                    str = path + str + "//" + "wrf-17zhan-" + str + hour + "-lb-tiaojianzhishu-gailv.dat";
                    break;
                case POTENTIAL_FACTOR.LEIBAO_MULTI_INDEX:
                    //wrf-17zhan-2015072100-lbdf-tiaojianzhishu-gailv
                    str = path + str + "//" + "wrf-17zhan-" + str + hour + "-lb-duozhishu-gailv.dat";
                    break;
                case POTENTIAL_FACTOR.LEIBAO_SINGLE_INDEX:
                    //wrf-17zhan-2015072100-lbdf-tiaojianzhishu-gailv
                    str = path + str + "//" + "wrf-17zhan-" + str + hour + "-lb-danzhishu-gailv.dat";
                    break;
                default:
                    break;
            }

            return str;
        }

        //public enum FilePathType
        //{
        //    MM5File,
        //    Index,
        //    Dan,
        //    Duo,
        //    TiaoJian
        //}
    }
}
