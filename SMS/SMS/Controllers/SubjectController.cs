using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class SubjectController : Controller
    {
        [HttpGet]
        public ActionResult add_sub()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
                return View();
            else
                return RedirectToAction("login", "Login");

        }

        [HttpPost]
        public ActionResult add_sub(Subject sub)
        {
            sub.add_sub();
            return View(sub);
        }

       
	}
}