using System.Linq;

using System.Web.Mvc;


namespace Madhuvan.Businesslayer
{
    public class AuthorizationHelper
    {
        /// <summary>
        /// Function to authorize controller action
        /// </summary>
        /// <param name="filterContext">action context</param>
        /// <returns>Return true if authorized</returns>
        public static bool IsAuthorized(ActionExecutingContext filterContext)
        {
            if (
                //SessionHelper.IsSuperAdmin ||
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName == "Error" ||
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "home" ||
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "login" ||
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "general" ||
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "PaymentAfterIntimation" ||
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "binddropdown") return true;

            if (
                filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower() == "User" &&
                filterContext.ActionDescriptor.ActionName.ToLower() == "vflread"
               ) return true;

            //var userAccessPermissions = SessionHelper.UserAccessPermissionsDynamic.Where(perm => perm.Controller != null
            //    && (perm.Controller.ToLower() == filterContext.ActionDescriptor.ControllerDescriptor.ControllerName.ToLower())).ToList();


            //return userAccessPermissions.Count > 0;
            return true;
        }
    }
}