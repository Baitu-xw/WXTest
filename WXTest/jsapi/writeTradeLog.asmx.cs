using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Services;
using System.Xml;
using WX_TennisAssociation.BLL;
using WX_TennisAssociation.Common;

namespace WXTest.jsapi
{
    /// <summary>
    /// writeTradeLog 的摘要说明
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // 若要允许使用 ASP.NET AJAX 从脚本中调用此 Web 服务，请取消注释以下行。 
    // [System.Web.Script.Services.ScriptService]
    public class writeTradeLog : System.Web.Services.WebService
    {

        [WebMethod]
        public bool PayWeiXin()
        {
            string postString = string.Empty;
            if (HttpContext.Current.Request.HttpMethod.ToUpper() == "POST")
            {
                using (Stream stream = HttpContext.Current.Request.InputStream)
                {
                    Byte[] postBytes = new Byte[stream.Length];
                    stream.Read(postBytes, 0, (Int32)stream.Length);
                    postString = Encoding.UTF8.GetString(postBytes);
                }
            }
            System.Diagnostics.Debug.WriteLine(postString);

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(postString);
            XmlElement rootElement = doc.DocumentElement;

            TradeReturn tradeReturn = new TradeReturn();
            tradeReturn.appid = rootElement.SelectSingleNode("appid").InnerText;
            tradeReturn.attach = rootElement.SelectSingleNode("attach").InnerText;
            tradeReturn.bank_type = rootElement.SelectSingleNode("bank_type").InnerText;
            tradeReturn.cash_fee = rootElement.SelectSingleNode("cash_fee").InnerText;
            tradeReturn.fee_type = rootElement.SelectSingleNode("fee_type").InnerText;
            tradeReturn.is_subscribe = rootElement.SelectSingleNode("is_subscribe").InnerText;
            tradeReturn.mch_id = rootElement.SelectSingleNode("mch_id").InnerText;
            tradeReturn.nonce_str = rootElement.SelectSingleNode("nonce_str").InnerText;
            tradeReturn.openid = rootElement.SelectSingleNode("openid").InnerText;
            tradeReturn.out_trade_no = rootElement.SelectSingleNode("out_trade_no").InnerText;
            tradeReturn.result_code = rootElement.SelectSingleNode("result_code").InnerText;
            tradeReturn.return_code = rootElement.SelectSingleNode("return_code").InnerText;
            tradeReturn.sign = rootElement.SelectSingleNode("sign").InnerText;
            tradeReturn.time_end = rootElement.SelectSingleNode("time_end").InnerText;
            tradeReturn.total_fee = rootElement.SelectSingleNode("total_fee").InnerText;
            tradeReturn.trade_type = rootElement.SelectSingleNode("trade_type").InnerText;
            tradeReturn.transaction_id = rootElement.SelectSingleNode("transaction_id").InnerText;

            wx_tb_transactiondetailsBLL bll = new wx_tb_transactiondetailsBLL();

            bool boolUpdate = bll.WX_PersonalMember_Update(tradeReturn);
            System.Diagnostics.Debug.WriteLine(postString);
            return boolUpdate;
        }
    }
}
