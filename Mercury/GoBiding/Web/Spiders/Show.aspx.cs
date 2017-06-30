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
namespace GoBiding.Web.Spiders
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
		GoBiding.BLL.Spiders bll=new GoBiding.BLL.Spiders();
		GoBiding.Model.Spiders model=bll.GetModel(SpiderId);
		this.lblSpiderId.Text=model.SpiderId.ToString();
		this.lblSpiderName.Text=model.SpiderName;
		this.lblSpiderUrl.Text=model.SpiderUrl;
		this.lblCreateTime.Text=model.CreateTime.ToString();
		this.lblEncodeType.Text=model.EncodeType;
		this.lblListExpression.Text=model.ListExpression;
		this.lblDetailExpression.Text=model.DetailExpression;
		this.lblSpiderUrlPrefix.Text=model.SpiderUrlPrefix;
		this.lblDistrictId.Text=model.DistrictId.ToString();
		this.lblCityId.Text=model.CityId.ToString();
		this.lblProvinceId.Text=model.ProvinceId.ToString();
		this.lblTitleExpression.Text=model.TitleExpression;
		this.lblPublishExpression.Text=model.PublishExpression;
		this.lblContentExpression.Text=model.ContentExpression;
		this.lblSourceExpression.Text=model.SourceExpression;
		this.lblFilenameExpressoin.Text=model.FilenameExpressoin;
		this.lblBidType.Text=model.BidType;
		this.lblStatus.Text=model.Status.ToString();
		this.lblHttpMethod.Text=model.HttpMethod;
		this.lblPageParameter.Text=model.PageParameter;
		this.lblIsActive.Text=model.IsActive?"是":"否";
		this.lblSpiderType.Text=model.SpiderType.ToString();
		this.lblPageCount.Text=model.PageCount.ToString();

	}


    }
}
