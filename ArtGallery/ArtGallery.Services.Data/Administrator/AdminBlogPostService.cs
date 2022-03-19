namespace ArtGallery.Services.Data.Administrator
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ArtGallery.Data.Models;
    using ArtGallery.Data.Repositories.Contracts;
    using ArtGallery.Services.Data.Administrator.Contracts;
    using ArtGallery.Web.ViewModels.Administrator;
    using ArtGallery.Web.ViewModels.BlogPosts;

    public class AdminBlogPostService : IAdminBlogPostService
    {
        private readonly IAppRepository blogRepo;

        public AdminBlogPostService(IAppRepository blogRepo)
        {
            this.blogRepo = blogRepo;
        }

        public async Task CreateBlogPostAsync(BlogPostCreateInputModel model)
        {
            await this.blogRepo.AddAsync(new BlogPostViewModel
            {
                Title = model.Title,
                UrlImage = model.UrlImage,
                Content = model.Content,
                Author = model.Author,
            });

            await this.blogRepo.SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var blogPost = this.blogRepo
                .All<BlogPostViewModel>()
                .Where(x => x.Id == id)
                .FirstOrDefault();

            this.blogRepo.Delete(blogPost);
            this.blogRepo.SaveChanges();
        }
    }
}
