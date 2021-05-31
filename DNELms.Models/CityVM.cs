using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DNELms.Models
{
    public class CityVM_Result : DTModel
    {
        public string CityName { get; set; }
        public int CityId { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string StateCode { get; set; }
        public string CountryCode { get; set; }
        public string StateName { get; set; }
        public string CountryName { get; set; }
    }
    public class DTModel
    {
        public int RowNo { get; set; }
        public int Total { get; set; }

    }
}
