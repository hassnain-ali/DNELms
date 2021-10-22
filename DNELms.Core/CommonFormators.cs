using DNELms.Model.NoSchoolModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DNELms.Core
{
    public static class CommonFormators
    {
        #region CategoryBreadcrumb (CategoryVM)

        /// <summary>
        /// Get formatted category breadcrumb 
        /// Note: ACL and store mapping is ignored
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="allCategories">All categories</param>
        /// <param name="separator">Separator</param>
        /// <param name="languageId">Language identifier for localization</param>
        /// <returns>Formatted breadcrumb</returns>
        public static string GetFormattedBreadCrumb(this CourseCategoryVM category, IEnumerable<CourseCategoryVM> allCategories = null,
            string separator = ">>")
        {
            var result = string.Empty;

            var breadcrumb = GetCategoryBreadCrumb(category, allCategories, true);
            for (var i = 0; i <= breadcrumb.Count - 1; i++)
            {
                var categoryName = breadcrumb[i].Name;
                result = string.IsNullOrEmpty(result) ? categoryName : $"{result} {separator} {categoryName}";
            }

            return result;
        }


        /// <summary>
        /// Get category breadcrumb 
        /// </summary>
        /// <param name="category">Category</param>
        /// <param name="allCategories">All categories</param>
        /// <param name="showHidden">A value indicating whether to load hidden records</param>
        /// <returns>Category breadcrumb </returns>
        public static IList<CourseCategoryVM> GetCategoryBreadCrumb(CourseCategoryVM category, IEnumerable<CourseCategoryVM> allCategories = null, bool showHidden = false)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            var result = new List<CourseCategoryVM>();

            //used to prevent circular references
            var alreadyProcessedCategoryIds = new List<long>();

            while (category != null && //not null
                   (showHidden || category.IsActive == true) && //published
                   !alreadyProcessedCategoryIds.Contains(category.Id)) //prevent circular references
            {
                result.Add(category);

                alreadyProcessedCategoryIds.Add(category.Id);

                category = allCategories.FirstOrDefault(c => c.Id == category.ParentId);
            }

            result.Reverse();

            return result;
        }
        #endregion

    }
}
