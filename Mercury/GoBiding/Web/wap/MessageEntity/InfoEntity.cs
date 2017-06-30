using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace GoBiding.Web.wap.MessageEntity
{
    [Serializable]
    [XmlRootAttribute("xml", IsNullable = false)]
    public class InfoEntity
    {
        public string ToUserName;
        
        public string FromUserName;

        public string CreateTime;

        public string MsgType;

        public string Content;

        public string MsgId;

    }
}