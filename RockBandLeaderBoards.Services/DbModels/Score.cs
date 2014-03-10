using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockBandLeaderBoards.Services.DbModels
{
    [Table("Score")]
    public class Score
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScoreId { get; set; }
        public Game Game { get; set; }
        public Song Song { get; set; }
        public Instrument Instrument { get; set; }
        [Required]
        public int SongScore { get; set; }
        [Required]
        public byte StarScore { get; set; }
        [Required]
        public byte Percentage { get; set; }
        public Player Player { get; set; }
        public Difficulty Difficulty { get; set; }
        [Required]
        public bool ObsoleteScore { get; set; }
        [Required]
        public DateTime ScoreAddedDate { get; set; }
        public int Ranking { get; set; }
    }
}
