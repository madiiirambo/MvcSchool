using SMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class StudentController : Controller
    {
        StudentModel std_dataa = new StudentModel();
        Get_Std_By_Class gsby = new Get_Std_By_Class();

        [HttpGet]
        public ActionResult get_all_std_by_class()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                List<Get_Std_By_Class> std_list = new List<Get_Std_By_Class>();
                return View(std_list);
            }
            else
                return RedirectToAction("login", "Login");
        }

        [HttpPost]
        public ActionResult get_all_std_by_class(Get_Std_By_Class gsby, string class_no)
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                List<Get_Std_By_Class> std_list = gsby.get_std_by_class(class_no);
                return View(std_list);
            }
            else
                return RedirectToAction("login", "Login");
        }


        [HttpGet]
        public ActionResult add_student()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
                return View();
            else
                return RedirectToAction("login", "Login");

        }

        [HttpPost]
        public ActionResult add_student(StudentModel std_d)
        {
            std_d.addstd_data();
            return View(std_d);
        }
        [HttpGet]
        public ActionResult Get_all_std()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                List<StudentModel> std_list = std_dataa.get_all_std().ToList();
                return View(std_list);
            }
            else
                return RedirectToAction("login", "Login");
        }

        
        [HttpGet]
        public ActionResult edit(int std_id)
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                StudentModel std_m = new StudentModel();
                bool chk = std_m.Get_std_data(std_id);

                if (chk)
                {
                    std_dataa = std_m;
                    return View(std_dataa);
                }
                else
                  return View(std_dataa);
            }
            else
              return View(std_dataa);
            
            
        }

        [HttpPost]
        public ActionResult edit(StudentModel std)
        {
            std.std_upt();
            return View(std);
        }

        [HttpGet]
        public ActionResult edit1(int std_id)
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                StudentModel std_m = new StudentModel();
                bool chk = std_m.Get_std_data(std_id);

                if (chk)
                {
                    std_dataa = std_m;
                    return View(std_dataa);
                }
                else
                {
                    return View(std_dataa);
                }
            }
            else return View(std_dataa);
        }

        [HttpPost]
        public ActionResult edit1(StudentModel std)
        {
            std.std_delete();
            return View(std);
        }


        
    }
}