using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class CourseOrderPaymentDetail : BaseEntity
    {
        //public int Id { get; set; }
        public string PaymentType { get; set; }
        public string PayeeId { get; set; }
        public int? CourseOrderId { get; set; }
        public string FilePath { get; set; }
        public string UserId { get; set; }
        public string PaymentStatus { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public decimal? PaymentAmount { get; set; }
        public int? PaymentDiscountP { get; set; }
        public decimal? FinalAmount { get; set; }
    }
}
