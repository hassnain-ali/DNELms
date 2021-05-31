using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class SchoolOwner
    {
        public long Id { get; set; }
        public int? SchoolId { get; set; }
        public string OwnerId { get; set; }

        public virtual AspNetUser Owner { get; set; }
        public virtual School School { get; set; }
    }
}
