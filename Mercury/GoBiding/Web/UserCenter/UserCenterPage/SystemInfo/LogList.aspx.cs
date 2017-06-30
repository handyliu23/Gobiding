using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.DBUtility;
using System.Data.SqlClient;

namespace GoBiding.Web.UserCenter.UserCenterPage.SystemInfo
{
    public partial class LogList : System.Web.UI.Page
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

                Init(null, null);
            }
        }

        public void Init(string appName, string logType)
        {
            if (Session["UserSessionId"] != null)
            {
                int userId = int.Parse(Session["UserSessionId"].ToString());

                List<SqlParameter> _params = new List<SqlParameter> { 
                new SqlParameter("@pageIndex", AspNetPager1.CurrentPageIndex),
                new SqlParameter("@pageSize", AspNetPager1.PageSize)
            };
                string where = " where 1=1 ";

                if (!string.IsNullOrEmpty(appName))
                {
                    _params.Add( new SqlParameter("@appName", appName));
                    where += " and AppName = '" + appName + "'";
                }
                if (!string.IsNullOrEmpty(logType))
                {
                    _params.Add(new SqlParameter("@logType", logType));
                    where += " and logType = '" + logType + "'";
                }

                if (where.Length < " where 1=1 ".Length)
                    where = "";

                rptBidList.DataSource = DbHelperSQL.RunProcedure("GetSystemLogList", _params.ToArray());
                rptBidList.DataBind();

                int totalUserCount = (int)DbHelperSQL.GetSingle("SELECT COUNT(*) FROM SystemLog " + where);

                ltrTotalUserCount.Text = totalUserCount.ToString();
                AspNetPager1.RecordCount = totalUserCount;
            }
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string appName = ddlAppName.SelectedItem.Text;
            string logType = ddlLogType.SelectedItem.Text;
            Init(appName, logType);
        }

    }
}