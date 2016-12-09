using System.Web.Mvc;
using Madhuvan.Resourcelayer;

namespace Madhuvan.Web
{
    public static class HtmlExtension
    {
        //private static MvcHtmlString CreateAddLink(HtmlHelper htmlHelper, string actionName, string controllerName)
        //{
        //    return htmlHelper.SecureActionLink(Label.Create, actionName, controllerName);
        //}

        //private static MvcHtmlString CreateAddLink(HtmlHelper htmlHelper, string actionName, string controllerName, int menuId)
        //{
        //    return htmlHelper.SecureActionLink(Label.Create, actionName, controllerName, menuId);
        //}

        //private static MvcHtmlString GenerateMvcHtmlString(this HtmlHelper htmlHelper, string normalString)
        //{
        //    return MvcHtmlString.Create(normalString);
        //}

        //public static MvcHtmlString LabelWithColon(this HtmlHelper html, string expression)
        //{
        //    string strTemp = "<label for=\"" + expression.Replace(" ", "_") + "\" style=\"display:inline !important\">" + expression + "</label> : ";
        //    return GenerateMvcHtmlString(html, strTemp);
        //}

        //public static string SetStatusClientTemplate(this HtmlHelper helper, string isActive, string controllerName, string action, string parameter, string id, string gridId, string entityName)
        //{

        //    string deactivteMessage = Messages.Deactivate + " " + entityName;


        //    string activteMessage = Messages.Activate + " " + entityName;

        //    var deactiveAttributes = " onclick='changeStatus(" + @"""" + controllerName + @"""" + ", " + @"""" +
        //                            action + @"""" + ", " + @"""""" + ", "
        //                            + @"""" + parameter + @"""" + ", " + @"""" + deactivteMessage + @"""" + ", " + id
        //                            + ", " + @"""" + gridId + @"""" + @")'";

        //    var activeAttributes = " onclick='changeStatus(" + @"""" + controllerName + @"""" + ", " + @"""" +
        //                           action + @"""" + ", " + @"""""" + ", "
        //                           + @"""" + parameter + @"""" + ", " + @"""" + activteMessage + @"""" + ", " + id
        //                           + ", " + @"""" + gridId + @"""" + @")'";


        //    return "# if (" + isActive + ")    {#" +
        //           @"<a class='k-button' " + deactiveAttributes + @"><span class='k-icon k-i-tick'></span></a>" +
        //           "#}else { #" +
        //           @"<a class='k-button' " + activeAttributes + @"><span class='k-icon k-i-close'></span></a>"
        //           + "#}#";
        //}
        //public static string SetStatusClientTemplateReturn(this HtmlHelper helper, string isActive, string controllerName, string action, string parameter, string id, string gridId, string entityName)
        //{

        //    string deactivteMessage = Messages.Deactivate + " " + entityName;


        //    string activteMessage = Messages.Activate + " " + entityName;

        //    var deactiveAttributes = " onclick='ReturnItems(" + @"""" + controllerName + @"""" + ", " + @"""" +
        //                            action + @"""" + ", " + @"""""" + ", "
        //                            + @"""" + parameter + @"""" + ", " + @"""" + deactivteMessage + @"""" + ", " + id
        //                            + ", " + @"""" + gridId + @"""" + @")'";

        //    var activeAttributes = " onclick='ReturnItems(" + @"""" + controllerName + @"""" + ", " + @"""" +
        //                           action + @"""" + ", " + @"""""" + ", "
        //                           + @"""" + parameter + @"""" + ", " + @"""" + activteMessage + @"""" + ", " + id
        //                           + ", " + @"""" + gridId + @"""" + @")'";


        //    return "# if (" + isActive + ")    {#" +
        //           @"<a class='k-button' " + deactiveAttributes + @"><span class='k-icon k-i-tick'></span></a>" +
        //           "#}else { #" +
        //           @"<a class='k-button' " + activeAttributes + @"><span class='k-icon k-i-close'></span></a>"
        //           + "#}#";
        //}

        //public static string SetStatusClientTemplateIcon(this HtmlHelper helper, string isActive, string controllerName, string action, string parameter, string id, string gridId, string entityName)
        //{

        //    string deactivteMessage = Messages.Deactivate + " " + entityName;


        //    string activteMessage = Messages.Activate + " " + entityName;

        //    var deactiveAttributes = " onclick='changeStatus(" + @"""" + controllerName + @"""" + ", " + @"""" +
        //                            action + @"""" + ", " + @"""""" + ", "
        //                            + @"""" + parameter + @"""" + ", " + @"""" + deactivteMessage + @"""" + ", " + id
        //                            + ", " + @"""" + gridId + @"""" + @")'";

        //    var activeAttributes = " onclick='changeStatus(" + @"""" + controllerName + @"""" + ", " + @"""" +
        //                           action + @"""" + ", " + @"""""" + ", "
        //                           + @"""" + parameter + @"""" + ", " + @"""" + activteMessage + @"""" + ", " + id
        //                           + ", " + @"""" + gridId + @"""" + @")'";


        //    return "# if (" + isActive + ")    {#" +
        //           @"<a class='k-button' " + deactiveAttributes + @"><span class='fa fa-thumbs-up'></span></a>" +
        //           "#}else { #" +
        //           @"<a class='k-button' " + activeAttributes + @"><span class='fa fa-thumbs-down'></span></a>"
        //           + "#}#";
        //}
    }
}