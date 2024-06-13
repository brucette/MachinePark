using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MachinePark.Data.Domain;
using MachinePark.Core.Models;

namespace MachinePark.API.Controllers
{
    [Route("api/machines")]
    [ApiController]
    public class MachinesController : ControllerBase
    {
        private readonly MachineParkContext _context;

        public MachinesController(MachineParkContext context)
        {
            _context = context;
        }

        // GET: api/Machines
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MachineWithLatestData>>> GetMachines()
        {
            var machines = await _context.Machines.Select(m => 
            new MachineWithLatestData
            {
                MachineId = m.MachineId,
                Name = m.Name,
                IsOnline = m.IsOnline,
                Location = m.Location,
                LatestData = _context.ReceivedData
                .Where(rd => rd.MachineId == m.MachineId)
                .OrderByDescending(rd => rd.Time)
                .FirstOrDefault()
            }).ToListAsync();

            return Ok(machines);
        }
        
        // GET: api/Machines/stats
        [HttpGet("stats")]
        public async Task<ActionResult<DashBoardModel>> GetStats()
        {
            var totalCount = await _context.Machines.CountAsync();
            var machinesOnline = await _context.Machines.CountAsync(m => m.IsOnline);
            //var lastEditedMachine = await _context.Machines.OrderByDescending(m => m.LastDataReceived).FirstOrDefaultAsync();

            var stats = new DashBoardModel
            {
                TotalCount = totalCount,
                MachinesOnline = machinesOnline,
                //LastEditedMachineId = lastEditedMachine?.Id ?? Guid.Empty,
                //LastEditedMachineTimestamp = lastEditedMachine?.LastDataReceived ?? DateTime.MinValue
            };

            return Ok(stats);
        }

        // GET: api/Machines/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Machine>> GetMachine(Guid id)
        {
            var machine = await _context.Machines.FindAsync(id);

            if (machine == null)
            {
                return NotFound();
            }

            return machine;
        }

        // PUT: api/Machines/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMachine(Guid id, Machine machine)
        {
            if (id != machine.MachineId)
            {
                return BadRequest();
            }

            _context.Entry(machine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MachineExists(id))
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

        // POST: api/Machines
        [HttpPost]
        public async Task<ActionResult<Machine>> PostMachine(Machine machine)
        {
            _context.Machines.Add(machine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMachine", new { id = machine.MachineId }, machine);
        }

        // DELETE: api/Machines/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMachine(Guid id)
        {
            var machine = await _context.Machines.FindAsync(id);
            if (machine == null)
            {
                return NotFound();
            }

            _context.Machines.Remove(machine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MachineExists(Guid id)
        {
            return _context.Machines.Any(e => e.MachineId == id);
        }
    }
}
