using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Model;
using System.Data;
using GoBiding.BLL;
using Maticsoft.DBUtility;

namespace GoBiding.Web
{
    public partial class BidList : System.Web.UI.Page
    {
        public string keywords = "";
        private string keyword = "";
        private List<GoBiding.Model.BidCategorys> categorys;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    keyword = Request.QueryString["keyword"] == null ? "" : Request.QueryString["keyword"].ToString().Replace("'", "");
                    if (!string.IsNullOrEmpty(keyword))
                    {
                        Model.Keyword keywordPO = new Model.Keyword();
                        keywordPO.CategoryId = 0;
                        keywordPO.Name = keyword;
                        keywordPO.SearchTime = DateTime.Now;
                        new BLL.Keyword().Add(keywordPO);
                    }

                    Init();
                }
                catch (Exception err)
                {
                    Logger.Warn(err.Message, err.StackTrace);
                }
            }

        }

        public void Init()
        {
            int pageindex = 1;
            if (Request.QueryString["page"] != null)
            {
                pageindex = int.Parse(Request.QueryString["page"]);
            }

            if (pageindex > 15)
            {
                rptBidList.Visible = false;
                AspNetPager1.Visible = false;
                return;
            }

            var area = Request.QueryString["area"] == null ? "" : Request.QueryString["area"].ToString();
            var industry = Request.QueryString["industry"] == null ? "" : Request.QueryString["industry"].ToString();
            var subindustry = Request.QueryString["subindustry"] == null ? "" : Request.QueryString["subindustry"].ToString();
            var bidtype = Request.QueryString["bidtype"] == null ? "" : Request.QueryString["bidtype"].ToString();
            var bidtime = Request.QueryString["bidtime"] == null ? "" : Request.QueryString["bidtime"].ToString();

            hdnbidarea.Value = area;
            hdnbidindustry.Value = industry;
            hdnsubindustry.Value = subindustry;
            hdnbidtime.Value = bidtime;
            hdnbidtype.Value = bidtype;
            hdnkeyword.Value = keyword;
            keywords = keyword;

            List<SqlParameter> _params = new List<SqlParameter>
                                             {
                                                 new SqlParameter("@pageindex", AspNetPager1.CurrentPageIndex),
                                                 new SqlParameter("@pagesize", AspNetPager1.PageSize)
                                             };

            if (!string.IsNullOrEmpty(area) && area != "0")
            {
                _params.Add(new SqlParameter("@ProvinceId", area));
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                _params.Add(new SqlParameter("@Keyword", keyword));
            }
            if (!string.IsNullOrEmpty(bidtype) && bidtype != "0")
            {
                _params.Add(new SqlParameter("@BidType", bidtype));
            }
            if (!string.IsNullOrEmpty(industry) && industry != "0")
            {
                if (!string.IsNullOrEmpty(subindustry) && subindustry != "0")
                {
                    industry = subindustry; //指定了二级类
                }
                _params.Add(new SqlParameter("@BidCategoryId", industry));
            }
            if (!string.IsNullOrEmpty(bidtime) && bidtime != "0")
            {
                DateTime earlytime = GetEarlyTime(bidtime);
                _params.Add(new SqlParameter("@BidCreateTimeStart", earlytime));
            }
            List<Model.Bids> bidList = new List<Model.Bids>();

            if (!string.IsNullOrEmpty(keyword))
            {

                if (keyword.Contains(" ") || keyword.Contains(","))
                {
                    using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetSearchForBidsListByFreetext", _params.ToArray()))
                    //ExecuteReader返回的对象类型是SqlDataReader
                    {
                        while (reader.Read())
                        {
                            var bid = new Model.Bids();
                            bid.BidId = reader.GetInt64(1);
                            bid.BidTitle = reader.GetString(2);
                            bid.BidNumber = reader.GetValue(7) == null ? "" : reader.GetValue(7).ToString();
                            bid.ProvinceId = reader.GetInt32(6);
                            bid.BidPublishTime = DateTime.Parse(reader.GetDateTime(3).ToString());
                            bid.BidType = reader.GetString(22);
                            bid.BidContent = CommonUtility.GetChineseCh(reader.GetString(4));
                            bid.BidCompanyName = reader.GetValue(27).ToString();
                            bid.CreateTime = DateTime.Parse(reader.GetDateTime(20).ToString());
                            bid.BidCategoryId = reader["BidCategoryId"].ToString() != "" ? Convert.ToInt32(reader["BidCategoryId"].ToString()) : 0;

                            bidList.Add(bid);
                        }
                    }
                }
                else
                {
                    using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetSearchForBidsList", _params.ToArray()))
                    //ExecuteReader返回的对象类型是SqlDataReader
                    {
                        while (reader.Read())
                        {
                            var bid = new Model.Bids();
                            bid.BidId = reader.GetInt64(1);
                            bid.BidTitle = reader.GetString(2);
                            bid.BidNumber = reader.GetValue(7) == null ? "" : reader.GetValue(7).ToString();
                            bid.ProvinceId = reader.GetInt32(6);
                            bid.BidPublishTime = DateTime.Parse(reader.GetDateTime(3).ToString());
                            bid.BidType = reader.GetString(22);
                            bid.BidContent = CommonUtility.GetChineseCh(reader.GetString(4));
                            bid.BidCompanyName = reader.GetValue(27).ToString();
                            bid.CreateTime = DateTime.Parse(reader.GetDateTime(20).ToString());
                            bid.BidCategoryId = reader["BidCategoryId"].ToString() != "" ? Convert.ToInt32(reader["BidCategoryId"].ToString()) : 0;

                            bidList.Add(bid);
                        }
                    }
                }

                #region 计算总数
                List<SqlParameter> _countparams = new List<SqlParameter> { 
                new SqlParameter("@pageIndex", AspNetPager1.CurrentPageIndex),
                new SqlParameter("@pageSize", AspNetPager1.PageSize)
                    };

                if (!string.IsNullOrEmpty(area) && area != "0")
                {
                    _countparams.Add(new SqlParameter("@ProvinceId", area));
                }
                if (!string.IsNullOrEmpty(keyword))
                {
                    _countparams.Add(new SqlParameter("@Keyword", keyword));
                }
                if (!string.IsNullOrEmpty(bidtype) && bidtype != "0")
                {
                    _countparams.Add(new SqlParameter("@BidType", bidtype));
                }
                if (!string.IsNullOrEmpty(industry) && industry != "0")
                {
                    _countparams.Add(new SqlParameter("@BidCategoryId", industry));
                }
                if (!string.IsNullOrEmpty(bidtime) && bidtime != "0")
                {
                    DateTime earlytime = GetEarlyTime(bidtime);
                    _countparams.Add(new SqlParameter("@BidCreateTimeStart", earlytime));
                }

                _countparams.Add(new SqlParameter("@docount", 1));
                int count = 0;
                using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetSearchForBidsListByFreetext", _countparams.ToArray()))//ExecuteReader返回的对象类型是SqlDataReader
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }
                AspNetPager1.RecordCount = count;
                lblTotalCount.Text = count.ToString();

                #endregion
            }
            else
            {
                using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetUserBidsList", _params.ToArray()))
                {
                    while (reader.Read())
                    {
                        var bid = new Model.Bids();
                        bid.BidId = reader.GetInt64(1);
                        bid.BidTitle = reader.GetString(2);
                        bid.BidNumber = reader.GetValue(7) == null ? "" : reader.GetValue(7).ToString();
                        bid.ProvinceId = reader.GetInt32(6);
                        bid.BidPublishTime = DateTime.Parse(reader.GetDateTime(3).ToString());
                        bid.BidType = reader.GetString(22);
                        bid.BidContent = CommonUtility.GetChineseCh(reader.GetString(4));
                        bid.BidCompanyName = reader.GetValue(27).ToString();
                        bid.CreateTime = DateTime.Parse(reader.GetDateTime(20).ToString());
                        bid.BidCategoryId = reader["BidCategoryId"].ToString() != "" ? Convert.ToInt32(reader["BidCategoryId"].ToString()) : 0;

                        bidList.Add(bid);
                    }
                }

                List<SqlParameter> _countparams = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(area) && area != "0")
                {
                    _countparams.Add(new SqlParameter("@ProvinceId", area));
                }
                if (!string.IsNullOrEmpty(bidtype) && bidtype != "0")
                {
                    _countparams.Add(new SqlParameter("@BidType", bidtype));
                }
                if (!string.IsNullOrEmpty(industry) && industry != "0")
                {
                    _countparams.Add(new SqlParameter("@BidCategoryId", industry));
                }
                if (!string.IsNullOrEmpty(bidtime) && bidtime != "0")
                {
                    DateTime earlytime = GetEarlyTime(bidtime);
                    _countparams.Add(new SqlParameter("@BidCreateTimeStart", earlytime));
                }
                int count = 0;

                using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetUserBidsCount", _countparams.ToArray()))//ExecuteReader返回的对象类型是SqlDataReader
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }
                AspNetPager1.RecordCount = count;
                lblTotalCount.Text = count.ToString();

            }

            List<string> cIdList = bidList.Select(o => (o.BidCategoryId ?? 0).ToString()).ToList();
            string categoryIdwhere = string.Join(",", cIdList);
            if(string.IsNullOrEmpty(categoryIdwhere))
                categorys = new BLL.BidCategorys().GetModelList("");
            else
                categorys = new BLL.BidCategorys().GetModelList(" BidCategoryId in ( " + categoryIdwhere + ")");

            rptBidList.DataSource = bidList;
            rptBidList.DataBind();

            if (bidList.Count > 0)
            {
                emptyDiv.Visible = false;
            }
            else {
                emptyDiv.Visible = true;
            }

            string sql2 = @"
