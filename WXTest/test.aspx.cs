using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXPay;
using WX_TennisAssociation.BLL;
using WX_TennisAssociation.Common;

namespace WXTest
{
    public partial class test : System.Web.UI.Page
    {
        protected string code = string.Empty;
        protected string OrderAmount = string.Empty;
        protected string OrderID = string.Empty;
        protected string OrderTime = string.Empty;
        protected string OrderGive = string.Empty;
        protected string ImagePath = string.Empty;
        protected string appId = string.Empty;
        protected string secret = string.Empty;
        protected string timeStamp = string.Empty;
        protected string nonceStr = string.Empty;
        protected string prepay_id = string.Empty;
        protected string paySign = string.Empty;
        protected UserJson userJson;



        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                code = HttpContext.Current.Request.QueryString["code"];
                lab_code.Text = code;
                WeixinApiDispatch wxApiDispatch = new WeixinApiDispatch();
                string result = wxApiDispatch.GetAccess_token(code);
                lab_openid.Text = result;

                appId = ConfigurationManager.AppSettings["appid"];
                secret = ConfigurationManager.AppSettings["secret"];
                string accessToken = wxApiDispatch.GetAccessToken(appId, secret);

                System.Diagnostics.Debug.WriteLine("accessToken值: ");
                System.Diagnostics.Debug.WriteLine(accessToken);

                userJson = wxApiDispatch.GetUserDetail(accessToken, result, "zh_CN");
                txt_user.Text = userJson.nickname.ToString();
                Session["openid"] = userJson.openid;
            }
        }

        private string getString(int count)  
       {  
           int number;  
           string checkCode = String.Empty;     //存放随机码的字符串   
  
           System.Random random = new Random();  
  
           for (int i = 0; i < count; i++) //产生4位校验码   
           {  
               number = random.Next();  
               number = number % 36;  
               if (number < 10)  
               {  
                   number += 48;    //数字0-9编码在48-57   
               }  
               else  
               {  
                   number += 55;    //字母A-Z编码在65-90   
               }  
  
               checkCode += ((char)number).ToString();  
           }
            return checkCode;
       }  

        protected void btn_pay_OnClick(object sender, EventArgs e)
        {
            bool booResult = false;
            int OrderAmount = 1;
            int shareID = 13;
            string strTime = DateTime.Now.ToString("yyyyMMddHHmmss");
            string strRand = getString(16);
            string orderID = "wx" + strTime + strRand;
            try
            {
                WXpayUtil wXpayUtil = new WXpayUtil();
                string paySignKey = ConfigurationManager.AppSettings["paySignKey"].ToString();
                string AppSecret = ConfigurationManager.AppSettings["secret"].ToString();
                string mch_id = ConfigurationManager.AppSettings["mch_id"].ToString();
                appId = ConfigurationManager.AppSettings["AppId"].ToString();

                WeixinApiDispatch wxApiDispatch = new WeixinApiDispatch();
                string accessToken = wxApiDispatch.GetAccessToken(appId, AppSecret);

                System.Diagnostics.Debug.WriteLine("accessToken值: ");
                System.Diagnostics.Debug.WriteLine(accessToken);

                string strOpenid = Session["openid"].ToString();
                UserJson userJson = wxApiDispatch.GetUserDetail(accessToken, strOpenid, "zh_CN");

                UnifiedOrder order = new UnifiedOrder();
                order.appid = appId;
                order.attach = "vinson";
                order.body = "12" + "拍币";
                order.device_info = "";
                order.mch_id = mch_id;
                order.nonce_str = WXpayUtil.getNoncestr();
                order.notify_url = ConfigurationManager.AppSettings["notify_url"].ToString(); 
                order.openid = userJson.openid;
                order.out_trade_no = orderID;
                order.trade_type = "JSAPI";
                order.spbill_create_ip = Page.Request.UserHostAddress;
                order.total_fee = OrderAmount;

                wx_tb_transactiondetailsBLL bll = new wx_tb_transactiondetailsBLL();
                try
                {
                    booResult = bll.WX_PersonalMember_Insert(order.appid,order.attach,order.body,order.device_info,
                        order.mch_id,order.nonce_str,order.notify_url,order.openid,order.out_trade_no,
                        order.trade_type,order.spbill_create_ip,order.total_fee.ToString());
                }
                catch (Exception ex)
                {
                    WriteLog.WriteLogFile(ex);
                    throw ex;
                }

                prepay_id = wXpayUtil.getPrepay_id(order, paySignKey);
                timeStamp = WXpayUtil.getTimestamp();
                nonceStr = WXpayUtil.getNoncestr();

                SortedDictionary<string, string> sParams = new SortedDictionary<string, string>();
                sParams.Add("appId", appId);
                sParams.Add("timeStamp", timeStamp);
                sParams.Add("nonceStr", nonceStr);
                sParams.Add("package", "prepay_id=" + prepay_id);
                sParams.Add("signType", "MD5");
                paySign = wXpayUtil.getsign(sParams, paySignKey);
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
                return;
            }

            Response.Redirect("http://abelxu19.imwork.net/jsapi/pay.aspx?showwxpaytitle=1&appId=" + appId +
                "&timeStamp=" + timeStamp +
                "&nonceStr=" + nonceStr +
                "&prepay_id=" + prepay_id +
                "&signType=MD5&paySign=" + paySign +
                "&OrderID=" + OrderID);
        }
    }
}