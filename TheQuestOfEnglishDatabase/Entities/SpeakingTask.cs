using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class SpeakingTask : QuizTask
    {
        [ForeignKey("SpeakingQuiz")]
        public int SpeakingQuizId { get; set; }
        public virtual SpeakingQuiz SpeakingQuiz { get; set; }
        public string TaskType { get; set; }

    }
}
