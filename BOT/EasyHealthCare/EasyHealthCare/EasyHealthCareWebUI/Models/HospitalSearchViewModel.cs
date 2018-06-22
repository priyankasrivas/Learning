using EasyHealthCareService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyHealthCareWebUI.Models
{
    public class HospitalSearchViewModel
    {
        public SearchCriteria SearchCriteria { get; set; }
        public List<Hospital> SearchResult { get; set; }
    }
}