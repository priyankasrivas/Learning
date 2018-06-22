using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHealthCareService.Models
{
   public class SearchCriteria
    {
        public int hospId { get; set; }
        [DisplayName("Name")]
        public string hospName { get; set; }
        [DisplayName("State")]
        public string hospState { get; set; }
        [DisplayName("City")]
        public string hospCity { get; set; }
        [DisplayName("Location")]
        public string hospLocation { get; set; }
        public string insuranceCompany { get; set; }
        public string hospCount { get; set; }
        public string hospSpeciality { get; set; }
        public int maRating { get; set; }

    }
}
