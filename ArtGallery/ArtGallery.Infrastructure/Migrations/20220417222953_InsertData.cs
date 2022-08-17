using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArtGallery.Infrastructure.Migrations
{
    public partial class InsertData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Arts",
                columns: new[] { "Id", "AuthorName", "CreatedOn", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "PaintingName", "Price", "ShoppingCartId", "UrlImage" },
                values: new object[,]
                {
                    { 1, "Anke Gruss", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Mr Peacock - an expressive take on the vibrancy and pride of our Peacock friends around the world. A print of a hand-painted piece created from acrylic paint completed with a metallic gold crescent. This vibrant Peacock would look fantastic in any room, particularly an entrance, bedroom or living room. This print would also make a great gift for any animal lover.", false, null, "Mr. Peacock", 4970m, null, "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821443/app_gallery/peacock-jpeg_d9gei3.jpg" },
                    { 2, "Van Gogh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "The Starry Night is an oil-on-canvas painting by the Dutch Post-Impressionist painter Vincent van Gogh. Painted in June 1889, it depicts the view from the east-facing window of his asylum room at Saint-Remy-de-Provence, just before sunrise, with the addition of an imaginary village.", false, null, "The Starry Night", 3270m, null, "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821452/app_gallery/The_Starry_Night-jpeg_ph9mxf.jpg" },
                    { 3, "William Merritt", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "We produce flawless giclee prints, thanks to the premium quality paper we use and our top-of-the-range 12 cartridge ink-jet printer. We use premium 270gsm luster/satin paper. This paper gives you the best of both worlds, as it is a hybrid of glossy and matte paper, you get the vibrancy of a gloss finish and the robustness of a matte paper. The paper we use is very durable and not vulnerable to fingerprints.", false, null, "Terrace, Prospect Park (1887)", 2100m, null, "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821445/app_gallery/Terrace_Prospect_Park_1887_-jpeg_uesqef.jpg" },
                    { 4, "Van Gogh", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vincent Van Gogh Wheat Field with Cypresses (1889) Art Print, Cypresses (1889) Art Print, Make a statement in any room with, this fine art poster, printed on thick, durable, matte paper. Add a wonderful, accent to your room and office with, these posters that are sure to brighten, any environment.", false, null, "Green Wheat Fields", 1500m, null, "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821441/app_gallery/Green_Wheat_Fields-jpeg_dzmndr.jpg" },
                    { 5, "Leonardo da Vinci", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Quality art reproductions, printed in our French Workshop since 2015. Our Art Reproductions are hangings in so many walls around the world.", false, null, "Portrait of Mona Lisa", 84m, null, "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1645821444/app_gallery/Portrait_of_Mona_Lisa-jpeg_jhvgpi.jpg" },
                    { 6, "Michiel van Huysum", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Vintage Italian coastal landscape oil painting. Muted tonal wall decor. Original c. 1800's", false, null, "Italian landscape", 60m, null, "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_300,w_300/v1646154562/app_gallery/landscape-jpeg_odeze0.jpg" },
                    { 7, "Michiel van Huysum", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "Beautiful print based on antique illustrations from 1780. Wonderful details, colors and natural history feel.", false, null, "Birds", 30m, null, "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--18fSIQ9v--/c_fit,h_400,w_400/v1648592592/app_gallery/y4PqRPqSako-unsplash_gzmv2d.jpg" }
                });

            migrationBuilder.InsertData(
                table: "BlogPosts",
                columns: new[] { "Id", "Author", "Content", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Title", "UrlImage", "UserReaction" },
                values: new object[,]
                {
                    { 1, "Humph Hack", "Most, but not all, of the art we sell on this site is destined for private homes. There's a 1964 ballad written by Bacharach and David originally recorded by Dionne Warwick, which explains, 'A house is not a home'. In the case of art, I would claim that a house is not a home, until there is some on the walls or displayed within. If you doubt me, why do all show homes and hotels, have paintings, or more likely prints, scattered about the rooms? Even the cheapest hotels will never have blank walls. It is because, they hope to make you feel at home and more welcoming as a result.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Art in the Home", "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_400,w_400/v1646156702/app_gallery/Artist_painting-jpeg_nn02fh.jpg", 0 },
                    { 2, "Tara Paul", "This week, pet owners show off their special animal friends on Love your Pet Day. Studies have shown that owning a pet can increase your chances of being happy and successful. In fact, of 1,000 pet owners studied, researchers found that they brought laughter to six in 10 owners and made seven in 10 feel more relaxed. As a nation of die-hard animal lovers, it's not surprising our furry (and feathery and scaly) friends make us happy. Animals are hugely popular subjects for artists, and why we have hundreds of paintings of all kinds of wildlife. Pets in art: Dogs and horses have always been incredibly popular in the history of art. Some of the earliest cave paintings ever discovered is of horses. Many years before horses were domesticated they were being carefully observed and recorded by humans. Renaissance artists painted their subjects with their dogs. Dogs symbolised loyalty, faithfulness, protection and love. One of the most well-known and recognised being Velazquez' 'Las Meninas' where a dog snoozes in the corner, or Jan Van Eyck's Arnolfini marriage where a puppy is at the forefront of the painting. Renaissance artists painted their subjects with their dogs. Dogs symbolised loyalty, faithfulness, protection and love. One of the most well-known and recognised being Velazquez' 'Las Meninas' where a dog snoozes in the corner, or Jan Van Eyck's Arnolfini marriage where a puppy is at the forefront of the painting. Here's a modern cat-tastic take on the Arnolfini Portrait.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Paintings of Pets - Capturing Animal Spirit in Art", "https://res.cloudinary.com/dnvg6uuxl/image/upload/c_fit,h_400,w_400/v1646157537/app_gallery/image-from-id-556828-jpeg_pvzrkd.jpg", 0 },
                    { 3, "Tara Paul", "Who doesn't love Italy? Bellisima weather, bellisima landscapes and bellisima cuisine. Offering a wealth of subject matter, it is no surprise Italy is such a popular country for artists. Let's also not forget that it is considered to be the birthplace of 'modern' art, making it a place that has a strong heritage of creative inspiration. Not only that, but Italy is also a popular holiday destination and a country people associate with sunshine, laughter and relaxation. To help beat the January blues and give you that nice summer holiday feeling, we have a large selection of Italian art on our site, so you can capture that holiday moment in your own home forever.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Italian Art", "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--eMTBpUc4--/c_fit,h_400,w_400/v1646156777/app_gallery/image-from-id-405327-jpeg_njsywp.jpg", 0 },
                    { 4, "Cassie Stephens", "Hi! I scored this amazing sweater recently and while I absolutely loved it, I hated the obnoxious plastic white buttons that were on the sweater. They just stuck out like a sore thumb! So I picked up some polymer clay at the craft store with the idea to create my own. Normally, I buy the 'name brand' polymer clay but this time, I was feeling cheap and decided to give the house brand a try. It was half the price and I have to say despite the fact that the yellow clay stained my hands a pinch, it worked great! I am used to stained hands so, no big deal!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Vincent Van Gogh Inspired Buttons And Earrings!", "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--GIhqN_we--/c_fit,h_400,w_400/v1648590618/app_gallery/arun-prakash-unsplash_tuluof.jpg", 0 },
                    { 5, "Ninja", "We all love to enjoy art. If you are one of them, you should think about following the best art blogs that are available out there to consider. Then you can secure getting a perfect experience out of those art blogs. In fact, you can rediscover your love for art and take your imagination to the next level with the help of art blogs. Reviewing the Top Art Websites and Blogs. Here is a list of 10 of the best art blogs available for anyone to follow in 2020. We believe that you will never end up with any regretful experience after following these art blogs. That's because the art blogs cover a variety of interesting topics and you can get a perfect experience out of them.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Best Art Blogs of 2022 - Artist Bloggers and Websites", "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--7d9hBVji--/c_fit,h_400,w_400/v1648591070/app_gallery/annie-spratt-unsplash_e2hv3u.jpg", 0 },
                    { 6, "Lachri", "If your acrylic paintings are looking too rough when you try to blend, try this tool to keep everything smooth! This tool will help keep your acrylic paints wet longer so that you have time to blend like you would in oil paints! I am showing you this tool in action to blend clouds in wet over dry vs drybrushing and again in a more advanced raccoon painting! We have all seen the beginner painting books that teach you to dry brush. Now there is a place for dry brushing, the problem is when you use it on everything and your painting ends up looking really rough. Fine if that is the look you are going for, but what if you want it to blend smoothly like an oil painting? I love oils, I love acrylics. If used right, you can't tell a difference between my oils and acrylics. That is a personal preference, you paint how you want, but if you want yours to look like mine, let me show you this tool along with a few very important warnings to help you get the best results!", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "This will make your acrylic paintings look like oils!", "https://res.cloudinary.com/dnvg6uuxl/image/upload/s--43NHpf2_--/c_fit,h_400,w_400/v1648592182/app_gallery/russn_fckr-unsplash_alixhl.jpg", 0 }
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "Confirmed", "CreatedOn", "Date", "DeletedOn", "Description", "IsDeleted", "ModifiedOn", "Name", "Price", "TicketSelection", "Type" },
                values: new object[,]
                {
                    { 1, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), null, "The lively and colourful beasts painted onto ceramic dishes featured in this show have been conceived as partners to the adjoining Myths & Monsters exhibition.", false, null, "Mythical Beasts Past and Present", 0.0m, 1, 2 },
                    { 2, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), null, "The National Gallery is marking International Women's Day and Women's History Month with various online events celebrating women in the arts. Highlights include a forum exploring the way women artists have interacted with the national collection, and a lecture examining the role played by art historian Anna Jameson in the reception of Raphael's work in the 19th century.", false, null, "Women in Art", 15m, 2, 2 },
                    { 3, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), null, "Exhibiting Artists include:  Sasha Constable,  Paul Wright,  Alice Cescatti", false, null, "Contemporary Paintings", 10m, 2, 2 },
                    { 4, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), null, "Let's visit Brooklyn and discover some of the finest street art in the world! WHAT WE'LL DO: Our experience will be broken up into five parts: 1: Transport to a coffee shop in Brooklyn filled with stunning artwork. There, we'll chat about what street art means to each of us. 2: Take a guided tour through East Williamsburg and view dozens of commissioned murals, some over 40 feet in size! I will share amazing stories from a mix of local and international artists. 3.Hop on a virtual subway ride to the Wall of Justice a new space devoted to a powerful art movement. Bonus: Get to see some 'creatures' on the train with unique artwork by Subway Doodle.", false, null, "Brooklyn Virtual Street Art Experience", 0.0m, 1, 2 },
                    { 5, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), null, "Art historian and author of Gardens of the Arts and Crafts Movement, Judith B. Tankard surveys the inspirations, characteristics and development of garden design during the Arts and Crafts Movement. Tankard presents a selection of houses and gardens from the era, with an emphasis on the diversity of designers who forge a special approach to garden design with illustrations and photographs of examples from Europe and North America.", false, null, "ART TALES: Yuki Aruga", 12m, 1, 1 },
                    { 6, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), null, "Discover an array of engaging installations, topical talks, hundreds of programmed events across amazing venues at Clerkenwell Design Week. This amazing independent design festival returns for its 11th edition. During this event, you'll have the chance to discover more than 200 exhibitors showcasing their captivating installations, talks and hundreds of programmed events. Whilst you're there feast upon the area's delicious array of food and drink choices.", false, null, "Art Fair", 12m, 2, 1 },
                    { 7, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), null, "The island of Puerto Rico, or 'La Isla del Encanto', and its people are products of a fusion of 3 distinct cultures: Indigenous Taino, Spanish, and African, resulting in cultural traditions that Puerto Ricans rightfully take pride in preserving.  The Contemporary Art Modern Project is pleased to present Views From El Barrio, an exhibition featuring works by NYC Puerto Rican, or Nuyorican, artists Elsie Deliz and Albert Justiniano.", false, null, "The Contemporary Art Modern Project Gallery", 25m, 2, 1 },
                    { 8, null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2022, 4, 18, 0, 0, 0, 0, DateTimeKind.Local), null, "The exhibition 'Art et Programmation', bringing together historical artists from the Denise Rene gallery and others from a younger generation, proposes a look at geometric abstraction through the notion of programming. Although it only officially appeared in the artistic landscape in 1962, with the exhibition 'Arte Programmata' in Italy, this notion covers aesthetic concerns whose sources are much earlier. It is present in filigree at the artists of the constructive avant-gardes who, aspiring to a form of universal art, depersonalize their creations, call for a connection between art and sciences.", false, null, "GALERIE DENISE RENE", 15m, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Faqs",
                columns: new[] { "Id", "Answer", "CreatedOn", "DeletedOn", "IsDeleted", "ModifiedOn", "Question" },
                values: new object[,]
                {
                    { 1, "We got three payment methods Debit/Credit card, Apple Pay or Google Pay.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "What payment menthods we are offering?" },
                    { 2, "The best time to visit our Gallery is our openning time or during our events. In regards of visiting any of our exhibition events you are required to purchase a ticket.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "What is the best time to visit us?" },
                    { 3, "It depends on the type of delivery. For Fast delivery we charge 3.95lev, but the Standart delivery for up to 5 day is free.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Do we charge for delivery?" },
                    { 4, "No, we don't deliver outside Bulgarian.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Do we made an international delivery?" },
                    { 5, "Gallery visitors may take non-flash photography for personal enjoymnet. Photos made for commercial use, wedding photos and formal distribution or sharing are not allowed.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Is photography permitted?" },
                    { 6, "Unfornatunately, we do not rent for private events to the general public. We only rent the Gallery to artist for exhibition purpose only where they can present their art.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Is the Gallery available for private event rentals?" },
                    { 7, "No we are not allowing dogs or any kind of pets inside the Art Gallery.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, null, "Are pets permitted in the GallerY?" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Arts",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "BlogPosts",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Events",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Faqs",
                keyColumn: "Id",
                keyValue: 7);
        }
    }
}
