using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class CourseOrdersMaster : BaseEntity
    {
        //public int Id { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }

    }
}
