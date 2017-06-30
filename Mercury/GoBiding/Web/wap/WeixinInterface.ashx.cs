using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Net;
using System.Xml;
using System.Xml.Serialization;
using GoBiding.Common;
using GoBiding.Model;
using GoBiding.Web.wap.MessageEntity;
using Newtonsoft.Json;
using xrwang.PublicLibrary;
using xrwang.weixin.PublicAccount;

namespace GoBiding.Web.wap
{
    /// <summary>
    /// WeixinInterface 的摘要说明
    /// </summary>
    public class WeixinInterface : IHttpHandler
    {
        //secret = "08dbce3bc399a97a734895b7eb2042c1";
        public string HttpPost(HttpContext context)
        {
            string xml = "";
            if (context.Request.TotalBytes > 0)
                xml = System.Text.Encoding.UTF8.GetString(context.Request.BinaryRead(context.Request.TotalBytes));

            return xml;
        }

        public class button
        {
            public string type;
            public string name;
            public string key;
            public string url;
            public List<button> sub_button;
        }

        public class Menus
        {
            public List<button> button;
        }

        public void DeleteMenuList()
        {
            string token = "https://api.weixin.qq.com/cgi-bin/menu/create?access_token=zwYbxHPgcaiwZsyqMhWYKj8KrjKd3v3bmOTsy9ZuG64lHR4-j5F4AvQi3VIRTfwUlEIOTge5uk1ArquS40OhC6EQvg31BwxG5wRBcR1cbie4MujknwDTLfFIvqvhEZ-NPOSdAHASRV";
            new Maticsoft.Common.WebClient().GetData(token);
        }

//{
//    "button": [
//        {
//            "type": "view", 
//            "name": "搜索招标", 
//            "key": "search", 
//            "url": "http://www.gobiding.com/wap/Default.aspx?platform=wx"
//        }, 
//        {
//            "type": "view", 
//            "name": "订阅招标", 
//            "key": "subscribe", 
//            "url": "http://www.gobiding.com/wap/Subscribe.aspx?platform=wx"
//        }, 
//        {
//            "type": "view", 
//            "name": "GoBiding", 
//            "key": "center", 
//            "url": "http://www.gobiding.com/wap/Default.aspx?platform=wx"
//        }
//    ]
//}
        public void CreateMenuList()
        {
            Menus menu = new Menus();
            menu.button = new List<button>();
            var button = new button();
            button.key = "search";
            button.name = "搜索招标";
            button.url = "http://118.178.194.107/wap/Default.aspx?platform=wx";
            button.type = "view";
            menu.button.Add(button);

            var button2 = new button();
            button2.key = "subscribe";
            button2.name = "订阅招标";
            button2.url = "http://118.178.194.107/wap/Subscribe.aspx?platform=wx";
            button2.type = "view";
            menu.button.Add(button2);

            var button3 = new button();
            button3.key = "center";
            button3.name = "GoBiding";
            button3.url = "http://118.178.194.107/wap/Default.aspx?platform=wx";
            button3.type = "view";
            menu.button.Add(button3);

            string jsonStudents = JsonConvert.SerializeObject(menu);
            string token = "http://api.weixin.qq.com/cgi-bin/menu/create?access_token=zwYbxHPgcaiwZsyqMhWYKj8KrjKd3v3bmOTsy9ZuG64lHR4-j5F4AvQi3VIRTfwUlEIOTge5uk1ArquS40OhC6EQvg31BwxG5wRBcR1cbie4MujknwDTLfFIvqvhEZ-NPOSdAHASRV";
            new Maticsoft.Common.WebClient().Post(token, jsonStudents);

        }

