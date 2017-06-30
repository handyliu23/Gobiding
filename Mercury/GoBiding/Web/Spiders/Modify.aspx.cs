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
namespace GoBiding.Web.Spiders
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					long SpiderId=(Convert.ToInt64(Request.Params["id"]));
					ShowInfo(SpiderId);
				}
			}
		}
			
	private void ShowInfo(long SpiderId)
	{
		GoBiding.BLL.Spiders bll=new GoBiding.BLL.Spiders();
		GoBiding.Model.Spiders model=bll.GetModel(SpiderId);
		this.lblSpiderId.Text=model.SpiderId.ToString();
		this.txtSpiderName.Text=model.SpiderName;
		this.txtSpiderUrl.Text=model.SpiderUrl;
		this.txtCreateTime.Text=model.CreateTime.ToString();
		this.txtEncodeType.Text=model.EncodeType;
		this.txtListExpression.Text=model.ListExpression;
		this.txtDetailExpression.Text=model.DetailExpression;
		this.txtSpiderUrlPrefix.Text=model.SpiderUrlPrefix;
		this.txtDistrictId.Text=model.DistrictId.ToString();
		this.txtCityId.Text=model.CityId.ToString();
		this.txtProvinceId.Text=model.ProvinceId.ToString();
		this.txtTitleExpression.Text=model.TitleExpression;
		this.txtPublishExpression.Text=model.PublishExpression;
		this.txtContentExpression.Text=model.ContentExpression;
		this.txtSourceExpression.Text=model.SourceExpression;
		this.txtFilenameExpressoin.Text=model.FilenameExpressoin;
		this.txtBidType.Text=model.BidType;
		this.txtStatus.Text=model.Status.ToString();
		this.txtHttpMethod.Text=model.HttpMethod;
		this.txtPageParameter.Text=model.PageParameter;
		this.chkIsActive.Checked=model.IsActive;
		this.txtSpiderType.Text=model.SpiderType.ToString();
		this.txtPageCount.Text=model.PageCount.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtSpiderName.Text.Trim().Length==0)
			{
				strErr+="SpiderName不能为空！\\n";	
			}
			if(this.txtSpiderUrl.Text.Trim().Length==0)
			{
				strErr+="SpiderUrl不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCreateTime.Text))
			{
				strErr+="CreateTime格式错误！\\n";	
			}
			if(this.txtEncodeType.Text.Trim().Length==0)
			{
				strErr+="EncodeType不能为空！\\n";	
			}
			if(this.txtListExpression.Text.Trim().Length==0)
			{
				strErr+="ListExpression不能为空！\\n";	
			}
			if(this.txtDetailExpression.Text.Trim().Length==0)
			{
				strErr+="DetailExpression不能为空！\\n";	
			}
			if(this.txtSpiderUrlPrefix.Text.Trim().Length==0)
			{
				strErr+="SpiderUrlPrefix不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtDistrictId.Text))
			{
				strErr+="DistrictId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtCityId.Text))
			{
				strErr+="CityId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtProvinceId.Text))
			{
				strErr+="ProvinceId格式错误！\\n";	
			}
			if(this.txtTitleExpression.Text.Trim().Length==0)
			{
				strErr+="TitleExpression不能为空！\\n";	
			}
			if(this.txtPublishExpression.Text.Trim().Length==0)
			{
				strErr+="PublishExpression不能为空！\\n";	
			}
			if(this.txtContentExpression.Text.Trim().Length==0)
			{
				strErr+="ContentExpression不能为空！\\n";	
			}
			if(this.txtSourceExpression.Text.Trim().Length==0)
			{
				strErr+="SourceExpression不能为空！\\n";	
			}
			if(this.txtFilenameExpressoin.Text.Trim().Length==0)
			{
				strErr+="FilenameExpressoin不能为空！\\n";	
			}
			if(this.txtBidType.Text.Trim().Length==0)
			{
				strErr+="BidType不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtStatus.Text))
			{
				strErr+="Status格式错误！\\n";	
			}
			if(this.txtHttpMethod.Text.Trim().Length==0)
			{
				strErr+="HttpMethod不能为空！\\n";	
			}
			if(this.txtPageParameter.Text.Trim().Length==0)
			{
				strErr+="PageParameter不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtSpiderType.Text))
			{
				strErr+="SpiderType格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtPageCount.Text))
			{
				strErr+="PageCount格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			long SpiderId=long.Parse(this.lblSpiderId.Text);
			string SpiderName=this.txtSpiderName.Text;
			string SpiderUrl=this.txtSpiderUrl.Text;
			DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);
			string EncodeType=this.txtEncodeType.Text;
			string ListExpression=this.txtListExpression.Text;
			string DetailExpression=this.txtDetailExpression.Text;
			string SpiderUrlPrefix=this.txtSpiderUrlPrefix.Text;
			int DistrictId=int.Parse(this.txtDistrictId.Text);
			int CityId=int.Parse(this.txtCityId.Text);
			int ProvinceId=int.Parse(this.txtProvinceId.Text);
			string TitleExpression=this.txtTitleExpression.Text;
			string PublishExpression=this.txtPublishExpression.Text;
			string ContentExpression=this.txtContentExpression.Text;
			string SourceExpression=this.txtSourceExpression.Text;
			string FilenameExpressoin=this.txtFilenameExpressoin.Text;
			string BidType=this.txtBidType.Text;
			int Status=int.Parse(this.txtStatus.Text);
			string HttpMethod=this.txtHttpMethod.Text;
			string PageParameter=this.txtPageParameter.Text;
			bool IsActive=this.chkIsActive.Checked;
			int SpiderType=int.Parse(this.txtSpiderType.Text);
			int PageCount=int.Parse(this.txtPageCount.Text);


			GoBiding.Model.Spiders model=new GoBiding.Model.Spiders();
			model.SpiderId=SpiderId;
			model.SpiderName=SpiderName;
			model.SpiderUrl=SpiderUrl;
			model.CreateTime=CreateTime;
			model.EncodeType=EncodeType;
			model.ListExpression=ListExpression;
			model.DetailExpression=DetailExpression;
			model.SpiderUrlPrefix=SpiderUrlPrefix;
			model.DistrictId=DistrictId;
			model.CityId=CityId;
			model.ProvinceId=ProvinceId;
			model.TitleExpression=TitleExpression;
			model.PublishExpression=PublishExpression;
			model.ContentExpression=ContentExpression;
			model.SourceExpression=SourceExpression;
			model.FilenameExpressoin=FilenameExpressoin;
			model.BidType=BidType;
			model.Status=Status;
			model.HttpMethod=HttpMethod;
			model.PageParameter=PageParameter;
			model.IsActive=IsActive;
			model.SpiderType=SpiderType;
			model.PageCount=PageCount;

			GoBiding.BLL.Spiders bll=new GoBiding.BLL.Spiders();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
