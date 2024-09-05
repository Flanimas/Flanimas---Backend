namespace Flanimas___Backend.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Library
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the animes.
        /// </summary>
        /// <value>
        /// The animes.
        /// </value>
        public IList<AnimeProgress> Animes { get; set; } = [];

        /// <summary>
        /// Gets or sets the mangas.
        /// </summary>
        /// <value>
        /// The mangas.
        /// </value>
        public IList<MangaProgress> Mangas { get; set; } = [];
    }
}
