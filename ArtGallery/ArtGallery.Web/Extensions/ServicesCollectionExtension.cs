using ArtGallery.Data.Repositories;
using ArtGallery.Data.Repositories.Contracts;

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
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IValidationService, ValidationService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ISettingsService, SettingsService>();
            services.AddScoped<IBlogPostsService, BlogPostService>();
            services.AddScoped<IArtOrderService, ArtOrderService>();
            return services;
        }
    }
}
