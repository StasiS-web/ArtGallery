namespace ArtGallery.Core.Services
{
    using ArtGallery.Core.Contracts;
    using ArtGallery.Core.Models.BlogPosts;
    using ArtGallery.Infrastructure.Data.Models;
    using ArtGallery.Infrastructure.Data.Repositories;

    public class CommentsService : ICommentsService
    {
        private readonly IAppRepository _commentsRepo;

        public CommentsService(IAppRepository commentsRepo)
        {
            this._commentsRepo = commentsRepo;
        }

        public async Task CreateAsync(int commentId, int blogPostId, string userId, string content)
        {
            await this._commentsRepo.AddAsync(new BlogComment
            {
                Id = commentId,
                BlogPostId = blogPostId,
                CommentContent = content,
                CreatedOn = DateTime.UtcNow,
                UserId = userId,
            });

            await this._commentsRepo.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var commnets = this._commentsRepo
                              .All<BlogComment>()
                              .Where(x => x.Id == id)
                              .FirstOrDefault();

            this._commentsRepo.Delete(commnets);
            await this._commentsRepo.SaveChangesAsync();
        }

        public async Task<string> GetBlogIdByCommentsAsync(int commentId)
        {
            return this._commentsRepo
                .All<BlogCommentViewModel>()
                .FirstOrDefault(c => c.CommentId == commentId)
                .BlogPostId;
        }
    }
}
