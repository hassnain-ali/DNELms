using System;
using System.Collections.Generic;

namespace DNELms.Model
{
    public record CategoryVM
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string SmallImage { get; set; }
        public string BannerImage { get; set; }
        public long? ParentId { get; set; }
        public bool? IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public IEnumerable<CategoryVM> SubCategories { get; set; }
    }
}
