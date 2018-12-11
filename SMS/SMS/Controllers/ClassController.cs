using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class ClassController : Controller
    {
        Class sc = new Class();
        List<Class> ids_list;

        [HttpGet]
        public ActionResult add_class()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                

                return View();
            }
            else
                return RedirectToAction("login", "Login");

        }

        [HttpPost]
        public ActionResult add_class(Class cl)
        {
            cl.add_class();
        
            return View(cl);
        }

        [HttpGet]
        public ActionResult add_class_sub()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                Class std = new Class();

                ids_list = std.get_class_all_id_();
                ViewBag.adil1 = new SelectList(ids_list, "class_id", "class_id");

                ids_list = std.get_sub_all_id_();
                ViewBag.adil3 = new SelectList(ids_list, "sub_id", "sub_id");

                ids_list = std.get_sub_t_id_();
                ViewBag.adil4 = new SelectList(ids_list, "t_id", "t_id");

                return View();

            }
            else
                return RedirectToAction("login", "Login");

        }

        [HttpPost]
        public ActionResult add_class_sub(Class cl)
        {
            cl.add_class_sub();
            ViewBag.adil1 = new SelectList(cl.get_class_all_id_(), "class_id", "class_id");
            ViewBag.adil3 = new SelectList(cl.get_sub_all_id_(), "sub_id", "sub_id");
            ViewBag.adil4 = new SelectList(cl.get_sub_t_id_(), "t_id", "t_id");
            return View(cl);
        }
	}
}