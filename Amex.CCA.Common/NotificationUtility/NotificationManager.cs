using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Amex.CCA.Common.NotificationUtility
{
    public static class NotificationManager
    {
        //read the config settings
        private static NameValueCollection notificationManagerSettings =
            ConfigurationManager.GetSection("notificationManagerSettings") as NameValueCollection;

        /// <summary>
        /// Send an mail.
        /// </summary>
        /// <param name="email">an Email with relavnt details</param>
        /// <returns>NotificationResult indicating the status</returns>
        public static NotificationResult SendMail(Email email)
        {
            try
            {
                MailMessage message = GetMailMessage(email);
                SmtpClient client = GetSmtpClient();
                client.Send(message);
                return new NotificationResult()
                {
                    IsSuccess = true
                };
            }
            catch (Exception exception)
            {
                return new NotificationResult()
                {
                    IsSuccess = false,
                    Message = exception.Message
                };
            }
        }

        #region Private methods

        /// <summary>
        /// Gets the SMTP client.
        /// </summary>
        /// <returns>SmtpClient</returns>
        private static SmtpClient GetSmtpClient()
        {
            //create smtp client
            SmtpClient client = new SmtpClient(notificationManagerSettings["smtpHost"], int.Parse(notificationManagerSettings["smtpPort"]));
            //if credentials are required
            if (bool.Parse(notificationManagerSettings["useSmtpCredentials"]))
            {
                client.UseDefaultCredentials = false;
                //set the credentials
                client.Credentials = new NetworkCredential(notificationManagerSettings["smtpUserName"], notificationManagerSettings["smtpPassword"]);
            }
            client.EnableSsl = true;
            return client;
        }

        /// <summary>
        /// Gets the MailMessage.
        /// </summary>
        /// <param name="email">an Email with relavnt details</param>
        /// <returns></returns>
        private static MailMessage GetMailMessage(Email email)
        {
            MailMessage message = new MailMessage();
            //if the sender specified on email set the given sender, else set the default sender from configuration
            message.From = new MailAddress(string.IsNullOrEmpty(email.From) ? notificationManagerSettings["defaultEmailSender"] : email.From);
            //set the recipients list
            foreach (var recipient in email.To)
            {
                message.To.Add(recipient);
            }
            //set the Subject
            message.Subject = email.Subject;
            //set the Body
            message.Body = email.Body;
            //set the body as Html
            message.IsBodyHtml = true;
            return message;
        }

        #endregion Private methods
    }
}