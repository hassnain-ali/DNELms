using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class CourseLessonsDetail : BaseEntity
    {
        //public long Id { get; set; }
        public long? CourseLessonId { get; set; }
        public string ContentType { get; set; }
        public string FilePath { get; set; }
        public string Accessiblity { get; set; }

        public virtual CourseLessonsMaster CourseLesson { get; set; }
    }
}
