using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;
using System.Data.SqlClient;
using System.Data;
namespace WebApplication19.Controllers
{
    public class bookrecvController : Controller
    {
        // GET: bookrecv
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
            bookrecvmodel a = new bookrecvmodel(Convert.ToInt32(fc["bookisno"]),Convert.ToInt32( fc["bcno"]),Convert.ToDateTime((fc["brd"])),Convert.ToInt32(fc["fine"]));
            bookrecvmodel.enter(a);
            return View("show");

        }
        public ActionResult Delete(string id)
        {

            string Sqry = "Delete from BookRecv  where Bissueno='" + id + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("show");
        }
        public ActionResult edit(string bino)
        {
            ViewBag.Message = "Your contact page.";

            bookrecvmodel.bino = bino;
            return View();

        }
        [HttpPost]
        public ActionResult edit(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
            bookrecvmodel a = new bookrecvmodel(Convert.ToInt32(fc["bookisno"]), Convert.ToInt32(fc["bcno"]), Convert.ToDateTime((fc["brd"])), Convert.ToInt32(fc["fine"]));
            bookrecvmodel.edit(a);
            return View("show");

        }
    }
}