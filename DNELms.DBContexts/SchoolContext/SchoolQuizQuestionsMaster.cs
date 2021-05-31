using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class SchoolQuizQuestionsMaster
    {
        public SchoolQuizQuestionsMaster()
        {
            SchoolQuizQuestionDetails = new HashSet<SchoolQuizQuestionDetail>();
            SchoolStudentAttemptedQuizzs = new HashSet<SchoolStudentAttemptedQuizz>();
        }

        public long Id { get; set; }
        public long? QuizId { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }
        public string QuestionType { get; set; }

        public virtual SchoolCourseQuizzsMaster Quiz { get; set; }
        public virtual ICollection<SchoolQuizQuestionDetail> SchoolQuizQuestionDetails { get; set; }
        public virtual ICollection<SchoolStudentAttemptedQuizz> SchoolStudentAttemptedQuizzs { get; set; }
    }
}
