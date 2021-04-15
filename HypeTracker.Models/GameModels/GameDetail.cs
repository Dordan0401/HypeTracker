using HypeTracker.Data;
using HypeTracker.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Models.GameModels
{
    public class GameDetail
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public int DaysToRelease { get; set; }
        public GameGenre Genre { get; set; }
        public string DevStudio { get; set; }
        public int? AnticipationValue { get; set; }
    }
}
