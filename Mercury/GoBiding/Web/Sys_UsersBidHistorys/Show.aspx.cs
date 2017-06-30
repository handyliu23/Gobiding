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
namespace GoBiding.Web.Sys_UsersBidHistorys
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
					long UserBidsHistory=(Convert.ToInt64(strid));
					ShowInfo(UserBidsHistory);
				}
			}
		}
		
	private void ShowInfo(long UserBidsHistory)
	{
		GoBiding.BLL.Sys_UsersBidHistorys bll=new GoBiding.BLL.Sys_UsersBidHistorys();
		GoBiding.Model.Sys_UsersBidHistorys model=bll.GetModel(UserBidsHistory);
		this.lblUserBidsHistory.Text=model.UserBidsHistory.ToString();
		this.lblUserId.Text=model.UserId.ToString();
		this.lblBidId.Text=model.BidId.ToString();
		this.lblCreateTime.Text=model.CreateTime.ToString();

	}


    }
}
