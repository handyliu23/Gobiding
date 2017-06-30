using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Web.BaseCode;
using Maticsoft.DBUtility;
using GoBiding.Model;

namespace GoBiding.UserCenter.UserCenterPage
{
    public partial class BidTracker : PhoenixBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Init();
            }
        }

        public void Init()
        {
            int tId = 0;
            if (Request.QueryString["tId"] != null)
            {
                tId = int.Parse(Request.QueryString["tId"].ToString());
                Model.Sys_UserTrackers tracker = new BLL.Sys_UserTrackers().GetModel(tId);
                hdnTrackerId.Value = tId.ToString();

                if (Request.QueryString["option"] != null)
                {
                    if (Request.QueryString["option"].ToString() == "edit")
                    {
                        btnAddOrSave.InnerText = "保存";
                        titleAddOrSave.InnerText = "保存";

                        divTrackerBidList.Visible = false;

                        txtKeyword1.Value = tracker.Keyword1;
                        txtKeyword2.Value = tracker.Keyword2;
                        txtKeyword3.Value = tracker.Keyword3;
                        txtKeyword4.Value = tracker.Keyword4;
                        txtKeyword5.Value = tracker.Keyword5;

                        txtTrackerName.Value = tracker.TrackerName;

                        if (!string.IsNullOrEmpty(tracker.TrackerIndustryIds))
                        {
                            if (tracker.TrackerIndustryIds.Length == 1)
                            {
                                hdnCategorys.Value = tracker.TrackerIndustryIds;
                            }
                            else
                            {
                                hdnCategorys.Value = tracker.TrackerIndustryIds.Substring(0, tracker.TrackerIndustryIds.Length - 1);
                            }
                        }
                        
                        if (!string.IsNullOrEmpty(tracker.TrackerCityIds))
                        {
                            if (tracker.TrackerCityIds.Length == 1)
                            {
                                hdnCitys.Value = tracker.TrackerCityIds;
                            }
                            else {
                                hdnCitys.Value = tracker.TrackerCityIds.Substring(0, tracker.TrackerCityIds.Length - 1);
                            }
                        }
       
                        
                    }
                    else if(Request.QueryString["option"].ToString() == "delete")
                    {
                        new BLL.Sys_UserTrackers().Delete(tId);
                        Response.Redirect("/UserCenter/UserCenterPage/BidTracker.aspx");
                    }
                }
                else
                {
                    btnAddOrSave.InnerText = "创建追踪宝";
                    titleAddOrSave.InnerText = "创建追踪宝";

                    ltrTrackerName.Text = tracker.TrackerName;
                    InitTrackList();

                    divCreateOrEditTracker.Visible = false;
                    GetListByTracker(tracker);
                }
            }
            else
            {
                divTrackerBidList.Visible = false;

                InitTrackList();
            }
        }

        public void InitTrackList()
        {
            int userId = int.Parse(Session["UserSessionId"].ToString());
            var list = new BLL.Sys_UserTrackers().GetList(10, "Sys_UserId = " + userId, "UserTrackerId desc");
            this.rptTrackerList.DataSource = list;
            this.rptTrackerList.DataBind();

        }

        public void GetListByTracker(Model.Sys_UserTrackers tracker)
        {
            string where = "";
            if (!string.IsNullOrEmpty(tracker.Keyword1))
            {
                where += " or BidTitle like '%" + tracker.Keyword1 + "%'";
            }
            if (!string.IsNullOrEmpty(tracker.Keyword2))
            {
                where += " or BidTitle like '%" + tracker.Keyword2 + "%'";
            }
            if (!string.IsNullOrEmpty(tracker.Keyword3))
            {
                where += " or BidTitle like '%" + tracker.Keyword3 + "%'";
            }
            if (!string.IsNullOrEmpty(tracker.Keyword4))
            {
                where += " or BidTitle like '%" + tracker.Keyword4 + "%'";
            }
            if (!string.IsNullOrEmpty(tracker.Keyword5))
            {
                where += " or BidTitle like '%" + tracker.Keyword5 + "%'";
            }
            if (where != "")
            {
                where = " and (" + where.Substring(3) + ")";
            }

            if (!string.IsNullOrEmpty(tracker.TrackerIndustryIds))
            {
                if (tracker.TrackerIndustryIds != "0" && tracker.TrackerIndustryIds.Length > 1)
                {
                    where += " and BidCategoryId in (" + tracker.TrackerIndustryIds.Substring(0, tracker.TrackerIndustryIds.Length - 1) + ")";
                }
            }
            if (!string.IsNullOrEmpty(tracker.TrackerCityIds))
            {
                if (tracker.TrackerCityIds != "0" && tracker.TrackerCityIds.Length > 1)
                {
                    where += " and ProvinceId in (" + tracker.TrackerCityIds.Substring(0, tracker.TrackerCityIds.Length - 1) + ")";
                }
            }


            string sql = string.Format(@"
SELECT TOP {0} BidId,BidTitle,BidPublishTime,BidCompanyName,ProvinceId,BidCategoryId,BidType
FROM 
(
SELECT ROW_NUMBER() OVER (ORDER BY BidPublishTime desc) AS RowNumber,BidId,BidTitle,BidPublishTime,BidCompanyName,ProvinceId,BidCategoryId,BidType
FROM Bids Where 1=1 {2}
) A
WHERE RowNumber > {0}*({1} - 1)
", AspNetPager1.PageSize, AspNetPager1.CurrentPageIndex, where);
            
            string sqlCount = "SELECT count(*) FROM Bids Where 1=1 " + where;

            var bidList = new List<Bids>();
            using (SqlDataReader reader = DbHelperSQL.ExecuteReader(sql, null))
            //ExecuteReader返回的对象类型是SqlDataReader
            {
                while (reader.Read())
                {
                    var bid = new Model.Bids();
                    bid.BidId = reader.GetInt64(0);
                    bid.BidTitle = reader.GetString(1);
                    bid.ProvinceId = reader.GetInt32(4);
                    bid.BidPublishTime = DateTime.Parse(reader.GetDateTime(2).ToString());
                    bid.BidType = reader.GetString(6);
                    bid.BidCompanyName = reader.GetValue(3).ToString();

                    bidList.Add(bid);
                }

                rptBidList.DataSource = bidList;
                rptBidList.DataBind();
            }

            #region 计算总数
            AspNetPager1.RecordCount = int.Parse(DbHelperSQL.GetSingle(sqlCount).ToString());
            ltrTotalCount.Text = AspNetPager1.RecordCount.ToString();

            #endregion
        }

        protected void AspNetPager1_PageChanged(object src, EventArgs e)
        {
            Init();
        }

    }
}