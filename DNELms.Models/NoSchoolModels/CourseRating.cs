using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class CourseRatings : BaseEntity
    {
        //public long Id { get; set; }
        public long? CourseId { get; set; }
        public string UserId { get; set; }
        public int? Rating { get; set; }
    }
}
