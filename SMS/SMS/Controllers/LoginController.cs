using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public ActionResult login()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                return RedirectToAction("login", "Login");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]

        public ActionResult login(LoginModel lm, string userType)
        {
            userType = "admin";
            int a = lm.AdminLogin();
            if (userType == "admin" && a > 0)
            {
                Session["login_session"] = "ok";
                return RedirectToAction("admin_panel","Admin_Panel");
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }
        [HttpGet]
        public ActionResult logout()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                return RedirectToAction("login", "Login");
            }
            else
            {
                return RedirectToAction("admin_panel", "Admin_Panel");
            }
        }
	}
}