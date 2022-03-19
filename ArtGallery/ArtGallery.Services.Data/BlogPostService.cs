namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Services.Mapping;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.BlogPosts;

    public class BlogPostService : IBlogPostService
    {
        private readonly IAppRepository blogRepo;

        public BlogPostService(IAppRepository blogRepo)
        {
            this.blogRepo = blogRepo;
        }

        public async Task AddAsync(BlogPostViewModel model)
        {
            await this.blogRepo.AddAsync(new BlogPost
            {
                Title = model.Title,
                Content = model.Content,
                Author = model.Author,
                UrlImage = model.UrlImage.ToString(),
                UserReaction = model.UserReaction,
            });

            await this.blogRepo.SaveChangesAsync();
        }

        public int AllBlogsCount()
        {
            return this.blogRepo
                   .All<BlogPost>()
                   .Count();
        }

        public IEnumerable<BlogPostViewModel> GetAllBlogs()
        {
            return this.blogRepo
                .All<BlogPost>()
                .To<BlogPostViewModel>()
                .ToList();
        }

        public IEnumerable<BlogPostViewModel> GetAll()
        {
            var blogList = blogRepo.All<BlogPostViewModel>()
                 .OrderByDescending(b => b.CreatedOn)
                 .ToList();

            return blogList;
        }

        public IEnumerable<int> GetById<T>(int id)
        {
            var blogPost = this.blogRepo
                    .All<BlogPostViewModel>()
                    .Where(x => x.Id == id)
                    .FirstOrDefault();

            return (IEnumerable<int>)blogPost;
        }

        public async Task<string> GetAuthorIdAsync(int postId)
        {
            var posts = this.blogRepo
                .All<BlogPostViewModel>()
                .SingleOrDefault(p => p.Id == postId);

            return posts.Author;
        }
    }
}
