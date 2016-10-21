using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Xml;

namespace WX_TennisAssociation.Common
{
    #region 微信用户网页授权的API接口
    /// <summary>
    /// 微信用户网页授权的API接口
    /// </summary>
    public interface IAuthApi
    {
        #region 通过code换取网页授权access_token
        /// <summary>
        /// 通过code换取网页授权access_token
        /// </summary>
        /// <param name="code">用户同意授权，获取code</param>
        /// <returns></returns>
        string GetAccess_token(string code);
        #endregion
    }
    #endregion

    #region 微信用户管理的API接口
    /// <summary>
    /// 微信用户管理的API接口
    /// </summary>
    public interface IUserApi
    {
        #region 获取关注用户列表
        /// <summary>
        /// 获取关注用户列表
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="nextOpenId">第一个拉取的OPENID，不填默认从头开始拉取</param>
        /// <returns></returns>
        List<string> GetUserList(string accessToken, string nextOpenId = null);
        #endregion

        #region 获取用户基本信息
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="openId">普通用户的标识，对当前公众号唯一</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        UserJson GetUserDetail(string accessToken, string openId, string lang);
        #endregion

        #region 查询所有分组
        /// <summary>
        /// 查询所有分组
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <returns></returns>
        List<GroupJson> GetGroupList(string accessToken);
        #endregion

        #region 创建分组
        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="name">分组名称</param>
        /// <returns></returns>
        GroupJson CreateGroup(string accessToken, string name);
        #endregion

        #region 查询用户所在分组
        /// <summary>
        /// 查询用户所在分组
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="openid">用户的OpenID</param>
        /// <returns></returns>
        int GetUserGroupId(string accessToken, string openid);
        #endregion

        #region 修改分组名
        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="id">分组id，由微信分配</param>
        /// <param name="name">分组名字（30个字符以内）</param>
        /// <returns></returns>
        CommonResult UpdateGroupName(string accessToken, int id, string name);
        #endregion

        #region 移动用户分组
        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="openid">用户的OpenID</param>
        /// <param name="to_groupid">分组id</param>
        /// <returns></returns>
        CommonResult MoveUserToGroup(string accessToken, string openid, int to_groupid);
        #endregion
    }
    #endregion

    #region 客户端请求的数据接口
    /// <summary>
    /// 客户端请求的数据接口
    /// </summary>
    public interface IWeixinAction
    {
        #region 对文本请求信息进行处理
        /// <summary>
        /// 对文本请求信息进行处理
        /// </summary>
        /// <param name="info">文本信息实体</param>
        /// <returns></returns>
        string HandleText(ResponseText info);
        #endregion

        #region 对图片请求信息进行处理
        /// <summary>
        /// 对图片请求信息进行处理
        /// </summary>
        /// <param name="info">图片信息实体</param>
        /// <returns></returns>
        //string HandleImage(RequestImage info);
        #endregion

        #region 对订阅请求事件进行处理
        /// <summary>
        /// 对订阅请求事件进行处理
        /// </summary>
        /// <param name="info">订阅请求事件信息实体</param>
        /// <returns></returns>
        //string HandleEventSubscribe(RequestEventSubscribe info);
        #endregion

        #region 对菜单单击请求事件进行处理
        /// <summary>
        /// 对菜单单击请求事件进行处理
        /// </summary>
        /// <param name="info">菜单单击请求事件信息实体</param>
        /// <returns></returns>
        string HandleEventClick(RequestEventClick info);
        #endregion
    }
    #endregion

    #region 菜单的相关操作
    /// <summary>
    /// 菜单的相关操作
    /// </summary>
    public interface IMenuApi
    {
        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <returns></returns>
        MenuJson GetMenu(string accessToken);

        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="menuJson">菜单对象</param>
        /// <returns></returns>
        CommonResult CreateMenu(string accessToken, MenuJson menuJson);

        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <returns></returns>
        CommonResult DeleteMenu(string accessToken);
    }
    #endregion



