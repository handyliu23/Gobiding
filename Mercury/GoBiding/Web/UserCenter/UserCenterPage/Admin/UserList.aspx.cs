using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace GoBiding.Web.UserCenter.UserCenterPage.Admin
{
    public partial class UserList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserSessionId"] == null)
                {
                    mainContent.Visible = false;
                    Response.Redirect("/Login.aspx");
                    return;
                }

                if (Request.QueryString["Sort"] != null)
                {
                    Init(Request.QueryString["Sort"].ToString());
                }
                else
                {
                    Init("Sys_UserId");
                }
            }
        }

        public void Init(string sortName)
        {
            int page = 1;
            if (Request.QueryString["page"] != null)
                page = int.Parse(Request.QueryString["page"].ToString());

            if (Session["UserSessionId"] != null)
            {
                int userId = int.Parse(Session["UserSessionId"].ToString());

                List<SqlParameter> _params = new List<SqlParameter> { 
                new SqlParameter("@pageIndex", page),
                new SqlParameter("@pageSize", AspNetPager1.PageSize)
            };
                if (!string.IsNullOrEmpty(sortName))
                {
                    _params.Add(new SqlParameter("@sortName", sortName));
                }
                rptBidList.DataSource = DbHelperSQL.RunProcedure("GetSysUserList", _params.ToArray());
                rptBidList.DataBind();

                int totalUserCount = (int)DbHelperSQL.GetSingle("SELECT COUNT(*) FROM Sys_Users WHERE Deleted <> 1 and (CreateByPlatform is null or CreateByPlatform <> 1)");

                ltrTotalUserCount.Text = totalUserCount.ToString();
                AspNetPager1.RecordCount = totalUserCount;
            }
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
        }

        public string GetUserLoginTypeName(int type)
        {
            if (type == 1)
                return "投标商";
            else if (type == 2)
                return "招标商";

            return "其他";
        }

        public string GetCompanyAuditStatusName(string CompanyAuditStatusString)
        {
            if (string.IsNullOrEmpty(CompanyAuditStatusString))
                return "";

            int CompanyAuditStatus = int.Parse(CompanyAuditStatusString);
            if (CompanyAuditStatus == 0)
            {
                return "未认证";
            }
            else if (CompanyAuditStatus == 1)
            {
                return "待审核";
            }
            else if (CompanyAuditStatus == 2)
            {
                return "已认证";
            }
            else if (CompanyAuditStatus == 3)
            {
                return "未认证";
            }

            return "其他";
        }

        protected void btnSortByLastLoginTime_Click(object sender, EventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = 1;

            Response.Redirect("/UserCenter/UserCenterPage/Admin/UserList.aspx?Sort=LastLoginTime");
        }

        protected void btnSortByScore_Click(object sender, EventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = 1;
            Response.Redirect("/UserCenter/UserCenterPage/Admin/UserList.aspx?Sort=Scores");
        }

        protected void btnDefault_Click(object sender, EventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = 1;
            Response.Redirect("/UserCenter/UserCenterPage/Admin/UserList.aspx?Sort=Sys_UserId");
        }

        protected void btnLoginTimes_Click(object sender, EventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = 1;
            Response.Redirect("/UserCenter/UserCenterPage/Admin/UserList.aspx?Sort=LoginTimes");
        }


        public void GetRegistUserCountByDate()
        {
            string usercountsql = @"
select top 30 COUNT(*),convert(varchar(10),OnCreate,120)  from Sys_Users 
where CreateByPlatform <> 1
and Deleted <> 1
group by convert(varchar(10),OnCreate,120)
order by convert(varchar(10),OnCreate,120)  desc ";

            DbHelperSQL.Query(usercountsql);

        
        }
    }
}