using DNELms.Model.NoSchoolModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.CoursesRepo
{
    public interface ICourseService
    {
        Task<bool> Delete(long id);
        Task<List<Courses>> Fetch();
        Task<Courses> GetById(long id);
        Task<Courses> Save(Courses model, IFormFile smallImage, IFormFile largeImage);
    }
}