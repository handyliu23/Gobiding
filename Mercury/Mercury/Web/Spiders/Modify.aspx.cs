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
namespace Mercury.Web.Spiders
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
		Mercury.BLL.Spiders bll=new Mercury.BLL.Spiders();
		Mercury.Model.Spiders model=bll.GetModel(SpiderId);
		this.lblSpiderId.Text=model.SpiderId.ToString();
		this.txtSpiderName.Text=model.SpiderName;
		this.txtSpiderUrl.Text=model.SpiderUrl;
		this.txtCreateTime.Text=model.CreateTime.ToString();

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

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			long SpiderId=long.Parse(this.lblSpiderId.Text);
			string SpiderName=this.txtSpiderName.Text;
			string SpiderUrl=this.txtSpiderUrl.Text;
			DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);


			Mercury.Model.Spiders model=new Mercury.Model.Spiders();
			model.SpiderId=SpiderId;
			model.SpiderName=SpiderName;
			model.SpiderUrl=SpiderUrl;
			model.CreateTime=CreateTime;

			Mercury.BLL.Spiders bll=new Mercury.BLL.Spiders();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
