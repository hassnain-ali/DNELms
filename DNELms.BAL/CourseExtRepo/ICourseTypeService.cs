using DNELms.Model.NoSchoolModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.CourseExtRepo
{
    public interface ICourseTypeService
    {
        Task<bool> Delete(long id);
        Task<List<CourseTypes>> Fetch();
        Task<CourseTypes> GetById(long id);
        Task<CourseTypes> Save(CourseTypes model);
    }
}