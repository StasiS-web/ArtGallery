var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

// builder.Services.AddAuthentication()
//  .AddFacebook(options =>
//  {
//      options.AppId = builder.Configuration.GetValue<string>("Facebook:AppId");
//     options.AppSecret = builder.Configuration.GetValue<string>("Facebook:AppSecret");
//  }); 

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCulture = new CultureInfo[]
    {
        new CultureInfo("bg"),
        new CultureInfo("en"),
        new CultureInfo("es")
    };

    options.DefaultRequestCulture = new RequestCulture("bg");
    options.SupportedCultures = supportedCulture;
    options.SupportedUICultures = supportedCulture;
});

var config = new MapperConfiguration(cfg =>
{
    cfg.AddProfile(new AutoMapperConfig());
});
var mapper = config.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    { // Add Model Binding helps to work with model types
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
        options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider(Formating.NormalDateFormat));
        options.ModelBinderProviders.Insert(2, new DoubleModelBinderProvider());
    })
    .AddMvcLocalization(LanguageViewLocationExpanderFormat.Suffix);

builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = builder.Configuration.GetConnectionString("Redis");
});

// Data Repositories
builder.Services.AddScoped<IAppRepository, AppRepository>();
builder.Services.AddScoped<IDbQueryRunner, DbQueryRunner>();

// Application services
builder.Services.AddScoped<IEmailSender>(
    x => new SendGridEmailSender(builder.Configuration["SendGrid:SendGridApiKey"]));
builder.Services.AddTransient<IAboutService, AboutService>();
builder.Services.AddScoped<IBlogPostService, BlogPostService>();
builder.Services.AddScoped<ICloudinaryService, CloudinaryService>();
builder.Services.AddScoped<IContactsService, ContactsService>();
builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<ISettingsService, SettingsService>();
builder.Services.AddScoped<IUserService, UserService>();

// Cloudinary Setup
Account account = new Account(
                GlobalConstants.CloudName,
                builder.Configuration["Cloudinary: ApiKey"],
                builder.Configuration["Cloudinary: ApiSecret"]);
Cloudinary cloudinary = new Cloudinary(account);
builder.Services.AddSingleton(cloudinary);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();
app.UseRequestLocalization();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
  name: "Area",
  pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

    app.MapRazorPages();
});


app.Run();

