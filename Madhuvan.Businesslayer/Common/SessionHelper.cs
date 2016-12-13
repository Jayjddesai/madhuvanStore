using System.Collections.Generic;
using System.Web;


namespace Madhuvan.Businesslayer
{
    public class SessionHelper
    {
        //public static SessionHelper Current
        //{
        //    get
        //    {
        //        return (SessionHelper)HttpContext.Current.Session["SessionHelper"];
        //    }
        //    set
        //    {
        //        HttpContext.Current.Session["SessionHelper"] = value;
        //    }
        //}

        public static int UserId
        {
            get
            {
                return HttpContext.Current.Session["UserId"] == null ? 0 : (int)HttpContext.Current.Session["UserId"];
            }
            set
            {
                HttpContext.Current.Session["UserId"] = value;
            }
        }

        public static bool IsSuperAdmin
        {
            get
            {
                return HttpContext.Current.Session["IsSuperAdmin"] != null && (bool)HttpContext.Current.Session["IsSuperAdmin"];
            }
            set
            {
                HttpContext.Current.Session["IsSuperAdmin"] = value;
            }
        }



        public static string LoginEmail
        {
            get
            {
                return (string)HttpContext.Current.Session["LoginEmail"];
            }
            set
            {
                HttpContext.Current.Session["LoginEmail"] = value;
            }
        }

        public static string WelcomeUser
        {
            get
            {
                return HttpContext.Current.Session["WelcomeUser"] == null
                           ? "Guest"
                           : (string)HttpContext.Current.Session["WelcomeUser"];
            }
            set
            {
                HttpContext.Current.Session["WelcomeUser"] = value;
            }
        }

    }
}
