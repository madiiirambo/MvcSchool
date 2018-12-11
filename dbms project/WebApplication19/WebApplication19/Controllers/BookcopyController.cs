using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;
namespace WebApplication19.Controllers
{
    public class BookcopyController : Controller
    {
        // GET: Bookcopy
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
            bookcopy a = new bookcopy(Convert.ToInt32(fc["bcno"]), Convert.ToInt32(fc["isbn"]), Convert.ToInt32(fc["blid"]));
            bookcopy.enter(a);
            return View("show");

        }
        public ActionResult Delete(string bno)
        {

            string Sqry = "Delete from BookCopy  where Bcopyno='" + bno + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("show");
        }
        public ActionResult update(string bno)
        {
            ViewBag.Message = "Your contact page.";

            bookcopy.bno = bno;
            return View();

        }
        [HttpPost]
        public ActionResult update(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
            bookcopy a = new bookcopy(Convert.ToInt32(fc["bcno"]), Convert.ToInt32(fc["isbn"]), Convert.ToInt32(fc["blid"]));
            bookcopy.update(a);
            return View("show");

        }
    }
}