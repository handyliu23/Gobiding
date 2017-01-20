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
            _logger.InfoFormat("SendSubscribeBids Job start.");

            int pageIndex = 0;
            int pageSize = 100;

            var list = userService.GetListByPage(" Email <> '' ", "Sys_UserId desc", pageIndex, pageSize);
            for (int i = 0; i < list.Tables[0].Rows.Count; i++)
            {
                string receiver = list.Tables[0].Rows[i]["Email"].ToString();
                string username = list.Tables[0].Rows[i]["UserNickName"].ToString();
                string sys_UserId = list.Tables[0].Rows[i]["Sys_UserId"].ToString();
                var bidList = new List<Mercury.Model.Bids>();
                string content = "";

                var trackerlist = trackerService.GetModelList(" Sys_UserId = " + sys_UserId);
                if (trackerlist == null || trackerlist.Count == 0)
                {
                    //没有设置订阅的，直接推送最新招标信息
                    bidList = bidService.GetModelList(5, "BidType = 1", " BidPublishTime desc");

                }
                else
                {
                    Mercury.Model.Sys_UserTrackers tracker = trackerlist.FirstOrDefault();
                    string where = " BidType = 1 ";
                    if (!string.IsNullOrEmpty(tracker.Keyword1))
                    {
                        where += " and BidTitle like '%" + tracker.Keyword1 + "%'";
                    }
                    if (!string.IsNullOrEmpty(tracker.TrackerCityIds))
                    {
                        where += " and ProvinceId in (" + tracker.TrackerCityIds.Substring(0, tracker.TrackerCityIds.Length - 1) + ")";
                    }

                    bidList = bidService.GetModelList(5, where, " BidPublishTime desc");

                    var provinceList = provinceService.GetModelList(" ProvinceID in (" + tracker.TrackerCityIds.Substring(0, tracker.TrackerCityIds.Length - 1) + ")");
                    var industryList = industryService.GetModelList(" BidCategoryId in (" + tracker.TrackerIndustryIds.Substring(0, tracker.TrackerIndustryIds.Length - 1) + ")");

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

                content += "<br/><br/>去投标网向您推荐最新的招标信息：<br/>";

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

                content += "<br/><br/>订阅说明：您是去投标网普通会员，每日上午10时会为您免费推送一次招标信息（不超过10条），如需专属定制订阅更多更实时的招标采购信息，请升级为高级vip会员";
                content += "<br/>商业市场竞争激烈，愿您抓住每一个机会，您的成功是我们为之努力的心愿！<br/><br/>扫一扫关注微信公众号即可手机微信订阅，万千商机，尽在掌握！<br/><img src='http://gobiding.com/imgs/system/wx100_100.png'/>";
                content += "<br/>如有任何疑问或者建议请及时联系我们！";
                content += "<br/>官方网址：http://www.gobiding.com";
                content += "<br/>微信公众号：去投标网";
                content += "<br/>邮箱：postmaster@gobiding.com";
                content += "<br/>qq客服：2968038259";

                SendEmail(receiver, content);
            }

        }

        public void SendEmail(string email, string content)
        {
            if (!CommonUtility.IsEmail(email))
            {
                return;
            }

            sendMail(new List<string>() { email }, "招标信息订阅提醒,去投标网（www.gobiding.com)", content);
        }

        private void sendMail(List<string> receiveEmail, string title, string content)
        {
            try
            {
                SmtpSection cfg = GoBidingEmailSender.getSmtpSection();
                GoBidingEmailSender.Send(null, cfg, true, receiveEmail, title, content, true, Encoding.UTF8, true, null);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
