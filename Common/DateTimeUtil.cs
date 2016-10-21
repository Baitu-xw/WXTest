using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WX_TennisAssociation.Common
{
    public class DateTimeUtil
    {
        /// <summary>
        /// 微信的CreateTime是当前与1970-01-01 00:00:00之间的秒数
        /// </summary>
        /// <param name=“dt”></param>
        /// <returns></returns>
        public static long DateTimeToInt(DateTime dt)
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1, 0, 0, 0, 0));
            long t = (dt.Ticks - startTime.Ticks)/10000000; //现在是10位，除10000调整为13位
            return t;
        }
    }
}