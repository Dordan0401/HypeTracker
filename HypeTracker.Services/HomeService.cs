using HypeTracker.Data;
using HypeTracker.Data.Classes;
using HypeTracker.Models.GameModels;
using HypeTracker.Models.MovieModels;
using HypeTracker.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Services
{
    public class HomeService
    {
        public MovieListItem GetTopMovie()
        {
            using(var ctx = new ApplicationDbContext())
            {
                var movies = ctx.Movies;
                if(movies.Count() == 0)
                {
                    return null;
                }
                var orderedMovies = movies.OrderByDescending(m => m.AnticipationValue);

                Movie movie = orderedMovies.First();

                MovieListItem movieItem = new MovieListItem()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Franchise = movie.Franchise,
                    ReleaseDate = movie.ReleaseDate
                };

                return movieItem;
            }
        }

        public ShowListItem GetTopShow()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var shows = ctx.Shows;
                if (shows.Count() == 0)
                {
                    return null;
                }
                var orderedShows = shows.OrderByDescending(m => m.AnticipationValue);

                Show show = orderedShows.First();

                ShowListItem showItem = new ShowListItem()
                {
                    Id = show.Id,
                    Title = show.Title,
                    Description = show.Description,
                    Franchise = show.Franchise,
                    NextReleaseDate = show.NextReleaseDate
                };

                return showItem;
            }
        }

        public GameListItem GetTopGame()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx.Games;
                if (games.Count() == 0)
                {
                    return null;
                }
                var orderedGames = games.OrderByDescending(m => m.AnticipationValue);

                Game game = orderedGames.First();

                GameListItem gameItem = new GameListItem()
                {
                    Id = game.Id,
                    Title = game.Title,
                    Description = game.Description,
                    DevStudio = game.DevStudio,
                    ReleaseDate = game.ReleaseDate
                };

                return gameItem;
            }
        }
    }
}
