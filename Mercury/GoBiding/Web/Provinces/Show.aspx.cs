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
namespace GoBiding.Web.Provinces
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
					long ProvinceID=(Convert.ToInt64(strid));
					ShowInfo(ProvinceID);
				}
			}
		}
		
	private void ShowInfo(long ProvinceID)
	{
		GoBiding.BLL.Provinces bll=new GoBiding.BLL.Provinces();
		GoBiding.Model.Provinces model=bll.GetModel(ProvinceID);
		this.lblProvinceID.Text=model.ProvinceID.ToString();
		this.lblProvinceName.Text=model.ProvinceName;
		this.lblDateCreated.Text=model.DateCreated.ToString();
		this.lblDateUpdated.Text=model.DateUpdated.ToString();

	}


    }
}
