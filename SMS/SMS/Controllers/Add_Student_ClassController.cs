using SMS.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class Add_Student_ClassController : Controller
    {
        Student_Class sc = new Student_Class();
        List<Student_Class> st_list;
        [HttpGet]

        public ActionResult add_std_class()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
               
                Student_Class std = new Student_Class();
                st_list = std.get_std_all_ids();
                ViewBag.adil = new SelectList(st_list, "std_id", "std_id");
                return View(std);
            }
            else
                return RedirectToAction("login", "Login");

        }

        [HttpPost]
        public ActionResult add_std_class(Student_Class std)
        {
            std.add_std_class();
            ViewBag.adil = new SelectList(std.get_std_all_ids(), "std_id", "std_id");
            return View(std);



        }
    }
}