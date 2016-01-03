using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;

namespace LifeScan.Models
{
    public static class Email
    {
        //新用户注册后提醒管理员
        public static string RegisterReminder(string emailbody)
        {
            bool status = false;
            try
            {


                MailMessage msgMail = new MailMessage();

                msgMail.BodyEncoding = System.Text.Encoding.UTF8;

                //格式
                msgMail.BodyFormat = MailFormat.Html;
                //接受者
                msgMail.To = System.Configuration.ConfigurationManager.AppSettings["LifeScanMailTo"].ToString(); ;
                //发送者
                // msgMail.From = System.Configuration.ConfigurationSettings.AppSettings["LifeScanMailFrom"].ToString();
                msgMail.From = System.Configuration.ConfigurationManager.AppSettings["LifeScanMailFrom"].ToString();
                //标题
                msgMail.Subject = "强生血糖仪用户新用户注册";
                msgMail.Priority = MailPriority.High;
                msgMail.Body = emailbody;

                msgMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");     //认证类型
                msgMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", System.Configuration.ConfigurationManager.AppSettings["LifeScanMailFrom"].ToString());    //要认证的用户名
                msgMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings["LifeScanMailPassword"].ToString());    //要认证的密码 

                //邮件主机
                SmtpMail.SmtpServer = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"].ToString();

                //发送邮件
                SmtpMail.Send(msgMail);

                status = true;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
       //密码找回时候使用
        public static string FindPWDByEmail(string EmailTo,string emailbody)
        {
            bool status = false;
            try
            {
 

                MailMessage msgMail = new MailMessage();

                msgMail.BodyEncoding = System.Text.Encoding.UTF8;

                //格式
                msgMail.BodyFormat = MailFormat.Html;
                //接受者

                msgMail.To = EmailTo;
                //发送者
                // msgMail.From = System.Configuration.ConfigurationSettings.AppSettings["LifeScanMailFrom"].ToString();
                msgMail.From = System.Configuration.ConfigurationManager.AppSettings["LifeScanMailFrom"].ToString();
                //标题
                msgMail.Subject = "强生血糖仪用户密码重置";
                msgMail.Priority = MailPriority.High;
                msgMail.Body = emailbody;

                msgMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");     //认证类型
                msgMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", System.Configuration.ConfigurationManager.AppSettings["LifeScanMailFrom"].ToString());    //要认证的用户名
                msgMail.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", System.Configuration.ConfigurationManager.AppSettings["LifeScanMailPassword"].ToString());    //要认证的密码 

                //邮件主机
                SmtpMail.SmtpServer = System.Configuration.ConfigurationManager.AppSettings["SMTPServer"].ToString();

                //发送邮件
                SmtpMail.Send(msgMail);

                status = true;
            }
            catch (System.Exception ex)
            {
                return ex.Message;
            }

            return "";
        }
    }
}