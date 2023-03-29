using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usos_de_JWT.Constants;

namespace Usos_de_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountrysController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var listCountry = CountrysList.Countrys;
            return Ok(listCountry);
        }
    }
}
