using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class CourseOvercomes
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        [ForeignKey("CourseId")]
        public long? CourseId { get; set; }
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDT { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdatedDT { get; set; }
        [NotMapped]
        public Courses Course { get; set; }
    }
}
