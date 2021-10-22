using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DNELms.DBContexts.NoSchoolContext
{
    public partial class CourseRequirements
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("CourseId")]
        public long? CourseId { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDT { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdateDT { get; set; }
        [NotMapped]
        public Course Course { get; set; }
    }
}
