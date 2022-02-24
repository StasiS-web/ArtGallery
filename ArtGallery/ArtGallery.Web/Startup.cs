namespace ArtGallery.Web
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration _configuration)
        {
            configuration = _configuration;
        }

        // Method gets called by the runtime and use it to add services to the container
        public void ConfigureServices()
        {


            // Data repository

            // Cloudinary Setup

            //Application services
        }

        // Method gets called by the runtime and use it to configure the HTTP request pipeline
        public void Configure()
        {

        }
    }
}
