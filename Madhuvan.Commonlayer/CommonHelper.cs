using Madhuvan.Resourcelayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;



namespace Madhuvan.Commonlayer
{
    public static class CommonHelper
    {
        public const string DateFormatForLR = "dd-MM-yyyy";
        public const string DateFormat = "dd/MM/yyyy";

        public const string MonthFormat = "MMM yyyy";

        public const string DateTimeFormat = "dd/MM/yyyy HH:mm";

        public const int PageSize = 10;

        public static IEnumerable<int> PageSizes = new[] { 10, 20, 30 };

        public const string PleaseSelect = "---Select---";


     

        public static void ClearDirectory(string strDirPath)
        {
            CreateDirectory(strDirPath);
            foreach (string strFileName in Directory.GetFiles(strDirPath))
            {
                File.Delete(strFileName);
            }
        }

        public static void CreateDirectory(string strPath)
        {
            if (!Directory.Exists(strPath))
            {
                Directory.CreateDirectory(strPath);
            }
        }

        public static string GetErrorMessage(Exception ex, bool getStactRetrace = true)
        {
            try
            {
                var errorMessage = String.Empty;
                if (ex == null) return errorMessage;
                errorMessage = ex.Message;
                if (ex.InnerException != null)
                    errorMessage += Environment.NewLine + GetErrorMessage(ex.InnerException, getStactRetrace);
                if (getStactRetrace)
                    errorMessage += Environment.NewLine + ex.StackTrace;

                errorMessage = errorMessage.Replace("An error occurred while updating the entries. See the inner exception for details.", "");
                return errorMessage;
            }
            catch
            {
                return ex != null ? ex.Message : String.Empty;
            }
        }

        public static void WriteToLogText(string message, string logSource, string directory)
        {
            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            string filePath = Path.Combine(directory, logSource + " " + DateTime.Now.ToString("dd MMM yyyy") + ".txt");
            using (StreamWriter outfile = new StreamWriter(filePath, true))
                outfile.WriteLine(message);
        }

        public static string GetDeleteErrorMessage(Exception ex, bool getStactRetrace = true)
        {
            try
            {
                var errorMessage = String.Empty;
                if (ex == null) return errorMessage;
                errorMessage = ex.Message;
                if (ex.InnerException != null)
                    errorMessage += Environment.NewLine + GetDeleteErrorMessage(ex.InnerException, getStactRetrace);
                if (getStactRetrace)
                    errorMessage += Environment.NewLine + ex.StackTrace;

                errorMessage = errorMessage.Replace("\"", " ");
                errorMessage = errorMessage.Replace("'", " ");
                return errorMessage;
            }
            catch
            {
                return ex != null ? ex.Message : String.Empty;
            }
        }

        public static string GetDeleteException(Exception exception)
        {
            string errorMessage = GetDeleteErrorMessage(exception, false);
            return errorMessage.Contains(Messages.DeleteStatementConflict) ? ParseDeleteMessage(errorMessage) : errorMessage;
        }

        private static string ParseDeleteMessage(string message)
        {
            try
            {
                return Messages.RecordCannotBeDeleted;
            }
            catch
            {
                return message;
            }
        }

        public static string GetNameWithspace(string name)
        {
            try
            {
                string name2 = "";
                int nameCount = name.Length;
                for (int i = 0; i < nameCount; i++)
                {
                    char car = name[i];
                    if (Char.IsUpper(car))
                    {
                        if (i + 1 == nameCount)
                        {
                            if (!Char.IsUpper(name[i - 1]))
                                name2 = name2 + " " + car;
                            else
                                name2 = name2 + car;
                        }
                        else if (i + 1 < nameCount && Char.IsUpper(name[i + 1]) && i - 1 >= 0 && !Char.IsUpper(name[i - 1]))
                        {
                            name2 = name2 + " " + car;
                        }
                        else if (i + 1 < nameCount && Char.IsUpper(name[i + 1]) && i - 1 >= 0 && Char.IsUpper(name[i - 1]))
                        {
                            name2 = name2 + car;
                        }
                        else if (i + 1 < nameCount && !Char.IsUpper(name[i + 1]) && i - 1 >= 0 && Char.IsUpper(name[i - 1]))
                        {
                            name2 = name2 + car;
                        }
                        else
                        {
                            name2 = name2 + " " + car;
                        }
                    }
                    else
                        name2 = name2 + car;
                }

                name2 = name2.Replace("_", " ");

                if (name == "RECOOrders") name = "RECO Orders";
                return name2.Trim();
            }
            catch (Exception)
            {
                return name;
            }

        }

        public static string SendErrorMail(string errorMessege, string to, string cc, string bcc)
        {
            try
            {
                Email.MailServerEnableSsl = false;
                Email.MailServerHost = "smtp@gmail.com";
                Email.MailServerPort = 587;
                Email.MailServerEmail = "vinodpandya73@gmail.com";
                Email.MailServerPassword = "vinodpandya@@4444";

                string returnMessage = Email.SendMail("", to, "SMS | " + Messages.ErrorOccurred, errorMessege, true, bcc, cc);
                return returnMessage;
            }
            catch (Exception exception)
            {
                return GetErrorMessage(exception, false);
            }
        }

