using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using GoBiding.BLL;
using System.Data.SqlClient;
using Maticsoft.DBUtility;
using System.Web.UI.HtmlControls;

namespace GoBiding.Web
{
    public partial class BidDetail : System.Web.UI.Page
    {
        string strTitle;
        string strSeoKey;
        string strSeoDescription;

        public int BidId = 0;

        public string biddescription = "";
        public string title = "";
        //邮件正则表达式
        private static string _emailregex =
            @"[a-z]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\.][a-z]{2,3}([\.][a-z]{2})?";
        //手机号正则表达式
        private static string _mobileregex = @"1[34589]\d{9}";
        //固话号正则表达式
        private static string _phoneregex = @"(\d{3,4}-?)?\d{7,8}";

        private static string _httpurl =
            @"((https?|ftp|news):\/\/)?([a-z]([a-z0-9\-]*[\.。])+([a-z]{2}|aero|arpa|biz|com|coop|edu|gov|info|int|jobs|mil|museum|name|nato|net|org|pro|travel)|(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])\.){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]))(\/[a-z0-9_\-\.~]+)*(\/([a-z0-9_\-\.]*)(\?[a-z0-9+_\-\.%=&]*)?)?(#[a-z][a-z0-9_]*)?";
        //IP正则表达式
        private static Regex _ipregex = new Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
        //日期正则表达式
        private static Regex _dateregex = new Regex(@"(\d{4})-(\d{1,2})-(\d{1,2})");
        //数值(包括整数和小数)正则表达式
        private static Regex _numericregex = new Regex(@"^[-]?[0-9]+(\.[0-9]+)?$");
        //邮政编码正则表达式
        private static Regex _zipcoderegex = new Regex(@"^\d{6}$");

        private List<string> addressRegex = new List<string>() { "址：(?<v>.*?)</", "址:(?<v>.*?)</", 
            "地点：(?<v>.*?)</", "人：(?<v>.*?)</", "人:(?<v>.*?)</", "行：(?<v>.*?)</",  "户：(?<v>.*?)</"};

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public GoBiding.Model.Bids GetModelWithOutContent(long BidId)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 '' as bidcontent,BidId,BidTitle,BidPublishTime,CityId,ProvinceId,BidNumber,BidExpireTime,BidFileName,BidProjectName,BidAgent,BidKeywords,BidContacter,BidContacterMobile,BidContacterTel,BidContacterAddress,BidContacterURL,BidSourceURL,BidSourceName,CreateTime,LastChangeTime,BidType,BidFileNameURI,BidSpiderName,BidCategoryId,BidCompanyId,BidCompanyName,BidOpenTime,BidPlatFrom,SysUserId,BidCategoryType,TotalAmount,WinBidCompanyName,IsEmergency from Bids ");
            strSql.Append(" where BidId=@BidId");
            SqlParameter[] parameters = {
					new SqlParameter("@BidId", SqlDbType.BigInt)
			};
            parameters[0].Value = BidId;

