using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class CourseOrdersDetail
    {
        public long Id { get; set; }
        public int? CourseOrderId { get; set; }
        public long? CourseId { get; set; }

        public virtual Course Course { get; set; }
        public virtual CourseOrdersMaster CourseOrder { get; set; }
    }
}
