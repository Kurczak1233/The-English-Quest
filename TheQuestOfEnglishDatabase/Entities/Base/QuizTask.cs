using System.ComponentModel.DataAnnotations;

namespace TheEnglishQuestDatabase
{
    public abstract class QuizTask
    {
        [Key]
        public int Id { get; set; }
        public string QuestionFirstPart { get; set; }
        public string QuestionDecoratedPart { get; set; }
        public string QuestionSecondPart { get; set; }
        public string FirstAnswear { get; set; }
        public string SecondAnswear { get; set; }
        public string ThirdAnswear { get; set; }
        public string FourthAnswear { get; set; }
        [Required]
        public string CorrectAnswear { get; set; }
    }
}
