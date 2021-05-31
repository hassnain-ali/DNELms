using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class SchoolCourseLessonsMaster
    {
        public SchoolCourseLessonsMaster()
        {
            SchoolCourseLessonsDetails = new HashSet<SchoolCourseLessonsDetail>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long? CourseId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual SchoolCourse Course { get; set; }
        public virtual ICollection<SchoolCourseLessonsDetail> SchoolCourseLessonsDetails { get; set; }
    }
}
