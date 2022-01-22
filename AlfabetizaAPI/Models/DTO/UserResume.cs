using AlfabetizaAPI.Models.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlfabetizaAPI.Models.DTO
{
    public class UserResume
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public int type_account { get; set; }
    }
}
