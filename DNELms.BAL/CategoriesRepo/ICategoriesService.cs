using DNELms.Model.NoSchoolModels;
using DNELms.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fyp.BAL.CategoriesRepo
{
    public interface ICategoriesService
    {
        Task<bool> Delete(long id);
        Task<IEnumerable<CourseCategoryVM>> Fetch(PagingVM paging);
        Task<CourseCategory> GetById(long id);
        Task<CourseCategory> Save(CourseCategory model, IFormFile smallImage, IFormFile largeImage);
        Task<List<SelectListItem>> GetSelectListAsync(long? selected);
    }
}