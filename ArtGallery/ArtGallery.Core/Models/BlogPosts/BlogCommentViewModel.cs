﻿namespace ArtGallery.Core.Models.BlogPosts
{
    public class BlogCommentViewModel 
    {
        public int CommentId { get; set; }

        public string BlogPostId { get; set; }

        public string BlogPost { get; set; }

        public string CommentContent { get; set; }

        public string UserId { get; set; }

        public string User { get; set; }
    }
}
