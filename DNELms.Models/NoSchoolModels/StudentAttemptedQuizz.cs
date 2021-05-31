using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class StudentAttemptedQuizzs : BaseEntity
    {
        //public long Id { get; set; }
        public long? QuizId { get; set; }
        public string StudentId { get; set; }
        public long? QuestionId { get; set; }
        public string StudentAnswerType { get; set; }
        public bool IsCorrectAnswer { get; set; }
        public DateTime? QuizAttemptedDate { get; set; }
        public string Answer { get; set; }

    }
}
