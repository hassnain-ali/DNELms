using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class StudentEnrolledCourses : BaseEntity
    {

        //public long Id { get; set; }
        public long? CourseId { get; set; }
        public string StudentId { get; set; }
        public bool IsExpired { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public DateTime? EnrolledDate { get; set; }

    }
}
