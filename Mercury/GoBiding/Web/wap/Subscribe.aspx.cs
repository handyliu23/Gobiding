using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Serialization;
using GoBiding.Web.wap;
using GoBiding.Web.wap.MessageEntity;
using Maticsoft.Common;
using Newtonsoft.Json;

namespace TestForWap
{
    public partial class Subscribe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSessionId"] == null)
                {
                    Response.Redirect("/wap/waplogin.aspx?redirecturl=" + "/wap/Subscribe.aspx");
                }


                hdnSysUserId.Value = Session["UserSessionId"].ToString();
                InitPage(int.Parse(Session["UserSessionId"].ToString()));

                new GoBiding.BLL.WeiXinMessage().Add(new GoBiding.Model.WeiXinMessage()
                {
                    WeiXinMesssageType = "Log",
                    MessageTime = DateTime.Now,
                    MessageContent = "context.Request.HttpMethod:" + Request.HttpMethod + ":" + Request.RawUrl
                });

                if (Request.HttpMethod.ToLower() == "post")
                {
                    HandlePost(Request);
                }

                //var res =
                //    "https://open.weixin.qq.com/connect/oauth2/authorize?appid={0}&redirect_uri={1}&response_type=code&scope=SCOPE&state=STATE#wechat_redirect";
            }

        }

        public void InitPage(int userId)
        {
            IsSubscribed.Value = "F";

            var models = new GoBiding.BLL.Sys_UserTrackers().GetModelList(" Sys_UserId = " + userId);
            if (models == null || models.Count == 0)
                return;

            GoBiding.Model.Sys_UserTrackers model = models.FirstOrDefault();
            if (model != null)
            {
                IsSubscribed.Value = "T";
                hdnUserTrackerId.Value = model.UserTrackerId.ToString();
                hdnkeyword1.Value = model.Keyword1;
                hdnkeyword2.Value = model.Keyword2;
                hdnkeyword3.Value = model.Keyword3;
                hdnarea.Value = model.TrackerCityIds;
                hdnindustry.Value = model.TrackerIndustryIds;
                hdntrackername.Value = model.TrackerName;
                if (model.BidTime != null)
                {
                    hdnbidtime.Value = model.BidTime.ToString();
                }
                if (model.BidType != null)
                {
                    hdnbidtype.Value = model.BidType.ToString();
                }
            }
        }

        public string HttpPost(HttpRequest request)
        {
            string xml = "";
            if (request.TotalBytes > 0)
                xml = System.Text.Encoding.UTF8.GetString(request.BinaryRead(request.TotalBytes));

            return xml;
        }

        /// <summary>
        /// 处理微信的POST请求
        /// </summary>
        /// <param name="context"></param>
        /// <returns>返回xml响应</returns>
        private string HandlePost(HttpRequest request)
        {
            string postData = HttpPost(request);
            new GoBiding.BLL.WeiXinMessage().Add(new GoBiding.Model.WeiXinMessage()
            {
                WeiXinMesssageType = "Log",
                MessageTime = DateTime.Now,
                MessageContent = postData
            });

            XmlSerializer serializer = new XmlSerializer(typeof(InfoEntity));
            //InfoEntity obj = serializer.Deserialize(new MemoryStream(Encoding.Unicode.GetBytes(postData))) as InfoEntity;

            return "";
            //return new WeixinAction().HandleSubscribeText(obj);
        }
    }
}