namespace AlfabetizaAPI.Repository.Interface
{
    public interface IBaseRepository
    {
        public void Add<T>(T Entity) where T : class;
        public void Update<T>(T Entity) where T : class;
        public void Delete<T>(T Entity) where T : class;
        Task<bool> SaveChangesAsync();
    }
}
