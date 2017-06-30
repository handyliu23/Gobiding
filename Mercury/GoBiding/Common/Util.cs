using System.Linq;
using System.Security.Cryptography;

namespace Maticsoft.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.OleDb;
    using System.Diagnostics;
    using System.IO;
    using System.Net;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// Summary description for Util.
    /// </summary>
    public static class Util
    {
        //private static readonly ILog log = LogManager.GetLogger(typeof(Util));
        #region Is Series

        /// <summary>
        /// 判断是否为日期格式，空返回false
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDate(string date)
        {
            if (date == string.Empty)
                return false;
            try
            {
                // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                DateTime.Parse(date);
                // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool IsDateOrEmpty(string date)
        {
            return ((date == string.Empty) || IsDate(date));
        }

        /// <summary>
        /// 是否是整数，空返回false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(string str)
        {
            if (str == string.Empty)
                return false;
            try
            {
                // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                Convert.ToInt32(str);
                // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 是否整数集合，空返回false
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="ch">分隔符</param>
        /// <returns></returns>
        public static bool IsInt(string str, char ch)
        {
            if (str == string.Empty)
                return false;

            string[] arrInt = str.Split(ch);
            foreach (string t in arrInt)
            {
                try
                {
                    // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                    Convert.ToInt32(t);
                    // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                }
                catch
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Int >= 0 ，空返回false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIntNoLessThanZero(string str)
        {
            if (str == string.Empty)
                return false;
            try
            {
                return Convert.ToInt32(str) >= 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// Int > 0，空返回false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIntGreaterThanZero(string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            try
            {
                var tmp = Convert.ToInt32(str);
                return tmp > 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        // ReSharper disable CSharpWarnings::CS1570
        /// Int <= 0 ，空返回false
        // ReSharper restore CSharpWarnings::CS1570
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIntNoGreaterThanZero(string str)
        {
            if (str == string.Empty)
                return false;
            try
            {
                var tmp = Convert.ToInt32(str);
                return tmp <= 0;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 是否邮编，空返回false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsZipCode(string str)
        {
            if (str == String.Empty)
                return false;

            return IsIntGreaterThanZero(str) && str.Length == 6;
        }

        /// <summary>
        /// 是否是小数
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDecimal(string str)
        {
            if (str == String.Empty)
                return false;
            try
            {
                // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                Decimal.Parse(str);
                // ReSharper restore ReturnValueOfPureMethodIsNotUsed
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// decimal >= 0。空返回false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDecimalNoLessThanZero(string str)
        {
            if (str == String.Empty)
                return false;
            try
            {
                var tmp = Decimal.Parse(str);
                return tmp >= 0 && tmp <= 9999999999999999999.999999m; //(decimal 19,6)
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// decimal > 0。空返回false
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDecimalGreaterThanZero(string str)
        {
            if (str == String.Empty)
                return false;
            try
            {
                var tmp = Decimal.Parse(str);
                return tmp > 0;
            }
            catch
            {
                return false;
            }

        }

        /// <summary>
        /// 是否数字字母组合，空返回false
        /// </summary>
        /// <param name="strToCheck"></param>
        /// <returns></returns>
        public static bool IsAlphaNumeric(String strToCheck)
        {
            if (strToCheck == String.Empty)
                return false;
            var objAlphaNumericPattern = new Regex("[^a-zA-Z0-9]");
            return !objAlphaNumericPattern.IsMatch(strToCheck);
        }

        /// <summary>
        /// A-Z的字母。有且仅有一个
        /// </summary>
        /// <param name="strToCheck"></param>
        /// <returns></returns>
        public static bool IsCapitalLetter(String strToCheck)
        {
            if (strToCheck == String.Empty)
                return false;
            var objAlphaNumericPattern = new Regex("^[A-Z]$");
            return objAlphaNumericPattern.IsMatch(strToCheck);
        }

        /// <summary>
        /// A-Z的字母或0-9的数字。有且仅有一个
        /// </summary>
        /// <param name="strToCheck"></param>
        /// <returns></returns>
        public static bool IsAlphaOrNumeric(String strToCheck)
        {
            if (strToCheck == String.Empty)
                return false;
            var objAlphaNumericPattern = new Regex("^[0-9A-Z]$");
            return objAlphaNumericPattern.IsMatch(strToCheck);
        }

        /// <summary>
        /// 是否Email，空返回false
        /// </summary>
        /// <param name="strEmailAddress"></param>
        /// <returns></returns>
        public static bool IsEmailAddress(string strEmailAddress)
        {
            var objNotEmailAddress = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            return objNotEmailAddress.IsMatch(strEmailAddress);
        }

        /// <summary>
        /// 是否Email(可多个地址在一起)，空返回false
        /// </summary>
        /// <param name="strEmailAddress"></param>
        /// <returns></returns>
        public static bool IsEmailAddresses(string strEmailAddress)
        {
            string[] strEmailAddresses = strEmailAddress.Split(';');
            var objNotEmailAddress = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*");
            foreach (string s in strEmailAddresses)
            {
                if (!objNotEmailAddress.IsMatch(s))
                    return false;
            }
            return true;
        }

        /// <summary>
        /// 验证多个字符是否Email，空返回false
        /// </summary>
        /// <param name="strEmailAddress"></param>
        /// <returns></returns>
        public static bool IsEmailAddress(string[] strEmailAddress)
        {
            var objNotEmailAddress = new Regex(@"^\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");
            foreach (string t in strEmailAddress)
            {
                if (t.Trim() != "" && !objNotEmailAddress.IsMatch(t))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 是否手机,长度为11，开头是13或者159，153
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        public static bool IsCellNumber(string cell)
        {
            //验证长度
            if (cell.Length != 11)
            {
                return false;
            }

            try
            {
                //验证为数字，防止全角字符
                // ReSharper disable ReturnValueOfPureMethodIsNotUsed
                Convert.ToInt64(cell);
                // ReSharper restore ReturnValueOfPureMethodIsNotUsed

                //验证特征码
                var cellSpec1 = cell.Substring(0, 2);

                //string cellSpec2 = cell.Substring(0, 2);
                if (cellSpec1 != "13" && cellSpec1 != "15" && cellSpec1 !="18")
                    return false;
            }
            catch
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 是否电话号码，包括国外电话，国内电话，国内电话加分机号码，手机号码，用-_－—做分割符
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static bool IsPhoneNumber(string Phone)
        {
            var objNotPhoneNumber = new Regex(@"^((\d{2,4}[-_－—]?)?\d{3,8}([-_－—]?\d{3,8})?([-_－—]?\d{1,7})?$)|(^0?1[35]\d{9}$)");
            return objNotPhoneNumber.IsMatch(Phone);
        }

        #endregion

        #region SQL 格式化函数
        /// <summary>
        /// 整理字符串到安全格式，单引号替换为两个单引号
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string ToSqlSafeFormat(string strInput)
        {
            if (strInput == AppConst.StringNull)
            {
                strInput = string.Empty;
            }
            return strInput.Replace("'", "''").Trim();
        }

        /// <summary>
        /// 整理字符串到全文索引格式，单引号替换为两个单引号，清理双引号
        /// </summary>
        /// <param name="strInput"></param>
        /// <returns></returns>
        public static string ToSqlFullTextFormat(string strInput)
        {
            if (strInput == AppConst.StringNull)
            {
                strInput = string.Empty;
            }
            return strInput.Replace("'", "''").Replace('"', ' ').Trim();
        }


        /// <summary>
        /// 字符串两端加单引号'
        /// </summary>
        /// <param name="paramStr"></param>
        /// <returns></returns>
        public static string ToSqlString(string paramStr)
        {
            return "'" + ToSqlSafeFormat(paramStr) + "'";
        }

        /// <summary>
        /// 字符串两端加单引号',并用Unicode
        /// </summary>
        /// <param name="paramStr"></param>
        /// <returns></returns>
        public static string ToSqlSafeUnicode(string paramStr)
        {
            return "N'" + ToSqlSafeFormat(paramStr) + "'";
        }

        /// <summary>
        /// 字符串两端增加%和'
        /// </summary>
        /// <param name="paramStr"></param>
        /// <returns></returns>
        public static string ToSqlLikeString(string paramStr)
        {
            return "'%" + ToSqlSafeFormat(paramStr) + "%'";
        }

        /// <summary>
        /// 字符串右侧增加%，两侧增加单引号'
        /// </summary>
        /// <param name="paramStr"></param>
        /// <returns></returns>
        public static string ToSqlLikeStringR(string paramStr)
        {
            return "'" + ToSqlSafeFormat(paramStr) + "%'";
        }
        /// <summary>
        /// 日期后增加 23:59:59。传入的参数必须是'yyyy-MM-dd' 格式. 不另外检查
        /// </summary>
        /// <param name="paramDate"></param>
        /// <returns></returns>
        public static string ToSqlEndDate(string paramDate)
        {
            return ToSqlString(paramDate + " 23:59:59");
        }

        /// <summary>
        /// 就是一组数字或文字拼接到SQL文中的IN Clause中去。比如传入一个数组，得到拼接好的(a,b,c,d)之类的
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string ToSqlInString(ICollection list)
        {
            StringBuilder res = new StringBuilder();

            int i = 0;
            foreach (object o in list)
            {
                if (i != 0)
                    res.Append(',');

                res.Append(o.ToString());
                i++;
            }
            return "(" + res + ")";
        }

        #endregion

        #region Trim 系列函数
        public static string TrimNull(Object obj)
        {
            if (obj is DBNull)
                return AppConst.StringNull;
            return obj.ToString().Trim();
        }
        public static Guid TrimGuidNull(object obj)
        {
            return obj is DBNull ? AppConst.GuidNull : new Guid(obj.ToString());
        }

        public static int TrimIntNull(Object obj)
        {
            if (obj is DBNull)
                return AppConst.IntNull;
            return Int32.Parse(obj.ToString());
        }
        public static short TrimShortNull(Object obj)
        {
            return obj is DBNull ? AppConst.ShortNull : short.Parse(obj.ToString());
        }

        public static decimal TrimDecimalNull(Object obj)
        {
            if (obj is DBNull)
                return AppConst.DecimalNull;
            return decimal.Parse(obj.ToString());
        }

        public static DateTime TrimDateNull(Object obj)
        {
            if (obj is DBNull)
                return AppConst.DateTimeNull;
            return DateTime.Parse(obj.ToString());
        }

        public static bool TrimBoolNull(Object obj)
        {
            if (obj is DBNull)
                return false;
            return bool.Parse(obj.ToString());
        }

        public static int TrimLogicInt(int param)
        {
            return param < 0 ? 0 : param;
        }

        public static decimal TrimLogicDecimal(decimal param)
        {
            return param < 0 ? 0m : param;
        }

        #endregion

        #region 加密url并验证是否是我们加密的

        public static string BuildUrlCheckSum(string url)
        {
            string checksum = GetMD5(url.ToLower() + AppConst.md5pal);
            return "&checksum=" + checksum;
        }
        public static bool IsUrlCheck(string url, string checksum)
        {
            return GetMD5(url.ToLower() + AppConst.md5pal) == checksum;
        }

        #endregion

        #region 散列算法 MD5 SHA1
        public static string GetSHA1(string str)
        {
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "SHA1");
        }

        public static string GetMD5(String str)
        {
            // ReSharper disable PossibleNullReferenceException
            return FormsAuthentication.HashPasswordForStoringInConfigFile(str, "md5").ToLower();
            // ReSharper restore PossibleNullReferenceException
            //			byte[] data = Encoding.Unicode.GetBytes(str);
            //			MD5 md = new MD5CryptoServiceProvider();
            //			byte[] result = md.ComputeHash(data);
            //			return Encoding.Unicode.GetString(result);
        }
        #endregion

        /// <summary>
        /// string to int
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt32(string str)
        {
            return Convert.ToInt32(str.Trim());
        }
        public static int ToIntOrZero(string str)
        {
            int tmp;
            Int32.TryParse(str.Trim(), out tmp);
            return tmp;
        }
        public static int? ToInt32X(string str)
        {
            int? tmp = null;
            int out_int;
            if ( Int32.TryParse(str.Trim(), out out_int))
            {
                tmp = out_int;
            }
            return tmp;
        }

        public static bool ToBool(string str)
        {
            bool tmp;
            bool.TryParse(str.Trim(), out tmp);
            return tmp;
        }

        /// <summary>
        /// 保留2位小数
        /// </summary>
        /// <param name="moneyStr"></param>
        /// <returns></returns>
        public static decimal ToMoney(string moneyStr)
        {
            return Round(decimal.Parse(moneyStr.Trim()), 2);
        }

        /// <summary>
        /// 保留2位小数
        /// </summary>
        /// <param name="moneyValue"></param>
        /// <returns></returns>
        public static decimal ToMoney(decimal moneyValue)
        {
            return Round(moneyValue, 2);
        }

        /// <summary>
        /// 保留3位小数
        /// </summary>
        /// <param name="moneyStr"></param>
        /// <returns></returns>
        public static decimal ToMoneyThree(string moneyStr)
        {
            return Util.Round(decimal.Parse(moneyStr.Trim()), 3);
        }

        /// <summary>
        /// 保留3位小数
        /// </summary>
        /// <param name="moneyValue"></param>
        /// <returns></returns>
        public static decimal ToMoneyThree(decimal moneyValue)
        {
            return Util.Round(moneyValue, 3);
        }

        /// <summary>
        /// 保留4位小数
        /// </summary>
        /// <param name="moneyStr"></param>
        /// <returns></returns>
        public static decimal ToMoneyFour(string moneyStr)
        {
            return Round(decimal.Parse(moneyStr.Trim()), 4);
        }

        /// <summary>
        /// 保留4位小数
        /// </summary>
        /// <param name="moneyValue"></param>
        /// <returns></returns>
        public static decimal ToMoneyFour(decimal moneyValue)
        {
            return Round(moneyValue, 4);
        }

        /// <summary>
        /// 舍去金额的分,直接舍去,非四舍五入
        /// </summary>
        /// <param name="moneyValue"></param>
        /// <returns></returns>
        public static decimal TruncMoney(decimal moneyValue)
        {
            var tempAmt = Convert.ToInt32(moneyValue * 100) % 10;
            return (moneyValue * 100 - tempAmt) / 100m;
        }


        /// <summary>
        /// 计算指定的字符串出现的次数.
        /// </summary>
        /// <param name="fullStr"></param>
        /// <param name="findRegex"></param>
        /// <returns></returns>
        public static int CountString(string fullStr, string findRegex)
        {
            return new Regex(findRegex).Matches(fullStr).Count;
        }

        /// <summary>
        /// 舍去所有的小数位，直接舍去，非四舍五入
        /// </summary>
        /// <param name="decValue"></param>
        /// <returns></returns>
        public static int TruncDecimal(decimal decValue)
        {
            var valueStr = decValue.ToString();
            var pointIndex = valueStr.IndexOf('.');
            return pointIndex > 0 ? int.Parse(valueStr.Substring(0, pointIndex)) : Convert.ToInt32(decValue);
        }

        #region ToExcel
        public static void ToExcel(DataGrid DataGrid2Excel, string FileName, string Title)
        {
            ToExcel(DataGrid2Excel, FileName, Title, "");
        }

        /// <summary>
        /// Renders the html text before the datagrid.
        /// </summary>
        /// <param name="writer">A HtmlTextWriter to write html to output stream</param>
        private static void ToExcelFrontDecorator(HtmlTextWriter writer)
        {
            writer.WriteFullBeginTag("HTML");
            writer.WriteFullBeginTag("Head");
            //			writer.RenderBeginTag(HtmlTextWriterTag.Style);
            //			writer.Write("<!--");
            //			
            //			StreamReader sr = File.OpenText(CurrentPage.MapPath(MY_CSS_FILE));
            //			String input;
            //			while ((input=sr.ReadLine())!=null) 
            //			{
            //				writer.WriteLine(input);
            //			}
            //			sr.Close();
            //			writer.Write("-->");
            //			writer.RenderEndTag();
            writer.WriteEndTag("Head");
            writer.WriteFullBeginTag("Body");
        }

        /// <summary>
        /// Renders the html text after the datagrid.
        /// </summary>
        /// <param name="writer">A HtmlTextWriter to write html to output stream</param>
        private static void ToExelRearDecorator(HtmlTextWriter writer)
        {
            writer.WriteEndTag("Body");
            writer.WriteEndTag("HTML");
        }

        public static void ToExcel(DataGrid DataGrid2Excel, string FileName, string Title, string Head)
        {
            StringWriter sw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            ToExcelFrontDecorator(hw);
            if (Title != "")
                hw.Write(Title + "<br>");
            if (Head != "")
                hw.Write(Head + "<br>");

            DataGrid2Excel.EnableViewState = false;
            DataGrid2Excel.RenderControl(hw);

            ToExelRearDecorator(hw);

            HttpResponse response = HttpContext.Current.Response;
            response.Clear();
            response.Buffer = true;
            response.ContentType = "application/vnd.ms-excel";
            response.AddHeader("Content-Disposition", "attachment; filename=" + HttpUtility.UrlEncode(FileName) + ".xls");
            response.Charset = "UTF-7";
            response.ContentEncoding = Encoding.GetEncoding("UTF-7");
            response.Write(sw.ToString());
            response.End();
        }

        public static void ToExcel(DataTable dt, string FileName)
        {
            DataGrid dgTemp = new DataGrid { DataSource = dt };
            dgTemp.DataBind();
            ToExcel(dgTemp, FileName, "", "");
        }

        public static string ToExcelByODBC(DataTable dt, string excelName)
        {
            if (dt == null)
            {
                return "DataTable不能为空";
            }

            int rows = dt.Rows.Count;

            if (rows == 0)
            {
                return "没有数据";
            }

            const string physicPath = ""; //在使用的时候要重新制定上传路径；(Marco@2011-03-21 17:53:10) PhoenixConfig.SysConfig.ErrorLogFolder;
            if (physicPath == "")
                throw new Exception("在使用的时候要重新制定上传路径；(Marco@2011-03-21 17:53:10)");
        }
        #endregion

        #region swap int, decimal, string
        // ReSharper disable RedundantAssignment
        public static void Swap(ref int x, int y)
        // ReSharper restore RedundantAssignment
        {
            x = y;
        }
        // ReSharper disable RedundantAssignment
        public static void Swap(ref decimal x, decimal y)
        // ReSharper restore RedundantAssignment
        {
            x = y;
        }
        // ReSharper disable RedundantAssignment
        public static void Swap(ref string x, string y)
        // ReSharper restore RedundantAssignment
        {
            x = y;
        }
        #endregion

        #region Chinese Money
        private static readonly string[] ChineseNum = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
        private static string getSmallMoney(string moneyValue)
        {
            int intMoney = Convert.ToInt32(moneyValue);
            if (intMoney == 0)
            {
                return "";
            }
            string strMoney = intMoney.ToString();
            int temp;
            StringBuilder strBuf = new StringBuilder(10);
            if (strMoney.Length == 4)
            {
                temp = Convert.ToInt32(strMoney.Substring(0, 1));
                strMoney = strMoney.Substring(1, strMoney.Length - 1);
                strBuf.Append(ChineseNum[temp]);
                if (temp != 0)
                    strBuf.Append("仟");
            }
            if (strMoney.Length == 3)
            {
                temp = Convert.ToInt32(strMoney.Substring(0, 1));
                strMoney = strMoney.Substring(1, strMoney.Length - 1);
                strBuf.Append(ChineseNum[temp]);
                if (temp != 0)
                    strBuf.Append("佰");
            }
            if (strMoney.Length == 2)
            {
                temp = Convert.ToInt32(strMoney.Substring(0, 1));
                strMoney = strMoney.Substring(1, strMoney.Length - 1);
                strBuf.Append(ChineseNum[temp]);
                if (temp != 0)
                    strBuf.Append("拾");
            }
            if (strMoney.Length == 1)
            {
                temp = Convert.ToInt32(strMoney);
                strBuf.Append(ChineseNum[temp]);
            }
            return strBuf.ToString();
        }

        public static string GetChineseMoney(decimal moneyValue)
        {
            string result = "";
            if (moneyValue == 0)
                return "零";

            if (moneyValue < 0)
            {
                moneyValue *= -1;
                result = "负";
            }
            int intMoney = Convert.ToInt32(moneyValue * 100);
            string strMoney = intMoney.ToString();
            int moneyLength = strMoney.Length;
            StringBuilder strBuf = new StringBuilder(100);
            if (moneyLength > 14)
            {
                throw new Exception("Money Value Is Too Large");
            }

            //处理亿部分
            if (moneyLength > 10 && moneyLength <= 14)
            {
                strBuf.Append(getSmallMoney(strMoney.Substring(0, strMoney.Length - 10)));
                strMoney = strMoney.Substring(strMoney.Length - 10, 10);
                strBuf.Append("亿");
            }

            //处理万部分
            if (moneyLength > 6)
            {
                strBuf.Append(getSmallMoney(strMoney.Substring(0, strMoney.Length - 6)));
                strMoney = strMoney.Substring(strMoney.Length - 6, 6);
                strBuf.Append("万");
            }

            //处理元部分
            if (moneyLength > 2)
            {
                strBuf.Append(getSmallMoney(strMoney.Substring(0, strMoney.Length - 2)));
                strMoney = strMoney.Substring(strMoney.Length - 2, 2);
                strBuf.Append("元");
            }

            //处理角、分处理分
            if (Convert.ToInt32(strMoney) == 0)
            {
                strBuf.Append("整");
            }
            else
            {
                if (moneyLength > 1)
                {
                    int intJiao = Convert.ToInt32(strMoney.Substring(0, 1));
                    strBuf.Append(ChineseNum[intJiao]);
                    if (intJiao != 0)
                    {
                        strBuf.Append("角");
                    }
                    strMoney = strMoney.Substring(1, 1);
                }

                int intFen = Convert.ToInt32(strMoney.Substring(0, 1));
                if (intFen != 0)
                {
                    strBuf.Append(ChineseNum[intFen]);
                    strBuf.Append("分");
                }
            }
            string temp = strBuf.ToString();
            while (temp.IndexOf("零零") != -1)
            {
                strBuf.Replace("零零", "零");
                temp = strBuf.ToString();
            }

            strBuf.Replace("零亿", "亿");
            strBuf.Replace("零万", "万");
            strBuf.Replace("亿万", "亿");

            return result + strBuf;
        }
        #endregion



        /// <summary>
        /// 计算文件的绝对路径, 在类库中调用，一般是不能使用Server.MapPath的时候
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static string GetAbsoluteFilePath(string filePath)
        {
            var file = filePath;
            if (!filePath.Substring(1, 1).Equals(":")
                && !filePath.StartsWith("\\"))
            {
                file = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, filePath);
            }

            return file.Replace("/", "\\");
        }

        /// <summary>
        /// 是否含有多行记录
        /// </summary>
        /// <param name="ds"></param>
        /// <returns></returns>
        public static bool HasMoreRow(DataSet ds)
        {
            return (ds != null && ds.Tables.Count != 0) && ds.Tables[0].Rows.Count != 0;
        }

        public static bool HasMoreRow(DataTable dt)
        {
            return dt != null && dt.Rows.Count != 0;
        }

        /// <summary>
        /// 去除Html标签
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveHtmlTag(string str)
        {
            var reg = new Regex(@"<\/*[^<>]*>");
            return reg.Replace(str, string.Empty);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="originalImagePath">源图路径（物理路径）</param>
        /// <param name="thumbnailPath">缩略图路径（物理路径）</param>
        /// <param name="width">缩略图宽度</param>
        /// <param name="height">缩略图高度</param>
        /// <param name="mode">生成缩略图的方式</param> 
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, string mode)
        {
            var originalImage = System.Drawing.Image.FromFile(originalImagePath);

            var towidth = width;
            var toheight = height;

            var x = 0;
            var y = 0;
            var ow = originalImage.Width;
            var oh = originalImage.Height;

            switch (mode)
            {
                case "HW"://指定高宽缩放（可能变形） 
                    break;
                case "W"://指定宽，高按比例 
                    toheight = originalImage.Height * width / originalImage.Width;
                    break;
                case "H"://指定高，宽按比例
                    towidth = originalImage.Width * height / originalImage.Height;
                    break;
                case "Cut"://指定高宽裁减（不变形） 
                    if (originalImage.Width / (double)originalImage.Height > towidth / (double)toheight)
                    {
                        oh = originalImage.Height;
                        ow = originalImage.Height * towidth / toheight;
                        y = 0;
                        x = (originalImage.Width - ow) / 2;
                    }
                    else
                    {
                        ow = originalImage.Width;
                        oh = originalImage.Width * height / towidth;
                        x = 0;
                        y = (originalImage.Height - oh) / 2;
                    }

                    break;
            }

            //新建一个bmp图片
            System.Drawing.Image bitmap = new System.Drawing.Bitmap(towidth, toheight);

            //新建一个画板
            var g = System.Drawing.Graphics.FromImage(bitmap);

            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;

            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.Transparent);

            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(originalImage, new System.Drawing.Rectangle(0, 0, towidth, toheight),
                        new System.Drawing.Rectangle(x, y, ow, oh),
                        System.Drawing.GraphicsUnit.Pixel);

            try
            {
                //以jpg格式保存缩略图
                bitmap.Save(thumbnailPath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            finally
            {
                originalImage.Dispose();
                bitmap.Dispose();
                g.Dispose();
            }
        }

        /// <summary>
        /// 获取给定Url的内容, 大部分用于Email模板的读取
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string GetHttpContent(string url)
        {

            var http = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)http.GetResponse();
            // ReSharper disable AssignNullToNotNullAttribute
            var responseStream = new StreamReader(response.GetResponseStream(), Encoding.Default);
            // ReSharper restore AssignNullToNotNullAttribute
            var html = responseStream.ReadToEnd();
            response.Close();
            responseStream.Close();

            return html;
        }


        public static string ReadFile(string filePath, string backUpFile)
        {
            try
            {
                string currentFilePath;
                if (File.Exists(filePath))
                    currentFilePath = filePath;
                else if (File.Exists(backUpFile))
                    currentFilePath = backUpFile;
                else
                    return string.Empty;

                var aFile = new FileStream(currentFilePath, FileMode.Open, FileAccess.Read);

                var sr = new StreamReader(aFile, Encoding.GetEncoding("gb2312"));

                var templet = sr.ReadToEnd();
                sr.Close();

                return templet;
            }
            catch (Exception)
            {
                //log.Error("",exp);
                return string.Empty;
            }
        }

        /// <summary>
        /// 计算文本长度，区分中英文字符，中文算两个长度，英文算一个长度
        /// </summary>
        /// <param name="Text"></param>
        /// <returns></returns>
        public static int GetLength(string Text)
        {
            var len = 0;

            for (var i = 0; i < Text.Length; i++)
            {
                var byte_len = Encoding.Default.GetBytes(Text.Substring(i, 1));
                if (byte_len.Length > 1)
                    len += 2;  //如果长度大于1，是中文，占两个字节，+2
                else
                    len += 1;  //如果长度等于1，是英文，占一个字节，+1
            }

            return len;
        }


        /// <summary>
        /// 去除字符串中的引号.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string KickQuoteFlag(string text)
        {
            return text.Replace("\"", string.Empty);
        }

        /// <summary>
        /// 把JavaScript中的非法字符转换为安全字符
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string FilterJS(string s)
        {
            var res = string.Empty;

            if (string.IsNullOrEmpty(s))
                return string.Empty;

            for (var i = 0; i < s.Length; i++)
            {
                switch (s.Substring(i, 1))
                {
                    case "<":
                        res += "&lt;";
                        break;
                    case ">":
                        res += "&gt;";
                        break;
                    case "&":
                        res += "&amp;";
                        break;
                    case " ":
                        res += "&nbsp;";
                        break;
                    case "'":
                        res += "&#39;";
                        break;
                    case "\"":
                        res += "&quot;";
                        break;
                    case "\n":
                        res += "<br>";
                        break;
                    default:
                        res += s.Substring(i, 1);
                        break;
                }
            }

            return res;
        }

        #region Obsolete functions
        // Function to test for Positive Integers.  
        [Obsolete("please use IsIntGreaterThanZero, by marco")]
        public static bool IsNaturalNumber(String strNumber)
        {
            Regex objNotNaturalPattern = new Regex("[^0-9]");
            Regex objNaturalPattern = new Regex("0*[1-9][0-9]*");
            return !objNotNaturalPattern.IsMatch(strNumber) &&
                objNaturalPattern.IsMatch(strNumber);
        }

        // Function to test for Positive Integers with zero inclusive  
        [Obsolete("please use IsIntNoLessThanZero, by marco")]
        public static bool IsWholeNumber(String strNumber)
        {
            Regex objNotWholePattern = new Regex("[^0-9]");
            return !objNotWholePattern.IsMatch(strNumber);
        }

        // Function to Test for Integers both Positive & Negative  
        [Obsolete("please use IsInt, by marco")]
        public static bool IsInteger(String strNumber)
        {
            Regex objNotIntPattern = new Regex("[^0-9-]");
            Regex objIntPattern = new Regex("^-[0-9]+$|^[0-9]+$");
            return !objNotIntPattern.IsMatch(strNumber) && objIntPattern.IsMatch(strNumber);
        }


        // Function to Test for Positive Number both Integer & Real 
        [Obsolete("please use IsIntNoLessThanZero or IsDecimalNoLessThanZero, by marco")]
        public static bool IsPositiveNumber(String strNumber)
        {
            Regex objNotPositivePattern = new Regex("[^0-9.]");
            Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            return !objNotPositivePattern.IsMatch(strNumber) &&
                objPositivePattern.IsMatch(strNumber) &&
                !objTwoDotPattern.IsMatch(strNumber);
        }

        [Obsolete("please use RemoveHtmlTag , by marco")]
        public static string GetNoHTMLString(string str)
        {
            Regex regex = new Regex(@"<([\s-\S][^>]*)?>");
            Regex regex2 = new Regex(@"(\w(\.|,|\/))");
            return regex2.Replace(regex.Replace(str, ""), "");
        }
        #endregion

        /// <summary>
        /// 设置输出显示
        /// </summary>
        /// <param name="lbl">显示信息的lab控件ID</param>
        /// <param name="msg">显示信息</param>
        /// <param name="status">信息类型：小于0为错误信息，大于0为正确信息，-1显示自定义错误信息。-2显示默认错误信息</param>
        public static void Assert(Label lbl, string msg, int status)
        {
            if (status <= 0)
            {
                lbl.Text = status == -1 ? AppConst.ErrorTemplet.Replace("@errorMsg", msg) : AppConst.ErrorTemplet.Replace("@errorMsg", "<br>" + "AppConst.WebMaster");
            }
            else
            {
                lbl.Text = AppConst.SuccTemplet.Replace("@succMsg", msg);
            }

        }

        public static bool Assert(Label lbl, ArrayList errorList)
        {
            if (errorList.Count == 0)
                return true;
            var errorShow = string.Empty;
            for (var i = 1; i <= errorList.Count; i++)
            {
                if (i != 1)
                    errorShow += "<br>";
                errorShow += i + "." + errorList[i - 1];
            }

            Assert(lbl, errorShow, -1);
            return false;
        }


        public static List<string[]> RemoveDupSizes(IEnumerable<string[]> sizes)
        {
            var rtnSizes = new List<string[]>();
            foreach (string[] s in sizes)
            {
                bool isDup = false;
                foreach (string[] rs in rtnSizes)
                {
                    if (rs[1] == s[1])
                        isDup = true;
                }
                if (!isDup)
                    rtnSizes.Add(s);
            }

            return rtnSizes;
        }

        /// <summary>
        /// 删除数组中的重复项.
        /// </summary>
        public static List<T> RemoveDup<T>(List<T> values)
        {
            var list = new List<T>();

            // 遍历数组成员.
            foreach (T t in values)
            {
                // 对每个成员做一次新数组查询如果没有相等的则加到新数组.
                if (list.IndexOf(t) == -1)
                    list.Add(t);
            }

            return list;
        }

        public static decimal Round(decimal x, int len)
        {
            return Decimal.Round(x, len, MidpointRounding.AwayFromZero);
        }

        public static decimal Round(decimal x)
        {
            return Decimal.Round(x, 0, MidpointRounding.AwayFromZero);
        }

        #region Base64 加解密
        //public static string EncodeBase64(string source)
        //{
        //    try
        //    {
        //        byte[] bytes_1 = Encoding.Default.GetBytes(source);
        //        return Convert.ToBase64String(bytes_1).Replace("+"," ");
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}

        //public static string DecodeBase64(string result)
        //{
        //    try
        //    {
        //        byte[] bytes_2 = Convert.FromBase64String(result.Replace(" ", "+"));
        //        return Encoding.Default.GetString(bytes_2);
        //    }
        //    catch
        //    {
        //        return string.Empty;
        //    }
        //}
        #endregion
        /// <summary>
        /// 根据传进来的数值所属范围得到对应的keyword
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static string GetKeyword(int num)
        {
            if (num < 25) return "Promotional";
            if (num < 50) return "Customized";
            if (num < 60) return "Custom Products";
            if (num < 62) return "Business giveaways";
            if (num < 72) return "Advertising Specialties";
            if (num < 82) return "Logo Imprinted";
            if (num < 84) return "Promotional Merchandise";
            if (num < 86) return "Wholesale";
            if (num < 88) return "Event giveaways";
            if (num < 90) return "Swags";
            if (num < 92) return "Personalized";
            if (num < 94) return "Corporate Gifts";
            if (num < 96) return "Corporate Giveaways";
            return num < 98 ? "Tradeshow Giveaways" : "for Imprint";
        }

        /// <summary>
        /// 将DataSet里的Sheet1$读取到DataSet中(William@2011-02-16 14:45:08)
        /// </summary>
        /// <returns></returns>
        public static DataSet ReadExcelFileToDataSet(String fileName, string sheetName)
        {
            FileInfo fileInfo = new FileInfo(fileName);
            String strConn;
            //if (fileInfo.Extension.ToLower() == ".xls")
            //{
            //    //strConn = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HDR=Yes;IMEX=1'";
            //    strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 14.0 Xml;HDR=YES'";
            //}
            if (fileInfo.Extension.ToLower() == ".xlsx")
            {
                //strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
                strConn = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileName + ";Extended Properties='Excel 12.0 Xml;HDR=YES'";
            }
            else
            {
                throw new Exception("only .xlsx file can be read");
            }


            OleDbConnection Conn = new OleDbConnection(strConn);
            DataSet ds = new DataSet();
            try
            {
                string SQL = "select * from [" + sheetName + "$]";
                Conn.Open();
                OleDbDataAdapter da = new OleDbDataAdapter(SQL, strConn);
                da.Fill(ds);
                return ds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }
        }

        // string<>改为&lt; &gt;(William@2011-03-03 13:48:41)
        public static string DisableHTML(string str)
        {
            return str.Replace("<", "&lt;").Replace(">", "&gt;");
        }

        /// <summary>
        /// 根据name生成商品的sename，主要用于url(William@2011-03-01 08:43:54)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string GetSEName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }
            //转成小写
            name = RemoveHtmlTag(name).ToLower();
            //允许字母、数字、-（短破折号）_(下划线) 空格
            name = new Regex("[^a-z0-9-_ ]").Replace(name, "");
            //空格转为-（短破折号）
            name = name.Trim().Replace(" ", "-");
            //对多个连续短破折号换成一个短破折号
            while (name.Contains("--"))
            {
                name = name.Replace("--", "-");
            }
            //对多个连续_换成一个_
            while (name.Contains("__"))
            {
                name = name.Replace("__", "_");
            }
            return name;
        }

        /// <summary>
        /// 根据name生成商品的htmltagname，主要用于商品图片的alt(William@2011-03-01 08:44:39)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string Gethtmltagname(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return name;
            }
            //测试用例 ®->(R)，™->(TM)we      ---      //////33/b  a/b  aa//3/4/4/b/5_____%
            //转换®->(R)，™->(TM)，全角括号->半角括号
            name = name.Replace("®", "(R)").Replace("™", "(TM)").Replace("（", "(").Replace("）", ")");
            //允许字母（大小写）、数字、括号、-（短破折号）、/（斜线）、空格、_(下划线)
            name = new Regex("[^A-Za-z0-9()-/_ ]").Replace(name, "");
            //对多个连续空格换成一个空格
            while (name.Contains("  "))
            {
                name = name.Replace("  ", " ");
            }
            //对多个连续_换成一个_
            while (name.Contains("__"))
            {
                name = name.Replace("__", "_");
            }
            //对多个连续短破折号换成一个短破折号
            while (name.Contains("--"))
            {
                name = name.Replace("--", "-");
            }
            //-（短破折号）、/（斜线）前后都是字母的，再增加一个空格。（如果是1/2就不要增加空格 blue/red就增加空格）
            Regex reg = new Regex("[-/]");
            Match mat = reg.Match(name);
            if (mat.Success)
            {
                //MatchCollection和上边的Match的区别是Match不能统计多个相同的子字符串，而MatchCollection能
                MatchCollection mc = reg.Matches(name);
                int tempAdd = 0;
                for (int i = 0; i < mc.Count; i++)
                {
                    char temp1 = ' ';
                    char temp2 = ' ';
                    int index = mc[i].Index + tempAdd;
                    if (index > 0)
                        temp1 = name[index - 1];
                    if (index < name.Length - 1)
                        temp2 = name[index + 1];
                    //前一个字符是否为字母
                    if (temp1 >= 'A' && temp1 <= 'Z' || temp1 >= 'a' && temp1 <= 'z')
                    {
                        name = name.Substring(0, index) + " " + name.Substring(index);
                        tempAdd++;
                        index++;
                    }
                    //后一个字符是否为字母
                    if ((temp2 < 'A' || temp2 > 'Z') && (temp2 < 'a' || temp2 > 'z')) continue;
                    name = name.Substring(0, index + 1) + " " + name.Substring(index + 1);
                    tempAdd++;
                }
            }
            return name;
        }
        public static DateTime GetFirstDayOfMonth()
        {
            return DateTime.Now.AddDays(-DateTime.Now.Day + 1);
        }
        public static DateTime GetLastDayOfMonth()
        {
            return DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.Day);
        }
        public static bool IsIP(string ip)
        {
            //判断是否为IP
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// Customer表中IsAdmin字段按位2得到1表示是超级管理员,按位1得到1表示是一般管理员,否则就是普通客户帐号
        /// </summary>
        /// <param name="IsAdmin"></param>
        /// <returns></returns>
        public static int GetCustomerRole(int IsAdmin)
        {
            switch ((IsAdmin & 2))
            {
                case 1:
                    return 2;
                default:
                    return (IsAdmin & 1) == 1 ? 1 : 0;
            }
        }


        /// <summary>
        /// 如果读取不到就返回空 by snail 05.31
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static String Form(String paramName)
        {
            String tmpS = String.Empty;
            if (HttpContext.Current.Request.Form[paramName] != null)
            {
                try
                {
                    tmpS = HttpContext.Current.Request.Form[paramName];
                }
                catch
                {
                    tmpS = String.Empty;
                }
            }
            return tmpS;
        }

        /// <summary>
        /// 如果读取不到就返回空 by marco 11.17
        /// </summary>
        /// <param name="paramName"></param>
        /// <returns></returns>
        public static String QueryString(String paramName)
        {
            String tmpS = String.Empty;
            if (HttpContext.Current.Request.QueryString[paramName] != null)
            {
                try
                {
                    tmpS = HttpContext.Current.Request.QueryString[paramName];
                }
                catch
                {
                    tmpS = String.Empty;
                }
            }
            return tmpS;
        }

        public static bool QueryStringBool(String paramName)
        {
            String tmpS = QueryString(paramName).ToUpperInvariant();
            return (tmpS == "TRUE" || tmpS == "YES" || tmpS == "1");
        }

        public static int QueryStringInt(String paramName)
        {
            String tmpS = QueryString(paramName);
            int usi;
            Int32.TryParse(tmpS, out usi); // use default locale setting
            return usi;
        }

        public static long QueryStringLong(String paramName)
        {
            String tmpS = QueryString(paramName);
            long usl;
            Int64.TryParse(tmpS, out usl); // use default locale setting
            return usl;
        }

        public static Single QueryStringSingle(String paramName)
        {
            String tmpS = QueryString(paramName);
            Single uss;
            Single.TryParse(tmpS, out uss);
            return uss;
        }

        public static Double QueryStringDouble(String paramName)
        {
            String tmpS = QueryString(paramName);
            Double usd;
            Double.TryParse(tmpS, out usd);
            return usd;
        }

        public static decimal QueryStringDecimal(String paramName)
        {
            String tmpS = QueryString(paramName);
            Decimal usd;
            Decimal.TryParse(tmpS, out usd);
            return usd;
        }

        public static DateTime QueryStringDateTime(String paramName)
        {
            String tmpS = QueryString(paramName);
            try
            {
                return DateTime.Parse(tmpS); // use default locale setting
            }
            catch
            {
                return DateTime.MinValue;
            }
        }

        public static int GetDateDiffDays(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan ts = dateTime2.Subtract(dateTime1);
            try
            {
                return Convert.ToInt32(ts.TotalDays.ToString().Remove(ts.TotalDays.ToString().IndexOf(".")));
            }
            catch
            {
                return Math.Abs(Convert.ToInt32(Math.Round(ts.TotalDays)));
            }
        }

        public static int GetDateDiffHours(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan ts = dateTime2.Subtract(dateTime1);
            try
            {
                return Convert.ToInt32(ts.TotalHours.ToString().Remove(ts.TotalHours.ToString().IndexOf(".")));
            }
            catch
            {
                return Math.Abs(Convert.ToInt32(Math.Round(ts.TotalHours)));
            }
        }

        public static int GetDateDiffMinutes(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan ts = dateTime2.Subtract(dateTime1);
            try
            {
                return Convert.ToInt32(ts.TotalMinutes.ToString().Remove(ts.TotalMinutes.ToString().IndexOf(".")));
            }
            catch
            {
                return Math.Abs(Convert.ToInt32(Math.Round(ts.TotalMinutes)));
            }
        }

        public static int GetDateDiffSeconds(DateTime dateTime1, DateTime dateTime2)
        {
            TimeSpan ts = dateTime2.Subtract(dateTime1);
            try
            {
                return Convert.ToInt32(ts.TotalSeconds.ToString().Remove(ts.TotalSeconds.ToString().IndexOf(".")));
            }
            catch
            {
                return Math.Abs(Convert.ToInt32(Math.Round(ts.TotalSeconds)));
            }
        }

        public static bool IsMd5Equal(string str1, string str2)
        {
            var aMd5Csp = new MD5CryptoServiceProvider();
            Byte[] aHashTable = aMd5Csp.ComputeHash(Encoding.UTF8.GetBytes(str1));
            string aMd5 = BitConverter.ToString(aHashTable);
            Byte[] bHashTable = aMd5Csp.ComputeHash(Encoding.UTF8.GetBytes(str2));
            string bMd5 = BitConverter.ToString(bHashTable);

            return aMd5.Equals(bMd5);
        }

        public static Dictionary<string, decimal> GetCostCodeTable()
        {
            Dictionary<string, decimal> costcode_table = new Dictionary<string, decimal>(14);
            costcode_table.Add("A", 0.50m);
            costcode_table.Add("B", 0.55m);
            costcode_table.Add("C", 0.60m);
            costcode_table.Add("D", 0.65m);
            costcode_table.Add("E", 0.70m);
            costcode_table.Add("F", 0.75m);
            costcode_table.Add("G", 0.80m);
            costcode_table.Add("P", 0.50m);
            costcode_table.Add("Q", 0.55m);
            costcode_table.Add("R", 0.60m);
            costcode_table.Add("S", 0.65m);
            costcode_table.Add("T", 0.70m);
            costcode_table.Add("U", 0.75m);
            costcode_table.Add("V", 0.80m);
            return costcode_table;
        }
        /// <summary>
        /// 用于Product_Price中的CostCode转换
        /// </summary>
        /// <param name="costcode_org"></param>
        /// <returns></returns>
        public static string ConvertCostCode(string costcode_org)
        {
            string result = "";

            if (costcode_org.Length == 1)
            {
                result = new string(costcode_org[0], 12);
                return result;
            }
            for (int i = costcode_org.Length - 1; i >= 0; i--)
            {
                char current_costcode = costcode_org[i];
                int current_int;
                bool isInt = Int32.TryParse(current_costcode.ToString(), out current_int);
                if (isInt)
                {
                    string costcode_by_int = new string(costcode_org[i + 1], current_int - 1);
                    result = costcode_by_int + result;
                }
                else
                {
                    result = current_costcode + result;
                }
            }

            return result;
        }
        /// <summary>
        /// 字符串中逗号前后去空格
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string RemoveSpaceSideOfComma(string str)
        {
            if (str.Trim().Length == 0 || !str.Contains(","))
                return str;
            string[] ss = str.Split(',');
            string returnStr = "";
            foreach (string s in ss)
            {
                returnStr += s.Trim() + ",";
            }
            return returnStr.Substring(0, returnStr.Length - 1);
        }

        /// <summary>
        /// method for validating a US zip code
        /// </summary>
        /// <returns>true/false</returns>
        public static bool IsValidUSZip(string num)
        {
            // Allows 5 digit zip codes
            const string pattern = @"^(\d{5})$";
            Regex match = new Regex(pattern);
            return match.IsMatch(num);
        }

        /// <summary>
        /// 统一记录log的模板
        /// </summary>
        /// <param name="log">已有log</param>
        /// <param name="notes">新增的</param>
        /// <param name="username">添加者</param>
        /// <returns></returns>
        public static string GetLogTemplate(string log, string notes, string username)
        {
            if (!string.IsNullOrEmpty(notes))
            {
                log += "\n" + DateTime.Now.ToString(AppConst.DateFormatLong) + "    ---" + username + "\n" + notes + "\n---------------------------------------------------";
            }
            return log;
        }


        /// <summary>
        /// html特殊字符显示的转换(w3c)
        /// </summary>
        /// <param name="originId"></param>
        /// <returns></returns>
        public static string StringReplaceForW3C(string oldValue)
        {
            return oldValue.Replace("&", "&amp;");
        
        }


        public static string HtmlIDEncode(string originId)
        {
            return "E" + string.Join("_", Encoding.UTF8.GetBytes(originId).Select(f => BitConverter.ToString(new[] { f })));

        }

        public static string HtmlIDDecode(string codeStr)
        {
            return
                Encoding.UTF8.GetString(
                    codeStr.Substring(1).Split(new[] { "_" }, StringSplitOptions.RemoveEmptyEntries).Select(
                        f => Convert.ToByte(f, 16)).ToArray());
        }

        public static string ToPDF_From_HtmlString(string htmlString, string pdfFileName)
        {
            //创建一个随机的html file, 可以被覆盖，只要不同时生成同名文件即可。
            string tmpHtmlFolder = PhoenixConfig.Common.ToPDFFolder + "temp\\";
            if (!Directory.Exists(tmpHtmlFolder))
            {
                Directory.CreateDirectory(tmpHtmlFolder);
            }

            string tmpHtmlFullPath = tmpHtmlFolder + RandomString.GetRndInt(6) + ".htm";

            using (StreamWriter sw = new StreamWriter(tmpHtmlFullPath))
            {
                sw.Write(htmlString);
                sw.Close();
            }
            return ToPDF_From_UrlOrLocalHtmlFile(tmpHtmlFullPath, pdfFileName);

        }

        public static string ToPDF_From_UrlOrLocalHtmlFile(string urlOrLocalHtmlFile, string pdfFileName)
        {
            //實例一個Process類，啟動一個獨立進程

            //Process類有一個 StartInfo屬性，這個是ProcessStartInfo類，包括了一些屬性和方法，下面我們用到了他的幾個屬性：
            //UseShellExecute
            //若要在启动进程时使用外壳程序，则为 true；否则，直接从可执行文件创建进程。默认为 true。 
            //将此属性设置为 false 使您能够重定向输入流、输出流和错误流。

            string pdfPath = PhoenixConfig.Common.ToPDFFolder; //+ DateTime.Now.ToString("yyyyMMdd") + "\\";
            if (!Directory.Exists(pdfPath))
                Directory.CreateDirectory(pdfPath);

            int ver = 0;
            Regex reg = new Regex("_Ver([1-9]\\d*).pdf");
            foreach (string file in Directory.GetFiles(pdfPath))
            {
                string file2 = file.Replace(pdfPath, "");
                if (file2.StartsWith(pdfFileName))
                {
                    Match mat = reg.Match(file2);
                    if (mat.Success)
                    {
                        int verTemp = int.Parse(mat.Groups[0].Value.Substring(4).Substring(0, mat.Groups[0].Value.Length - 8));
                        if (verTemp > ver)
                            ver = verTemp;
                    }
                }
            }
            string pdfFileFullPach = pdfPath + pdfFileName + "_Ver" + ++ver + ".pdf";

            Process p = new Process
            {
                StartInfo =
                {
                    FileName = PhoenixConfig.Common.ToPDFExe,
                    Arguments = String.Format(" {0} {1}", urlOrLocalHtmlFile, "\"" + pdfFileFullPach + "\""),
                    UseShellExecute = false,            //關閉Shell的使用
                    RedirectStandardInput = true,       //重定向標準輸入
                    RedirectStandardOutput = true,      //重定向標準輸出
                    RedirectStandardError = true,       //重定向錯誤輸出
                    CreateNoWindow = true               //設置不顯示窗口
                }
            };

            p.Start();   //啟動

            //p.StandardInput.WriteLine(command);       //也可以用這種方式輸入要執行的命令
            //p.StandardInput.WriteLine("exit");        //不過要記得加上Exit要不然下一行程式執行的時候會當機

            //return "";
            string succ = p.StandardOutput.ReadToEnd();        //從輸出流取得命令執行結果
            if (succ != "")
            {
                return "";
            }
            return pdfFileFullPach;
        }

        /// <summary>
        /// 用于生成随机文件夹和相同名称PDF
        /// </summary>
        /// <param name="htmlString"></param>
        /// <param name="pdFRandFolderName"></param>
        /// <param name="pdfFileName"></param>
        /// <returns></returns>
        public static string ToPDF_From_HtmlString(string htmlString, string pdFRandFolder, string pdfFileName)
        {
            //创建一个随机的html file, 可以被覆盖，只要不同时生成同名文件即可。
            string tmpHtmlFolder = PhoenixConfig.Common.ToPDFFolder + "temp\\";
            if (!Directory.Exists(tmpHtmlFolder))
            {
                Directory.CreateDirectory(tmpHtmlFolder);
            }

            string tmpHtmlFullPath = tmpHtmlFolder + RandomString.GetRndInt(6) + ".htm";

            using (var sw = new StreamWriter(tmpHtmlFullPath))
            {
                sw.Write(htmlString);
                sw.Close();
            }

            string pdfFileFullPach = PhoenixConfig.Common.ToPDFFolder + pdfFileName + ".pdf";
            if(!string.IsNullOrEmpty(pdFRandFolder))
            {
                if (!Directory.Exists(PhoenixConfig.Common.ToPDFFolder + pdFRandFolder))
                {
                    Directory.CreateDirectory(PhoenixConfig.Common.ToPDFFolder + pdFRandFolder);
                }
                pdfFileFullPach = PhoenixConfig.Common.ToPDFFolder + pdFRandFolder + "\\" + pdfFileName + ".pdf";
            }

            var p = new Process
            {
                StartInfo =
                {
                    FileName = PhoenixConfig.Common.ToPDFExe,
                    Arguments = String.Format(" {0} {1}", tmpHtmlFullPath, "\"" + pdfFileFullPach + "\""),
                    UseShellExecute = false,            //關閉Shell的使用
                    RedirectStandardInput = true,       //重定向標準輸入
                    RedirectStandardOutput = true,      //重定向標準輸出
                    RedirectStandardError = true,       //重定向錯誤輸出
                    CreateNoWindow = true               //設置不顯示窗口
                }
            };

            p.Start();   //啟動
            string succ = p.StandardOutput.ReadToEnd();        //從輸出流取得命令執行結果
            if (succ != "")
            {
                return "";
            }
            return pdfFileFullPach;
        }

        /// <summary>
        /// 根据文件和文件所在文件夹的路径得到版本号
        /// </summary>
        /// <param name="FolderPath"></param>
        /// <param name="File"></param>
        /// <returns></returns>
        public static string GetStringPathAndVer(string FolderPath, string File)
        {
            //FolderPath: 文件所在文件夹的路径,比如：C:\\    File: 文件,比如: a.htm
            string[] list = File.Split('.');
            if (list.Length != 2) return FolderPath + File;
            string FileType = list[1];
            string FileName = list[0];
            int ver = 0;
            Regex reg = new Regex("_Ver([1-9]\\d*)." + FileType);
            foreach (string file in Directory.GetFiles(FolderPath))
            {
                //file2=除去路径剩下文件名
                string file2 = file.Replace(FolderPath, "");
                if (file2.StartsWith(FileName) &&file2.EndsWith(FileType))
                {
                    Match mat = reg.Match(file2);
                    if (mat.Success)
                    {
                        int verTemp = int.Parse(mat.Groups[0].Value.Substring(4).Split('.')[0]);
                        if (verTemp > ver)
                            ver = verTemp;
                    }
                }
            }
            return FolderPath + FileName + "_Ver" + ++ver + "." + FileType;
        }

        public static String ServerVariables(String paramName)
        {
            String tmpS = String.Empty;
            if (HttpContext.Current.Request.ServerVariables[paramName] != null)
            {
                try
                {
                    tmpS = HttpContext.Current.Request.ServerVariables[paramName];
                }
                catch
                {
                    tmpS = String.Empty;
                }
            }
            return tmpS;
        }

        /// <summary>
        /// 如果是liveserver，直接返回www.anypromo.com,否则返回Request.Url.Host
        /// </summary>
        /// <returns></returns>
        public static string GetHostName()
        {
            if (PhoenixConfig.Web.IsLiveServer)
                return PhoenixConfig.Web.LiveServerName;
            else
                return HttpContext.Current.Request.Url.Host;
        }


        public static string SubStringEx(this string s, int index_start, int length)
        {
            if (length > s.Length) length = s.Length;
            return s.Substring(index_start, length);
        }

		#region "弹出消息"
		/// <summary>
		/// 在页面加载之前弹出消息
		/// </summary>
		/// <param name="message">要弹出的消息</param>
		public static void AlertBefortLoad(string message)
		{
			Page page = System.Web.HttpContext.Current.Handler as Page;

			if(page != null)
			{
				page.ClientScript.RegisterClientScriptBlock(
					page.GetType(),
					"alert",
					string.Format("alert('{0}');", JsEncoding(message)),
					true
				);
			}
		}

		/// <summary>
		/// 对字符串进行编码，使其中不含有 ' 或 "
		/// </summary>
		/// <param name="message"></param>
		/// <returns></returns>
		public static string JsEncoding(string message)
		{
			if(string.IsNullOrEmpty(message))
			{
				return message;
			}

			return message.Replace("\\", "\\\\").Replace("'", "\\\'").Replace("\"", "\\\"").Replace("\n", "\\n").Replace("\r", "\\r");
		}

		public static string SetPDFName(string pdfFileName)
		{
			string pdfPath = PhoenixConfig.Common.ToPDFFolder; //+ DateTime.Now.ToString("yyyyMMdd") + "\\";
			if(!Directory.Exists(pdfPath))
				Directory.CreateDirectory(pdfPath);

			int ver = 0;
			Regex reg = new Regex("_Ver([1-9]\\d*).pdf");
			foreach(string file in Directory.GetFiles(pdfPath))
			{
				string file2 = file.Replace(pdfPath, "");
				if(file2.StartsWith(pdfFileName))
				{
					Match mat = reg.Match(file2);
					if(mat.Success)
					{
						int verTemp = int.Parse(mat.Groups[0].Value.Substring(4).Substring(0, mat.Groups[0].Value.Length - 8));
						if(verTemp > ver)
							ver = verTemp;
					}
				}
			}
			string pdfFileFullPach = pdfPath + pdfFileName + "_Ver" + ++ver + ".pdf";
			return pdfFileFullPach;
		}

		public static void DownloadFile(string url, string fileSavePath)
		{
			using(System.Net.WebClient client = new System.Net.WebClient())
			{
				client.DownloadFile(@url, fileSavePath);
			} 
		} 		
		#endregion

        /// <summary>
        /// 获取对固定列不重复的新DataTable
        /// </summary>
        /// <param name="dt">含有重复数据的DataTable</param>
        /// <param name="colName">需要验证重复的列名</param>
        /// <returns>新的DataTable，colName列不重复，表格式保持不变</returns>
        public static DataTable GetDistinctTable(DataTable dt, string colName)
        {
            DataView dv = dt.DefaultView;
            DataTable dtOne = dv.ToTable(true, colName);
            DataTable dtTwo = new DataTable();
            dtTwo = dv.ToTable();
            dtTwo.Clear();
            for(int i = 0; i < dtOne.Rows.Count; i++)
            {
                DataRow dr = dt.Select(colName + "='" + dtOne.Rows[i][0].ToString() + "'")[0];
                dtTwo.Rows.Add(dr.ItemArray);
            }
            return dtTwo;
        }

        public static string ListToString(List<string> list, bool IsSpace = false)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                if (i != 0)
                    sb.Append(",");
                if (IsSpace)
                    sb.Append(" ");
                sb.Append(list[i]);
            }
            return sb.ToString();
        }

        public static string GetWordsLessThan(string orgStr, int len, string more = "")
        {
            string[] strs = orgStr.Split(new Char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); //先用空格拆分单词
            string result = "";
            bool flag = false;
            for (int i = 0; i < strs.Length; i++)
            {
                //如果是第一组，那么不加空格，长度为实际长度，否则长度要加1个空格
                int appendLenth = strs[i].Length;
                if (i != 0)
                {
                    appendLenth += 1;
                }

                //判断是否超过长度？ 超过退出，不超过附加上去。
                if ((appendLenth + result.Length) > len - 4)
                {
                    flag = true;
                    break;
                }
                if (i != 0)
                    result += " ";
                result += strs[i];
            }
            if (flag)
                result += " ..." + more;
            return result;
        }

        private static readonly string[] MonthNames = new[]
	        {
		        "Jan", "Feb", "Mar", "Apr", "May", "Jun", 
		        "Jul", "Aug", "Sep", "Oct", "Nov", "Dec"
            };


        public static string ReadToEnd(string filepath)
        {
            string str = "";
            using (var fs = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                using (var sr = new StreamReader(fs))
                {
                    str = sr.ReadToEnd();
                }
            }
            return str;
        }
        //执行正则提取值
        public static string GetRegValue(string RegexString, string RemoteStr)
        {
            string r = "";
            Regex rs = new Regex(RegexString);
            Match m = rs.Match(RemoteStr);
            if (m.Success)
            {
                r = m.Value;
			}
            return r;
		}

        static public String GetThisPageName(bool includePath)
        {
            String s = ServerVariables("SCRIPT_NAME");
            if (!includePath)
            {
                int ix = s.LastIndexOf("/");
                if (ix != -1)
                {
                    s = s.Substring(ix + 1);
                }
            }
            return s;
        }

        static public string ToTitleCase(string str)
        {
            StringBuilder sb = new StringBuilder();
            List<string> list = str.Split(' ').Select(o=>o.Trim()).Where(o=>!string.IsNullOrEmpty(o)).ToList();
            foreach (var s in list)
            {
                if (s.Length > 0)
                    sb.Append(sb.Length > 0 ? " " : "").Append(s.Substring(0, 1).ToUpper() +
                                                               s.Substring(1, s.Length - 1));
            }
            return sb.ToString();
        }

    }
}
