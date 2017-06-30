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
namespace GoBiding.Web.BidCategorys
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int BidCategoryId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(BidCategoryId);
				}
			}
		}
			
	private void ShowInfo(int BidCategoryId)
	{
		GoBiding.BLL.BidCategorys bll=new GoBiding.BLL.BidCategorys();
		GoBiding.Model.BidCategorys model=bll.GetModel(BidCategoryId);
		this.lblBidCategoryId.Text=model.BidCategoryId.ToString();
		this.txtBidCategoryName.Text=model.BidCategoryName;
		this.txtParentCategoryId.Text=model.ParentCategoryId.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtBidCategoryName.Text.Trim().Length==0)
			{
				strErr+="BidCategoryName不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtParentCategoryId.Text))
			{
				strErr+="ParentCategoryId格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int BidCategoryId=int.Parse(this.lblBidCategoryId.Text);
			string BidCategoryName=this.txtBidCategoryName.Text;
			int ParentCategoryId=int.Parse(this.txtParentCategoryId.Text);


			GoBiding.Model.BidCategorys model=new GoBiding.Model.BidCategorys();
			model.BidCategoryId=BidCategoryId;
			model.BidCategoryName=BidCategoryName;
			model.ParentCategoryId=ParentCategoryId;

			GoBiding.BLL.BidCategorys bll=new GoBiding.BLL.BidCategorys();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
