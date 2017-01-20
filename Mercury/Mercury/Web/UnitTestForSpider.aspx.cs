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

namespace Mercury.Web
{
    public partial class UnitTestForSpider : System.Web.UI.Page
    {
        private string detailcontent = "";

        public static string GetDomainName(string url)
        {
            if (url == null)
            {
                throw new Exception("输入的url为空");
            }
            Regex reg = new Regex(@"(?<=://)([\w-]+\.)+[\w-]+(?<=/?)");
            return reg.Match(url, 0).Value.Replace("/", string.Empty);
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
                if(!url.Contains("http"))
                    _302url = "http://" + request.Host + GetElement("<a href=\"(?<v>.*?)\">", html);
                else
                {
                    _302url = GetElement("<a href=\"(?<v>.*?)\">", html);
                }
                html = GetHtml(_302url.Replace("&amp;","&"), encode, page);
            }
            html = html.Replace("\r", string.Empty);
            html = html.Replace("\n", string.Empty);
            html = html.Replace("\t", string.Empty);
            streamReader.Close();

            return html;
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnUrl_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtSpiderUrl.Text))
            {
                if(txtHttpMethod.Text.ToLower().Equals("post"))
                    txtUrlResponse.Text = GetHtmlByPost(txtSpiderUrl.Text, txtHttpMethod.Text, int.Parse(txtPageNumber.Text), txtPageParameter.Text);
                else
                    txtUrlResponse.Text = GetHtml(txtSpiderUrl.Text, txtEncode.Text, txtPageNumber.Text);
            }
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

        public string GetHtmlByPost(string url, string encode, int page, string pageparameter)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            CookieContainer cc = new CookieContainer();
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.CookieContainer = cc;
            request.KeepAlive = true;
            request.UserAgent =
                "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36";
            request.Host = GetDomainName(url);
            request.AllowAutoRedirect = false;
            request.Referer = url;
            request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";

            StringBuilder builder = new StringBuilder();
            builder.Append(string.Format(pageparameter, page));
            byte[] data = Encoding.UTF8.GetBytes(builder.ToString());

            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(data, 0, data.Length);
                reqStream.Close();
            }
            HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
            Stream stream = resp.GetResponseStream();
            //获取响应内容  
            string html = "";
            using (StreamReader reader = new StreamReader(stream, Encoding.UTF8))
            {
                html = reader.ReadToEnd();
            }

            html = html.Replace("\r", string.Empty);
            html = html.Replace("\n", string.Empty);
            html = html.Replace("\t", string.Empty);

            return html;
        }

        protected void btnListExpression_Click(object sender, EventArgs e)
        {
            StringBuilder builder = new StringBuilder();

            var regex = new Regex(txtListExpression.Text, RegexOptions.None);

            var matchs = regex.Matches(txtUrlResponse.Text);
            if (matchs.Count > 0)
            {
                for (int i = 0; i < matchs.Count; i++)
                {
                    var g = matchs[i].Groups["v"];
                    builder.Append(g.Value);
                    break;
                }
            }

            txtResponse2.Text = builder.ToString();

        }

        protected void btnDetailPrefix_Click(object sender, EventArgs e)
        {
            string detailurl = txtResponse2.Text.Replace("&amp;","&");
            txtResponse3.Text = GetHtml(txtDetailURLPrefix.Text + detailurl, txtEncode.Text, ""); 
        }

        protected void btnTitle_Click(object sender, EventArgs e)
        {
            txtResponse4.Text = GetElement(txtTitleExpression.Text, txtResponse3.Text);

        }

        protected void btnPublishTime_Click(object sender, EventArgs e)
        {
            txtResponse5.Text = GetElement(txtPublishExpression.Text, txtResponse3.Text);
        }

        protected void btnContent_Click(object sender, EventArgs e)
        {
            txtResponse6.Text = GetElement(txtContentExpression.Text, txtResponse3.Text);
        }

    }
}