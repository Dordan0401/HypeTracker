using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Models.GameModels
{
    public class GameListItem
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset ReleaseDate { get; set; }
        public string DevStudio { get; set; }
    }
}
