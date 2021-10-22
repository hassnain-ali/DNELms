using DNELms.BAL.CoursesRepo;
using DNELms.Model.NoSchoolModels;
using DNELms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        readonly ICourseService context;
        public CoursesController(ICourseService _context)
        {
            context = _context;
        }
        // GET: api/<CoursesController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return FetchOrOkApiResponse(await context.Fetch(Request.FetchPaging()));
        }

        // GET api/<CoursesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return FetchOrOkApiResponse(await context.GetById(id));
        }

        // POST api/<CoursesController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CoursesVM course)
        {
            IFormFile file = null;
            IFormFile file1 = null;
            return CreatedApiResponse(await context.SaveSteps(course, file, file1));
        }


        // DELETE api/<CoursesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await context.Delete(id);
            return Ok();
        }
    }
}
