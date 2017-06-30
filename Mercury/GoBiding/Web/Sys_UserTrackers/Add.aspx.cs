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
namespace GoBiding.Web.Sys_UserTrackers
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtTrackerName.Text.Trim().Length==0)
			{
				strErr+="TrackerName不能为空！\\n";	
			}
			if(this.txtTrackerCityIds.Text.Trim().Length==0)
			{
				strErr+="TrackerCityIds不能为空！\\n";	
			}
			if(this.txtTrackerIndustryIds.Text.Trim().Length==0)
			{
				strErr+="TrackerIndustryIds不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtCreateTime.Text))
			{
				strErr+="CreateTime格式错误！\\n";	
			}
			if(this.txtKeyword1.Text.Trim().Length==0)
			{
				strErr+="Keyword1不能为空！\\n";	
			}
			if(this.txtKeyword2.Text.Trim().Length==0)
			{
				strErr+="Keyword2不能为空！\\n";	
			}
			if(this.txtKeyword3.Text.Trim().Length==0)
			{
				strErr+="Keyword3不能为空！\\n";	
			}
			if(this.txtKeyword4.Text.Trim().Length==0)
			{
				strErr+="Keyword4不能为空！\\n";	
			}
			if(this.txtKeyword5.Text.Trim().Length==0)
			{
				strErr+="Keyword5不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtSys_UserId.Text))
			{
				strErr+="Sys_UserId格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			string TrackerName=this.txtTrackerName.Text;
			string TrackerCityIds=this.txtTrackerCityIds.Text;
			string TrackerIndustryIds=this.txtTrackerIndustryIds.Text;
			DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);
			string Keyword1=this.txtKeyword1.Text;
			string Keyword2=this.txtKeyword2.Text;
			string Keyword3=this.txtKeyword3.Text;
			string Keyword4=this.txtKeyword4.Text;
			string Keyword5=this.txtKeyword5.Text;
			int Sys_UserId=int.Parse(this.txtSys_UserId.Text);

			GoBiding.Model.Sys_UserTrackers model=new GoBiding.Model.Sys_UserTrackers();
			model.TrackerName=TrackerName;
			model.TrackerCityIds=TrackerCityIds;
			model.TrackerIndustryIds=TrackerIndustryIds;
			model.CreateTime=CreateTime;
			model.Keyword1=Keyword1;
			model.Keyword2=Keyword2;
			model.Keyword3=Keyword3;
			model.Keyword4=Keyword4;
			model.Keyword5=Keyword5;
			model.Sys_UserId=Sys_UserId;

			GoBiding.BLL.Sys_UserTrackers bll=new GoBiding.BLL.Sys_UserTrackers();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
