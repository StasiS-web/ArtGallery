﻿namespace ArtGallery.Web.ViewModels.BlogPosts
{
    public class BlogCommentInputViewModel
    {
        public int BlogPostId { get; set; }

        public string BlogPost { get; set; }

        public string CommentContent { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }
    }
}
