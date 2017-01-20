using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Mercury.Web
{
    public partial class BidList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitControl();
                Bind();
            }
        }

        public void InitControl()
        {
            DataSet spiderds = new BLL.Spiders().GetAllList();
            ddlSpiderNameList.DataSource = spiderds;
            ddlSpiderNameList.DataValueField = "SpiderName";
            ddlSpiderNameList.DataTextField = "SpiderName";
            ddlSpiderNameList.DataBind();
            ddlSpiderNameList.Items.Add(new ListItem("全部", "All"));
        }

        public void Bind()
        {
            string strWhere = "";
            if (ddlSpiderNameList.SelectedValue != "All")
            {
                strWhere = "BidSpiderName = '" + ddlSpiderNameList.SelectedValue + "'";
            }
            DataSet ds = new BLL.Bids().GetList(strWhere);
            dgBidList.DataSource = ds;
            dgBidList.DataBind();
        }

        protected void dgBidList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgBidList.PageIndex = e.NewPageIndex;
            Bind();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bind();
        }

    }
}