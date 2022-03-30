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
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Microsoft.EntityFrameworkCore;
    using static ArtGallery.Common.MessageConstants;

    public class BlogPostService : IBlogPostService
    {
        private readonly IAppRepository blogRepo;
        private readonly IConfigurationProvider mapper;
        private readonly ICloudinaryService cloudinary;

        public BlogPostService(IAppRepository blogRepo, ICloudinaryService cloudinary, IConfigurationProvider mapper)
        {
            this.blogRepo = blogRepo;
            this.cloudinary = cloudinary;
            this.mapper = mapper;
        }

        public async Task<int> CreateBlogPostAsync(BlogPostCreateInputModel model, string user)
        {
            var coverImage = this.cloudinary.UploadImageAsync(model.CoverImage, model.Title);

            var blog = new BlogPost
            {
                Title = model.Title,
                UrlImage = coverImage,
                Content = model.Content,
                Author = user, // only if user is an Administrator
            };

            bool isPostExist = this.blogRepo.All<BlogPost>().Any(x => x.Title == model.Title);

            if (isPostExist)
            {
                throw new ArgumentException(string.Format(BlogPostAlredyExists, model.Title));
            }

            await this.blogRepo.AddAsync(blog);
            await this.blogRepo.SaveChangesAsync();
            return blog.Id;
        }

        public async Task<int> EditBlog(BlogPostEditViewModel model, int blogId)
        {
            var blog = this.blogRepo.All<BlogPost>()
                        .FirstOrDefault(b => b.Id == blogId);

            if (blog == null)
            {
                throw new ArgumentNullException(string.Format(NonExistingPost, $"{blogId}"));
            }

            blog.Title = model.Title;
            blog.Content = model.Content;
            blog.UrlImage = model.UrlImage;

            this.blogRepo.Update(blog);
            await this.blogRepo.SaveChangesAsync();

            return blog.Id;
        }

        public void Delete(int id)
        {
            var blogPost = this.blogRepo
                .All<BlogPostViewModel>()
                .Where(x => x.BlogId == id)
                .FirstOrDefault();

            if (blogPost == null)
            {
                throw new ArgumentNullException(string.Format(NonExistingPost, $"{id}"));
            }

            this.blogRepo.Delete(blogPost);
            this.blogRepo.SaveChanges();
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

        public async Task<IEnumerable<T>> GetAll<T>(int? sortId, int blogId)
        {
            var blog = this.blogRepo.All<BlogPostViewModel>().OrderByDescending(x => x.CreatedOn);

            if (sortId != null)
            {
                blog = (IOrderedQueryable<BlogPostViewModel>)blog.Where(x => x.BlogId == sortId);
            }

            return await blog.Skip(blogId - 1).To<T>().ToListAsync();
        }

        public IEnumerable<int> GetById<T>(int blogId)
        {
            var blogPost = this.blogRepo
                    .All<BlogPostViewModel>()
                    .Where(x => x.BlogId == blogId)
                    .FirstOrDefault();

            return (IEnumerable<int>)blogPost;
        }

        public async Task<string> GetAuthorIdAsync(int blogId)
        {
            var posts = this.blogRepo
                .All<BlogPostViewModel>()
                .SingleOrDefault(p => p.BlogId == blogId);

            return posts.Author;
        }

        public async Task<T> GetBlogPostDetailsByIdAsync<T>(int blogId)
        {
            var blogPost = this.blogRepo
                            .All<BlogPostViewModel>()
                            .Where(b => b.BlogId == blogId)
                            .To<T>()
                            .FirstOrDefault();

            return blogPost;
        }

        public async Task<IEnumerable<BlogPostViewModel>> GetLatestBlogAsync(int blogId)
        {
           return this.blogRepo.All<BlogPostViewModel>()
                               .Where(b => b.BlogId == blogId)
                               .OrderByDescending(b => b.CreatedOn)
                               .ProjectTo<BlogPostViewModel>(this.mapper)
                               .Take(5)
                               .ToList();
        }

        public async Task<bool> BlogPostExists(int blogId) => this.blogRepo
                                .All<BlogPostViewModel>()
                                .Any(b => b.BlogId == blogId);
    }
}
