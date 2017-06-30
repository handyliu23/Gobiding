using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoBiding.Model;

namespace GoBiding.Web.wap.handlers
{
    /// <summary>
    /// addSubscribe 的摘要说明
    /// </summary>
    public class addSubscribe : IHttpHandler
    {
        BLL.Sys_UserTrackers usertrackerBiz = new BLL.Sys_UserTrackers();

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";

                var keyword1 = context.Request.Form["keyword1"].ToString();
                var keyword2 = context.Request.Form["keyword2"].ToString();
                var keyword3 = context.Request.Form["keyword3"].ToString();

                var industry = context.Request.Form["bidtype"] == null ? "0" : context.Request.Form["industry"].ToString();
                var area = context.Request.Form["area"] == null ? "0" : context.Request.Form["area"].ToString();
                var bidtype = context.Request.Form["bidtype"] == null ? "0" : context.Request.Form["bidtype"].ToString();
                var bidtime = context.Request.Form["bidtime"] == null ? "0" : context.Request.Form["bidtime"].ToString();

                var userId = context.Request.Form["userId"].ToString();
                var userTrackerId = 0;

                if (!string.IsNullOrEmpty(context.Request.Form["userTrackerId"]))
                {
                    userTrackerId = int.Parse(context.Request.Form["userTrackerId"].ToString());
                }

                Model.Sys_UserTrackers tracker = null;
                if (userTrackerId > 0)
                {
                    tracker = usertrackerBiz.GetModel(userTrackerId);
                }
                else
                {
                    tracker = new Sys_UserTrackers();
                }
                tracker.TrackerName = "追踪器" + DateTime.Now.ToShortDateString() + new Random().Next(100);
                tracker.CreateTime = DateTime.Now;
                tracker.Keyword1 = keyword1;
                tracker.Keyword2 = keyword2;
                tracker.Keyword3 = keyword3;
                tracker.TrackerIndustryIds = industry;
                tracker.TrackerCityIds = area;
                tracker.BidType = bidtype;
                tracker.BidTime = bidtime;
                tracker.Sys_UserId = int.Parse(userId);

                if (userTrackerId > 0)
                {
                    usertrackerBiz.Update(tracker);
                }
                else
                {
                    usertrackerBiz.Add(tracker);
                }
                context.Response.Write(tracker.UserTrackerId.ToString());
            }
            catch (Exception err)
            {
                BLL.Logger.Warn(err.Message, err.StackTrace);
                context.Response.Write("Fail");
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