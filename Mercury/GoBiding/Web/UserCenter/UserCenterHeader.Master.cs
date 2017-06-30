using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;

namespace GoBiding.UserCenter
{
    public partial class UserCenterHeader : System.Web.UI.MasterPage
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["UserSessionId"] == null)
                    return; 

                int userId = int.Parse(Session["UserSessionId"].ToString());
                var user = new BLL.Sys_Users().GetModel(userId);
                ltrUserName.Text = user.UserName;
                ltrUserName2.Text = user.UserName;
                ltrUserName3.Text = user.UserName;
                ltrCompanyName.Text = user.CompanyName;

                if (!string.IsNullOrEmpty(user.UserProfile))
                {
                    if (user.UserProfile.Contains("qzapp"))
                    {
                        imgProfile.ImageUrl = user.UserProfile + "/30";
                        imgProfile2.ImageUrl = user.UserProfile + "/30";
                    }
                    else if (user.UserProfile.Contains("wx.qlogo"))
                    {
                        imgProfile.ImageUrl = user.UserProfile;
                        imgProfile2.ImageUrl = user.UserProfile;
                    }
                    else if (user.UserProfile.Contains("sinaimg"))
                    {
                        imgProfile.ImageUrl = user.UserProfile;
                    }
                    else
                    {
                        imgProfile.ImageUrl = "~/imgs/users/" + user.UserProfile;
                        imgProfile2.ImageUrl = "~/imgs/users/" + user.UserProfile;
                    }
                }
                else {
                    imgProfile.ImageUrl = "~/imgs/system/zwtp.png";
                    imgProfile2.ImageUrl = "~/imgs/system/zwtp.png";
                }

                int totalBidsCount = (int)DbHelperSQL.GetSingle("SELECT COUNT(*) FROM Message where isread = 0 and ReceiverId = " + userId);
                ltrUnreadMessageCount.Text = totalBidsCount.ToString();
                ltrUnreadMessageCount2.Text = totalBidsCount.ToString();
                ltrUnreadMessageCount3.Text = totalBidsCount.ToString();
                    
                int totalHistorysCount = (int)DbHelperSQL.GetSingle("SELECT COUNT(*) FROM Sys_UsersBidHistorys where UserId = " + userId);
                ltrHistory.Text = totalHistorysCount.ToString();

                var ds = new BLL.Message().GetList(20, " IsRead = 0 and ReceiverId = " + userId, " Id desc");
                rptUnreadMessage.DataSource = ds;
                rptUnreadMessage.DataBind();

                if (user.UserNickName == "18321571921")
                {
                    moduleUserManager.Visible = true;
                    moduleSystemManager.Visible = true;
                    moduleNewsManager.Visible = true;
                }
                else {
                    moduleUserManager.Visible = false;
                    moduleNewsManager.Visible = false;
                    moduleSystemManager.Visible = false;
                }
            }
        }
    }
}