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
            throw new NotImplementedException();
        }

        public void Delete<T>(T Entity) where T : class
        {
            throw new NotImplementedException();
        }

        public bool SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update<T>(T Entity) where T : class
        {
            throw new NotImplementedException();
        }
    }
}
