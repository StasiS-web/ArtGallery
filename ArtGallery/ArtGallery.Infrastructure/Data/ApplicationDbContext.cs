using System.Runtime.CompilerServices;

namespace ArtGallery.Infrastructure.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using ArtGallery.Infrastructure.Data.Common.Models.Contracts;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Seeding;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet represent each table entity in the database
        public DbSet<BlogPost> BlogPosts { get; set; }

        public DbSet<BlogComment> Comments { get; set; }

        public DbSet<ArtStore> Arts { get; set; }

        public DbSet<ExhibitionHall> ExhibitionHalls { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<ArtOrder> ArtsOrders { get; set; }

        public DbSet<EventOrder> EventsOrders { get; set; }

        public DbSet<SaleTransaction> SaleTransactions { get; set; }

        public DbSet<BookingTransaction> BookingTransactions { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ContactForm> Contacts { get; set; }

        public DbSet<Setting> Settings { get; set; } // Default from template

        public DbSet<Privacy> Privacies { get; set; }

        public DbSet<FaqEntity> Faqs { get; set; }

        public DbSet<ArtGalleryUser> ArtGalleryUser { get; set; }

        public override int SaveChanges() => this.SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            this.SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            this.ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            this.ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }

            // Entity Configuration
            builder.Entity<BlogComment>()
                .HasKey(x => new { x.BlogPostId, x.UserId });

            builder.Entity<ArtOrder>()
                .HasKey(x => new { x.UserId, x.ArtId });

            builder.Entity<EventOrder>()
                .HasKey(x => new { x.EventId, x.UserId });

            builder.Entity<SaleTransaction>()
                .HasKey(x => new { x.ArtId, x.UserId });

            builder.Entity<BookingTransaction>()
                .HasKey(x => new { x.EventId, x.UserId });

           // builder.Entity<IdentityUserRole<string>>()
            //    .HasKey(x => new { x.UserId, x.RoleId });

            // Proprerty Configuration
            builder.Entity<ShoppingCart>()
                .Property(x => x.Id)
                .HasColumnName("TotalPrice")
                .HasColumnName("Price")
                .HasColumnType("decimal");

            // Initial Data Seed
            //  builder.ApplyConfiguration(new InitialDataSeed<BlogPost>(@"DataSeed/blog.json"));
            //  builder.ApplyConfiguration(new InitialDataSeed<ArtStore>(@"DataSeed/arts.json"));
            //  builder.ApplyConfiguration(new InitialDataSeed<Event>(@"DataSeed/events.json"));
            //  builder.ApplyConfiguration(new InitialDataSeed<FaqEntity>(@"DataSeed/faqs.json"));

            // Code change by behaviour.
            builder.Entity<BlogPost>().HasData(SeedUserData<BlogPost>(@"DataSeed/blog.json"));
            builder.Entity<ArtStore>().HasData(SeedUserData<ArtStore>(@"DataSeed/arts.json"));
            builder.Entity<Event>().HasData(SeedUserData<Event>(@"DataSeed/events.json"));
            builder.Entity<FaqEntity>().HasData(SeedUserData<FaqEntity>(@"DataSeed/faqs.json"));
        }

        public List<T> SeedUserData<T>(string filePath) where T : class
        {
            var model = new List<T>();
            using (StreamReader r = new StreamReader(filePath))
            {
                string json = r.ReadToEnd();
                model = JsonConvert.DeserializeObject<List<T>>(json);
            }
            return model;
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
       private void ConfigureUserIdentityRelations(ModelBuilder builder)
            => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}