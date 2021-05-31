using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class UserWishlist : BaseEntity
    {
        //public long Id { get; set; }
        public long? CourseId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsRemoved { get; set; }

    }
}
