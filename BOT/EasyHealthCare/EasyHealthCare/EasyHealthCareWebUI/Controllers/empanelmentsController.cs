using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EasyHealthCareDataStore;

namespace EasyHealthCareWebUI.Controllers
{
    public class empanelmentsController : Controller
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();

        // GET: empanelments
        public ActionResult Index()
        {
            return View(db.empanelments.ToList());
        }

        // GET: empanelments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empanelment empanelment = db.empanelments.Find(id);
            if (empanelment == null)
            {
                return HttpNotFound();
            }
            return View(empanelment);
        }

        // GET: empanelments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: empanelments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "empanelment_id,empanelment_type,empanelment_Code")] empanelment empanelment)
        {
            if (ModelState.IsValid)
            {
                db.empanelments.Add(empanelment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empanelment);
        }

        // GET: empanelments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empanelment empanelment = db.empanelments.Find(id);
            if (empanelment == null)
            {
                return HttpNotFound();
            }
            return View(empanelment);
        }

        // POST: empanelments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "empanelment_id,empanelment_type,empanelment_Code")] empanelment empanelment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empanelment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empanelment);
        }

        // GET: empanelments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            empanelment empanelment = db.empanelments.Find(id);
            if (empanelment == null)
            {
                return HttpNotFound();
            }
            return View(empanelment);
        }

        // POST: empanelments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            empanelment empanelment = db.empanelments.Find(id);
            db.empanelments.Remove(empanelment);
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
