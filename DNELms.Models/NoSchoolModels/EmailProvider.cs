using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class EmailProviders : BaseEntity
    {
        //public int Id { get; set; }
        public string Email { get; set; }
        public string FromDisplayName { get; set; }
        public string FromPassword { get; set; }
        public bool IsPrimary { get; set; }
        public string Smtpurl { get; set; }
        public bool Smtpssl { get; set; }
        public int? Smtpport { get; set; }

    }
}
