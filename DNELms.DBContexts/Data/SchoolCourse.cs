using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.Data
{
    public partial class SchoolCourse
    {
        public SchoolCourse()
        {
            InverseParent = new HashSet<SchoolCourse>();
            SchoolCourseInstructors = new HashSet<SchoolCourseInstructor>();
            SchoolCourseLessonsMasters = new HashSet<SchoolCourseLessonsMaster>();
            SchoolCourseOrdersDetails = new HashSet<SchoolCourseOrdersDetail>();
            SchoolCourseQuizzsMasters = new HashSet<SchoolCourseQuizzsMaster>();
            SchoolCourseRatings = new HashSet<SchoolCourseRating>();
            SchoolStudentEnrolledCourses = new HashSet<SchoolStudentEnrolledCourse>();
            SchoolUserCarts = new HashSet<SchoolUserCart>();
            SchoolUserWishlists = new HashSet<SchoolUserWishlist>();
        }

        public long Id { get; set; }
        public long? CourseCategoryId { get; set; }
        public string Name { get; set; }
        public string SeUrl { get; set; }
        public long? CourseTypeId { get; set; }
        public int? CourseLevelId { get; set; }
        public bool ShowOnHome { get; set; }
        public bool ShowOnSitemap { get; set; }
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
        public bool IsActive { get; set; }
        public int? SortOrder { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string InstructorId { get; set; }
        public int? SchoolId { get; set; }

        public virtual SchoolCourseCategory CourseCategory { get; set; }
        public virtual SchoolCourseType CourseType { get; set; }
        public virtual AspNetUser Instructor { get; set; }
        public virtual SchoolLanguage Language { get; set; }
        public virtual SchoolCourse Parent { get; set; }
        public virtual School School { get; set; }
        public virtual ICollection<SchoolCourse> InverseParent { get; set; }
        public virtual ICollection<SchoolCourseInstructor> SchoolCourseInstructors { get; set; }
        public virtual ICollection<SchoolCourseLessonsMaster> SchoolCourseLessonsMasters { get; set; }
        public virtual ICollection<SchoolCourseOrdersDetail> SchoolCourseOrdersDetails { get; set; }
        public virtual ICollection<SchoolCourseQuizzsMaster> SchoolCourseQuizzsMasters { get; set; }
        public virtual ICollection<SchoolCourseRating> SchoolCourseRatings { get; set; }
        public virtual ICollection<SchoolStudentEnrolledCourse> SchoolStudentEnrolledCourses { get; set; }
        public virtual ICollection<SchoolUserCart> SchoolUserCarts { get; set; }
        public virtual ICollection<SchoolUserWishlist> SchoolUserWishlists { get; set; }
    }
}
