using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class Banner
    {
        public int Id { get; set; }
        public string BannerTitle { get; set; }
        public string BannerDesc { get; set; }
        public bool? IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string ImagePath { get; set; }
    }
}
