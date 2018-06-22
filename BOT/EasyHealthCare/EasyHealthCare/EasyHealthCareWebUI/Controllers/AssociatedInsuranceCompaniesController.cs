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
    public class AssociatedInsuranceCompaniesController : Controller
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();

        // GET: AssociatedInsuranceCompanies
        public ActionResult Index()
        {
            var associatedInsuranceCompanies = db.AssociatedInsuranceCompanies.Include(a => a.hospital_medibuddy);
            return View(associatedInsuranceCompanies.ToList());
        }

        // GET: AssociatedInsuranceCompanies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociatedInsuranceCompany associatedInsuranceCompany = db.AssociatedInsuranceCompanies.Find(id);
            if (associatedInsuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(associatedInsuranceCompany);
        }

        // GET: AssociatedInsuranceCompanies/Create
        public ActionResult Create()
        {
            ViewBag.hospital_id = new SelectList(db.hospital_medibuddy, "hospital_id", "hospital_name");
            return View();
        }

        // POST: AssociatedInsuranceCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hospital_id,insurance_company_id")] AssociatedInsuranceCompany associatedInsuranceCompany)
        {
            if (ModelState.IsValid)
            {
                db.AssociatedInsuranceCompanies.Add(associatedInsuranceCompany);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hospital_id = new SelectList(db.hospital_medibuddy, "hospital_id", "hospital_name", associatedInsuranceCompany.hospital_id);
            return View(associatedInsuranceCompany);
        }

        // GET: AssociatedInsuranceCompanies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociatedInsuranceCompany associatedInsuranceCompany = db.AssociatedInsuranceCompanies.Find(id);
            if (associatedInsuranceCompany == null)
            {
                return HttpNotFound();
            }
            ViewBag.hospital_id = new SelectList(db.hospital_medibuddy, "hospital_id", "hospital_name", associatedInsuranceCompany.hospital_id);
            return View(associatedInsuranceCompany);
        }

        // POST: AssociatedInsuranceCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hospital_id,insurance_company_id")] AssociatedInsuranceCompany associatedInsuranceCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(associatedInsuranceCompany).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hospital_id = new SelectList(db.hospital_medibuddy, "hospital_id", "hospital_name", associatedInsuranceCompany.hospital_id);
            return View(associatedInsuranceCompany);
        }

        // GET: AssociatedInsuranceCompanies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssociatedInsuranceCompany associatedInsuranceCompany = db.AssociatedInsuranceCompanies.Find(id);
            if (associatedInsuranceCompany == null)
            {
                return HttpNotFound();
            }
            return View(associatedInsuranceCompany);
        }

        // POST: AssociatedInsuranceCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssociatedInsuranceCompany associatedInsuranceCompany = db.AssociatedInsuranceCompanies.Find(id);
            db.AssociatedInsuranceCompanies.Remove(associatedInsuranceCompany);
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
