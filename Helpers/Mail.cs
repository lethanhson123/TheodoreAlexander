using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace TA.Helpers
{
    public class Mail
    {

        public string FromMail { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Display { get; set; }

        public string ToMail { get; set; }
        public string CCMail { get; set; }
        public string BCCMail { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public string AttachmentFiles { get; set; }

        public string SMTPServer { get; set; }

        public int SMTPPort { get; set; }

        public bool IsUsingSSL { get; set; }

        public bool IsMailBodyHtml { get; set; }

        public Mail()
        {
            if (string.IsNullOrEmpty(this.SMTPServer))
            {
                this.SMTPServer = AppGlobal.SMTPServer;
            }
            if (string.IsNullOrEmpty(this.FromMail))
            {
                this.FromMail = AppGlobal.MasterEmail;
            }
            if (string.IsNullOrEmpty(this.ToMail))
            {
                this.ToMail = AppGlobal.ToEmail;
            }
            if (string.IsNullOrEmpty(this.Username))
            {
                this.Username = AppGlobal.MasterEmailUser;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                this.Password = AppGlobal.MasterEmailPassword;
            }
            if (string.IsNullOrEmpty(this.Display))
            {
                this.Display = AppGlobal.MasterEmailDisplay;
            }
            if (string.IsNullOrEmpty(this.Subject))
            {
                this.Subject = AppGlobal.MasterEmailSubject;
            }
            if (this.SMTPPort == 0)
            {
                this.SMTPPort = AppGlobal.SMTPPort;
            }
            this.IsMailBodyHtml = false;
            this.IsUsingSSL = false;
            if (AppGlobal.IsMailBodyHtml == 1)
            {
                this.IsMailBodyHtml = true;
            }
            if (AppGlobal.IsMailUsingSSL == 1)
            {
                this.IsUsingSSL = true;
            }
        }
        public static SmtpClient Initialization(Mail mail)
        {
            if (mail != null)
            {
                SmtpClient client = new SmtpClient()
                {
                    EnableSsl = false,
                    Host = mail.SMTPServer,
                    Port = mail.SMTPPort,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(mail.Username, mail.Password),
                };
                return client;
            }
            return null;
        }

        public static MailMessage WriteMessage(Mail mail)
        {
            if (mail != null)
            {
                MailMessage message = new MailMessage()
                {
                    IsBodyHtml = mail.IsMailBodyHtml,
                    Subject = mail.Subject,
                    Body = mail.Body,
                    //Priority = MailPriority.High,
                    BodyEncoding = Encoding.GetEncoding("UTF-8"),
                    From = new MailAddress(mail.FromMail, mail.Display),
                };
                if (!string.IsNullOrEmpty(mail.AttachmentFiles))
                {
                    foreach (string attachmentFile in mail.AttachmentFiles.Split(';'))
                    {
                        if (!string.IsNullOrEmpty(attachmentFile))
                        {
                            System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(mail.AttachmentFiles);
                            message.Attachments.Add(attachment);
                        }
                    }
                }
                if (!string.IsNullOrEmpty(mail.ToMail))
                {
                    mail.ToMail = mail.ToMail.Replace(@";", @",");
                    message.To.Add(mail.ToMail);
                }
                if (!string.IsNullOrEmpty(mail.CCMail))
                {
                    message.CC.Add(mail.CCMail);
                }
                if (!string.IsNullOrEmpty(mail.BCCMail))
                {
                    message.Bcc.Add(mail.BCCMail);
                }
                return message;
            }
            return null;
        }
        public static void Send(Mail mail)
        {
            var client = Initialization(mail);
            if (client != null)
            {
                var message = WriteMessage(mail);
                client.Send(message);
            }
        }
        public static int SendNotUserNameAndPassword(Mail mail)
        {
            string result = AppGlobal.InitializationString;
            string smtpServer = mail.SMTPServer;
            MailAddress fromAddress = new MailAddress(mail.FromMail, mail.Display);
            MailAddress toAddress = new MailAddress(mail.ToMail);
            MailMessage mailMessage = new MailMessage(fromAddress, toAddress)
            {
                Subject = mail.Subject,
                Body = mail.Body,
                IsBodyHtml = true
            };
            using (var smtpClient = new SmtpClient(smtpServer))
            {
                smtpClient.UseDefaultCredentials = false;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.EnableSsl = false;
                smtpClient.SendCompleted += (s, e) => { smtpClient.Dispose(); };
                smtpClient.Send(mailMessage);
            }
            return 1;
        }
        public static Exception SendNotUserNameAndPassword001(Mail mail)
        {
            Exception result = new Exception();
            try
            {
                string smtpServer = mail.SMTPServer;
                MailAddress fromAddress = new MailAddress(mail.FromMail, mail.Display);
                MailAddress toAddress = new MailAddress(mail.ToMail);
                MailMessage mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = mail.Subject,
                    Body = mail.Body,
                    Priority = MailPriority.High,
                    IsBodyHtml = true
                };
                using (var smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = false;
                    smtpClient.SendCompleted += new SendCompletedEventHandler(smtp_SendCompleted);
                    smtpClient.Send(mailMessage);
                }
            }
            catch (Exception e)
            {
                result = e;
            }
            return result;
        }
        private static void smtp_SendCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true || e.Error != null)
            {
                throw new Exception(e.Cancelled ? "EMail sedning was canceled." : "Error: " + e.Error.ToString());
            }
        }
        public static async Task<string> AsyncSendNotUserNameAndPassword(Mail mail)
        {
            string result = AppGlobal.InitializationString;
            try
            {
                string smtpServer = mail.SMTPServer;
                MailAddress fromAddress = new MailAddress(mail.FromMail, mail.Display);
                MailAddress toAddress = new MailAddress(mail.ToMail);                
                MailMessage mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = mail.Subject,
                    Body = mail.Body,
                    Priority = MailPriority.High,
                    IsBodyHtml = true
                };
                using (var smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = false;
                    smtpClient.SendCompleted += (s, e) => { smtpClient.Dispose(); };
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        public static async Task<string> AsyncSendMail()
        {
            string result = AppGlobal.InitializationString;
            try
            {
                string smtpServer = "p1smtp.tahl.com";
                MailAddress fromAddress = new MailAddress("no-reply@theodorealexander.com", "TA");
                MailAddress toAddress = new MailAddress("ltson@theodorealexander.com", "HR");
                MailMessage mailMessage = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "Tuyển dụng - " + AppGlobal.InitializationDateTimeCode,
                    Body = "OK",
                    IsBodyHtml = true
                };
                using (var smtpClient = new SmtpClient(smtpServer))
                {
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtpClient.EnableSsl = false;
                    smtpClient.SendCompleted += (s, e) => { smtpClient.Dispose(); };
                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        public static string SendMail001(Mail mail)
        {
            string result = AppGlobal.InitializationString;
            try
            {
                System.Net.Mail.MailMessage smail = new System.Net.Mail.MailMessage();
                smail.IsBodyHtml = mail.IsMailBodyHtml;
                smail.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                smail.From = new System.Net.Mail.MailAddress(mail.FromMail, mail.Display);
                foreach (string toMailAddress in mail.ToMail.Split(','))
                {
                    if (!string.IsNullOrEmpty(toMailAddress))
                    {
                        smail.To.Add(new System.Net.Mail.MailAddress(toMailAddress));
                    }
                }
                smail.Subject = mail.Subject;
                smail.Body = mail.Body;
                smail.Priority = MailPriority.High;
                System.Net.Mail.SmtpClient Client = new System.Net.Mail.SmtpClient();
                Client.EnableSsl = mail.IsUsingSSL;
                Client.Host = mail.SMTPServer;
                Client.Port = mail.SMTPPort;
                System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(mail.Username, mail.Password);
                Client.Credentials = theCredential;
                Client.Send(smail);
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
        public static async Task<string> AsyncSendMail001(Mail mail)
        {
            string result = AppGlobal.InitializationString;
            try
            {
                System.Net.Mail.MailMessage smail = new System.Net.Mail.MailMessage();
                smail.IsBodyHtml = mail.IsMailBodyHtml;
                smail.BodyEncoding = System.Text.Encoding.GetEncoding("UTF-8");
                smail.From = new System.Net.Mail.MailAddress(mail.FromMail, mail.Display);
                foreach (string toMailAddress in mail.ToMail.Split(','))
                {
                    if (!string.IsNullOrEmpty(toMailAddress))
                    {
                        smail.To.Add(new System.Net.Mail.MailAddress(toMailAddress));
                    }
                }
                smail.Subject = mail.Subject;
                smail.Body = mail.Body;
                smail.Priority = MailPriority.High;
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
                //client.EnableSsl = mail.IsUsingSSL;
                client.Host = mail.SMTPServer;
                client.Port = mail.SMTPPort;
                System.Net.NetworkCredential theCredential = new System.Net.NetworkCredential(mail.Username, mail.Password);
                //client.Credentials = theCredential;
                await client.SendMailAsync(smail);
            }
            catch (Exception e)
            {
                result = e.Message;
            }
            return result;
        }
    }
}
