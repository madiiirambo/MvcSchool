using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class locController : Controller
    {
        // GET: loc
        public ActionResult show()
        {
            return View();
        }
        public ActionResult enter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult enter(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
            locationmodel a = new locationmodel(Convert.ToInt32(fc["locid"]), Convert.ToInt32(fc["shelfno"]));
            locationmodel.enter(a);
            return View("show");

        }
        public ActionResult Delete(string lid)
        {

            string Sqry = "Delete from Location  where Locationid='" + lid + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("show");
        }
        public ActionResult edit(string lid)
        {
            ViewBag.Message = "Your contact page.";

            locationmodel.lid = lid;
            return View();

        }
        [HttpPost]
        public ActionResult edit(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
            locationmodel a = new locationmodel(Convert.ToInt32(fc["locid"]), Convert.ToInt32(fc["shelfno"]));
            locationmodel.edit(a);
            return View("show");

        }
    }
}