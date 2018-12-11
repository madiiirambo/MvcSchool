using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using WebApplication19.Models;
using System.IO;
using Microsoft.Reporting.WebForms;
namespace WebApplication19.Controllers
{
    public class HomeController : Controller
    {
        [HttpPost]
        public ActionResult Viewmmember(FormCollection fc)
        {
            //Models.newmem a = new Models.newmem(Convert.ToInt32(fc["midd"]));
            //Class2.asd(a);
            

            return View("Index");
        }
        
        public ActionResult report()
        {

            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Report"), "Report2.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }

            List<Reportmodel> cm = Reportmodel.get_report_data().ToList();

            ReportDataSource rd = new ReportDataSource("DataSet1", cm);
            lr.DataSources.Add(rd);
            string reportType = "pdf";
            string mimeType;
            string encoding;
            string fileNameExtension;

            string deviceInfo =

            "<DeviceInfo>" +
            "  <OutputFormat>" + reportType + "</OutputFormat>" +
            "  <PageWidth>11in</PageWidth>" +
            "  <PageHeight>8.5in</PageHeight>" +
            "  <MarginTop>0.5in</MarginTop>" +
            "  <MarginLeft>0.5in</MarginLeft>" +
            "  <MarginRight>0.5in</MarginRight>" +
            "  <MarginBottom>0.5in</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;

            renderedBytes = lr.Render(
                reportType,
                deviceInfo,
                out mimeType,
                out encoding,
                out fileNameExtension,
                out streams,
                out warnings);


            return File(renderedBytes, mimeType);
        }
        public ActionResult Search(string id)
        {
            msearch.id = Convert.ToInt32(id);
            return View("show");
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(FormCollection fc,string id)
        {
           adminlogin a=new adminlogin(fc["email"],fc["passward"]);
           //object s = a.get_data(a);
            //int t=Convert.ToInt32(s);
            //if(t>0)
            //a.get_data(a);
           if (a.get_data(a).Rows.Count > 0)
            {
           //int t = Convert.ToInt32(s);
            //if(t>0)
            
                return RedirectToAction("Viewmmember", "Home");

            }
            return View();
          //int v = Convert.ToInt32(s);
            //string s = login.get_data()
            //if (login.get_data().Rows.Count > 0)
            //{
              //if (v>0)
                //{
                //    return RedirectToAction("Viewmmember", "Home");
                //}
            
            //return View();
        }
        public ActionResult Viewmmember()
        {
            ViewBag.Message = "";
            return View("Viewmmember");
        }
        public ActionResult newmember()
        {
            return View();
        }
        public ActionResult Viewm()
        {
            ViewBag.Message = "";
            return View("Viewm");
        }
       
        [HttpPost]
        public ActionResult newmember(FormCollection fc)
        {
            
            Models.newmem s = new Models.newmem(Convert.ToInt32(fc["bisno"]), Convert.ToDateTime(fc["bisdate"]),Convert.ToInt32( fc["mid"]),Convert.ToDateTime( fc["ddate"]));
            Class2.bk(s);

            return View("Viewbook");
        }
       
       
        public ActionResult Viewbook()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult upbook()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult upbook(FormCollection fc)
        {
            Models.newmem s = new Models.newmem(Convert.ToInt32(fc["bisno"]),Convert.ToDateTime( fc["bisdate"]), Convert.ToInt32(fc["mid"]),Convert.ToDateTime( fc["ddate"]));
            Class2.bku(s);

            return View("Viewbook");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [HttpPost]
        public ActionResult About(FormCollection fc)
        {
            Models.newmem ss = new Models.newmem(fc["name"], fc["email"], fc["contact"], fc["address"], fc["cnic"]);
            Class2.newme(ss);
            ViewBag.succesfull = true;
            ViewBag.Message = "Your application description page.";

            return View("Viewmmember");
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //[HttpPost]
        //public ActionResult userpass(FormCollection fc)

        //{
        //    Models.User u = new Models.User(Convert.ToInt32(fc["Userid"]), fc["password"]);
        //    Class2.ps(u);
        ////    ViewBag.Message = "Your contact page.";

        ////    Alllist a = new Alllist();
        ////    filllist b = new filllist();
        ////    a.user = b.filluser();
        //    return View();
        //}
        //public ActionResult userpass()
        //{
           
        //    return View("userpass");
        //}
        
        public ActionResult up(string id)
        {
            ViewBag.Message = "Your contact page.";
            //string Sqry = "select * from Member  where Mid='" + id + "'";
            //SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            //SqlDataAdapter sda = new SqlDataAdapter(sqlcmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);
            //Class2.upmg(id);
            //Class2 a = new Class2();
            Class2.id = id;
            return View();

        }
        [HttpPost]
        public ActionResult up(FormCollection fc)
        {

            Models.newmem ss = new Models.newmem(Convert.ToInt32(fc["mid"]), fc["name"], fc["email"], fc["contact"], fc["address"], fc["cnic"]);
            Class2.asd(ss);
            return View("Viewmmember");
        }
        [HttpGet]
        public ActionResult Delete(string id)
        {
            
            string Sqry = "Delete from Member  where Mid='" + id + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("Viewmmember");
        }
        [HttpGet]
        public ActionResult Debk(string id)
        {

            string Sqry = "Delete from BokIssue  where Bisuueno='" + id + "'";

            SqlCommand sqlcmd = new SqlCommand(Sqry, Class1.GetConnection());
            sqlcmd.ExecuteNonQuery();
            return View("viewbook");
        }
        //[HttpGet]
        public string id;
        public ActionResult Edit(string id)
        {
            this.id = id;
            
            //SqlCommand sqlcmd = new SqlCommand("Update Member  set Mname='" +name+ "',Memail='" + email + "',Mcontact='" + contact + "',Maddress='" + address + "',CNIC='" + cnic + "' where Mid='" + id+"'", Class1.GetConnection());
            //sqlcmd.ExecuteNonQuery();
            
            return View("up");
        }
        public ActionResult AfterLogIN()
        {
            return View();
        }
    }
}