using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_CompetitionSignUpPerson
    {
        /// <summary>
        /// 各比赛报名人员ID
        /// </summary>
       public int  CompetitionSignUpPerson_ID{get;set;}
        /// <summary>
       /// 比赛报名ID
        /// </summary>
       public int CompetitionSignUp_ID{get;set;}
        /// <summary>
        /// 人员ID
        /// </summary>
       public int PersonalMember_ID{get;set;}
        /// <summary>
       /// 名次
        /// </summary>
       public int? Ranking{get;set;}
        /// <summary>
       /// 积分
        /// </summary>
       public int? Score { get; set; }
    }
}
