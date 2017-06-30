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
using Maticsoft.Common;
using LTP.Accounts.Bus;
namespace GoBiding.Web.Bids
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			if(this.txtBidType.Text.Trim().Length==0)
			{
				strErr+="BidType不能为空！\\n";	
			}
			if(this.txtBidFileNameURI.Text.Trim().Length==0)
			{
				strErr+="BidFileNameURI不能为空！\\n";	
			}
			if(this.txtBidSpiderName.Text.Trim().Length==0)
			{
				strErr+="BidSpiderName不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtBidCategoryId.Text))
			{
				strErr+="BidCategoryId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBidCompanyId.Text))
			{
				strErr+="BidCompanyId格式错误！\\n";	
			}
			if(this.txtBidCompanyName.Text.Trim().Length==0)
			{
				strErr+="BidCompanyName不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtBidOpenTime.Text))
			{
				strErr+="BidOpenTime格式错误！\\n";	
			}
			if(this.txtBidPlatFrom.Text.Trim().Length==0)
			{
				strErr+="BidPlatFrom不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
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
			string BidType=this.txtBidType.Text;
			string BidFileNameURI=this.txtBidFileNameURI.Text;
			string BidSpiderName=this.txtBidSpiderName.Text;
			int BidCategoryId=int.Parse(this.txtBidCategoryId.Text);
			int BidCompanyId=int.Parse(this.txtBidCompanyId.Text);
			string BidCompanyName=this.txtBidCompanyName.Text;
			DateTime BidOpenTime=DateTime.Parse(this.txtBidOpenTime.Text);
			string BidPlatFrom=this.txtBidPlatFrom.Text;

			GoBiding.Model.Bids model=new GoBiding.Model.Bids();
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
			model.BidType=BidType;
			model.BidFileNameURI=BidFileNameURI;
			model.BidSpiderName=BidSpiderName;
			model.BidCategoryId=BidCategoryId;
			model.BidCompanyId=BidCompanyId;
			model.BidCompanyName=BidCompanyName;
			model.BidOpenTime=BidOpenTime;
			model.BidPlatFrom=BidPlatFrom;

			GoBiding.BLL.Bids bll=new GoBiding.BLL.Bids();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
