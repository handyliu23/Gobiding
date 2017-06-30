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
namespace GoBiding.Web.Sys_UsersBidHistorys
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					long UserBidsHistory=(Convert.ToInt64(Request.Params["id"]));
					ShowInfo(UserBidsHistory);
				}
			}
		}
			
	private void ShowInfo(long UserBidsHistory)
	{
		GoBiding.BLL.Sys_UsersBidHistorys bll=new GoBiding.BLL.Sys_UsersBidHistorys();
		GoBiding.Model.Sys_UsersBidHistorys model=bll.GetModel(UserBidsHistory);
		this.lblUserBidsHistory.Text=model.UserBidsHistory.ToString();
		this.txtUserId.Text=model.UserId.ToString();
		this.txtBidId.Text=model.BidId.ToString();
		this.txtCreateTime.Text=model.CreateTime.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
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
			long UserBidsHistory=long.Parse(this.lblUserBidsHistory.Text);
			int UserId=int.Parse(this.txtUserId.Text);
			int BidId=int.Parse(this.txtBidId.Text);
			DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);


			GoBiding.Model.Sys_UsersBidHistorys model=new GoBiding.Model.Sys_UsersBidHistorys();
			model.UserBidsHistory=UserBidsHistory;
			model.UserId=UserId;
			model.BidId=BidId;
			model.CreateTime=CreateTime;

			GoBiding.BLL.Sys_UsersBidHistorys bll=new GoBiding.BLL.Sys_UsersBidHistorys();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