        public static string SendMail(string mailTo, string subject, string content, string mailFrom = "",
          bool ishtml = true, string bcc = "", string cc = "", string attachmentFileName = "")
        {
            try
            {
                Email.MailServerEnableSsl = false;
                Email.MailServerHost = "mail.sgit.in";
                Email.MailServerPort = 25;
                Email.MailServerEmail = "viram.k@sgit.in";
                Email.MailServerPassword = "sit@123";
                

                string returnMessage = Email.SendMail(
                        "viram.k@sgit.in",
                        mailTo,
                        "SMS | " + subject,
                        content,
                        ishtml,
                        bcc,
                        cc,
                        attachmentFileName);


                return returnMessage;
            }
            catch (Exception exception)
            {
                return GetErrorMessage(exception, false);
            }
        }

       

       
        public static List<MonthClass> GetMonth(bool setDefaultMonth = false)
        {
            var lstMonthName = Enumerable.Range(1, 12).Select(x => DateTimeFormatInfo.CurrentInfo != null ?
                new MonthClass { MonthaName = DateTimeFormatInfo.CurrentInfo.GetMonthName(x), MonthaValue = x } : null).ToList();
            return lstMonthName;
        }

        public static int WeekOfYear(DateTime date)
        {
            return CultureInfo.CurrentCulture.Calendar.GetWeekOfYear(date, CultureInfo.CurrentCulture.DateTimeFormat.CalendarWeekRule, DayOfWeek.Monday);

        }

        public static DateTime GetFirstDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            var firstDayInWeek = dayInWeek.Date;
            while (firstDayInWeek.DayOfWeek != firstDay)
                firstDayInWeek = firstDayInWeek.AddDays(-1);

            return firstDayInWeek;
        }

        public static DateTime GetLastDateOfWeek(DateTime dayInWeek, DayOfWeek firstDay)
        {
            var lastDayInWeek = dayInWeek.Date;
            while (lastDayInWeek.DayOfWeek != firstDay)
                lastDayInWeek = lastDayInWeek.AddDays(1);

            return lastDayInWeek;
        }

        public static DateTime GetFirstDateOfCurrentMonth()
        {
            DateTime now = DateTime.Now;
            return new DateTime(now.Year, now.Month, 1);
        }

        public static DateTime GetLastDateOfCurrentMonth()
        {
            DateTime now = DateTime.Now;
            var startDate = new DateTime(now.Year, now.Month, 1);
            return startDate.AddMonths(1).AddDays(-1);
        }

        public static SelectList MonthSelectList(int? monthId)
        {
            return monthId != null ? new SelectList(GetMonth(), "MonthaValue", "MonthaName", monthId)
                : new SelectList(GetMonth(), "MonthaValue", "MonthaName");
        }

        public static SelectList ToSelectListWithString(Enum enumeration, string selectedvalue = null)
        {
            var list = Enum.GetValues(enumeration.GetType()).Cast<Enum>().Select(
                d =>
                    new
                    {
                        ID = d.GetDescription(),
                        Name = d.GetDescription()
                    }).ToList().OrderBy(d => d.Name);
            return new SelectList(list, "ID", "Name", selectedvalue);
        }

        public static bool CheckFileExtension(string fileName)
        {
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension.ToLower();
            return extn == ".xls" || extn == ".xlsx";
        }

      

       
        public static string AddSpacesBeforeCapitalLatter(string text)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(text))
                    return "";
                StringBuilder newText = new StringBuilder(text.Length * 2);
                newText.Append(text[0]);
                for (int i = 1; i < text.Length; i++)
                {
                    if (Char.IsUpper(text[i]) && text[i - 1] != ' ')
                        newText.Append(' ');
                    newText.Append(text[i]);
                }
                return newText.ToString();
            }
            catch
            {
                return text;
            }
        }

        public static bool IsUpper(this string value)
        {
            // Consider string to be uppercase if it has no lowercase letters.
            return value.All(t => !Char.IsLower(t));
        }

        public static string ConvertToCamelCase(string text)
        {
            try
            {
                if (text.Length == 1) return text;
                TextInfo myTi = new CultureInfo("en-US", false).TextInfo;
                //text = text.ToLower();

                string[] stringArray = text.Split(' ');
                string foramttedText = "";
                foreach (string s in stringArray)
                {
                    if (IsUpper(s))
                        foramttedText += s + " ";
                    else if (s.Length > 2)
                        foramttedText += myTi.ToTitleCase(s) + " ";
                    else if (s.Length == 1)
                        foramttedText += myTi.ToTitleCase(s) + " ";
                    else
                        foramttedText += s + " ";
                }

                return String.IsNullOrWhiteSpace(text) ? text : foramttedText.Trim();
            }
            catch
            {
                return text;
            }
        }

        public static string ShowAlertMessage(string url, string message, string messageType)
        {
            message = message.Replace("'", " ");
            return @"<script type='text/javascript' language='javascript'>$(function() { showMessage('" + url + "',' " + message + "',' " + messageType + "') ; })</script>";
        }

        public static string ShowAlertMessage(string message)
        {
            message = message.Replace("'", " ");
            var strString = @"<script type='text/javascript' language='javascript'>$(function() { showMessageOnly(' " + message + "') ; })</script>";
            return strString;
        }

        public static string ShowNotification(string message, string title)
        {
            message = message.Replace("'", " ");
            var strString = @"<script type='text/javascript' language='javascript'>$(function() { showNotification(' " + message + "',' " + title + "') ; })</script>";
            return strString;
        }

        public static string DetermineCompName(string ip)
        {
            var myIp = IPAddress.Parse(ip);
            var getIpHost = Dns.GetHostEntry(myIp);
            var compName = getIpHost.HostName.Split('.').ToList();
            return compName.First();
        }

        public static string BeautifyHTML(string strHTML)
        {
            return Regex.Replace(strHTML, "(style=\")(.*?;).*\"", m => m.Groups[1].Value + m.Groups[2].Value + @"""");
        }
    }


}
