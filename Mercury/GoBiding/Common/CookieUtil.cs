using System;
using System.Web;

namespace Maticsoft.Common
{
    /// <summary>
    /// Summary description for CookieUtil.
    /// </summary>
    public class CookieUtil
    {
        public const string Cookie_ShoppingCart = "O1Y";
        public const string Cookie_IsShoppingCartChecked = "2S";
        public const string Cookie_BrowseHistory = "5C";
        public const string Cookie_ProductViewOrder = "6D";
        public const string Cookie_ThirdCategoryOrderBy = "7M";
        public const string Cookie_ThirdCategoryPicText = "8J";
        public const string Cookie_ThirdCategoryOrderShow = "AA";
        public const string Cookie_RemeberMe = "RM001";
        public const string Cookie_CookieGuid = "5T";
        public const string Cookie_RecentViewd1 = "RV1";
        public const string Cookie_RecentViewd2 = "RV2";
        public const string Cookie_ReviewHelpful = "RH";
        //public const string Cookie_CustomerGuid = "K7";
        public const string Cookie_RecentViewd = "RV";
        public const string Cookie_CJ = "anypromo_CJ";
        public const string Cookie_LS = "anypromo_ls";


        public static void SetCookie(string cookieName, string val, DateTime expires, bool isDes)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieName] ?? new HttpCookie(cookieName);

            if (expires != AppConst.DateTimeNull)
                cookie.Expires = expires;

            if( isDes)
                val = CryptoUtil.Encrypt(val);
            val = HttpContext.Current.Server.UrlEncode(val);

            cookie.Value = val;

            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        public static string GetCookie(string cookieName,bool isDes)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
                return string.Empty;
            var val = cookie.Value;
            val = HttpContext.Current.Server.UrlDecode(val);
            if (isDes)
                val = CryptoUtil.Decrypt(val);
            return val;
        }

        public static string GetCookie(string cookieName)
        {
            return GetCookie(cookieName, false);
        }

        public static void SetCookie(string cookieName, string val, DateTime expires)
        {
            SetCookie(cookieName, val, expires, false);
        }


        public static string GetCookieByDES(string cookieName)
        {
            return GetCookie(cookieName, true);
        }

        public static void SetCookieByDES(string cookieName, string val, DateTime expires)
        {
            SetCookie(cookieName, val, expires, true);
        }


        public static void SetCookieList(string cookieName, string val, DateTime expires)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieName] ?? new HttpCookie(cookieName);

            if (expires != AppConst.DateTimeNull)
                cookie.Expires = expires;
            if (string.IsNullOrEmpty(cookie.Value))
                cookie.Value = val;
            else
                cookie.Value += "," + val;
            HttpContext.Current.Response.Cookies.Set(cookie);
        }

        public static string GetCookieList(string cookieName)
        {
            var cookie = HttpContext.Current.Request.Cookies[cookieName];
            if (cookie == null)
                return string.Empty;
            var val = cookie.Value;
            return val;
        }
    }
}
