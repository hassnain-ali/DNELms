using DNELms.Dapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DNELms.Areas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = AuthSchemes.AngularAppScheme)]
    public class RawSqlController : BaseController
    {
        readonly ISQLFactory factory;
        public RawSqlController(ISQLFactory _factory)
        {
            factory = _factory;
        }
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Values query)
        {
            try
            {
                IDataReader reader = await factory.ExecuteDataReader(query.Query);
                return RawSqlResult(query.Query, reader);
            }
            catch (Exception ex)
            {
                return Ok(new { RecordsAffected = -2, Error = ex.InnerException?.Message ?? ex.Message });
            }
        }
        public class Values
        {
            public string Query { get; set; }
        }
    }
}
