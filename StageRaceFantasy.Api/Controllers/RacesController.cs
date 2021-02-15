using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StartAndPark.Application.Common.Interfaces;
using StartAndPark.Application;
using StartAndPark.Domain.Entities;
using StartAndPark.Server.Controllers.Utils;
using StartAndPark.Client;

namespace StartAndPark.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RacesController : ControllerBase
    {
        private readonly IApplicationDbContext _context;
        private readonly IMediator _mediator;

        public RacesController(IApplicationDbContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }

        // GET: api/Races
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RaceDto>>> GetRaces()
        {
            var result = await _mediator.Send(new GetAllRacesQuery());

            return result.Content.ItemList;

            //return await _context.Races
            //    .OrderBy(x => x.StartTime)
            //    .ThenBy(x => x.Id)
            //    .ToListAsync();
        }

        [HttpGet("{id}/entries2")]
        public async Task<ActionResult<IEnumerable<DriverRaceEntryDto>>> GetEntries(int id)
        {
            return await _context.RaceEntries
                .Include(x => x.Race)
                .Include(x => x.Driver)
                .Where(x => x.RaceId == id)
                .Select(x => new DriverRaceEntryDto
                {
                    Id = x.Id,
                    RaceId = x.RaceId,
                    NascarRaceId = x.Race.NascarId,
                    DriverId = x.DriverId,
                    NascarDriverId = x.Driver.NascarId,
                    Name = x.Driver.Name,
                    CarNumber = x.CarNumber,
                    Tier = x.Tier
                })
                .ToListAsync();
        }

        // GET: api/Races/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Race>> GetRace(int id)
        {
            var race = await _context.Races.FindAsync(id);

            if (race == null)
            {
                return NotFound();
            }

            return race;
        }

        // GET: api/Races/current
        [HttpGet("current")]
        public async Task<ActionResult<Race>> GetCurrentRace()
        {
            var race = await _context.Races
                .Where(x => x.Type == Constants.RACE_TYPE_POINTS)
                .Where(x => !x.WinningDriverId.HasValue)
                .OrderBy(x => x.StartTime)
                .FirstOrDefaultAsync();

            if (race == null)
            {
                return NotFound();
            }

            return race;
        }

        // GET: api/races/{id}/picks
        [HttpGet("{id}/picks")]
        public async Task<ActionResult<List<RacePick>>> GetRacePicks(int id)
        {
            return await _context.RacePicks
                .Include(x => x.RaceEntries)
                .ThenInclude(e => e.Driver)
                .Where(x => x.RaceId == id)
                .ToListAsync();
        }

        // PUT: api/Races/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRace(int id, Race race)
        {
            if (id != race.Id)
            {
                return BadRequest();
            }

            _context.Entry(race).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RaceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Races
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<int>> PostRace(CreateRaceCommand race)
        {
            var result = await _mediator.Send(race);

            return ResponseHelpers.BuildCreatedAtResponse(
                this,
                result,
                nameof(GetRace),
                () => new { id = result.Content });
        }

        // DELETE: api/Races/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRace(int id)
        {
            var race = await _context.Races.FindAsync(id);
            if (race == null)
            {
                return NotFound();
            }

            _context.Races.Remove(race);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RaceExists(int id)
        {
            return _context.Races.Any(e => e.Id == id);
        }
    }
}
