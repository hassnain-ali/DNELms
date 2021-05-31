using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class CourseInstructor : BaseEntity
    {
        //public long Id { get; set; }
        public long? CourseId { get; set; }
        public string InstructorId { get; set; }
    }
}
