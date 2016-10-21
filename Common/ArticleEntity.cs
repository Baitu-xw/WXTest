using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WX_TennisAssociation.Common
{
    public class ArticleEntity
    {
        /// <summary>
        /// 图文消息标题
        /// </summary>
        public string Title { set; get; }

        /// <summary>
        /// 图文消息描述
        /// </summary>
        public string Description { set; get; }

        /// <summary>
        /// 图文消息图片链接
        /// </summary>
        public string PicUrl { set; get; }

        /// <summary>
        /// 图文消息链接
        /// </summary>
        public string Url { set; get; }

    }
}