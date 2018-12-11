using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication19.Models;

namespace WebApplication19.Controllers
{
    public class userpassController : Controller
    {
        // GET: userpass
        [HttpPost]
        public ActionResult enter(FormCollection fc)
        {
            Models.User u = new Models.User(Convert.ToInt32(fc["Userid"]), fc["password"]);
            Class2.ps(u);
            
            return View();
        }
        public ActionResult enter()
        {

            return View("");
        }
        public ActionResult show()
        {

            return View("");
        }
        public ActionResult Delete(string id)
        {

            string Sqry = "Delete from Member  where Mid='" + id + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("show");
        }
        public ActionResult edit(string id)
        {
            ViewBag.Message = "Your contact page.";
            
            userpassmodel.id = id;
            return View();

        }
        [HttpPost]
        public ActionResult edit(FormCollection fc)
        {
            ViewBag.Message = "Your contact page.";
            userpassmodel a=new userpassmodel(Convert.ToInt32(fc["mid"]), fc["pass"]);
            userpassmodel.edit1(a);
            return View("show");

        }
    }
}