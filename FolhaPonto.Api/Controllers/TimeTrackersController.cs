using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FolhaPonto.Api.Controllers
{
    /// <summary>
    /// API de Times
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TimeTrackersController : Controller
    {
        private readonly ITimeTrackersService _timeTrackersService;

        public TimeTrackersController(ITimeTrackersService timeTrackersService)
        {
            _timeTrackersService = timeTrackersService;
        }

        /// <summary>
        /// Retorna todos os TimeTrackers existentes na base
        /// </summary>
        /// <returns>Objeto response com a lista de TimeTrackers</returns>
        [Authorize]
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TimeTrackers>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _timeTrackersService.BuscarAll());
        }

        /// <summary>
        /// Retorna somente um
        /// </summary>
        /// <returns>Objeto com retorn de um TimeTrackers</returns>
        [Authorize]
        [HttpGet("{{timeTrackersId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTrackers))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetById([FromRoute] Guid timeTrackersId)
        {
            return Ok(await _timeTrackersService.BuscarId(timeTrackersId));
        }

        /// <summary>
        /// Inserir um TimeTrackers
        /// </summary>
        /// <returns>Objeto retorna o TimeTrackers que foi inserido</returns>
        [Authorize]
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Nullable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Post([FromBody] TimeTrackersRequest request)
        {
            var result = await _timeTrackersService.Post(request);
            return Ok(result);
        }

        /// <summary>
        /// Atualiza um TimeTrackers
        /// </summary>
        /// <returns>Objeto com retorn de um TimeTrackers</returns>
        [Authorize]
        [HttpPut("{{timeTrackersId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTrackers))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Put([FromRoute] Guid timeTrackersId, [FromBody] TimeTrackersRequest request)
        {
            return Ok(await _timeTrackersService.Put(timeTrackersId, request));
        }

        /// <summary>
        /// Atualiza um TimeTrackers
        /// </summary>
        /// <returns>Objeto com retorn de um TimeTrackers</returns>
        [Authorize]
        [HttpDelete("{{timeTrackersId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TimeTrackers))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Delete([FromRoute] Guid timeTrackersId)
        {
            return Ok(await _timeTrackersService.Delete(timeTrackersId));
        }
    }
}
