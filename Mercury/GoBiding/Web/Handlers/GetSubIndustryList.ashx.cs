using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Maticsoft.Common.DEncrypt;
using GoBiding.BLL;
using Newtonsoft.Json;

namespace GoBiding.Web
{
    /// <summary>
    /// Summary description for BindAccount1
    /// </summary>
    public class GetSubIndustryList : IHttpHandler
    {
        private BLL.Sys_Users userBLL = new BLL.Sys_Users();

        public void ProcessRequest(HttpContext context)
        {
            BLL.Logger.Info("GetSubIndustryList","");

            try
            {
                context.Response.ContentType = "text/plain";

                if (context.Request["IndustryId"] != null)
                {
                    int industryId = int.Parse(context.Request["IndustryId"].ToString());

                    List<Model.BidCategorys> cList = new List<Model.BidCategorys>();
                    if(industryId > 0)
                        cList = new BLL.BidCategorys().GetModelList(" ParentCategoryId = " + industryId);
                    else
                        cList = new BLL.BidCategorys().GetModelList(" ParentCategoryId <> 0");

                    string result = JsonConvert.SerializeObject(cList);
                    BLL.Logger.Info("GetSubIndustryListResponse", result);

                    context.Response.Write(result);
                }

            }
            catch (Exception err)
            {
                BLL.Logger.Warn(err.Message, err.StackTrace);
                context.Response.Write("处理异常");
                return;
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