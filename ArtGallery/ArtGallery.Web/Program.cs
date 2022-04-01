var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddDefaultTokenProviders();

builder.Services.AddIdentityCore<ApplicationUser>(opt =>
{
    opt.User.RequireUniqueEmail = true;
})
.AddRoles<IdentityRole>()
.AddClaimsPrincipalFactory<UserClaimsPrincipalFactory<ApplicationUser, IdentityRole>>()
.AddSignInManager<SignInManager<ApplicationUser>>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    { // Add Model Binding helps to work with model types
        options.ModelBinderProviders.Insert(0, new DecimalModelBinderProvider());
        options.ModelBinderProviders.Insert(1, new DateTimeModelBinderProvider(Formating.NormalDateFormat));
        options.ModelBinderProviders.Insert(2, new DoubleModelBinderProvider());
    });

builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<CookiePolicyOptions>(
        options =>
        {
             options.CheckConsentNeeded = context => true;
             options.MinimumSameSitePolicy = SameSiteMode.None;
        });

// Cloudinary Setup
Account account = new Account(
                builder.Configuration["Cloudinary: CloudName"],
                builder.Configuration["Cloudinary:ApiKey"],
                builder.Configuration["Cloudinary:ApiSecret"]);
Cloudinary cloudinary = new Cloudinary(account);

builder.Services.AddSingleton(cloudinary);
builder.Services.AddApplicationServices();

var app = builder.Build();

// Configure AutoMapper Registration
AutoMapperConfig.RegisterMappings(
    typeof(ArtStoreCreateInputModel).GetTypeInfo().Assembly,
    typeof(BlogPostCreateInputModel).GetTypeInfo().Assembly,
    typeof(BlogPostEditViewModel).GetTypeInfo().Assembly,
    typeof(EventCreateInputViewModel).GetTypeInfo().Assembly,
    typeof(EventEditViewModel).GetTypeInfo().Assembly,
    typeof(UserEditViewModel).GetTypeInfo().Assembly,
    typeof(PrivacyCreateInputModel).GetTypeInfo().Assembly,
    typeof(ArtStoreViewModel).GetTypeInfo().Assembly,
    typeof(ArtDetailsViewModel).GetTypeInfo().Assembly,
    typeof(BlogPostViewModel).GetTypeInfo().Assembly,
    typeof(BlogCommentViewModel).GetTypeInfo().Assembly,
    typeof(BlogCommentInputViewModel).GetTypeInfo().Assembly,
    typeof(EventViewModel).GetTypeInfo().Assembly,
    typeof(EventOrderViewModel).GetTypeInfo().Assembly,
    typeof(LatestBlogPostViewModel).GetTypeInfo().Assembly,
    typeof(UpcomingEventViewModel).GetTypeInfo().Assembly,
    typeof(PrivacyVewModel).GetTypeInfo().Assembly,
    typeof(ShoppingCartViewModel).GetTypeInfo().Assembly,
    typeof(SettingViewModel).GetTypeInfo().Assembly,
    typeof(UserViewModel).GetTypeInfo().Assembly);

// Seed data on application startup
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

    if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
    {
        dbContext.Database.Migrate();
    }

    new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseStatusCodePagesWithReExecute("/Error/{0}");
    app.UseExceptionHandler("/Home/{code:int}");

    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Use(async (context, next) =>
{
    await next();

    if (context.Response.StatusCode == 404)
    {
        context.Request.Path = "/Error/404";
        await next();
    }
    else if (context.Response.StatusCode == 500)
    {
        context.Request.Path = "/Error/500";
        await next();
    }
    else
    {
        context.Request.Path = "/Error/Error";
        await next();
    }
});

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseCookiePolicy();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areaRoute",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");
    endpoints.MapRazorPages();
});

app.Run();
