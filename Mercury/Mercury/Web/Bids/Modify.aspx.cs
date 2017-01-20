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
namespace Mercury.Web.Bids
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					long BidId=(Convert.ToInt64(Request.Params["id"]));
					ShowInfo(BidId);
				}
			}
		}
			
	private void ShowInfo(long BidId)
	{
		Mercury.BLL.Bids bll=new Mercury.BLL.Bids();
		Mercury.Model.Bids model=bll.GetModel(BidId);
		this.lblBidId.Text=model.BidId.ToString();
		this.txtBidTitle.Text=model.BidTitle;
		this.txtBidPublishTime.Text=model.BidPublishTime.ToString();
		this.txtBidContent.Text=model.BidContent;
		this.txtCityId.Text=model.CityId.ToString();
		this.txtProvinceId.Text=model.ProvinceId.ToString();
		this.txtBidNumber.Text=model.BidNumber;
		this.txtBidExpireTime.Text=model.BidExpireTime.ToString();
		this.txtBidFileName.Text=model.BidFileName;
		this.txtBidProjectName.Text=model.BidProjectName;
		this.txtBidAgent.Text=model.BidAgent;
		this.txtBidKeywords.Text=model.BidKeywords;
		this.txtBidContacter.Text=model.BidContacter;
		this.txtBidContacterMobile.Text=model.BidContacterMobile;
		this.txtBidContacterTel.Text=model.BidContacterTel;
		this.txtBidContacterAddress.Text=model.BidContacterAddress;
		this.txtBidContacterURL.Text=model.BidContacterURL;
		this.txtBidSourceURL.Text=model.BidSourceURL;
		this.txtBidSourceName.Text=model.BidSourceName;
		this.txtCreateTime.Text=model.CreateTime.ToString();
		this.txtLastChangeTime.Text=model.LastChangeTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtBidTitle.Text.Trim().Length==0)
			{
				strErr+="BidTitle不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtBidPublishTime.Text))
			{
				strErr+="BidPublishTime格式错误！\\n";	
			}
			if(this.txtBidContent.Text.Trim().Length==0)
			{
				strErr+="BidContent不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCityId.Text))
			{
				strErr+="CityId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtProvinceId.Text))
			{
				strErr+="ProvinceId格式错误！\\n";	
			}
			if(this.txtBidNumber.Text.Trim().Length==0)
			{
				strErr+="BidNumber不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtBidExpireTime.Text))
			{
				strErr+="BidExpireTime格式错误！\\n";	
			}
			if(this.txtBidFileName.Text.Trim().Length==0)
			{
				strErr+="BidFileName不能为空！\\n";	
			}
			if(this.txtBidProjectName.Text.Trim().Length==0)
			{
				strErr+="BidProjectName不能为空！\\n";	
			}
			if(this.txtBidAgent.Text.Trim().Length==0)
			{
				strErr+="BidAgent不能为空！\\n";	
			}
			if(this.txtBidKeywords.Text.Trim().Length==0)
			{
				strErr+="BidKeywords不能为空！\\n";	
			}
			if(this.txtBidContacter.Text.Trim().Length==0)
			{
				strErr+="BidContacter不能为空！\\n";	
			}
			if(this.txtBidContacterMobile.Text.Trim().Length==0)
			{
				strErr+="BidContacterMobile不能为空！\\n";	
			}
			if(this.txtBidContacterTel.Text.Trim().Length==0)
			{
				strErr+="BidContacterTel不能为空！\\n";	
			}
			if(this.txtBidContacterAddress.Text.Trim().Length==0)
			{
				strErr+="BidContacterAddress不能为空！\\n";	
			}
			if(this.txtBidContacterURL.Text.Trim().Length==0)
			{
				strErr+="BidContacterURL不能为空！\\n";	
			}
			if(this.txtBidSourceURL.Text.Trim().Length==0)
			{
				strErr+="BidSourceURL不能为空！\\n";	
			}
			if(this.txtBidSourceName.Text.Trim().Length==0)
			{
				strErr+="BidSourceName不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCreateTime.Text))
			{
				strErr+="CreateTime格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtLastChangeTime.Text))
			{
				strErr+="LastChangeTime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			long BidId=long.Parse(this.lblBidId.Text);
			string BidTitle=this.txtBidTitle.Text;
			DateTime BidPublishTime=DateTime.Parse(this.txtBidPublishTime.Text);
			string BidContent=this.txtBidContent.Text;
			int CityId=int.Parse(this.txtCityId.Text);
			int ProvinceId=int.Parse(this.txtProvinceId.Text);
			string BidNumber=this.txtBidNumber.Text;
			DateTime BidExpireTime=DateTime.Parse(this.txtBidExpireTime.Text);
			string BidFileName=this.txtBidFileName.Text;
			string BidProjectName=this.txtBidProjectName.Text;
			string BidAgent=this.txtBidAgent.Text;
			string BidKeywords=this.txtBidKeywords.Text;
			string BidContacter=this.txtBidContacter.Text;
			string BidContacterMobile=this.txtBidContacterMobile.Text;
			string BidContacterTel=this.txtBidContacterTel.Text;
			string BidContacterAddress=this.txtBidContacterAddress.Text;
			string BidContacterURL=this.txtBidContacterURL.Text;
			string BidSourceURL=this.txtBidSourceURL.Text;
			string BidSourceName=this.txtBidSourceName.Text;
			DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);
			DateTime LastChangeTime=DateTime.Parse(this.txtLastChangeTime.Text);


			Mercury.Model.Bids model=new Mercury.Model.Bids();
			model.BidId=BidId;
			model.BidTitle=BidTitle;
			model.BidPublishTime=BidPublishTime;
			model.BidContent=BidContent;
			model.CityId=CityId;
			model.ProvinceId=ProvinceId;
			model.BidNumber=BidNumber;
			model.BidExpireTime=BidExpireTime;
			model.BidFileName=BidFileName;
			model.BidProjectName=BidProjectName;
			model.BidAgent=BidAgent;
			model.BidKeywords=BidKeywords;
			model.BidContacter=BidContacter;
			model.BidContacterMobile=BidContacterMobile;
			model.BidContacterTel=BidContacterTel;
			model.BidContacterAddress=BidContacterAddress;
			model.BidContacterURL=BidContacterURL;
			model.BidSourceURL=BidSourceURL;
			model.BidSourceName=BidSourceName;
			model.CreateTime=CreateTime;
			model.LastChangeTime=LastChangeTime;

			Mercury.BLL.Bids bll=new Mercury.BLL.Bids();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
