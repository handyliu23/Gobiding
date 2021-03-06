﻿using System;
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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace GoBiding.Web.Sys_Users
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtUserNickName.Text.Trim().Length==0)
			{
				strErr+="UserNickName不能为空！\\n";	
			}
			if(this.txtPassword.Text.Trim().Length==0)
			{
				strErr+="Password不能为空！\\n";	
			}
			if(this.txtUserName.Text.Trim().Length==0)
			{
				strErr+="UserName不能为空！\\n";	
			}
			if(this.txtDescription.Text.Trim().Length==0)
			{
				strErr+="Description不能为空！\\n";	
			}
			if(this.txtUserProfile.Text.Trim().Length==0)
			{
				strErr+="UserProfile不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtGender.Text))
			{
				strErr+="Gender格式错误！\\n";	
			}
			if(this.txtAddress.Text.Trim().Length==0)
			{
				strErr+="Address不能为空！\\n";	
			}
			if(this.txtContacterName.Text.Trim().Length==0)
			{
				strErr+="ContacterName不能为空！\\n";	
			}
			if(this.txtTelephonePhone.Text.Trim().Length==0)
			{
				strErr+="TelephonePhone不能为空！\\n";	
			}
			if(this.txtTelephonePhone2.Text.Trim().Length==0)
			{
				strErr+="TelephonePhone2不能为空！\\n";	
			}
			if(this.txtMobilePhone.Text.Trim().Length==0)
			{
				strErr+="MobilePhone不能为空！\\n";	
			}
			if(this.txtMobilePhone2.Text.Trim().Length==0)
			{
				strErr+="MobilePhone2不能为空！\\n";	
			}
			if(this.txtEmail.Text.Trim().Length==0)
			{
				strErr+="Email不能为空！\\n";	
			}
			if(this.txtQQ.Text.Trim().Length==0)
			{
				strErr+="QQ不能为空！\\n";	
			}
			if(this.txtFax.Text.Trim().Length==0)
			{
				strErr+="Fax不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDistrictId.Text))
			{
				strErr+="DistrictId格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtOnCreate.Text))
			{
				strErr+="OnCreate格式错误！\\n";	
			}
			if(this.txtManufacturerGUID.Text.Trim().Length==0)
			{
				strErr+="ManufacturerGUID不能为空！\\n";	
			}
			if(this.txtPostCode.Text.Trim().Length==0)
			{
				strErr+="PostCode不能为空！\\n";	
			}
			if(this.txtWebSite.Text.Trim().Length==0)
			{
				strErr+="WebSite不能为空！\\n";	
			}
			if(this.txtNotes.Text.Trim().Length==0)
			{
				strErr+="Notes不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDisplayOrder.Text))
			{
				strErr+="DisplayOrder格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtScores.Text))
			{
				strErr+="Scores格式错误！\\n";	
			}
			if(this.txtLoginIp.Text.Trim().Length==0)
			{
				strErr+="LoginIp不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtLastLoginTime.Text))
			{
				strErr+="LastLoginTime格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtLevelId.Text))
			{
				strErr+="LevelId格式错误！\\n";	
			}
			if(this.txtLastLoginIp.Text.Trim().Length==0)
			{
				strErr+="LastLoginIp不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDefaultAddressId.Text))
			{
				strErr+="DefaultAddressId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtRecommenderId.Text))
			{
				strErr+="RecommenderId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUserLoginType.Text))
			{
				strErr+="1:QQ,2:新浪微博格式错误！\\n";	
			}
			if(this.txtOpenId.Text.Trim().Length==0)
			{
				strErr+="OpenId不能为空！\\n";	
			}
			if(this.txtAccessToken.Text.Trim().Length==0)
			{
				strErr+="AccessToken不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtRecommendUserId.Text))
			{
				strErr+="RecommendUserId格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string UserNickName=this.txtUserNickName.Text;
			string Password=this.txtPassword.Text;
			string UserName=this.txtUserName.Text;
			string Description=this.txtDescription.Text;
			string UserProfile=this.txtUserProfile.Text;
			int Gender=int.Parse(this.txtGender.Text);
			string Address=this.txtAddress.Text;
			string ContacterName=this.txtContacterName.Text;
			string TelephonePhone=this.txtTelephonePhone.Text;
			string TelephonePhone2=this.txtTelephonePhone2.Text;
			string MobilePhone=this.txtMobilePhone.Text;
			string MobilePhone2=this.txtMobilePhone2.Text;
			string Email=this.txtEmail.Text;
			string QQ=this.txtQQ.Text;
			string Fax=this.txtFax.Text;
			int DistrictId=int.Parse(this.txtDistrictId.Text);
			DateTime OnCreate=DateTime.Parse(this.txtOnCreate.Text);
			bool Deleted=this.chkDeleted.Checked;
			string ManufacturerGUID=this.txtManufacturerGUID.Text;
			string PostCode=this.txtPostCode.Text;
			string WebSite=this.txtWebSite.Text;
			string Notes=this.txtNotes.Text;
			int DisplayOrder=int.Parse(this.txtDisplayOrder.Text);
			int Scores=int.Parse(this.txtScores.Text);
			string LoginIp=this.txtLoginIp.Text;
			DateTime LastLoginTime=DateTime.Parse(this.txtLastLoginTime.Text);
			int LevelId=int.Parse(this.txtLevelId.Text);
			string LastLoginIp=this.txtLastLoginIp.Text;
			int DefaultAddressId=int.Parse(this.txtDefaultAddressId.Text);
			int RecommenderId=int.Parse(this.txtRecommenderId.Text);
			int UserLoginType=int.Parse(this.txtUserLoginType.Text);
			string OpenId=this.txtOpenId.Text;
			string AccessToken=this.txtAccessToken.Text;
			int RecommendUserId=int.Parse(this.txtRecommendUserId.Text);

			GoBiding.Model.Sys_Users model=new GoBiding.Model.Sys_Users();
			model.UserNickName=UserNickName;
			model.Password=Password;
			model.UserName=UserName;
			model.Description=Description;
			model.UserProfile=UserProfile;
			model.Gender=Gender;
			model.Address=Address;
			model.ContacterName=ContacterName;
			model.TelephonePhone=TelephonePhone;
			model.TelephonePhone2=TelephonePhone2;
			model.MobilePhone=MobilePhone;
			model.MobilePhone2=MobilePhone2;
			model.Email=Email;
			model.QQ=QQ;
			model.Fax=Fax;
			model.DistrictId=DistrictId;
			model.OnCreate=OnCreate;
			model.Deleted=Deleted;
			model.ManufacturerGUID=ManufacturerGUID;
			model.PostCode=PostCode;
			model.WebSite=WebSite;
			model.Notes=Notes;
			model.DisplayOrder=DisplayOrder;
			model.Scores=Scores;
			model.LoginIp=LoginIp;
			model.LastLoginTime=LastLoginTime;
			model.LevelId=LevelId;
			model.LastLoginIp=LastLoginIp;
			model.DefaultAddressId=DefaultAddressId;
			model.RecommenderId=RecommenderId;
			model.UserLoginType=UserLoginType;
			model.OpenId=OpenId;
			model.AccessToken=AccessToken;
			model.RecommendUserId=RecommendUserId;

			GoBiding.BLL.Sys_Users bll=new GoBiding.BLL.Sys_Users();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
