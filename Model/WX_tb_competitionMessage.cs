using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_competitionMessage
    {
        /// <summary>
        /// 比赛ID
        /// </summary>
        public int Competition_ID { get; set; }
        /// <summary>
        /// 比赛类型ID
        /// </summary>
        public int CompetitionType_ID { get; set; }
        /// <summary>
        /// 比赛级别ID
        /// </summary>
        public int CompetitionLevel_ID { get; set; }
        /// <summary>
        /// 比赛项目ID
        /// </summary>
        public int CompetitionItem_ID { get; set; }
        /// <summary>
        /// 签位ID
        /// </summary>
        public int PositionNum_ID { get; set; }
        /// <summary>
        /// 赛事编号
        /// </summary>
        public string Competition_No { get; set; }
        /// <summary>
        /// 比赛标题
        /// </summary>
        public string Competition_Title { get; set; }
        /// <summary>
        /// 比赛报名开始时间
        /// </summary>
        public DateTime? Competition_SignUpBeginTime { get; set; }
        /// <summary>
        /// 比赛报名结束时间
        /// </summary>
        public DateTime? Competition_SignUpEndTime { get; set; }
        /// <summary>
        /// 比赛时间
        /// </summary>
        public DateTime? Competition_Time { get; set; }
        /// <summary>
        /// 比赛状态:0(报名)、1(审核)、2(进行中)、3(结束)
        /// </summary>
        public int Competition_Status { get; set; }
        /// <summary>
        /// 比赛场地
        /// </summary>
        public string Competition_Court { get; set; }
        /// <summary>
        /// 比赛创建时间
        /// </summary>
        public DateTime? Competition_CreateTime { get; set; }
        /// <summary>
        /// 比赛更新时间
        /// </summary>
        public DateTime? Competition_UpdateTime { get; set; }
    }
}
