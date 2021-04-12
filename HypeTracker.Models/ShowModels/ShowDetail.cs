using HypeTracker.Data;
using HypeTracker.Data.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Models.ShowModels
{
    public class ShowDetail
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PremierDate { get; set; }
        public DateTime NextReleaseDate
        {
            get
            {
                if (DateTime.Today < PremierDate)
                {
                    return PremierDate;
                }

                return PremierDate.AddDays(7);
            }
        }
        public Genre Genre { get; set; }
        public string Franchise { get; set; }
        public int DaysToNextRelease { get; set; }
        public int? AnticipationValue { get; set; }
    }
}
