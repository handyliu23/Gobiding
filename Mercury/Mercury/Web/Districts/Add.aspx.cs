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
namespace Mercury.Web.Districts
{
    public partial class Add : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                       
        }

        		protected void btnSave_Click(object sender, EventArgs e)
		{
			
			string strErr="";
			if(this.txtDistrictName.Text.Trim().Length==0)
			{
				strErr+="DistrictName不能为空！\\n";	
			}
			if(this.txtCityID.Text.Trim().Length==0)
			{
				strErr+="CityID不能为空！\\n";	
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
			string DistrictName=this.txtDistrictName.Text;
			string CityID=this.txtCityID.Text;
			DateTime DateCreated=DateTime.Parse(this.txtDateCreated.Text);
			DateTime DateUpdated=DateTime.Parse(this.txtDateUpdated.Text);

			Mercury.Model.Districts model=new Mercury.Model.Districts();
			model.DistrictName=DistrictName;
			model.CityID=CityID;
			model.DateCreated=DateCreated;
			model.DateUpdated=DateUpdated;

			Mercury.BLL.Districts bll=new Mercury.BLL.Districts();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
