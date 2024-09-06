using Flanimas___Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flanimas___Backend.Controllers
{
    [Route("api/anime")]
    [ApiController]
    [Authorize]
    public class AnimeController : ControllerBase
    {
        private readonly FlanimasContext _context;

        public AnimeController(FlanimasContext context)
        {
            _context = context;
        }

        // GET: api/Anime
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeProgress>>> GetAnimeProgress()
        {
            return await _context.AnimeProgress.ToListAsync();
        }

        // GET: api/Anime/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeProgress>> GetAnimeProgress(Guid id)
        {
            var animeProgress = await _context.AnimeProgress.FindAsync(id);

            if (animeProgress == null)
            {
                return NotFound();
            }

            return animeProgress;
        }

        // PUT: api/Anime/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnimeProgress(Guid id, AnimeProgress animeProgress)
        {
            if (id != animeProgress.Id)
            {
                return BadRequest();
            }

            _context.Entry(animeProgress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnimeProgressExists(id))
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

        // POST: api/Anime
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnimeProgress>> PostAnimeProgress(AnimeProgress animeProgress)
        {
            _context.AnimeProgress.Add(animeProgress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnimeProgress", new { id = animeProgress.Id }, animeProgress);
        }

        // DELETE: api/Anime/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeProgress(Guid id)
        {
            var animeProgress = await _context.AnimeProgress.FindAsync(id);
            if (animeProgress == null)
            {
                return NotFound();
            }

            _context.AnimeProgress.Remove(animeProgress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeProgressExists(Guid id)
        {
            return _context.AnimeProgress.Any(e => e.Id == id);
        }
    }
}
