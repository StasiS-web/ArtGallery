namespace ArtGallery.Web
{
    using ArtGallery.Common;
    using ArtGallery.Data;
    using ArtGallery.Data.Common;
    using ArtGallery.Data.Common.Repositories;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories;
    using CloudinaryDotNet;
    using Microsoft.EntityFrameworkCore;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // Method gets called by the runtime and use it to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ArtGalleryUser>(IdentityOptionsProvider.GetIndentityOptions)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.None;
                });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddSingleton(this.configuration);

            // Data repository
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Cloudinary Setup
            Account account = new Account(
                GlobalConstants.CloudName,
                this.configuration["Cloudinary:ApiKey"],
                this.configuration["Cloudinary:ApiSecret"]);
            Cloudinary cloudinary = new Cloudinary(account);
            services.AddSingleton(cloudinary);

            // Application services
        }

        // Method gets called by the runtime and use it to configure the HTTP request pipeline
        public void Configure()
        {

        }
    }
}
