using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Model;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using System.Data;
using GoBiding.BLL;
using Newtonsoft.Json;

namespace GoBiding.Web.wap
{
    public partial class Default : System.Web.UI.Page
    {
        private string Token = "gobiding";
        public string keywords = "";
        private List<GoBiding.Model.BidCategorys> categorys;

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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSessionId"] == null)
            {
                logouthref.InnerText = "登录";
                logouthref.HRef = "wapLogin.aspx";

                ltrUserName.Text = "未登录";
                Init();
                return;
                //Response.Redirect("/wap/wapLogin.aspx");
            }
            if (!IsPostBack)
            {
                Model.Sys_Users user = new BLL.Sys_Users().GetModel(int.Parse(Session["UserSessionId"].ToString()));
                ltrUserName.Text = user.UserNickName;

                Init();
            }
        }
        public string GetProvinceName(string provinceId)
        {
            var model = new BLL.Provinces().GetModel(int.Parse(provinceId));
            if (model != null)
                return model.ProvinceName;

            return "";
        }

        public string GetBidTypeList(string bidTypeList)
        {
            string result = "";
            if (bidTypeList.Contains("1"))
            {
                result += "招标公告,";
            }
            if (bidTypeList.Contains("2"))
            {
                result += "招标变更,";
            }
            if (bidTypeList.Contains("3"))
            {
                result += "中标公告,";
            }
            if (bidTypeList.Contains("4"))
            {
                result += "招标预告,";
            }

            if (result.Contains(","))
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        
        }

        public string GetBidTimesList(string timeType)
        {
            if (timeType == "1")
            {
                return "一天内";
            }
            else if (timeType == "2")
            {
                return "三天内";
            }
            else if (timeType == "3")
            {
                return "一周内";
            }
            else if (timeType == "4")
            {
                return "半月内";
            }

            return "三天内";
        }

