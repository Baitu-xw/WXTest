using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_TennisAssociation.Common
{
    #region 生成随机数
    /// <summary>
    /// 生成随机数
    /// </summary>
    public class RandomNumber
    {
        /// <summary>
        /// 获得14位随机数
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public static string GetRandomNumber(int i)
        {
            Random random = new Random();

            byte[] bData = BitConverter.GetBytes(Convert.ToInt32(DateTime.Now.ToString("MMddhhmmss")) + DateTime.Now.Millisecond + random.Next(10000, 99999));

            return BitConverter.ToString(bData).ToUpper().Replace("-", "") + random.Next(100, 999) + (i + string.Empty).PadLeft(3, '0');
        }
    }
    #endregion
}
