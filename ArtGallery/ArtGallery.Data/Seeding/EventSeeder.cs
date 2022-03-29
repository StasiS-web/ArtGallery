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
                    TicketSelection = TicketType.Free,
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
                    ExhibitionHallId = (int)ExhibitionHallType.Medium,
                    TicketSelection = TicketType.Paid,
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
                    TicketSelection = TicketType.Paid,
                    Description = "Exhibiting Artists include:  Sasha Constable,  Paul Wright,  Alice Cescatti",
                },
                new Event()
                {
                    Name = "Brooklyn Virtual Street Art Experience",
                    Price = 0.0M,
                    Date = DateTime.ParseExact(
                                "13.03.2022 11:30",
                                DateTimeFormat,
                                CultureInfo.InvariantCulture),
                    Type = EventType.Online,
                    ExhibitionHallId = (int)ExhibitionHallType.Large,
                    TicketSelection = TicketType.Free,
                    Description = "Let’s visit Brooklyn and discover some of the finest street art in the world! WHAT WE'LL DO: Our experience will be broken up into five parts: 1: Transport to a coffee shop in Brooklyn filled with stunning artwork.There, we’ll chat about what street art means to each of us. 2: Take a guided tour through East Williamsburg and view dozens of commissioned murals, some over 40 feet in size! I’ll share amazing stories from a mix of local and international artists. 3.Hop on a virtual subway ride to the Wall of Justice– a new space devoted to a powerful art movement.Bonus: Get to see some ‘creatures’ on the train with unique artwork by Subway Doodle.",
                },
                new Event()
                {
                    Name = "ART TALES: Yuki Aruga",
                    Price = 12.0M,
                    Date = DateTime.ParseExact(
                                "14.03.2022 12:30",
                                DateTimeFormat,
                                CultureInfo.InvariantCulture),
                    Type = EventType.InPerson,
                    ExhibitionHallId = (int)ExhibitionHallType.Small,
                    TicketSelection = TicketType.Paid,
                    Description = "Yuki's sensitive and stunningly rendered still lifes are sumptuous in their detail and mastery of medium, with elements of Memento Mori and Vantias paintings undated with a darkly contemporary twist. We can't wait to have Yuki on the program to talk through her work and processes with us - this will be a rare treat so don't miss out!",
                },
                new Event()
                {
                    Name = "Gardens of the Arts and Crafts Movement",
                    Price = 0.0M,
                    Date = DateTime.ParseExact(
                                "15.03.2022 16:00",
                                DateTimeFormat,
                                CultureInfo.InvariantCulture),
                    Type = EventType.Online,
                    ExhibitionHallId = (int)ExhibitionHallType.Small,
                    TicketSelection = TicketType.Free,
                    Description = "Art historian and author of Gardens of the Arts and Crafts Movement, Judith B. Tankard surveys the inspirations, characteristics and development of garden design during the Arts and Crafts Movement. Tankard presents a selection of houses and gardens from the era, with an emphasis on the diversity of designers who forge a special approach to garden design – with illustrations and photographs of examples from Europe and North America.",
                },
                new Event()
                {
                    Name = "Art Fair",
                    Price = 12M,
                    Date = DateTime.ParseExact(
                                "23.03.2022 14:00",
                                DateTimeFormat,
                                CultureInfo.InvariantCulture),
                    Type = EventType.InPerson,
                    ExhibitionHallId = (int)ExhibitionHallType.Medium,
                    TicketSelection = TicketType.Paid,
                    Description = "Discover an array of engaging installations, topical talks, hundreds of programmed events across amazing venues at Clerkenwell Design Week. This amazing independent design festival returns for its 11th edition. During this event, you'll have the chance to discover more than 200 exhibitors showcasing their captivating installations, talks and hundreds of programmed events. Whilst you're there feast upon the area’s delicious array of food and drink choices.",
                },
                new Event()
                {
                    Name = "The Contemporary Art Modern Project Gallery",
                    Price = 25M,
                    Date = DateTime.ParseExact(
                                "01.04.2022 11:00",
                                DateTimeFormat,
                                CultureInfo.InvariantCulture),
                    Type = EventType.InPerson,
                    ExhibitionHallId = (int)ExhibitionHallType.Large,
                    TicketSelection = TicketType.Paid,
                    Description = "The island of Puerto Rico, or “La Isla del Encanto”, and its people are products of a fusion of 3 distinct cultures: Indigenous Taino, Spanish, and African, resulting in cultural traditions that Puerto Ricans rightfully take pride in preserving.  The Contemporary Art Modern Project is pleased to present Views From El Barrio, an exhibition featuring works by NYC Puerto Rican, or Nuyorican, artists Elsie Deliz and Albert Justiniano.",
                },
                new Event()
                {
                    Name = "GALERIE DENISE RENÉ",
                    Price = 15M,
                    Date = DateTime.ParseExact(
                                "28.03.2022 09:00",
                                DateTimeFormat,
                                CultureInfo.InvariantCulture),
                    Type = EventType.InPerson,
                    ExhibitionHallId = (int)ExhibitionHallType.Medium,
                    TicketSelection = TicketType.Paid,
                    Description = "The exhibition 'Art et Programmation', bringing together historical artists from the Denise René gallery and others from a younger generation, proposes a look at geometric abstraction through the notion of programming. Although it only officially appeared in the artistic landscape in 1962, with the exhibition "Arte Programmata" in Italy, this notion covers aesthetic concerns whose sources are much earlier. It is present in filigree at the artists of the constructive avant-gardes who, aspiring to a form of universal art, depersonalize their creations, call for a connection between art and sciences.",
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
