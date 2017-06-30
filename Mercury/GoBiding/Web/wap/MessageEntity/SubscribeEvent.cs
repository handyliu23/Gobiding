using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace GoBiding.Web.wap.MessageEntity
{
    [XmlRootAttribute("xml", IsNullable = false)]
    public class SubscribeEvent
    {
        [XmlAttribute("ToUserName")]
        public string ToUserName
        {
            get;
            set;
        }

        [XmlAttribute("FromUserName")]
        public string FromUserName
        {
            get;
            set;
        }

        [XmlArrayAttribute("CreateTime")]
        public int CreateTime
        {
            get;
            set;
        }

        [XmlArrayAttribute("MsgType")]
        public string MsgType
        {
            get;
            set;
        }

        [XmlArrayAttribute("Event")]
        public string Event
        {
            get;
            set;
        }

        [XmlArrayAttribute("EventKey", IsNullable = true)]
        public string EventKey
        {
            get;
            set;
        }

        [XmlArrayAttribute("Ticket", IsNullable = true)]
        public string Ticket
        {
            get;
            set;
        }
    }
}