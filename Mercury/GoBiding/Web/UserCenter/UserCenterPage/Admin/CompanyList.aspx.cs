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
    public partial class CompanyList : System.Web.UI.Page
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
                Init("Id");
            }
        }

        public void Init(string sortName)
        {
            if (Session["UserSessionId"] != null)
            {
                int userId = int.Parse(Session["UserSessionId"].ToString());

                List<SqlParameter> _params = new List<SqlParameter> { 
                new SqlParameter("@pageIndex", AspNetPager1.CurrentPageIndex),
                new SqlParameter("@pageSize", AspNetPager1.PageSize)
            };
                if(!string.IsNullOrEmpty(sortName))
                {
                    _params.Add(new SqlParameter("@sortName", sortName));
                }
                rptBidList.DataSource = DbHelperSQL.RunProcedure("GetCompanyList", _params.ToArray());
                rptBidList.DataBind();

                int totalUserCount = (int)DbHelperSQL.GetSingle("SELECT COUNT(*) FROM CatchCompany ");

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
            Init("OnCreated");
        }

        protected void btnDefault_Click(object sender, EventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = 1;

            Init("Id");
        }

        protected void btnLoginTimes_Click(object sender, EventArgs e)
        {
            this.AspNetPager1.CurrentPageIndex = 1;

            Init("按ProvinceId倒序");
        }
    }
}