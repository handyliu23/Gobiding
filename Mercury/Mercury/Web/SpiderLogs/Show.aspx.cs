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
namespace Mercury.Web.SpiderLogs
{
    public partial class Show : Page
    {        
        		public string strid=""; 
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!Page.IsPostBack)
			{
				if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
				{
					strid = Request.Params["id"];
					long SpiderLogId=(Convert.ToInt64(strid));
					ShowInfo(SpiderLogId);
				}
			}
		}
		
	private void ShowInfo(long SpiderLogId)
	{
		Mercury.BLL.SpiderLogs bll=new Mercury.BLL.SpiderLogs();
		Mercury.Model.SpiderLogs model=bll.GetModel(SpiderLogId);
		this.lblSpiderLogId.Text=model.SpiderLogId.ToString();
		this.lblSpiderName.Text=model.SpiderName;
		this.lblSpiderLog.Text=model.SpiderLog;
		this.lblIsSuccess.Text=model.IsSuccess?"是":"否";
		this.lblMessage.Text=model.Message;

	}


    }
}
