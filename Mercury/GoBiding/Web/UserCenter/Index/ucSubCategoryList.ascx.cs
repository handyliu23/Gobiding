using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web.UserCenter.Index
{
    public partial class ucSubCategoryList : System.Web.UI.UserControl
    {
        public int parentCategoryId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                rptSubCategoryList.DataSource = new GoBiding.BLL.BidCategorys().GetList(" ParentCategoryId = " + parentCategoryId.ToString());
                rptSubCategoryList.DataBind();
            }
        }
    }
}