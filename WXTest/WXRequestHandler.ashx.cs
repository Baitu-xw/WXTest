using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Security;
using TestLog4Net;
using WX_TennisAssociation.Common;

namespace WXTest
{
    #region 微信处理接口类
    /// <summary>
    /// 微信处理接口
    /// </summary>
    public class WXRequestHandler : IHttpHandler
    {
        #region 请求处理函数
        public void ProcessRequest(HttpContext context)
        {
            string postString = string.Empty;
            System.Diagnostics.Debug.WriteLine("收到的请求为：");
            System.Diagnostics.Debug.WriteLine(HttpContext.Current.Request.HttpMethod.ToUpper());
            if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
            {
                using (Stream stream = HttpContext.Current.Request.InputStream)
                {
                    Byte[] postBytes = new Byte[stream.Length];
                    stream.Read(postBytes, 0, (Int32)stream.Length);
                    postString = Encoding.UTF8.GetString(postBytes);
                }

                if (!string.IsNullOrEmpty(postString))
                {
                    //System.Diagnostics.Debug.WriteLine("收到的内容为：");
                    //System.Diagnostics.Debug.WriteLine(postString);
                    Execute(postString);
                }
            }
            else
            {
                Auth(); //微信验证接入
            }
        }
    #endregion

        #region 是否可重用
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        #endregion

        #region 验证并相应服务器的数据
        /// <summary>
        /// 成为开发者的第一步，验证并相应服务器的数据
        /// </summary>
        private void Auth()
        {
            string token = ConfigurationManager.AppSettings["WeixinToken"];//从配置文件获取Token
            System.Diagnostics.Debug.WriteLine("token:" + token);
            if (string.IsNullOrEmpty(token))
            {
                LogHelper.WriteLog(typeof(string),string.Format("WeixinToken 配置项没有配置！"));
            }

            string echoString = HttpContext.Current.Request.QueryString["echoStr"];
            string signature = HttpContext.Current.Request.QueryString["signature"];
            string timestamp = HttpContext.Current.Request.QueryString["timestamp"];
            string nonce = HttpContext.Current.Request.QueryString["nonce"];

            //System.Diagnostics.Debug.WriteLine("echoString = " + echoString);
            //System.Diagnostics.Debug.WriteLine("signature = " + signature);
            //System.Diagnostics.Debug.WriteLine("timestamp = " + timestamp);
            //System.Diagnostics.Debug.WriteLine("nonce = " + nonce);

            if (CheckSignature(token, signature, timestamp, nonce))
            {
                if (!string.IsNullOrEmpty(echoString))
                {
                    HttpContext.Current.Response.Write(echoString);
                    HttpContext.Current.Response.End();
                }
            }
        }
        #endregion

        #region 验证微信签名
        /// <summary>
        /// 验证微信签名
        /// </summary>
        public bool CheckSignature(string token, string signature, string timestamp, string nonce)
        {
            string[] ArrTmp = { token, timestamp, nonce };

            Array.Sort(ArrTmp);
            string tmpStr = string.Join("", ArrTmp);

            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            //System.Diagnostics.Debug.WriteLine("tmpStr = " + tmpStr);

            if (tmpStr == signature)
            {
                //System.Diagnostics.Debug.WriteLine("验证通过");
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region 处理各种请求信息并应答
        /// <summary>
        /// 处理各种请求信息并应答（通过POST的请求）
        /// </summary>
        /// <param name="postStr">POST方式提交的数据</param>
        private void Execute(string postStr)
        {
            WeixinApiDispatch dispatch = new WeixinApiDispatch();
            string responseContent = dispatch.Execute(postStr);
            //System.Diagnostics.Debug.WriteLine("响应的内容为：");
            //System.Diagnostics.Debug.WriteLine(responseContent);

            HttpContext.Current.Response.ContentEncoding = Encoding.UTF8;
            HttpContext.Current.Response.ContentType = "text/xml";
            HttpContext.Current.Response.Write(responseContent);
        }
        #endregion
    }
    #endregion
}