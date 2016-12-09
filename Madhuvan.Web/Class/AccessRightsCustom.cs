using System.Linq;
using Madhuvan.Businesslayer;


namespace Madhuvan.Web.Class
{
    public class AccessRightsCustom
    {

        //public static bool IsAccessRightExists(string controllerName, AccessRightss accessRightName)
        //{
        //    bool isAcees = SessionHelper.UserAccessPermissionsDynamic.Any(item => item.Controller != null && (item.AccessRight.ToLower() == accessRightName.ToString().ToLower()
        //                                                                        && item.Controller.ToLower() == controllerName.ToLower()));
        //    return isAcees;
        //}


        //public static bool IsAccessRightExistsForSetting(string controllerName, AccessRightss accessRightName, int parentMenuId)
        //{
        //    bool isAcees = SessionHelper.UserAccessPermissionsDynamic.Any(item => item.Controller != null && (item.AccessRight.ToLower() == accessRightName.ToString().ToLower()
        //                                                                        && item.Controller.ToLower() == controllerName.ToLower() && item.ParentMenuId == parentMenuId));
        //    return isAcees;
        //}

        //public static bool IsEditDeleteRightsExist(string controllerName)
        //{
        //    bool isAcees = SessionHelper.UserAccessPermissionsDynamic.Any(item => item.Controller != null && (item.AccessRight.ToLower() == AccessRightss.Edit.ToString().ToLower() || item.AccessRight.ToLower() == AccessRightss.Delete.ToString().ToLower()) && item.Controller.ToLower() == controllerName.ToLower());
        //    return isAcees;
        //}


        //public static bool IsEditAddRightsExist(string controllerName)
        //{
        //    bool isAcees = SessionHelper.UserAccessPermissionsDynamic.Any(item => item.Controller != null &&(item.AccessRight.ToLower() == AccessRightss.Edit.ToString().ToLower() || item.AccessRight.ToLower() == AccessRightss.Add.ToString().ToLower()) && item.Controller.ToLower() == controllerName.ToLower());
        //    return isAcees;
        //}


    }
}
