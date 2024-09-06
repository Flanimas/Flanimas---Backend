using Flanimas___Backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Flanimas___Backend.Controllers
{
    [Route("api/manga")]
    [ApiController]
    [Authorize]
    public class MangaController : ControllerBase
    {
        private readonly FlanimasContext _context;

        public MangaController(FlanimasContext context)
        {
            _context = context;
        }

        // GET: api/Manga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MangaProgress>>> GetMangaProgress()
        {
            return await _context.MangaProgress.ToListAsync();
        }

        // GET: api/Manga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MangaProgress>> GetMangaProgress(Guid id)
        {
            var mangaProgress = await _context.MangaProgress.FindAsync(id);

            if (mangaProgress == null)
            {
                return NotFound();
            }

            return mangaProgress;
        }

        // PUT: api/Manga/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMangaProgress(Guid id, MangaProgress mangaProgress)
        {
            if (id != mangaProgress.Id)
            {
                return BadRequest();
            }

            _context.Entry(mangaProgress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MangaProgressExists(id))
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

        // POST: api/Manga
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MangaProgress>> PostMangaProgress(MangaProgress mangaProgress)
        {
            _context.MangaProgress.Add(mangaProgress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMangaProgress", new { id = mangaProgress.Id }, mangaProgress);
        }

        // DELETE: api/Manga/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMangaProgress(Guid id)
        {
            var mangaProgress = await _context.MangaProgress.FindAsync(id);
            if (mangaProgress == null)
            {
                return NotFound();
            }

            _context.MangaProgress.Remove(mangaProgress);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MangaProgressExists(Guid id)
        {
            return _context.MangaProgress.Any(e => e.Id == id);
        }
    }
}
