using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class SchoolCourseOrdersMaster
    {
        public SchoolCourseOrdersMaster()
        {
            SchoolCourseOrderPaymentDetails = new HashSet<SchoolCourseOrderPaymentDetail>();
            SchoolCourseOrdersDetails = new HashSet<SchoolCourseOrdersDetail>();
        }

        public int Id { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string Status { get; set; }

        public virtual AspNetUser User { get; set; }
        public virtual ICollection<SchoolCourseOrderPaymentDetail> SchoolCourseOrderPaymentDetails { get; set; }
        public virtual ICollection<SchoolCourseOrdersDetail> SchoolCourseOrdersDetails { get; set; }
    }
}
