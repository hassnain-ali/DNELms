using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class State : BaseEntity
    {
        public State()
        {
            AspNetUsers = new HashSet<AspNetUser>();
            Cities = new HashSet<City>();
        }

        //public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public string CountryCode { get; set; }
        public string FipsCode { get; set; }
        public string Iso2 { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public short Flag { get; set; }
        public string WikiDataId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<AspNetUser> AspNetUsers { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}
