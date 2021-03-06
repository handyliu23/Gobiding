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
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
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
			string SpiderName=this.txtSpiderName.Text;
			string SpiderLog=this.txtSpiderLog.Text;
			bool IsSuccess=this.chkIsSuccess.Checked;
			string Message=this.txtMessage.Text;

			Mercury.Model.SpiderLogs model=new Mercury.Model.SpiderLogs();
			model.SpiderName=SpiderName;
			model.SpiderLog=SpiderLog;
			model.IsSuccess=IsSuccess;
			model.Message=Message;

			Mercury.BLL.SpiderLogs bll=new Mercury.BLL.SpiderLogs();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
