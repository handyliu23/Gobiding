using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Mercury.Model;

namespace Mercury.Web
{
    public partial class IdleFish : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUrl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSpiderUrl.Text))
            {
                int pageStart = string.IsNullOrWhiteSpace(txtPageStart.Text) ? 1 : int.Parse(txtPageStart.Text);

                int pageEnd = string.IsNullOrWhiteSpace(txtPageEnd.Text) ? 1 : int.Parse(txtPageEnd.Text);

                for (int p = pageStart; p <= pageEnd; p++)
                {

                    string context = GetHtml(txtSpiderUrl.Text, txtEncode.Text, p.ToString());

                    txtUrlResponse.Text = context;

                    IdleFishBO idleFishBo = Newtonsoft.Json.JsonConvert.DeserializeObject<IdleFishBO>(context);
                    List<string> userNickNames = new List<string>();

                    int h = 1;
                    if (idleFishBo != null)
                    {
                        idleFishBo.idle.ForEach(i =>
                        {
                            if (h > 1) return;

                            if (i.item.price < 800 || string.IsNullOrWhiteSpace(i.item.title)
                                || i.item.title.Trim().Length < 8) return;

                            if (userNickNames.Contains(i.user.userNick)) return;

                            userNickNames.Add(i.user.userNick);

                            int userId = AddUser(i.user);
                            AddPurchaseOrder(userId, i.user.userNick, i.item);
                        });
                    }
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
            Model.Sys_Users user = new BLL.Sys_Users().GetModelList(String.Format(" UserNickName='{0}' ", userBo.userNick)).FirstOrDefault(); ;

            if (user == null)
            {
                Model.Sys_Users userModel = new Sys_Users();
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
                return new BLL.Sys_Users().Add(userModel);
            }
            else
            {
                user.UserProfile = string.Format("//wwc.alicdn.com/avatar/getAvatar.do?userNick={0}", userBo.userNick);
                new BLL.Sys_Users().Update(user);
                return user.Sys_UserId;
            }
        }

        private void AddPurchaseOrder(int userId, string contactName, IdleFish_ItemBO item)
        {
            PurchaseOrder purchaseOrder = new PurchaseOrder();
            try
            {
                string cityName = Regex.Replace(item.provcity.Substring(2), @"[^\u4e00-\u9fa5]", ""); //只留汉字
                Model.Citys city = new BLL.Citys().GetModelList(string.Format(" cityName like '%{0}%'", cityName)).FirstOrDefault();
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
            //purchaseOrder.ProductCategoryId = 1;
            //purchaseOrder.Status = 1;
            purchaseOrder.Email = "715794512@qq.com";
            purchaseOrder.CompanyName = "个人";
            purchaseOrder.ContacterName = contactName;
            //purchaseOrder.PurchaseType = 1;

            new Mercury.BLL.PurchaseOrder().Add(purchaseOrder);
        }
    }
}