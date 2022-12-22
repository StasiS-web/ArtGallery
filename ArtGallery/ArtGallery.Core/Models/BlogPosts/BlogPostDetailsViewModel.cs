using ArtGallery.Core.Mapping.Contracts;
using ArtGallery.Infrastructure.Data.Models;
using ArtGallery.Infrastructure.Data.Models.Enumeration;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtGallery.Core.Models.BlogPosts
{
    public class BlogPostDetailsViewModel : IMapFrom<BlogPost>, IHaveCustomMappings
    {
        public int BlogId { get; set; }
        public string Title { get; set; }
        public IFormFile UrlImage { get; set; }
        public string UrlImageStr { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }

        public IEnumerable<BlogCommentViewModel> BlogComments { get; set; }

        public IEnumerable<ReactionType> UserReactionsPost { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<BlogPost, BlogPostDetailsViewModel>()
                .ForMember(x => x.UserReactionsPost, options =>
                {
                    options.MapFrom(m => m.UserReaction);
                });
        }
    }
}
