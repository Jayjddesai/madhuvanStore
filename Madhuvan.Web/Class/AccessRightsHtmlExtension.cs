using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;



namespace Madhuvan.Web.Class
{
    public static class HtmlExtensions
    {
        private static int _roleID;

      //static readonly GenericRepository<AccessRights> _repositoryAccessRights = new GenericRepository<AccessRights>();

      //static readonly GenericRepository<MenuAccessRights> _repositoryMenuAccessRights = new GenericRepository<MenuAccessRights>();

      //  public static MvcHtmlString BuildAccessRightTableWithGroup(this HtmlHelper helper, int roleId, IEnumerable<Menu_SelectMenuList_Dynamic_Result> allActiveHeaderMenus)
      //  {
      //      _roleID = roleId;
      //      List<AccessRights> accessRights = _repositoryAccessRights.GetEntities().ToList();

      //     // List<AccessRights> accessRights = MenuEntity.GetAccessRights();
      //      //We have to pass role id here.

      //      List<AccessRightsForRole_Result> accessRightsForRole = GetRoleAccess.AccessRightsForRole(roleId);

      //      var sb = new StringBuilder();
      //      sb.AppendLine("<table class=grid>");
      //      sb.AppendLine(BuildMainHeader(accessRights));

      //      allActiveHeaderMenus = GetRoleAccess.GetAllActiveHeadesInMenu();

      //      foreach (Menu_SelectMenuList_Dynamic_Result headerMenu in allActiveHeaderMenus)
      //      {
      //          List<Menu> childMenus = GetRoleAccess.GetChildMenus(headerMenu.MenuId);
      //          sb.AppendLine("<tr>");
      //          if (childMenus.Count > 0)
      //          {
      //              sb.AppendLine(BuildChildMenuTable(childMenus, accessRights, accessRightsForRole, headerMenu.MenuId, headerMenu.Name));
      //          }
      //          else
      //          {
      //              sb.AppendLine("<td class='popup_grid_inner_header'  style='padding-left:17px;'>" + headerMenu.Name.Replace("<br/>", "") + "</td>");
      //              sb.AppendLine(BuildLeafRow(accessRights, accessRightsForRole, headerMenu.MenuId, headerMenu.Name, true));
      //          }
      //          sb.AppendLine("</tr>");
      //      }
      //      sb.AppendLine("</table>");
      //      return MvcHtmlString.Create(sb.ToString());
      //  }

      //  private static string BuildChildMenuTable(IEnumerable<Menu> childMenus, List<AccessRights> accessRights, List<AccessRightsForRole_Result> accessRightsForRole, int parentMenuId, string parentMenuName)
      //  {
      //      StringBuilder sb = new StringBuilder();
      //      sb.AppendLine("#BuildHeaderForInnerMenu#");

      //      sb.AppendLine("<tr id='menu" + parentMenuId + "' class = 'headerrow' style='display:none;'>");
      //      sb.AppendLine("<td colspan='" + accessRights.Count() + 1 + "' style='padding-left:20px !important;padding-top:0px !important;padding-right:0px !important;padding-bottom:0px !important'>");
      //      sb.AppendLine("<table width='100%'>");

      //      foreach (Menu childMenu in childMenus)
      //      {

      //          sb.AppendLine("<tr class='gridrow' id='" + childMenu.MenuId + "'>");
      //          sb.AppendFormat("<td>{0}</td>\n", childMenu.Name);
      //          sb.AppendLine(BuildLeafRow(accessRights, accessRightsForRole, childMenu.MenuId, parentMenuName, false));
      //          sb.AppendLine("</tr>");

      //      }

      //      sb.AppendLine("</table>");
      //      sb.AppendLine("</td>");
      //      sb.AppendLine("</tr>");
      //      string strMain = sb.ToString();
      //      strMain = strMain.Replace("#BuildHeaderForInnerMenu#", BuildHeaderForInnerMenu(parentMenuId, parentMenuName, accessRights, accessRightsForRole));
      //      return strMain;
      //  }

      //  private static string BuildHeaderForInnerMenu(int headerMenuId, string headerMenuName, IEnumerable<AccessRights> accessRights, List<AccessRightsForRole_Result> accessRightsForRole)
      //  {
      //      StringBuilder sb = new StringBuilder();

