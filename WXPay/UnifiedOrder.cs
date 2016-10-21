using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPay
{
    /// <summary>
    /// 微信同一接口请求对象
    /// </summary>
    [Serializable]
    public class UnifiedOrder
    {
        /// 公共号ID(微信分配的公众账号 ID)
        public string appid { get; set; }

        /// 商户号(微信支付分配的商户号)
        public string mch_id { get; set; }

        /// 微信支付分配的终端设备号
        public string device_info { get; set; }

        /// 随机字符串，不长于 32 位
        public string nonce_str { get; set; }

        /// 签名
        public string sign { get; set; }

        /// 商品描述
        public string body { get; set; }

        /// 附加数据，原样返回
        public string attach { get; set; }

        /// 商户系统内部的订单号,32个字符内、可包含字母,确保在商户系统唯一,详细说明
        public string out_trade_no { get; set; }

        /// 订单总金额，单位为分，不能带小数点
        public int total_fee { get; set; }

        /// 终端IP
        public string spbill_create_ip { get; set; }

        /// 订 单 生 成 时 间 ， 格 式 为yyyyMMddHHmmss，如 2009 年12 月 25 日 9 点 10 分 10 秒表示为 20091225091010。时区为 GMT+8 beijing。该时间取自商户服务器
        public string time_start { get; set; }
        /// 

        /// 交易结束时间
        public string time_expire { get; set; }

        /// 商品标记 商品标记，该字段不能随便填，不使用请填空，使用说明详见第 5 节
        public string goods_tag { get; set; }

        /// 接收微信支付成功通知
        public string notify_url { get; set; }

        /// JSAPI、NATIVE、APP
        public string trade_type { get; set; }

        /// 用户标识 trade_type 为 JSAPI时，此参数必传
        public string openid { get; set; }

        /// 只在 trade_type 为 NATIVE时需要填写。
        public string product_id { get; set; }
    }
}
