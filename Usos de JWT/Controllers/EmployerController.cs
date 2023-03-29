using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usos_de_JWT.Constants;

namespace Usos_de_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployerController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles =("Administrador"))]  // AQUI INDICMAOS QUE SOLO ESTARA AUTORIZADA ESTA RUTA AL USUARIO QUE TENGA LE ROL DE "Administrador"
        public IActionResult Get()
        {
            var listEmployers = EmplyerList.Employers;
            return Ok(listEmployers);
        }
    }
}
