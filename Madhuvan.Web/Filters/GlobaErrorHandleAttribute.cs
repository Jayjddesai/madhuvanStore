using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;

using System;


namespace Madhuvan.Web
{
    public class GlobaErrorHandleAttribute : HandleErrorAttribute
    {
        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || !filterContext.HttpContext.IsCustomErrorEnabled)
                return;

            var controllerName = (string)filterContext.RouteData.Values["controller"];
            var actionName = (string)filterContext.RouteData.Values["action"];

            string errorMessege = "error";

            #region Log Exception
            //Log Exception
            string logDirectory = HttpContext.Current.Server.MapPath("~");
            logDirectory = Path.Combine(logDirectory, "Log");
           // CommonHelper.WriteToLogText(errorMessege, "Madhuvan", logDirectory);
            #endregion

            

            #region Handle Error
            // if the request is AJAX return JSON else view.,
            if (IsAjax(filterContext))
            {
                /*
                 * IF any error occured in kendo create/update/delete then we do not to handle it with below code
                 * By default kenod ajax call post the form so we have checked RequestType != "POST"
                 */
                if (filterContext.HttpContext.Request.RequestType != "POST")
                {
                    filterContext.Result = new JsonResult
                    {
                        Data = filterContext.Exception.Message,
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };

                    filterContext.ExceptionHandled = true;
                    filterContext.HttpContext.Response.Clear();
                }
            }
            else
            {
                Exception ex = filterContext.Exception;
                filterContext.ExceptionHandled = true;


                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Shared/Error.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                };
            }
            #endregion
        }
    }
}