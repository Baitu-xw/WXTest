using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace WX_TennisAssociation.Common
{
    public class CRegex : Regex
    {
        public static string GetText(string strData, string strRegex, string strKeyword)
        {
            Regex reg = new Regex(strRegex);
            Match match = reg.Match(strData);

            if (match.Length > 0)
            {
                return match.Groups[strKeyword].Value;
            }
            return string.Empty;
        }
    }
}