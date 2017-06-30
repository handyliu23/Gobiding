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
    public partial class BrowseHistoryBids : PhoenixBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = int.Parse(Session["UserSessionId"].ToString());

                int totalBidsCount = (int)DbHelperSQL.GetSingle("SELECT COUNT(*) FROM Sys_UsersBidHistorys where userId = " + userId);
                AspNetPager1.RecordCount = totalBidsCount;
                Init();
            }
        }

        public void Init()
        {
            int userId = int.Parse(Session["UserSessionId"].ToString());
            SqlParameter[] _params = new SqlParameter[] { 
                new SqlParameter("@pageIndex", AspNetPager1.CurrentPageIndex),
                new SqlParameter("@pageSize", AspNetPager1.PageSize),
                new SqlParameter("@sysuserId", userId)
            };
            rptBidList.DataSource = DbHelperSQL.RunProcedure("GetUserHistoryBidsList", _params);
            rptBidList.DataBind();
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            Init();
        }
    }
}