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
namespace GoBiding.Web.Sys_UserFavouriteBids
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(!PageValidate.IsNumber(txtSys_UserFavouriteBidId.Text))
			{
				strErr+="Sys_UserFavouriteBidId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtUserId.Text))
			{
				strErr+="UserId格式错误！\\n";	
			}
			if(!PageValidate.IsNumber(txtBidId.Text))
			{
				strErr+="BidId格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCreateTime.Text))
			{
				strErr+="CreateTime格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			int Sys_UserFavouriteBidId=int.Parse(this.txtSys_UserFavouriteBidId.Text);
			int UserId=int.Parse(this.txtUserId.Text);
			int BidId=int.Parse(this.txtBidId.Text);
			DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);
			bool IsActive=this.chkIsActive.Checked;

			GoBiding.Model.Sys_UserFavouriteBids model=new GoBiding.Model.Sys_UserFavouriteBids();
			model.Sys_UserFavouriteBidId=Sys_UserFavouriteBidId;
			model.UserId=UserId;
			model.BidId=BidId;
			model.CreateTime=CreateTime;
			model.IsActive=IsActive;

			GoBiding.BLL.Sys_UserFavouriteBids bll=new GoBiding.BLL.Sys_UserFavouriteBids();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
