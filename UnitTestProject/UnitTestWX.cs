using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WX_TennisAssociation.Common;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestWX
    {
        #region 测试BaseMessage类
        [TestMethod]
        public void BaseMessage_Test()
        {
            BaseMessage bm = new BaseMessage();
            bm.FromUserName = "AbelXu";
            bm.MsgType = "text";
            bm.ToUserName = "Lucy";

            System.Diagnostics.Debug.WriteLine("xml值: ");
            System.Diagnostics.Debug.WriteLine(bm.ToXml());
        }
        #endregion

        #region 测试MyXmlHelper.ObjectToXml函数
        [TestMethod]
        public void ObjectToXml_Test()
        {
            BaseMessage bm = new BaseMessage();
            bm.FromUserName = "AbelXu";
            bm.MsgType = "text";
            bm.ToUserName = "Lucy";

            //MyXmlHelper myXmlHelper = new MyXmlHelper();
            string bmXml = MyXmlHelper.ObjectToXml(bm);
            System.Diagnostics.Debug.WriteLine("xml值: ");
            System.Diagnostics.Debug.WriteLine(bmXml);
            System.Diagnostics.Debug.WriteLine("xml值: ");

            string toXml = bm.ToXml();
            System.Diagnostics.Debug.WriteLine("xml值: ");
            System.Diagnostics.Debug.WriteLine(toXml);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试ResponseText类
        [TestMethod]
        public void ResponseText_Test()
        {
            ResponseText responseText = new ResponseText();
            responseText.FromUserName = "AbelXu";
            responseText.MsgType = "text";
            responseText.ToUserName = "Lucy";
            responseText.Content = "这是一个测试，哈哈哈哈，abel。";

            string bmXml = MyXmlHelper.ObjectToXml(responseText);
            System.Diagnostics.Debug.WriteLine("xml值: ");
            System.Diagnostics.Debug.WriteLine(bmXml);
            System.Diagnostics.Debug.WriteLine("xml值: ");

            string toXml = responseText.ToXml();
            System.Diagnostics.Debug.WriteLine("xml值: ");
            System.Diagnostics.Debug.WriteLine(toXml);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试ResponseNews类
        [TestMethod]
        public void ResponseNews_Test()
        {
            BaseMessage bm = new BaseMessage();
            bm.FromUserName = "AbelXu";
            bm.MsgType = "text";
            bm.ToUserName = "Lucy";

            string result = "";
            //使用在微信平台上的图文信息(单图文信息)
            ResponseNews response = new ResponseNews(bm);
            ArticleEntity entity = new ArticleEntity();
            entity.Title = "中体彩科技发展有限公司";
            entity.Description = "欢迎关注中体彩科技发展有限公司--为中国体育彩票提供与彩票发行管理平台和乐透类游戏相关的产品规划及运营、技术研发、系统运维、第三方系统监管等专业服务。\r\n";
            entity.Description += "我们以体彩事业发展和客户需求为导向,产品和服务覆盖体育彩票核心技术领域,包括发行与销售管理平台、全热线游戏系统、高频游戏系统等 , 满足客户对体育彩票发 行与销售业务领域的公用信息技术服务平台支撑和特定业务领域的专业技术服务需求。";
            entity.PicUrl = "http://www.cslc.com.cn/images/logo.jpg";
            entity.Url = "http://www.cslc.com.cn/about.aspx";

            response.Articles.Add(entity);
            result = response.ToXml();

            System.Diagnostics.Debug.WriteLine("xml值: ");
            System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.GetUserList函数
        [TestMethod]
        public void GetUserList_Test()
        {
            string accessToken = "AXUSAUVu6Rt2W895GOQmQ7ii59Zhlr0ECoVilnZvLcUNm6P3TbWK93bQeIDeaI5IRGA4qLNkmquMCOX2wLZfcwAwGqKy11pJ1P58E_3a5YMCGScAEAGKW";
            string nextOpenId = null;
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            List<string> strList = apiDispatch.GetUserList(accessToken, nextOpenId);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.GetAccessToken函数
        [TestMethod]
        public void GetAccessToken_Test()
        {
            // 正式环境的配置参数
            //string appid = "wxb9ce3400fe010bef";
            //string secret = "753059da997c86b08d1f9cc484deeb6e";

            // 自己环境的配置参数
            //string appid = "wx7dacf8590e2420b4";
            //string secret = "d4624c36b6795d1d99dcf0547af5443d";

            // 尹冉冉环境的配置参数
            //string appid = "wxc8c704a1ebe05db2";
            // string secret = "d4624c36b6795d1d99dcf0547af5443d";

            // 李皓璇环境的配置参数
            string appid = "wxf2f31473567a4e78";
            string secret = "d4624c36b6795d1d99dcf0547af5443d";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            string strToken = apiDispatch.GetAccessToken(appid, secret);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            System.Diagnostics.Debug.WriteLine(strToken);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.GetUserDetail函数
        [TestMethod]
        public void GetUserDetail_Test()
        {
            string accessToken = "LosCpQ_5lzsV_z9Doa9g6W7OLtBG93ojxPs9cogMhxthrFfRo-JtkoSjLdCbD-R6EK3xfdIkiVlyejqSBclbjqXAwavB1FDVDcfNJng4rA8TDLbAJAPZH";
            string nextOpenId = "orN7bs6_L78qLzGXrYJUIOCBxDpc";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            UserJson strList = apiDispatch.GetUserDetail(accessToken, nextOpenId, "zh_CN");

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.CreateGroup函数
        [TestMethod]
        public void CreateGroup_Test()
        {
            string accessToken = "8yAOAGyWGxg-IguVF6zxfqysQ1dv4yKbNWAeBT7tjCGxMUkj2XthiEuwug8xHnM988_DPtjZMdK9DxmMZG9NCawFFFU8n7lgTXclIWwpxX0XYWaAJAPQO";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            string groupName = "test";
            GroupJson groupJson = apiDispatch.CreateGroup(accessToken, groupName);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.GetGroupList函数
        [TestMethod]
        public void GetGroupList_Test()
        {
            string accessToken = "6pef1cHFvRAQhBCdD_oDjNIdPii05wnDLelcTHLkOrJzBW05Ly6FnybuQsKb6CwkLkhoIF41iUw_63aszwAKbiDNEnzkMSNoe4EEZQa3fWwNIFeABADYV";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            List<GroupJson> groupJson = apiDispatch.GetGroupList(accessToken);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.GetUserGroupId函数
        [TestMethod]
        public void GetUserGroupId_Test()
        {
            string accessToken = "6pef1cHFvRAQhBCdD_oDjNIdPii05wnDLelcTHLkOrJzBW05Ly6FnybuQsKb6CwkLkhoIF41iUw_63aszwAKbiDNEnzkMSNoe4EEZQa3fWwNIFeABADYV";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            string openid = "orN7bs6_L78qLzGXrYJUIOCBxDpc";
            int groupID = apiDispatch.GetUserGroupId(accessToken, openid);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.UpdateGroupName函数
        [TestMethod]
        public void UpdateGroupName_Test()
        {
            string accessToken = "8yAOAGyWGxg-IguVF6zxfqysQ1dv4yKbNWAeBT7tjCGxMUkj2XthiEuwug8xHnM988_DPtjZMdK9DxmMZG9NCawFFFU8n7lgTXclIWwpxX0XYWaAJAPQO";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            string openid = "orN7bs6_L78qLzGXrYJUIOCBxDpc";
            int id = 100;
            string name = "测试";
            CommonResult commonResult = apiDispatch.UpdateGroupName(accessToken, id, name);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.MoveUserToGroup函数
        [TestMethod]
        public void MoveUserToGroup_Test()
        {
            string accessToken = "8yAOAGyWGxg-IguVF6zxfqysQ1dv4yKbNWAeBT7tjCGxMUkj2XthiEuwug8xHnM988_DPtjZMdK9DxmMZG9NCawFFFU8n7lgTXclIWwpxX0XYWaAJAPQO";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            string openid = "orN7bs4KDrOLt81QUnjvwPsQgiLE";
            int groupid = 100;
            CommonResult commonResult = apiDispatch.MoveUserToGroup(accessToken, openid, groupid);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.GetMenu函数
        [TestMethod]
        public void GetMenu_Test()
        {
            string accessToken = "JX3c3iz6flnClqfRXrUAHVRa6brq8zxkOHCgc3dmrZhh1iXxAK2WnYdbxkgX8Bulf9qI6hrSTFeu3Q8NC8IREhreKLqTQyNGSSBh1P1Tad8BARgAAAONE";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            MenuJson menuJson = apiDispatch.GetMenu(accessToken);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.DeleteMenu函数
        [TestMethod]
        public void DeleteMenu_Test()
        {
            string accessToken = "8-cvMkqEwLQkRmDes5HdOWjW843k2fu9u0JQEKhzDa2uoJCh7dLRvttq5v_O3uCBtgSlA45L2WfRIDstSmo4V_I5sLAQTuFasbEjBjIQk3oJYThABAYNI";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            CommonResult menuJson = apiDispatch.DeleteMenu(accessToken);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.CreateMenu函数
        [TestMethod]
        public void CreateMenu_Test()
        {
            string accessToken = "f-nqpUZATHXq9Fg3UQBNsHm3LjHBiR-PZ1udDdi-SlUBoe29f88SCr2G39posLZyIhYVWHWhO6uuD-5hC11NAutS3O_01Q3YfLUQWgfjSLzhrQRCjOghRgBUybcsvPBPGTUhAFAPCD";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();

            MenuInfo menuInfo = new MenuInfo("分级公开赛", 
                "view",
                "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf2f31473567a4e78&redirect_uri=http://alqqvfsxba.proxy.qqbrowser.cc/CompetitionClient/CompetitionSignuUp.aspx&response_type=code&scope=snsapi_base&state=1#wechat_redirect", 
                new MenuInfo[0]);
            MenuInfo menuInfo_rule = new MenuInfo("竞赛规程",
                "view",
                "http://alqqvfsxba.proxy.qqbrowser.cc/PersonalCenterClient/RulesShow.html",
                new MenuInfo[0]);
            MenuInfo menuInfo_ = new MenuInfo("分级公开赛",
                "view",
                "https://open.weixin.qq.com/connect/oauth2/authorize?appid=wxf2f31473567a4e78&redirect_uri=http://alqqvfsxba.proxy.qqbrowser.cc/CompetitionClient/CompetitionSignuUp.aspx&response_type=code&scope=snsapi_base&state=1#wechat_redirect",
                new MenuInfo[0]);

            MenuJson menuJson = new MenuJson();
            
            menuJson.button.AddRange(new MenuInfo[] { menuInfo_rule });
            menuJson.button.AddRange(new MenuInfo[] { menuInfo });
            menuJson.button.AddRange(new MenuInfo[] { menuInfo_ });
            CommonResult commonResult = apiDispatch.CreateMenu(accessToken, menuJson);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 测试WeixinApiDispatch.ResponseText函数
        [TestMethod]
        public void ResponseText1_Test()
        {
            ResponseText responseText = new ResponseText();
            responseText.Content = "你好，天天有网球欢迎您！";
            responseText.FromUserName = "gh_551d7ee9c6e9";
            responseText.ToUserName = "orN7bsyPHG5RfteiazRRPXbYgYnc";

            string result = responseText.ToXml();

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion


        #region 测试WeixinApiDispatch.sendTemplateMessage函数
        [TestMethod]
        public void sendTemplateMessage_Test()
        {
            string accessToken = "RssbtGlXXlg9nvoRO4f6HH6fmgw-02U6-pxj0VChUlO49DYXp9Ihk3ksjnXdBM7d1BCbeoFFNYDcMG8YULKhuS01_r7pGB8yWk2GbjZElGEDEMaAIAXYG";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();

            TemplateMessageJsonData temMsgJsonData = new TemplateMessageJsonData();

            TemplateMessageJson temMsgJson = new TemplateMessageJson();

            ValueColor first = new ValueColor();
            first.value = "您好，您已报名成功。";
            first.color = "#743A3A";
            temMsgJson.first = first;

            ValueColor personName = new ValueColor();
            personName.value = "许大树";
            personName.color = "#0000FF";
            temMsgJson.keyword1 = personName;

            ValueColor competitionName = new ValueColor();
            competitionName.value = "测试1";
            competitionName.color = "#0000FF";
            temMsgJson.keyword2 = competitionName;

            ValueColor competitionTime = new ValueColor();
            competitionTime.value = "20151218 15:27:00";
            competitionTime.color = "#0000FF";
            temMsgJson.keyword3 = competitionTime;

            ValueColor competitionAddress = new ValueColor();
            competitionAddress.value = "翌景大厦2层";
            competitionAddress.color = "#0000FF";
            temMsgJson.keyword4 = competitionAddress;

            ValueColor remark = new ValueColor();
            remark.value = "届时，我们期待您的参加!";
            remark.color = "#743A3A";
            temMsgJson.remark = remark;

            temMsgJsonData.data = temMsgJson;
            temMsgJsonData.touser = "orN7bsyPHG5RfteiazRRPXbYgYnc";
            temMsgJsonData.template_id = "oozpr7gHPmaDCM2Htn6DTkhjD8TscNXrnPrf0gYE-NM";
            temMsgJsonData.topcolor = "#7B68EE";

            CommonResult commonResult = apiDispatch.sendTemplateMessage(accessToken, temMsgJsonData);


            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(result);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion
    }
}
