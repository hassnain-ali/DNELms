using DNELms.BAL.WorldRepo;
using DNELms.Model.NoSchoolModels;
using DNELms.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DNELms.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthSchemes.AngularAppScheme)]
    public class CitiesController : BaseController
    {
        readonly ICitiesService service;
        public CitiesController(ICitiesService _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return FetchOrOkApiResponse(MaterialTable(await service.Fetch(Request.FetchPaging())));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return FetchOrOkApiResponse(await service.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cities countries)
        {
            return CreatedApiResponse(await service.Save(countries));
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
           return DeletedApiResponse(await service.Delete(id));
        }
    }
}
