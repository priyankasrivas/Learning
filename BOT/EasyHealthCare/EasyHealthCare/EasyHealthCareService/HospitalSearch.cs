using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyHealthCareService.Models;
using Flurl.Http;
using Newtonsoft.Json;

namespace EasyHealthCareService
{
    public class HospitalSearch : IHospitalSearch
    {
        public async Task<List<Hospital>> SearchHospital(SearchCriteria searchInput)
        {
            List<Hospital> hospitals= new List<Hospital>();
           var response = await Constants.MedibuddySearchUrl.PostJsonAsync(searchInput).ReceiveJson<RootObject>();
           
            if (response != null)
            {
                hospitals = response.hospitals;
            }
            return hospitals;
        }
    }
}
