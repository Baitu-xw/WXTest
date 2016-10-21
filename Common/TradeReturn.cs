using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WX_TennisAssociation.Common
{
    /// <summary>
    /// 交易完成返回的信息
    /// </summary>
    [XmlRoot(ElementName = "xml")]
    public class TradeReturn
    {
        public string appid { set; get; }

        public string attach { set; get; }

        public string bank_type { set; get; }

        public string cash_fee { set; get; }

        public string fee_type { set; get; }

        public string is_subscribe { set; get; }

        public string mch_id { set; get; }

        public string nonce_str { set; get; }

        public string openid { set; get; }

        public string out_trade_no { set; get; }

        public string result_code { set; get; }

        public string return_code { set; get; }

        public string sign { set; get; }

        public string time_end { set; get; }

        public string total_fee { set; get; }

        public string trade_type { set; get; }

        public string transaction_id { set; get; }

        public virtual string ToXml()
        {
            return MyXmlHelper.ObjectToXml(this);
        }
    }
}