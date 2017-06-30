using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.UserHostAddress == "127.0.0.1")
                {
                    txtLoginUserName.Value = "18321571920";
                    txtLoginPassword.Value = "123123";
                }
            }
        }
    }
}