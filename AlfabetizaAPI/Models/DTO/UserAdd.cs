namespace AlfabetizaAPI.Models.DTO
{
    public class UserAdd
    {
        public string name { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int type_account { get; set; }
        public DateTime birth_date { get; set; }
    }
}
