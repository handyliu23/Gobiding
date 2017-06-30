using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.BLL;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using Newtonsoft.Json;

namespace GoBiding.Web.wap
{
    public partial class Suggest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSessionId"] == null)
            {
                Response.Redirect("/wap/waplogin.aspx?redirecturl=" + "/wap/Suggest.aspx");
            }

            if (!IsPostBack)
            {
                Init();
            }
        }

        public void Init()
        {


        }

        protected void btnSuggest_Click(object sender, EventArgs e)
        {

            if (Session["UserSessionId"] == null)
            {
                Response.Redirect("/wap/waplogin.aspx?redirecturl=" + "/wap/Suggest.aspx");
            }

            BLL.Message msgBLL = new BLL.Message();
            Model.Message msgModel = new Model.Message();
            msgModel.IsRead = false;
            msgModel.Title = "用户建议";
            msgModel.Content = txtSuggest.Text;
            msgModel.ReceiverId = 7;
            msgModel.MessageType = 2;
            msgModel.MessageTime = DateTime.Now;
            msgModel.SenderId = int.Parse(Session["UserSessionId"].ToString());

            msgBLL.Add(msgModel);

            Response.Write("<script>alert('提交成功，去投标网会认真研究您的建议，2个工作日内给您答复！')</script>");
        }
    }
}