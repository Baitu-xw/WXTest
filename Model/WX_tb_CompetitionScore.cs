using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_CompetitionScore
    {
        /// <summary>
        /// 比分ID
        /// </summary>
        public int CompetitionScore_ID { get; set; }
        /// <summary>
        /// 各比赛报名人员ID
        /// </summary>
        public int SignUpCpmpetition_ID { get; set; }
        /// <summary>
        /// 第一场比赛赢得的比分
        /// </summary>
        public int? MatchFirstWin { get; set; }
        /// <summary>
        /// 第一场比赛输得的比分
        /// </summary>
        public int? MatchFirstLose { get; set; }
        /// <summary>
        /// 第二场比赛赢得的比分
        /// </summary>
        public int? MatchSecondWin { get; set; }
        /// <summary>
        /// 第二场比赛输得的比分
        /// </summary>
        public int? MatchSecondLose { get; set; }
        /// <summary>
        /// 第三场比赛赢得的比分
        /// </summary>
        public int? MatchThirdWin { get; set; }
        /// <summary>
        /// 第三场比赛输得的比分
        /// </summary>
        public int? MatchThirdLose { get; set; }
        /// <summary>
        /// 第四场比赛赢得的比分
        /// </summary>
        public int? MatchFourthWin { get; set; }
        /// <summary>
        /// 第四场比赛输得的比分
        /// </summary>
        public int? MatchFourthLose { get; set; }
        /// <summary>
        /// 第五场比赛赢得的比分
        /// </summary>
        public int? MatchFifthWin { get; set; }
        /// <summary>
        /// 第五场比赛输得的比分
        /// </summary>
        public int? MatchFifthLose { get; set; }
        /// <summary>
        /// 第六场比赛赢得的比分
        /// </summary>
        public int? MatchSixthWin { get; set; }
        /// <summary>
        /// 第六场比赛输得的比分
        /// </summary>
        public int? MatchSixthLose { get; set; }
        /// <summary>
        /// 第七场比赛赢得的比分
        /// </summary>
        public int? MatchSeventhWin { get; set; }
        /// <summary>
        /// 第七场比赛输得的比分
        /// </summary>
        public int? MatchSeventhLose { get; set; }
    }
}
