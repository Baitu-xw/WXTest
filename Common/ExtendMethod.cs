using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WX_TennisAssociation.Common
{
    public static class ExtendMethod
    {
        /// <summary>
        /// 判断是否为空
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsEmpty(this String s)
        {
            if (String.IsNullOrEmpty(s) || s.Trim().Length == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 验证是否在52个月内
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool Is52Week(this String s)
        {
            string[] week = {
                                "1","2","3","4","5","6","7","8","9","10",
                                "11","12","13","14","15","16","17","18","19","20",
                                "21","22","23","24","25","26","27","28","29","30",
                                "31","32","33","34","35","36","37","38","39","40",
                                "41","42","43","44","45","46","47","48","49","50",
                                "51","52" 
                            };
           return  week.Where(u => u == s).Any();
        }

        /// <summary>
        /// 判断是否为日期格式
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsDateTime(this String s)
        {
            //传入的日期对象如果为空，直接返回错误
            if (s.IsEmpty())
            {
                return false;
            }

            Regex reg = new Regex(@"((^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(10|12|0?[13578])([-\/\._])(3[01]|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(11|0?[469])([-\/\._])(30|[12][0-9]|0?[1-9])$)|(^((1[8-9]\d{2})|([2-9]\d{3}))([-\/\._])(0?2)([-\/\._])(2[0-8]|1[0-9]|0?[1-9])$)|(^([2468][048]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([3579][26]00)([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][0][48])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][2468][048])([-\/\._])(0?2)([-\/\._])(29)$)|(^([1][89][13579][26])([-\/\._])(0?2)([-\/\._])(29)$)|(^([2-9][0-9][13579][26])([-\/\._])(0?2)([-\/\._])(29)$))");
            return reg.IsMatch(s);
        }

        public static string ToExtString(this DateTime? time)
        {
            if (time == null||time.Value==null)
            {
                return "";
            }
            return time.Value.ToString("yyyy-MM-dd");
        }

        //判断是否为手机号码
        public static bool IsPhone(this string s)
        {
            if (s.Trim().IsEmpty()) return true;

            Regex reg = new Regex(@"^((\+86)|(86))?(1)\d{10}$");
            return reg.IsMatch(s);
        }

        /// <summary>
        /// 判断今天是第几周
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static int DayofWeek(DateTime date)
        { 
            //判断今天是第几周
            DateTime data = new DateTime(date.Year, 1, 1);
            int firstWeekDay = 0;
            firstWeekDay = 7 - ((int)data.DayOfWeek == 0 ? 7 : (int)data.DayOfWeek);

            var startWeek = 1 + (DateTime.Now.DayOfYear + firstWeekDay) / 7;

            return startWeek;
        }

        /// <summary>
        /// 判断传入的星期，是否在下4周内
        /// </summary>
        /// <param name="week"></param>
        /// <returns></returns>
        public static bool IsNext4Week(int year,int? week)
        {
            week = week ?? 0; 
            //判断今天是第几周
            DateTime data = new DateTime(year, 1, 1);
            int firstWeekDay = 0;
            firstWeekDay =7-((int)data.DayOfWeek == 0 ? 7 : (int)data.DayOfWeek); 

            var startWeek =1+(DateTime.Now.DayOfYear+firstWeekDay)/7; 
            var endWeek = startWeek + 4;
            if (week>= startWeek && week <endWeek)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 按周数换算开始日期
        /// </summary>
        /// <param name="year"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DateTime ConvertToStartDate(int year, int week)
        {

            DateTime data = new DateTime(year, 1, 1);
            int firstWeekDay = 0;
            //年初第一周特殊处理
            if (week == 1)
            {
                return data;
            }
            else
            {
                firstWeekDay = 7 - ((int)data.DayOfWeek == 0 ? 7 : (int)data.DayOfWeek); 
                //因老外每周从周日开始，所以需要多加1天
                int days = (week - 2) * 7 + firstWeekDay + 1;
                return data.AddDays(days);
            }
             
        }

        /// <summary>
        /// 按周数换算结束周数
        /// </summary>
        /// <param name="year"></param>
        /// <param name="week"></param>
        /// <returns></returns>
        public static DateTime ConvertToEndDate(int year, int week)
        {
            DateTime data = ConvertToStartDate(year, week);
            int firstWeekDay = 7 - ((int)data.DayOfWeek == 0 ? 7 : (int)data.DayOfWeek);
            return data.AddDays(firstWeekDay);

        }
        /// <summary>
        /// 正整数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsInt(this String s)
        {
            if (s.IsEmpty())
            {
                return false;
            }

            Regex reg = new Regex(@"^(0|([1-9]\d*))$");
            return reg.IsMatch(s);
        }

        /// <summary>
        /// 正整数
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static bool IsTime(this String s)
        {
            if (s.IsEmpty())
            {
                return false;
            }

            Regex reg = new Regex(@"^(([0-1]?[0-9])|([2][0-3])):([0-5]?[0-9])(:([0-5]?[0-9]))?$");
            return reg.IsMatch(s);
        }

    }
}
