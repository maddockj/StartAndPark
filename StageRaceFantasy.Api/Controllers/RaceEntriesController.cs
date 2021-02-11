﻿using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.Commands.FanasyTeamRaceEntries;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Create;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.Delete;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Commands.RemoveRider;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetAll;
using StageRaceFantasy.Application.FantasyTeamRaceEntries.Queries.GetById;
using StageRaceFantasy.Domain.Entities;
using StageRaceFantasy.Server.Controllers.Utils;

namespace StageRaceFantasy.Server.Controllers
{
    [Route("api/fantasy-teams/{fantasyTeamId}/race-entries")]
    [ApiController]
    public class RaceEntriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RaceEntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllRaceEntriesVm>> GetRaceEntries(int ownerId)
        {
            var query = new GetAllRaceEntriesQuery(ownerId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpGet("{raceId}")]
        public async Task<ActionResult<GetRaceEntryByIdVm>> GetRaceEntry(int ownerId, int raceId)
        {
            var query = new GetRaceEntryByIdQuery(ownerId, raceId);
            var result = await _mediator.Send(query);

            return ResponseHelpers.BuildRawContentResponse(this, result);
        }

        [HttpPost]
        public async Task<ActionResult> PostFantasyTeamRaceEntry(int ownerId, CreateRaceEntryCommand command)
        {
            if (command.OwnerId != ownerId) return BadRequest();

            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildStatusCodeResponse(this, result, 201);
        }

        [HttpDelete("{raceId}")]
        public async Task<IActionResult> DeleteFantasyTeamRaceEntry(int ownerId, int raceId)
        {
            var command = new DeleteRaceEntryCommand(ownerId, raceId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpPost("{raceId}/riders/{driverId}")]
        public async Task<IActionResult> AddDriver(int ownerId, int raceId, int driverId)
        {
            var command = new AddDriverToRaceEntryCommand(ownerId, raceId, driverId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }

        [HttpDelete("{raceId}/riders/{driverId}")]
        public async Task<IActionResult> RemoveDriver(int ownerId, int raceId, int driverId)
        {
            var command = new RemoveDriverFromRaceEntryCommand(ownerId, raceId, driverId);
            var result = await _mediator.Send(command);

            return ResponseHelpers.BuildNoContentResponse(this, result);
        }
    }
}
