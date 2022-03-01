namespace ArtGallery.Web.ViewModels.AdministrationInputModels
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.GlobalConstants.ErrorMessages;
    using static ArtGallery.Common.GlobalConstants.FaqEntity;

    public class FaqCreateInputModel
    {
        [Required(ErrorMessage = EmptyField)]
        [StringLength(QuestionMaxLength, MinimumLength = QuestionMinLength)]
        public string Question { get; set; }

        [Required(ErrorMessage = EmptyField)]
        [StringLength(AnswerMaxLength, MinimumLength = AnswerMinLength)]
        public string Answer { get; set; }
    }
}
