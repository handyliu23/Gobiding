using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GoBiding.Web
{
    public partial class NewsEdit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
        }

        public void Bind()
        {
            int NewsId = int.Parse(Request.QueryString["NewsId"].ToString());
            var bidModel = new BLL.DynamicNews().GetModel(NewsId);

            this.txtTitle.Text = bidModel.NewsTitle;
            this.ckDetailContent.Text = bidModel.Content;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int NewsId = int.Parse(Request.QueryString["NewsId"].ToString());
            var bidModel = new BLL.DynamicNews().GetModel(NewsId);

            bidModel.NewsTitle = this.txtTitle.Text;
            bidModel.Content = this.ckDetailContent.Text;
            new BLL.DynamicNews().Update(bidModel);

            Bind();

        }
    }
}