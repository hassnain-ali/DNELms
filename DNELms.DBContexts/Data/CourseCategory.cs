using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class CourseCategory
    {
        public CourseCategory()
        {
            Courses = new HashSet<Course>();
            InverseParent = new HashSet<CourseCategory>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string SmallImage { get; set; }
        public string BannerImage { get; set; }
        public long? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual CourseCategory Parent { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<CourseCategory> InverseParent { get; set; }
    }
}
