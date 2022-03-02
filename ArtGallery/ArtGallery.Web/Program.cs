var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.Configure<CookiePolicyOptions>(
        options =>
        {
             options.CheckConsentNeeded = context => true;
             options.MinimumSameSitePolicy = SameSiteMode.None;
        });

// Cloudinary Setup
Account account = new Account(
                GlobalConstants.CloudName,
                builder.Configuration["Cloudinary:ApiKey"],
                builder.Configuration["Cloudinary:ApiSecret"]);
Cloudinary cloudinary = new Cloudinary(account);
cloudinary.Api.Secure = true;
builder.Services.AddSingleton(cloudinary);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsEnvironment("Docker"))
{
                app.UseDeveloperExceptionPage();
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

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
           name: "default",
           pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();