using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;




namespace Madhuvan.Businesslayer
{
    public class GeneralController : BaseController
    {
        //public JsonResult BindMenu()
        //{
        //    try
        //    {
        //        // List<UserAccessPermissions_Result> menuList = SessionHelper.MenuList.OrderBy(item => item.DispalyOrder).ToList();

        //        List<UserAccessPermissionsDynamic_Result> menuList =
        //            CustomRepository.UserAccessPermissionsDynamic(SessionHelper.UserId);


        //        menuList = menuList.Where(item => item.AccessRight == AccessRightss.View.ToString()
        //                                          ).ToList();


        //        var result = menuList.Aggregate(
        //            new StringBuilder(),
        //            (aggregate, item) => aggregate.Append(
        //                "['" + item.Action + "','" +
        //                item.Controller + "','" +
        //                item.ImagePath + "','" +
        //                item.Name + "','" +
        //                Convert.ToString(item.MenuId) + "','" +
        //                CommonHelper.SiteRootPathUrl + "','" +
        //                item.MenuId + "','" +
        //                item.ParentMenuId + "'],"),
        //            sb => sb.ToString());

        //        if (result.Length > 1)
        //        {
        //            result = "[" + result.Remove(result.Length - 1) + "]";
        //        }

        //        return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = result };
        //    }
        //    catch (Exception)
        //    {
        //        return new JsonResult { JsonRequestBehavior = JsonRequestBehavior.AllowGet, Data = "" };
        //    }
        //}
    }
}
