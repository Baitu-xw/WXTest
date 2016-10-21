using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace WX_TennisAssociation.Common
{
    #region 写入日志类
    /// <summary>
    /// 写入日志类
    /// </summary>
    public class WriteLog
    {
        private static string  strLogDir = System.Configuration.ConfigurationManager.AppSettings["LogConfig"];

        #region 写入日志
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="appPath">写日志的路径</param>
        /// <param name="content">内容</param>
        public static void WriteLogFile(Exception ex)
        {
            if (!Directory.Exists(strLogDir))
                Directory.CreateDirectory(strLogDir);

            string filename = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss-") + DateTime.Now.Millisecond + "_log.txt";

            if (File.Exists(strLogDir + "/" + filename))
            {
                StreamWriter logfile = new StreamWriter(strLogDir + "/" + filename, true, System.Text.Encoding.UTF8);

                string strErrmsg = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日 " + DateTime.Now.Hour + "时" + DateTime.Now.Minute + "分" + DateTime.Now.Second + "秒" + DateTime.Now.Millisecond + "毫秒"+"\n";
                strErrmsg += "错误消息:" + ex.Message + "\n";
                strErrmsg += "导致错误的应用程序或对象的名称:" + ex.Source + "\n";
                strErrmsg += "堆栈内容:" + ex.StackTrace + "\n";
                strErrmsg += "引发异常的方法:" + ex.TargetSite + "\n\n";
                logfile.WriteLine(strErrmsg);
                logfile.Flush();//刷新
                logfile.Close();//关闭文件流
                logfile.Dispose();//释放资源
            }
            else
            {
                FileStream file = new FileStream(strLogDir + "/" + filename, FileMode.CreateNew);

                file.Close();
                file.Dispose();

                if (File.Exists(strLogDir + "/" + filename))
                {
                    StreamWriter logfile = new StreamWriter(strLogDir + "/" + filename, true);
                    
                    string strErrmsg = DateTime.Now.Year + "年" + DateTime.Now.Month + "月" + DateTime.Now.Day + "日 " + DateTime.Now.Hour + "时" + DateTime.Now.Minute + "分" + DateTime.Now.Second + "秒" + DateTime.Now.Millisecond + "毫秒" + "\n";
                    strErrmsg += "错误消息:" + ex.Message + "\n";
                    strErrmsg += "导致错误的应用程序或对象的名称:" + ex.Source + "\n";
                    strErrmsg += "堆栈内容:" + ex.StackTrace + "\n";
                    strErrmsg += "引发异常的方法:" + ex.TargetSite + "\n\n";
                    logfile.WriteLine(strErrmsg);
                    logfile.Flush();//刷新
                    logfile.Close();//关闭文件流
                    logfile.Dispose();//释放资源
                }
            }
        }
        #endregion
    }
    #endregion
}
