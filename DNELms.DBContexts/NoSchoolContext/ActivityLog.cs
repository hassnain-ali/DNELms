using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class ActivityLog : BaseEntity
    {
        //public long Id { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public string Detail { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual AspNetUser CreatedByNavigation { get; set; }
    }
}
