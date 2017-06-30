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
namespace GoBiding.Web.BidCategorys
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
					int BidCategoryId=(Convert.ToInt32(strid));
					ShowInfo(BidCategoryId);
				}
			}
		}
		
	private void ShowInfo(int BidCategoryId)
	{
		GoBiding.BLL.BidCategorys bll=new GoBiding.BLL.BidCategorys();
		GoBiding.Model.BidCategorys model=bll.GetModel(BidCategoryId);
		this.lblBidCategoryId.Text=model.BidCategoryId.ToString();
		this.lblBidCategoryName.Text=model.BidCategoryName;
		this.lblParentCategoryId.Text=model.ParentCategoryId.ToString();

	}


    }
}
