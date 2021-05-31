using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.DBContexts.SchoolContext
{
    public partial class AspNetUser
    {
        public AspNetUser()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            AspNetUserClaims = new HashSet<AspNetUserClaim>();
            AspNetUserLogins = new HashSet<AspNetUserLogin>();
            AspNetUserRoles = new HashSet<AspNetUserRole>();
            AspNetUserTokens = new HashSet<AspNetUserToken>();
            SchoolCourseInstructors = new HashSet<SchoolCourseInstructor>();
            SchoolCourseOrderPaymentDetails = new HashSet<SchoolCourseOrderPaymentDetail>();
            SchoolCourseOrdersMasters = new HashSet<SchoolCourseOrdersMaster>();
            SchoolCourseRatings = new HashSet<SchoolCourseRating>();
            SchoolCourses = new HashSet<SchoolCourse>();
            SchoolOwners = new HashSet<SchoolOwner>();
            SchoolStudentAttemptedQuizzs = new HashSet<SchoolStudentAttemptedQuizz>();
            SchoolStudentEnrolledCourses = new HashSet<SchoolStudentEnrolledCourse>();
            SchoolStudentSubmitedAssignments = new HashSet<SchoolStudentSubmitedAssignment>();
            SchoolUserCarts = new HashSet<SchoolUserCart>();
            SchoolUserWishlists = new HashSet<SchoolUserWishlist>();
        }

        public string Id { get; set; }
        public string UserName { get; set; }
        public string NormalizedUserName { get; set; }
        public string Email { get; set; }
        public string NormalizedEmail { get; set; }
        public bool EmailConfirmed { get; set; }
        public string PasswordHash { get; set; }
        public string SecurityStamp { get; set; }
        public string ConcurrencyStamp { get; set; }
        public string PhoneNumber { get; set; }
        public bool PhoneNumberConfirmed { get; set; }
        public bool TwoFactorEnabled { get; set; }
        public DateTimeOffset? LockoutEnd { get; set; }
        public bool LockoutEnabled { get; set; }
        public int AccessFailedCount { get; set; }
        public int? CityId { get; set; }
        public int? StateId { get; set; }
        public int? PostCode { get; set; }
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FlatPassword { get; set; }
        public bool? IsActive { get; set; }
        public int? CountryId { get; set; }

        public virtual City City { get; set; }
        public virtual Country Country { get; set; }
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual ICollection<SchoolCourseInstructor> SchoolCourseInstructors { get; set; }
        public virtual ICollection<SchoolCourseOrderPaymentDetail> SchoolCourseOrderPaymentDetails { get; set; }
        public virtual ICollection<SchoolCourseOrdersMaster> SchoolCourseOrdersMasters { get; set; }
        public virtual ICollection<SchoolCourseRating> SchoolCourseRatings { get; set; }
        public virtual ICollection<SchoolCourse> SchoolCourses { get; set; }
        public virtual ICollection<SchoolOwner> SchoolOwners { get; set; }
        public virtual ICollection<SchoolStudentAttemptedQuizz> SchoolStudentAttemptedQuizzs { get; set; }
        public virtual ICollection<SchoolStudentEnrolledCourse> SchoolStudentEnrolledCourses { get; set; }
        public virtual ICollection<SchoolStudentSubmitedAssignment> SchoolStudentSubmitedAssignments { get; set; }
        public virtual ICollection<SchoolUserCart> SchoolUserCarts { get; set; }
        public virtual ICollection<SchoolUserWishlist> SchoolUserWishlists { get; set; }
    }
}
