using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using DAL;
using System.Net.Mail;
using System.Net;
using System.Data.Entity;
using System.Configuration;

namespace TA_Web_2020_API.Helper
{
    public class EmailJob : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                using (var _ctx = new TheodoreAlexanderEntities())
                {
                    var lstEmail = await _ctx.SubcribedEmails.AsNoTracking().ToListAsync();
                    // Get info to send (xml)


                    if (lstEmail.Count > 0)
                    {
                        string smtpServer = ConfigurationManager.AppSettings["SMTPserver"];
                        //using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                        using (var smtpClient = new SmtpClient(smtpServer))
                        {
                            using (var mailMessage = new MailMessage())
                            {
                                mailMessage.From = new MailAddress("duyhau.206@gmail.com");
                                foreach (var email in lstEmail)
                                {
                                    var mailTo = new MailAddress(email.Email);
                                    mailMessage.To.Add(mailTo);
                                }
                                mailMessage.Subject = "Test auto send email";
                                mailMessage.Body = "Nhận được email không?";
                                mailMessage.IsBodyHtml = true;
                                //smtpClient.EnableSsl = true;
                                smtpClient.UseDefaultCredentials = false;
                                //smtpClient.Credentials = new NetworkCredential("duyhau.206@gmail.com", "08110039");
                                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtpClient.SendCompleted += (s, e) => { smtpClient.Dispose(); };
                                await smtpClient.SendMailAsync(mailMessage);
                            }
                        }
                    }
                }
                //using (var smtpClient = new SmtpClient("smtp.gmail.com", 587))
                //{
                //    using (var mailMessage = new MailMessage())
                //    {
                //        mailMessage.From = new MailAddress("duyhau.206@gmail.com");
                //        var mailTo = new MailAddress("hdhau@theodorealexander.com");
                //        mailMessage.To.Add(mailTo);
                //        //foreach (var email in lstEmail)
                //        //{
                //        //    var mailTo = new MailAddress(email.Email);
                //        //    mailMessage.To.Add(mailTo);
                //        //}
                //        mailMessage.Subject = "Test auto send email";
                //        mailMessage.Body = "Nhận được email không?";
                //        mailMessage.IsBodyHtml = true;
                //        smtpClient.EnableSsl = true;
                //        smtpClient.UseDefaultCredentials = false;
                //        smtpClient.Credentials = new NetworkCredential("duyhau.206@gmail.com", "08110039");
                //        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                //        smtpClient.SendCompleted += (s, e) => { smtpClient.Dispose(); };
                //        await smtpClient.SendMailAsync(mailMessage);
                //    }
                //}

            }
            catch(Exception e)
            {
                throw e;
            }
        }
    }
}