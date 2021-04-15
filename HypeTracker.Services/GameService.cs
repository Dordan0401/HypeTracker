using HypeTracker.Data;
using HypeTracker.Data.Classes;
using HypeTracker.Models.GameModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Services
{
    public class GameService
    {
        public bool CreateGame(GameCreate model)
        {
            Game newGame = new Game()
            {
                Title = model.Title,
                Description = model.Description,
                PosterUrl = model.PosterUrl,
                ReleaseDate = model.ReleaseDate,
                Genre = model.Genre,
                DevStudio = model.DevStudio,
                AnticipationValue = model.AnticipationValue,
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(newGame);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetAllGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx
                             .Games
                             .Select(g => new GameListItem
                             {
                                 Id = g.Id,
                                 Title = g.Title,
                                 Description = g.Description,
                                 PosterUrl = g.PosterUrl,
                                 DevStudio = g.DevStudio,
                                 ReleaseDate = g.ReleaseDate
                             });

                return games.ToArray();
            }
        }

        public IEnumerable<GameListItem> GetGamesByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var games = ctx
                             .Games
                             .Where(g => g.Title.Contains($"{title}"))
                             .Select(g => new GameListItem
                             {
                                 Id = g.Id,
                                 Title = g.Title,
                                 Description = g.Description,
                                 PosterUrl = g.PosterUrl,
                                 DevStudio = g.DevStudio,
                                 ReleaseDate = g.ReleaseDate
                             });

                return games.ToArray();
            }
        }

        public GameDetail GetGameById(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx
                            .Games
                            .Single(g => g.Id == id);

                var gameDetail = new GameDetail()
                {
                    Id = game.Id,
                    PosterUrl = game.PosterUrl,
                    Title = game.Title,
                    Description = game.Description,
                    DevStudio = game.DevStudio,
                    Genre = game.Genre,
                    ReleaseDate = game.ReleaseDate,
                    DaysToRelease = game.DaysToRelease,
                    AnticipationValue = game.AnticipationValue
                };

                return gameDetail;
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx
                            .Games
                            .Single(g => g.Id == model.Id);

                game.PosterUrl = model.PosterUrl;
                game.Title = model.Title;
                game.Description = model.Description;
                game.ReleaseDate = model.ReleaseDate;
                game.DevStudio = model.DevStudio;
                game.Genre = model.Genre;
                game.AnticipationValue = model.AnticipationValue;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteGame(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var game = ctx
                             .Games
                             .Single(g => g.Id == Id);

                ctx.Games.Remove(game);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
