namespace Flanimas___Backend.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class MangaProgress
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the manga identifier.
        /// </summary>
        /// <value>
        /// The manga identifier.
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
        /// The current chapter.
        /// </value>
        public int CurrentChapter { get; set; }
    }
}
