using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Web.Dtos;
using Maticsoft.DBUtility;

namespace GoBiding.Web
{
    public partial class BidCompanyList : System.Web.UI.Page
    {
        public string keywords = "";

        public void InitCompanylist()
        {
            List<Model.Bids> list = new List<Model.Bids>();

            List<SqlParameter> _params = new List<SqlParameter>
                                             {
                                                 new SqlParameter("@pageIndex", AspNetPager1.CurrentPageIndex),
                                                 new SqlParameter("@pageSize", AspNetPager1.PageSize)
                                             };
            var keyword = Request.QueryString["keyword"] == null ? "" : HttpUtility.UrlDecode(Request.QueryString["keyword"].ToString().Replace("'", ""));
            var area = Request.QueryString["area"] == null ? "" : Request.QueryString["area"].ToString();
            hdnbidarea.Value = area;
            keywords = keyword;
            hdnkeyword.Value = keyword;

            if (!string.IsNullOrEmpty(area) && area != "0")
            {
                _params.Add(new SqlParameter("@ProvinceId", area));
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                _params.Add(new SqlParameter("@keyword", keyword));
            }

            using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetBidCompanyList", _params.ToArray()))
            //ExecuteReader返回的对象类型是SqlDataReader
            {
                while (reader.Read())
                {
                    var bid = new Model.Bids();
                    bid.BidCompanyName = reader.GetValue(1).ToString();
                    bid.ProvinceId = int.Parse(reader.GetValue(2).ToString());
                    bid.CreateTime = DateTime.Parse(reader.GetValue(3).ToString());
                    
                    list.Add(bid);
                }
            }
            rptCompanyList.DataSource = list;
            rptCompanyList.DataBind();

            string sql = string.Format(@"
SELECT count(*) from CatchCompany where OnCreated > '2016-12-1' and isbidagent = 1");
            if(!string.IsNullOrEmpty(keyword))
            {
                sql += string.Format(" and VendorName like '%{0}%'", keyword);
            }
            if (!string.IsNullOrEmpty(area) && area != "0")
            {
                sql += string.Format(" and ProvinceId = {0}", area);
            }
            int totalcount = 0;
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql))
            //ExecuteReader返回的对象类型是SqlDataReader
            {
                while (reader.Read())
                {
                    totalcount = reader.GetInt32(0);
                }
            }

            this.AspNetPager1.RecordCount = totalcount;
            lblTotalCount.Text = totalcount.ToString();

        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                InitCompanylist();

                List<Model.Bids> list = new List<Model.Bids>();

                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(@"
DECLARE @tb1 Table
(
BidId bigint,
BidCompanyName varchar(20)
)
SELECT distinct(bidcompanyname),BidId into #@tb1 FROM Bids
where BidCompanyName <>''
order by BidId desc
select top 8 * from #@tb1 order by BidId desc
", null))
                //ExecuteReader返回的对象类型是SqlDataReader
                {
                    while (reader.Read())
                    {
                        var bid = new Model.Bids();
                        bid.BidCompanyName = reader.GetValue(0).ToString();
                        list.Add(bid);
                    }
                }

                rptLatestCompanyList.DataSource = list;
                rptLatestCompanyList.DataBind();

                List<Model.Bids> list2 = new List<Model.Bids>();

                string sql = "select top 8 count(BidCompanyName),BidCompanyName from Bids where BidCompanyName <> '' group by BidCompanyName order by 1 desc";
                using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql, null))
                //ExecuteReader返回的对象类型是SqlDataReader
                {
                    while (reader.Read())
                    {
                        var bid = new Model.Bids();
                        bid.BidCompanyName = reader.GetValue(1).ToString();
                        list2.Add(bid);
                    }
                }
                rptHotCompanyList.DataSource = list2;
                rptHotCompanyList.DataBind();

                var ds = new BLL.Sys_Users().GetList(8, "UserLoginType = 3", " Sys_UserId desc");
                rptProfessionalCompanyList.DataSource = ds;
                rptProfessionalCompanyList.DataBind();
            }
        }
    }
}