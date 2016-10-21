<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PayOrder.aspx.cs" Inherits="WXTest.jsapi.PayOrder" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <script type="text/javascript">
        var appId = "<%=appId %>";
        var timeStamp = "<%=timeStamp %>";
        var nonceStr = "<%=nonceStr %>";
        var prepay_id = "<%=prepay_id %>";
        var paySign = "<%=paySign %>";
        var OrderID = "<%=OrderID %>";
        //alert("appId:" + appId + ",timeStamp:" + timeStamp + ",nonceStr:" + nonceStr + ",prepay_id:" + prepay_id + ",paySign:" + paySign);
        //return;
        function onBridgeReady() {
            WeixinJSBridge.invoke(
           'getBrandWCPayRequest', {
               "appId": appId,     //公众号名称，由商户传入     
               "timeStamp": timeStamp,         //时间戳，自1970年以来的秒数     
               "nonceStr": nonceStr, //随机串     
               "package": "prepay_id=" + prepay_id,
               "signType": "MD5",         //微信签名方式:     
               "paySign": paySign //微信签名 
           },
           function (res) {
               if (res.err_msg == "get_brand_wcpay_request:ok") {
                   $(function () {
                       $.ajax({
                           contentType: "application/json",
                           url: "/WS/vinson.asmx/payWeiXin",
                           data: "{OrderID:'" + OrderID + "'}",
                           type: "POST",
                           dataType: "json",
                           success: function (json) {
                               json = eval("(" + json.d + ")");
                               if (json.success == "success") {
                                   $("#tip").text("支付成功，正在跳转......");
                                   window.location = "http://abelxu19.imwork.net/successful.aspx";
                               }
                               else {
                                   $("#tip").text(json.msg);
                                   alert(json.msg);
                                   window.location = "";
                               }
                           },
                           error: function (err, ex) {http://http://abelxu19.imwork.net/fail.aspx
                               alert(err.responseText);
                           }
                       });
                   })
               }     // 使用以上方式判断前端返回,微信团队郑重提示：res.err_msg将在用户支付成功后返回    ok，但并不保证它绝对可靠。 
               else {
                   alert("交易取消");
                   window.location = "http://http://abelxu19.imwork.net/PayOrder.aspx";
               }
           }
       );
        }
        if (typeof WeixinJSBridge == "undefined") {
            if (document.addEventListener) {
                document.addEventListener('WeixinJSBridgeReady', onBridgeReady, false);
            } else if (document.attachEvent) {
                document.attachEvent('WeixinJSBridgeReady', onBridgeReady);
                document.attachEvent('onWeixinJSBridgeReady', onBridgeReady);
            }
        } else {
            onBridgeReady();
        }
</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>这是OrderPay页面</div>
        <div>
            <asp:Button ID="btn_pay" runat="server" Text="支付" OnClick="btn_pay_Click" />
        </div>
    </div>
    </form>
</body>
</html>
