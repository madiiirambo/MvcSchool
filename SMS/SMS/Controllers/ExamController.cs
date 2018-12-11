using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class ExamController : Controller
    {
        //
        // GET: /Exam/
        [HttpGet]
        public ActionResult add_exam()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
                return View();
            else
                return RedirectToAction("login", "Login");

        }

        [HttpPost]
        public ActionResult add_exam(Exam ex)
        {
            ex.add_exam();
            return View(ex);
        }
    }
}