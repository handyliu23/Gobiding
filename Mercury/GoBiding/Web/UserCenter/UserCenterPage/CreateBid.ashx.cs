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
    public class CreateBid : IHttpHandler
    {
        private int UserId = 7;

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string BidContacter = context.Request["BidContacter"].ToString();
            string BidNumber = context.Request["BidNumber"].ToString();
            string BidContent = context.Request["BidContent"].ToString();
            int BidCategoryId = int.Parse(context.Request["CategoryId"].ToString());
            string BidContacterMobile = context.Request["BidContacterMobile"].ToString();
            int ProvinceId = int.Parse(context.Request["ProvinceId"].ToString());
            int CityId = int.Parse(context.Request["CityId"].ToString());
            string BidContacterAddress = context.Request["BidContacterAddress"].ToString();
            string BidTitle = context.Request["BidTitle"].ToString();
            string BidContacterTel = context.Request["BidContacterTel"].ToString();
            string ExpireTime = context.Request["ExpireTime"].ToString();
            string CompanyName = context.Request["CompanyName"].ToString();
            string BidCategoryName = context.Request["BidCategoryName"].ToString();
            string BidType = context.Request["BidType"].ToString();
            
            Model.Bids model = new Bids();
            model.BidAgent = "";
            model.BidCompanyName = CompanyName;
            model.BidCategoryId = BidCategoryId;
            model.SysUserId = UserId;
            model.BidContacter = BidContacter;
            model.BidExpireTime = Convert.ToDateTime(ExpireTime);
            model.BidNumber = BidNumber;
            model.BidContent = BidContent;
            model.BidContacterMobile = BidContacterMobile;
            model.BidContacterTel = BidContacterTel;
            model.BidPlatFrom = "GoBiding";
            model.ProvinceId = ProvinceId;
            model.CityId = CityId;
            model.BidPublishTime = DateTime.Now;
            model.BidType = BidType;
            model.LastChangeTime = DateTime.Now;
            model.CreateTime = DateTime.Now;
            model.BidContacterAddress = BidContacterAddress;
            model.BidTitle = BidTitle;
            model.BidCategoryType = int.Parse(BidCategoryName);

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