namespace ArtGallery.Core.Models.Administrator
{
    using System.ComponentModel.DataAnnotations;
    using static ArtGallery.Common.MessageConstants;
    using static ArtGallery.Common.GlobalConstants.FaqEntity;

    public class FaqEditViewModel
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
