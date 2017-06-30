using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace GoBiding.BLL
{
    public static class CommonUtility
    {
        //邮件正则表达式
        private static string _emailregex =
            @"[A-Za-z0-9\u4e00-\u9fa5]+@[a-zA-Z0-9_-]+(\.[a-zA-Z0-9_-]+)+$";
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

        public static string ReplaceHtmlTag(string html, int length = 0)
        {
            string strText = System.Text.RegularExpressions.Regex.Replace(html, "<[^>]+>", "");
            strText = System.Text.RegularExpressions.Regex.Replace(strText, "&[^;]+;", "");

            if (length > 0 && strText.Length > length)
                return strText.Substring(0, length);

            return strText.Trim();
        }

        public static string GetChineseCh(string source)
        {
            source = RemoveStyle(source);
            source = CommonUtility.ReplaceHtmlTag(source);
            //Regex reg = new Regex("[\\u4e00-\\u9fa5,，。！、\\d\\.\\s]+", RegexOptions.None);
            //var result = reg.Match(source, 0).Value;
            //result = result.Length > 200 ? result.Substring(0, 200) : result.Substring(0, result.Length);
            //return result;
            string pure = source.Replace(" ", "");
            return pure.Length > 60 ? pure.Substring(0, 60) + "..." : pure.Substring(0, pure.Length);
        }

        public static string RemoveScriptTag(string content)
        {
            if (content.Contains("<script>"))
                content = System.Text.RegularExpressions.Regex.Replace(content, @"<script.*?/script>", "");

            return content;
        }

        public static string RemoveStyle(string content)
        {
            content = content.Replace("\r\n", "").Replace("\t", "").Replace("</strong>", "").Replace("align=\"center\"", ""); 

            if (content.Contains("<strong"))
                content = System.Text.RegularExpressions.Regex.Replace(content, @"<strong(.*?)>", "");

            if (content.Contains("<style"))
                content = System.Text.RegularExpressions.Regex.Replace(content, @"<style(.*?)</style>", "");

            if (content.Contains("<STYLE>"))
                content = System.Text.RegularExpressions.Regex.Replace(content, @"<STYLE>(.*?)</STYLE>", "");

            if (content.Contains(".style"))
                content = System.Text.RegularExpressions.Regex.Replace(content, "\\.style(.*?)\\}", "");

            if (content.Contains("style"))
                content = System.Text.RegularExpressions.Regex.Replace(content, "style=\"(.*?)\"", "");

            if (content.Contains("width"))
                content = System.Text.RegularExpressions.Regex.Replace(content, "width=\"(.*?)\"", "");

            if (content.Contains("class="))
                content = System.Text.RegularExpressions.Regex.Replace(content, "class=\"(.*?)\"", "");

            if (content.Contains("<img"))
                content = System.Text.RegularExpressions.Regex.Replace(content, @"<img(.*?)>", "");

            content = content.Replace("&nbsp;", "").Replace("border=1", "").Replace("<br/>","");
            return content;
        }

        public static int GetUserTypeId(string userType)
        {
            switch (userType)
            {
                case "投标方":
                    return 1;
                case "招标方":
                    return 2;
                case "代理机构":
                    return 3;
            }

            return 1;
        }

        public static string GetBidTypeValue(string bidtype)
        {
            switch (bidtype)
            {
                case "1":
                    return "招标公告";
                case "2":
                    return "变更公告";
                case "3":
                    return "中标公告";
                case "4":
                    return "招标预告";
                case "5":
                    return "废标公告";
                case "6":
                    return "邀请招标";
                case "7":
                    return "竞争性谈判";
                case "11":
                    return "采购公告";
            }

            return "招标公告";

        }

        public static string GetCityName(string Id)
        {
            var model = new GoBiding.BLL.Citys().GetModel(int.Parse(Id));
            if (model != null)
                return model.CityName;

            return "";
        }

        public static string GetProvinceName(string provinceId)
        {
            var model = new GoBiding.BLL.Provinces().GetModel(int.Parse(provinceId));
            if (model != null)
                return model.ProvinceName;

            return "";
        }

        public static string GetCategoryName(int cId)
        {
            var model = new BLL.BidCategorys().GetModel(cId);
            if (model != null)
                return model.BidCategoryName;

            return "";
        }

        public static string GetCategoryTypeName(string tId)
        {
            switch (tId)
            {
                case "1":
                    return "工程招标";
                case "2":
                    return "货物招标";
                case "3":
                    return "服务招标";
            }

            return "工程招标";
        }

        public static bool CheckInputString(string input)
        {
            if (input.ToLower().Contains("delete") || input.ToLower().Contains("update") || input.ToLower().Contains("'") || input.ToLower().Contains("drop")
                || input.ToLower().Contains("\""))
            {
                return false;
            }

            return true;
        }

        public static bool IsTelephone(string str_telephone)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_telephone, @"^(\d{3,4}-)?\d{6,8}$");
        }
        //验证手机号码的主要代码如下：
        public static bool IsMobilePhone(string str_handset)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_handset, _mobileregex);
        }
        //验证邮箱的主要代码如下：
        public static bool IsEmail(string str_email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_email, _emailregex);
        }
        //验证身份证号的主要代码如下：
        public static bool IsIDcard(string str_idcard)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_idcard, @"(^\d{18}$)|(^\d{15}$)");
        }
        //验证输入为数字的主要代码如下：
        public static bool IsNumber(string str_number)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_number, @"^[0-9]*$");
        }
        //验证邮编的主要代码如下：
        public static bool IsPostalcode(string str_postalcode)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(str_postalcode, @"^\d{6}$");
        }
    }
}
