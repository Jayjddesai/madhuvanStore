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


    }
}
