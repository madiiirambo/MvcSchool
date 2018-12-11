using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;
namespace WebApplication19.Controllers
{
    public class bkauthorController : Controller
    {
        // GET: bkauthor
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
            bkauthor a = new bkauthor(Convert.ToInt32(fc["isbn"]), Convert.ToInt32(fc["aid"]), fc["aname"]);
            bkauthor.enter(a);
            return View("show");

        }
        public ActionResult Delete(string id)
        {

            string Sqry = "Delete from BookAuthor  where ISBN='" + id + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("show");
        }
        public ActionResult update(string id)
        {
            ViewBag.Message = "Your contact page.";

            bkauthor.id = id;
            return View();

        }
        [HttpPost]
        public ActionResult update(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
             bkauthor a = new bkauthor(Convert.ToInt32(fc["isbn"]), Convert.ToInt32(fc["aid"]), fc["aname"]);
            bkauthor.update(a);
            return View("show");

        }
    }
}