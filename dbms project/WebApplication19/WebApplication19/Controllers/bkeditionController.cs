using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;
namespace WebApplication19.Controllers
{
    public class bkeditionController : Controller
    {
        // GET: bkedition
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
            bkeditionn a = new bkeditionn(Convert.ToInt32(fc["bkid"]), fc["bkedition"],Convert.ToInt32(fc["pid"]),Convert.ToDateTime(fc["pdate"]));
            bkeditionn.enter(a);
            return View("show");

        }
        public ActionResult Delete(string bid)
        {

            string Sqry = "Delete from BookEdition  where Bid='" + bid + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("show");
        }
        public ActionResult update(string bid)
        {
            ViewBag.Message = "Your contact page.";

            bkeditionn.bid = bid;
            return View();

        }
        [HttpPost]
        public ActionResult update(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
            bkeditionn a = new bkeditionn(Convert.ToInt32(fc["bkid"]), fc["bkedition"], Convert.ToInt32(fc["pid"]), Convert.ToDateTime(fc["pdate"]));
            bkeditionn.update(a);
            return View("show");

        }
    }
}