using EasyHealthCareDataStore;
using EasyHealthCareService;
using EasyHealthCareService.Models;
using EasyHealthCareWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace EasyHealthCareWebUI.Controllers
{
    public class HospitalSearchController : Controller
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();
        // GET: HospitalSearch
        public ActionResult Index()
        {
            HospitalSearchViewModel data = new HospitalSearchViewModel();
            return View(data);
        }

        [HttpPost]
        public async Task<ActionResult> Index(HospitalSearchViewModel sc)
        {
            HospitalSearchViewModel data = new HospitalSearchViewModel();
            data.SearchCriteria = sc.SearchCriteria;
            IHospitalSearch search = new HospitalSearch();
            data.SearchResult = await search.SearchHospital(sc.SearchCriteria);
            //addEmpanelmentData(data.SearchResult);
            return View(data);
        }

        public ActionResult Report()
        {
            HospitalSearchViewModel data = new HospitalSearchViewModel();
            return View("Report");
        }

        private void addEmpanelmentData(List<Hospital> hospitalData)
        {
            foreach (var item in hospitalData)
            {
                var record = db.hosp_emp_emergency_map.Where(r => r.hospital_id == item.id);
                item.empanelments = record.Select(r => r.empanelment.empanelment_Code).ToList();
                item.emergencyContactNumber = record.Where(r=>r.emergency_num != null).Select(r => r.emergency_num).FirstOrDefault();
            }

           
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