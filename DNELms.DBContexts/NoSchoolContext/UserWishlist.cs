﻿using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class UserWishlist : BaseEntity
    {
        //public long Id { get; set; }
        public long? CourseId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool IsRemoved { get; set; }

        public virtual Course Course { get; set; }
        public virtual AspNetUser CreatedByNavigation { get; set; }
    }
}
