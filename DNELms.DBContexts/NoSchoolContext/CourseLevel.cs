using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class CourseLevel : BaseEntity
    {
        public CourseLevel()
        {
            Courses = new HashSet<Course>();
        }

        //public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
