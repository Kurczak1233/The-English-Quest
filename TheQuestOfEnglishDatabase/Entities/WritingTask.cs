using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class WritingTask : PlacementTestTask
    {
        [ForeignKey("WritingQuiz")]
        public int WritingQuizId { get; set; }
        public virtual WritingQuiz WritingQuiz { get; set; }
        public string TaskType { get; set; }
    }
}
