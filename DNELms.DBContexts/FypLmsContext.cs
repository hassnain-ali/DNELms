using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class DNELmsContext : DbContext
    {
        public DNELmsContext()
        {
        }

        public DNELmsContext(DbContextOptions<DNELmsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseCategory> CourseCategories { get; set; }
       
    }
}
