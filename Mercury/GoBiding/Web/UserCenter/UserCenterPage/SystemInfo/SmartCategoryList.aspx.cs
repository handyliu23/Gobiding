using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web.UserCenter.UserCenterPage.SystemInfo
{
    public partial class SmartCategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if (Session["UserSessionId"] == null)
                {
                    mainContent.Visible = false;
                    Response.Redirect("/Login.aspx");
                    return;
                }

                Bind();
            }
        }

        public void Bind()
        {
            if (Request.QueryString["CId"] == null)
            {
                DataSet ds = new BLL.SmartCategorys().GetList(" ParentCategoryId = 0");
                lstSmartCategorys.DataSource = ds;
                lstSmartCategorys.DataBind();
            }
            else {
                int cId = int.Parse(Request.QueryString["CId"].ToString());
                DataSet ds = new BLL.SmartCategorys().GetList(" ParentCategoryId = " + cId + " or BidCategoryId = " + cId);
                lstSmartCategorys.DataSource = ds;
                lstSmartCategorys.DataBind();
            }
        }

        protected void lstSmartCategorys_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "SAVE")
            {
                HiddenField hidfield = (HiddenField)e.Item.FindControl("hdfKeyId");
                TextBox txtKeywords = (TextBox)e.Item.FindControl("txtKeywords");

                int keyid = int.Parse(hidfield.Value);
                var model = new BLL.SmartCategorys().GetModel(keyid);
                model.Keywords = txtKeywords.Text;
                new BLL.SmartCategorys().Update(model);

                Bind();
            }
        }

    }
}