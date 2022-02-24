namespace ArtGallery.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using ArtGallery.Data.Common.Models;
    using static ArtGallery.Common.GlobalConstants.FaqEntity;

    public class FaqEntity : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(QuestionMaxLength)]
        public string Question { get; set; }

        [Required]
        [MaxLength(AnswerMaxLength)]
        public string Answer { get; set; }
    }
}
