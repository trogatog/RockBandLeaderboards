using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockBandLeaderBoards.Services.DbModels
{
    [Table("Platform")]
    public class Platform
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PlatformId { get; set; }
        [MaxLength(50)]
        public string ConsoleName { get; set; }
        [MaxLength(5)]
        public string ShortName { get; set; }
    }
}
