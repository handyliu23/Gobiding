using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GoBiding.BLL;
using GoBiding.Common;
using Maticsoft.Common.DEncrypt;
using Maticsoft.Common;

namespace GoBiding.Web
{
    public partial class ForgetPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEmail_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();

            if(!CommonUtility.IsEmail(email))
            {
                ltrMessage.Text = "<font style='color:red;'>请输入正确的邮箱地址!</font>";
                return;
            }
            if (new BLL.Sys_Users().GetRecordCount(" Email='" + email + "'") == 0)
            {
                ltrMessage.Text = "<font style='color:red;'>该邮箱从未被注册，请输入正确的邮箱地址！</font>";
                return;
            }

            var modellist = new BLL.Sys_Users().GetModelList(" Email='" + email + "'");
            if(modellist == null || modellist.Count == 0)
            {
                return;
            }
            string pwd = DESEncrypt.Decrypt(modellist.FirstOrDefault().Password);
            string content = string.Format("亲爱的{0}，您在去投标网(www.gobiding.com)的登录密码是{1},您的密码较简单，建议您修改密码。", modellist.FirstOrDefault().UserNickName, pwd);

            sendMail(new List<string>(){email}, content);

        }

        private void sendMail(List<string> receiveEmaila, string content)
        {
            try
            {
                SmtpSection cfg = GoBidingEmailSender.getSmtpSection();
                GoBidingEmailSender.Send(null, cfg, true, receiveEmaila, "找回密码", content, true, Encoding.UTF8, true, null);
                ltrMessage.Text = "<font style='color:green;'>操作成功，请登录到您的邮箱查看密码</font><Br/><a href='http://www.gobiding.com'>点此登录</a>";
            }
            catch (Exception ex)
            {
                ltrMessage.Text = "邮件发送失败,如多次重试仍然失败，请联系管理员";
            }
        }
    }
}