using ArtGallery.Data.Repositories;
using ArtGallery.Data.Repositories.Contracts;
using ArtGallery.Services.Cloudinary;
using ArtGallery.Services.Cloudinary.Contracts;
using ArtGallery.Services.Mapping;
using IConfigurationProvider = Microsoft.Extensions.Configuration.IConfigurationProvider;

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
            services.AddScoped<IArtStoreService, ArtStoreService>();
            services.AddScoped<IEventOrderService, EventOrderService>();
            services.AddScoped<ICloudinaryService, CloudinaryService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationDbContext>(options =>
                    options.UseSqlServer(connectionString));
            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }
    }
}
