﻿using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class SchoolLanguage
    {
        public SchoolLanguage()
        {
            SchoolCourses = new HashSet<SchoolCourse>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ShortName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string ShortNameLocal { get; set; }

        public virtual ICollection<SchoolCourse> SchoolCourses { get; set; }
    }
}
