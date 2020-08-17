using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using US5NET.Models.US;

namespace US5NET.Controllers.US1000
{
    public class QuerController : Controller
    {
        private USLocalEntities db = new USLocalEntities();

        
        public ActionResult Quer()
        {
            return View(db.T_SYST_CLAS.ToList());
        }

        [HttpPost]
        public ActionResult Quer(string problem)
        {

            var receiveProblem = problem;

            return View();
        }

        [HttpPost]
        public string GetData(string id)
        {
            var data = db.T_SYST_CLAS.Where(m => m.CLAS_NAME == id);
            //var receiveProblem = id;

            return id;
        }

        [HttpPost]
        public JsonResult GetSystData(string id)
        {
            var data = db.T_SYST_CLAS.Where(m => m.SYST_NO == id);

            return Json(data);
        }

        public ActionResult Upload()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Quers(FormCollection post, IEnumerable<HttpPostedFileBase> file)
        {
            //獲得上一次的案號，並加1
            var t = db.T_CASE_BASE.Max(m => m.CASE_NO);
            string s = (Convert.ToInt32(t) + 1).ToString();
            string CASE_NO = s.PadLeft(4, '0');
            string SYST_NO = post["option_system"];
            string CLAS_NO = post["option_problem"];
            string QUER_CONT = post["exampleFormControlTextarea_content"];
            string URGE_IF = post["customRadioInline1"];
            string EXPE_REPL_TIME = post["select_time"];
            string QUER_DATE = DateTime.UtcNow.ToString("yyyyMMdd");
            string CASE_STAT = "B";
            string CASE_STAR_DATE = DateTime.UtcNow.ToString("yyyyMMdd"); ;
            string CASE_END_DATE = "";
            string EMPL_NO = "";
            int QUER_NUMB = 1;

            string FILE_NAME = "";
            string FILE_ADDR = "";
            int FILE_NO = 1;



            //step1 insert CASE_BASE
            string RawSQL1 = "INSERT INTO T_CASE_BASE (CASE_NO,SYST_NO,CLAS_NO,EMPL_NO,CASE_STAR_DATE,CASE_END_DATE) " +
                                    "VALUES('" +
                                    CASE_NO + "','" +
                                    SYST_NO + "','" +
                                    CLAS_NO + "','" +
                                    EMPL_NO + "','" +
                                    CASE_STAR_DATE + "','" +
                                    CASE_END_DATE + "'); ";
            db.Database.ExecuteSqlCommand(RawSQL1);
            db.SaveChanges();


            //step2 insert CASE_BASE
            string RawSQL2 = "INSERT INTO T_QUER_DATA (CASE_NO,QUER_NUMB,URGE_IF,EXPE_REPL_TIME,QUER_CONT,QUER_DATE,CASE_STAT) " +
                                "VALUES('" +
                                CASE_NO + "','" +
                                QUER_NUMB + "','" +
                                URGE_IF + "','" +
                                EXPE_REPL_TIME + "','" +
                                QUER_CONT + "','" +
                                QUER_DATE + "','" +
                                CASE_STAT + "'); ";
            db.Database.ExecuteSqlCommand(RawSQL2);
            db.SaveChanges();

            //step3 insert 

            foreach (var files in file)
            {

                if (files != null && files.ContentLength > 0)
                {
                    FILE_NAME = Path.GetFileName(files.FileName);
                    FILE_ADDR = Path.Combine(Server.MapPath("~/FileUploads"), FILE_NAME);

                    files.SaveAs(FILE_ADDR);
                    string RawSQL3 = "INSERT INTO T_QUER_FILE (CASE_NO,QUER_NUMB,FILE_NO,FILE_ADDR,FILE_NAME,UPLD_DATE) " +
                                 "VALUES('" +
                                 CASE_NO + "'," +
                                 QUER_NUMB + "," +
                                 FILE_NO++ + ",'" +
                                 FILE_ADDR + "','" +
                                 FILE_NAME + "','" +
                                 CASE_STAR_DATE + "');";
                    db.Database.ExecuteSqlCommand(RawSQL3);
                    db.SaveChanges();

                }

            }



            return Redirect("/Home");
        }

    
    }
}