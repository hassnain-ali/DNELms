using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class CourseLessonsDetail
    {
        public long Id { get; set; }
        public long? CourseLessonId { get; set; }
        public string ContentType { get; set; }
        public string FilePath { get; set; }
        public string Accessiblity { get; set; }

        public virtual CourseLessonsMaster CourseLesson { get; set; }
    }
}
