using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using TestLog4Net;
using System.Net;
using System.IO;

namespace WX_TennisAssociation.Common
{
    public static class JsonHelper
    {
        private static JsonSerializerSettings _jsonSettings;

        static JsonHelper()
        {
            IsoDateTimeConverter datetimeConverter = new IsoDateTimeConverter();
            datetimeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";

            _jsonSettings = new JsonSerializerSettings();
            _jsonSettings.MissingMemberHandling = Newtonsoft.Json.MissingMemberHandling.Ignore;
            _jsonSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            _jsonSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
            _jsonSettings.Converters.Add(datetimeConverter);
        }

        /// <summary>
        /// 将指定的对象序列化成 JSON 数据。
        /// </summary>
        /// <param name="obj">要序列化的对象。</param>
        /// <returns></returns>
        public static string ToJson(this object obj)
        {
            try
            {
                if (null == obj)
                    return null;

                return JsonConvert.SerializeObject(obj, Formatting.None, _jsonSettings);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(Exception), ex);
                return null;
            }
        }

        /// <summary>
        /// 将指定的 JSON 数据反序列化成指定对象。
        /// </summary>
        /// <typeparam name="T">对象类型。</typeparam>
        /// <param name="json">JSON 数据。</param>
        /// <returns></returns>
        public static T FromJson<T>(this string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(json, _jsonSettings);
            }
            catch (Exception ex)
            {
                LogHelper.WriteLog(typeof(Exception), ex);
                return default(T);
            }
        }
    }


    /// <summary>
    /// Json字符串操作辅助类
    /// </summary>
    public class JsonHelper<T> where T : class, new()
    {
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

        /// <summary>
        /// 转换Json字符串到具体的对象
        /// </summary>
        /// <param name="url">返回Json数据的链接地址</param>
        /// <returns></returns>
        public static T ConvertJson(string url)
        {
            HttpHelper helper = new HttpHelper();
            string content = helper.GetHtml(url);
            VerifyErrorCode(content);

            T result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }


        /// <summary>
        /// 转换Json字符串到具体的对象
        /// </summary>
        /// <param name="url">返回Json数据的链接地址</param>
        /// <returns></returns>
        public static T ConvertJson(string url, string postData)
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
            T result = null;
            try
            {
                var response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                res = reader.ReadToEnd();
                reader.Close();
                result = JsonConvert.DeserializeObject<T>(res);
            }
            catch (Exception ex)
            {
                string error = string.Format("微信Post发生错误！");
                LogHelper.WriteLog(typeof(Exception), error);
            }
            return result;  
        }
    }
}