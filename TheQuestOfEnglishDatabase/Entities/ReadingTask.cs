using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class ReadingTask : QuizTask
    {

        [ForeignKey("ReadingQuiz")]
        public int ReadingQuizId { get; set; }
        public virtual ReadingQuiz ReadingQuiz { get; set; }
        public string TaskType { get; set; }
    }
}
