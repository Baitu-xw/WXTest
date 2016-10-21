using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace WXPay
{
    public class MD5Util
    {
        public MD5Util()
        {
            
        }

        /// <summary>
        /// 获取大写的MD5签名结果
        /// </summary>
        /// <param name="encypStr"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        public static string GetMD5(string encypStr, string charset)
        {
            string retStr = string.Empty;

            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //创建md5对象
            byte[] inputBytes;
            byte[] outpuBytes;

            //使用GB2312编码方式把字符串转化为字符节数组
            try
            {
                inputBytes = Encoding.GetEncoding(charset).GetBytes(encypStr);
            }
            catch (Exception ex)
            {
                inputBytes = Encoding.GetEncoding("GB2312").GetBytes(encypStr);
            }
            outpuBytes = md5.ComputeHash(inputBytes);

            retStr = System.BitConverter.ToString(outpuBytes);
            retStr = retStr.Replace("-", "").ToUpper();
            return retStr;
        }
    }
}
