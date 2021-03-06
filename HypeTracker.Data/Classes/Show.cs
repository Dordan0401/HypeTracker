using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Data.Classes
{
    public class Show
    {
        [Key]
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTimeOffset PremierDate { get; set; }
        [Required]
        public DateTimeOffset NextReleaseDate { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public string Franchise { get; set; }
        public int DaysToNextRelease
        {
            get
            {
                TimeSpan daysTill = NextReleaseDate - DateTimeOffset.Now;
                return (int)daysTill.TotalDays;
            }
        }
        [Required]
        public int? AnticipationValue { get; set; }
    }
}
