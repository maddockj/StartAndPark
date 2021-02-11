using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StartAndPark.Application.DriverRaceEntries.Commands.Create;
using StartAndPark.Application.DriverRaceEntries.Commands.Delete;
using StartAndPark.Application.DriverRaceEntries.Commands.Update;
using StartAndPark.Application.DriverRaceEntries.Queries.GetAll;
using StartAndPark.Server.Controllers.Utils;

namespace StartAndPark.Server.Controllers
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
        public async Task<ActionResult> PutDriverRaceEntry(int raceId, int driverId, UpdateDriverRaceEntryCommand command)
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
        public async Task<ActionResult> DeleteDriverRaceEntry(int raceId, int driverId)
        {
            var command = new DeleteDriverRaceEntryCommand(raceId, driverId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
