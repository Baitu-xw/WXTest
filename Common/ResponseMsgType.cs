using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace WX_TennisAssociation.Common
{
    /// <summary>
    /// 基础消息内容
    /// </summary>
    public class ResponseMsgType
    {
        /// <summary>
        /// 文本消息
        /// </summary>
        public static string Text
        {
            set { Text = value; }
            get { return "text"; }
        }

        /// <summary>
        /// 图文消息
        /// </summary>
        public static string News
        {
            set { Text = value; }
            get { return "news"; }
        }

        /// <summary>
        /// 图片消息
        /// </summary>
        public static string Image
        {
            set { Image = value; }
            get { return "image"; }
        }

        /// <summary>
        /// 音乐消息
        /// </summary>
        public static string Music
        {
            set { Music = value; }
            get { return "music"; }
        }

        /// <summary>
        /// 视频消息
        /// </summary>
        public static string Video
        {
            set { Video = value; }
            get { return "video"; }
        }

        /// <summary>
        /// 音频消息
        /// </summary>
        public static string Voice
        {
            set { Voice = value; }
            get { return "voice"; }
        }
    }
}