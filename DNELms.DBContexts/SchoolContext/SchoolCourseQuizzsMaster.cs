using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class SchoolCourseQuizzsMaster
    {
        public SchoolCourseQuizzsMaster()
        {
            SchoolQuizQuestionsMasters = new HashSet<SchoolQuizQuestionsMaster>();
            SchoolStudentAttemptedQuizzs = new HashSet<SchoolStudentAttemptedQuizz>();
        }

        public long Id { get; set; }
        public long CourseId { get; set; }
        public DateTime QuizDate { get; set; }
        public TimeSpan QuizTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public TimeSpan AllowedTime { get; set; }
        public bool AllowedReview { get; set; }

        public virtual SchoolCourse Course { get; set; }
        public virtual ICollection<SchoolQuizQuestionsMaster> SchoolQuizQuestionsMasters { get; set; }
        public virtual ICollection<SchoolStudentAttemptedQuizz> SchoolStudentAttemptedQuizzs { get; set; }
    }
}
