using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlfabetizaAPI.Models.Entities
{
    public class Community
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public int max_user { get; set; }

        [Required]
        public int is_private { get; set; }

        public string password { get; set; }

        [Required, ForeignKey("user")]
        public int user_id { get; set; }

        public User user { get; set; }

        public DateTime created_at { get; set; }

        public DateTime updated_at { get; set; }
    }
}
