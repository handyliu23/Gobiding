using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Web.BaseCode;

namespace GoBiding.UserCenter
{
    public partial class Index : PhoenixBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        
            int userId = int.Parse(Session["UserSessionId"].ToString());

            if (!IsPostBack)
            {
                var user = new BLL.Sys_Users().GetModel(userId);

                if (!string.IsNullOrEmpty(user.CompanyName))
                    ltrCompanyName.Text = user.CompanyName;
                else
                    ltrCompanyName.Text = "未填写";

                ltrLoginUserName.Text = user.UserNickName;
                ltrUserName.Text = user.UserName;
                ltrUserTypeName.Text = GetUserTypeName(user.UserLoginType ?? 0);
                ltrUserLevel.Text = GetUserLevelName(user.LevelId ?? 0);

                ltrRegistTime.Text = user.OnCreate.ToString();
                ltrLastLoginIP.Text = user.LastLoginIp.ToString();
                ltrLastLoginTime.Text = user.LastLoginTime.ToString();
                ltrScore.Text = user.Scores.ToString();

                if (user.CompanyAuditStatus == 0)
                {
                    ltrValidation.Text = "未认证";
                }
                else if (user.CompanyAuditStatus == 1)
                {
                    ltrValidation.Text = "待审核";
                }
                else if (user.CompanyAuditStatus == 2)
                {
                    ltrValidation.Text = "已认证";
                }
                else if (user.CompanyAuditStatus == 3)
                {
                    ltrValidation.Text = "未认证";
                }
                else 
                {
                    ltrValidation.Text = "未认证";
                }
            }
        }

        public string GetUserTypeName(int type)
        {
            switch (type)
            {
                case 1:
                    return "投标商";

                case 2:
                    return "招标商";

                case 3:
                    return "代理机构";
            }

            return "投标商";

        }
        public string GetUserLevelName(int type)
        {
            switch (type)
            {
                case 1:
                    return "普通会员";
                case 2:
                    return "Vip会员";
                case 3:
                    return "白金Vip会员";
                case 4:
                    return "钻石Vip会员";
            }

            return "普通会员";

        }
    }
}