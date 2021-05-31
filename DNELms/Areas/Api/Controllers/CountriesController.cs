using DNELms.BAL.WorldRepo;
using DNELms.Model.NoSchoolModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DNELms.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : BaseController
    {
        readonly ICountriesService service;
        public CountriesController(ICountriesService _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<IEnumerable<Countries>> Get()
        {
            return await service.Fetch();
        }

        [HttpGet("{id}")]
        public async Task<Countries> Get(int id)
        {
            return await service.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] Countries countries)
        {
            service.Save(countries);
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Countries countries)
        {
            service.Save(countries);
        }

        // DELETE api/<CountriesController>/5
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            service.Delete(id);
        }
    }
}
