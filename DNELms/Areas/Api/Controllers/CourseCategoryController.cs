using DNELms.Areas.Api.Models;
using DNELms.DBContexts.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DNELms.Areas.Api.Controllers
{
    [Area("api")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthSchemes.AngularAppScheme)]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CourseCategoryController : ControllerBase
    {
        readonly DNELmsContext context;
        public CourseCategoryController(DNELmsContext _context)
        {
            context = _context;
        }
        // GET: api/<CourseCategoryController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await context.CourseCategories.AsNoTracking().Include(s=>s.Courses).ToListAsync());
        }

        // GET api/<CourseCategoryController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(new ApiResponseResult(await context.CourseCategories.FindAsync(id)));
        }

        // POST api/<CourseCategoryController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CourseCategory course)
        {
            await context.CourseCategories.AddAsync(course);
            await context.SaveChangesAsync();
            return Ok(new ApiResponseResult(course));
        }

        // PUT api/<CourseCategoryController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] CourseCategory course)
        {
            if (id != course.Id)
            {
                var resp = new ApiResponseResult(course, StatusCodes.Status400BadRequest);
                return BadRequest(resp);
            }
            context.CourseCategories.Update(course);
            await context.SaveChangesAsync();
            return Ok(new ApiResponseResult(course));
        }

        // DELETE api/<CourseCategoryController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            context.CourseCategories.Remove(await context.CourseCategories.FindAsync(id));
            await context.SaveChangesAsync();
            return Ok(new ApiResponseResult("", "Deleted SuccessFully"));
        }
    }
}
