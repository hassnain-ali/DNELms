using DNELms.Keys;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class CourseAssignments : BaseEntity
    {
        //public long Id { get; set; }
        public long? CourseId { get; set; }
        public DateTime? AssignmentStartDate { get; set; }
        public DateTime? AssignmentEndDate { get; set; }
        public string FilePath { get; set; }
        public int? AssignmentMarks { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool? AllowModify { get; set; }
    }
}
