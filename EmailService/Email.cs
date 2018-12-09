using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Runtime.Remoting.Messaging;

namespace EmailService
{
    public class Email
    {
        private static void SendEmail(EmailOptions emailOptions)
        {
            try
            {
                MailAddress fromAddress = new MailAddress(EmailConstant.EmailFromAddress, EmailConstant.EmailFromDisplayName);
                string fromPassword = EmailConstant.EmailFromAddressPassword;

                SmtpClient smtpClient = GetSmtpClient(fromAddress.Address, fromPassword, Provider.Akij);
                if (smtpClient != null)
                {

                    var message = new MailMessage
                    {
                        From = fromAddress,
                        Subject = emailOptions.Subject,
                        Body = emailOptions.Body,
                        IsBodyHtml = true
                    };
                    foreach (string address in emailOptions.ToAddress)
                    {
                        message.To.Add(new MailAddress(address, emailOptions.ToAddressDisplayName));
                    }
                    foreach (string address in emailOptions.CcAddress)
                    {
                        message.CC.Add(new MailAddress(address, emailOptions.ToAddressDisplayName));
                    }
                    foreach (string address in emailOptions.BccAddress)
                    {
                        message.Bcc.Add(new MailAddress(address, emailOptions.ToAddressDisplayName));
                    }
                    foreach (string filePath in emailOptions.Attachment)
                    {
                        Attachment attachment = new Attachment(filePath);
                        message.Attachments.Add(attachment);
                        
                    }
                    ServicePointManager.ServerCertificateValidationCallback =
                        (s, certificate, chain, sslPolicyErrors) => true;
                    smtpClient.Send(message);
                    foreach (string filePath in emailOptions.Attachment)
                    {
                        Utility.FileHelper.DeleteFile(filePath);

                    }

                }
                else
                {
                    //todo
                }

            }
            catch (Exception e)
            {

                if (e.InnerException != null)
                {
                }

                //todo
            }
        }
        private static SmtpClient GetSmtpClient(string email, string password, Provider provider)
        {
            switch (provider)
            {
                case Provider.Gmail:
                    return GetSmtpForGmail(email, password);
                case Provider.Yahoo:
                    return GetSmtpForYahoo(email, password);
                case Provider.HotMail:
                    return GetSmtpForHotmail(email, password);
                case Provider.Akij:
                    return GetSmtpForAkij(email, password);
                default:
                    return null;
            }

        }

        private static SmtpClient GetSmtpForGmail(string email, string password)
        {
            return new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,

                Credentials = new NetworkCredential(email, password)
            };
        }
        private static SmtpClient GetSmtpForYahoo(string email, string password)
        {
            //Todo: Prepare For Yahoo
            return null;
        }
        private static SmtpClient GetSmtpForHotmail(string email, string password)
        {
            //Todo: Prepare For hotmail
            return null;
        }
        private static SmtpClient GetSmtpForAkij(string email, string password)
        {
            return new SmtpClient
            {
                Host = "ex5.akij.net",
                Port = 587,
                EnableSsl = false,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = true,

                Credentials = new NetworkCredential(email, password)
            };
        }
        public enum Provider
        {
            Gmail,
            Yahoo,
            HotMail,
            Akij
        }
        public static bool Send(EmailOptions emailOptions)
        {
            try
            {
                AsyncMethodCaller caller = new AsyncMethodCaller(SendMailInSeperateThread);
                AsyncCallback callbackHandler = new AsyncCallback(AsyncCallback);
                caller.BeginInvoke(emailOptions, callbackHandler, emailOptions);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
        private delegate void AsyncMethodCaller(EmailOptions emailOptions);
        private static void SendMailInSeperateThread(EmailOptions emailOptions)
        {
            SendEmail(emailOptions);
        }
        private static void AsyncCallback(IAsyncResult ar)
        {
            try
            {

                AsyncResult result = (AsyncResult)ar;
                EmailOptions option = (EmailOptions)ar.AsyncState;
                AsyncMethodCaller caller = (AsyncMethodCaller)result.AsyncDelegate;
                foreach (string filePath in option.Attachment)
                {
                    Utility.FileHelper.DeleteFile(filePath);
                }
                caller.EndInvoke(ar);
            }
            catch (Exception e)
            {
                //Todo: 
            }
        }
        public static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public static List<string> GetMaiListFromString(string address,out string message)
        {
            List<string> mailList = new List<string>();
            if (!string.IsNullOrWhiteSpace(address))
            {
                char[] delimiters = { ',', ';', ' ' };
                string[] addresss = address.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
                foreach (string email in addresss)
                {
                    if (IsValidEmail(email))
                    {
                        mailList.Add(email);
                    }
                    else
                    {
                        message = "Please input valid email \"" + email + "\" '";
                        return null;
                    }

                }

            }
            else
            {
                message = "There Should be atleast 1 email address";
                return null;
            }
            message = "added successfully";
            return mailList;
        }
    }
}
