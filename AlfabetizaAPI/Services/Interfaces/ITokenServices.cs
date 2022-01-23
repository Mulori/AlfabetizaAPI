using AlfabetizaAPI.Models.Entities;

namespace AlfabetizaAPI.Services.Interfaces
{
    public interface ITokenServices
    {
        string GenerateToken(User user);
    }
}
