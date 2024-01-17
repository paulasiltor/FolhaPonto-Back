using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FolhaPonto.Api.Controllers
{
    /// <summary>
    /// API de Tasks
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly ITasksService _tasksService;

        public TasksController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        /// <summary>
        /// Retorna todos os Tasks existentes na base
        /// </summary>
        /// <returns>Objeto response com a lista de Tasks</returns>
        [Authorize]
        [HttpGet("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Tasks>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetAll()
        {
            return Ok(await _tasksService.BuscarAll());
        }

        /// <summary>
        /// Retorna somente um
        /// </summary>
        /// <returns>Objeto com retorn de um Tasks</returns>
        [Authorize]
        [HttpGet("{{tasksId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tasks))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> GetById([FromRoute] Guid tasksId)
        {
            return Ok(await _tasksService.BuscarId(tasksId));
        }

        /// <summary>
        /// Inserir um Tasks
        /// </summary>
        /// <returns>Objeto retorna o Tasks que foi inserido</returns>
        [Authorize]
        [HttpPost("")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Nullable))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Post([FromBody] TasksRequest request)
        {
            _tasksService.Post(request);
            return Ok();
        }

        /// <summary>
        /// Atualiza um Tasks
        /// </summary>
        /// <returns>Objeto com retorn de um Tasks</returns>
        [Authorize]
        [HttpPut("{{tasksId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tasks))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Put([FromRoute] Guid tasksId, [FromBody] TasksRequest request)
        {
            return Ok(await _tasksService.Put(tasksId, request));
        }

        /// <summary>
        /// Atualiza um Tasks
        /// </summary>
        /// <returns>Objeto com retorn de um Tasks</returns>
        [Authorize]
        [HttpDelete("{{tasksId}}")]
        [Produces("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Tasks))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ProblemDetails))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult> Delete([FromRoute] Guid tasksId)
        {
            return Ok(await _tasksService.Delete(tasksId));
        }
    }
}
