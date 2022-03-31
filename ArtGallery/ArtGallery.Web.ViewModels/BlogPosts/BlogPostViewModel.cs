namespace ArtGallery.Web.ViewModels.BlogPosts
{
    using System;
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;
    using AutoMapper;

    public class BlogPostViewModel : IMapFrom<BlogPost>, IHaveCustomMappings
    {
        public BlogPostViewModel()
        {
            this.Comments = new HashSet<BlogCommentViewModel>();
        }

        public int BlogId { get; set; }

        public string Title { get; set; }

        public string UrlImage { get; set; }

        public string Content { get; set; }

        public string ShortContect
        {
            get
            {
                var shortContent = this.Content;
                return shortContent.Length > 50
                    ? shortContent.Substring(0, 50) + "..."
                    : shortContent;
            }
        }

        // Blog Post are only created by the admin
        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Date => this.CreatedOn.ToShortDateString();

        public string UserReaction { get; set; }

        public ICollection<BlogCommentViewModel> Comments { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BlogPost, BlogPostViewModel>()
                .ForMember(b => b.Date, opt => opt.MapFrom(b => b.CreatedOn))
                .ForMember(b => b.Author, opt => opt.MapFrom(b => b.Author))
                .ForMember(b => b.UrlImage, opt => opt.MapFrom(b => b.UrlImage))
                .ForMember(b => b.UserReaction, opt => opt.MapFrom(b => b.UserReaction));
        }
    }
}
