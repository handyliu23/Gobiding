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
namespace GoBiding.Web.Sys_UserFavouriteBids
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
					int Sys_UserFavouriteBidId=(Convert.ToInt32(strid));
					ShowInfo(Sys_UserFavouriteBidId);
				}
			}
		}
		
	private void ShowInfo(int Sys_UserFavouriteBidId)
	{
		GoBiding.BLL.Sys_UserFavouriteBids bll=new GoBiding.BLL.Sys_UserFavouriteBids();
		GoBiding.Model.Sys_UserFavouriteBids model=bll.GetModel(Sys_UserFavouriteBidId);
		this.lblSys_UserFavouriteBidId.Text=model.Sys_UserFavouriteBidId.ToString();
		this.lblUserId.Text=model.UserId.ToString();
		this.lblBidId.Text=model.BidId.ToString();
		this.lblCreateTime.Text=model.CreateTime.ToString();
		this.lblIsActive.Text=model.IsActive?"是":"否";

	}


    }
}
