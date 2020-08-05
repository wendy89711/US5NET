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
    public class SystClasController : Controller
    {
        private USEntities db = new USEntities();

        // GET: T_SYST_CLAS
        public ActionResult Index()
        {
            return View(db.T_SYST_CLAS.ToList());
            //return View();
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

        [HttpPost]
        public ActionResult Getdata(string id)
        {
            //Model Select


            return XXX;
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
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            T_SYST_CLAS t_SYST_CLAS = db.T_SYST_CLAS.Find(id);
            if (t_SYST_CLAS == null)
            {
                return HttpNotFound();
            }
            return View(t_SYST_CLAS);
        }

        // POST: T_SYST_CLAS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirm(string id)
        {
            T_SYST_CLAS t_SYST_CLAS = db.T_SYST_CLAS.Find(id);
            db.T_SYST_CLAS.Remove(t_SYST_CLAS);
            db.SaveChanges();
            return RedirectToAction("Index");
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
