using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Threading;

namespace Madhuvan.Commonlayer
{
    public static class Email
    {
        public static string MailServerPassword { get; set; }

        public static string MailServerHost { get; set; }

        public static string MailServerEmail { get; set; }

        public static int MailServerPort { get; set; }

        public static bool MailServerEnableSsl { get; set; }

        public static string SendMail(string from, string to, string subject, string body, bool isHtml = false, string bcc = "", string cc = "", string attachmentFileName = "", bool isAsynch = true)
        {
            try
            {
                if (string.IsNullOrEmpty(MailServerPassword))
                    return "MailServerPassword property is not initialized.";
                if (string.IsNullOrEmpty(MailServerHost))
                    return "MailServerHost property is not initialized.";
                if (string.IsNullOrEmpty(from))
                    return "From email address is not initialized.";
                if (string.IsNullOrEmpty(to))
                    return "To email address is not initialized.";
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(from)
                };
                AddReceipt(ReceiptType.To, to, mailMessage);
                AddReceipt(ReceiptType.Bcc, bcc, mailMessage);
                AddReceipt(ReceiptType.Cc, cc, mailMessage);
                AddReceipt(ReceiptType.Attachment, attachmentFileName, mailMessage);
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isHtml;
                return SendMail(from, isAsynch, mailMessage);
            }
            catch (Exception ex)
            {
                return GetErrorMessage(ex);
            }
        }

        public static string SendMailWithFileStream(string from, string to, string subject, string body, bool isHtml = false, string bcc = "", string cc = "", Stream attachmentFile = null, string fileName = "", bool isAsynch = true)
        {
            try
            {
                if (string.IsNullOrEmpty(MailServerPassword))
                    return "MailServerPassword property is not initialized.";
                if (string.IsNullOrEmpty(MailServerHost))
                    return "MailServerHost property is not initialized.";
                if (string.IsNullOrEmpty(from))
                    return "From email address is not initialized.";
                if (string.IsNullOrEmpty(to))
                    return "To email address is not initialized.";
                MailMessage mailMessage = new MailMessage
                {
                    From = new MailAddress(from)
                };
                AddReceipt(ReceiptType.To, to, mailMessage);
                AddReceipt(ReceiptType.Bcc, bcc, mailMessage);
                AddReceipt(ReceiptType.Cc, cc, mailMessage);
                if (attachmentFile != null && !string.IsNullOrEmpty(fileName))
                    mailMessage.Attachments.Add(new Attachment(attachmentFile, fileName));
                mailMessage.Subject = subject;
                mailMessage.Body = body;
                mailMessage.IsBodyHtml = isHtml;
                return SendMail(from, isAsynch, mailMessage);
            }
            catch (Exception ex)
            {
                return GetErrorMessage(ex);
            }
        }

        private static string SendMail(string from, bool isAsynch, MailMessage mailMessage)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient
                {
                    Host = MailServerHost,
                    Port = MailServerPort,
                    Credentials = new NetworkCredential(MailServerEmail, MailServerPassword),
                    EnableSsl = MailServerEnableSsl,
                    DeliveryMethod = SmtpDeliveryMethod.Network
                };
                if (isAsynch)
                {
                    Thread emailThread = new Thread(() => smtpClient.Send(mailMessage)) { IsBackground = true };
                    emailThread.Start();
                }
                else
                {
                    smtpClient.Send(mailMessage);
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                return GetErrorMessage(ex);
            }
        }

        private static void AddReceipt(ReceiptType receiptType, string receipt, MailMessage mMailMessage)
        {
            if (string.IsNullOrEmpty(receipt))
                return;
            string[] strArray = receipt.Split(new[] { ',', ';' });
            switch (receiptType)
            {
                case ReceiptType.To:
                    foreach (string address in strArray)
                        mMailMessage.To.Add(new MailAddress(address));
                    break;
                case ReceiptType.Cc:
                    foreach (string address in strArray)
                        mMailMessage.CC.Add(new MailAddress(address));
                    break;
                case ReceiptType.Bcc:
                    foreach (string address in strArray)
                        mMailMessage.Bcc.Add(new MailAddress(address));
                    break;
                case ReceiptType.Attachment:
                    foreach (string fileName in strArray)
                        mMailMessage.Attachments.Add(new Attachment(fileName));
                    break;
            }
        }

        public static string GetErrorMessage(Exception ex, bool getStactRetrace = true)
        {
            try
            {
                string str1 = string.Empty;
                if (ex == null)
                    return str1;
                string str2 = ex.Message;
                if (ex.InnerException != null)
                    str2 = str2 + Environment.NewLine + GetErrorMessage(ex.InnerException, getStactRetrace);
                if (getStactRetrace)
                    str2 = str2 + Environment.NewLine + ex.StackTrace;
                return str2.Replace("An error occurred while sending mail. See the inner exception for details.", "");
            }
            catch
            {
                return ex != null ? ex.Message : string.Empty;
            }
        }

        private enum ReceiptType
        {
            To,
            Cc,
            Bcc,
            Attachment,
        }
    }
}
