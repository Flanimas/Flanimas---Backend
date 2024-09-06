using Flanimas___Backend.Models;
using Flanimas___Backend.Queries;

namespace Flanimas___Backend.Services
{
    public interface IAnimeService
    {
        public AnimeProgress GetAnimeProgressFromQuery(AddAnimeQuery animeQuery);
    }
}
