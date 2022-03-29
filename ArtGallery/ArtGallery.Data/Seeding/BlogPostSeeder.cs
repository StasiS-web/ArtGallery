namespace ArtGallery.Data.Seeding
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Seeding.Contracts;
    using static ArtGallery.Common.GlobalConstants.Images;

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
                    UrlImage = ArtisticPainter,
                    Content = @"Most, but not all, of the art we sell on this site is destined for private homes.

There’s a 1964 ballad written by Bacharach and David – originally recorded by Dionne Warwick, which explains, “A house is not a home….”. In the case of art, I would claim that a house is not a home, until there is some on the walls or displayed within.

If you doubt me, why do all show homes and hotels, have paintings, or more likely prints, scattered about the rooms? Even the cheapest hotels will never have blank walls. It’s because, they hope to make you feel at home and more welcoming as a result.",
                    Author = "Humph Hack",
                },
                new BlogPost
                {
                    Title = "Paintings of Pets - Capturing Animal Spirit in Art",
                    UrlImage = AnimalSpirits,
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
                    UrlImage = Art,
                    Content = @"Who doesn’t love Italy? Bellisima weather, bellisima landscapes and bellisima cuisine.

Offering a wealth of subject matter, it’s no surprise Italy is such a popular country for artists. Let’s also not forget that it’s considered to be the birthplace of ‘modern’ art, making it a place that has a strong heritage of creative inspiration.

Not only that, but Italy is also a popular holiday destination and a country people associate with sunshine, laughter and relaxation.

To help beat the January blues and give you that nice summer holiday feeling, we have a large selection of Italian art on our site, so you can capture that holiday moment in your own home forever.",
                    Author = "Tara Paul",
                },
                new BlogPost
                {
                    Title = "Vincent Van Gogh Inspired Buttons And Earrings!",
                    UrlImage = Buttons,
                    Content = @"Hi! I scored this amazing sweater recently and while I absolutely loved it, I hated the obnoxious plastic white buttons that were on the sweater. They just stuck out like a sore thumb! So I picked up some polymer clay at the craft store with the idea to create my own. Normally, I buy the 'name brand' polymer clay but this time, I was feeling cheap and decided to give the house brand a try. It was half the price and I have to say...despite the fact that the yellow clay stained my hands a pinch, it worked great! I'm used to stained hands so, no big deal!",
                    Author = "Cassie Stephens",
                },
                new BlogPost
                {
                    Title = "Best Art Blogs of 2022 – Artist Bloggers and Websites",
                    UrlImage = BestArt,
                    Content = @"We all love to enjoy art. If you are one of them, you should think about following the best art blogs that are available out there to consider. Then you can secure getting a perfect experience out of those art blogs. In fact, you can rediscover your love for art and take your imagination to the next level with the help of art blogs.
                              Reviewing the Top Art Websites and Blogs
                              Here is a list of 10 of the best art blogs available for anyone to follow in 2020. We believe that you will never end up with any regretful experience after following these art blogs. That’s because the art blogs cover a variety of interesting topics and you can get a perfect experience out of them.",
                    Author = "Blog Ninja",
                },
                new BlogPost
                {
                    Title = "This will make your acrylic paintings look like oils!",
                    UrlImage = AcrylicPainting,
                    Content = @"If your acrylic paintings are looking too rough when you try to blend, try this tool to keep everything smooth! This tool will help keep your acrylic paints wet longer so that you have time to blend like you would in oil paints! I’m showing you this tool in action to blend clouds in wet over dry vs drybrushing and again in a more advanced raccoon painting!
                              We’ve all seen the beginner painting books that teach you to dry brush. Now there is a place for dry brushing, the problem is when you use it on EVERYTHING and your painting ends up looking really rough. Fine if that’s the look you’re going for, but what if you want it to blend smoothly like an oil painting?
                              I love oils, I love acrylics. If used right, you can’t tell a difference between my oils and acrylics. That is a personal preference, you paint how you want, but if you want yours to look like mine, let me show you this tool along with a few VERY important warnings to help you get the best results! ",
                    Author = "Lachri",
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
