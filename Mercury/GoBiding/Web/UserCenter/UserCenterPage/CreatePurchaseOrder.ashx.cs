using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoBiding.Model;
using System.Web.SessionState;


namespace GoBiding.Web.UserCenter.UserCenterPage
{
    /// <summary>
    /// CreateBid 的摘要说明
    /// </summary>
    public class CreatePurchaseOrder : IHttpHandler, IRequiresSessionState
    {
        private int UserId = 0;

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";

                if (context.Session["UserSessionId"] != null)
                    UserId = int.Parse(context.Session["UserSessionId"].ToString());

                string BidContacter = context.Request["BidContacter"].ToString();
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
                string POId = context.Request["POId"].ToString();

                PurchaseOrder model = null;
                if (string.IsNullOrEmpty(POId) || POId == "0")
                {
                    model = new PurchaseOrder();
                }
                else
                {
                    model = new BLL.PurchaseOrder().GetModel(int.Parse(POId));
                }

                model.Address = "";
                model.BrowseCount = 0;
                model.Budget = 0;
                model.CompanyName = CompanyName;
                model.ContacterName = BidContacter;
                model.CreateTime = DateTime.Now;
                model.CustomInfo = "";
                model.Deleted = 0;
                model.Description = BidContent;
                model.Email = BidContacterAddress;
                if (!string.IsNullOrEmpty(ExpireTime))
                    model.ExpireTime = DateTime.Parse(ExpireTime);
                model.IsEmergency = 0;
                model.IsSetTop = false;
                model.IsNeedVipVendor = false;
                model.MobilePhone = BidContacterMobile;
                model.NeedCustom = 0;
                model.NeedInvoice = 0;
                model.NeedSample = 0;
                model.PublishTime = DateTime.Now;
                model.PurchaseType = 1;
                model.RecvProvinceId = ProvinceId;
                model.RecvCityId = CityId;
                model.Status = 1;
                model.Title = BidTitle;
                model.ProductCategoryId = BidCategoryId;
                model.TelePhone = BidContacterTel;
                model.SysUserId = UserId;

                if (string.IsNullOrEmpty(POId) || POId == "0")
                {
                    new BLL.PurchaseOrder().Add(model);
                }
                else
                {
                    new BLL.PurchaseOrder().Update(model);
                }

                context.Response.Write("OK");
            }
            catch (Exception err)
            {
                BLL.Logger.Warn(err.Message, err.StackTrace);
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