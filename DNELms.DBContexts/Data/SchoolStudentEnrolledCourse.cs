using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class SchoolStudentEnrolledCourse
    {
        public SchoolStudentEnrolledCourse()
        {
            SchoolStudentEnrolledCoursesPayments = new HashSet<SchoolStudentEnrolledCoursesPayment>();
        }

        public long Id { get; set; }
        public long? CourseId { get; set; }
        public string StudentId { get; set; }
        public bool IsExpired { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountPrice { get; set; }
        public DateTime? EnrolledDate { get; set; }

        public virtual SchoolCourse Course { get; set; }
        public virtual AspNetUser Student { get; set; }
        public virtual ICollection<SchoolStudentEnrolledCoursesPayment> SchoolStudentEnrolledCoursesPayments { get; set; }
    }
}
