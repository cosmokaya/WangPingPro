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
            str = path + str + "//" + "wrfbgm" + str + ".dat";
            //wrfbgm20150525
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        private string Get12IndexPath(DateTime datetime)
        {
            string str = datetime.ToString("yyyyMMdd");
            string path = ConfigurationManager.AppSettings["data"];
            //wrf-17zhan-2015072100-12INDEX
            str = path + str + "//" + "wrf-17zhan-" + str + "00-12INDEX.dat";
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        private string GetDanZhishuPath(DateTime datetime)
        {
            string str = datetime.ToString("yyyyMMdd");
            string path = ConfigurationManager.AppSettings["data"];
            //wrf-17zhan-2015072100-lbdf-danzhishu-gailv
            str = path + str + "//" + "wrf-17zhan-" + str + "00-lbdf-danzhishu-gailv.dat";
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        private string GetDuoZhishuPath(DateTime datetime)
        {
            string str = datetime.ToString("yyyyMMdd");
            string path = ConfigurationManager.AppSettings["data"];
            //wrf-17zhan-2015072100-lbdf-duozhishu-gailv
            str = path + str + "//" + "wrf-17zhan-" + str + "00-lbdf-duozhishu-gailv.dat";
            return str;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        private string GetTjIndexPath(DateTime datetime)
        {
            string str = datetime.ToString("yyyyMMdd");
            string path = ConfigurationManager.AppSettings["data"];
            //wrf-17zhan-2015072100-lbdf-tiaojianzhishu-gailv
            str = path + str + "//" + "wrf-17zhan-" + str + "00-lbdf-tiaojianzhishu-gailv.dat";
            return str;
        }


        public enum FilePathType
        {
            All,
            Index,
            Duo,
            Dan,
            TiaoJian
        }
    }
}
