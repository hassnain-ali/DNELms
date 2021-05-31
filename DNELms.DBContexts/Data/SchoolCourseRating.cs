using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class SchoolCourseRating
    {
        public long Id { get; set; }
        public long? CourseId { get; set; }
        public string UserId { get; set; }
        public int? Rating { get; set; }

        public virtual SchoolCourse Course { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
