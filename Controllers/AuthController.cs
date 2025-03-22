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
            return View();
        }

        public ActionResult ForgetPass()
        {
            return View();
        }

    }
}