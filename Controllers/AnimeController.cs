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
    [Route("api/anime")]
    [ApiController]
    [Authorize]
    public class AnimeController(FlanimasContext context, IAnimeService animeService) : ControllerBase
    {

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnimeProgress>>> GetAnimeOfUser()
        {
            User? user = await GetUser();
            return user!.Library.Animes.ToList();
        }

        // GET: api/Anime/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnimeProgress>> GetAnimeProgress(Guid id)
        {
            var animeProgress = await context.AnimeProgress.FindAsync(id);

            if (animeProgress == null)
            {
                return NotFound();
            }

            if (!await IsAnimeOfUser(animeProgress))
            {
                return Unauthorized();
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

            if (!await IsAnimeOfUser(animeProgress))
            {
                return Unauthorized();
            }

            context.Entry(animeProgress).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
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
        public async Task<ActionResult<AnimeProgress>> PostAnimeProgress(AddAnimeQuery animeQuery)
        {
            AnimeProgress animeProgress = animeService.GetAnimeProgressFromQuery(animeQuery);
            User? user = await GetUser();
            user!.Library.Animes.Add(animeProgress);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetAnimeProgress", new { id = animeProgress.Id }, animeProgress);
        }

        // DELETE: api/Anime/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimeProgress(Guid id)
        {
            var animeProgress = await context.AnimeProgress.FindAsync(id);
            if (animeProgress == null)
            {
                return NotFound();
            }

            if (!await IsAnimeOfUser(animeProgress))
            {
                return Unauthorized();
            }

            context.AnimeProgress.Remove(animeProgress);
            await context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnimeProgressExists(Guid id)
        {
            return context.AnimeProgress.Any(e => e.Id == id);
        }

        private async Task<bool> IsAnimeOfUser(AnimeProgress anime)
        {
            var library = await context.Library.Where(library => library.Animes.Contains(anime)).FirstOrDefaultAsync();
            var user = await context.Users.Where(user => user.Library.Id == library!.Id).FirstOrDefaultAsync();
            return user?.UserName != User.FindFirstValue("Username");
        }

        private async Task<User?> GetUser()
        {
            String? userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return await context.Users.Include(u => u.Library).ThenInclude(l => l.Animes).Where(u => u.Id == userId).FirstOrDefaultAsync();
        }
    }
}
