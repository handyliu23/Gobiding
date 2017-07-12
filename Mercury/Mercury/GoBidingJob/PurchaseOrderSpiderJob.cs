using Maticsoft.DBUtility;
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
using System.Threading;
using Mercury.Model;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace GoBidingJob
{
    class PurchaseOrderSpiderJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(FillBidCityIdJob));
        private Mercury.BLL.Sys_Users userService = new Mercury.BLL.Sys_Users();
        private Mercury.BLL.Bids bidService = new Mercury.BLL.Bids();
        private Mercury.BLL.Sys_UserTrackers trackerService = new Mercury.BLL.Sys_UserTrackers();
        private Mercury.BLL.Provinces provinceService = new Mercury.BLL.Provinces();
        private Mercury.BLL.Citys cityService = new Mercury.BLL.Citys();
        private DataSet districts = new Mercury.BLL.Districts().GetAllList();
        private DataSet citys = new Mercury.BLL.Citys().GetAllList();
        private DataSet provinces = new Mercury.BLL.Provinces().GetAllList();
        static HtmlWeb webClient = new HtmlWeb();

        private const string IdleFishSpider_3CUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499837888477_143&callback=jsonp144&stype=1&catid=50100403&st_trust=1&start=800&q=%B2%C9%B9%BA&ist=1";
        private const string IdleFishSpider_HomeDailyUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499836187958_143&start=500&callback=jsonp144&stype=1&catid=57538002&st_trust=1&q=%B2%C9%B9%BA&ist=1";
        private const string IdleFishSpider_StationeryAndSportsUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499836187958_143&start=500&callback=jsonp144&stype=1&catid=50100412&st_trust=1&q=%B2%C9%B9%BA&ist=1";
        private const string IdleFishSpider_ComputerUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499836187958_143&start=500&callback=jsonp144&stype=1&catid=50100402&st_trust=1&q=%B2%C9%B9%BA&ist=1";
        private const string IdleFishSpider_PhoneUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499836187958_143&start=500&callback=jsonp144&stype=1&catid=50100398&st_trust=1&q=%B2%C9%B9%BA&ist=1";
        private const string IdleFishSpider_BeautyUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499836187958_143&start=500&callback=jsonp157&stype=1&catid=50100405&st_trust=1&q=%B2%C9%B9%BA&ist=1";
        private const string IdleFishSpider_CarUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499873133725_143&callback=jsonp144&stype=1&catid=57556002&st_trust=1&q=%C7%F3%B9%BA&ist=1";
        private const string IdleFishSpider_GameUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499873306990_143&callback=jsonp144&stype=1&catid=57562001&st_trust=1&q=%C7%F3%B9%BA&ist=1";
        private const string IdleFishSpider_BicycleUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499873420690_143&callback=jsonp144&stype=1&catid=57532003&st_trust=1&q=%C7%F3%B9%BA&ist=1";
        private const string IdleFishSpider_CameraUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499873568632_143&callback=jsonp144&stype=1&catid=50100401&st_trust=1&q=%C7%F3%B9%BA&ist=1";
        private const string IdleFishSpider_TicketUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499873790953_143&callback=jsonp144&stype=1&catid=57556003&st_trust=1&q=%C7%F3%B9%BA&ist=1";
        private const string IdleFishSpider_LoveBeautyUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499873903818_143&callback=jsonp144&stype=1&catid=50100405&st_trust=1&q=%C7%F3%B9%BA&ist=1";
        private const string IdleFishSpider_ClockUrl = "https://s.2.taobao.com/list/waterfall/waterfall.htm?wp={0}&_ksTS=1499874073398_143&callback=jsonp144&stype=1&catid=50100414&st_trust=1&q=%C7%F3%B9%BA&ist=1";


        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("PurchaseOrderSpiderJob Start");
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_3C), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_HomeDaily), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_StationeryAndSports), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_Computer), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_Phone), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_Beauty), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_Car), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_Game), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_Bicycle), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_Camera), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_Ticket), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_LoveBeauty), new object());
            ThreadPool.QueueUserWorkItem(new WaitCallback(IdleFishSpider_Clock), new object());

            _logger.InfoFormat("PurchaseOrderSpiderJob Start");
        }

        /// <summary>
        /// 3C 数码
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_3C(object val)
        {
            IdleFishSpider(1, 800, IdleFishSpider_3CUrl);
        }

        /// <summary>
        /// 家家居日用
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_HomeDaily(object val)
        {
            IdleFishSpider(2, 500, IdleFishSpider_HomeDailyUrl);
        }

        /// <summary>
        /// 文体用品
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_StationeryAndSports(object val)
        {
            IdleFishSpider(3, 500, IdleFishSpider_StationeryAndSportsUrl);
        }

        /// <summary>
        /// 电脑配件
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_Computer(object val)
        {
            IdleFishSpider(1, 800, IdleFishSpider_ComputerUrl);
        }

        /// <summary>
        /// 手机
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_Phone(object val)
        {
            IdleFishSpider(1, 800, IdleFishSpider_ComputerUrl);
        }

        /// <summary>
        /// 美容美颜
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_Beauty(object val)
        {
            IdleFishSpider(2, 500, IdleFishSpider_BeautyUrl);
        }

        /// <summary>
        /// 汽车
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_Car(object val)
        {
            IdleFishSpider(8, 800, IdleFishSpider_BeautyUrl);
        }

        /// <summary>
        /// 游戏产品
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_Game(object val)
        {
            IdleFishSpider(1, 800, IdleFishSpider_BeautyUrl);
        }


        /// <summary>
        /// 自行车
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_Bicycle(object val)
        {
            IdleFishSpider(2, 800, IdleFishSpider_BicycleUrl);
        }

        /// <summary>
        /// 相机
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_Camera(object val)
        {
            IdleFishSpider(2, 800, IdleFishSpider_CameraUrl);
        }

        /// <summary>
        /// 票务娱乐
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_Ticket(object val)
        {
            IdleFishSpider(9, 500, IdleFishSpider_TicketUrl);
        }

        /// <summary>
        /// 美容、美颜、香水
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_LoveBeauty(object val)
        {
            IdleFishSpider(2, 500, IdleFishSpider_LoveBeautyUrl);
        }

        /// <summary>
        /// 钟表
        /// </summary>
        /// <param name="val"></param>
        public void IdleFishSpider_Clock(object val)
        {
            IdleFishSpider(2, 500, IdleFishSpider_ClockUrl);
        }



        private void IdleFishSpider(int productCategoryId, decimal price, string url)
        {
            for (int p = 1; p <= 3; p++)
            {
                try
                {
                    string context = GetHtml(url, "gb2312", p.ToString());

                    if (string.IsNullOrWhiteSpace(context))
                    {
                        continue;
                    }

                    _logger.InfoFormat("PurchaseOrderSpiderJob" + context);
                    IdleFishBO idleFishBo = Newtonsoft.Json.JsonConvert.DeserializeObject<IdleFishBO>(context);
                    List<string> userNickNames = new List<string>();

                    if (idleFishBo != null)
                    {
                        idleFishBo.idle.ForEach(i =>
                        {
                            if (i.item.price < price || string.IsNullOrWhiteSpace(i.item.title)
                                || i.item.title.Trim().Length < 8) return;

                            if (userNickNames.Contains(i.user.userNick)) return;

                            userNickNames.Add(i.user.userNick);

                            int userId = AddUser(i.user);
                            AddPurchaseOrder(productCategoryId, userId, i.user.userNick, i.item);
                        });
                    }
                }
                catch (Exception e)
                {
                }
            }
        }

        public string GetHtml(string url, string encode, string page)
        {
            if (page == "1" && !url.Contains("www.snjsjy.com"))        //首页特殊逻辑，如果分页地址带下划线，首页地址不带下划线
                if (url.Contains("_{0}"))
                    url = url.Replace("_{0}", "");

            var request = (HttpWebRequest)WebRequest.Create(string.Format(url, page));
            CookieContainer cc = new CookieContainer();
            request.Method = "Get";
            request.ContentType = "text/html; charset=utf-8";
            request.ContentLength = 0;
            request.CookieContainer = cc;
            request.KeepAlive = true;
            request.Host = GetDomainName(url);
            request.AllowAutoRedirect = false;

            var response = (HttpWebResponse)request.GetResponse();
            StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encode));
            string html = streamReader.ReadToEnd();

            if (string.IsNullOrWhiteSpace(html))
            {
                return string.Empty;
            }

            if (response.StatusCode == HttpStatusCode.Redirect)
            {
                string _302url = "";
                string detailurl = GetElement("<a href=\"(?<v>.*?)\">", html);
                if (!url.Contains("http"))
                    _302url = "http://" + request.Host + GetElement("<a href=\"(?<v>.*?)\">", html);
                else
                {
                    _302url = GetElement("<a href=\"(?<v>.*?)\">", html);
                }
                html = GetHtml(_302url.Replace("&amp;", "&"), encode, page);
            }
            html = html.Replace("\r", string.Empty);
            html = html.Replace("\n", string.Empty);
            html = html.Replace("\t", string.Empty);
            html = html.Replace("jsonp144(", string.Empty);
            html = html.Replace("lt", string.Empty);
            html = html.Replace(";", string.Empty);
            html = html.Replace("font", string.Empty);
            html = html.Replace("&", string.Empty);
            html = html.Replace("color", string.Empty);
            html = html.Replace("=", string.Empty);
            html = html.Replace("red", string.Empty);
            html = html.Replace("&gt", string.Empty);
            html = html.Replace("/font]", string.Empty);
            html = html.Replace("/gt", string.Empty);
            html = html.Replace("gt", string.Empty);
            html = html.Replace("[ gt", string.Empty);
            html = html.Replace("[ gt", string.Empty);
            html = html.Replace("[求购]", string.Empty);
            html = html.TrimEnd(')');
            streamReader.Close();

            return html;
        }

        public static string GetDomainName(string url)
        {
            if (url == null)
            {
                throw new Exception("输入的url为空");
            }
            Regex reg = new Regex(@"(?<=://)([\w-]+\.)+[\w-]+(?<=/?)");
            return reg.Match(url, 0).Value.Replace("/", string.Empty);
        }

        public string GetElement(string regexString, string html)
        {
            var regexitems = regexString.Split(',');
            Regex regex = null;
            MatchCollection matchs = null;

            foreach (var regexitem in regexitems)
            {
                regex = new Regex(regexitem, RegexOptions.None);

                matchs = regex.Matches(html);
                if (matchs.Count > 0)
                {
                    return matchs[0].Groups["v"].Value;
                }
            }

            return "";
        }

        private int AddUser(IdleFish_UserBO userBo)
        {
            Mercury.Model.Sys_Users user = new Mercury.BLL.Sys_Users().GetModelList(String.Format(" UserNickName='{0}' ", userBo.userNick)).FirstOrDefault(); ;

            if (user == null)
            {
                Mercury.Model.Sys_Users userModel = new Mercury.Model.Sys_Users();
                userModel.UserName = userBo.userNick.Trim();
                userModel.UserNickName = userBo.userNick.Trim();
                userModel.ContacterName = userBo.userNick.Trim();
                userModel.UserGUID = new Guid();
                userModel.UserLoginType = 1;
                userModel.CreateByPlatform = "1";
                userModel.Password = "576672F92FB5DD33";
                userModel.OnCreate = DateTime.Now;
                userModel.QQ = "715794512";
                userModel.UserProfile = string.Format("//wwc.alicdn.com/avatar/getAvatar.do?userNick={0}", userBo.userNick);
                return new Mercury.BLL.Sys_Users().Add(userModel);
            }
            else
            {
                user.UserProfile = string.Format("//wwc.alicdn.com/avatar/getAvatar.do?userNick={0}", userBo.userNick);
                new Mercury.BLL.Sys_Users().Update(user);
                return user.Sys_UserId;
            }
        }

        private void AddPurchaseOrder(int productCategoryId, int userId, string contactName, IdleFish_ItemBO item)
        {
            Mercury.Model.PurchaseOrder purchaseOrder = new Mercury.Model.PurchaseOrder();
            try
            {
                string cityName = Regex.Replace(item.provcity.Substring(2), @"[^\u4e00-\u9fa5]", ""); //只留汉字
                Mercury.Model.Citys city = new Mercury.BLL.Citys().GetModelList(string.Format(" cityName like '%{0}%'", cityName)).FirstOrDefault();
                purchaseOrder.RecvCityId = (int)city.CityID;
                purchaseOrder.RecvProvinceId = (int)city.ProvinceID;
            }
            catch
            {
                //找不到城市的数据直接过滤
                return;
            }
            purchaseOrder.Address = item.provcity;
            purchaseOrder.Budget = item.price;
            purchaseOrder.CreateTime = DateTime.Now;
            purchaseOrder.Description = string.Format("<p> {0} </p>", item.describe);
            purchaseOrder.Image1 = item.imageUrl;
            purchaseOrder.Image2 = item.itemUrl;
            purchaseOrder.PublishTime = DateTime.Now;
            string title = item.title.Replace("[ 求购]", string.Empty).Replace("[", string.Empty).Replace("]", string.Empty).Replace("【", string.Empty).Replace("】", string.Empty).Trim();

            purchaseOrder.Title = title;
            purchaseOrder.SysUserId = userId;
            purchaseOrder.ProductCategoryId = productCategoryId;
            //purchaseOrder.Status = 1;
            purchaseOrder.Email = "715794512@qq.com";
            purchaseOrder.CompanyName = "个人";
            purchaseOrder.ContacterName = contactName;
            //purchaseOrder.PurchaseType = 1;

            new Mercury.BLL.PurchaseOrder().Add(purchaseOrder);
        }


        //private void dd(string url)
        //{
        //    HtmlDocument doc = webClient.Load(url);
        //    HtmlNodeCollection hrefList = doc.DocumentNode.SelectNodes("//div[@class='ks-waterfall ks-waterfall-col-0 ks-waterfall-col-first']");
        //    string dd = "";
        //}

    }
}