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
namespace GoBiding.Web.Bids
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
					long BidId=(Convert.ToInt64(strid));
					ShowInfo(BidId);
				}
			}
		}
		
	private void ShowInfo(long BidId)
	{
		GoBiding.BLL.Bids bll=new GoBiding.BLL.Bids();
		GoBiding.Model.Bids model=bll.GetModel(BidId);
		this.lblBidId.Text=model.BidId.ToString();
		this.lblBidTitle.Text=model.BidTitle;
		this.lblBidPublishTime.Text=model.BidPublishTime.ToString();
		this.lblBidContent.Text=model.BidContent;
		this.lblCityId.Text=model.CityId.ToString();
		this.lblProvinceId.Text=model.ProvinceId.ToString();
		this.lblBidNumber.Text=model.BidNumber;
		this.lblBidExpireTime.Text=model.BidExpireTime.ToString();
		this.lblBidFileName.Text=model.BidFileName;
		this.lblBidProjectName.Text=model.BidProjectName;
		this.lblBidAgent.Text=model.BidAgent;
		this.lblBidKeywords.Text=model.BidKeywords;
		this.lblBidContacter.Text=model.BidContacter;
		this.lblBidContacterMobile.Text=model.BidContacterMobile;
		this.lblBidContacterTel.Text=model.BidContacterTel;
		this.lblBidContacterAddress.Text=model.BidContacterAddress;
		this.lblBidContacterURL.Text=model.BidContacterURL;
		this.lblBidSourceURL.Text=model.BidSourceURL;
		this.lblBidSourceName.Text=model.BidSourceName;
		this.lblCreateTime.Text=model.CreateTime.ToString();
		this.lblLastChangeTime.Text=model.LastChangeTime.ToString();
		this.lblBidType.Text=model.BidType;
		this.lblBidFileNameURI.Text=model.BidFileNameURI;
		this.lblBidSpiderName.Text=model.BidSpiderName;
		this.lblBidCategoryId.Text=model.BidCategoryId.ToString();
		this.lblBidCompanyId.Text=model.BidCompanyId.ToString();
		this.lblBidCompanyName.Text=model.BidCompanyName;
		this.lblBidOpenTime.Text=model.BidOpenTime.ToString();
		this.lblBidPlatFrom.Text=model.BidPlatFrom;

	}


    }
}
