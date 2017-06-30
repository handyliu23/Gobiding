using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Maticsoft.Common.DEncrypt;
using GoBiding.Model;
using GoBiding.Web.BaseCode;
using Maticsoft.Common;
using GoBiding.BLL;

namespace GoBiding.Web
{
    /// <summary>
    /// SecurityLogin 的摘要说明
    /// </summary>
    public class SecurityLogin : IHttpHandler, IRequiresSessionState
    {
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string UserCheckCode = context.Request["UserCheckCode"].ToString();
                string UserName = context.Request["UserName"].ToString();
                string PWD = context.Request["PWD"].ToString();

                if (context.Session["CheckCode"] == null)
                {
                    context.Response.Write("验证码失效，请刷新.");
                    return;
                }
                if (context.Session["CheckCode"].ToString().ToLower().Equals(UserCheckCode.ToLower()))
                {
                    var users = new BLL.Sys_Users().GetModelList("UserNickName = '" + UserName + "'");
                    if (users == null || users.Count == 0)
                    {
                        users = new BLL.Sys_Users().GetModelList("Email = '" + UserName + "'");
                        if (users == null || users.Count == 0)
                        {
                            context.Response.Write("该用户不存在，请重新输入！");
                            return;
                        }
                    }

                    if (users.FirstOrDefault().Password == DESEncrypt.Encrypt(PWD))
                    {
                        SiteSessionInfo oSession = LoginUtil.GetSession();
                        oSession.sCustomer = users.FirstOrDefault();
                        HttpContext.Current.Session["SiteSessionInfo"] = oSession;

                        CookieUtil.SetCookieByDES(CookieUtil.Cookie_RemeberMe, (users.FirstOrDefault().Sys_UserId != null) ? users.FirstOrDefault().Sys_UserId.ToString().Replace("{", "").Replace("}", "") : users.FirstOrDefault().Sys_UserId.ToString(), DateTime.MaxValue);

                        context.Session["UserSessionId"] = users.FirstOrDefault().Sys_UserId.ToString();
                        users.FirstOrDefault().LoginTimes += 1;
                        users.FirstOrDefault().LastLoginIp = context.Request.UserHostAddress;
                        users.FirstOrDefault().LastLoginTime = DateTime.Now;

                        new BLL.Sys_Users().Update(users.FirstOrDefault());

                        context.Response.Write("OK");
                    }
                    else
                    {
                        context.Response.Write("账户名或密码错误，请重新输入");
                        return;
                    }

                }
                else
                {
                    context.Response.Write("验证码输入错误，请重新输入");
                    return;
                }
            }
            catch (Exception err)
            {
                Logger.Warn(err.Message, err.StackTrace);
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}