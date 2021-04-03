using System.Collections.Generic;

namespace TheEnglishQuestCore
{
    public class WritingQuizDto : QuizDto
    {
        public IEnumerable<WritingTaskDto> WritingTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Writing";
    }
}
