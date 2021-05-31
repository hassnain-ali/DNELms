using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class ErrorLog : BaseEntity
    {
        //public int Id { get; set; }
        public string UserId { get; set; }
        public string Message { get; set; }
        public string Url { get; set; }
        public DateTime CreateDate { get; set; }
        public string IpAddress { get; set; }
    }
}
