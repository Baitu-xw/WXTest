using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_CompetitionItem
    {
        /// <summary>
        /// 比赛项目ID
        /// </summary>
        public int CompetitionItem_ID{get;set;}
        /// <summary>
        /// 比赛项目：男子单打、女子单打、男子双打、女子双打、混合双打
        /// </summary>
        public string CompetitionItem_Name { get; set; }
    }
}
