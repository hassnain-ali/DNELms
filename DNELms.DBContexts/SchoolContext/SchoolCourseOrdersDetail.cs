using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class SchoolCourseOrdersDetail
    {
        public long Id { get; set; }
        public int? CourseOrderId { get; set; }
        public long? CourseId { get; set; }

        public virtual SchoolCourse Course { get; set; }
        public virtual SchoolCourseOrdersMaster CourseOrder { get; set; }
    }
}
