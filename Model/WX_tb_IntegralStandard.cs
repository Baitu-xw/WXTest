using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_IntegralStandard
    {
        /// <summary>
        /// 积分ID
        /// </summary>
        public int RegularSeasonStandard_ID { get; set; }
        /// <summary>
        /// 比赛类型ID
        /// </summary>
        public int CompetitionType_ID { get; set; }
        /// <summary>
        /// 签位
        /// </summary>
        public int? PositionNum_ID { get; set; }
        /// <summary>
        /// 名次
        /// </summary>
        public int? Ranking { get; set; }
        /// <summary>
        /// 级别
        /// </summary>
        public int Level_ID { get; set; }
        /// <summary>
        /// 积分
        /// </summary>
        public int? Credit { get; set; }
    }
}
