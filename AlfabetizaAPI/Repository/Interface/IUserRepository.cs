using AlfabetizaAPI.Models.Entities;

namespace AlfabetizaAPI.Repository.Interface
{
    public interface IUserRepository : IBaseRepository
    {
        IEnumerable<User> Get();
        User GetById(int id);
    }
}
