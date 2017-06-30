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
namespace GoBiding.Web.Districts
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					long DistrictID=(Convert.ToInt64(Request.Params["id"]));
					ShowInfo(DistrictID);
				}
			}
		}
			
	private void ShowInfo(long DistrictID)
	{
		GoBiding.BLL.Districts bll=new GoBiding.BLL.Districts();
		GoBiding.Model.Districts model=bll.GetModel(DistrictID);
		this.lblDistrictID.Text=model.DistrictID.ToString();
		this.txtDistrictName.Text=model.DistrictName;
		this.txtCityID.Text=model.CityID.ToString();
		this.txtDateCreated.Text=model.DateCreated.ToString();
		this.txtDateUpdated.Text=model.DateUpdated.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtDistrictName.Text.Trim().Length==0)
			{
				strErr+="DistrictName不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtCityID.Text))
			{
				strErr+="CityID格式错误！\\n";	
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
			long DistrictID=long.Parse(this.lblDistrictID.Text);
			string DistrictName=this.txtDistrictName.Text;
			long CityID=long.Parse(this.txtCityID.Text);
			DateTime DateCreated=DateTime.Parse(this.txtDateCreated.Text);
			DateTime DateUpdated=DateTime.Parse(this.txtDateUpdated.Text);


			GoBiding.Model.Districts model=new GoBiding.Model.Districts();
			model.DistrictID=DistrictID;
			model.DistrictName=DistrictName;
			model.CityID=CityID;
			model.DateCreated=DateCreated;
			model.DateUpdated=DateUpdated;

			GoBiding.BLL.Districts bll=new GoBiding.BLL.Districts();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
