using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;


namespace Madhuvan.Businesslayer
{
    public class BaseController : Controller
    {
        #region Overridden Methods
        /// <summary>
        /// On Result Executing
        /// </summary>
        /// <param name="filterContext">ResultExecutingContext</param>
        protected override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
            filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
            filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            filterContext.HttpContext.Response.Cache.SetNoStore();
            base.OnResultExecuting(filterContext);
        }

        /// <summary>
        /// On Action Executing
        /// </summary>
        /// <param name="filterContext">ActionExecutingContext</param>
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            if (Request.IsAuthenticated)
            {

                
                string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower();
                if (!controllerName.Contains("error") && !controllerName.Contains("nopagefound"))
                {
                    #region Handle Session Time Out
                    if (SessionHelper.UserId == 0)
                    {
                        //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Error" }, { "Action", "AccessDenied" }, { "message", MessageHelper.NoAccess } });
                        SetSessionValues(filterContext);
                        if (!AuthorizationHelper.IsAuthorized(filterContext))
                        {
                            filterContext.RouteData.Values["message"] = "No Role.";
                            filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Error" }, { "Action", "Index" }, { "message", "Sorry, You Have Not rights to Access This page." } });
                        }

                    }
                    #endregion
                }
                else
                {
                    if (!AuthorizationHelper.IsAuthorized(filterContext))
                    {
                        filterContext.RouteData.Values["message"] = "No Role.";
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Error" }, { "Action", "Index" }, { "message", "Sorry, You Have Not rights to Access This page." } });
                    }
                   // RedirectToLoginPage(filterContext);
                    //filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Error" }, { "Action", "Index" }, { "message", "Sorry, You Have Not rights to Access This page." } });
                }

                
            }
            else
            {
               // filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Error" }, { "Action", "Index" }, { "message", "Sorry, You Have Not rights to Access This page." } });
                //if (!AuthorizationHelper.IsAuthorized(filterContext))
                //{
                //    filterContext.RouteData.Values["message"] = "No Role.";
                //    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Error" }, { "Action", "Index" }, { "message", "Sorry, You Have Not rights to Access This page." } });
                //}
                RedirectToLoginPage(filterContext);
            }

            if (!AuthorizationHelper.IsAuthorized(filterContext))
            {
                filterContext.RouteData.Values["message"] = "Sorry, You Have Not rights to Access This page.";
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "Controller", "Error" }, { "Action", "Index" }, { "message", "Sorry, You Have Not rights to Access This page." } });
            }

           
        }

        /// <summary>
        /// On Authorization
        /// </summary>
        /// <param name="filterContext">AuthorizationContext</param>
        protected override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);
            var cookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie != null)
            {
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value);
                FormsAuthenticationTicket newTicket = FormsAuthentication.RenewTicketIfOld(ticket);
                if (newTicket != null && newTicket.Expiration != ticket.Expiration)
                {
                    string encryptedTicket = FormsAuthentication.Encrypt(newTicket);

                    cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket)
                    {
                        Path = FormsAuthentication.FormsCookiePath
                    };
                    Response.Cookies.Add(cookie);
                }
            }
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Redirect To Login Page
        /// </summary>
        /// <param name="filterContext">ActionExecutingContext</param>
        private void RedirectToLoginPage(ActionExecutingContext filterContext)
        {
            var url = new UrlHelper(filterContext.RequestContext);
            var loginUrl = url.Action("Index", "Login");
            if (loginUrl != null) filterContext.HttpContext.Response.Redirect(loginUrl, true);
        }


        /// <summary>
        /// Set Session Values
        /// </summary>
        /// <param name="filterContext"></param>
        private void SetSessionValues(ActionExecutingContext filterContext)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie == null)
            {
                RedirectToLoginPage(filterContext);
            }
            else
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket == null || authTicket.Expired)
                {
                    RedirectToLoginPage(filterContext);
                }
                else
                {

                    string userName = authTicket.Name;
                    
                   
                }
            }
        }

        #endregion
    }
}
