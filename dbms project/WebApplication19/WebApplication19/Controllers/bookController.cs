using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;
namespace WebApplication19.Controllers
{
    public class bookController : Controller
    {
        // GET: book
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
            bookmodel a = new bookmodel(Convert.ToInt32(fc["bkid"]), (fc["title"]));
            bookmodel.enter(a);
            return View("show");

        }
        public ActionResult Delete(string bid)
        {

            string Sqry = "Delete from Bok  where Bid='" + bid + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("show");
        }
        public ActionResult update(string bid)
        {
            ViewBag.Message = "Your contact page.";

            bookmodel.bid = bid;
            return View();

        }
        [HttpPost]
        public ActionResult update(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
            bookmodel a = new bookmodel(Convert.ToInt32(fc["bkid"]), (fc["title"]));
            bookmodel.update(a);
            return View("show");

        }
    }
}