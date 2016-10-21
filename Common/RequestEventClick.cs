using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WX_TennisAssociation.Common
{
    /// <summary>
    /// 自定义菜单事件
    /// </summary>
    [System.Xml.Serialization.XmlRoot(ElementName = "xml")]
    public class RequestEventClick : BaseMessage
    {
        public RequestEventClick()
        {
            this.MsgType = RequestMsgType.Event.ToString().ToLower();
        }

        public RequestEventClick(BaseMessage info)
            : this()
        {
            this.FromUserName = info.ToUserName;
            this.ToUserName = info.FromUserName;
        }

        /// <summary>
        /// 事件类型
        /// </summary>        
        public string Event { get; set; }

        /// <summary>
        /// 事件类型
        /// </summary>        
        public string EventKey { get; set; }
    }
}
