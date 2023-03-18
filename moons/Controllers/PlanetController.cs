using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DefaultNamespace;

namespace moons.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetController : ControllerBase
    {
        private readonly Context _context;

        public PlanetController(Context context)
        {
            _context = context;
        }

        // GET: api/Planet
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetPlanets()
        {
            var planets = await _context.Planet.Include(p => p.Moons).ToListAsync();

            return planets;
        }

        // GET: api/Planet/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Planet>> GetPlanet(int id)
        {
            var planet = await _context.Planet.Include(p => p.Moons).FirstOrDefaultAsync(p => p.PlanetId == id);

            if (planet == null)
            {
                return NotFound();
            }

            return planet;
        }

        // PUT: api/Planet/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanet(int id, Planet planet)
        {
            if (id != planet.PlanetId)
            {
                return BadRequest();
            }

            _context.Entry(planet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetExists(id))
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

        // POST: api/Planet
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Planet>> PostPlanet(Planet planet)
        {
            if (_context.Planet == null)
            {
                return Problem("Entity set 'Context.Planet'  is null.");
            }

            _context.Planet.Add(planet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlanet", new { id = planet.PlanetId }, planet);
        }

        // DELETE: api/Planet/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanet(int id)
        {
            if (_context.Planet == null)
            {
                return NotFound();
            }

            var planet = await _context.Planet.FindAsync(id);
            if (planet == null)
            {
                return NotFound();
            }

            _context.Planet.Remove(planet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanetExists(int id)
        {
            return (_context.Planet?.Any(e => e.PlanetId == id)).GetValueOrDefault();
        }
    }
}