    #region 微信接口分发类
    public class WeixinApiDispatch
    {
        #region 执行函数
        public string Execute(string postStr)
        {
            BaseMessage info = new BaseMessage();
            //封装请求类
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(postStr);
            XmlElement rootElement = doc.DocumentElement;
            XmlNode msgType = rootElement.SelectSingleNode("MsgType");

            if (!string.IsNullOrEmpty(msgType.InnerText))
            {
                if (msgType.InnerText == "text")
                {
                    ResponseText requestXML = new ResponseText();
                    requestXML.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                    requestXML.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                    requestXML.CreateTime = Convert.ToInt64((rootElement.SelectSingleNode("CreateTime").InnerText));
                    requestXML.MsgType = msgType.InnerText;
                    requestXML.Content = rootElement.SelectSingleNode("Content").InnerText;


                    //回复新闻消息
                    
                    info.ToUserName = requestXML.FromUserName.ToString();
                    info.FromUserName = requestXML.ToUserName.ToString();
                    info.MsgType = "news";
                    
                }
                else if (msgType.InnerText == "event")
                {
                    RequestEventClick requestEventClick = new RequestEventClick();
                    requestEventClick.ToUserName = rootElement.SelectSingleNode("ToUserName").InnerText;
                    requestEventClick.FromUserName = rootElement.SelectSingleNode("FromUserName").InnerText;
                    requestEventClick.CreateTime = Convert.ToInt64((rootElement.SelectSingleNode("CreateTime").InnerText));
                    requestEventClick.MsgType = msgType.InnerText;
                    requestEventClick.Event = rootElement.SelectSingleNode("Event").InnerText;
                    requestEventClick.EventKey = rootElement.SelectSingleNode("EventKey").InnerText;
                }
            }

            //System.Diagnostics.Debug.WriteLine("xml值: ");
            //System.Diagnostics.Debug.WriteLine(rootElement.InnerText);
            //System.Diagnostics.Debug.WriteLine("xml值: ");

            //回复文本消息
            //ResponseText responseText = new ResponseText();
            //responseText.Content = "你好，天天有网球欢迎您！";
            //responseText.FromUserName = "gh_551d7ee9c6e9";
            //responseText.ToUserName = "orN7bsyPHG5RfteiazRRPXbYgYnc";

            //return responseText.ToXml();
            return ShowCompanyInfo(info);
            
        }
        #endregion

        # region 订阅或者显示公司信息
        /// <summary>
        /// 订阅或者显示公司信息
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        private string ShowCompanyInfo(BaseMessage info)
        {
            string result = "";
            //使用在微信平台上的图文信息(单图文信息)
            ResponseNews response = new ResponseNews(info);
            ArticleEntity entity = new ArticleEntity();
            entity.Title = "天天有网球";
            entity.Description = "中央国家机关网球协会（以下简称“协会”）是经中央国家机关工会联合会批准，于2010年5月成立，由中央国家机关广大网球爱好者组成的群众性体育团体。\r\n";
            entity.Description += "协会的任务是通过开展网球活动服务于广大干部群众的身心健康。";
            entity.PicUrl = "http://zygjjgtennis.sports.cn/Image/201403_02.jpg";
            entity.Url = "http://zygjjgtennis.sports.cn/";

            response.Articles.Add(entity);
            result = response.ToXml();

            return result;
        }
        #endregion

        #region 获取每次操作微信API的Token访问令牌
        /// <summary>
        /// 获取每次操作微信API的Token访问令牌
        /// </summary>
        /// <param name="appid">应用ID</param>
        /// <param name="secret">开发者凭据</param>
        /// <returns></returns>
        public string GetAccessToken(string appid, string secret)
        {
            //正常情况下access_token有效期为7200秒,这里使用缓存设置短于这个时间即可
            string access_token = MemoryCacheHelper.GetCacheItem<string>("access_token", delegate()
            {
                string grant_type = "client_credential";
                var url = string.Format("https://api.weixin.qq.com/cgi-bin/token?grant_type={0}&appid={1}&secret={2}",
                                        grant_type, appid, secret);

                HttpHelper helper = new HttpHelper();
                string result = helper.GetHtml(url);
                string regex = "\"access_token\":\"(?<token>.*?)\"";
                string token = CRegex.GetText(result, regex, "token");
                return token;
            },
                new TimeSpan(0, 0, 7000)//7000秒过期
            );

            return access_token;
        }
        #endregion

        #region 获取关注用户列表
        /// <summary>
        /// 获取关注用户列表
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="nextOpenId">第一个拉取的OPENID，不填默认从头开始拉取</param>
        /// <returns></returns>
        public List<string> GetUserList(string accessToken, string nextOpenId = null)
        {
            List<string> list = new List<string>();

            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/get?access_token={0}", accessToken);
            if (!string.IsNullOrEmpty(nextOpenId))
            {
                url += "&next_openid=" + nextOpenId;
            }

            UserListJsonResult result = JsonHelper<UserListJsonResult>.ConvertJson(url);
            if (result != null && result.data != null)
            {
                list.AddRange(result.data.openid);
            }

            return list;
        }
        #endregion

        #region 获取用户基本信息
        /// <summary>
        /// 获取用户基本信息
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="openId">普通用户的标识，对当前公众号唯一</param>
        /// <param name="lang">返回国家地区语言版本，zh_CN 简体，zh_TW 繁体，en 英语</param>
        public UserJson GetUserDetail(string accessToken, string openId, string lang = "zh_CN")
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/user/info?access_token={0}&openid={1}&lang={2}",
                   accessToken, openId, lang.ToString());

