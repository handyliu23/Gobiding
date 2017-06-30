using System;
using System.Web;
using GoBiding.Model;
using Maticsoft.Common;

namespace GoBiding.Web.BaseCode
{
    public class LoginUtil
    {
        public static void SignOut()
        {
            HttpContext.Current.Session["SiteSessionInfo"] = null;
            CookieUtil.SetCookieByDES(CookieUtil.Cookie_RemeberMe, "", DateTime.Now.AddDays(-1));
        }

        public static SiteSessionInfo GetSession()
        {
            SiteSessionInfo oSession = (SiteSessionInfo)HttpContext.Current.Session["SiteSessionInfo"];
            if (oSession == null)
            {
                oSession = new SiteSessionInfo();
                HttpContext.Current.Session["SiteSessionInfo"] = oSession;
            }
            return oSession;
        }

        public static AuthenticationSessionInfo GetAuthentication()
        {
            AuthenticationSessionInfo oSession = (AuthenticationSessionInfo)HttpContext.Current.Session["AuthenticationSessionInfo"];
            if (oSession == null)
            {
                oSession = new AuthenticationSessionInfo();
                HttpContext.Current.Session["AuthenticationSessionInfo"] = oSession;
            }
            return oSession;
        }

        public static bool IsLoginAllowNoRegister()
        {
            return IsLogin(true);
        }

        private static bool IsLogin(bool allowNoRegister)
        {

            //取Session变量
            bool isLogin = false;

            SiteSessionInfo oSession = GetSession(); //没有会初始化一个

            if (oSession.sCustomer != null && (allowNoRegister ? (oSession.sCustomer.Sys_UserId != AppConst.IntNull) : oSession.sCustomer.Sys_UserId != AppConst.IntNull))
            {
                isLogin = true;
            }
            return isLogin;
        }
        public static bool IsLogin()
        {
            return IsLogin(false);
        }

        public static void RequiresLoginAllowNoRegister(String ReturnURL)
        {
            if (!IsLoginAllowNoRegister())
                HttpContext.Current.Response.Redirect("/Index.aspx?returnurl=" + HttpUtility.UrlEncode(ReturnURL));
        }


        public static void RequiresLogin(String ReturnURL)
        {
            if (!IsLogin())
                HttpContext.Current.Response.Redirect("/Index.aspx?returnurl=" + HttpUtility.UrlEncode(ReturnURL));
        }

        //需要二次鉴权
        public static void RequiresLoginAuth(String ReturnURL)
        {
            if (!IsLogin() || GetAuthentication().AuthenticationHoldTime < DateTime.Now)
                HttpContext.Current.Response.Redirect("/Index.aspx?identityauth=1&returnurl=" + HttpUtility.UrlEncode(ReturnURL));
        }

        //public static bool IsAdmin()
        //{
        //    if (!IsLogin())
        //        return false;
        //    return GetSession().sCustomer.IsAdmin == (int)AppEnum.YNStatus.Yes;
        //}

        static public void RequireSecurePage()
        {
            RequireSecurePage(true);
        }

        static public void RequireSecurePage(bool isRequireSSL)
        {
            bool isHttps = Util.ServerVariables("SERVER_PORT_SECURE") == "1";
            isRequireSSL = isRequireSSL & PhoenixConfig.Web.IsLiveServer; //如果在开发环境，就不需要SSL啦。

            //异或，如果要求和当前的url的ssl方式不相同，则结果是true，需要redirect
            //否则意味着请求和当前是一致的，不需要处理，否则成死循环了
            if (isRequireSSL ^ isHttps)
            {
                string hostName = Util.GetHostName();
                string protocal = isRequireSSL ? "https://" : "http://";
                string rawurl = HttpContext.Current.Request.RawUrl;

                string url = protocal + hostName + rawurl;
                HttpContext.Current.Response.Redirect(url);
            }
            
        }
    }
}