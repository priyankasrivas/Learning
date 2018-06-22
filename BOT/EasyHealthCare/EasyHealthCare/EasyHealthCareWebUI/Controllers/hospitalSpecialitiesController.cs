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
    public class hospitalSpecialitiesController : Controller
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();

        // GET: hospitalSpecialities
        public ActionResult Index()
        {
            return View(db.hospitalSpecialities.ToList());
        }

        // GET: hospitalSpecialities/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospitalSpeciality hospitalSpeciality = db.hospitalSpecialities.Find(id);
            if (hospitalSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(hospitalSpeciality);
        }

        // GET: hospitalSpecialities/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: hospitalSpecialities/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hosp_speciality_id,Speciality_Name,Speciality_Description")] hospitalSpeciality hospitalSpeciality)
        {
            if (ModelState.IsValid)
            {
                db.hospitalSpecialities.Add(hospitalSpeciality);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(hospitalSpeciality);
        }

        // GET: hospitalSpecialities/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospitalSpeciality hospitalSpeciality = db.hospitalSpecialities.Find(id);
            if (hospitalSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(hospitalSpeciality);
        }

        // POST: hospitalSpecialities/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hosp_speciality_id,Speciality_Name,Speciality_Description")] hospitalSpeciality hospitalSpeciality)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospitalSpeciality).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(hospitalSpeciality);
        }

        // GET: hospitalSpecialities/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospitalSpeciality hospitalSpeciality = db.hospitalSpecialities.Find(id);
            if (hospitalSpeciality == null)
            {
                return HttpNotFound();
            }
            return View(hospitalSpeciality);
        }

        // POST: hospitalSpecialities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hospitalSpeciality hospitalSpeciality = db.hospitalSpecialities.Find(id);
            db.hospitalSpecialities.Remove(hospitalSpeciality);
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
