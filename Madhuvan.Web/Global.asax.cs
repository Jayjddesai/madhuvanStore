using Madhuvan.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Http.WebHost;
using System.Web.Http;

namespace Madhuvan.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {


            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new RazorViewEngine());

            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            ModelBinders.Binders.DefaultBinder = new TrimModelBinder();







            ////AreaRegistration.RegisterAllAreas();
            ////FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            ////RouteConfig.RegisterRoutes(RouteTable.Routes);
            ////BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
