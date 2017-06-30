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
    public partial class SechduleList : System.Web.UI.Page
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

            }
        }

        public void Init()
        {
           
        }


    }
}