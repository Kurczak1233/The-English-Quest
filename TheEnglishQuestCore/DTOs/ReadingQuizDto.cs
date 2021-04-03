using System.Collections.Generic;

namespace TheEnglishQuestCore
{
    public class ReadingQuizDto : QuizDto
    {
        public IEnumerable<GrammarTaskDto> ReadingTasks { get; set; }
        public string Level { get; set; }
        public string Section { get; set; } = "Reading";
    }
}
