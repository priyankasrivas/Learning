using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHealthCareService.Models
{
    public class Hospital
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string state { get; set; }
        public string district { get; set; }
        public string city { get; set; }
        public string pinCode { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public bool isPPN { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public List<AssociatedInsuranceCompany> associatedInsuranceCompanies { get; set; }
        public List<string> hospSpecialities { get; set; }
        public int avgRating { get; set; }
        public int entityId { get; set; }
        public bool blacklisted { get; set; }
        public string location { get; set; }
        public List<string> empanelments { get; set; }
        public string emergencyContactNumber { get; set; }
    }

}
