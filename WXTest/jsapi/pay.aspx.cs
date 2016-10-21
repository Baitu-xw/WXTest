using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WXTest.jsapi
{

    public partial class pay : System.Web.UI.Page
    {
        protected string appId = string.Empty;
        protected string timeStamp = string.Empty;
        protected string nonceStr = string.Empty;
        protected string prepay_id = string.Empty;
        protected string paySign = string.Empty;
        protected string OrderID = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            appId = Request.QueryString["appId"];
            timeStamp = Request.QueryString["timeStamp"];
            nonceStr = Request.QueryString["nonceStr"];
            prepay_id = Request.QueryString["prepay_id"];
            paySign = Request.QueryString["paySign"];
            OrderID = Request.QueryString["OrderID"];
        }
    }
}