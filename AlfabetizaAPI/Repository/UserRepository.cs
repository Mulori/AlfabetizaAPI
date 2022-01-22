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

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.User.Include(x => x.community).ToListAsync();
        }

        public async Task<User> GetByIdAsync(int _id)
        {
            return await _context.User.Include(_x => _x.community).Where(x => x.id == _id).FirstOrDefaultAsync();
        }
    }
}
