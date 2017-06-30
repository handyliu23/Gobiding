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
    public partial class MessageCenter : PhoenixBase
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userId = int.Parse(Session["UserSessionId"].ToString());

                int totalBidsCount = (int)DbHelperSQL.GetSingle("SELECT COUNT(*) FROM Message where ReceiverId = " + userId);
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
                new SqlParameter("@ReceiverId", userId)
            };
            rptBidList.DataSource = DbHelperSQL.RunProcedure("GetUserMessagesList", _params);
            rptBidList.DataBind();
        }
        
        public string GetSenderName(string senderId)
        {
            if (senderId == "0")
                return "管理员";

            var model =new BLL.Sys_Users().GetModel(int.Parse(senderId));
            if (model == null)
                return "";
            return model.UserName;
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            Init();
        }
    }
}