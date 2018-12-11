using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;
namespace WebApplication19.Controllers
{
    public class authorController : Controller
    {
        // GET: author
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
            author a = new author( Convert.ToInt32(fc["aid"]), fc["aname"]);
            author.enter(a);
            return View("show");

        }
        public ActionResult Delete(string id)
        {

            string Sqry = "Delete from Author  where Aid='" + id + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("show");
        }
        public ActionResult update(string id)
        {
            ViewBag.Message = "Your contact page.";

            author.id = id;
            return View();

        }
        [HttpPost]
        public ActionResult update(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
            author a = new author( Convert.ToInt32(fc["aid"]), fc["aname"]);
            author.update(a);
            return View("show");

        }
    }
}