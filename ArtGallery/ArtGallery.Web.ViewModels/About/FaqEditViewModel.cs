namespace ArtGallery.Web.ViewModels.About
{
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Data.Models;
    using ArtGallery.Services.Mapping.Contracts;
    using static ArtGallery.Common.GlobalConstants.FaqEntity;
    using static ArtGallery.Common.MessageConstants;

    public class FaqEditViewModel : IMapFrom<FaqEntity>
    {
        public int FaqId { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [MaxLength(QuestionMaxLength)]
        [MinLength(QuestionMinLength)]
        public string Question { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [MaxLength(AnswerMaxLength)]
        [MinLength(AnswerMinLength)]
        public string Answer { get; set; }
    }
}
