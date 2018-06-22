using EasyHealthCareDataStore;
using EasyHealthCareService.Models;
using Flurl.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace EasyHealthCareService
{
    public class HospitalDetails: IHospitalDetails
    {
        private EasyHealthCareEntities db = new EasyHealthCareEntities();

        public async Task<List<Hospital>> GetHospitalDetails()
        {
            List<Hospital> hospitals = new List<Hospital>();
            var response = await Constants.MedibuddySearchUrl.PostJsonAsync(new SearchCriteria { hospCity= "Faridabad"}).ReceiveJson<RootObject>();

            if (response != null)
            {
                hospitals = response.hospitals;
            }
            foreach (var hospital in hospitals)
            {
                db.hospital_medibuddy.Add(new hospital_medibuddy
                {

                    hospital_name = hospital.name,
                    hospital_email = hospital.email,
                    hospital_address = hospital.address,
                    hospital_state = hospital.state,
                    hospital_pincode = hospital.pinCode,
                    hospital_city = hospital.city,
                    hospital_district = hospital.district,
                    hospital_id = hospital.id,
                    avgRating = hospital.avgRating,
                    location= hospital.location,
                    blacklisted = hospital.blacklisted,
                    hospital_phone = hospital.phone,
                    entityId = hospital.entityId,
                    hospital_latitude = hospital.latitude,
                    hospital_longitude = hospital.longitude,

                });

            }

            db.SaveChanges();
            return hospitals;
        }
    }
}
