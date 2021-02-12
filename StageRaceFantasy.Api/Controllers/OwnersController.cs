using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StartAndPark.Application;
using StartAndPark.Domain.Entities;
using StartAndPark.Server.Controllers.Utils;
using System.Collections.Generic;

namespace StartAndPark.Server.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OwnersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OwnerDto>>> GetOwners()
        {
            var query = new GetAllOwnersQuery();
            var result = await _mediator.Send(query);

            return result.Content.ItemList;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOwnerByIdVm>> GetOwner(int id)
        {
            var query = new GetOwnerByIdQuery(id);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutOwner(int id, UpdateOwnerCommand command)
        {
            if (command.Id != id) return BadRequest();

            var query = new UpdateOwnerCommand(id, command.Name);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpPost]
        public async Task<ActionResult<Owner>> PostOwner(CreateOwnerCommand command)
        {
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildCreatedAtResponse(
                this,
                result,
                nameof(GetOwner),
                () => new { id = result.Content.Id });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOwner(int id)
        {
            var command = new DeleteOwnerCommand(id);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
