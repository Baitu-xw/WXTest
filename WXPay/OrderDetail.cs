﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WXPay
{
    /// <summary>
    /// 微信订单明细
    /// </summary>
    [Serializable]
    public class OrderDetail
    {
        /// 返回状态码，SUCCESS/FAIL 此字段是通信标识，非交易标识，交易是否成功需要查看trade_state来判断
        public string return_code { get; set; }

        /// 返回信息返回信息，如非空，为错误原因 签名失败 参数格式校验错误
        public string return_msg { get; set; }

        /// 公共号ID(微信分配的公众账号 ID)
        public string appid { get; set; }

        /// 商户号(微信支付分配的商户号)
        public string mch_id { get; set; }

        /// 随机字符串，不长于32位
        public string nonce_str { get; set; }

        /// 签名
        public string sign { get; set; }

        /// 业务结果,SUCCESS/FAIL
        public string result_code { get; set; }

        /// 错误代码
        public string err_code { get; set; }

        /// 错误代码描述
        public string err_code_des { get; set; }

        /// 交易状态
        ///SUCCESS—支付成功
        ///REFUND—转入退款
        ///NOTPAY—未支付
        ///CLOSED—已关闭
        ///REVOKED—已撤销
        ///USERPAYING--用户支付中
        ///NOPAY--未支付(输入密码或确认支付超时) PAYERROR--支付失败(其他原因，如银行返回失败)
        public string trade_state { get; set; }

        /// 微信支付分配的终端设备号
        public string device_info { get; set; }

        /// 用户在商户appid下的唯一标识
        public string openid { get; set; }

        /// 用户是否关注公众账号，Y-关注，N-未关注，仅在公众账号类型支付有效
        public string is_subscribe { get; set; }

        /// 交易类型,JSAPI、NATIVE、MICROPAY、APP
        public string trade_type { get; set; }

        /// 银行类型，采用字符串类型的银行标识
        public string bank_type { get; set; }

        /// 订单总金额，单位为分
        public string total_fee { get; set; }

        /// 现金券支付金额订单总金额，订单总金额-现金券金额为现金支付金额
        public string coupon_fee { get; set; }

        /// 货币类型，符合ISO 4217标准的三位字母代码，默认人民币：CNY
        public string fee_type { get; set; }

        /// 微信支付订单号
        public string transaction_id { get; set; }

        /// 

        /// 商户系统的订单号，与请求一致。
        /// 

        public string out_trade_no { get; set; }

        /// 商家数据包，原样返回
        public string attach { get; set; }

        /// 支付完成时间，格式为yyyyMMddhhmmss，如2009年12月27日9点10分10秒表示为20091227091010。
        /// 时区为GMT+8 beijing。该时间取自微信支付服务器
        public string time_end { get; set; }
    }
}
