using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class StudentSubmitedAssignment : BaseEntity
    {
        //public long Id { get; set; }
        public long AssignmentId { get; set; }
        public string StudentId { get; set; }
        public string SubmittedFilePath { get; set; }
        public bool IsSubmitted { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public int? ObtainedMarks { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
}
