using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class QuizQuestionsMaster : BaseEntity
    {
        public QuizQuestionsMaster()
        {
            QuizQuestionDetails = new HashSet<QuizQuestionDetail>();
            StudentAttemptedQuizzs = new HashSet<StudentAttemptedQuizz>();
        }

        //public long Id { get; set; }
        public long? QuizId { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }
        public string QuestionType { get; set; }

        public virtual CourseQuizzsMaster Quiz { get; set; }
        public virtual ICollection<QuizQuestionDetail> QuizQuestionDetails { get; set; }
        public virtual ICollection<StudentAttemptedQuizz> StudentAttemptedQuizzs { get; set; }
    }
}
