using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoBiding.Model;
using System.Web.SessionState;

namespace GoBiding.UserCenter.UserCenterPage
{
    /// <summary>
    /// CreateTracker 的摘要说明
    /// </summary>
    public class CreateTracker : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                if (context.Session["UserSessionId"] == null)
                {
                    context.Response.Write("登录状态过期，请先登录！");
                    return;
                }

                context.Response.ContentType = "text/plain";
                string IndustryIdListStr = context.Request["IndustryIdList"].ToString();
                string TrackerAreaIdList = context.Request["TrackerAreaIdList"].ToString();
                string TrackerNameStr = context.Request["TrackerName"].ToString();
                string TrackerId = context.Request["TrackerId"].ToString();

                string Keyword1 = context.Request["Keyword1"].ToString();
                string Keyword2 = context.Request["Keyword2"].ToString();
                string Keyword3 = context.Request["Keyword3"].ToString();
                string Keyword4 = context.Request["Keyword4"].ToString();
                string Keyword5 = context.Request["Keyword5"].ToString();

                Model.Sys_UserTrackers tracker;
                

                if (string.IsNullOrEmpty(TrackerId))
                {
                    tracker = new Sys_UserTrackers();
                }
                else
                {
                    tracker = new BLL.Sys_UserTrackers().GetModel(int.Parse(TrackerId));
                }

                tracker.CreateTime = DateTime.Now;
                tracker.TrackerName = TrackerNameStr;
                tracker.TrackerIndustryIds = IndustryIdListStr;
                tracker.TrackerCityIds = TrackerAreaIdList;
                tracker.TrackerIndustryIds = IndustryIdListStr;

                tracker.Keyword1 = Keyword1;
                tracker.Keyword2 = Keyword2;
                tracker.Keyword3 = Keyword3;
                tracker.Keyword4 = Keyword4;
                tracker.Keyword5 = Keyword5;

                tracker.Sys_UserId = int.Parse(context.Session["UserSessionId"].ToString());
;

                if (string.IsNullOrEmpty(TrackerId))
                {
                    if (new BLL.Sys_UserTrackers().GetRecordCount(" Sys_UserId = " + tracker.Sys_UserId) > 5)
                    {
                        context.Response.Write("最多只能创建5个追踪器！");
                        return;
                    }

                    new BLL.Sys_UserTrackers().Add(tracker);
                }
                else
                {
                    new BLL.Sys_UserTrackers().Update(tracker);
                }

                context.Response.Write("OK");
            }
            catch (Exception err)
            {
                context.Response.Write(err.Message);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}