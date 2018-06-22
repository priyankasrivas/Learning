using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using EasyHealthCareDataStore;
using EasyHealthCareService;
using EasyHealthCareService.Models;

namespace EasyHealthCareWebUI.Controllers
{
    public class hospital_medibuddyController : Controller
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();

        // GET: hospital_medibuddy
        public ActionResult Index()
        {
            var hospital_medibuddy = db.hospital_medibuddy.Include(h => h.hospitalSpeciality);
            return View(hospital_medibuddy.ToList());
        }

        // GET: hospital_medibuddy/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_medibuddy hospital_medibuddy = db.hospital_medibuddy.Find(id);
            if (hospital_medibuddy == null)
            {
                return HttpNotFound();
            }
            return View(hospital_medibuddy);
        }

        // GET: hospital_medibuddy/Create
        public ActionResult Create()
        {
            ViewBag.hosp_speciality_id = new SelectList(db.hospitalSpecialities, "hosp_speciality_id", "Speciality_Name");
            return View();
        }

        // POST: hospital_medibuddy/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "hospital_id,hospital_name,hospital_address,hospital_state,hospital_district,hospital_city,hospital_pincode,hospital_phone,hospital_email,hospital_latitude,hospital_longitude,hosp_speciality_id,avgRating,entityId,blacklisted,location")] hospital_medibuddy hospital_medibuddy)
        {
            if (ModelState.IsValid)
            {
                db.hospital_medibuddy.Add(hospital_medibuddy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.hosp_speciality_id = new SelectList(db.hospitalSpecialities, "hosp_speciality_id", "Speciality_Name", hospital_medibuddy.hosp_speciality_id);
            return View(hospital_medibuddy);
        }

        // GET: hospital_medibuddy/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_medibuddy hospital_medibuddy = db.hospital_medibuddy.Find(id);
            if (hospital_medibuddy == null)
            {
                return HttpNotFound();
            }
            ViewBag.hosp_speciality_id = new SelectList(db.hospitalSpecialities, "hosp_speciality_id", "Speciality_Name", hospital_medibuddy.hosp_speciality_id);
            return View(hospital_medibuddy);
        }

        // POST: hospital_medibuddy/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "hospital_id,hospital_name,hospital_address,hospital_state,hospital_district,hospital_city,hospital_pincode,hospital_phone,hospital_email,hospital_latitude,hospital_longitude,hosp_speciality_id,avgRating,entityId,blacklisted,location")] hospital_medibuddy hospital_medibuddy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hospital_medibuddy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.hosp_speciality_id = new SelectList(db.hospitalSpecialities, "hosp_speciality_id", "Speciality_Name", hospital_medibuddy.hosp_speciality_id);
            return View(hospital_medibuddy);
        }

        // GET: hospital_medibuddy/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            hospital_medibuddy hospital_medibuddy = db.hospital_medibuddy.Find(id);
            if (hospital_medibuddy == null)
            {
                return HttpNotFound();
            }
            return View(hospital_medibuddy);
        }

        // POST: hospital_medibuddy/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            hospital_medibuddy hospital_medibuddy = db.hospital_medibuddy.Find(id);
            db.hospital_medibuddy.Remove(hospital_medibuddy);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        [Route("hospital_medibuddy/InsertHospitalDetails")]
        public async Task<ActionResult> InsertHospitalDetails()
        {
            List<Hospital> hm = new List<Hospital>();          
            IHospitalDetails hospitalDetails = new HospitalDetails();
            hm = await hospitalDetails.GetHospitalDetails();
            return View(hm);
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
