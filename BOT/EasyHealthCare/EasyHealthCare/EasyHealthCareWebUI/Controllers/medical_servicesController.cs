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
    public class medical_servicesController : Controller
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();

        // GET: medical_services
        public ActionResult Index()
        {
            return View(db.medical_services.ToList());
        }

        // GET: medical_services/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medical_services medical_services = db.medical_services.Find(id);
            if (medical_services == null)
            {
                return HttpNotFound();
            }
            return View(medical_services);
        }

        // GET: medical_services/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: medical_services/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "medical_service_id,medical_service_name,medical_service_category,medical_service_description")] medical_services medical_services)
        {
            if (ModelState.IsValid)
            {
                db.medical_services.Add(medical_services);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medical_services);
        }

        // GET: medical_services/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medical_services medical_services = db.medical_services.Find(id);
            if (medical_services == null)
            {
                return HttpNotFound();
            }
            return View(medical_services);
        }

        // POST: medical_services/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "medical_service_id,medical_service_name,medical_service_category,medical_service_description")] medical_services medical_services)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medical_services).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medical_services);
        }

        // GET: medical_services/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            medical_services medical_services = db.medical_services.Find(id);
            if (medical_services == null)
            {
                return HttpNotFound();
            }
            return View(medical_services);
        }

        // POST: medical_services/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            medical_services medical_services = db.medical_services.Find(id);
            db.medical_services.Remove(medical_services);
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
