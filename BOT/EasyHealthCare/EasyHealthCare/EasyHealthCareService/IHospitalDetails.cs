using EasyHealthCareService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHealthCareService
{
    public interface IHospitalDetails
    {
        Task<List<Hospital>> GetHospitalDetails();
    }
}
