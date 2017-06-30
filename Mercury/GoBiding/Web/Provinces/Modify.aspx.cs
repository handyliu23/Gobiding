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
namespace GoBiding.Web.Provinces
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					long ProvinceID=(Convert.ToInt64(Request.Params["id"]));
					ShowInfo(ProvinceID);
				}
			}
		}
			
	private void ShowInfo(long ProvinceID)
	{
		GoBiding.BLL.Provinces bll=new GoBiding.BLL.Provinces();
		GoBiding.Model.Provinces model=bll.GetModel(ProvinceID);
		this.lblProvinceID.Text=model.ProvinceID.ToString();
		this.txtProvinceName.Text=model.ProvinceName;
		this.txtDateCreated.Text=model.DateCreated.ToString();
		this.txtDateUpdated.Text=model.DateUpdated.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtProvinceName.Text.Trim().Length==0)
			{
				strErr+="ProvinceName不能为空！\\n";	
			}
			if(!PageValidate.IsDateTime(txtDateCreated.Text))
			{
				strErr+="DateCreated格式错误！\\n";	
			}
			if(!PageValidate.IsDateTime(txtDateUpdated.Text))
			{
				strErr+="DateUpdated格式错误！\\n";	
			}

			if(strErr!="")
			{
				MessageBox.Show(this,strErr);
				return;
			}
			long ProvinceID=long.Parse(this.lblProvinceID.Text);
			string ProvinceName=this.txtProvinceName.Text;
			DateTime DateCreated=DateTime.Parse(this.txtDateCreated.Text);
			DateTime DateUpdated=DateTime.Parse(this.txtDateUpdated.Text);


			GoBiding.Model.Provinces model=new GoBiding.Model.Provinces();
			model.ProvinceID=ProvinceID;
			model.ProvinceName=ProvinceName;
			model.DateCreated=DateCreated;
			model.DateUpdated=DateUpdated;

			GoBiding.BLL.Provinces bll=new GoBiding.BLL.Provinces();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
