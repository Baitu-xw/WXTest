using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_CompetitionType
    {
        /// <summary>
        /// 比赛类型ID
        /// </summary>
       public int CompetitionType_ID {get;set;}
        /// <summary>
       /// 比赛类型名称：常规赛、月度赛、季度赛、年度总决赛
        /// </summary>
       public string CompetitionType_Name { get; set; }
    }
}
