using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mercury.Web.Tools
{
    public partial class SmartCategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            DataSet ds = new Mercury.BLL.SmartCategorys().GetAllList();
            lstSmartCategorys.DataSource = ds;
            lstSmartCategorys.DataBind();
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