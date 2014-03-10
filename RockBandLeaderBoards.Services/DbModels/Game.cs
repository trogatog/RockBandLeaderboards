using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockBandLeaderBoards.Services.DbModels
{
    [Table("Game")]
    public class Game
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int GameId { get; set; }
        [MaxLength(50)]
        public string GameName { get; set; }
        [MaxLength(5)]
        public string ShortName { get; set; }
    }
}
