using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_CompetitionSignUp
    {
        /// <summary>
        /// 比赛报名ID
        /// </summary>
        public int SignUpCpmpetition_ID{get;set;}
        /// <summary>
        /// 比赛ID
        /// </summary>
        public int  Competition_ID{get;set;}
        /// <summary>
        /// 报名状态:0(待审核)、1(报名成功)、2(报名失败)
        /// </summary>
        public int SignUpCompetition_Status{get;set;}
        /// <summary>
        /// 分组
        /// </summary>
        public int SignUpCompetition_Group{get;set;}
        /// <summary>
        /// 是否缴费
        /// </summary>
        public int Pay_Status{get;set;}
        /// <summary>
        /// 报名创建时间
        /// </summary>
        public DateTime? SignUpCompetition_CreateTime{get;set;}
        /// <summary>
        /// 报名更新时间
        /// </summary>
        public DateTime? SignUpCompetition_UpdateTime { get; set; }
    }
}
