using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_AwardRecords
    {
        /// <summary>
        /// 奖惩ID
        /// </summary>
        public int AwardRecords_ID{get;set;}
        /// <summary>
        /// 人员ID
        /// </summary>
        public int PersonalMember_ID{get;set;}
        /// <summary>
        /// 奖惩明细
        /// </summary>
        public int AwardRecords_Text { get; set; }
    }
}
