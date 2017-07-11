using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Configuration;
using System.Net.Mail;
using System.Text;
using System.Web.Configuration;

namespace Maticsoft.Common
{
    public static class GoBidingEmailSender
    {
        /// <summary>
        /// 从web.config中获取全局SMTP配置
        /// </summary>
        private static readonly SmtpSection DefaultSmtpSection = NetSectionGroup.GetSectionGroup(
                                WebConfigurationManager.OpenWebConfiguration("/web.config")).MailSettings.Smtp;
        private static readonly string DEFAULT_MAIL_SUBJECT = "默认主题";

        /// <summary>
        /// 从数据库EmailCategory中获取SMTP配置
        /// </summary>
        /// <param name="fromUserName"></param>
        /// <returns></returns>
        public static SmtpSection getSmtpSection()
        {
            SmtpSection smtpSection = null;

            smtpSection = new SmtpSection();
            smtpSection.Network.Host = DefaultSmtpSection.Network.Host;
            smtpSection.Network.UserName = DefaultSmtpSection.Network.UserName;
            smtpSection.Network.Password = "19870609040223Yu";
            smtpSection.Network.Port = 25;
            smtpSection.From = "postmaster@gobiding.com";
            
            return smtpSection;
        }

        /// <summary>
        /// 基础发送邮件函数
        /// </summary>
        /// <param name="server">发送邮件服务器</param>
        /// <param name="cfg">SmtpSection配置类</param>
        /// <param name="isEnableSsl">是否支持ssl</param>
        /// <param name="receivers">收件人</param>
        /// <param name="subject">主题</param>
        /// <param name="body">邮件内容</param>
        /// <param name="isBodyHtml">是否支持html</param>
        /// <param name="encoding">编码格式</param>
        /// <param name="isAuthentication">是否需要验证</param>
        /// <param name="files">附件列表</param>
        public static void Send(string server, SmtpSection cfg, bool isEnableSsl, List<string> receivers, string subject,
                string body, bool isBodyHtml, Encoding encoding, bool isAuthentication, params string[] files)
        {
            SmtpClient smtpClient;
            if (!string.IsNullOrEmpty(server))
                smtpClient = new SmtpClient(server);
            else
                smtpClient = new SmtpClient(cfg.Network.Host);
            //smtpClient.EnableSsl = isEnableSsl;

            MailMessage message = new MailMessage();

            message.IsBodyHtml = isBodyHtml;
            message.SubjectEncoding = encoding;
            message.BodyEncoding = encoding;
            message.Subject = subject;
            message.Body = body;

            //收件人
            if (receivers.Count <= 0)
                return;
            foreach (string receiver in receivers)
            {
                message.To.Add(new MailAddress(receiver));
            }

            //附件
            message.Attachments.Clear();
            if (files != null && files.Length != 0)
            {
                for (int i = 0; i < files.Length; ++i)
                {
                    Attachment attach = new Attachment(files[i]);
                    message.Attachments.Add(attach);
                }
            }

            //身份验证
            if (isAuthentication == true)
            {
                smtpClient.UseDefaultCredentials = true;
                smtpClient.Credentials = new NetworkCredential(cfg.Network.UserName, cfg.Network.Password);
            }

            smtpClient.Send(message);
        }
    }

}
