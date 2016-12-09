using System;
using System.Web.Optimization;

namespace Madhuvan.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.IgnoreList.Clear();

            #region CSS
            bundles.Add(new StyleBundle("~/css/ui").Include(
                "~/Content/bootbox.css",
                        "~/assets/bootstrap/css/bootstrap.min.css",
                        "~/css/flaty.css",
                        "~/css/flaty-responsive.css").Include("~/assets/font-awesome/css/font-awesome.min.css"));



            bundles.Add(new StyleBundle("~/Content/kendo/kendoCss").Include(
                        "~/Content/kendo/kendo.blueopal.min.css",
                        "~/Content/kendo/kendo.common.min.css",
                        "~/Content/kendo/kendoCustom.css"));
            #endregion

            #region js
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-2.1.4.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                         "~/Scripts/jquery.validate.min.js",
                         "~/Scripts/jquery.unobtrusive-ajax.min.js",
                         "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/KendoJQuery").Include(
                      "~/Scripts/kendo/kendo.all.min.js",
                      "~/Scripts/kendo/kendo.aspnetmvc.min.js",
                      "~/Scripts/kendo/kendo.culture.en-IN.min.js",
                      "~/Scripts/kendo/kendo.messages.en-US.min.js",
                       "~/Scripts/kendo/KendoCustom.js",
                        "~/Scripts/kendo/jszip.min.js"
                      ));


            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/Scripts/bootstrap.min.js",
                    "~/Scripts/bootbox.js"));


            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include("~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/UIScripts").Include(
                        "~/Scripts/Custom/Common.js",
                        "~/Scripts/Custom/ajaxCall.js",
                        "~/Scripts/Custom/Menu.js",
                        "~/assets/jquery-slimscroll/jquery.slimscroll.min.js",
                        "~/assets/jquery-cookie/jquery.cookie.js",
                        "~/js/flaty.js",
                        "~/js/flaty-demo-codes.js"));

            #endregion


            BundleTable.EnableOptimizations = true;
        }
    }


}