select top 10 Sys_UserId, CompanyId,OnCreate, DistrictId, CompanyName, c.CityName from Sys_Users u
left join Citys c on u.DistrictId = c.CityID
where CompanyName <> '' and CompanyName like '%公司' order by u.OnCreate desc
";

            var ds = DbHelperSQL.Query(sql2);

            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                rptEmergencyPurchaseOrderList.DataSource = ds;
                rptEmergencyPurchaseOrderList.DataBind();
            }

            sql2 = "select top 8 count(BidCompanyName) as count,max(BidCompanyId) as BidCompanyId,BidCompanyName from Bids where BidCompanyName <> '' and BidCompanyName like '%公司' and bidcompanyname <> '详情见公告' and  bidcompanyname <> '无详细信息' group by BidCompanyName order by 1 desc";
            var ds2 = DbHelperSQL.Query(sql2);
         
            rptHotCompanyList.DataSource = ds2;
            rptHotCompanyList.DataBind();
        }

        public string GetHotLevel(string count)
        {
            int c = int.Parse(count);
            string one = "<img src=\"imgs/system/level.png\" width=\"20\"/>";
            string result = "";            
            if (c > 1000)
            {
                result += one;
                result += one;
                result += one;
                result += one;
                result += one;
            }
            else if (c > 500)
            {
                result += one;
                result += one;
                result += one;
                result += one;
            }
            else if (c > 200)
            {
                result += one;
                result += one;
                result += one;
            }
            else if (c > 100)
            {
                result += one;
                result += one;
            }
            else if (c > 10)
            {
                result += one;
            }

            return result;
        }

        public string HighlightKeyword(string source)
        {
            if (string.IsNullOrEmpty(keywords))
                return source;

            List<string> keys = keywords.Split(' ').ToList();
            if (keys != null && keys.Count > 0)
                keys.ForEach(o =>
                {
                    source = source.Replace(o, "<font style='color:red'>" + o + "</font>");
                });
            return source;
        }

        public DateTime GetEarlyTime(string bidtime)
        {
            switch (bidtime)
            {
                case "1":
                    return DateTime.Today;
                case "2":
                    return DateTime.Today.AddDays(-3);
                case "3":
                    return DateTime.Today.AddDays(-7);
                case "4":
                    return DateTime.Today.AddDays(-14);
                case "5":
                    return DateTime.Today.AddDays(-30);
            }

            return DateTime.Today;
        }

        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }

        public string GetProvinceName(string provinceId)
        {
            var model = new BLL.Provinces().GetModel(int.Parse(provinceId));
            if (model != null)
                return model.ProvinceName;

            return "";
        }

        public string GetDisplayPublishTime(string publishTime)
        {
            var diff = DateDiff(DateTime.Parse(publishTime), DateTime.Now);
            if (diff <= 5)
                return "5分钟前";
            else if (diff <= 10)
                return "10分钟前";
            else if (diff <= 30)
                return "30分钟前";
            else if (diff <= 60)
                return "1小时前";
            else if (diff <= 120)
                return "2小时前";
            else if (diff <= 360)
                return "6小时前";
            else if (diff <= 720)
                return "12小时前";
            else if (diff <= 1440)
                return "1天内";
            else if (diff <= 4320)
                return "3天内";
            else if (diff <= 10080)
                return "7天内";
            else 
                return "1周前";
            return "";
        }

        private static int DateDiff(DateTime dateStart, DateTime dateEnd)
        {
            TimeSpan sp = dateEnd.Subtract(dateStart);

            return (int)sp.TotalMinutes;
        }

        public string GetBidCategoryNameValue(string categoryId) {
            if (!string.IsNullOrEmpty(categoryId))
            {
                var c = categorys.Where(o => o.BidCategoryId == int.Parse(categoryId)).FirstOrDefault();
                if (c == null)
                    return "其他";

                return c.BidCategoryName;
            }
            else { 
                return "其他";
            }

        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            //Init();
        }
    }
}