using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mercury.Web
{
    public partial class BidAreas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BLL.Provinces provinceService = new BLL.Provinces();
                lstAreas.DataSource = provinceService.GetAllList();
                lstAreas.DataBind();

            }
        }

        public bool IsCoverd(string pName)
        {
            var ds = new BLL.Spiders().GetList(1, " SpiderName like '%" + pName + "%'", "SpiderId");

            if (ds != null && ds.Tables[0].Rows.Count > 0)
                return true;

            return false;
        }
    }
}