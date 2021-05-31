using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class CourseQuizzsMaster
    {
        public CourseQuizzsMaster()
        {
            QuizQuestionsMasters = new HashSet<QuizQuestionsMaster>();
            StudentAttemptedQuizzs = new HashSet<StudentAttemptedQuizz>();
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
        public bool? AllowedReview { get; set; }

        public virtual Course Course { get; set; }
        public virtual ICollection<QuizQuestionsMaster> QuizQuestionsMasters { get; set; }
        public virtual ICollection<StudentAttemptedQuizz> StudentAttemptedQuizzs { get; set; }
    }
}
