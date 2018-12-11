using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SMS.Controllers
{
    public class Admin_PanelController : Controller
    {

        public ActionResult admin_panel()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {
                return View();
            }
            else
            {
                return RedirectToAction("login", "Login");
            }
        }
    }
}