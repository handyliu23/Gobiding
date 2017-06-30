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
namespace GoBiding.Web.SmartCategorys
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
					int SmartCategoryId=(Convert.ToInt32(strid));
					ShowInfo(SmartCategoryId);
				}
			}
		}
		
	private void ShowInfo(int SmartCategoryId)
	{
		GoBiding.BLL.SmartCategorys bll=new GoBiding.BLL.SmartCategorys();
		GoBiding.Model.SmartCategorys model=bll.GetModel(SmartCategoryId);
		this.lblSmartCategoryId.Text=model.SmartCategoryId.ToString();
		this.lblKeywords.Text=model.Keywords;
		this.lblBidCategoryId.Text=model.BidCategoryId.ToString();
		this.lblBidCategoryName.Text=model.BidCategoryName;

	}


    }
}
