using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Web.BaseCode;
using Wuqi.Webdiyer;
using Maticsoft.DBUtility;

namespace GoBiding.Web.UserCenter.UserCenterPage
{
    public partial class MessageDetail : PhoenixBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
            }
        }

        public string GetSenderName(string senderId)
        {
            if (senderId == "0")
                return "管理员";

            var model = new BLL.Sys_Users().GetModel(int.Parse(senderId));
            if (model == null)
                return "";
            return model.UserName;
        }

        public void Init()
        {
            int userId = int.Parse(Session["UserSessionId"].ToString());

            int mId = int.Parse(Request.QueryString["mId"].ToString());
            Model.Message msg = new BLL.Message().GetModel(mId);

            ltrMsgTitle.Text = msg.Title;
            ltrMsgContent.Text = msg.Content;
            ltrSender.Text = GetSenderName((msg.SenderId ?? 0).ToString());
            ltrSendTime.Text = msg.MessageTime.ToString();
            ltrMsgType.Text = msg.MessageType.ToString() == "1" ? "系统消息" :"用户消息";


            msg.IsRead = true;
            new BLL.Message().Update(msg);
        }
      
    }
}