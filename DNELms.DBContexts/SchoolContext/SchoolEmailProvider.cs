using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class SchoolEmailProvider
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FromDisplayName { get; set; }
        public string FromPassword { get; set; }
        public bool IsPrimary { get; set; }
        public string Smtpurl { get; set; }
        public bool Smtpssl { get; set; }
        public int? Smtpport { get; set; }
    }
}
