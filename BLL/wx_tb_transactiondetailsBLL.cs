using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX_TennisAssociation.Common;
using WX_TennisAssociation.DAL;

namespace WX_TennisAssociation.BLL
{
    #region 交易记录
    /// <summary>
    /// 交易记录操作
    /// </summary>
    public class wx_tb_transactiondetailsBLL
    {
        wx_tb_transactiondetailsDAL dal = new wx_tb_transactiondetailsDAL();

        /// <summary>
        /// 交易记录插入
        /// </summary>
        /// <param name="appid"></param>
        /// <param name="attach"></param>
        /// <param name="body"></param>
        /// <param name="device_info"></param>
        /// <param name="mch_id"></param>
        /// <param name="nonce_str"></param>
        /// <param name="notify_url"></param>
        /// <param name="openid"></param>
        /// <param name="out_trade_no"></param>
        /// <param name="trade_type"></param>
        /// <param name="spbill_create_ip"></param>
        /// <param name="total_fee"></param>
        /// <returns></returns>
        public bool WX_PersonalMember_Insert(string appid, string attach, string body, string device_info,
            string mch_id, string nonce_str, string notify_url, string openid, string out_trade_no,
            string trade_type, string spbill_create_ip, string total_fee)
        {
            return dal.WX_PersonalMember_Insert(appid, attach, body, device_info,
            mch_id, nonce_str, notify_url, openid, out_trade_no,
            trade_type, spbill_create_ip, total_fee);
        }

        /// <summary>
        /// 交易记录更新
        /// </summary>
        /// <param name="tradeReturn"></param>
        /// <returns></returns>
        public bool WX_PersonalMember_Update(TradeReturn tradeReturn)
        {
            return dal.WX_PersonalMember_Update(tradeReturn);
        }
    }
    #endregion
}
