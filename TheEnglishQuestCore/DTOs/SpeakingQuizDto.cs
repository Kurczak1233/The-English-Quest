using System.Collections.Generic;

namespace TheEnglishQuestCore
{
    public class SpeakingQuizDto : QuizDto
    {
        public IEnumerable<SpeakingTaskDto> SpeakingTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Speaking";
    }
}
