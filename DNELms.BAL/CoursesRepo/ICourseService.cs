using DNELms.Model.NoSchoolModels;
using DNELms.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DNELms.BAL.CoursesRepo
{
    public interface ICourseService
    {
        Task<bool> Delete(long id);
        Task<IEnumerable<CoursesVM>> Fetch(PagingVM paging);
        Task<CoursesVM> GetById(long id);
        Task<CoursesVM> SaveSteps(CoursesVM model, IFormFile smallImage, IFormFile largeImage);
    }
}