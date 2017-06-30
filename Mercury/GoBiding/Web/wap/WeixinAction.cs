using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoBiding.Web.wap.MessageEntity;
using Newtonsoft.Json;

namespace GoBiding.Web.wap
{
    public class WeixinAction
    {
        public string HandleSubscribeText(InfoEntity info)
        {
            new BLL.WeiXinMessage().Add(new Model.WeiXinMessage()
            {
                WeiXinMesssageType = "RequestPostData",
                MessageTime = DateTime.Now,
                MessageContent = JsonConvert.SerializeObject(info)
                //info.CreateTime + info.ToUserName + info.FromUserName + info.MsgType + info.Event
            });

            return "";
        }

    }
}