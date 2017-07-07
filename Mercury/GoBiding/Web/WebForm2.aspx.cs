using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace GoBiding.Web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            //txt3.Text = Encoding.UTF8.GetBytes(txt.Text);
            txt2.Text = Convert.ToBase64String(Encoding.UTF8.GetBytes(txt.Text));
        }
    }
}