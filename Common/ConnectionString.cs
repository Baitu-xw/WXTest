using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;

namespace WX_TennisAssociation.Common
{
    /// <summary>
    /// ADO.Net连接字符串
    /// </summary>
    public class ConnectionString
    {
        /// <summary>
        /// 获得ADO.Net连接字符串
        /// </summary>
        /// <param name="strConn"></param>
        /// <returns></returns>
        public static SqlConnection GetConnectionString(string strConn)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strConn);
                return conn;
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile(ex);throw ex;
            }
        }

        /// <summary>
        /// 获得MySQL ADO.Net连接字符串
        /// </summary>
        /// <param name="strMySQLConn"></param>
        /// <returns></returns>
        public static MySqlConnection GetMySQLConnectionString(string strMySQLConn)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(strMySQLConn);
                return conn;
            }
            catch (Exception ex)
            {
                WriteLog.WriteLogFile(ex);throw ex;
            }
        }
    }
}
