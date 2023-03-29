using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Usos_de_JWT.Constants;
using Usos_de_JWT.Models;



namespace Usos_de_JWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public LoginController(IConfiguration configuration)
        {
            _configuration= configuration;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var currentUser = GetCurrentUser();
            return Ok(currentUser);
        }

        [HttpPost]
        public IActionResult Login(LoginUser userLogin)
        {
            var user = Authenticate(userLogin);
            if(user != null)
            {
                // Creamos el token
                var token = Generate(user);
                return Ok("Usuario logeado");
            }
            return NotFound("Usuario no encontrado");
        }

        private User Authenticate(LoginUser userLogin)
        {
            var currentUser = UserList.Users.FirstOrDefault(user => user.Username == userLogin.Username && user.Password == userLogin.Password);
            if(currentUser != null)
            {
                return currentUser;
            }

            return null;
        }

        private string Generate(User user)
        {
            // "securityKey" nos permite acceder a la contraseña a travez de una clase que codifica la key del appsettings
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            // "credentials" indicamos que tipo de algoridmo queremos usar para las credenciales
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            // Crear los claims o reclamaciones
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Username),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.Role, user.Rol),
            };

            // crear el token
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],   // accedemos al usuario y la audiencia de donde se reclama la peticion
                _configuration["Jwt:Audience"],
                claims,  // pasamos las claims / reclamaciones
                expires: DateTime.Now.AddMinutes(60), // indicamos el tiempo de expiracion del token
                signingCredentials: credentials); // le pasamos las credenciales

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User GetCurrentUser()
        {
            // aqui buscamos obtener la "identidad" del usuario a travez del claim que corresponde a la identidad
            var identity = HttpContext.User.Identity as ClaimsIdentity;

            if (identity == null)
            {
                var userClaims = identity.Claims;
                return new User
                {
                    Username = userClaims.FirstOrDefault(e => e.Type == ClaimTypes.NameIdentifier)?.Value,
                    FirstName = userClaims.FirstOrDefault(e => e.Type == ClaimTypes.GivenName)?.Value,
                    LastName = userClaims.FirstOrDefault(e => e.Type == ClaimTypes.Surname)?.Value,
                    Email = userClaims.FirstOrDefault(e => e.Type == ClaimTypes.Email)?.Value,
                    Rol = userClaims.FirstOrDefault(e => e.Type == ClaimTypes.Role)?.Value,
                };
            }
            return null;  
        }


    }
}
