﻿using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class StudentEnrolledCoursesPayment : BaseEntity
    {
        //public long Id { get; set; }
        public long? EnrolledCourseId { get; set; }
        public string TransactionId { get; set; }
        public string PayerId { get; set; }
        public decimal? Amount { get; set; }
        public string Status { get; set; }
        public string PaymentType { get; set; }
        public string PaymentEvidencePicture { get; set; }
        public DateTime? TransactionDate { get; set; }

    }
}
