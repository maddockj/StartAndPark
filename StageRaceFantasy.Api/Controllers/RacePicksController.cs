using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StartAndPark.Application;
using StartAndPark.Domain.Entities;
using StartAndPark.Server.Controllers.Utils;

namespace StartAndPark.Server.Controllers
{
    [Route("api/owners/{ownerId}/race-entries")]
    [ApiController]
    public class RacePicksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RacePicksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllRacePicksVm>> GetRacePicks(int ownerId)
        {
            var query = new GetAllRacePicksQuery(ownerId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{raceId}")]
        public async Task<ActionResult<GetRacePickByIdVm>> GetRacePick(int ownerId, int raceId)
        {
            var query = new GetRacePicksByIdQuery(ownerId, raceId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPost]
        public async Task<ActionResult> PostRacePick(int ownerId, CreateRacePickCommand command)
        {
            if (command.OwnerId != ownerId) return BadRequest();

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildStatusCodeResponse(this, result, 201);
        }

        [HttpDelete("{raceId}")]
        public async Task<IActionResult> DeleteRacePick(int ownerId, int raceId)
        {
            var command = new DeleteRacePickCommand(ownerId, raceId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpPost("{raceId}/drivers/{driverId}")]
        public async Task<IActionResult> AddDriver(int ownerId, int raceId, int driverId)
        {
            var command = new AddDriverToRacePickCommand(ownerId, raceId, driverId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpDelete("{raceId}/drivers/{driverId}")]
        public async Task<IActionResult> RemoveDriver(int ownerId, int raceId, int driverId)
        {
            var command = new RemoveDriverFromRacePickCommand(ownerId, raceId, driverId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
