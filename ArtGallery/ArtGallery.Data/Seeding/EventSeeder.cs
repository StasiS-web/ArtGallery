namespace ArtGallery.Data.Seeding
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Models.Enumeration;
    using ArtGallery.Data.Seeding.Contracts;
    using static ArtGallery.Common.GlobalConstants.Formating;

    public class EventSeeder : ISeeder
    {

        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.Events.Any())
            {
                return;
            }

            var events = new Event[]
            {
                new Event()
                {
                    Name = "Mythical Beasts Past & Present",
                    Price = 0.0M,
                    Date = DateTime.ParseExact(
                                "25.02.2022 12:30",
                                DateTimeFormat,
                                CultureInfo.InvariantCulture),
                    Type = EventType.Online,
                    ExhibitionHallId = (int)ExhibitionHallType.Small,
                    TicketType = TicketType.Free,
                    Description = "The lively and colourful beasts painted onto ceramic dishes featured in this show have been conceived as partners to the adjoining Myths & Monsters exhibition.",
                },
                new Event()
                {
                    Name = "International Women’s Day - Women in Art",
                    Price = 15M,
                    Date = DateTime.ParseExact(
                                "29.02.2022 13:00",
                                DateTimeFormat,
                                CultureInfo.InvariantCulture),
                    Type = EventType.Online,
                    ExhibitionHallId = (int)ExhibitionHallType.Small,
                    TicketType = TicketType.Paid,
                    Description = "The National Gallery is marking International Women’s Day and Women’s History Month with various online events celebrating women in the arts. Highlights include a forum exploring the way women artists have interacted with the national collection, and a lecture examining the role played by art historian Anna Jameson in the reception of Raphael's work in the 19th century.",
                },
                new Event()
                {
                    Name = "Contemporary Paintings,Sculpture & Ceramics",
                    Price = 10M,
                    Date = DateTime.ParseExact(
                                "12.03.2022 11:30",
                                DateTimeFormat,
                                CultureInfo.InvariantCulture),
                    Type = EventType.Online,
                    ExhibitionHallId = (int)ExhibitionHallType.Small,
                    TicketType = TicketType.Paid,
                    Description = "Exhibiting Artists include:  Sasha Constable,  Paul Wright,  Alice Cescatti",
                },
            };

            foreach (var eve in events)
            {
                await dbContext.AddAsync(eve);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
