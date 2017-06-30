using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GoBiding.Model;
using GoBiding.Web.BaseCode;
using Maticsoft.Common;
using Maticsoft.DBUtility;
using Newtonsoft.Json;
using System.Web.SessionState;

namespace GoBiding.Web.wap.handlers
{
    /// <summary>
    /// waplogin 的摘要说明
    /// </summary>
    public class waplogin : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";

                string UserName = context.Request["UserName"].ToString();
                string PWD = context.Request["PWD"].ToString();
                string redirect = context.Request["Redirect"] == null ? string.Empty : context.Request["Redirect"].ToString();

                var users = new BLL.Sys_Users().GetModelList("UserNickName = '" + UserName + "'");
                if (users == null || users.Count == 0)
                {
                    context.Response.Write("不存在该用户.");
                }
                else
                {
                    if (users.FirstOrDefault().Password == DESEncrypt.Encrypt(PWD))
                    {
                        //选中让
                        CookieUtil.SetCookieByDES(CookieUtil.Cookie_RemeberMe, JsonConvert.SerializeObject(users.FirstOrDefault()), DateTime.MaxValue);
                        context.Session["UserSessionId"] = users.FirstOrDefault().Sys_UserId;
                        string redirecturl = redirect;
                        if (string.IsNullOrEmpty(redirecturl))
                        {
                            redirecturl = "/wap/Default.aspx";
                        }
                        context.Response.Write("OK");
                        context.Response.Flush();  
                        return;
                    }
                    else
                    {
                        context.Response.Write("用户名密码错误.");
                    }
                }

                context.Response.Write("fail");
            }
            catch (Exception err)
            {
                new GoBiding.BLL.WeiXinMessage().Add(new GoBiding.Model.WeiXinMessage()
                {
                    WeiXinMesssageType = "waplogin err",
                    MessageTime = DateTime.Now,
                    MessageContent = err.Message
                });

                context.Response.Write(err.Message);
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