namespace DNELms.Keys
{
    public static class SpKeys
    {

        public record CategoryKeys
        {
            public const string InsertCategory = "insertCourseCategory";
            public const string UpdateCategory = "updateCourseCategory";
            public const string DeleteCategory = "deleteCourseCategory";
            public const string SelectCategory = "CourseCategoryFetch";
        }

        public record CourseLevelKeys
        {
            public const string InsertCourseLevels = "InsertCourseLevels";
            public const string UpdateCourseLevels = "UpdateCourseLevels";
            public const string DeleteCourseLevels = "DeleteCourseLevels";
            public const string SelectCourseLevels = "SelectCourseLevels";
        }

        public record CourseTypeKeys
        {
            public const string InsertCourseTypes = "InsertCourseTypes";
            public const string UpdateCourseTypes = "UpdateCourseTypes";
            public const string DeleteCourseTypes = "DeleteCourseTypes";
            public const string SelectCourseTypes = "SelectCourseTypes";
        }

        public record LanguageKeys
        {
            public const string InsertLanguages = "InsertLanguages";
            public const string UpdateLanguages = "UpdateLanguages";
            public const string DeleteLanguages = "DeleteLanguages";
            public const string SelectLanguages = "SelectLanguages";
        }

        public record CourseKeys
        {
            public const string InsertCourses = "InsertCourses";
            public const string UpdateCourses = "UpdateCourses";
            public const string DeleteCourses = "DeleteCourses";
            public const string SelectCourses = "SelectCourses";
        }

        public record CountryKeys
        {
            public const string InsertCountries = "InsertCountries";
            public const string UpdateCountries = "UpdateCountries";
            public const string DeleteCountries = "DeleteCountries";
            public const string SelectCountries = "SelectCountries";
        }

        public record StateKeys
        {
            public const string InsertStates = "InsertStates";
            public const string UpdateStates = "UpdateStates";
            public const string DeleteStates = "DeleteStates";
            public const string SelectStates = "SelectStates";
        }

        public record CityKeys
        {
            public const string InsertCities = "InsertCities";
            public const string UpdateCities = "UpdateCities";
            public const string DeleteCities = "DeleteCities";
            public const string SelectCities = "SelectCities";
        }

    }
    public record Paging
    {
        public int DisplayLength { get; set; }
        public int DisplayStart { get; set; }
        public int SortCol { get; set; }
        public string SortOrder { get; set; }
        public string Search { get; set; }
    }
}
