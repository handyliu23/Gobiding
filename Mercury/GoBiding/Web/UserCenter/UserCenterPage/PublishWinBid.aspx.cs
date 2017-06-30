using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Model;
using GoBiding.Web.BaseCode;

namespace GoBiding.Web.UserCenter.UserCenterPage
{
    public partial class PublishWinBid : PhoenixBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
            }

        }

        public void Init()
        {
            var ps = new BLL.Provinces().GetAllList();

            this.rptBidAreas.DataSource = ps;
            rptBidAreas.DataBind();

            int userId = int.Parse(Session["UserSessionId"].ToString());

            var user = new BLL.Sys_Users().GetModel(userId);
            IsCompanyAudited.Value = user.CompanyAuditStatus == 2 ? "true" : "false";

        }

    }
}