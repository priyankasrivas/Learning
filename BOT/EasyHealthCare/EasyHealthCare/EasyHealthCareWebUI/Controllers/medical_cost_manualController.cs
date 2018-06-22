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
    public class medical_cost_manualController : Controller
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();

        // GET: medical_cost_manual
        public ActionResult Index()
        {
            var medical_cost_manual = db.medical_cost_manual.Include(m => m.hospital_manual).Include(m => m.medical_services);
            return View(medical_cost_manual.ToList());
        }

        // GET: medical_cost_manual/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medical_cost_manual medical_cost_manual = db.medical_cost_manual.Find(id);
            if (medical_cost_manual == null)
            {
                return HttpNotFound();
            }
            return View(medical_cost_manual);
        }

        // GET: medical_cost_manual/Create
        public ActionResult Create()
        {
            ViewBag.hospital_id = new SelectList(db.hospital_manual, "hospital_id", "hospital_name");
            ViewBag.medical_service_id = new SelectList(db.medical_services, "medical_service_id", "medical_service_name");
            return View();
        }

        // POST: medical_cost_manual/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medical_cost_id,hospital_id,medical_service_id,medical_cost")] medical_cost_manual medical_cost_manual)
        {
            if (ModelState.IsValid)
            {
                db.medical_cost_manual.Add(medical_cost_manual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hospital_id = new SelectList(db.hospital_manual, "hospital_id", "hospital_name", medical_cost_manual.hospital_id);
            ViewBag.medical_service_id = new SelectList(db.medical_services, "medical_service_id", "medical_service_name", medical_cost_manual.medical_service_id);
            return View(medical_cost_manual);
        }

        // GET: medical_cost_manual/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medical_cost_manual medical_cost_manual = db.medical_cost_manual.Find(id);
            if (medical_cost_manual == null)
            {
                return HttpNotFound();
            }
            ViewBag.hospital_id = new SelectList(db.hospital_manual, "hospital_id", "hospital_name", medical_cost_manual.hospital_id);
            ViewBag.medical_service_id = new SelectList(db.medical_services, "medical_service_id", "medical_service_name", medical_cost_manual.medical_service_id);
            return View(medical_cost_manual);
        }

        // POST: medical_cost_manual/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medical_cost_id,hospital_id,medical_service_id,medical_cost")] medical_cost_manual medical_cost_manual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medical_cost_manual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hospital_id = new SelectList(db.hospital_manual, "hospital_id", "hospital_name", medical_cost_manual.hospital_id);
            ViewBag.medical_service_id = new SelectList(db.medical_services, "medical_service_id", "medical_service_name", medical_cost_manual.medical_service_id);
            return View(medical_cost_manual);
        }

        // GET: medical_cost_manual/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medical_cost_manual medical_cost_manual = db.medical_cost_manual.Find(id);
            if (medical_cost_manual == null)
            {
                return HttpNotFound();
            }
            return View(medical_cost_manual);
        }

        // POST: medical_cost_manual/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            medical_cost_manual medical_cost_manual = db.medical_cost_manual.Find(id);
            db.medical_cost_manual.Remove(medical_cost_manual);
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