            UserJson result = JsonHelper<UserJson>.ConvertJson(url);
            return result;
        }
        #endregion

        #region 创建分组
        /// <summary>
        /// 创建分组
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="name">分组名称</param>
        /// <returns></returns>
        public GroupJson CreateGroup(string accessToken, string name)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/create?access_token={0}", accessToken);
            var data = new
            {
                group = new
                {
                    name = name
                }
            };
            string postData = data.ToJson();

            GroupJson group = null;
            CreateGroupResult result = JsonHelper<CreateGroupResult>.ConvertJson(url, postData);
            if (result != null)
            {
                group = result.group;
            }
            return group;
        }
        #endregion

        #region 查询所有分组
        /// <summary>
        /// 查询所有分组
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <returns></returns>
        public List<GroupJson> GetGroupList(string accessToken)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/get?access_token={0}", accessToken);

            List<GroupJson> list = new List<GroupJson>();
            GroupListJsonResult result = JsonHelper<GroupListJsonResult>.ConvertJson(url);
            if (result != null && result.groups != null)
            {
                list.AddRange(result.groups);
            }

            return list;
        }
        #endregion

        #region 查询用户所在分组
        /// <summary>
        /// 查询用户所在分组
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="openid">用户的OpenID</param>
        /// <returns></returns>
        public int GetUserGroupId(string accessToken, string openid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/getid?access_token={0}", accessToken);
            var data = new
            {
                openid = openid
            };
            string postData = data.ToJson();

            int groupId = -1;
            GroupIdJsonResult result = JsonHelper<GroupIdJsonResult>.ConvertJson(url, postData);
            if (result != null)
            {
                groupId = result.groupid;
            }
            return groupId;
        }
        #endregion

        #region 修改分组名
        /// <summary>
        /// 修改分组名
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="id">分组id，由微信分配</param>
        /// <param name="name">分组名字（30个字符以内）</param>
        /// <returns></returns>
        public CommonResult UpdateGroupName(string accessToken, int id, string name)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/update?access_token={0}", accessToken);
            var data = new
            {
                group = new
                {
                    id = id,
                    name = name
                }
            };
            string postData = data.ToJson();

            return Helper.GetExecuteResult(url, postData);
        }
        #endregion

        #region 移动用户分组
        /// <summary>
        /// 移动用户分组
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="openid">用户的OpenID</param>
        /// <param name="to_groupid">分组id</param>
        /// <returns></returns>
        public CommonResult MoveUserToGroup(string accessToken, string openid, int to_groupid)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/groups/members/update?access_token={0}", accessToken);
            var data = new
            {
                openid = openid,
                to_groupid = to_groupid
            };
            string postData = data.ToJson();

            return Helper.GetExecuteResult(url, postData);
        }
        #endregion

        #region 获取菜单数据
        /// <summary>
        /// 获取菜单数据
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <returns></returns>
        public MenuJson GetMenu(string accessToken)
        {
            MenuJson menu = null;

            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/get?access_token={0}", accessToken);
            MenuListJson list = JsonHelper<MenuListJson>.ConvertJson(url);
            if (list != null)
            {
                menu = list.menu;
            }
            return menu;
        }
        #endregion

        #region 创建菜单
        /// <summary>
        /// 创建菜单
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <param name="menuJson">菜单对象</param>
        /// <returns></returns>
        public CommonResult CreateMenu(string accessToken, MenuJson menuJson)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/create?access_token={0}", accessToken);
            string postData = menuJson.ToJson();

            return Helper.GetExecuteResult(url, postData);
        }
        #endregion

        #region 删除菜单
        /// <summary>
        /// 删除菜单
        /// </summary>
        /// <param name="accessToken">调用接口凭证</param>
        /// <returns></returns>
        public CommonResult DeleteMenu(string accessToken)
        {
            var url = string.Format("https://api.weixin.qq.com/cgi-bin/menu/delete?access_token={0}", accessToken);

            return Helper.GetExecuteResult(url);
        }
        #endregion

        public string GetAccess_token(string code)
        {
            string appid = ConfigurationManager.AppSettings["appid"];
            string secret = ConfigurationManager.AppSettings["secret"];
            string url = string.Format("https://api.weixin.qq.com/sns/oauth2/access_token?appid={0}&secret={1}&code={2}&grant_type=authorization_code",
                   appid, secret, code);

            System.Diagnostics.Debug.WriteLine("appid值: ");
            System.Diagnostics.Debug.WriteLine(appid);
            System.Diagnostics.Debug.WriteLine("secret值: ");
            System.Diagnostics.Debug.WriteLine(secret);

            string content = Helper.GetAccess_token(url);
            System.Diagnostics.Debug.WriteLine("content值: ");
            System.Diagnostics.Debug.WriteLine(content);

            //CommonResult result = JsonConvert.DeserializeObject<CommonResult>(content);
            return content;
        }


        #region 获取模板信息
        public CommonResult sendTemplateMessage(string accessToken, 
            TemplateMessageJsonData templateMessageJsonData)
        {
            string url = string.Format("https://api.weixin.qq.com/cgi-bin/message/template/send?access_token={0}", accessToken);

            string postData = templateMessageJsonData.ToJson();

            return Helper.GetExecuteResult(url, postData);
        }
        #endregion

    }
    #endregion
}