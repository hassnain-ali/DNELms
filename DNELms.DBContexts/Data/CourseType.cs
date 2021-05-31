using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class CourseType
    {
        public CourseType()
        {
            Courses = new HashSet<Course>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
