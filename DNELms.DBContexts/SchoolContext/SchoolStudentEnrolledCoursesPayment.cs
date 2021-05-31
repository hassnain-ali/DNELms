using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class SchoolStudentEnrolledCoursesPayment
    {
        public long Id { get; set; }
        public long? EnrolledCourseId { get; set; }
        public string TransactionId { get; set; }
        public string PayerId { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
        public string PaymentEvidencePicture { get; set; }
        public DateTime? TransactionDate { get; set; }

        public virtual SchoolStudentEnrolledCourse EnrolledCourse { get; set; }
    }
}
