using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace DotnetBookCloud.Utils
{
    public class MailInfo
    {
        public String MailTo { get; set; }
        public String MailSubject { get; set; }
        public String MailContent { get; set; }
        public String SmtpServer { get; set; }
        public String MailFrom { get; set; }
        public String UserPassword { get; set; }
    }
    public class MailHelper
    {
        public static void Execute(object obj)
        {
            MailInfo info = (MailInfo)obj;
            if (info != null)
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Host = info.SmtpServer; 

                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = false;
                smtpClient.Credentials = new System.Net.NetworkCredential(info.MailFrom, info.UserPassword);
     
                MailMessage mailMessage = new MailMessage(info.MailFrom, info.MailTo);
                mailMessage.Subject = info.MailSubject;
                mailMessage.Body = info.MailContent;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.IsBodyHtml = true;
                mailMessage.Priority = MailPriority.Low;
                smtpClient.Send(mailMessage); 

            }
        }

    }
}
