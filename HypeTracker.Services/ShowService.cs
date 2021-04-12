using HypeTracker.Data;
using HypeTracker.Data.Classes;
using HypeTracker.Models.ShowModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Services
{
    public class ShowService
    {
        public bool CreateShow(ShowCreate model)
        {
            Show newShow = new Show()
            {
                Title = model.Title,
                Description = model.Description,
                PremierDate = model.PremierDate,
                NextReleaseDate = model.NextReleaseDate,
                Genre = model.Genre,
                Franchise = model.Franchise,
                AnticipationValue = model.AnticipationValue
            };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Shows.Add(newShow);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<ShowListItem> GetAllShows()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var shows = ctx
                             .Shows
                             .Select(s => new ShowListItem
                             {
                                 Id = s.Id,
                                 Title = s.Title,
                                 Description = s.Description,
                                 Franchise = s.Franchise,
                                 NextReleaseDate = s.NextReleaseDate
                             });

                return shows.ToArray();
            }
        }

        public IEnumerable<ShowListItem> GetShowsByTitle(string title)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var shows = ctx
                             .Shows
                             .Where(s => s.Title.Contains($"{title}"))
                             .Select(s => new ShowListItem
                             {
                                 Id = s.Id,
                                 Title = s.Title,
                                 Description = s.Description,
                                 Franchise = s.Franchise,
                                 NextReleaseDate = s.NextReleaseDate
                             });

                return shows.ToArray();
            }
        }

        public ShowDetail GetShowById(int? id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var show = ctx
                            .Shows
                            .Single(s => s.Id == id);

                var showDetail = new ShowDetail()
                {
                    Id = show.Id,
                    Title = show.Title,
                    Description = show.Description,
                    Franchise = show.Franchise,
                    Genre = show.Genre,
                    PremierDate = show.PremierDate,
                    DaysToNextRelease = show.DaysToNextRelease,
                    AnticipationValue = show.AnticipationValue
                };

                return showDetail;
            }
        }

        public bool UpdateShow(ShowEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var show = ctx
                            .Shows
                            .Single(s => s.Id == model.Id);

                show.Title = model.Title;
                show.Description = model.Description;
                show.NextReleaseDate = model.NextReleaseDate;
                show.Franchise = model.Franchise;
                show.AnticipationValue = model.AnticipationValue;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteShow(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var show = ctx
                             .Shows
                             .Single(s => s.Id == Id);

                ctx.Shows.Remove(show);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
