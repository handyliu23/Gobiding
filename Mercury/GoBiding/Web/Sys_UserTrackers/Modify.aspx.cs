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
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					int UserTrackerId=(Convert.ToInt32(Request.Params["id"]));
					ShowInfo(UserTrackerId);
				}
			}
		}
			
	private void ShowInfo(int UserTrackerId)
	{
		GoBiding.BLL.Sys_UserTrackers bll=new GoBiding.BLL.Sys_UserTrackers();
		GoBiding.Model.Sys_UserTrackers model=bll.GetModel(UserTrackerId);
		this.lblUserTrackerId.Text=model.UserTrackerId.ToString();
		this.txtTrackerName.Text=model.TrackerName;
		this.txtTrackerCityIds.Text=model.TrackerCityIds;
		this.txtTrackerIndustryIds.Text=model.TrackerIndustryIds;
		this.txtCreateTime.Text=model.CreateTime.ToString();
		this.txtKeyword1.Text=model.Keyword1;
		this.txtKeyword2.Text=model.Keyword2;
		this.txtKeyword3.Text=model.Keyword3;
		this.txtKeyword4.Text=model.Keyword4;
		this.txtKeyword5.Text=model.Keyword5;
		this.txtSys_UserId.Text=model.Sys_UserId.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
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
			int UserTrackerId=int.Parse(this.lblUserTrackerId.Text);
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
			model.UserTrackerId=UserTrackerId;
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
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
