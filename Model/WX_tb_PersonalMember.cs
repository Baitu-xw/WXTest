using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WX_TennisAssociation.Model
{
    public class WX_tb_PersonalMember
    {
        /// <summary>
        /// 人员ID
        /// </summary>
        public int PersonalMember_ID { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string PersonalMember_NickName { get; set; }
        /// <summary>
        /// 手机号码
        /// </summary>
        public string PersonalMember_Mobile { get; set; }
        /// <summary>
        /// 性别,值为1时是男性，值为2时是女性，值为0时是未知
        /// </summary>
        public int Gender { get; set; }
        /// <summary>
        /// 单打级别ID
        /// </summary>
        public int? Single_Level_ID { get; set; }
        /// <summary>
        /// 双打级别ID
        /// </summary>
        public int? Double_Level_ID { get; set; }
        /// <summary>
        /// 是否订阅该公众号标识,0未订阅，1订阅
        /// </summary>
        public int? Subscribe { get; set; }
        /// <summary>
        /// 用户的标识，对当前公众号唯一
        /// </summary>
        public string Openid { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Headimgurl { get; set; }
        /// <summary>
        /// 所在城市
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// 所在国家
        /// </summary>
        public string Country { get; set; }
        /// <summary>
        /// 所在省份
        /// </summary>
        public string Province { get; set; }
        /// <summary>
        /// 用户的语言
        /// </summary>
        public string Language { get; set; }
        /// <summary>
        /// 用户关注时间
        /// </summary>
        public string Subscribe_time { get; set; }
        /// <summary>
        /// 单打总积分
        /// </summary>
        public int? Singl_ScoreSum { get; set; }
        /// <summary>
        /// 双打总积分
        /// </summary>
        public int? Double_ScoreSum { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        public string PassWord { get; set; }
    }
}
