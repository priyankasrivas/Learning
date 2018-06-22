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
    public class hosp_emp_emergency_mapController : Controller
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();

        // GET: hosp_emp_emergency_map
        public ActionResult Index()
        {
            var hosp_emp_emergency_map = db.hosp_emp_emergency_map.Include(h => h.empanelment).Include(h => h.hospital_medibuddy);
            return View(hosp_emp_emergency_map.ToList());
        }

        // GET: hosp_emp_emergency_map/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hosp_emp_emergency_map hosp_emp_emergency_map = db.hosp_emp_emergency_map.Find(id);
            if (hosp_emp_emergency_map == null)
            {
                return HttpNotFound();
            }
            return View(hosp_emp_emergency_map);
        }

        // GET: hosp_emp_emergency_map/Create
        public ActionResult Create()
        {
            ViewBag.empanelment_id = new SelectList(db.empanelments, "empanelment_id", "empanelment_type");
            ViewBag.hospital_id = new SelectList(db.hospital_medibuddy, "hospital_id", "hospital_name");
            return View();
        }

        // POST: hosp_emp_emergency_map/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hosp_emp_emergency_map1,empanelment_id,hospital_id,emergency_num")] hosp_emp_emergency_map hosp_emp_emergency_map)
        {
            if (ModelState.IsValid)
            {
                db.hosp_emp_emergency_map.Add(hosp_emp_emergency_map);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.empanelment_id = new SelectList(db.empanelments, "empanelment_id", "empanelment_type", hosp_emp_emergency_map.empanelment_id);
            ViewBag.hospital_id = new SelectList(db.hospital_medibuddy, "hospital_id", "hospital_name", hosp_emp_emergency_map.hospital_id);
            return View(hosp_emp_emergency_map);
        }

        // GET: hosp_emp_emergency_map/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hosp_emp_emergency_map hosp_emp_emergency_map = db.hosp_emp_emergency_map.Find(id);
            if (hosp_emp_emergency_map == null)
            {
                return HttpNotFound();
            }
            ViewBag.empanelment_id = new SelectList(db.empanelments, "empanelment_id", "empanelment_type", hosp_emp_emergency_map.empanelment_id);
            ViewBag.hospital_id = new SelectList(db.hospital_medibuddy, "hospital_id", "hospital_name", hosp_emp_emergency_map.hospital_id);
            return View(hosp_emp_emergency_map);
        }

        // POST: hosp_emp_emergency_map/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hosp_emp_emergency_map1,empanelment_id,hospital_id,emergency_num")] hosp_emp_emergency_map hosp_emp_emergency_map)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hosp_emp_emergency_map).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.empanelment_id = new SelectList(db.empanelments, "empanelment_id", "empanelment_type", hosp_emp_emergency_map.empanelment_id);
            ViewBag.hospital_id = new SelectList(db.hospital_medibuddy, "hospital_id", "hospital_name", hosp_emp_emergency_map.hospital_id);
            return View(hosp_emp_emergency_map);
        }

        // GET: hosp_emp_emergency_map/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hosp_emp_emergency_map hosp_emp_emergency_map = db.hosp_emp_emergency_map.Find(id);
            if (hosp_emp_emergency_map == null)
            {
                return HttpNotFound();
            }
            return View(hosp_emp_emergency_map);
        }

        // POST: hosp_emp_emergency_map/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hosp_emp_emergency_map hosp_emp_emergency_map = db.hosp_emp_emergency_map.Find(id);
            db.hosp_emp_emergency_map.Remove(hosp_emp_emergency_map);
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
