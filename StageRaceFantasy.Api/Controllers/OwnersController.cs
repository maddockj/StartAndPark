using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StartAndPark.Application.Owners.Commands.Create;
using StartAndPark.Application.Owners.Queries.GetById;
using StartAndPark.Application.Owners.Queries.GetAll;
using StartAndPark.Domain.Entities;
using StartAndPark.Server.Controllers.Utils;
using StartAndPark.Application.Owners.Commands.Delete;
using StartAndPark.Application.Owners.Commands.Update;

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
        public async Task<ActionResult<GetAllOwnersVm>> GetOwners()
        {
            var query = new GetAllOwnersQuery();
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
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
