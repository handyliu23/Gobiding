using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.BLL;
using System.Web.UI.HtmlControls;

namespace GoBiding.Web.Province
{
    public partial class Index : System.Web.UI.Page
    {
        public string provincename = "";
        public string CategoryName = "";
        public string CategoryEnglishName = "";
        public int CategoryId = 0;
        private string Id = "";

        string strTitle;
        string strSeoKey;
        string strSeoDescription;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {
                Id = Request.QueryString["id"];
                string type = Request.QueryString["type"];

                if (string.IsNullOrEmpty(type) || type == "p")
                {
                    InitForProvinceId();
                }
                if (type == "c")
                {
                    InitForCityId();
                }
            }
        }

        public void InitForProvinceId()
        {
            provincename = CommonUtility.GetProvinceName(Id);

            if (string.IsNullOrEmpty(provincename))
                return;

            #region
            strTitle = provincename + "免费招标_" + provincename + "采购信息_" + provincename + "公开招标_" + provincename + "工程招标";
            strSeoKey = provincename + "免费招标_" + provincename + "采购信息_" + provincename + "公开招标_" + provincename + "工程招标";
            strSeoDescription = "去投标网_免费招标采购信息_" + provincename + "免费招标_" + provincename + "采购信息_" + provincename + "公开招标_" + provincename + "工程招标";

            Page.Title = strTitle;
            HtmlMeta desc = new HtmlMeta();
            desc.Name = "Description";
            desc.Content = strSeoDescription;
            Page.Header.Controls.Add(desc);

            HtmlMeta keywords = new HtmlMeta();
            keywords.Name = "keywords";
            keywords.Content = strSeoKey;
            Page.Header.Controls.Add(keywords);
            #endregion

            var ds = new BLL.Bids().GetList(10, " ProvinceId = " + Id + " and bidtype = 1", "BidPublishTime desc");
            rptBidList.DataSource = ds;
            rptBidList.DataBind();

            ds = new BLL.Bids().GetList(10, " ProvinceId = " + Id + " and bidtype = 3", "BidPublishTime desc");
            rptBidResultList.DataSource = ds;
            rptBidResultList.DataBind();

            ds = new BLL.Bids().GetList(10, " ProvinceId = " + Id + " and bidtype = 2", "BidPublishTime desc");
            rptBidChangeList.DataSource = ds;
            rptBidChangeList.DataBind();

            ds = new BLL.Bids().GetList(10, " ProvinceId = " + Id + " and bidtype = 5", "BidPublishTime desc");
            rptBidCancelList.DataSource = ds;
            rptBidCancelList.DataBind();

            ds = new BLL.Bids().GetList(10, " ProvinceId = " + Id + " and bidtype = 6", "BidPublishTime desc");
            rptBidInviteList.DataSource = ds;
            rptBidInviteList.DataBind();

            ds = new BLL.Bids().GetList(10, " ProvinceId = " + Id + " and bidtype = 8", "BidPublishTime desc");
            rptBidSingleList.DataSource = ds;
            rptBidSingleList.DataBind();

        }

        public void InitForCityId()
        {
            provincename = CommonUtility.GetCityName(Id);

            if (string.IsNullOrEmpty(provincename))
                return;

            var ds = new BLL.Bids().GetList(10, " CityId = " + Id + " and bidtype = 1", "BidPublishTime desc");
            rptBidList.DataSource = ds;
            rptBidList.DataBind();

            ds = new BLL.Bids().GetList(10, " CityId = " + Id + " and bidtype = 3", "BidPublishTime desc");
            rptBidResultList.DataSource = ds;
            rptBidResultList.DataBind();

            ds = new BLL.Bids().GetList(10, " CityId = " + Id + " and bidtype = 2", "BidPublishTime desc");
            rptBidChangeList.DataSource = ds;
            rptBidChangeList.DataBind();

            ds = new BLL.Bids().GetList(10, " CityId = " + Id + " and bidtype = 5", "BidPublishTime desc");
            rptBidCancelList.DataSource = ds;
            rptBidCancelList.DataBind();

            ds = new BLL.Bids().GetList(10, " CityId = " + Id + " and bidtype = 6", "BidPublishTime desc");
            rptBidInviteList.DataSource = ds;
            rptBidInviteList.DataBind();

            ds = new BLL.Bids().GetList(10, " CityId = " + Id + " and bidtype = 8", "BidPublishTime desc");
            rptBidSingleList.DataSource = ds;
            rptBidSingleList.DataBind();

        }
    }
}