using OstadAssignment2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OstadAssignment2.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string txtUserNm, string txtPassword)
        {
            LoginUser user = new LoginUser();
            if (user.ValidateUser(txtUserNm, txtPassword))
            {
                Session["UserName"] = user.UserName;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Invalid User Name or Password";
                return View();
            }
        }

        public ActionResult ForgetPass()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgetPass(string txtUserName, string txtNewPassword, string txtConfirmPassword)
        {
            LoginUser login = new LoginUser();
            if (!login.ValidateUserExist(txtUserName))
            {
                ViewBag.Message = "User name doesn't exist!";
                return View();
            }
            else if (txtNewPassword != txtConfirmPassword)
            {
                ViewBag.Message = "Confirm Password did'nt match";
                return View();
            }
            else
            {
                login.UpdatePassword(txtUserName, txtNewPassword);
                ViewBag.Message = "Password Updated";
                return RedirectToAction("Login");
            }

        }

    }
}