using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyHealthCareService.Models
{
    public class RootObject
    {
        public bool isSuccess { get; set; }
        public List<Hospital> hospitals { get; set; }
    }
}
