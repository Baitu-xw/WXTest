using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WX_TennisAssociation.Common
{
    /// <summary>
    /// 回复图文消息
    /// </summary>
    [System.Xml.Serialization.XmlRoot(ElementName = "xml")]
    public class ResponseNews : BaseMessage
    {
        public ResponseNews()
        {
            this.MsgType = ResponseMsgType.News.ToString().ToLower();

            this.Articles = new List<ArticleEntity>();
        }
        public ResponseNews(BaseMessage info)
            : this()
        {
            this.FromUserName = info.FromUserName;
            this.ToUserName = info.ToUserName;
        }

        /// <summary>
        /// 图文消息个数，限制为10条以内
        /// </summary>
        public int ArticleCount
        {
            get
            {
                return this.Articles.Count;
            }
            set
            {
                this.ArticleCount = this.Articles.Count;//增加这个步骤才出来XML内容
                if (this.ArticleCount > 10)
                {
                    this.ArticleCount = 10;
                }


                
            }
        }

        /// <summary>
        /// 图文列表。
        /// 多条图文消息信息，默认第一个item为大图,注意，如果图文数超过10，则将会无响应
        /// </summary>
        [System.Xml.Serialization.XmlArrayItem("item")]
        public List<ArticleEntity> Articles { get; set; }

    }
}