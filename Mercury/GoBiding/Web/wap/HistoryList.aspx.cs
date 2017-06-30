using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.BLL;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using Newtonsoft.Json;

namespace GoBiding.Web.wap
{
    public partial class HistoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSessionId"] == null)
            {
                Response.Redirect("/wap/waplogin.aspx?redirecturl=" + "/wap/FavouriteList.aspx");
            }

            if (!IsPostBack)
            {
                Init();
            }
        }

        public void Init()
        {

            //SqlParameter[] _params = new SqlParameter[] { 
            //    new SqlParameter("@pageIndex", AspNetPager1.CurrentPageIndex),
            //    new SqlParameter("@pageSize", AspNetPager1.PageSize),
            //    new SqlParameter("@sysuserId", userId)
            //};
            int userId = int.Parse(Session["UserSessionId"].ToString());


            SqlParameter[] _params = new SqlParameter[]
                                             {
                                                 new SqlParameter("@pageIndex", 1),
                                                 new SqlParameter("@pageSize", 10),
                                                 new SqlParameter("@sysuserId", userId)
                                             };

            rptBidList.DataSource = DbHelperSQL.RunProcedure("GetUserHistoryBidsList", _params);
            rptBidList.DataBind();


            #region 计算总数

            #endregion

        }
    }
}