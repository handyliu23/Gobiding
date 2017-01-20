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
namespace Mercury.Web.Spiders
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
					long SpiderId=(Convert.ToInt64(strid));
					ShowInfo(SpiderId);
				}
			}
		}
		
	private void ShowInfo(long SpiderId)
	{
		Mercury.BLL.Spiders bll=new Mercury.BLL.Spiders();
		Mercury.Model.Spiders model=bll.GetModel(SpiderId);
		this.lblSpiderId.Text=model.SpiderId.ToString();
		this.lblSpiderName.Text=model.SpiderName;
		this.lblSpiderUrl.Text=model.SpiderUrl;
		this.lblCreateTime.Text=model.CreateTime.ToString();

	}


    }
}
