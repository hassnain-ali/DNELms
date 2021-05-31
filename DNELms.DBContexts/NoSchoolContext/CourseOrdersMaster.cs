using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class CourseOrdersMaster : BaseEntity
    {
        public CourseOrdersMaster()
        {
            CourseOrderPaymentDetails = new HashSet<CourseOrderPaymentDetail>();
            CourseOrdersDetails = new HashSet<CourseOrdersDetail>();
        }

        //public int Id { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }

        public virtual AspNetUser User { get; set; }
        public virtual ICollection<CourseOrderPaymentDetail> CourseOrderPaymentDetails { get; set; }
        public virtual ICollection<CourseOrdersDetail> CourseOrdersDetails { get; set; }
    }
}
