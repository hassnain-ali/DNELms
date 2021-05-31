using DNELms.Model.NoSchoolModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.CourseExtRepo
{
    public interface ICourseLevelService
    {
        Task<bool> Delete(long id);
        Task<List<CourseLevel>> Fetch();
        Task<CourseLevel> GetById(long id);
        Task<CourseLevel> Save(CourseLevel model);
    }
}