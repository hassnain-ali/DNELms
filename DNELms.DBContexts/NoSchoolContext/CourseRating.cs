using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class CourseRating : BaseEntity
    {
        //public long Id { get; set; }
        public long? CourseId { get; set; }
        public string UserId { get; set; }
        public int? Rating { get; set; }

        public virtual Course Course { get; set; }
        public virtual AspNetUser User { get; set; }
    }
}
