using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Data.Classes
{
    public enum Genre { Action_Adventure, Romance, Horror_Thriller, Comedy, Fantasy, Sci_Fi, Musical, Documentary, History, Superhero }
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime ReleaseDate { get; set; }
        [Required]
        public Genre Genre { get; set; }
        [Required]
        public string Franchise { get; set; }
        public int DaysToRelease
        {
            get
            {
                TimeSpan daysTill = ReleaseDate - DateTime.Now;
                return (int)daysTill.TotalDays;
            }
        }
        [Required]
        public int? AnticipationValue { get; set; }
    }
}
