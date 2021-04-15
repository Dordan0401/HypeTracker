using HypeTracker.Data;
using HypeTracker.Data.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Models.GameModels
{
    public class GameCreate
    {
        public string PosterUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTimeOffset ReleaseDate { get; set; }
        [Required]
        public GameGenre Genre { get; set; }
        [Required]
        public string DevStudio { get; set; }
        [Required]
        public int? AnticipationValue { get; set; }
    }
}
