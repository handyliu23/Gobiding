using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using Mercury.Model;
using System.Data;
using System.Globalization;
using System.IO.Compression;
using Mercury.BLL;

namespace MercurySpider
{
    class Program
    {
        List<Mercury.Model.SmartCategorys> smarts = new Mercury.BLL.SmartCategorys().GetModelList("");
        private DataSet citys = new Mercury.BLL.Citys().GetAllList();
        private DataSet provinces = new Mercury.BLL.Provinces().GetAllList();
        private Mercury.BLL.Spiders spiderBussiness = new Mercury.BLL.Spiders();
        private Mercury.BLL.Bids bidsBussiness = new Mercury.BLL.Bids();
        private Mercury.BLL.CatchCompany catchCompanyBussiness = new Mercury.BLL.CatchCompany();
        private Mercury.BLL.SpiderLogs loger = new Mercury.BLL.SpiderLogs();
        private Mercury.BLL.Provinces provinceBussiness = new Mercury.BLL.Provinces();
        private Mercury.BLL.Hearts heartService = new Mercury.BLL.Hearts();

        public static string GetDomainName(string url)
        {
            if (url == null)
            {
                throw new Exception("输入的url为空");
            }
            Regex reg = new Regex(@"(?<=://)([\w-]+\.)+[\w-]+(?<=/?)");
            return reg.Match(url, 0).Value.Replace("/", string.Empty);
        }

        public List<Mercury.Model.Spiders> GetSpiderURL()
        {
            return spiderBussiness.GetModelList("");
        }

        public string GetHtml(string url, string encode, string page, List<HttpCookie> cookies)
        {
            try
            {
                if (page == "1" && !url.Contains("www.snjsjy.com") &&
                    !url.Contains("www.ccgp-hebei.gov.cn"))        //首页特殊逻辑，如果分页地址带下划线，首页地址不带下划线
                    if (url.Contains("_{0}"))
                        url = url.Replace("_{0}", "");

                var request = (HttpWebRequest)WebRequest.Create(string.Format(url, page));
                request.Host = GetDomainName(url);

                CookieContainer cc = new CookieContainer();
                if (cookies != null && cookies.Count > 0)
                {
                    foreach (var cookie in cookies)
                    {
                        Cookie clientCookie = new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain == null ? request.Host : cookie.Domain);
                        cc.Add(clientCookie);
                    }
                }

                request.Method = "Get";
                if (!url.Contains("www.jzggzy.cn") && !url.Contains("222.178.87.199") && !url.Contains("www.wzzbtb.com") && !url.Contains("www.zjggzy.gov.cn")
                    && !url.Contains("www.zjbid.cn") && !url.Contains("www.gzggzy.cn") && !url.Contains("www.jszb.com"))
                {
                    request.ContentType = "text/html; charset=utf-8";
                }
                if (url.Contains("www.gzggzy.cn"))
                {
                    //request.Headers.Add("Accept-Encoding", "gzip, deflate, sdch");
                    request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                    request.UserAgent =
                        "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36";
                }

                request.ContentLength = 0;
                request.CookieContainer = cc;
                request.KeepAlive = true;
                request.AllowAutoRedirect = false;
                request.Timeout = 20000;

                if (url.Contains("www.rzzfcg.gov.cn") ||
                    url.Contains("zfcgjj.snjsjy.com") || url.Contains("pxzyjy.gov.cn") || url.Contains("dyxggzyjy.gov.cn") || url.Contains("ajjyzx.com.cn") || url.Contains("shggzyjy.com")
                    || url.Contains("sncsjyzx.com") || url.Contains("rizhao.gov.cn"))
                {
                    request.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36";
                }
                if (url.Contains("ccgp-shanghai"))
                {
                    request.Headers.Add("Accept-Language", "zh-CN");
                    request.Referer = url;
                    request.Accept =
                        "application/x-ms-application, image/jpeg, application/xaml+xml, image/gif, image/pjpeg, application/x-ms-xbap, application/vnd.ms-excel, application/vnd.ms-powerpoint, application/msword, */*";
                    encode = "gb2312";
                }
                if (url.Contains("ynggzy.com"))
                {
                    encode = "gbk";
                }
                if (url.Contains("hljcg.gov.cn"))
                {
                    request.Referer = "http://www.hljcg.gov.cn/xwzs!index.action";
                }

                var response = (HttpWebResponse)request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.GetEncoding(encode));
                Thread.Sleep(100);
                string html = streamReader.ReadToEnd();

                if (response.StatusCode == HttpStatusCode.Redirect)
                {
                    string _302url = "";
                    string detailurl = GetElement("<a href=\"(?<v>.*?)\">", html);
                    if (detailurl.Contains("404"))
                    {
                        return "";
                    }
                    if (!detailurl.ToLower().Contains("http") && !detailurl.ToLower().Contains(".com"))
                        _302url = "http://" + request.Host + detailurl;
                    else
                    {
                        _302url = GetElement("<a href=\"(?<v>.*?)\">", html);
                    }

                    if (detailurl.Contains("sczfcg"))
                    {
                        encode = "utf-8";
                    }
                    html = GetHtml(_302url.Replace("&amp;", "&"), encode, page, null);
                }
                if (html.Contains("ZtbggxxDetail_content1") && html.Contains("安徽合肥公共资源交易中心"))
                {
                    string iframeurl = GetElement("<iframe src='(?<v>.*?)' id", html).Replace("..", "");
                    html = GetHtml("http://" + request.Host + "/hfzbtb" + iframeurl, encode, page, null);
                }
                if (url.Contains("getConte") && html.Contains("珠海市财政局"))
                {
                    string iframeurl = GetElement("<iframe(.*?) src=\"(?<v>.*?)\"", html);
                    html = GetHtml("http:www.zhgpo.gov.cn" + iframeurl, encode, page, null);
                }
                if (!url.Contains("List") && html.Contains("株洲市招标投标管理局"))
                {
                    string iframeurl = GetElement("<a href=\"(?<v>.*?)\"", html);
                    html = GetHtml("http://www.zzzyjy.cn" + iframeurl, "GBK", page, null);
                }
                if (url.Contains("caigou.my.gov.cn"))
                {
                    string iframeurl = GetElement("src='(?<v>.*?)'></iframe>", html);
                    if (!string.IsNullOrEmpty(iframeurl))
                        html = GetHtml("http://caigou.my.gov.cn/" + iframeurl, encode, page, null);
                }

