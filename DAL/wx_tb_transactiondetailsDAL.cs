using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WX_TennisAssociation.Common;

namespace WX_TennisAssociation.DAL
{
    #region 交易访问
    /// <summary>
    /// 交易访问
    /// </summary>
    public class wx_tb_transactiondetailsDAL
    {
        //数据库连接字符串
        private string strConnection = System.Configuration.ConfigurationManager.AppSettings["WXTennis_MySQLConnectionString"];
        
        #region 添加交易记录
        /// <summary>
        /// 添加交易记录
        /// </summary>
        /// <param name="string">相关参数</param>
        /// <returns>返回是否添加成功</returns>
        public bool WX_PersonalMember_Insert(string appid, string attach, string body, string device_info,
            string mch_id, string nonce_str, string notify_url, string openid, string out_trade_no,
            string trade_type, string spbill_create_ip, string total_fee)
        {
            MySqlParameter[] param = new MySqlParameter[]
            {
                new MySqlParameter("?pappid", appid),
                new MySqlParameter("?pattach", attach),
                new MySqlParameter("?pbody", body),
                new MySqlParameter("?pdevice_info", device_info),

                new MySqlParameter("?pmch_id", mch_id),
                new MySqlParameter("?pnonce_str", nonce_str),
                new MySqlParameter("?pnotify_url", notify_url),
                new MySqlParameter("?popenid", openid),
                new MySqlParameter("?pout_trade_no", out_trade_no),

                new MySqlParameter("?ptrade_type", trade_type),
                new MySqlParameter("?pspbill_create_ip", spbill_create_ip),
                new MySqlParameter("?ptotal_fee", total_fee)
            };

            bool bInsert = false;

            MySqlConnection conn = ConnectionString.GetMySQLConnectionString(strConnection);

            try
            {
                int i = MySQLHelperClass.ExecuteNonQuery(conn, CommandType.StoredProcedure,
                    "sp_WX_tb_transactiondetails_Insert", param);
                if (i > 0)
                    bInsert = true;
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile(ex);
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return bInsert;
        }
        #endregion


        #region 更新交易记录
        /// <summary>
        /// 更新交易记录
        /// </summary>
        /// <param name="string">相关参数</param>
        /// <returns>返回是否更新成功</returns>
        public bool WX_PersonalMember_Update(TradeReturn tradeReturn)
        {
            MySqlParameter[] param = new MySqlParameter[]
            {
                new MySqlParameter("?pbank_type", tradeReturn.bank_type),
                new MySqlParameter("?pcash_fee", tradeReturn.cash_fee),
                new MySqlParameter("?pfee_type", tradeReturn.fee_type),
                new MySqlParameter("?pis_subscribe", tradeReturn.is_subscribe),

                new MySqlParameter("?presult_code",tradeReturn.result_code),
                new MySqlParameter("?preturn_code", tradeReturn.return_code),
                new MySqlParameter("?psign",tradeReturn.sign),
                new MySqlParameter("?ptime_end", tradeReturn.time_end),
                new MySqlParameter("?ptransaction_id", tradeReturn.transaction_id),
                new MySqlParameter("?pout_trade_no", tradeReturn.out_trade_no)
            };

            bool bUpdate = false;

            MySqlConnection conn = ConnectionString.GetMySQLConnectionString(strConnection);

            try
            {
                int i = MySQLHelperClass.ExecuteNonQuery(conn, CommandType.StoredProcedure,
                    "sp_WX_tb_transactiondetails_Update", param);
                if (i > 0)
                    bUpdate = true;
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile(ex);
                throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return bUpdate;
        }
        #endregion
    }
    #endregion
}
