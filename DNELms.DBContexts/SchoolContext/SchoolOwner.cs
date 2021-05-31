using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class SchoolOwner
    {
        public long Id { get; set; }
        public int? SchoolId { get; set; }
        public string OwnerId { get; set; }

        public virtual AspNetUser Owner { get; set; }
    }
}
