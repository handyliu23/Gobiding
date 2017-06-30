using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.Model;
using Maticsoft.Common;
using System.Configuration;

namespace GoBiding.Web.BaseCode
{
    public class PhoenixBase : Page
    {
        private static string blackIps = ConfigurationManager.AppSettings["Agency"];

        public static string[] GetAgenceValue()
        {
            string[] arrAgency = blackIps.Trim('|').Split('|');
            return arrAgency;
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (Session["UserSessionId"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
        }
        public PhoenixBase()
        {
            //if (PhoenixConfig.Web.IsLiveServer)
            //{
            //    //两种情况，需要重定向 301永久转向到完整域名www.Phoenix.com
            //    //1 所有非Phoenix的范围，全部转到www.Phoenix.com/...
            //    //2 /index.aspx重定向到/

            //    string rawurl = HttpContext.Current.Request.RawUrl;

            //    if (HttpContext.Current.Request.Url.Host.ToLower() != PhoenixConfig.Web.LiveServerName.ToLower()
            //        || rawurl.ToLower() == "/Login.aspx")
            //    {
            //        string hostName = Util.GetHostName();
            //        string protocal = Util.ServerVariables("SERVER_PORT_SECURE") == "1" ? "https://" : "http://";

            //        if (rawurl.ToLower() == "/Login.aspx")
            //            rawurl = "";

            //        string url = protocal + hostName + rawurl;

            //        HttpContext.Current.Response.Clear();
            //        HttpContext.Current.Response.StatusCode = 301;
            //        HttpContext.Current.Response.Status = "301 Moved Permanently";
            //        HttpContext.Current.Response.AddHeader("Location", url);
            //    }

            //}
        }

        public SiteSessionInfo GetSession()
        {
            SiteSessionInfo oSession = (SiteSessionInfo)Session["UserSessionId"];
            if (oSession == null)
            {
                oSession = new SiteSessionInfo();
                Session["UserSessionId"] = oSession;
            }
            return oSession;
        }
  
        protected override void Render(HtmlTextWriter writer)
        {
            Response.CacheControl = "private";
            Response.Expires = 0;
            Response.AddHeader("pragma", "no-cache");
            base.Render(writer);
        }

        protected string Post(string key)
        {
            return Post(key, null);
        }
        protected string Get(string key)
        {
            return Get(key, null);
        }
        protected virtual string Post(string key, string defReturn)
        {
            return Request.Form[key] ?? defReturn;
        }

        protected virtual string Get(string key, string defReturn)
        {
            return Request.QueryString[key] ?? defReturn;
        }

        protected virtual void RenderContents(HtmlTextWriter writer) { }


        /// <summary>
        /// 设置输出显示
        /// </summary>
        /// <param name="lbl">显示信息的lab控件ID</param>
        /// <param name="msg">显示信息</param>
        /// <param name="status">信息类型：小于0为错误信息，大于0为正确信息，-1显示自定义错误信息。-2显示默认错误信息</param>
        public static void Assert(Label lbl, string msg, int status)
        {
            lbl.Text = status <= 0 ? ErrorTemplet.Replace("@errorMsg", status == -1 ? msg : "the default error message") : SuccTemplet.Replace("@succMsg", msg);
        }

        public static bool Assert(Label lbl, ArrayList errorList)
        {
            if (errorList.Count == 0)
                return true;
            string errorShow = "";
            if (errorList.Count == 1)
            {
                errorShow = errorList[0].ToString();
            }
            else
            {
                for (int i = 1; i <= errorList.Count; i++)
                {
                    if (i != 1)
                        errorShow += "<br>";
                    errorShow += i + "." + errorList[i - 1];
                }
            }
            Assert(lbl, errorShow, -1);
            return false;
        }

        public static void AssertNew(Literal ltl, string msg, int status)
        {
            ltl.Text = status <= 0 ? NewErrorTemplet.Replace("@errorMsg", status == -1 ? msg : "the default error message") : NewSuccTemplet.Replace("@succMsg", msg);
        }

        public static bool AssertNew(Literal ltl, ArrayList errorList)
        {
            if (errorList.Count == 0)
                return true;
            string errorShow = "";
            for (int i = 1; i <= errorList.Count; i++)
            {
                errorShow += "<dd>" + i + "." + errorList[i - 1] + "</dd>";
            }
            AssertNew(ltl, errorShow, -1);
            return false;
        }

        public const string ErrorTemplet = @"
<table width='100%' border='0' cellpadding='1' cellspacing='1' bgcolor='#FFD8D9'>
    <tr>
        <td align='left' style='color: #7E0001'>
            @errorMsg
        </td>
    </tr>
</table>";

        public const string NewErrorTemplet = @"<div class='acc_error'><dl>@errorMsg</dl></div>";
        public const string NewSuccTemplet = @"<div class='acc_succ'><dl>@succMsg</dl></div>";
        public const string SuccTemplet = @"
<table width='100%' border='0' cellpadding='1' cellspacing='1' bgcolor='#FFFFD5'>
    <tr>
        <td align='left' style='color: green'>
            @succMsg
        </td>
    </tr>
</table>";

        protected bool DoCheck(Dictionary<TextBox, int> checkList, Literal ltl)
        {
            // 1 不能为空
            // 2 不能为空，必须为整数
            // 3 不能为空，必须为小数
            // 4 如果不为空，必须为整数,默认为0
            // 5 如果不为空，必须为小数,默认为0.00

            ArrayList errorList = new ArrayList(5);
            foreach (TextBox tb in checkList.Keys)
            {
                int checkType = checkList[tb];
                string tbName = tb.ID.Replace("txt", "");

                if (checkType == 1)
                {
                    if (tb.Text == "")
                        errorList.Add(tbName + " can't be empty");
                }

                if (checkType == 2)
                {

                    if (!Util.IsIntNoLessThanZero(tb.Text))
                        errorList.Add(tbName + " should be a positive integer");
                }
                if (checkType == 4)
                {
                    if (tb.Text == "")
                        tb.Text = "0";
                    else if (!Util.IsIntNoLessThanZero(tb.Text))
                    {
                        errorList.Add(tbName + " should be a positive integer");
                    }
                }
                if (checkType == 3)
                {
                    if (!Util.IsDecimalNoLessThanZero(tb.Text))
                        errorList.Add(tbName + " should be a positive decimal");
                }
                if (checkType != 5) continue;
                if (tb.Text == "")
                    tb.Text = "0.00";
                else if (!Util.IsDecimalNoLessThanZero(tb.Text))
                    errorList.Add(tbName + " should be a positive decimal");
            }

            return AssertNew(ltl, errorList);
        }

        public string GetSocialAnnexScript(int type)
        {
            return
                @"<script type=""text/javascript"">    var sa_page = '_pagetype_'; (function () { function sa_async_load() { var sa = document.createElement('script'); sa.type = 'text/javascript'; sa.async = true; sa.src = '//cdn.socialannex.com/partner/9912031/universal.js'; var sax = document.getElementsByTagName('script')[0]; sax.parentNode.insertBefore(sa, sax); } if (window.attachEvent) { window.attachEvent('onload', sa_async_load); } else { window.addEventListener('load', sa_async_load, false); } })();</script>"
                    .Replace("_pagetype_", type.ToString());
        }
    }
}
