using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WX_TennisAssociation.Common
{
    /// <summary>
    /// 菜单的Json字符串对象
    /// </summary>
    public class MenuJson
    {
        public List<MenuInfo> button { get; set; }

        public MenuJson()
        {
            button = new List<MenuInfo>();
        }
    }
}