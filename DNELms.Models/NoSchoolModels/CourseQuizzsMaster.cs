using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class CourseQuizzsMaster : BaseEntity
    {
        //public long Id { get; set; }
        public long CourseId { get; set; }
        public DateTime QuizDate { get; set; }
        public TimeSpan QuizTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public TimeSpan AllowedTime { get; set; }
        public bool? AllowedReview { get; set; }

    }
}
