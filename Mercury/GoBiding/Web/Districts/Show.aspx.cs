using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
namespace GoBiding.Web.Districts
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					long DistrictID=(Convert.ToInt64(strid));
					ShowInfo(DistrictID);
				}
			}
		}
		
	private void ShowInfo(long DistrictID)
	{
		GoBiding.BLL.Districts bll=new GoBiding.BLL.Districts();
		GoBiding.Model.Districts model=bll.GetModel(DistrictID);
		this.lblDistrictID.Text=model.DistrictID.ToString();
		this.lblDistrictName.Text=model.DistrictName;
		this.lblCityID.Text=model.CityID.ToString();
		this.lblDateCreated.Text=model.DateCreated.ToString();
		this.lblDateUpdated.Text=model.DateUpdated.ToString();

	}


    }
}
