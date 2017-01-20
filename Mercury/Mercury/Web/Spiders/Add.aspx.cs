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
			string SpiderName=this.txtSpiderName.Text;
			string SpiderUrl=this.txtSpiderUrl.Text;
			DateTime CreateTime=DateTime.Parse(this.txtCreateTime.Text);

			Mercury.Model.Spiders model=new Mercury.Model.Spiders();
			model.SpiderName=SpiderName;
			model.SpiderUrl=SpiderUrl;
			model.CreateTime=CreateTime;

			Mercury.BLL.Spiders bll=new Mercury.BLL.Spiders();
			bll.Add(model);
			Maticsoft.Common.MessageBox.ShowAndRedirect(this,"保存成功！","add.aspx");

		}


        public void btnCancle_Click(object sender, EventArgs e)
        {
            Response.Redirect("list.aspx");
        }
    }
}
