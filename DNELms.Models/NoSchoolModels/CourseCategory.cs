using DNELms.Keys;
using DNELms.Models;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class CourseCategory : BaseEntity
    {
        //public long Id { get; set; }
        public string Name { get; set; }
        public string SmallImage { get; set; }
        public string BannerImage { get; set; }
        public long? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
    public partial class CourseCategoryVM : DTModel
    {
        public long Id { get; set; }
        public long ParentPk { get; set; }
        public string Name { get; set; }
        public string ParentName { get; set; }
        public string SmallImage { get; set; }
        public string BannerImage { get; set; }
        public long? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

    }
}
