using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using US5NET.Models.US;


namespace US5NET.Controllers.US2000
{
    public class AnsrController : Controller
    {

        private USEntities db = new USEntities();

        // GET: Ansr
        public ActionResult Index()
        {
            List<T_CASE_BASE> CaseBase = db.T_CASE_BASE.ToList();
            List<T_QUER_DATA> QuerData = db.T_QUER_DATA.ToList();
            List<T_SYST_CLAS> SystClas = db.T_SYST_CLAS.ToList();

            var CaseList = from c in CaseBase
                           join q in QuerData on c.CASE_NO equals q.CASE_NO
                           into table1
                           from q in table1.ToList()
                           join s in SystClas on new { c.CLAS_NO, c.SYST_NO } equals new { s.CLAS_NO, s.SYST_NO }
                           into table2
                           from s in table2.ToList()
                           select new V_CASE_LIST
                           {
                               CaseBase = c,
                               QuerData = q,
                               SystClas = s
                           };
            //db.Database.ExecuteSqlCommand("select * from ...);

            return View(CaseList);
        }

        //Ajax Action
        [HttpPost]
        public JsonResult Getdata(string id)
        {
            //Model Select
            //var data = db.T_CASE_BASE.Where(m => m.SYST_NO.Contains(id)).ToList();

            List<T_CASE_BASE> CaseBase = db.T_CASE_BASE.ToList();
            List<T_QUER_DATA> QuerData = db.T_QUER_DATA.ToList();
            List<T_SYST_CLAS> SystClas = db.T_SYST_CLAS.ToList();

            var CaseList = from c in CaseBase
                           join q in QuerData on c.CASE_NO equals q.CASE_NO
                           into table1
                           from q in table1.ToList()
                           join s in SystClas on new { c.CLAS_NO, c.SYST_NO } equals new { s.CLAS_NO, s.SYST_NO }
                           into table2
                           from s in table2.ToList()
                           where s.SYST_NO == id
                           select new V_CASE_LIST
                           {
                               CaseBase = c,
                               QuerData = q,
                               SystClas = s
                           };

            ArrayList result = new ArrayList();
            for (int i = 0; i < CaseList.ToList().Count; i++)
            {
                ArrayList d = new ArrayList();
                var p = 0;
                d.Insert(p, CaseList.ToList()[i].CaseBase.CASE_NO);
                d.Insert(++p, CaseList.ToList()[i].CaseBase.SYST_NO);
                d.Insert(++p, CaseList.ToList()[i].SystClas.CLAS_NAME);
                d.Insert(++p, CaseList.ToList()[i].CaseBase.EMPL_NO);
                d.Insert(++p, CaseList.ToList()[i].CaseBase.CASE_STAR_DATE);
                d.Insert(++p, CaseList.ToList()[i].QuerData.QUER_NUMB);
                d.Insert(++p, CaseList.ToList()[i].QuerData.URGE_IF);
                d.Insert(++p, CaseList.ToList()[i].QuerData.EXPE_REPL_TIME);
                d.Insert(++p, CaseList.ToList()[i].QuerData.CASE_STAT);
                d.Insert(++p, CaseList.ToList()[i].CaseBase.CASE_END_DATE);

                result.Insert(i, d);
            }

            //var result = new {C_CASE_NO = CaseList.ToList()[0].CaseBase.CASE_NO,
            //    C_SYST_NO = CaseList.ToList()[0].CaseBase.SYST_NO,
            //    S_CLAS_NAME = CaseList.ToList()[0].SystClas.CLAS_NAME,
            //    C_EMPL_NO = CaseList.ToList()[0].CaseBase.EMPL_NO,
            //    C_CASE_STAR_DATE = CaseList.ToList()[0].CaseBase.CASE_STAR_DATE,
            //    Q_QUER_NUMB = CaseList.ToList()[0].QuerData.QUER_NUMB,
            //    Q_URGE_IF = CaseList.ToList()[0].QuerData.URGE_IF,
            //    Q_EXPE_REPL_TIME = CaseList.ToList()[0].QuerData.EXPE_REPL_TIME,
            //    Q_CASE_STAT = CaseList.ToList()[0].QuerData.CASE_STAT,
            //    C_CASE_END_DATE = CaseList.ToList()[0].CaseBase.CASE_END_DATE
            //};

            return Json(result);
        }

        public ActionResult Ansr(string caseno, string systno, int numb)
        {
            List<T_CASE_BASE> CaseBase = db.T_CASE_BASE.ToList();
            List<T_QUER_DATA> QuerData = db.T_QUER_DATA.ToList();
            List<T_SYST_CLAS> SystClas = db.T_SYST_CLAS.ToList();

            //var t_case_base = db.T_CASE_BASE.Where(m => m.CASE_NO == caseno && m.SYST_NO == systno);
            var CaseList = from c in CaseBase
                           join q in QuerData on c.CASE_NO equals q.CASE_NO
                           into table1
                           from q in table1.ToList()
                           join s in SystClas on new { c.CLAS_NO, c.SYST_NO } equals new { s.CLAS_NO, s.SYST_NO }
                           into table2
                           from s in table2.ToList()
                           where s.SYST_NO == systno && c.CASE_NO == caseno && q.QUER_NUMB == numb
                           select new V_CASE_LIST
                           {
                               CaseBase = c,
                               QuerData = q,
                               SystClas = s
                           };



            return View(CaseList);
        }
        
        public ActionResult SaveResponseData(IEnumerable<HttpPostedFileBase> fileData, FormCollection formData)
        {
            var path = "";
            var fileName = "";

            //RawSQL寫法
            //var RawSQL = "";
            //RawSQL = "insert into TableName() values()";
            //db.Database.ExecuteSqlCommand(RawSQL);
            //db.SaveChanges();

            //EF寫法
            T_ANSR_DATA t_ANSR_DATA = new T_ANSR_DATA()
            {
                CASE_NO = formData[0],
                QUER_NUMB = int.Parse(formData[1]),
                ANSR_CONT = formData[3],
                ANSR_DATE = DateTime.Now.ToString("yyyyMMddHHmmss"),
                QA_NO = formData[2]
            };
            //t_SYST_CLAS.SYST_NO = "";
            //t_SYST_CLAS.CLAS_NAME = "";
            //t_SYST_CLAS.CLAS_NO = "";
            db.T_ANSR_DATA.Add(t_ANSR_DATA);
            db.SaveChanges();

            try
            {
                int i = 1;
                foreach (var file in fileData)
                {
                    if (file != null && file.ContentLength > 0)
                    {
                        fileName = Path.GetFileName(file.FileName);
                        path = Path.Combine(Server.MapPath("~/FileUploads"), fileName);
                        file.SaveAs(path);
                        T_ANSR_FILE t_ANSR_FILE = new T_ANSR_FILE()
                        {
                            CASE_NO = formData[0],
                            QUER_NUMB = int.Parse(formData[1]),
                            FILE_NO = i++,
                            FILE_ADDR = path,
                            FILE_NAME = fileName,
                            UPLD_DATE = DateTime.Now.ToString("yyyyMMddHHmmss")
                        };
                        db.T_ANSR_FILE.Add(t_ANSR_FILE);
                        db.SaveChanges();
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }     
                }
            }
            catch (DbEntityValidationException ex)
            {
                
            }
            
            return RedirectToAction("Index");
        }
    }
}
