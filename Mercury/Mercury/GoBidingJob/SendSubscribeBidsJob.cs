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

                    content += "<img src='http://www.gobiding.com/imgs/ad/ad_m_2.gif' /><br/>去投标网免费向您推荐最新的招标信息：<br/><br/>";

                    string url = "http://www.gobiding.com/BidDetail.aspx?bId={0}";

                    foreach (Mercury.Model.Bids bid in bidList)
                    {
                        content += string.Format("{3}.<a href='{0}' style='text-decoration:none;'>[{1}]{2}</a><br/>",
                            string.Format(url, bid.BidId),
                            CommonUtility.GetProvinceName(bid.ProvinceId == null ? "" : bid.ProvinceId.ToString()),
                            bid.BidTitle,
                            bidList.IndexOf(bid) + 1
                            );
                    }

                    content += "<br/><br/>订阅说明：去投标网每日为您免费推送一次全国各行业招标信息，<a href='http://www.goboding.com'>登录官方平台</a>可以设置追踪器获取更多精准的招标采购信息";
                    content += "<br/>商业市场竞争激烈，愿您抓住每一个机会，您的成功是我们为之努力的心愿！<br/><br/>扫一扫关注微信公众号即可手机微信订阅，万千商机，尽在掌握！<br/><img src='http://gobiding.com/imgs/system/wx300_300.png'/>";
                    content += "<br/>如有任何疑问或者建议请及时联系我们！";
                    content += "<br/>官方网址：http://www.gobiding.com";
                    content += "<br/>联系地址：上海市长宁区金钟路968号";
                    content += "<br/>微信公众号：去投标网";
                    content += "<br/>邮箱：postmaster@gobiding.com";
                    content += "<br/>qq客服：2968038259";

                    SendEmail(receiver, content);

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

        public void SendEmail(string email, string content)
        {
            if (!CommonUtility.IsEmail(email))
            {
                return;
            }

            sendMail(new List<string>() { email }, "全国免费招标信息订阅提醒,去投标网（http://www.gobiding.com)", content);
        }

        private void sendMail(List<string> receiveEmail, string title, string content)
        {
            try
            {
                SmtpSection cfg = GoBidingEmailSender.getSmtpSection();
                GoBidingEmailSender.Send(null, cfg, true, receiveEmail, title, content, true, Encoding.UTF8, true, null);
            }
            catch (Exception err)
            {
                Logger.Warn(err.Message, err.StackTrace, "GoBidingJob");
            }
        }
    }
}
