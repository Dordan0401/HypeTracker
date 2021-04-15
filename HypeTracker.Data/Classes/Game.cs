using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HypeTracker.Data.Classes
{ 
    public enum GameGenre { RPG, Simulation, Strategy, Stealth, Platform, FPS, Fighting, BattleRoyale, Survival, VisualNovel, Indie }
   
    public class Game
    {
        [Key]
        public int Id { get; set; }
        public string PosterUrl { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTimeOffset ReleaseDate { get; set; }
        public int DaysToRelease
        {
            get
            {
                TimeSpan daysTill = ReleaseDate - DateTime.Today;
                return (int)daysTill.TotalDays;
            }
        }
        [Required]
        public GameGenre Genre { get; set; }
        [Required]
        public string DevStudio { get; set; }
        [Required]
        public int? AnticipationValue { get; set; }
    }
}
