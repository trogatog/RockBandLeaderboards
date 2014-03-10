using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockBandLeaderBoards.Services.DbModels
{
    [Table("SongInstrumentDifficulty")]
    public class SongInstrumentDifficulty
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SongInstrumentDifficultyId { get; set; }
        public List<Song> Songs { get; set; } 
        public List<Instrument> Instruments { get; set; }
        public byte StarRank { get; set; }
    }
}
