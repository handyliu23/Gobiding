using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Maticsoft.Common.DEncrypt;

namespace GoBiding.Web
{
    /// <summary>
    /// Summary description for logingateway
    /// 第三方登录专用
    /// </summary>
    public class logingateway : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            try
            {
                string UserNickName = context.Request["UserNickName"].ToString().Trim();
                string Profile = context.Request["Profile"].ToString().Trim();
                string Gender = context.Request["Gender"].ToString().Trim();
                string AccessToken = context.Request["AccessToken"].ToString().Trim();
                string OpenId = context.Request["OpenId"].ToString().Trim();
                string ThirdLoginPartyName = context.Request["ThirdLoginPartyName"].ToString().Trim();

                var userBll = new BLL.Sys_Users();

                var users = userBll.GetModelList("  Deleted <> 1 and ThirdLoginPartyName ='" + ThirdLoginPartyName + "' and OpenId = '" + OpenId + "'");
                Model.Sys_Users user = new Model.Sys_Users();

                //已有openId
                if (users != null && users.Count > 0)
                {
                    user = users.FirstOrDefault();
                    user.LoginTimes += 1;
                    user.LastLoginIp = context.Request.UserHostAddress;
                    user.LastLoginTime = DateTime.Now;
                    user.ThirdLoginPartyName = ThirdLoginPartyName;
                }
                else
                {
                    //没有注册
                    user.AccessToken = AccessToken;
                    user.OpenId = OpenId;
                    user.UserProfile = Profile;
                    user.UserGUID = Guid.NewGuid();
                    user.UserLoginType = 1;
                    user.LoginTimes = 1;
                    user.UserNickName = UserNickName;
                    user.UserName = UserNickName;
                    user.OnCreate = DateTime.Now;
                    user.Scores = 100;
                    if (ThirdLoginPartyName == "QQ")
                    {
                        user.Gender = (Gender == "男" ? 1 : 2);
                    }
                    else if(ThirdLoginPartyName == "WeiXin")
                    {
                        user.Gender = int.Parse(Gender);
                    }
                    user.LoginIp = context.Request.UserHostAddress;
                    user.LastLoginIp = context.Request.UserHostAddress;
                    user.LastLoginTime = DateTime.Now;
                    user.Password = DESEncrypt.Encrypt("123456");
                    user.ThirdLoginPartyName = ThirdLoginPartyName;
                }

                context.Session["UserSessionOpenId"] = OpenId;

                //已有openId
                if (users != null && users.Count > 0)
                {
                    userBll.Update(user);

                    if (string.IsNullOrEmpty(user.Email))   //需要绑定邮箱
                    {
                        context.Response.Write("Bind");
                        return;
                    }
                    else
                    {
                        //只有之前已绑定过邮箱，写登录态
                        context.Session["UserSessionId"] = user.Sys_UserId;
                    }   
                }
                else
                {
                    userBll.Add(user);
                    context.Response.Write("Bind");
                    return;
                }
            }
            catch (Exception err)
            {
                BLL.Logger.Warn("logingateway失败", err.StackTrace);
                context.Response.Write("Fail");
                return;
            }

            context.Response.Write("OK");
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