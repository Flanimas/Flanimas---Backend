﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