        public void ProcessRequest(HttpContext context)
        {
            new BLL.WeiXinMessage().Add(new Model.WeiXinMessage()
            {
                WeiXinMesssageType = "Log",
                MessageTime = DateTime.Now,
                MessageContent = "context.Request.HttpMethod:" + context.Request.HttpMethod + ":" + context.Request.RawUrl
            });

            CreateMenuList();

            var result = string.Empty;

            try
            {
                if (context.Request.HttpMethod == WebRequestMethods.Http.Get)
                    result = HandleGet(context);
                else if (context.Request.HttpMethod == WebRequestMethods.Http.Post)
                    result = HandlePost(context);
            }
            catch (Exception err)
            {
                new BLL.WeiXinMessage().Add(new Model.WeiXinMessage()
                {
                    WeiXinMesssageType = "Error",
                    MessageTime = DateTime.Now,
                    MessageContent = err.Message
                });
            }

            InfoEntity reply = new InfoEntity()
                                   {
                                       ToUserName = "opTCdv9J9xPaHc2qtjcwYu-d9gK4",
                                       CreateTime = "1487346991",
                                       FromUserName = "gh_adfa2af5fec3",
                                       MsgId = "123",
                                       MsgType = "text",
                                       Content = "欢迎使用<a href='http://gobiding.com/wap/Default.aspx'>去投标网</a>微信公众号，每日更新全国范围各行业招投标采购信息！"
                                   };

            string replymsg = XmlHelper.XmlSerialize(reply, Encoding.UTF8);
            replymsg = replymsg.Substring(replymsg.IndexOf("<xml>"));
            new BLL.WeiXinMessage().Add(new Model.WeiXinMessage()
            {
                WeiXinMesssageType = "Response",
                MessageTime = DateTime.Now,
                MessageContent = replymsg
            });
            context.Response.ContentEncoding = Encoding.UTF8;
            context.Response.Write(replymsg);

            //string openid = "oI-tguJsradCmtjV-EouJPKk4PiU";

            //if (context.Request.QueryString["openid"] != null)
            //    openid = context.Request.QueryString["openid"].ToString();

            //context.Response.Redirect("Default.aspx?openId=" + openid);

            //Model.WeiXinMessage model = new WeiXinMessage();
            //model = new Model.WeiXinMessage()
            //            {
            //                WeiXinMesssageType = "Request",
            //                MessageTime = DateTime.Now,
            //                MessageContent = context.Request.HttpMethod + ":" + context.Request.Url.ToString()
            //            };

            ////model.MessageContent += HttpPost(context);

            //new BLL.WeiXinMessage().Add(model);

            //string result = string.Empty;
            //if (true) //Validate(context))
            //{
            //    if (context.Request.HttpMethod == WebRequestMethods.Http.Get)
            //        result = HandleGet(context);
            //    else if (context.Request.HttpMethod == WebRequestMethods.Http.Post)
            //        result = HandlePost(context);
            //}
            //else
            //{
            //    new BLL.WeiXinMessage().Add(new Model.WeiXinMessage()
            //    {
            //        WeiXinMesssageType = "Exception",
            //        MessageTime = DateTime.Now,
            //        MessageContent = "校验消息失败。\r\n地址：" + context.Request.RawUrl
            //    });
            //}
            //context.Response.Write(result);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        /// <summary>
        /// 验证消息的有效性
        /// </summary>
        /// <param name="context"></param>
        /// <returns>如果消息有效，返回true；否则返回false。</returns>
        private bool Validate(HttpContext context)
        {
            string username = RequestEx.TryGetQueryString("username");  //在接口配置的URL中加入了username参数，表示哪个微信公众号
            AccountInfo account = AccountInfoCollection.GetAccountInfo(username);
            if (account == null)
                return false;
            string token = account.Token;
            string signature = RequestEx.TryGetQueryString("signature");
            string timestamp = RequestEx.TryGetQueryString("timestamp");
            string nonce = RequestEx.TryGetQueryString("nonce");
            if (string.IsNullOrWhiteSpace(signature) || string.IsNullOrWhiteSpace(timestamp) || string.IsNullOrWhiteSpace(nonce))
                return false;
            return xrwang.weixin.PublicAccount.Utility.CheckSignature(signature, token, timestamp, nonce);
        }

        /// <summary>
        /// 处理微信的GET请求，校验签名
        /// </summary>
        /// <param name="context"></param>
        /// <returns>返回echostr</returns>
        private string HandleGet(HttpContext context)
        {
            return RequestEx.TryGetQueryString("echostr");
        }

        /// <summary>
        /// 处理微信的POST请求
        /// </summary>
        /// <param name="context"></param>
        /// <returns>返回xml响应</returns>
        private string HandlePost(HttpContext context)
        {
            string postData = HttpPost(context);
            new BLL.WeiXinMessage().Add(new Model.WeiXinMessage()
            {
                WeiXinMesssageType = "Log",
                MessageTime = DateTime.Now,
                MessageContent = postData
            });

            XmlSerializer serializer = new XmlSerializer(typeof(InfoEntity));
            InfoEntity obj = serializer.Deserialize(new MemoryStream(Encoding.Unicode.GetBytes(postData))) as InfoEntity;

            return new WeixinAction().HandleSubscribeText(obj);
        }

        /// <summary>
        /// 处理请求消息，返回响应消息
        /// </summary>
        /// <returns>返回响应消息</returns>
        private ResponseBaseMessage HandleRequestMessage(RequestBaseMessage requestMessage)
        {
            ResponseTextMessage response = new ResponseTextMessage(requestMessage.FromUserName, requestMessage.ToUserName,
                DateTime.Now, string.Format("自动回复，请求内容如下：\r\n{0}", requestMessage));
            response.Content += "\r\n<a href=\"http://www.gobiding.com\">去投标网</a>";
            ErrorMessage errorMessage = CustomerService.SendMessage(new ResponseTextMessage(requestMessage.FromUserName, requestMessage.ToUserName, DateTime.Now, string.Format("自动回复客服消息，请求内容如下：\r\n{0}", requestMessage.ToString())));
            if (!errorMessage.IsSuccess)
                new BLL.WeiXinMessage().Add(new Model.WeiXinMessage()
                                                {
                                                    WeiXinMesssageType = "Exception",
                                                    MessageTime = DateTime.Now,
                                                    MessageContent = errorMessage.ToString()
                                                });
            return response;
        }
    }
}