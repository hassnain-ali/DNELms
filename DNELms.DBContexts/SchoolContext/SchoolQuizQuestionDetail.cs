using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class SchoolQuizQuestionDetail
    {
        public long Id { get; set; }
        public long? QuestionId { get; set; }
        public string Qoption { get; set; }
        public bool IsCorrect { get; set; }
        public string Type { get; set; }

        public virtual SchoolQuizQuestionsMaster Question { get; set; }
    }
}
