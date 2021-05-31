using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class City
    {
        public City()
        {
            AspNetUsers = new HashSet<AspNetUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int StateId { get; set; }
        public string StateCode { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public short Flag { get; set; }
        public string WikiDataId { get; set; }

        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
    }
}
