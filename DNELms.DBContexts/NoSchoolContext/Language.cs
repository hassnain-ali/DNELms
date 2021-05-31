using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class Language : BaseEntity
    {
        public Language()
        {
            Courses = new HashSet<Course>();
        }

        //public int Id { get; set; }
        public string Name { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ShortName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ShortNameLocal { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
