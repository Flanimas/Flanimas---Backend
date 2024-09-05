namespace Flanimas___Backend.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class AnimeProgress
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the anime identifier.
        /// </summary>
        /// <value>
        /// The anime identifier.
        /// </value>
        public int AnimeId { get; set; }

        /// <summary>
        /// Gets or sets the personal rating.
        /// </summary>
        /// <value>
        /// The personal rating.
        /// </value>
        public int PersonalRating { get; set; }

        /// <summary>
        /// Gets or sets the current episode.
        /// </summary>
        /// <value>
        /// The current episode.
        /// </value>
        public int CurrentEpisode { get; set; }
    }
}
