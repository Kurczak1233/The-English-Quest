using System.ComponentModel.DataAnnotations;

namespace TheEnglishQuestDatabase
{
    public class PlacementTestTask
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string QuestionFirstPart { get; set; }
        public string QuestionDecoratedPart { get; set; }
        public string QuestionSecondPart { get; set; }
        [Required]
        public string FirstAnswear { get; set; }
        [Required]
        public string SecondAnswear { get; set; }
        [Required]
        public string ThirdAnswear { get; set; }
        public string FourthAnswear { get; set; }
        [Required]
        public string CorrectAnswear { get; set; }
    }
}
