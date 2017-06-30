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
namespace GoBiding.Web.Sys_UserTrackers
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
					int UserTrackerId=(Convert.ToInt32(strid));
					ShowInfo(UserTrackerId);
				}
			}
		}
		
	private void ShowInfo(int UserTrackerId)
	{
		GoBiding.BLL.Sys_UserTrackers bll=new GoBiding.BLL.Sys_UserTrackers();
		GoBiding.Model.Sys_UserTrackers model=bll.GetModel(UserTrackerId);
		this.lblUserTrackerId.Text=model.UserTrackerId.ToString();
		this.lblTrackerName.Text=model.TrackerName;
		this.lblTrackerCityIds.Text=model.TrackerCityIds;
		this.lblTrackerIndustryIds.Text=model.TrackerIndustryIds;
		this.lblCreateTime.Text=model.CreateTime.ToString();
		this.lblKeyword1.Text=model.Keyword1;
		this.lblKeyword2.Text=model.Keyword2;
		this.lblKeyword3.Text=model.Keyword3;
		this.lblKeyword4.Text=model.Keyword4;
		this.lblKeyword5.Text=model.Keyword5;
		this.lblSys_UserId.Text=model.Sys_UserId.ToString();

	}


    }
}
