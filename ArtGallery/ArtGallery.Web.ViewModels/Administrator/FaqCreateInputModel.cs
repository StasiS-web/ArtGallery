namespace ArtGallery.Web.ViewModels.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.FaqEntity;
    using static ArtGallery.Common.MessageConstants;

    public class FaqCreateInputModel
    {
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
