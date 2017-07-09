using System.Net.Configuration;
using Maticsoft.Common;
using Mercury.BLL;
using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Maticsoft.DBUtility;
using System.Threading;

namespace GoBidingJob
{
    public sealed class SendSubscribeBidsJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(SendSubscribeBidsJob));
        private Mercury.BLL.Sys_Users userService = new Sys_Users();
        private Mercury.BLL.Bids bidService = new Bids();
        private Mercury.BLL.Sys_UserTrackers trackerService = new Sys_UserTrackers();
        private Mercury.BLL.Provinces provinceService = new Provinces();
        private Mercury.BLL.BidCategorys industryService = new BidCategorys();

        public void Execute(IJobExecutionContext context)
        {
            try
            {
                //_logger.InfoFormat("SendSubscribeBids Job start.");

                int pageIndex = 0;
                int pageSize = 500;

                string sqlEmaillog = @"
select top 1 sys_userid from EmailLogs order by 1 desc
";
                var obj = DbHelperSQL.Query(sqlEmaillog);
                int lastuserid = int.Parse(obj.Tables[0].Rows[0]["sys_userid"].ToString());

                var list = userService.GetListByPage(string.Format(" Email <> '' and sys_userid > {0} ",lastuserid), "Sys_UserId", pageIndex, pageSize);
                for (int i = 0; i < list.Tables[0].Rows.Count; i++)
                {
                    string receiver = list.Tables[0].Rows[i]["Email"].ToString();
                    string username = list.Tables[0].Rows[i]["UserName"].ToString();
                    int sys_UserId = int.Parse(list.Tables[0].Rows[i]["Sys_UserId"].ToString());
                    var bidList = new List<Mercury.Model.Bids>();
                    string content = "";
                    //sys_UserId = "7";
                    var trackerlist = trackerService.GetModelList(" Sys_UserId = " + sys_UserId);
                    if (trackerlist == null || trackerlist.Count == 0)
                    {
                        //没有设置订阅的，直接推送最新招标信息
                        bidList = bidService.GetModelList(10, "BidType = 1 and BidPublishTime > '" + DateTime.Now.Date.ToShortDateString() + "'", " BidPublishTime desc");
                        if (bidList == null || bidList.Count == 0)
                        {
                            bidList = bidService.GetModelList(10, "BidType = 1 and BidPublishTime > '" + DateTime.Now.AddDays(-1).Date.ToShortDateString() + "'", " BidPublishTime desc");
                        }
                    }
                    else
                    {
                        Mercury.Model.Sys_UserTrackers tracker = trackerlist.FirstOrDefault();
                        string where = " BidType = 1 ";
                        if (!string.IsNullOrEmpty(tracker.Keyword1))
                        {
                            where += string.Format(" and (contains(BidTitle,'{0}') or contains(BidContent,'{0}'))", tracker.Keyword1);
                        }
                        if (!string.IsNullOrEmpty(tracker.TrackerCityIds) && tracker.TrackerCityIds != "0")
                        {
                            where += " and ProvinceId in (" + tracker.TrackerCityIds.Substring(0, tracker.TrackerCityIds.Length - 1) + ")";
                        }

                        where += " and BidPublishTime > '" + DateTime.Now.AddDays(-3).ToShortDateString() + "'";

                        bidList = bidService.GetModelList(5, where, " BidPublishTime desc");
                        List<Mercury.Model.Provinces> provinceList = new List<Mercury.Model.Provinces>();
                        List<Mercury.Model.BidCategorys> industryList = new List<Mercury.Model.BidCategorys>();
                        if (tracker.TrackerCityIds != "0")
                        {
                            provinceList = provinceService.GetModelList(" ProvinceID in (" + tracker.TrackerCityIds.Substring(0, tracker.TrackerCityIds.Length - 1) + ")");
                        }
                        else
                        {
                            provinceList.Add(new Mercury.Model.Provinces { ProvinceName = "全国" });
                        }
                        if (tracker.TrackerIndustryIds != "0")
                        {
                            industryList = industryService.GetModelList(" BidCategoryId in (" + tracker.TrackerIndustryIds.Substring(0, tracker.TrackerIndustryIds.Length - 1) + ")");
                        }else
                        {
                            industryList.Add(new Mercury.Model.BidCategorys { BidCategoryName = "所有行业" });
                        }
                        string keywords = tracker.Keyword1 + " " + tracker.Keyword2 + " " + tracker.Keyword3 + " " + tracker.Keyword4 + " " +
                                          tracker.Keyword5;

                        content = username +
                                         "您好，根据您在<a href='http://www.gobiding.com'>去投标网</a>的订阅要求：<br/>√ 订阅地区:<span style='color:orange;'>" +
                                         string.Join(",", provinceList.Select(o => o.ProvinceName)) + "</span>" +
                                         "<br/>√ 订阅关键词：<span style='color:orange;'>" + keywords + "</span>" +
                                         "<br/>√ 订阅行业：<span style='color:orange;'>" +
                                         string.Join(",", industryList.Select(o => o.BidCategoryName)) + "</span>";
                        //"<br/>√ 信息分类：<span style='color:orange;'>" + tracker. + "</span>";
                    }

                    content += createEmailHtml(bidList);

                    if (SendEmail(receiver, content) < 0)
                    {
                        continue;
                    }

                    if (i == 0)
                    {
                        SendEmail("715794512@qq.com", content);
                    }
            
                    AddEmailLog(sys_UserId, "");

                    Thread.Sleep(120000);

                }
            }
            catch (Exception err)
            {
                Logger.Warn(err.Message, err.StackTrace, "GoBidingJob");
            }
        }

        public void AddEmailLog(int userId, string content )
        {
            string sql = "insert into EmailLogs values(" + userId + ", '', getdate(), '" + content + "')";

            DbHelperSQL.ExecuteSql(sql);
        }

        public int SendEmail(string email, string content)
        {
            if (!CommonUtility.IsEmail(email))
            {
                return -1;
            }

            return sendMail(new List<string>() { email }, "全国免费招标信息订阅提醒,去投标网（http://www.gobiding.com)", content);
        }

        private int sendMail(List<string> receiveEmail, string title, string content)
        {
            try
            {
                SmtpSection cfg = GoBidingEmailSender.getSmtpSection();
                GoBidingEmailSender.Send(null, cfg, true, receiveEmail, title, content, true, Encoding.UTF8, true, null);
            }
            catch (Exception err)
            {
                Logger.Warn(err.Message, err.StackTrace, "GoBidingJob");
                return -1;
            }

            return 1;
        }

        public string createEmailHtml( List<Mercury.Model.Bids> bidList)
        {
            string html = @"
  <div style=""width: 100%; background-color: #fff; padding: 20px;""> 
   <div style=""width: 950px; margin: 0px auto; min-height: 300px; background-color: #fcfcfc;
            padding: 20px;""> 
    <img src=""http://www.gobiding.com/imgs/ad/ad_m_2.gif"" /> 
    <br /> 
    <div style=""font-size: 13px; color: #333; padding: 10px; line-height: 24px;  font-family: '微软雅黑';"">
      订阅说明：去投标网每日收集发布全国招标采购信息超过10000条，平台为您免费推送一次全国各行业招标信息，登录官方平台可以设置追踪器获取更多精准的招标采购信息商业市场竞争激烈，愿您抓住每一个机会，您的成功是我们为之努力的心愿！ 
     <br />
     <br /> 以下是为您推选的招标信息（您也可以免费注册登录去投标网设置订阅关键词，获取更精准匹配的招标信息）： 
    </div> 
";
            string htmlbody = "";

            for (int i = 0; i < bidList.Count; i++)
            {
                htmlbody += string.Format(@"
    <table id=""bidinfoitem"" cellspacing=""0"" style=""width: 100%; border: 1px solid #dcdcdc;
                        margin-bottom: 10px;""> 
     <tbody>
      <tr> 
       <td style=""width: 70px; height: 110px; padding-left: 10px; text-align: center; line-height: 30px;
                                vert-align: middle; font-size: 12px;""> 2017-07-05 </td> 
       <td style=""width: 500px; line-height: 24px; padding: 5px; vertical-align: top;""> <span style=""background: #FFBB66; font-size: 9px; padding: 2px 5px 2px 5px; color: #fff;"">正在招标</span> <a href=""http://www.gobiding.com/BidDetail/{0}.html"" target=""_blank"" style=""font-size: 14px;
                                    font-family: microsoft yahei; text-decoration: none; color: #000;""> {1}</a><br /> 
        <div style=""color: #666; font-size: 12px; line-height: 24px; padding-right: 100px;
                                    padding-bottom: 2px;"">{2}</div> <span style=""background-color: #fff; font-size: 12px; padding: 5px;"">{3}</span> <span style=""background-color: #fff; font-size: 12px; padding: 5px;"">{4}</span> <span style=""background-color: #fff;
                                        font-size: 12px; padding: 5px;"">{5}</span> </td> 
      </tr> 
     </tbody>
    </table> 
", 
 bidList.ElementAt(i).BidId, 
 bidList.ElementAt(i).BidTitle, 
 CommonUtility.GetChineseCh(bidList.ElementAt(i).BidContent),
 Mercury.BLL.CommonUtility.GetBidTypeValue(bidList.ElementAt(i).BidType),
 GetBidCategoryNameValue(bidList.ElementAt(i).BidCategoryId ?? 0),
 CommonUtility.GetProvinceName(bidList.ElementAt(i) == null ? "" : bidList.ElementAt(i).ProvinceId.ToString())
);

            }

            string htmltail = @"
 <div style=""line-height: 24px; font-family: '微软雅黑'; padding: 10px; font-size: 14px;""> 
     <table> 
      <tbody>
       <tr> 
        <td style=""width: 200px;""> <img src=""http://www.gobiding.com/imgs/system/wx300_300.png"" width=""170"" /> </td> 
        <td> 扫一扫关注微信公众号即可手机微信订阅，万千商机，尽在掌握！<br /> 如有任何疑问或者建议请及时联系我们！<br /> 官方网址：http://www.gobiding.com<br /> 联系地址：上海市长宁区金钟路968号<br /> 微信公众号：去投标网<br /> 企业邮箱：postmaster@gobiding.com<br /> qq客服：2968038259<br /> </td> 
       </tr> 
      </tbody>
     </table> 
    </div> 
   </div> 
  </div> 
";

            string totalhtml = html + htmlbody + htmltail;
            return totalhtml;
        }

        public string GetBidCategoryNameValue(int categoryId)
        {
            if (!string.IsNullOrEmpty(categoryId.ToString()))
            {
                var categorys = new Mercury.BLL.BidCategorys().GetModelList(" ParentCategoryId = 0 ");
                var c = categorys.Where(o => o.BidCategoryId == categoryId).FirstOrDefault();
                if (c == null)
                    return "其他";

                return c.BidCategoryName;
            }
            else
            {
                return "其他";
            }

        }
    }
}
