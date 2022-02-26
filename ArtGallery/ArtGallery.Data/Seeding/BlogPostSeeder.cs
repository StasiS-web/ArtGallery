namespace ArtGallery.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;

    public class BlogPostSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            if (dbContext.BlogPosts.Any())
            {
                return;
            }

            var blogPosts = new BlogPost[]
            {
                new BlogPost
                {
                    Title = "Art in the Home",
                    Content = @"Most, but not all, of the art we sell on this site is destined for private homes.

There’s a 1964 ballad written by Bacharach and David – originally recorded by Dionne Warwick, which explains, “A house is not a home….”. In the case of art, I would claim that a house is not a home, until there is some on the walls or displayed within.

If you doubt me, why do all show homes and hotels, have paintings, or more likely prints, scattered about the rooms? Even the cheapest hotels will never have blank walls. It’s because, they hope to make you feel at home and more welcoming as a result.",
                    Author = "Humph Hack",
                },
                new BlogPost
                {
                    Title = "Paintings of Pets - Capturing Animal Spirit in Art",
                    Content = @"This week, pet owners show off their special animal friends on Love your Pet Day.

Studies have shown that owning a pet can increase your chances of being happy and successful. In fact, of 1,000 pet owners studied, researchers found that they brought laughter to six in 10 owners and made seven in 10 feel more relaxed.

As a nation of die-hard animal lovers, it’s not surprising our furry (and feathery and scaly) friends make us happy.

Animals are hugely popular subjects for artists, and why we have hundreds of paintings of all kinds of wildlife.

Pets in art
Dogs and horses have always been incredibly popular in the history of art.

Some of the earliest cave paintings ever discovered is of horses. Many years before horses were domesticated they were being carefully observed and recorded by humans.

Renaissance artists painted their subjects with their dogs. Dogs symbolised loyalty, faithfulness, protection and love. One of the most well-known and recognised being Velazquez’ ‘Las Meninas’ where a dog snoozes in the corner, or Jan Van Eyck’s Arnolfini marriage where a puppy is at the forefront of the painting.

Here's a modern cat-tastic take on the Arnolfini Portrait.",
                    Author = "Tara Paul",
                },
                new BlogPost
                {
                    Title = "Italian Art",
                    Content = @"Who doesn’t love Italy? Bellisima weather, bellisima landscapes and bellisima cuisine.

Offering a wealth of subject matter, it’s no surprise Italy is such a popular country for artists. Let’s also not forget that it’s considered to be the birthplace of ‘modern’ art, making it a place that has a strong heritage of creative inspiration.

Not only that, but Italy is also a popular holiday destination and a country people associate with sunshine, laughter and relaxation.

To help beat the January blues and give you that nice summer holiday feeling, we have a large selection of Italian art on our site, so you can capture that holiday moment in your own home forever.",
                    Author = "Tara Paul",
                },
            };

            foreach (var blogPost in blogPosts)
            {
                await dbContext.AddAsync(blogPost);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
