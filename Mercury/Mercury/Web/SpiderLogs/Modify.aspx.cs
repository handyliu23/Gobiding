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
namespace Mercury.Web.SpiderLogs
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					long SpiderLogId=(Convert.ToInt64(Request.Params["id"]));
					ShowInfo(SpiderLogId);
				}
			}
		}
			
	private void ShowInfo(long SpiderLogId)
	{
		Mercury.BLL.SpiderLogs bll=new Mercury.BLL.SpiderLogs();
		Mercury.Model.SpiderLogs model=bll.GetModel(SpiderLogId);
		this.lblSpiderLogId.Text=model.SpiderLogId.ToString();
		this.txtSpiderName.Text=model.SpiderName;
		this.txtSpiderLog.Text=model.SpiderLog;
		this.chkIsSuccess.Checked=model.IsSuccess;
		this.txtMessage.Text=model.Message;

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtSpiderName.Text.Trim().Length==0)
			{
				strErr+="SpiderName不能为空！\\n";	
			}
			if(this.txtSpiderLog.Text.Trim().Length==0)
			{
				strErr+="SpiderLog不能为空！\\n";	
			}
			if(this.txtMessage.Text.Trim().Length==0)
			{
				strErr+="Message不能为空！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			long SpiderLogId=long.Parse(this.lblSpiderLogId.Text);
			string SpiderName=this.txtSpiderName.Text;
			string SpiderLog=this.txtSpiderLog.Text;
			bool IsSuccess=this.chkIsSuccess.Checked;
			string Message=this.txtMessage.Text;


			Mercury.Model.SpiderLogs model=new Mercury.Model.SpiderLogs();
			model.SpiderLogId=SpiderLogId;
			model.SpiderName=SpiderName;
			model.SpiderLog=SpiderLog;
			model.IsSuccess=IsSuccess;
			model.Message=Message;

			Mercury.BLL.SpiderLogs bll=new Mercury.BLL.SpiderLogs();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
