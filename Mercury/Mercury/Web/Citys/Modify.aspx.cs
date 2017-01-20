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
namespace Mercury.Web.Citys
{
    public partial class Modify : Page
    {       

        		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					long CityID=(Convert.ToInt64(Request.Params["id"]));
					ShowInfo(CityID);
				}
			}
		}
			
	private void ShowInfo(long CityID)
	{
		Mercury.BLL.Citys bll=new Mercury.BLL.Citys();
		Mercury.Model.Citys model=bll.GetModel(CityID);
		this.lblCityID.Text=model.CityID.ToString();
		this.txtCityName.Text=model.CityName;
		this.txtZipCode.Text=model.ZipCode;
		this.txtProvinceID.Text=model.ProvinceID.ToString();
		this.txtDateCreated.Text=model.DateCreated.ToString();
		this.txtDateUpdated.Text=model.DateUpdated.ToString();

	}

		public void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtCityName.Text.Trim().Length==0)
			{
				strErr+="CityName不能为空！\\n";	
			}
			if(this.txtZipCode.Text.Trim().Length==0)
			{
				strErr+="ZipCode不能为空！\\n";	
			}
			if(!PageValidate.IsNumber(txtProvinceID.Text))
			{
				strErr+="ProvinceID格式错误！\\n";	
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
			long CityID=long.Parse(this.lblCityID.Text);
			string CityName=this.txtCityName.Text;
			string ZipCode=this.txtZipCode.Text;
			long ProvinceID=long.Parse(this.txtProvinceID.Text);
			DateTime DateCreated=DateTime.Parse(this.txtDateCreated.Text);
			DateTime DateUpdated=DateTime.Parse(this.txtDateUpdated.Text);


			Mercury.Model.Citys model=new Mercury.Model.Citys();
			model.CityID=CityID;
			model.CityName=CityName;
			model.ZipCode=ZipCode;
			model.ProvinceID=ProvinceID;
			model.DateCreated=DateCreated;
			model.DateUpdated=DateUpdated;

			Mercury.BLL.Citys bll=new Mercury.BLL.Citys();
			bll.Update(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","list.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
