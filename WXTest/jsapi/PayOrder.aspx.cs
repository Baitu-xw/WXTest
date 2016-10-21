using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WXPay;
using WX_TennisAssociation.Common;

namespace WXTest.jsapi
{
    public partial class PayOrder : System.Web.UI.Page
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
        protected string strOpenid = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["openid"] != null)
                {
                    strOpenid = Session["openid"].ToString();
                }
            }
        }

        protected void btn_pay_Click(object sender, EventArgs e)
        {
            int OrderAmount = 1;
            int shareID = 13;
            string orderID = "wx88888888888888881414411779";
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

                strOpenid = Session["openid"].ToString();
                UserJson userJson = wxApiDispatch.GetUserDetail(accessToken, strOpenid, "zh_CN");

                UnifiedOrder order = new UnifiedOrder();
                order.appid = appId;
                order.attach = "vinson";
                order.body = "12" + "拍币";
                order.device_info = "";
                order.mch_id = mch_id;
                order.nonce_str = WXpayUtil.getNoncestr();
                order.notify_url = "http://abelxu19.imwork.net/jsapi/pay.aspx";
                order.openid = userJson.openid;
                order.out_trade_no = orderID;
                order.trade_type = "JSAPI";
                order.spbill_create_ip = Page.Request.UserHostAddress;
                order.total_fee = OrderAmount;

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