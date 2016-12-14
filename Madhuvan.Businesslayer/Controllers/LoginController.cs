using Madhuvan.Businesslayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Madhuvan.Datalayer;
using Madhuvan.Commonlayer;

namespace Madhuvan.Businesslayer
{
    public class LoginController : Controller
    {
       
        readonly GenericRepository<AdminUserMaster> _repository = new GenericRepository<AdminUserMaster>();

        public ActionResult Index()
        {
            return View(new AdminUserMaster());
        }

        [HttpPost]
        public ActionResult ValidateUser(AdminUserMaster model)
        {

            AdminUserMaster logedInUser = _repository.GetEntities().SingleOrDefault(u => u.Email == model.Email && u.Password == model.Password);
            
            if (logedInUser == null)
            {
                ModelState.AddModelError("UserName", "Username/Password is not valid");
                return View("Login", model);
            }
            
            if (logedInUser.UserTypeId == (byte)UserTypes.SuperAdmin)
            {
                SessionHelper.IsSuperAdmin = true;
            }
            else
            {
                SessionHelper.IsSuperAdmin = false;
            }

            string LoginEmail = logedInUser.Email;
            string branchName = string.Empty;
            string stationName = string.Empty;

            SessionHelper.UserId = logedInUser.AdminUserId;
            SessionHelper.LoginEmail = LoginEmail;
            SessionHelper.WelcomeUser = logedInUser.FirstName + " " + logedInUser.LastName;

            SettingConfig.InitilizeSettings();
            return RedirectToAction("Index", "Home");

        }
    }
}
