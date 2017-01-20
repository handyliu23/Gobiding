using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mercury.Web.Controls
{
    public partial class CitysControl1 : System.Web.UI.UserControl
    {
        public int ProvinceID;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BLL.Citys cityService = new BLL.Citys();
                lstCitys.DataSource = cityService.GetList(" ProvinceID = " + ProvinceID);
                lstCitys.DataBind();
            }
        }

        public bool IsCoverd(int cityId)
        {
            var ds = new BLL.Spiders().GetList(1, "CityId=" + cityId, "SpiderId");

            if (ds != null && ds.Tables[0].Rows.Count > 0)
                return true;

            return false;
        }
    }
}