namespace ArtGallery.Data
{
    using System.Linq;
    using ArtGallery.Data.Common.Models.Contarcts;
    using Microsoft.EntityFrameworkCore;

    internal static class EntityIndexesConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            // IDeletableEntity.IsDeleted index
            var deletableEntityTypes = modelBuilder
                .Model
                .GetEntityTypes()
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));

            foreach (var deletableEntityType in deletableEntityTypes)
            {
                modelBuilder
                    .Entity(deletableEntityType.ClrType)
                    .HasIndex(nameof(IDeletableEntity.IsDeleted));
            }
        }
    }
}
