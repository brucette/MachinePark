using MachinePark.Core.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MachinePark.API.Controllers
{
    [Route("api/receiveddata")]
    [ApiController]
    public class ReceivedDataController : ControllerBase
    {
        private readonly MachineParkContext _context;

        public ReceivedDataController(MachineParkContext context)
        {
            _context = context;
        }

        // GET: api/ReceivedData
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceivedData>>> GetReceivedData()
        { 
            var allReceivedData = await _context.ReceivedData.ToListAsync();

            return Ok(allReceivedData);
        }

        // GET: api/ReceivedData/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceivedData>> GetReceivedDataByID(int id)
        {
            var receivedData = await _context.ReceivedData.FindAsync(id);

            if (receivedData == null)
            {
                return NotFound();
            }

            return receivedData;
        }

        // POST: api/ReceivedData
        [HttpPost]
        public async Task<ActionResult<ReceivedData>> PostReceivedData(ReceivedData receivedData)
        { 
            // check related machine exists
            var machine = await _context.Machines.FindAsync(receivedData.MachineId);

            if (machine == null)
            {
                return NotFound("Related machine not found");
            }

            _context.ReceivedData.Add(receivedData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceivedDataByID", new { id = receivedData.ReceivedDataId }, receivedData);
        }
    }
}
