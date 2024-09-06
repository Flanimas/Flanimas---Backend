using System.ComponentModel.DataAnnotations;

namespace Flanimas___Backend.Queries
{
    public class AddMangaQuery
    {

        /// <summary>
        /// Gets or sets the manga identifier.
        /// </summary>
        /// <value>
        /// The anime identifier.
        /// </value>
        public int MangaId { get; set; }

        /// <summary>
        /// Gets or sets the personal rating.
        /// </summary>
        /// <value>
        /// The personal rating.
        /// </value>
        public int PersonalRating { get; set; }

        /// <summary>
        /// Gets or sets the current chapter.
        /// </summary>
        /// <value>
        /// The current episode.
        /// </value>
        public int CurrentChapter { get; set; }
    }
}
