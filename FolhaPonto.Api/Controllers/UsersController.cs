using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace FolhaPonto.Api.Controllers
{
    /// <summary>
    /// API de Usuarios
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IUsersServices _usersServices;
        private readonly IConfiguration _config;
        
        public UsersController(IUsersServices usersServices, IConfiguration configuration)
        {
            _usersServices = usersServices;
            _config = configuration;
        }

        /// <summary>
        /// Autorizar
        /// </summary>
        /// <returns>Objeto response com o bearer de autorização</returns>
        [HttpPost("autorizar")]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Autorizar([FromBody] UsersRequest request)
        {
            bool resultado = await ValidarUsuario(request);
            if (resultado)
            {
                var tokenString = GerarTokenJwt();
                return Ok(tokenString);
            }
            else
                return Unauthorized();
            
        }

        /// <summary>
        /// Retorna todos os usuarios existentes na base
        /// </summary>
        /// <returns>Objeto response com a lista de usuarios</returns>
        [Authorize]
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Users>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _usersServices.BuscarAll());
        }


        /// <summary>
        /// Retorna somente um
        /// </summary>
        /// <returns>Objeto com retorn de um usuario</returns>
        [Authorize]
        [HttpGet("{{usersId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Users))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetById([FromRoute] Guid usersId)
        {
            return Ok(await _usersServices.BuscarId(usersId));
        }

        /// <summary>
        /// Inserir um usuario
        /// </summary>
        /// <returns>Objeto retorna o usuario que foi inserido</returns>
        [HttpPost("")]
        [AllowAnonymous]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(bool))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Post([FromBody] UsersRequest request)
        {
            var result = await _usersServices.Post(request);
            return Ok(result);
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <returns>Objeto com retorn de um usuario</returns>
        [Authorize]
        [HttpPut("{{usersId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Users))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Put([FromRoute] Guid usersId, [FromBody] UsersRequest request)
        {
            return Ok(await _usersServices.Put(usersId, request));
        }

        /// <summary>
        /// Atualiza um usuario
        /// </summary>
        /// <returns>Objeto com retorn de um usuario</returns>
        [Authorize]
        [HttpDelete("{{usersId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Users))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Delete([FromRoute] Guid usersId)
        {
            return Ok(await _usersServices.Delete(usersId));
        }

        private async Task<bool> ValidarUsuario(UsersRequest loginDetails)
        {
            if (await _usersServices.Autorizar(loginDetails))
                return true;
            
            else
                return false;
            
        }
        private string GerarTokenJwt()
        {
            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var expiry = DateTime.Now.AddMinutes(60);
            var securityKey = new SymmetricSecurityKey
                              (Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials
                              (securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer: issuer,
                                             audience: audience,
                                             expires: DateTime.Now.AddMinutes(120),
                                             signingCredentials: credentials);
            var tokenHandler = new JwtSecurityTokenHandler();
            var stringToken = tokenHandler.WriteToken(token);
            return stringToken;
        }
    }
}
