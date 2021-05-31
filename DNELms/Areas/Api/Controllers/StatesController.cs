using DNELms.BAL.WorldRepo;
using DNELms.Model.NoSchoolModels;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize(AuthenticationSchemes = AuthSchemes.AngularAppScheme)]
    public class StatesController : BaseController
    {
        readonly IStatesService service;
        public StatesController(IStatesService _service)
        {
            service = _service;
        }
        [HttpGet]
        public async Task<IEnumerable<States>> Get()
        {
            return await service.Fetch();
        }

        [HttpGet("{id}")]
        public async Task<States> Get(int id)
        {
            return await service.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] States countries)
        {
            service.Save(countries);
        }

        // PUT api/<CountriesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] States countries)
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
