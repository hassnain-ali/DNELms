using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class School
    {
        public School()
        {
            SchoolCourses = new HashSet<SchoolCourse>();
            SchoolOwners = new HashSet<SchoolOwner>();
        }

        public int SchoolId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }

        public virtual ICollection<SchoolCourse> SchoolCourses { get; set; }
        public virtual ICollection<SchoolOwner> SchoolOwners { get; set; }
    }
}
