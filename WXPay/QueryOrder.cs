using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPay
{
    /// <summary>
    /// 微信订单查询接口请求对象
    /// </summary>
    [Serializable]
    public class QueryOrder
    {
        /// 公共号ID(微信分配的公众账号 ID)
        public string appid { get; set; }

        /// 商户号(微信支付分配的商户号)
        public string mch_id { get; set; }

        /// 微信订单号，优先使用
        public string transaction_id { get; set; }

        /// 商户系统内部订单号
        public string out_trade_no { get; set; }

        /// 随机字符串，不长于 32 位
        public string nonce_str { get; set; }

        /// 签名，参与签名参数：appid，mch_id，transaction_id，out_trade_no，nonce_str，key
        public string sign { get; set; }
    }
}
