using SMS.Models;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Microsoft.Reporting.WebForms;

namespace SMS.Controllers
{
    public class ResultController : Controller
    {
        AddResult sc = new AddResult();
        List<AddResult> ids_list;
        [HttpGet]
        public ActionResult addresult()
        {
            //if (Convert.ToString(Session["login_session"]) == "ok")
            //{

                AddResult std = new AddResult();
                

                ids_list = std.get_class_all_id_();
                ViewBag.adil1 = new SelectList(ids_list, "class_id", "class_id");

                ids_list = std.get_exam_all_id_();
                ViewBag.adil2 = new SelectList(ids_list, "exam_id", "exam_id");

                ids_list = std.get_sub_all_id_();
                ViewBag.adil3 = new SelectList(ids_list, "sub_id", "sub_id");
                 // phr isse tw direct query likh k ni hora kia?
            // ni yarr woh iENUM ka error h view run karo dikhao 
                return View(std);
            //}
            //else
            //    return RedirectToAction("login", "Login");

        }

        [HttpPost]
        public ActionResult addresult(AddResult std,int class_id,int sub_id,int exam_id)
        { 

            ids_list = std.get_class_all_id_();
            ViewBag.adil1 = new SelectList(ids_list, "class_id", "class_id");

            ids_list = std.get_exam_all_id_();
            ViewBag.adil2 = new SelectList(ids_list, "exam_id", "exam_id");

            ids_list = std.get_sub_all_id_();
            ViewBag.adil3 = new SelectList(ids_list, "sub_id", "sub_id");
            
            std.add_result1(class_id, sub_id);
            ViewBag.myList = std.obj;
            for (int i = 0; i < std.obj.Count; i++)
            {
                std.obj[i].exam_id = exam_id;
            }
            
            
            

            return View("save_date",std.obj);

}
      [HttpGet]
        public ActionResult save_date(List<AddResult> riz)
        {
            
            return View(riz);
        }
        [HttpPost]
        public ActionResult save_date(List<AddResult> riz, FormCollection obj)
        {
            AddResult obj2 = new AddResult();
            for (int i = 0; i < obj.Count; i+=6)
            {
                string id = obj[i];
                string name = obj[i + 1];
                string class_id = obj[i + 2];
                string sub_id = obj[i + 3];
                string exam_id = obj[i + 4];
                string marks_obt = obj[i + 5];
                obj2.add_result(id,class_id,exam_id,sub_id,marks_obt);
            }
            return Content("Updated");
        }



        [HttpGet]
        public ActionResult addattend()
        {
            if (Convert.ToString(Session["login_session"]) == "ok")
            {

                AddResult std = new AddResult();
                ids_list = std.get_std_all_id_();
                ViewBag.adil = new SelectList(ids_list, "std_id", "std_id");

                ids_list = std.get_class_all_id_();
                ViewBag.adil1 = new SelectList(ids_list, "class_id", "class_id");

                

                ids_list = std.get_sub_all_id_();
                ViewBag.adil3 = new SelectList(ids_list, "sub_id", "sub_id");

                return View(std);
            }
            else
                return RedirectToAction("login", "Login");

        }

        [HttpPost]
        public ActionResult addattend(AddResult std)
        {
            std.add_attend();
            ViewBag.adil = new SelectList(std.get_std_all_id_(), "std_id", "std_id");
            ViewBag.adil1 = new SelectList(std.get_class_all_id_(), "class_id", "class_id");
           
            ViewBag.adil3 = new SelectList(std.get_sub_all_id_(), "sub_id", "sub_id");
            return View(std);

        }
        public ActionResult Report()
        {

            LocalReport lr = new LocalReport();

            string path = Path.Combine(Server.MapPath("~/Reporting"), "adil.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }

            List<reportModel> cm = reportModel.get_report_data().ToList();

            ReportDataSource rd = new ReportDataSource("DataSet1", cm);
            lr.DataSources.Add(rd);
            string reportType = "PDF";
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

            try
            {
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
            }catch(LocalProcessingException ex)
            {
                return View(ex);  
            }
        }

       
    }
}