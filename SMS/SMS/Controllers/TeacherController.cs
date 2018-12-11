using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class TeacherController : Controller
    {
        Teacher tm = new Teacher();
        [HttpGet]
        public ActionResult add_teacher()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
                return View();
            else
                return RedirectToAction("login", "Login");
        }
        [HttpPost]
        public ActionResult add_teacher(Teacher tm)
        {
            tm.add_teacher();
            return View(tm);
        }
        [HttpGet]
        public ActionResult Get_all_t()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                List<Teacher> std_list = tm.get_all_t().ToList();
                return View(std_list);
            }
            else
                return RedirectToAction("login", "Login");
        }
	}
}