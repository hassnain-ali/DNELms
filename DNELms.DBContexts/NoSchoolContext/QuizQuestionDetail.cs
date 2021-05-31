using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class QuizQuestionDetail : BaseEntity
    {
        //public long Id { get; set; }
        public long? QuestionId { get; set; }
        public string Qoption { get; set; }
        public bool IsCorrect { get; set; }
        public string Type { get; set; }

        public virtual QuizQuestionsMaster Question { get; set; }
    }
}
