using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using US5NET.Models.US;

namespace US5NET.Controllers.US2000
{
    public class SystClasController : Controller
    {
        private USEntities db = new USEntities();

        // GET: T_SYST_CLAS
        public ActionResult Index()
        {
            return View(db.T_SYST_CLAS.ToList());
            //return View();
        }

        //Ajax Action
        [HttpPost]
        public JsonResult Getdata(string id)
        {
            //Model Select
            var data = db.T_SYST_CLAS.Where(m => m.SYST_NO.Contains(id)).ToList();


            return Json(data);
        }

        //Form Submit Action
        public ActionResult GetdataSubmit(T_SYST_CLAS t_SYST_CLAS)
        {
            //Model Select
            var data = db.T_SYST_CLAS.Where(m => m.SYST_NO.Contains(t_SYST_CLAS.SYST_NO)).ToList();

            //
            return View("Index", data);
        }


        // GET: T_SYST_CLAS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: T_SYST_CLAS/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SYST_NO,CLAS_NO,CLAS_NAME")] T_SYST_CLAS t_SYST_CLAS)
        {
            if (ModelState.IsValid)
            {
                db.T_SYST_CLAS.Add(t_SYST_CLAS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(t_SYST_CLAS);
        }

        // GET: T_SYST_CLAS/Edit/5
        public ActionResult Edit(string systno, string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //T_SYST_CLAS t_SYST_CLAS = db.T_SYST_CLAS.Find(systno,id);
            var t_SYST_CLAS = db.T_SYST_CLAS.Where(m => m.SYST_NO == systno && m.CLAS_NO == id);

            if (t_SYST_CLAS == null)
            {
                return HttpNotFound();
            }

            return View(t_SYST_CLAS.ToList());
        }

       
        // POST: T_SYST_CLAS/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SYST_NO,CLAS_NO,CLAS_NAME")] T_SYST_CLAS t_SYST_CLAS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(t_SYST_CLAS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(t_SYST_CLAS);
        }

        // GET: T_SYST_CLAS/Delete/5
        public ActionResult Delete(string systno, string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var t_SYST_CLAS = db.T_SYST_CLAS.Where(m => m.SYST_NO == systno && m.CLAS_NO == id).FirstOrDefault();
            db.T_SYST_CLAS.Remove(t_SYST_CLAS);
            db.SaveChanges();
            return RedirectToAction("Index");

            if (t_SYST_CLAS == null)
            {
                return HttpNotFound();
            }
            return View(t_SYST_CLAS);
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
