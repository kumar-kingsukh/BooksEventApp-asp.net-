using EventApplication.Business.Services;
using EventApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventApplication.Models;
using System.Web.Security;

namespace EventApplication.Controllers
{
    public class AccountController : Controller
    {

        public ActionResult Index()
        {
            return View("LoginUser");
        }

        public ActionResult CreateUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult CreateUser(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserDataModel userDataModel = new UserDataModel();
                userDataModel.Email = model.Email;
                userDataModel.FullName = model.FullName;
                userDataModel.Password = model.Password;
                userDataModel.Role= "normal";

                AccountService accountService= new AccountService();

                var result = accountService.CreateUser(userDataModel);

                if (result == null )
                {
                    ModelState.AddModelError("", "Something went wrong...");
                    return View();
                }

                return RedirectToAction("LoginUser");
            }
            ModelState.Clear();
            return View();
        }

        public ActionResult LoginUser()
        {
            return View();
        }


        [HttpPost]
        public ActionResult LoginUser(UserDataModel model)
        {
            if (ModelState.IsValid)
            {
                UserDataModel userDataModel = new UserDataModel();
                userDataModel.Email = model.Email;
                userDataModel.FullName = model.FullName;
                userDataModel.Password = model.Password;
                userDataModel.Role = "normal";

                AccountService accountService = new AccountService();

                var result = accountService.LoginUser(userDataModel);
                if (result != null)
                {
                    FormsAuthentication.SetAuthCookie(result.FullName + "|" + result.Id + "|" + result.Role, false);
                    return RedirectToAction("Index", "User");
                }
            }
            ModelState.AddModelError("", " Wrong email or password...");
            return View();

        }



        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginUser");
        }
    }
}