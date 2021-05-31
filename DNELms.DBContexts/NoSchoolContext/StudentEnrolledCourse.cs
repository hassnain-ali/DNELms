using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class StudentEnrolledCourse : BaseEntity
    {
        public StudentEnrolledCourse()
        {
            StudentEnrolledCoursesPayments = new HashSet<StudentEnrolledCoursesPayment>();
        }

        //public long Id { get; set; }
        public long? CourseId { get; set; }
        public string StudentId { get; set; }
        public bool IsExpired { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public DateTime? EnrolledDate { get; set; }

        public virtual Course Course { get; set; }
        public virtual AspNetUser Student { get; set; }
        public virtual ICollection<StudentEnrolledCoursesPayment> StudentEnrolledCoursesPayments { get; set; }
    }
}
