using DNELms.DBContexts.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DNELms.Areas.Api.Controllers
{
    [Area("api")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthSchemes.AngularAppScheme)]
    public class CoursesController : BaseController
    {
        readonly DNELmsContext context;
        public CoursesController(DNELmsContext _context)
        {
            context = _context;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var courses = context.Courses.Include(s => s.Parent);
            var coursesList = await courses.ToListAsync();
            return Ok(coursesList);
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await context.Courses.Include(s => s.Parent).FirstOrDefaultAsync(s => s.Id == id));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Course course)
        {
            await context.Courses.AddAsync(course);
            await context.SaveChangesAsync();
            return Ok(course);
        }

        // PUT api/<CoursesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(long id, [FromBody] Course course)
        {
            if (id != course.Id)
            {
                return BadRequest();
            }
            context.Courses.Update(course);
            await context.SaveChangesAsync();
            return Ok(course);
        }

        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            context.Courses.Remove(await context.Courses.FindAsync(id));
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
