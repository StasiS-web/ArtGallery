namespace ArtGallery.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Cloudinary.Contracts;
    using ArtGallery.Services.Data.Contracts;
    using ArtGallery.Services.Mapping;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.BlogPosts;
    using Microsoft.AspNetCore.Http;

    public class BlogPostService : IBlogPostsService
    {
        private readonly IAppRepository repo;
        //private readonly ICloudinaryService cloudinary;

        public BlogPostService(IAppRepository repo)
        {
            this.repo = repo;
            // this.cloudinary = cloudinary;
        }

        public async Task AddAsync(BlogPostViewModel model)
        {
            await this.repo.AddAsync(new BlogPostViewModel
            {
                Title = model.Title,
                Content = model.Content,
                Author = model.Author,
                UrlImage = model.UrlImage,
                UserReaction = model.UserReaction,
            });

            await this.repo.SaveChangesAsync();
        }

        public int AllBlogsCount()
        {
            return this.repo
                   .All<BlogPost>()
                   .Count();
        }

        public IEnumerable<BlogPostViewModel> GetAllBlogs()
        {
            return this.repo
                .All<BlogPost>()
                .To<BlogPostViewModel>()
                .ToList();
        }

        public async Task CreateBlogPostAsync(BlogPostCreateInputModel model)
        {
            await this.repo.AddAsync(new BlogPost
            {
                Title = model.Title,
                UrlImage = model.UrlImage,
                Content = model.Content,
                Author = model.Author,
            });

            await this.repo.SaveChangesAsync();
        }

        public IEnumerable<BlogPostViewModel> GetAll()
        {
            var blogList = repo.All<BlogPostViewModel>()
                 .OrderByDescending(b => b.CreatedOn)
                 .ToList();

            return blogList;
        }

        public IEnumerable<int> GetById<T>(int id)
        {
            var blogPost = this.repo
                    .All<BlogPostViewModel>()
                    .Where(x => x.BlogPostId == id)
                    .FirstOrDefault();

            return (IEnumerable<int>)blogPost;
        }

        public async Task<string> GetAuthorIdAsync(int postId)
        {
            var posts = this.repo
                .All<BlogPostViewModel>()
                .SingleOrDefault(p => p.BlogPostId == postId);

            return posts.Author;
        }

        public void Delete(int id)
        {
            var blogPost = this.repo
                .All<BlogPostViewModel>()
                .Where(x => x.BlogPostId == id)
                .FirstOrDefault();

            this.repo.Delete(blogPost);
            this.repo.SaveChanges();
        }
    }
}
