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
namespace GoBiding.Web.Sys_Users
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
					int Sys_UserId=(Convert.ToInt32(strid));
					ShowInfo(Sys_UserId);
				}
			}
		}
		
	private void ShowInfo(int Sys_UserId)
	{
		GoBiding.BLL.Sys_Users bll=new GoBiding.BLL.Sys_Users();
		GoBiding.Model.Sys_Users model=bll.GetModel(Sys_UserId);
		this.lblSys_UserId.Text=model.Sys_UserId.ToString();
		this.lblUserNickName.Text=model.UserNickName;
		this.lblUserGUID.Text=model.UserGUID.ToString();
		this.lblPassword.Text=model.Password;
		this.lblUserName.Text=model.UserName;
		this.lblDescription.Text=model.Description;
		this.lblUserProfile.Text=model.UserProfile;
		this.lblGender.Text=model.Gender.ToString();
		this.lblAddress.Text=model.Address;
		this.lblContacterName.Text=model.ContacterName;
		this.lblTelephonePhone.Text=model.TelephonePhone;
		this.lblTelephonePhone2.Text=model.TelephonePhone2;
		this.lblMobilePhone.Text=model.MobilePhone;
		this.lblMobilePhone2.Text=model.MobilePhone2;
		this.lblEmail.Text=model.Email;
		this.lblQQ.Text=model.QQ;
		this.lblFax.Text=model.Fax;
		this.lblDistrictId.Text=model.DistrictId.ToString();
		this.lblOnCreate.Text=model.OnCreate.ToString();
		this.lblDeleted.Text=model.Deleted?"是":"否";
		this.lblManufacturerGUID.Text=model.ManufacturerGUID;
		this.lblPostCode.Text=model.PostCode;
		this.lblWebSite.Text=model.WebSite;
		this.lblNotes.Text=model.Notes;
		this.lblDisplayOrder.Text=model.DisplayOrder.ToString();
		this.lblScores.Text=model.Scores.ToString();
		this.lblLoginIp.Text=model.LoginIp;
		this.lblLastLoginTime.Text=model.LastLoginTime.ToString();
		this.lblLevelId.Text=model.LevelId.ToString();
		this.lblLastLoginIp.Text=model.LastLoginIp;
		this.lblDefaultAddressId.Text=model.DefaultAddressId.ToString();
		this.lblRecommenderId.Text=model.RecommenderId.ToString();
		this.lblUserLoginType.Text=model.UserLoginType.ToString();
		this.lblOpenId.Text=model.OpenId;
		this.lblAccessToken.Text=model.AccessToken;
		this.lblRecommendUserId.Text=model.RecommendUserId.ToString();

	}


    }
}
