using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockBandLeaderBoards.Services.DbModels
{
    [Table("Difficulty")]
    public class Difficulty
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DifficultyId { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        [MaxLength(1)]
        public string SmallDescription { get; set; }
    }
}
