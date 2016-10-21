using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_TennisAssociation.Common
{
    /// <summary>
    /// 判断文件路径
    /// </summary>
    public class FilePath
    {
        public static string GetFilePath(string filepath)
        {
            string strResultpath=string.Empty;
            string strReplace = filepath.Trim().Replace('\\','/');
            if (!strReplace.EndsWith("/"))
                strResultpath = strReplace + "/";
            else
                strResultpath = strReplace;

            return strResultpath;
        }
    }
}
