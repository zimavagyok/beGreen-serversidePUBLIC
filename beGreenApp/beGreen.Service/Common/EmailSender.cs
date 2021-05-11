using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;

namespace beGreen.Services.Common
{
    public static class EmailSender
    {
        private const string supportEmail = "support@portalnekretnine.com";

        public static void SendEmail(string email, string subject, string message)
        {
            try
            {
                SmtpClient client = SmtpClientConfiguration();

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(supportEmail);
                mailMessage.To.Add(email);
                mailMessage.Body = message;
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;

                client.Send(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async void SendEmailAsync(string email, string subject, string message)
        {
            try
            {
                SmtpClient client = SmtpClientConfiguration();

                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(supportEmail);
                mailMessage.Body = message;
                mailMessage.To.Add(email);
                mailMessage.Subject = subject;
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = Encoding.UTF8;
                mailMessage.SubjectEncoding = Encoding.UTF8;

                AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message);
                htmlView.ContentType = new ContentType("text/html");

                mailMessage.AlternateViews.Add(htmlView);

                await client.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static async void SendEmailAsync(string email, string subject, string message, byte[] data)
        {
            SmtpClient client = SmtpClientConfiguration();

            Stream attachment = new MemoryStream(data);

            // Create  the file attachment for this e-mail message.
            Attachment pdfAttachment = new Attachment(attachment, MediaTypeNames.Application.Pdf);
            pdfAttachment.ContentType = new ContentType("application/pdf");
            pdfAttachment.Name = "portalnekretnine.pdf";
            // Add time stamp information for the file.
            ContentDisposition disposition = pdfAttachment.ContentDisposition;
            disposition.CreationDate = DateTime.Now;

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(supportEmail);
            mailMessage.To.Add(email);
            mailMessage.Body = message;
            mailMessage.Subject = subject;
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.SubjectEncoding = Encoding.UTF8;

            AlternateView htmlView = AlternateView.CreateAlternateViewFromString(message);
            htmlView.ContentType = new ContentType("text/html");

            mailMessage.AlternateViews.Add(htmlView);

            // Add the file attachment to this e-mail message.
            mailMessage.Attachments.Add(pdfAttachment);

            await client.SendMailAsync(mailMessage);
        }

        private static SmtpClient SmtpClientConfiguration()
        {
            SmtpClient client = new SmtpClient("mail.portalnekretnine.com");
            client.Port = 587;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential("support", "zQH#+8D-4ejz95eD");
            client.EnableSsl = true;

            return client;
        }
    }
}
