using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace GoBiding.Web.UserCenter.UserCenterPage
{
    /// <summary>
    /// GetCityList 的摘要说明
    /// </summary>
    public class GetCityList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            int provinceId = int.Parse(context.Request["ProvinceId"].ToString());

            var models = new BLL.Citys().GetModelList("ProvinceID = " + provinceId);
            context.Response.Write(JsonConvert.SerializeObject(models));
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