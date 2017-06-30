using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web
{
    public partial class BidLaws : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            int NewsId = 1;
            if(Request.QueryString["NewsId"] != null)
            {
                NewsId = int.Parse(Request.QueryString["NewsId"].ToString());
            }
            var bidModel = new BLL.DynamicNews().GetModel(NewsId);

            lblTitle.Text = bidModel.NewsTitle;
            lblTitle2.Text = bidModel.NewsTitle;
            this.ltrContent.Text = bidModel.Content;

            this.rptLawsList.DataSource = new BLL.DynamicNews().GetList(" DynamicNewsTypeId = 1");
            this.rptLawsList.DataBind();

        }
    }
}