using Flanimas___Backend.Models;
using Flanimas___Backend.Queries;

namespace Flanimas___Backend.Services
{
    public class MangaService : IMangaService
    {
        public MangaProgress GetMangaProgressFromQuery(AddMangaQuery mangaQuery)
        {
            return new()
            {
                MangaId = mangaQuery.MangaId,
                CurrentChapter = mangaQuery.CurrentChapter,
                PersonalRating = mangaQuery.PersonalRating
            };
        }
    }
}
