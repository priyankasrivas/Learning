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
    public class hospital_manualController : Controller
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();

        // GET: hospital_manual
        public ActionResult Index()
        {
            var hospital_manual = db.hospital_manual.Include(h => h.hospitalSpeciality);
            return View(hospital_manual.ToList());
        }

        // GET: hospital_manual/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_manual hospital_manual = db.hospital_manual.Find(id);
            if (hospital_manual == null)
            {
                return HttpNotFound();
            }
            return View(hospital_manual);
        }

        // GET: hospital_manual/Create
        public ActionResult Create()
        {
            ViewBag.hosp_speciality_id = new SelectList(db.hospitalSpecialities, "hosp_speciality_id", "Speciality_Name");
            return View();
        }

        // POST: hospital_manual/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hospital_id,hospital_name,hospital_address,hospital_state,hospital_district,hospital_city,hospital_pincode,hospital_phone,hospital_email,hospital_latitude,hospital_longitude,hosp_speciality_id,avgRating,entityId,blacklisted,location")] hospital_manual hospital_manual)
        {
            if (ModelState.IsValid)
            {
                db.hospital_manual.Add(hospital_manual);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hosp_speciality_id = new SelectList(db.hospitalSpecialities, "hosp_speciality_id", "Speciality_Name", hospital_manual.hosp_speciality_id);
            return View(hospital_manual);
        }

        // GET: hospital_manual/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_manual hospital_manual = db.hospital_manual.Find(id);
            if (hospital_manual == null)
            {
                return HttpNotFound();
            }
            ViewBag.hosp_speciality_id = new SelectList(db.hospitalSpecialities, "hosp_speciality_id", "Speciality_Name", hospital_manual.hosp_speciality_id);
            return View(hospital_manual);
        }

        // POST: hospital_manual/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hospital_id,hospital_name,hospital_address,hospital_state,hospital_district,hospital_city,hospital_pincode,hospital_phone,hospital_email,hospital_latitude,hospital_longitude,hosp_speciality_id,avgRating,entityId,blacklisted,location")] hospital_manual hospital_manual)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital_manual).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hosp_speciality_id = new SelectList(db.hospitalSpecialities, "hosp_speciality_id", "Speciality_Name", hospital_manual.hosp_speciality_id);
            return View(hospital_manual);
        }

        // GET: hospital_manual/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_manual hospital_manual = db.hospital_manual.Find(id);
            if (hospital_manual == null)
            {
                return HttpNotFound();
            }
            return View(hospital_manual);
        }

        // POST: hospital_manual/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hospital_manual hospital_manual = db.hospital_manual.Find(id);
            db.hospital_manual.Remove(hospital_manual);
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
