using CRUD_WEB_API_SP_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CRUD_WEB_API_SP_MVC.Controllers
{
    public class AccountsController : Controller
    {
        cmEntities entity = new cmEntities();
        // GET: Accounts
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel credentials)
        {
            bool userExist = entity.UsersTbls.Any(x => x.Email == credentials.Email && x.Passcode == credentials.Password);
            UsersTbl u = entity.UsersTbls.FirstOrDefault(x => x.Email == credentials.Email && x.Passcode == credentials.Password);

            if (userExist)
            {
                FormsAuthentication.SetAuthCookie(u.Username, false);
                return RedirectToAction("ShowAllCustomerDetails","Customer",null);
            }
            ModelState.AddModelError("", "Username or Password is wrong");
            return View();
        }
        [HttpPost]
        public ActionResult Signup(UsersTbl userinfo)
        {
            entity.UsersTbls.Add(userinfo);
            entity.SaveChanges();
            return RedirectToAction("Login");
           
        }
        public ActionResult Signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}