using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WX_TennisAssociation.Common;
using System.Collections.Generic;
using WX_TennisAssociation.BLL;
using System.Text;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTestDB
    {
        #region 导入微信公共号的用户信息进数据库
        [TestMethod]
        public void TestImportUserToDB()
        {
            //string appid = "wxb9ce3400fe010bef";
            //string secret = "753059da997c86b08d1f9cc484deeb6e";
            WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            //string accessToken = apiDispatch.GetAccessToken(appid, secret);

            string accessToken = "bWqlv9eyWmg7X6jN7oaiIoBEp1qwtK-SMGN0YN14TZXEyw_v5jUSnqtJQ-GlSfhFnFCFyYUANrt5U0LYgBhKd2Xl2LPoxkRdm3rGLC709yEMAAjACAIWW";
            string nextOpenId = null;
            //WeixinApiDispatch apiDispatch = new WeixinApiDispatch();
            List<string> strList = apiDispatch.GetUserList(accessToken, nextOpenId);

            PersonnalMemberBLL pmBll = new PersonnalMemberBLL();
            foreach (string strOpenId in strList)
            {
                bool result = pmBll.isMember(strOpenId);
                if (!result)
                {
                    UserJson userJson = apiDispatch.GetUserDetail(accessToken, strOpenId, "zh_CN");
                    pmBll.WX_PersonalMember_Insert(userJson);
                }
            }

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(strToken);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion

        #region 检测用户是否在数据库中
        [TestMethod]
        public void TestIsMember()
        {
            string strOpenId = "orN7bs4KDrOLt81QUnjvwPsQgiLE";

            PersonnalMemberBLL pmBll = new PersonnalMemberBLL();

            bool result = pmBll.isMember(strOpenId);

            System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(strToken);
            System.Diagnostics.Debug.WriteLine("xml值: ");
        }
        #endregion
    }

}
