namespace ArtGallery.Web.ViewModels.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.FaqEntity;
    using static ArtGallery.Common.MessageConstants.ErrorMessages;

    public class FaqCreateInputModel
    {
        [Required(ErrorMessage = EmptyField)]
        [MinLength(QuestionMinLength)]
        [MaxLength(QuestionMaxLength)]
        public string Question { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [MinLength(AnswerMinLength)]
        [MaxLength(AnswerMaxLength)]
        public string Answer { get; set; }
    }
}
