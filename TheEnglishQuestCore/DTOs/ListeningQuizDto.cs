using System.Collections.Generic;

namespace TheEnglishQuestCore
{
    public class ListeningQuizDto : QuizDto
    {
        public IEnumerable<ListeningTaskDto> ListeningTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Listening";
    }
}
