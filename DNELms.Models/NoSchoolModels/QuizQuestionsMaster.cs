using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class QuizQuestionsMaster : BaseEntity
    {

        //public long Id { get; set; }
        public long? QuizId { get; set; }
        public string Question { get; set; }
        public bool IsActive { get; set; }
        public string QuestionType { get; set; }

    }
}
