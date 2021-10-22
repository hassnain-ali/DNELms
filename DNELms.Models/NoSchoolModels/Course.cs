using DNELms.Keys;
using DNELms.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

#nullable disable

namespace DNELms.Model.NoSchoolModels
{
    public partial class Courses : BaseEntity
    {
        //public long Id { get; set; }
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

    }

    public partial class CoursesVM : DTModel
    {
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
        [FromForm] public List<CourseOvercomes> Overcomes { get; set; }
        [FromForm] public List<CourseRequirements> Requirements { get; set; }
        public CoursesVM()
        {
            Overcomes = new();
            Requirements = new();
        }
    }
}
