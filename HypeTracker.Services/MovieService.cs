using HypeTracker.Data;
using HypeTracker.Data.Classes;
using HypeTracker.Models.MovieModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Services
{
    public class MovieService
    {
        public bool CreateMovie(MovieCreate model)
        {
            Movie newMovie = new Movie()
            {
                Title = model.Title,
                Description = model.Description,
                ReleaseDate = model.ReleaseDate,
                Genre = model.Genre,
                Franchise = model.Franchise,
                AnticipationValue = model.AnticipationValue
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Movies.Add(newMovie);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MovieListItem> GetAllMovies()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var movies = ctx
                             .Movies
                             .Select(m => new MovieListItem
                             {
                                 Id = m.Id,
                                 Title = m.Title,
                                 Description = m.Description,
                                 Franchise = m.Franchise,
                                 ReleaseDate = m.ReleaseDate
                             });

                return movies.ToArray();
            }
        }

        //public List<string> GetGenres()
        //{
        //    using (var ctx = new ApplicationDbContext())
        //    {
        //        List<string> genres = new List<string>();
        //        for (int i = 0; i <= 9; i++)
        //        {
        //            Genre genre = (Genre)i;
        //            string genreString = genre.ToString();
        //            genres.Add(genreString);
        //        }

        //        return genres;
        //    }
        //}

        public IEnumerable<MovieListItem> GetMoviesByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var movies = ctx
                             .Movies
                             .Where(m => m.Title.Contains($"{title}"))
                             .Select(m => new MovieListItem
                             {
                                 Id = m.Id,
                                 Title = m.Title,
                                 Description = m.Description,
                                 Franchise = m.Franchise,
                                 ReleaseDate = m.ReleaseDate
                             });

                return movies.ToArray();
            }
        }

        public MovieDetail GetMovieById(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var movie = ctx
                            .Movies
                            .Single(m => m.Id == id);

                var movieDetail = new MovieDetail()
                {
                    Id = movie.Id,
                    Title = movie.Title,
                    Description = movie.Description,
                    Franchise = movie.Franchise,
                    Genre = movie.Genre,
                    ReleaseDate = movie.ReleaseDate,
                    DaysToRelease = movie.DaysToRelease,
                    AnticipationValue = movie.AnticipationValue
                };

                return movieDetail;
            }
        }

        public bool UpdateMovie(MovieEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var movie = ctx
                            .Movies
                            .Single(m => m.Id == model.Id);

                movie.Title = model.Title;
                movie.Description = model.Description;
                movie.ReleaseDate = model.ReleaseDate;
                movie.Franchise = model.Franchise;
                movie.AnticipationValue = model.AnticipationValue;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMovie(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var movie = ctx
                             .Movies
                             .Single(e => e.Id == Id);

                ctx.Movies.Remove(movie);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
