using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web.UserCenter.UserCenterPage
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Session["UserSessionId"] = null;
                Session["UserSessionOpenId"] = null;

                Response.Redirect("/Default.html");
            }
        }
    }
}