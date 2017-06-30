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
namespace GoBiding.Web.SmartCategorys
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int SmartCategoryId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(SmartCategoryId);
				}
			}
		}
			
	private void ShowInfo(int SmartCategoryId)
	{
		GoBiding.BLL.SmartCategorys bll=new GoBiding.BLL.SmartCategorys();
		GoBiding.Model.SmartCategorys model=bll.GetModel(SmartCategoryId);
		this.lblSmartCategoryId.Text=model.SmartCategoryId.ToString();
		this.txtKeywords.Text=model.Keywords;
		this.txtBidCategoryId.Text=model.BidCategoryId.ToString();
		this.txtBidCategoryName.Text=model.BidCategoryName;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtKeywords.Text.Trim().Length==0)
			{
				strErr+="Keywords不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtBidCategoryId.Text))
			{
				strErr+="BidCategoryId格式错误！\\n";	
			}
			if(this.txtBidCategoryName.Text.Trim().Length==0)
			{
				strErr+="BidCategoryName不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int SmartCategoryId=int.Parse(this.lblSmartCategoryId.Text);
			string Keywords=this.txtKeywords.Text;
			int BidCategoryId=int.Parse(this.txtBidCategoryId.Text);
			string BidCategoryName=this.txtBidCategoryName.Text;


			GoBiding.Model.SmartCategorys model=new GoBiding.Model.SmartCategorys();
			model.SmartCategoryId=SmartCategoryId;
			model.Keywords=Keywords;
			model.BidCategoryId=BidCategoryId;
			model.BidCategoryName=BidCategoryName;

			GoBiding.BLL.SmartCategorys bll=new GoBiding.BLL.SmartCategorys();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
