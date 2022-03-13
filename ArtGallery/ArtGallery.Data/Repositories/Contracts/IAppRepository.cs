namespace ArtGallery.Data.Repositories.Contracts
{
    public interface IAppRepository : IDisposable
    {
        IQueryable<T> All<T>()
            where T : class;

        Task<T> GetByIdAsync<T>(object id) 
            where T : class;

        Task AddAsync<T>(T entity)
            where T : class;

        void Update<T>(T entity)
            where T : class;

        Task DeleteAsync<T>(object id)
            where T : class;

        void Delete<T>(T entity)
            where T : class;

        IQueryable<T> AllWithDeleted<T>()
          where T : class;

        void HardDelete<T>(T entity)
             where T : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();
    }
}
