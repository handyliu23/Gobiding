using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mercury.Web
{
    public partial class BidDetailEdit : System.Web.UI.Page
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
            int bId = int.Parse(Request.QueryString["BId"].ToString());
            var bidModel = new BLL.Bids().GetModel(bId);

            this.txtTitle.Text = bidModel.BidTitle;
            this.ckDetailContent.Text = bidModel.BidContent;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            int bId = int.Parse(Request.QueryString["BId"].ToString());
            var bidModel = new BLL.Bids().GetModel(bId);

            bidModel.BidTitle = this.txtTitle.Text;
            bidModel.BidContent = this.ckDetailContent.Text;
            new BLL.Bids().Update(bidModel);

            Bind();
        }
    }
}