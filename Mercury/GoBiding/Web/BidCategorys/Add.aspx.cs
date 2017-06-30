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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string BidCategoryName=this.txtBidCategoryName.Text;
			int ParentCategoryId=int.Parse(this.txtParentCategoryId.Text);

			GoBiding.Model.BidCategorys model=new GoBiding.Model.BidCategorys();
			model.BidCategoryName=BidCategoryName;
			model.ParentCategoryId=ParentCategoryId;

			GoBiding.BLL.BidCategorys bll=new GoBiding.BLL.BidCategorys();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