                html = html.Replace("\r", string.Empty);
                html = html.Replace("\n", string.Empty);
                html = html.Replace("\t", string.Empty);
                streamReader.Close();
                response.Close();
                return html;
            }
            catch (Exception err)
            {
                return "";
            }
        }

        public void ExceuteList(Mercury.Model.Spiders spider)
        {
            if (spider.SpiderType == 2) //增长式
            {
                int i = 0;
                while (i < spider.PageCount)
                {
                    try
                    {
                        ExceuteDetail(string.Format(spider.SpiderUrl, int.Parse(spider.PageParameter) + i),
                        spider.EncodeType,
                        spider,
                        "",
                        "",
                        "");
                        i++;
                    }
                    catch (Exception err)
                    {
                        spider.PageParameter = (int.Parse(spider.PageParameter) + i).ToString();
                        spiderBussiness.Update(spider);
                        break;
                    }
                }

                spider.PageParameter = (int.Parse(spider.PageParameter) + spider.PageCount).ToString();
                spiderBussiness.Update(spider);
                return;
            }

            for (int page = 1; page <= spider.PageCount; page++)
            {
                Console.WriteLine("ExceuteList Page>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>" + spider.SpiderId + spider.SpiderName + ":" + page);
                string html = "";

                if (spider.SpiderUrl.Contains("chinabidding"))
                {
                    Thread.Sleep(3000);
                }

                try
                {
                    #region 获取列表页

                    var model = spiderBussiness.GetModel(spider.SpiderId);
                    model.LastRunTime = DateTime.Now;
                    spiderBussiness.Update(model);

                    List<HttpCookie> requestCookies = new List<HttpCookie>();
                    if (spider.HttpMethod.ToLower().Equals("post"))
                    {
                        if (spider.SpiderName == "江西省政府采购网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "1lzoke45epkyfs45e4rrtafo"));
                            requestCookies.Add(new HttpCookie("__CSRFCOOKIE", "0ee1aa3e-5fa3-4ca3-8f14-f4d59cd429c2"));
                        }
                        if (spider.SpiderName == "鹰潭市公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "zxop4r45ear01245kjs2kg55"));
                        }
                        if (spider.SpiderName == "吉林省公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "hdxfmn55sgvhoz45hniw2ze5"));
                        }
                        if (spider.SpiderName == "周口市公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "nr1vgrfzlhaldjyafzoz4d55"));
                            requestCookies.Add(new HttpCookie("__CSRFCOOKIE", "edef3099-21f5-4291-92b6-9332dc81d918"));
                            requestCookies.Add(new HttpCookie("_gscu_95861235", "82735999bus3ir20"));
                            requestCookies.Add(new HttpCookie("_gscs_95861235", "8273599946chpo20|pv:4"));
                            requestCookies.Add(new HttpCookie("_gscbrs_95861235", "1"));
                        }
                        if (spider.SpiderName == "上饶市政府采购网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "xxcmih45bcghrc45hbn054rm"));
                            requestCookies.Add(new HttpCookie("__CSRFCOOKIE", "a8d948c5-fdba-45f4-a48e-dfbaac112d52"));
                        }

                        if (spider.SpiderName == "广东省政府采购网")
                        {
                            requestCookies.Add(new HttpCookie("PortalCookie", "xrQ6IogJMb1R7est_6B34fk_IXkvt99XWB-B7faapV2h3fbbIDqC!1576892664"));
                            requestCookies.Add(new HttpCookie("ManageSystemCookie", "7Ec6Iopa-sPsmWICEM7N2vfxZ9TgfloGY2SoH64V48iqC6zY-WJ0!-868736256"));
                            requestCookies.Add(new HttpCookie("_gscu_152972740", "=827391302ecb3i72"));
                            requestCookies.Add(new HttpCookie("_gscs_152972740", "82739130y0jkrc72|pv:3"));
                            requestCookies.Add(new HttpCookie("_gscbrs_152972740", "1"));
                        }

                        if (spider.SpiderName == "芜湖市政府采购网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "m2bjmn55vo2cz3qf03t2jfu0"));
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId_NS_Sig", "vVUOZ4arTFjHJQHG"));
                        }
                        if (spider.SpiderName == "黔东南公共资源网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "xqfd0yvhgb1fbl2xnyjtjo55"));
                            requestCookies.Add(new HttpCookie("_gscu_1534320378", "83106583rgcmus10"));
                            requestCookies.Add(new HttpCookie("_gscs_1534320378", "83106583abb6vu10|pv:7"));
                            requestCookies.Add(new HttpCookie("_gscbrs_1534320378", "_gscbrs_1534320378"));
                        }
                        if (spider.SpiderName == "钦州市公共资源网")
                        {
                            requestCookies.Add(new HttpCookie("ASPSESSIONIDSQRSSTST", "EFMDGAFDOMJALCMONGGEACJI"));
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "xwxx2r55xe0u5s45bx4uwx55"));
                            requestCookies.Add(new HttpCookie("__CSRFCOOKIE", "536e92fc-c5a1-4750-abc6-0a253e7a93b6"));
                        }
                        if (spider.SpiderName == "济宁市公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "z0c3351tey4xwqrallwwpasw"));
                            requestCookies.Add(new HttpCookie("_gscu_32821163", "831671260vekdz11"));
                            requestCookies.Add(new HttpCookie("_gscs_32821163", "83167126aqhwrb11|pv:10"));
                            requestCookies.Add(new HttpCookie("_gscbrs_32821163", "1"));
                        }
                        if (spider.SpiderName == "淮安市公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "knx0iu45g4uhnx4555deoy55"));
                        }
                        if (spider.SpiderName == "泉州市公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("JSESSIONID", "E4174AA297DA8466F0BD9BA63766888E"));
                            requestCookies.Add(new HttpCookie("_gscu_1695014749", "83613081g23nfr12"));
                            requestCookies.Add(new HttpCookie("_gscs_1695014749", "836130818s80r612|pv:11"));
                            requestCookies.Add(new HttpCookie("_gscbrs_1695014749", "1"));
                        }
                        if (spider.SpiderName == "江西省公共资源交易中心")
                        {
                            requestCookies.Add(new HttpCookie("_gscu_1592055701", "8354817442so3t65"));
                            requestCookies.Add(new HttpCookie("_gscbrs_1592055701", "1"));
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "hwkg0g45lgx1oo45nuunuemm"));
                            requestCookies.Add(new HttpCookie("__CSRFCOOKIE", "450df5fc-2891-42d0-8fa5-0c2299c5f498"));
                            requestCookies.Add(new HttpCookie("_gscu_705762682", "83549157ijyk6023"));
                            requestCookies.Add(new HttpCookie("_gscs_705762682", "t8370807369v6eo24|pv:4"));
                            requestCookies.Add(new HttpCookie("_gscbrs_705762682", "1"));
                        }

                        if (spider.SpiderName == "大连市政府采购网")
                        {
                            requestCookies.Add(new HttpCookie("_gscu_2122849726", "83721672hmnlw613"));
                            requestCookies.Add(new HttpCookie("_gscs_2122849726", "837216723ekv0k13|pv:2"));
                            requestCookies.Add(new HttpCookie("_gscbrs_2122849726", "1"));
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "ajfbigjvv1gmf345uu1huw45"));
                            requestCookies.Add(new HttpCookie("_gscu_1258514303", "83721715eccpwb17|pv:7"));
                            requestCookies.Add(new HttpCookie("_gscbrs_1258514303", "1"));
                        }

                        if (!string.IsNullOrEmpty(spider.Cookies))
                        {
                            List<string> cookiestr = spider.Cookies.Split(';').ToList();
                            foreach (string cookie in cookiestr)
                            {
                                List<string> itemcookistr = cookie.Split('=').ToList();
                                if (itemcookistr.Count > 1)
                                {
                                    requestCookies.Add(new HttpCookie(itemcookistr.ElementAt(0).Trim(), itemcookistr.ElementAt(1).Trim()));
                                }
                            }
                        }

                        html = GetHtmlByPost(spider.SpiderUrl, spider.EncodeType, page, spider.PageParameter, requestCookies);
                    }
                    else
                    {
                        if (spider.SpiderName == "甘肃省政府采购网")
                        {
                            //requestCookie = new HttpCookie("JSESSIONID", "1039A176BEA4D346BD1E8D3B22C0633E");
                            //html = GetHtml(string.Format(spider.SpiderUrl, 20 * (page - 1)), spider.EncodeType, page.ToString(), requestCookie);
                        }
                        if (spider.SpiderName == "山东公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("JSESSIONID", "3684a460e94345b46e8a358e898359fb"));
                            requestCookies.Add(new HttpCookie("DedeUserID", "21580"));
                            requestCookies.Add(new HttpCookie("DedeUserID__ckMd5", "ed0faf7f7ab5af27"));
                            requestCookies.Add(new HttpCookie("DedeLoginTime", "1482664582"));
                            requestCookies.Add(new HttpCookie("DedeLoginTime__ckMd5", "e3d8882ec6acd966"));
                            requestCookies.Add(new HttpCookie("CNZZDATA1497705", "cnzz_eid%3D87202838-1482659639-http%253A%252F%252Fwww.sdggzy.com%252F%26ntime%3D1482659639"));
                        }
                        if (spider.SpiderName == "陕西省政府采购网")
                        {
                            requestCookies.Add(new HttpCookie("JSESSIONID", "D06DC6FCC906F066D3154C174F9042EC"));
                        }
                        if (spider.SpiderName == "重庆市工程建设交易网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "kygfzk45ykyujx45nv2sv445"));
                            requestCookies.Add(new HttpCookie("_gscu_1893208869", "82849962ea25u845"));
                            requestCookies.Add(new HttpCookie("_gscs_1893208869", "82849962zdxpmy45|pv:10"));
                            requestCookies.Add(new HttpCookie("_gscbrs_1893208869", "1"));
                            requestCookies.Add(new HttpCookie("Hm_lvt_b364065e18d977e04ec2833b5e4e5a07", "1482849962"));
                            requestCookies.Add(new HttpCookie("Hm_lpvt_b364065e18d977e04ec2833b5e4e5a07", "1482851246"));
                        }
                        if (spider.SpiderName == "焦作市公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "0gyylbwfrpxde0gjtv5rf0pa"));
                            requestCookies.Add(new HttpCookie("__CSRFCOOKIE", "41470a8c-1ffb-45d2-930a-6b568db5017d"));
                            requestCookies.Add(new HttpCookie("INSPURCLOUDSLB", "GGZYJY02|WGdrn|WGdqo"));
                            requestCookies.Add(new HttpCookie("_gscu_664959170", "83172575gsq7d448"));
                            requestCookies.Add(new HttpCookie("_gscs_664959170", "83172575irr9qd48|pv:8"));
                            requestCookies.Add(new HttpCookie("_gscbrs_664959170", "1"));
                        }
                        if (spider.SpiderName == "湖州市公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "ivv2r3tsfv1aotj5vzlqwvmt"));
                            requestCookies.Add(new HttpCookie("__CSRFCOOKIE", "ac545d9f-67a7-4977-8ffd-1d4d3c23d57b"));
                            requestCookies.Add(new HttpCookie("_gscu_1709246437", "83179382r991v937"));
                            requestCookies.Add(new HttpCookie("_gscs_1709246437", "83179382dt0lt037|pv:23"));
                            requestCookies.Add(new HttpCookie("_gscbrs_1709246437", "1"));
                        }
                        if (spider.SpiderName == "重庆市公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("JSESSIONID", "F9326274A5C4F6179C2B5112D01C9E1C"));
                            requestCookies.Add(new HttpCookie("_CSRFCOOKIE", "604B7C1A39C83AED68CBC486A1D71D9EAA518E88"));
                            requestCookies.Add(new HttpCookie("CNZZDATA1260771780", "400380580-1483193217-null%7C1483193217"));
                        }
                        if (spider.SpiderName == "呼伦贝尔市公共资源交易中心")
                        {
                            requestCookies.Add(new HttpCookie("JSESSIONID", "C7A6F10844EA28FBD07044F951CC2D92"));
                            requestCookies.Add(new HttpCookie("_gscu_1864733377", "83260886t8ycfi13"));
                            requestCookies.Add(new HttpCookie("_gscs_1864733377", "83260886huutn713|pv:3"));
                            requestCookies.Add(new HttpCookie("_gscbrs_1864733377", "1"));
                            requestCookies.Add(new HttpCookie("clientlanguage", "zh_CN"));
                        }
                        if (spider.SpiderName == "黑龙江省政府采购网" || spider.SpiderUrl.Contains("www.hljcg.gov.cn"))
                        {
                            requestCookies.Add(new HttpCookie("JSESSIONID", "0qbjYpLGQzfQJCtQRwjDMsKF7TLYB20JRpLNc7cQvrcKryXNK0dJ!10983391!-364480508"));
                            requestCookies.Add(new HttpCookie("_gscu_1363291358", "832792455wxkqt10"));
                            //requestCookies.Add(new HttpCookie("_gscs_1363291358", "832792457jtj3w10|pv:251"));
                            requestCookies.Add(new HttpCookie("_gscbrs_1363291358", "1"));
                        }
                        if (spider.SpiderName == "遂宁市公共资源交易网")
                        {
                            requestCookies.Add(new HttpCookie("AspxAutoDetectCookieSupport", "1"));
                            requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "tjlzlntaegygxvssckooxbcc"));
                            requestCookies.Add(new HttpCookie("_gscu_1732904760", "8359691729lgtz98"));
                            requestCookies.Add(new HttpCookie("_gscs_1732904760", "t83598891w81juc87|pv:8"));
                            requestCookies.Add(new HttpCookie("_gscbrs_1732904760", "1"));
                        }

                        html = GetHtml(spider.SpiderUrl, spider.EncodeType, page.ToString(), requestCookies);

                        if (string.IsNullOrEmpty(html))
                            continue;
                    }
                    #endregion
                }
                catch (Exception err)
                {
                    Mercury.Model.SpiderLogs log = new Mercury.Model.SpiderLogs();
                    log.IsSuccess = false;
                    log.Message = "列表页访问失败" + DateTime.Now.ToString();
                    log.SpiderName = spider.SpiderName;
                    log.SpiderLog = spider.SpiderId + ":" + spider.SpiderName + ":" + spider.SpiderUrl;
                    log.CreateTime = DateTime.Now;
                    loger.Add(log);

                    continue;
                }
                Regex regex = null;
                Group g = null;
                string v = null;
                string[] values = null;
                MatchCollection matchs = null;
                MatchCollection provincesmatch = null;
                MatchCollection bidCompanyNames = null;
                MatchCollection bidTitles = null;
                MatchCollection bidTitleTypes = null;
                MatchCollection bidPubTimes = null;

                regex = new Regex(spider.ListExpression, RegexOptions.None);

                BeatHeart();
                matchs = regex.Matches(html);
                if (matchs.Count > 0)
                {
                    #region 列表页数据纠正
                    if (spider.SpiderName == "中国政府采购网")
                    {
                        regex = new Regex("地域：<span>(?<v>.*?)</span> ", RegexOptions.None);
                        provincesmatch = regex.Matches(html);

                        regex = new Regex("采购人：<span>(?<v>.*?)</span>", RegexOptions.None);
                        bidCompanyNames = regex.Matches(html);
                    }
                    if (spider.SpiderName == "山东省政府采购网")
                    {
                        //title从列表获取
                        regex = new Regex("title='(?<v>.*?)' class='aa'", RegexOptions.None);
                        bidTitles = regex.Matches(html);
                    }
                    if (spider.SpiderName == "上海市政府采购网" || spider.SpiderName == "天津市政府采购网"
                        || spider.SpiderName == "山东省政府采购网")
                    {
                        //title从列表获取
                        regex = new Regex(spider.TitleExpression, RegexOptions.None);
                        bidTitles = regex.Matches(html);

                        regex = new Regex(spider.PublishExpression);
                        bidPubTimes = regex.Matches(html);
                    }
                    if (spider.SpiderName == "芜湖市政府采购网")
                    {
                        //title从列表获取
                        regex = new Regex("title=\"(?<v>.*?)</a>                        ", RegexOptions.None);
                        bidTitles = regex.Matches(html);
                    }
                    if (spider.SpiderName == "甘肃省政府采购网")
                    {
                        regex = new Regex("<p><span><strong>(?<v>.*?)</li>");
                        bidTitleTypes = regex.Matches(html);
                    }
                    if (spider.SpiderName == "福建省政府采购网")
                    {
                        regex = new Regex("\"time\":\"(?<v>.*?)\",");
                        bidPubTimes = regex.Matches(html);
                    }
                    if (spider.SpiderId > 79 || spider.SpiderName == "中华人民共和国财政部" || spider.SpiderName == "无锡市政府采购网" || spider.SpiderName == "深圳市政府采购网")
                    {
                        if (spider.SpiderName != "南京市公共资源交易中心" && spider.SpiderName != "广元市公共资源交易网" && spider.SpiderName != "厦门市政府采购网"
                            && spider.SpiderName != "大连市建设工程信息网"
                            )
                        {
                            regex = new Regex(spider.PublishExpression);
                            bidPubTimes = regex.Matches(html);
                        }
                    }
                    if (spider.SpiderId > 67 || spider.SpiderName == "中国政府采购网" || spider.SpiderName == "中华人民共和国财政部" || spider.SpiderName == "深圳市政府采购网")
                    {
                        regex = new Regex(spider.TitleExpression, RegexOptions.None);
                        bidTitles = regex.Matches(html);
                    }

                    #endregion

                    for (int i = 0; i < matchs.Count; i++)
                    {
                        if (spider.SpiderName == "烟台市政府采购网")
                        {
                            if (i > spider.CountPerPage) break;
                        }
                        if (spider.SpiderName == "北京市政府采购网")
                        {
                            if (i > 30)
                                break;
                        }
                        #region 获取列表页标题，日期
                        string _bidCompanyName = "";
                        string _bidPubTime = "";

                        if (spider.SpiderName == "中国政府采购网")
                        {
                            spider.ProvinceId = ParseProvinceId(provincesmatch[i].Groups["v"].Value);
                            _bidCompanyName = bidCompanyNames[i].Groups["v"].Value;
                        }
                        string _bidTitle = "";
                        if (spider.SpiderName == "山东省政府采购网" || spider.SpiderName == "芜湖市政府采购网" ||
                            spider.SpiderId > 67 || spider.SpiderName == "中国政府采购网" || spider.SpiderName == "中华人民共和国财政部" || spider.SpiderName == "深圳市政府采购网")
                        {
                            _bidTitle = bidTitles[i].Groups["v"].Value;
                        }
                        if (spider.SpiderName == "上海市政府采购网" || spider.SpiderName == "天津市政府采购网" || spider.SpiderName == "山东省政府采购网")
                        {
                            _bidTitle = bidTitles[i].Groups["v"].Value;
                            _bidPubTime = bidPubTimes[i].Groups["v"].Value;
                            if (spider.SpiderName == "山东省政府采购网" && _bidPubTime.Contains("img"))
                            {
                                _bidPubTime = GetElement("(.*?)>(?<v>.*?)", _bidPubTime);
                            }
                        }
                        if (spider.SpiderName == "甘肃省政府采购网")
                        {
                            if (bidTitleTypes[i].Groups["v"].Value.Contains("其他公告"))
                                continue;
                        }
                        if (spider.SpiderName == "福建省政府采购网")
                        {
                            try
                            {
                                _bidPubTime = bidPubTimes[i].Groups["v"].Value;
                                if (!string.IsNullOrEmpty(_bidPubTime))
                                {
                                    _bidPubTime = _bidPubTime.Substring(0, 4) + "-" + _bidPubTime.Substring(4, 2) + "-" +
                                                  _bidPubTime.Substring(6, 2);
                                }
                            }
                            catch (Exception e) { }
                        }

                        if ((spider.SpiderId > 79 || spider.SpiderName == "中华人民共和国财政部" || spider.SpiderName == "无锡市政府采购网" || spider.SpiderName == "深圳市政府采购网")
                            && spider.SpiderName != "内蒙古政府采购网" && spider.SpiderName != "济南市政务服务中心" && spider.SpiderName != "广元市公共资源交易网" && spider.SpiderName != "厦门市政府采购网"
                            && spider.SpiderName != "大连市建设工程信息网")
                        {
                            if (spider.SpiderName != "南京市公共资源交易中心")
                            {
                                _bidPubTime = bidPubTimes[i].Groups["v"].Value.Trim();
                            }
                            if (spider.SpiderName == "广东招投标监管网")
                            {
                                if (int.Parse(_bidPubTime.Substring(0, 2)) > 6)
                                    _bidPubTime = DateTime.Now.Year - 1 + "-" + _bidPubTime;
                                else
                                {
                                    _bidPubTime = DateTime.Now.Year + "-" + _bidPubTime;
                                }
                            }
                            if (spider.SpiderId == 745 || spider.SpiderName == "上海地铁采购平台")
                            {
                                _bidPubTime = _bidPubTime.Substring(0, 4) + "-" + _bidPubTime.Substring(4, 2) + "-" +
                                                  _bidPubTime.Substring(6, 2);
                            }
                        }
                        if (spider.SpiderName == "贵州省招投标网")
                        {
                            _bidPubTime = DateTime.Now.Year + "-" + bidPubTimes[i].Groups["v"].Value.Trim();
                        }

                        #endregion

                        #region 获取详情页
                        g = matchs[i].Groups["v"];

                        if (spider.SpiderName == "湖北省政府采购网")
                        {
                            try
                            {
                                ExceuteDetail(spider.SpiderUrlPrefix + g.Value.Replace("HTMLPATH", "queryInfo.isHtmlPage"),
                                    spider.EncodeType, spider, _bidCompanyName, _bidTitle, _bidPubTime);
                            }
                            catch (Exception err)
                            {

                            }
                        }
                        else if (spider.SpiderName == "苏州市政府采购网")
                        {
                            ExceuteDetail(spider.SpiderUrlPrefix + g.Value + ".shtml", spider.EncodeType, spider, _bidCompanyName, _bidTitle, _bidPubTime);
                        }
                        else
                        {
                            try
                            {
                                if (spider.SpiderName == "日照市公共资源交易网" && _bidTitle.Contains("通知"))
                                    continue;

                                if (spider.SpiderName == "株洲市政府采购网" || spider.SpiderName == "内蒙古政府采购网" || spider.SpiderName == "北京市建设工程信息网")
                                {
                                    _bidPubTime = DateTime.Now.ToString();
                                }
                                if (spider.SpiderName == "浙江省政府采购网")
                                {
                                    _bidPubTime = DateTime.Parse(_bidPubTime).AddDays(-90).ToString();
                                }
                                if (spider.SpiderName == "南京市公共资源交易中心")
                                {
                                    _bidPubTime = "";
                                }
                                if (spider.SpiderName == "福州市政府采购网")
                                {
                                    string copytime = _bidPubTime;
                                    _bidPubTime = copytime.Substring(0, 4) + "-" + copytime.Substring(4, 2) + "-" + copytime.Substring(6, 2);
                                }

                                string listExpression = g.Value.Replace("&amp;", "&");
                                if (spider.SpiderName == "上海地铁采购平台")
                                {
                                    string str1 = g.Value.Replace("&amp;", "&").Substring(0, 16);
                                    string str2 = g.Value.Replace("&amp;", "&").Substring(19, 16);
                                    listExpression =
                                        string.Format(
                                            "code={1}&articleId={0}&columnId={1}",
                                            str1, str2);
                                }
                                ExceuteDetail(spider.SpiderUrlPrefix + listExpression, spider.EncodeType, spider, _bidCompanyName, _bidTitle, _bidPubTime);
                            }
                            catch (Exception err)
                            {

                            }
                        }
                        #endregion
                    }
                }

                if (spider.SpiderType == 2)
                {
                    break;
                }

                if (spider.SpiderName == "东营市政府采购网")
                {
                    spider.HttpMethod = "post";
                    spider.PageParameter = "__EVENTTARGET=LinkButton4&__EVENTARGUMENT=&__VIEWSTATE=" +
                                           GetElement("id=\"__VIEWSTATE\" value=\"(?<v>.*?)\" />", html).
                                           Replace("/", "%2F").Replace("+", "%2B") + "&__EVENTVALIDATION=" +
                                           GetElement("EVENTVALIDATION\" value=\"(?<v>.*?)\" />", html).
                                           Replace("/", "%2F").Replace("+", "%2B");
                }

            }
        }

        public void BeatHeart()
        {
            Mercury.Model.Hearts heart = new Mercury.Model.Hearts();
            heart.HeartId = 1;
            heart.HeartName = "爬虫心跳";
            heart.HeartTime = DateTime.Now;
            heartService.Update(heart);
        }

        public string GetElement(string regexString, string html)
        {
            if (string.IsNullOrEmpty(regexString))
                return html;

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

        public List<string> GetElementList(string regexString, string html)
        {
            List<string> result = new List<string>();
            var regexitems = regexString.Split(',');
            Regex regex = null;
            MatchCollection matchs = null;

            foreach (var regexitem in regexitems)
            {
                regex = new Regex(regexitem, RegexOptions.None);

                matchs = regex.Matches(html);
                for (int i = 0; i < matchs.Count; i++)
                {
                    result.Add(matchs[i].Groups["v"].Value);
                }
            }

            return result;
        }

        public string GetAttachElement(string regexString, string html, Mercury.Model.Bids bid)
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
                    bid.BidFileName = matchs[0].Groups["x"].Value;
                    bid.BidFileNameURI = matchs[0].Groups["v"].Value;
                }
            }

            return "";
        }

        public void ParseDetail(string url, Mercury.Model.Spiders spider, string html, string bidCompanyName, string bidTitle, string bidTime)
        {
            if (string.IsNullOrEmpty(html))
            {
                Console.WriteLine("html 为空" + url);
                return;
            }
            try
            {
                Regex regex = null;
                Group g = null;
                string v = null;
                string[] values = null;
                MatchCollection matchs = null;
                Mercury.Model.Bids bid = new Mercury.Model.Bids();

                //title
                List<string> titleexpressions = spider.TitleExpression.Split(',').ToList();

                if (!string.IsNullOrEmpty(bidTitle)) //列表有传title不需要再重新解析
                    bid.BidTitle = bidTitle;
                else
                {
                    foreach (var titleexpression in titleexpressions)
                    {
                        bid.BidTitle = GetElement(titleexpression, html).Trim();
                        if (!string.IsNullOrEmpty(bid.BidTitle))
                            break;
                    }

                    Console.WriteLine(bid.BidTitle);
                    if (bid.BidTitle.Trim() == "大理公共资源交易中心")
                    {
                        bid.BidTitle = GetElement("<span id=\"ContentPlaceHolder1_Label36\"(.*?)>(?<v>.*?)</span>", html).Trim();
                        if (bid.BidTitle == "")
                        {
                            throw new Exception("大理公共资源交易中心：已到最新信息索引");
                        }
                    }
                }

                if (string.IsNullOrEmpty(bid.BidTitle) && spider.SpiderName == "合肥市政府采购网")
                {
                    bid.BidTitle = GetElement("仿宋(.*?)>(?<v>.*?)</", html);
                }
                else if (string.IsNullOrEmpty(bid.BidTitle) && spider.SpiderName == "深圳市政府采购网")
                {
                    bid.BidTitle = GetElement("项目名称：(?<v>.*?)<", html);
                    if (string.IsNullOrEmpty(bid.BidTitle))
                        bid.BidTitle = GetElement("AR-SA\">(?<v>.*?)</span>", html);
                }
                else if (string.IsNullOrEmpty(bid.BidTitle) && spider.SpiderName == "山东省政府采购网")
                {
                    bid.BidTitle = GetElement("<span style=\"FONT-SIZE: 22pt; FONT-FAMILY: 黑体\">(?<v>.*?)</span>", html);
                    if (string.IsNullOrEmpty(bid.BidTitle))
                        bid.BidTitle = GetElement("<div align=center>(?<v>.*?)<br>", html);
                    if (string.IsNullOrEmpty(bid.BidTitle))
                        bid.BidTitle = GetElement("<p align='center'(?<v>.*?)</p>", html);
                }

                if (string.IsNullOrEmpty(bid.BidTitle))
                {
                    Mercury.Model.SpiderLogs log = new Mercury.Model.SpiderLogs();
                    log.IsSuccess = false;
                    log.Message = "抓取信息不全" + bid.BidSourceURL;
                    log.SpiderName = url;
                    log.SpiderLog = DateTime.Now.ToString();
                    log.CreateTime = DateTime.Now;
                    loger.Add(log);
                    return;
                }
                if (bid.BidTitle.Contains("<") && bid.BidTitle.Contains(">"))
                {
                    bid.BidTitle = ReplaceHtmlTag(bid.BidTitle, bid.BidTitle.Length);
                }

                bid.BidTitle = bid.BidTitle.Trim();
                if (bidsBussiness.GetList("BidTitle = '" + bid.BidTitle + "'").Tables[0].Rows.Count > 0)
                {
                    Console.WriteLine("已存在");
                    return;
                }

                //更新行业分类
                ParseIndustryId(bid);

                //publish time               
                string pub = "";
                if (!string.IsNullOrEmpty(bidTime))
                {
                    bidTime = CommonUtility.ReplaceHtmlTag(bidTime);
                    if (bidTime.Length < 6)
                    {
                        if (bidTime.Contains("/"))
                            pub = DateTime.Now.Year + "/" + bidTime;
                        else if (bidTime.Contains("-"))
                        {
                            pub = DateTime.Now.Year + "-" + bidTime;
                        }
                    }
                    else
                    {
                        pub = bidTime;
                    }
                }
                else
                {
                    List<string> pubexpressions = spider.PublishExpression.Split(',').ToList();
                    foreach (var pubexpression in pubexpressions)
                    {
                        pub = GetElement(pubexpression, html);
                        if (!string.IsNullOrEmpty(pub))
                            break;
                    }

                    if (pub.Trim() == "" && spider.SpiderName == "大理白族自治州公共资源中心")
                    {
                        pub = GetElement("<span id=\"ContentPlaceHolder1_Label38\"><(.*?)>(?<v>.*?)</font></span>", html);
                    }
                }
                if (!string.IsNullOrEmpty(pub))
                {
                    if (spider.SpiderName == "天津市政府采购网" || spider.SpiderName == "广东公共资源交易网")
                    {
                        CultureInfo cultureInfo = CultureInfo.CreateSpecificCulture("en-US");
                        string format = "ddd MMM dd HH:mm:ss CST yyyy";
                        bid.BidPublishTime = DateTime.ParseExact(pub, format, cultureInfo);
                    }
                    else if (spider.SpiderName == "济宁市公共资源交易网")
                    {
                        bid.BidPublishTime = GetTime(pub);
                    }
                    else
                        bid.BidPublishTime = DateTime.Parse(pub.Trim().Replace("&nbsp;", ""));
                }
                else
                {
                    bid.BidPublishTime = GetLastBidPublishTime();
                }

                if (bid.BidPublishTime > DateTime.Now)
                {
                    bid.BidPublishTime = DateTime.Now;
                }

                //content
                if (string.IsNullOrEmpty(spider.ContentExpression))
                    bid.BidContent = "" + html + "";
                else
                {
                    List<string> contentexpressions = spider.ContentExpression.Split(',').ToList();
                    foreach (var contentexpression in contentexpressions)
                    {
                        bid.BidContent = GetElement(contentexpression, html);
                        if (spider.SpiderName == "重庆市政府采购网")
                        {
                            bid.BidContent = System.Text.RegularExpressions.Regex.Unescape(bid.BidContent);
                        }
                        if (!string.IsNullOrEmpty(bid.BidContent))
                            break;
                    }
                }
                if (string.IsNullOrEmpty(bid.BidContent) && spider.SpiderName == "株洲市政府采购网")
                {
                    bid.BidContent = html;
                }
                if (string.IsNullOrEmpty(bid.BidContent) && spider.SpiderName == "东营市政府采购网")
                {
                    bid.BidContent = GetElement("<div id=\"ContentControl1_content\" style=\"width:900px;margin:0 auto;\" class=\"nfont\">(?<v>.*?)<a href=\"javascript:window.close", html);
                }
                if (string.IsNullOrEmpty(bid.BidContent) && spider.SpiderName == "合肥市政府采购网")
                {
                    bid.BidContent = GetElement("</span></p>(?<v>.*?)<iframe", html);
                }
                if (spider.SpiderName == "深圳市政府采购网")
                {
                    string footprefix = "<table cellspacing=\"0\" cellpadding=\"2\" width=\"80%\" align=\"center\" border=\"0\">";
                    string footfix = "</p></td></tr></tbody></table>";
                    string foot = GetElement(
                            footprefix + "(?<v>.*?)" + footfix,
                            bid.BidContent);
                    if (!string.IsNullOrEmpty(foot))
                    {
                        bid.BidContent = bid.BidContent.Replace(footprefix + foot + footfix, "");
                    }
                }
                if (spider.SpiderName == "中华人民共和国财政部")
                {
                    bid.BidContent = bid.BidContent.Replace("bgcolor='#bfbfbf'", "");
                }
                if (spider.SpiderName == "江苏省政府采购网")
                {
                    bid.BidContent =
                        bid.BidContent.Replace(
                            "“江苏政府采购网”是江苏省财政厅主办，江苏省级唯一的政府采购信息发布网络媒体。“江苏政府采购网”发布的所有招投标信息，未经书面许可其他任何网站和个人不得转载。否则，“江苏政府采购网”将追究转载者的法律责任。",
                            "").Replace(
                                "<input onclick=\"window.opener = '';window.close();\" type=\"button\" class=\"btnclose\" value=\"\" /></p>",
                                "").Replace(
                                    "<input id=\"btnPrint\" class=\"btnprint\" type=\"button\" value=\"\" onclick=preview(1) />",
                                    "");
                }
                if (spider.SpiderName == "甘肃省政府采购网")
                {
                    bid.BidContent = bid.BidContent.Replace("background-color:#960000", "").Replace("文章基本信息", "公告信息").Replace("#FFFFFF", "");
                }
                if (spider.SpiderName == "湖北省政府采购网")
                {
                    bid.BidContent = bid.BidContent.Replace("<table width=\"90%\" border=\"0\" align=\"center\" cellpadding=\"5\" cellspacing=\"0\" bgcolor=\"#DDDDDD\">  <tr>    <td class=\"bt2\">附件</td>  </tr>  </table>", "");
                    bid.BidContent = bid.BidContent.Replace("href=\"javascript:download('", "javascript:download('http://www.ccgp-hubei.gov.cn/fnewsAction!download.action?filepath=");
                    bid.BidContent = bid.BidContent.Replace("onclick=\"download('", "javascript:download('http://www.ccgp-hubei.gov.cn/fnewsAction!download.action?filepath=");
                }
                if (spider.SpiderName == "四川省政府采购网")
                {
                    bid.BidContent = bid.BidContent.Replace("<br>", "");
                }
                bid.BidContent = RemoveScriptTag(bid.BidContent);
                if (string.IsNullOrEmpty(bid.BidContent))
                {
                    Mercury.Model.SpiderLogs log = new Mercury.Model.SpiderLogs();
                    log.IsSuccess = false;
                    log.Message = "抓取信息不全" + bid.BidSourceURL;
                    log.SpiderName = url;
                    log.SpiderLog = DateTime.Now.ToString();
                    log.CreateTime = DateTime.Now;
                    loger.Add(log);
                    return;
                }

                //带链接的地址全部转为目标站点绝对地址
                bid.BidContent = ChangeVirtualAddress(bid.BidContent, spider.SpiderUrl);
                bid.BidContent = CommonUtility.RemoveStyle(bid.BidContent);

                //content - attachment
                bid.BidFileName = GetAttachElement("<a href=\"(?<v>.*?)\">(?<x>.*?)</a>", bid.BidContent, bid);

                //filename
                if (!string.IsNullOrEmpty(bid.BidFileName))
                    bid.BidFileName = GetElement(spider.FilenameExpressoin, html);

                //filename
                if (!string.IsNullOrEmpty(spider.SourceExpression))
                    bid.BidSourceName = GetElement(spider.SourceExpression, html);

                CompleteAttachHostLink(bid, spider.SpiderUrlPrefix);

                bid.CreateTime = DateTime.Now;
                bid.LastChangeTime = DateTime.Now;

                bid.BidCompanyName = bidCompanyName;
                bid.ProvinceId = spider.ProvinceId;
                bid.CityId = spider.CityId;
                if (spider.SpiderName == "中国电力招标采购网" || spider.SpiderName == "中国移动采招网" || spider.SpiderName == "中煤招标与采购网")
                {
                    bid.ProvinceId = 0;
                    bool isFindinCity = false;
                    foreach (DataRow city in citys.Tables[0].Rows)
                    {
                        if (bid.BidTitle.Contains(city["CityName"].ToString().Replace("市", "")))
                        {
                            bid.CityId = int.Parse(city["CityID"].ToString());
                            bid.ProvinceId = int.Parse(city["ProvinceID"].ToString());
                            isFindinCity = true;
                            break;
                        }
                    }
                    if (!isFindinCity)
                    {
                        foreach (DataRow provice in provinces.Tables[0].Rows)
                        {
                            if (bid.BidTitle.Contains(provice["ProvinceName"].ToString().Replace("省", "").Replace("自治区", "").Replace("回族", "").Replace("壮族", "").Replace("维吾尔", "")))
                            {
                                bid.ProvinceId = int.Parse(provice["ProvinceID"].ToString());
                                break;
                            }
                        }
                    }
                }
                bid.BidSourceURL = url;
                bid.BidSpiderName = spider.SpiderName;
                bid.BidPlatFrom = "Auto";

                //解析BidNumber
                bid.BidNumber = ParseBidNumber(bid.BidContent);

                //解析BidCompanyName
                if (string.IsNullOrEmpty(bidCompanyName))
                {
                    bid.BidCompanyName = ParseCompanyName(bid.BidContent);
                }
                if (!string.IsNullOrEmpty(bid.BidCompanyName))
                {
                    //BidCompanyName 不为空就创建一个企业表记录CatchCompany
                    Mercury.Model.CatchCompany company = null;
                    var modellist = catchCompanyBussiness.GetModelList(" VendorName ='" + bid.BidCompanyName + "'");
                    if (modellist != null && modellist.Count > 0)
                    {
                        company = modellist.FirstOrDefault();
                    }
                    else
                    {
                        company = new Mercury.Model.CatchCompany();
                    }

                    company.VendorName = bid.BidCompanyName;
                    company.ProvinceId = bid.ProvinceId;
                    company.CityId = bid.CityId;
                    company.OnCreated = DateTime.Now;
                    if (modellist != null && modellist.Count > 0)
                    {
                        catchCompanyBussiness.Update(company);
                    }
                    else
                    {
                        company.Id = catchCompanyBussiness.Add(company);
                    }
                    bid.BidCompanyId = company.Id;
                }

                if (bid.BidTitle.Contains("结果") || bid.BidTitle.Contains("成交") || bid.BidTitle.Contains("中标"))
                    bid.BidType = "3";  //"中标结果"
                else if (bid.BidTitle.Contains("变更") || bid.BidTitle.Contains("更正") || bid.BidTitle.Contains("更正更改"))
                    bid.BidType = "2";  //变更公告
                else if (bid.BidTitle.Contains("预告") || bid.BidTitle.Contains("预公告") || bid.BidTitle.Contains("预公式"))
                    bid.BidType = "4"; //"招标预告"
                else if (bid.BidTitle.Contains("中止") || bid.BidTitle.Contains("撤销") || bid.BidTitle.Contains("废标"))
                    bid.BidType = "5"; //"中止公告";
                else if (bid.BidTitle.Contains("邀请"))
                    bid.BidType = "6"; //"邀请招标";
                else if (bid.BidTitle.Contains("竞争性"))
                    bid.BidType = "7"; //"竞争性招标";
                else if (bid.BidTitle.Contains("单一来源"))
                    bid.BidType = "8"; //"单一来源";
                else
                    bid.BidType = "1";  //招标公告


                if (string.IsNullOrEmpty(bid.BidContent) || string.IsNullOrEmpty(bid.BidTitle))
                {
                    Mercury.Model.SpiderLogs log = new Mercury.Model.SpiderLogs();
                    log.IsSuccess = false;
                    log.Message = "抓取信息不全" + bid.BidSourceURL;
                    log.SpiderName = url;
                    log.SpiderLog = DateTime.Now.ToString();
                    log.CreateTime = DateTime.Now;
                    loger.Add(log);
                    return;
                }

                Console.WriteLine(bid.BidPublishTime + " ok");

                bidsBussiness.Add(bid);

            }
            catch (Exception err)
            {
                Mercury.Model.SpiderLogs log = new Mercury.Model.SpiderLogs();
                log.IsSuccess = false;
                log.Message = DateTime.Now.ToString() + err.Message;
                log.SpiderName = url;
                log.SpiderLog = err.StackTrace;

                loger.Add(log);
                return;
            }
        }

        public string ChangeVirtualAddress(string html, string url)
        {
            Regex regex = new Regex("href=\"(?<v>.*?)\"", RegexOptions.None);
            Group g = null;
            string host = GetDomainName(url);

            var matchs = regex.Matches(html);
            if (matchs.Count > 0)
            {
                for (int i = 0; i < matchs.Count; i++)
                {
                    g = matchs[i].Groups["v"];
                    if (!g.Value.Contains("http://") && !g.Value.Contains("mailto"))   //虚拟地址 -〉绝对地址
                    {
                        html = html.Replace(g.Value, url.Substring(0, url.IndexOf(":")) + "://" + host + "/" + g.Value);
                    }
                }
            }

            return html;
        }

        private DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }

        public void ParseIndustryId(Mercury.Model.Bids bid)
        {
            foreach (Mercury.Model.SmartCategorys smart in smarts)
            {
                List<string> keywords = smart.Keywords.Split(' ').ToList();
                foreach (var keyword in keywords)
                {
                    if (bid.BidTitle.Contains(keyword))
                    {
                        bid.BidCategoryId = smart.BidCategoryId;
                        return;
                    }
                }
            }
        }
        public string RemoveScriptTag(string content)
        {
            if (content.Contains("<script>"))
                content = System.Text.RegularExpressions.Regex.Replace(content, @"<script.*?/script>", "");

            return content;
        }

        public string ParseCompanyName(string BidContent)
        {
            string BidCompanyName = FindSpecialSegmentByContent("采购单位：", BidContent);

            if (BidCompanyName.Trim() == "")
            {
                BidCompanyName = FindSpecialSegmentByContent("采购人名称：", BidContent);
            }

            BidCompanyName = BidCompanyName.Replace("：", "");
            BidCompanyName = ReplaceHtmlTag(BidCompanyName);

            if (BidCompanyName.Length > 20)
                BidCompanyName = "";
            return BidCompanyName;
        }

        public string ParseBidNumber(string BidContent)
        {
            string BidNumber = FindSpecialSegmentByContent("采购编号：", BidContent);
            if (BidNumber.Trim() == "")
            {
                BidNumber = FindSpecialSegmentByContent("项目编号：", BidContent);
            }
            if (BidNumber.Trim() == "")
            {
                BidNumber = FindSpecialSegmentByContent("招标编号", BidContent);
            }
            if (BidNumber.Trim() == "")
            {
                BidNumber = FindSpecialSegmentByContent("项目编号", BidContent);
                //BidNumber = GetElement("采购编号(?<v>.*?)<tr>", BidContent);
            }
            if (BidNumber.Trim() == "")
            {
                BidNumber = FindSpecialSegmentByContent("编号：", BidContent);
                if (BidNumber.Trim() == "")
                    BidNumber = FindSpecialSegmentByContent("编号:", BidContent);

            }
            if (BidNumber != "" && BidNumber.Length < 4) //长交采</FONT>2016XJ004号</SPAN>
            {
                BidNumber += FindSpecialSegmentByContent(BidNumber, BidContent);
            }

            if (BidNumber != "" && BidNumber.Substring(BidNumber.Length - 1, 1) == "-") //YJCG（竞）2016-</span><span style="font-size: 12pt">202</span>
            {
                BidNumber += FindSpecialSegmentByContent(BidNumber, BidContent);
            }

            BidNumber = BidNumber.Replace("：", "");
            BidNumber = ReplaceHtmlTag(BidNumber);

            if (BidNumber == "")
                BidNumber = "见正文";
            return BidNumber;
        }

        public static string FindSpecialSegmentByContent(string key, string content)
        {
            int startindex = content.IndexOf(key);

            if (startindex <= 0)
                return "";

            int tagCount = 0;
            string result = "";
            int resultLength = 0;
            int resultStartIndex = 0;

            for (int i = startindex + key.Length; i < 100000; i++)
            {
                if (content.Substring(i, 1) == ":" || content.Substring(i, 1) == "：")
                    continue;

                if (content.Substring(i).Length < 2)
                    break;

                if (content.Substring(i, 2) == "</" && tagCount == 0)
                {
                    if (resultLength > 0)
                        break;

                    tagCount++;
                    i += 1;
                    continue;
                }

                if (content.Substring(i, 2).ToLower() == "<a" ||
                    content.Substring(i, 2).ToLower() == "<b" ||
                    content.Substring(i, 2).ToLower() == "<h" ||
                    content.Substring(i, 2).ToLower() == "<t" ||
                    content.Substring(i, 2).ToLower() == "<p" ||
                    content.Substring(i, 2).ToLower() == "<f" ||
                    content.Substring(i, 2).ToLower() == "<o" ||
                    content.Substring(i, 2).ToLower() == "<u" ||
                    content.Substring(i, 2).ToLower() == "<s"
                    )
                {
                    if (resultLength > 0) //已经匹配到后
                    {
                        break;
                    }

                    tagCount++;
                    i += 1;
                    continue;
                }

                if (content.Substring(i, 1) == ">")   //标签结束符
                {
                    tagCount--;
                }
                else
                {
                    if (tagCount <= 0)   //匹配到key
                    {
                        if (resultStartIndex == 0)
                            resultStartIndex = i;

                        resultLength++;
                        continue;
                    }
                    else
                    {
                        continue;  //匹配tag内容   
                    }
                }
            }

            if (resultLength > 0)
            {
                result = content.Substring(resultStartIndex, resultLength);
            }

            string str2 = result.Replace("）", "");
            int count = result.Length - str2.Length;
            if (result.Contains("（") && count >= 2)
                result = result.Substring(0, result.LastIndexOf("）"));
            str2 = result.Replace(")", "");
            count = result.Length - str2.Length;
            if (result.Contains("(") && count >= 2)
                result = result.Substring(0, result.LastIndexOf(")"));

            if (!result.Contains("(") && result.Contains(")"))
                result = result.Substring(0, result.IndexOf(")"));
            if (!result.Contains("（") && result.Contains("）"))
                result = result.Substring(0, result.IndexOf("）"));

            result = result.Replace("&nbsp;", "").Trim();
            result = result.IndexOf("，") > 0 ? result.Substring(0, result.IndexOf("，")).Trim() : result;
            return result;
        }

        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText;
        }

        public void ExceuteDetail(string url, string encode, Mercury.Model.Spiders spider, string bidCompanyName, string bidTitle, string bidTime)
        {
            BeatHeart();
            if (!string.IsNullOrEmpty(bidTitle.Trim()))
                Console.WriteLine(bidTitle.Trim());
            if (!string.IsNullOrEmpty(bidTime.Trim()))
                Console.WriteLine(bidTime.Trim());

            if (!string.IsNullOrEmpty(bidTitle) && bidsBussiness.GetList("BidTitle = '" + bidTitle + "'").Tables[0].Rows.Count > 0)
            {
                Console.WriteLine("已存在");
                return;
            }
            if (url.Contains("www.zjggzy.gov.cn"))
            {
                url = url.Replace("\\", "");
            }
            string html = "";
            if (spider.SpiderName == "河北省政府采购网")
            {
                url = url + ".html";
            }
            if (spider.SpiderName == "柳州市公共资源交易网")
            {
                encode = "utf-8";
            }
            if (spider.SpiderName == "福建省政府采购网")
            {
                html = GetHtmlByPost("http://cz.fjzfcg.gov.cn/n/noticemgr/query-viewcontentfj.do", encode, 0, "noticeId=" + url, null);
            }
            else if (spider.SpiderName == "郑州市政府采购网")
            {
                url = string.Format(url, DateTime.Parse(bidTime).Year + "/" + DateTime.Parse(bidTime).Month + "/") + ".htm";
                html = GetHtml(url, "utf-8", "", null);
            }
            else if (spider.SpiderName == "安徽省招标投标信息网")
            {
                string post = url.Substring(url.IndexOf("+") + 1);
                url = url.Substring(0, url.IndexOf("+"));

                List<HttpCookie> requestCookies = new List<HttpCookie>();
                requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "rxfyayyxoczm0abm0dbqlykr"));
                requestCookies.Add(new HttpCookie("CNZZDATA2273996", "cnzz_eid%3D553905254-1483107534-null%26ntime%3D1483107534"));

                html = GetHtmlByPost(url, encode, 0, post, requestCookies);
            }
            else if (spider.SpiderName == "遂宁市公共资源交易网")
            {
                List<HttpCookie> requestCookies = new List<HttpCookie>();
                requestCookies.Add(new HttpCookie("AspxAutoDetectCookieSupport", "1"));
                requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "tjlzlntaegygxvssckooxbcc"));
                requestCookies.Add(new HttpCookie("_gscu_1732904760", "8359691729lgtz98"));
                requestCookies.Add(new HttpCookie("_gscs_1732904760", "t83598891w81juc87|pv:8"));
                requestCookies.Add(new HttpCookie("_gscbrs_1732904760", "1"));
                html = GetHtml(url, encode, "", requestCookies);
            }
            else if (spider.SpiderName == "福州市公共资源交易网")
            {
                if (url.Contains("query-viewcontent"))
                {
                    string postdata = url.Substring(url.IndexOf("noticeId="));
                    url = url.Substring(0, url.IndexOf("noticeId="));
                    html = GetHtmlByPost(url, encode, 0, postdata, null);
                }
            }
            else if (spider.SpiderName == "温州市公共资源交易中心")
            {
                List<HttpCookie> requestCookies = new List<HttpCookie>();
                requestCookies.Add(new HttpCookie("ASPSESSIONIDASTQCSAR", "=OCJEDFFAKOKHCKEADKMDJPFN"));
                html = GetHtml(url, encode, "", requestCookies);
            }
            else if (spider.SpiderName == "浙江省招投标网")
            {
                List<HttpCookie> requestCookies = new List<HttpCookie>();
                requestCookies.Add(new HttpCookie("ASP.NET_SessionId", "431vc5i0yhm1oc45rbsgobi4"));
                requestCookies.Add(new HttpCookie("_gscu_345275868", "84452911klt4ea19"));
                requestCookies.Add(new HttpCookie("_gscs_345275868", "t844586990mkimj34|pv:3"));
                requestCookies.Add(new HttpCookie("_gscbrs_345275868", "1"));
                html = GetHtml(url, encode, "", requestCookies);
            }
            else if (spider.SpiderName == "合肥市公共资源交易网")
            {
                if (url.Contains("ZtbDyDetail"))
                {
                    url = "http://www.hfggzy.com/hfzbtb/ZtbInfo/ZBGG/" + GetElement(@"InfoID=(?<v>.*?)&", url) + ".htm";
                }
                html = GetHtml(url, encode, "", null);
            }
            else
            {
                html = GetHtml(url, encode, "", null);
            }
            if (!string.IsNullOrEmpty(html))
            {
                Console.WriteLine("Detail HTML OK");
            }

            if (spider.SpiderName == "河南省政府采购网") //需要再一次跳转获取详情页
            {
                string _2ndurl = GetElement("get\\(\"(?<v>.*?)\"", html);
                html = GetHtml("http://www.hngp.gov.cn" + _2ndurl, encode, "", null);
            }

            ParseDetail(url, spider, html, bidCompanyName, bidTitle.Trim(), bidTime);
        }

        //如果存在附件，将虚拟地址为绝对地址
        public void CompleteAttachHostLink(Mercury.Model.Bids bid, string prefix)
        {
            List<string> hrefs = GetElementList("<a href=\"(?<v>.*?)\">", bid.BidContent);
            hrefs.ForEach(o =>
                              {
                                  if (!o.StartsWith("h") && !o.StartsWith("H"))
                                      bid.BidContent = bid.BidContent.Replace(o, prefix + o);
                              });

        }

        public DateTime GetLastBidPublishTime()
        {
            DataSet ds = bidsBussiness.GetList(1, "", "BidId desc");
            if (ds.Tables[0].Rows.Count == 0)
                return DateTime.Now;

            string pdatetime = ds.Tables[0].Rows[0]["BidPublishTime"].ToString();
            return DateTime.Parse(pdatetime);
        }

        public string GetHtmlByPost(string url, string encode, int page, string pageparameter, List<HttpCookie> cookies)
        {
            while (true)
            {
                var request = (HttpWebRequest)WebRequest.Create(url);
                CookieContainer cc = new CookieContainer();
                if (cookies != null && cookies.Count > 0)
                {
                    foreach (var cookie in cookies)
                    {
                        Cookie clientCookie = new Cookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain == null ? request.Host : cookie.Domain);
                        cc.Add(clientCookie);
                    }
                }

                if (url.Contains("ccgp-shanghai"))
                {
                    request.Headers.Add("useajaxprep", "true");
                }

                request.Method = "POST";
                if (!url.Contains("www.jszb.com"))
                    request.ContentType = "application/x-www-form-urlencoded";
                request.CookieContainer = cc;
                request.KeepAlive = true;
                request.UserAgent =
                    "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/51.0.2704.84 Safari/537.36";
                request.Host = GetDomainName(url);
                request.AllowAutoRedirect = false;
                request.Referer = url;
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8";
                request.Timeout = 10000;
                request.ContentType = "application/json;charset=UTF-8";

                if (url.Contains("ynggzy.com"))
                {
                    request.Headers.Add("useajaxprep", "true");
                    request.Headers.Add("charset", "UTF-8");
                }
                if (url.Contains("hljcg.gov.cn"))
                {
                    request.Headers.Add("Origin", "http://www.hljcg.gov.cn");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                    request.Headers.Add("Upgrade-Insecure-Requests", "1");
                }
                if (url.Contains("www.jszb.com"))
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Origin", "http://www.jszb.com.cn");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                    request.Headers.Add("Upgrade-Insecure-Requests", "1");
                }

                if (url.Contains("www.ynggzyxx.gov"))
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Origin", "http://www.ynggzyxx.gov.cn");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                    request.Headers.Add("Upgrade-Insecure-Requests", "1");
                }
                if (url.Contains("www.chinabidding.com"))
                {
                    request.ContentType = "application/x-www-form-urlencoded";
                    request.Headers.Add("Origin", "http://www.chinabidding.com");
                    request.Headers.Add("Accept-Encoding", "gzip, deflate");
                    request.Headers.Add("Accept-Language", "zh-CN,zh;q=0.8");
                    request.Headers.Add("Upgrade-Insecure-Requests", "1");
                }

                StringBuilder builder = new StringBuilder();
                if (url.Contains("http://123.234.82.17/"))  //青岛市公共资源交易网
                {
                    page--;
                }
                if (pageparameter.Contains("{0}"))
                    builder.Append(string.Format(pageparameter, page));
                else
                    builder.Append(pageparameter);

                byte[] data = Encoding.UTF8.GetBytes(builder.ToString());

                using (Stream reqStream = request.GetRequestStream())
                {
                    reqStream.Write(data, 0, data.Length);
                    reqStream.Close();
                }
                HttpWebResponse resp = (HttpWebResponse)request.GetResponse();
                Thread.Sleep(100);

                Stream stream = resp.GetResponseStream();

                //获取响应内容  
                string html = "";
                if (url.Contains("www.jszb.com") || url.Contains("www.chinabidding.com"))
                {
                    GZipStream gzip = new GZipStream(stream, CompressionMode.Decompress);
                    using (StreamReader reader = new StreamReader(gzip, Encoding.GetEncoding(encode)))
                    {
                        html = reader.ReadToEnd();
                    }
                }
                else
                {
                    using (StreamReader reader = new StreamReader(stream, Encoding.GetEncoding(encode)))
                    {
                        html = reader.ReadToEnd();
                    }
                }
                html = html.Replace("\r", string.Empty);
                html = html.Replace("\n", string.Empty);
                html = html.Replace("\t", string.Empty);

                stream.Close();
                resp.Close();

                if (!string.IsNullOrEmpty(html))
                    return html;

                return "";
            }
        }

        void Start(int startSpiderId)
        {
            var spiders = GetSpiderURL();
            while (true)
            {
                foreach (var spider in spiders)
                {
                    if (spider.SpiderId > startSpiderId)
                    {
                        if (spider.IsActive)
                            ExceuteList(spider);
                    }
                }

                startSpiderId = 0;

                //return;
            }
        }

        public int ParseProvinceId(string provincename)
        {
            var models = provinceBussiness.GetModelList(" provincename like '%" + provincename + "%'");

            if (models != null && models.Count > 0)
                return (int)models.FirstOrDefault().ProvinceID;
            return 0;
        }

        static void Main(string[] args)
        {
            int startSpiderId = 1;

            if (args != null && args.Count() > 0)
            {
                startSpiderId = int.Parse(args[0]);
            }
            else
            {
                string str = Console.ReadLine();
                startSpiderId = int.Parse(str);
            }
            Program hy = new Program();
            hy.Start(startSpiderId);
        }
    }
}
