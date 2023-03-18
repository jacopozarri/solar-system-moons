using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DefaultNamespace;

namespace moons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoonController : ControllerBase
    {
        private readonly Context _context;

        public MoonController(Context context)
        {
            _context = context;
        }

        // GET: api/Moon
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Moon>>> GetMoon()
        {
            if (_context.Moon == null)
            {
                return NotFound();
            }

            return await _context.Moon.ToListAsync();
        }

        // GET: api/Moon/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Moon>> GetMoon(int id)
        {
            if (_context.Moon == null)
            {
                return NotFound();
            }

            var moon = await _context.Moon.FindAsync(id);

            if (moon == null)
            {
                return NotFound();
            }

            return moon;
        }

        // PUT: api/Moon/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoon(int id, Moon moon)
        {
            if (id != moon.MoonId)
            {
                return BadRequest();
            }

            _context.Entry(moon).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MoonExists(id))
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

        // POST: api/Moon
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Moon>> PostMoon(Moon moon)
        {
            if (_context.Moon == null)
            {
                return Problem("Entity set 'Context.Moon'  is null.");
            }

            _context.Moon.Add(moon);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMoon", new { id = moon.MoonId }, moon);
        }

        // DELETE: api/Moon/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoon(int id)
        {
            if (_context.Moon == null)
            {
                return NotFound();
            }

            var moon = await _context.Moon.FindAsync(id);
            if (moon == null)
            {
                return NotFound();
            }

            _context.Moon.Remove(moon);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MoonExists(int id)
        {
            return (_context.Moon?.Any(e => e.MoonId == id)).GetValueOrDefault();
        }
    }
}