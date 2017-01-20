using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Mercury.Web
{
    public partial class BidDetail : System.Web.UI.Page
    {
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    int bId = int.Parse(Request.QueryString["BId"].ToString());
                    var bid = new BLL.Bids().GetModel(bId);

                    lblTitle.Text = bid.BidTitle;
                    ltrPublishTime.Text = bid.BidPublishTime.ToString();
                    lblSource.Text = bid.BidSourceName;

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

                    lblContent.Text = bid.BidContent;
                }
                catch (Exception er)
                {
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