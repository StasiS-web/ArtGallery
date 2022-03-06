namespace ArtGallery.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using ArtGallery.Data.Common.Models.Contracts;
    using ArtGallery.Data.Models;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using static ArtGallery.Common.GlobalConstants.ArtStore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
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

        public DbSet<Event> Events { get; set; }

        public DbSet<ExhibitionHall> ExhibitionHalls { get; set; }

        public DbSet<ArtOrder> ArtsOrders { get; set; }

        public DbSet<EventOrder> EventsOrders { get; set; }

        public DbSet<SaleTransaction> SaleTransactions { get; set; }

        public DbSet<BookingTransaction> BookingTransactions { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Setting> Settings { get; set; } // Default from template

        public DbSet<Privacy> Privacies { get; set; }

        public DbSet<FaqEntity> Faqs { get; set; }

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

            // Needed for Entity with many-to-many relationship
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

            builder.Entity<ShoppingCart>()
                .Property(x => x.Id)
                .HasColumnName("Price")
                .HasColumnType("decimal");
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