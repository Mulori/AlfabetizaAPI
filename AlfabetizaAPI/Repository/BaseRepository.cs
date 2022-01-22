using AlfabetizaAPI.Context;
using AlfabetizaAPI.Repository.Interface;

namespace AlfabetizaAPI.Repository
{
    public class BaseRepository : IBaseRepository
    {
        public readonly AlfabetizaContext _context;

        public BaseRepository(AlfabetizaContext context)
        {
            _context = context;
        }

        public void Add<T>(T Entity) where T : class
        {
            _context.Add(Entity);
        }

        public void Delete<T>(T Entity) where T : class
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update<T>(T Entity) where T : class
        {
            _context.Update(Entity);
        }
    }
}
