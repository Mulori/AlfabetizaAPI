using AlfabetizaAPI.Context;
using AlfabetizaAPI.Models.Entities;
using AlfabetizaAPI.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace AlfabetizaAPI.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public readonly AlfabetizaContext _context;

        public UserRepository(AlfabetizaContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<User> Get()
        {
            return _context.User.Include(x => x.community).ToList();
        }

        public User GetById(int _id)
        {
            return _context.User.Include(_x => _x.community).Where(x => x.id == _id).FirstOrDefault();
        }
    }
}
