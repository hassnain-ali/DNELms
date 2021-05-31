using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class Course
    {
        public Course()
        {
            CourseAssignments = new HashSet<CourseAssignment>();
            CourseInstructors = new HashSet<CourseInstructor>();
            CourseLessonsMasters = new HashSet<CourseLessonsMaster>();
            CourseOrdersDetails = new HashSet<CourseOrdersDetail>();
            CourseQuizzsMasters = new HashSet<CourseQuizzsMaster>();
            CourseRatings = new HashSet<CourseRating>();
            InverseParent = new HashSet<Course>();
            StudentEnrolledCourses = new HashSet<StudentEnrolledCourse>();
            UserCarts = new HashSet<UserCart>();
            UserWishlists = new HashSet<UserWishlist>();
        }

        public long Id { get; set; }
        public long? CourseCategoryId { get; set; }
        public string Name { get; set; }
        public string SeUrl { get; set; }
        public long? CourseTypeId { get; set; }
        public int? CourseLevelId { get; set; }
        public bool? ShowOnHome { get; set; }
        public bool? ShowOnSitemap { get; set; }
        public string CourseCode { get; set; }
        public decimal? Price { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal? DiscountPrice { get; set; }
        public bool IsParent { get; set; }
        public long? ParentId { get; set; }
        public int? LanguageId { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? UnPublishDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public TimeSpan? TotalHours { get; set; }
        public string Visibility { get; set; }
        public string SmallImagePath { get; set; }
        public string PromotionalVideo { get; set; }
        public string LargeImagePath { get; set; }
        public bool? IsActive { get; set; }
        public int? SortOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string InstructorId { get; set; }

        public virtual CourseCategory CourseCategory { get; set; }
        public virtual CourseLevel CourseLevel { get; set; }
        public virtual CourseType CourseType { get; set; }
        public virtual AspNetUser Instructor { get; set; }
        public virtual Language Language { get; set; }
        public virtual Course Parent { get; set; }
        public virtual ICollection<CourseAssignment> CourseAssignments { get; set; }
        public virtual ICollection<CourseInstructor> CourseInstructors { get; set; }
        public virtual ICollection<CourseLessonsMaster> CourseLessonsMasters { get; set; }
        public virtual ICollection<CourseOrdersDetail> CourseOrdersDetails { get; set; }
        public virtual ICollection<CourseQuizzsMaster> CourseQuizzsMasters { get; set; }
        public virtual ICollection<CourseRating> CourseRatings { get; set; }
        public virtual ICollection<Course> InverseParent { get; set; }
        public virtual ICollection<StudentEnrolledCourse> StudentEnrolledCourses { get; set; }
        public virtual ICollection<UserCart> UserCarts { get; set; }
        public virtual ICollection<UserWishlist> UserWishlists { get; set; }
    }
}
