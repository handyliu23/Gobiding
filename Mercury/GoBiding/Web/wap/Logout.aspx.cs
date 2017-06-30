using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Maticsoft.Common;

namespace GoBiding.Web.wap
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            CookieUtil.SetCookie(CookieUtil.Cookie_RemeberMe,"",new DateTime(1970,1,1));
            Session.Abandon();
            Response.Redirect("/wap/wapLogin.aspx");
        }
    }
}