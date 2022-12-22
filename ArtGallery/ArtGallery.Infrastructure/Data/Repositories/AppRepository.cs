namespace ArtGallery.Infrastructure.Data.Repositories
{
    using ArtGallery.Infrastructure.Data.Common;
    using Microsoft.EntityFrameworkCore;
    public class AppRepository : Repository, IAppRepository
    {
        public AppRepository(ApplicationDbContext context) 
            : base(context)
        {
        }
    }
}
