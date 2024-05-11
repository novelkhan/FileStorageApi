using FileStorageApi.DTOs.Account;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using MailKit.Security;
using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;

namespace FileStorageApi.Services
{
    public class EmailService
    {
        private readonly IConfiguration _config;

        public EmailService(IConfiguration config)
        {
            _config = config;
        }

        public async Task<bool> SendEmailAsync(EmailSendDto emailSend)
        {
            //var isEmailSent = await EmailSendViaOutlookAsync(_config["Outlook:EmailAddress"],
            //                                    _config["Outlook:Password"],
            //                                    int.Parse(_config["Outlook:Port"]),
            //                                    _config["Outlook:Host"],
            //                                    emailSend);


            //var isEmailSent =  EmailSendViaOutlook(_config["Outlook:EmailAddress"],
            //                                    _config["Outlook:Password"],
            //                                    int.Parse(_config["Outlook:Port"]),
            //                                    _config["Outlook:Host"],
            //                                    emailSend);


            //var isEmailSent = await EmailSendViaGmailAsync(_config["Gmail:EmailAddress"],
            //                                    _config["Gmail:Password"],
            //                                    int.Parse(_config["Gmail:Port"]),
            //                                    _config["Gmail:Host"],
            //                                    emailSend);



            var isEmailSent = EmailSendViaGmail(_config["Gmail:EmailAddress"],
                                                _config["Gmail:TwoFactorPassword"],
                                                int.Parse(_config["Gmail:Port"]),
                                                _config["Gmail:Host"],
                                                emailSend);


            return isEmailSent;
        }


        public bool EmailSendViaGmail(string emailAddress, string twoFactorPassword, int port, string host, EmailSendDto emailSend)
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(emailAddress));
            email.To.Add(MailboxAddress.Parse(emailSend.To));
            email.Subject = emailSend.Subject;
            email.Body = new TextPart(TextFormat.Html) { Text = emailSend.Body };

            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(host, port, SecureSocketOptions.StartTls);
            smtp.Authenticate(emailAddress, twoFactorPassword);
            try
            {
                smtp.Send(email);
            }
            catch (System.Net.Mail.SmtpFailedRecipientException ex)
            {
                // ex.FailedRecipient and ex.GetBaseException() should give you enough info.
                ex.GetBaseException();
                smtp.Disconnect(true);
                return false;
            }
            smtp.Disconnect(true);

            return true;
        }







        public async Task<bool> EmailSendViaGmailAsync(string emailAddress, string Password, int port, string host, EmailSendDto emailSend)
        {
            try
            {
                var smtpClient = new System.Net.Mail.SmtpClient(host, port)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(emailAddress, Password)
                };

                var message = new MailMessage(from: emailAddress, to: emailSend.To, subject: emailSend.Subject, body: emailSend.Body);

                message.IsBodyHtml = true;
                await smtpClient.SendMailAsync(message);
                //smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }







        public bool EmailSendViaOutlook(string emailAddress, string Password, int port, string host, EmailSendDto emailSend)
        {
            try
            {
                var smtpClient = new System.Net.Mail.SmtpClient(host, port)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(emailAddress, Password)
                };

                var message = new MailMessage(from: emailAddress, to: emailSend.To, subject: emailSend.Subject, body: emailSend.Body);

                message.IsBodyHtml = true;
                //smtpClient.SendMailAsync(message);
                smtpClient.Send(message);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }




        public async Task<bool> EmailSendViaOutlookAsync(string emailAddress, string Password, int port, string host, EmailSendDto emailSend)
        {
            try
            {
                var smtpClient = new System.Net.Mail.SmtpClient(host, port)
                {
                    EnableSsl = true,
                    Credentials = new NetworkCredential(emailAddress, Password)
                };

                var message = new MailMessage(from: emailAddress, to: emailSend.To, subject: emailSend.Subject, body: emailSend.Body);

                message.IsBodyHtml = true;
                await smtpClient.SendMailAsync(message);
                //smtpClient.Send(message);
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}
