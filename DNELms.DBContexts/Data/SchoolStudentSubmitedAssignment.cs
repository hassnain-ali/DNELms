using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class SchoolStudentSubmitedAssignment
    {
        public long Id { get; set; }
        public long AssignmentId { get; set; }
        public string StudentId { get; set; }
        public string SubmittedFilePath { get; set; }
        public bool IsSubmitted { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public int? ObtainedMarks { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public virtual SchoolCourseAssignment Assignment { get; set; }
        public virtual AspNetUser Student { get; set; }
    }
}
