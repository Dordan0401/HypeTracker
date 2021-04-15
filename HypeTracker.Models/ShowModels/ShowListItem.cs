using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Models.ShowModels
{
    public class ShowListItem
    {
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTimeOffset PremierDate { get; set; }
        public DateTimeOffset NextReleaseDate
        {
            get
            {
                DateTimeOffset nextDate = PremierDate;

                if (DateTime.Today < PremierDate)
                {
                    return PremierDate;
                }

                while (DateTime.Today >= nextDate)
                {
                    nextDate = nextDate.AddDays(7);
                }

                return nextDate;
            }
        }
        public string Franchise { get; set; }
    }
}
