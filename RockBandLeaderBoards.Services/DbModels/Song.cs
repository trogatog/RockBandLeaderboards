using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockBandLeaderBoards.Services.DbModels
{
    [Table("Song")]
    public class Song
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongId { get; set; }
        [Required]
        public int HmxSongId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ShortName { get; set; }
        [Required]
        [MaxLength(50)]
        public string Artist { get; set; } 
        [Required]
        [MaxLength(50)]
        public string ArtistTr { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [MaxLength(100)]
        public string NameTr { get; set; }
        [Required]
        [MaxLength(50)]
        public string Genre { get; set; }
        [Required]
        [MaxLength(15)]
        public string Source { get; set; }
        [Required]
        public byte Rating { get; set; }
        [Required]
        public byte VocalParts { get; set; }
        [Required]
        public int YearReleased { get; set; }
        [Required]
        [MaxLength(6)]
        public string Decade { get; set; }
        [Required]
        public char StartsWith { get; set; }
        [Required]
        [MaxLength(50)]
        public string Cover { get; set; }
        [Required]
        [MaxLength(100)]
        public string SongDisplyName { get; set; }
        [Required]
        public DateTime LastUpdatedDate { get; set; }

    }
}
