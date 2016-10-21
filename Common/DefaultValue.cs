using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_TennisAssociation.Common
{
    /// <summary>
    /// 获得默认值
    /// </summary>
    public class DefaultValue
    {
        /// <summary>
        /// 获得默认值
        /// </summary>
        /// <param name="strValue">传进去的字符串参数</param>
        /// <returns></returns>
        public static string GetDefaultValue(string strValue)
        {
            string strResult = null;

            if (string.IsNullOrEmpty(strValue))
                strResult = "-1";
            else
                strResult = strValue;

            return strResult;
        }
    }
}
