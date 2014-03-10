using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RockBandLeaderBoards.Services.DbModels
{
    [Table("Player")]
	public class Player
	{
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int PlayerId { get; set; }
        [MaxLength(50)]
        public string OnlineName { get; set; }
        public Platform Platform { get; set; }
	}
}
