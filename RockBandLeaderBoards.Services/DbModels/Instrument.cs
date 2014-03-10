using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockBandLeaderBoards.Services.DbModels
{
    [Table("Instrument")]
    public class Instrument
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InstrumentId { get; set; }
        [MaxLength(15)]
        public string Description { get; set; }
    }
}
