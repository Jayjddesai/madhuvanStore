using System;
using System.Collections.Generic;
using System.Linq;


namespace Madhuvan.Businesslayer
{
    public class SettingConfig
    {
        /// <summary>
        /// Mail Server Host
        /// </summary>
        public static string MailServerHost;

        /// <summary>
        /// mail server password.
        /// </summary>
        public static string MailServerPassword;

        /// <summary>
        /// mail server from mail.
        /// </summary>
        public static string MailServerFromMail;

        /// <summary>
        /// mail server from mail.
        /// </summary>
        public static int Port;

        /// <summary>
        /// mail server from mail.
        /// </summary>
        public static bool EnableSSL;

        /// <summary>
        /// mail server from mail.
        /// </summary>
        public static string MailCCAddress;

        public static bool IsErrorMail;

        /// <summary>
        /// Register Settings value from setting table
        /// </summary>

        public static void InitilizeSettings()
        {
            //GenericRepository<Settings> _repository = new GenericRepository<Settings>();
            //List<Settings> settings = new List<Settings>();

            //settings = SessionHelper.BranchId !=null ? _repository.GetEntities().Where(x=>x.BranchId== SessionHelper.BranchId).ToList() : _repository.GetEntities().ToList();

            //foreach (var setting in settings)
            //{
            //    switch (setting.SettingKey)
            //    {
            //        case Settings.MailServerHost:
            //            MailServerHost = setting.SettingValue;
            //            break;
            //        case Settings.MailServerPassword:
            //            MailServerPassword = setting.SettingValue;
            //            break;
            //        case Settings.MailServerFromMail:
            //            MailServerFromMail = setting.SettingValue;
            //            break;
            //        case Settings.Port:
            //            Port = Convert.ToInt32(setting.SettingValue);
            //            break;
            //        case Settings.EnableSSL:
            //            EnableSSL = Convert.ToBoolean(setting.SettingValue);
            //            break;
            //        case Settings.MailCCAddress:
            //            MailCCAddress = setting.SettingValue;
            //            break;

            //        case Settings.IsErrorMail:
            //            IsErrorMail =Convert.ToBoolean(setting.SettingValue);
            //            break;
            //    }
        }

    }

}
