using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;
using FolhaPonto.Domain.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FolhaPonto.Api.Controllers
{

    /// <summary>
    /// API de Collaborators
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CollaboratorsController : Controller
    {
        private readonly ICollaboratorsService _collaboratorsService;

        public CollaboratorsController(ICollaboratorsService collaboratorsService)
        {
            _collaboratorsService = collaboratorsService;
        }

        /// <summary>
        /// Retorna todos os colaboratores existentes na base
        /// </summary>
        /// <returns>Objeto response com a lista de colaboradores</returns>
        [Authorize]
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Collaborators>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _collaboratorsService.BuscarAll());
        }


        /// <summary>
        /// Retorna somente um
        /// </summary>
        /// <returns>Objeto com retorn de um colaboradores</returns>
        [Authorize]
        [HttpGet("{{collaboratorsId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Collaborators))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetById([FromRoute] Guid collaboratorsId)
        {
            return Ok(await _collaboratorsService.BuscarId(collaboratorsId));
        }

        /// <summary>
        /// Inserir um colaborador
        /// </summary>
        /// <returns>Objeto retorna o colaborador que foi inserido</returns>
        [Authorize]
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Nullable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Post([FromBody] CollaboratorsRequest request)
        {
            _collaboratorsService.Post(request);
            return Ok();
        }

        /// <summary>
        /// Atualiza um colaborador
        /// </summary>
        /// <returns>Objeto com retorn de um colaborador</returns>
        [Authorize]
        [HttpPut("{{collaboratorsId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Collaborators))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Put([FromRoute] Guid collaboratorsId, [FromBody] CollaboratorsRequest request)
        {
            return Ok(await _collaboratorsService.Put(collaboratorsId, request));
        }

        /// <summary>
        /// Atualiza um colaborador
        /// </summary>
        /// <returns>Objeto com retorn de um colaborador</returns>
        [Authorize]
        [HttpDelete("{{collaboratorsId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Collaborators))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Delete([FromRoute] Guid collaboratorsId)
        {
            return Ok(await _collaboratorsService.Delete(collaboratorsId));
        }
    }
}
