using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web.UserCenter.Index
{
    public partial class ucBidCategoryList : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Init();
            }
        }

        public void Init()
        {
            lstCategoryList.DataSource = new GoBiding.BLL.BidCategorys().GetList(" ParentCategoryId = 0");
            lstCategoryList.DataBind();
        }
    }
}