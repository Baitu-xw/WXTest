using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using TestLog4Net;

namespace WX_TennisAssociation.Common
{
    public class HttpHelper
    {
        public string GetHtml(string url)
        {
            string strMsg = string.Empty;
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader reader = new System.IO.StreamReader(response.GetResponseStream(), Encoding.GetEncoding("utf-8"));

                strMsg = reader.ReadToEnd();
                reader.Close();
                reader.Dispose();
                response.Close();
            }
            catch
            {
                LogHelper.WriteLog(typeof(string), string.Format(url + "   读取链接网页内容出错。"));
            }
            return strMsg;
        }
    }
}