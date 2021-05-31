using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class CourseOrdersDetail : BaseEntity
    {
        //public long Id { get; set; }
        public int? CourseOrderId { get; set; }
        public long? CourseId { get; set; }

    }
}
