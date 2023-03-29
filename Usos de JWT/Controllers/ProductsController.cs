using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Usos_de_JWT.Constants;

namespace Usos_de_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        // ESTA RUTA SOLO DEBE SER ACCESIBLE A LAS PERSONAS QUE ESTEN AUTENTICADAS
        [HttpGet]
        [Authorize] // este authorize es a nivel de ruta
        public IActionResult Get()
        {
            var listProducts = ProductsList.Products;
            return Ok(listProducts);
        }
    }
}
