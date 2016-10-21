using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WX_TennisAssociation.Model;
using System.Data;
using System.Data.SqlClient;
using WX_TennisAssociation.Common;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;

namespace WX_TennisAssociation.DAL
{
    #region 会员信息数据访问
    /// <summary>
    /// 会员信息数据访问
    /// </summary>
    public class PersonnalMemberDAL
    {
        //数据库连接字符串
        private string strConnection = System.Configuration.ConfigurationManager.AppSettings["WXTennis_MySQLConnectionString"];

        #region 过滤emojizifu
        private String filterEmoji(string source)
        {
            string result = Regex.Replace(source, @"\p{Cs}", "*");
            return result;
        } 
        #endregion

        #region 添加微信成员
        /// <summary>
        /// 添加微信成员
        /// </summary>
        /// <param name="model">微信成员实体</param>
        /// <returns>返回是否添加成功</returns>
        public bool WX_PersonalMember_Insert(UserJson model)
        {
            MySqlParameter[] param = new MySqlParameter[]
            {
                new MySqlParameter("?pSubscribe", model.subscribe),
                new MySqlParameter("?pOpenid", model.openid),
                new MySqlParameter("?pPersonalMember_NickName", filterEmoji(model.nickname)),
                new MySqlParameter("?pGender", model.sex),
                new MySqlParameter("?pLanguage", model.language),
                new MySqlParameter("?pCity", model.city),
                new MySqlParameter("?pProvince", model.province),
                new MySqlParameter("?pCountry", model.country),
                new MySqlParameter("?pHeadimgurl", model.headimgurl),
                new MySqlParameter("?pSubscribe_time", model.subscribe_time)
            };

            bool bInsert = false;

            MySqlConnection conn = ConnectionString.GetMySQLConnectionString(strConnection);

            try
            {
                int i = MySQLHelperClass.ExecuteNonQuery(conn, CommandType.StoredProcedure,
                    "sp_WX_PersonalMember_Insert", param);
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

        #region 判断微信用户是否是会员
        /// <summary>
        /// 判断微信用户是否是会员
        /// </summary>
        /// <returns>返回是否是会员</returns>
        public bool isMember(string strOpenId)
        {
            MySqlParameter[] param = new MySqlParameter[] { 
            new MySqlParameter("?pOpenId",strOpenId)
            };
            bool isMem = false;

            MySqlConnection conn = ConnectionString.GetMySQLConnectionString(strConnection);
            try
            {
                object obj = MySQLHelperClass.ExecuteScalar(conn, CommandType.StoredProcedure, "sp_IsMember", param);

                string strResult = obj + string.Empty;
                if (!string.IsNullOrEmpty(strResult))
                {
                    isMem = true;
                }
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile(ex); throw ex;
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
            }
            return isMem;
        }
        #endregion
    }
    #endregion
}
