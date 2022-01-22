using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlfabetizaAPI.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [Required, DataType(DataType.Text)]
        public string name { get; set; } = string.Empty;
        [Required, DataType(DataType.EmailAddress)]
        public string email { get; set; } = string.Empty;
        [Required, DataType(DataType.Text)]
        public string password { get; set; } = string.Empty;
        [Required]
        public int type_account { get; set; }
        public List<Community> community { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
