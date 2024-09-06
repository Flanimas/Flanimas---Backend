using Flanimas___Backend.Models;
using Flanimas___Backend.Queries;

namespace Flanimas___Backend.Services
{
    public class AnimeService : IAnimeService
    {
        public AnimeProgress GetAnimeProgressFromQuery(AddAnimeQuery animeQuery)
        {
            return new()
            {
                AnimeId = animeQuery.AnimeId,
                CurrentEpisode = animeQuery.CurrentEpisode,
                PersonalRating = animeQuery.PersonalRating
            };
        }
    }
}
