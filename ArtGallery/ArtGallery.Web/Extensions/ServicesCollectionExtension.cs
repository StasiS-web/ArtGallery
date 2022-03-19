using ArtGallery.Data.Repositories;
using ArtGallery.Data.Repositories.Contracts;
using ArtGallery.Services.Data.Administrator;
using ArtGallery.Services.Data.Administrator.Contracts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Data Repositories
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();
            services.AddScoped<IAppRepository, AppRepository>();

            // Application services
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IBlogPostService, BlogPostService>();
            services.AddScoped<IShoppingCartService, ShoppingCartService>();
            services.AddScoped<IArtOrderService, ArtOrderService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<ICommentsService, CommentsService>();

            // Application Admin services
            services.AddScoped<IAdminEventService, AdminEventService>();
            services.AddScoped<IAdminArtStoreService, AdminArtStoreService>();
            services.AddScoped<IAdminBlogPostService, AdminBlogPostService>();
            return services;
        }
    }
}
