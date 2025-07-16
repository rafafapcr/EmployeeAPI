using MediatR;
using Microsoft.AspNetCore.Mvc;
using Worker.Application.Workers.Commands.CreateWorker;
using static Microsoft.AspNetCore.Http.StatusCodes;

namespace Worker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkersController : ControllerBase
    {
        private readonly IMediator _dispatcher;

        public WorkersController(IMediator dispatcher)
        {
            _dispatcher = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), Status201Created)]
        [ProducesResponseType(Status400BadRequest)]
        public async Task<ActionResult<Guid>> PostContact([FromBody] CreateWorkerCommand command)
        {
            var response = await _dispatcher.Send(command);
            return CreatedAtAction(nameof(PostContact), response);
        }
    }
}
