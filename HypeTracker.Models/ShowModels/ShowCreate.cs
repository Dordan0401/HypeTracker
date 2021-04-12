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
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
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
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public string Franchise { get; set; }
        [Required]
        public int? AnticipationValue { get; set; }
    }
}
