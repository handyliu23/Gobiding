using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoBiding.Model;


namespace GoBiding.Web.UserCenter.UserCenterPage
{
    /// <summary>
    /// CreateBid 的摘要说明
    /// </summary>
    public class CreateWinBid : IHttpHandler
    {
        private int UserId = 7;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string BidNumber = context.Request["BidNumber"].ToString();
            string BidContent = context.Request["BidContent"].ToString();
            int BidCategoryId = int.Parse(context.Request["CategoryId"].ToString());
            int ProvinceId = int.Parse(context.Request["ProvinceId"].ToString());
            int CityId = int.Parse(context.Request["CityId"].ToString());
            string BidTitle = context.Request["BidTitle"].ToString();
            string CompanyName = context.Request["CompanyName"].ToString();
            
            Model.Bids model = new Bids();
            model.BidAgent = "";
            model.WinBidCompanyName = CompanyName;
            model.BidCategoryId = BidCategoryId;
            model.SysUserId = UserId;
            model.BidNumber = BidNumber;
            model.BidContent = BidContent;
            model.BidPlatFrom = "GoBiding";
            model.ProvinceId = ProvinceId;
            model.CityId = CityId;
            model.BidPublishTime = DateTime.Now;
            model.BidType = "3";
            model.LastChangeTime = DateTime.Now;
            model.CreateTime = DateTime.Now;
            model.BidTitle = BidTitle;

            new BLL.Bids().Add(model);

            context.Response.Write("OK");
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