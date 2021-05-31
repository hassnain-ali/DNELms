using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class CourseInstructor
    {
        public long Id { get; set; }
        public long? CourseId { get; set; }
        public string InstructorId { get; set; }

        public virtual Course Course { get; set; }
        public virtual AspNetUser Instructor { get; set; }
    }
}
