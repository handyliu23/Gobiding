using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web.oauth
{
    public partial class QQLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            QQ_Login q = new QQ_Login();
            string url = q.Authorize();//这里调用
            Response.Write(url);
        }
    }
}