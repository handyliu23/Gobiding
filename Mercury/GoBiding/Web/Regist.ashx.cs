using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using GoBiding.BLL;
using GoBiding.Model;
using Maticsoft.DBUtility;
using CatchCompany = GoBiding.Model.CatchCompany;
using Sys_Users = GoBiding.Model.Sys_Users;

namespace GoBiding.Web
{
    /// <summary>
    /// Regist 的摘要说明
    /// </summary>
    public class Regist : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";
                string UserNickName = context.Request["UserNickName"].ToString().Trim();
                string Password = context.Request["Password"].ToString().Trim();
                string UserName = context.Request["UserName"].ToString().Trim();
                string CompanyPosition = context.Request["CompanyPosition"].ToString().Trim();
                string CompanyName = context.Request["CompanyName"].ToString().Trim();
                string Email = context.Request["Email"].ToString().Trim();
                string UserType = context.Request["UserType"].ToString().Trim();

                if (!CommonUtility.CheckInputString(UserNickName) || !CommonUtility.CheckInputString(Password) || !CommonUtility.CheckInputString(UserName)
                    || !CommonUtility.CheckInputString(CompanyPosition) || !CommonUtility.CheckInputString(CompanyName) || !CommonUtility.CheckInputString(Email)
                    || !CommonUtility.CheckInputString(UserType))
                {
                    context.Response.Write("数据包含非法字符！");
                    return;
                }
                if (!CommonUtility.IsMobilePhone(UserNickName))
                {
                    context.Response.Write("请输入正确的手机号！");
                    return;
                }
                if (!string.IsNullOrEmpty(Email) && !CommonUtility.IsEmail(Email))
                {
                    context.Response.Write("请输入有效的邮箱！");
                    return;
                }
                if (new BLL.Sys_Users().GetRecordCount(" UserNickName='" + UserNickName + "'") > 0)
                {
                    context.Response.Write("该手机号已被注册，请直接登录！");
                    return;
                }

                if (!string.IsNullOrEmpty(UserNickName) && !string.IsNullOrEmpty(Password) && !string.IsNullOrEmpty(UserName))
                {
                    Model.Sys_Users user = new Sys_Users();
                    user.UserNickName = UserNickName;
                    user.OnCreate = DateTime.Now;
                    user.Password = DESEncrypt.Encrypt(Password);
                    user.LoginIp = context.Request.UserHostAddress;
                    user.UserName = UserName;
                    user.Email = Email;
                    user.MobilePhone = UserNickName;
                    user.UserLoginType = CommonUtility.GetUserTypeId(UserType);
                    user.Scores = 100;
                    user.LastLoginTime = DateTime.Now;
                    user.LoginTimes = 1;

                    //新增一个企业
                    var ccs = new BLL.CatchCompany().GetModelList("VendorName = '" + CompanyName + "'");
                    var cc = new CatchCompany();

                    if (ccs == null || ccs.Count == 0)
                    {
                        cc.VendorName = CompanyName;
                        cc.ContacterName = UserName;
                        cc.ContacterPosition = CompanyPosition;
                        cc.MobilePhone = UserNickName;
                    }
                    else
                    {
                        cc = ccs.FirstOrDefault();
                        cc.VendorName = CompanyName;
                    }
                    cc.Id = new BLL.CatchCompany().Add(cc);

                    user.CompanyId = cc.Id;
                    user.CompanyName = CompanyName;
                    user.Description = CompanyPosition;
                    user.Sys_UserId = new BLL.Sys_Users().Add(user);

                    context.Session["UserNickName"] = user.UserNickName;
                    context.Session["UserId"] = user.Sys_UserId;
                    context.Session["UserSessionId"] = user.Sys_UserId;

                    //发送注册成功赠送积分提醒
                    Model.Message msg = new Model.Message();
                    msg.Content = "欢迎您，作为去投标网的新用户，系统将自动赠送给您100个金币，您可以在查看招投标信息的过程中通过金币抵扣，去投标网的全体工作人员祝您生活愉快，工作顺心。";
                    msg.Title = "欢迎您，作为去投标网的新用户，系统赠送100个金币";
                    msg.MessageTime = DateTime.Now;
                    msg.IsRead = false;
                    msg.SenderId = 0;
                    msg.MessageType = 1;
                    msg.ReceiverId = user.Sys_UserId;
                    new BLL.Message().Add(msg);

                    context.Response.Write("OK");

                }
                else
                {
                    context.Response.Write("信息不完整！");
                }
            }
            catch(Exception err)
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