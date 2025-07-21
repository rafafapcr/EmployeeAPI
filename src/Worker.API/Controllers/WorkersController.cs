using MediatR;
using Microsoft.AspNetCore.Mvc;
using Worker.Application.Workers.Commands.CreateWorker;
using Worker.Application.Workers.Commands.UpdateWorker;
using Worker.Application.Workers.Commands.DeleteWorker;
using Worker.Application.Workers.Queries.GetWorkerById;
using Worker.Application.Workers.Queries.GetAllWorkers;
using Worker.Domain.Entities;
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

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(bool), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<bool>> UpdateWorker(Guid id, [FromBody] UpdateWorkerCommand command)
        {
            if (id != command.Id)
                return BadRequest();

            var result = await _dispatcher.Send(command);
            if (!result)
                return NotFound();

            return Ok(result);
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(bool), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<bool>> DeleteWorker(Guid id)
        {
            var result = await _dispatcher.Send(new DeleteWorkerCommand(id));
            if (!result)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Employee), Status200OK)]
        [ProducesResponseType(Status404NotFound)]
        public async Task<ActionResult<Employee>> GetWorkerById(Guid id)
        {
            var worker = await _dispatcher.Send(new GetWorkerByIdQuery(id));
            if (worker == null)
                return NotFound();

            return Ok(worker);
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Employee>), Status200OK)]
        public async Task<ActionResult<List<Employee>>> GetAllWorkers()
        {
            var workers = await _dispatcher.Send(new GetAllWorkersQuery());
            return Ok(workers);
        }
    }
}
