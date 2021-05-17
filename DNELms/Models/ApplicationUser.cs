using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace DNELms.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string PostCode { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FlatPassword { get; set; }
        public bool IsActive { get; set; }
        [ForeignKey("CityId")]
        public int? CityId { get; set; }
        [ForeignKey("StateId")]
        public int? StateId { get; set; }
        [ForeignKey("CountryId")]
        public int? CountryId { get; set; }

        //public virtual City City { get; set; }
        //public virtual Country Country { get; set; }
        //public virtual State State { get; set; }
    }
}
