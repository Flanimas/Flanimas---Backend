using Flanimas___Backend.Models;
using Flanimas___Backend.Models.Identity;
using Flanimas___Backend.Queries;
using Flanimas___Backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Flanimas___Backend.Controllers
{
    [Route("api/manga")]
    [ApiController]
    [Authorize]
    public class MangaController(FlanimasContext context, IMangaService mangaService) : ControllerBase
    {

        // GET: api/Manga
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MangaProgress>>> GetMangaProgress()
        {
            User? user = await GetUser();
            return user!.Library.Mangas.ToList();
        }

        // GET: api/Manga/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MangaProgress>> GetMangaProgress(Guid id)
        {
            var mangaProgress = await context.MangaProgress.FindAsync(id);

            if (mangaProgress == null)
            {
                return NotFound();
            }

            if (!await IsMangaOfUser(mangaProgress))
            {
                return Unauthorized();
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

            if (!await IsMangaOfUser(mangaProgress))
            {
                return Unauthorized();
            }

            context.Entry(mangaProgress).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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
        public async Task<ActionResult<MangaProgress>> PostMangaProgress(AddMangaQuery mangaQuery)
        {
            MangaProgress mangaProgress = mangaService.GetMangaProgressFromQuery(mangaQuery);
            User? user = await GetUser();
            user!.Library.Mangas.Add(mangaProgress);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetMangaProgress", new { id = mangaProgress.Id }, mangaProgress);
        }

        // DELETE: api/Manga/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMangaProgress(Guid id)
        {
            var mangaProgress = await context.MangaProgress.FindAsync(id);
            if (mangaProgress == null)
            {
                return NotFound();
            }

            if (!await IsMangaOfUser(mangaProgress))
            {
                return Unauthorized();
            }

            context.MangaProgress.Remove(mangaProgress);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool MangaProgressExists(Guid id)
        {
            return context.MangaProgress.Any(e => e.Id == id);
        }

        private async Task<bool> IsMangaOfUser(MangaProgress manga)
        {
            var library = await context.Library.Where(library => library.Mangas.Contains(manga)).FirstOrDefaultAsync();
            var user = await context.Users.Where(user => user.Library.Id == library!.Id).FirstOrDefaultAsync();
            return user?.UserName != User.FindFirstValue("Username");
        }

        private async Task<User?> GetUser()
        {
            String? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await context.Users.Include(u => u.Library).ThenInclude(l => l.Mangas).Where(u => u.Id == userId).FirstOrDefaultAsync();
        }
    }
}
