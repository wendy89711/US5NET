using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using US5NET.Models;

namespace US5NET.Controllers.US2000
{
    public class SystQAdbController : Controller
    {
        private USEntities db = new USEntities();

        // GET: SystQAdb
        public ActionResult Index()
        {
            return View(db.T_SYST_QADB.ToList());
        }

        //Ajax Action
        [HttpPost]
        public JsonResult Getdata(string id)
        {
            //Model Select
            var data = db.T_SYST_QADB.Where(m => m.SYST_NO.Contains(id)).ToList();


            return Json(data);
        }

        // GET: SystQAdb/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SystQAdb/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SYST_NO,QA_NO,QUER_CONT,ANSR_CONT")] T_SYST_QADB t_SYST_QADB)
        {
            if (ModelState.IsValid)
            {
                db.T_SYST_QADB.Add(t_SYST_QADB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_SYST_QADB);
        }

        // GET: SystQAdb/Edit/5
        public ActionResult Edit(string systno, string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //T_SYST_QADB t_SYST_QADB = db.T_SYST_QADB.Find(id);
            var t_SYST_QADB = db.T_SYST_QADB.Where(m => m.SYST_NO == systno && m.QA_NO == id);

            if (t_SYST_QADB == null)
            {
                return HttpNotFound();
            }
            return View(t_SYST_QADB.ToList());
        }

        // POST: SystQAdb/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SYST_NO,QA_NO,QUER_CONT,ANSR_CONT")] T_SYST_QADB t_SYST_QADB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_SYST_QADB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_SYST_QADB);
        }

        // GET: SystQAdb/Delete/5
        public ActionResult Delete(string systno, string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var t_SYST_QADB = db.T_SYST_QADB.Where(m => m.SYST_NO == systno && m.QA_NO == id).FirstOrDefault();
            db.T_SYST_QADB.Remove(t_SYST_QADB);
            db.SaveChanges();
            return RedirectToAction("Index");

            if (t_SYST_QADB == null)
            {
                return HttpNotFound();
            }
            return View(t_SYST_QADB);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
