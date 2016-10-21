using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_TransactionDetails
    {
        /// <summary>
        /// 交易清单ID
        /// </summary>
        public int TransactionDetails_ID { get; set; }
        /// <summary>
        /// 人员ID
        /// </summary>
        public int PersonalMember_ID { get; set; }
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string Openid { get; set; }
        /// <summary>
        /// 交易流水
        /// </summary>
        public string Transaction { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        public float? MoneyAmount { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public DateTime? CreateTime { get; set; }
    }
}
