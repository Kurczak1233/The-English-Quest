using System.ComponentModel.DataAnnotations.Schema;

namespace TheEnglishQuestDatabase
{
    public class ListeningTask : QuizTask
    {
        [ForeignKey("ListeningQuiz")]
        public int ListeningQuizId { get; set; }
        public virtual ListeningQuiz ListeningQuiz { get; set; }
        public string TaskType { get; set; }
    }
}
