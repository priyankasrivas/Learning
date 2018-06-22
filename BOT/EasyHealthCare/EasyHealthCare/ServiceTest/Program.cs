using EasyHealthCareService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            IHospitalSearch search = new HospitalSearch();
            search.SearchHospital(new EasyHealthCareService.Models.SearchCriteria{ hospState = "Punjab", hospCity = "Jalandhar" });
            Console.ReadLine();
        }
    }
}
