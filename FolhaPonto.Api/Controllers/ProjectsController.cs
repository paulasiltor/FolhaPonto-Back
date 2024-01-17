using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FolhaPonto.Api.Controllers
{

    /// <summary>
    /// API de Projetcs
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : Controller
    {
        private readonly IProjectsService _projectsService;

        public ProjectsController(IProjectsService projectsService)
        {
            _projectsService = projectsService;
        }

        /// <summary>
        /// Retorna todos os Projects existentes na base
        /// </summary>
        /// <returns>Objeto response com a lista de Projects</returns>
        [Authorize]
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Projects>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _projectsService.BuscarAll());
        }

        /// <summary>
        /// Retorna somente um
        /// </summary>
        /// <returns>Objeto com retorn de um Projects</returns>
        [Authorize]
        [HttpGet("{{projectsId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projects))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetById([FromRoute] Guid projectsId)
        {
            return Ok(await _projectsService.BuscarId(projectsId));
        }

        /// <summary>
        /// Inserir um Projects
        /// </summary>
        /// <returns>Objeto retorna o Projects que foi inserido</returns>
        [Authorize]
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Nullable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Post([FromBody] ProjectsRequest request)
        {
            _projectsService.Post(request);
            return Ok();
        }

        /// <summary>
        /// Atualiza um Projects
        /// </summary>
        /// <returns>Objeto com retorn de um Projects</returns>
        [Authorize]
        [HttpPut("{{projectsId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projects))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Put([FromRoute] Guid projectsId, [FromBody] ProjectsRequest request)
        {
            return Ok(await _projectsService.Put(projectsId, request));
        }

        /// <summary>
        /// Atualiza um Projects
        /// </summary>
        /// <returns>Objeto com retorn de um Projects</returns>
        [Authorize]
        [HttpDelete("{{projectsId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Projects))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Delete([FromRoute] Guid projectsId)
        {
            return Ok(await _projectsService.Delete(projectsId));
        }
    }
}
