using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class CourseLessonsMaster : BaseEntity
    {
        public CourseLessonsMaster()
        {
            CourseLessonsDetails = new HashSet<CourseLessonsDetail>();
        }

        //public long Id { get; set; }
        public string Name { get; set; }
        public long? CourseId { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<CourseLessonsDetail> CourseLessonsDetails { get; set; }
    }
}