            GoBiding.Model.Bids model = new GoBiding.Model.Bids();
            DataSet ds = DbHelperSQL.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return new DAL.Bids().DataRowToModel(ds.Tables[0].Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public Boolean IsMobileDevice()
        {
            string[] mobileAgents = { "iphone", "android", "phone", "mobile", "wap", "netfront", "java", "opera mobi", "opera mini", "ucweb", "windows ce", "symbian", "series","webos", "sony", "blackberry", "dopod", "nokia", "samsung", "palmsource", "xda", "pieplus", "meizu", "midp", "cldc", "motorola", "foma","docomo", "up.browser", "up.link", "blazer", "helio", "hosin", "huawei", "novarra", "coolpad", "webos", "techfaith", "palmsource", "alcatel","amoi", "ktouch", "nexian", "ericsson", "philips", "sagem", "wellcom", "bunjalloo", "maui", "smartphone", "iemobile", "spice", "bird", "zte-", "longcos", "pantech", "gionee", 
                                        "portalmmm", "jig browser", "hiptop", "benq", "haier", "^lct", "320x320", "240x320", "176x220","w3c ", 
                                        "acs-", "alav", "alca", "amoi", "audi", "avan", "benq", "bird", "blac", "blaz", "brew", "cell", "cldc", 
                                        "cmd-", "dang", "doco", "eric", "hipt", "inno", "ipaq", "java", "jigs", "kddi", "keji", "leno", "lg-c", "lg-d", 
                                        "lg-g", "lge-", "maui", "maxo", "midp", "mits","mmef", "mobi", "mot-", "moto", "mwbp", "nec-", "newt", "noki", 
                                        "oper", "palm", "pana", "pant", "phil", "play", "port", "prox", "qwap", "sage", "sams", "sany", "sch-", "sec-",
                                        "send", "seri", "sgh-", "shar", "sie-", "siem", "smal", "smar", "sony", "sph-", "symb", "t-mo","teli", "tim-", 
                                        "tosh", "tsm-", "upg1", "upsi", "vk-v", "voda", "wap-", "wapa", "wapi", "wapp", "wapr", "webc", "winw", "winw", "xda", "xda-", "Googlebot-Mobile" };
            bool isMoblie = false;
            if (Request.UserAgent.ToString().ToLower() != null)
            {
                for (int i = 0; i < mobileAgents.Length; i++)
                {
                    if (Request.UserAgent.ToString().ToLower().IndexOf(mobileAgents[i]) >= 0)
                    {
                        isMoblie = true;
                        break;
                    }
                }
            }
            if (isMoblie)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserSessionId"] != null)
            {
                hdnIsLogin.Value = "True";
            }
            else {
                hdnIsLogin.Value = "False";
            }


            if(IsMobileDevice())
            {
                if(Request.QueryString["BId"] != null)
                    Response.Redirect("/wap/BidDetail.aspx?bid=" + int.Parse(Request.QueryString["BId"].ToString()));
                return;
            }

            if (!IsPostBack)
            {
                try
                {
                    int bidId = int.Parse(Request.QueryString["BId"].ToString());
                    var bid = GetModelWithOutContent(bidId);

                    qqAuthorizationUrl.HRef = "https://graph.qq.com/oauth2.0/authorize?client_id=101405089&response_type=token&scope=all&redirect_uri=http%3A%2F%2Fwww.gobiding.com/ThirdLogin.aspx?" + "urlredirect=" + bidId;

                    if (bid == null)
                        return;

                    BidId = bidId;

                    #region
                    strTitle = "免费招标信息_" + bid.BidTitle + "_去投标网_免费招标采购信息发布平台_手机招标采购";
                    strSeoKey = bid.BidTitle + "_免费招标_采购信息_公开招标_工程招标_手机招标采购";
                    strSeoDescription = "去投标网_免费招标采购信息_免费招标_采购信息_公开招标_工程招标_上海商麓网络科技有限公司官网";
                    Page.Title = strTitle;
                    HtmlMeta desc = new HtmlMeta();
                    desc.Name = "Description";
                    desc.Content = strSeoDescription;
                    Page.Header.Controls.Add(desc);

                    HtmlMeta keywords = new HtmlMeta();
                    keywords.Name = "keywords";
                    keywords.Content = strSeoKey;
                    Page.Header.Controls.Add(keywords);
                    #endregion

                    lblTitle.Text = bid.BidTitle;
                    lblTitle2.Text = bid.BidTitle.Length > 48 ? bid.BidTitle.Substring(0, 48) + "..." : bid.BidTitle;
                    divLatestBrowse.Visible = false;

                    //var desc = CommonUtility.RemoveStyle(bid.BidContent);

                    //descMeta.Content = "去投标网>" + CommonUtility.GetProvinceName(bid.ProvinceId.ToString()) + ">" +
                    //                   (desc.Length > 20 ? desc.Substring(0, 20) : desc) + "www.gobiding.com";

                    ltrPublishTime.Text = bid.BidPublishTime.ToString();
                    //lblSource.Text = bid.BidSourceName;
                    ltrBidAmount.Text = (bid.TotalAmount ?? 0) == 0 ? "见正文" : bid.TotalAmount.ToString();
                    ltrBidCompany.Text = bid.BidCompanyName;
                    ltrBidNumber.Text = string.IsNullOrEmpty(bid.BidNumber) ? "见正文" : bid.BidNumber;
                    ltrBidType.Text = CommonUtility.GetBidTypeValue(bid.BidType);
                    ltrCategoryId.Text = (bid.BidCategoryId ?? 0) == 0
                                             ? "其他"
                                             : CommonUtility.GetCategoryName(bid.BidCategoryId ?? 0);
                    ltrExpireTime.Text = bid.BidExpireTime == null ? "见正文" : bid.BidExpireTime.Value.ToShortDateString();
                    ltrProvinceName.Text = CommonUtility.GetProvinceName(bid.ProvinceId.ToString());
                    ltrPublishTime.Text = bid.BidPublishTime == null ? "" : bid.BidPublishTime.ToShortDateString();
                    ltrSourceURL.HRef = bid.BidSourceURL;

                    int userId = 0;
                    if (Session["UserSessionId"] != null)
                        userId = int.Parse(Session["UserSessionId"].ToString());

                    if (userId > 0)
                    {
                        var history = new Model.Sys_UsersBidHistorys();
                        var list = new BLL.Sys_UsersBidHistorys().GetModelList(" BidId =" + bidId + " and UserId =" + userId);
                        if (list != null && list.Count > 0)
                        {
                            history = list.FirstOrDefault();
                            history.CreateTime = DateTime.Now;
                            new BLL.Sys_UsersBidHistorys().Update(history);
                        }
                        else
                        {
                            history.BidId = bidId;
                            history.UserId = userId;
                            history.CreateTime = DateTime.Now;
                            new BLL.Sys_UsersBidHistorys().Add(history);
                        }
                    }

                    //邮件
                    //EncodeValueByRegex(bid, _emailregex);

                    //手机
                    //EncodeValueByRegex(bid, _mobileregex);

                    //电话号码
                    //EncodeValueByRegex(bid, _phoneregex);

                    //网址
                    //EncodeValueByRegex(bid, _httpurl);

                    //地址
                    //EncodeValueByRegex(bid, addressRegex);

                    //lblContent.Text = CommonUtility.RemoveStyle(bid.BidContent);

                    if (bid.ProvinceId > 0)
                    {
                        List<int> mainCityId = new List<int> { 1, 2, 9, 19, 22, 23, 27 };
                        List<GoBiding.Model.Citys> ds = new List<GoBiding.Model.Citys>();
                        if (mainCityId.Contains(bid.ProvinceId.Value))
                        {
                            ds = new BLL.Citys().GetModelList(" CityID in (1, 2, 73, 197, 199, 234, 288) ");
                        }
                        else
                        {
                            ds = new BLL.Citys().GetModelList(" ProvinceID = " + bid.ProvinceId);
                        }
                        lstCityList.DataSource = ds;
                        lstCityList.DataBind();
                    }

                    int ccId = 0;
                    if (bid.BidCategoryId.HasValue && bid.BidCategoryId > 0)
                    {
                        ccId = bid.BidCategoryId.Value;
                    }
                    else
                    {
                        ccId = 31;
                    }

                    List<Model.Bids> bidList = new List<Model.Bids>();
                    using (SqlDataReader reader = DbHelperSQL.ExecuteReader(
                        string.Format(
                            "select top 8 BidId,BidTitle from Bids where ProvinceId = {0} and BidCategoryId = {1}",
                            bid.ProvinceId, ccId)))
                    //ExecuteReader返回的对象类型是SqlDataReader
                    {
                        while (reader.Read())
                        {
                            var sbid = new Model.Bids();
                            sbid.BidId = reader.GetInt64(0);
                            sbid.BidTitle = reader.GetString(1).Length > 20 ? reader.GetString(1).Substring(0, 20) + "..." : reader.GetString(1);
                            bidList.Add(sbid);
                        }
                    }
                    lstSimilarBid.DataSource = bidList;
                    lstSimilarBid.DataBind();

                    if (userId > 0)
                    {
                        string sql = @"select top 8 * from Sys_UsersBidHistorys h inner join Bids b on h.BidId = b.BidId where h.UserId = " + userId;

                        var datasource = DbHelperSQL.Query(sql);
                        lstHistory.DataSource = datasource;
                        lstHistory.DataBind();

                        if (datasource.Tables[0].Rows.Count > 0)
                        {
                            divLatestBrowse.Visible = true;
                        }
                    }
                }
                catch (Exception err)
                {
                    Logger.Warn(err.Message, err.StackTrace);
                }
            }
        }

        public void EncodeValueByRegex(Model.Bids bid, string regex)
        {
            var mathes = Regex.Matches(bid.BidContent, regex);
            if (mathes.Count > 0)
            {
                for (int i = 0; i < mathes.Count; i++)
                {
                    bid.BidContent = bid.BidContent.Replace(mathes[i].Value, "********");
                }
            }
        }

        public string EncodeValueByRegex(Model.Bids bid, List<string> regexitems)
        {
            Regex regex = null;
            MatchCollection matchs = null;

            foreach (var regexitem in regexitems)
            {
                regex = new Regex(regexitem, RegexOptions.None);

                matchs = regex.Matches(bid.BidContent);
                if (matchs.Count > 0)
                {
                    for (int i = 0; i < matchs.Count; i++)
                    {
                        if (matchs[i].Groups["v"].Value.Length > 3)
                            bid.BidContent = bid.BidContent.Replace(matchs[i].Groups["v"].Value, "********");
                    }
                }
            }

            return "";
        }
    }
}