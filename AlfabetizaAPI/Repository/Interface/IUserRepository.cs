using AlfabetizaAPI.Models.Entities;

namespace AlfabetizaAPI.Repository.Interface
{
    public interface IUserRepository : IBaseRepository
    {
        Task<IEnumerable<User>> GetAsync();
        Task<User> GetByIdAsync(int id);
    }
}
