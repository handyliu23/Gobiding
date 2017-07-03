﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.BLL;
using System.Web.UI.HtmlControls;
using Maticsoft.DBUtility;

namespace GoBiding.Web.Province
{
    public partial class Index : System.Web.UI.Page
    {
        private List<GoBiding.Model.BidCategorys> categorys;

        public string provincename = "";
        public string CategoryName = "";
        public string CategoryEnglishName = "";
        public int CategoryId = 0;
        private string Id = "";

        string strTitle;
        string strSeoKey;
        string strSeoDescription;

        public string GetCityName(string cityId)
        {
            var model = new BLL.Citys().GetModel(int.Parse(cityId));
            if (model != null)
                return model.CityName;

            return "";
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                categorys = new BLL.BidCategorys().GetModelList("");

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
            ltrProvinceName.Text = provincename;
            ltrProvinceName2.Text = provincename;

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

            int pageindex = 1;
            if (Request.QueryString["page"] != null)
            {
                pageindex = int.Parse(Request.QueryString["page"]);
            }

            string where = " and provinceId = " + Id;
            string sql = string.Format(@"
SELECT TOP {0} BidId,BidTitle,BidPublishTime,BidCompanyName,ProvinceId,BidCategoryId,BidType,CityId
FROM 
(
SELECT ROW_NUMBER() OVER (ORDER BY BidPublishTime desc) AS RowNumber,BidId,BidTitle,BidPublishTime,BidCompanyName,ProvinceId,BidCategoryId,BidType,CityId
FROM Bids Where 1=1 {2}
) A
WHERE RowNumber > {0}*({1} - 1)
", AspNetPager1.PageSize, pageindex, where);

            string sqlCount = "SELECT count(*) FROM Bids Where 1=1 " + where;

            var ds = DbHelperSQL.Query(sql);
            rptBidList.DataSource = ds;
            rptBidList.DataBind();

            var dsCount = DbHelperSQL.Query(sqlCount);
            AspNetPager1.RecordCount = int.Parse(dsCount.Tables[0].Rows[0][0].ToString());
            

            ds = new BLL.Citys().GetList(20, " ProvinceId = " + Id, " CityID");

            ddlCitys.DataTextField = "CityName";
            ddlCitys.DataValueField = "CityID";
            ddlCitys.DataSource = ds;
            ddlCitys.DataBind();

            rptBidInviteList.DataSource = ds;
            rptBidInviteList.DataBind();

        }

        public string GetBidCategoryNameValue(string categoryId)
        {
            if (!string.IsNullOrEmpty(categoryId))
            {
                var c = categorys.Where(o => o.BidCategoryId == int.Parse(categoryId)).FirstOrDefault();
                if (c == null)
                    return "其他";

                return c.BidCategoryName;
            }
            else
            {
                return "其他";
            }

        }

        public void InitForCityId()
        {
            provincename = CommonUtility.GetCityName(Id);

            if (string.IsNullOrEmpty(provincename))
                return;

            var ds = new BLL.Bids().GetList(10, " CityId = " + Id + " and bidtype = 1", "BidPublishTime desc");
            rptBidList.DataSource = ds;
            rptBidList.DataBind();

            ds = new BLL.Bids().GetList(10, " CityId = " + Id + " and bidtype = 6", "BidPublishTime desc");
            rptBidInviteList.DataSource = ds;
            rptBidInviteList.DataBind();

        }
    }
}