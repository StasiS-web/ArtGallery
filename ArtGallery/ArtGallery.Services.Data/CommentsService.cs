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
    using ArtGallery.Web.ViewModels.BlogPosts;

    public class CommentsService : ICommentsService
    {
        private readonly IAppRepository commentsRepo;

        public CommentsService(IAppRepository commentsRepo)
        {
            this.commentsRepo = commentsRepo;
        }

        public async Task CreateAsync(int commentId, int blogPostId, string userId, string content)
        {
            await this.commentsRepo.AddAsync(new BlogComment
            {
                Id = commentId,
                BlogPostId = blogPostId,
                CommentContent = content,
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
            });

            await this.commentsRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var commnets = this.commentsRepo
                              .All<BlogComment>()
                              .Where(x => x.Id == id)
                              .FirstOrDefault();

            this.commentsRepo.Delete(commnets);
            await this.commentsRepo.SaveChangesAsync();
        }

        public async Task<string> GetBlogIdByCommentsAsync(int commentId)
        {
            return this.commentsRepo
                .All<BlogCommentViewModel>()
                .FirstOrDefault(c => c.CommentId == commentId)
                .BlogPostId;
        }
    }
}
