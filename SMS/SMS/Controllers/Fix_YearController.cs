using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class Fix_YearController : Controller
    {
        //
        // GET: /Fix_Year/
        [HttpGet]
        public ActionResult fix_year()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
                return View();
            else
                return RedirectToAction("login", "Login");

        }

        [HttpPost]
        public ActionResult fix_year(Fix_Year fy)
        {
            fy.add_fix_year();
            return View(fy);
        }
        
	}
}