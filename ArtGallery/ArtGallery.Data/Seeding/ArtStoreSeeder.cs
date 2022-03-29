namespace ArtGallery.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Seeding.Contracts;
    using static ArtGallery.Common.GlobalConstants.Images;

    public class ArtStoreSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Arts.Any())
            {
                return;
            }

            var arts = new ArtStore[]
            {
                new ArtStore
                {
                    PaintingName = "Mr. Peacock",
                    AuthorName = "Anke Gruss",
                    UrlImage = MrPeacock,
                    Price = 4970M,
                    Description = @"Majestically colored portrait of a peacock.",
                },
                new ArtStore
                {
                    PaintingName = "The Starry Night",
                    AuthorName = "Van Gogh",
                    UrlImage = TheStaryNight,
                    Price = 3270M,
                    Description = @"The Starry Night is an oil-on-canvas painting by the Dutch Post-Impressionist painter Vincent van Gogh. Painted in June 1889, it depicts the view from the east-facing window of his asylum room at Saint-Rémy-de-Provence, just before sunrise, with the addition of an imaginary village. ",
                },
                new ArtStore
                {
                    PaintingName = "Terrace, Prospect Park (1887)",
                    AuthorName = "William Merritt",
                    UrlImage = TerraceProspect,
                    Price = 2100M,
                    Description = @"Original from The Smithsonian.",
                },
                new ArtStore
                {
                    PaintingName = "Green Wheat Fields",
                    AuthorName = "Van Gogh",
                    UrlImage = GreeanWheatFields,
                    Price = 1500M,
                    Description = @"Original from The National Gallery of Art",
                },
                new ArtStore
                {
                    PaintingName = "Portrait of Mona Lisa",
                    AuthorName = "Leonardo da Vinci",
                    UrlImage = MonaLisa,
                    Price = 840M,
                    Description = @"A portrait famous painting.",
                },
                new ArtStore
                {
                    PaintingName = "Italianizing landscape",
                    AuthorName = " Michiel van Huysum ",
                    UrlImage = Landscape,
                    Price = 650M,
                    Description = @"The Rijksmuseum.",
                },
                new ArtStore
                {
                    PaintingName = "Birds",
                    AuthorName = " Michiel van Huysum ",
                    UrlImage = SingingBirds,
                    Price = 450M,
                    Description = @"Featured in Editorial",
                },
            };

            foreach (var art in arts)
            {
                await dbContext.AddAsync(art);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
