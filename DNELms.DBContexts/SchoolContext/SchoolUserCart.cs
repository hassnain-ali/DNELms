using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class SchoolUserCart
    {
        public long Id { get; set; }
        public long? CourseId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsRemoved { get; set; }

        public virtual SchoolCourse Course { get; set; }
        public virtual AspNetUser CreatedByNavigation { get; set; }
    }
}
