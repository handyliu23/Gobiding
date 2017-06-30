using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using GoBiding.BLL;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Web.UI.HtmlControls;

namespace GoBiding.Web
{
    public partial class HighSchoolBidList : System.Web.UI.Page
    {
        string strTitle;
        string strSeoKey;
        string strSeoDescription;

        public string biddescription = "";
        public string title = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Init();
                InitTop();
            }
        }
        public void InitTop()
        {
            string sql1 = "select COUNT(*) from Bids where BidCompanyName like '%华北理工大学%'";
            string sql2 = "select COUNT(*) from Bids where BidCompanyName like '%河北工业大学%'";
            string sql3 = "select COUNT(*) from Bids where BidCompanyName like '%福建农林大学%'";
            string sql4 = "select COUNT(*) from Bids where BidCompanyName like '%南昌大学%'";

            string sql = sql1 + sql2 + sql3 + sql4;

            DataSet ds = DbHelperSQL.Query(sql);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                lblhblgdx.Text = ds.Tables[0].Rows[0][0].ToString();
                lblhbgydx.Text = ds.Tables[1].Rows[0][0].ToString();
                lblfjnldx.Text = ds.Tables[2].Rows[0][0].ToString();
                lblncdx.Text = ds.Tables[3].Rows[0][0].ToString();
            }


        }

        public void Init()
        {
            if (Request.QueryString["cn"] == null)
                return;


            string companyIdString = Request.QueryString["cn"].ToString();
            if (string.IsNullOrEmpty(companyIdString))
            {
                return;
            }

            var companyId = int.Parse(companyIdString);

            var company = new BLL.CatchCompany().GetModel(companyId);

            #region
            strTitle = "免费招标信息_" + company.VendorName + "招标采购_去投标网_免费招标采购信息发布平台_手机招标采购";
            strSeoKey = company.VendorName + "_免费招标_采购信息_公开招标_工程招标_手机招标采购";
            strSeoDescription = "去投标网_免费招标采购信息_免费招标_采购信息_公开招标_工程招标_上海商麓网络科技有限公司官网";
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

            lblCompanyName.Text = company.VendorName;

            List<SqlParameter> _params = new List<SqlParameter>
                                             {
                                                 new SqlParameter("@pageIndex", AspNetPager1.CurrentPageIndex),
                                                 new SqlParameter("@pageSize", AspNetPager1.PageSize),
                                                 new SqlParameter("@BidCompanyName", company.VendorName),
                                             };
            List<Model.Bids> bidList = new List<Model.Bids>();

            using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetHighSchoolBidList", _params.ToArray()))
            //ExecuteReader返回的对象类型是SqlDataReader
            {
                while (reader.Read())
                {
                    var bid = new Model.Bids();
                    bid.BidId = reader.GetInt64(1);
                    bid.BidTitle = reader.GetString(2);
                    bid.BidNumber = reader.GetValue(3) == null ? "" : reader.GetValue(3).ToString();
                    bid.ProvinceId = reader.GetInt32(4);
                    bid.BidPublishTime = DateTime.Parse(reader.GetDateTime(5).ToString());
                    bid.BidType = reader.GetString(6);
                    bid.BidCompanyName = reader.GetValue(7).ToString();

                    bidList.Add(bid);
                }

                //var ds = new BLL.Bids().GetList(10, string.Format(" BidCompanyName like '%{0}%'", companyname), "BidPublishTime desc");
                rptBidList.DataSource = bidList;
                rptBidList.DataBind();
            }

            List<SqlParameter> _countparams = new List<SqlParameter>();
            _countparams.Add(new SqlParameter("@BidCompanyName", company.VendorName));
            int count = 0;
            using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetHighSchoolBidListCount", _countparams.ToArray()))//ExecuteReader返回的对象类型是SqlDataReader
            {
                while (reader.Read())
                {
                    count = reader.GetInt32(0);
                }
            }
            AspNetPager1.RecordCount = count;
            lblTotalCount.Text = count.ToString();
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            Init();
        }
    }
}