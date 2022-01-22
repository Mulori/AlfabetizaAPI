using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlfabetizaAPI.Models.Entities
{
    public class UserCommunity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required, ForeignKey("community")]
        public int community_id { get; set; }

        [Required, ForeignKey("user")]
        public int user_id { get; set; }

        public User user { get; set; }
        public Community community { get; set; }
    }
}
