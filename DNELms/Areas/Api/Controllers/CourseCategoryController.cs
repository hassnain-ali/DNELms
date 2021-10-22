using DNELms.Model.NoSchoolModels;
using DNELms.ModelMappers;
using DNELms.Services;
using Fyp.BAL.CategoriesRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using DNELms.Core;

namespace DNELms.Areas.Api.Controllers
{
    [Area("api")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthSchemes.AngularAppScheme)]
    public class CourseCategoryController : BaseController
    {
        readonly ICategoriesService context;
        public CourseCategoryController(ICategoriesService repository)
        {
            context = repository;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await context.Fetch(Request.FetchPaging());
              
                return FetchOrOkApiResponse(MaterialTable(result));
            }
            catch (Exception ex)
            {
                return ExceptionApiResponse(ex);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(long id)
        {
            try
            {
                return FetchOrOkApiResponse(await context.GetById(id));
            }
            catch (Exception ex)
            {
                return ExceptionApiResponse(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromForm] CourseCategory courseCategory, [FromForm] IFormFile SmallImageFile = null, [FromForm] IFormFile BannerImageFile = null)
        {
            try
            {
                var userid = User.UserId();
                if (courseCategory.Id > 0)
                {
                    courseCategory.UpdatedBy = userid;
                    courseCategory.UpdatedDate = DateTime.UtcNow;
                }
                else
                {
                    courseCategory.CreatedBy = userid;
                    courseCategory.CreatedDate = DateTime.UtcNow;
                }
                return CreatedApiResponse(await context.Save(courseCategory, SmallImageFile, BannerImageFile));
            }
            catch (Exception ex)
            {
                return ExceptionApiResponse(ex);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(long id, [FromForm] CourseCategory courseCategory, [FromForm] IFormFile SmallImageFile = null, [FromForm] IFormFile BannerImageFile = null)
        {
            try
            {
                if (id != courseCategory.Id)
                {
                    return BadRequest();
                }
                var userid = User.UserId();
                courseCategory.UpdatedBy = userid;
                courseCategory.UpdatedDate = DateTime.UtcNow;
                await context.Save(courseCategory, SmallImageFile, BannerImageFile);
                return UpdatedApiResponse(courseCategory);
            }
            catch (Exception ex)
            {
                return ExceptionApiResponse(ex);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            try
            {
                context.Delete(id);
                return DeletedApiResponse("Deleted SuccessFully");
            }
            catch (Exception ex)
            {
                return ExceptionApiResponse(ex);
            }
        }
        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> GetDDL(long? id)
        {
            return FetchOrOkApiResponse(await context.GetSelectListAsync(id));
        }
    }
}