      //      sb.AppendLine("<tr class='gridrow MainParentMenu' id='" + headerMenuId + "'>");
      //      sb.AppendLine("<td class='popup_grid_inner_header'>");
      //      sb.AppendLine("<a class='k-icon k-i-expand' href='#' tabindex='-1' onclick='showhidetable(this,\"menu" + headerMenuId + "\")'></a>");
      //      sb.AppendLine(headerMenuName.Replace("<br/>", ""));
      //      sb.AppendLine("</td>");
      //      sb.AppendLine(BuildLeafRow(accessRights, accessRightsForRole, headerMenuId, headerMenuName, true));
      //      sb.AppendLine("</tr>");

      //      return sb.ToString();
      //  }

      //  private static string CreateCheckBox(string value, string className, string onClickMethod, bool isChecked, string id)
      //  {
      //      string checkBox = "";
      //      checkBox += "<input type='checkbox'";
      //      if (!string.IsNullOrEmpty(id)) checkBox += " id='" + id + "'";
      //      if (!string.IsNullOrEmpty(value)) checkBox += " value='" + value + "'";
      //      if (!string.IsNullOrEmpty(className)) checkBox += " class='" + className + "'";
      //      if (!string.IsNullOrEmpty(onClickMethod)) checkBox += " " + onClickMethod;
      //      if (isChecked && _roleID > 0) checkBox += " checked='checked' ";
      //      checkBox += " />";
      //      return checkBox;
      //  }

      //  private static string BuildMainHeader(IEnumerable<AccessRights> accessRights)
      //  {
      //      StringBuilder sb = new StringBuilder();

      //      sb.AppendLine("<tr>");
      //      sb.AppendLine("<td class='popup_grid_header'>Name");
      //      sb.AppendLine("</td>");
      //      foreach (var accessRight in accessRights)
      //      {
      //          sb.AppendLine("<td style='width: 60px' class='popup_grid_header_checkbox'>" + CommonHelper.GetNameWithspace(accessRight.AccessRightName) + "<br />");

      //          string className = "";
      //          if (accessRight.AccessRightName != "View")
      //              className = accessRight.AccessRightName;
      //          sb.AppendLine(CreateCheckBox(null, className, "onclick=\"CheckHeader(this, '" + accessRight.AccessRightName + "')\"", false, "chkHeader" + accessRight.AccessRightName));
      //          sb.AppendLine("</td>");
      //      }
      //      sb.AppendLine("</tr>");
      //      return sb.ToString();
      //  }

      //  private static string BuildLeafRow(IEnumerable<AccessRights> accessRights, List<AccessRightsForRole_Result> accessRightsForRole, int menuID, string menuName, bool withStyle)
      //  {
      //      StringBuilder sb = new StringBuilder();
      //     //List<int> accessRightsIDs = MenuEntity.GetMenuAccessRights(menuID).Select(item => item.AccessRightID).ToList();

      //      List<int> accessRightsIDs = _repositoryMenuAccessRights.GetEntities().Where(r => r.MenuID == menuID).Select(item => item.AccessRightID).ToList();

      //      foreach (var accessRight in accessRights)
      //      {
      //          if (accessRightsIDs.Contains(accessRight.AccessRightID))
      //          {
      //              AccessRightsForRole_Result accessRightApplicable = accessRightsForRole.FirstOrDefault(role => role.MenuId == menuID && role.AccessRight == accessRight.AccessRightName);
      //              if (accessRightApplicable != null)
      //              {
      //                  sb.AppendLine(withStyle
      //                                    ? "<td style='width: 60px' class='popup_grid_inner_header_checkbox'>"
      //                                    : "<td style='width: 60px; text-align: center'>");

      //                  bool isChecked = (accessRightApplicable.RoleMenuAccessRightId != null && accessRightApplicable.RoleId != null);
      //                  sb.AppendLine(
      //                                  CreateCheckBox(
      //                                      accessRightApplicable.MenuAccessRightId.ToString(),
      //                                      (accessRightApplicable.AccessRight + "_" + RemoveWhitespace(menuName)),
      //                                      "onclick=\"Check(this, $('#chkHeader" + accessRightApplicable.AccessRight + "'))\"",
      //                                      isChecked, null)
      //                                      );


      //                  sb.AppendLine("</td>\n");
      //              }
      //          }
      //          else
      //          {
      //              if (withStyle)
      //                  sb.AppendFormat("<td style='width: 60px' class='popup_grid_inner_header_checkbox' id='" + accessRight.Description + "'></td>\n");
      //              else
      //                  sb.AppendFormat("<td style='width: 60px; text-align: center' id='" + accessRight.Description + "'></td>\n");
      //          }

      //      }
      //      return sb.ToString();

      //  }

      //  private static string RemoveWhitespace(this string input)
      //  {
      //      return new string(input.ToCharArray().Where(c => !Char.IsWhiteSpace(c)).ToArray());
      //  }
    }
}