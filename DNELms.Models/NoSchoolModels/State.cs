using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class States : BaseEntity
    {

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

    }
}
