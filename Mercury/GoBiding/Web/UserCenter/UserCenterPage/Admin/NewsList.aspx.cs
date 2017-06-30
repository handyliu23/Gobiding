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
    public partial class NewsList : System.Web.UI.Page
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
             
                Init();
            }
        }

        public void Init()
        {
            int page = 1;
            if (Request.QueryString["page"] != null)
                page = int.Parse(Request.QueryString["page"].ToString());

            if (Session["UserSessionId"] != null)
            {
                int userId = int.Parse(Session["UserSessionId"].ToString());

                SqlParameter[] _params = new SqlParameter[] { 
                new SqlParameter("@pageIndex", page),
                new SqlParameter("@pageSize", AspNetPager1.PageSize)
            };
                rptBidList.DataSource = DbHelperSQL.RunProcedure("GetNewsList", _params);
                rptBidList.DataBind();

                int totalUserCount = (int)DbHelperSQL.GetSingle("SELECT COUNT(*) FROM DynamicNews");

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
    }
}