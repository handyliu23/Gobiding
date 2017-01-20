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
namespace Mercury.Web.Citys
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
					long CityID=(Convert.ToInt64(strid));
					ShowInfo(CityID);
				}
			}
		}
		
	private void ShowInfo(long CityID)
	{
		Mercury.BLL.Citys bll=new Mercury.BLL.Citys();
		Mercury.Model.Citys model=bll.GetModel(CityID);
		this.lblCityID.Text=model.CityID.ToString();
		this.lblCityName.Text=model.CityName;
		this.lblZipCode.Text=model.ZipCode;
		this.lblProvinceID.Text=model.ProvinceID.ToString();
		this.lblDateCreated.Text=model.DateCreated.ToString();
		this.lblDateUpdated.Text=model.DateUpdated.ToString();

	}


    }
}