        public void Init()
        {
            //根据订阅显示
            if (Request.QueryString["UserTrackerId"] != null && Session["UserSessionId"] != null)
            {
                #region 有tracker
                int tId = int.Parse(Request.QueryString["UserTrackerId"].ToString());

                var tracker = new BLL.Sys_UserTrackers().GetModel(tId);
                if (tracker != null) // (tracker.Sys_UserId.Value == int.Parse(Session["UserSessionId"].ToString()))
                {
                    divTrackerInfo.Visible = true;
                    divsearchrow.Visible = false;
                    divConditionArea.Visible = false;
                    divConditionBidType.Visible = false;
                    divsearchconditionrow.Visible = false;
                    divTop.Visible = false;

                    ltrKeywords.Text = tracker.Keyword1 + "," + tracker.Keyword2 + "," + tracker.Keyword3;

                    string citys = tracker.TrackerCityIds;
                    if (citys.Contains(","))
                        citys = citys.Substring(0, citys.Length - 1);
                    var provinces = new BLL.Provinces().GetModelList(" ProvinceID in (" + citys + ")");
                    ltrAreas.Text = string.Join(",", provinces.Select(o => o.ProvinceName));

                    string industrys = tracker.TrackerIndustryIds;
                    if (industrys.Contains(","))
                        industrys = industrys.Substring(0, industrys.Length - 1);
                    var industryList = new BLL.BidCategorys().GetModelList(" BidCategoryId in (" + industrys + ")");
                    ltrIndustry.Text = string.Join(",", industryList.Select(o => o.BidCategoryName));

                    string bidTypes = tracker.BidType;
                    if (bidTypes.Contains(","))
                        bidTypes = bidTypes.Substring(0, bidTypes.Length - 1);
                    var bidTypeList = GetBidTypeList(bidTypes);
                    ltrBidType.Text = bidTypeList;

                    string bidTimes = tracker.BidTime;
                    if (bidTimes.Contains(","))
                        bidTimes = bidTimes.Substring(0, bidTimes.Length - 1);
                    var bidTimeList = GetBidTimesList(bidTimes);
                    ltrTimeType.Text = bidTimeList;

                    string keywordsql = tracker.Keyword1 + " " + tracker.Keyword2 + " " + tracker.Keyword3;

                    string sql = string.Format(@"
with temptbl as (
SELECT ROW_NUMBER() OVER (ORDER BY BidPublishTime desc)AS Row,O.BidId,O.BidTitle,O.ProvinceId,O.BidNumber,O.CreateTime,O.BidPublishTime,O.BidCompanyName,
O.BidType,O.BidCategoryId, O.SysUserId,O.BidCategoryType,O.LastChangeTime,O.BidKeywords,O.BidContent
from Bids O where (freetext(BidTitle,'{0}') or freetext(BidContent,'{0}'))
", tracker.Keyword1);

                    if(!string.IsNullOrEmpty(citys) && citys != "0")
                        sql += string.Format(@"
and (ProvinceId in ({0}) OR '{0}' is null)
",citys);
                    if (!string.IsNullOrEmpty(industrys) && industrys != "0")
                        sql += string.Format(@"
and (BidCategoryId in ({0}) or '{0}' is null)
", industrys);
                    if (!string.IsNullOrEmpty(bidTypes) && bidTypes != "0")
                        sql += string.Format(@"
and (BidType in ({0}) or '{0}' is null)
", bidTypes);

                    if (!string.IsNullOrEmpty(bidTimes) && bidTimes != "0")
                    {
                        if (bidTimes.Contains("1"))
                        {
                            sql += string.Format(@"and (BidPublishTime > getDate()-1)");
                        }
                        if (bidTimes.Contains("2"))
                        {
                            sql += string.Format(@"and (BidPublishTime > getDate()-3)");
                        }
                        if (bidTimes.Contains("3"))
                        {
                            sql += string.Format(@"and (BidPublishTime > getDate()-7)");
                        }
                        if (bidTimes.Contains("4"))
                        {
                            sql += string.Format(@"and  (BidPublishTime > getDate()-15)");
                        }
                    }

                    sql += string.Format(@"
)SELECT * FROM temptbl where Row between ({0}-1)*{1}+1 and ({0}-1)*{0}+{1}
", AspNetPager1.CurrentPageIndex, AspNetPager1.PageSize);

                    DataSet ds = DbHelperSQL.Query(sql);

                    List<string> cIdList = new List<string>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        ds.Tables[0].Rows[i]["BidContent"] = CommonUtility.GetChineseCh(ds.Tables[0].Rows[i]["BidContent"].ToString());
                        if (ds.Tables[0].Rows[i]["BidCategoryId"] != null)
                        {
                            string bidCategoryId = ds.Tables[0].Rows[i]["BidCategoryId"].ToString();
                            if (!cIdList.Contains(bidCategoryId))
                                cIdList.Add(bidCategoryId);
                        }
                    }                
                    if (cIdList != null && cIdList.Count > 0)
                    {
                        string categoryIdwhere = string.Join(",", cIdList);
                        categorys = new BLL.BidCategorys().GetModelList(" BidCategoryId in ( " + categoryIdwhere + ")");
                    }

                    rptBidList.DataSource = ds;
                    rptBidList.DataBind();
                }

                #endregion
            
            }
            else
            {
                divTrackerInfo.Visible = false;
                #region 无tracker
                if (AspNetPager1.CurrentPageIndex > 15)
                {
                    divInvalid.Visible = true;
                    rptBidList.Visible = false;
                    AspNetPager1.Visible = false;
                    return;
                }
                else
                {
                    divInvalid.Visible = false;
                }

                #region 查询参数
                var keyword = Request.QueryString["keyword"] == null ? "" : HttpUtility.UrlDecode(Request.QueryString["keyword"].ToString().Replace("'", ""));
                var area = Request.QueryString["area"] == null ? "" : Request.QueryString["area"].ToString();
                var industry = Request.QueryString["industry"] == null ? "" : Request.QueryString["industry"].ToString();
                var bidtype = Request.QueryString["bidtype"] == null ? "" : Request.QueryString["bidtype"].ToString();
                var bidtime = Request.QueryString["bidtime"] == null ? "" : Request.QueryString["bidtime"].ToString();

                hdnarea.Value = area;
                hdnindustry.Value = industry;
                hdnbidtype.Value = bidtype;
                hdnkeyword.Value = keyword;
                keywords = keyword;

                List<SqlParameter> _params = new List<SqlParameter>
                                             {
                                                 new SqlParameter("@pageIndex", AspNetPager1.CurrentPageIndex),
                                                 new SqlParameter("@pageSize", AspNetPager1.PageSize)
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
                    _params.Add(new SqlParameter("@BidCategoryId", industry));
                }
                #endregion

                List<Model.Bids> bidList = new List<Model.Bids>();

                if (!string.IsNullOrEmpty(keyword))
                {
                    PrepareForkeywords(keyword, bidList, _params, area, industry, bidtype, bidtime);
                }
                else
                {
                    #region 无关键词
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

                    int count = 0;

                    using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetUserBidsCount", _countparams.ToArray()))//ExecuteReader返回的对象类型是SqlDataReader
                    {
                        while (reader.Read())
                        {
                            count = reader.GetInt32(0);
                        }
                    }
                    AspNetPager1.RecordCount = count;

                    #endregion
                }

                #region 绑定
                List<string> cIdList = bidList.Select(o => (o.BidCategoryId ?? 0).ToString()).ToList();
                if (cIdList != null && cIdList.Count > 0)
                {
                    string categoryIdwhere = string.Join(",", cIdList);
                    categorys = new BLL.BidCategorys().GetModelList(" BidCategoryId in ( " + categoryIdwhere + ")");

                    rptBidList.DataSource = bidList;
                    rptBidList.DataBind();
                }
                #endregion 

                #endregion
            }


            
        }

        public void PrepareForkeywords(string keyword, List<Model.Bids> bidList, List<SqlParameter> _params,
           string area, string industry, string bidtype, string bidtime)
        { 
          #region 有关键词
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

            _countparams.Add(new SqlParameter("@docount", 1));
            int count = 0;
            if (keyword.Contains(" ") || keyword.Contains(","))
            {
                using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetSearchForBidsListByFreetext", _countparams.ToArray()))//ExecuteReader返回的对象类型是SqlDataReader
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }
            }
            else
            {
                using (SqlDataReader reader = DbHelperSQL.RunProcedure("GetSearchForBidsList", _countparams.ToArray()))//ExecuteReader返回的对象类型是SqlDataReader
                {
                    while (reader.Read())
                    {
                        count = reader.GetInt32(0);
                    }
                }
            }
            AspNetPager1.RecordCount = count;

            #endregion
            #endregion
        }

        private void Valid()
        {
            string echoStr = Request.QueryString["echoStr"].ToString();
            if (CheckSignature())
            {
                if (!string.IsNullOrEmpty(echoStr))
                {
                    Response.Write(echoStr);
                    Response.End();
                }
            }
        }


        private static int DateDiff(DateTime dateStart, DateTime dateEnd)
        {
            TimeSpan sp = dateEnd.Subtract(dateStart);

            return (int)sp.TotalMinutes;
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

            return "";
        }

        public string HighlightKeyword(string source)
        {
            if (string.IsNullOrEmpty(keywords))
                return source;

            List<string> keys = keywords.Split(' ').ToList();

            keys.ForEach(o =>
            {
                source = source.Replace(o, "<font style='color:red'>" + o + "</font>");
            });
            return source;
        }

        private bool CheckSignature()
        {
            string signature = Request.QueryString["signature"].ToString();
            string timestamp = Request.QueryString["timestamp"].ToString();
            string nonce = Request.QueryString["nonce"].ToString();
            string[] ArrTmp = { Token, timestamp, nonce };
            Array.Sort(ArrTmp);     //字典排序  
            string tmpStr = string.Join("", ArrTmp);
            tmpStr = FormsAuthentication.HashPasswordForStoringInConfigFile(tmpStr, "SHA1");
            tmpStr = tmpStr.ToLower();
            if (tmpStr == signature)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            Init();
        }
    }
}