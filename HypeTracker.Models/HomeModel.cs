using HypeTracker.Models.GameModels;
using HypeTracker.Models.MovieModels;
using HypeTracker.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Models
{
    public class HomeModel
    {
        public MovieListItem topMovie { get; set; }
        public ShowListItem topShow { get; set; }
        public GameListItem topGame { get; set; }
    }
}
