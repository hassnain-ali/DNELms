using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class SchoolCourseCategory
    {
        public SchoolCourseCategory()
        {
            InverseParent = new HashSet<SchoolCourseCategory>();
            SchoolCourses = new HashSet<SchoolCourse>();
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

        public virtual SchoolCourseCategory Parent { get; set; }
        public virtual ICollection<SchoolCourseCategory> InverseParent { get; set; }
        public virtual ICollection<SchoolCourse> SchoolCourses { get; set; }
    }
}
