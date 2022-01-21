namespace AlfabetizaAPI.Models.Entities
{
    public class User
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string email { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public int type_account { get; set; } = 0;
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
