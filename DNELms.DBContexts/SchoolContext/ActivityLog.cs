using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class ActivityLog
    {
        public long Id { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public string Detail { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual AspNetUser CreatedByNavigation { get; set; }
    }
}
