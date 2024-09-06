using Flanimas___Backend.Models;
using Flanimas___Backend.Queries;

namespace Flanimas___Backend.Services
{
    public interface IMangaService
    {
        public MangaProgress GetMangaProgressFromQuery(AddMangaQuery mangaQuery);
    }
}
