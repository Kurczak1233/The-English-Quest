using System.ComponentModel.DataAnnotations;

namespace The_quest_of_English.Models
{
    public class QuestionModelInput
    {
        [Required]
        [StringLength(400, ErrorMessage = "The question can contain only 400 signs!")]
        public string QuestionFirstPart { get; set; }
        [StringLength(100, ErrorMessage = "The decoration part can contain only 100 signs!")]
        public string QuestionDecoratedPart { get; set; }
        [StringLength(400, ErrorMessage = "The question can contain only 400 signs!")]
        public string QuestionSecondPart { get; set; }
    }
}
