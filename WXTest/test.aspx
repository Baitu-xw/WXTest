<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="WXTest.test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <div>哈哈哈哈，嘿嘿嘿</div>
        <div>
            <table>
            <tr><td><asp:Label ID="lab_code" runat="server" Text="Label"></asp:Label></td></tr>
            <tr><td><asp:Label ID="lab_openid" runat="server" Text="Label"></asp:Label></td></tr>
            <tr><td><asp:TextBox ID="txt_user" runat="server"></asp:TextBox></td></tr>
            <tr><td><asp:Button ID="btn_pay" runat="server" Text="支付" OnClick="btn_pay_OnClick"/></td></tr>
            <%--<%--<tr><td><%--<a href="jsapi/PayOrder.aspx">点击</a></td></tr>--%>
            <%--<tr><td>
                <asp:LinkButton ID="lbt_pay" runat="server">LinkButton</asp:LinkButton></td></tr>--%>
            </table>
        </div>
    </div>
    </form>
</body>
</html>
