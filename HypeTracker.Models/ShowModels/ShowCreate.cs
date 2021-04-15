using HypeTracker.Data;
using HypeTracker.Data.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Models.ShowModels
{
    public class ShowCreate
    {
        public string PosterUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
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
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public string Franchise { get; set; }
        [Required]
        public int? AnticipationValue { get; set; }
    }
}
