using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;
namespace WebApplication19.Controllers
{
    public class publisherController : Controller
    {
        // GET: publisher
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
            publishermodel a = new publishermodel(Convert.ToInt32(fc["pid"]), fc["pname"]);
            publishermodel.enter(a);
            return View("show");

        }
        public ActionResult Delete(string id)
        {

            string Sqry = "Delete from Publisher  where Pid='" + id + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("show");
        }
        public ActionResult update(string id)
        {
            ViewBag.Message = "Your contact page.";

            publishermodel.id = id;
            return View();

        }
        [HttpPost]
        public ActionResult update(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
            publishermodel a = new publishermodel(Convert.ToInt32(fc["pid"]), fc["pname"]);
            publishermodel.update(a);
            return View("show");

        }
    }
}