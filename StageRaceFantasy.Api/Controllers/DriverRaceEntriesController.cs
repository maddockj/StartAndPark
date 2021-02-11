using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.RiderRaceEntries.Commands.Create;
using StageRaceFantasy.Application.RiderRaceEntries.Commands.Delete;
using StageRaceFantasy.Application.RiderRaceEntries.Commands.Update;
using StageRaceFantasy.Application.RiderRaceEntries.Queries.GetAll;
using StageRaceFantasy.Server.Controllers.Utils;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/races/{raceId}/entries")]
    [ApiController]
    public class DriverRaceEntriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DriverRaceEntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllDriverRaceEntriesVm>> GetDriverRaceEntries(int raceId)
        {
            var query = new GetAllDriverRaceEntriesQuery(raceId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPut("{driverId}")]
        public async Task<ActionResult> PutRiderRaceEntry(int raceId, int driverId, UpdateDriverRaceEntryCommand command)
        {
            if (command.RaceId != raceId || command.DriverId != driverId) return BadRequest();

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpPost]
        public async Task<ActionResult> PostDriverRaceEntry(int raceId, CreateDriverRaceEntryCommand command)
        {
            if (command.RaceId != raceId) return BadRequest();

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildStatusCodeResponse(this, result, 201);
        }

        [HttpDelete("{driverId}")]
        public async Task<ActionResult> DeleteRiderRaceEntry(int raceId, int driverId)
        {
            var command = new DeleteDriverRaceEntryCommand(raceId, driverId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
