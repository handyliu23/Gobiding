using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using Maticsoft.Common.DEncrypt;
using GoBiding.BLL;

namespace GoBiding.Web
{
    /// <summary>
    /// Summary description for BindAccount1
    /// </summary>
    public class BindAccountHandle : IHttpHandler, IRequiresSessionState
    {
        private BLL.Sys_Users userBLL = new BLL.Sys_Users();

        public Model.CatchCompany CreateCompany(string companyname)
        {
            //新增一个企业
            var cc = new Model.CatchCompany();
            cc.VendorName = companyname;
            cc.OnCreated = DateTime.Now;
            cc.CreatedDate = DateTime.Now.ToString();
            cc.Id = new BLL.CatchCompany().Add(cc);

            return cc;
        }

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                context.Response.ContentType = "text/plain";

                if (context.Request["Email"] == null || !CommonUtility.IsEmail(context.Request["Email"].ToString()))
                {
                    context.Response.Write("请输入有效的邮箱！");
                    return;
                }

                if (context.Request["CompanyName"] == null || string.IsNullOrEmpty(context.Request["CompanyName"].ToString()))
                {
                    context.Response.Write("请输入企业名称！");
                    return;
                }

                if (context.Session["UserSessionOpenId"] == null)
                {
                    context.Response.Write("登录失效，请重新登录");
                    return;
                }

                string openId = context.Session["UserSessionOpenId"].ToString();
                var users = userBLL.GetModelList(" Deleted <> 1 and openId = '" + openId + "'");
                if (users == null || users.Count == 0)
                {
                    context.Response.Write("登录失效，请重新登录");
                    return;
                }

                var user = users.FirstOrDefault();
                string companyName = context.Request["CompanyName"].ToString();

                var companyexists = new BLL.CatchCompany().GetModelList("VendorName = '" + companyName + "'");
                Model.CatchCompany company = null;
                if (companyexists == null || companyexists.Count == 0)
                {
                    company = CreateCompany(companyName);
                    BLL.Logger.Info("CreateCompany,Id:" + company.Id.ToString(), "");

                }
                else {
                    company = companyexists.FirstOrDefault();
                }

                if (context.Request["Type"] != null)
                {
                    string Type = context.Request["Type"].ToString().Trim();
                    if (Type.ToLower().Equals("new"))
                    {
                        string Email = context.Request["Email"].ToString().Trim();
                        user.Email = Email;
                        user.CompanyName = companyName;
                        user.CompanyId = company.Id;
                        BLL.Logger.Info("Update User,CompanyId:" + user.CompanyId.ToString(), "");

                        userBLL.Update(user);

                        context.Session["UserSessionId"] = user.Sys_UserId;
                        context.Response.Write("OK");

                    }
                    else if (Type.ToLower().Equals("old"))  //如果绑定老的，把新生成的user表数据删除，将openId 赋值到老的账户中
                    {
                        string email = context.Request["Email"].ToString().Trim();
                        string pwd = context.Request["Password"].ToString().Trim();

                        var oldUsers = userBLL.GetModelList(" Deleted <>1 and email = '" + email + "' and Password = '" + DESEncrypt.Encrypt(pwd) + "'");
                        if (oldUsers != null && oldUsers.Count > 0)
                        {
                            var oldUser = oldUsers.FirstOrDefault();

                            user.CompanyName = companyName;
                            oldUser.OpenId = user.OpenId;
                            user.CompanyId = company.Id;

                            userBLL.Update(oldUser);
                            if (user.Sys_UserId != oldUser.Sys_UserId)
                            {
                                userBLL.Delete(user.Sys_UserId);
                            }
                            context.Session["UserSessionId"] = oldUser.Sys_UserId;
                            context.Response.Write("OK");
                        }
                        else
                        {
                            context.Response.Write("绑定的用户不存在");
                        }
                    }
                }
            }
            catch (Exception err)
            {
                BLL.Logger.Warn(err.Message, err.StackTrace);
                context.Response.Write("处理异常");
                return;
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