using ArtGallery.Data.Repositories;
using ArtGallery.Data.Repositories.Contracts;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Data Repositories
            services.AddTransient<IDbQueryRunner, DbQueryRunner>();
            services.AddTransient<IAppRepository, AppRepository>();

            // Application services
            services.AddTransient<IAccountService, AccountService>();
            services.AddTransient<IValidationService, ValidationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ISettingsService, SettingsService>();
            services.AddTransient<IShoppingCartService, ShoppingCartService>();
            services.AddTransient<IBlogPostsService, BlogPostService>();
            services.AddTransient<IArtOrderService, ArtOrderService>();
            return services;
        }
    }
}
