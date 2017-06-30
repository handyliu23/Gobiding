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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string Keywords=this.txtKeywords.Text;
			int BidCategoryId=int.Parse(this.txtBidCategoryId.Text);
			string BidCategoryName=this.txtBidCategoryName.Text;

			GoBiding.Model.SmartCategorys model=new GoBiding.Model.SmartCategorys();
			model.Keywords=Keywords;
			model.BidCategoryId=BidCategoryId;
			model.BidCategoryName=BidCategoryName;

			GoBiding.BLL.SmartCategorys bll=new GoBiding.BLL.SmartCategorys();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
