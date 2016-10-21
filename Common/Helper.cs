using Newtonsoft.Json;
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
    public class Helper
    {
        public static CommonResult GetExecuteResult(string url, string postData)
        {
            var dataArray = Encoding.UTF8.GetBytes(postData);
            //创建请求  
            var request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "POST";
            request.ContentLength = dataArray.Length;
            //设置上传服务的数据格式  
            request.ContentType = "application/x-www-form-urlencoded";
            //请求的身份验证信息为默认  
            request.Credentials = CredentialCache.DefaultCredentials;
            //请求超时时间  
            request.Timeout = 10000;
            //创建输入流  
            Stream dataStream;
            try
            {
                dataStream = request.GetRequestStream();
            }
            catch (Exception)
            {
                return null;//连接服务器失败  
            }
            //发送请求  
            dataStream.Write(dataArray, 0, dataArray.Length);
            dataStream.Close();
            //读取返回消息  
            string res = null;
            CommonResult result = null;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
                reader.Close();
                result = JsonConvert.DeserializeObject<CommonResult>(res);
            }
            catch (Exception ex)
            {
                string error = string.Format("微信Post发生错误！");
                LogHelper.WriteLog(typeof(Exception), error);
            }
            return result;  
        }

        public static CommonResult GetExecuteResult(string url)
        {
            HttpHelper helper = new HttpHelper();
            string content = helper.GetHtml(url);
            VerifyErrorCode(content);

            CommonResult result = JsonConvert.DeserializeObject<CommonResult>(content);
            return result;
        }

        /// <summary>
        /// 检查返回的记录，如果返回没有错误，或者结果提示成功，则不抛出异常
        /// </summary>
        /// <param name="content">返回的结果</param>
        /// <returns></returns>
        private static bool VerifyErrorCode(string content)
        {
            if (content.Contains("errcode"))
            {
                ErrorJsonResult errorResult = JsonConvert.DeserializeObject<ErrorJsonResult>(content);
                //非成功操作才记录异常，因为有些操作是返回正常的结果（{"errcode": 0, "errmsg": "ok"}）
                if (errorResult != null && errorResult.errcode != 0)
                {
                    string error = string.Format("微信请求发生错误！错误代码：{0}，说明：{1}",
                        (int)errorResult.errcode, errorResult.errmsg);
                    LogHelper.WriteLog(typeof(string), error);

                    throw new Exception(error);//抛出错误
                }
            }
            return true;
        }

        public static string GetAccess_token(string url)
        {
            HttpHelper helper = new HttpHelper();
            string content = helper.GetHtml(url);
            VerifyErrorCode(content);

            if (content.Contains("errcode"))
            {
                CommonResult result = JsonConvert.DeserializeObject<CommonResult>(content);
                return result.errcode.ToString() + ": " + result.errmsg;
            }
            else
            {
                AuthJson result = JsonConvert.DeserializeObject<AuthJson>(content);
                return result.openid;
            }
        }
    }
}