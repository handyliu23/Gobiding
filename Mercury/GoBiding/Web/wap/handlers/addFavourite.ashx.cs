using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoBiding.Model;
using Maticsoft.Common;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace GoBiding.Web.wap.handlers
{
    /// <summary>
    /// addFavourite 的摘要说明
    /// </summary>
    public class addFavourite : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            string bidId = context.Request["BidId"].ToString();

            if (string.IsNullOrEmpty(bidId))
                return;

            if (context.Session["SessionUserId"] == null)
            {
                context.Response.Write("regist");
                return;
            }

            Model.Sys_Users user = new BLL.Sys_Users().GetModel(int.Parse(bidId));

            var list = new BLL.Sys_UserFavouriteBids().GetList(1, string.Format("UserId = {0} and BidId = {1}", user.Sys_UserId, bidId), "Sys_UserFavouriteBidId");
            if(list != null && list.Tables[0].Rows.Count > 0)
            {
                context.Response.Write("ok");
                return;
            }

            Model.Sys_UserFavouriteBids ub = new Sys_UserFavouriteBids();
            ub.BidId = int.Parse(bidId);
            ub.CreateTime = DateTime.Now;
            ub.IsActive = true;
            ub.UserId = user.Sys_UserId;

            new BLL.Sys_UserFavouriteBids().Add(ub);

            context.Response.Write("ok");
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